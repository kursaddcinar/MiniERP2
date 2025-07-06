using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; } = string.Empty;
        
        [StringLength(255)]
        public string? Description { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
} 