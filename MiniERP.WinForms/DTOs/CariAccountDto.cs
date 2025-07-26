using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiniERP.WinForms.DTOs
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
        public string? TaxNo { get; set; }
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
        public string BalanceType { get; set; } = string.Empty; // ALACAK, BORÇ, SIFIR
    }

    public class CreateCariAccountDto
    {
        [Required(ErrorMessage = "Cari kodu gereklidir")]
        public string CariCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cari adı gereklidir")]
        public string CariName { get; set; } = string.Empty;

        public string? ContactPerson { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? TaxNo { get; set; }
        public string? TaxOffice { get; set; }
        public decimal CreditLimit { get; set; }
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Cari tipi seçimi gereklidir")]
        public int TypeID { get; set; }
    }

    public class UpdateCariAccountDto
    {
        [Required(ErrorMessage = "Cari kodu gereklidir")]
        public string CariCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cari adı gereklidir")]
        public string CariName { get; set; } = string.Empty;

        public string? ContactPerson { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? TaxNo { get; set; }
        public string? TaxOffice { get; set; }
        public decimal CreditLimit { get; set; }
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Cari tipi seçimi gereklidir")]
        public int TypeID { get; set; }
    }

    public class CariTypeDto
    {
        public int TypeID { get; set; }
        public string TypeCode { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CariAccountCount { get; set; }
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

    public class CariBalanceDto
    {
        public int CariID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public decimal CurrentBalance { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal CreditUsed { get; set; }
        public decimal CreditAvailable { get; set; }
        public string BalanceType { get; set; } = string.Empty;
        public DateTime LastTransactionDate { get; set; }
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


