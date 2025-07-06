using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Web.Models;
using MiniERP.Web.Services;

namespace MiniERP.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            if (_authService.IsAuthenticated())
            {
                return RedirectToAction("Index", "Dashboard");
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var result = await _authService.LoginAsync(model);
                
                if (result.Success)
                {
                    _logger.LogInformation($"User {model.Username} logged in successfully");
                    
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    _logger.LogWarning($"Login failed for user {model.Username}: {result.Message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error during login for user {model.Username}");
                ModelState.AddModelError(string.Empty, "Giriş yapılırken bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            var username = _authService.GetCurrentUsername();
            await _authService.LogoutAsync();
            
            _logger.LogInformation($"User {username} logged out");
            
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            try
            {
                var result = await _authService.GetCurrentUserAsync();
                
                if (result.Success && result.Data != null)
                {
                    return View(result.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting current user profile");
                TempData["ErrorMessage"] = "Profil bilgileri alınırken hata oluştu.";
                return RedirectToAction("Index", "Dashboard");
            }
        }
    }
} 