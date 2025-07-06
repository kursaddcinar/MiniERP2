using MiniERP.API.DTOs;

namespace MiniERP.API.Services
{
    public interface IPurchaseInvoiceService
    {
        // Temel CRUD işlemleri
        Task<ApiResponse<PagedResult<PurchaseInvoiceDto>>> GetInvoicesAsync(PaginationParameters parameters);
        Task<ApiResponse<PurchaseInvoiceDto>> GetInvoiceByIdAsync(int id);
        Task<ApiResponse<PurchaseInvoiceDto>> GetInvoiceByNoAsync(string invoiceNo);
        Task<ApiResponse<PurchaseInvoiceDto>> CreateInvoiceAsync(CreatePurchaseInvoiceDto createInvoiceDto);
        Task<ApiResponse<PurchaseInvoiceDto>> UpdateInvoiceAsync(int id, UpdatePurchaseInvoiceDto updateInvoiceDto);
        Task<ApiResponse<bool>> DeleteInvoiceAsync(int id);

        // Fatura durumu işlemleri
        Task<ApiResponse<bool>> ApproveInvoiceAsync(int id, InvoiceApprovalDto approvalDto);
        Task<ApiResponse<bool>> CancelInvoiceAsync(int id, string reason);
        Task<ApiResponse<bool>> UpdateInvoiceTotalsAsync(int id);

        // Filtreleme ve listeleme
        Task<ApiResponse<PagedResult<PurchaseInvoiceDto>>> GetInvoicesByCariAsync(int cariId, PaginationParameters parameters);
        Task<ApiResponse<PagedResult<PurchaseInvoiceDto>>> GetInvoicesByStatusAsync(string status, PaginationParameters parameters);
        Task<ApiResponse<PagedResult<PurchaseInvoiceDto>>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate, PaginationParameters parameters);
        Task<ApiResponse<List<PurchaseInvoiceDto>>> GetDraftInvoicesAsync();
        Task<ApiResponse<List<PurchaseInvoiceDto>>> GetApprovedInvoicesAsync();

        // İstatistikler ve raporlar
        Task<ApiResponse<InvoiceSummaryDto>> GetInvoiceSummaryAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<ApiResponse<decimal>> GetTotalPurchaseAmountAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<ApiResponse<int>> GetInvoiceCountAsync(string? status = null);
        Task<ApiResponse<string>> GenerateInvoiceNoAsync();

        // Fatura detayları
        Task<ApiResponse<PurchaseInvoiceDto>> GetInvoiceWithDetailsAsync(int id);
    }
} 