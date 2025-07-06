using AutoMapper;
using Microsoft.Extensions.Logging;
using MiniERP.API.DTOs;
using MiniERP.API.Models;
using MiniERP.API.Repositories;

namespace MiniERP.API.Services
{
    public class SalesInvoiceService : ISalesInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<SalesInvoiceService> _logger;

        public SalesInvoiceService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SalesInvoiceService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        #region Temel CRUD İşlemleri

        public async Task<ApiResponse<PagedResult<SalesInvoiceDto>>> GetInvoicesAsync(PaginationParameters parameters)
        {
            try
            {
                var (invoices, totalCount) = await _unitOfWork.SalesInvoices.GetPagedWithCountAsync(
                    parameters.PageNumber,
                    parameters.PageSize);

                var invoiceDtos = _mapper.Map<List<SalesInvoiceDto>>(invoices);
                var pagedResult = new PagedResult<SalesInvoiceDto>(invoiceDtos, totalCount, parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<SalesInvoiceDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Satış faturaları getirilirken hata oluştu");
                return ApiResponse<PagedResult<SalesInvoiceDto>>.ErrorResult("Satış faturaları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<SalesInvoiceDto>> GetInvoiceByIdAsync(int id)
        {
            try
            {
                var invoice = await _unitOfWork.SalesInvoices.GetByIdAsync(id);
                if (invoice == null)
                {
                    return ApiResponse<SalesInvoiceDto>.ErrorResult("Satış faturası bulunamadı");
                }

                var invoiceDto = _mapper.Map<SalesInvoiceDto>(invoice);
                return ApiResponse<SalesInvoiceDto>.SuccessResult(invoiceDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Satış faturası {InvoiceId} getirilirken hata oluştu", id);
                return ApiResponse<SalesInvoiceDto>.ErrorResult("Satış faturası getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<SalesInvoiceDto>> GetInvoiceByNoAsync(string invoiceNo)
        {
            try
            {
                var invoice = await _unitOfWork.SalesInvoices.GetByInvoiceNoAsync(invoiceNo);
                if (invoice == null)
                {
                    return ApiResponse<SalesInvoiceDto>.ErrorResult("Satış faturası bulunamadı");
                }

                var invoiceDto = _mapper.Map<SalesInvoiceDto>(invoice);
                return ApiResponse<SalesInvoiceDto>.SuccessResult(invoiceDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Satış faturası {InvoiceNo} getirilirken hata oluştu", invoiceNo);
                return ApiResponse<SalesInvoiceDto>.ErrorResult("Satış faturası getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<SalesInvoiceDto>> CreateInvoiceAsync(CreateSalesInvoiceDto createInvoiceDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // Fatura numarası kontrolü
                if (!await _unitOfWork.SalesInvoices.IsInvoiceNoUniqueAsync(createInvoiceDto.InvoiceNo))
                {
                    return ApiResponse<SalesInvoiceDto>.ErrorResult("Bu fatura numarası zaten kullanılıyor");
                }

                var invoice = _mapper.Map<SalesInvoice>(createInvoiceDto);
                invoice.CreatedDate = DateTime.Now;
                invoice.Status = "DRAFT";

                // Fatura detayları için toplam hesaplama
                decimal subTotal = 0;
                decimal vatTotal = 0;
                decimal netTotal = 0;

                var invoiceDetails = new List<SalesInvoiceDetail>();
                foreach (var detailDto in createInvoiceDto.Details)
                {
                    var detail = _mapper.Map<SalesInvoiceDetail>(detailDto);
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

                await _unitOfWork.SalesInvoices.AddAsync(invoice);
                await _unitOfWork.SaveChangesAsync();

                // Detayları ekle
                foreach (var detail in invoiceDetails)
                {
                    detail.InvoiceID = invoice.InvoiceID;
                    await _unitOfWork.SalesInvoiceDetails.AddAsync(detail);
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                var result = await GetInvoiceWithDetailsAsync(invoice.InvoiceID);
                
                _logger.LogInformation("Satış faturası {InvoiceNo} başarıyla oluşturuldu", invoice.InvoiceNo);
                return result;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError(ex, "Satış faturası oluşturulurken hata oluştu");
                return ApiResponse<SalesInvoiceDto>.ErrorResult("Satış faturası oluşturulurken hata oluştu");
            }
        }

        public async Task<ApiResponse<SalesInvoiceDto>> UpdateInvoiceAsync(int id, UpdateSalesInvoiceDto updateInvoiceDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var invoice = await _unitOfWork.SalesInvoices.GetInvoiceWithDetailsAsync(id);
                if (invoice == null)
                {
                    return ApiResponse<SalesInvoiceDto>.ErrorResult("Satış faturası bulunamadı");
                }

                if (invoice.Status == "APPROVED")
                {
                    return ApiResponse<SalesInvoiceDto>.ErrorResult("Onaylanmış fatura güncellenemez");
                }

                // Mevcut detayları sil
                foreach (var detail in invoice.SalesInvoiceDetails.ToList())
                {
                    await _unitOfWork.SalesInvoiceDetails.DeleteAsync(detail);
                }

                // Fatura bilgilerini güncelle
                _mapper.Map(updateInvoiceDto, invoice);

                // Yeni detayları ekle ve toplamları hesapla
                decimal subTotal = 0;
                decimal vatTotal = 0;
                decimal netTotal = 0;

                foreach (var detailDto in updateInvoiceDto.Details)
                {
                    var detail = _mapper.Map<SalesInvoiceDetail>(detailDto);
                    detail.InvoiceID = invoice.InvoiceID;
                    detail.LineTotal = detail.Quantity * detail.UnitPrice;
                    detail.VatAmount = detail.LineTotal * detail.VatRate / 100;
                    detail.NetTotal = detail.LineTotal + detail.VatAmount;
                    detail.CreatedDate = DateTime.Now;

                    subTotal += detail.LineTotal;
                    vatTotal += detail.VatAmount;
                    netTotal += detail.NetTotal;

                    await _unitOfWork.SalesInvoiceDetails.AddAsync(detail);
                }

                invoice.SubTotal = subTotal;
                invoice.VatAmount = vatTotal;
                invoice.Total = netTotal;

                await _unitOfWork.SalesInvoices.UpdateAsync(invoice);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                var result = await GetInvoiceWithDetailsAsync(id);
                
                _logger.LogInformation("Satış faturası {InvoiceId} başarıyla güncellendi", id);
                return result;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError(ex, "Satış faturası {InvoiceId} güncellenirken hata oluştu", id);
                return ApiResponse<SalesInvoiceDto>.ErrorResult("Satış faturası güncellenirken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> DeleteInvoiceAsync(int id)
        {
            try
            {
                var invoice = await _unitOfWork.SalesInvoices.GetByIdAsync(id);
                if (invoice == null)
                {
                    return ApiResponse<bool>.ErrorResult("Satış faturası bulunamadı");
                }

                if (invoice.Status == "APPROVED")
                {
                    return ApiResponse<bool>.ErrorResult("Onaylanmış fatura silinemez");
                }

                await _unitOfWork.SalesInvoices.DeleteAsync(invoice);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Satış faturası {InvoiceId} başarıyla silindi", id);
                return ApiResponse<bool>.SuccessResult(true, "Satış faturası başarıyla silindi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Satış faturası {InvoiceId} silinirken hata oluştu", id);
                return ApiResponse<bool>.ErrorResult("Satış faturası silinirken hata oluştu");
            }
        }

        #endregion

        #region Fatura Durumu İşlemleri

        public async Task<ApiResponse<bool>> ApproveInvoiceAsync(int id, InvoiceApprovalDto approvalDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var invoice = await _unitOfWork.SalesInvoices.GetInvoiceWithDetailsAsync(id);
                if (invoice == null)
                {
                    return ApiResponse<bool>.ErrorResult("Satış faturası bulunamadı");
                }

                if (invoice.Status != "DRAFT")
                {
                    return ApiResponse<bool>.ErrorResult("Sadece taslak faturalar onaylanabilir");
                }

                var result = await _unitOfWork.SalesInvoices.ApproveInvoiceAsync(id);
                if (!result)
                {
                    return ApiResponse<bool>.ErrorResult("Fatura onaylanırken hata oluştu");
                }

                // Stok çıkışı yapabilir (gelecekte eklenebilir)
                // foreach (var detail in invoice.SalesInvoiceDetails)
                // {
                //     await _unitOfWork.StockCards.UpdateStockAsync(detail.ProductID, invoice.WarehouseID, detail.Quantity, "CIKIS");
                // }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                _logger.LogInformation("Satış faturası {InvoiceId} başarıyla onaylandı", id);
                return ApiResponse<bool>.SuccessResult(true, "Satış faturası başarıyla onaylandı");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError(ex, "Satış faturası {InvoiceId} onaylanırken hata oluştu", id);
                return ApiResponse<bool>.ErrorResult("Satış faturası onaylanırken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> CancelInvoiceAsync(int id, string reason)
        {
            try
            {
                var result = await _unitOfWork.SalesInvoices.CancelInvoiceAsync(id);
                if (!result)
                {
                    return ApiResponse<bool>.ErrorResult("Fatura iptal edilirken hata oluştu");
                }

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Satış faturası {InvoiceId} iptal edildi. Sebep: {Reason}", id, reason);
                return ApiResponse<bool>.SuccessResult(true, "Satış faturası başarıyla iptal edildi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Satış faturası {InvoiceId} iptal edilirken hata oluştu", id);
                return ApiResponse<bool>.ErrorResult("Satış faturası iptal edilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> UpdateInvoiceTotalsAsync(int id)
        {
            try
            {
                var result = await _unitOfWork.SalesInvoices.UpdateInvoiceTotalsAsync(id);
                if (!result)
                {
                    return ApiResponse<bool>.ErrorResult("Fatura toplamları güncellenirken hata oluştu");
                }

                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResult(true, "Fatura toplamları başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fatura {InvoiceId} toplamları güncellenirken hata oluştu", id);
                return ApiResponse<bool>.ErrorResult("Fatura toplamları güncellenirken hata oluştu");
            }
        }

        #endregion

        #region Filtreleme ve Listeleme

        public async Task<ApiResponse<PagedResult<SalesInvoiceDto>>> GetInvoicesByCariAsync(int cariId, PaginationParameters parameters)
        {
            try
            {
                var invoices = await _unitOfWork.SalesInvoices.GetInvoicesByCariAsync(cariId);
                var pagedInvoices = invoices.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                                          .Take(parameters.PageSize);

                var invoiceDtos = _mapper.Map<List<SalesInvoiceDto>>(pagedInvoices);
                var pagedResult = new PagedResult<SalesInvoiceDto>(invoiceDtos, invoices.Count(), parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<SalesInvoiceDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cari {CariId} için satış faturaları getirilirken hata oluştu", cariId);
                return ApiResponse<PagedResult<SalesInvoiceDto>>.ErrorResult("Satış faturaları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<PagedResult<SalesInvoiceDto>>> GetInvoicesByStatusAsync(string status, PaginationParameters parameters)
        {
            try
            {
                var invoices = await _unitOfWork.SalesInvoices.GetInvoicesByStatusAsync(status);
                var pagedInvoices = invoices.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                                          .Take(parameters.PageSize);

                var invoiceDtos = _mapper.Map<List<SalesInvoiceDto>>(pagedInvoices);
                var pagedResult = new PagedResult<SalesInvoiceDto>(invoiceDtos, invoices.Count(), parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<SalesInvoiceDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Durum {Status} için satış faturaları getirilirken hata oluştu", status);
                return ApiResponse<PagedResult<SalesInvoiceDto>>.ErrorResult("Satış faturaları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<PagedResult<SalesInvoiceDto>>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate, PaginationParameters parameters)
        {
            try
            {
                var invoices = await _unitOfWork.SalesInvoices.GetInvoicesByDateRangeAsync(startDate, endDate);
                var pagedInvoices = invoices.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                                          .Take(parameters.PageSize);

                var invoiceDtos = _mapper.Map<List<SalesInvoiceDto>>(pagedInvoices);
                var pagedResult = new PagedResult<SalesInvoiceDto>(invoiceDtos, invoices.Count(), parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<SalesInvoiceDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Tarih aralığı {StartDate} - {EndDate} için satış faturaları getirilirken hata oluştu", startDate, endDate);
                return ApiResponse<PagedResult<SalesInvoiceDto>>.ErrorResult("Satış faturaları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<SalesInvoiceDto>>> GetDraftInvoicesAsync()
        {
            try
            {
                var invoices = await _unitOfWork.SalesInvoices.GetDraftInvoicesAsync();
                var invoiceDtos = _mapper.Map<List<SalesInvoiceDto>>(invoices);

                return ApiResponse<List<SalesInvoiceDto>>.SuccessResult(invoiceDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Taslak satış faturaları getirilirken hata oluştu");
                return ApiResponse<List<SalesInvoiceDto>>.ErrorResult("Taslak satış faturaları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<SalesInvoiceDto>>> GetApprovedInvoicesAsync()
        {
            try
            {
                var invoices = await _unitOfWork.SalesInvoices.GetApprovedInvoicesAsync();
                var invoiceDtos = _mapper.Map<List<SalesInvoiceDto>>(invoices);

                return ApiResponse<List<SalesInvoiceDto>>.SuccessResult(invoiceDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Onaylanmış satış faturaları getirilirken hata oluştu");
                return ApiResponse<List<SalesInvoiceDto>>.ErrorResult("Onaylanmış satış faturaları getirilirken hata oluştu");
            }
        }

        #endregion

        #region İstatistikler ve Raporlar

        public async Task<ApiResponse<InvoiceSummaryDto>> GetInvoiceSummaryAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                var totalInvoices = await _unitOfWork.SalesInvoices.GetInvoiceCountAsync();
                var draftInvoices = await _unitOfWork.SalesInvoices.GetInvoiceCountAsync("DRAFT");
                var approvedInvoices = await _unitOfWork.SalesInvoices.GetInvoiceCountAsync("APPROVED");
                var cancelledInvoices = await _unitOfWork.SalesInvoices.GetInvoiceCountAsync("CANCELLED");
                
                var totalAmount = await _unitOfWork.SalesInvoices.GetTotalSalesAmountAsync(fromDate, toDate);
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
                _logger.LogError(ex, "Satış faturası özeti getirilirken hata oluştu");
                return ApiResponse<InvoiceSummaryDto>.ErrorResult("Satış faturası özeti getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<decimal>> GetTotalSalesAmountAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                var totalAmount = await _unitOfWork.SalesInvoices.GetTotalSalesAmountAsync(fromDate, toDate);
                return ApiResponse<decimal>.SuccessResult(totalAmount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Toplam satış tutarı getirilirken hata oluştu");
                return ApiResponse<decimal>.ErrorResult("Toplam satış tutarı getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<int>> GetInvoiceCountAsync(string? status = null)
        {
            try
            {
                var count = await _unitOfWork.SalesInvoices.GetInvoiceCountAsync(status);
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
                var invoiceNo = await _unitOfWork.SalesInvoices.GenerateInvoiceNoAsync();
                return ApiResponse<string>.SuccessResult(invoiceNo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fatura numarası oluşturulurken hata oluştu");
                return ApiResponse<string>.ErrorResult("Fatura numarası oluşturulurken hata oluştu");
            }
        }

        #endregion

        #region Fatura Detayları

        public async Task<ApiResponse<SalesInvoiceDto>> GetInvoiceWithDetailsAsync(int id)
        {
            try
            {
                var invoice = await _unitOfWork.SalesInvoices.GetInvoiceWithDetailsAsync(id);
                if (invoice == null)
                {
                    return ApiResponse<SalesInvoiceDto>.ErrorResult("Satış faturası bulunamadı");
                }

                var invoiceDto = _mapper.Map<SalesInvoiceDto>(invoice);
                return ApiResponse<SalesInvoiceDto>.SuccessResult(invoiceDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Satış faturası {InvoiceId} detayları getirilirken hata oluştu", id);
                return ApiResponse<SalesInvoiceDto>.ErrorResult("Satış faturası detayları getirilirken hata oluştu");
            }
        }

        #endregion
    }
} 