using MiniERP.WinForms.Models;

namespace MiniERP.WinForms.Services
{
    public class PurchaseService
    {
        private readonly ApiService _apiService;

        public PurchaseService(ApiService apiService)
        {
            _apiService = apiService;
        }

        // Purchase Invoices
        public async Task<ApiResponse<PagedResult<PurchaseInvoiceDto>>> GetPurchaseInvoicesAsync(int pageNumber = 1, int pageSize = 100, string? searchTerm = null)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";
            }

            return await _apiService.GetAsync<PagedResult<PurchaseInvoiceDto>>($"/api/purchaseinvoices{query}");
        }

        public async Task<ApiResponse<PurchaseInvoiceDto>> GetPurchaseInvoiceByIdAsync(int id)
        {
            return await _apiService.GetAsync<PurchaseInvoiceDto>($"/api/purchaseinvoices/{id}");
        }

        public async Task<ApiResponse<List<PurchaseInvoiceDto>>> GetPurchaseInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var query = $"?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";
            return await _apiService.GetAsync<List<PurchaseInvoiceDto>>($"/api/purchaseinvoices/by-date-range{query}");
        }

        public async Task<ApiResponse<List<PurchaseInvoiceDto>>> GetPurchaseInvoicesByCariAsync(int cariAccountId)
        {
            return await _apiService.GetAsync<List<PurchaseInvoiceDto>>($"/api/purchaseinvoices/by-cari/{cariAccountId}");
        }

        public async Task<ApiResponse<List<PurchaseInvoiceDto>>> GetPurchaseInvoicesByStatusAsync(string status)
        {
            return await _apiService.GetAsync<List<PurchaseInvoiceDto>>($"/api/purchaseinvoices/by-status/{status}");
        }

        public async Task<ApiResponse<PurchaseInvoiceDto>> CreatePurchaseInvoiceAsync(CreatePurchaseInvoiceDto createDto)
        {
            return await _apiService.PostAsync<PurchaseInvoiceDto>("/api/purchaseinvoices", createDto);
        }

        public async Task<ApiResponse<PurchaseInvoiceDto>> UpdatePurchaseInvoiceAsync(int id, UpdatePurchaseInvoiceDto updateDto)
        {
            return await _apiService.PutAsync<PurchaseInvoiceDto>($"/api/purchaseinvoices/{id}", updateDto);
        }

        public async Task<ApiResponse> DeletePurchaseInvoiceAsync(int id)
        {
            return await _apiService.DeleteAsync($"/api/purchaseinvoices/{id}");
        }

        public async Task<ApiResponse<PurchaseInvoiceDto>> ApprovePurchaseInvoiceAsync(int id)
        {
            return await _apiService.PostAsync<PurchaseInvoiceDto>($"/api/purchaseinvoices/{id}/approve", new { });
        }

        public async Task<ApiResponse<PurchaseInvoiceDto>> CancelPurchaseInvoiceAsync(int id, InvoiceCancellationDto cancellationDto)
        {
            return await _apiService.PostAsync<PurchaseInvoiceDto>($"/api/purchaseinvoices/{id}/cancel", cancellationDto);
        }

        // Suppliers (Cari Accounts)
        public async Task<ApiResponse<PagedResult<CariAccountDto>>> GetSuppliersAsync(int pageNumber = 1, int pageSize = 100, string? searchTerm = null)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";
            }

            return await _apiService.GetAsync<PagedResult<CariAccountDto>>($"/api/cariaccounts{query}");
        }

        public async Task<ApiResponse<List<CariAccountDto>>> GetActiveSuppliersAsync()
        {
            return await _apiService.GetAsync<List<CariAccountDto>>("/api/cariaccounts/suppliers");
        }

        public async Task<ApiResponse<CariAccountDto>> GetSupplierByIdAsync(int id)
        {
            return await _apiService.GetAsync<CariAccountDto>($"/api/cariaccounts/{id}");
        }

        public async Task<ApiResponse<CariAccountDto>> CreateSupplierAsync(CreateCariAccountDto createDto)
        {
            // Set type to supplier (assuming TypeID 2 is for suppliers)
            createDto.TypeID = 2;
            return await _apiService.PostAsync<CariAccountDto>("/api/cariaccounts", createDto);
        }

        public async Task<ApiResponse<CariAccountDto>> UpdateSupplierAsync(int id, UpdateCariAccountDto updateDto)
        {
            return await _apiService.PutAsync<CariAccountDto>($"/api/cariaccounts/{id}", updateDto);
        }

        public async Task<ApiResponse> DeleteSupplierAsync(int id)
        {
            return await _apiService.DeleteAsync($"/api/cariaccounts/{id}");
        }

        // Supplier Transactions
        public async Task<ApiResponse<List<CariTransactionDto>>> GetSupplierTransactionsAsync(int cariAccountId)
        {
            return await _apiService.GetAsync<List<CariTransactionDto>>($"/api/cariaccounts/{cariAccountId}/transactions");
        }

        public async Task<ApiResponse<CariTransactionDto>> CreateSupplierTransactionAsync(CreateCariTransactionDto createDto)
        {
            return await _apiService.PostAsync<CariTransactionDto>("/api/cariaccounts/transactions", createDto);
        }

        // Payments
        public async Task<ApiResponse<List<object>>> GetPaymentsAsync(int? supplierId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = "?";
            if (supplierId.HasValue)
                query += $"supplierId={supplierId}&";
            if (startDate.HasValue)
                query += $"startDate={startDate:yyyy-MM-dd}&";
            if (endDate.HasValue)
                query += $"endDate={endDate:yyyy-MM-dd}&";

            query = query.TrimEnd('&', '?');
            return await _apiService.GetAsync<List<object>>($"/api/purchaseinvoices/payments{query}");
        }

        public async Task<ApiResponse<object>> CreatePaymentAsync(object paymentDto)
        {
            return await _apiService.PostAsync<object>("/api/purchaseinvoices/payments", paymentDto);
        }

        // Reports
        public async Task<ApiResponse<object>> GetPurchaseReportAsync(DateTime? startDate = null, DateTime? endDate = null, int? cariAccountId = null)
        {
            var query = "?";
            if (startDate.HasValue)
                query += $"startDate={startDate:yyyy-MM-dd}&";
            if (endDate.HasValue)
                query += $"endDate={endDate:yyyy-MM-dd}&";
            if (cariAccountId.HasValue)
                query += $"cariAccountId={cariAccountId}&";

            query = query.TrimEnd('&', '?');
            return await _apiService.GetAsync<object>($"/api/purchaseinvoices/summary{query}");
        }

        public async Task<ApiResponse<object>> GetTopSuppliersReportAsync(int count = 10, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = $"?count={count}";
            if (startDate.HasValue)
                query += $"&startDate={startDate:yyyy-MM-dd}";
            if (endDate.HasValue)
                query += $"&endDate={endDate:yyyy-MM-dd}";

            return await _apiService.GetAsync<object>($"/api/cariaccounts/reports/top-suppliers{query}");
        }

        public async Task<ApiResponse<object>> GetPurchaseAnalyticsAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = "?";
            if (startDate.HasValue)
                query += $"startDate={startDate:yyyy-MM-dd}&";
            if (endDate.HasValue)
                query += $"endDate={endDate:yyyy-MM-dd}&";

            query = query.TrimEnd('&', '?');
            return await _apiService.GetAsync<object>($"/api/purchaseinvoices/summary{query}");
        }

        public async Task<ApiResponse<object>> GetPayableReportAsync(DateTime? asOfDate = null)
        {
            var query = asOfDate.HasValue ? $"?asOfDate={asOfDate:yyyy-MM-dd}" : "";
            return await _apiService.GetAsync<object>($"/api/purchaseinvoices/payables{query}");
        }
    }
} 