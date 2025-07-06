using Newtonsoft.Json;

namespace MiniERP.WinForms.Models
{
    // Sales Invoice DTOs
    public class SalesInvoiceDto
    {
        [JsonProperty("salesInvoiceID")]
        public int SalesInvoiceID { get; set; }
        
        [JsonProperty("invoiceNo")]
        public string InvoiceNumber { get; set; } = string.Empty;
        
        [JsonProperty("invoiceDate")]
        public DateTime InvoiceDate { get; set; }
        
        [JsonProperty("cariAccountID")]
        public int CariAccountID { get; set; }
        
        [JsonProperty("cariCode")]
        public string CariCode { get; set; } = string.Empty;
        
        [JsonProperty("cariName")]
        public string CariName { get; set; } = string.Empty;
        
        [JsonProperty("warehouseID")]
        public int WarehouseID { get; set; }
        
        [JsonProperty("warehouseName")]
        public string WarehouseName { get; set; } = string.Empty;
        
        [JsonProperty("subtotalAmount")]
        public decimal SubtotalAmount { get; set; }
        
        [JsonProperty("vatAmount")]
        public decimal VatAmount { get; set; }
        
        [JsonProperty("totalAmount")]
        public decimal TotalAmount { get; set; }
        
        [JsonProperty("discountRate")]
        public decimal DiscountRate { get; set; }
        
        [JsonProperty("discountAmount")]
        public decimal DiscountAmount { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;
        
        [JsonProperty("notes")]
        public string Notes { get; set; } = string.Empty;
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;
        
        [JsonProperty("details")]
        public List<SalesInvoiceDetailDto> Details { get; set; } = new List<SalesInvoiceDetailDto>();
    }

    public class SalesInvoiceDetailDto
    {
        [JsonProperty("salesInvoiceDetailID")]
        public int SalesInvoiceDetailID { get; set; }
        
        [JsonProperty("salesInvoiceID")]
        public int SalesInvoiceID { get; set; }
        
        [JsonProperty("productID")]
        public int ProductID { get; set; }
        
        [JsonProperty("productCode")]
        public string ProductCode { get; set; } = string.Empty;
        
        [JsonProperty("productName")]
        public string ProductName { get; set; } = string.Empty;
        
        [JsonProperty("unitName")]
        public string UnitName { get; set; } = string.Empty;
        
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
        
        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }
        
        [JsonProperty("discountRate")]
        public decimal DiscountRate { get; set; }
        
        [JsonProperty("discountAmount")]
        public decimal DiscountAmount { get; set; }
        
        [JsonProperty("subtotalAmount")]
        public decimal SubtotalAmount { get; set; }
        
        [JsonProperty("vatRate")]
        public decimal VatRate { get; set; }
        
        [JsonProperty("vatAmount")]
        public decimal VatAmount { get; set; }
        
        [JsonProperty("totalAmount")]
        public decimal TotalAmount { get; set; }
    }

    // Purchase Invoice DTOs
    public class PurchaseInvoiceDto
    {
        [JsonProperty("purchaseInvoiceID")]
        public int PurchaseInvoiceID { get; set; }
        
        [JsonProperty("invoiceNo")]
        public string InvoiceNumber { get; set; } = string.Empty;
        
        [JsonProperty("invoiceDate")]
        public DateTime InvoiceDate { get; set; }
        
        [JsonProperty("cariAccountID")]
        public int CariAccountID { get; set; }
        
        [JsonProperty("cariCode")]
        public string CariCode { get; set; } = string.Empty;
        
        [JsonProperty("cariName")]
        public string CariName { get; set; } = string.Empty;
        
        [JsonProperty("warehouseID")]
        public int WarehouseID { get; set; }
        
        [JsonProperty("warehouseName")]
        public string WarehouseName { get; set; } = string.Empty;
        
        [JsonProperty("subtotalAmount")]
        public decimal SubtotalAmount { get; set; }
        
        [JsonProperty("vatAmount")]
        public decimal VatAmount { get; set; }
        
        [JsonProperty("totalAmount")]
        public decimal TotalAmount { get; set; }
        
        [JsonProperty("discountRate")]
        public decimal DiscountRate { get; set; }
        
        [JsonProperty("discountAmount")]
        public decimal DiscountAmount { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;
        
        [JsonProperty("notes")]
        public string Notes { get; set; } = string.Empty;
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;
        
        [JsonProperty("details")]
        public List<PurchaseInvoiceDetailDto> Details { get; set; } = new List<PurchaseInvoiceDetailDto>();
    }

    public class PurchaseInvoiceDetailDto
    {
        [JsonProperty("purchaseInvoiceDetailID")]
        public int PurchaseInvoiceDetailID { get; set; }
        
        [JsonProperty("purchaseInvoiceID")]
        public int PurchaseInvoiceID { get; set; }
        
        [JsonProperty("productID")]
        public int ProductID { get; set; }
        
        [JsonProperty("productCode")]
        public string ProductCode { get; set; } = string.Empty;
        
        [JsonProperty("productName")]
        public string ProductName { get; set; } = string.Empty;
        
        [JsonProperty("unitName")]
        public string UnitName { get; set; } = string.Empty;
        
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
        
        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }
        
        [JsonProperty("discountRate")]
        public decimal DiscountRate { get; set; }
        
        [JsonProperty("discountAmount")]
        public decimal DiscountAmount { get; set; }
        
        [JsonProperty("subtotalAmount")]
        public decimal SubtotalAmount { get; set; }
        
        [JsonProperty("vatRate")]
        public decimal VatRate { get; set; }
        
        [JsonProperty("vatAmount")]
        public decimal VatAmount { get; set; }
        
        [JsonProperty("totalAmount")]
        public decimal TotalAmount { get; set; }
    }

    // Create DTOs
    public class CreateSalesInvoiceDto
    {
        public DateTime InvoiceDate { get; set; }
        public int CariAccountID { get; set; }
        public int WarehouseID { get; set; }
        public decimal DiscountRate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public List<CreateSalesInvoiceDetailDto> Details { get; set; } = new List<CreateSalesInvoiceDetailDto>();
    }

    public class CreateSalesInvoiceDetailDto
    {
        public int ProductID { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountRate { get; set; }
    }

    public class CreatePurchaseInvoiceDto
    {
        public DateTime InvoiceDate { get; set; }
        public int CariAccountID { get; set; }
        public int WarehouseID { get; set; }
        public decimal DiscountRate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public List<CreatePurchaseInvoiceDetailDto> Details { get; set; } = new List<CreatePurchaseInvoiceDetailDto>();
    }

    public class CreatePurchaseInvoiceDetailDto
    {
        public int ProductID { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountRate { get; set; }
    }

    // Update DTOs
    public class UpdateSalesInvoiceDto
    {
        public DateTime InvoiceDate { get; set; }
        public int CariAccountID { get; set; }
        public int WarehouseID { get; set; }
        public decimal DiscountRate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public List<CreateSalesInvoiceDetailDto> Details { get; set; } = new List<CreateSalesInvoiceDetailDto>();
    }

    public class UpdatePurchaseInvoiceDto
    {
        public DateTime InvoiceDate { get; set; }
        public int CariAccountID { get; set; }
        public int WarehouseID { get; set; }
        public decimal DiscountRate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public List<CreatePurchaseInvoiceDetailDto> Details { get; set; } = new List<CreatePurchaseInvoiceDetailDto>();
    }

    // Invoice cancellation DTO
    public class InvoiceCancellationDto
    {
        public string CancellationReason { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
} 