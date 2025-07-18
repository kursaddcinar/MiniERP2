using MiniERP.Web.Models;

namespace MiniERP.Web.Services
{
    public class PaymentService
    {
        private readonly ApiService _apiService;

        public PaymentService(ApiService apiService)
        {
            _apiService = apiService;
        }

        // Payment Methods
        public async Task<PagedResult<PaymentDto>> GetPaymentsAsync(int pageNumber = 1, int pageSize = 10, string searchTerm = "", int? cariId = null, DateTime? startDate = null, DateTime? endDate = null)
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

                if (cariId.HasValue)
                    queryParams.Add($"cariId={cariId.Value}");

                if (startDate.HasValue)
                    queryParams.Add($"startDate={startDate.Value:yyyy-MM-dd}");

                if (endDate.HasValue)
                    queryParams.Add($"endDate={endDate.Value:yyyy-MM-dd}");

                var queryString = string.Join("&", queryParams);
                var result = await _apiService.GetAsync<PagedResult<PaymentDto>>($"api/Payment?{queryString}");
                
                return result.Data ?? new PagedResult<PaymentDto> { Data = new List<PaymentDto>(), TotalCount = 0 };
            }
            catch (Exception)
            {
                return new PagedResult<PaymentDto> { Data = new List<PaymentDto>(), TotalCount = 0 };
            }
        }

        public async Task<PaymentDto?> GetPaymentByIdAsync(int id)
        {
            try
            {
                var result = await _apiService.GetAsync<PaymentDto>($"api/Payment/{id}");
                return result.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ApiResponse<PaymentDto>> CreatePaymentAsync(CreatePaymentDto createDto)
        {
            try
            {
                return await _apiService.PostAsync<PaymentDto>("api/Payment", createDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<PaymentDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PaymentDto>> UpdatePaymentAsync(int id, UpdatePaymentDto updateDto)
        {
            try
            {
                return await _apiService.PutAsync<PaymentDto>($"api/Payment/{id}", updateDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<PaymentDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeletePaymentAsync(int id)
        {
            try
            {
                return await _apiService.DeleteAsync<bool>($"api/Payment/{id}");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> ActivatePaymentAsync(int id)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/Payment/{id}/activate", new { });
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeactivatePaymentAsync(int id)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/Payment/{id}/deactivate", new { });
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        // Collection Methods
        public async Task<PagedResult<CollectionDto>> GetCollectionsAsync(int pageNumber = 1, int pageSize = 10, string searchTerm = "", int? cariId = null, DateTime? startDate = null, DateTime? endDate = null)
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

                if (cariId.HasValue)
                    queryParams.Add($"cariId={cariId.Value}");

                if (startDate.HasValue)
                    queryParams.Add($"startDate={startDate.Value:yyyy-MM-dd}");

                if (endDate.HasValue)
                    queryParams.Add($"endDate={endDate.Value:yyyy-MM-dd}");

                var queryString = string.Join("&", queryParams);
                var result = await _apiService.GetAsync<PagedResult<CollectionDto>>($"api/Collection?{queryString}");
                
                return result.Data ?? new PagedResult<CollectionDto> { Data = new List<CollectionDto>(), TotalCount = 0 };
            }
            catch (Exception)
            {
                return new PagedResult<CollectionDto> { Data = new List<CollectionDto>(), TotalCount = 0 };
            }
        }

        public async Task<CollectionDto?> GetCollectionByIdAsync(int id)
        {
            try
            {
                var result = await _apiService.GetAsync<CollectionDto>($"api/Collection/{id}");
                return result.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ApiResponse<CollectionDto>> CreateCollectionAsync(CreateCollectionDto createDto)
        {
            try
            {
                return await _apiService.PostAsync<CollectionDto>("api/Collection", createDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<CollectionDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CollectionDto>> UpdateCollectionAsync(int id, UpdateCollectionDto updateDto)
        {
            try
            {
                return await _apiService.PutAsync<CollectionDto>($"api/Collection/{id}", updateDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<CollectionDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteCollectionAsync(int id)
        {
            try
            {
                return await _apiService.DeleteAsync<bool>($"api/Collection/{id}");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> ActivateCollectionAsync(int id)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/Collection/{id}/activate", new { });
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeactivateCollectionAsync(int id)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/Collection/{id}/deactivate", new { });
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        // Payment Type Methods
        public async Task<ApiResponse<List<PaymentTypeDto>>> GetPaymentTypesAsync()
        {
            try
            {
                return await _apiService.GetAsync<List<PaymentTypeDto>>("api/PaymentType");
            }
            catch (Exception ex)
            {
                return ApiResponse<List<PaymentTypeDto>>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<List<PaymentTypeDto>>> GetActivePaymentTypesAsync()
        {
            try
            {
                return await _apiService.GetAsync<List<PaymentTypeDto>>("api/PaymentType/active");
            }
            catch (Exception ex)
            {
                return ApiResponse<List<PaymentTypeDto>>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<PaymentTypeDto?> GetPaymentTypeByIdAsync(int id)
        {
            try
            {
                var result = await _apiService.GetAsync<PaymentTypeDto>($"api/PaymentType/{id}");
                return result.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ApiResponse<PaymentTypeDto>> CreatePaymentTypeAsync(CreatePaymentTypeDto createDto)
        {
            try
            {
                return await _apiService.PostAsync<PaymentTypeDto>("api/PaymentType", createDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<PaymentTypeDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PaymentTypeDto>> UpdatePaymentTypeAsync(int id, UpdatePaymentTypeDto updateDto)
        {
            try
            {
                return await _apiService.PutAsync<PaymentTypeDto>($"api/PaymentType/{id}", updateDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<PaymentTypeDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeletePaymentTypeAsync(int id)
        {
            try
            {
                return await _apiService.DeleteAsync<bool>($"api/PaymentType/{id}");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> ActivatePaymentTypeAsync(int id)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/PaymentType/{id}/activate", new { });
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeactivatePaymentTypeAsync(int id)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/PaymentType/{id}/deactivate", new { });
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }
    }
} 

