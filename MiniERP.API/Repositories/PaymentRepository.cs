using Microsoft.EntityFrameworkCore;
using MiniERP.API.Data;
using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByCariIdAsync(int cariId)
        {
            return await _dbSet
                .Include(p => p.CariAccount)
                .Include(p => p.PaymentType)
                .Where(p => p.CariID == cariId)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(p => p.CariAccount)
                .Include(p => p.PaymentType)
                .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByPaymentTypeAsync(int paymentTypeId)
        {
            return await _dbSet
                .Include(p => p.CariAccount)
                .Include(p => p.PaymentType)
                .Where(p => p.PaymentTypeID == paymentTypeId)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByStatusAsync(string status)
        {
            return await _dbSet
                .Include(p => p.CariAccount)
                .Include(p => p.PaymentType)
                .Where(p => p.Status == status)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }

        public async Task<Payment?> GetPaymentByPaymentNoAsync(string paymentNo)
        {
            return await _dbSet
                .Include(p => p.CariAccount)
                .Include(p => p.PaymentType)
                .FirstOrDefaultAsync(p => p.PaymentNo == paymentNo);
        }

        public async Task<decimal> GetTotalPaymentAmountAsync(int cariId)
        {
            return await _dbSet
                .Where(p => p.CariID == cariId && p.Status == "COMPLETED")
                .SumAsync(p => p.Amount);
        }

        public async Task<decimal> GetTotalPaymentAmountByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate && p.Status == "COMPLETED")
                .SumAsync(p => p.Amount);
        }

        public async Task<IEnumerable<Payment>> GetRecentPaymentsAsync(int count = 10)
        {
            return await _dbSet
                .Include(p => p.CariAccount)
                .Include(p => p.PaymentType)
                .OrderByDescending(p => p.CreatedDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task<bool> IsPaymentNoUniqueAsync(string paymentNo, int? excludeId = null)
        {
            return !await _dbSet.AnyAsync(p => p.PaymentNo == paymentNo && (!excludeId.HasValue || p.PaymentID != excludeId.Value));
        }

        public async Task<(IEnumerable<Payment> payments, int totalCount)> GetPaymentsWithDetailsAsync(int pageNumber, int pageSize, string? searchTerm = null, int? cariId = null, int? paymentTypeId = null, string? status = null)
        {
            var query = _dbSet
                .Include(p => p.CariAccount)
                .Include(p => p.PaymentType)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.PaymentNo.Contains(searchTerm) || 
                                        p.CariAccount.CariName.Contains(searchTerm) || 
                                        p.Description!.Contains(searchTerm));
            }

            if (cariId.HasValue)
            {
                query = query.Where(p => p.CariID == cariId.Value);
            }

            if (paymentTypeId.HasValue)
            {
                query = query.Where(p => p.PaymentTypeID == paymentTypeId.Value);
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(p => p.Status == status);
            }

            var totalCount = await query.CountAsync();
            var payments = await query
                .OrderByDescending(p => p.PaymentDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (payments, totalCount);
        }
    }
} 