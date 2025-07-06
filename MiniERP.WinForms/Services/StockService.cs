using MiniERP.WinForms.Models;

namespace MiniERP.WinForms.Services
{
    public class StockService
    {
        private readonly ApiService _apiService;

        public StockService(ApiService apiService)
        {
            _apiService = apiService;
        }

        // Stock Cards
        public async Task<ApiResponse<PagedResult<StockCardDto>>> GetStockCardsAsync(int pageNumber = 1, int pageSize = 100, string? searchTerm = null)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";
            }

            return await _apiService.GetAsync<PagedResult<StockCardDto>>($"/api/stock/cards{query}");
        }

        public async Task<ApiResponse<StockCardDto>> GetStockCardByIdAsync(int id)
        {
            return await _apiService.GetAsync<StockCardDto>($"/api/stock/cards/{id}");
        }

        public async Task<ApiResponse<List<StockCardDto>>> GetStockCardsByProductIdAsync(int productId)
        {
            return await _apiService.GetAsync<List<StockCardDto>>($"/api/stock/cards/product/{productId}");
        }

        public async Task<ApiResponse<List<StockCardDto>>> GetStockCardsByWarehouseIdAsync(int warehouseId)
        {
            return await _apiService.GetAsync<List<StockCardDto>>($"/api/stock/cards/warehouse/{warehouseId}");
        }

        public async Task<ApiResponse<List<StockCardDto>>> GetCriticalStockAsync()
        {
            return await _apiService.GetAsync<List<StockCardDto>>("/api/stock/cards/critical");
        }

        // Stock Transactions
        public async Task<ApiResponse<PagedResult<StockTransactionDto>>> GetStockTransactionsAsync(int pageNumber = 1, int pageSize = 100, string? searchTerm = null)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";
            }

            return await _apiService.GetAsync<PagedResult<StockTransactionDto>>($"/api/stock/transactions{query}");
        }

        public async Task<ApiResponse<StockTransactionDto>> GetStockTransactionByIdAsync(int id)
        {
            return await _apiService.GetAsync<StockTransactionDto>($"/api/stock/transactions/{id}");
        }

        public async Task<ApiResponse<List<StockTransactionDto>>> GetStockTransactionsByProductIdAsync(int productId)
        {
            return await _apiService.GetAsync<List<StockTransactionDto>>($"/api/stock/transactions/product/{productId}");
        }

        public async Task<ApiResponse<List<StockTransactionDto>>> GetStockTransactionsByWarehouseIdAsync(int warehouseId)
        {
            return await _apiService.GetAsync<List<StockTransactionDto>>($"/api/stock/transactions/warehouse/{warehouseId}");
        }

        public async Task<ApiResponse<StockTransactionDto>> CreateStockTransactionAsync(CreateStockTransactionDto createDto)
        {
            return await _apiService.PostAsync<StockTransactionDto>("/api/stock/transactions", createDto);
        }

        public async Task<ApiResponse> DeleteStockTransactionAsync(int id)
        {
            return await _apiService.DeleteAsync($"/api/stock/transactions/{id}");
        }

        // Warehouses
        public async Task<ApiResponse<PagedResult<WarehouseDto>>> GetWarehousesAsync(int pageNumber = 1, int pageSize = 100)
        {
            return await _apiService.GetAsync<PagedResult<WarehouseDto>>($"/api/stock/warehouses?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<ApiResponse<WarehouseDto>> GetWarehouseByIdAsync(int id)
        {
            return await _apiService.GetAsync<WarehouseDto>($"/api/stock/warehouses/{id}");
        }

        public async Task<ApiResponse<List<WarehouseDto>>> GetActiveWarehousesAsync()
        {
            return await _apiService.GetAsync<List<WarehouseDto>>("/api/stock/warehouses/active");
        }

        // Stock Operations
        public async Task<ApiResponse> ReserveStockAsync(ReserveStockDto reserveDto)
        {
            return await _apiService.PostAsync("/api/stock/reserve", reserveDto);
        }

        public async Task<ApiResponse> UnreserveStockAsync(ReserveStockDto unreserveDto)
        {
            return await _apiService.PostAsync("/api/stock/unreserve", unreserveDto);
        }

        public async Task<ApiResponse> TransferStockAsync(int productId, int fromWarehouseId, int toWarehouseId, decimal quantity, string notes)
        {
            var transferDto = new
            {
                ProductID = productId,
                FromWarehouseID = fromWarehouseId,
                ToWarehouseID = toWarehouseId,
                Quantity = quantity,
                Notes = notes
            };

            return await _apiService.PostAsync("/api/stock/transfer", transferDto);
        }

        public async Task<ApiResponse> AdjustStockAsync(int productId, int warehouseId, decimal quantity, string reason, string notes)
        {
            var adjustDto = new
            {
                ProductID = productId,
                WarehouseID = warehouseId,
                Quantity = quantity,
                Reason = reason,
                Notes = notes
            };

            return await _apiService.PostAsync("/api/stock/adjust", adjustDto);
        }

        // Stock Reports
        public async Task<ApiResponse<List<StockCardDto>>> GetStockReportAsync(int? warehouseId = null, int? categoryId = null, string? stockStatus = null)
        {
            var query = "?";
            if (warehouseId.HasValue)
                query += $"warehouseId={warehouseId}&";
            if (categoryId.HasValue)
                query += $"categoryId={categoryId}&";
            if (!string.IsNullOrWhiteSpace(stockStatus))
                query += $"stockStatus={Uri.EscapeDataString(stockStatus)}&";

            query = query.TrimEnd('&', '?');
            return await _apiService.GetAsync<List<StockCardDto>>($"/api/stock/report{query}");
        }

        public async Task<ApiResponse<object>> GetStockMovementReportAsync(int? productId = null, int? warehouseId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = "?";
            if (productId.HasValue)
                query += $"productId={productId}&";
            if (warehouseId.HasValue)
                query += $"warehouseId={warehouseId}&";
            if (startDate.HasValue)
                query += $"startDate={startDate:yyyy-MM-dd}&";
            if (endDate.HasValue)
                query += $"endDate={endDate:yyyy-MM-dd}&";

            query = query.TrimEnd('&', '?');
            return await _apiService.GetAsync<object>($"/api/stock/movement-report{query}");
        }
    }
} 