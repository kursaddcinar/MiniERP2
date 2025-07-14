using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniERP.Web.Models;
using MiniERP.Web.Services;

namespace MiniERP.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [Authorize(Roles = "Admin,Manager,Sales,Purchase,Warehouse")]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string? search = null, int? categoryId = null)
        {
            try
            {
                var result = await _productService.GetProductsAsync(page, pageSize, search, categoryId);
                
                if (result.Success && result.Data != null)
                {
                    ViewBag.CurrentPage = page;
                    ViewBag.PageSize = pageSize;
                    ViewBag.Search = search;
                    ViewBag.CategoryId = categoryId;
                    
                    // Get categories for filter dropdown
                    var categories = await _productService.GetCategoriesAsync();
                    if (categories.Success && categories.Data != null)
                    {
                        ViewBag.Categories = categories.Data.Select(c => new SelectListItem
                        {
                            Value = c.CategoryID.ToString(),
                            Text = c.CategoryName
                        }).ToList();
                    }
                    
                    return View(result.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return View(new PagedResult<ProductDto>(new List<ProductDto>(), 0, page, pageSize));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading products");
                TempData["ErrorMessage"] = "Ürünler yüklenirken hata oluştu.";
                return View(new PagedResult<ProductDto>(new List<ProductDto>(), 0, page, pageSize));
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var result = await _productService.GetProductByIdAsync(id);
                
                if (result.Success && result.Data != null)
                {
                    return View(result.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error loading product details for ID: {id}");
                TempData["ErrorMessage"] = "Ürün detayları yüklenirken hata oluştu.";
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Roles = "Admin,Manager,Purchase")]
        public async Task<IActionResult> Create()
        {
            await LoadDropdownData();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Purchase")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductDto model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownData();
                return View(model);
            }

            try
            {
                var result = await _productService.CreateProductAsync(model);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Ürün başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    await LoadDropdownData();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                ModelState.AddModelError(string.Empty, "Ürün oluşturulurken hata oluştu.");
                await LoadDropdownData();
                return View(model);
            }
        }

        [Authorize(Roles = "Admin,Manager,Purchase")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _productService.GetProductByIdAsync(id);
                
                if (result.Success && result.Data != null)
                {
                    var model = new UpdateProductDto
                    {
                        ProductCode = result.Data.ProductCode,
                        ProductName = result.Data.ProductName,
                        Description = result.Data.Description,
                        PurchasePrice = result.Data.PurchasePrice,
                        SalePrice = result.Data.SalePrice,
                        VatRate = result.Data.VatRate,
                        MinStockLevel = result.Data.MinStockLevel,
                        IsActive = result.Data.IsActive,
                        CategoryID = result.Data.CategoryID,
                        UnitID = result.Data.UnitID
                    };
                    
                    await LoadDropdownData();
                    return View(model);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error loading product for edit, ID: {id}");
                TempData["ErrorMessage"] = "Ürün düzenleme verisi yüklenirken hata oluştu.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Purchase")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateProductDto model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownData();
                return View(model);
            }

            try
            {
                var result = await _productService.UpdateProductAsync(id, model);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Ürün başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    await LoadDropdownData();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating product, ID: {id}");
                ModelState.AddModelError(string.Empty, "Ürün güncellenirken hata oluştu.");
                await LoadDropdownData();
                return View(model);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _productService.DeleteProductAsync(id);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Ürün başarıyla silindi.";
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting product, ID: {id}");
                TempData["ErrorMessage"] = "Ürün silinirken hata oluştu.";
            }
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleActive(int id, bool isActive)
        {
            try
            {
                var result = isActive 
                    ? await _productService.ActivateProductAsync(id)
                    : await _productService.DeactivateProductAsync(id);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = $"Ürün {(isActive ? "aktif" : "pasif")} edildi.";
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error toggling product active state, ID: {id}");
                TempData["ErrorMessage"] = "Ürün durumu değiştirilirken hata oluştu.";
            }
            
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadDropdownData()
        {
            try
            {
                var categoriesTask = _productService.GetCategoriesAsync();
                var unitsTask = _productService.GetUnitsAsync();
                
                await Task.WhenAll(categoriesTask, unitsTask);
                
                var categories = await categoriesTask;
                var units = await unitsTask;
                
                ViewBag.Categories = categories.Success && categories.Data != null 
                    ? categories.Data.Select(c => new SelectListItem
                    {
                        Value = c.CategoryID.ToString(),
                        Text = c.CategoryName
                    }).ToList()
                    : new List<SelectListItem>();
                
                ViewBag.Units = units.Success && units.Data != null
                    ? units.Data.Select(u => new SelectListItem
                    {
                        Value = u.UnitID.ToString(),
                        Text = u.UnitName
                    }).ToList()
                    : new List<SelectListItem>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading dropdown data");
                ViewBag.Categories = new List<SelectListItem>();
                ViewBag.Units = new List<SelectListItem>();
            }
        }
    }
} 