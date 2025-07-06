namespace MiniERP.API.DTOs
{
    public class StockCardDto
    {
        public int StockCardID { get; set; }
        public int ProductID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public decimal CurrentStock { get; set; }
        public decimal ReservedStock { get; set; }
        public decimal AvailableStock { get; set; }
        public decimal MinStockLevel { get; set; }
        public decimal MaxStockLevel { get; set; }
        public DateTime? LastTransactionDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string StockStatus { get; set; } = string.Empty; // NORMAL, CRITICAL, OVER
    }

    public class CreateStockCardDto
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public decimal CurrentStock { get; set; } = 0;
        public decimal ReservedStock { get; set; } = 0;
    }

    public class UpdateStockCardDto
    {
        public decimal CurrentStock { get; set; }
        public decimal ReservedStock { get; set; }
    }

    public class StockTransactionDto
    {
        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Description { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNo { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateStockTransactionDto
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } = string.Empty; // GIRIS, CIKIS
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; } = 0;
        public string? Description { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNo { get; set; }
    }

    public class StockMovementDto
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int FromWarehouseID { get; set; }
        public string FromWarehouseName { get; set; } = string.Empty;
        public int ToWarehouseID { get; set; }
        public string ToWarehouseName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string? Description { get; set; }
        public DateTime MovementDate { get; set; }
    }

    public class CreateStockMovementDto
    {
        public int ProductID { get; set; }
        public int FromWarehouseID { get; set; }
        public int ToWarehouseID { get; set; }
        public decimal Quantity { get; set; }
        public string? Description { get; set; }
        public DateTime MovementDate { get; set; }
    }

    public class StockReportDto
    {
        public string ReportType { get; set; } = string.Empty;
        public DateTime ReportDate { get; set; }
        public List<StockCardDto> StockCards { get; set; } = new List<StockCardDto>();
        public decimal TotalValue { get; set; }
        public int TotalProducts { get; set; }
        public int CriticalStockProducts { get; set; }
        public int OverStockProducts { get; set; }
        public int OutOfStockProducts { get; set; }
        public int TotalItems { get; set; }
    }

    public class StockSummaryDto
    {
        public int TotalProducts { get; set; }
        public int ActiveProducts { get; set; }
        public int CriticalStockProducts { get; set; }
        public int OverStockProducts { get; set; }
        public int OutOfStockProducts { get; set; }
        public decimal TotalStockValue { get; set; }
        public decimal TotalSaleValue { get; set; }
        public int TotalTransactions { get; set; }
        public decimal TotalIncoming { get; set; }
        public decimal TotalOutgoing { get; set; }
        public decimal TotalIncomingValue { get; set; }
        public decimal TotalOutgoingValue { get; set; }
    }

    public class WarehouseDto
    {
        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ResponsiblePerson { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalStockValue { get; set; }
    }

    public class CreateWarehouseDto
    {
        public string WarehouseCode { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ResponsiblePerson { get; set; }
    }

    public class UpdateWarehouseDto
    {
        public string WarehouseName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ResponsiblePerson { get; set; }
        public bool IsActive { get; set; } = true;
    }
} 