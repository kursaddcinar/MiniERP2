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
    public class UnitController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UnitController> _logger;

        public UnitController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UnitController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Tüm birimleri getir
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Sales,Purchase,Warehouse")]
        public async Task<ActionResult<ApiResponse<List<UnitDto>>>> GetUnits()
        {
            try
            {
                var units = await _unitOfWork.Units.GetAllAsync();
                var unitDtos = _mapper.Map<List<UnitDto>>(units);
                
                return Ok(ApiResponse<List<UnitDto>>.SuccessResult(unitDtos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting units");
                return BadRequest(ApiResponse<List<UnitDto>>.ErrorResult("An error occurred while getting units"));
            }
        }

        /// <summary>
        /// Aktif birimleri getir
        /// </summary>
        [HttpGet("active")]
        [Authorize(Roles = "Admin,Manager,Sales,Purchase,Warehouse")]
        public async Task<ActionResult<ApiResponse<List<UnitDto>>>> GetActiveUnits()
        {
            try
            {
                var units = await _unitOfWork.Units.FindAsync(u => u.IsActive);
                var unitDtos = _mapper.Map<List<UnitDto>>(units);
                
                return Ok(ApiResponse<List<UnitDto>>.SuccessResult(unitDtos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting active units");
                return BadRequest(ApiResponse<List<UnitDto>>.ErrorResult("An error occurred while getting active units"));
            }
        }

        /// <summary>
        /// ID'ye göre birim getir
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<UnitDto>>> GetUnit(int id)
        {
            try
            {
                var unit = await _unitOfWork.Units.GetByIdAsync(id);
                if (unit == null)
                {
                    return NotFound(ApiResponse<UnitDto>.ErrorResult("Unit not found"));
                }

                var unitDto = _mapper.Map<UnitDto>(unit);
                return Ok(ApiResponse<UnitDto>.SuccessResult(unitDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting unit {UnitId}", id);
                return BadRequest(ApiResponse<UnitDto>.ErrorResult("An error occurred while getting unit"));
            }
        }

        /// <summary>
        /// Yeni birim oluştur
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<UnitDto>>> CreateUnit([FromBody] CreateUnitDto createUnitDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<UnitDto>.ErrorResult("Invalid input data"));
                }

                // Check if unit code is unique
                var existingUnit = await _unitOfWork.Units.FindAsync(u => u.UnitCode == createUnitDto.UnitCode);
                if (existingUnit.Any())
                {
                    return BadRequest(ApiResponse<UnitDto>.ErrorResult("Unit code already exists"));
                }

                var unit = _mapper.Map<Unit>(createUnitDto);
                unit.IsActive = true;
                unit.CreatedDate = DateTime.Now;

                await _unitOfWork.Units.AddAsync(unit);
                await _unitOfWork.SaveChangesAsync();

                var unitDto = _mapper.Map<UnitDto>(unit);
                _logger.LogInformation("Unit {UnitCode} created successfully", createUnitDto.UnitCode);
                
                return CreatedAtAction(nameof(GetUnit), new { id = unit.UnitID }, 
                    ApiResponse<UnitDto>.SuccessResult(unitDto, "Unit created successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating unit {UnitCode}", createUnitDto.UnitCode);
                return BadRequest(ApiResponse<UnitDto>.ErrorResult("An error occurred while creating unit"));
            }
        }

        /// <summary>
        /// Birim güncelle
        /// </summary>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<UnitDto>>> UpdateUnit(int id, [FromBody] UpdateUnitDto updateUnitDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<UnitDto>.ErrorResult("Invalid input data"));
                }

                var unit = await _unitOfWork.Units.GetByIdAsync(id);
                if (unit == null)
                {
                    return NotFound(ApiResponse<UnitDto>.ErrorResult("Unit not found"));
                }

                // UnitCode is not updatable, so no need to check uniqueness for update

                _mapper.Map(updateUnitDto, unit);
                await _unitOfWork.Units.UpdateAsync(unit);
                await _unitOfWork.SaveChangesAsync();

                var unitDto = _mapper.Map<UnitDto>(unit);
                _logger.LogInformation("Unit {UnitId} updated successfully", id);
                
                return Ok(ApiResponse<UnitDto>.SuccessResult(unitDto, "Unit updated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating unit {UnitId}", id);
                return BadRequest(ApiResponse<UnitDto>.ErrorResult("An error occurred while updating unit"));
            }
        }

        /// <summary>
        /// Birim sil
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteUnit(int id)
        {
            try
            {
                var unit = await _unitOfWork.Units.GetByIdAsync(id);
                if (unit == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResult("Unit not found"));
                }

                // Check if unit is being used in products
                var hasProducts = await _unitOfWork.Products.FindAsync(p => p.UnitID == id);
                if (hasProducts.Any())
                {
                    return BadRequest(ApiResponse<bool>.ErrorResult("Cannot delete unit. It is being used in products."));
                }

                await _unitOfWork.Units.DeleteAsync(unit);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Unit {UnitId} deleted successfully", id);
                return Ok(ApiResponse<bool>.SuccessResult(true, "Unit deleted successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting unit {UnitId}", id);
                return BadRequest(ApiResponse<bool>.ErrorResult("An error occurred while deleting unit"));
            }
        }

        /// <summary>
        /// Birimi aktif et
        /// </summary>
        [HttpPost("{id:int}/activate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> ActivateUnit(int id)
        {
            try
            {
                var unit = await _unitOfWork.Units.GetByIdAsync(id);
                if (unit == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResult("Unit not found"));
                }

                unit.IsActive = true;
                await _unitOfWork.Units.UpdateAsync(unit);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Unit {UnitId} activated successfully", id);
                return Ok(ApiResponse<bool>.SuccessResult(true, "Unit activated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error activating unit {UnitId}", id);
                return BadRequest(ApiResponse<bool>.ErrorResult("An error occurred while activating unit"));
            }
        }

        /// <summary>
        /// Birimi pasif et
        /// </summary>
        [HttpPost("{id:int}/deactivate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> DeactivateUnit(int id)
        {
            try
            {
                var unit = await _unitOfWork.Units.GetByIdAsync(id);
                if (unit == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResult("Unit not found"));
                }

                unit.IsActive = false;
                await _unitOfWork.Units.UpdateAsync(unit);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Unit {UnitId} deactivated successfully", id);
                return Ok(ApiResponse<bool>.SuccessResult(true, "Unit deactivated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deactivating unit {UnitId}", id);
                return BadRequest(ApiResponse<bool>.ErrorResult("An error occurred while deactivating unit"));
            }
        }
    }
} 