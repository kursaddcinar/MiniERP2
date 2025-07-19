using MiniERP.Web.Models;
using Newtonsoft.Json;
using System.Text;

namespace MiniERP.Web.Services
{
    public class StockService
    {
        private readonly ApiService _apiService;
        private readonly ILogger<StockService> _logger;

        public StockService(ApiService apiService, ILogger<StockService> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        #region StockCard İşlemleri

        public async Task<ApiResponse<PagedResult<StockCardDto>>> GetStockCardsAsync(int page = 1, int pageSize = 10, string? search = null)
        {
            try
            {
                var query = $"PageNumber={page}&PageSize={pageSize}";
                if (!string.IsNullOrEmpty(search))
                {
                    query += $"&SearchTerm={Uri.EscapeDataString(search)}";
                }

                return await _apiService.GetAsync<PagedResult<StockCardDto>>($"api/Stock/cards?{query}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting stock cards");
                return ApiResponse<PagedResult<StockCardDto>>.ErrorResult("Stok kartları yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<StockCardDto>> GetStockCardByIdAsync(int id)
        {
            try
            {
                return await _apiService.GetAsync<StockCardDto>($"api/Stock/cards/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting stock card {id}");
                return ApiResponse<StockCardDto>.ErrorResult("Stok kartı yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<StockCardDto>> GetStockCardByProductAndWarehouseAsync(int productId, int warehouseId)
        {
            try
            {
                return await _apiService.GetAsync<StockCardDto>($"api/Stock/cards/by-product-warehouse?productId={productId}&warehouseId={warehouseId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting stock card for product {productId} and warehouse {warehouseId}");
                return ApiResponse<StockCardDto>.ErrorResult("Stok kartı yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<List<StockCardDto>>> GetStockCardsByProductAsync(int productId)
        {
            try
            {
                return await _apiService.GetAsync<List<StockCardDto>>($"api/Stock/cards/by-product/{productId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting stock cards for product {productId}");
                return ApiResponse<List<StockCardDto>>.ErrorResult("Ürün stok kartları yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<StockCardDto>> CreateStockCardAsync(CreateStockCardDto createDto)
        {
            try
            {
                return await _apiService.PostAsync<StockCardDto>("api/Stock/cards", createDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating stock card");
                return ApiResponse<StockCardDto>.ErrorResult("Stok kartı oluşturulurken hata oluştu.");
            }
        }

        public async Task<ApiResponse<StockCardDto>> UpdateStockCardAsync(int id, UpdateStockCardDto updateDto)
        {
            try
            {
                // Web'den gelen UpdateStockCardDto'yu API'nin beklediği formata dönüştür
                var apiUpdateDto = new
                {
                    CurrentStock = updateDto.CurrentStock,
                    ReservedStock = updateDto.ReservedStock
                    // API şu anda sadece bu iki alanı destekliyor
                    // Location, Notes, MinStockLevel vb. alanlar henüz desteklenmiyor
                };
                
                return await _apiService.PutAsync<StockCardDto>($"api/Stock/cards/{id}", apiUpdateDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating stock card {id}");
                return ApiResponse<StockCardDto>.ErrorResult("Stok kartı güncellenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<bool>> DeleteStockCardAsync(int id)
        {
            try
            {
                return await _apiService.DeleteAsync<bool>($"api/Stock/cards/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting stock card {id}");
                return ApiResponse<bool>.ErrorResult("Stok kartı silinirken hata oluştu.");
            }
        }

        #endregion

        #region Stok Durumu İşlemleri

        public async Task<ApiResponse<List<StockCardDto>>> GetCriticalStockCardsAsync()
        {
            try
            {
                return await _apiService.GetAsync<List<StockCardDto>>("api/Stock/cards/critical");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting critical stock cards");
                return ApiResponse<List<StockCardDto>>.ErrorResult("Kritik stok kartları yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<List<StockCardDto>>> GetOverStockCardsAsync()
        {
            try
            {
                return await _apiService.GetAsync<List<StockCardDto>>("api/Stock/cards/over-stock");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting over stock cards");
                return ApiResponse<List<StockCardDto>>.ErrorResult("Fazla stok kartları yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<List<StockCardDto>>> GetOutOfStockCardsAsync()
        {
            try
            {
                return await _apiService.GetAsync<List<StockCardDto>>("api/Stock/cards/out-of-stock");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting out of stock cards");
                return ApiResponse<List<StockCardDto>>.ErrorResult("Stokta olmayan kartlar yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<bool>> UpdateStockAsync(UpdateStockDto updateDto)
        {
            try
            {
                // Web'den gelen UpdateStockDto'yu API'nin DetailedUpdateStockDto formatına dönüştür
                var detailedUpdateDto = new
                {
                    ProductID = updateDto.ProductID,
                    WarehouseID = updateDto.WarehouseID,
                    Quantity = updateDto.Quantity,
                    TransactionType = updateDto.TransactionType,
                    UnitPrice = updateDto.UnitPrice,
                    DocumentNo = updateDto.DocumentNo,
                    Notes = updateDto.Notes
                };

                return await _apiService.PostAsync<bool>("api/Stock/update-stock-detailed", detailedUpdateDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating stock");
                return ApiResponse<bool>.ErrorResult("Stok güncellenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<bool>> ReserveStockAsync(ReserveStockDto reserveDto)
        {
            try
            {
                return await _apiService.PostAsync<bool>("api/Stock/reserve", reserveDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reserving stock");
                return ApiResponse<bool>.ErrorResult("Stok rezerve edilirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<bool>> ReleaseReservedStockAsync(ReserveStockDto reserveDto)
        {
            try
            {
                return await _apiService.PostAsync<bool>("api/Stock/release-reserved", reserveDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error releasing reserved stock");
                return ApiResponse<bool>.ErrorResult("Rezerve stok serbest bırakılırken hata oluştu.");
            }
        }

        #endregion

        #region Stok Hareket İşlemleri

        public async Task<ApiResponse<PagedResult<StockTransactionDto>>> GetStockTransactionsAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                var query = $"PageNumber={page}&PageSize={pageSize}";
                return await _apiService.GetAsync<PagedResult<StockTransactionDto>>($"api/Stock/transactions?{query}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting stock transactions");
                return ApiResponse<PagedResult<StockTransactionDto>>.ErrorResult("Stok hareketleri yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<StockTransactionDto>> GetStockTransactionByIdAsync(int id)
        {
            try
            {
                return await _apiService.GetAsync<StockTransactionDto>($"api/Stock/transactions/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting stock transaction {id}");
                return ApiResponse<StockTransactionDto>.ErrorResult("Stok hareketi yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<StockTransactionDto>> CreateStockTransactionAsync(CreateStockTransactionDto createDto)
        {
            try
            {
                return await _apiService.PostAsync<StockTransactionDto>("api/Stock/transactions", createDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating stock transaction");
                return ApiResponse<StockTransactionDto>.ErrorResult("Stok hareketi oluşturulurken hata oluştu.");
            }
        }

        public async Task<ApiResponse<List<StockTransactionDto>>> GetTransactionsByProductAsync(int productId)
        {
            try
            {
                return await _apiService.GetAsync<List<StockTransactionDto>>($"api/Stock/transactions/by-product/{productId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting transactions for product {productId}");
                return ApiResponse<List<StockTransactionDto>>.ErrorResult("Ürün hareketleri yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<List<StockTransactionDto>>> GetTransactionsByWarehouseAsync(int warehouseId)
        {
            try
            {
                return await _apiService.GetAsync<List<StockTransactionDto>>($"api/Stock/transactions/by-warehouse/{warehouseId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting transactions for warehouse {warehouseId}");
                return ApiResponse<List<StockTransactionDto>>.ErrorResult("Depo hareketleri yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<List<StockTransactionDto>>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _apiService.GetAsync<List<StockTransactionDto>>($"api/Stock/transactions/by-date-range?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting transactions for date range {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");
                return ApiResponse<List<StockTransactionDto>>.ErrorResult("Tarih aralığı hareketleri yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<bool>> ProcessStockMovementAsync(CreateStockMovementDto movementDto)
        {
            try
            {
                return await _apiService.PostAsync<bool>("api/Stock/transfer", movementDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing stock movement");
                return ApiResponse<bool>.ErrorResult("Stok hareketi işlenirken hata oluştu.");
            }
        }

        #endregion

        #region Depo İşlemleri

        public async Task<ApiResponse<PagedResult<WarehouseDto>>> GetWarehousesAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                var query = $"PageNumber={page}&PageSize={pageSize}";
                return await _apiService.GetAsync<PagedResult<WarehouseDto>>($"api/Stock/warehouses?{query}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting warehouses");
                return ApiResponse<PagedResult<WarehouseDto>>.ErrorResult("Depolar yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<List<WarehouseDto>>> GetActiveWarehousesAsync()
        {
            try
            {
                return await _apiService.GetAsync<List<WarehouseDto>>("api/Stock/warehouses/active");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting active warehouses");
                return ApiResponse<List<WarehouseDto>>.ErrorResult("Aktif depolar yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<WarehouseDto>> GetWarehouseByIdAsync(int id)
        {
            try
            {
                return await _apiService.GetAsync<WarehouseDto>($"api/Stock/warehouses/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting warehouse {id}");
                return ApiResponse<WarehouseDto>.ErrorResult("Depo yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<WarehouseDto>> CreateWarehouseAsync(CreateWarehouseDto createDto)
        {
            try
            {
                return await _apiService.PostAsync<WarehouseDto>("api/Stock/warehouses", createDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating warehouse");
                return ApiResponse<WarehouseDto>.ErrorResult("Depo oluşturulurken hata oluştu.");
            }
        }

        public async Task<ApiResponse<WarehouseDto>> UpdateWarehouseAsync(int id, UpdateWarehouseDto updateDto)
        {
            try
            {
                return await _apiService.PutAsync<WarehouseDto>($"api/Stock/warehouses/{id}", updateDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating warehouse {id}");
                return ApiResponse<WarehouseDto>.ErrorResult("Depo güncellenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<bool>> DeleteWarehouseAsync(int id)
        {
            try
            {
                return await _apiService.DeleteAsync<bool>($"api/Stock/warehouses/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting warehouse {id}");
                return ApiResponse<bool>.ErrorResult("Depo silinirken hata oluştu.");
            }
        }

        #endregion

        #region Raporlar

        public async Task<ApiResponse<StockSummaryDto>> GetStockSummaryAsync()
        {
            try
            {
                return await _apiService.GetAsync<StockSummaryDto>("api/Stock/summary");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting stock summary");
                return ApiResponse<StockSummaryDto>.ErrorResult("Stok özeti yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<StockReportDto>> GetStockReportAsync(int? warehouseId = null, int? categoryId = null)
        {
            try
            {
                var query = new List<string>();
                if (warehouseId.HasValue)
                    query.Add($"warehouseId={warehouseId.Value}");
                if (categoryId.HasValue)
                    query.Add($"categoryId={categoryId.Value}");

                var queryString = query.Count > 0 ? "?" + string.Join("&", query) : "";
                return await _apiService.GetAsync<StockReportDto>($"api/Stock/report{queryString}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting stock report");
                return ApiResponse<StockReportDto>.ErrorResult("Stok raporu yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<decimal>> GetTotalStockValueAsync()
        {
            try
            {
                return await _apiService.GetAsync<decimal>("api/Stock/total-value");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total stock value");
                return ApiResponse<decimal>.ErrorResult("Toplam stok değeri yüklenirken hata oluştu.");
            }
        }

        public async Task<ApiResponse<decimal>> GetTotalStockValueByWarehouseAsync(int warehouseId)
        {
            try
            {
                return await _apiService.GetAsync<decimal>($"api/Stock/total-value/by-warehouse/{warehouseId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting total stock value for warehouse {warehouseId}");
                return ApiResponse<decimal>.ErrorResult("Depo stok değeri yüklenirken hata oluştu.");
            }
        }

        #endregion
    }
} 