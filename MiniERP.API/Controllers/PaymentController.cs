using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.API.DTOs;
using MiniERP.API.Services;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        /// <summary>
        /// Tüm ödemeleri getir (Finance, Admin, Manager yetkisi gerekir)
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<PagedResult<PaymentDto>>>> GetPayments(
            [FromQuery] PaginationParameters parameters,
            [FromQuery] string? searchTerm = null,
            [FromQuery] int? cariId = null,
            [FromQuery] int? paymentTypeId = null,
            [FromQuery] string? status = null)
        {
            var result = await _paymentService.GetPaymentsAsync(parameters, searchTerm, cariId, paymentTypeId, status);
            return Ok(result);
        }

        /// <summary>
        /// ID'ye göre ödeme getir
        /// </summary>
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<PaymentDto>>> GetPayment(int id)
        {
            var result = await _paymentService.GetPaymentByIdAsync(id);
            
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Yeni ödeme oluştur
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<PaymentDto>>> CreatePayment([FromBody] CreatePaymentDto createPaymentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<PaymentDto>.ErrorResult("Invalid input data"));
            }

            var result = await _paymentService.CreatePaymentAsync(createPaymentDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetPayment), new { id = result.Data?.PaymentID }, result);
        }

        /// <summary>
        /// Ödeme bilgilerini güncelle
        /// </summary>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<PaymentDto>>> UpdatePayment(int id, [FromBody] UpdatePaymentDto updatePaymentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<PaymentDto>.ErrorResult("Invalid input data"));
            }

            var result = await _paymentService.UpdatePaymentAsync(id, updatePaymentDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Ödeme sil
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Finance")]
        public async Task<ActionResult<ApiResponse<bool>>> DeletePayment(int id)
        {
            var result = await _paymentService.DeletePaymentAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Cari hesaba göre ödemeleri getir
        /// </summary>
        [HttpGet("by-cari/{cariId:int}")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<List<PaymentDto>>>> GetPaymentsByCari(int cariId)
        {
            var result = await _paymentService.GetPaymentsByCariIdAsync(cariId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Tarih aralığına göre ödemeleri getir
        /// </summary>
        [HttpGet("by-date-range")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<List<PaymentDto>>>> GetPaymentsByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var result = await _paymentService.GetPaymentsByDateRangeAsync(startDate, endDate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Son ödemeleri getir
        /// </summary>
        [HttpGet("recent")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<List<PaymentDto>>>> GetRecentPayments([FromQuery] int count = 10)
        {
            var result = await _paymentService.GetRecentPaymentsAsync(count);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Cari hesap toplam ödeme miktarını getir
        /// </summary>
        [HttpGet("total-amount/{cariId:int}")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<decimal>>> GetTotalPaymentAmount(int cariId)
        {
            var result = await _paymentService.GetTotalPaymentAmountAsync(cariId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Ödeme özetini getir
        /// </summary>
        [HttpGet("summary")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<PaymentSummaryDto>>> GetPaymentSummary(
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            var result = await _paymentService.GetPaymentSummaryAsync(startDate, endDate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Duruma göre ödemeleri getir
        /// </summary>
        [HttpGet("by-status/{status}")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<List<PaymentDto>>>> GetPaymentsByStatus(string status)
        {
            var result = await _paymentService.GetPaymentsByStatusAsync(status);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Ödemeyi onayla
        /// </summary>
        [HttpPost("{id:int}/approve")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<bool>>> ApprovePayment(int id)
        {
            var result = await _paymentService.ApprovePaymentAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Ödemeyi iptal et
        /// </summary>
        [HttpPost("{id:int}/cancel")]
        [Authorize(Roles = "Admin,Finance")]
        public async Task<ActionResult<ApiResponse<bool>>> CancelPayment(int id)
        {
            var result = await _paymentService.CancelPaymentAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
} 