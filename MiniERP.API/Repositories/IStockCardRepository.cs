using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public interface IStockCardRepository : IGenericRepository<StockCard>
    {
        Task<StockCard?> GetByProductAndWarehouseAsync(int productId, int warehouseId);
        Task<IEnumerable<StockCard>> GetByProductIdAsync(int productId);
        Task<IEnumerable<StockCard>> GetByWarehouseIdAsync(int warehouseId);
        Task<IEnumerable<StockCard>> GetCriticalStockCardsAsync();
        Task<IEnumerable<StockCard>> GetOverStockCardsAsync();
        Task<IEnumerable<StockCard>> GetOutOfStockCardsAsync();
        Task<IEnumerable<StockCard>> GetStockCardsWithProductsAsync();
        Task<decimal> GetTotalStockValueAsync();
        Task<decimal> GetTotalStockValueByWarehouseAsync(int warehouseId);
        Task<bool> UpdateStockAsync(int productId, int warehouseId, decimal quantity, string transactionType);
        Task<bool> ReserveStockAsync(int productId, int warehouseId, decimal quantity);
        Task<bool> ReleaseReservedStockAsync(int productId, int warehouseId, decimal quantity);
        Task<StockCard> CreateStockCardIfNotExistsAsync(int productId, int warehouseId);
        Task<(IEnumerable<StockCard> Data, int TotalCount)> GetPagedWithCountAsync(int pageNumber, int pageSize, string? searchTerm = null);
        Task<StockCard?> GetByIdWithIncludesAsync(int id);
    }
} 