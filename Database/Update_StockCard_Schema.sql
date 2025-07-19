-- StockCard tablosuna eksik alanları ekle
USE MiniERPTrial;
GO

-- Mevcut tabloyu kontrol et
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'StockCards' AND COLUMN_NAME = 'Location')
BEGIN
    PRINT 'Location column already exists'
END
ELSE
BEGIN
    ALTER TABLE StockCards ADD Location nvarchar(100) NULL;
    PRINT 'Location column added'
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'StockCards' AND COLUMN_NAME = 'Notes')
BEGIN
    PRINT 'Notes column already exists'
END
ELSE
BEGIN
    ALTER TABLE StockCards ADD Notes nvarchar(500) NULL;
    PRINT 'Notes column added'
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'StockCards' AND COLUMN_NAME = 'ReorderLevel')
BEGIN
    PRINT 'ReorderLevel column already exists'
END
ELSE
BEGIN
    ALTER TABLE StockCards ADD ReorderLevel decimal(18,3) DEFAULT 0;
    PRINT 'ReorderLevel column added'
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'StockCards' AND COLUMN_NAME = 'ReorderQuantity')
BEGIN
    PRINT 'ReorderQuantity column already exists'
END
ELSE
BEGIN
    ALTER TABLE StockCards ADD ReorderQuantity decimal(18,3) DEFAULT 0;
    PRINT 'ReorderQuantity column added'
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'StockCards' AND COLUMN_NAME = 'IsActive')
BEGIN
    PRINT 'IsActive column already exists'
END
ELSE
BEGIN
    ALTER TABLE StockCards ADD IsActive bit DEFAULT 1;
    PRINT 'IsActive column added'
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'StockCards' AND COLUMN_NAME = 'LastUpdateDate')
BEGIN
    PRINT 'LastUpdateDate column already exists'
END
ELSE
BEGIN
    ALTER TABLE StockCards ADD LastUpdateDate datetime DEFAULT GETDATE();
    PRINT 'LastUpdateDate column added'
END

-- Mevcut kayıtların IsActive alanını güncelle
UPDATE StockCards SET IsActive = 1 WHERE IsActive IS NULL;
UPDATE StockCards SET LastUpdateDate = GETDATE() WHERE LastUpdateDate IS NULL;

PRINT 'StockCard table schema updated successfully!'
