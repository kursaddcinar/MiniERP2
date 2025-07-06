using MiniERP.WinForms.Models;

namespace MiniERP.WinForms.Services
{
    public class CariAccountService
    {
        private readonly ApiService _apiService;

        public CariAccountService(ApiService apiService)
        {
            _apiService = apiService;
        }

        #region CariAccount Operations

        /// <summary>
        /// Get paginated list of cari accounts
        /// </summary>
        public async Task<ApiResponse<PagedResult<CariAccountDto>>> GetCariAccountsAsync(int pageNumber = 1, int pageSize = 50, string? searchTerm = null, int? typeId = null)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";
            
            if (!string.IsNullOrEmpty(searchTerm))
                query += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";
            
            if (typeId.HasValue)
                query += $"&typeId={typeId}";

            return await _apiService.GetAsync<PagedResult<CariAccountDto>>($"/api/cariaccounts{query}");
        }

        /// <summary>
        /// Get cari account by ID
        /// </summary>
        public async Task<ApiResponse<CariAccountDto>> GetCariAccountByIdAsync(int id)
        {
            return await _apiService.GetAsync<CariAccountDto>($"/api/cariaccounts/{id}");
        }

        /// <summary>
        /// Get cari account by code
        /// </summary>
        public async Task<ApiResponse<CariAccountDto>> GetCariAccountByCodeAsync(string code)
        {
            return await _apiService.GetAsync<CariAccountDto>($"/api/cariaccounts/by-code/{Uri.EscapeDataString(code)}");
        }

        /// <summary>
        /// Create new cari account
        /// </summary>
        public async Task<ApiResponse<CariAccountDto>> CreateCariAccountAsync(CreateCariAccountDto createDto)
        {
            return await _apiService.PostAsync<CariAccountDto>("/api/cariaccounts", createDto);
        }

        /// <summary>
        /// Update existing cari account
        /// </summary>
        public async Task<ApiResponse<CariAccountDto>> UpdateCariAccountAsync(int id, UpdateCariAccountDto updateDto)
        {
            return await _apiService.PutAsync<CariAccountDto>($"/api/cariaccounts/{id}", updateDto);
        }

        /// <summary>
        /// Delete cari account
        /// </summary>
        public async Task<ApiResponse> DeleteCariAccountAsync(int id)
        {
            return await _apiService.DeleteAsync($"/api/cariaccounts/{id}");
        }

        /// <summary>
        /// Activate cari account
        /// </summary>
        public async Task<ApiResponse> ActivateCariAccountAsync(int id)
        {
            return await _apiService.PostAsync($"/api/cariaccounts/{id}/activate", new { });
        }

        /// <summary>
        /// Deactivate cari account
        /// </summary>
        public async Task<ApiResponse> DeactivateCariAccountAsync(int id)
        {
            return await _apiService.PostAsync($"/api/cariaccounts/{id}/deactivate", new { });
        }

        #endregion

        #region Customer Operations

        /// <summary>
        /// Get all customers
        /// </summary>
        public async Task<ApiResponse<List<CariAccountDto>>> GetCustomersAsync()
        {
            return await _apiService.GetAsync<List<CariAccountDto>>("/api/cariaccounts/customers");
        }

        /// <summary>
        /// Get paginated customers
        /// </summary>
        public async Task<ApiResponse<PagedResult<CariAccountDto>>> GetCustomersPagedAsync(int pageNumber = 1, int pageSize = 50, string? searchTerm = null)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}&typeId=1";
            
            if (!string.IsNullOrEmpty(searchTerm))
                query += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";

            return await _apiService.GetAsync<PagedResult<CariAccountDto>>($"/api/cariaccounts{query}");
        }

        /// <summary>
        /// Create new customer
        /// </summary>
        public async Task<ApiResponse<CariAccountDto>> CreateCustomerAsync(CreateCariAccountDto createDto)
        {
            createDto.TypeID = 1; // Customer type
            return await _apiService.PostAsync<CariAccountDto>("/api/cariaccounts", createDto);
        }

        #endregion

        #region Supplier Operations

        /// <summary>
        /// Get all suppliers
        /// </summary>
        public async Task<ApiResponse<List<CariAccountDto>>> GetSuppliersAsync()
        {
            return await _apiService.GetAsync<List<CariAccountDto>>("/api/cariaccounts/suppliers");
        }

        /// <summary>
        /// Get paginated suppliers
        /// </summary>
        public async Task<ApiResponse<PagedResult<CariAccountDto>>> GetSuppliersPagedAsync(int pageNumber = 1, int pageSize = 50, string? searchTerm = null)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}&typeId=2";
            
            if (!string.IsNullOrEmpty(searchTerm))
                query += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";

            return await _apiService.GetAsync<PagedResult<CariAccountDto>>($"/api/cariaccounts{query}");
        }

        /// <summary>
        /// Create new supplier
        /// </summary>
        public async Task<ApiResponse<CariAccountDto>> CreateSupplierAsync(CreateCariAccountDto createDto)
        {
            createDto.TypeID = 2; // Supplier type
            return await _apiService.PostAsync<CariAccountDto>("/api/cariaccounts", createDto);
        }

        #endregion

        #region Balance Operations

        /// <summary>
        /// Get cari balances
        /// </summary>
        public async Task<ApiResponse<List<CariBalanceDto>>> GetCariBalancesAsync(bool includeZeroBalance = false)
        {
            var query = $"?includeZeroBalance={includeZeroBalance}";
            return await _apiService.GetAsync<List<CariBalanceDto>>($"/api/cariaccounts/balances{query}");
        }

        /// <summary>
        /// Update cari balance
        /// </summary>
        public async Task<ApiResponse> UpdateCariBalanceAsync(int cariId, decimal amount, string transactionType)
        {
            var request = new { Amount = amount, TransactionType = transactionType };
            return await _apiService.PostAsync($"/api/cariaccounts/{cariId}/update-balance", request);
        }

        #endregion

        #region CariType Operations

        /// <summary>
        /// Get cari types
        /// </summary>
        public async Task<ApiResponse<PagedResult<CariTypeDto>>> GetCariTypesAsync(int pageNumber = 1, int pageSize = 50)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";
            return await _apiService.GetAsync<PagedResult<CariTypeDto>>($"/api/cariaccounts/types{query}");
        }

        /// <summary>
        /// Get cari type by ID
        /// </summary>
        public async Task<ApiResponse<CariTypeDto>> GetCariTypeByIdAsync(int id)
        {
            return await _apiService.GetAsync<CariTypeDto>($"/api/cariaccounts/types/{id}");
        }

        /// <summary>
        /// Create new cari type
        /// </summary>
        public async Task<ApiResponse<CariTypeDto>> CreateCariTypeAsync(CreateCariTypeDto createDto)
        {
            return await _apiService.PostAsync<CariTypeDto>("/api/cariaccounts/types", createDto);
        }

        /// <summary>
        /// Update cari type
        /// </summary>
        public async Task<ApiResponse<CariTypeDto>> UpdateCariTypeAsync(int id, UpdateCariTypeDto updateDto)
        {
            return await _apiService.PutAsync<CariTypeDto>($"/api/cariaccounts/types/{id}", updateDto);
        }

        /// <summary>
        /// Delete cari type
        /// </summary>
        public async Task<ApiResponse> DeleteCariTypeAsync(int id)
        {
            return await _apiService.DeleteAsync($"/api/cariaccounts/types/{id}");
        }

        #endregion

        #region Transaction Operations

        /// <summary>
        /// Get cari transactions
        /// </summary>
        public async Task<ApiResponse<PagedResult<CariTransactionDto>>> GetCariTransactionsAsync(int cariId, int pageNumber = 1, int pageSize = 50)
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";
            return await _apiService.GetAsync<PagedResult<CariTransactionDto>>($"/api/cariaccounts/{cariId}/transactions{query}");
        }

        /// <summary>
        /// Get cari statement
        /// </summary>
        public async Task<ApiResponse<CariStatementDto>> GetCariStatementAsync(int cariId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = "?";
            if (startDate.HasValue)
                query += $"startDate={startDate.Value:yyyy-MM-dd}&";
            if (endDate.HasValue)
                query += $"endDate={endDate.Value:yyyy-MM-dd}&";
            
            return await _apiService.GetAsync<CariStatementDto>($"/api/cariaccounts/{cariId}/statement{query}");
        }

        /// <summary>
        /// Create cari transaction
        /// </summary>
        public async Task<ApiResponse<CariTransactionDto>> CreateCariTransactionAsync(CreateCariTransactionDto createDto)
        {
            return await _apiService.PostAsync<CariTransactionDto>("/api/cariaccounts/transactions", createDto);
        }

        #endregion

        #region Report Operations

        /// <summary>
        /// Get total receivables
        /// </summary>
        public async Task<ApiResponse<decimal>> GetTotalReceivablesAsync()
        {
            return await _apiService.GetAsync<decimal>("/api/cariaccounts/reports/total-receivables");
        }

        /// <summary>
        /// Get total payables
        /// </summary>
        public async Task<ApiResponse<decimal>> GetTotalPayablesAsync()
        {
            return await _apiService.GetAsync<decimal>("/api/cariaccounts/reports/total-payables");
        }

        /// <summary>
        /// Get top customers
        /// </summary>
        public async Task<ApiResponse<List<CariAccountDto>>> GetTopCustomersAsync(int count = 10, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = $"?count={count}";
            if (fromDate.HasValue)
                query += $"&fromDate={fromDate.Value:yyyy-MM-dd}";
            if (toDate.HasValue)
                query += $"&toDate={toDate.Value:yyyy-MM-dd}";
            
            return await _apiService.GetAsync<List<CariAccountDto>>($"/api/cariaccounts/reports/top-customers{query}");
        }

        #endregion
    }

    // Additional DTOs for missing types
    public class CariBalanceDto
    {
        public int CariAccountID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string BalanceType { get; set; } = string.Empty;
        public DateTime LastTransactionDate { get; set; }
    }

    public class CariStatementDto
    {
        public int CariAccountID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public List<CariTransactionDto> Transactions { get; set; } = new List<CariTransactionDto>();
    }

    public class CreateCariTypeDto
    {
        public string TypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class UpdateCariTypeDto
    {
        public string TypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
} 