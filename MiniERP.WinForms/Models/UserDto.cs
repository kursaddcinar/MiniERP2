using Newtonsoft.Json;

namespace MiniERP.WinForms.Models
{
    public class UserDto
    {
        [JsonProperty("userID")]
        public int UserID { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;
        
        [JsonProperty("email")]
        public string? Email { get; set; }
        
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string? LastName { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("roles")]
        public List<string> Roles { get; set; } = new List<string>();
    }

    public class CreateUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<int> RoleIds { get; set; } = new List<int>();
    }

    public class UpdateUserDto
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; } = true;
        public List<int> RoleIds { get; set; } = new List<int>();
    }

    public class LoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponseDto
    {
        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;
        
        [JsonProperty("user")]
        public UserDto User { get; set; } = new UserDto();
    }

    public class ChangePasswordDto
    {
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
} 