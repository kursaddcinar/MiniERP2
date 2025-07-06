using Newtonsoft.Json;

namespace MiniERP.WinForms.Models
{
    public class StockCardDto
    {
        [JsonProperty("stockCardID")]
        public int StockCardID { get; set; }
        
        [JsonProperty("productID")]
        public int ProductID { get; set; }
        
        [JsonProperty("productCode")]
        public string ProductCode { get; set; } = string.Empty;
        
        [JsonProperty("productName")]
        public string ProductName { get; set; } = string.Empty;
        
        [JsonProperty("warehouseID")]
        public int WarehouseID { get; set; }
        
        [JsonProperty("warehouseCode")]
        public string WarehouseCode { get; set; } = string.Empty;
        
        [JsonProperty("warehouseName")]
        public string WarehouseName { get; set; } = string.Empty;
        
        [JsonProperty("unitName")]
        public string UnitName { get; set; } = string.Empty;
        
        [JsonProperty("currentStock")]
        public decimal CurrentStock { get; set; }
        
        [JsonProperty("reservedStock")]
        public decimal ReservedStock { get; set; }
        
        [JsonProperty("availableStock")]
        public decimal AvailableStock { get; set; }
        
        [JsonProperty("minStockLevel")]
        public decimal MinStockLevel { get; set; }
        
        [JsonProperty("maxStockLevel")]
        public decimal MaxStockLevel { get; set; }
        
        [JsonProperty("stockStatus")]
        public string StockStatus { get; set; } = string.Empty;
        
        [JsonProperty("lastUpdateDate")]
        public DateTime LastUpdateDate { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }

    public class StockTransactionDto
    {
        [JsonProperty("stockTransactionID")]
        public int StockTransactionID { get; set; }
        
        [JsonProperty("productID")]
        public int ProductID { get; set; }
        
        [JsonProperty("productCode")]
        public string ProductCode { get; set; } = string.Empty;
        
        [JsonProperty("productName")]
        public string ProductName { get; set; } = string.Empty;
        
        [JsonProperty("warehouseID")]
        public int WarehouseID { get; set; }
        
        [JsonProperty("warehouseCode")]
        public string WarehouseCode { get; set; } = string.Empty;
        
        [JsonProperty("warehouseName")]
        public string WarehouseName { get; set; } = string.Empty;
        
        [JsonProperty("unitName")]
        public string UnitName { get; set; } = string.Empty;
        
        [JsonProperty("transactionType")]
        public string TransactionType { get; set; } = string.Empty;
        
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
        
        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }
        
        [JsonProperty("totalAmount")]
        public decimal TotalAmount { get; set; }
        
        [JsonProperty("referenceType")]
        public string ReferenceType { get; set; } = string.Empty;
        
        [JsonProperty("referenceID")]
        public int? ReferenceID { get; set; }
        
        [JsonProperty("notes")]
        public string Notes { get; set; } = string.Empty;
        
        [JsonProperty("transactionDate")]
        public DateTime TransactionDate { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;
    }

    public class WarehouseDto
    {
        [JsonProperty("warehouseID")]
        public int WarehouseID { get; set; }
        
        [JsonProperty("warehouseCode")]
        public string WarehouseCode { get; set; } = string.Empty;
        
        [JsonProperty("warehouseName")]
        public string WarehouseName { get; set; } = string.Empty;
        
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;
        
        [JsonProperty("phone")]
        public string Phone { get; set; } = string.Empty;
        
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;
        
        [JsonProperty("responsiblePerson")]
        public string ResponsiblePerson { get; set; } = string.Empty;
        
        [JsonProperty("productCount")]
        public int ProductCount { get; set; }
        
        [JsonProperty("totalStockValue")]
        public decimal TotalStockValue { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }

    public class CreateStockTransactionDto
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ReferenceType { get; set; } = string.Empty;
        public int? ReferenceID { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
    }

    public class ReserveStockDto
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public decimal Quantity { get; set; }
        public string ReferenceType { get; set; } = string.Empty;
        public int? ReferenceID { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
} 