# MiniERP Database Documentation

## 📋 Kurulum Talimatları

### Sıfırdan Kurulum
1. **Ana Database Script**: `MiniERP_Clean.sql` dosyasını çalıştırın
   - Database oluşturur
   - Tüm tabloları oluşturur
   - İlişkileri kurar
   - Default rolleri ve admin kullanıcısını oluşturur

2. **Test Verileri** (Opsiyonel): `Test_Data_Insert.sql` dosyasını çalıştırın
   - Örnek ürünler
   - Örnek cari hesaplar
   - Test faturaları

### 🗂️ Dosya Yapısı
- `MiniERP_Clean.sql` - Ana database script (ZORUNLU)
- `Test_Data_Insert.sql` - Test verileri (OPSİYONEL)
- `Database_Documentation.md` - Bu dokümantasyon

## 🏗️ Genel Bakış

MiniERP sistemi için tasarlanmış SQL Server veritabanı. Aşağıdaki modülleri destekler:
- **Kullanıcı Yönetimi**: Kullanıcı hesapları ve rol bazlı yetkilendirme
- **Cari Yönetimi**: Müşteri/Tedarikçi hesapları ve bakiye takibi
- **Stok Yönetimi**: Ürün yönetimi ve stok kartları
- **Alış Yönetimi**: Satın alma faturaları ve stok güncelleme
- **Satış Yönetimi**: Satış faturaları ve stok güncelleme
- **Depo Yönetimi**: Depo yönetimi ve stok dağılımı
- **Ödeme Yönetimi**: Ödeme ve tahsilat takibi

## 📊 Tablo Yapısı

### 1. 👥 Kullanıcı ve Yetkilendirme
- **Users**: Kullanıcı bilgileri (LastLoginDate dahil)
- **Roles**: Sistem rolleri (Admin, Manager, Sales, Purchase, Finance, Warehouse, Employee)
- **UserRoles**: Kullanıcı-rol ilişkisi

### 2. 📚 Temel Tanımlar
- **Units**: Birim tanımları (Adet, Kg, Lt, vb.)
- **ProductCategories**: Ürün kategorileri
- **CariTypes**: Cari tipleri (Müşteri, Tedarikçi, Her İkisi)
- **PaymentTypes**: Ödeme türleri (Nakit, Kredi, Havale, vb.)

### 3. 🏢 Cari Yönetimi
- **CariAccounts**: Cari hesap bilgileri
- **CariTransactions**: Cari hareket kayıtları (Borç/Alacak)

### 4. 📦 Stok Yönetimi
- **Products**: Ürün bilgileri
- **StockCards**: Depo bazında stok durumu (Location, Notes, ReorderLevel, ReorderQuantity dahil)
- **StockTransactions**: Stok hareket kayıtları

### 5. 🏪 Depo Yönetimi
- **Warehouses**: Depo bilgileri

### 6. 🛒 Satış Yönetimi
- **SalesInvoices**: Satış fatura başlıkları
- **SalesInvoiceDetails**: Satış fatura detayları

### 7. 📋 Alış Yönetimi
- **PurchaseInvoices**: Alış fatura başlıkları
- **PurchaseInvoiceDetails**: Alış fatura detayları

### 8. 💰 Ödeme Yönetimi
- **Payments**: Tedarikçiye yapılan ödemeler
- **Collections**: Müşterilerden yapılan tahsilatlar

## ⚡ Yeni Özellikler (Son Güncelleme)

### Otomatik Senkronizasyon
1. **Satış Faturası Onaylandığında**:
   - Stok otomatik azalır
   - Cari hesapta alacak kaydı oluşur
   - Stok hareket kaydı oluşur

2. **Alış Faturası Onaylandığında**:
   - Stok otomatik artar
   - Cari hesapta borç kaydı oluşur
   - Stok hareket kaydı oluşur

3. **Ödeme Yapıldığında**:
   - Cari bakiye otomatik güncellenir
   - Cari hareket kaydı oluşur

4. **Tahsilat Yapıldığında**:
   - Cari bakiye otomatik güncellenir
   - Cari hareket kaydı oluşur

### Trigger'lar
- `TR_SalesInvoice_StockUpdate`: Satış faturası onaylandığında stok ve cari güncelleme
- `TR_PurchaseInvoice_StockUpdate`: Alış faturası onaylandığında stok ve cari güncelleme
- `TR_Payment_CariUpdate`: Ödeme yapıldığında cari güncelleme
- `TR_Collection_CariUpdate`: Tahsilat yapıldığında cari güncelleme
- `TR_SalesInvoiceDetails_UpdateTotals`: Satış fatura toplamları otomatik hesaplama
- `TR_PurchaseInvoiceDetails_UpdateTotals`: Alış fatura toplamları otomatik hesaplama

### Varsayılan Veriler
- **Roller**: Admin, Manager, Employee, Finance
- **Test Kullanıcıları**: 
  - admin/admin (Admin Role - Tüm yetkiler)
  - manager/manager (Manager Role - Yönetim yetkileri)
  - employee/employee (Employee Role - Temel işlem yetkileri)
  - finance/finance (Finance Role - Mali işlemler)
- **Cari Tipleri**: Müşteri, Tedarikçi, Her İkisi
- **Birimler**: Adet, Kg, Lt, M, M2, M3, Paket, Kutu
- **Ödeme Türleri**: Nakit, Kredi Kartı, Havale, Çek, Senet
- **Varsayılan Depo**: Ana Depo

## Kullanım Notları

### Fatura İşlem Akışı
1. **Taslak Fatura**: Status = 'DRAFT' (Stok ve cari etkilenmez)
2. **Onaylı Fatura**: Status = 'APPROVED' (Stok ve cari otomatik güncellenir)
3. **İptal Fatura**: Status = 'CANCELLED' (İşlem yapılmaz)

### Stok Yönetimi
- Her ürün için depo bazında stok kartı tutulur
### 🔒 Kullanıcı Yönetimi
- **LastLoginDate**: Kullanıcıların son giriş tarihi takibi
- **Rol bazlı yetkilendirme**: 7 farklı rol (Admin, Manager, Sales, Purchase, Finance, Warehouse, Employee)
- **Güvenli şifre saklama**: Hash'lenmiş şifreler

### 📦 Geliştirilmiş Stok Yönetimi
- **Location**: Stok kartlarında konum bilgisi
- **Notes**: Stok kartları için notlar
- **ReorderLevel**: Yeniden sipariş seviyesi
- **ReorderQuantity**: Yeniden sipariş miktarı
- **IsActive**: Stok kartı aktiflik durumu

### 🎯 Önemli Özellikler
- Stok hareketleri detaylı olarak kaydedilir
- Minimum/maksimum stok seviyeleri takip edilir
- Cari bakiye otomatik hesaplama
- Kredi limiti kontrolü
- Detaylı hareket takibi

### ⚡ Performans Optimizasyonları
- Önemli tablolar için index'ler
- Computed column'lar (AvailableStock)
- Optimize edilmiş trigger'lar

## 🚀 Default Kullanıcılar

Ana script çalıştırıldıktan sonra aşağıdaki kullanıcılar otomatik oluşturulur:

| Kullanıcı Adı | Şifre | Rol | Açıklama |
|---------------|-------|-----|----------|
| admin | 123456 | Admin | Tam yetki |
| manager | 123456 | Manager | Yönetici yetkisi |
| sales | 123456 | Sales | Satış yetkisi |
| purchase | 123456 | Purchase | Satın alma yetkisi |
| finance | 123456 | Finance | Finans yetkisi |
| warehouse | 123456 | Warehouse | Depo yetkisi |

⚠️ **Güvenlik Uyarısı**: Prodüksiyon ortamında mutlaka şifreleri değiştirin!

## 📝 Sürüm Notları

### v2.1 (Son Güncelleme)
- ✅ Users tablosuna LastLoginDate eklendi
- ✅ StockCards tablosuna Location, Notes, ReorderLevel, ReorderQuantity, IsActive eklendi
- ✅ Gereksiz update script'leri kaldırıldı
- ✅ Tek script ile kurulum sağlandı

### v2.0
- Kapsamlı ERP sistemi
- Kullanıcı yönetimi entegrasyonu
- Gelişmiş stok yönetimi 