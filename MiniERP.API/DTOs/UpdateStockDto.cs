namespace MiniERP.API.DTOs
{
    public class UpdateStockDto
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public decimal Quantity { get; set; }
        public string TransactionType { get; set; } = string.Empty; // GIRIS veya CIKIS
    }

    public class DetailedUpdateStockDto
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public decimal Quantity { get; set; }
        public string TransactionType { get; set; } = string.Empty; // GIRIS veya CIKIS
        public decimal UnitPrice { get; set; } = 0;
        public string? DocumentNo { get; set; }
        public string? Notes { get; set; }
    }
} 