using MiniERP.WinForms.Models;

namespace MiniERP.WinForms.Services
{
    public class SalesService
    {
        private readonly ApiService _apiService;

        public SalesService(ApiService apiService)
        {
            _apiService = apiService;
        }

        // Sales Invoices
        public async Task<ApiResponse<PagedResult<SalesInvoiceDto>>> GetSalesInvoicesAsync(int pageNumber = 1, int pageSize = 100, string? searchTerm = null)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";
            }

            return await _apiService.GetAsync<PagedResult<SalesInvoiceDto>>($"/api/salesinvoices{query}");
        }

        public async Task<ApiResponse<SalesInvoiceDto>> GetSalesInvoiceByIdAsync(int id)
        {
            return await _apiService.GetAsync<SalesInvoiceDto>($"/api/salesinvoices/{id}");
        }

        public async Task<ApiResponse<List<SalesInvoiceDto>>> GetSalesInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var query = $"?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";
            return await _apiService.GetAsync<List<SalesInvoiceDto>>($"/api/salesinvoices/by-date-range{query}");
        }

        public async Task<ApiResponse<List<SalesInvoiceDto>>> GetSalesInvoicesByCariAsync(int cariAccountId)
        {
            return await _apiService.GetAsync<List<SalesInvoiceDto>>($"/api/salesinvoices/by-cari/{cariAccountId}");
        }

        public async Task<ApiResponse<List<SalesInvoiceDto>>> GetSalesInvoicesByStatusAsync(string status)
        {
            return await _apiService.GetAsync<List<SalesInvoiceDto>>($"/api/salesinvoices/by-status/{status}");
        }

        public async Task<ApiResponse<SalesInvoiceDto>> CreateSalesInvoiceAsync(CreateSalesInvoiceDto createDto)
        {
            return await _apiService.PostAsync<SalesInvoiceDto>("/api/salesinvoices", createDto);
        }

        public async Task<ApiResponse<SalesInvoiceDto>> UpdateSalesInvoiceAsync(int id, UpdateSalesInvoiceDto updateDto)
        {
            return await _apiService.PutAsync<SalesInvoiceDto>($"/api/salesinvoices/{id}", updateDto);
        }

        public async Task<ApiResponse> DeleteSalesInvoiceAsync(int id)
        {
            return await _apiService.DeleteAsync($"/api/salesinvoices/{id}");
        }

        public async Task<ApiResponse<SalesInvoiceDto>> ApproveSalesInvoiceAsync(int id)
        {
            return await _apiService.PostAsync<SalesInvoiceDto>($"/api/salesinvoices/{id}/approve", new { });
        }

        public async Task<ApiResponse<SalesInvoiceDto>> CancelSalesInvoiceAsync(int id, InvoiceCancellationDto cancellationDto)
        {
            return await _apiService.PostAsync<SalesInvoiceDto>($"/api/salesinvoices/{id}/cancel", cancellationDto);
        }

        // Cari Accounts (Customer management)
        public async Task<ApiResponse<PagedResult<CariAccountDto>>> GetCustomersAsync(int pageNumber = 1, int pageSize = 100, string? searchTerm = null)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";
            }

            return await _apiService.GetAsync<PagedResult<CariAccountDto>>($"/api/cariaccounts{query}");
        }

        public async Task<ApiResponse<List<CariAccountDto>>> GetActiveCustomersAsync()
        {
            return await _apiService.GetAsync<List<CariAccountDto>>("/api/cariaccounts/customers");
        }

        public async Task<ApiResponse<CariAccountDto>> GetCustomerByIdAsync(int id)
        {
            return await _apiService.GetAsync<CariAccountDto>($"/api/cariaccounts/{id}");
        }

        public async Task<ApiResponse<CariAccountDto>> CreateCustomerAsync(CreateCariAccountDto createDto)
        {
            // Set type to customer (assuming TypeID 1 is for customers)
            createDto.TypeID = 1;
            return await _apiService.PostAsync<CariAccountDto>("/api/cariaccounts", createDto);
        }

        public async Task<ApiResponse<CariAccountDto>> UpdateCustomerAsync(int id, UpdateCariAccountDto updateDto)
        {
            return await _apiService.PutAsync<CariAccountDto>($"/api/cariaccounts/{id}", updateDto);
        }

        public async Task<ApiResponse> DeleteCustomerAsync(int id)
        {
            return await _apiService.DeleteAsync($"/api/cariaccounts/{id}");
        }

        // Customer Transactions
        public async Task<ApiResponse<List<CariTransactionDto>>> GetCustomerTransactionsAsync(int cariAccountId)
        {
            return await _apiService.GetAsync<List<CariTransactionDto>>($"/api/cariaccounts/{cariAccountId}/transactions");
        }

        public async Task<ApiResponse<CariTransactionDto>> CreateCustomerTransactionAsync(CreateCariTransactionDto createDto)
        {
            return await _apiService.PostAsync<CariTransactionDto>("/api/cariaccounts/transactions", createDto);
        }

        // Reports
        public async Task<ApiResponse<object>> GetSalesReportAsync(DateTime? startDate = null, DateTime? endDate = null, int? cariAccountId = null)
        {
            var query = "?";
            if (startDate.HasValue)
                query += $"startDate={startDate:yyyy-MM-dd}&";
            if (endDate.HasValue)
                query += $"endDate={endDate:yyyy-MM-dd}&";
            if (cariAccountId.HasValue)
                query += $"cariAccountId={cariAccountId}&";

            query = query.TrimEnd('&', '?');
            return await _apiService.GetAsync<object>($"/api/salesinvoices/summary{query}");
        }

        public async Task<ApiResponse<object>> GetTopCustomersReportAsync(int count = 10, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = $"?count={count}";
            if (startDate.HasValue)
                query += $"&startDate={startDate:yyyy-MM-dd}";
            if (endDate.HasValue)
                query += $"&endDate={endDate:yyyy-MM-dd}";

            return await _apiService.GetAsync<object>($"/api/cariaccounts/reports/top-customers{query}");
        }

        public async Task<ApiResponse<object>> GetSalesAnalyticsAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = "?";
            if (startDate.HasValue)
                query += $"startDate={startDate:yyyy-MM-dd}&";
            if (endDate.HasValue)
                query += $"endDate={endDate:yyyy-MM-dd}&";

            query = query.TrimEnd('&', '?');
            return await _apiService.GetAsync<object>($"/api/salesinvoices/summary{query}");
        }
    }
} 