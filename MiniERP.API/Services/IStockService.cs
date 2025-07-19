using MiniERP.API.DTOs;

namespace MiniERP.API.Services
{
    public interface IStockService
    {
        // StockCard işlemleri
        Task<ApiResponse<PagedResult<StockCardDto>>> GetStockCardsAsync(PaginationParameters parameters);
        Task<ApiResponse<StockCardDto>> GetStockCardByIdAsync(int id);
        Task<ApiResponse<StockCardDto>> GetStockCardByProductAndWarehouseAsync(int productId, int warehouseId);
        Task<ApiResponse<List<StockCardDto>>> GetStockCardsByProductIdAsync(int productId);
        Task<ApiResponse<List<StockCardDto>>> GetStockCardsByWarehouseIdAsync(int warehouseId);
        Task<ApiResponse<StockCardDto>> CreateStockCardAsync(CreateStockCardDto createStockCardDto);
        Task<ApiResponse<StockCardDto>> UpdateStockCardAsync(int id, UpdateStockCardDto updateStockCardDto);
        Task<ApiResponse<bool>> DeleteStockCardAsync(int id);

        // Stok durumu işlemleri
        Task<ApiResponse<List<StockCardDto>>> GetCriticalStockCardsAsync();
        Task<ApiResponse<List<StockCardDto>>> GetOverStockCardsAsync();
        Task<ApiResponse<List<StockCardDto>>> GetOutOfStockCardsAsync();
        Task<ApiResponse<bool>> UpdateStockAsync(int productId, int warehouseId, decimal quantity, string transactionType);
        Task<ApiResponse<bool>> UpdateStockWithTransactionAsync(DetailedUpdateStockDto updateStockDto);
        Task<ApiResponse<bool>> ReserveStockAsync(int productId, int warehouseId, decimal quantity);
        Task<ApiResponse<bool>> ReleaseReservedStockAsync(int productId, int warehouseId, decimal quantity);

        // StockTransaction işlemleri
        Task<ApiResponse<PagedResult<StockTransactionDto>>> GetStockTransactionsAsync(PaginationParameters parameters);
        Task<ApiResponse<StockTransactionDto>> GetStockTransactionByIdAsync(int id);
        Task<ApiResponse<StockTransactionDto>> CreateStockTransactionAsync(CreateStockTransactionDto createTransactionDto);
        Task<ApiResponse<List<StockTransactionDto>>> GetTransactionsByProductIdAsync(int productId);
        Task<ApiResponse<List<StockTransactionDto>>> GetTransactionsByWarehouseIdAsync(int warehouseId);
        Task<ApiResponse<List<StockTransactionDto>>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ApiResponse<List<StockTransactionDto>>> GetIncomingTransactionsAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<ApiResponse<List<StockTransactionDto>>> GetOutgoingTransactionsAsync(DateTime? fromDate = null, DateTime? toDate = null);

        // Stok hareketi işlemleri
        Task<ApiResponse<bool>> ProcessStockMovementAsync(CreateStockMovementDto movementDto);

        // Warehouse işlemleri
        Task<ApiResponse<PagedResult<WarehouseDto>>> GetWarehousesAsync(PaginationParameters parameters);
        Task<ApiResponse<WarehouseDto>> GetWarehouseByIdAsync(int id);
        Task<ApiResponse<WarehouseDto>> GetWarehouseByCodeAsync(string warehouseCode);
        Task<ApiResponse<WarehouseDto>> CreateWarehouseAsync(CreateWarehouseDto createWarehouseDto);
        Task<ApiResponse<WarehouseDto>> UpdateWarehouseAsync(int id, UpdateWarehouseDto updateWarehouseDto);
        Task<ApiResponse<bool>> DeleteWarehouseAsync(int id);
        Task<ApiResponse<List<WarehouseDto>>> GetActiveWarehousesAsync();

        // Raporlar ve istatistikler
        Task<ApiResponse<StockSummaryDto>> GetStockSummaryAsync();
        Task<ApiResponse<StockReportDto>> GetStockReportAsync(int? warehouseId = null, int? categoryId = null);
        Task<ApiResponse<decimal>> GetTotalStockValueAsync();
        Task<ApiResponse<decimal>> GetTotalStockValueByWarehouseAsync(int warehouseId);
        Task<ApiResponse<decimal>> GetTotalIncomingValueAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<ApiResponse<decimal>> GetTotalOutgoingValueAsync(DateTime? fromDate = null, DateTime? toDate = null);
    }
} 