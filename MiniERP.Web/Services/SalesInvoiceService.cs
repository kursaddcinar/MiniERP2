using MiniERP.Web.Models;

namespace MiniERP.Web.Services
{
    public class SalesInvoiceService
    {
        private readonly ApiService _apiService;

        public SalesInvoiceService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<PagedResult<SalesInvoiceDto>> GetSalesInvoicesAsync(int pageNumber = 1, int pageSize = 10, string searchTerm = "", string status = "", DateTime? startDate = null, DateTime? endDate = null)
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
                var result = await _apiService.GetAsync<PagedResult<SalesInvoiceDto>>($"api/SalesInvoices?{queryString}");
                
                return result.Data ?? new PagedResult<SalesInvoiceDto> { Data = new List<SalesInvoiceDto>(), TotalCount = 0 };
            }
            catch (Exception ex)
            {
                return new PagedResult<SalesInvoiceDto> { Data = new List<SalesInvoiceDto>(), TotalCount = 0 };
            }
        }

        public async Task<SalesInvoiceDto> GetSalesInvoiceByIdAsync(int id)
        {
            try
            {
                var result = await _apiService.GetAsync<SalesInvoiceDto>($"api/SalesInvoices/{id}/details");
                return result.Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ApiResponse<SalesInvoiceDto>> CreateSalesInvoiceAsync(CreateSalesInvoiceDto createDto)
        {
            try
            {
                return await _apiService.PostAsync<SalesInvoiceDto>("api/SalesInvoices", createDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<SalesInvoiceDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<SalesInvoiceDto>> UpdateSalesInvoiceAsync(int id, UpdateSalesInvoiceDto updateDto)
        {
            try
            {
                return await _apiService.PutAsync<SalesInvoiceDto>($"api/SalesInvoices/{id}", updateDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<SalesInvoiceDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteSalesInvoiceAsync(int id)
        {
            try
            {
                return await _apiService.DeleteAsync<bool>($"api/SalesInvoices/{id}");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> ApproveSalesInvoiceAsync(int id, InvoiceApprovalDto approvalDto)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/SalesInvoices/{id}/approve", approvalDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> CancelSalesInvoiceAsync(int id, InvoiceCancellationDto cancellationDto)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/SalesInvoices/{id}/cancel", cancellationDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<InvoiceSummaryDto> GetSalesInvoiceSummaryAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var queryParams = new List<string>();

                if (startDate.HasValue)
                    queryParams.Add($"startDate={startDate.Value:yyyy-MM-dd}");

                if (endDate.HasValue)
                    queryParams.Add($"endDate={endDate.Value:yyyy-MM-dd}");

                var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
                var result = await _apiService.GetAsync<InvoiceSummaryDto>($"api/SalesInvoices/summary{queryString}");
                
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
                var result = await _apiService.GetAsync<List<CariAccountDto>>("api/CariAccounts/customers");
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