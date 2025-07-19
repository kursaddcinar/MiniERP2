using MiniERP.Web.Models;

namespace MiniERP.Web.Services
{
    public class PurchaseInvoiceService
    {
        private readonly ApiService _apiService;

        public PurchaseInvoiceService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<PagedResult<PurchaseInvoiceDto>> GetPurchaseInvoicesAsync(int pageNumber = 1, int pageSize = 10, string searchTerm = "", string status = "", DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var queryParams = new List<string>
                {
                    $"pageNumber={pageNumber}",
                    $"pageSize={pageSize}"
                };

                if (!string.IsNullOrEmpty(searchTerm))
                    queryParams.Add($"searchTerm={Uri.EscapeDataString(searchTerm)}");

                if (!string.IsNullOrEmpty(status))
                    queryParams.Add($"status={Uri.EscapeDataString(status)}");

                if (startDate.HasValue)
                    queryParams.Add($"startDate={startDate.Value:yyyy-MM-dd}");

                if (endDate.HasValue)
                    queryParams.Add($"endDate={endDate.Value:yyyy-MM-dd}");

                var queryString = string.Join("&", queryParams);
                var result = await _apiService.GetAsync<PagedResult<PurchaseInvoiceDto>>($"api/PurchaseInvoices?{queryString}");
                
                return result.Data ?? new PagedResult<PurchaseInvoiceDto> { Data = new List<PurchaseInvoiceDto>(), TotalCount = 0 };
            }
            catch (Exception ex)
            {
                return new PagedResult<PurchaseInvoiceDto> { Data = new List<PurchaseInvoiceDto>(), TotalCount = 0 };
            }
        }

        public async Task<PurchaseInvoiceDto> GetPurchaseInvoiceByIdAsync(int id)
        {
            try
            {
                var result = await _apiService.GetAsync<PurchaseInvoiceDto>($"api/PurchaseInvoices/{id}/details");
                return result.Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ApiResponse<PurchaseInvoiceDto>> CreatePurchaseInvoiceAsync(CreatePurchaseInvoiceDto createDto)
        {
            try
            {
                return await _apiService.PostAsync<PurchaseInvoiceDto>("api/PurchaseInvoices", createDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<PurchaseInvoiceDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PurchaseInvoiceDto>> UpdatePurchaseInvoiceAsync(int id, UpdatePurchaseInvoiceDto updateDto)
        {
            try
            {
                return await _apiService.PutAsync<PurchaseInvoiceDto>($"api/PurchaseInvoices/{id}", updateDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<PurchaseInvoiceDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeletePurchaseInvoiceAsync(int id)
        {
            try
            {
                return await _apiService.DeleteAsync<bool>($"api/PurchaseInvoices/{id}");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> ApprovePurchaseInvoiceAsync(int id, InvoiceApprovalDto approvalDto)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/PurchaseInvoices/{id}/approve", approvalDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> CancelPurchaseInvoiceAsync(int id, InvoiceCancellationDto cancellationDto)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/PurchaseInvoices/{id}/cancel", cancellationDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<InvoiceSummaryDto> GetPurchaseInvoiceSummaryAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var queryParams = new List<string>();

                if (startDate.HasValue)
                    queryParams.Add($"startDate={startDate.Value:yyyy-MM-dd}");

                if (endDate.HasValue)
                    queryParams.Add($"endDate={endDate.Value:yyyy-MM-dd}");

                var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
                var result = await _apiService.GetAsync<InvoiceSummaryDto>($"api/PurchaseInvoices/summary{queryString}");
                
                return result.Data ?? new InvoiceSummaryDto();
            }
            catch (Exception ex)
            {
                return new InvoiceSummaryDto();
            }
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            try
            {
                var result = await _apiService.GetAsync<PagedResult<ProductDto>>("api/Products?pageSize=1000");
                return result.Data?.Data ?? new List<ProductDto>();
            }
            catch (Exception ex)
            {
                return new List<ProductDto>();
            }
        }

        public async Task<List<CariAccountDto>> GetCariAccountsAsync()
        {
            try
            {
                var result = await _apiService.GetAsync<List<CariAccountDto>>("api/CariAccounts/suppliers");
                return result.Data ?? new List<CariAccountDto>();
            }
            catch (Exception ex)
            {
                return new List<CariAccountDto>();
            }
        }

        public async Task<List<WarehouseDto>> GetWarehousesAsync()
        {
            try
            {
                var result = await _apiService.GetAsync<PagedResult<WarehouseDto>>("api/Stock/warehouses?pageSize=1000");
                return result.Data?.Data ?? new List<WarehouseDto>();
            }
            catch (Exception ex)
            {
                return new List<WarehouseDto>();
            }
        }
    }
} 