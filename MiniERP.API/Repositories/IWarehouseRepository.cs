using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public interface IWarehouseRepository : IGenericRepository<Warehouse>
    {
        Task<Warehouse?> GetByCodeAsync(string warehouseCode);
        Task<Warehouse?> GetWarehouseWithStockCardsAsync(int warehouseId);
        Task<IEnumerable<Warehouse>> GetActiveWarehousesAsync();
        Task<bool> IsWarehouseCodeUniqueAsync(string warehouseCode, int? excludeWarehouseId = null);
        Task<IEnumerable<Warehouse>> SearchWarehousesAsync(string searchTerm);
        Task<IEnumerable<Warehouse>> GetWarehousesWithStockValueAsync();
        Task<decimal> GetTotalStockValueByWarehouseAsync(int warehouseId);
        Task<int> GetProductCountByWarehouseAsync(int warehouseId);
    }
} 