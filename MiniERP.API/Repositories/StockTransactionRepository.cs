using Microsoft.EntityFrameworkCore;
using MiniERP.API.Data;
using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public class StockTransactionRepository : GenericRepository<StockTransaction>, IStockTransactionRepository
    {
        public StockTransactionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<StockTransaction>> GetByProductIdAsync(int productId)
        {
            return await _dbSet
                .Include(st => st.Product)
                .ThenInclude(p => p.Unit)
                .Include(st => st.Warehouse)
                .Where(st => st.ProductID == productId)
                .OrderByDescending(st => st.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockTransaction>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbSet
                .Include(st => st.Product)
                .ThenInclude(p => p.Unit)
                .Include(st => st.Warehouse)
                .Where(st => st.WarehouseID == warehouseId)
                .OrderByDescending(st => st.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockTransaction>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(st => st.Product)
                .ThenInclude(p => p.Unit)
                .Include(st => st.Warehouse)
                .Where(st => st.TransactionDate >= startDate && st.TransactionDate <= endDate)
                .OrderByDescending(st => st.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockTransaction>> GetByTransactionTypeAsync(string transactionType)
        {
            return await _dbSet
                .Include(st => st.Product)
                .ThenInclude(p => p.Unit)
                .Include(st => st.Warehouse)
                .Where(st => st.TransactionType == transactionType)
                .OrderByDescending(st => st.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockTransaction>> GetByDocumentAsync(string documentType, string documentNo)
        {
            return await _dbSet
                .Include(st => st.Product)
                .ThenInclude(p => p.Unit)
                .Include(st => st.Warehouse)
                .Where(st => st.DocumentType == documentType && st.DocumentNo == documentNo)
                .OrderByDescending(st => st.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockTransaction>> GetIncomingTransactionsAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _dbSet
                .Include(st => st.Product)
                .ThenInclude(p => p.Unit)
                .Include(st => st.Warehouse)
                .Where(st => st.TransactionType == "GIRIS");

            if (fromDate.HasValue && toDate.HasValue)
            {
                query = query.Where(st => st.TransactionDate >= fromDate && st.TransactionDate <= toDate);
            }

            return await query
                .OrderByDescending(st => st.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockTransaction>> GetOutgoingTransactionsAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _dbSet
                .Include(st => st.Product)
                .ThenInclude(p => p.Unit)
                .Include(st => st.Warehouse)
                .Where(st => st.TransactionType == "CIKIS");

            if (fromDate.HasValue && toDate.HasValue)
            {
                query = query.Where(st => st.TransactionDate >= fromDate && st.TransactionDate <= toDate);
            }

            return await query
                .OrderByDescending(st => st.TransactionDate)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalIncomingQuantityAsync(int productId, int warehouseId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _dbSet
                .Where(st => st.ProductID == productId && st.WarehouseID == warehouseId && st.TransactionType == "GIRIS");

            if (fromDate.HasValue && toDate.HasValue)
            {
                query = query.Where(st => st.TransactionDate >= fromDate && st.TransactionDate <= toDate);
            }

            return await query.SumAsync(st => st.Quantity);
        }

        public async Task<decimal> GetTotalOutgoingQuantityAsync(int productId, int warehouseId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _dbSet
                .Where(st => st.ProductID == productId && st.WarehouseID == warehouseId && st.TransactionType == "CIKIS");

            if (fromDate.HasValue && toDate.HasValue)
            {
                query = query.Where(st => st.TransactionDate >= fromDate && st.TransactionDate <= toDate);
            }

            return await query.SumAsync(st => st.Quantity);
        }

        public async Task<decimal> GetTotalIncomingValueAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _dbSet.Where(st => st.TransactionType == "GIRIS");

            if (fromDate.HasValue && toDate.HasValue)
            {
                query = query.Where(st => st.TransactionDate >= fromDate && st.TransactionDate <= toDate);
            }

            return await query.SumAsync(st => st.TotalAmount);
        }

        public async Task<decimal> GetTotalOutgoingValueAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _dbSet.Where(st => st.TransactionType == "CIKIS");

            if (fromDate.HasValue && toDate.HasValue)
            {
                query = query.Where(st => st.TransactionDate >= fromDate && st.TransactionDate <= toDate);
            }

            return await query.SumAsync(st => st.TotalAmount);
        }

        public async Task<IEnumerable<StockTransaction>> GetTransactionsWithDetailsAsync()
        {
            return await _dbSet
                .Include(st => st.Product)
                .ThenInclude(p => p.Unit)
                .Include(st => st.Warehouse)
                .OrderByDescending(st => st.TransactionDate)
                .ToListAsync();
        }
    }
} 