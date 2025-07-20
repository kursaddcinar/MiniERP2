using MiniERP.WinForms.DTOs;

namespace MiniERP.WinForms.Services
{
    public class UserService
    {
        private readonly ApiService _apiService;

        public UserService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<PagedResult<UserDto>> GetUsersAsync(int pageNumber = 1, int pageSize = 50, string searchTerm = "", string role = "")
        {
            try
            {
                var queryParams = new List<string>
                {
                    $"pageNumber={pageNumber}",
                    $"pageSize={pageSize}"
                };

                if (!string.IsNullOrEmpty(searchTerm))
                    queryParams.Add($"searchTerm={Uri.EscapeDataString(searchTerm)}");

                if (!string.IsNullOrEmpty(role))
                    queryParams.Add($"role={Uri.EscapeDataString(role)}");

                var queryString = string.Join("&", queryParams);

                var response = await _apiService.GetAsync<PagedResult<UserDto>>($"User?{queryString}");
                
                if (response.Success)
                {
                    return response.Data ?? new PagedResult<UserDto>
                    {
                        Data = new List<UserDto>(),
                        TotalCount = 0,
                        PageNumber = pageNumber,
                        PageSize = pageSize
                    };
                }
                else
                {
                    throw new Exception(response.Message ?? "Kullanıcılar alınamadı");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcılar alınırken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<UserDto>> GetUserByIdAsync(int userId)
        {
            try
            {
                var response = await _apiService.GetAsync<UserDto>($"User/{userId}");
                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponse<UserDto>
                {
                    Success = false,
                    Message = $"Kullanıcı alınırken hata oluştu: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            try
            {
                return await _apiService.PostAsync<UserDto>("User", createUserDto);
            }
            catch (Exception ex)
            {
                return new ApiResponse<UserDto>
                {
                    Success = false,
                    Message = $"Kullanıcı oluşturulurken hata oluştu: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<UserDto>> UpdateUserAsync(int userId, UpdateUserDto updateUserDto)
        {
            try
            {
                return await _apiService.PutAsync<UserDto>($"User/{userId}", updateUserDto);
            }
            catch (Exception ex)
            {
                return new ApiResponse<UserDto>
                {
                    Success = false,
                    Message = $"Kullanıcı güncellenirken hata oluştu: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<bool>> DeleteUserAsync(int userId)
        {
            try
            {
                return await _apiService.DeleteAsync<bool>($"User/{userId}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = $"Kullanıcı silinirken hata oluştu: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<bool>> ToggleUserActivationAsync(int userId)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"User/{userId}/toggle-activation", new { });
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = $"Kullanıcı aktivasyon durumu değiştirilirken hata oluştu: {ex.Message}"
                };
            }
        }

        public List<string> GetAvailableRoles()
        {
            return new List<string> { "Admin", "Manager", "Sales", "Purchase", "Finance", "Warehouse", "Employee" };
        }

        public async Task<ApiResponse<bool>> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            try
            {
                var data = new
                {
                    userId = userId,
                    currentPassword = currentPassword,
                    newPassword = newPassword
                };

                return await _apiService.PostAsync<bool>("User/change-password", data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = $"Şifre değiştirilirken hata oluştu: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<bool>> ResetPasswordAsync(int userId, string newPassword)
        {
            try
            {
                var data = new
                {
                    userId = userId,
                    newPassword = newPassword
                };

                return await _apiService.PostAsync<bool>("User/reset-password", data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = $"Şifre sıfırlanırken hata oluştu: {ex.Message}"
                };
            }
        }
    }
}
