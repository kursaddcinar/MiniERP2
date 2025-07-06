using Microsoft.EntityFrameworkCore;
using MiniERP.API.Data;
using MiniERP.API.Models;
using System.Linq.Expressions;

namespace MiniERP.API.Repositories
{
    public class PurchaseInvoiceRepository : GenericRepository<PurchaseInvoice>, IPurchaseInvoiceRepository
    {
        public PurchaseInvoiceRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<(IEnumerable<PurchaseInvoice> Items, int TotalCount)> GetPagedWithCountAsync(int pageNumber, int pageSize, 
            Expression<Func<PurchaseInvoice, bool>>? filter = null, Expression<Func<PurchaseInvoice, object>>? orderBy = null, bool ascending = true)
        {
            IQueryable<PurchaseInvoice> query = _dbSet
                .Include(pi => pi.CariAccount)
                .Include(pi => pi.Warehouse);

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
                query = query.OrderByDescending(pi => pi.InvoiceDate);
            }

            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (items, totalCount);
        }

        public async Task<PurchaseInvoice?> GetByInvoiceNoAsync(string invoiceNo)
        {
            return await _dbSet
                .Include(pi => pi.CariAccount)
                .Include(pi => pi.Warehouse)
                .Include(pi => pi.PurchaseInvoiceDetails)
                .ThenInclude(pid => pid.Product)
                .FirstOrDefaultAsync(pi => pi.InvoiceNo == invoiceNo);
        }

        public async Task<PurchaseInvoice?> GetInvoiceWithDetailsAsync(int invoiceId)
        {
            return await _dbSet
                .Include(pi => pi.CariAccount)
                .Include(pi => pi.Warehouse)
                .Include(pi => pi.PurchaseInvoiceDetails)
                .ThenInclude(pid => pid.Product)
                .ThenInclude(p => p.Unit)
                .FirstOrDefaultAsync(pi => pi.InvoiceID == invoiceId);
        }

        public async Task<IEnumerable<PurchaseInvoice>> GetInvoicesByCariAsync(int cariId)
        {
            return await _dbSet
                .Include(pi => pi.CariAccount)
                .Include(pi => pi.Warehouse)
                .Where(pi => pi.CariID == cariId)
                .OrderByDescending(pi => pi.InvoiceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseInvoice>> GetInvoicesByStatusAsync(string status)
        {
            return await _dbSet
                .Include(pi => pi.CariAccount)
                .Include(pi => pi.Warehouse)
                .Where(pi => pi.Status == status)
                .OrderByDescending(pi => pi.InvoiceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseInvoice>> GetDraftInvoicesAsync()
        {
            return await GetInvoicesByStatusAsync("DRAFT");
        }

        public async Task<IEnumerable<PurchaseInvoice>> GetApprovedInvoicesAsync()
        {
            return await GetInvoicesByStatusAsync("APPROVED");
        }

        public async Task<IEnumerable<PurchaseInvoice>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(pi => pi.CariAccount)
                .Include(pi => pi.Warehouse)
                .Where(pi => pi.InvoiceDate >= startDate && pi.InvoiceDate <= endDate)
                .OrderByDescending(pi => pi.InvoiceDate)
                .ToListAsync();
        }

        public async Task<bool> IsInvoiceNoUniqueAsync(string invoiceNo, int? excludeInvoiceId = null)
        {
            return !await _dbSet.AnyAsync(pi => pi.InvoiceNo == invoiceNo && 
                (!excludeInvoiceId.HasValue || pi.InvoiceID != excludeInvoiceId.Value));
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

        public async Task<decimal> GetTotalPurchaseAmountAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _dbSet.Where(pi => pi.Status == "APPROVED");

            if (fromDate.HasValue && toDate.HasValue)
            {
                query = query.Where(pi => pi.InvoiceDate >= fromDate && pi.InvoiceDate <= toDate);
            }

            return await query.SumAsync(pi => pi.Total);
        }

        public async Task<int> GetInvoiceCountAsync(string? status = null)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(pi => pi.Status == status);
            }

            return await query.CountAsync();
        }

        public async Task<string> GenerateInvoiceNoAsync()
        {
            var year = DateTime.Now.Year;
            var prefix = $"AF{year}";
            
            var lastInvoice = await _dbSet
                .Where(pi => pi.InvoiceNo.StartsWith(prefix))
                .OrderByDescending(pi => pi.InvoiceNo)
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
                .Include(pi => pi.PurchaseInvoiceDetails)
                .FirstOrDefaultAsync(pi => pi.InvoiceID == invoiceId);

            if (invoice == null) return false;

            invoice.SubTotal = invoice.PurchaseInvoiceDetails.Sum(d => d.LineTotal);
            invoice.VatAmount = invoice.PurchaseInvoiceDetails.Sum(d => d.VatAmount);
            invoice.Total = invoice.PurchaseInvoiceDetails.Sum(d => d.NetTotal);

            return await SaveChangesAsync();
        }
    }
} 