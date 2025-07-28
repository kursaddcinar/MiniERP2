namespace MiniERP.API.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IGenericRepository<Models.Role> Roles { get; }
        IGenericRepository<Models.Unit> Units { get; }
        IGenericRepository<Models.ProductCategory> ProductCategories { get; }
        IProductRepository Products { get; }
        IGenericRepository<Models.CariType> CariTypes { get; }
        ICariAccountRepository CariAccounts { get; }
        IGenericRepository<Models.CariTransaction> CariTransactions { get; }
        IWarehouseRepository Warehouses { get; }
        IStockCardRepository StockCards { get; }
        IStockTransactionRepository StockTransactions { get; }
        ISalesInvoiceRepository SalesInvoices { get; }
        IGenericRepository<Models.SalesInvoiceDetail> SalesInvoiceDetails { get; }
        IPurchaseInvoiceRepository PurchaseInvoices { get; }
        IGenericRepository<Models.PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
} 