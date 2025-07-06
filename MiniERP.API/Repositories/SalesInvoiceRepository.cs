using Microsoft.EntityFrameworkCore;
using MiniERP.API.Data;
using MiniERP.API.Models;
using System.Linq.Expressions;

namespace MiniERP.API.Repositories
{
    public class SalesInvoiceRepository : GenericRepository<SalesInvoice>, ISalesInvoiceRepository
    {
        public SalesInvoiceRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<(IEnumerable<SalesInvoice> Items, int TotalCount)> GetPagedWithCountAsync(int pageNumber, int pageSize, 
            Expression<Func<SalesInvoice, bool>>? filter = null, Expression<Func<SalesInvoice, object>>? orderBy = null, bool ascending = true)
        {
            IQueryable<SalesInvoice> query = _dbSet
                .Include(si => si.CariAccount)
                .Include(si => si.Warehouse);

            if (filter != null)
                query = query.Where(filter);

            var totalCount = await query.CountAsync();

            if (orderBy != null)
            {
                query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
            }
            else
            {
                // Varsayılan sıralama: Fatura tarihine göre azalan
                query = query.OrderByDescending(si => si.InvoiceDate);
            }

            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (items, totalCount);
        }

        public async Task<SalesInvoice?> GetByInvoiceNoAsync(string invoiceNo)
        {
            return await _dbSet
                .Include(si => si.CariAccount)
                .Include(si => si.Warehouse)
                .Include(si => si.SalesInvoiceDetails)
                .ThenInclude(sid => sid.Product)
                .FirstOrDefaultAsync(si => si.InvoiceNo == invoiceNo);
        }

        public async Task<SalesInvoice?> GetInvoiceWithDetailsAsync(int invoiceId)
        {
            return await _dbSet
                .Include(si => si.CariAccount)
                .Include(si => si.Warehouse)
                .Include(si => si.SalesInvoiceDetails)
                .ThenInclude(sid => sid.Product)
                .ThenInclude(p => p.Unit)
                .FirstOrDefaultAsync(si => si.InvoiceID == invoiceId);
        }

        public async Task<IEnumerable<SalesInvoice>> GetInvoicesByCariAsync(int cariId)
        {
            return await _dbSet
                .Include(si => si.CariAccount)
                .Include(si => si.Warehouse)
                .Where(si => si.CariID == cariId)
                .OrderByDescending(si => si.InvoiceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesInvoice>> GetInvoicesByStatusAsync(string status)
        {
            return await _dbSet
                .Include(si => si.CariAccount)
                .Include(si => si.Warehouse)
                .Where(si => si.Status == status)
                .OrderByDescending(si => si.InvoiceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesInvoice>> GetDraftInvoicesAsync()
        {
            return await GetInvoicesByStatusAsync("DRAFT");
        }

        public async Task<IEnumerable<SalesInvoice>> GetApprovedInvoicesAsync()
        {
            return await GetInvoicesByStatusAsync("APPROVED");
        }

        public async Task<IEnumerable<SalesInvoice>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(si => si.CariAccount)
                .Include(si => si.Warehouse)
                .Where(si => si.InvoiceDate >= startDate && si.InvoiceDate <= endDate)
                .OrderByDescending(si => si.InvoiceDate)
                .ToListAsync();
        }

        public async Task<bool> IsInvoiceNoUniqueAsync(string invoiceNo, int? excludeInvoiceId = null)
        {
            return !await _dbSet.AnyAsync(si => si.InvoiceNo == invoiceNo && 
                (!excludeInvoiceId.HasValue || si.InvoiceID != excludeInvoiceId.Value));
        }

        public async Task<bool> ApproveInvoiceAsync(int invoiceId)
        {
            var invoice = await _dbSet.FindAsync(invoiceId);
            if (invoice == null || invoice.Status != "DRAFT") return false;

            invoice.Status = "APPROVED";
            return await SaveChangesAsync();
        }

        public async Task<bool> CancelInvoiceAsync(int invoiceId)
        {
            var invoice = await _dbSet.FindAsync(invoiceId);
            if (invoice == null) return false;

            invoice.Status = "CANCELLED";
            return await SaveChangesAsync();
        }

        public async Task<decimal> GetTotalSalesAmountAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _dbSet.Where(si => si.Status == "APPROVED");

            if (fromDate.HasValue && toDate.HasValue)
            {
                query = query.Where(si => si.InvoiceDate >= fromDate && si.InvoiceDate <= toDate);
            }

            return await query.SumAsync(si => si.Total);
        }

        public async Task<int> GetInvoiceCountAsync(string? status = null)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(si => si.Status == status);
            }

            return await query.CountAsync();
        }

        public async Task<string> GenerateInvoiceNoAsync()
        {
            var year = DateTime.Now.Year;
            var prefix = $"SF{year}";
            
            var lastInvoice = await _dbSet
                .Where(si => si.InvoiceNo.StartsWith(prefix))
                .OrderByDescending(si => si.InvoiceNo)
                .FirstOrDefaultAsync();

            int nextNumber = 1;
            if (lastInvoice != null)
            {
                var lastNumber = lastInvoice.InvoiceNo.Substring(prefix.Length);
                if (int.TryParse(lastNumber, out var number))
                {
                    nextNumber = number + 1;
                }
            }

            return $"{prefix}{nextNumber:D6}";
        }

        public async Task<bool> UpdateInvoiceTotalsAsync(int invoiceId)
        {
            var invoice = await _dbSet
                .Include(si => si.SalesInvoiceDetails)
                .FirstOrDefaultAsync(si => si.InvoiceID == invoiceId);

            if (invoice == null) return false;

            invoice.SubTotal = invoice.SalesInvoiceDetails.Sum(d => d.LineTotal);
            invoice.VatAmount = invoice.SalesInvoiceDetails.Sum(d => d.VatAmount);
            invoice.Total = invoice.SalesInvoiceDetails.Sum(d => d.NetTotal);

            return await SaveChangesAsync();
        }
    }
} 