using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.API.DTOs;
using MiniERP.API.Models;
using MiniERP.API.Repositories;
using AutoMapper;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductCategoryController> _logger;

        public ProductCategoryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductCategoryController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Tüm ürün kategorilerini getir
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ProductCategoryDto>>>> GetProductCategories()
        {
            try
            {
                var categories = await _unitOfWork.ProductCategories.GetAllAsync();
                var categoryDtos = _mapper.Map<List<ProductCategoryDto>>(categories);
                
                return Ok(ApiResponse<List<ProductCategoryDto>>.SuccessResult(categoryDtos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting product categories");
                return BadRequest(ApiResponse<List<ProductCategoryDto>>.ErrorResult("An error occurred while getting product categories"));
            }
        }

        /// <summary>
        /// Aktif ürün kategorilerini getir
        /// </summary>
        [HttpGet("active")]
        public async Task<ActionResult<ApiResponse<List<ProductCategoryDto>>>> GetActiveProductCategories()
        {
            try
            {
                var categories = await _unitOfWork.ProductCategories.FindAsync(c => c.IsActive);
                var categoryDtos = _mapper.Map<List<ProductCategoryDto>>(categories);
                
                return Ok(ApiResponse<List<ProductCategoryDto>>.SuccessResult(categoryDtos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting active product categories");
                return BadRequest(ApiResponse<List<ProductCategoryDto>>.ErrorResult("An error occurred while getting active product categories"));
            }
        }

        /// <summary>
        /// ID'ye göre ürün kategorisi getir
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<ProductCategoryDto>>> GetProductCategory(int id)
        {
            try
            {
                var category = await _unitOfWork.ProductCategories.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(ApiResponse<ProductCategoryDto>.ErrorResult("Product category not found"));
                }

                var categoryDto = _mapper.Map<ProductCategoryDto>(category);
                return Ok(ApiResponse<ProductCategoryDto>.SuccessResult(categoryDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting product category {CategoryId}", id);
                return BadRequest(ApiResponse<ProductCategoryDto>.ErrorResult("An error occurred while getting product category"));
            }
        }

        /// <summary>
        /// Yeni ürün kategorisi oluştur
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<ProductCategoryDto>>> CreateProductCategory([FromBody] CreateProductCategoryDto createCategoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<ProductCategoryDto>.ErrorResult("Invalid input data"));
                }

                // Check if category code is unique
                var existingCategory = await _unitOfWork.ProductCategories.FindAsync(c => c.CategoryCode == createCategoryDto.CategoryCode);
                if (existingCategory.Any())
                {
                    return BadRequest(ApiResponse<ProductCategoryDto>.ErrorResult("Category code already exists"));
                }

                var category = _mapper.Map<ProductCategory>(createCategoryDto);
                category.IsActive = true;
                category.CreatedDate = DateTime.Now;

                await _unitOfWork.ProductCategories.AddAsync(category);
                await _unitOfWork.SaveChangesAsync();

                var categoryDto = _mapper.Map<ProductCategoryDto>(category);
                _logger.LogInformation("Product category {CategoryCode} created successfully", createCategoryDto.CategoryCode);
                
                return CreatedAtAction(nameof(GetProductCategory), new { id = category.CategoryID }, 
                    ApiResponse<ProductCategoryDto>.SuccessResult(categoryDto, "Product category created successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product category {CategoryCode}", createCategoryDto.CategoryCode);
                return BadRequest(ApiResponse<ProductCategoryDto>.ErrorResult("An error occurred while creating product category"));
            }
        }

        /// <summary>
        /// Ürün kategorisi güncelle
        /// </summary>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<ProductCategoryDto>>> UpdateProductCategory(int id, [FromBody] UpdateProductCategoryDto updateCategoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<ProductCategoryDto>.ErrorResult("Invalid input data"));
                }

                var category = await _unitOfWork.ProductCategories.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(ApiResponse<ProductCategoryDto>.ErrorResult("Product category not found"));
                }

                // CategoryCode is not updatable, so no need to check uniqueness for update

                _mapper.Map(updateCategoryDto, category);
                await _unitOfWork.ProductCategories.UpdateAsync(category);
                await _unitOfWork.SaveChangesAsync();

                var categoryDto = _mapper.Map<ProductCategoryDto>(category);
                _logger.LogInformation("Product category {CategoryId} updated successfully", id);
                
                return Ok(ApiResponse<ProductCategoryDto>.SuccessResult(categoryDto, "Product category updated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product category {CategoryId}", id);
                return BadRequest(ApiResponse<ProductCategoryDto>.ErrorResult("An error occurred while updating product category"));
            }
        }

        /// <summary>
        /// Ürün kategorisi sil
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProductCategory(int id)
        {
            try
            {
                var category = await _unitOfWork.ProductCategories.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResult("Product category not found"));
                }

                // Check if category is being used in products
                var hasProducts = await _unitOfWork.Products.FindAsync(p => p.CategoryID == id);
                if (hasProducts.Any())
                {
                    return BadRequest(ApiResponse<bool>.ErrorResult("Cannot delete category. It is being used in products."));
                }

                await _unitOfWork.ProductCategories.DeleteAsync(category);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Product category {CategoryId} deleted successfully", id);
                return Ok(ApiResponse<bool>.SuccessResult(true, "Product category deleted successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product category {CategoryId}", id);
                return BadRequest(ApiResponse<bool>.ErrorResult("An error occurred while deleting product category"));
            }
        }

        /// <summary>
        /// Ürün kategorisini aktif et
        /// </summary>
        [HttpPost("{id:int}/activate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> ActivateProductCategory(int id)
        {
            try
            {
                var category = await _unitOfWork.ProductCategories.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResult("Product category not found"));
                }

                category.IsActive = true;
                await _unitOfWork.ProductCategories.UpdateAsync(category);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Product category {CategoryId} activated successfully", id);
                return Ok(ApiResponse<bool>.SuccessResult(true, "Product category activated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error activating product category {CategoryId}", id);
                return BadRequest(ApiResponse<bool>.ErrorResult("An error occurred while activating product category"));
            }
        }

        /// <summary>
        /// Ürün kategorisini pasif et
        /// </summary>
        [HttpPost("{id:int}/deactivate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> DeactivateProductCategory(int id)
        {
            try
            {
                var category = await _unitOfWork.ProductCategories.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResult("Product category not found"));
                }

                category.IsActive = false;
                await _unitOfWork.ProductCategories.UpdateAsync(category);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Product category {CategoryId} deactivated successfully", id);
                return Ok(ApiResponse<bool>.SuccessResult(true, "Product category deactivated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deactivating product category {CategoryId}", id);
                return BadRequest(ApiResponse<bool>.ErrorResult("An error occurred while deactivating product category"));
            }
        }
    }
} 