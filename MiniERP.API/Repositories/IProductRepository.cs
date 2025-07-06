using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetByCodeAsync(string productCode);
        Task<Product?> GetProductWithDetailsAsync(int productId);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetActiveProductsAsync();
        Task<IEnumerable<Product>> GetLowStockProductsAsync();
        Task<IEnumerable<Product>> GetCriticalStockProductsAsync();
        Task<bool> IsProductCodeUniqueAsync(string productCode, int? excludeProductId = null);
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
        Task<IEnumerable<Product>> GetProductsWithStockAsync(int warehouseId);
        Task<decimal> GetTotalStockValueAsync();
        Task<IEnumerable<Product>> GetTopSellingProductsAsync(int count, DateTime? fromDate = null, DateTime? toDate = null);
    }
} 