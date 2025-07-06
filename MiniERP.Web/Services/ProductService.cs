using MiniERP.Web.Models;

namespace MiniERP.Web.Services
{
    public class ProductService
    {
        private readonly ApiService _apiService;
        private readonly AuthService _authService;

        public ProductService(ApiService apiService, AuthService authService)
        {
            _apiService = apiService;
            _authService = authService;
        }

        private void EnsureAuthenticated()
        {
            var token = _authService.GetCurrentToken();
            if (!string.IsNullOrEmpty(token))
            {
                _apiService.SetAuthToken(token);
            }
        }

        public async Task<ApiResponse<PagedResult<ProductDto>>> GetProductsAsync(int pageNumber = 1, int pageSize = 10, string? searchTerm = null, int? categoryId = null)
        {
            EnsureAuthenticated();
            
            var queryParams = new List<string>
            {
                $"pageNumber={pageNumber}",
                $"pageSize={pageSize}"
            };

            if (!string.IsNullOrEmpty(searchTerm))
                queryParams.Add($"searchTerm={Uri.EscapeDataString(searchTerm)}");

            if (categoryId.HasValue)
                queryParams.Add($"categoryId={categoryId.Value}");

            var queryString = string.Join("&", queryParams);
            
            return await _apiService.GetAsync<PagedResult<ProductDto>>($"api/Products?{queryString}");
        }

        public async Task<ApiResponse<ProductDto>> GetProductByIdAsync(int id)
        {
            EnsureAuthenticated();
            return await _apiService.GetAsync<ProductDto>($"api/Products/{id}");
        }

        public async Task<ApiResponse<ProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            EnsureAuthenticated();
            return await _apiService.PostAsync<ProductDto>("api/Products", createProductDto);
        }

        public async Task<ApiResponse<ProductDto>> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            EnsureAuthenticated();
            return await _apiService.PutAsync<ProductDto>($"api/Products/{id}", updateProductDto);
        }

        public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
        {
            EnsureAuthenticated();
            return await _apiService.DeleteAsync<bool>($"api/Products/{id}");
        }

        public async Task<ApiResponse<PagedResult<ProductCategoryDto>>> GetCategoriesAsync(int pageNumber = 1, int pageSize = 50)
        {
            EnsureAuthenticated();
            return await _apiService.GetAsync<PagedResult<ProductCategoryDto>>($"api/Products/categories?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<ApiResponse<PagedResult<UnitDto>>> GetUnitsAsync(int pageNumber = 1, int pageSize = 50)
        {
            EnsureAuthenticated();
            return await _apiService.GetAsync<PagedResult<UnitDto>>($"api/Products/units?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<ApiResponse<List<ProductDto>>> GetLowStockProductsAsync()
        {
            EnsureAuthenticated();
            return await _apiService.GetAsync<List<ProductDto>>("api/Products/low-stock");
        }

        public async Task<ApiResponse<bool>> ActivateProductAsync(int id)
        {
            EnsureAuthenticated();
            return await _apiService.PostAsync<bool>($"api/Products/{id}/activate", new { });
        }

        public async Task<ApiResponse<bool>> DeactivateProductAsync(int id)
        {
            EnsureAuthenticated();
            return await _apiService.PostAsync<bool>($"api/Products/{id}/deactivate", new { });
        }
    }
} 