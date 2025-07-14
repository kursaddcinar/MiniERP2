using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetPaymentsByCariIdAsync(int cariId);
        Task<IEnumerable<Payment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Payment>> GetPaymentsByPaymentTypeAsync(int paymentTypeId);
        Task<IEnumerable<Payment>> GetPaymentsByStatusAsync(string status);
        Task<Payment?> GetPaymentByPaymentNoAsync(string paymentNo);
        Task<decimal> GetTotalPaymentAmountAsync(int cariId);
        Task<decimal> GetTotalPaymentAmountByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Payment>> GetRecentPaymentsAsync(int count = 10);
        Task<bool> IsPaymentNoUniqueAsync(string paymentNo, int? excludeId = null);
        Task<(IEnumerable<Payment> payments, int totalCount)> GetPaymentsWithDetailsAsync(int pageNumber, int pageSize, string? searchTerm = null, int? cariId = null, int? paymentTypeId = null, string? status = null);
    }
} 