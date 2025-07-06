using Microsoft.EntityFrameworkCore;
using MiniERP.API.Data;
using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public class CariAccountRepository : GenericRepository<CariAccount>, ICariAccountRepository
    {
        public CariAccountRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<CariAccount?> GetByCodeAsync(string cariCode)
        {
            return await _dbSet
                .Include(c => c.Type)
                .Include(c => c.CariTransactions)
                .FirstOrDefaultAsync(c => c.CariCode == cariCode);
        }

        public async Task<CariAccount?> GetCariWithTransactionsAsync(int cariId)
        {
            return await _dbSet
                .Include(c => c.Type)
                .Include(c => c.CariTransactions)
                .Include(c => c.SalesInvoices)
                .Include(c => c.PurchaseInvoices)
                .Include(c => c.Payments)
                .Include(c => c.Collections)
                .FirstOrDefaultAsync(c => c.CariID == cariId);
        }

        public async Task<IEnumerable<CariAccount>> GetCustomersAsync()
        {
            return await _dbSet
                .Include(c => c.Type)
                .Where(c => c.IsActive && (c.Type.TypeCode == "MUSTERI" || c.Type.TypeCode == "HERSIKI")) // Müşteri veya Her İkisi
                .ToListAsync();
        }

        public async Task<IEnumerable<CariAccount>> GetSuppliersAsync()
        {
            return await _dbSet
                .Include(c => c.Type)
                .Where(c => c.IsActive && (c.Type.TypeCode == "TEDARIKCI" || c.Type.TypeCode == "HERSIKI")) // Tedarikçi veya Her İkisi
                .ToListAsync();
        }

        public async Task<IEnumerable<CariAccount>> GetActiveCariAccountsAsync()
        {
            return await _dbSet
                .Include(c => c.Type)
                .Where(c => c.IsActive)
                .ToListAsync();
        }

        public async Task<bool> IsCariCodeUniqueAsync(string cariCode, int? excludeCariId = null)
        {
            return !await _dbSet.AnyAsync(c => c.CariCode == cariCode && 
                (!excludeCariId.HasValue || c.CariID != excludeCariId.Value));
        }

        public async Task<IEnumerable<CariAccount>> SearchCariAccountsAsync(string searchTerm)
        {
            return await _dbSet
                .Include(c => c.Type)
                .Where(c => c.IsActive && 
                    (c.CariCode.Contains(searchTerm) || c.CariName.Contains(searchTerm)))
                .ToListAsync();
        }

        public async Task<IEnumerable<CariAccount>> GetCariAccountsWithBalanceAsync(bool includeZeroBalance = false)
        {
            var query = _dbSet
                .Include(c => c.Type)
                .Where(c => c.IsActive);

            if (!includeZeroBalance)
            {
                query = query.Where(c => c.CurrentBalance != 0);
            }

            return await query.ToListAsync();
        }

        public async Task<decimal> GetTotalReceivablesAsync()
        {
            return await _dbSet
                .Where(c => c.IsActive && c.CurrentBalance > 0)
                .SumAsync(c => c.CurrentBalance);
        }

        public async Task<decimal> GetTotalPayablesAsync()
        {
            return await _dbSet
                .Where(c => c.IsActive && c.CurrentBalance < 0)
                .SumAsync(c => Math.Abs(c.CurrentBalance));
        }

        public async Task<IEnumerable<CariAccount>> GetTopCustomersAsync(int count, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _dbSet
                .Include(c => c.Type)
                .Include(c => c.SalesInvoices)
                .Where(c => c.IsActive && (c.Type.TypeCode == "MUSTERI" || c.Type.TypeCode == "HERSIKI"));

            if (fromDate.HasValue && toDate.HasValue)
            {
                query = query.Where(c => c.SalesInvoices.Any(si => 
                    si.InvoiceDate >= fromDate && si.InvoiceDate <= toDate));
            }

            return await query
                .OrderByDescending(c => c.SalesInvoices.Sum(si => si.Total))
                .Take(count)
                .ToListAsync();
        }

        public async Task<bool> UpdateBalanceAsync(int cariId, decimal amount, string transactionType)
        {
            var cari = await _dbSet.FindAsync(cariId);
            if (cari == null) return false;

            if (transactionType == "ALACAK")
            {
                cari.CurrentBalance += amount;
            }
            else if (transactionType == "BORC")
            {
                cari.CurrentBalance -= amount;
            }

            return await SaveChangesAsync();
        }
    }
} 