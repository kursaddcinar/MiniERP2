namespace MiniERP.WinForms.DTOs
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
        public string StockStatus { get; set; } = string.Empty; // NORMAL, CRITICAL, OVER, OUT
    }

    public class CreateStockCardDto
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public decimal CurrentStock { get; set; } = 0;
        public decimal ReservedStock { get; set; } = 0;
        public decimal MinStockLevel { get; set; } = 0;
        public decimal MaxStockLevel { get; set; } = 0;
    }

    public class UpdateStockCardDto
    {
        public decimal CurrentStock { get; set; }
        public decimal ReservedStock { get; set; }
        public decimal MinStockLevel { get; set; }
        public decimal MaxStockLevel { get; set; }
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
        public string TransactionType { get; set; } = string.Empty; // GIRIS, CIKIS
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

    public class StockSummaryDto
    {
        public int TotalStock { get; set; }
        public int CriticalStock { get; set; }
        public int OutOfStock { get; set; }
        public int TodayMovements { get; set; }
        public decimal TotalValue { get; set; }
    }

    public class StockCardDisplayDto
    {
        public int StockCardID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;
        public decimal CurrentStock { get; set; }
        public decimal ReservedStock { get; set; }
        public decimal AvailableStock { get; set; }
        public string StockStatus { get; set; } = string.Empty;
        public string LastTransactionDate { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
    }

    public class UpdateStockDto
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public decimal Quantity { get; set; }
        public string MovementType { get; set; } = string.Empty; // "IN" veya "OUT"
        public decimal? UnitPrice { get; set; }
        public string? Description { get; set; }
    }

}
