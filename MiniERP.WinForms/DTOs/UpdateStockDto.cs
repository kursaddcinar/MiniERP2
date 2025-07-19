namespace MiniERP.WinForms.DTOs
{
    public class DetailedUpdateStockDto
    {
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public decimal Quantity { get; set; }
        public string TransactionType { get; set; } = string.Empty; // API ile uyumlu: GIRIS veya CIKIS
        public decimal UnitPrice { get; set; } = 0;
        public string? DocumentNo { get; set; } // API ile uyumlu alan adı
        public string? Notes { get; set; } // API ile uyumlu alan adı
    }
}
