using MiniERP.API.DTOs;

namespace MiniERP.API.Services
{
    public interface ICariAccountService
    {
        // CariAccount operations
        Task<ApiResponse<PagedResult<CariAccountDto>>> GetCariAccountsAsync(PaginationParameters parameters, string? searchTerm = null, int? typeId = null);
        Task<ApiResponse<CariAccountDto>> GetCariAccountByIdAsync(int id);
        Task<ApiResponse<CariAccountDto>> GetCariAccountByCodeAsync(string code);
        Task<ApiResponse<CariAccountDto>> CreateCariAccountAsync(CreateCariAccountDto createCariAccountDto);
        Task<ApiResponse<CariAccountDto>> UpdateCariAccountAsync(int id, UpdateCariAccountDto updateCariAccountDto);
        Task<ApiResponse<bool>> DeleteCariAccountAsync(int id);
        Task<ApiResponse<bool>> ActivateCariAccountAsync(int id);
        Task<ApiResponse<bool>> DeactivateCariAccountAsync(int id);
        Task<ApiResponse<List<CariAccountDto>>> GetCustomersAsync();
        Task<ApiResponse<List<CariAccountDto>>> GetSuppliersAsync();
        Task<ApiResponse<List<CariBalanceDto>>> GetCariBalancesAsync(bool includeZeroBalance = false);

        // CariType operations
        Task<ApiResponse<PagedResult<CariTypeDto>>> GetCariTypesAsync(PaginationParameters parameters);
        Task<ApiResponse<CariTypeDto>> GetCariTypeByIdAsync(int id);
        Task<ApiResponse<CariTypeDto>> CreateCariTypeAsync(CreateCariTypeDto createCariTypeDto);
        Task<ApiResponse<CariTypeDto>> UpdateCariTypeAsync(int id, UpdateCariTypeDto updateCariTypeDto);
        Task<ApiResponse<bool>> DeleteCariTypeAsync(int id);

        // CariTransaction operations
        Task<ApiResponse<PagedResult<CariTransactionDto>>> GetCariTransactionsAsync(int cariId, PaginationParameters parameters);
        Task<ApiResponse<CariTransactionDto>> CreateCariTransactionAsync(CreateCariTransactionDto createTransactionDto);
        Task<ApiResponse<bool>> UpdateCariBalanceAsync(int cariId, decimal amount, string transactionType);
        Task<ApiResponse<CariStatementDto>> GetCariStatementAsync(int cariId, DateTime? startDate = null, DateTime? endDate = null);

        // Reports and analytics
        Task<ApiResponse<decimal>> GetTotalReceivablesAsync();
        Task<ApiResponse<decimal>> GetTotalPayablesAsync();
        Task<ApiResponse<List<CariAccountDto>>> GetTopCustomersAsync(int count, DateTime? fromDate = null, DateTime? toDate = null);
    }
} 