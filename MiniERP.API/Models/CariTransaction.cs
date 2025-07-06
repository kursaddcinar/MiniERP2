using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.API.Models
{
    [Table("CariTransactions")]
    public class CariTransaction
    {
        [Key]
        public int TransactionID { get; set; }
        
        [Required]
        public int CariID { get; set; }
        
        [Required]
        public DateTime TransactionDate { get; set; }
        
        [Required]
        [StringLength(10)]
        public string TransactionType { get; set; } = string.Empty;
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        
        [StringLength(255)]
        public string? Description { get; set; }
        
        [StringLength(20)]
        public string? DocumentType { get; set; }
        
        [StringLength(50)]
        public string? DocumentNo { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public int? CreatedBy { get; set; }
        
        // Navigation Properties
        [ForeignKey("CariID")]
        public virtual CariAccount CariAccount { get; set; } = null!;
    }
} 