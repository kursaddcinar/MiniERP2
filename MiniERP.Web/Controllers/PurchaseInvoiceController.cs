using Microsoft.AspNetCore.Mvc;
using MiniERP.Web.Models;
using MiniERP.Web.Services;

namespace MiniERP.Web.Controllers
{
    public class PurchaseInvoiceController : Controller
    {
        private readonly PurchaseInvoiceService _purchaseInvoiceService;
        private readonly CariAccountService _cariAccountService;
        private readonly ProductService _productService;

        public PurchaseInvoiceController(
            PurchaseInvoiceService purchaseInvoiceService,
            CariAccountService cariAccountService,
            ProductService productService)
        {
            _purchaseInvoiceService = purchaseInvoiceService;
            _cariAccountService = cariAccountService;
            _productService = productService;
        }

        // GET: PurchaseInvoice
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, string searchTerm = "", string status = "", DateTime? startDate = null, DateTime? endDate = null)
        {
            var invoices = await _purchaseInvoiceService.GetPurchaseInvoicesAsync(pageNumber, pageSize, searchTerm, status, startDate, endDate);
            var summary = await _purchaseInvoiceService.GetPurchaseInvoiceSummaryAsync(startDate, endDate);

            ViewBag.SearchTerm = searchTerm;
            ViewBag.Status = status;
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
            ViewBag.Summary = summary;

            return View(invoices);
        }

        // GET: PurchaseInvoice/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var invoice = await _purchaseInvoiceService.GetPurchaseInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: PurchaseInvoice/Create
        public async Task<IActionResult> Create()
        {
            var productsResponse = await _productService.GetProductsAsync();
            var suppliers = await _cariAccountService.GetSuppliersAsync();
            
            ViewBag.Products = productsResponse.Success && productsResponse.Data != null ? 
                productsResponse.Data.Data : new List<ProductDto>();
            ViewBag.Suppliers = suppliers;
            
            // Basit warehouse listesi - gelecekte warehouse service'i eklenebilir
            var warehouses = new List<WarehouseDto>
            {
                new WarehouseDto { WarehouseID = 1, WarehouseCode = "ANA", WarehouseName = "Ana Depo" },
                new WarehouseDto { WarehouseID = 2, WarehouseCode = "SUB", WarehouseName = "Şube Depo" }
            };
            ViewBag.Warehouses = warehouses;

            return View();
        }

        // POST: PurchaseInvoice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePurchaseInvoiceDto createDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _purchaseInvoiceService.CreatePurchaseInvoiceAsync(createDto);
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Satın alma faturası başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                }
            }

            // Reload dropdowns
            var productsResponse = await _productService.GetProductsAsync();
            var suppliers = await _cariAccountService.GetSuppliersAsync();
            
            ViewBag.Products = productsResponse.Success && productsResponse.Data != null ? 
                productsResponse.Data.Data : new List<ProductDto>();
            ViewBag.Suppliers = suppliers;
            
            // Basit warehouse listesi - gelecekte warehouse service'i eklenebilir
            var warehouses = new List<WarehouseDto>
            {
                new WarehouseDto { WarehouseID = 1, WarehouseCode = "ANA", WarehouseName = "Ana Depo" },
                new WarehouseDto { WarehouseID = 2, WarehouseCode = "SUB", WarehouseName = "Şube Depo" }
            };
            ViewBag.Warehouses = warehouses;

            return View(createDto);
        }

        // GET: PurchaseInvoice/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _purchaseInvoiceService.GetPurchaseInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            var productsResponse = await _productService.GetProductsAsync();
            var suppliers = await _cariAccountService.GetSuppliersAsync();
            
            ViewBag.Products = productsResponse.Success && productsResponse.Data != null ? 
                productsResponse.Data.Data : new List<ProductDto>();
            ViewBag.Suppliers = suppliers;

            var updateDto = new UpdatePurchaseInvoiceDto
            {
                CariID = invoice.CariID,
                WarehouseID = invoice.WarehouseID,
                InvoiceDate = invoice.InvoiceDate,
                DueDate = invoice.DueDate,
                Description = invoice.Description,
                Details = invoice.Details?.Select(d => new CreatePurchaseInvoiceDetailDto
                {
                    ProductID = d.ProductID,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    VatRate = d.VatRate,
                    Description = d.Description
                }).ToList() ?? new List<CreatePurchaseInvoiceDetailDto>()
            };

            return View(updateDto);
        }

        // POST: PurchaseInvoice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdatePurchaseInvoiceDto updateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _purchaseInvoiceService.UpdatePurchaseInvoiceAsync(id, updateDto);
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Satın alma faturası başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                }
            }

            // Reload dropdowns
            var productsResponse = await _productService.GetProductsAsync();
            var suppliers = await _cariAccountService.GetSuppliersAsync();
            
            ViewBag.Products = productsResponse.Success && productsResponse.Data != null ? 
                productsResponse.Data.Data : new List<ProductDto>();
            ViewBag.Suppliers = suppliers;
            
            // Basit warehouse listesi - gelecekte warehouse service'i eklenebilir
            var warehouses = new List<WarehouseDto>
            {
                new WarehouseDto { WarehouseID = 1, WarehouseCode = "ANA", WarehouseName = "Ana Depo" },
                new WarehouseDto { WarehouseID = 2, WarehouseCode = "SUB", WarehouseName = "Şube Depo" }
            };
            ViewBag.Warehouses = warehouses;

            return View(updateDto);
        }

        // GET: PurchaseInvoice/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _purchaseInvoiceService.GetPurchaseInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: PurchaseInvoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _purchaseInvoiceService.DeletePurchaseInvoiceAsync(id);
            if (result.Success)
            {
                TempData["SuccessMessage"] = "Satın alma faturası başarıyla silindi.";
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: PurchaseInvoice/Approve/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id, string description = "")
        {
            var approvalDto = new InvoiceApprovalDto
            {
                InvoiceID = id,
                ApprovalNote = description
            };

            var result = await _purchaseInvoiceService.ApprovePurchaseInvoiceAsync(id, approvalDto);
            if (result.Success)
            {
                TempData["SuccessMessage"] = "Satın alma faturası başarıyla onaylandı.";
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: PurchaseInvoice/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id, string reason = "")
        {
            var cancellationDto = new InvoiceCancellationDto
            {
                Reason = reason
            };

            var result = await _purchaseInvoiceService.CancelPurchaseInvoiceAsync(id, cancellationDto);
            if (result.Success)
            {
                TempData["SuccessMessage"] = "Satın alma faturası başarıyla iptal edildi.";
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: PurchaseInvoice/Summary
        public async Task<IActionResult> Summary(DateTime? startDate = null, DateTime? endDate = null)
        {
            var summary = await _purchaseInvoiceService.GetPurchaseInvoiceSummaryAsync(startDate, endDate);
            
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
            
            return View(summary);
        }

        // API Methods for AJAX calls
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productsResponse = await _productService.GetProductsAsync();
            if (productsResponse.Success && productsResponse.Data != null)
            {
                return Json(productsResponse.Data.Data);
            }
            
            return Json(new List<ProductDto>());
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliers = await _cariAccountService.GetSuppliersAsync();
            return Json(suppliers);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var productsResponse = await _productService.GetProductsAsync();
            if (productsResponse.Success && productsResponse.Data != null)
            {
                var product = productsResponse.Data.Data.FirstOrDefault(p => p.ProductID == id);
                return Json(product);
            }
            
            return Json(null);
        }
    }
} 