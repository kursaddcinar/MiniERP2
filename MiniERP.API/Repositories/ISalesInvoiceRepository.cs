using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public interface ISalesInvoiceRepository : IGenericRepository<SalesInvoice>
    {
        Task<SalesInvoice?> GetByInvoiceNoAsync(string invoiceNo);
        Task<SalesInvoice?> GetInvoiceWithDetailsAsync(int invoiceId);
        Task<IEnumerable<SalesInvoice>> GetInvoicesByCariAsync(int cariId);
        Task<IEnumerable<SalesInvoice>> GetInvoicesByStatusAsync(string status);
        Task<IEnumerable<SalesInvoice>> GetDraftInvoicesAsync();
        Task<IEnumerable<SalesInvoice>> GetApprovedInvoicesAsync();
        Task<IEnumerable<SalesInvoice>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<bool> IsInvoiceNoUniqueAsync(string invoiceNo, int? excludeInvoiceId = null);
        Task<bool> ApproveInvoiceAsync(int invoiceId);
        Task<bool> CancelInvoiceAsync(int invoiceId);
        Task<decimal> GetTotalSalesAmountAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<int> GetInvoiceCountAsync(string? status = null);
        Task<string> GenerateInvoiceNoAsync();
        Task<bool> UpdateInvoiceTotalsAsync(int invoiceId);
    }
} 