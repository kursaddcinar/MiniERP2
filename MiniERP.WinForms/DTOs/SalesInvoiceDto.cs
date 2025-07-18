namespace MiniERP.WinForms.DTOs
{
    public class SalesInvoiceDto
    {
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public int CariID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public int WarehouseID { get; set; }
        public string WarehouseName { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal VatAmount { get; set; }
        public decimal Total { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public List<SalesInvoiceDetailDto> Details { get; set; } = new List<SalesInvoiceDetailDto>();
    }

    public class CreateSalesInvoiceDto
    {
        public string InvoiceNo { get; set; } = string.Empty;
        public int CariID { get; set; }
        public int WarehouseID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Description { get; set; }
        public List<CreateSalesInvoiceDetailDto> Details { get; set; } = new List<CreateSalesInvoiceDetailDto>();
    }

    public class UpdateSalesInvoiceDto
    {
        public int CariID { get; set; }
        public int WarehouseID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Description { get; set; }
        public List<CreateSalesInvoiceDetailDto> Details { get; set; } = new List<CreateSalesInvoiceDetailDto>();
    }

    public class SalesInvoiceDetailDto
    {
        public int DetailID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VatRate { get; set; }
        public decimal SubTotal { get; set; } // Miktar * Birim Fiyat
        public decimal VatAmount { get; set; } // KDV Tutarı
        public decimal LineTotal { get; set; } // Net Toplam
        public decimal NetTotal { get; set; }
        public string? Description { get; set; }
    }

    public class CreateSalesInvoiceDetailDto
    {
        public int ProductID { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VatRate { get; set; }
        public string? Description { get; set; }
    }

    public class InvoiceSummaryDto
    {
        public int TotalInvoices { get; set; }
        public decimal TotalAmount { get; set; }
        public int DraftInvoices { get; set; }
        public int ApprovedInvoices { get; set; }
        public decimal DraftTotal { get; set; }
        public decimal ApprovedTotal { get; set; }
    }

    public class InvoiceApprovalDto
    {
        public string ApprovalNote { get; set; } = string.Empty;
    }

    public class InvoiceCancellationDto
    {
        public string Reason { get; set; } = string.Empty;
    }
}


