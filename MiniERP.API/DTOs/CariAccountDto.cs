namespace MiniERP.API.DTOs
{
    public class CariAccountDto
    {
        public int CariID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public int TypeID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string? TaxNo { get; set; }
        public string? TaxOffice { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ContactPerson { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string BalanceType { get; set; } = string.Empty; // ALACAK, BORÇ, SIFIR
    }

    public class CreateCariAccountDto
    {
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public int TypeID { get; set; }
        public string? TaxNo { get; set; }
        public string? TaxOffice { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ContactPerson { get; set; }
        public decimal CreditLimit { get; set; } = 0;
    }

    public class UpdateCariAccountDto
    {
        public string CariName { get; set; } = string.Empty;
        public int TypeID { get; set; }
        public string? TaxNo { get; set; }
        public string? TaxOffice { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ContactPerson { get; set; }
        public decimal CreditLimit { get; set; }
        public bool IsActive { get; set; } = true;
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

    public class CreateCariTypeDto
    {
        public string TypeCode { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class UpdateCariTypeDto
    {
        public string TypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class CariTransactionDto
    {
        public int TransactionID { get; set; }
        public int CariID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal Balance { get; set; }
        public string? Description { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNo { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateCariTransactionDto
    {
        public int CariID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } = string.Empty; // ALACAK, BORC
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNo { get; set; }
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