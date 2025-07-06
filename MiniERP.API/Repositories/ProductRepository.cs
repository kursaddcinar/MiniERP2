using Microsoft.EntityFrameworkCore;
using MiniERP.API.Data;
using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product?> GetByCodeAsync(string productCode)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Unit)
                .Include(p => p.StockCards)
                .FirstOrDefaultAsync(p => p.ProductCode == productCode);
        }

        public async Task<Product?> GetProductWithDetailsAsync(int productId)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Unit)
                .Include(p => p.StockCards)
                .ThenInclude(sc => sc.Warehouse)
                .FirstOrDefaultAsync(p => p.ProductID == productId);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Unit)
                .Where(p => p.CategoryID == categoryId && p.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetActiveProductsAsync()
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Unit)
                .Where(p => p.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetLowStockProductsAsync()
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Unit)
                .Include(p => p.StockCards)
                .Where(p => p.IsActive && p.StockCards.Sum(sc => sc.CurrentStock) <= p.MinStockLevel)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetCriticalStockProductsAsync()
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Unit)
                .Include(p => p.StockCards)
                .Where(p => p.IsActive && p.StockCards.Sum(sc => sc.CurrentStock) < p.MinStockLevel)
                .ToListAsync();
        }

        public async Task<bool> IsProductCodeUniqueAsync(string productCode, int? excludeProductId = null)
        {
            return !await _dbSet.AnyAsync(p => p.ProductCode == productCode && 
                (!excludeProductId.HasValue || p.ProductID != excludeProductId.Value));
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Unit)
                .Where(p => p.IsActive && 
                    (p.ProductCode.Contains(searchTerm) || p.ProductName.Contains(searchTerm)))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithStockAsync(int warehouseId)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Unit)
                .Include(p => p.StockCards.Where(sc => sc.WarehouseID == warehouseId))
                .Where(p => p.IsActive && p.StockCards.Any(sc => sc.WarehouseID == warehouseId && sc.CurrentStock > 0))
                .ToListAsync();
        }

        public async Task<decimal> GetTotalStockValueAsync()
        {
            return await _dbSet
                .Where(p => p.IsActive)
                .SumAsync(p => p.StockCards.Sum(sc => sc.CurrentStock) * p.PurchasePrice);
        }

        public async Task<IEnumerable<Product>> GetTopSellingProductsAsync(int count, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _dbSet
                .Include(p => p.Category)
                .Include(p => p.Unit)
                .Include(p => p.SalesInvoiceDetails)
                .Where(p => p.IsActive);

            if (fromDate.HasValue && toDate.HasValue)
            {
                query = query.Where(p => p.SalesInvoiceDetails.Any(sid => 
                    sid.SalesInvoice.InvoiceDate >= fromDate && sid.SalesInvoice.InvoiceDate <= toDate));
            }

            return await query
                .OrderByDescending(p => p.SalesInvoiceDetails.Sum(sid => sid.Quantity))
                .Take(count)
                .ToListAsync();
        }
    }
} 