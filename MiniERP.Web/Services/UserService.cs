using MiniERP.Web.Models;

namespace MiniERP.Web.Services
{
    public class UserService
    {
        private readonly ApiService _apiService;

        public UserService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<PagedResult<UserDto>> GetUsersAsync(int pageNumber = 1, int pageSize = 10, string searchTerm = "", string role = "")
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
                var result = await _apiService.GetAsync<PagedResult<UserDto>>($"api/User?{queryString}");
                
                return result.Data ?? new PagedResult<UserDto> { Data = new List<UserDto>(), TotalCount = 0 };
            }
            catch (Exception)
            {
                return new PagedResult<UserDto> { Data = new List<UserDto>(), TotalCount = 0 };
            }
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            try
            {
                var result = await _apiService.GetAsync<UserDto>($"api/User/{id}");
                return result.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserDto?> GetUserByUsernameAsync(string username)
        {
            try
            {
                var result = await _apiService.GetAsync<UserDto>($"api/User/username/{username}");
                return result.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ApiResponse<UserDto>> CreateUserAsync(CreateUserDto createDto)
        {
            try
            {
                // Web'deki DTO'yu API'nin beklediği formata dönüştür
                var apiCreateDto = new
                {
                    Username = createDto.Username,
                    Password = createDto.Password,
                    Email = createDto.Email,
                    FirstName = createDto.FirstName,
                    LastName = createDto.LastName,
                    RoleIds = await GetRoleIdsByNameAsync(createDto.Role)
                };

                return await _apiService.PostAsync<UserDto>("api/User", apiCreateDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<UserDto>> UpdateUserAsync(int id, UpdateUserDto updateDto)
        {
            try
            {
                // Web'deki DTO'yu API'nin beklediği formata dönüştür
                var apiUpdateDto = new
                {
                    Email = updateDto.Email,
                    FirstName = updateDto.FirstName,
                    LastName = updateDto.LastName,
                    IsActive = updateDto.IsActive,
                    RoleIds = await GetRoleIdsByNameAsync(updateDto.Role)
                };

                return await _apiService.PutAsync<UserDto>($"api/User/{id}", apiUpdateDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDto>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        private Task<List<int>> GetRoleIdsByNameAsync(string roleName)
        {
            try
            {
                if (string.IsNullOrEmpty(roleName))
                    return Task.FromResult(new List<int>());

                // Rol ID'lerini sabit kodlayarak çözüm sağlayalım (daha sonra API'den alınabilir)
                var roleMapping = new Dictionary<string, int>
                {
                    { "Admin", 1 },
                    { "Manager", 2 },
                    { "Sales", 3 },
                    { "Purchase", 4 },
                    { "Finance", 5 },
                    { "Warehouse", 6 },
                    { "Employee", 7 }
                };

                if (roleMapping.ContainsKey(roleName))
                {
                    return Task.FromResult(new List<int> { roleMapping[roleName] });
                }

                return Task.FromResult(new List<int>());
            }
            catch
            {
                return Task.FromResult(new List<int>());
            }
        }

        public async Task<ApiResponse<bool>> DeleteUserAsync(int id)
        {
            try
            {
                return await _apiService.DeleteAsync<bool>($"api/User/{id}");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> ChangePasswordAsync(int id, ChangePasswordDto changePasswordDto)
        {
            try
            {
                return await _apiService.PutAsync<bool>($"api/User/{id}/change-password", changePasswordDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> ActivateUserAsync(int id)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/User/{id}/activate", new { });
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeactivateUserAsync(int id)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/User/{id}/deactivate", new { });
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> ToggleUserActivationAsync(int id)
        {
            try
            {
                return await _apiService.PostAsync<bool>($"api/User/{id}/toggle-activation", new { });
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult($"Hata: {ex.Message}");
            }
        }

        public async Task<ApiResponse<List<RoleDto>>> GetRolesAsync()
        {
            try
            {
                return await _apiService.GetAsync<List<RoleDto>>("api/User/roles");
            }
            catch (Exception ex)
            {
                return ApiResponse<List<RoleDto>>.ErrorResult($"Hata: {ex.Message}");
            }
        }
    }
} 