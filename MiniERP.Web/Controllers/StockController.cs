using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniERP.Web.Models;
using MiniERP.Web.Services;

namespace MiniERP.Web.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private readonly StockService _stockService;
        private readonly ProductService _productService;
        private readonly ILogger<StockController> _logger;

        public StockController(StockService stockService, ProductService productService, ILogger<StockController> logger)
        {
            _stockService = stockService;
            _productService = productService;
            _logger = logger;
        }

        #region Stok Kartları

        [Authorize(Roles = "Admin,Manager,Warehouse,Sales,Purchase")]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string? search = null)
        {
            try
            {
                var result = await _stockService.GetStockCardsAsync(page, pageSize, search);
                
                if (result.Success && result.Data != null)
                {
                    ViewBag.CurrentPage = page;
                    ViewBag.PageSize = pageSize;
                    ViewBag.Search = search;
                    
                    return View(result.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return View(new PagedResult<StockCardDto>(new List<StockCardDto>(), 0, page, pageSize));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading stock cards");
                TempData["ErrorMessage"] = "Stok kartları yüklenirken hata oluştu.";
                return View(new PagedResult<StockCardDto>(new List<StockCardDto>(), 0, page, pageSize));
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var result = await _stockService.GetStockCardByIdAsync(id);
                
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
                _logger.LogError(ex, $"Error loading stock card details for ID: {id}");
                TempData["ErrorMessage"] = "Stok kartı detayları yüklenirken hata oluştu.";
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Roles = "Admin,Manager,Warehouse")]
        public async Task<IActionResult> Create()
        {
            await LoadDropdownData();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStockCardDto model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownData();
                return View(model);
            }

            try
            {
                var result = await _stockService.CreateStockCardAsync(model);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Stok kartı başarıyla oluşturuldu.";
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
                _logger.LogError(ex, "Error creating stock card");
                ModelState.AddModelError(string.Empty, "Stok kartı oluşturulurken hata oluştu.");
                await LoadDropdownData();
                return View(model);
            }
        }

        [Authorize(Roles = "Admin,Manager,Warehouse")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _stockService.GetStockCardByIdAsync(id);
                
                if (result.Success && result.Data != null)
                {
                    var model = new UpdateStockCardDto
                    {
                        ProductID = result.Data.ProductID,
                        WarehouseID = result.Data.WarehouseID,
                        CurrentStock = result.Data.CurrentStock,
                        ReservedStock = result.Data.ReservedStock,
                        MinStockLevel = result.Data.MinStockLevel,
                        MaxStockLevel = result.Data.MaxStockLevel,
                        Location = "", // Şu anda desteklenmiyor
                        Notes = "", // Şu anda desteklenmiyor
                        IsActive = true, // Varsayılan değer
                        ReorderLevel = 0, // Şu anda desteklenmiyor
                        ReorderQuantity = 0, // Şu anda desteklenmiyor
                        LastUpdateDate = DateTime.Now
                    };
                    
                    ViewBag.CurrentStockCard = result.Data;
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
                _logger.LogError(ex, $"Error loading stock card for edit, ID: {id}");
                TempData["ErrorMessage"] = "Stok kartı düzenleme verisi yüklenirken hata oluştu.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateStockCardDto model)
        {
            if (!ModelState.IsValid)
            {
                var stockCardResult = await _stockService.GetStockCardByIdAsync(id);
                if (stockCardResult.Success && stockCardResult.Data != null)
                {
                    ViewBag.CurrentStockCard = stockCardResult.Data;
                }
                return View(model);
            }

            try
            {
                var result = await _stockService.UpdateStockCardAsync(id, model);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Stok kartı başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    var stockCardResult = await _stockService.GetStockCardByIdAsync(id);
                    if (stockCardResult.Success && stockCardResult.Data != null)
                    {
                        ViewBag.CurrentStockCard = stockCardResult.Data;
                    }
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating stock card, ID: {id}");
                ModelState.AddModelError(string.Empty, "Stok kartı güncellenirken hata oluştu.");
                var stockCardResult = await _stockService.GetStockCardByIdAsync(id);
                if (stockCardResult.Success && stockCardResult.Data != null)
                {
                    ViewBag.CurrentStockCard = stockCardResult.Data;
                }
                return View(model);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _stockService.DeleteStockCardAsync(id);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Stok kartı başarıyla silindi.";
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting stock card, ID: {id}");
                TempData["ErrorMessage"] = "Stok kartı silinirken hata oluştu.";
            }
            
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region AJAX Actions

        [HttpGet]
        public async Task<IActionResult> GetStockInfo(int productId, int warehouseId)
        {
            try
            {
                var result = await _stockService.GetStockCardByProductAndWarehouseAsync(productId, warehouseId);
                
                if (result.Success && result.Data != null)
                {
                    return Json(new 
                    { 
                        success = true, 
                        stock = result.Data.CurrentStock,
                        reserved = result.Data.ReservedStock,
                        available = result.Data.AvailableStock,
                        unit = result.Data.UnitName,
                        minLevel = result.Data.MinStockLevel,
                        maxLevel = result.Data.MaxStockLevel
                    });
                }
                else
                {
                    return Json(new { success = false, message = "Stok bilgisi bulunamadı" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting stock info for Product: {ProductId}, Warehouse: {WarehouseId}", productId, warehouseId);
                return Json(new { success = false, message = "Stok bilgisi alınamadı" });
            }
        }

        #endregion

        #region Stok Durumu

        public async Task<IActionResult> Critical()
        {
            try
            {
                var result = await _stockService.GetCriticalStockCardsAsync();
                
                if (result.Success && result.Data != null)
                {
                    return View(result.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return View(new List<StockCardDto>());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading critical stock cards");
                TempData["ErrorMessage"] = "Kritik stok kartları yüklenirken hata oluştu.";
                return View(new List<StockCardDto>());
            }
        }

        public async Task<IActionResult> OutOfStock()
        {
            try
            {
                var result = await _stockService.GetOutOfStockCardsAsync();
                
                if (result.Success && result.Data != null)
                {
                    return View(result.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return View(new List<StockCardDto>());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading out of stock cards");
                TempData["ErrorMessage"] = "Stokta olmayan kartlar yüklenirken hata oluştu.";
                return View(new List<StockCardDto>());
            }
        }

        [Authorize(Roles = "Admin,Manager,Warehouse")]
        public async Task<IActionResult> UpdateStock()
        {
            await LoadDropdownData();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStock(UpdateStockDto model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownData();
                return View(model);
            }

            try
            {
                var result = await _stockService.UpdateStockAsync(model);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Stok başarıyla güncellendi.";
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
                _logger.LogError(ex, "Error updating stock");
                ModelState.AddModelError(string.Empty, "Stok güncellenirken hata oluştu.");
                await LoadDropdownData();
                return View(model);
            }
        }

        [Authorize(Roles = "Admin,Manager,Warehouse")]
        public async Task<IActionResult> Reserve()
        {
            await LoadDropdownData();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reserve(ReserveStockDto model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownData();
                return View(model);
            }

            try
            {
                var result = await _stockService.ReserveStockAsync(model);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Stok başarıyla rezerve edildi.";
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
                _logger.LogError(ex, "Error reserving stock");
                ModelState.AddModelError(string.Empty, "Stok rezerve edilirken hata oluştu.");
                await LoadDropdownData();
                return View(model);
            }
        }

        #endregion

        #region Stok Hareketleri

        public async Task<IActionResult> Transactions(int page = 1, int pageSize = 10)
        {
            try
            {
                var result = await _stockService.GetStockTransactionsAsync(page, pageSize);
                
                if (result.Success && result.Data != null)
                {
                    ViewBag.CurrentPage = page;
                    ViewBag.PageSize = pageSize;
                    
                    return View(result.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return View(new PagedResult<StockTransactionDto>(new List<StockTransactionDto>(), 0, page, pageSize));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading stock transactions");
                TempData["ErrorMessage"] = "Stok hareketleri yüklenirken hata oluştu.";
                return View(new PagedResult<StockTransactionDto>(new List<StockTransactionDto>(), 0, page, pageSize));
            }
        }

        public async Task<IActionResult> TransactionDetails(int id)
        {
            try
            {
                var result = await _stockService.GetStockTransactionByIdAsync(id);
                
                if (result.Success && result.Data != null)
                {
                    return View(result.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return RedirectToAction(nameof(Transactions));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error loading stock transaction details for ID: {id}");
                TempData["ErrorMessage"] = "Stok hareketi detayları yüklenirken hata oluştu.";
                return RedirectToAction(nameof(Transactions));
            }
        }

        [Authorize(Roles = "Admin,Manager,Warehouse")]
        public async Task<IActionResult> CreateTransaction()
        {
            await LoadDropdownData();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTransaction(CreateStockTransactionDto model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownData();
                return View(model);
            }

            try
            {
                var result = await _stockService.CreateStockTransactionAsync(model);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Stok hareketi başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Transactions));
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
                _logger.LogError(ex, "Error creating stock transaction");
                ModelState.AddModelError(string.Empty, "Stok hareketi oluşturulurken hata oluştu.");
                await LoadDropdownData();
                return View(model);
            }
        }

        [Authorize(Roles = "Admin,Manager,Warehouse")]
        public async Task<IActionResult> Transfer()
        {
            await LoadDropdownData();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transfer(CreateStockMovementDto model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownData();
                return View(model);
            }

            try
            {
                var result = await _stockService.ProcessStockMovementAsync(model);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Stok transferi başarıyla gerçekleştirildi.";
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
                _logger.LogError(ex, "Error processing stock transfer");
                ModelState.AddModelError(string.Empty, "Stok transferi işlenirken hata oluştu.");
                await LoadDropdownData();
                return View(model);
            }
        }

        #endregion

        #region Depolar

        public async Task<IActionResult> Warehouses(int page = 1, int pageSize = 10)
        {
            try
            {
                var result = await _stockService.GetWarehousesAsync(page, pageSize);
                
                if (result.Success && result.Data != null)
                {
                    ViewBag.CurrentPage = page;
                    ViewBag.PageSize = pageSize;
                    
                    return View(result.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return View(new PagedResult<WarehouseDto>(new List<WarehouseDto>(), 0, page, pageSize));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading warehouses");
                TempData["ErrorMessage"] = "Depolar yüklenirken hata oluştu.";
                return View(new PagedResult<WarehouseDto>(new List<WarehouseDto>(), 0, page, pageSize));
            }
        }

        public async Task<IActionResult> WarehouseDetails(int id)
        {
            try
            {
                var result = await _stockService.GetWarehouseByIdAsync(id);
                
                if (result.Success && result.Data != null)
                {
                    return View(result.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return RedirectToAction(nameof(Warehouses));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error loading warehouse details for ID: {id}");
                TempData["ErrorMessage"] = "Depo detayları yüklenirken hata oluştu.";
                return RedirectToAction(nameof(Warehouses));
            }
        }

        [Authorize(Roles = "Admin,Manager,Warehouse")]
        public IActionResult CreateWarehouse()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWarehouse(CreateWarehouseDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var result = await _stockService.CreateWarehouseAsync(model);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Depo başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Warehouses));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating warehouse");
                ModelState.AddModelError(string.Empty, "Depo oluşturulurken hata oluştu.");
                return View(model);
            }
        }

        [Authorize(Roles = "Admin,Manager,Warehouse")]
        public async Task<IActionResult> EditWarehouse(int id)
        {
            try
            {
                var result = await _stockService.GetWarehouseByIdAsync(id);
                
                if (result.Success && result.Data != null)
                {
                    var model = new UpdateWarehouseDto
                    {
                        WarehouseName = result.Data.WarehouseName,
                        Address = result.Data.Address,
                        City = result.Data.City,
                        ResponsiblePerson = result.Data.ResponsiblePerson,
                        IsActive = result.Data.IsActive
                    };
                    
                    ViewBag.Warehouse = result.Data;
                    return View(model);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return RedirectToAction(nameof(Warehouses));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error loading warehouse for edit, ID: {id}");
                TempData["ErrorMessage"] = "Depo düzenleme verisi yüklenirken hata oluştu.";
                return RedirectToAction(nameof(Warehouses));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWarehouse(int id, UpdateWarehouseDto model)
        {
            if (!ModelState.IsValid)
            {
                var warehouseResult = await _stockService.GetWarehouseByIdAsync(id);
                if (warehouseResult.Success && warehouseResult.Data != null)
                {
                    ViewBag.Warehouse = warehouseResult.Data;
                }
                return View(model);
            }

            try
            {
                var result = await _stockService.UpdateWarehouseAsync(id, model);
                
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Depo başarıyla güncellendi.";
                    return RedirectToAction(nameof(Warehouses));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    var warehouseResult = await _stockService.GetWarehouseByIdAsync(id);
                    if (warehouseResult.Success && warehouseResult.Data != null)
                    {
                        ViewBag.Warehouse = warehouseResult.Data;
                    }
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating warehouse, ID: {id}");
                ModelState.AddModelError(string.Empty, "Depo güncellenirken hata oluştu.");
                var warehouseResult = await _stockService.GetWarehouseByIdAsync(id);
                if (warehouseResult.Success && warehouseResult.Data != null)
                {
                    ViewBag.Warehouse = warehouseResult.Data;
                }
                return View(model);
            }
        }

        #endregion

        #region Raporlar

        public async Task<IActionResult> Summary()
        {
            try
            {
                var result = await _stockService.GetStockSummaryAsync();
                
                if (result.Success && result.Data != null)
                {
                    return View(result.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return View(new StockSummaryDto());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading stock summary");
                TempData["ErrorMessage"] = "Stok özeti yüklenirken hata oluştu.";
                return View(new StockSummaryDto());
            }
        }

        public async Task<IActionResult> Report(int? warehouseId = null, int? categoryId = null)
        {
            try
            {
                var result = await _stockService.GetStockReportAsync(warehouseId, categoryId);
                
                if (result.Success && result.Data != null)
                {
                    await LoadDropdownData();
                    ViewBag.WarehouseId = warehouseId;
                    ViewBag.CategoryId = categoryId;
                    return View(result.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    await LoadDropdownData();
                    return View(new StockReportDto());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading stock report");
                TempData["ErrorMessage"] = "Stok raporu yüklenirken hata oluştu.";
                await LoadDropdownData();
                return View(new StockReportDto());
            }
        }

        #endregion

        #region Private Methods

        private async Task LoadDropdownData()
        {
            try
            {
                // Ürünleri yükle
                var products = await _productService.GetProductsAsync(1, 1000);
                if (products.Success && products.Data != null)
                {
                    ViewBag.Products = products.Data.Data.Select(p => new SelectListItem
                    {
                        Value = p.ProductID.ToString(),
                        Text = $"{p.ProductCode} - {p.ProductName}"
                    }).ToList();
                }

                // Depoları yükle
                var warehouses = await _stockService.GetActiveWarehousesAsync();
                if (warehouses.Success && warehouses.Data != null)
                {
                    ViewBag.Warehouses = warehouses.Data.Select(w => new SelectListItem
                    {
                        Value = w.WarehouseID.ToString(),
                        Text = $"{w.WarehouseCode} - {w.WarehouseName}"
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading dropdown data");
            }
        }

        #endregion
    }
} 