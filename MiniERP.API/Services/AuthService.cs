using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using MiniERP.API.DTOs;
using MiniERP.API.Models;
using MiniERP.API.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniERP.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, ILogger<AuthService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var user = await _unitOfWork.Users.AuthenticateAsync(loginDto.Username, loginDto.Password);
                
                if (user == null)
                {
                    return ApiResponse<LoginResponseDto>.ErrorResult("Invalid username or password");
                }

                var userDto = _mapper.Map<UserDto>(user);
                var token = GenerateJwtToken(userDto);

                var response = new LoginResponseDto
                {
                    Token = token,
                    User = userDto
                };

                _logger.LogInformation("User {Username} logged in successfully", loginDto.Username);
                return ApiResponse<LoginResponseDto>.SuccessResult(response, "Login successful");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for user {Username}", loginDto.Username);
                return ApiResponse<LoginResponseDto>.ErrorResult("An error occurred during login");
            }
        }

        public async Task<ApiResponse<UserDto>> RegisterAsync(CreateUserDto createUserDto)
        {
            try
            {
                // Check if username is unique
                if (!await _unitOfWork.Users.IsUsernameUniqueAsync(createUserDto.Username))
                {
                    return ApiResponse<UserDto>.ErrorResult("Username already exists");
                }

                // Check if email is unique
                if (!string.IsNullOrEmpty(createUserDto.Email) && 
                    !await _unitOfWork.Users.IsEmailUniqueAsync(createUserDto.Email))
                {
                    return ApiResponse<UserDto>.ErrorResult("Email already exists");
                }

                var user = _mapper.Map<User>(createUserDto);
                user.Password = HashPassword(createUserDto.Password); // In production, use proper hashing
                user.CreatedDate = DateTime.Now;
                user.IsActive = true;

                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();

                // Assign roles if provided
                if (createUserDto.RoleIds.Any())
                {
                    await _unitOfWork.Users.AssignRolesAsync(user.UserID, createUserDto.RoleIds);
                }

                var userWithRoles = await _unitOfWork.Users.GetUserWithRolesAsync(user.UserID);
                var userDto = _mapper.Map<UserDto>(userWithRoles);

                _logger.LogInformation("User {Username} registered successfully", createUserDto.Username);
                return ApiResponse<UserDto>.SuccessResult(userDto, "User registered successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user registration for {Username}", createUserDto.Username);
                return ApiResponse<UserDto>.ErrorResult("An error occurred during registration");
            }
        }

        public async Task<ApiResponse<string>> RefreshTokenAsync(string token)
        {
            try
            {
                // Validate the existing token
                var principal = GetPrincipalFromExpiredToken(token);
                if (principal == null)
                {
                    return ApiResponse<string>.ErrorResult("Invalid token");
                }

                var username = principal.Identity?.Name;
                if (string.IsNullOrEmpty(username))
                {
                    return ApiResponse<string>.ErrorResult("Invalid token");
                }

                var user = await _unitOfWork.Users.GetByUsernameAsync(username);
                if (user == null || !user.IsActive)
                {
                    return ApiResponse<string>.ErrorResult("User not found or inactive");
                }

                var userDto = _mapper.Map<UserDto>(user);
                var newToken = GenerateJwtToken(userDto);

                return ApiResponse<string>.SuccessResult(newToken, "Token refreshed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during token refresh");
                return ApiResponse<string>.ErrorResult("An error occurred during token refresh");
            }
        }

        public async Task<ApiResponse<bool>> ChangePasswordAsync(int userId, ChangePasswordDto changePasswordDto)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(userId);
                if (user == null)
                {
                    return ApiResponse<bool>.ErrorResult("User not found");
                }

                // Verify current password
                if (!VerifyPassword(changePasswordDto.CurrentPassword, user.Password))
                {
                    return ApiResponse<bool>.ErrorResult("Current password is incorrect");
                }

                var newPasswordHash = HashPassword(changePasswordDto.NewPassword);
                var success = await _unitOfWork.Users.UpdatePasswordAsync(userId, newPasswordHash);

                if (success)
                {
                    _logger.LogInformation("Password changed successfully for user {UserId}", userId);
                    return ApiResponse<bool>.SuccessResult(true, "Password changed successfully");
                }

                return ApiResponse<bool>.ErrorResult("Failed to change password");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during password change for user {UserId}", userId);
                return ApiResponse<bool>.ErrorResult("An error occurred during password change");
            }
        }

        public async Task<ApiResponse<bool>> LogoutAsync(int userId)
        {
            try
            {
                // In a real application, you might want to blacklist the token or store logout information
                _logger.LogInformation("User {UserId} logged out", userId);
                return await Task.FromResult(ApiResponse<bool>.SuccessResult(true, "Logout successful"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during logout for user {UserId}", userId);
                return ApiResponse<bool>.ErrorResult("An error occurred during logout");
            }
        }

        public string GenerateJwtToken(UserDto user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]!);

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new(ClaimTypes.Name, user.Username),
                new(ClaimTypes.Email, user.Email ?? ""),
                new("FirstName", user.FirstName ?? ""),
                new("LastName", user.LastName ?? "")
            };

            // Add role claims
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<ApiResponse<UserDto>> GetCurrentUserAsync(int userId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetUserWithRolesAsync(userId);
                if (user == null)
                {
                    return ApiResponse<UserDto>.ErrorResult("User not found");
                }

                var userDto = _mapper.Map<UserDto>(user);
                return ApiResponse<UserDto>.SuccessResult(userDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting current user {UserId}", userId);
                return ApiResponse<UserDto>.ErrorResult("An error occurred while getting user information");
            }
        }

        public async Task<bool> ValidateTokenAsync(string token)
        {
            try
            {
                var principal = GetPrincipalFromExpiredToken(token);
                return principal != null;
            }
            catch
            {
                return false;
            }
        }

        private string HashPassword(string password)
        {
            // In production, use BCrypt or similar
            return password; // This is just for demo purposes
        }

        private bool VerifyPassword(string password, string hash)
        {
            // In production, use BCrypt or similar
            return password == hash; // This is just for demo purposes
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]!);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                ValidateLifetime = false, // Don't validate lifetime for refresh
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

            if (validatedToken is not JwtSecurityToken jwtToken || 
                !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            return principal;
        }
    }
} 