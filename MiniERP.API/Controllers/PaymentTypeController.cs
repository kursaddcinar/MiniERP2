using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.API.DTOs;
using MiniERP.API.Models;
using MiniERP.API.Repositories;
using AutoMapper;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PaymentTypeController> _logger;

        public PaymentTypeController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PaymentTypeController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Tüm ödeme türlerini getir
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<List<PaymentTypeDto>>>> GetPaymentTypes()
        {
            try
            {
                var paymentTypes = await _unitOfWork.PaymentTypes.GetAllAsync();
                var paymentTypeDtos = _mapper.Map<List<PaymentTypeDto>>(paymentTypes);
                
                return Ok(ApiResponse<List<PaymentTypeDto>>.SuccessResult(paymentTypeDtos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payment types");
                return BadRequest(ApiResponse<List<PaymentTypeDto>>.ErrorResult("An error occurred while getting payment types"));
            }
        }

        /// <summary>
        /// Aktif ödeme türlerini getir
        /// </summary>
        [HttpGet("active")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<List<PaymentTypeDto>>>> GetActivePaymentTypes()
        {
            try
            {
                var paymentTypes = await _unitOfWork.PaymentTypes.FindAsync(pt => pt.IsActive);
                var paymentTypeDtos = _mapper.Map<List<PaymentTypeDto>>(paymentTypes);
                
                return Ok(ApiResponse<List<PaymentTypeDto>>.SuccessResult(paymentTypeDtos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting active payment types");
                return BadRequest(ApiResponse<List<PaymentTypeDto>>.ErrorResult("An error occurred while getting active payment types"));
            }
        }

        /// <summary>
        /// ID'ye göre ödeme türü getir
        /// </summary>
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<PaymentTypeDto>>> GetPaymentType(int id)
        {
            try
            {
                var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(id);
                if (paymentType == null)
                {
                    return NotFound(ApiResponse<PaymentTypeDto>.ErrorResult("Payment type not found"));
                }

                var paymentTypeDto = _mapper.Map<PaymentTypeDto>(paymentType);
                return Ok(ApiResponse<PaymentTypeDto>.SuccessResult(paymentTypeDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payment type {PaymentTypeId}", id);
                return BadRequest(ApiResponse<PaymentTypeDto>.ErrorResult("An error occurred while getting payment type"));
            }
        }

        /// <summary>
        /// Yeni ödeme türü oluştur
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<PaymentTypeDto>>> CreatePaymentType([FromBody] CreatePaymentTypeDto createPaymentTypeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<PaymentTypeDto>.ErrorResult("Invalid input data"));
                }

                // Check if type code is unique
                var existingPaymentType = await _unitOfWork.PaymentTypes.FindAsync(pt => pt.TypeCode == createPaymentTypeDto.TypeCode);
                if (existingPaymentType.Any())
                {
                    return BadRequest(ApiResponse<PaymentTypeDto>.ErrorResult("Payment type code already exists"));
                }

                var paymentType = _mapper.Map<PaymentType>(createPaymentTypeDto);
                paymentType.IsActive = true;
                paymentType.CreatedDate = DateTime.Now;

                await _unitOfWork.PaymentTypes.AddAsync(paymentType);
                await _unitOfWork.SaveChangesAsync();

                var paymentTypeDto = _mapper.Map<PaymentTypeDto>(paymentType);
                _logger.LogInformation("Payment type {TypeCode} created successfully", createPaymentTypeDto.TypeCode);
                
                return CreatedAtAction(nameof(GetPaymentType), new { id = paymentType.PaymentTypeID }, 
                    ApiResponse<PaymentTypeDto>.SuccessResult(paymentTypeDto, "Payment type created successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating payment type {TypeCode}", createPaymentTypeDto.TypeCode);
                return BadRequest(ApiResponse<PaymentTypeDto>.ErrorResult("An error occurred while creating payment type"));
            }
        }

        /// <summary>
        /// Ödeme türünü güncelle
        /// </summary>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<PaymentTypeDto>>> UpdatePaymentType(int id, [FromBody] UpdatePaymentTypeDto updatePaymentTypeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<PaymentTypeDto>.ErrorResult("Invalid input data"));
                }

                var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(id);
                if (paymentType == null)
                {
                    return NotFound(ApiResponse<PaymentTypeDto>.ErrorResult("Payment type not found"));
                }

                _mapper.Map(updatePaymentTypeDto, paymentType);
                await _unitOfWork.PaymentTypes.UpdateAsync(paymentType);
                await _unitOfWork.SaveChangesAsync();

                var paymentTypeDto = _mapper.Map<PaymentTypeDto>(paymentType);
                _logger.LogInformation("Payment type {PaymentTypeId} updated successfully", id);
                
                return Ok(ApiResponse<PaymentTypeDto>.SuccessResult(paymentTypeDto, "Payment type updated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating payment type {PaymentTypeId}", id);
                return BadRequest(ApiResponse<PaymentTypeDto>.ErrorResult("An error occurred while updating payment type"));
            }
        }

        /// <summary>
        /// Ödeme türünü sil
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeletePaymentType(int id)
        {
            try
            {
                var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(id);
                if (paymentType == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResult("Payment type not found"));
                }

                // Check if payment type is being used in payments or collections
                var hasPayments = await _unitOfWork.Payments.FindAsync(p => p.PaymentTypeID == id);
                var hasCollections = await _unitOfWork.Collections.FindAsync(c => c.PaymentTypeID == id);
                
                if (hasPayments.Any() || hasCollections.Any())
                {
                    return BadRequest(ApiResponse<bool>.ErrorResult("Cannot delete payment type. It is being used in payments or collections."));
                }

                await _unitOfWork.PaymentTypes.DeleteAsync(paymentType);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Payment type {PaymentTypeId} deleted successfully", id);
                return Ok(ApiResponse<bool>.SuccessResult(true, "Payment type deleted successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting payment type {PaymentTypeId}", id);
                return BadRequest(ApiResponse<bool>.ErrorResult("An error occurred while deleting payment type"));
            }
        }

        /// <summary>
        /// Ödeme türünü aktif et
        /// </summary>
        [HttpPost("{id:int}/activate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> ActivatePaymentType(int id)
        {
            try
            {
                var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(id);
                if (paymentType == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResult("Payment type not found"));
                }

                paymentType.IsActive = true;
                await _unitOfWork.PaymentTypes.UpdateAsync(paymentType);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Payment type {PaymentTypeId} activated successfully", id);
                return Ok(ApiResponse<bool>.SuccessResult(true, "Payment type activated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error activating payment type {PaymentTypeId}", id);
                return BadRequest(ApiResponse<bool>.ErrorResult("An error occurred while activating payment type"));
            }
        }

        /// <summary>
        /// Ödeme türünü pasif et
        /// </summary>
        [HttpPost("{id:int}/deactivate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> DeactivatePaymentType(int id)
        {
            try
            {
                var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(id);
                if (paymentType == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResult("Payment type not found"));
                }

                paymentType.IsActive = false;
                await _unitOfWork.PaymentTypes.UpdateAsync(paymentType);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Payment type {PaymentTypeId} deactivated successfully", id);
                return Ok(ApiResponse<bool>.SuccessResult(true, "Payment type deactivated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deactivating payment type {PaymentTypeId}", id);
                return BadRequest(ApiResponse<bool>.ErrorResult("An error occurred while deactivating payment type"));
            }
        }
    }
} 