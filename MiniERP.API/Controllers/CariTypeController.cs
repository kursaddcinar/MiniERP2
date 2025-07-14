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
    public class CariTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CariTypeController> _logger;

        public CariTypeController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CariTypeController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Tüm cari türlerini getir
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Sales,Purchase,Finance")]
        public async Task<ActionResult<ApiResponse<List<CariTypeDto>>>> GetCariTypes()
        {
            try
            {
                var cariTypes = await _unitOfWork.CariTypes.GetAllAsync();
                var cariTypeDtos = _mapper.Map<List<CariTypeDto>>(cariTypes);
                
                return Ok(ApiResponse<List<CariTypeDto>>.SuccessResult(cariTypeDtos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cari types");
                return BadRequest(ApiResponse<List<CariTypeDto>>.ErrorResult("An error occurred while getting cari types"));
            }
        }

        /// <summary>
        /// Aktif cari türlerini getir
        /// </summary>
        [HttpGet("active")]
        [Authorize(Roles = "Admin,Manager,Sales,Purchase,Finance")]
        public async Task<ActionResult<ApiResponse<List<CariTypeDto>>>> GetActiveCariTypes()
        {
            try
            {
                var cariTypes = await _unitOfWork.CariTypes.FindAsync(ct => ct.IsActive);
                var cariTypeDtos = _mapper.Map<List<CariTypeDto>>(cariTypes);
                
                return Ok(ApiResponse<List<CariTypeDto>>.SuccessResult(cariTypeDtos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting active cari types");
                return BadRequest(ApiResponse<List<CariTypeDto>>.ErrorResult("An error occurred while getting active cari types"));
            }
        }

        /// <summary>
        /// ID'ye göre cari türü getir
        /// </summary>
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Manager,Sales,Purchase,Finance")]
        public async Task<ActionResult<ApiResponse<CariTypeDto>>> GetCariType(int id)
        {
            try
            {
                var cariType = await _unitOfWork.CariTypes.GetByIdAsync(id);
                if (cariType == null)
                {
                    return NotFound(ApiResponse<CariTypeDto>.ErrorResult("Cari type not found"));
                }

                var cariTypeDto = _mapper.Map<CariTypeDto>(cariType);
                return Ok(ApiResponse<CariTypeDto>.SuccessResult(cariTypeDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cari type {CariTypeId}", id);
                return BadRequest(ApiResponse<CariTypeDto>.ErrorResult("An error occurred while getting cari type"));
            }
        }

        /// <summary>
        /// Yeni cari türü oluştur
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<CariTypeDto>>> CreateCariType([FromBody] CreateCariTypeDto createCariTypeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<CariTypeDto>.ErrorResult("Invalid input data"));
                }

                // Check if type code is unique
                var existingCariType = await _unitOfWork.CariTypes.FindAsync(ct => ct.TypeCode == createCariTypeDto.TypeCode);
                if (existingCariType.Any())
                {
                    return BadRequest(ApiResponse<CariTypeDto>.ErrorResult("Cari type code already exists"));
                }

                var cariType = _mapper.Map<CariType>(createCariTypeDto);
                cariType.IsActive = true;
                cariType.CreatedDate = DateTime.Now;

                await _unitOfWork.CariTypes.AddAsync(cariType);
                await _unitOfWork.SaveChangesAsync();

                var cariTypeDto = _mapper.Map<CariTypeDto>(cariType);
                _logger.LogInformation("Cari type {TypeCode} created successfully", createCariTypeDto.TypeCode);
                
                return CreatedAtAction(nameof(GetCariType), new { id = cariType.TypeID }, 
                    ApiResponse<CariTypeDto>.SuccessResult(cariTypeDto, "Cari type created successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating cari type {TypeCode}", createCariTypeDto.TypeCode);
                return BadRequest(ApiResponse<CariTypeDto>.ErrorResult("An error occurred while creating cari type"));
            }
        }

        /// <summary>
        /// Cari türü güncelle
        /// </summary>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<CariTypeDto>>> UpdateCariType(int id, [FromBody] UpdateCariTypeDto updateCariTypeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<CariTypeDto>.ErrorResult("Invalid input data"));
                }

                var cariType = await _unitOfWork.CariTypes.GetByIdAsync(id);
                if (cariType == null)
                {
                    return NotFound(ApiResponse<CariTypeDto>.ErrorResult("Cari type not found"));
                }

                // TypeCode is not updatable, so no need to check uniqueness for update

                _mapper.Map(updateCariTypeDto, cariType);
                await _unitOfWork.CariTypes.UpdateAsync(cariType);
                await _unitOfWork.SaveChangesAsync();

                var cariTypeDto = _mapper.Map<CariTypeDto>(cariType);
                _logger.LogInformation("Cari type {CariTypeId} updated successfully", id);
                
                return Ok(ApiResponse<CariTypeDto>.SuccessResult(cariTypeDto, "Cari type updated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating cari type {CariTypeId}", id);
                return BadRequest(ApiResponse<CariTypeDto>.ErrorResult("An error occurred while updating cari type"));
            }
        }

        /// <summary>
        /// Cari türü sil
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteCariType(int id)
        {
            try
            {
                var cariType = await _unitOfWork.CariTypes.GetByIdAsync(id);
                if (cariType == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResult("Cari type not found"));
                }

                // Check if cari type is being used in cari accounts
                var hasCariAccounts = await _unitOfWork.CariAccounts.FindAsync(ca => ca.TypeID == id);
                if (hasCariAccounts.Any())
                {
                    return BadRequest(ApiResponse<bool>.ErrorResult("Cannot delete cari type. It is being used in cari accounts."));
                }

                await _unitOfWork.CariTypes.DeleteAsync(cariType);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Cari type {CariTypeId} deleted successfully", id);
                return Ok(ApiResponse<bool>.SuccessResult(true, "Cari type deleted successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting cari type {CariTypeId}", id);
                return BadRequest(ApiResponse<bool>.ErrorResult("An error occurred while deleting cari type"));
            }
        }

        /// <summary>
        /// Cari türünü aktif et
        /// </summary>
        [HttpPost("{id:int}/activate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> ActivateCariType(int id)
        {
            try
            {
                var cariType = await _unitOfWork.CariTypes.GetByIdAsync(id);
                if (cariType == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResult("Cari type not found"));
                }

                cariType.IsActive = true;
                await _unitOfWork.CariTypes.UpdateAsync(cariType);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Cari type {CariTypeId} activated successfully", id);
                return Ok(ApiResponse<bool>.SuccessResult(true, "Cari type activated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error activating cari type {CariTypeId}", id);
                return BadRequest(ApiResponse<bool>.ErrorResult("An error occurred while activating cari type"));
            }
        }

        /// <summary>
        /// Cari türünü pasif et
        /// </summary>
        [HttpPost("{id:int}/deactivate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> DeactivateCariType(int id)
        {
            try
            {
                var cariType = await _unitOfWork.CariTypes.GetByIdAsync(id);
                if (cariType == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResult("Cari type not found"));
                }

                cariType.IsActive = false;
                await _unitOfWork.CariTypes.UpdateAsync(cariType);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Cari type {CariTypeId} deactivated successfully", id);
                return Ok(ApiResponse<bool>.SuccessResult(true, "Cari type deactivated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deactivating cari type {CariTypeId}", id);
                return BadRequest(ApiResponse<bool>.ErrorResult("An error occurred while deactivating cari type"));
            }
        }
    }
} 