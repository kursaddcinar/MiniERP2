using System.ComponentModel.DataAnnotations;

namespace MiniERP.Web.Models
{
    #region Sales Invoice Models

    public class SalesInvoiceDto
    {
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public int CariID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
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
        [Required(ErrorMessage = "Fatura numarası gereklidir")]
        [Display(Name = "Fatura No")]
        public string InvoiceNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cari seçimi gereklidir")]
        [Display(Name = "Cari")]
        public int CariID { get; set; }

        [Required(ErrorMessage = "Depo seçimi gereklidir")]
        [Display(Name = "Depo")]
        public int WarehouseID { get; set; }

        [Required(ErrorMessage = "Fatura tarihi gereklidir")]
        [Display(Name = "Fatura Tarihi")]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        [Display(Name = "Vade Tarihi")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Durum")]
        public string Status { get; set; } = "DRAFT";

        [Display(Name = "Ara Toplam")]
        public decimal SubTotal { get; set; }

        [Display(Name = "KDV Tutarı")]
        public decimal VatAmount { get; set; }

        [Display(Name = "Genel Toplam")]
        public decimal Total { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        public List<CreateSalesInvoiceDetailDto> Details { get; set; } = new List<CreateSalesInvoiceDetailDto>();
    }

    public class UpdateSalesInvoiceDto
    {
        [Required(ErrorMessage = "Fatura numarası gereklidir")]
        [Display(Name = "Fatura No")]
        public string InvoiceNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cari seçimi gereklidir")]
        [Display(Name = "Cari")]
        public int CariID { get; set; }

        [Required(ErrorMessage = "Depo seçimi gereklidir")]
        [Display(Name = "Depo")]
        public int WarehouseID { get; set; }

        [Required(ErrorMessage = "Fatura tarihi gereklidir")]
        [Display(Name = "Fatura Tarihi")]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Vade Tarihi")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Durum")]
        public string Status { get; set; } = "DRAFT";

        [Display(Name = "Ara Toplam")]
        public decimal SubTotal { get; set; }

        [Display(Name = "KDV Tutarı")]
        public decimal VatAmount { get; set; }

        [Display(Name = "Genel Toplam")]
        public decimal Total { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        public List<SalesInvoiceDetailDto> Details { get; set; } = new List<SalesInvoiceDetailDto>();
    }

    public class SalesInvoiceDetailDto
    {
        public int DetailID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VatRate { get; set; }
        public decimal LineTotal { get; set; }
        public decimal VatAmount { get; set; }
        public decimal NetTotal { get; set; }
        public string? Description { get; set; }
    }

    public class CreateSalesInvoiceDetailDto
    {
        [Required(ErrorMessage = "Ürün seçimi gereklidir")]
        [Display(Name = "Ürün")]
        public int ProductID { get; set; }

        [Display(Name = "Ürün Kodu")]
        public string ProductCode { get; set; } = string.Empty;

        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "Birim")]
        public string UnitName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Miktar gereklidir")]
        [Display(Name = "Miktar")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Birim fiyat gereklidir")]
        [Display(Name = "Birim Fiyat")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "KDV Oranı")]
        public decimal VatRate { get; set; } = 18;

        [Display(Name = "Satır Toplam")]
        public decimal LineTotal { get; set; }

        [Display(Name = "KDV Tutarı")]
        public decimal VatAmount { get; set; }

        [Display(Name = "Net Toplam")]
        public decimal NetTotal { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
    }

    #endregion

    #region Purchase Invoice Models

    public class PurchaseInvoiceDto
    {
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public int CariID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
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
        public List<PurchaseInvoiceDetailDto> Details { get; set; } = new List<PurchaseInvoiceDetailDto>();
    }

    public class CreatePurchaseInvoiceDto
    {
        [Required(ErrorMessage = "Fatura numarası gereklidir")]
        [Display(Name = "Fatura No")]
        public string InvoiceNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cari seçimi gereklidir")]
        [Display(Name = "Cari")]
        public int CariID { get; set; }

        [Required(ErrorMessage = "Depo seçimi gereklidir")]
        [Display(Name = "Depo")]
        public int WarehouseID { get; set; }

        [Required(ErrorMessage = "Fatura tarihi gereklidir")]
        [Display(Name = "Fatura Tarihi")]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        [Display(Name = "Vade Tarihi")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Durum")]
        public string Status { get; set; } = "DRAFT";

        [Display(Name = "Ara Toplam")]
        public decimal SubTotal { get; set; }

        [Display(Name = "KDV Tutarı")]
        public decimal VatAmount { get; set; }

        [Display(Name = "Genel Toplam")]
        public decimal Total { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        public List<CreatePurchaseInvoiceDetailDto> Details { get; set; } = new List<CreatePurchaseInvoiceDetailDto>();
    }

    public class UpdatePurchaseInvoiceDto
    {
        [Required(ErrorMessage = "Fatura numarası gereklidir")]
        [Display(Name = "Fatura No")]
        public string InvoiceNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cari seçimi gereklidir")]
        [Display(Name = "Cari")]
        public int CariID { get; set; }

        [Required(ErrorMessage = "Depo seçimi gereklidir")]
        [Display(Name = "Depo")]
        public int WarehouseID { get; set; }

        [Required(ErrorMessage = "Fatura tarihi gereklidir")]
        [Display(Name = "Fatura Tarihi")]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Vade Tarihi")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Durum")]
        public string Status { get; set; } = "DRAFT";

        [Display(Name = "Ara Toplam")]
        public decimal SubTotal { get; set; }

        [Display(Name = "KDV Tutarı")]
        public decimal VatAmount { get; set; }

        [Display(Name = "Genel Toplam")]
        public decimal Total { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        public List<PurchaseInvoiceDetailDto> Details { get; set; } = new List<PurchaseInvoiceDetailDto>();
    }

    public class PurchaseInvoiceDetailDto
    {
        public int DetailID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VatRate { get; set; }
        public decimal LineTotal { get; set; }
        public decimal VatAmount { get; set; }
        public decimal NetTotal { get; set; }
        public string? Description { get; set; }
    }

    public class CreatePurchaseInvoiceDetailDto
    {
        [Required(ErrorMessage = "Ürün seçimi gereklidir")]
        [Display(Name = "Ürün")]
        public int ProductID { get; set; }

        [Display(Name = "Ürün Kodu")]
        public string ProductCode { get; set; } = string.Empty;

        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "Birim")]
        public string UnitName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Miktar gereklidir")]
        [Display(Name = "Miktar")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Birim fiyat gereklidir")]
        [Display(Name = "Birim Fiyat")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "KDV Oranı")]
        public decimal VatRate { get; set; } = 18;

        [Display(Name = "Satır Toplam")]
        public decimal LineTotal { get; set; }

        [Display(Name = "KDV Tutarı")]
        public decimal VatAmount { get; set; }

        [Display(Name = "Net Toplam")]
        public decimal NetTotal { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
    }

    #endregion

    #region Common Invoice Models

    public class InvoiceApprovalDto
    {
        public int InvoiceID { get; set; }
        public string? ApprovalNote { get; set; }
    }

    public class InvoiceSummaryDto
    {
        public int TotalInvoices { get; set; }
        public decimal TotalAmount { get; set; }
        public int DraftInvoices { get; set; }
        public int ApprovedInvoices { get; set; }
        public int CancelledInvoices { get; set; }
        public decimal DraftAmount { get; set; }
        public decimal ApprovedAmount { get; set; }
    }

    public class InvoiceCancellationDto
    {
        [Required(ErrorMessage = "İptal nedeni gereklidir")]
        [Display(Name = "İptal Nedeni")]
        public string Reason { get; set; } = string.Empty;
    }

    #endregion
} 