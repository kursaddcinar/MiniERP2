namespace MiniERP.API.DTOs
{
    public class ReserveStockDto
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public decimal Quantity { get; set; }
    }
} 