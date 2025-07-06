using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("StockTransactions")]
    public class StockTransaction
    {
        [Key]
        public int TransactionID { get; set; }
        
        [Required]
        public int ProductID { get; set; }
        
        [Required]
        public int WarehouseID { get; set; }
        
        [Required]
        public DateTime TransactionDate { get; set; }
        
        [Required]
        [StringLength(10)]
        public string TransactionType { get; set; } = string.Empty;
        
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } = 0;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; } = 0;
        
        [StringLength(255)]
        public string? Description { get; set; }
        
        [StringLength(20)]
        public string? DocumentType { get; set; }
        
        [StringLength(50)]
        public string? DocumentNo { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; } = null!;
        
        [ForeignKey("WarehouseID")]
        public virtual Warehouse Warehouse { get; set; } = null!;
    }
} 