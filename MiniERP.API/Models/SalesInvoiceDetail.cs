using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("SalesInvoiceDetails")]
    public class SalesInvoiceDetail
    {
        [Key]
        public int DetailID { get; set; }
        
        [Required]
        public int InvoiceID { get; set; }
        
        [Required]
        public int ProductID { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal VatRate { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal LineTotal { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal VatAmount { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetTotal { get; set; }
        
        [StringLength(255)]
        public string? Description { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        [ForeignKey("InvoiceID")]
        public virtual SalesInvoice SalesInvoice { get; set; } = null!;
        
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; } = null!;
    }
} 