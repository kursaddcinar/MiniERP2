using MiniERP.API.DTOs;

namespace MiniERP.API.Services
{
    public interface IAuthService
    {
        Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto);
        Task<ApiResponse<UserDto>> RegisterAsync(CreateUserDto createUserDto);
        Task<ApiResponse<string>> RefreshTokenAsync(string token);
        Task<ApiResponse<bool>> ChangePasswordAsync(int userId, ChangePasswordDto changePasswordDto);
        Task<ApiResponse<bool>> LogoutAsync(int userId);
        string GenerateJwtToken(UserDto user);
        Task<ApiResponse<UserDto>> GetCurrentUserAsync(int userId);
        Task<bool> ValidateTokenAsync(string token);
    }
} 