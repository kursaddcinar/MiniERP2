using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.API.DTOs;
using MiniERP.API.Services;

namespace MiniERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        #region StockCard İşlemleri

        /// <summary>
        /// Tüm stok kartlarını sayfalı olarak getirir
        /// </summary>
        [HttpGet("cards")]
        [Authorize(Roles = "Admin,Manager,Warehouse,Sales,Purchase")]
        public async Task<ActionResult<ApiResponse<PagedResult<StockCardDto>>>> GetStockCards([FromQuery] PaginationParameters parameters)
        {
            var result = await _stockService.GetStockCardsAsync(parameters);
            return Ok(result);
        }

        /// <summary>
        /// ID'ye göre stok kartı getirir
        /// </summary>
        [HttpGet("cards/{id}")]
        [Authorize(Roles = "Admin,Manager,Warehouse,Sales,Purchase")]
        public async Task<ActionResult<ApiResponse<StockCardDto>>> GetStockCard(int id)
        {
            var result = await _stockService.GetStockCardByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Ürün ve depoya göre stok kartı getirir
        /// </summary>
        [HttpGet("cards/by-product-warehouse")]
        [Authorize(Roles = "Admin,Manager,Warehouse,Sales,Purchase")]
        public async Task<ActionResult<ApiResponse<StockCardDto>>> GetStockCardByProductAndWarehouse([FromQuery] int productId, [FromQuery] int warehouseId)
        {
            var result = await _stockService.GetStockCardByProductAndWarehouseAsync(productId, warehouseId);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Ürüne göre stok kartlarını getirir
        /// </summary>
        [HttpGet("cards/by-product/{productId}")]
        [Authorize(Roles = "Admin,Manager,Warehouse,Sales,Purchase")]
        public async Task<ActionResult<ApiResponse<List<StockCardDto>>>> GetStockCardsByProduct(int productId)
        {
            var result = await _stockService.GetStockCardsByProductIdAsync(productId);
            return Ok(result);
        }

        /// <summary>
        /// Depoya göre stok kartlarını getirir
        /// </summary>
        [HttpGet("cards/by-warehouse/{warehouseId}")]
        [Authorize(Roles = "Admin,Manager,Warehouse,Sales,Purchase")]
        public async Task<ActionResult<ApiResponse<List<StockCardDto>>>> GetStockCardsByWarehouse(int warehouseId)
        {
            var result = await _stockService.GetStockCardsByWarehouseIdAsync(warehouseId);
            return Ok(result);
        }

        /// <summary>
        /// Yeni stok kartı oluşturur
        /// </summary>
        [HttpPost("cards")]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        public async Task<ActionResult<ApiResponse<StockCardDto>>> CreateStockCard([FromBody] CreateStockCardDto createStockCardDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<StockCardDto>.ErrorResult("Geçersiz veri"));
            }

            var result = await _stockService.CreateStockCardAsync(createStockCardDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetStockCard), new { id = result.Data?.StockCardID }, result);
        }

        /// <summary>
        /// Stok kartını günceller
        /// </summary>
        [HttpPut("cards/{id}")]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        public async Task<ActionResult<ApiResponse<StockCardDto>>> UpdateStockCard(int id, [FromBody] UpdateStockCardDto updateStockCardDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<StockCardDto>.ErrorResult("Geçersiz veri"));
            }

            var result = await _stockService.UpdateStockCardAsync(id, updateStockCardDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Stok kartını siler
        /// </summary>
        [HttpDelete("cards/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteStockCard(int id)
        {
            var result = await _stockService.DeleteStockCardAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        #endregion

        #region Stok Durumu İşlemleri

        /// <summary>
        /// Kritik seviyedeki stokları getirir
        /// </summary>
        [HttpGet("cards/critical")]
        public async Task<ActionResult<ApiResponse<List<StockCardDto>>>> GetCriticalStockCards()
        {
            var result = await _stockService.GetCriticalStockCardsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Aşırı stok seviyesindeki ürünleri getirir
        /// </summary>
        [HttpGet("cards/over-stock")]
        public async Task<ActionResult<ApiResponse<List<StockCardDto>>>> GetOverStockCards()
        {
            var result = await _stockService.GetOverStockCardsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Stokta tükenen ürünleri getirir
        /// </summary>
        [HttpGet("cards/out-of-stock")]
        public async Task<ActionResult<ApiResponse<List<StockCardDto>>>> GetOutOfStockCards()
        {
            var result = await _stockService.GetOutOfStockCardsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Stok günceller (giriş/çıkış)
        /// </summary>
        [HttpPost("update-stock")]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateStock([FromBody] UpdateStockDto updateStockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<bool>.ErrorResult("Geçersiz veri"));
            }

            var result = await _stockService.UpdateStockAsync(updateStockDto.ProductID, updateStockDto.WarehouseID, 
                updateStockDto.Quantity, updateStockDto.TransactionType);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Stok rezerve eder
        /// </summary>
        [HttpPost("reserve")]
        [Authorize(Roles = "Admin,Manager,Warehouse")]
        public async Task<ActionResult<ApiResponse<bool>>> ReserveStock([FromBody] ReserveStockDto reserveStockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<bool>.ErrorResult("Geçersiz veri"));
            }

            var result = await _stockService.ReserveStockAsync(reserveStockDto.ProductID, reserveStockDto.WarehouseID, reserveStockDto.Quantity);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Rezerve stoğu serbest bırakır
        /// </summary>
        [HttpPost("release-reserved")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> ReleaseReservedStock([FromBody] ReserveStockDto reserveStockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<bool>.ErrorResult("Geçersiz veri"));
            }

            var result = await _stockService.ReleaseReservedStockAsync(reserveStockDto.ProductID, reserveStockDto.WarehouseID, reserveStockDto.Quantity);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        #endregion

        #region StockTransaction İşlemleri

        /// <summary>
        /// Tüm stok işlemlerini sayfalı olarak getirir
        /// </summary>
        [HttpGet("transactions")]
        public async Task<ActionResult<ApiResponse<PagedResult<StockTransactionDto>>>> GetStockTransactions([FromQuery] PaginationParameters parameters)
        {
            var result = await _stockService.GetStockTransactionsAsync(parameters);
            return Ok(result);
        }

        /// <summary>
        /// ID'ye göre stok işlemi getirir
        /// </summary>
        [HttpGet("transactions/{id}")]
        public async Task<ActionResult<ApiResponse<StockTransactionDto>>> GetStockTransaction(int id)
        {
            var result = await _stockService.GetStockTransactionByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Yeni stok işlemi oluşturur
        /// </summary>
        [HttpPost("transactions")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<StockTransactionDto>>> CreateStockTransaction([FromBody] CreateStockTransactionDto createTransactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<StockTransactionDto>.ErrorResult("Geçersiz veri"));
            }

            var result = await _stockService.CreateStockTransactionAsync(createTransactionDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetStockTransaction), new { id = result.Data?.TransactionID }, result);
        }

        /// <summary>
        /// Ürüne göre stok işlemlerini getirir
        /// </summary>
        [HttpGet("transactions/by-product/{productId}")]
        public async Task<ActionResult<ApiResponse<List<StockTransactionDto>>>> GetTransactionsByProduct(int productId)
        {
            var result = await _stockService.GetTransactionsByProductIdAsync(productId);
            return Ok(result);
        }

        /// <summary>
        /// Depoya göre stok işlemlerini getirir
        /// </summary>
        [HttpGet("transactions/by-warehouse/{warehouseId}")]
        public async Task<ActionResult<ApiResponse<List<StockTransactionDto>>>> GetTransactionsByWarehouse(int warehouseId)
        {
            var result = await _stockService.GetTransactionsByWarehouseIdAsync(warehouseId);
            return Ok(result);
        }

        /// <summary>
        /// Tarih aralığına göre stok işlemlerini getirir
        /// </summary>
        [HttpGet("transactions/by-date-range")]
        public async Task<ActionResult<ApiResponse<List<StockTransactionDto>>>> GetTransactionsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = await _stockService.GetTransactionsByDateRangeAsync(startDate, endDate);
            return Ok(result);
        }

        /// <summary>
        /// Giren stok işlemlerini getirir
        /// </summary>
        [HttpGet("transactions/incoming")]
        public async Task<ActionResult<ApiResponse<List<StockTransactionDto>>>> GetIncomingTransactions([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var result = await _stockService.GetIncomingTransactionsAsync(fromDate, toDate);
            return Ok(result);
        }

        /// <summary>
        /// Çıkan stok işlemlerini getirir
        /// </summary>
        [HttpGet("transactions/outgoing")]
        public async Task<ActionResult<ApiResponse<List<StockTransactionDto>>>> GetOutgoingTransactions([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var result = await _stockService.GetOutgoingTransactionsAsync(fromDate, toDate);
            return Ok(result);
        }

        /// <summary>
        /// Stok transferi gerçekleştirir
        /// </summary>
        [HttpPost("transfer")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> ProcessStockMovement([FromBody] CreateStockMovementDto movementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<bool>.ErrorResult("Geçersiz veri"));
            }

            var result = await _stockService.ProcessStockMovementAsync(movementDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        #endregion

        #region Warehouse İşlemleri

        /// <summary>
        /// Tüm depoları sayfalı olarak getirir
        /// </summary>
        [HttpGet("warehouses")]
        public async Task<ActionResult<ApiResponse<PagedResult<WarehouseDto>>>> GetWarehouses([FromQuery] PaginationParameters parameters)
        {
            var result = await _stockService.GetWarehousesAsync(parameters);
            return Ok(result);
        }

        /// <summary>
        /// ID'ye göre depo getirir
        /// </summary>
        [HttpGet("warehouses/{id}")]
        public async Task<ActionResult<ApiResponse<WarehouseDto>>> GetWarehouse(int id)
        {
            var result = await _stockService.GetWarehouseByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Koda göre depo getirir
        /// </summary>
        [HttpGet("warehouses/by-code/{warehouseCode}")]
        public async Task<ActionResult<ApiResponse<WarehouseDto>>> GetWarehouseByCode(string warehouseCode)
        {
            var result = await _stockService.GetWarehouseByCodeAsync(warehouseCode);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Yeni depo oluşturur
        /// </summary>
        [HttpPost("warehouses")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<WarehouseDto>>> CreateWarehouse([FromBody] CreateWarehouseDto createWarehouseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<WarehouseDto>.ErrorResult("Geçersiz veri"));
            }

            var result = await _stockService.CreateWarehouseAsync(createWarehouseDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetWarehouse), new { id = result.Data?.WarehouseID }, result);
        }

        /// <summary>
        /// Depoyu günceller
        /// </summary>
        [HttpPut("warehouses/{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<WarehouseDto>>> UpdateWarehouse(int id, [FromBody] UpdateWarehouseDto updateWarehouseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<WarehouseDto>.ErrorResult("Geçersiz veri"));
            }

            var result = await _stockService.UpdateWarehouseAsync(id, updateWarehouseDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Depoyu siler
        /// </summary>
        [HttpDelete("warehouses/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteWarehouse(int id)
        {
            var result = await _stockService.DeleteWarehouseAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Aktif depoları getirir
        /// </summary>
        [HttpGet("warehouses/active")]
        public async Task<ActionResult<ApiResponse<List<WarehouseDto>>>> GetActiveWarehouses()
        {
            var result = await _stockService.GetActiveWarehousesAsync();
            return Ok(result);
        }

        #endregion

        #region Raporlar ve İstatistikler

        /// <summary>
        /// Stok özetini getirir
        /// </summary>
        [HttpGet("summary")]
        public async Task<ActionResult<ApiResponse<StockSummaryDto>>> GetStockSummary()
        {
            var result = await _stockService.GetStockSummaryAsync();
            return Ok(result);
        }

        /// <summary>
        /// Stok raporunu getirir
        /// </summary>
        [HttpGet("report")]
        public async Task<ActionResult<ApiResponse<StockReportDto>>> GetStockReport([FromQuery] int? warehouseId, [FromQuery] int? categoryId)
        {
            var result = await _stockService.GetStockReportAsync(warehouseId, categoryId);
            return Ok(result);
        }

        /// <summary>
        /// Toplam stok değerini getirir
        /// </summary>
        [HttpGet("total-value")]
        public async Task<ActionResult<ApiResponse<decimal>>> GetTotalStockValue()
        {
            var result = await _stockService.GetTotalStockValueAsync();
            return Ok(result);
        }

        /// <summary>
        /// Depoya göre toplam stok değerini getirir
        /// </summary>
        [HttpGet("total-value/by-warehouse/{warehouseId}")]
        public async Task<ActionResult<ApiResponse<decimal>>> GetTotalStockValueByWarehouse(int warehouseId)
        {
            var result = await _stockService.GetTotalStockValueByWarehouseAsync(warehouseId);
            return Ok(result);
        }

        /// <summary>
        /// Toplam giriş değerini getirir
        /// </summary>
        [HttpGet("incoming-value")]
        public async Task<ActionResult<ApiResponse<decimal>>> GetTotalIncomingValue([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var result = await _stockService.GetTotalIncomingValueAsync(fromDate, toDate);
            return Ok(result);
        }

        /// <summary>
        /// Toplam çıkış değerini getirir
        /// </summary>
        [HttpGet("outgoing-value")]
        public async Task<ActionResult<ApiResponse<decimal>>> GetTotalOutgoingValue([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var result = await _stockService.GetTotalOutgoingValueAsync(fromDate, toDate);
            return Ok(result);
        }

        #endregion
    }
} 