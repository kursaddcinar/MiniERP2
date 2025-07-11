// CariAccountService

using AutoMapper;
using MiniERP.API.DTOs;
using MiniERP.API.Models;
using MiniERP.API.Repositories;

namespace MiniERP.API.Services
{
    public class CariAccountService : ICariAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CariAccountService> _logger;

        public CariAccountService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CariAccountService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        #region CariAccount Operations

        public async Task<ApiResponse<PagedResult<CariAccountDto>>> GetCariAccountsAsync(PaginationParameters parameters, string? searchTerm = null, int? typeId = null)
        {
            try
            {
                IEnumerable<CariAccount> cariAccounts;

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    cariAccounts = await _unitOfWork.CariAccounts.SearchCariAccountsAsync(searchTerm);
                }
                else
                {
                    cariAccounts = await _unitOfWork.CariAccounts.GetActiveCariAccountsAsync();
                }

                if (typeId.HasValue)
                {
                    cariAccounts = cariAccounts.Where(c => c.TypeID == typeId.Value);
                }

                var totalCount = cariAccounts.Count();
                var pagedCariAccounts = cariAccounts
                    .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                    .Take(parameters.PageSize)
                    .ToList();

                var cariAccountDtos = _mapper.Map<List<CariAccountDto>>(pagedCariAccounts);
                var pagedResult = new PagedResult<CariAccountDto>(cariAccountDtos, totalCount, parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<CariAccountDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cari accounts");
                return ApiResponse<PagedResult<CariAccountDto>>.ErrorResult("An error occurred while getting cari accounts");
            }
        }

        public async Task<ApiResponse<CariAccountDto>> GetCariAccountByIdAsync(int id)
        {
            try
            {
                var cariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(id);
                if (cariAccount == null)
                {
                    return ApiResponse<CariAccountDto>.ErrorResult("Cari account not found");
                }

                var cariAccountDto = _mapper.Map<CariAccountDto>(cariAccount);
                return ApiResponse<CariAccountDto>.SuccessResult(cariAccountDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cari account {CariId}", id);
                return ApiResponse<CariAccountDto>.ErrorResult("An error occurred while getting cari account");
            }
        }

        public async Task<ApiResponse<CariAccountDto>> GetCariAccountByCodeAsync(string code)
        {
            try
            {
                var cariAccount = await _unitOfWork.CariAccounts.GetByCodeAsync(code);
                if (cariAccount == null)
                {
                    return ApiResponse<CariAccountDto>.ErrorResult("Cari account not found");
                }

                var cariAccountDto = _mapper.Map<CariAccountDto>(cariAccount);
                return ApiResponse<CariAccountDto>.SuccessResult(cariAccountDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cari account by code {CariCode}", code);
                return ApiResponse<CariAccountDto>.ErrorResult("An error occurred while getting cari account");
            }
        }

        public async Task<ApiResponse<CariAccountDto>> CreateCariAccountAsync(CreateCariAccountDto createCariAccountDto)
        {
            try
            {
                if (!await _unitOfWork.CariAccounts.IsCariCodeUniqueAsync(createCariAccountDto.CariCode))
                {
                    return ApiResponse<CariAccountDto>.ErrorResult("Cari code already exists");
                }

                var cariType = await _unitOfWork.CariTypes.GetByIdAsync(createCariAccountDto.TypeID);
                if (cariType == null)
                {
                    return ApiResponse<CariAccountDto>.ErrorResult("Cari type not found");
                }

                var cariAccount = _mapper.Map<CariAccount>(createCariAccountDto);
                cariAccount.CreatedDate = DateTime.Now;
                cariAccount.IsActive = true;
                cariAccount.CurrentBalance = 0;

                await _unitOfWork.CariAccounts.AddAsync(cariAccount);
                await _unitOfWork.SaveChangesAsync();

                var cariAccountDto = _mapper.Map<CariAccountDto>(cariAccount);

                _logger.LogInformation("Cari account {CariCode} created successfully", createCariAccountDto.CariCode);
                return ApiResponse<CariAccountDto>.SuccessResult(cariAccountDto, "Cari account created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating cari account {CariCode}", createCariAccountDto.CariCode);
                return ApiResponse<CariAccountDto>.ErrorResult("An error occurred while creating cari account");
            }
        }

        public async Task<ApiResponse<CariAccountDto>> UpdateCariAccountAsync(int id, UpdateCariAccountDto updateCariAccountDto)
        {
            try
            {
                var cariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(id);
                if (cariAccount == null)
                {
                    return ApiResponse<CariAccountDto>.ErrorResult("Cari account not found");
                }

                var cariType = await _unitOfWork.CariTypes.GetByIdAsync(updateCariAccountDto.TypeID);
                if (cariType == null)
                {
                    return ApiResponse<CariAccountDto>.ErrorResult("Cari type not found");
                }

                _mapper.Map(updateCariAccountDto, cariAccount);
                await _unitOfWork.CariAccounts.UpdateAsync(cariAccount);
                await _unitOfWork.SaveChangesAsync();

                var cariAccountDto = _mapper.Map<CariAccountDto>(cariAccount);

                _logger.LogInformation("Cari account {CariId} updated successfully", id);
                return ApiResponse<CariAccountDto>.SuccessResult(cariAccountDto, "Cari account updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating cari account {CariId}", id);
                return ApiResponse<CariAccountDto>.ErrorResult("An error occurred while updating cari account");
            }
        }

        public async Task<ApiResponse<bool>> DeleteCariAccountAsync(int id)
        {
            try
            {
                var cariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(id);
                if (cariAccount == null)
                {
                    return ApiResponse<bool>.ErrorResult("Cari account not found");
                }

                await _unitOfWork.CariAccounts.DeleteAsync(cariAccount);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Cari account {CariId} deleted successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Cari account deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting cari account {CariId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while deleting cari account");
            }
        }

        public async Task<ApiResponse<bool>> ActivateCariAccountAsync(int id)
        {
            try
            {
                var cariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(id);
                if (cariAccount == null)
                {
                    return ApiResponse<bool>.ErrorResult("Cari account not found");
                }

                cariAccount.IsActive = true;
                await _unitOfWork.CariAccounts.UpdateAsync(cariAccount);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Cari account {CariId} activated successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Cari account activated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error activating cari account {CariId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while activating cari account");
            }
        }

        public async Task<ApiResponse<bool>> DeactivateCariAccountAsync(int id)
        {
            try
            {
                var cariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(id);
                if (cariAccount == null)
                {
                    return ApiResponse<bool>.ErrorResult("Cari account not found");
                }

                cariAccount.IsActive = false;
                await _unitOfWork.CariAccounts.UpdateAsync(cariAccount);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Cari account {CariId} deactivated successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Cari account deactivated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deactivating cari account {CariId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while deactivating cari account");
            }
        }

        public async Task<ApiResponse<List<CariAccountDto>>> GetCustomersAsync()
        {
            try
            {
                var customers = await _unitOfWork.CariAccounts.GetCustomersAsync();
                var customerDtos = _mapper.Map<List<CariAccountDto>>(customers);

                return ApiResponse<List<CariAccountDto>>.SuccessResult(customerDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting customers");
                return ApiResponse<List<CariAccountDto>>.ErrorResult("An error occurred while getting customers");
            }
        }

        public async Task<ApiResponse<List<CariAccountDto>>> GetSuppliersAsync()
        {
            try
            {
                var suppliers = await _unitOfWork.CariAccounts.GetSuppliersAsync();
                var supplierDtos = _mapper.Map<List<CariAccountDto>>(suppliers);

                return ApiResponse<List<CariAccountDto>>.SuccessResult(supplierDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting suppliers");
                return ApiResponse<List<CariAccountDto>>.ErrorResult("An error occurred while getting suppliers");
            }
        }

        public async Task<ApiResponse<List<CariBalanceDto>>> GetCariBalancesAsync(bool includeZeroBalance = false)
        {
            try
            {
                var cariAccounts = await _unitOfWork.CariAccounts.GetCariAccountsWithBalanceAsync(includeZeroBalance);
                var balanceDtos = cariAccounts.Select(c => new CariBalanceDto
                {
                    CariID = c.CariID,
                    CariCode = c.CariCode,
                    CariName = c.CariName,
                    TypeName = c.Type.TypeName,
                    CurrentBalance = c.CurrentBalance,
                    CreditLimit = c.CreditLimit,
                    CreditUsed = c.CurrentBalance < 0 ? Math.Abs(c.CurrentBalance) : 0,
                    CreditAvailable = c.CreditLimit - (c.CurrentBalance < 0 ? Math.Abs(c.CurrentBalance) : 0),
                    BalanceType = c.CurrentBalance > 0 ? "ALACAK" : c.CurrentBalance < 0 ? "BORÇ" : "SIFIR",
                    LastTransactionDate = c.CariTransactions?.OrderByDescending(t => t.TransactionDate).FirstOrDefault()?.TransactionDate ?? DateTime.MinValue
                }).ToList();

                return ApiResponse<List<CariBalanceDto>>.SuccessResult(balanceDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cari balances");
                return ApiResponse<List<CariBalanceDto>>.ErrorResult("An error occurred while getting cari balances");
            }
        }

        #endregion

        #region CariType Operations

        public async Task<ApiResponse<PagedResult<CariTypeDto>>> GetCariTypesAsync(PaginationParameters parameters)
        {
            try
            {
                var (cariTypes, totalCount) = await _unitOfWork.CariTypes.GetPagedWithCountAsync(
                    parameters.PageNumber,
                    parameters.PageSize);

                var cariTypeDtos = _mapper.Map<List<CariTypeDto>>(cariTypes);
                var pagedResult = new PagedResult<CariTypeDto>(cariTypeDtos, totalCount, parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<CariTypeDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cari types");
                return ApiResponse<PagedResult<CariTypeDto>>.ErrorResult("An error occurred while getting cari types");
            }
        }

        public async Task<ApiResponse<CariTypeDto>> GetCariTypeByIdAsync(int id)
        {
            try
            {
                var cariType = await _unitOfWork.CariTypes.GetByIdAsync(id);
                if (cariType == null)
                {
                    return ApiResponse<CariTypeDto>.ErrorResult("Cari type not found");
                }

                var cariTypeDto = _mapper.Map<CariTypeDto>(cariType);
                return ApiResponse<CariTypeDto>.SuccessResult(cariTypeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cari type {TypeId}", id);
                return ApiResponse<CariTypeDto>.ErrorResult("An error occurred while getting cari type");
            }
        }

        public async Task<ApiResponse<CariTypeDto>> CreateCariTypeAsync(CreateCariTypeDto createCariTypeDto)
        {
            try
            {
                var cariType = _mapper.Map<CariType>(createCariTypeDto);
                cariType.CreatedDate = DateTime.Now;
                cariType.IsActive = true;

                await _unitOfWork.CariTypes.AddAsync(cariType);
                await _unitOfWork.SaveChangesAsync();

                var cariTypeDto = _mapper.Map<CariTypeDto>(cariType);

                _logger.LogInformation("Cari type {TypeCode} created successfully", createCariTypeDto.TypeCode);
                return ApiResponse<CariTypeDto>.SuccessResult(cariTypeDto, "Cari type created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating cari type {TypeCode}", createCariTypeDto.TypeCode);
                return ApiResponse<CariTypeDto>.ErrorResult("An error occurred while creating cari type");
            }
        }

        public async Task<ApiResponse<CariTypeDto>> UpdateCariTypeAsync(int id, UpdateCariTypeDto updateCariTypeDto)
        {
            try
            {
                var cariType = await _unitOfWork.CariTypes.GetByIdAsync(id);
                if (cariType == null)
                {
                    return ApiResponse<CariTypeDto>.ErrorResult("Cari type not found");
                }

                _mapper.Map(updateCariTypeDto, cariType);
                await _unitOfWork.CariTypes.UpdateAsync(cariType);
                await _unitOfWork.SaveChangesAsync();

                var cariTypeDto = _mapper.Map<CariTypeDto>(cariType);

                _logger.LogInformation("Cari type {TypeId} updated successfully", id);
                return ApiResponse<CariTypeDto>.SuccessResult(cariTypeDto, "Cari type updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating cari type {TypeId}", id);
                return ApiResponse<CariTypeDto>.ErrorResult("An error occurred while updating cari type");
            }
        }

        public async Task<ApiResponse<bool>> DeleteCariTypeAsync(int id)
        {
            try
            {
                var cariType = await _unitOfWork.CariTypes.GetByIdAsync(id);
                if (cariType == null)
                {
                    return ApiResponse<bool>.ErrorResult("Cari type not found");
                }

                await _unitOfWork.CariTypes.DeleteAsync(cariType);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Cari type {TypeId} deleted successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Cari type deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting cari type {TypeId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while deleting cari type");
            }
        }

        #endregion

        #region CariTransaction Operations

        public async Task<ApiResponse<PagedResult<CariTransactionDto>>> GetCariTransactionsAsync(int cariId, PaginationParameters parameters)
        {
            try
            {
                var cariAccount = await _unitOfWork.CariAccounts.GetCariWithTransactionsAsync(cariId);
                if (cariAccount == null)
                {
                    return ApiResponse<PagedResult<CariTransactionDto>>.ErrorResult("Cari account not found");
                }

                var transactions = cariAccount.CariTransactions?.OrderByDescending(t => t.TransactionDate).ToList() ?? new List<CariTransaction>();
                var totalCount = transactions.Count();
                var pagedTransactions = transactions
                    .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                    .Take(parameters.PageSize)
                    .ToList();

                var transactionDtos = _mapper.Map<List<CariTransactionDto>>(pagedTransactions);
                var pagedResult = new PagedResult<CariTransactionDto>(transactionDtos, totalCount, parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<CariTransactionDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cari transactions for {CariId}", cariId);
                return ApiResponse<PagedResult<CariTransactionDto>>.ErrorResult("An error occurred while getting cari transactions");
            }
        }

        public async Task<ApiResponse<CariTransactionDto>> CreateCariTransactionAsync(CreateCariTransactionDto createTransactionDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var cariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(createTransactionDto.CariID);
                if (cariAccount == null)
                {
                    return ApiResponse<CariTransactionDto>.ErrorResult("Cari account not found");
                }

                var transaction = _mapper.Map<CariTransaction>(createTransactionDto);
                transaction.CreatedDate = DateTime.Now;

                await _unitOfWork.CariTransactions.AddAsync(transaction);

                // Update cari account balance
                await _unitOfWork.CariAccounts.UpdateBalanceAsync(createTransactionDto.CariID, createTransactionDto.Amount, createTransactionDto.TransactionType);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                var transactionDto = _mapper.Map<CariTransactionDto>(transaction);

                _logger.LogInformation("Cari transaction created for cari {CariId}", createTransactionDto.CariID);
                return ApiResponse<CariTransactionDto>.SuccessResult(transactionDto, "Transaction created successfully");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError(ex, "Error creating cari transaction for {CariId}", createTransactionDto.CariID);
                return ApiResponse<CariTransactionDto>.ErrorResult("An error occurred while creating transaction");
            }
        }

        public async Task<ApiResponse<bool>> UpdateCariBalanceAsync(int cariId, decimal amount, string transactionType)
        {
            try
            {
                var result = await _unitOfWork.CariAccounts.UpdateBalanceAsync(cariId, amount, transactionType);
                if (!result)
                {
                    return ApiResponse<bool>.ErrorResult("Failed to update cari balance");
                }

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Cari balance updated for {CariId}", cariId);
                return ApiResponse<bool>.SuccessResult(true, "Cari balance updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating cari balance for {CariId}", cariId);
                return ApiResponse<bool>.ErrorResult("An error occurred while updating cari balance");
            }
        }

        public async Task<ApiResponse<CariStatementDto>> GetCariStatementAsync(int cariId, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var cariAccount = await _unitOfWork.CariAccounts.GetCariWithTransactionsAsync(cariId);
                if (cariAccount == null)
                {
                    return ApiResponse<CariStatementDto>.ErrorResult("Cari account not found");
                }

                var transactions = cariAccount.CariTransactions?.OrderBy(t => t.TransactionDate).ToList() ?? new List<CariTransaction>();

                // Filter transactions by date range if specified
                if (startDate.HasValue || endDate.HasValue)
                {
                    transactions = transactions.Where(t => 
                        (!startDate.HasValue || t.TransactionDate >= startDate.Value) &&
                        (!endDate.HasValue || t.TransactionDate <= endDate.Value)
                    ).ToList();
                }

                var transactionDtos = _mapper.Map<List<CariTransactionDto>>(transactions);

                // Calculate opening balance (balance before the start date)
                decimal openingBalance = 0;
                if (startDate.HasValue)
                {
                    var preTransactions = cariAccount.CariTransactions?
                        .Where(t => t.TransactionDate < startDate.Value)
                        .ToList() ?? new List<CariTransaction>();

                    openingBalance = preTransactions.Sum(t => 
                        t.TransactionType == "ALACAK" ? t.Amount : -t.Amount);
                }

                var totalDebit = transactionDtos.Sum(t => t.TransactionType == "BORC" ? t.Amount : 0);
                var totalCredit = transactionDtos.Sum(t => t.TransactionType == "ALACAK" ? t.Amount : 0);
                var closingBalance = openingBalance + totalCredit - totalDebit;

                var statement = new CariStatementDto
                {
                    CariAccountID = cariAccount.CariID,
                    CariCode = cariAccount.CariCode,
                    CariName = cariAccount.CariName,
                    OpeningBalance = openingBalance,
                    TotalDebit = totalDebit,
                    TotalCredit = totalCredit,
                    ClosingBalance = closingBalance,
                    Transactions = transactionDtos
                };

                return ApiResponse<CariStatementDto>.SuccessResult(statement);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cari statement for {CariId}", cariId);
                return ApiResponse<CariStatementDto>.ErrorResult("An error occurred while getting cari statement");
            }
        }

        #endregion

        #region Reports and Analytics

        public async Task<ApiResponse<decimal>> GetTotalReceivablesAsync()
        {
            try
            {
                var totalReceivables = await _unitOfWork.CariAccounts.GetTotalReceivablesAsync();
                return ApiResponse<decimal>.SuccessResult(totalReceivables);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total receivables");
                return ApiResponse<decimal>.ErrorResult("An error occurred while getting total receivables");
            }
        }

        public async Task<ApiResponse<decimal>> GetTotalPayablesAsync()
        {
            try
            {
                var totalPayables = await _unitOfWork.CariAccounts.GetTotalPayablesAsync();
                return ApiResponse<decimal>.SuccessResult(totalPayables);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total payables");
                return ApiResponse<decimal>.ErrorResult("An error occurred while getting total payables");
            }
        }

        public async Task<ApiResponse<List<CariAccountDto>>> GetTopCustomersAsync(int count, DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                var topCustomers = await _unitOfWork.CariAccounts.GetTopCustomersAsync(count, fromDate, toDate);
                var customerDtos = _mapper.Map<List<CariAccountDto>>(topCustomers);

                return ApiResponse<List<CariAccountDto>>.SuccessResult(customerDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting top customers");
                return ApiResponse<List<CariAccountDto>>.ErrorResult("An error occurred while getting top customers");
            }
        }

        #endregion
    }
}
