using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("Units")]
    public class Unit
    {
        [Key]
        public int UnitID { get; set; }
        
        [Required]
        [StringLength(10)]
        public string UnitCode { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string UnitName { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
} 