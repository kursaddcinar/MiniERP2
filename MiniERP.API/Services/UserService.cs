using AutoMapper;
using MiniERP.API.DTOs;
using MiniERP.API.Models;
using MiniERP.API.Repositories;

namespace MiniERP.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResponse<PagedResult<UserDto>>> GetUsersAsync(PaginationParameters parameters)
        {
            try
            {
                var (users, totalCount) = await _unitOfWork.Users.GetPagedWithCountAsync(
                    parameters.PageNumber, 
                    parameters.PageSize);

                var userDtos = _mapper.Map<List<UserDto>>(users);
                var pagedResult = new PagedResult<UserDto>(userDtos, totalCount, parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<UserDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting users");
                return ApiResponse<PagedResult<UserDto>>.ErrorResult("An error occurred while getting users");
            }
        }

        public async Task<ApiResponse<UserDto>> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetUserWithRolesAsync(id);
                if (user == null)
                {
                    return ApiResponse<UserDto>.ErrorResult("User not found");
                }

                var userDto = _mapper.Map<UserDto>(user);
                return ApiResponse<UserDto>.SuccessResult(userDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user {UserId}", id);
                return ApiResponse<UserDto>.ErrorResult("An error occurred while getting user");
            }
        }

        public async Task<ApiResponse<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            try
            {
                // Check uniqueness
                if (!await _unitOfWork.Users.IsUsernameUniqueAsync(createUserDto.Username))
                {
                    return ApiResponse<UserDto>.ErrorResult("Username already exists");
                }

                if (!string.IsNullOrEmpty(createUserDto.Email) && 
                    !await _unitOfWork.Users.IsEmailUniqueAsync(createUserDto.Email))
                {
                    return ApiResponse<UserDto>.ErrorResult("Email already exists");
                }

                var user = _mapper.Map<User>(createUserDto);
                user.Password = HashPassword(createUserDto.Password);
                user.CreatedDate = DateTime.Now;
                user.IsActive = true;

                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();

                // Assign roles
                if (createUserDto.RoleIds.Any())
                {
                    await _unitOfWork.Users.AssignRolesAsync(user.UserID, createUserDto.RoleIds);
                }

                var userWithRoles = await _unitOfWork.Users.GetUserWithRolesAsync(user.UserID);
                var userDto = _mapper.Map<UserDto>(userWithRoles);

                _logger.LogInformation("User {Username} created successfully", createUserDto.Username);
                return ApiResponse<UserDto>.SuccessResult(userDto, "User created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user {Username}", createUserDto.Username);
                return ApiResponse<UserDto>.ErrorResult("An error occurred while creating user");
            }
        }

        public async Task<ApiResponse<UserDto>> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(id);
                if (user == null)
                {
                    return ApiResponse<UserDto>.ErrorResult("User not found");
                }

                // Check email uniqueness
                if (!string.IsNullOrEmpty(updateUserDto.Email) && 
                    !await _unitOfWork.Users.IsEmailUniqueAsync(updateUserDto.Email, id))
                {
                    return ApiResponse<UserDto>.ErrorResult("Email already exists");
                }

                _mapper.Map(updateUserDto, user);
                await _unitOfWork.Users.UpdateAsync(user);

                // Update roles
                if (updateUserDto.RoleIds.Any())
                {
                    await _unitOfWork.Users.AssignRolesAsync(id, updateUserDto.RoleIds);
                }

                await _unitOfWork.SaveChangesAsync();

                var userWithRoles = await _unitOfWork.Users.GetUserWithRolesAsync(id);
                var userDto = _mapper.Map<UserDto>(userWithRoles);

                _logger.LogInformation("User {UserId} updated successfully", id);
                return ApiResponse<UserDto>.SuccessResult(userDto, "User updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user {UserId}", id);
                return ApiResponse<UserDto>.ErrorResult("An error occurred while updating user");
            }
        }

        public async Task<ApiResponse<bool>> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(id);
                if (user == null)
                {
                    return ApiResponse<bool>.ErrorResult("User not found");
                }

                await _unitOfWork.Users.DeleteAsync(user);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("User {UserId} deleted successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "User deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user {UserId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while deleting user");
            }
        }

        public async Task<ApiResponse<bool>> ActivateUserAsync(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(id);
                if (user == null)
                {
                    return ApiResponse<bool>.ErrorResult("User not found");
                }

                user.IsActive = true;
                await _unitOfWork.Users.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("User {UserId} activated successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "User activated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error activating user {UserId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while activating user");
            }
        }

        public async Task<ApiResponse<bool>> DeactivateUserAsync(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(id);
                if (user == null)
                {
                    return ApiResponse<bool>.ErrorResult("User not found");
                }

                user.IsActive = false;
                await _unitOfWork.Users.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("User {UserId} deactivated successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "User deactivated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deactivating user {UserId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while deactivating user");
            }
        }

        public async Task<ApiResponse<List<UserDto>>> GetUsersByRoleAsync(string roleName)
        {
            try
            {
                var users = await _unitOfWork.Users.GetUsersByRoleAsync(roleName);
                var userDtos = _mapper.Map<List<UserDto>>(users);

                return ApiResponse<List<UserDto>>.SuccessResult(userDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting users by role {RoleName}", roleName);
                return ApiResponse<List<UserDto>>.ErrorResult("An error occurred while getting users by role");
            }
        }

        public async Task<ApiResponse<List<RoleDto>>> GetRolesAsync()
        {
            try
            {
                var roles = await _unitOfWork.Roles.GetAllAsync();
                var roleDtos = _mapper.Map<List<RoleDto>>(roles);

                return ApiResponse<List<RoleDto>>.SuccessResult(roleDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting roles");
                return ApiResponse<List<RoleDto>>.ErrorResult("An error occurred while getting roles");
            }
        }

        public async Task<ApiResponse<RoleDto>> CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            try
            {
                var role = _mapper.Map<Role>(createRoleDto);
                role.CreatedDate = DateTime.Now;
                role.IsActive = true;

                await _unitOfWork.Roles.AddAsync(role);
                await _unitOfWork.SaveChangesAsync();

                var roleDto = _mapper.Map<RoleDto>(role);

                _logger.LogInformation("Role {RoleName} created successfully", createRoleDto.RoleName);
                return ApiResponse<RoleDto>.SuccessResult(roleDto, "Role created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating role {RoleName}", createRoleDto.RoleName);
                return ApiResponse<RoleDto>.ErrorResult("An error occurred while creating role");
            }
        }

        public async Task<ApiResponse<RoleDto>> UpdateRoleAsync(int id, UpdateRoleDto updateRoleDto)
        {
            try
            {
                var role = await _unitOfWork.Roles.GetByIdAsync(id);
                if (role == null)
                {
                    return ApiResponse<RoleDto>.ErrorResult("Role not found");
                }

                _mapper.Map(updateRoleDto, role);
                await _unitOfWork.Roles.UpdateAsync(role);
                await _unitOfWork.SaveChangesAsync();

                var roleDto = _mapper.Map<RoleDto>(role);

                _logger.LogInformation("Role {RoleId} updated successfully", id);
                return ApiResponse<RoleDto>.SuccessResult(roleDto, "Role updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating role {RoleId}", id);
                return ApiResponse<RoleDto>.ErrorResult("An error occurred while updating role");
            }
        }

        public async Task<ApiResponse<bool>> DeleteRoleAsync(int id)
        {
            try
            {
                var role = await _unitOfWork.Roles.GetByIdAsync(id);
                if (role == null)
                {
                    return ApiResponse<bool>.ErrorResult("Role not found");
                }

                await _unitOfWork.Roles.DeleteAsync(role);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Role {RoleId} deleted successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Role deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting role {RoleId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while deleting role");
            }
        }

        public async Task<ApiResponse<bool>> AssignRolesToUserAsync(int userId, List<int> roleIds)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(userId);
                if (user == null)
                {
                    return ApiResponse<bool>.ErrorResult("User not found");
                }

                await _unitOfWork.Users.AssignRolesAsync(userId, roleIds);

                _logger.LogInformation("Roles assigned to user {UserId} successfully", userId);
                return ApiResponse<bool>.SuccessResult(true, "Roles assigned successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning roles to user {UserId}", userId);
                return ApiResponse<bool>.ErrorResult("An error occurred while assigning roles");
            }
        }

        private string HashPassword(string password)
        {
            // In production, use BCrypt or similar
            return password; // This is just for demo purposes
        }
    }
} 