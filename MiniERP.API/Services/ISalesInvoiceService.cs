using MiniERP.API.DTOs;

namespace MiniERP.API.Services
{
    public interface ISalesInvoiceService
    {
        // Temel CRUD işlemleri
        Task<ApiResponse<PagedResult<SalesInvoiceDto>>> GetInvoicesAsync(PaginationParameters parameters);
        Task<ApiResponse<SalesInvoiceDto>> GetInvoiceByIdAsync(int id);
        Task<ApiResponse<SalesInvoiceDto>> GetInvoiceByNoAsync(string invoiceNo);
        Task<ApiResponse<SalesInvoiceDto>> CreateInvoiceAsync(CreateSalesInvoiceDto createInvoiceDto);
        Task<ApiResponse<SalesInvoiceDto>> UpdateInvoiceAsync(int id, UpdateSalesInvoiceDto updateInvoiceDto);
        Task<ApiResponse<bool>> DeleteInvoiceAsync(int id);

        // Fatura durumu işlemleri
        Task<ApiResponse<bool>> ApproveInvoiceAsync(int id, InvoiceApprovalDto approvalDto);
        Task<ApiResponse<bool>> CancelInvoiceAsync(int id, string reason);
        Task<ApiResponse<bool>> UpdateInvoiceTotalsAsync(int id);

        // Filtreleme ve listeleme
        Task<ApiResponse<PagedResult<SalesInvoiceDto>>> GetInvoicesByCariAsync(int cariId, PaginationParameters parameters);
        Task<ApiResponse<PagedResult<SalesInvoiceDto>>> GetInvoicesByStatusAsync(string status, PaginationParameters parameters);
        Task<ApiResponse<PagedResult<SalesInvoiceDto>>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate, PaginationParameters parameters);
        Task<ApiResponse<List<SalesInvoiceDto>>> GetDraftInvoicesAsync();
        Task<ApiResponse<List<SalesInvoiceDto>>> GetApprovedInvoicesAsync();

        // İstatistikler ve raporlar
        Task<ApiResponse<InvoiceSummaryDto>> GetInvoiceSummaryAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<ApiResponse<decimal>> GetTotalSalesAmountAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<ApiResponse<int>> GetInvoiceCountAsync(string? status = null);
        Task<ApiResponse<string>> GenerateInvoiceNoAsync();

        // Fatura detayları
        Task<ApiResponse<SalesInvoiceDto>> GetInvoiceWithDetailsAsync(int id);
    }
} 