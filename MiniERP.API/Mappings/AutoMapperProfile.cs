using AutoMapper;
using MiniERP.API.Models;
using MiniERP.API.DTOs;

namespace MiniERP.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User mappings
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.RoleName).ToList()));
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            // Role mappings
            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.UserCount, opt => opt.MapFrom(src => src.UserRoles.Count));
            CreateMap<CreateRoleDto, Role>();
            CreateMap<UpdateRoleDto, Role>();

            // Unit mappings
            CreateMap<Unit, UnitDto>()
                .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products.Count));
            CreateMap<CreateUnitDto, Unit>();
            CreateMap<UpdateUnitDto, Unit>();

            // ProductCategory mappings
            CreateMap<ProductCategory, ProductCategoryDto>()
                .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products.Count));
            CreateMap<CreateProductCategoryDto, ProductCategory>();
            CreateMap<UpdateProductCategoryDto, ProductCategory>();

            // Product mappings
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : null))
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.UnitName))
                .ForMember(dest => dest.CurrentStock, opt => opt.MapFrom(src => src.StockCards.Sum(sc => sc.CurrentStock)))
                .ForMember(dest => dest.ReservedStock, opt => opt.MapFrom(src => src.StockCards.Sum(sc => sc.ReservedStock)))
                .ForMember(dest => dest.AvailableStock, opt => opt.MapFrom(src => src.StockCards.Sum(sc => sc.CurrentStock - sc.ReservedStock)));
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

            // CariType mappings
            CreateMap<CariType, CariTypeDto>()
                .ForMember(dest => dest.CariAccountCount, opt => opt.MapFrom(src => src.CariAccounts.Count));
            CreateMap<CreateCariTypeDto, CariType>();
            CreateMap<UpdateCariTypeDto, CariType>();

            // CariAccount mappings
            CreateMap<CariAccount, CariAccountDto>()
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.TypeName))
                .ForMember(dest => dest.BalanceType, opt => opt.MapFrom(src => 
                    src.CurrentBalance > 0 ? "ALACAK" : 
                    src.CurrentBalance < 0 ? "BORÇ" : "SIFIR"));
            CreateMap<CreateCariAccountDto, CariAccount>();
            CreateMap<UpdateCariAccountDto, CariAccount>();

            // CariTransaction mappings
            CreateMap<CariTransaction, CariTransactionDto>()
                .ForMember(dest => dest.CariCode, opt => opt.MapFrom(src => src.CariAccount.CariCode))
                .ForMember(dest => dest.CariName, opt => opt.MapFrom(src => src.CariAccount.CariName))
                .ForMember(dest => dest.DebitAmount, opt => opt.MapFrom(src => src.TransactionType == "BORC" ? src.Amount : 0))
                .ForMember(dest => dest.CreditAmount, opt => opt.MapFrom(src => src.TransactionType == "ALACAK" ? src.Amount : 0))
                .ForMember(dest => dest.Balance, opt => opt.Ignore()); // Will be calculated separately
            CreateMap<CreateCariTransactionDto, CariTransaction>();

            // Warehouse mappings
            CreateMap<Warehouse, WarehouseDto>()
                .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.StockCards.Count))
                .ForMember(dest => dest.TotalStockValue, opt => opt.MapFrom(src => 
                    src.StockCards.Sum(sc => sc.CurrentStock * sc.Product.PurchasePrice)));
            CreateMap<CreateWarehouseDto, Warehouse>();
            CreateMap<UpdateWarehouseDto, Warehouse>();

            // StockCard mappings
            CreateMap<StockCard, StockCardDto>()
                .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.Product.ProductCode))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.WarehouseCode, opt => opt.MapFrom(src => src.Warehouse.WarehouseCode))
                .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.WarehouseName))
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Product.Unit.UnitName))
                .ForMember(dest => dest.AvailableStock, opt => opt.MapFrom(src => src.CurrentStock - src.ReservedStock))
                .ForMember(dest => dest.MinStockLevel, opt => opt.MapFrom(src => src.Product.MinStockLevel))
                .ForMember(dest => dest.MaxStockLevel, opt => opt.MapFrom(src => src.Product.MaxStockLevel))
                .ForMember(dest => dest.StockStatus, opt => opt.MapFrom(src => 
                    src.CurrentStock <= src.Product.MinStockLevel ? "CRITICAL" :
                    src.CurrentStock >= src.Product.MaxStockLevel ? "OVER" : "NORMAL"));
            CreateMap<CreateStockCardDto, StockCard>();
            CreateMap<UpdateStockCardDto, StockCard>();

            // StockTransaction mappings
            CreateMap<StockTransaction, StockTransactionDto>()
                .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.Product.ProductCode))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.WarehouseCode, opt => opt.MapFrom(src => src.Warehouse.WarehouseCode))
                .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.WarehouseName))
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Product.Unit.UnitName));
            CreateMap<CreateStockTransactionDto, StockTransaction>();

            // SalesInvoice mappings
            CreateMap<SalesInvoice, SalesInvoiceDto>()
                .ForMember(dest => dest.CariCode, opt => opt.MapFrom(src => src.CariAccount.CariCode))
                .ForMember(dest => dest.CariName, opt => opt.MapFrom(src => src.CariAccount.CariName))
                .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.WarehouseName))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.SalesInvoiceDetails));
            CreateMap<CreateSalesInvoiceDto, SalesInvoice>();
            CreateMap<UpdateSalesInvoiceDto, SalesInvoice>();

            // SalesInvoiceDetail mappings
            CreateMap<SalesInvoiceDetail, SalesInvoiceDetailDto>()
                .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.Product.ProductCode))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Product.Unit.UnitName))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.VatRate, opt => opt.MapFrom(src => src.VatRate))
                .ForMember(dest => dest.LineTotal, opt => opt.MapFrom(src => src.LineTotal))
                .ForMember(dest => dest.VatAmount, opt => opt.MapFrom(src => src.VatAmount))
                .ForMember(dest => dest.NetTotal, opt => opt.MapFrom(src => src.NetTotal));
            CreateMap<CreateSalesInvoiceDetailDto, SalesInvoiceDetail>();

            // PurchaseInvoice mappings
            CreateMap<PurchaseInvoice, PurchaseInvoiceDto>()
                .ForMember(dest => dest.CariCode, opt => opt.MapFrom(src => src.CariAccount.CariCode))
                .ForMember(dest => dest.CariName, opt => opt.MapFrom(src => src.CariAccount.CariName))
                .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.WarehouseName))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.PurchaseInvoiceDetails));
            CreateMap<CreatePurchaseInvoiceDto, PurchaseInvoice>();
            CreateMap<UpdatePurchaseInvoiceDto, PurchaseInvoice>();

            // PurchaseInvoiceDetail mappings
            CreateMap<PurchaseInvoiceDetail, PurchaseInvoiceDetailDto>()
                .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.Product.ProductCode))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Product.Unit.UnitName))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.VatRate, opt => opt.MapFrom(src => src.VatRate))
                .ForMember(dest => dest.LineTotal, opt => opt.MapFrom(src => src.LineTotal))
                .ForMember(dest => dest.VatAmount, opt => opt.MapFrom(src => src.VatAmount))
                .ForMember(dest => dest.NetTotal, opt => opt.MapFrom(src => src.NetTotal));
            CreateMap<CreatePurchaseInvoiceDetailDto, PurchaseInvoiceDetail>();

            // PaymentType mappings
            CreateMap<PaymentType, PaymentTypeDto>()
                .ForMember(dest => dest.PaymentCount, opt => opt.MapFrom(src => src.Payments.Count))
                .ForMember(dest => dest.CollectionCount, opt => opt.MapFrom(src => src.Collections.Count));
            CreateMap<CreatePaymentTypeDto, PaymentType>();
            CreateMap<UpdatePaymentTypeDto, PaymentType>();

            // Payment mappings
            CreateMap<Payment, PaymentDto>()
                .ForMember(dest => dest.CariCode, opt => opt.MapFrom(src => src.CariAccount.CariCode))
                .ForMember(dest => dest.CariName, opt => opt.MapFrom(src => src.CariAccount.CariName))
                .ForMember(dest => dest.PaymentTypeName, opt => opt.MapFrom(src => src.PaymentType.TypeName));
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<UpdatePaymentDto, Payment>();

            // Collection mappings
            CreateMap<Collection, CollectionDto>()
                .ForMember(dest => dest.CariCode, opt => opt.MapFrom(src => src.CariAccount.CariCode))
                .ForMember(dest => dest.CariName, opt => opt.MapFrom(src => src.CariAccount.CariName))
                .ForMember(dest => dest.PaymentTypeName, opt => opt.MapFrom(src => src.PaymentType.TypeName));
            CreateMap<CreateCollectionDto, Collection>();
            CreateMap<UpdateCollectionDto, Collection>();
        }
    }
} 