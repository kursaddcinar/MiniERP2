using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("PurchaseInvoices")]
    public class PurchaseInvoice
    {
        [Key]
        public int InvoiceID { get; set; }
        
        [Required]
        [StringLength(50)]
        public string InvoiceNo { get; set; } = string.Empty;
        
        [Required]
        public int CariID { get; set; }
        
        [Required]
        public int WarehouseID { get; set; }
        
        [Required]
        public DateTime InvoiceDate { get; set; }
        
        public DateTime? DueDate { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; } = 0;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal VatAmount { get; set; } = 0;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; } = 0;
        
        [StringLength(255)]
        public string? Description { get; set; }
        
        [StringLength(20)]
        public string Status { get; set; } = "DRAFT";
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        [ForeignKey("CariID")]
        public virtual CariAccount CariAccount { get; set; } = null!;
        
        [ForeignKey("WarehouseID")]
        public virtual Warehouse Warehouse { get; set; } = null!;
        
        public virtual ICollection<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; } = new List<PurchaseInvoiceDetail>();
    }
} 