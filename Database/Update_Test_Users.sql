-- MiniERP - Güncel Test Kullanıcıları (Tüm Roller)
-- Bu script'i veritabanında çalıştırarak güncel kullanıcıları oluşturabilirsiniz

USE MiniERPTrial;
GO

-- Önce mevcut test kullanıcılarını temizle (isteğe bağlı)
-- UYARI: Bu komutları çalıştırırsanız mevcut tüm kullanıcılar silinir!
/*
DELETE FROM UserRoles WHERE UserID IN (SELECT UserID FROM Users WHERE Username IN ('admin', 'manager', 'sales', 'purchase', 'finance', 'warehouse', 'employee'));
DELETE FROM Users WHERE Username IN ('admin', 'manager', 'sales', 'purchase', 'finance', 'warehouse', 'employee');
*/

-- Yeni test kullanıcılarını ekle (sadece eksik olanlar eklenecek)
BEGIN TRY
    -- Admin kullanıcısı
    IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'admin')
    BEGIN
        INSERT INTO Users (Username, Password, Email, FirstName, LastName, IsActive, CreatedBy) 
        VALUES ('admin', 'admin', 'admin@minierp.com', 'Sistem', 'Yöneticisi', 1, 1);
        
        INSERT INTO UserRoles (UserID, RoleID) 
        VALUES ((SELECT UserID FROM Users WHERE Username = 'admin'), 1);
        
        PRINT '✓ Admin kullanıcısı oluşturuldu';
    END
    ELSE PRINT '- Admin kullanıcısı zaten mevcut';

    -- Manager kullanıcısı
    IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'manager')
    BEGIN
        INSERT INTO Users (Username, Password, Email, FirstName, LastName, IsActive, CreatedBy) 
        VALUES ('manager', 'manager', 'manager@minierp.com', 'Genel', 'Müdür', 1, 1);
        
        INSERT INTO UserRoles (UserID, RoleID) 
        VALUES ((SELECT UserID FROM Users WHERE Username = 'manager'), 2);
        
        PRINT '✓ Manager kullanıcısı oluşturuldu';
    END
    ELSE PRINT '- Manager kullanıcısı zaten mevcut';

    -- Sales kullanıcısı
    IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'sales')
    BEGIN
        INSERT INTO Users (Username, Password, Email, FirstName, LastName, IsActive, CreatedBy) 
        VALUES ('sales', 'sales', 'sales@minierp.com', 'Satış', 'Personeli', 1, 1);
        
        INSERT INTO UserRoles (UserID, RoleID) 
        VALUES ((SELECT UserID FROM Users WHERE Username = 'sales'), 3);
        
        PRINT '✓ Sales kullanıcısı oluşturuldu';
    END
    ELSE PRINT '- Sales kullanıcısı zaten mevcut';

    -- Purchase kullanıcısı
    IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'purchase')
    BEGIN
        INSERT INTO Users (Username, Password, Email, FirstName, LastName, IsActive, CreatedBy) 
        VALUES ('purchase', 'purchase', 'purchase@minierp.com', 'Satın Alma', 'Personeli', 1, 1);
        
        INSERT INTO UserRoles (UserID, RoleID) 
        VALUES ((SELECT UserID FROM Users WHERE Username = 'purchase'), 4);
        
        PRINT '✓ Purchase kullanıcısı oluşturuldu';
    END
    ELSE PRINT '- Purchase kullanıcısı zaten mevcut';

    -- Finance kullanıcısı  
    IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'finance')
    BEGIN
        INSERT INTO Users (Username, Password, Email, FirstName, LastName, IsActive, CreatedBy) 
        VALUES ('finance', 'finance', 'finance@minierp.com', 'Muhasebe', 'Personeli', 1, 1);
        
        INSERT INTO UserRoles (UserID, RoleID) 
        VALUES ((SELECT UserID FROM Users WHERE Username = 'finance'), 5);
        
        PRINT '✓ Finance kullanıcısı oluşturuldu';
    END
    ELSE PRINT '- Finance kullanıcısı zaten mevcut';

    -- Warehouse kullanıcısı
    IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'warehouse')
    BEGIN
        INSERT INTO Users (Username, Password, Email, FirstName, LastName, IsActive, CreatedBy) 
        VALUES ('warehouse', 'warehouse', 'warehouse@minierp.com', 'Depo', 'Personeli', 1, 1);
        
        INSERT INTO UserRoles (UserID, RoleID) 
        VALUES ((SELECT UserID FROM Users WHERE Username = 'warehouse'), 6);
        
        PRINT '✓ Warehouse kullanıcısı oluşturuldu';
    END
    ELSE PRINT '- Warehouse kullanıcısı zaten mevcut';

    -- Employee kullanıcısı
    IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'employee')
    BEGIN
        INSERT INTO Users (Username, Password, Email, FirstName, LastName, IsActive, CreatedBy) 
        VALUES ('employee', 'employee', 'employee@minierp.com', 'Genel', 'Çalışan', 1, 1);
        
        INSERT INTO UserRoles (UserID, RoleID) 
        VALUES ((SELECT UserID FROM Users WHERE Username = 'employee'), 7);
        
        PRINT '✓ Employee kullanıcısı oluşturuldu';
    END
    ELSE PRINT '- Employee kullanıcısı zaten mevcut';

END TRY
BEGIN CATCH
    PRINT 'HATA: ' + ERROR_MESSAGE();
END CATCH

-- Kullanıcıları kontrol et
PRINT '';
PRINT '========================================';
PRINT '           KULLANICI LİSTESİ           ';
PRINT '========================================';

SELECT 
    u.Username,
    u.FirstName + ' ' + u.LastName AS FullName,
    r.RoleName,
    u.Email,
    CASE WHEN u.IsActive = 1 THEN 'Aktif' ELSE 'Pasif' END AS Status
FROM Users u
INNER JOIN UserRoles ur ON u.UserID = ur.UserID
INNER JOIN Roles r ON ur.RoleID = r.RoleID
WHERE u.Username IN ('admin', 'manager', 'sales', 'purchase', 'finance', 'warehouse', 'employee')
ORDER BY r.RoleID;

PRINT '';
PRINT '========================================';
PRINT '              ÖZET BİLGİ               ';
PRINT '========================================';
PRINT 'Toplam Test Kullanıcısı: 7';
PRINT 'Tüm şifreler kullanıcı adı ile aynı';
PRINT '';
PRINT 'ROLLER:';
PRINT '1. Admin     - Sistem Yöneticisi (tüm yetkiler)';
PRINT '2. Manager   - Genel Müdür (yönetim yetkileri)';  
PRINT '3. Sales     - Satış Personeli (satış işlemleri)';
PRINT '4. Purchase  - Satın Alma (alış işlemleri)';
PRINT '5. Finance   - Muhasebe (mali işlemler)';
PRINT '6. Warehouse - Depo (stok işlemleri)';
PRINT '7. Employee  - Genel Çalışan (temel yetkiler)';
PRINT '';
PRINT 'Web login sayfasında hızlı giriş butonları';
PRINT 'ile tüm kullanıcıları test edebilirsiniz.';
PRINT '========================================';

GO
