using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("CariTypes")]
    public class CariType
    {
        [Key]
        public int TypeID { get; set; }
        
        [Required]
        [StringLength(10)]
        public string TypeCode { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string TypeName { get; set; } = string.Empty;
        
        [StringLength(255)]
        public string? Description { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        public virtual ICollection<CariAccount> CariAccounts { get; set; } = new List<CariAccount>();
    }
} 