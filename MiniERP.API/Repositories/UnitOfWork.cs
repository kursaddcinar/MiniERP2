using Microsoft.EntityFrameworkCore.Storage;
using MiniERP.API.Data;
using MiniERP.API.Models;

namespace MiniERP.API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        // Lazy initialization of repositories
        private IUserRepository? _users;
        private IGenericRepository<Role>? _roles;
        private IGenericRepository<Unit>? _units;
        private IGenericRepository<ProductCategory>? _productCategories;
        private IProductRepository? _products;
        private IGenericRepository<CariType>? _cariTypes;
        private ICariAccountRepository? _cariAccounts;
        private IGenericRepository<CariTransaction>? _cariTransactions;
        private IWarehouseRepository? _warehouses;
        private IStockCardRepository? _stockCards;
        private IStockTransactionRepository? _stockTransactions;
        private ISalesInvoiceRepository? _salesInvoices;
        private IGenericRepository<SalesInvoiceDetail>? _salesInvoiceDetails;
        private IPurchaseInvoiceRepository? _purchaseInvoices;
        private IGenericRepository<PurchaseInvoiceDetail>? _purchaseInvoiceDetails;

        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IGenericRepository<Role> Roles => _roles ??= new GenericRepository<Role>(_context);
        public IGenericRepository<Unit> Units => _units ??= new GenericRepository<Unit>(_context);
        public IGenericRepository<ProductCategory> ProductCategories => _productCategories ??= new GenericRepository<ProductCategory>(_context);
        public IProductRepository Products => _products ??= new ProductRepository(_context);
        public IGenericRepository<CariType> CariTypes => _cariTypes ??= new GenericRepository<CariType>(_context);
        public ICariAccountRepository CariAccounts => _cariAccounts ??= new CariAccountRepository(_context);
        public IGenericRepository<CariTransaction> CariTransactions => _cariTransactions ??= new GenericRepository<CariTransaction>(_context);
        public IWarehouseRepository Warehouses => _warehouses ??= new WarehouseRepository(_context);
        public IStockCardRepository StockCards => _stockCards ??= new StockCardRepository(_context);
        public IStockTransactionRepository StockTransactions => _stockTransactions ??= new StockTransactionRepository(_context);
        public ISalesInvoiceRepository SalesInvoices => _salesInvoices ??= new SalesInvoiceRepository(_context);
        public IGenericRepository<SalesInvoiceDetail> SalesInvoiceDetails => _salesInvoiceDetails ??= new GenericRepository<SalesInvoiceDetail>(_context);
        public IPurchaseInvoiceRepository PurchaseInvoices => _purchaseInvoices ??= new PurchaseInvoiceRepository(_context);
        public IGenericRepository<PurchaseInvoiceDetail> PurchaseInvoiceDetails => _purchaseInvoiceDetails ??= new GenericRepository<PurchaseInvoiceDetail>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
} 