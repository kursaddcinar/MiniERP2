using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Web.Models;
using MiniERP.Web.Services;

namespace MiniERP.Web.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ApiTestController : Controller
    {
        private readonly UserService _userService;
        private readonly ProductService _productService;
        private readonly CariAccountService _cariAccountService;
        private readonly StockService _stockService;
        private readonly SalesInvoiceService _salesInvoiceService;
        private readonly PurchaseInvoiceService _purchaseInvoiceService;
        private readonly ILogger<ApiTestController> _logger;

        public ApiTestController(
            UserService userService,
            ProductService productService,
            CariAccountService cariAccountService,
            StockService stockService,
            SalesInvoiceService salesInvoiceService,
            PurchaseInvoiceService purchaseInvoiceService,
            ILogger<ApiTestController> logger)
        {
            _userService = userService;
            _productService = productService;
            _cariAccountService = cariAccountService;
            _stockService = stockService;
            _salesInvoiceService = salesInvoiceService;
            _purchaseInvoiceService = purchaseInvoiceService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region User Tests

        [HttpGet]
        public async Task<IActionResult> TestUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                ViewBag.TestResult = "Users API - Success";
                ViewBag.Data = users;
                return View("TestResult");
            }
            catch (Exception ex)
            {
                ViewBag.TestResult = "Users API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        [HttpPost]
        public async Task<IActionResult> TestCreateUser()
        {
            try
            {
                var createUser = new CreateUserDto
                {
                    Username = "testuser" + DateTime.Now.Ticks,
                    Email = "test" + DateTime.Now.Ticks + "@example.com",
                    FirstName = "Test",
                    LastName = "User",
                    Password = "password123",
                    ConfirmPassword = "password123",
                    Role = "Finance" // Finance role
                };

                var result = await _userService.CreateUserAsync(createUser);
                ViewBag.TestResult = "Create User API - " + (result.Success ? "Success" : "Error: " + result.Message);
                ViewBag.Data = result;
                return View("TestResult");
            }
            catch (Exception ex)
            {
                ViewBag.TestResult = "Create User API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        [HttpGet]
        public async Task<IActionResult> TestUserRoles()
        {
            try
            {
                var rolesResult = await _userService.GetRolesAsync();
                ViewBag.TestResult = "User Roles API - " + (rolesResult.Success ? "Success" : "Error: " + rolesResult.Message);
                ViewBag.Data = rolesResult;
                return View("TestResult");
            }
            catch (Exception ex)
            {
                ViewBag.TestResult = "User Roles API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        #endregion

        #region Product Tests

        [HttpGet]
        public async Task<IActionResult> TestCategories()
        {
            try
            {
                var categoriesResult = await _productService.GetCategoriesAsync();
                ViewBag.TestResult = "Categories API - " + (categoriesResult.Success ? "Success" : "Error: " + categoriesResult.Message);
                ViewBag.Data = categoriesResult;
                return View("TestResult");
            }
            catch (Exception ex)
            {
                ViewBag.TestResult = "Categories API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        [HttpGet]
        public async Task<IActionResult> TestUnits()
        {
            try
            {
                var unitsResult = await _productService.GetUnitsAsync();
                ViewBag.TestResult = "Units API - " + (unitsResult.Success ? "Success" : "Error: " + unitsResult.Message);
                ViewBag.Data = unitsResult;
                return View("TestResult");
            }
            catch (Exception ex)
            {
                ViewBag.TestResult = "Units API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        [HttpPost]
        public async Task<IActionResult> TestCreateCategory()
        {
            try
            {
                _logger.LogInformation("=== API TEST: Starting Create Category Test ===");
                
                var createCategory = new CreateProductCategoryDto
                {
                    CategoryCode = "TEST" + DateTime.Now.ToString("HHmmss"),
                    CategoryName = "Test Category",
                    Description = "Test category created from API test"
                };

                _logger.LogInformation("API TEST: Created category DTO: {@CreateCategory}", createCategory);

                var result = await _productService.CreateCategoryAsync(createCategory);
                
                _logger.LogInformation("API TEST: Create Category completed. Success: {Success}, Message: {Message}", 
                    result.Success, result.Message);
                
                ViewBag.TestResult = "Create Category API - " + (result.Success ? "Success" : "Error: " + result.Message);
                ViewBag.Data = result;
                
                _logger.LogInformation("=== API TEST: Create Category Test Completed ===");
                return View("TestResult");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "=== API TEST: Create Category Test Failed ===");
                ViewBag.TestResult = "Create Category API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        [HttpPost]
        public async Task<IActionResult> TestCreateUnit()
        {
            try
            {
                var createUnit = new CreateUnitDto
                {
                    UnitCode = "TST" + DateTime.Now.ToString("mmss"),
                    UnitName = "Test Unit",
                    Description = "Test unit created from API test"
                };

                var result = await _productService.CreateUnitAsync(createUnit);
                ViewBag.TestResult = "Create Unit API - " + (result.Success ? "Success" : "Error: " + result.Message);
                ViewBag.Data = result;
                return View("TestResult");
            }
            catch (Exception ex)
            {
                ViewBag.TestResult = "Create Unit API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        #endregion

        #region CariAccount Tests

        [HttpGet]
        public async Task<IActionResult> TestCariTypes()
        {
            try
            {
                var cariTypes = await _cariAccountService.GetCariTypesAsync();
                ViewBag.TestResult = "Cari Types API - Success";
                ViewBag.Data = cariTypes;
                return View("TestResult");
            }
            catch (Exception ex)
            {
                ViewBag.TestResult = "Cari Types API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        [HttpGet]
        public async Task<IActionResult> TestCariAccounts()
        {
            try
            {
                _logger.LogInformation("API Test: Testing Cari Accounts endpoint");
                var cariAccountsResult = await _cariAccountService.GetCariAccountsAsync(1, 10);
                ViewBag.TestResult = "Cari Accounts API - Success";
                ViewBag.Data = cariAccountsResult;
                _logger.LogInformation("API Test: Cari Accounts endpoint test completed successfully");
                return View("TestResult");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "API Test: Error testing Cari Accounts endpoint");
                ViewBag.TestResult = "Cari Accounts API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        [HttpPost]
        public async Task<IActionResult> TestCreateCariAccount()
        {
            try
            {
                _logger.LogInformation("API Test: Testing Create Cari Account endpoint");
                
                // Önce cari tiplerini al
                var cariTypes = await _cariAccountService.GetCariTypesAsync();
                if (cariTypes == null || !cariTypes.Any())
                {
                    ViewBag.TestResult = "Create Cari Account API - Error: Cari tipi bulunamadı.";
                    return View("TestResult");
                }

                var createCari = new CreateCariAccountDto
                {
                    CariCode = "TC" + DateTime.Now.ToString("HHmmss"),
                    CariName = "Test Cari " + DateTime.Now.ToString("HH:mm:ss"),
                    TypeID = cariTypes.First().TypeID,
                    Email = "test@example.com",
                    Phone = "555-0123",
                    Address = "Test Address",
                    TaxNumber = "1234567890",
                    TaxOffice = "Test Tax Office",
                    CreditLimit = 10000.00m
                };

                var result = await _cariAccountService.CreateCariAccountAsync(createCari);
                ViewBag.TestResult = "Create Cari Account API - " + (result.Success ? "Success" : "Error: " + result.Message);
                ViewBag.Data = result;
                _logger.LogInformation("API Test: Create Cari Account endpoint test completed with status: {Status}", result.Success ? "Success" : "Error");
                return View("TestResult");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "API Test: Error testing Create Cari Account endpoint");
                ViewBag.TestResult = "Create Cari Account API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        #endregion

        #region Product Advanced Tests

        [HttpGet]
        public async Task<IActionResult> TestProducts()
        {
            try
            {
                _logger.LogInformation("API Test: Testing Products endpoint");
                var productsResult = await _productService.GetProductsAsync(1, 10);
                ViewBag.TestResult = "Products API - " + (productsResult.Success ? "Success" : "Error: " + productsResult.Message);
                ViewBag.Data = productsResult;
                _logger.LogInformation("API Test: Products endpoint test completed with status: {Status}", productsResult.Success ? "Success" : "Error");
                return View("TestResult");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "API Test: Error testing Products endpoint");
                ViewBag.TestResult = "Products API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        [HttpPost]
        public async Task<IActionResult> TestCreateProduct()
        {
            try
            {
                _logger.LogInformation("API Test: Testing Create Product endpoint");
                
                // Önce kategori ve birim listelerini al
                var categoriesResult = await _productService.GetCategoriesAsync();
                var unitsResult = await _productService.GetUnitsAsync();

                if (!categoriesResult.Success || !unitsResult.Success || 
                    categoriesResult.Data == null || !categoriesResult.Data.Any() ||
                    unitsResult.Data == null || !unitsResult.Data.Any())
                {
                    ViewBag.TestResult = "Create Product API - Error: Kategori veya birim bulunamadı. Önce kategori ve birim oluşturun.";
                    return View("TestResult");
                }

                var createProduct = new CreateProductDto
                {
                    ProductCode = "TESTPRD" + DateTime.Now.Ticks,
                    ProductName = "Test Product " + DateTime.Now.ToString("HH:mm:ss"),
                    Description = "Test product created from API test",
                    CategoryID = categoriesResult.Data.First().CategoryID,
                    UnitID = unitsResult.Data.First().UnitID,
                    SalePrice = 100.00m,
                    PurchasePrice = 80.00m,
                    VatRate = 18.00m,
                    MinStockLevel = 5.00m
                };

                var result = await _productService.CreateProductAsync(createProduct);
                ViewBag.TestResult = "Create Product API - " + (result.Success ? "Success" : "Error: " + result.Message);
                ViewBag.Data = result;
                _logger.LogInformation("API Test: Create Product endpoint test completed with status: {Status}", result.Success ? "Success" : "Error");
                return View("TestResult");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "API Test: Error testing Create Product endpoint");
                ViewBag.TestResult = "Create Product API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        #endregion

        #region Stock Tests

        [HttpGet]
        public async Task<IActionResult> TestStockCards()
        {
            try
            {
                _logger.LogInformation("API Test: Testing Stock Cards endpoint");
                var stockCardsResult = await _stockService.GetStockCardsAsync(1, 10);
                ViewBag.TestResult = "Stock Cards API - " + (stockCardsResult.Success ? "Success" : "Error: " + stockCardsResult.Message);
                ViewBag.Data = stockCardsResult;
                _logger.LogInformation("API Test: Stock Cards endpoint test completed with status: {Status}", stockCardsResult.Success ? "Success" : "Error");
                return View("TestResult");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "API Test: Error testing Stock Cards endpoint");
                ViewBag.TestResult = "Stock Cards API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        [HttpGet]
        public async Task<IActionResult> TestWarehouses()
        {
            try
            {
                _logger.LogInformation("API Test: Testing Warehouses endpoint");
                var warehousesResult = await _stockService.GetWarehousesAsync();
                ViewBag.TestResult = "Warehouses API - " + (warehousesResult.Success ? "Success" : "Error: " + warehousesResult.Message);
                ViewBag.Data = warehousesResult;
                _logger.LogInformation("API Test: Warehouses endpoint test completed with status: {Status}", warehousesResult.Success ? "Success" : "Error");
                return View("TestResult");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "API Test: Error testing Warehouses endpoint");
                ViewBag.TestResult = "Warehouses API - Error: " + ex.Message;
                return View("TestResult");
            }
        }

        #endregion

        #region Comprehensive Tests

        [HttpGet]
        public async Task<IActionResult> TestAllApis()
        {
            var results = new List<object>();

            _logger.LogInformation("API Test: Starting comprehensive API test");

            // Test Users GET
            try
            {
                var users = await _userService.GetUsersAsync();
                results.Add(new { API = "Users (GET)", Status = "Success", Count = users.Data?.Count ?? 0 });
                _logger.LogInformation("API Test: Users GET test completed successfully");
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Users (GET)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: Users GET test failed");
            }

            // Test User CREATE
            try
            {
                var createUser = new CreateUserDto
                {
                    Username = "testuser" + DateTime.Now.Ticks,
                    Email = "test" + DateTime.Now.Ticks + "@example.com",
                    FirstName = "Test",
                    LastName = "User",
                    Password = "password123",
                    ConfirmPassword = "password123",
                    Role = "Finance"
                };

                var userResult = await _userService.CreateUserAsync(createUser);
                results.Add(new { API = "User (CREATE)", Status = userResult.Success ? "Success" : "Error", Message = userResult.Message });
                _logger.LogInformation("API Test: User CREATE test completed with status: {Status}", userResult.Success ? "Success" : "Error");
            }
            catch (Exception ex)
            {
                results.Add(new { API = "User (CREATE)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: User CREATE test failed");
            }

            // Test Roles
            try
            {
                var rolesResult = await _userService.GetRolesAsync();
                results.Add(new { API = "User Roles (GET)", Status = rolesResult.Success ? "Success" : "Error", Count = rolesResult.Data?.Count ?? 0, Message = rolesResult.Message });
                _logger.LogInformation("API Test: User Roles test completed with status: {Status}", rolesResult.Success ? "Success" : "Error");
            }
            catch (Exception ex)
            {
                results.Add(new { API = "User Roles (GET)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: User Roles test failed");
            }

            // Test Categories GET
            try
            {
                var categoriesResult = await _productService.GetCategoriesAsync();
                results.Add(new { API = "Categories (GET)", Status = categoriesResult.Success ? "Success" : "Error", Count = categoriesResult.Data?.Count ?? 0, Message = categoriesResult.Message });
                _logger.LogInformation("API Test: Categories GET test completed with status: {Status}", categoriesResult.Success ? "Success" : "Error");
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Categories (GET)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: Categories GET test failed");
            }

            // Test Category CREATE
            try
            {
                var createCategory = new CreateProductCategoryDto
                {
                    CategoryCode = "TEST" + DateTime.Now.ToString("HHmmss"),
                    CategoryName = "Test Category",
                    Description = "Test category created from comprehensive test"
                };

                var categoryResult = await _productService.CreateCategoryAsync(createCategory);
                results.Add(new { API = "Category (CREATE)", Status = categoryResult.Success ? "Success" : "Error", Message = categoryResult.Message });
                _logger.LogInformation("API Test: Category CREATE test completed with status: {Status}", categoryResult.Success ? "Success" : "Error");
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Category (CREATE)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: Category CREATE test failed");
            }

            // Test Units GET
            try
            {
                var unitsResult = await _productService.GetUnitsAsync();
                results.Add(new { API = "Units (GET)", Status = unitsResult.Success ? "Success" : "Error", Count = unitsResult.Data?.Count ?? 0, Message = unitsResult.Message });
                _logger.LogInformation("API Test: Units GET test completed with status: {Status}", unitsResult.Success ? "Success" : "Error");
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Units (GET)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: Units GET test failed");
            }

            // Test Unit CREATE
            try
            {
                var createUnit = new CreateUnitDto
                {
                    UnitCode = "TST" + DateTime.Now.ToString("mmss"),
                    UnitName = "Test Unit",
                    Description = "Test unit created from comprehensive test"
                };

                var unitResult = await _productService.CreateUnitAsync(createUnit);
                results.Add(new { API = "Unit (CREATE)", Status = unitResult.Success ? "Success" : "Error", Message = unitResult.Message });
                _logger.LogInformation("API Test: Unit CREATE test completed with status: {Status}", unitResult.Success ? "Success" : "Error");
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Unit (CREATE)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: Unit CREATE test failed");
            }

            // Test Products GET
            try
            {
                var productsResult = await _productService.GetProductsAsync(1, 10);
                results.Add(new { API = "Products (GET)", Status = productsResult.Success ? "Success" : "Error", Count = productsResult.Data?.Data?.Count ?? 0, Message = productsResult.Message });
                _logger.LogInformation("API Test: Products GET test completed with status: {Status}", productsResult.Success ? "Success" : "Error");
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Products (GET)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: Products GET test failed");
            }

            // Test Product CREATE
            try
            {
                var categoriesResult = await _productService.GetCategoriesAsync();
                var unitsResult = await _productService.GetUnitsAsync();

                if (categoriesResult.Success && unitsResult.Success && 
                    categoriesResult.Data?.Any() == true && unitsResult.Data?.Any() == true)
                {
                    var createProduct = new CreateProductDto
                    {
                        ProductCode = "TESTPRD" + DateTime.Now.Ticks,
                        ProductName = "Test Product " + DateTime.Now.ToString("HH:mm:ss"),
                        Description = "Test product created from comprehensive test",
                        CategoryID = categoriesResult.Data.First().CategoryID,
                        UnitID = unitsResult.Data.First().UnitID,
                        SalePrice = 100.00m,
                        PurchasePrice = 80.00m,
                        VatRate = 18.00m,
                        MinStockLevel = 5.00m
                    };

                    var productResult = await _productService.CreateProductAsync(createProduct);
                    results.Add(new { API = "Product (CREATE)", Status = productResult.Success ? "Success" : "Error", Message = productResult.Message });
                    _logger.LogInformation("API Test: Product CREATE test completed with status: {Status}", productResult.Success ? "Success" : "Error");
                }
                else
                {
                    results.Add(new { API = "Product (CREATE)", Status = "Error", Message = "Category veya Unit bulunamadı" });
                    _logger.LogError("API Test: Product CREATE test failed - Category or Unit not found");
                }
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Product (CREATE)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: Product CREATE test failed");
            }

            // Test Cari Types
            try
            {
                var cariTypes = await _cariAccountService.GetCariTypesAsync();
                results.Add(new { API = "Cari Types (GET)", Status = "Success", Count = cariTypes.Count });
                _logger.LogInformation("API Test: Cari Types test completed successfully");
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Cari Types (GET)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: Cari Types test failed");
            }

            // Test Cari Accounts
            try
            {
                var cariAccountsResult = await _cariAccountService.GetCariAccountsAsync(1, 10);
                results.Add(new { API = "Cari Accounts (GET)", Status = "Success", Count = cariAccountsResult.Data?.Count ?? 0 });
                _logger.LogInformation("API Test: Cari Accounts test completed successfully");
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Cari Accounts (GET)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: Cari Accounts test failed");
            }

            // Test CariAccount CREATE
            try
            {
                var cariTypes = await _cariAccountService.GetCariTypesAsync();
                if (cariTypes?.Any() == true)
                {
                    var createCari = new CreateCariAccountDto
                    {
                        CariCode = "TC" + DateTime.Now.ToString("HHmmss"),
                        CariName = "Test Cari " + DateTime.Now.ToString("HH:mm:ss"),
                        TypeID = cariTypes.First().TypeID,
                        Email = "test@example.com",
                        Phone = "555-0123",
                        Address = "Test Address",
                        TaxNumber = "1234567890",
                        TaxOffice = "Test Tax Office",
                        CreditLimit = 10000.00m
                    };

                    var cariResult = await _cariAccountService.CreateCariAccountAsync(createCari);
                    results.Add(new { API = "CariAccount (CREATE)", Status = cariResult.Success ? "Success" : "Error", Message = cariResult.Message });
                    _logger.LogInformation("API Test: CariAccount CREATE test completed with status: {Status}", cariResult.Success ? "Success" : "Error");
                }
                else
                {
                    results.Add(new { API = "CariAccount (CREATE)", Status = "Error", Message = "Cari tipi bulunamadı" });
                    _logger.LogError("API Test: CariAccount CREATE test failed - Cari type not found");
                }
            }
            catch (Exception ex)
            {
                results.Add(new { API = "CariAccount (CREATE)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: CariAccount CREATE test failed");
            }

            // Test Stock Cards
            try
            {
                var stockCardsResult = await _stockService.GetStockCardsAsync(1, 10);
                results.Add(new { API = "Stock Cards (GET)", Status = stockCardsResult.Success ? "Success" : "Error", Count = stockCardsResult.Data?.Data?.Count ?? 0, Message = stockCardsResult.Message });
                _logger.LogInformation("API Test: Stock Cards test completed with status: {Status}", stockCardsResult.Success ? "Success" : "Error");
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Stock Cards (GET)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: Stock Cards test failed");
            }

            // Test Warehouses
            try
            {
                var warehousesResult = await _stockService.GetWarehousesAsync();
                results.Add(new { API = "Warehouses (GET)", Status = warehousesResult.Success ? "Success" : "Error", Count = warehousesResult.Data?.Data?.Count ?? 0, Message = warehousesResult.Message });
                _logger.LogInformation("API Test: Warehouses test completed with status: {Status}", warehousesResult.Success ? "Success" : "Error");
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Warehouses (GET)", Status = "Error", Message = ex.Message });
                _logger.LogError(ex, "API Test: Warehouses test failed");
            }

            _logger.LogInformation("API Test: Comprehensive API test completed. Total tests run: {Count}", results.Count);

            ViewBag.TestResult = "All APIs Test - Completed";
            ViewBag.Data = results;
            return View("TestResult");
        }

        #endregion
    }
} 