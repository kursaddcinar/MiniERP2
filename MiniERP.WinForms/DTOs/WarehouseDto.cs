namespace MiniERP.WinForms.DTOs
{
    public class WarehouseDto
    {
        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateWarehouseDto
    {
        public string WarehouseName { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateWarehouseDto
    {
        public string WarehouseName { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}


