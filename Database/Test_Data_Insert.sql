-- MiniERPTrial Test Data Insert Script
-- Bu script sistemi test etmek için kapsamlı örnek veriler ekler
-- Not: Bu script MiniERP_Clean.sql çalıştırıldıktan sonra çalıştırılmalıdır

USE MiniERPTrial;
GO

PRINT 'Starting test data insertion...';

-- =================================================================================
-- 0. KULLANICI VE ROL KONTROLÜ
-- =================================================================================

-- Test kullanıcılarının var olup olmadığını kontrol et
IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'admin')
BEGIN
    PRINT 'ERROR: Test users not found! Please run MiniERP_Clean.sql first.';
    RAISERROR('Test users not found! Run MiniERP_Clean.sql first.', 16, 1);
    RETURN;
END

PRINT 'User system verified. Found test users:';
SELECT 
    u.Username, 
    r.RoleName,
    CASE WHEN u.IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS Status
FROM Users u 
INNER JOIN UserRoles ur ON u.UserID = ur.UserID
INNER JOIN Roles r ON ur.RoleID = r.RoleID
ORDER BY u.UserID;

-- =================================================================================
-- 1. ÜRÜN KATEGORİLERİ
-- =================================================================================

INSERT INTO ProductCategories (CategoryCode, CategoryName, Description, CreatedBy) VALUES
('ELEKTRONIK', 'Elektronik Ürünler', 'Bilgisayar, telefon, tablet vb.', 1),
('OFIS', 'Ofis Malzemeleri', 'Kırtasiye, mobilya, yazıcı vb.', 1),
('TEMIZLIK', 'Temizlik Malzemeleri', 'Deterjan, sabun, dezenfektan vb.', 1),
('GIYIM', 'Giyim ve Aksesuar', 'Kıyafet, ayakkabı, çanta vb.', 1),
('GIDA', 'Gıda ve İçecek', 'Yiyecek, içecek, atıştırmalık vb.', 1);

PRINT 'Product categories inserted.';

-- =================================================================================
-- 2. ÜRÜNLER
-- =================================================================================

INSERT INTO Products (ProductCode, ProductName, CategoryID, UnitID, SalePrice, PurchasePrice, VatRate, MinStockLevel, MaxStockLevel, CreatedBy) VALUES
-- Elektronik
('LAPTOP001', 'Dell Laptop 15.6"', 1, 1, 25000.00, 20000.00, 18.00, 5, 50, 1),
('PHONE001', 'Samsung Galaxy S24', 1, 1, 35000.00, 28000.00, 18.00, 10, 100, 1),
('TABLET001', 'iPad Air 11"', 1, 1, 22000.00, 18000.00, 18.00, 5, 30, 1),
('MONITOR001', 'LG 27" 4K Monitor', 1, 1, 8500.00, 7000.00, 18.00, 3, 25, 1),
('KEYBOARD001', 'Logitech Wireless Keyboard', 1, 1, 850.00, 650.00, 18.00, 20, 100, 1),

-- Ofis
('KALEM001', 'Pilot Tükenmez Kalem Mavi', 2, 1, 15.00, 10.00, 18.00, 100, 1000, 1),
('DEFTER001', 'Spiralli Defter A4 100 Sayfa', 2, 1, 25.00, 18.00, 18.00, 50, 500, 1),
('YAZICI001', 'HP LaserJet Pro Yazıcı', 2, 1, 3500.00, 2800.00, 18.00, 2, 20, 1),
('MASA001', 'Ofis Masası Ahşap 120x80', 2, 1, 2500.00, 2000.00, 18.00, 3, 15, 1),
('SANDALYE001', 'Ergonomik Ofis Sandalyesi', 2, 1, 1800.00, 1400.00, 18.00, 5, 25, 1),

-- Temizlik
('SABUN001', 'Sıvı El Sabunu 500ml', 3, 8, 45.00, 32.00, 18.00, 30, 200, 1),
('DETERJAN001', 'Çamaşır Deterjanı 3kg', 3, 8, 125.00, 95.00, 18.00, 20, 150, 1),
('KAGIT001', 'Tuvalet Kağıdı 24lü', 3, 7, 85.00, 65.00, 18.00, 50, 300, 1),
('MENDIL001', 'Kağıt Mendil 200lü', 3, 7, 35.00, 25.00, 18.00, 100, 500, 1),

-- Giyim
('TISORT001', 'Polo Yaka T-Shirt Lacivert L', 4, 1, 195.00, 145.00, 18.00, 15, 100, 1),
('PANTOLON001', 'Jean Pantolon Mavi 32/34', 4, 1, 350.00, 280.00, 18.00, 10, 80, 1),
('AYAKKABI001', 'Spor Ayakkabı Siyah 42', 4, 1, 750.00, 580.00, 18.00, 8, 50, 1),

-- Gıda
('KAHVE001', 'Türk Kahvesi 100gr', 5, 7, 85.00, 65.00, 8.00, 25, 200, 1),
('CAY001', 'Bergamot Aromalı Çay 25li', 5, 7, 45.00, 32.00, 8.00, 40, 300, 1),
('BISKUVI001', 'Çikolatalı Bisküvi 150gr', 5, 7, 18.00, 12.00, 8.00, 60, 400, 1);

PRINT 'Products inserted.';

-- =================================================================================
-- 3. CARİ HESAPLAR (MÜŞTERİLER)
-- =================================================================================

INSERT INTO CariAccounts (CariCode, CariName, TypeID, TaxNo, TaxOffice, Address, City, Phone, Email, ContactPerson, CreditLimit, CreatedBy) VALUES
('MUS001', 'ABC Teknoloji Ltd. Şti.', 1, '1234567890', 'Beşiktaş VD', 'Levent Mah. Teknoloji Cad. No:1 Beşiktaş', 'İstanbul', '0212 123 45 67', 'info@abctek.com', 'Ahmet Yılmaz', 100000.00, 1),
('MUS002', 'XYZ Ofis Hizmetleri A.Ş.', 1, '0987654321', 'Kadıköy VD', 'Bağdat Cad. No:100 Kadıköy', 'İstanbul', '0216 987 65 43', 'contact@xyz.com', 'Fatma Demir', 75000.00, 1),
('MUS003', 'Mega Market Zinciri', 1, '1122334455', 'Ataşehir VD', 'Barbaros Bulvarı No:45 Ataşehir', 'İstanbul', '0216 444 55 66', 'siparis@megamarket.com', 'Mehmet Kaya', 200000.00, 1),
('MUS004', 'Global Tekstil San. Tic.', 1, '5566778899', 'Şişli VD', 'Mecidiyeköy Cad. No:78 Şişli', 'İstanbul', '0212 777 88 99', 'info@globaltekstil.com', 'Ayşe Özkan', 150000.00, 1),
('MUS005', 'Özel Eğitim Kurumları', 1, '3344556677', 'Üsküdar VD', 'Çamlıca Sok. No:12 Üsküdar', 'İstanbul', '0216 333 44 55', 'admin@ozelegitim.edu.tr', 'Emre Polat', 80000.00, 1);

PRINT 'Customer accounts inserted.';

-- =================================================================================
-- 4. CARİ HESAPLAR (TEDARİKÇİLER)
-- =================================================================================

INSERT INTO CariAccounts (CariCode, CariName, TypeID, TaxNo, TaxOffice, Address, City, Phone, Email, ContactPerson, CreditLimit, CreatedBy) VALUES
('TED001', 'Teknoloji Dünyası A.Ş.', 2, '1111222233', 'Beyoğlu VD', 'İstiklal Cad. No:150 Beyoğlu', 'İstanbul', '0212 111 22 33', 'satis@tekdunya.com', 'Ali Veli', 300000.00, 1),
('TED002', 'Ofis Malzemeleri Ltd.', 2, '4444555566', 'Bakırköy VD', 'Atatürk Bulvarı No:25 Bakırköy', 'İstanbul', '0212 444 55 66', 'info@ofismalzeme.com', 'Zeynep Aydın', 200000.00, 1),
('TED003', 'Temizlik Ürünleri San.', 2, '7777888899', 'Pendik VD', 'Sanayi Sitesi A Blok No:5 Pendik', 'İstanbul', '0216 777 88 99', 'siparis@temizlik.com', 'Hasan Çelik', 150000.00, 1),
('TED004', 'Moda Giyim Konfeksiyon', 2, '2222333344', 'Fatih VD', 'Laleli Cad. No:88 Fatih', 'İstanbul', '0212 222 33 44', 'wholesale@modagiyim.com', 'Elif Şahin', 180000.00, 1),
('TED005', 'Gıda Dağıtım A.Ş.', 2, '6666777788', 'Kartal VD', 'Gıda Sanayii Sitesi C2 Blok Kartal', 'İstanbul', '0216 666 77 88', 'satis@gidadagitim.com', 'Mustafa Yıldız', 250000.00, 1);

PRINT 'Supplier accounts inserted.';

-- =================================================================================
-- 5. STOK KARTLARI (BAŞLANGIÇ STOKLARI SIFIR)
-- =================================================================================

-- Tüm ürünler için ana depoda stok kartı oluştur
INSERT INTO StockCards (ProductID, WarehouseID, CurrentStock, ReservedStock, CreatedBy)
SELECT ProductID, 1, 0, 0, 1 FROM Products;

PRINT 'Stock cards initialized.';

-- =================================================================================
-- 6. ALIŞ FATURALARı (STOK GİRİŞLERİ)
-- =================================================================================

-- Alış Faturası 1: Teknoloji Ürünleri
INSERT INTO PurchaseInvoices (InvoiceNo, CariID, WarehouseID, InvoiceDate, DueDate, Status, CreatedBy) VALUES
('AF2024001', (SELECT CariID FROM CariAccounts WHERE CariCode = 'TED001'), 1, '2024-01-15', '2024-02-15', 'DRAFT', 1);

INSERT INTO PurchaseInvoiceDetails (InvoiceID, ProductID, Quantity, UnitPrice, VatRate, LineTotal, VatAmount, NetTotal, CreatedBy) VALUES
(1, (SELECT ProductID FROM Products WHERE ProductCode = 'LAPTOP001'), 20, 20000.00, 18.00, 400000.00, 72000.00, 472000.00, 1),
(1, (SELECT ProductID FROM Products WHERE ProductCode = 'PHONE001'), 30, 28000.00, 18.00, 840000.00, 151200.00, 991200.00, 1),
(1, (SELECT ProductID FROM Products WHERE ProductCode = 'TABLET001'), 15, 18000.00, 18.00, 270000.00, 48600.00, 318600.00, 1),
(1, (SELECT ProductID FROM Products WHERE ProductCode = 'MONITOR001'), 25, 7000.00, 18.00, 175000.00, 31500.00, 206500.00, 1);

-- Alış Faturası 2: Ofis Malzemeleri
INSERT INTO PurchaseInvoices (InvoiceNo, CariID, WarehouseID, InvoiceDate, DueDate, Status, CreatedBy) VALUES
('AF2024002', (SELECT CariID FROM CariAccounts WHERE CariCode = 'TED002'), 1, '2024-01-18', '2024-02-18', 'DRAFT', 1);

INSERT INTO PurchaseInvoiceDetails (InvoiceID, ProductID, Quantity, UnitPrice, VatRate, LineTotal, VatAmount, NetTotal, CreatedBy) VALUES
(2, (SELECT ProductID FROM Products WHERE ProductCode = 'KALEM001'), 500, 10.00, 18.00, 5000.00, 900.00, 5900.00, 1),
(2, (SELECT ProductID FROM Products WHERE ProductCode = 'DEFTER001'), 200, 18.00, 18.00, 3600.00, 648.00, 4248.00, 1),
(2, (SELECT ProductID FROM Products WHERE ProductCode = 'YAZICI001'), 10, 2800.00, 18.00, 28000.00, 5040.00, 33040.00, 1),
(2, (SELECT ProductID FROM Products WHERE ProductCode = 'MASA001'), 8, 2000.00, 18.00, 16000.00, 2880.00, 18880.00, 1);

-- Alış Faturası 3: Temizlik Ürünleri
INSERT INTO PurchaseInvoices (InvoiceNo, CariID, WarehouseID, InvoiceDate, DueDate, Status, CreatedBy) VALUES
('AF2024003', (SELECT CariID FROM CariAccounts WHERE CariCode = 'TED003'), 1, '2024-01-20', '2024-02-20', 'DRAFT', 1);

INSERT INTO PurchaseInvoiceDetails (InvoiceID, ProductID, Quantity, UnitPrice, VatRate, LineTotal, VatAmount, NetTotal, CreatedBy) VALUES
(3, (SELECT ProductID FROM Products WHERE ProductCode = 'SABUN001'), 100, 32.00, 18.00, 3200.00, 576.00, 3776.00, 1),
(3, (SELECT ProductID FROM Products WHERE ProductCode = 'DETERJAN001'), 80, 95.00, 18.00, 7600.00, 1368.00, 8968.00, 1),
(3, (SELECT ProductID FROM Products WHERE ProductCode = 'KAGIT001'), 150, 65.00, 18.00, 9750.00, 1755.00, 11505.00, 1);

PRINT 'Purchase invoices created (DRAFT status).';

-- Fatura toplamlarını manuel güncelle (trigger olmadığı için)
UPDATE PurchaseInvoices 
SET SubTotal = (SELECT SUM(LineTotal) FROM PurchaseInvoiceDetails WHERE InvoiceID = 1),
    VatAmount = (SELECT SUM(VatAmount) FROM PurchaseInvoiceDetails WHERE InvoiceID = 1),
    Total = (SELECT SUM(NetTotal) FROM PurchaseInvoiceDetails WHERE InvoiceID = 1)
WHERE InvoiceID = 1;

UPDATE PurchaseInvoices 
SET SubTotal = (SELECT SUM(LineTotal) FROM PurchaseInvoiceDetails WHERE InvoiceID = 2),
    VatAmount = (SELECT SUM(VatAmount) FROM PurchaseInvoiceDetails WHERE InvoiceID = 2),
    Total = (SELECT SUM(NetTotal) FROM PurchaseInvoiceDetails WHERE InvoiceID = 2)
WHERE InvoiceID = 2;

UPDATE PurchaseInvoices 
SET SubTotal = (SELECT SUM(LineTotal) FROM PurchaseInvoiceDetails WHERE InvoiceID = 3),
    VatAmount = (SELECT SUM(VatAmount) FROM PurchaseInvoiceDetails WHERE InvoiceID = 3),
    Total = (SELECT SUM(NetTotal) FROM PurchaseInvoiceDetails WHERE InvoiceID = 3)
WHERE InvoiceID = 3;

-- Alış faturalarını onayla ve stokları güncelle
UPDATE PurchaseInvoices SET Status = 'APPROVED' WHERE InvoiceID IN (1, 2, 3);

-- Manuel stok güncellemeleri (trigger olmadığı için)
-- Fatura 1 ürünleri
UPDATE StockCards SET CurrentStock = 20 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'LAPTOP001');
UPDATE StockCards SET CurrentStock = 30 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'PHONE001');
UPDATE StockCards SET CurrentStock = 15 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'TABLET001');
UPDATE StockCards SET CurrentStock = 25 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'MONITOR001');

-- Fatura 2 ürünleri
UPDATE StockCards SET CurrentStock = 500 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'KALEM001');
UPDATE StockCards SET CurrentStock = 200 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'DEFTER001');
UPDATE StockCards SET CurrentStock = 10 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'YAZICI001');
UPDATE StockCards SET CurrentStock = 8 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'MASA001');

-- Fatura 3 ürünleri
UPDATE StockCards SET CurrentStock = 100 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'SABUN001');
UPDATE StockCards SET CurrentStock = 80 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'DETERJAN001');
UPDATE StockCards SET CurrentStock = 150 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'KAGIT001');

-- Stok hareketleri oluştur
INSERT INTO StockTransactions (ProductID, WarehouseID, TransactionDate, TransactionType, Quantity, UnitPrice, TotalAmount, Description, DocumentType, DocumentNo, CreatedBy)
SELECT 
    pid.ProductID, 
    pi.WarehouseID, 
    pi.InvoiceDate, 
    'GIRIS', 
    pid.Quantity, 
    pid.UnitPrice, 
    pid.NetTotal,
    'Alış Faturası: ' + pi.InvoiceNo,
    'ALIS',
    pi.InvoiceNo,
    1
FROM PurchaseInvoices pi
INNER JOIN PurchaseInvoiceDetails pid ON pi.InvoiceID = pid.InvoiceID
WHERE pi.Status = 'APPROVED';

-- Cari hareketleri oluştur (tedarikçi borçları)
INSERT INTO CariTransactions (CariID, TransactionDate, TransactionType, Amount, Description, DocumentType, DocumentNo, CreatedBy)
SELECT 
    pi.CariID,
    pi.InvoiceDate,
    'BORC',
    pi.Total,
    'Alış Faturası: ' + pi.InvoiceNo,
    'FATURA',
    pi.InvoiceNo,
    1
FROM PurchaseInvoices pi
WHERE pi.Status = 'APPROVED';

-- Cari bakiyeleri güncelle
UPDATE ca
SET CurrentBalance = ca.CurrentBalance - pi.Total
FROM CariAccounts ca
INNER JOIN PurchaseInvoices pi ON ca.CariID = pi.CariID
WHERE pi.Status = 'APPROVED';

PRINT 'Purchase invoices approved and stocks updated.';

-- =================================================================================
-- 7. SATIŞ FATURALARı
-- =================================================================================

-- Satış Faturası 1
INSERT INTO SalesInvoices (InvoiceNo, CariID, WarehouseID, InvoiceDate, DueDate, Status, CreatedBy) VALUES
('SF2024001', (SELECT CariID FROM CariAccounts WHERE CariCode = 'MUS001'), 1, '2024-01-25', '2024-02-25', 'DRAFT', 1);

INSERT INTO SalesInvoiceDetails (InvoiceID, ProductID, Quantity, UnitPrice, VatRate, LineTotal, VatAmount, NetTotal, CreatedBy) VALUES
(1, (SELECT ProductID FROM Products WHERE ProductCode = 'LAPTOP001'), 5, 25000.00, 18.00, 125000.00, 22500.00, 147500.00, 1),
(1, (SELECT ProductID FROM Products WHERE ProductCode = 'PHONE001'), 8, 35000.00, 18.00, 280000.00, 50400.00, 330400.00, 1),
(1, (SELECT ProductID FROM Products WHERE ProductCode = 'MONITOR001'), 10, 8500.00, 18.00, 85000.00, 15300.00, 100300.00, 1);

-- Satış Faturası 2
INSERT INTO SalesInvoices (InvoiceNo, CariID, WarehouseID, InvoiceDate, DueDate, Status, CreatedBy) VALUES
('SF2024002', (SELECT CariID FROM CariAccounts WHERE CariCode = 'MUS002'), 1, '2024-01-28', '2024-02-28', 'DRAFT', 1);

INSERT INTO SalesInvoiceDetails (InvoiceID, ProductID, Quantity, UnitPrice, VatRate, LineTotal, VatAmount, NetTotal, CreatedBy) VALUES
(2, (SELECT ProductID FROM Products WHERE ProductCode = 'KALEM001'), 100, 15.00, 18.00, 1500.00, 270.00, 1770.00, 1),
(2, (SELECT ProductID FROM Products WHERE ProductCode = 'DEFTER001'), 50, 25.00, 18.00, 1250.00, 225.00, 1475.00, 1),
(2, (SELECT ProductID FROM Products WHERE ProductCode = 'YAZICI001'), 3, 3500.00, 18.00, 10500.00, 1890.00, 12390.00, 1);

-- Fatura toplamlarını güncelle
UPDATE SalesInvoices 
SET SubTotal = (SELECT SUM(LineTotal) FROM SalesInvoiceDetails WHERE InvoiceID = 1),
    VatAmount = (SELECT SUM(VatAmount) FROM SalesInvoiceDetails WHERE InvoiceID = 1),
    Total = (SELECT SUM(NetTotal) FROM SalesInvoiceDetails WHERE InvoiceID = 1)
WHERE InvoiceID = 1;

UPDATE SalesInvoices 
SET SubTotal = (SELECT SUM(LineTotal) FROM SalesInvoiceDetails WHERE InvoiceID = 2),
    VatAmount = (SELECT SUM(VatAmount) FROM SalesInvoiceDetails WHERE InvoiceID = 2),
    Total = (SELECT SUM(NetTotal) FROM SalesInvoiceDetails WHERE InvoiceID = 2)
WHERE InvoiceID = 2;

-- Satış faturalarını onayla
UPDATE SalesInvoices SET Status = 'APPROVED' WHERE InvoiceID IN (1, 2);

-- Stokları güncelle (çıkış)
UPDATE StockCards SET CurrentStock = CurrentStock - 5 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'LAPTOP001');
UPDATE StockCards SET CurrentStock = CurrentStock - 8 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'PHONE001');
UPDATE StockCards SET CurrentStock = CurrentStock - 10 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'MONITOR001');
UPDATE StockCards SET CurrentStock = CurrentStock - 100 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'KALEM001');
UPDATE StockCards SET CurrentStock = CurrentStock - 50 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'DEFTER001');
UPDATE StockCards SET CurrentStock = CurrentStock - 3 WHERE ProductID = (SELECT ProductID FROM Products WHERE ProductCode = 'YAZICI001');

-- Satış stok hareketleri oluştur
INSERT INTO StockTransactions (ProductID, WarehouseID, TransactionDate, TransactionType, Quantity, UnitPrice, TotalAmount, Description, DocumentType, DocumentNo, CreatedBy)
SELECT 
    sid.ProductID, 
    si.WarehouseID, 
    si.InvoiceDate, 
    'CIKIS', 
    sid.Quantity, 
    sid.UnitPrice, 
    sid.NetTotal,
    'Satış Faturası: ' + si.InvoiceNo,
    'SATIS',
    si.InvoiceNo,
    1
FROM SalesInvoices si
INNER JOIN SalesInvoiceDetails sid ON si.InvoiceID = sid.InvoiceID
WHERE si.Status = 'APPROVED';

-- Cari hareketleri oluştur (müşteri alacakları)
INSERT INTO CariTransactions (CariID, TransactionDate, TransactionType, Amount, Description, DocumentType, DocumentNo, CreatedBy)
SELECT 
    si.CariID,
    si.InvoiceDate,
    'ALACAK',
    si.Total,
    'Satış Faturası: ' + si.InvoiceNo,
    'FATURA',
    si.InvoiceNo,
    1
FROM SalesInvoices si
WHERE si.Status = 'APPROVED';

-- Cari bakiyeleri güncelle
UPDATE ca
SET CurrentBalance = ca.CurrentBalance + si.Total
FROM CariAccounts ca
INNER JOIN SalesInvoices si ON ca.CariID = si.CariID
WHERE si.Status = 'APPROVED';

PRINT 'Sales invoices approved and stocks updated.';

-- =================================================================================
-- 8. ÖDEME VE TAHSİLATLAR
-- =================================================================================

-- Tedarikçiye ödeme
INSERT INTO Payments (PaymentNo, CariID, PaymentDate, Amount, PaymentTypeID, Description, Status, CreatedBy) VALUES
('ODE2024001', (SELECT CariID FROM CariAccounts WHERE CariCode = 'TED001'), '2024-02-01', 500000.00, 3, 'Kısmi ödeme - Havale', 'COMPLETED', 1);

-- Müşteriden tahsilat
INSERT INTO Collections (CollectionNo, CariID, CollectionDate, Amount, PaymentTypeID, Description, Status, CreatedBy) VALUES
('TAH2024001', (SELECT CariID FROM CariAccounts WHERE CariCode = 'MUS001'), '2024-02-05', 300000.00, 1, 'Kısmi tahsilat - Nakit', 'COMPLETED', 1);

-- Ödeme cari hareketleri
INSERT INTO CariTransactions (CariID, TransactionDate, TransactionType, Amount, Description, DocumentType, DocumentNo, CreatedBy)
SELECT CariID, PaymentDate, 'ALACAK', Amount, 'Ödeme: ' + PaymentNo, 'ODEME', PaymentNo, 1
FROM Payments WHERE Status = 'COMPLETED';

-- Tahsilat cari hareketleri
INSERT INTO CariTransactions (CariID, TransactionDate, TransactionType, Amount, Description, DocumentType, DocumentNo, CreatedBy)
SELECT CariID, CollectionDate, 'BORC', Amount, 'Tahsilat: ' + CollectionNo, 'TAHSILAT', CollectionNo, 1
FROM Collections WHERE Status = 'COMPLETED';

-- Cari bakiyelerini güncelle
UPDATE ca SET CurrentBalance = CurrentBalance + p.Amount
FROM CariAccounts ca
INNER JOIN Payments p ON ca.CariID = p.CariID
WHERE p.Status = 'COMPLETED';

UPDATE ca SET CurrentBalance = CurrentBalance - c.Amount
FROM CariAccounts ca
INNER JOIN Collections c ON ca.CariID = c.CariID
WHERE c.Status = 'COMPLETED';

PRINT 'Payments and collections processed.';

-- =================================================================================
-- 9. RAPORLAMA VE KONTROL
-- =================================================================================

PRINT '==========================================';
PRINT '           TEST DATA SUMMARY              ';
PRINT '==========================================';

-- Cari durum raporu
PRINT 'CARI HESAP DURUMLARI:';
SELECT 
    ca.CariCode,
    ca.CariName,
    ct.TypeName,
    FORMAT(ca.CurrentBalance, 'C', 'tr-TR') AS CurrentBalance,
    CASE 
        WHEN ca.CurrentBalance > 0 THEN 'ALACAK'
        WHEN ca.CurrentBalance < 0 THEN 'BORÇ'
        ELSE 'SIFIR'
    END AS DurumTipi
FROM CariAccounts ca
INNER JOIN CariTypes ct ON ca.TypeID = ct.TypeID
WHERE ca.CurrentBalance != 0
ORDER BY ca.CurrentBalance DESC;

-- Stok durum raporu
PRINT '';
PRINT 'STOK DURUMLARI:';
SELECT 
    p.ProductCode,
    p.ProductName,
    sc.CurrentStock,
    sc.ReservedStock,
    (sc.CurrentStock - sc.ReservedStock) AS AvailableStock,
    u.UnitName,
    FORMAT(p.SalePrice, 'C', 'tr-TR') AS SalePrice
FROM StockCards sc
INNER JOIN Products p ON sc.ProductID = p.ProductID
INNER JOIN Units u ON p.UnitID = u.UnitID
WHERE sc.CurrentStock > 0
ORDER BY sc.CurrentStock DESC;

-- Fatura özeti
PRINT '';
PRINT 'FATURA ÖZETLERİ:';
SELECT 'ALIŞ FATURALARı' AS FaturaType, COUNT(*) AS Adet, FORMAT(SUM(Total), 'C', 'tr-TR') AS ToplamTutar
FROM PurchaseInvoices WHERE Status = 'APPROVED'
UNION ALL
SELECT 'SATIŞ FATURALARı', COUNT(*), FORMAT(SUM(Total), 'C', 'tr-TR')
FROM SalesInvoices WHERE Status = 'APPROVED';

-- Kullanıcı sistemi özeti
PRINT '';
PRINT 'KULLANICI SİSTEMİ:';
SELECT 
    'Username: ' + u.Username + ' | Password: ' + u.Password + ' | Role: ' + r.RoleName AS LoginInfo
FROM Users u 
INNER JOIN UserRoles ur ON u.UserID = ur.UserID
INNER JOIN Roles r ON ur.RoleID = r.RoleID
WHERE u.IsActive = 1
ORDER BY u.UserID;

PRINT '';
PRINT '==========================================';
PRINT 'Test data insertion completed successfully!';
PRINT 'Database is ready for API development.';
PRINT '';
PRINT 'LOGIN CREDENTIALS FOR TESTING:';
PRINT '- admin/admin (Full Admin Access)';
PRINT '- manager/manager (Manager Access)';
PRINT '- employee/employee (Employee Access)';
PRINT '- finance/finance (Finance Access)';
PRINT '';
PRINT 'WEB APPLICATION:';
PRINT '1. Start API: cd MiniERP.API && dotnet run';
PRINT '2. Start Web: cd MiniERP.Web && dotnet run';
PRINT '3. Login with any test user above';
PRINT '4. Test role-based menu and authorization';
PRINT '==========================================';

GO 