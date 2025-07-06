using MiniERP.WinForms.Models;

namespace MiniERP.WinForms.Services
{
    public class ProductService
    {
        private readonly ApiService _apiService;

        public ProductService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<ApiResponse<List<ProductDto>>> GetProductsAsync()
        {
            // Tüm ürünleri almak için pageSize'ı büyük yapıyoruz
            var response = await _apiService.GetAsync<PagedResult<ProductDto>>("/api/products?pageSize=1000");
            
            if (response.Success && response.Data != null)
            {
                return new ApiResponse<List<ProductDto>>
                {
                    Success = true,
                    Data = response.Data.Data,
                    Message = response.Message
                };
            }
            else
            {
                return new ApiResponse<List<ProductDto>>
                {
                    Success = false,
                    Message = response.Message,
                    Errors = response.Errors
                };
            }
        }

        public async Task<ApiResponse<ProductDto>> GetProductByIdAsync(int id)
        {
            return await _apiService.GetAsync<ProductDto>($"/api/products/{id}");
        }

        public async Task<ApiResponse<ProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            return await _apiService.PostAsync<ProductDto>("/api/products", createProductDto);
        }

        public async Task<ApiResponse<ProductDto>> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            return await _apiService.PutAsync<ProductDto>($"/api/products/{id}", updateProductDto);
        }

        public async Task<ApiResponse> DeleteProductAsync(int id)
        {
            return await _apiService.DeleteAsync($"/api/products/{id}");
        }

        public async Task<ApiResponse<List<ProductCategoryDto>>> GetCategoriesAsync()
        {
            var response = await _apiService.GetAsync<PagedResult<ProductCategoryDto>>("/api/products/categories?pageSize=1000");
            
            if (response.Success && response.Data != null)
            {
                return new ApiResponse<List<ProductCategoryDto>>
                {
                    Success = true,
                    Data = response.Data.Data,
                    Message = response.Message
                };
            }
            else
            {
                return new ApiResponse<List<ProductCategoryDto>>
                {
                    Success = false,
                    Message = response.Message,
                    Errors = response.Errors
                };
            }
        }

        public async Task<ApiResponse<List<UnitDto>>> GetUnitsAsync()
        {
            var response = await _apiService.GetAsync<PagedResult<UnitDto>>("/api/products/units?pageSize=1000");
            
            if (response.Success && response.Data != null)
            {
                return new ApiResponse<List<UnitDto>>
                {
                    Success = true,
                    Data = response.Data.Data,
                    Message = response.Message
                };
            }
            else
            {
                return new ApiResponse<List<UnitDto>>
                {
                    Success = false,
                    Message = response.Message,
                    Errors = response.Errors
                };
            }
        }

        #region Enhanced Product Methods

        /// <summary>
        /// Get paginated products with search and filtering
        /// </summary>
        public async Task<ApiResponse<PagedResult<ProductDto>>> GetProductsPagedAsync(int pageNumber = 1, int pageSize = 50, string? searchTerm = null, int? categoryId = null)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";
            
            if (!string.IsNullOrEmpty(searchTerm))
                query += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";
            
            if (categoryId.HasValue)
                query += $"&categoryId={categoryId}";

            return await _apiService.GetAsync<PagedResult<ProductDto>>($"/api/products{query}");
        }

        /// <summary>
        /// Get product by code
        /// </summary>
        public async Task<ApiResponse<ProductDto>> GetProductByCodeAsync(string code)
        {
            return await _apiService.GetAsync<ProductDto>($"/api/products/by-code/{Uri.EscapeDataString(code)}");
        }

        /// <summary>
        /// Activate a product
        /// </summary>
        public async Task<ApiResponse> ActivateProductAsync(int id)
        {
            return await _apiService.PostAsync($"/api/products/{id}/activate", new { });
        }

        /// <summary>
        /// Deactivate a product
        /// </summary>
        public async Task<ApiResponse> DeactivateProductAsync(int id)
        {
            return await _apiService.PostAsync($"/api/products/{id}/deactivate", new { });
        }

        /// <summary>
        /// Get products with low stock levels
        /// </summary>
        public async Task<ApiResponse<List<ProductDto>>> GetLowStockProductsAsync()
        {
            return await _apiService.GetAsync<List<ProductDto>>("/api/products/low-stock");
        }

        #endregion

        #region Category Management

        /// <summary>
        /// Get paginated categories
        /// </summary>
        public async Task<ApiResponse<PagedResult<ProductCategoryDto>>> GetCategoriesPagedAsync(int pageNumber = 1, int pageSize = 50)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";
            return await _apiService.GetAsync<PagedResult<ProductCategoryDto>>($"/api/products/categories{query}");
        }

        /// <summary>
        /// Get category by ID
        /// </summary>
        public async Task<ApiResponse<ProductCategoryDto>> GetCategoryByIdAsync(int id)
        {
            return await _apiService.GetAsync<ProductCategoryDto>($"/api/products/categories/{id}");
        }

        /// <summary>
        /// Create new category
        /// </summary>
        public async Task<ApiResponse<ProductCategoryDto>> CreateCategoryAsync(CreateProductCategoryDto createDto)
        {
            return await _apiService.PostAsync<ProductCategoryDto>("/api/products/categories", createDto);
        }

        /// <summary>
        /// Update existing category
        /// </summary>
        public async Task<ApiResponse<ProductCategoryDto>> UpdateCategoryAsync(int id, UpdateProductCategoryDto updateDto)
        {
            return await _apiService.PutAsync<ProductCategoryDto>($"/api/products/categories/{id}", updateDto);
        }

        /// <summary>
        /// Delete category
        /// </summary>
        public async Task<ApiResponse> DeleteCategoryAsync(int id)
        {
            return await _apiService.DeleteAsync($"/api/products/categories/{id}");
        }

        #endregion

        #region Unit Management

        /// <summary>
        /// Get paginated units
        /// </summary>
        public async Task<ApiResponse<PagedResult<UnitDto>>> GetUnitsPagedAsync(int pageNumber = 1, int pageSize = 50)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";
            return await _apiService.GetAsync<PagedResult<UnitDto>>($"/api/products/units{query}");
        }

        /// <summary>
        /// Get unit by ID
        /// </summary>
        public async Task<ApiResponse<UnitDto>> GetUnitByIdAsync(int id)
        {
            return await _apiService.GetAsync<UnitDto>($"/api/products/units/{id}");
        }

        /// <summary>
        /// Create new unit
        /// </summary>
        public async Task<ApiResponse<UnitDto>> CreateUnitAsync(CreateUnitDto createDto)
        {
            return await _apiService.PostAsync<UnitDto>("/api/products/units", createDto);
        }

        /// <summary>
        /// Update existing unit
        /// </summary>
        public async Task<ApiResponse<UnitDto>> UpdateUnitAsync(int id, UpdateUnitDto updateDto)
        {
            return await _apiService.PutAsync<UnitDto>($"/api/products/units/{id}", updateDto);
        }

        /// <summary>
        /// Delete unit
        /// </summary>
        public async Task<ApiResponse> DeleteUnitAsync(int id)
        {
            return await _apiService.DeleteAsync($"/api/products/units/{id}");
        }

        #endregion
    }
} 