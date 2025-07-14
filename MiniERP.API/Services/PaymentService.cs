using AutoMapper;
using MiniERP.API.DTOs;
using MiniERP.API.Models;
using MiniERP.API.Repositories;

namespace MiniERP.API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PaymentService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResponse<PagedResult<PaymentDto>>> GetPaymentsAsync(PaginationParameters parameters, string? searchTerm = null, int? cariId = null, int? paymentTypeId = null, string? status = null)
        {
            try
            {
                var (payments, totalCount) = await _unitOfWork.Payments.GetPaymentsWithDetailsAsync(
                    parameters.PageNumber, parameters.PageSize, searchTerm, cariId, paymentTypeId, status);

                var paymentDtos = _mapper.Map<List<PaymentDto>>(payments);
                var pagedResult = new PagedResult<PaymentDto>(paymentDtos, totalCount, parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<PaymentDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payments");
                return ApiResponse<PagedResult<PaymentDto>>.ErrorResult("An error occurred while getting payments");
            }
        }

        public async Task<ApiResponse<PaymentDto>> GetPaymentByIdAsync(int id)
        {
            try
            {
                var payment = await _unitOfWork.Payments.GetByIdAsync(id);
                if (payment == null)
                {
                    return ApiResponse<PaymentDto>.ErrorResult("Payment not found");
                }

                var paymentDto = _mapper.Map<PaymentDto>(payment);
                return ApiResponse<PaymentDto>.SuccessResult(paymentDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payment {PaymentId}", id);
                return ApiResponse<PaymentDto>.ErrorResult("An error occurred while getting payment");
            }
        }

        public async Task<ApiResponse<PaymentDto>> CreatePaymentAsync(CreatePaymentDto createPaymentDto)
        {
            try
            {
                // Check if payment no is unique
                if (!await _unitOfWork.Payments.IsPaymentNoUniqueAsync(createPaymentDto.PaymentNo))
                {
                    return ApiResponse<PaymentDto>.ErrorResult("Payment number already exists");
                }

                // Check if cari account exists
                var cariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(createPaymentDto.CariID);
                if (cariAccount == null)
                {
                    return ApiResponse<PaymentDto>.ErrorResult("Cari account not found");
                }

                // Check if payment type exists
                var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(createPaymentDto.PaymentTypeID);
                if (paymentType == null)
                {
                    return ApiResponse<PaymentDto>.ErrorResult("Payment type not found");
                }

                var payment = _mapper.Map<Payment>(createPaymentDto);
                payment.Status = "COMPLETED";
                payment.CreatedDate = DateTime.Now;

                await _unitOfWork.Payments.AddAsync(payment);
                
                // Create cari transaction for payment
                var cariTransaction = new CariTransaction
                {
                    CariID = createPaymentDto.CariID,
                    TransactionDate = createPaymentDto.PaymentDate,
                    TransactionType = "BORC", // Tedarikçiye ödeme = Cari hesabın borcu azalır
                    Amount = createPaymentDto.Amount,
                    Description = $"Payment - {createPaymentDto.PaymentNo}",
                    DocumentType = "PAYMENT",
                    DocumentNo = createPaymentDto.PaymentNo,
                    CreatedDate = DateTime.Now
                };

                await _unitOfWork.CariTransactions.AddAsync(cariTransaction);

                // Update cari account balance
                cariAccount.CurrentBalance -= createPaymentDto.Amount;
                await _unitOfWork.CariAccounts.UpdateAsync(cariAccount);

                await _unitOfWork.SaveChangesAsync();

                var paymentDto = _mapper.Map<PaymentDto>(payment);
                _logger.LogInformation("Payment {PaymentNo} created successfully", createPaymentDto.PaymentNo);
                
                return ApiResponse<PaymentDto>.SuccessResult(paymentDto, "Payment created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating payment {PaymentNo}", createPaymentDto.PaymentNo);
                return ApiResponse<PaymentDto>.ErrorResult("An error occurred while creating payment");
            }
        }

        public async Task<ApiResponse<PaymentDto>> UpdatePaymentAsync(int id, UpdatePaymentDto updatePaymentDto)
        {
            try
            {
                var payment = await _unitOfWork.Payments.GetByIdAsync(id);
                if (payment == null)
                {
                    return ApiResponse<PaymentDto>.ErrorResult("Payment not found");
                }

                // Check if payment can be updated
                if (payment.Status == "CANCELLED")
                {
                    return ApiResponse<PaymentDto>.ErrorResult("Cannot update cancelled payment");
                }

                // Check if cari account exists
                var cariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(updatePaymentDto.CariID);
                if (cariAccount == null)
                {
                    return ApiResponse<PaymentDto>.ErrorResult("Cari account not found");
                }

                // Check if payment type exists
                var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(updatePaymentDto.PaymentTypeID);
                if (paymentType == null)
                {
                    return ApiResponse<PaymentDto>.ErrorResult("Payment type not found");
                }

                var originalAmount = payment.Amount;
                var originalCariId = payment.CariID;

                _mapper.Map(updatePaymentDto, payment);
                await _unitOfWork.Payments.UpdateAsync(payment);

                // Update cari transaction and balance if amount or cari changed
                if (originalAmount != updatePaymentDto.Amount || originalCariId != updatePaymentDto.CariID)
                {
                    // Revert original cari transaction
                    if (originalCariId != updatePaymentDto.CariID)
                    {
                        var originalCariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(originalCariId);
                        if (originalCariAccount != null)
                        {
                            originalCariAccount.CurrentBalance += originalAmount;
                            await _unitOfWork.CariAccounts.UpdateAsync(originalCariAccount);
                        }
                    }
                    else
                    {
                        cariAccount.CurrentBalance += originalAmount;
                    }

                    // Apply new cari transaction
                    cariAccount.CurrentBalance -= updatePaymentDto.Amount;
                    await _unitOfWork.CariAccounts.UpdateAsync(cariAccount);
                }

                await _unitOfWork.SaveChangesAsync();

                var paymentDto = _mapper.Map<PaymentDto>(payment);
                _logger.LogInformation("Payment {PaymentId} updated successfully", id);
                
                return ApiResponse<PaymentDto>.SuccessResult(paymentDto, "Payment updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating payment {PaymentId}", id);
                return ApiResponse<PaymentDto>.ErrorResult("An error occurred while updating payment");
            }
        }

        public async Task<ApiResponse<bool>> DeletePaymentAsync(int id)
        {
            try
            {
                var payment = await _unitOfWork.Payments.GetByIdAsync(id);
                if (payment == null)
                {
                    return ApiResponse<bool>.ErrorResult("Payment not found");
                }

                // Check if payment can be deleted
                if (payment.Status == "COMPLETED")
                {
                    return ApiResponse<bool>.ErrorResult("Cannot delete completed payment. Please cancel first.");
                }

                await _unitOfWork.Payments.DeleteAsync(payment);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Payment {PaymentId} deleted successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Payment deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting payment {PaymentId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while deleting payment");
            }
        }

        public async Task<ApiResponse<List<PaymentDto>>> GetPaymentsByCariIdAsync(int cariId)
        {
            try
            {
                var payments = await _unitOfWork.Payments.GetPaymentsByCariIdAsync(cariId);
                var paymentDtos = _mapper.Map<List<PaymentDto>>(payments);
                
                return ApiResponse<List<PaymentDto>>.SuccessResult(paymentDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payments for cari {CariId}", cariId);
                return ApiResponse<List<PaymentDto>>.ErrorResult("An error occurred while getting payments");
            }
        }

        public async Task<ApiResponse<List<PaymentDto>>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var payments = await _unitOfWork.Payments.GetPaymentsByDateRangeAsync(startDate, endDate);
                var paymentDtos = _mapper.Map<List<PaymentDto>>(payments);
                
                return ApiResponse<List<PaymentDto>>.SuccessResult(paymentDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payments for date range {StartDate} - {EndDate}", startDate, endDate);
                return ApiResponse<List<PaymentDto>>.ErrorResult("An error occurred while getting payments");
            }
        }

        public async Task<ApiResponse<List<PaymentDto>>> GetRecentPaymentsAsync(int count = 10)
        {
            try
            {
                var payments = await _unitOfWork.Payments.GetRecentPaymentsAsync(count);
                var paymentDtos = _mapper.Map<List<PaymentDto>>(payments);
                
                return ApiResponse<List<PaymentDto>>.SuccessResult(paymentDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting recent payments");
                return ApiResponse<List<PaymentDto>>.ErrorResult("An error occurred while getting recent payments");
            }
        }

        public async Task<ApiResponse<decimal>> GetTotalPaymentAmountAsync(int cariId)
        {
            try
            {
                var totalAmount = await _unitOfWork.Payments.GetTotalPaymentAmountAsync(cariId);
                return ApiResponse<decimal>.SuccessResult(totalAmount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total payment amount for cari {CariId}", cariId);
                return ApiResponse<decimal>.ErrorResult("An error occurred while getting total payment amount");
            }
        }

        public async Task<ApiResponse<PaymentSummaryDto>> GetPaymentSummaryAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var start = startDate ?? DateTime.Now.AddMonths(-1);
                var end = endDate ?? DateTime.Now;

                var payments = await _unitOfWork.Payments.GetPaymentsByDateRangeAsync(start, end);
                var collections = await _unitOfWork.Collections.GetCollectionsByDateRangeAsync(start, end);

                var summary = new PaymentSummaryDto
                {
                    TotalPayments = payments.Count(),
                    TotalPaymentAmount = payments.Where(p => p.Status == "COMPLETED").Sum(p => p.Amount),
                    TotalCollections = collections.Count(),
                    TotalCollectionAmount = collections.Where(c => c.Status == "COMPLETED").Sum(c => c.Amount),
                    PendingPayments = payments.Count(p => p.Status == "PENDING"),
                    PendingCollections = collections.Count(c => c.Status == "PENDING"),
                    PendingPaymentAmount = payments.Where(p => p.Status == "PENDING").Sum(p => p.Amount),
                    PendingCollectionAmount = collections.Where(c => c.Status == "PENDING").Sum(c => c.Amount)
                };

                summary.NetCashFlow = summary.TotalCollectionAmount - summary.TotalPaymentAmount;

                return ApiResponse<PaymentSummaryDto>.SuccessResult(summary);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payment summary");
                return ApiResponse<PaymentSummaryDto>.ErrorResult("An error occurred while getting payment summary");
            }
        }

        public async Task<ApiResponse<List<PaymentDto>>> GetPaymentsByStatusAsync(string status)
        {
            try
            {
                var payments = await _unitOfWork.Payments.GetPaymentsByStatusAsync(status);
                var paymentDtos = _mapper.Map<List<PaymentDto>>(payments);
                
                return ApiResponse<List<PaymentDto>>.SuccessResult(paymentDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payments by status {Status}", status);
                return ApiResponse<List<PaymentDto>>.ErrorResult("An error occurred while getting payments");
            }
        }

        public async Task<ApiResponse<bool>> ApprovePaymentAsync(int id)
        {
            try
            {
                var payment = await _unitOfWork.Payments.GetByIdAsync(id);
                if (payment == null)
                {
                    return ApiResponse<bool>.ErrorResult("Payment not found");
                }

                if (payment.Status == "COMPLETED")
                {
                    return ApiResponse<bool>.ErrorResult("Payment is already approved");
                }

                if (payment.Status == "CANCELLED")
                {
                    return ApiResponse<bool>.ErrorResult("Cannot approve cancelled payment");
                }

                payment.Status = "COMPLETED";
                await _unitOfWork.Payments.UpdateAsync(payment);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Payment {PaymentId} approved successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Payment approved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error approving payment {PaymentId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while approving payment");
            }
        }

        public async Task<ApiResponse<bool>> CancelPaymentAsync(int id)
        {
            try
            {
                var payment = await _unitOfWork.Payments.GetByIdAsync(id);
                if (payment == null)
                {
                    return ApiResponse<bool>.ErrorResult("Payment not found");
                }

                if (payment.Status == "CANCELLED")
                {
                    return ApiResponse<bool>.ErrorResult("Payment is already cancelled");
                }

                // Revert cari transaction
                var cariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(payment.CariID);
                if (cariAccount != null)
                {
                    cariAccount.CurrentBalance += payment.Amount;
                    await _unitOfWork.CariAccounts.UpdateAsync(cariAccount);
                }

                payment.Status = "CANCELLED";
                await _unitOfWork.Payments.UpdateAsync(payment);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Payment {PaymentId} cancelled successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Payment cancelled successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling payment {PaymentId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while cancelling payment");
            }
        }
    }
} 