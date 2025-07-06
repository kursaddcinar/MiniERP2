using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        
        [Required]
        [StringLength(30)]
        public string ProductCode { get; set; } = string.Empty;
        
        [Required]
        [StringLength(150)]
        public string ProductName { get; set; } = string.Empty;
        
        public int? CategoryID { get; set; }
        
        [Required]
        public int UnitID { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; } = 0;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; } = 0;
        
        [Column(TypeName = "decimal(5,2)")]
        public decimal VatRate { get; set; } = 18;
        
        [Column(TypeName = "decimal(18,3)")]
        public decimal MinStockLevel { get; set; } = 0;
        
        [Column(TypeName = "decimal(18,3)")]
        public decimal MaxStockLevel { get; set; } = 0;
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        [ForeignKey("CategoryID")]
        public virtual ProductCategory? Category { get; set; }
        
        [ForeignKey("UnitID")]
        public virtual Unit Unit { get; set; } = null!;
        
        public virtual ICollection<StockCard> StockCards { get; set; } = new List<StockCard>();
        public virtual ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();
        public virtual ICollection<SalesInvoiceDetail> SalesInvoiceDetails { get; set; } = new List<SalesInvoiceDetail>();
        public virtual ICollection<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; } = new List<PurchaseInvoiceDetail>();
    }
} 