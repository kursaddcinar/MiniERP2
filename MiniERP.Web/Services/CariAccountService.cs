using MiniERP.Web.Models;

namespace MiniERP.Web.Services
{
    public class CariAccountService
    {
        private readonly ApiService _apiService;

        public CariAccountService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<PagedResult<CariAccountDto>> GetCariAccountsAsync(int pageNumber = 1, int pageSize = 10, string searchTerm = "", int? typeId = null)
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

                if (typeId.HasValue)
                    queryParams.Add($"typeId={typeId.Value}");

                var queryString = string.Join("&", queryParams);
                var result = await _apiService.GetAsync<PagedResult<CariAccountDto>>($"api/CariAccounts?{queryString}");
                
                return result.Data ?? new PagedResult<CariAccountDto> { Data = new List<CariAccountDto>(), TotalCount = 0 };
            }
            catch (Exception ex)
            {
                return new PagedResult<CariAccountDto> { Data = new List<CariAccountDto>(), TotalCount = 0 };
            }
        }

        public async Task<CariAccountDto> GetCariAccountByIdAsync(int id)
        {
            try
            {
                var result = await _apiService.GetAsync<CariAccountDto>($"api/CariAccounts/{id}");
                return result.Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CariAccountDto> GetCariAccountByCodeAsync(string code)
        {
            try
            {
                var result = await _apiService.GetAsync<CariAccountDto>($"api/CariAccounts/by-code/{code}");
                return result.Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ApiResponse<CariAccountDto>> CreateCariAccountAsync(CreateCariAccountDto createDto)
        {
            try
            {
                return await _apiService.PostAsync<CariAccountDto>("api/CariAccounts", createDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<CariAccountDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CariAccountDto>> UpdateCariAccountAsync(int id, UpdateCariAccountDto updateDto)
        {
            try
            {
                return await _apiService.PutAsync<CariAccountDto>($"api/CariAccounts/{id}", updateDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<CariAccountDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteCariAccountAsync(int id)
        {
            try
            {
                return await _apiService.DeleteAsync<bool>($"api/CariAccounts/{id}");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<List<CariAccountDto>> GetCustomersAsync()
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

        public async Task<List<CariAccountDto>> GetSuppliersAsync()
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

        public async Task<List<CariTypeDto>> GetCariTypesAsync()
        {
            try
            {
                var result = await _apiService.GetAsync<PagedResult<CariTypeDto>>("api/CariAccounts/types");
                return result.Data?.Data ?? new List<CariTypeDto>();
            }
            catch (Exception ex)
            {
                return new List<CariTypeDto>();
            }
        }

        public async Task<List<CariTransactionDto>> GetCariTransactionsAsync(int cariAccountId, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var queryParams = new List<string>();

                if (startDate.HasValue)
                    queryParams.Add($"startDate={startDate.Value:yyyy-MM-dd}");

                if (endDate.HasValue)
                    queryParams.Add($"endDate={endDate.Value:yyyy-MM-dd}");

                var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
                var result = await _apiService.GetAsync<PagedResult<CariTransactionDto>>($"api/CariAccounts/{cariAccountId}/transactions{queryString}");
                
                return result.Data?.Data ?? new List<CariTransactionDto>();
            }
            catch (Exception ex)
            {
                return new List<CariTransactionDto>();
            }
        }

        public async Task<CariStatementDto> GetCariStatementAsync(int cariAccountId, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var queryParams = new List<string>();

                if (startDate.HasValue)
                    queryParams.Add($"startDate={startDate.Value:yyyy-MM-dd}");

                if (endDate.HasValue)
                    queryParams.Add($"endDate={endDate.Value:yyyy-MM-dd}");

                var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
                var result = await _apiService.GetAsync<CariStatementDto>($"api/CariAccounts/{cariAccountId}/statement{queryString}");
                
                return result.Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> GetTotalCariCountAsync()
        {
            try
            {
                var customers = await GetCustomersAsync();
                var suppliers = await GetSuppliersAsync();
                
                // Müşteri ve tedarikçilerde aynı cari hesap ID'leri olabileceği için unique ID'leri alıyoruz
                var customerIds = customers.Select(c => c.CariAccountID).ToHashSet();
                var supplierIds = suppliers.Select(s => s.CariAccountID).ToHashSet();
                
                // Toplam unique cari hesap sayısı
                var totalUniqueIds = customerIds.Union(supplierIds).Count();
                
                return totalUniqueIds;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
} 