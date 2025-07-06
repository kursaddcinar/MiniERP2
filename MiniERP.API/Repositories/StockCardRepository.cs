using Microsoft.EntityFrameworkCore;
using MiniERP.API.Data;
using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public class StockCardRepository : GenericRepository<StockCard>, IStockCardRepository
    {
        public StockCardRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<StockCard?> GetByProductAndWarehouseAsync(int productId, int warehouseId)
        {
            return await _dbSet
                .Include(sc => sc.Product)
                .ThenInclude(p => p.Unit)
                .Include(sc => sc.Warehouse)
                .FirstOrDefaultAsync(sc => sc.ProductID == productId && sc.WarehouseID == warehouseId);
        }

        public async Task<IEnumerable<StockCard>> GetByProductIdAsync(int productId)
        {
            return await _dbSet
                .Include(sc => sc.Product)
                .ThenInclude(p => p.Unit)
                .Include(sc => sc.Warehouse)
                .Where(sc => sc.ProductID == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockCard>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbSet
                .Include(sc => sc.Product)
                .ThenInclude(p => p.Unit)
                .Include(sc => sc.Warehouse)
                .Where(sc => sc.WarehouseID == warehouseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockCard>> GetCriticalStockCardsAsync()
        {
            return await _dbSet
                .Include(sc => sc.Product)
                .ThenInclude(p => p.Unit)
                .Include(sc => sc.Warehouse)
                .Where(sc => sc.CurrentStock <= sc.Product.MinStockLevel && sc.Product.MinStockLevel > 0)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockCard>> GetOverStockCardsAsync()
        {
            return await _dbSet
                .Include(sc => sc.Product)
                .ThenInclude(p => p.Unit)
                .Include(sc => sc.Warehouse)
                .Where(sc => sc.CurrentStock >= sc.Product.MaxStockLevel && sc.Product.MaxStockLevel > 0)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockCard>> GetOutOfStockCardsAsync()
        {
            return await _dbSet
                .Include(sc => sc.Product)
                .ThenInclude(p => p.Unit)
                .Include(sc => sc.Warehouse)
                .Where(sc => sc.CurrentStock <= 0)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockCard>> GetStockCardsWithProductsAsync()
        {
            return await _dbSet
                .Include(sc => sc.Product)
                .ThenInclude(p => p.Unit)
                .Include(sc => sc.Warehouse)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalStockValueAsync()
        {
            return await _dbSet
                .Include(sc => sc.Product)
                .SumAsync(sc => sc.CurrentStock * sc.Product.PurchasePrice);
        }

        public async Task<decimal> GetTotalStockValueByWarehouseAsync(int warehouseId)
        {
            return await _dbSet
                .Include(sc => sc.Product)
                .Where(sc => sc.WarehouseID == warehouseId)
                .SumAsync(sc => sc.CurrentStock * sc.Product.PurchasePrice);
        }

        public async Task<bool> UpdateStockAsync(int productId, int warehouseId, decimal quantity, string transactionType)
        {
            var stockCard = await GetByProductAndWarehouseAsync(productId, warehouseId);
            if (stockCard == null)
            {
                stockCard = await CreateStockCardIfNotExistsAsync(productId, warehouseId);
            }

            if (transactionType.ToUpper() == "GIRIS")
            {
                stockCard.CurrentStock += quantity;
            }
            else if (transactionType.ToUpper() == "CIKIS")
            {
                if (stockCard.CurrentStock < quantity)
                    return false; // Yetersiz stok

                stockCard.CurrentStock -= quantity;
            }

            stockCard.LastTransactionDate = DateTime.Now;
            await UpdateAsync(stockCard);
            return await SaveChangesAsync();
        }

        public async Task<bool> ReserveStockAsync(int productId, int warehouseId, decimal quantity)
        {
            var stockCard = await GetByProductAndWarehouseAsync(productId, warehouseId);
            if (stockCard == null || (stockCard.CurrentStock - stockCard.ReservedStock) < quantity)
                return false;

            stockCard.ReservedStock += quantity;
            await UpdateAsync(stockCard);
            return await SaveChangesAsync();
        }

        public async Task<bool> ReleaseReservedStockAsync(int productId, int warehouseId, decimal quantity)
        {
            var stockCard = await GetByProductAndWarehouseAsync(productId, warehouseId);
            if (stockCard == null || stockCard.ReservedStock < quantity)
                return false;

            stockCard.ReservedStock -= quantity;
            await UpdateAsync(stockCard);
            return await SaveChangesAsync();
        }

        public async Task<StockCard> CreateStockCardIfNotExistsAsync(int productId, int warehouseId)
        {
            var existingCard = await GetByProductAndWarehouseAsync(productId, warehouseId);
            if (existingCard != null)
                return existingCard;

            var newCard = new StockCard
            {
                ProductID = productId,
                WarehouseID = warehouseId,
                CurrentStock = 0,
                ReservedStock = 0,
                CreatedDate = DateTime.Now
            };

            await AddAsync(newCard);
            await SaveChangesAsync();
            return newCard;
        }

        public async Task<(IEnumerable<StockCard> Data, int TotalCount)> GetPagedWithCountAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {
            var query = _dbSet
                .Include(sc => sc.Product)
                .ThenInclude(p => p.Unit)
                .Include(sc => sc.Warehouse)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(sc => 
                    sc.Product.ProductName.Contains(searchTerm) || 
                    sc.Product.ProductCode.Contains(searchTerm) ||
                    sc.Warehouse.WarehouseName.Contains(searchTerm));
            }

            var totalCount = await query.CountAsync();
            var data = await query
                .OrderBy(sc => sc.Product.ProductName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<StockCard?> GetByIdWithIncludesAsync(int id)
        {
            return await _dbSet
                .Include(sc => sc.Product)
                .ThenInclude(p => p.Unit)
                .Include(sc => sc.Warehouse)
                .FirstOrDefaultAsync(sc => sc.StockCardID == id);
        }
    }
} 