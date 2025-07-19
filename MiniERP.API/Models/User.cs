using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? Email { get; set; }
        
        [StringLength(50)]
        public string? FirstName { get; set; }
        
        [StringLength(50)]
        public string? LastName { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? LastLoginDate { get; set; }
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
} 