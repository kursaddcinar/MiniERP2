using AutoMapper;
using Microsoft.Extensions.Logging;
using MiniERP.API.DTOs;
using MiniERP.API.Models;
using MiniERP.API.Repositories;

namespace MiniERP.API.Services
{
    public class PurchaseInvoiceService : IPurchaseInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PurchaseInvoiceService> _logger;

        public PurchaseInvoiceService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PurchaseInvoiceService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        #region Temel CRUD İşlemleri

        public async Task<ApiResponse<PagedResult<PurchaseInvoiceDto>>> GetInvoicesAsync(PaginationParameters parameters)
        {
            try
            {
                var (invoices, totalCount) = await _unitOfWork.PurchaseInvoices.GetPagedWithCountAsync(parameters.PageNumber, parameters.PageSize);
                var invoiceDtos = _mapper.Map<List<PurchaseInvoiceDto>>(invoices);
                var pagedResult = new PagedResult<PurchaseInvoiceDto>(invoiceDtos, totalCount, parameters.PageNumber, parameters.PageSize);
                return ApiResponse<PagedResult<PurchaseInvoiceDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Alış faturaları getirilirken hata oluştu");
                return ApiResponse<PagedResult<PurchaseInvoiceDto>>.ErrorResult("Alış faturaları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<PurchaseInvoiceDto>> GetInvoiceByIdAsync(int id)
        {
            try
            {
                var invoice = await _unitOfWork.PurchaseInvoices.GetByIdAsync(id);
                if (invoice == null)
                    return ApiResponse<PurchaseInvoiceDto>.ErrorResult("Alış faturası bulunamadı");

                var invoiceDto = _mapper.Map<PurchaseInvoiceDto>(invoice);
                return ApiResponse<PurchaseInvoiceDto>.SuccessResult(invoiceDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Alış faturası {InvoiceId} getirilirken hata oluştu", id);
                return ApiResponse<PurchaseInvoiceDto>.ErrorResult("Alış faturası getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<PurchaseInvoiceDto>> GetInvoiceByNoAsync(string invoiceNo)
        {
            try
            {
                var invoice = await _unitOfWork.PurchaseInvoices.GetByInvoiceNoAsync(invoiceNo);
                if (invoice == null)
                    return ApiResponse<PurchaseInvoiceDto>.ErrorResult("Alış faturası bulunamadı");

                var invoiceDto = _mapper.Map<PurchaseInvoiceDto>(invoice);
                return ApiResponse<PurchaseInvoiceDto>.SuccessResult(invoiceDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Alış faturası {InvoiceNo} getirilirken hata oluştu", invoiceNo);
                return ApiResponse<PurchaseInvoiceDto>.ErrorResult("Alış faturası getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<PurchaseInvoiceDto>> CreateInvoiceAsync(CreatePurchaseInvoiceDto createInvoiceDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // Fatura numarası kontrolü
                if (!await _unitOfWork.PurchaseInvoices.IsInvoiceNoUniqueAsync(createInvoiceDto.InvoiceNo))
                {
                    return ApiResponse<PurchaseInvoiceDto>.ErrorResult("Bu fatura numarası zaten kullanılıyor");
                }

                var invoice = _mapper.Map<PurchaseInvoice>(createInvoiceDto);
                invoice.CreatedDate = DateTime.Now;
                invoice.Status = "DRAFT";

                // Fatura detayları için toplam hesaplama
                decimal subTotal = 0;
                decimal vatTotal = 0;
                decimal netTotal = 0;

                var invoiceDetails = new List<PurchaseInvoiceDetail>();
                foreach (var detailDto in createInvoiceDto.Details)
                {
                    var detail = _mapper.Map<PurchaseInvoiceDetail>(detailDto);
                    detail.LineTotal = detail.Quantity * detail.UnitPrice;
                    detail.VatAmount = detail.LineTotal * detail.VatRate / 100;
                    detail.NetTotal = detail.LineTotal + detail.VatAmount;
                    detail.CreatedDate = DateTime.Now;

                    subTotal += detail.LineTotal;
                    vatTotal += detail.VatAmount;
                    netTotal += detail.NetTotal;

                    invoiceDetails.Add(detail);
                }

                invoice.SubTotal = subTotal;
                invoice.VatAmount = vatTotal;
                invoice.Total = netTotal;

                await _unitOfWork.PurchaseInvoices.AddAsync(invoice);
                await _unitOfWork.SaveChangesAsync();

                // Detayları ekle
                foreach (var detail in invoiceDetails)
                {
                    detail.InvoiceID = invoice.InvoiceID;
                    await _unitOfWork.PurchaseInvoiceDetails.AddAsync(detail);
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                var result = await GetInvoiceWithDetailsAsync(invoice.InvoiceID);
                
                _logger.LogInformation("Alış faturası {InvoiceNo} başarıyla oluşturuldu", invoice.InvoiceNo);
                return result;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError(ex, "Alış faturası oluşturulurken hata oluştu");
                return ApiResponse<PurchaseInvoiceDto>.ErrorResult("Alış faturası oluşturulurken hata oluştu");
            }
        }

        public async Task<ApiResponse<PurchaseInvoiceDto>> UpdateInvoiceAsync(int id, UpdatePurchaseInvoiceDto updateInvoiceDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var invoice = await _unitOfWork.PurchaseInvoices.GetInvoiceWithDetailsAsync(id);
                if (invoice == null)
                {
                    return ApiResponse<PurchaseInvoiceDto>.ErrorResult("Alış faturası bulunamadı");
                }

                if (invoice.Status == "APPROVED")
                {
                    return ApiResponse<PurchaseInvoiceDto>.ErrorResult("Onaylanmış fatura güncellenemez");
                }

                // Mevcut detayları sil
                foreach (var detail in invoice.PurchaseInvoiceDetails.ToList())
                {
                    await _unitOfWork.PurchaseInvoiceDetails.DeleteAsync(detail);
                }

                // Fatura bilgilerini güncelle
                _mapper.Map(updateInvoiceDto, invoice);

                // Yeni detayları ekle ve toplamları hesapla
                decimal subTotal = 0;
                decimal vatTotal = 0;
                decimal netTotal = 0;

                foreach (var detailDto in updateInvoiceDto.Details)
                {
                    var detail = _mapper.Map<PurchaseInvoiceDetail>(detailDto);
                    detail.InvoiceID = invoice.InvoiceID;
                    detail.LineTotal = detail.Quantity * detail.UnitPrice;
                    detail.VatAmount = detail.LineTotal * detail.VatRate / 100;
                    detail.NetTotal = detail.LineTotal + detail.VatAmount;
                    detail.CreatedDate = DateTime.Now;

                    subTotal += detail.LineTotal;
                    vatTotal += detail.VatAmount;
                    netTotal += detail.NetTotal;

                    await _unitOfWork.PurchaseInvoiceDetails.AddAsync(detail);
                }

                invoice.SubTotal = subTotal;
                invoice.VatAmount = vatTotal;
                invoice.Total = netTotal;

                await _unitOfWork.PurchaseInvoices.UpdateAsync(invoice);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                var result = await GetInvoiceWithDetailsAsync(invoice.InvoiceID);
                _logger.LogInformation("Alış faturası {InvoiceId} başarıyla güncellendi", id);
                return result;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError(ex, "Alış faturası {InvoiceId} güncellenirken hata oluştu", id);
                return ApiResponse<PurchaseInvoiceDto>.ErrorResult("Alış faturası güncellenirken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> DeleteInvoiceAsync(int id)
        {
            try
            {
                var invoice = await _unitOfWork.PurchaseInvoices.GetByIdAsync(id);
                if (invoice == null)
                    return ApiResponse<bool>.ErrorResult("Alış faturası bulunamadı");

                if (invoice.Status == "APPROVED")
                    return ApiResponse<bool>.ErrorResult("Onaylanmış fatura silinemez");

                await _unitOfWork.PurchaseInvoices.DeleteAsync(invoice);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Alış faturası {InvoiceId} başarıyla silindi", id);
                return ApiResponse<bool>.SuccessResult(true, "Alış faturası başarıyla silindi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Alış faturası {InvoiceId} silinirken hata oluştu", id);
                return ApiResponse<bool>.ErrorResult("Alış faturası silinirken hata oluştu");
            }
        }

        #endregion

        // Diğer methodlar için placeholder (dosya çok büyük olmasın diye)
        public async Task<ApiResponse<bool>> ApproveInvoiceAsync(int id, InvoiceApprovalDto approvalDto)
        {
            try
            {
                var result = await _unitOfWork.PurchaseInvoices.ApproveInvoiceAsync(id);
                if (!result)
                    return ApiResponse<bool>.ErrorResult("Fatura onaylanırken hata oluştu");

                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResult(true, "Alış faturası başarıyla onaylandı");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Alış faturası {InvoiceId} onaylanırken hata oluştu", id);
                return ApiResponse<bool>.ErrorResult("Alış faturası onaylanırken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> CancelInvoiceAsync(int id, string reason)
        {
            try
            {
                var result = await _unitOfWork.PurchaseInvoices.CancelInvoiceAsync(id);
                if (!result)
                    return ApiResponse<bool>.ErrorResult("Fatura iptal edilirken hata oluştu");

                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResult(true, "Alış faturası başarıyla iptal edildi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Alış faturası {InvoiceId} iptal edilirken hata oluştu", id);
                return ApiResponse<bool>.ErrorResult("Alış faturası iptal edilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> UpdateInvoiceTotalsAsync(int id)
        {
            try
            {
                var result = await _unitOfWork.PurchaseInvoices.UpdateInvoiceTotalsAsync(id);
                if (!result)
                    return ApiResponse<bool>.ErrorResult("Fatura toplamları güncellenirken hata oluştu");

                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResult(true, "Fatura toplamları başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fatura {InvoiceId} toplamları güncellenirken hata oluştu", id);
                return ApiResponse<bool>.ErrorResult("Fatura toplamları güncellenirken hata oluştu");
            }
        }

        public async Task<ApiResponse<PagedResult<PurchaseInvoiceDto>>> GetInvoicesByCariAsync(int cariId, PaginationParameters parameters)
        {
            try
            {
                var invoices = await _unitOfWork.PurchaseInvoices.GetInvoicesByCariAsync(cariId);
                var pagedInvoices = invoices.Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize);
                var invoiceDtos = _mapper.Map<List<PurchaseInvoiceDto>>(pagedInvoices);
                var pagedResult = new PagedResult<PurchaseInvoiceDto>(invoiceDtos, invoices.Count(), parameters.PageNumber, parameters.PageSize);
                return ApiResponse<PagedResult<PurchaseInvoiceDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cari {CariId} için alış faturaları getirilirken hata oluştu", cariId);
                return ApiResponse<PagedResult<PurchaseInvoiceDto>>.ErrorResult("Alış faturaları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<PagedResult<PurchaseInvoiceDto>>> GetInvoicesByStatusAsync(string status, PaginationParameters parameters)
        {
            try
            {
                var invoices = await _unitOfWork.PurchaseInvoices.GetInvoicesByStatusAsync(status);
                var pagedInvoices = invoices.Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize);
                var invoiceDtos = _mapper.Map<List<PurchaseInvoiceDto>>(pagedInvoices);
                var pagedResult = new PagedResult<PurchaseInvoiceDto>(invoiceDtos, invoices.Count(), parameters.PageNumber, parameters.PageSize);
                return ApiResponse<PagedResult<PurchaseInvoiceDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Durum {Status} için alış faturaları getirilirken hata oluştu", status);
                return ApiResponse<PagedResult<PurchaseInvoiceDto>>.ErrorResult("Alış faturaları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<PagedResult<PurchaseInvoiceDto>>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate, PaginationParameters parameters)
        {
            try
            {
                var invoices = await _unitOfWork.PurchaseInvoices.GetInvoicesByDateRangeAsync(startDate, endDate);
                var pagedInvoices = invoices.Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize);
                var invoiceDtos = _mapper.Map<List<PurchaseInvoiceDto>>(pagedInvoices);
                var pagedResult = new PagedResult<PurchaseInvoiceDto>(invoiceDtos, invoices.Count(), parameters.PageNumber, parameters.PageSize);
                return ApiResponse<PagedResult<PurchaseInvoiceDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Tarih aralığı {StartDate} - {EndDate} için alış faturaları getirilirken hata oluştu", startDate, endDate);
                return ApiResponse<PagedResult<PurchaseInvoiceDto>>.ErrorResult("Alış faturaları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<PurchaseInvoiceDto>>> GetDraftInvoicesAsync()
        {
            try
            {
                var invoices = await _unitOfWork.PurchaseInvoices.GetDraftInvoicesAsync();
                var invoiceDtos = _mapper.Map<List<PurchaseInvoiceDto>>(invoices);
                return ApiResponse<List<PurchaseInvoiceDto>>.SuccessResult(invoiceDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Taslak alış faturaları getirilirken hata oluştu");
                return ApiResponse<List<PurchaseInvoiceDto>>.ErrorResult("Taslak alış faturaları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<PurchaseInvoiceDto>>> GetApprovedInvoicesAsync()
        {
            try
            {
                var invoices = await _unitOfWork.PurchaseInvoices.GetApprovedInvoicesAsync();
                var invoiceDtos = _mapper.Map<List<PurchaseInvoiceDto>>(invoices);
                return ApiResponse<List<PurchaseInvoiceDto>>.SuccessResult(invoiceDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Onaylanmış alış faturaları getirilirken hata oluştu");
                return ApiResponse<List<PurchaseInvoiceDto>>.ErrorResult("Onaylanmış alış faturaları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<InvoiceSummaryDto>> GetInvoiceSummaryAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                var totalInvoices = await _unitOfWork.PurchaseInvoices.GetInvoiceCountAsync();
                var draftInvoices = await _unitOfWork.PurchaseInvoices.GetInvoiceCountAsync("DRAFT");
                var approvedInvoices = await _unitOfWork.PurchaseInvoices.GetInvoiceCountAsync("APPROVED");
                var cancelledInvoices = await _unitOfWork.PurchaseInvoices.GetInvoiceCountAsync("CANCELLED");
                
                var totalAmount = await _unitOfWork.PurchaseInvoices.GetTotalPurchaseAmountAsync(fromDate, toDate);
                var draftAmount = 0m; // İhtiyaç halinde ayrı sorgu yapılabilir
                var approvedAmount = totalAmount; // Onaylanan faturalar için

                var summary = new InvoiceSummaryDto
                {
                    TotalInvoices = totalInvoices,
                    DraftInvoices = draftInvoices,
                    ApprovedInvoices = approvedInvoices,
                    CancelledInvoices = cancelledInvoices,
                    TotalAmount = totalAmount,
                    DraftAmount = draftAmount,
                    ApprovedAmount = approvedAmount
                };

                return ApiResponse<InvoiceSummaryDto>.SuccessResult(summary);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Alış faturası özeti getirilirken hata oluştu");
                return ApiResponse<InvoiceSummaryDto>.ErrorResult("Alış faturası özeti getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<decimal>> GetTotalPurchaseAmountAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                var totalAmount = await _unitOfWork.PurchaseInvoices.GetTotalPurchaseAmountAsync(fromDate, toDate);
                return ApiResponse<decimal>.SuccessResult(totalAmount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Toplam alış tutarı getirilirken hata oluştu");
                return ApiResponse<decimal>.ErrorResult("Toplam alış tutarı getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<int>> GetInvoiceCountAsync(string? status = null)
        {
            try
            {
                var count = await _unitOfWork.PurchaseInvoices.GetInvoiceCountAsync(status);
                return ApiResponse<int>.SuccessResult(count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fatura sayısı getirilirken hata oluştu");
                return ApiResponse<int>.ErrorResult("Fatura sayısı getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<string>> GenerateInvoiceNoAsync()
        {
            try
            {
                var invoiceNo = await _unitOfWork.PurchaseInvoices.GenerateInvoiceNoAsync();
                return ApiResponse<string>.SuccessResult(invoiceNo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fatura numarası oluşturulurken hata oluştu");
                return ApiResponse<string>.ErrorResult("Fatura numarası oluşturulurken hata oluştu");
            }
        }

        public async Task<ApiResponse<PurchaseInvoiceDto>> GetInvoiceWithDetailsAsync(int id)
        {
            try
            {
                var invoice = await _unitOfWork.PurchaseInvoices.GetInvoiceWithDetailsAsync(id);
                if (invoice == null)
                    return ApiResponse<PurchaseInvoiceDto>.ErrorResult("Alış faturası bulunamadı");

                var invoiceDto = _mapper.Map<PurchaseInvoiceDto>(invoice);
                return ApiResponse<PurchaseInvoiceDto>.SuccessResult(invoiceDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Alış faturası {InvoiceId} detayları getirilirken hata oluştu", id);
                return ApiResponse<PurchaseInvoiceDto>.ErrorResult("Alış faturası detayları getirilirken hata oluştu");
            }
        }
    }
} 