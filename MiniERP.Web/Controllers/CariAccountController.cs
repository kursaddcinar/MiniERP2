using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Web.Models;
using MiniERP.Web.Services;

namespace MiniERP.Web.Controllers
{
    [Authorize]
    public class CariAccountController : Controller
    {
        private readonly CariAccountService _cariAccountService;

        public CariAccountController(CariAccountService cariAccountService)
        {
            _cariAccountService = cariAccountService;
        }

        // GET: CariAccount
        [Authorize(Roles = "Admin,Manager,Sales,Purchase,Finance")]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, string searchTerm = "", int? typeId = null)
        {
            var cariAccounts = await _cariAccountService.GetCariAccountsAsync(pageNumber, pageSize, searchTerm, typeId);
            var cariTypes = await _cariAccountService.GetCariTypesAsync();
            
            // Toplam müşteri ve tedarikçi sayılarını hesapla
            var customers = await _cariAccountService.GetCustomersAsync();
            var suppliers = await _cariAccountService.GetSuppliersAsync();
            
            // Toplam cari sayısını hesapla (filtrelenmemiş)
            var totalCariCount = await _cariAccountService.GetTotalCariCountAsync();
            
            ViewBag.SearchTerm = searchTerm;
            ViewBag.TypeId = typeId;
            ViewBag.CariTypes = cariTypes;
            ViewBag.TotalCustomers = customers.Count;
            ViewBag.TotalSuppliers = suppliers.Count;
            ViewBag.TotalActiveCustomers = customers.Count(c => c.IsActive);
            ViewBag.TotalActiveSuppliers = suppliers.Count(c => c.IsActive);
            ViewBag.TotalCariCount = totalCariCount; // Yeni eklenen toplam cari sayısı

            return View(cariAccounts);
        }

        // GET: CariAccount/Details/5
        [Authorize(Roles = "Admin,Manager,Sales,Purchase,Finance")]
        public async Task<IActionResult> Details(int id)
        {
            var cariAccount = await _cariAccountService.GetCariAccountByIdAsync(id);
            if (cariAccount == null)
            {
                return NotFound();
            }

            return View(cariAccount);
        }

        // GET: CariAccount/Create
        [Authorize(Roles = "Admin,Manager,Sales,Purchase")]
        public async Task<IActionResult> Create()
        {
            var cariTypes = await _cariAccountService.GetCariTypesAsync();
            ViewBag.CariTypes = cariTypes;

            return View();
        }

        // POST: CariAccount/Create
        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Sales,Purchase")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCariAccountDto createDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _cariAccountService.CreateCariAccountAsync(createDto);
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Cari hesap başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                }
            }

            // Reload dropdowns
            var cariTypes = await _cariAccountService.GetCariTypesAsync();
            ViewBag.CariTypes = cariTypes;

            return View(createDto);
        }

        // GET: CariAccount/Edit/5
        [Authorize(Roles = "Admin,Manager,Sales,Purchase")]
        public async Task<IActionResult> Edit(int id)
        {
            var cariAccount = await _cariAccountService.GetCariAccountByIdAsync(id);
            if (cariAccount == null)
            {
                return NotFound();
            }

            var cariTypes = await _cariAccountService.GetCariTypesAsync();
            ViewBag.CariTypes = cariTypes;

            var updateDto = new UpdateCariAccountDto
            {
                CariCode = cariAccount.CariCode,
                CariName = cariAccount.CariName,
                ContactPerson = cariAccount.ContactPerson,
                Phone = cariAccount.Phone,
                Email = cariAccount.Email,
                Address = cariAccount.Address,
                TaxNumber = cariAccount.TaxNumber,
                TaxOffice = cariAccount.TaxOffice,
                CreditLimit = cariAccount.CreditLimit,
                IsActive = cariAccount.IsActive,
                TypeID = cariAccount.TypeID
            };

            return View(updateDto);
        }

        // POST: CariAccount/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Sales,Purchase")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateCariAccountDto updateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _cariAccountService.UpdateCariAccountAsync(id, updateDto);
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Cari hesap başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                }
            }

            // Reload dropdowns
            var cariTypes = await _cariAccountService.GetCariTypesAsync();
            ViewBag.CariTypes = cariTypes;

            return View(updateDto);
        }

        // GET: CariAccount/Delete/5
        [Authorize(Roles = "Admin,Manager,Sales,Purchase")]
        public async Task<IActionResult> Delete(int id)
        {
            var cariAccount = await _cariAccountService.GetCariAccountByIdAsync(id);
            if (cariAccount == null)
            {
                return NotFound();
            }

            return View(cariAccount);
        }

        // POST: CariAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin,Manager,Sales,Purchase")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _cariAccountService.DeleteCariAccountAsync(id);
            if (result.Success)
            {
                TempData["SuccessMessage"] = "Cari hesap başarıyla silindi.";
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: CariAccount/Customers
        public async Task<IActionResult> Customers()
        {
            var customers = await _cariAccountService.GetCustomersAsync();
            ViewBag.Title = "Müşteriler";
            return View("CustomerSupplierList", customers);
        }

        // GET: CariAccount/Suppliers
        public async Task<IActionResult> Suppliers()
        {
            var suppliers = await _cariAccountService.GetSuppliersAsync();
            ViewBag.Title = "Tedarikçiler";
            return View("CustomerSupplierList", suppliers);
        }

        // GET: CariAccount/Transactions/5
        public async Task<IActionResult> Transactions(int id, DateTime? startDate = null, DateTime? endDate = null)
        {
            var cariAccount = await _cariAccountService.GetCariAccountByIdAsync(id);
            if (cariAccount == null)
            {
                return NotFound();
            }

            var transactions = await _cariAccountService.GetCariTransactionsAsync(id, startDate, endDate);
            
            ViewBag.CariAccount = cariAccount;
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");

            return View(transactions);
        }

        // GET: CariAccount/Statement/5
        public async Task<IActionResult> Statement(int id, DateTime? startDate = null, DateTime? endDate = null)
        {
            var statement = await _cariAccountService.GetCariStatementAsync(id, startDate, endDate);
            if (statement == null)
            {
                return NotFound();
            }

            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");

            return View(statement);
        }

        // API Methods for AJAX calls
        [HttpGet]
        public async Task<IActionResult> GetCariTypes()
        {
            var cariTypes = await _cariAccountService.GetCariTypesAsync();
            return Json(cariTypes);
        }

        [HttpGet]
        public async Task<IActionResult> GetCariAccountByCode(string code)
        {
            var cariAccount = await _cariAccountService.GetCariAccountByCodeAsync(code);
            return Json(cariAccount);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _cariAccountService.GetCustomersAsync();
            return Json(customers);
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliers = await _cariAccountService.GetSuppliersAsync();
            return Json(suppliers);
        }
    }
} 