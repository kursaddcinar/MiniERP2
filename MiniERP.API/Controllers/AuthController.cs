using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.API.DTOs;
using MiniERP.API.Services;
using System.Security.Claims;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        /// <summary>
        /// User login
        /// </summary>
        /// <param name="loginDto">Login credentials</param>
        /// <returns>JWT token and user information</returns>
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<LoginResponseDto>>> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<LoginResponseDto>.ErrorResult("Invalid input data"));
            }

            var result = await _authService.LoginAsync(loginDto);

            if (!result.Success)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// User registration
        /// </summary>
        /// <param name="createUserDto">User registration data</param>
        /// <returns>Created user information</returns>
        [HttpPost("register")]
        [Authorize(Roles = "Admin")] // Only admins can register new users
        public async Task<ActionResult<ApiResponse<UserDto>>> Register([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<UserDto>.ErrorResult("Invalid input data"));
            }

            var result = await _authService.RegisterAsync(createUserDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetCurrentUser), new { }, result);
        }

        /// <summary>
        /// Refresh JWT token
        /// </summary>
        /// <param name="token">Current JWT token</param>
        /// <returns>New JWT token</returns>
        [HttpPost("refresh-token")]
        public async Task<ActionResult<ApiResponse<string>>> RefreshToken([FromBody] string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(ApiResponse<string>.ErrorResult("Token is required"));
            }

            var result = await _authService.RefreshTokenAsync(token);

            if (!result.Success)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="changePasswordDto">Password change data</param>
        /// <returns>Success status</returns>
        [HttpPost("change-password")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<bool>>> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<bool>.ErrorResult("Invalid input data"));
            }

            var userId = GetCurrentUserId();
            if (userId == 0)
            {
                return Unauthorized(ApiResponse<bool>.ErrorResult("User not found"));
            }

            var result = await _authService.ChangePasswordAsync(userId, changePasswordDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get current user information
        /// </summary>
        /// <returns>Current user data</returns>
        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<UserDto>>> GetCurrentUser()
        {
            var userId = GetCurrentUserId();
            if (userId == 0)
            {
                return Unauthorized(ApiResponse<UserDto>.ErrorResult("User not found"));
            }

            var result = await _authService.GetCurrentUserAsync(userId);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// User logout
        /// </summary>
        /// <returns>Success status</returns>
        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<bool>>> Logout()
        {
            var userId = GetCurrentUserId();
            if (userId == 0)
            {
                return Unauthorized(ApiResponse<bool>.ErrorResult("User not found"));
            }

            var result = await _authService.LogoutAsync(userId);
            return Ok(result);
        }

        /// <summary>
        /// Validate JWT token
        /// </summary>
        /// <param name="token">JWT token to validate</param>
        /// <returns>Validation result</returns>
        [HttpPost("validate-token")]
        public async Task<ActionResult<ApiResponse<bool>>> ValidateToken([FromBody] string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(ApiResponse<bool>.ErrorResult("Token is required"));
            }

            var isValid = await _authService.ValidateTokenAsync(token);
            return Ok(ApiResponse<bool>.SuccessResult(isValid, isValid ? "Token is valid" : "Token is invalid"));
        }

        /// <summary>
        /// Initialize test users for development/testing purposes
        /// </summary>
        /// <returns>Initialization result</returns>
        [HttpPost("initialize-test-users")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<object>>> InitializeTestUsers()
        {
            try
            {
                var result = await _authService.InitializeTestUsersAsync();
                
                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error initializing test users");
                return StatusCode(500, ApiResponse<object>.ErrorResult("Internal server error"));
            }
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(userIdClaim, out var userId) ? userId : 0;
        }
    }
} 