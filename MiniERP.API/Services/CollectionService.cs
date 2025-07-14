using AutoMapper;
using MiniERP.API.DTOs;
using MiniERP.API.Models;
using MiniERP.API.Repositories;

namespace MiniERP.API.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CollectionService> _logger;

        public CollectionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CollectionService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResponse<PagedResult<CollectionDto>>> GetCollectionsAsync(PaginationParameters parameters, string? searchTerm = null, int? cariId = null, int? paymentTypeId = null, string? status = null)
        {
            try
            {
                var (collections, totalCount) = await _unitOfWork.Collections.GetCollectionsWithDetailsAsync(
                    parameters.PageNumber, parameters.PageSize, searchTerm, cariId, paymentTypeId, status);

                var collectionDtos = _mapper.Map<List<CollectionDto>>(collections);
                var pagedResult = new PagedResult<CollectionDto>(collectionDtos, totalCount, parameters.PageNumber, parameters.PageSize);

                return ApiResponse<PagedResult<CollectionDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting collections");
                return ApiResponse<PagedResult<CollectionDto>>.ErrorResult("An error occurred while getting collections");
            }
        }

        public async Task<ApiResponse<CollectionDto>> GetCollectionByIdAsync(int id)
        {
            try
            {
                var collection = await _unitOfWork.Collections.GetByIdAsync(id);
                if (collection == null)
                {
                    return ApiResponse<CollectionDto>.ErrorResult("Collection not found");
                }

                var collectionDto = _mapper.Map<CollectionDto>(collection);
                return ApiResponse<CollectionDto>.SuccessResult(collectionDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting collection {CollectionId}", id);
                return ApiResponse<CollectionDto>.ErrorResult("An error occurred while getting collection");
            }
        }

        public async Task<ApiResponse<CollectionDto>> CreateCollectionAsync(CreateCollectionDto createCollectionDto)
        {
            try
            {
                // Check if collection no is unique
                if (!await _unitOfWork.Collections.IsCollectionNoUniqueAsync(createCollectionDto.CollectionNo))
                {
                    return ApiResponse<CollectionDto>.ErrorResult("Collection number already exists");
                }

                // Check if cari account exists
                var cariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(createCollectionDto.CariID);
                if (cariAccount == null)
                {
                    return ApiResponse<CollectionDto>.ErrorResult("Cari account not found");
                }

                // Check if payment type exists
                var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(createCollectionDto.PaymentTypeID);
                if (paymentType == null)
                {
                    return ApiResponse<CollectionDto>.ErrorResult("Payment type not found");
                }

                var collection = _mapper.Map<Collection>(createCollectionDto);
                collection.Status = "COMPLETED";
                collection.CreatedDate = DateTime.Now;

                await _unitOfWork.Collections.AddAsync(collection);
                
                // Create cari transaction for collection
                var cariTransaction = new CariTransaction
                {
                    CariID = createCollectionDto.CariID,
                    TransactionDate = createCollectionDto.CollectionDate,
                    TransactionType = "ALACAK", // Müşteriden tahsilat = Cari hesabın alacağı azalır
                    Amount = createCollectionDto.Amount,
                    Description = $"Collection - {createCollectionDto.CollectionNo}",
                    DocumentType = "COLLECTION",
                    DocumentNo = createCollectionDto.CollectionNo,
                    CreatedDate = DateTime.Now
                };

                await _unitOfWork.CariTransactions.AddAsync(cariTransaction);

                // Update cari account balance
                cariAccount.CurrentBalance += createCollectionDto.Amount;
                await _unitOfWork.CariAccounts.UpdateAsync(cariAccount);

                await _unitOfWork.SaveChangesAsync();

                var collectionDto = _mapper.Map<CollectionDto>(collection);
                _logger.LogInformation("Collection {CollectionNo} created successfully", createCollectionDto.CollectionNo);
                
                return ApiResponse<CollectionDto>.SuccessResult(collectionDto, "Collection created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating collection {CollectionNo}", createCollectionDto.CollectionNo);
                return ApiResponse<CollectionDto>.ErrorResult("An error occurred while creating collection");
            }
        }

        public async Task<ApiResponse<CollectionDto>> UpdateCollectionAsync(int id, UpdateCollectionDto updateCollectionDto)
        {
            try
            {
                var collection = await _unitOfWork.Collections.GetByIdAsync(id);
                if (collection == null)
                {
                    return ApiResponse<CollectionDto>.ErrorResult("Collection not found");
                }

                // Check if collection can be updated
                if (collection.Status == "CANCELLED")
                {
                    return ApiResponse<CollectionDto>.ErrorResult("Cannot update cancelled collection");
                }

                // Check if cari account exists
                var cariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(updateCollectionDto.CariID);
                if (cariAccount == null)
                {
                    return ApiResponse<CollectionDto>.ErrorResult("Cari account not found");
                }

                // Check if payment type exists
                var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(updateCollectionDto.PaymentTypeID);
                if (paymentType == null)
                {
                    return ApiResponse<CollectionDto>.ErrorResult("Payment type not found");
                }

                var originalAmount = collection.Amount;
                var originalCariId = collection.CariID;

                _mapper.Map(updateCollectionDto, collection);
                await _unitOfWork.Collections.UpdateAsync(collection);

                // Update cari transaction and balance if amount or cari changed
                if (originalAmount != updateCollectionDto.Amount || originalCariId != updateCollectionDto.CariID)
                {
                    // Revert original cari transaction
                    if (originalCariId != updateCollectionDto.CariID)
                    {
                        var originalCariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(originalCariId);
                        if (originalCariAccount != null)
                        {
                            originalCariAccount.CurrentBalance -= originalAmount;
                            await _unitOfWork.CariAccounts.UpdateAsync(originalCariAccount);
                        }
                    }
                    else
                    {
                        cariAccount.CurrentBalance -= originalAmount;
                    }

                    // Apply new cari transaction
                    cariAccount.CurrentBalance += updateCollectionDto.Amount;
                    await _unitOfWork.CariAccounts.UpdateAsync(cariAccount);
                }

                await _unitOfWork.SaveChangesAsync();

                var collectionDto = _mapper.Map<CollectionDto>(collection);
                _logger.LogInformation("Collection {CollectionId} updated successfully", id);
                
                return ApiResponse<CollectionDto>.SuccessResult(collectionDto, "Collection updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating collection {CollectionId}", id);
                return ApiResponse<CollectionDto>.ErrorResult("An error occurred while updating collection");
            }
        }

        public async Task<ApiResponse<bool>> DeleteCollectionAsync(int id)
        {
            try
            {
                var collection = await _unitOfWork.Collections.GetByIdAsync(id);
                if (collection == null)
                {
                    return ApiResponse<bool>.ErrorResult("Collection not found");
                }

                // Check if collection can be deleted
                if (collection.Status == "COMPLETED")
                {
                    return ApiResponse<bool>.ErrorResult("Cannot delete completed collection. Please cancel first.");
                }

                await _unitOfWork.Collections.DeleteAsync(collection);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Collection {CollectionId} deleted successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Collection deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting collection {CollectionId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while deleting collection");
            }
        }

        public async Task<ApiResponse<List<CollectionDto>>> GetCollectionsByCariIdAsync(int cariId)
        {
            try
            {
                var collections = await _unitOfWork.Collections.GetCollectionsByCariIdAsync(cariId);
                var collectionDtos = _mapper.Map<List<CollectionDto>>(collections);
                
                return ApiResponse<List<CollectionDto>>.SuccessResult(collectionDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting collections for cari {CariId}", cariId);
                return ApiResponse<List<CollectionDto>>.ErrorResult("An error occurred while getting collections");
            }
        }

        public async Task<ApiResponse<List<CollectionDto>>> GetCollectionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var collections = await _unitOfWork.Collections.GetCollectionsByDateRangeAsync(startDate, endDate);
                var collectionDtos = _mapper.Map<List<CollectionDto>>(collections);
                
                return ApiResponse<List<CollectionDto>>.SuccessResult(collectionDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting collections for date range {StartDate} - {EndDate}", startDate, endDate);
                return ApiResponse<List<CollectionDto>>.ErrorResult("An error occurred while getting collections");
            }
        }

        public async Task<ApiResponse<List<CollectionDto>>> GetRecentCollectionsAsync(int count = 10)
        {
            try
            {
                var collections = await _unitOfWork.Collections.GetRecentCollectionsAsync(count);
                var collectionDtos = _mapper.Map<List<CollectionDto>>(collections);
                
                return ApiResponse<List<CollectionDto>>.SuccessResult(collectionDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting recent collections");
                return ApiResponse<List<CollectionDto>>.ErrorResult("An error occurred while getting recent collections");
            }
        }

        public async Task<ApiResponse<decimal>> GetTotalCollectionAmountAsync(int cariId)
        {
            try
            {
                var totalAmount = await _unitOfWork.Collections.GetTotalCollectionAmountAsync(cariId);
                return ApiResponse<decimal>.SuccessResult(totalAmount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total collection amount for cari {CariId}", cariId);
                return ApiResponse<decimal>.ErrorResult("An error occurred while getting total collection amount");
            }
        }

        public async Task<ApiResponse<List<CollectionDto>>> GetCollectionsByStatusAsync(string status)
        {
            try
            {
                var collections = await _unitOfWork.Collections.GetCollectionsByStatusAsync(status);
                var collectionDtos = _mapper.Map<List<CollectionDto>>(collections);
                
                return ApiResponse<List<CollectionDto>>.SuccessResult(collectionDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting collections by status {Status}", status);
                return ApiResponse<List<CollectionDto>>.ErrorResult("An error occurred while getting collections");
            }
        }

        public async Task<ApiResponse<bool>> ApproveCollectionAsync(int id)
        {
            try
            {
                var collection = await _unitOfWork.Collections.GetByIdAsync(id);
                if (collection == null)
                {
                    return ApiResponse<bool>.ErrorResult("Collection not found");
                }

                if (collection.Status == "COMPLETED")
                {
                    return ApiResponse<bool>.ErrorResult("Collection is already approved");
                }

                if (collection.Status == "CANCELLED")
                {
                    return ApiResponse<bool>.ErrorResult("Cannot approve cancelled collection");
                }

                collection.Status = "COMPLETED";
                await _unitOfWork.Collections.UpdateAsync(collection);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Collection {CollectionId} approved successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Collection approved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error approving collection {CollectionId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while approving collection");
            }
        }

        public async Task<ApiResponse<bool>> CancelCollectionAsync(int id)
        {
            try
            {
                var collection = await _unitOfWork.Collections.GetByIdAsync(id);
                if (collection == null)
                {
                    return ApiResponse<bool>.ErrorResult("Collection not found");
                }

                if (collection.Status == "CANCELLED")
                {
                    return ApiResponse<bool>.ErrorResult("Collection is already cancelled");
                }

                // Revert cari transaction
                var cariAccount = await _unitOfWork.CariAccounts.GetByIdAsync(collection.CariID);
                if (cariAccount != null)
                {
                    cariAccount.CurrentBalance -= collection.Amount;
                    await _unitOfWork.CariAccounts.UpdateAsync(cariAccount);
                }

                collection.Status = "CANCELLED";
                await _unitOfWork.Collections.UpdateAsync(collection);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Collection {CollectionId} cancelled successfully", id);
                return ApiResponse<bool>.SuccessResult(true, "Collection cancelled successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling collection {CollectionId}", id);
                return ApiResponse<bool>.ErrorResult("An error occurred while cancelling collection");
            }
        }
    }
} 