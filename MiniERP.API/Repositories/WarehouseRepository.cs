using Microsoft.EntityFrameworkCore;
using MiniERP.API.Data;
using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Warehouse?> GetByCodeAsync(string warehouseCode)
        {
            return await _dbSet
                .Include(w => w.StockCards)
                .ThenInclude(sc => sc.Product)
                .FirstOrDefaultAsync(w => w.WarehouseCode == warehouseCode);
        }

        public async Task<Warehouse?> GetWarehouseWithStockCardsAsync(int warehouseId)
        {
            return await _dbSet
                .Include(w => w.StockCards)
                .ThenInclude(sc => sc.Product)
                .ThenInclude(p => p.Unit)
                .FirstOrDefaultAsync(w => w.WarehouseID == warehouseId);
        }

        public async Task<IEnumerable<Warehouse>> GetActiveWarehousesAsync()
        {
            return await _dbSet
                .Where(w => w.IsActive)
                .OrderBy(w => w.WarehouseName)
                .ToListAsync();
        }

        public async Task<bool> IsWarehouseCodeUniqueAsync(string warehouseCode, int? excludeWarehouseId = null)
        {
            return !await _dbSet.AnyAsync(w => w.WarehouseCode == warehouseCode && 
                (!excludeWarehouseId.HasValue || w.WarehouseID != excludeWarehouseId.Value));
        }

        public async Task<IEnumerable<Warehouse>> SearchWarehousesAsync(string searchTerm)
        {
            return await _dbSet
                .Where(w => w.IsActive && 
                    (w.WarehouseCode.Contains(searchTerm) || w.WarehouseName.Contains(searchTerm)))
                .OrderBy(w => w.WarehouseName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Warehouse>> GetWarehousesWithStockValueAsync()
        {
            return await _dbSet
                .Include(w => w.StockCards)
                .ThenInclude(sc => sc.Product)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalStockValueByWarehouseAsync(int warehouseId)
        {
            return await _dbSet
                .Where(w => w.WarehouseID == warehouseId)
                .SelectMany(w => w.StockCards)
                .SumAsync(sc => sc.CurrentStock * sc.Product.PurchasePrice);
        }

        public async Task<int> GetProductCountByWarehouseAsync(int warehouseId)
        {
            return await _dbSet
                .Where(w => w.WarehouseID == warehouseId)
                .SelectMany(w => w.StockCards)
                .CountAsync();
        }
    }
} 