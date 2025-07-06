using System.ComponentModel.DataAnnotations;

namespace MiniERP.Web.Models
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
        
        // Additional properties for view requirements
        public decimal MinimumStock => MinStockLevel; // Alias for MinStockLevel
        public decimal MaximumStock => MaxStockLevel; // Alias for MaxStockLevel
        public string CategoryName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime LastUpdateDate { get; set; }
        public List<StockTransactionDto> RecentTransactions { get; set; } = new List<StockTransactionDto>();
        
        // Additional properties for report compatibility
        public decimal UnitPrice { get; set; } = 0;
        public decimal TotalValue => CurrentStock * UnitPrice;
    }

    public class CreateStockCardDto
    {
        [Required(ErrorMessage = "Ürün seçimi gereklidir")]
        [Display(Name = "Ürün")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Depo seçimi gereklidir")]
        [Display(Name = "Depo")]
        public int WarehouseID { get; set; }

        [Display(Name = "Mevcut Stok")]
        public decimal CurrentStock { get; set; } = 0;

        [Display(Name = "Rezerve Stok")]
        public decimal ReservedStock { get; set; } = 0;

        [Display(Name = "Minimum Stok")]
        public decimal MinStockLevel { get; set; } = 0;

        [Display(Name = "Maksimum Stok")]
        public decimal MaxStockLevel { get; set; } = 0;

        [Display(Name = "Kategori")]
        public string CategoryName { get; set; } = string.Empty;

        [Display(Name = "Lokasyon")]
        public string Location { get; set; } = string.Empty;
    }

    public class UpdateStockCardDto
    {
        [Required(ErrorMessage = "Ürün ID gereklidir")]
        [Display(Name = "Ürün ID")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Depo ID gereklidir")]
        [Display(Name = "Depo ID")]
        public int WarehouseID { get; set; }

        [Required(ErrorMessage = "Mevcut stok gereklidir")]
        [Display(Name = "Mevcut Stok")]
        public decimal CurrentStock { get; set; }

        [Display(Name = "Rezerve Stok")]
        public decimal ReservedStock { get; set; }

        [Display(Name = "Minimum Stok")]
        public decimal MinStockLevel { get; set; }

        [Display(Name = "Maksimum Stok")]
        public decimal MaxStockLevel { get; set; }

        [Display(Name = "Kategori")]
        public string CategoryName { get; set; } = string.Empty;

        [Display(Name = "Lokasyon")]
        public string Location { get; set; } = string.Empty;

        [Display(Name = "Son Güncelleme")]
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;

        [Display(Name = "Notlar")]
        public string Notes { get; set; } = string.Empty;

        // Additional properties for view requirements
        public decimal MinimumStock => MinStockLevel; // Alias for MinStockLevel
        public decimal MaximumStock => MaxStockLevel; // Alias for MaxStockLevel
        public decimal ReorderLevel { get; set; } = 0;
        public decimal ReorderQuantity { get; set; } = 0;
        public bool IsActive { get; set; } = true;
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
        
        // Additional properties for view requirements
        public string DocumentNumber => DocumentNo ?? string.Empty; // Alias for DocumentNo
        public decimal RemainingStock { get; set; } = 0; // Remaining stock after transaction
    }

    public class CreateStockTransactionDto
    {
        [Required(ErrorMessage = "Ürün seçimi gereklidir")]
        [Display(Name = "Ürün")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Depo seçimi gereklidir")]
        [Display(Name = "Depo")]
        public int WarehouseID { get; set; }

        [Required(ErrorMessage = "İşlem tarihi gereklidir")]
        [Display(Name = "İşlem Tarihi")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "İşlem türü gereklidir")]
        [Display(Name = "İşlem Türü")]
        public string TransactionType { get; set; } = string.Empty; // GIRIS, CIKIS

        [Required(ErrorMessage = "Miktar gereklidir")]
        [Display(Name = "Miktar")]
        public decimal Quantity { get; set; }

        [Display(Name = "Birim Fiyat")]
        public decimal UnitPrice { get; set; } = 0;

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Belge Türü")]
        public string? DocumentType { get; set; }

        [Display(Name = "Belge No")]
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
        [Required(ErrorMessage = "Ürün seçimi gereklidir")]
        [Display(Name = "Ürün")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Kaynak depo seçimi gereklidir")]
        [Display(Name = "Kaynak Depo")]
        public int FromWarehouseID { get; set; }

        [Required(ErrorMessage = "Hedef depo seçimi gereklidir")]
        [Display(Name = "Hedef Depo")]
        public int ToWarehouseID { get; set; }

        [Required(ErrorMessage = "Miktar gereklidir")]
        [Display(Name = "Miktar")]
        public decimal Quantity { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Transfer tarihi gereklidir")]
        [Display(Name = "Transfer Tarihi")]
        public DateTime MovementDate { get; set; } = DateTime.Now;

        [Display(Name = "Notlar")]
        public string? Notes { get; set; }
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

        // Aliases for view compatibility
        public int CriticalProducts => CriticalStockProducts;
        public List<StockCardDto> StockItems => StockCards;
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
        [Required(ErrorMessage = "Depo kodu gereklidir")]
        [Display(Name = "Depo Kodu")]
        public string WarehouseCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Depo adı gereklidir")]
        [Display(Name = "Depo Adı")]
        public string WarehouseName { get; set; } = string.Empty;

        [Display(Name = "Adres")]
        public string? Address { get; set; }

        [Display(Name = "Şehir")]
        public string? City { get; set; }

        [Display(Name = "Sorumlu Kişi")]
        public string? ResponsiblePerson { get; set; }
    }

    public class UpdateWarehouseDto
    {
        [Required(ErrorMessage = "Depo adı gereklidir")]
        [Display(Name = "Depo Adı")]
        public string WarehouseName { get; set; } = string.Empty;

        [Display(Name = "Adres")]
        public string? Address { get; set; }

        [Display(Name = "Şehir")]
        public string? City { get; set; }

        [Display(Name = "Sorumlu Kişi")]
        public string? ResponsiblePerson { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }

    public class ReserveStockDto
    {
        [Required(ErrorMessage = "Ürün seçimi gereklidir")]
        [Display(Name = "Ürün")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Depo seçimi gereklidir")]
        [Display(Name = "Depo")]
        public int WarehouseID { get; set; }

        [Required(ErrorMessage = "Miktar gereklidir")]
        [Display(Name = "Miktar")]
        public decimal Quantity { get; set; }
    }

    public class UpdateStockDto
    {
        [Required(ErrorMessage = "Ürün seçimi gereklidir")]
        [Display(Name = "Ürün")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Depo seçimi gereklidir")]
        [Display(Name = "Depo")]
        public int WarehouseID { get; set; }

        [Required(ErrorMessage = "Miktar gereklidir")]
        [Display(Name = "Miktar")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "İşlem türü gereklidir")]
        [Display(Name = "İşlem Türü")]
        public string TransactionType { get; set; } = string.Empty; // GIRIS veya CIKIS

        [Display(Name = "Birim Fiyat")]
        public decimal UnitPrice { get; set; } = 0;

        [Display(Name = "Belge No")]
        public string? DocumentNo { get; set; }

        [Display(Name = "Açıklama")]
        public string? Notes { get; set; }
    }
} 