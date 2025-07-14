using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MiniERP.Web.Models
{
    public class CariAccountDto
    {
        public int CariID { get; set; }
        public int CariAccountID => CariID; // API'den gelen CariID'yi CariAccountID olarak kullan
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        [JsonProperty("TaxNo")]
        public string? TaxNumber { get; set; }
        public string? TaxOffice { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public bool IsCustomer { get; set; }
        public bool IsSupplier { get; set; }
    }

    public class CreateCariAccountDto
    {
        [Required(ErrorMessage = "Cari kodu gereklidir")]
        [Display(Name = "Cari Kodu")]
        public string CariCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cari adı gereklidir")]
        [Display(Name = "Cari Adı")]
        public string CariName { get; set; } = string.Empty;

        [Display(Name = "İletişim Kişisi")]
        public string? ContactPerson { get; set; }

        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "E-posta")]
        public string? Email { get; set; }

        [Display(Name = "Adres")]
        public string? Address { get; set; }

        [Display(Name = "Vergi Numarası")]
        [JsonProperty("TaxNo")]
        public string? TaxNumber { get; set; }

        [Display(Name = "Vergi Dairesi")]
        public string? TaxOffice { get; set; }

        [Display(Name = "Kredi Limiti")]
        public decimal CreditLimit { get; set; }

        [Required(ErrorMessage = "Cari tipi seçimi gereklidir")]
        [Display(Name = "Cari Tipi")]
        public int TypeID { get; set; }
    }

    public class UpdateCariAccountDto
    {
        [Required(ErrorMessage = "Cari kodu gereklidir")]
        [Display(Name = "Cari Kodu")]
        public string CariCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cari adı gereklidir")]
        [Display(Name = "Cari Adı")]
        public string CariName { get; set; } = string.Empty;

        [Display(Name = "İletişim Kişisi")]
        public string? ContactPerson { get; set; }

        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "E-posta")]
        public string? Email { get; set; }

        [Display(Name = "Adres")]
        public string? Address { get; set; }

        [Display(Name = "Vergi Numarası")]
        [JsonProperty("TaxNo")]
        public string? TaxNumber { get; set; }

        [Display(Name = "Vergi Dairesi")]
        public string? TaxOffice { get; set; }

        [Display(Name = "Kredi Limiti")]
        public decimal CreditLimit { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Cari tipi seçimi gereklidir")]
        [Display(Name = "Cari Tipi")]
        public int TypeID { get; set; }
    }

    public class CariTypeDto
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CariTransactionDto
    {
        public int TransactionID { get; set; }
        public int CariID { get; set; }
        public int CariAccountID => CariID; // API'den gelen CariID'yi CariAccountID olarak kullan
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentNo { get; set; } = string.Empty;
        public string DocumentNumber => DocumentNo; // API'den gelen DocumentNo'yu DocumentNumber olarak kullan
        public string TransactionType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal Balance { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CariStatementDto
    {
        public int CariAccountID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public decimal OpeningBalance { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal ClosingBalance { get; set; }
        public List<CariTransactionDto> Transactions { get; set; } = new List<CariTransactionDto>();
    }
}
