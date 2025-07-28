using Microsoft.EntityFrameworkCore;
using MiniERP.API.Models;

namespace MiniERP.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<CariType> CariTypes { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<CariAccount> CariAccounts { get; set; }
        public DbSet<CariTransaction> CariTransactions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StockCard> StockCards { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesInvoiceDetail> SalesInvoiceDetails { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique constraints
            modelBuilder.Entity<Role>()
                .HasIndex(r => r.RoleName)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<UserRole>()
                .HasIndex(ur => new { ur.UserID, ur.RoleID })
                .IsUnique();

            modelBuilder.Entity<Unit>()
                .HasIndex(u => u.UnitCode)
                .IsUnique();

            modelBuilder.Entity<ProductCategory>()
                .HasIndex(pc => pc.CategoryCode)
                .IsUnique();

            modelBuilder.Entity<CariType>()
                .HasIndex(ct => ct.TypeCode)
                .IsUnique();

            modelBuilder.Entity<Warehouse>()
                .HasIndex(w => w.WarehouseCode)
                .IsUnique();

            modelBuilder.Entity<CariAccount>()
                .HasIndex(ca => ca.CariCode)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductCode)
                .IsUnique();

            modelBuilder.Entity<StockCard>()
                .HasIndex(sc => new { sc.ProductID, sc.WarehouseID })
                .IsUnique();

            modelBuilder.Entity<SalesInvoice>()
                .HasIndex(si => si.InvoiceNo)
                .IsUnique();

            modelBuilder.Entity<PurchaseInvoice>()
                .HasIndex(pi => pi.InvoiceNo)
                .IsUnique();

            // Decimal precision settings
            modelBuilder.Entity<CariAccount>()
                .Property(ca => ca.CreditLimit)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CariAccount>()
                .Property(ca => ca.CurrentBalance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CariTransaction>()
                .Property(ct => ct.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.SalePrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.PurchasePrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.VatRate)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.MinStockLevel)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Product>()
                .Property(p => p.MaxStockLevel)
                .HasPrecision(18, 3);

            modelBuilder.Entity<StockCard>()
                .Property(sc => sc.CurrentStock)
                .HasPrecision(18, 3);

            modelBuilder.Entity<StockCard>()
                .Property(sc => sc.ReservedStock)
                .HasPrecision(18, 3);

            modelBuilder.Entity<StockTransaction>()
                .Property(st => st.Quantity)
                .HasPrecision(18, 3);

            modelBuilder.Entity<StockTransaction>()
                .Property(st => st.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<StockTransaction>()
                .Property(st => st.TotalAmount)
                .HasPrecision(18, 2);

            // Configure relationships
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserID);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleID);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.CategoryID);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Unit)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.UnitID);

            modelBuilder.Entity<CariAccount>()
                .HasOne(ca => ca.Type)
                .WithMany(ct => ct.CariAccounts)
                .HasForeignKey(ca => ca.TypeID);

            modelBuilder.Entity<StockCard>()
                .HasOne(sc => sc.Product)
                .WithMany(p => p.StockCards)
                .HasForeignKey(sc => sc.ProductID);

            modelBuilder.Entity<StockCard>()
                .HasOne(sc => sc.Warehouse)
                .WithMany(w => w.StockCards)
                .HasForeignKey(sc => sc.WarehouseID);

            modelBuilder.Entity<SalesInvoice>()
                .HasOne(si => si.CariAccount)
                .WithMany(ca => ca.SalesInvoices)
                .HasForeignKey(si => si.CariID);

            modelBuilder.Entity<SalesInvoice>()
                .HasOne(si => si.Warehouse)
                .WithMany(w => w.SalesInvoices)
                .HasForeignKey(si => si.WarehouseID);

            modelBuilder.Entity<SalesInvoiceDetail>()
                .HasOne(sid => sid.SalesInvoice)
                .WithMany(si => si.SalesInvoiceDetails)
                .HasForeignKey(sid => sid.InvoiceID);

            modelBuilder.Entity<SalesInvoiceDetail>()
                .HasOne(sid => sid.Product)
                .WithMany(p => p.SalesInvoiceDetails)
                .HasForeignKey(sid => sid.ProductID);

            modelBuilder.Entity<PurchaseInvoice>()
                .HasOne(pi => pi.CariAccount)
                .WithMany(ca => ca.PurchaseInvoices)
                .HasForeignKey(pi => pi.CariID);

            modelBuilder.Entity<PurchaseInvoice>()
                .HasOne(pi => pi.Warehouse)
                .WithMany(w => w.PurchaseInvoices)
                .HasForeignKey(pi => pi.WarehouseID);

            modelBuilder.Entity<PurchaseInvoiceDetail>()
                .HasOne(pid => pid.PurchaseInvoice)
                .WithMany(pi => pi.PurchaseInvoiceDetails)
                .HasForeignKey(pid => pid.InvoiceID);

            modelBuilder.Entity<PurchaseInvoiceDetail>()
                .HasOne(pid => pid.Product)
                .WithMany(p => p.PurchaseInvoiceDetails)
                .HasForeignKey(pid => pid.ProductID);

            modelBuilder.Entity<CariTransaction>()
                .HasOne(ct => ct.CariAccount)
                .WithMany(ca => ca.CariTransactions)
                .HasForeignKey(ct => ct.CariID);

            modelBuilder.Entity<StockTransaction>()
                .HasOne(st => st.Product)
                .WithMany(p => p.StockTransactions)
                .HasForeignKey(st => st.ProductID);

            modelBuilder.Entity<StockTransaction>()
                .HasOne(st => st.Warehouse)
                .WithMany(w => w.StockTransactions)
                .HasForeignKey(st => st.WarehouseID);
        }
    }
} 