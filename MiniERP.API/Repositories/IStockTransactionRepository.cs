using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public interface IStockTransactionRepository : IGenericRepository<StockTransaction>
    {
        Task<IEnumerable<StockTransaction>> GetByProductIdAsync(int productId);
        Task<IEnumerable<StockTransaction>> GetByWarehouseIdAsync(int warehouseId);
        Task<IEnumerable<StockTransaction>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<StockTransaction>> GetByTransactionTypeAsync(string transactionType);
        Task<IEnumerable<StockTransaction>> GetByDocumentAsync(string documentType, string documentNo);
        Task<IEnumerable<StockTransaction>> GetIncomingTransactionsAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<IEnumerable<StockTransaction>> GetOutgoingTransactionsAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<decimal> GetTotalIncomingQuantityAsync(int productId, int warehouseId, DateTime? fromDate = null, DateTime? toDate = null);
        Task<decimal> GetTotalOutgoingQuantityAsync(int productId, int warehouseId, DateTime? fromDate = null, DateTime? toDate = null);
        Task<decimal> GetTotalIncomingValueAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<decimal> GetTotalOutgoingValueAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<IEnumerable<StockTransaction>> GetTransactionsWithDetailsAsync();
    }
} 