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

        public ApiTestController(
            UserService userService,
            ProductService productService,
            CariAccountService cariAccountService)
        {
            _userService = userService;
            _productService = productService;
            _cariAccountService = cariAccountService;
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
                    Email = "test@example.com",
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
                var createCategory = new CreateProductCategoryDto
                {
                    CategoryCode = "TEST" + DateTime.Now.Ticks,
                    CategoryName = "Test Category",
                    Description = "Test category created from API test"
                };

                var result = await _productService.CreateCategoryAsync(createCategory);
                ViewBag.TestResult = "Create Category API - " + (result.Success ? "Success" : "Error: " + result.Message);
                ViewBag.Data = result;
                return View("TestResult");
            }
            catch (Exception ex)
            {
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
                    UnitCode = "TEST" + DateTime.Now.Ticks,
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

        #endregion

        #region Comprehensive Tests

        [HttpGet]
        public async Task<IActionResult> TestAllApis()
        {
            var results = new List<object>();

            // Test Users
            try
            {
                var users = await _userService.GetUsersAsync();
                results.Add(new { API = "Users", Status = "Success", Count = users.Data?.Count ?? 0 });
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Users", Status = "Error", Message = ex.Message });
            }

            // Test Roles
            try
            {
                var rolesResult = await _userService.GetRolesAsync();
                results.Add(new { API = "User Roles", Status = rolesResult.Success ? "Success" : "Error", Count = rolesResult.Data?.Count ?? 0, Message = rolesResult.Message });
            }
            catch (Exception ex)
            {
                results.Add(new { API = "User Roles", Status = "Error", Message = ex.Message });
            }

            // Test Categories
            try
            {
                var categoriesResult = await _productService.GetCategoriesAsync();
                results.Add(new { API = "Categories", Status = categoriesResult.Success ? "Success" : "Error", Count = categoriesResult.Data?.Count ?? 0, Message = categoriesResult.Message });
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Categories", Status = "Error", Message = ex.Message });
            }

            // Test Units
            try
            {
                var unitsResult = await _productService.GetUnitsAsync();
                results.Add(new { API = "Units", Status = unitsResult.Success ? "Success" : "Error", Count = unitsResult.Data?.Count ?? 0, Message = unitsResult.Message });
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Units", Status = "Error", Message = ex.Message });
            }

            // Test Cari Types
            try
            {
                var cariTypes = await _cariAccountService.GetCariTypesAsync();
                results.Add(new { API = "Cari Types", Status = "Success", Count = cariTypes.Count });
            }
            catch (Exception ex)
            {
                results.Add(new { API = "Cari Types", Status = "Error", Message = ex.Message });
            }

            ViewBag.TestResult = "All APIs Test - Completed";
            ViewBag.Data = results;
            return View("TestResult");
        }

        #endregion
    }
} 