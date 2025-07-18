namespace MiniERP.WinForms.DTOs
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal VatRate { get; set; }
        public decimal MinStockLevel { get; set; }
        public decimal MaxStockLevel { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal CurrentStock { get; set; }
        public decimal ReservedStock { get; set; }
        public decimal AvailableStock { get; set; }
    }

    public class CreateProductDto
    {
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? CategoryID { get; set; }
        public int UnitID { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal VatRate { get; set; } = 18;
        public decimal MinStockLevel { get; set; } = 0;
        public decimal MaxStockLevel { get; set; } = 0;
    }

    public class UpdateProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? CategoryID { get; set; }
        public int UnitID { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal VatRate { get; set; }
        public decimal MinStockLevel { get; set; }
        public decimal MaxStockLevel { get; set; }
        public bool IsActive { get; set; } = true;
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
        public string CategoryCode { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class UpdateProductCategoryDto
    {
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class UnitDto
    {
        public int UnitID { get; set; }
        public string UnitCode { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductCount { get; set; }
    }

    public class CreateUnitDto
    {
        public string UnitCode { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
    }

    public class UpdateUnitDto
    {
        public string UnitName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}


