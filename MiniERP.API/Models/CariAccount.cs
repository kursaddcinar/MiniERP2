using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("CariAccounts")]
    public class CariAccount
    {
        [Key]
        public int CariID { get; set; }
        
        [Required]
        [StringLength(20)]
        public string CariCode { get; set; } = string.Empty;
        
        [Required]
        [StringLength(150)]
        public string CariName { get; set; } = string.Empty;
        
        [Required]
        public int TypeID { get; set; }
        
        [StringLength(20)]
        public string? TaxNo { get; set; }
        
        [StringLength(100)]
        public string? TaxOffice { get; set; }
        
        [StringLength(255)]
        public string? Address { get; set; }
        
        [StringLength(50)]
        public string? City { get; set; }
        
        [StringLength(20)]
        public string? Phone { get; set; }
        
        [StringLength(100)]
        public string? Email { get; set; }
        
        [StringLength(100)]
        public string? ContactPerson { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal CreditLimit { get; set; } = 0;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentBalance { get; set; } = 0;
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        [ForeignKey("TypeID")]
        public virtual CariType Type { get; set; } = null!;
        
        public virtual ICollection<CariTransaction> CariTransactions { get; set; } = new List<CariTransaction>();
        public virtual ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();
        public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Collection> Collections { get; set; } = new List<Collection>();
    }
} 