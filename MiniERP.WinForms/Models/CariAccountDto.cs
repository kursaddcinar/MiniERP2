using Newtonsoft.Json;

namespace MiniERP.WinForms.Models
{
    public class CariAccountDto
    {
        [JsonProperty("cariID")]
        public int CariAccountID { get; set; }
        
        [JsonProperty("cariCode")]
        public string CariCode { get; set; } = string.Empty;
        
        [JsonProperty("cariName")]
        public string CariName { get; set; } = string.Empty;
        
        [JsonProperty("typeID")]
        public int TypeID { get; set; }
        
        [JsonProperty("typeName")]
        public string TypeName { get; set; } = string.Empty;
        
        [JsonProperty("taxNo")]
        public string TaxNumber { get; set; } = string.Empty;
        
        [JsonProperty("taxOffice")]
        public string TaxOffice { get; set; } = string.Empty;
        
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;
        
        [JsonProperty("phone")]
        public string Phone { get; set; } = string.Empty;
        
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;
        
        [JsonProperty("contactPerson")]
        public string ContactPerson { get; set; } = string.Empty;
        
        [JsonProperty("creditLimit")]
        public decimal CreditLimit { get; set; }
        
        [JsonProperty("currentBalance")]
        public decimal CurrentBalance { get; set; }
        
        [JsonProperty("balanceType")]
        public string BalanceType { get; set; } = string.Empty;
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;
    }

    public class CariTypeDto
    {
        [JsonProperty("typeID")]
        public int TypeID { get; set; }
        
        [JsonProperty("typeName")]
        public string TypeName { get; set; } = string.Empty;
        
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
        
        [JsonProperty("cariAccountCount")]
        public int CariAccountCount { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }

    public class CariTransactionDto
    {
        [JsonProperty("cariTransactionID")]
        public int CariTransactionID { get; set; }
        
        [JsonProperty("cariAccountID")]
        public int CariAccountID { get; set; }
        
        [JsonProperty("cariCode")]
        public string CariCode { get; set; } = string.Empty;
        
        [JsonProperty("cariName")]
        public string CariName { get; set; } = string.Empty;
        
        [JsonProperty("transactionType")]
        public string TransactionType { get; set; } = string.Empty;
        
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
        
        [JsonProperty("referenceType")]
        public string ReferenceType { get; set; } = string.Empty;
        
        [JsonProperty("referenceID")]
        public int? ReferenceID { get; set; }
        
        [JsonProperty("transactionDate")]
        public DateTime TransactionDate { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;
    }

    public class CreateCariAccountDto
    {
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public int TypeID { get; set; }
        public string TaxNumber { get; set; } = string.Empty;
        public string TaxOffice { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public decimal CreditLimit { get; set; }
    }

    public class UpdateCariAccountDto
    {
        public string CariName { get; set; } = string.Empty;
        public int TypeID { get; set; }
        public string TaxNumber { get; set; } = string.Empty;
        public string TaxOffice { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public decimal CreditLimit { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class CreateCariTransactionDto
    {
        public int CariAccountID { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ReferenceType { get; set; } = string.Empty;
        public int? ReferenceID { get; set; }
        public DateTime TransactionDate { get; set; }
    }
} 