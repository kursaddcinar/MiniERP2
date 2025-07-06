using AutoMapper;
using MiniERP.API.DTOs;
using MiniERP.API.Models;
using MiniERP.API.Repositories;

namespace MiniERP.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        #region Product Operations

        public async Task<ApiResponse<PagedResult<ProductDto>>> GetProductsAsync(PaginationParameters parameters, string? searchTerm = null, int? categoryId = null)
        {
            try
            {
                IEnumerable<Product> products;

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = await _unitOfWork.Products.SearchProductsAsync(searchTerm);
                }
                else if (categoryId.HasValue)
                {
                    products = await _unitOfWork.Products.GetProductsByCategoryAsync(categoryId.Value);
                }
                else
                {
                    products = await _unitOfWork.Products.GetActiveProductsAsync();
                }

                var totalCount = products.Count();
                var pagedProducts = products
                    .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                    .Take(parameters.PageSize)
                    .ToList();

                var productDtos = _mapper.Map<List<ProductDto>>(pagedProducts);
                var pagedResult = new PagedResult<ProductDto>(productDtos, totalCount, parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<ProductDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting products");
                return ApiResponse<PagedResult<ProductDto>>.ErrorResult("An error occurred while getting products");
            }
        }

        public async Task<ApiResponse<ProductDto>> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetProductWithDetailsAsync(id);
                if (product == null)
                {
                    return ApiResponse<ProductDto>.ErrorResult("Product not found");
                }

                var productDto = _mapper.Map<ProductDto>(product);
                return ApiResponse<ProductDto>.SuccessResult(productDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting product {ProductId}", id);
                return ApiResponse<ProductDto>.ErrorResult("An error occurred while getting product");
            }
        }

        public async Task<ApiResponse<ProductDto>> GetProductByCodeAsync(string code)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByCodeAsync(code);
                if (product == null)
                {
                    return ApiResponse<ProductDto>.ErrorResult("Product not found");
                }

                var productDto = _mapper.Map<ProductDto>(product);
                return ApiResponse<ProductDto>.SuccessResult(productDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting product by code {ProductCode}", code);
                return ApiResponse<ProductDto>.ErrorResult("An error occurred while getting product");
            }
        }

        public async Task<ApiResponse<ProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            try
            {
                // Check if product code is unique
                if (!await _unitOfWork.Products.IsProductCodeUniqueAsync(createProductDto.ProductCode))
                {
                    return ApiResponse<ProductDto>.ErrorResult("Product code already exists");
                }

                // Validate unit exists
                var unit = await _unitOfWork.Units.GetByIdAsync(createProductDto.UnitID);
                if (unit == null)
                {
                    return ApiResponse<ProductDto>.ErrorResult("Unit not found");
                }

                // Validate category exists (if provided)
                if (createProductDto.CategoryID.HasValue)
                {
                    var category = await _unitOfWork.ProductCategories.GetByIdAsync(createProductDto.CategoryID.Value);
                    if (category == null)
                    {
                        return ApiResponse<ProductDto>.ErrorResult("Category not found");
                    }
                }

                var product = _mapper.Map<Product>(createProductDto);
                product.CreatedDate = DateTime.Now;
                product.IsActive = true;

                await _unitOfWork.Products.AddAsync(product);
                await _unitOfWork.SaveChangesAsync();

                var productWithDetails = await _unitOfWork.Products.GetProductWithDetailsAsync(product.ProductID);
                var productDto = _mapper.Map<ProductDto>(productWithDetails);

                _logger.LogInformation("Product {ProductCode} created successfully", createProductDto.ProductCode);
                return ApiResponse<ProductDto>.SuccessResult(productDto, "Product created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product {ProductCode}", createProductDto.ProductCode);
                return ApiResponse<ProductDto>.ErrorResult("An error occurred while creating product");
            }
        }

        public async Task<ApiResponse<ProductDto>> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(id);
                if (product == null)
                {
                    return ApiResponse<ProductDto>.ErrorResult("Product not found");
                }

                // Validate unit exists
                var unit = await _unitOfWork.Units.GetByIdAsync(updateProductDto.UnitID);
                if (unit == null)
                {
                    return ApiResponse<ProductDto>.ErrorResult("Unit not found");
                }

                // Validate category exists (if provided)
                if (updateProductDto.CategoryID.HasValue)
                {
                    var category = await _unitOfWork.ProductCategories.GetByIdAsync(updateProductDto.CategoryID.Value);
                    if (category == null)
                    {
                        return ApiResponse<ProductDto>.ErrorResult("Category not found");
                    }
                }

                _mapper.Map(updateProductDto, product);
                await _unitOfWork.Products.UpdateAsync(product);
                await _unitOfWork.SaveChangesAsync();

                var productWithDetails = await _unitOfWork.Products.GetProductWithDetailsAsync(id);
                var productDto = _mapper.Map<ProductDto>(productWithDetails);

                _logger.LogInformation("Product {ProductId} updated successfully", id);
                return ApiResponse<ProductDto>.SuccessResult(productDto, "Product updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product {ProductId}", id);
                return ApiResponse<ProductDto>.ErrorResult("An error occurred while updating product");
            }
        }

        public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(id);
                if (product == null)
                {
                    return ApiResponse<bool>.ErrorResult("Product not found");
                }

                await _unitOfWork.Products.DeleteAsync(product);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Product {ProductId} deleted successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Product deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product {ProductId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while deleting product");
            }
        }

        public async Task<ApiResponse<bool>> ActivateProductAsync(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(id);
                if (product == null)
                {
                    return ApiResponse<bool>.ErrorResult("Product not found");
                }

                product.IsActive = true;
                await _unitOfWork.Products.UpdateAsync(product);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Product {ProductId} activated successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Product activated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error activating product {ProductId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while activating product");
            }
        }

        public async Task<ApiResponse<bool>> DeactivateProductAsync(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(id);
                if (product == null)
                {
                    return ApiResponse<bool>.ErrorResult("Product not found");
                }

                product.IsActive = false;
                await _unitOfWork.Products.UpdateAsync(product);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Product {ProductId} deactivated successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Product deactivated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deactivating product {ProductId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while deactivating product");
            }
        }

        public async Task<ApiResponse<List<ProductDto>>> GetLowStockProductsAsync()
        {
            try
            {
                var products = await _unitOfWork.Products.GetLowStockProductsAsync();
                var productDtos = _mapper.Map<List<ProductDto>>(products);

                return ApiResponse<List<ProductDto>>.SuccessResult(productDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting low stock products");
                return ApiResponse<List<ProductDto>>.ErrorResult("An error occurred while getting low stock products");
            }
        }

        #endregion

        #region Product Category Operations

        public async Task<ApiResponse<PagedResult<ProductCategoryDto>>> GetCategoriesAsync(PaginationParameters parameters)
        {
            try
            {
                var (categories, totalCount) = await _unitOfWork.ProductCategories.GetPagedWithCountAsync(
                    parameters.PageNumber,
                    parameters.PageSize);

                var categoryDtos = _mapper.Map<List<ProductCategoryDto>>(categories);
                var pagedResult = new PagedResult<ProductCategoryDto>(categoryDtos, totalCount, parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<ProductCategoryDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting categories");
                return ApiResponse<PagedResult<ProductCategoryDto>>.ErrorResult("An error occurred while getting categories");
            }
        }

        public async Task<ApiResponse<ProductCategoryDto>> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _unitOfWork.ProductCategories.GetByIdAsync(id);
                if (category == null)
                {
                    return ApiResponse<ProductCategoryDto>.ErrorResult("Category not found");
                }

                var categoryDto = _mapper.Map<ProductCategoryDto>(category);
                return ApiResponse<ProductCategoryDto>.SuccessResult(categoryDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting category {CategoryId}", id);
                return ApiResponse<ProductCategoryDto>.ErrorResult("An error occurred while getting category");
            }
        }

        public async Task<ApiResponse<ProductCategoryDto>> CreateCategoryAsync(CreateProductCategoryDto createCategoryDto)
        {
            try
            {
                var category = _mapper.Map<ProductCategory>(createCategoryDto);
                category.CreatedDate = DateTime.Now;
                category.IsActive = true;

                await _unitOfWork.ProductCategories.AddAsync(category);
                await _unitOfWork.SaveChangesAsync();

                var categoryDto = _mapper.Map<ProductCategoryDto>(category);

                _logger.LogInformation("Category {CategoryCode} created successfully", createCategoryDto.CategoryCode);
                return ApiResponse<ProductCategoryDto>.SuccessResult(categoryDto, "Category created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating category {CategoryCode}", createCategoryDto.CategoryCode);
                return ApiResponse<ProductCategoryDto>.ErrorResult("An error occurred while creating category");
            }
        }

        public async Task<ApiResponse<ProductCategoryDto>> UpdateCategoryAsync(int id, UpdateProductCategoryDto updateCategoryDto)
        {
            try
            {
                var category = await _unitOfWork.ProductCategories.GetByIdAsync(id);
                if (category == null)
                {
                    return ApiResponse<ProductCategoryDto>.ErrorResult("Category not found");
                }

                _mapper.Map(updateCategoryDto, category);
                await _unitOfWork.ProductCategories.UpdateAsync(category);
                await _unitOfWork.SaveChangesAsync();

                var categoryDto = _mapper.Map<ProductCategoryDto>(category);

                _logger.LogInformation("Category {CategoryId} updated successfully", id);
                return ApiResponse<ProductCategoryDto>.SuccessResult(categoryDto, "Category updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating category {CategoryId}", id);
                return ApiResponse<ProductCategoryDto>.ErrorResult("An error occurred while updating category");
            }
        }

        public async Task<ApiResponse<bool>> DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _unitOfWork.ProductCategories.GetByIdAsync(id);
                if (category == null)
                {
                    return ApiResponse<bool>.ErrorResult("Category not found");
                }

                await _unitOfWork.ProductCategories.DeleteAsync(category);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Category {CategoryId} deleted successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Category deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting category {CategoryId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while deleting category");
            }
        }

        #endregion

        #region Unit Operations

        public async Task<ApiResponse<PagedResult<UnitDto>>> GetUnitsAsync(PaginationParameters parameters)
        {
            try
            {
                var (units, totalCount) = await _unitOfWork.Units.GetPagedWithCountAsync(
                    parameters.PageNumber,
                    parameters.PageSize);

                var unitDtos = _mapper.Map<List<UnitDto>>(units);
                var pagedResult = new PagedResult<UnitDto>(unitDtos, totalCount, parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<UnitDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting units");
                return ApiResponse<PagedResult<UnitDto>>.ErrorResult("An error occurred while getting units");
            }
        }

        public async Task<ApiResponse<UnitDto>> GetUnitByIdAsync(int id)
        {
            try
            {
                var unit = await _unitOfWork.Units.GetByIdAsync(id);
                if (unit == null)
                {
                    return ApiResponse<UnitDto>.ErrorResult("Unit not found");
                }

                var unitDto = _mapper.Map<UnitDto>(unit);
                return ApiResponse<UnitDto>.SuccessResult(unitDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting unit {UnitId}", id);
                return ApiResponse<UnitDto>.ErrorResult("An error occurred while getting unit");
            }
        }

        public async Task<ApiResponse<UnitDto>> CreateUnitAsync(CreateUnitDto createUnitDto)
        {
            try
            {
                var unit = _mapper.Map<Unit>(createUnitDto);
                unit.CreatedDate = DateTime.Now;
                unit.IsActive = true;

                await _unitOfWork.Units.AddAsync(unit);
                await _unitOfWork.SaveChangesAsync();

                var unitDto = _mapper.Map<UnitDto>(unit);

                _logger.LogInformation("Unit {UnitCode} created successfully", createUnitDto.UnitCode);
                return ApiResponse<UnitDto>.SuccessResult(unitDto, "Unit created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating unit {UnitCode}", createUnitDto.UnitCode);
                return ApiResponse<UnitDto>.ErrorResult("An error occurred while creating unit");
            }
        }

        public async Task<ApiResponse<UnitDto>> UpdateUnitAsync(int id, UpdateUnitDto updateUnitDto)
        {
            try
            {
                var unit = await _unitOfWork.Units.GetByIdAsync(id);
                if (unit == null)
                {
                    return ApiResponse<UnitDto>.ErrorResult("Unit not found");
                }

                _mapper.Map(updateUnitDto, unit);
                await _unitOfWork.Units.UpdateAsync(unit);
                await _unitOfWork.SaveChangesAsync();

                var unitDto = _mapper.Map<UnitDto>(unit);

                _logger.LogInformation("Unit {UnitId} updated successfully", id);
                return ApiResponse<UnitDto>.SuccessResult(unitDto, "Unit updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating unit {UnitId}", id);
                return ApiResponse<UnitDto>.ErrorResult("An error occurred while updating unit");
            }
        }

        public async Task<ApiResponse<bool>> DeleteUnitAsync(int id)
        {
            try
            {
                var unit = await _unitOfWork.Units.GetByIdAsync(id);
                if (unit == null)
                {
                    return ApiResponse<bool>.ErrorResult("Unit not found");
                }

                await _unitOfWork.Units.DeleteAsync(unit);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Unit {UnitId} deleted successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Unit deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting unit {UnitId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while deleting unit");
            }
        }

        #endregion
    }
} 