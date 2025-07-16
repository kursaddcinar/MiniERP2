using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.API.DTOs;
using MiniERP.API.Services;

namespace MiniERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PurchaseInvoicesController : ControllerBase
    {
        private readonly IPurchaseInvoiceService _purchaseInvoiceService;

        public PurchaseInvoicesController(IPurchaseInvoiceService purchaseInvoiceService)
        {
            _purchaseInvoiceService = purchaseInvoiceService;
        }

        /// <summary>
        /// Tüm alış faturalarını sayfalı olarak getirir
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Purchase,Finance")]
        public async Task<ActionResult<ApiResponse<PagedResult<PurchaseInvoiceDto>>>> GetInvoices([FromQuery] PaginationParameters parameters)
        {
            var result = await _purchaseInvoiceService.GetInvoicesAsync(parameters);
            return Ok(result);
        }

        /// <summary>
        /// ID'ye göre alış faturası getirir
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,Purchase,Finance")]
        public async Task<ActionResult<ApiResponse<PurchaseInvoiceDto>>> GetInvoice(int id)
        {
            var result = await _purchaseInvoiceService.GetInvoiceByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Fatura numarasına göre alış faturası getirir
        /// </summary>
        [HttpGet("by-invoice-no/{invoiceNo}")]
        public async Task<ActionResult<ApiResponse<PurchaseInvoiceDto>>> GetInvoiceByNo(string invoiceNo)
        {
            var result = await _purchaseInvoiceService.GetInvoiceByNoAsync(invoiceNo);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Alış faturası detayları ile birlikte getirir
        /// </summary>
        [HttpGet("{id}/details")]
        public async Task<ActionResult<ApiResponse<PurchaseInvoiceDto>>> GetInvoiceWithDetails(int id)
        {
            var result = await _purchaseInvoiceService.GetInvoiceWithDetailsAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Yeni alış faturası oluşturur
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Purchase")]
        public async Task<ActionResult<ApiResponse<PurchaseInvoiceDto>>> CreateInvoice([FromBody] CreatePurchaseInvoiceDto createInvoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<PurchaseInvoiceDto>.ErrorResult("Geçersiz veri"));
            }

            var result = await _purchaseInvoiceService.CreateInvoiceAsync(createInvoiceDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetInvoice), new { id = result.Data?.InvoiceID }, result);
        }

        /// <summary>
        /// Alış faturasını günceller
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager,Purchase")]
        public async Task<ActionResult<ApiResponse<PurchaseInvoiceDto>>> UpdateInvoice(int id, [FromBody] UpdatePurchaseInvoiceDto updateInvoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<PurchaseInvoiceDto>.ErrorResult("Geçersiz veri"));
            }

            var result = await _purchaseInvoiceService.UpdateInvoiceAsync(id, updateInvoiceDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Alış faturasını siler
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager,Purchase")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteInvoice(int id)
        {
            var result = await _purchaseInvoiceService.DeleteInvoiceAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Alış faturasını onaylar
        /// </summary>
        [HttpPost("{id}/approve")]
        [Authorize(Roles = "Admin,Manager,Purchase")]
        public async Task<ActionResult<ApiResponse<bool>>> ApproveInvoice(int id, [FromBody] InvoiceApprovalDto approvalDto)
        {
            var result = await _purchaseInvoiceService.ApproveInvoiceAsync(id, approvalDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Alış faturasını iptal eder
        /// </summary>
        [HttpPost("{id}/cancel")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> CancelInvoice(int id, [FromBody] InvoiceCancellationDto cancellationDto)
        {
            var result = await _purchaseInvoiceService.CancelInvoiceAsync(id, cancellationDto.Reason);
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
        [Authorize(Roles = "Admin,Manager,Purchase")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateInvoiceTotals(int id)
        {
            var result = await _purchaseInvoiceService.UpdateInvoiceTotalsAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Cari hesaba göre alış faturalarını getirir
        /// </summary>
        [HttpGet("by-cari/{cariId}")]
        public async Task<ActionResult<ApiResponse<PagedResult<PurchaseInvoiceDto>>>> GetInvoicesByCari(int cariId, [FromQuery] PaginationParameters parameters)
        {
            var result = await _purchaseInvoiceService.GetInvoicesByCariAsync(cariId, parameters);
            return Ok(result);
        }

        /// <summary>
        /// Duruma göre alış faturalarını getirir
        /// </summary>
        [HttpGet("by-status/{status}")]
        public async Task<ActionResult<ApiResponse<PagedResult<PurchaseInvoiceDto>>>> GetInvoicesByStatus(string status, [FromQuery] PaginationParameters parameters)
        {
            var result = await _purchaseInvoiceService.GetInvoicesByStatusAsync(status, parameters);
            return Ok(result);
        }

        /// <summary>
        /// Tarih aralığına göre alış faturalarını getirir
        /// </summary>
        [HttpGet("by-date-range")]
        public async Task<ActionResult<ApiResponse<PagedResult<PurchaseInvoiceDto>>>> GetInvoicesByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] PaginationParameters parameters)
        {
            var result = await _purchaseInvoiceService.GetInvoicesByDateRangeAsync(startDate, endDate, parameters);
            return Ok(result);
        }

        /// <summary>
        /// Taslak faturaları getirir
        /// </summary>
        [HttpGet("drafts")]
        public async Task<ActionResult<ApiResponse<List<PurchaseInvoiceDto>>>> GetDraftInvoices()
        {
            var result = await _purchaseInvoiceService.GetDraftInvoicesAsync();
            return Ok(result);
        }

        /// <summary>
        /// Onaylanmış faturaları getirir
        /// </summary>
        [HttpGet("approved")]
        public async Task<ActionResult<ApiResponse<List<PurchaseInvoiceDto>>>> GetApprovedInvoices()
        {
            var result = await _purchaseInvoiceService.GetApprovedInvoicesAsync();
            return Ok(result);
        }

        /// <summary>
        /// Alış faturası özetini getirir
        /// </summary>
        [HttpGet("summary")]
        public async Task<ActionResult<ApiResponse<InvoiceSummaryDto>>> GetInvoiceSummary([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var result = await _purchaseInvoiceService.GetInvoiceSummaryAsync(fromDate, toDate);
            return Ok(result);
        }

        /// <summary>
        /// Toplam alış tutarını getirir
        /// </summary>
        [HttpGet("total-amount")]
        public async Task<ActionResult<ApiResponse<decimal>>> GetTotalPurchaseAmount([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var result = await _purchaseInvoiceService.GetTotalPurchaseAmountAsync(fromDate, toDate);
            return Ok(result);
        }

        /// <summary>
        /// Fatura sayısını getirir
        /// </summary>
        [HttpGet("count")]
        public async Task<ActionResult<ApiResponse<int>>> GetInvoiceCount([FromQuery] string? status)
        {
            var result = await _purchaseInvoiceService.GetInvoiceCountAsync(status);
            return Ok(result);
        }

        /// <summary>
        /// Yeni fatura numarası üretir
        /// </summary>
        [HttpGet("generate-invoice-no")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<string>>> GenerateInvoiceNo()
        {
            var result = await _purchaseInvoiceService.GenerateInvoiceNoAsync();
            return Ok(result);
        }
    }
} 