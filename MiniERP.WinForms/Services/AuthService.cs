using MiniERP.WinForms.Models;

namespace MiniERP.WinForms.Services
{
    public class AuthService
    {
        private readonly ApiService _apiService;

        public AuthService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto)
        {
            return await _apiService.PostAsync<LoginResponseDto>("/api/auth/login", loginDto);
        }

        public async Task<ApiResponse<UserDto>> RegisterAsync(CreateUserDto createUserDto)
        {
            return await _apiService.PostAsync<UserDto>("/api/auth/register", createUserDto);
        }

        public async Task<ApiResponse> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            return await _apiService.PostAsync("/api/auth/change-password", changePasswordDto);
        }

        public async Task<ApiResponse<UserDto>> GetCurrentUserAsync()
        {
            return await _apiService.GetAsync<UserDto>("/api/auth/current-user");
        }

        public void Logout()
        {
            _apiService.ClearAuthToken();
        }
    }
} 