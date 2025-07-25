using System.ComponentModel.DataAnnotations;

namespace MiniERP.Web.Models
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal VatRate { get; set; }
        public decimal StockQuantity { get; set; }
        public decimal MinStockLevel { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public int UnitID { get; set; }
    }

    public class CreateProductDto
    {
        [Required(ErrorMessage = "Ürün kodu gereklidir")]
        [Display(Name = "Ürün Kodu")]
        public string ProductCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ürün adı gereklidir")]
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Alış fiyatı gereklidir")]
        [Display(Name = "Alış Fiyatı")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Satış fiyatı gereklidir")]
        [Display(Name = "Satış Fiyatı")]
        public decimal SalePrice { get; set; }

        [Display(Name = "KDV Oranı")]
        public decimal VatRate { get; set; } = 18;

        [Display(Name = "Minimum Stok Seviyesi")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal MinStockLevel { get; set; }

        [Required(ErrorMessage = "Kategori seçimi gereklidir")]
        [Display(Name = "Kategori")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Birim seçimi gereklidir")]
        [Display(Name = "Birim")]
        public int UnitID { get; set; }
    }

    public class UpdateProductDto
    {
        [Required(ErrorMessage = "Ürün kodu gereklidir")]
        [Display(Name = "Ürün Kodu")]
        public string ProductCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ürün adı gereklidir")]
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Alış fiyatı gereklidir")]
        [Display(Name = "Alış Fiyatı")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Satış fiyatı gereklidir")]
        [Display(Name = "Satış Fiyatı")]
        public decimal SalePrice { get; set; }

        [Display(Name = "KDV Oranı")]
        public decimal VatRate { get; set; }

        [Display(Name = "Minimum Stok Seviyesi")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal MinStockLevel { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Kategori seçimi gereklidir")]
        [Display(Name = "Kategori")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Birim seçimi gereklidir")]
        [Display(Name = "Birim")]
        public int UnitID { get; set; }
    }

    public class ProductCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryCode { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductCount { get; set; }
    }

    public class CreateProductCategoryDto
    {
        [Required(ErrorMessage = "Kategori kodu gereklidir")]
        [Display(Name = "Kategori Kodu")]
        public string CategoryCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kategori adı gereklidir")]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
    }

    public class UpdateProductCategoryDto
    {
        [Required(ErrorMessage = "Kategori adı gereklidir")]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }

    public class UnitDto
    {
        public int UnitID { get; set; }
        public string UnitCode { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductCount { get; set; }
    }

    public class CreateUnitDto
    {
        [Required(ErrorMessage = "Birim kodu gereklidir")]
        [Display(Name = "Birim Kodu")]
        public string UnitCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Birim adı gereklidir")]
        [Display(Name = "Birim Adı")]
        public string UnitName { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
    }

    public class UpdateUnitDto
    {
        [Required(ErrorMessage = "Birim adı gereklidir")]
        [Display(Name = "Birim Adı")]
        public string UnitName { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }
} 