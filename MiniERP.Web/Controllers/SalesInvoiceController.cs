using Microsoft.AspNetCore.Mvc;
using MiniERP.Web.Models;
using MiniERP.Web.Services;

namespace MiniERP.Web.Controllers
{
    public class SalesInvoiceController : Controller
    {
        private readonly SalesInvoiceService _salesInvoiceService;
        private readonly CariAccountService _cariAccountService;
        private readonly ProductService _productService;

        public SalesInvoiceController(
            SalesInvoiceService salesInvoiceService,
            CariAccountService cariAccountService,
            ProductService productService)
        {
            _salesInvoiceService = salesInvoiceService;
            _cariAccountService = cariAccountService;
            _productService = productService;
        }

        // GET: SalesInvoice
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, string searchTerm = "", string status = "", DateTime? startDate = null, DateTime? endDate = null)
        {
            var invoices = await _salesInvoiceService.GetSalesInvoicesAsync(pageNumber, pageSize, searchTerm, status, startDate, endDate);
            var summary = await _salesInvoiceService.GetSalesInvoiceSummaryAsync(startDate, endDate);

            ViewBag.SearchTerm = searchTerm;
            ViewBag.Status = status;
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
            ViewBag.Summary = summary;

            return View(invoices);
        }

        // GET: SalesInvoice/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var invoice = await _salesInvoiceService.GetSalesInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: SalesInvoice/Create
        public async Task<IActionResult> Create()
        {
            var productsResponse = await _productService.GetProductsAsync();
            var customers = await _cariAccountService.GetCustomersAsync();
            
            ViewBag.Products = productsResponse.Success && productsResponse.Data != null ? 
                productsResponse.Data.Data : new List<ProductDto>();
            ViewBag.Customers = customers;

            return View();
        }

        // POST: SalesInvoice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSalesInvoiceDto createDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _salesInvoiceService.CreateSalesInvoiceAsync(createDto);
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Satış faturası başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                }
            }

            // Reload dropdowns
            var productsResponse = await _productService.GetProductsAsync();
            var customers = await _cariAccountService.GetCustomersAsync();
            
            ViewBag.Products = productsResponse.Success && productsResponse.Data != null ? 
                productsResponse.Data.Data : new List<ProductDto>();
            ViewBag.Customers = customers;

            return View(createDto);
        }

        // GET: SalesInvoice/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _salesInvoiceService.GetSalesInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            var products = await _salesInvoiceService.GetProductsAsync();
            var customers = await _salesInvoiceService.GetCariAccountsAsync();
            
            ViewBag.Products = products;
            ViewBag.Customers = customers.Where(c => c.IsCustomer).ToList();

            var updateDto = new UpdateSalesInvoiceDto
            {
                CariID = invoice.CariID,
                WarehouseID = invoice.WarehouseID,
                InvoiceDate = invoice.InvoiceDate,
                DueDate = invoice.DueDate,
                Description = invoice.Description,
                Details = invoice.Details?.Select(d => new CreateSalesInvoiceDetailDto
                {
                    ProductID = d.ProductID,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    VatRate = d.VatRate,
                    Description = d.Description
                }).ToList() ?? new List<CreateSalesInvoiceDetailDto>()
            };

            return View(updateDto);
        }

        // POST: SalesInvoice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateSalesInvoiceDto updateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _salesInvoiceService.UpdateSalesInvoiceAsync(id, updateDto);
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Satış faturası başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                }
            }

            // Reload dropdowns
            var productsResponse = await _productService.GetProductsAsync();
            var customers = await _cariAccountService.GetCustomersAsync();
            
            ViewBag.Products = productsResponse.Success && productsResponse.Data != null ? 
                productsResponse.Data.Data : new List<ProductDto>();
            ViewBag.Customers = customers;

            return View(updateDto);
        }

        // GET: SalesInvoice/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _salesInvoiceService.GetSalesInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: SalesInvoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _salesInvoiceService.DeleteSalesInvoiceAsync(id);
            if (result.Success)
            {
                TempData["SuccessMessage"] = "Satış faturası başarıyla silindi.";
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: SalesInvoice/Approve/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id, string description = "")
        {
            var approvalDto = new InvoiceApprovalDto
            {
                InvoiceID = id,
                ApprovalNote = description
            };

            var result = await _salesInvoiceService.ApproveSalesInvoiceAsync(id, approvalDto);
            if (result.Success)
            {
                TempData["SuccessMessage"] = "Satış faturası başarıyla onaylandı.";
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: SalesInvoice/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id, string reason = "")
        {
            var cancellationDto = new InvoiceCancellationDto
            {
                Reason = reason
            };

            var result = await _salesInvoiceService.CancelSalesInvoiceAsync(id, cancellationDto);
            if (result.Success)
            {
                TempData["SuccessMessage"] = "Satış faturası başarıyla iptal edildi.";
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: SalesInvoice/Summary
        public async Task<IActionResult> Summary(DateTime? startDate = null, DateTime? endDate = null)
        {
            var summary = await _salesInvoiceService.GetSalesInvoiceSummaryAsync(startDate, endDate);
            
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
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _salesInvoiceService.GetCariAccountsAsync();
            return Json(customers.Where(c => c.IsCustomer));
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await _salesInvoiceService.GetProductsAsync();
            var product = products.FirstOrDefault(p => p.ProductID == id);
            return Json(product);
        }
    }
} 