using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.API.DTOs;
using MiniERP.API.Services;
using System.Security.Claims;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Tüm kullanıcıları getir (Admin ve Manager yetkisi gerekir)
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<PagedResult<UserDto>>>> GetUsers([FromQuery] PaginationParameters parameters)
        {
            var result = await _userService.GetUsersAsync(parameters);
            return Ok(result);
        }

        /// <summary>
        /// ID'ye göre kullanıcı getir
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<UserDto>>> GetUser(int id)
        {
            // Kullanıcı sadece kendi bilgilerini görebilir, Admin ve Manager herkesi görebilir
            var currentUserId = GetCurrentUserId();
            var isAdminOrManager = User.IsInRole("Admin") || User.IsInRole("Manager");
            
            if (!isAdminOrManager && currentUserId != id)
            {
                return Forbid();
            }

            var result = await _userService.GetUserByIdAsync(id);
            
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Yeni kullanıcı oluştur (Sadece Admin yetkisi gerekir)
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<UserDto>>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<UserDto>.ErrorResult("Invalid input data"));
            }

            var result = await _userService.CreateUserAsync(createUserDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetUser), new { id = result.Data?.UserID }, result);
        }

        /// <summary>
        /// Kullanıcı bilgilerini güncelle
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<UserDto>>> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<UserDto>.ErrorResult("Invalid input data"));
            }

            // Kullanıcı sadece kendi bilgilerini güncelleyebilir, Admin ve Manager herkesi güncelleyebilir
            var currentUserId = GetCurrentUserId();
            var isAdminOrManager = User.IsInRole("Admin") || User.IsInRole("Manager");
            
            if (!isAdminOrManager && currentUserId != id)
            {
                return Forbid();
            }

            // Eğer kullanıcı kendi bilgilerini güncelliyorsa, rol değiştirme yetkisi yok
            if (!isAdminOrManager && updateUserDto.RoleIds.Any())
            {
                updateUserDto.RoleIds.Clear();
            }

            var result = await _userService.UpdateUserAsync(id, updateUserDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Kullanıcı sil (Sadece Admin yetkisi gerekir)
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteUser(int id)
        {
            var currentUserId = GetCurrentUserId();
            
            // Kullanıcı kendini silemez
            if (currentUserId == id)
            {
                return BadRequest(ApiResponse<bool>.ErrorResult("You cannot delete your own account"));
            }

            var result = await _userService.DeleteUserAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Kullanıcıyı aktif et (Sadece Admin yetkisi gerekir)
        /// </summary>
        [HttpPost("{id:int}/activate")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> ActivateUser(int id)
        {
            var result = await _userService.ActivateUserAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Kullanıcıyı pasif et (Sadece Admin yetkisi gerekir)
        /// </summary>
        [HttpPost("{id:int}/deactivate")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeactivateUser(int id)
        {
            var currentUserId = GetCurrentUserId();
            
            // Kullanıcı kendini pasif yapamaz
            if (currentUserId == id)
            {
                return BadRequest(ApiResponse<bool>.ErrorResult("You cannot deactivate your own account"));
            }

            var result = await _userService.DeactivateUserAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Role göre kullanıcıları getir (Admin ve Manager yetkisi gerekir)
        /// </summary>
        [HttpGet("by-role/{roleName}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<List<UserDto>>>> GetUsersByRole(string roleName)
        {
            var result = await _userService.GetUsersByRoleAsync(roleName);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Tüm rolleri getir (Admin ve Manager yetkisi gerekir)
        /// </summary>
        [HttpGet("roles")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<List<RoleDto>>>> GetRoles()
        {
            var result = await _userService.GetRolesAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Yeni rol oluştur (Sadece Admin yetkisi gerekir)
        /// </summary>
        [HttpPost("roles")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<RoleDto>>> CreateRole([FromBody] CreateRoleDto createRoleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<RoleDto>.ErrorResult("Invalid input data"));
            }

            var result = await _userService.CreateRoleAsync(createRoleDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Rol güncelle (Sadece Admin yetkisi gerekir)
        /// </summary>
        [HttpPut("roles/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<RoleDto>>> UpdateRole(int id, [FromBody] UpdateRoleDto updateRoleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<RoleDto>.ErrorResult("Invalid input data"));
            }

            var result = await _userService.UpdateRoleAsync(id, updateRoleDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Rol sil (Sadece Admin yetkisi gerekir)
        /// </summary>
        [HttpDelete("roles/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteRole(int id)
        {
            var result = await _userService.DeleteRoleAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Kullanıcıya rol ata (Sadece Admin yetkisi gerekir)
        /// </summary>
        [HttpPost("{userId:int}/assign-roles")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> AssignRolesToUser(int userId, [FromBody] List<int> roleIds)
        {
            var result = await _userService.AssignRolesToUserAsync(userId, roleIds);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Mevcut kullanıcı bilgilerini getir
        /// </summary>
        [HttpGet("me")]
        public async Task<ActionResult<ApiResponse<UserDto>>> GetCurrentUser()
        {
            var currentUserId = GetCurrentUserId();
            var result = await _userService.GetUserByIdAsync(currentUserId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(userIdClaim, out var userId) ? userId : 0;
        }
    }
} 