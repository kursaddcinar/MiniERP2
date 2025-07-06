using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniERP.API.DTOs;
using MiniERP.API.Services;

namespace MiniERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CariAccountsController : ControllerBase
    {
        private readonly ICariAccountService _cariAccountService;
        private readonly ILogger<CariAccountsController> _logger;

        public CariAccountsController(ICariAccountService cariAccountService, ILogger<CariAccountsController> logger)
        {
            _cariAccountService = cariAccountService;
            _logger = logger;
        }

        #region CariAccount Endpoints

        /// <summary>
        /// Get paginated list of cari accounts with optional search and filtering
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResult<CariAccountDto>>>> GetCariAccounts(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null,
            [FromQuery] int? typeId = null)
        {
            var parameters = new PaginationParameters { PageNumber = pageNumber, PageSize = pageSize };
            var result = await _cariAccountService.GetCariAccountsAsync(parameters, searchTerm, typeId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get cari account by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<CariAccountDto>>> GetCariAccount(int id)
        {
            var result = await _cariAccountService.GetCariAccountByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get cari account by code
        /// </summary>
        [HttpGet("by-code/{code}")]
        public async Task<ActionResult<ApiResponse<CariAccountDto>>> GetCariAccountByCode(string code)
        {
            var result = await _cariAccountService.GetCariAccountByCodeAsync(code);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Create a new cari account
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<CariAccountDto>>> CreateCariAccount([FromBody] CreateCariAccountDto createCariAccountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<CariAccountDto>.ErrorResult("Invalid input data"));
            }

            var result = await _cariAccountService.CreateCariAccountAsync(createCariAccountDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetCariAccount), new { id = result.Data!.CariID }, result);
        }

        /// <summary>
        /// Update an existing cari account
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<CariAccountDto>>> UpdateCariAccount(int id, [FromBody] UpdateCariAccountDto updateCariAccountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<CariAccountDto>.ErrorResult("Invalid input data"));
            }

            var result = await _cariAccountService.UpdateCariAccountAsync(id, updateCariAccountDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete a cari account
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteCariAccount(int id)
        {
            var result = await _cariAccountService.DeleteCariAccountAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Activate a cari account
        /// </summary>
        [HttpPost("{id}/activate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> ActivateCariAccount(int id)
        {
            var result = await _cariAccountService.ActivateCariAccountAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Deactivate a cari account
        /// </summary>
        [HttpPost("{id}/deactivate")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> DeactivateCariAccount(int id)
        {
            var result = await _cariAccountService.DeactivateCariAccountAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        [HttpGet("customers")]
        public async Task<ActionResult<ApiResponse<List<CariAccountDto>>>> GetCustomers()
        {
            var result = await _cariAccountService.GetCustomersAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get all suppliers
        /// </summary>
        [HttpGet("suppliers")]
        public async Task<ActionResult<ApiResponse<List<CariAccountDto>>>> GetSuppliers()
        {
            var result = await _cariAccountService.GetSuppliersAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get cari account balances
        /// </summary>
        [HttpGet("balances")]
        public async Task<ActionResult<ApiResponse<List<CariBalanceDto>>>> GetCariBalances(
            [FromQuery] bool includeZeroBalance = false)
        {
            var result = await _cariAccountService.GetCariBalancesAsync(includeZeroBalance);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        #endregion

        #region CariType Endpoints

        /// <summary>
        /// Get paginated list of cari types
        /// </summary>
        [HttpGet("types")]
        public async Task<ActionResult<ApiResponse<PagedResult<CariTypeDto>>>> GetCariTypes(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var parameters = new PaginationParameters { PageNumber = pageNumber, PageSize = pageSize };
            var result = await _cariAccountService.GetCariTypesAsync(parameters);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get cari type by ID
        /// </summary>
        [HttpGet("types/{id}")]
        public async Task<ActionResult<ApiResponse<CariTypeDto>>> GetCariType(int id)
        {
            var result = await _cariAccountService.GetCariTypeByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Create a new cari type
        /// </summary>
        [HttpPost("types")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<CariTypeDto>>> CreateCariType([FromBody] CreateCariTypeDto createCariTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<CariTypeDto>.ErrorResult("Invalid input data"));
            }

            var result = await _cariAccountService.CreateCariTypeAsync(createCariTypeDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetCariType), new { id = result.Data!.TypeID }, result);
        }

        /// <summary>
        /// Update an existing cari type
        /// </summary>
        [HttpPut("types/{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<CariTypeDto>>> UpdateCariType(int id, [FromBody] UpdateCariTypeDto updateCariTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<CariTypeDto>.ErrorResult("Invalid input data"));
            }

            var result = await _cariAccountService.UpdateCariTypeAsync(id, updateCariTypeDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete a cari type
        /// </summary>
        [HttpDelete("types/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteCariType(int id)
        {
            var result = await _cariAccountService.DeleteCariTypeAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        #endregion

        #region CariTransaction Endpoints

        /// <summary>
        /// Get paginated transactions for a specific cari account
        /// </summary>
        [HttpGet("{cariId}/transactions")]
        public async Task<ActionResult<ApiResponse<PagedResult<CariTransactionDto>>>> GetCariTransactions(
            int cariId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var parameters = new PaginationParameters { PageNumber = pageNumber, PageSize = pageSize };
            var result = await _cariAccountService.GetCariTransactionsAsync(cariId, parameters);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get cari account statement
        /// </summary>
        [HttpGet("{cariId}/statement")]
        public async Task<ActionResult<ApiResponse<CariStatementDto>>> GetCariStatement(
            int cariId,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            var result = await _cariAccountService.GetCariStatementAsync(cariId, startDate, endDate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Create a new cari transaction
        /// </summary>
        [HttpPost("transactions")]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<ActionResult<ApiResponse<CariTransactionDto>>> CreateCariTransaction([FromBody] CreateCariTransactionDto createTransactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<CariTransactionDto>.ErrorResult("Invalid input data"));
            }

            var result = await _cariAccountService.CreateCariTransactionAsync(createTransactionDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetCariTransactions), new { cariId = createTransactionDto.CariID }, result);
        }

        /// <summary>
        /// Update cari account balance manually
        /// </summary>
        [HttpPost("{cariId}/update-balance")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateCariBalance(
            int cariId,
            [FromBody] UpdateBalanceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<bool>.ErrorResult("Invalid input data"));
            }

            var result = await _cariAccountService.UpdateCariBalanceAsync(cariId, request.Amount, request.TransactionType);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        #endregion

        #region Reports and Analytics

        /// <summary>
        /// Get total receivables amount
        /// </summary>
        [HttpGet("reports/total-receivables")]
        public async Task<ActionResult<ApiResponse<decimal>>> GetTotalReceivables()
        {
            var result = await _cariAccountService.GetTotalReceivablesAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get total payables amount
        /// </summary>
        [HttpGet("reports/total-payables")]
        public async Task<ActionResult<ApiResponse<decimal>>> GetTotalPayables()
        {
            var result = await _cariAccountService.GetTotalPayablesAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get top customers by sales volume
        /// </summary>
        [HttpGet("reports/top-customers")]
        public async Task<ActionResult<ApiResponse<List<CariAccountDto>>>> GetTopCustomers(
            [FromQuery] int count = 10,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            var result = await _cariAccountService.GetTopCustomersAsync(count, fromDate, toDate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        #endregion
    }

    /// <summary>
    /// Request model for updating cari balance
    /// </summary>
    public class UpdateBalanceRequest
    {
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = string.Empty; // ALACAK, BORC
    }
} 