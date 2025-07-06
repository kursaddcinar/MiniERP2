using MiniERP.API.DTOs;

namespace MiniERP.API.Services
{
    public interface IUserService
    {
        Task<ApiResponse<PagedResult<UserDto>>> GetUsersAsync(PaginationParameters parameters);
        Task<ApiResponse<UserDto>> GetUserByIdAsync(int id);
        Task<ApiResponse<UserDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<ApiResponse<UserDto>> UpdateUserAsync(int id, UpdateUserDto updateUserDto);
        Task<ApiResponse<bool>> DeleteUserAsync(int id);
        Task<ApiResponse<bool>> ActivateUserAsync(int id);
        Task<ApiResponse<bool>> DeactivateUserAsync(int id);
        Task<ApiResponse<List<UserDto>>> GetUsersByRoleAsync(string roleName);
        Task<ApiResponse<List<RoleDto>>> GetRolesAsync();
        Task<ApiResponse<RoleDto>> CreateRoleAsync(CreateRoleDto createRoleDto);
        Task<ApiResponse<RoleDto>> UpdateRoleAsync(int id, UpdateRoleDto updateRoleDto);
        Task<ApiResponse<bool>> DeleteRoleAsync(int id);
        Task<ApiResponse<bool>> AssignRolesToUserAsync(int userId, List<int> roleIds);
    }
} 