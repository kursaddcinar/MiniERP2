using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public interface ICollectionRepository : IGenericRepository<Collection>
    {
        Task<IEnumerable<Collection>> GetCollectionsByCariIdAsync(int cariId);
        Task<IEnumerable<Collection>> GetCollectionsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Collection>> GetCollectionsByPaymentTypeAsync(int paymentTypeId);
        Task<IEnumerable<Collection>> GetCollectionsByStatusAsync(string status);
        Task<Collection?> GetCollectionByCollectionNoAsync(string collectionNo);
        Task<decimal> GetTotalCollectionAmountAsync(int cariId);
        Task<decimal> GetTotalCollectionAmountByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Collection>> GetRecentCollectionsAsync(int count = 10);
        Task<bool> IsCollectionNoUniqueAsync(string collectionNo, int? excludeId = null);
        Task<(IEnumerable<Collection> collections, int totalCount)> GetCollectionsWithDetailsAsync(int pageNumber, int pageSize, string? searchTerm = null, int? cariId = null, int? paymentTypeId = null, string? status = null);
    }
} 