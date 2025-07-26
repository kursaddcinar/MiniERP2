namespace MiniERP.WinForms.DTOs
{
    public class DashboardStatsDto
    {
        public int TotalProducts { get; set; }
        public int TotalSalesInvoices { get; set; }
        public int TotalPurchaseInvoices { get; set; }
        public int TotalCariAccounts { get; set; }
        public int ActiveCustomers { get; set; }
        public int ActiveSuppliers { get; set; }
        public int CriticalStockCount { get; set; }
        public int OutOfStockCount { get; set; }
        public int LowStockCount { get; set; }
    }

    public class DashboardCardDto
    {
        public string Title { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public Color Color { get; set; }
    }
}
