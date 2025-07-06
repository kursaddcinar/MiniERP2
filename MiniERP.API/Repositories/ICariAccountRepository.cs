using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public interface ICariAccountRepository : IGenericRepository<CariAccount>
    {
        Task<CariAccount?> GetByCodeAsync(string cariCode);
        Task<CariAccount?> GetCariWithTransactionsAsync(int cariId);
        Task<IEnumerable<CariAccount>> GetCustomersAsync();
        Task<IEnumerable<CariAccount>> GetSuppliersAsync();
        Task<IEnumerable<CariAccount>> GetActiveCariAccountsAsync();
        Task<bool> IsCariCodeUniqueAsync(string cariCode, int? excludeCariId = null);
        Task<IEnumerable<CariAccount>> SearchCariAccountsAsync(string searchTerm);
        Task<IEnumerable<CariAccount>> GetCariAccountsWithBalanceAsync(bool includeZeroBalance = false);
        Task<decimal> GetTotalReceivablesAsync();
        Task<decimal> GetTotalPayablesAsync();
        Task<IEnumerable<CariAccount>> GetTopCustomersAsync(int count, DateTime? fromDate = null, DateTime? toDate = null);
        Task<bool> UpdateBalanceAsync(int cariId, decimal amount, string transactionType);
    }
} 