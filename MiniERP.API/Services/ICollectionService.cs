using MiniERP.API.DTOs;

namespace MiniERP.API.Services
{
    public interface ICollectionService
    {
        Task<ApiResponse<PagedResult<CollectionDto>>> GetCollectionsAsync(PaginationParameters parameters, string? searchTerm = null, int? cariId = null, int? paymentTypeId = null, string? status = null);
        Task<ApiResponse<CollectionDto>> GetCollectionByIdAsync(int id);
        Task<ApiResponse<CollectionDto>> CreateCollectionAsync(CreateCollectionDto createCollectionDto);
        Task<ApiResponse<CollectionDto>> UpdateCollectionAsync(int id, UpdateCollectionDto updateCollectionDto);
        Task<ApiResponse<bool>> DeleteCollectionAsync(int id);
        Task<ApiResponse<List<CollectionDto>>> GetCollectionsByCariIdAsync(int cariId);
        Task<ApiResponse<List<CollectionDto>>> GetCollectionsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ApiResponse<List<CollectionDto>>> GetRecentCollectionsAsync(int count = 10);
        Task<ApiResponse<decimal>> GetTotalCollectionAmountAsync(int cariId);
        Task<ApiResponse<List<CollectionDto>>> GetCollectionsByStatusAsync(string status);
        Task<ApiResponse<bool>> ApproveCollectionAsync(int id);
        Task<ApiResponse<bool>> CancelCollectionAsync(int id);
    }
} 