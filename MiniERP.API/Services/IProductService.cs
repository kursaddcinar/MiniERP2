using MiniERP.API.DTOs;

namespace MiniERP.API.Services
{
    public interface IProductService
    {
        // Product operations
        Task<ApiResponse<PagedResult<ProductDto>>> GetProductsAsync(PaginationParameters parameters, string? searchTerm = null, int? categoryId = null);
        Task<ApiResponse<ProductDto>> GetProductByIdAsync(int id);
        Task<ApiResponse<ProductDto>> GetProductByCodeAsync(string code);
        Task<ApiResponse<ProductDto>> CreateProductAsync(CreateProductDto createProductDto);
        Task<ApiResponse<ProductDto>> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
        Task<ApiResponse<bool>> DeleteProductAsync(int id);
        Task<ApiResponse<bool>> ActivateProductAsync(int id);
        Task<ApiResponse<bool>> DeactivateProductAsync(int id);
        Task<ApiResponse<List<ProductDto>>> GetLowStockProductsAsync();

        // Product Category operations
        Task<ApiResponse<PagedResult<ProductCategoryDto>>> GetCategoriesAsync(PaginationParameters parameters);
        Task<ApiResponse<ProductCategoryDto>> GetCategoryByIdAsync(int id);
        Task<ApiResponse<ProductCategoryDto>> CreateCategoryAsync(CreateProductCategoryDto createCategoryDto);
        Task<ApiResponse<ProductCategoryDto>> UpdateCategoryAsync(int id, UpdateProductCategoryDto updateCategoryDto);
        Task<ApiResponse<bool>> DeleteCategoryAsync(int id);

        // Unit operations
        Task<ApiResponse<PagedResult<UnitDto>>> GetUnitsAsync(PaginationParameters parameters);
        Task<ApiResponse<UnitDto>> GetUnitByIdAsync(int id);
        Task<ApiResponse<UnitDto>> CreateUnitAsync(CreateUnitDto createUnitDto);
        Task<ApiResponse<UnitDto>> UpdateUnitAsync(int id, UpdateUnitDto updateUnitDto);
        Task<ApiResponse<bool>> DeleteUnitAsync(int id);
    }
} 