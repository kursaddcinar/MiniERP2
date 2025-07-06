using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("ProductCategories")]
    public class ProductCategory
    {
        [Key]
        public int CategoryID { get; set; }
        
        [Required]
        [StringLength(20)]
        public string CategoryCode { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;
        
        [StringLength(255)]
        public string? Description { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
} 