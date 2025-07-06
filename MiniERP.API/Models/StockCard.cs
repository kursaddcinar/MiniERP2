using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("StockCards")]
    public class StockCard
    {
        [Key]
        public int StockCardID { get; set; }
        
        [Required]
        public int ProductID { get; set; }
        
        [Required]
        public int WarehouseID { get; set; }
        
        [Column(TypeName = "decimal(18,3)")]
        public decimal CurrentStock { get; set; } = 0;
        
        [Column(TypeName = "decimal(18,3)")]
        public decimal ReservedStock { get; set; } = 0;
        
        public DateTime? LastTransactionDate { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; } = null!;
        
        [ForeignKey("WarehouseID")]
        public virtual Warehouse Warehouse { get; set; } = null!;
    }
} 