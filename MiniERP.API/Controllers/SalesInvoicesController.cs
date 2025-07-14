using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.API.DTOs;
using MiniERP.API.Services;

namespace MiniERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesInvoicesController : ControllerBase
    {
        private readonly ISalesInvoiceService _salesInvoiceService;

        public SalesInvoicesController(ISalesInvoiceService salesInvoiceService)
        {
            _salesInvoiceService = salesInvoiceService;
        }

        /// <summary>
        /// Tüm satış faturalarını sayfalı olarak getirir
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Sales,Finance")]
        public async Task<ActionResult<ApiResponse<PagedResult<SalesInvoiceDto>>>> GetInvoices([FromQuery] PaginationParameters parameters)
        {
            var result = await _salesInvoiceService.GetInvoicesAsync(parameters);
            return Ok(result);
        }

        /// <summary>
        /// ID'ye göre satış faturası getirir
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,Sales,Finance")]
        public async Task<ActionResult<ApiResponse<SalesInvoiceDto>>> GetInvoice(int id)
        {
            var result = await _salesInvoiceService.GetInvoiceByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Fatura numarasına göre satış faturası getirir
        /// </summary>
        [HttpGet("by-invoice-no/{invoiceNo}")]
        public async Task<ActionResult<ApiResponse<SalesInvoiceDto>>> GetInvoiceByNo(string invoiceNo)
        {
            var result = await _salesInvoiceService.GetInvoiceByNoAsync(invoiceNo);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Satış faturası detayları ile birlikte getirir
        /// </summary>
        [HttpGet("{id}/details")]
        public async Task<ActionResult<ApiResponse<SalesInvoiceDto>>> GetInvoiceWithDetails(int id)
        {
            var result = await _salesInvoiceService.GetInvoiceWithDetailsAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Yeni satış faturası oluşturur
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Sales")]
        public async Task<ActionResult<ApiResponse<SalesInvoiceDto>>> CreateInvoice([FromBody] CreateSalesInvoiceDto createInvoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<SalesInvoiceDto>.ErrorResult("Geçersiz veri"));
            }

            var result = await _salesInvoiceService.CreateInvoiceAsync(createInvoiceDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetInvoice), new { id = result.Data?.InvoiceID }, result);
        }

        /// <summary>
        /// Satış faturasını günceller
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager,Sales")]
        public async Task<ActionResult<ApiResponse<SalesInvoiceDto>>> UpdateInvoice(int id, [FromBody] UpdateSalesInvoiceDto updateInvoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<SalesInvoiceDto>.ErrorResult("Geçersiz veri"));
            }

            var result = await _salesInvoiceService.UpdateInvoiceAsync(id, updateInvoiceDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Satış faturasını siler
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteInvoice(int id)
        {
            var result = await _salesInvoiceService.DeleteInvoiceAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Satış faturasını onaylar
        /// </summary>
        [HttpPost("{id}/approve")]
        [Authorize(Roles = "Admin,Manager,Sales")]
        public async Task<ActionResult<ApiResponse<bool>>> ApproveInvoice(int id, [FromBody] InvoiceApprovalDto approvalDto)
        {
            var result = await _salesInvoiceService.ApproveInvoiceAsync(id, approvalDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Satış faturasını iptal eder
        /// </summary>
        [HttpPost("{id}/cancel")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> CancelInvoice(int id, [FromBody] InvoiceCancellationDto cancellationDto)
        {
            var result = await _salesInvoiceService.CancelInvoiceAsync(id, cancellationDto.Reason);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Fatura toplamlarını yeniden hesaplar
        /// </summary>
        [HttpPost("{id}/update-totals")]
        [Authorize(Roles = "Admin,Manager,Sales")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateInvoiceTotals(int id)
        {
            var result = await _salesInvoiceService.UpdateInvoiceTotalsAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Cari hesaba göre satış faturalarını getirir
        /// </summary>
        [HttpGet("by-cari/{cariId}")]
        public async Task<ActionResult<ApiResponse<PagedResult<SalesInvoiceDto>>>> GetInvoicesByCari(int cariId, [FromQuery] PaginationParameters parameters)
        {
            var result = await _salesInvoiceService.GetInvoicesByCariAsync(cariId, parameters);
            return Ok(result);
        }

        /// <summary>
        /// Duruma göre satış faturalarını getirir
        /// </summary>
        [HttpGet("by-status/{status}")]
        public async Task<ActionResult<ApiResponse<PagedResult<SalesInvoiceDto>>>> GetInvoicesByStatus(string status, [FromQuery] PaginationParameters parameters)
        {
            var result = await _salesInvoiceService.GetInvoicesByStatusAsync(status, parameters);
            return Ok(result);
        }

        /// <summary>
        /// Tarih aralığına göre satış faturalarını getirir
        /// </summary>
        [HttpGet("by-date-range")]
        public async Task<ActionResult<ApiResponse<PagedResult<SalesInvoiceDto>>>> GetInvoicesByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] PaginationParameters parameters)
        {
            var result = await _salesInvoiceService.GetInvoicesByDateRangeAsync(startDate, endDate, parameters);
            return Ok(result);
        }

        /// <summary>
        /// Taslak faturaları getirir
        /// </summary>
        [HttpGet("drafts")]
        public async Task<ActionResult<ApiResponse<List<SalesInvoiceDto>>>> GetDraftInvoices()
        {
            var result = await _salesInvoiceService.GetDraftInvoicesAsync();
            return Ok(result);
        }

        /// <summary>
        /// Onaylanmış faturaları getirir
        /// </summary>
        [HttpGet("approved")]
        public async Task<ActionResult<ApiResponse<List<SalesInvoiceDto>>>> GetApprovedInvoices()
        {
            var result = await _salesInvoiceService.GetApprovedInvoicesAsync();
            return Ok(result);
        }

        /// <summary>
        /// Satış faturası özetini getirir
        /// </summary>
        [HttpGet("summary")]
        public async Task<ActionResult<ApiResponse<InvoiceSummaryDto>>> GetInvoiceSummary([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var result = await _salesInvoiceService.GetInvoiceSummaryAsync(fromDate, toDate);
            return Ok(result);
        }

        /// <summary>
        /// Toplam satış tutarını getirir
        /// </summary>
        [HttpGet("total-amount")]
        public async Task<ActionResult<ApiResponse<decimal>>> GetTotalSalesAmount([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var result = await _salesInvoiceService.GetTotalSalesAmountAsync(fromDate, toDate);
            return Ok(result);
        }

        /// <summary>
        /// Fatura sayısını getirir
        /// </summary>
        [HttpGet("count")]
        public async Task<ActionResult<ApiResponse<int>>> GetInvoiceCount([FromQuery] string? status)
        {
            var result = await _salesInvoiceService.GetInvoiceCountAsync(status);
            return Ok(result);
        }

    }
} 