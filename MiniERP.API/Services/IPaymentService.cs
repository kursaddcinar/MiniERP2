using MiniERP.API.DTOs;

namespace MiniERP.API.Services
{
    public interface IPaymentService
    {
        Task<ApiResponse<PagedResult<PaymentDto>>> GetPaymentsAsync(PaginationParameters parameters, string? searchTerm = null, int? cariId = null, int? paymentTypeId = null, string? status = null);
        Task<ApiResponse<PaymentDto>> GetPaymentByIdAsync(int id);
        Task<ApiResponse<PaymentDto>> CreatePaymentAsync(CreatePaymentDto createPaymentDto);
        Task<ApiResponse<PaymentDto>> UpdatePaymentAsync(int id, UpdatePaymentDto updatePaymentDto);
        Task<ApiResponse<bool>> DeletePaymentAsync(int id);
        Task<ApiResponse<List<PaymentDto>>> GetPaymentsByCariIdAsync(int cariId);
        Task<ApiResponse<List<PaymentDto>>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ApiResponse<List<PaymentDto>>> GetRecentPaymentsAsync(int count = 10);
        Task<ApiResponse<decimal>> GetTotalPaymentAmountAsync(int cariId);
        Task<ApiResponse<PaymentSummaryDto>> GetPaymentSummaryAsync(DateTime? startDate = null, DateTime? endDate = null);
        Task<ApiResponse<List<PaymentDto>>> GetPaymentsByStatusAsync(string status);
        Task<ApiResponse<bool>> ApprovePaymentAsync(int id);
        Task<ApiResponse<bool>> CancelPaymentAsync(int id);
    }
} 