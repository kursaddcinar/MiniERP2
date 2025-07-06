using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("Warehouses")]
    public class Warehouse
    {
        [Key]
        public int WarehouseID { get; set; }
        
        [Required]
        [StringLength(20)]
        public string WarehouseCode { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string WarehouseName { get; set; } = string.Empty;
        
        [StringLength(255)]
        public string? Address { get; set; }
        
        [StringLength(50)]
        public string? City { get; set; }
        
        [StringLength(100)]
        public string? ResponsiblePerson { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        public virtual ICollection<StockCard> StockCards { get; set; } = new List<StockCard>();
        public virtual ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();
        public virtual ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();
        public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
    }
} 