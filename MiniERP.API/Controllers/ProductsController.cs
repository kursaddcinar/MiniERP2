using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.API.DTOs;
using MiniERP.API.Services;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        #region Product Endpoints

        /// <summary>
        /// Get paginated list of products with optional search and filtering
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Sales,Purchase,Warehouse")]
        public async Task<ActionResult<ApiResponse<PagedResult<ProductDto>>>> GetProducts(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null,
            [FromQuery] int? categoryId = null)
        {
            var parameters = new PaginationParameters { PageNumber = pageNumber, PageSize = pageSize };
            var result = await _productService.GetProductsAsync(parameters, searchTerm, categoryId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get product by ID
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,Sales,Purchase,Warehouse")]
        public async Task<ActionResult<ApiResponse<ProductDto>>> GetProduct(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get product by code
        /// </summary>
        [HttpGet("by-code/{code}")]
        public async Task<ActionResult<ApiResponse<ProductDto>>> GetProductByCode(string code)
        {
            var result = await _productService.GetProductByCodeAsync(code);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<ProductDto>>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<ProductDto>.ErrorResult("Invalid input data"));
            }

            var result = await _productService.CreateProductAsync(createProductDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetProduct), new { id = result.Data!.ProductID }, result);
        }

        /// <summary>
        /// Update an existing product
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<ProductDto>>> UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<ProductDto>.ErrorResult("Invalid input data"));
            }

            var result = await _productService.UpdateProductAsync(id, updateProductDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Activate a product
        /// </summary>
        [HttpPost("{id}/activate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> ActivateProduct(int id)
        {
            var result = await _productService.ActivateProductAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Deactivate a product
        /// </summary>
        [HttpPost("{id}/deactivate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> DeactivateProduct(int id)
        {
            var result = await _productService.DeactivateProductAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get products with low stock levels
        /// </summary>
        [HttpGet("low-stock")]
        public async Task<ActionResult<ApiResponse<List<ProductDto>>>> GetLowStockProducts()
        {
            var result = await _productService.GetLowStockProductsAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        #endregion

        #region Category Endpoints

        /// <summary>
        /// Get paginated list of product categories
        /// </summary>
        [HttpGet("categories")]
        public async Task<ActionResult<ApiResponse<PagedResult<ProductCategoryDto>>>> GetCategories(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var parameters = new PaginationParameters { PageNumber = pageNumber, PageSize = pageSize };
            var result = await _productService.GetCategoriesAsync(parameters);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get category by ID
        /// </summary>
        [HttpGet("categories/{id}")]
        public async Task<ActionResult<ApiResponse<ProductCategoryDto>>> GetCategory(int id)
        {
            var result = await _productService.GetCategoryByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Create a new product category
        /// </summary>
        [HttpPost("categories")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<ProductCategoryDto>>> CreateCategory([FromBody] CreateProductCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<ProductCategoryDto>.ErrorResult("Invalid input data"));
            }

            var result = await _productService.CreateCategoryAsync(createCategoryDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetCategory), new { id = result.Data!.CategoryID }, result);
        }

        /// <summary>
        /// Update an existing category
        /// </summary>
        [HttpPut("categories/{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<ProductCategoryDto>>> UpdateCategory(int id, [FromBody] UpdateProductCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<ProductCategoryDto>.ErrorResult("Invalid input data"));
            }

            var result = await _productService.UpdateCategoryAsync(id, updateCategoryDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete a category
        /// </summary>
        [HttpDelete("categories/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteCategory(int id)
        {
            var result = await _productService.DeleteCategoryAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        #endregion

        #region Unit Endpoints

        /// <summary>
        /// Get paginated list of units
        /// </summary>
        [HttpGet("units")]
        public async Task<ActionResult<ApiResponse<PagedResult<UnitDto>>>> GetUnits(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var parameters = new PaginationParameters { PageNumber = pageNumber, PageSize = pageSize };
            var result = await _productService.GetUnitsAsync(parameters);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get unit by ID
        /// </summary>
        [HttpGet("units/{id}")]
        public async Task<ActionResult<ApiResponse<UnitDto>>> GetUnit(int id)
        {
            var result = await _productService.GetUnitByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Create a new unit
        /// </summary>
        [HttpPost("units")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<UnitDto>>> CreateUnit([FromBody] CreateUnitDto createUnitDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<UnitDto>.ErrorResult("Invalid input data"));
            }

            var result = await _productService.CreateUnitAsync(createUnitDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetUnit), new { id = result.Data!.UnitID }, result);
        }

        /// <summary>
        /// Update an existing unit
        /// </summary>
        [HttpPut("units/{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<UnitDto>>> UpdateUnit(int id, [FromBody] UpdateUnitDto updateUnitDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<UnitDto>.ErrorResult("Invalid input data"));
            }

            var result = await _productService.UpdateUnitAsync(id, updateUnitDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete a unit
        /// </summary>
        [HttpDelete("units/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteUnit(int id)
        {
            var result = await _productService.DeleteUnitAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        #endregion
    }
}
