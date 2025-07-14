using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.API.DTOs;
using MiniERP.API.Services;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService _collectionService;
        private readonly ILogger<CollectionController> _logger;

        public CollectionController(ICollectionService collectionService, ILogger<CollectionController> logger)
        {
            _collectionService = collectionService;
            _logger = logger;
        }

        /// <summary>
        /// Tüm tahsilatları getir (Finance, Admin, Manager yetkisi gerekir)
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<PagedResult<CollectionDto>>>> GetCollections(
            [FromQuery] PaginationParameters parameters,
            [FromQuery] string? searchTerm = null,
            [FromQuery] int? cariId = null,
            [FromQuery] int? paymentTypeId = null,
            [FromQuery] string? status = null)
        {
            var result = await _collectionService.GetCollectionsAsync(parameters, searchTerm, cariId, paymentTypeId, status);
            return Ok(result);
        }

        /// <summary>
        /// ID'ye göre tahsilat getir
        /// </summary>
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<CollectionDto>>> GetCollection(int id)
        {
            var result = await _collectionService.GetCollectionByIdAsync(id);
            
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Yeni tahsilat oluştur
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<CollectionDto>>> CreateCollection([FromBody] CreateCollectionDto createCollectionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<CollectionDto>.ErrorResult("Invalid input data"));
            }

            var result = await _collectionService.CreateCollectionAsync(createCollectionDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetCollection), new { id = result.Data?.CollectionID }, result);
        }

        /// <summary>
        /// Tahsilat bilgilerini güncelle
        /// </summary>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<CollectionDto>>> UpdateCollection(int id, [FromBody] UpdateCollectionDto updateCollectionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<CollectionDto>.ErrorResult("Invalid input data"));
            }

            var result = await _collectionService.UpdateCollectionAsync(id, updateCollectionDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Tahsilat sil
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Finance")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteCollection(int id)
        {
            var result = await _collectionService.DeleteCollectionAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Cari hesaba göre tahsilatları getir
        /// </summary>
        [HttpGet("by-cari/{cariId:int}")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<List<CollectionDto>>>> GetCollectionsByCari(int cariId)
        {
            var result = await _collectionService.GetCollectionsByCariIdAsync(cariId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Tarih aralığına göre tahsilatları getir
        /// </summary>
        [HttpGet("by-date-range")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<List<CollectionDto>>>> GetCollectionsByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var result = await _collectionService.GetCollectionsByDateRangeAsync(startDate, endDate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Son tahsilatları getir
        /// </summary>
        [HttpGet("recent")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<List<CollectionDto>>>> GetRecentCollections([FromQuery] int count = 10)
        {
            var result = await _collectionService.GetRecentCollectionsAsync(count);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Cari hesap toplam tahsilat miktarını getir
        /// </summary>
        [HttpGet("total-amount/{cariId:int}")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<decimal>>> GetTotalCollectionAmount(int cariId)
        {
            var result = await _collectionService.GetTotalCollectionAmountAsync(cariId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Duruma göre tahsilatları getir
        /// </summary>
        [HttpGet("by-status/{status}")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<List<CollectionDto>>>> GetCollectionsByStatus(string status)
        {
            var result = await _collectionService.GetCollectionsByStatusAsync(status);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Tahsilatı onayla
        /// </summary>
        [HttpPost("{id:int}/approve")]
        [Authorize(Roles = "Admin,Manager,Finance")]
        public async Task<ActionResult<ApiResponse<bool>>> ApproveCollection(int id)
        {
            var result = await _collectionService.ApproveCollectionAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Tahsilatı iptal et
        /// </summary>
        [HttpPost("{id:int}/cancel")]
        [Authorize(Roles = "Admin,Finance")]
        public async Task<ActionResult<ApiResponse<bool>>> CancelCollection(int id)
        {
            var result = await _collectionService.CancelCollectionAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
} 