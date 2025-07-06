using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("UserRoles")]
    public class UserRole
    {
        [Key]
        public int UserRoleID { get; set; }
        
        [Required]
        public int UserID { get; set; }
        
        [Required]
        public int RoleID { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        // Navigation Properties
        [ForeignKey("UserID")]
        public virtual User User { get; set; } = null!;
        
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; } = null!;
    }
} 