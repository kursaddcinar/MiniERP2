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

        // Product Methods
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

        // Category Methods
        public async Task<ApiResponse<List<ProductCategoryDto>>> GetCategoriesAsync()
        {
            EnsureAuthenticated();
            return await _apiService.GetAsync<List<ProductCategoryDto>>("api/ProductCategory");
        }

        public async Task<ApiResponse<List<ProductCategoryDto>>> GetActiveCategoriesAsync()
        {
            EnsureAuthenticated();
            return await _apiService.GetAsync<List<ProductCategoryDto>>("api/ProductCategory/active");
        }

        public async Task<ApiResponse<ProductCategoryDto>> GetCategoryByIdAsync(int id)
        {
            EnsureAuthenticated();
            return await _apiService.GetAsync<ProductCategoryDto>($"api/ProductCategory/{id}");
        }

        public async Task<ApiResponse<ProductCategoryDto>> CreateCategoryAsync(CreateProductCategoryDto createDto)
        {
            EnsureAuthenticated();
            return await _apiService.PostAsync<ProductCategoryDto>("api/ProductCategory", createDto);
        }

        public async Task<ApiResponse<ProductCategoryDto>> UpdateCategoryAsync(int id, UpdateProductCategoryDto updateDto)
        {
            EnsureAuthenticated();
            return await _apiService.PutAsync<ProductCategoryDto>($"api/ProductCategory/{id}", updateDto);
        }

        public async Task<ApiResponse<bool>> DeleteCategoryAsync(int id)
        {
            EnsureAuthenticated();
            return await _apiService.DeleteAsync<bool>($"api/ProductCategory/{id}");
        }

        public async Task<ApiResponse<bool>> ActivateCategoryAsync(int id)
        {
            EnsureAuthenticated();
            return await _apiService.PostAsync<bool>($"api/ProductCategory/{id}/activate", new { });
        }

        public async Task<ApiResponse<bool>> DeactivateCategoryAsync(int id)
        {
            EnsureAuthenticated();
            return await _apiService.PostAsync<bool>($"api/ProductCategory/{id}/deactivate", new { });
        }

        // Unit Methods
        public async Task<ApiResponse<List<UnitDto>>> GetUnitsAsync()
        {
            EnsureAuthenticated();
            return await _apiService.GetAsync<List<UnitDto>>("api/Unit");
        }

        public async Task<ApiResponse<List<UnitDto>>> GetActiveUnitsAsync()
        {
            EnsureAuthenticated();
            return await _apiService.GetAsync<List<UnitDto>>("api/Unit/active");
        }

        public async Task<ApiResponse<UnitDto>> GetUnitByIdAsync(int id)
        {
            EnsureAuthenticated();
            return await _apiService.GetAsync<UnitDto>($"api/Unit/{id}");
        }

        public async Task<ApiResponse<UnitDto>> CreateUnitAsync(CreateUnitDto createDto)
        {
            EnsureAuthenticated();
            return await _apiService.PostAsync<UnitDto>("api/Unit", createDto);
        }

        public async Task<ApiResponse<UnitDto>> UpdateUnitAsync(int id, UpdateUnitDto updateDto)
        {
            EnsureAuthenticated();
            return await _apiService.PutAsync<UnitDto>($"api/Unit/{id}", updateDto);
        }

        public async Task<ApiResponse<bool>> DeleteUnitAsync(int id)
        {
            EnsureAuthenticated();
            return await _apiService.DeleteAsync<bool>($"api/Unit/{id}");
        }

        public async Task<ApiResponse<bool>> ActivateUnitAsync(int id)
        {
            EnsureAuthenticated();
            return await _apiService.PostAsync<bool>($"api/Unit/{id}/activate", new { });
        }

        public async Task<ApiResponse<bool>> DeactivateUnitAsync(int id)
        {
            EnsureAuthenticated();
            return await _apiService.PostAsync<bool>($"api/Unit/{id}/deactivate", new { });
        }
    }
} 