using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("Collections")]
    public class Collection
    {
        [Key]
        public int CollectionID { get; set; }
        
        [Required]
        [StringLength(50)]
        public string CollectionNo { get; set; } = string.Empty;
        
        [Required]
        public int CariID { get; set; }
        
        [Required]
        public DateTime CollectionDate { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        
        [Required]
        public int PaymentTypeID { get; set; }
        
        [StringLength(255)]
        public string? Description { get; set; }
        
        [StringLength(20)]
        public string Status { get; set; } = "COMPLETED";
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        [ForeignKey("CariID")]
        public virtual CariAccount CariAccount { get; set; } = null!;
        
        [ForeignKey("PaymentTypeID")]
        public virtual PaymentType PaymentType { get; set; } = null!;
    }
} 