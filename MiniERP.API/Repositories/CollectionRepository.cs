using Microsoft.EntityFrameworkCore;
using MiniERP.API.Data;
using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public class CollectionRepository : GenericRepository<Collection>, ICollectionRepository
    {
        public CollectionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Collection>> GetCollectionsByCariIdAsync(int cariId)
        {
            return await _dbSet
                .Include(c => c.CariAccount)
                .Include(c => c.PaymentType)
                .Where(c => c.CariID == cariId)
                .OrderByDescending(c => c.CollectionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Collection>> GetCollectionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(c => c.CariAccount)
                .Include(c => c.PaymentType)
                .Where(c => c.CollectionDate >= startDate && c.CollectionDate <= endDate)
                .OrderByDescending(c => c.CollectionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Collection>> GetCollectionsByPaymentTypeAsync(int paymentTypeId)
        {
            return await _dbSet
                .Include(c => c.CariAccount)
                .Include(c => c.PaymentType)
                .Where(c => c.PaymentTypeID == paymentTypeId)
                .OrderByDescending(c => c.CollectionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Collection>> GetCollectionsByStatusAsync(string status)
        {
            return await _dbSet
                .Include(c => c.CariAccount)
                .Include(c => c.PaymentType)
                .Where(c => c.Status == status)
                .OrderByDescending(c => c.CollectionDate)
                .ToListAsync();
        }

        public async Task<Collection?> GetCollectionByCollectionNoAsync(string collectionNo)
        {
            return await _dbSet
                .Include(c => c.CariAccount)
                .Include(c => c.PaymentType)
                .FirstOrDefaultAsync(c => c.CollectionNo == collectionNo);
        }

        public async Task<decimal> GetTotalCollectionAmountAsync(int cariId)
        {
            return await _dbSet
                .Where(c => c.CariID == cariId && c.Status == "COMPLETED")
                .SumAsync(c => c.Amount);
        }

        public async Task<decimal> GetTotalCollectionAmountByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(c => c.CollectionDate >= startDate && c.CollectionDate <= endDate && c.Status == "COMPLETED")
                .SumAsync(c => c.Amount);
        }

        public async Task<IEnumerable<Collection>> GetRecentCollectionsAsync(int count = 10)
        {
            return await _dbSet
                .Include(c => c.CariAccount)
                .Include(c => c.PaymentType)
                .OrderByDescending(c => c.CreatedDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task<bool> IsCollectionNoUniqueAsync(string collectionNo, int? excludeId = null)
        {
            return !await _dbSet.AnyAsync(c => c.CollectionNo == collectionNo && (!excludeId.HasValue || c.CollectionID != excludeId.Value));
        }

        public async Task<(IEnumerable<Collection> collections, int totalCount)> GetCollectionsWithDetailsAsync(int pageNumber, int pageSize, string? searchTerm = null, int? cariId = null, int? paymentTypeId = null, string? status = null)
        {
            var query = _dbSet
                .Include(c => c.CariAccount)
                .Include(c => c.PaymentType)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(c => c.CollectionNo.Contains(searchTerm) || 
                                        c.CariAccount.CariName.Contains(searchTerm) || 
                                        c.Description!.Contains(searchTerm));
            }

            if (cariId.HasValue)
            {
                query = query.Where(c => c.CariID == cariId.Value);
            }

            if (paymentTypeId.HasValue)
            {
                query = query.Where(c => c.PaymentTypeID == paymentTypeId.Value);
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(c => c.Status == status);
            }

            var totalCount = await query.CountAsync();
            var collections = await query
                .OrderByDescending(c => c.CollectionDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (collections, totalCount);
        }
    }
} 