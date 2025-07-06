using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public interface IPurchaseInvoiceRepository : IGenericRepository<PurchaseInvoice>
    {
        Task<PurchaseInvoice?> GetByInvoiceNoAsync(string invoiceNo);
        Task<PurchaseInvoice?> GetInvoiceWithDetailsAsync(int invoiceId);
        Task<IEnumerable<PurchaseInvoice>> GetInvoicesByCariAsync(int cariId);
        Task<IEnumerable<PurchaseInvoice>> GetInvoicesByStatusAsync(string status);
        Task<IEnumerable<PurchaseInvoice>> GetDraftInvoicesAsync();
        Task<IEnumerable<PurchaseInvoice>> GetApprovedInvoicesAsync();
        Task<IEnumerable<PurchaseInvoice>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<bool> IsInvoiceNoUniqueAsync(string invoiceNo, int? excludeInvoiceId = null);
        Task<bool> ApproveInvoiceAsync(int invoiceId);
        Task<bool> CancelInvoiceAsync(int invoiceId);
        Task<decimal> GetTotalPurchaseAmountAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<int> GetInvoiceCountAsync(string? status = null);
        Task<string> GenerateInvoiceNoAsync();
        Task<bool> UpdateInvoiceTotalsAsync(int invoiceId);
    }
} 