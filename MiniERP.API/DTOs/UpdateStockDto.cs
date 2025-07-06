namespace MiniERP.API.DTOs
{
    public class UpdateStockDto
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public decimal Quantity { get; set; }
        public string TransactionType { get; set; } = string.Empty; // GIRIS veya CIKIS
    }
} 