using MiniERP.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace MiniERP.Web.Services
{
    public class AuthService
    {
        private readonly ApiService _apiService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(ApiService apiService, IHttpContextAccessor httpContextAccessor)
        {
            _apiService = apiService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto)
        {
            var result = await _apiService.PostAsync<LoginResponseDto>("api/Auth/login", loginDto);
            
            if (result.Success && result.Data != null)
            {
                // Store token in session
                _httpContextAccessor.HttpContext?.Session.SetString("AuthToken", result.Data.Token);
                
                // Set auth token for future API calls
                _apiService.SetAuthToken(result.Data.Token);
                
                // Create claims for cookie authentication
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, result.Data.User.UserID.ToString()),
                    new Claim(ClaimTypes.Name, result.Data.User.Username),
                    new Claim("Token", result.Data.Token)
                };

                // Add all role claims
                foreach (var role in result.Data.User.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await _httpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
            }

            return result;
        }

        public async Task LogoutAsync()
        {
            _httpContextAccessor.HttpContext?.Session.Remove("AuthToken");
            await _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public string? GetCurrentToken()
        {
            return _httpContextAccessor.HttpContext?.Session.GetString("AuthToken");
        }

        public int GetCurrentUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(userIdClaim, out var userId) ? userId : 0;
        }

        public string? GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        }

        public string? GetCurrentUserRole()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated == true;
        }

        public bool IsInRole(string role)
        {
            return _httpContextAccessor.HttpContext?.User.IsInRole(role) == true;
        }

        public async Task<ApiResponse<UserDto>> GetCurrentUserAsync()
        {
            var token = GetCurrentToken();
            if (string.IsNullOrEmpty(token))
            {
                return new ApiResponse<UserDto> { Success = false, Message = "No authentication token found" };
            }

            _apiService.SetAuthToken(token);
            return await _apiService.GetAsync<UserDto>("api/Auth/me");
        }

        public async Task<ApiResponse<object>> InitializeTestUsersAsync()
        {
            // Call special initialization endpoint that doesn't require authentication
            return await _apiService.PostAsync<object>("api/Auth/initialize-test-users", null);
        }
    }
} 