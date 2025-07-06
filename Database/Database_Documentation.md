# MiniERP Database Documentation

## Genel Bakış

MiniERP sistemi için tasarlanmış SQL Server veritabanı. Aşağıdaki modülleri destekler:
- **Cari Yönetimi**: Müşteri/Tedarikçi hesapları ve bakiye takibi
- **Stok Yönetimi**: Ürün yönetimi ve stok kartları
- **Alış Yönetimi**: Satın alma faturaları ve stok güncelleme
- **Satış Yönetimi**: Satış faturaları ve stok güncelleme
- **Depo Yönetimi**: Depo yönetimi ve stok dağılımı

## Tablo Yapısı

### 1. Kullanıcı ve Yetkilendirme
- **Users**: Kullanıcı bilgileri
- **Roles**: Sistem rolleri (Admin, Manager, Sales, Purchase, Warehouse, Finance)
- **UserRoles**: Kullanıcı-rol ilişkisi

### 2. Temel Tanımlar
- **Units**: Birim tanımları (Adet, Kg, Lt, vb.)
- **ProductCategories**: Ürün kategorileri
- **CariTypes**: Cari tipleri (Müşteri, Tedarikçi, Her İkisi)
- **PaymentTypes**: Ödeme türleri (Nakit, Kredi, Havale, vb.)

### 3. Cari Yönetimi
- **CariAccounts**: Cari hesap bilgileri
- **CariTransactions**: Cari hareket kayıtları (Borç/Alacak)

### 4. Stok Yönetimi
- **Products**: Ürün bilgileri
- **StockCards**: Depo bazında stok durumu
- **StockTransactions**: Stok hareket kayıtları

### 5. Depo Yönetimi
- **Warehouses**: Depo bilgileri

### 6. Satış Yönetimi
- **SalesInvoices**: Satış fatura başlıkları
- **SalesInvoiceDetails**: Satış fatura detayları

### 7. Alış Yönetimi
- **PurchaseInvoices**: Alış fatura başlıkları
- **PurchaseInvoiceDetails**: Alış fatura detayları

### 8. Ödeme Yönetimi
- **Payments**: Tedarikçiye yapılan ödemeler
- **Collections**: Müşterilerden yapılan tahsilatlar

## Önemli Özellikler

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
- **Roller**: Admin, Manager, Sales, Purchase, Warehouse, Finance
- **Cari Tipleri**: Müşteri, Tedarikçi, Her İkisi
- **Birimler**: Adet, Kg, Lt, M, M2, M3, Paket, Kutu
- **Ödeme Türleri**: Nakit, Kredi Kartı, Havale, Çek, Senet
- **Varsayılan Depo**: Ana Depo
- **Admin Kullanıcı**: admin / 123456

## Kullanım Notları

### Fatura İşlem Akışı
1. **Taslak Fatura**: Status = 'DRAFT' (Stok ve cari etkilenmez)
2. **Onaylı Fatura**: Status = 'APPROVED' (Stok ve cari otomatik güncellenir)
3. **İptal Fatura**: Status = 'CANCELLED' (İşlem yapılmaz)

### Stok Yönetimi
- Her ürün için depo bazında stok kartı tutulur
- Stok hareketleri detaylı olarak kaydedilir
- Minimum/maksimum stok seviyeleri takip edilir

### Cari Yönetimi
- Borç/Alacak durumu otomatik hesaplanır
- Kredi limiti kontrolü yapılabilir
- Tüm cari hareketleri detaylı takip edilir

### Performans
- Önemli tablolar için index'ler oluşturulmuştur
- Computed column'lar kullanılmıştır (AvailableStock)
- Trigger'lar optimize edilmiştir

## Kurulum

1. SQL Server'da `MiniERP_Database.sql` dosyasını çalıştırın
2. Varsayılan admin kullanıcısı: `admin` / `123456`
3. Varsayılan depo: `ANA` (Ana Depo)
4. Sistem kullanıma hazır! 