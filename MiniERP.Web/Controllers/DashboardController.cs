using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Web.Services;

namespace MiniERP.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly AuthService _authService;
        private readonly ProductService _productService;
        private readonly CariAccountService _cariAccountService;
        private readonly SalesInvoiceService _salesInvoiceService;
        private readonly PurchaseInvoiceService _purchaseInvoiceService;
        private readonly StockService _stockService;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(
            AuthService authService, 
            ProductService productService, 
            CariAccountService cariAccountService,
            SalesInvoiceService salesInvoiceService,
            PurchaseInvoiceService purchaseInvoiceService,
            StockService stockService,
            ILogger<DashboardController> logger)
        {
            _authService = authService;
            _productService = productService;
            _cariAccountService = cariAccountService;
            _salesInvoiceService = salesInvoiceService;
            _purchaseInvoiceService = purchaseInvoiceService;
            _stockService = stockService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Get current user info
                var currentUser = await _authService.GetCurrentUserAsync();
                if (currentUser.Success && currentUser.Data != null)
                {
                    ViewBag.CurrentUser = currentUser.Data;
                    ViewBag.UserRole = currentUser.Data.Role;
                }

                // Role-based data loading
                var userRole = currentUser.Data?.Role ?? "Sales";
                
                // Products - visible to most roles
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Sales") || 
                    User.IsInRole("Purchase") || User.IsInRole("Warehouse"))
                {
                    var totalProductsResponse = await _productService.GetProductsAsync(1, 1);
                    ViewBag.TotalProducts = totalProductsResponse.Success && totalProductsResponse.Data != null ? 
                        totalProductsResponse.Data.TotalCount : 0;

                    // Low stock products for dashboard
                    var lowStockProducts = await _productService.GetLowStockProductsAsync();
                    if (lowStockProducts.Success && lowStockProducts.Data != null)
                    {
                        ViewBag.LowStockProducts = lowStockProducts.Data;
                    }
                }

                // Cari Accounts - visible to most roles
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Sales") || 
                    User.IsInRole("Purchase") || User.IsInRole("Finance"))
                {
                    var totalCariAccountsResponse = await _cariAccountService.GetCariAccountsAsync(1, 1000);
                    ViewBag.TotalCariAccounts = totalCariAccountsResponse?.TotalCount ?? 0;

                    var activeCustomers = await _cariAccountService.GetCustomersAsync();
                    var activeSuppliers = await _cariAccountService.GetSuppliersAsync();
                    ViewBag.ActiveCustomers = activeCustomers?.Count ?? 0;
                    ViewBag.ActiveSuppliers = activeSuppliers?.Count ?? 0;
                }

                // Sales Invoices - visible to sales and finance roles
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Sales") || User.IsInRole("Finance"))
                {
                    var totalSalesInvoicesResponse = await _salesInvoiceService.GetSalesInvoicesAsync(1, 1);
                    ViewBag.TotalSalesInvoices = totalSalesInvoicesResponse?.TotalCount ?? 0;
                }

                // Purchase Invoices - visible to purchase and finance roles
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Purchase") || User.IsInRole("Finance"))
                {
                    var totalPurchaseInvoicesResponse = await _purchaseInvoiceService.GetPurchaseInvoicesAsync(1, 1);
                    ViewBag.TotalPurchaseInvoices = totalPurchaseInvoicesResponse?.TotalCount ?? 0;
                }

                // Stock Information - visible to warehouse and management roles
                if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Warehouse") || 
                    User.IsInRole("Sales") || User.IsInRole("Purchase"))
                {
                    // Critical and out-of-stock products
                    var criticalStockResponse = await _stockService.GetCriticalStockCardsAsync();
                    ViewBag.CriticalStockCount = criticalStockResponse.Success && criticalStockResponse.Data != null ? 
                        criticalStockResponse.Data.Count : 0;

                    var outOfStockResponse = await _stockService.GetOutOfStockCardsAsync();
                    ViewBag.OutOfStockCount = outOfStockResponse.Success && outOfStockResponse.Data != null ? 
                        outOfStockResponse.Data.Count : 0;
                }

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading dashboard");
                TempData["ErrorMessage"] = "Dashboard yüklenirken hata oluştu: " + ex.Message;
                return View();
            }
        }
    }
} 