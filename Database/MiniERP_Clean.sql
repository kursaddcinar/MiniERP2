-- MiniERP Clean Installation Script
-- Uses different database name to avoid file conflicts

USE master;
GO

-- Force close all connections to any MiniERP databases
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'MiniERP')
BEGIN
    ALTER DATABASE MiniERP SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE MiniERP;
END
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'MiniERPTrial')
BEGIN
    ALTER DATABASE MiniERPTrial SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE MiniERPTrial;
END
GO

-- Wait for files to be released
WAITFOR DELAY '00:00:03';
GO

-- Create new database with different name and file paths
CREATE DATABASE MiniERPTrial
ON (
    NAME = 'MiniERPTrial_Data',
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MiniERPTrial_Data.mdf',
    SIZE = 100MB,
    MAXSIZE = 1GB,
    FILEGROWTH = 10MB
)
LOG ON (
    NAME = 'MiniERPTrial_Log',
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MiniERPTrial_Log.ldf',
    SIZE = 10MB,
    MAXSIZE = 100MB,
    FILEGROWTH = 10%
);
GO

USE MiniERPTrial;
GO

-- Create all tables
CREATE TABLE Roles (
    RoleID int IDENTITY(1,1) PRIMARY KEY,
    RoleName nvarchar(50) NOT NULL UNIQUE,
    Description nvarchar(255),
    IsActive bit DEFAULT 1,
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int
);

CREATE TABLE Users (
    UserID int IDENTITY(1,1) PRIMARY KEY,
    Username nvarchar(50) NOT NULL UNIQUE,
    Password nvarchar(255) NOT NULL,
    Email nvarchar(100),
    FirstName nvarchar(50),
    LastName nvarchar(50),
    IsActive bit DEFAULT 1,
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int
);

CREATE TABLE UserRoles (
    UserRoleID int IDENTITY(1,1) PRIMARY KEY,
    UserID int NOT NULL,
    RoleID int NOT NULL,
    CreatedDate datetime DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
    UNIQUE(UserID, RoleID)
);

CREATE TABLE Units (
    UnitID int IDENTITY(1,1) PRIMARY KEY,
    UnitCode nvarchar(10) NOT NULL UNIQUE,
    UnitName nvarchar(50) NOT NULL,
    IsActive bit DEFAULT 1,
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int
);

CREATE TABLE ProductCategories (
    CategoryID int IDENTITY(1,1) PRIMARY KEY,
    CategoryCode nvarchar(20) NOT NULL UNIQUE,
    CategoryName nvarchar(100) NOT NULL,
    Description nvarchar(255),
    IsActive bit DEFAULT 1,
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int
);

CREATE TABLE CariTypes (
    TypeID int IDENTITY(1,1) PRIMARY KEY,
    TypeCode nvarchar(10) NOT NULL UNIQUE,
    TypeName nvarchar(50) NOT NULL,
    Description nvarchar(255),
    IsActive bit DEFAULT 1,
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int
);

CREATE TABLE Warehouses (
    WarehouseID int IDENTITY(1,1) PRIMARY KEY,
    WarehouseCode nvarchar(20) NOT NULL UNIQUE,
    WarehouseName nvarchar(100) NOT NULL,
    Address nvarchar(255),
    City nvarchar(50),
    ResponsiblePerson nvarchar(100),
    IsActive bit DEFAULT 1,
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int
);

CREATE TABLE CariAccounts (
    CariID int IDENTITY(1,1) PRIMARY KEY,
    CariCode nvarchar(20) NOT NULL UNIQUE,
    CariName nvarchar(150) NOT NULL,
    TypeID int NOT NULL,
    TaxNo nvarchar(20),
    TaxOffice nvarchar(100),
    Address nvarchar(255),
    City nvarchar(50),
    Phone nvarchar(20),
    Email nvarchar(100),
    ContactPerson nvarchar(100),
    CreditLimit decimal(18,2) DEFAULT 0,
    CurrentBalance decimal(18,2) DEFAULT 0,
    IsActive bit DEFAULT 1,
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int,
    FOREIGN KEY (TypeID) REFERENCES CariTypes(TypeID)
);

CREATE TABLE CariTransactions (
    TransactionID int IDENTITY(1,1) PRIMARY KEY,
    CariID int NOT NULL,
    TransactionDate datetime NOT NULL,
    TransactionType nvarchar(10) NOT NULL,
    Amount decimal(18,2) NOT NULL,
    Description nvarchar(255),
    DocumentType nvarchar(20),
    DocumentNo nvarchar(50),
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int,
    FOREIGN KEY (CariID) REFERENCES CariAccounts(CariID)
);

CREATE TABLE Products (
    ProductID int IDENTITY(1,1) PRIMARY KEY,
    ProductCode nvarchar(30) NOT NULL UNIQUE,
    ProductName nvarchar(150) NOT NULL,
    CategoryID int,
    UnitID int NOT NULL,
    SalePrice decimal(18,2) DEFAULT 0,
    PurchasePrice decimal(18,2) DEFAULT 0,
    VatRate decimal(5,2) DEFAULT 18,
    MinStockLevel decimal(18,3) DEFAULT 0,
    MaxStockLevel decimal(18,3) DEFAULT 0,
    IsActive bit DEFAULT 1,
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int,
    FOREIGN KEY (CategoryID) REFERENCES ProductCategories(CategoryID),
    FOREIGN KEY (UnitID) REFERENCES Units(UnitID)
);

CREATE TABLE StockCards (
    StockCardID int IDENTITY(1,1) PRIMARY KEY,
    ProductID int NOT NULL,
    WarehouseID int NOT NULL,
    CurrentStock decimal(18,3) DEFAULT 0,
    ReservedStock decimal(18,3) DEFAULT 0,
    LastTransactionDate datetime,
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (WarehouseID) REFERENCES Warehouses(WarehouseID),
    UNIQUE(ProductID, WarehouseID)
);

CREATE TABLE StockTransactions (
    TransactionID int IDENTITY(1,1) PRIMARY KEY,
    ProductID int NOT NULL,
    WarehouseID int NOT NULL,
    TransactionDate datetime NOT NULL,
    TransactionType nvarchar(10) NOT NULL,
    Quantity decimal(18,3) NOT NULL,
    UnitPrice decimal(18,2) DEFAULT 0,
    TotalAmount decimal(18,2) DEFAULT 0,
    Description nvarchar(255),
    DocumentType nvarchar(20),
    DocumentNo nvarchar(50),
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (WarehouseID) REFERENCES Warehouses(WarehouseID)
);

CREATE TABLE SalesInvoices (
    InvoiceID int IDENTITY(1,1) PRIMARY KEY,
    InvoiceNo nvarchar(50) NOT NULL UNIQUE,
    CariID int NOT NULL,
    WarehouseID int NOT NULL,
    InvoiceDate datetime NOT NULL,
    DueDate datetime,
    SubTotal decimal(18,2) DEFAULT 0,
    VatAmount decimal(18,2) DEFAULT 0,
    Total decimal(18,2) DEFAULT 0,
    Description nvarchar(255),
    Status nvarchar(20) DEFAULT 'DRAFT',
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int,
    FOREIGN KEY (CariID) REFERENCES CariAccounts(CariID),
    FOREIGN KEY (WarehouseID) REFERENCES Warehouses(WarehouseID)
);

CREATE TABLE SalesInvoiceDetails (
    DetailID int IDENTITY(1,1) PRIMARY KEY,
    InvoiceID int NOT NULL,
    ProductID int NOT NULL,
    Quantity decimal(18,3) NOT NULL,
    UnitPrice decimal(18,2) NOT NULL,
    VatRate decimal(5,2) NOT NULL,
    LineTotal decimal(18,2) NOT NULL,
    VatAmount decimal(18,2) NOT NULL,
    NetTotal decimal(18,2) NOT NULL,
    Description nvarchar(255),
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int,
    FOREIGN KEY (InvoiceID) REFERENCES SalesInvoices(InvoiceID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE PurchaseInvoices (
    InvoiceID int IDENTITY(1,1) PRIMARY KEY,
    InvoiceNo nvarchar(50) NOT NULL UNIQUE,
    CariID int NOT NULL,
    WarehouseID int NOT NULL,
    InvoiceDate datetime NOT NULL,
    DueDate datetime,
    SubTotal decimal(18,2) DEFAULT 0,
    VatAmount decimal(18,2) DEFAULT 0,
    Total decimal(18,2) DEFAULT 0,
    Description nvarchar(255),
    Status nvarchar(20) DEFAULT 'DRAFT',
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int,
    FOREIGN KEY (CariID) REFERENCES CariAccounts(CariID),
    FOREIGN KEY (WarehouseID) REFERENCES Warehouses(WarehouseID)
);

CREATE TABLE PurchaseInvoiceDetails (
    DetailID int IDENTITY(1,1) PRIMARY KEY,
    InvoiceID int NOT NULL,
    ProductID int NOT NULL,
    Quantity decimal(18,3) NOT NULL,
    UnitPrice decimal(18,2) NOT NULL,
    VatRate decimal(5,2) NOT NULL,
    LineTotal decimal(18,2) NOT NULL,
    VatAmount decimal(18,2) NOT NULL,
    NetTotal decimal(18,2) NOT NULL,
    Description nvarchar(255),
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int,
    FOREIGN KEY (InvoiceID) REFERENCES PurchaseInvoices(InvoiceID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE PaymentTypes (
    PaymentTypeID int IDENTITY(1,1) PRIMARY KEY,
    TypeCode nvarchar(10) NOT NULL UNIQUE,
    TypeName nvarchar(50) NOT NULL,
    Description nvarchar(255),
    IsActive bit DEFAULT 1,
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int
);

CREATE TABLE Payments (
    PaymentID int IDENTITY(1,1) PRIMARY KEY,
    PaymentNo nvarchar(50) NOT NULL UNIQUE,
    CariID int NOT NULL,
    PaymentDate datetime NOT NULL,
    Amount decimal(18,2) NOT NULL,
    PaymentTypeID int NOT NULL,
    Description nvarchar(255),
    Status nvarchar(20) DEFAULT 'COMPLETED',
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int,
    FOREIGN KEY (CariID) REFERENCES CariAccounts(CariID),
    FOREIGN KEY (PaymentTypeID) REFERENCES PaymentTypes(PaymentTypeID)
);

CREATE TABLE Collections (
    CollectionID int IDENTITY(1,1) PRIMARY KEY,
    CollectionNo nvarchar(50) NOT NULL UNIQUE,
    CariID int NOT NULL,
    CollectionDate datetime NOT NULL,
    Amount decimal(18,2) NOT NULL,
    PaymentTypeID int NOT NULL,
    Description nvarchar(255),
    Status nvarchar(20) DEFAULT 'COMPLETED',
    CreatedDate datetime DEFAULT GETDATE(),
    CreatedBy int,
    FOREIGN KEY (CariID) REFERENCES CariAccounts(CariID),
    FOREIGN KEY (PaymentTypeID) REFERENCES PaymentTypes(PaymentTypeID)
);

-- Insert basic data
INSERT INTO CariTypes (TypeCode, TypeName, Description) VALUES
('MUSTERI', 'Müşteri', 'Müşteri Hesabı'),
('TEDARIKCI', 'Tedarikçi', 'Tedarikçi Hesabı'),
('HERSIKI', 'Her İkisi', 'Hem Müşteri Hem Tedarikçi');

INSERT INTO Roles (RoleName, Description) VALUES
('Admin', 'Sistem Yöneticisi'),
('Manager', 'Genel Müdür'),
('Sales', 'Satış Personeli'),
('Purchase', 'Satın Alma Personeli'),
('Warehouse', 'Depo Personeli'),
('Finance', 'Muhasebe Personeli');

INSERT INTO Units (UnitCode, UnitName) VALUES
('ADET', 'Adet'),
('KG', 'Kilogram'),
('LT', 'Litre'),
('M', 'Metre'),
('M2', 'Metrekare'),
('M3', 'Metreküp'),
('PAKET', 'Paket'),
('KUTU', 'Kutu');

INSERT INTO PaymentTypes (TypeCode, TypeName, Description) VALUES
('NAKIT', 'Nakit', 'Nakit Ödeme'),
('KREDI', 'Kredi Kartı', 'Kredi Kartı ile Ödeme'),
('HAVALE', 'Havale/EFT', 'Banka Havalesi'),
('CEK', 'Çek', 'Çek ile Ödeme'),
('SENET', 'Senet', 'Senet ile Ödeme');

INSERT INTO Warehouses (WarehouseCode, WarehouseName, Address, City, ResponsiblePerson) VALUES
('ANA', 'Ana Depo', 'Merkez Mah. Sanayi Cad. No:1', 'İstanbul', 'Depo Sorumlusu');

INSERT INTO Users (Username, Password, Email, FirstName, LastName, IsActive) VALUES
('admin', '123456', 'admin@minierp.com', 'Admin', 'User', 1);

INSERT INTO UserRoles (UserID, RoleID) VALUES (1, 1);

PRINT '================================================';
PRINT '    MiniERPTrial Database Created Successfully!';
PRINT '================================================';
PRINT 'Database Name: MiniERPTrial';
PRINT 'Admin User: admin';
PRINT 'Admin Password: 123456';
PRINT 'Default Warehouse: ANA';
PRINT 'Tables Created: 16';
PRINT 'Basic Data Loaded: YES';
PRINT '================================================';
PRINT 'IMPORTANT: Use MiniERPTrial as database name!';
PRINT 'Connection String: Data Source=.;Initial Catalog=MiniERPTrial;Integrated Security=true';
PRINT '================================================';
PRINT 'Database is ready! You can now proceed with API development.';
PRINT '================================================';
GO 