namespace MiniERP.API.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public static ApiResponse<T> SuccessResult(T data, string message = "Operation successful")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> ErrorResult(string message, List<string>? errors = null)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = errors ?? new List<string>()
            };
        }
    }

    public class PagedResult<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }

        public PagedResult(List<T> data, int totalCount, int pageNumber, int pageSize)
        {
            Data = data;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            HasNext = PageNumber < TotalPages;
            HasPrevious = PageNumber > 1;
        }
    }

    public class PaginationParameters
    {
        private const int MaxPageSize = 100;
        private int _pageSize = 10;

        public int PageNumber { get; set; } = 1;
        
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string? SearchTerm { get; set; }
        public string? SortBy { get; set; }
        public string SortDirection { get; set; } = "asc";
        public string? FilterBy { get; set; }
        public string? FilterValue { get; set; }
    }

    public class RoleDto
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserCount { get; set; }
    }

    public class CreateRoleDto
    {
        public string RoleName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class UpdateRoleDto
    {
        public string RoleName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class DashboardDto
    {
        public DashboardSummaryDto Summary { get; set; } = new DashboardSummaryDto();
        public List<RecentTransactionDto> RecentTransactions { get; set; } = new List<RecentTransactionDto>();
        public List<CriticalStockDto> CriticalStocks { get; set; } = new List<CriticalStockDto>();
        public List<PendingInvoiceDto> PendingInvoices { get; set; } = new List<PendingInvoiceDto>();
        public List<TopCustomerDto> TopCustomers { get; set; } = new List<TopCustomerDto>();
        public List<TopProductDto> TopProducts { get; set; } = new List<TopProductDto>();
    }

    public class DashboardSummaryDto
    {
        public decimal TotalSales { get; set; }
        public decimal TotalPurchases { get; set; }
        public decimal TotalReceivables { get; set; }
        public decimal TotalPayables { get; set; }
        public int TotalProducts { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalSuppliers { get; set; }
        public int PendingInvoices { get; set; }
        public int CriticalStockItems { get; set; }
        public decimal NetProfit { get; set; }
        public decimal CashFlow { get; set; }
    }

    public class RecentTransactionDto
    {
        public int TransactionID { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string DocumentNo { get; set; } = string.Empty;
        public string PartyName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CriticalStockDto
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal CurrentStock { get; set; }
        public decimal MinStockLevel { get; set; }
        public string WarehouseName { get; set; } = string.Empty;
        public string StockStatus { get; set; } = string.Empty;
    }

    public class PendingInvoiceDto
    {
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public string InvoiceType { get; set; } = string.Empty;
        public string PartyName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int DaysOverdue { get; set; }
    }

    public class TopCustomerDto
    {
        public int CariID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public decimal TotalSales { get; set; }
        public int InvoiceCount { get; set; }
        public decimal AverageOrderValue { get; set; }
        public DateTime LastOrderDate { get; set; }
    }

    public class TopProductDto
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal TotalSold { get; set; }
        public decimal TotalRevenue { get; set; }
        public int OrderCount { get; set; }
        public decimal AveragePrice { get; set; }
    }

    public class ReportParametersDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? WarehouseID { get; set; }
        public int? CategoryID { get; set; }
        public int? CariID { get; set; }
        public string? ReportFormat { get; set; } = "JSON";
        public bool IncludeDetails { get; set; } = true;
        public string? GroupBy { get; set; }
        public string? SortBy { get; set; }
    }

    public class SystemSettingsDto
    {
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyAddress { get; set; } = string.Empty;
        public string CompanyPhone { get; set; } = string.Empty;
        public string CompanyEmail { get; set; } = string.Empty;
        public string TaxNo { get; set; } = string.Empty;
        public string Currency { get; set; } = "TRY";
        public string DateFormat { get; set; } = "dd/MM/yyyy";
        public string TimeFormat { get; set; } = "HH:mm";
        public int DefaultWarehouseID { get; set; }
        public decimal DefaultVatRate { get; set; } = 18;
        public bool AutoGenerateInvoiceNo { get; set; } = true;
        public bool EnableStockReservation { get; set; } = true;
        public bool RequireApprovalForInvoices { get; set; } = false;
    }
} 