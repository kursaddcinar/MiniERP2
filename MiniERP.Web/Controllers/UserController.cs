using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Web.Models;
using MiniERP.Web.Services;

namespace MiniERP.Web.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(UserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // GET: User
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, string searchTerm = "", string role = "")
        {
            try
            {
                var users = await _userService.GetUsersAsync(pageNumber, pageSize, searchTerm, role);
                
                ViewBag.SearchTerm = searchTerm;
                ViewBag.Role = role;
                ViewBag.Roles = new List<string> { "Admin", "Manager", "Sales", "Purchase", "Finance", "Warehouse", "Employee" };

                return View(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading users");
                TempData["ErrorMessage"] = "Kullanıcılar yüklenirken hata oluştu.";
                return View(new PagedResult<UserDto>(new List<UserDto>(), 0, pageNumber, pageSize));
            }
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                return View("Details", user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error loading user details for ID: {id}");
                TempData["ErrorMessage"] = "Kullanıcı detayları yüklenirken hata oluştu.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: User/Create
        public IActionResult Create()
        {
            ViewBag.Roles = new List<string> { "Admin", "Manager", "Sales", "Purchase", "Finance", "Warehouse", "Employee" };
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [Authorize(Roles = "Admin")] // Sadece Admin yeni kullanıcı oluşturabilir
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserDto createDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = new List<string> { "Admin", "Manager", "Sales", "Purchase", "Finance", "Warehouse", "Employee" };
                return View(createDto);
            }

            try
            {
                var result = await _userService.CreateUserAsync(createDto);
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Kullanıcı başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    ViewBag.Roles = new List<string> { "Admin", "Manager", "Sales", "Purchase", "Finance", "Warehouse", "Employee" };
                    return View(createDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user");
                ModelState.AddModelError(string.Empty, "Kullanıcı oluşturulurken hata oluştu.");
                ViewBag.Roles = new List<string> { "Admin", "Manager", "Sales", "Purchase", "Finance", "Warehouse", "Employee" };
                return View(createDto);
            }
        }

        // GET: User/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                // Manager yetkisindeki kullanıcı Admin yetkisindeki kullanıcıyı düzenleyemez
                if (User.IsInRole("Manager") && !User.IsInRole("Admin"))
                {
                    var targetUserRoles = user.Roles ?? new List<string>();
                    if (targetUserRoles.Contains("Admin"))
                    {
                        TempData["ErrorMessage"] = "Manager yetkisindeki kullanıcılar Admin yetkisindeki kullanıcıları düzenleyemez.";
                        return RedirectToAction(nameof(Index));
                    }
                }

                var updateDto = new UpdateUserDto
                {
                    UserID = user.UserID,
                    Username = user.Username,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsActive = user.IsActive,
                    Role = user.Role
                };

                ViewBag.Roles = new List<string> { "Admin", "Manager", "Sales", "Purchase", "Finance", "Warehouse", "Employee" };
                return View("Edit", updateDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error loading user for edit, ID: {id}");
                TempData["ErrorMessage"] = "Kullanıcı düzenleme verisi yüklenirken hata oluştu.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateUserDto updateDto)
        {
            if (id != updateDto.UserID)
            {
                TempData["ErrorMessage"] = "Geçersiz kullanıcı ID'si.";
                return RedirectToAction(nameof(Index));
            }

            // Manager yetkisindeki kullanıcı Admin yetkisindeki kullanıcıyı düzenleyemez
            if (User.IsInRole("Manager") && !User.IsInRole("Admin"))
            {
                try
                {
                    var targetUser = await _userService.GetUserByIdAsync(id);
                    if (targetUser != null)
                    {
                        var targetUserRoles = targetUser.Roles ?? new List<string>();
                        if (targetUserRoles.Contains("Admin"))
                        {
                            TempData["ErrorMessage"] = "Manager yetkisindeki kullanıcılar Admin yetkisindeki kullanıcıları düzenleyemez.";
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error checking target user role for ID: {id}");
                    TempData["ErrorMessage"] = "Yetki kontrolü sırasında hata oluştu.";
                    return RedirectToAction(nameof(Index));
                }
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Roles = new List<string> { "Admin", "Manager", "Sales", "Purchase", "Finance", "Warehouse", "Employee" };
                return View(updateDto);
            }

            try
            {
                var result = await _userService.UpdateUserAsync(id, updateDto);
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Kullanıcı başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    ViewBag.Roles = new List<string> { "Admin", "Manager", "Sales", "Purchase", "Finance", "Warehouse", "Employee" };
                    return View(updateDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating user, ID: {id}");
                ModelState.AddModelError(string.Empty, "Kullanıcı güncellenirken hata oluştu.");
                ViewBag.Roles = new List<string> { "Admin", "Manager", "Sales", "Purchase", "Finance", "Warehouse", "Employee" };
                return View(updateDto);
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")] // Sadece Admin kullanıcı silebilir
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _userService.DeleteUserAsync(id);
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Kullanıcı başarıyla silindi.";
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting user, ID: {id}");
                TempData["ErrorMessage"] = "Kullanıcı silinirken hata oluştu.";
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: User/ToggleActivation/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> ToggleActivation(int id)
        {
            // Manager yetkisindeki kullanıcı Admin yetkisindeki kullanıcının aktiflik durumunu değiştiremez
            if (User.IsInRole("Manager") && !User.IsInRole("Admin"))
            {
                try
                {
                    var targetUser = await _userService.GetUserByIdAsync(id);
                    if (targetUser != null)
                    {
                        var targetUserRoles = targetUser.Roles ?? new List<string>();
                        if (targetUserRoles.Contains("Admin"))
                        {
                            TempData["ErrorMessage"] = "Manager yetkisindeki kullanıcılar Admin yetkisindeki kullanıcıların aktiflik durumunu değiştiremez.";
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error checking target user role for activation toggle, ID: {id}");
                    TempData["ErrorMessage"] = "Yetki kontrolü sırasında hata oluştu.";
                    return RedirectToAction(nameof(Index));
                }
            }

            try
            {
                var result = await _userService.ToggleUserActivationAsync(id);
                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Kullanıcı durumu başarıyla güncellendi.";
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error toggling user activation, ID: {id}");
                TempData["ErrorMessage"] = "Kullanıcı durumu güncellenirken hata oluştu.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
