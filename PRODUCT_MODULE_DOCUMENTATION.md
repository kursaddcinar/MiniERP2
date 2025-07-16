# Ürün Yönetimi Modülü - Windows Forms

Bu dokümanda Windows Forms uygulamasına eklenen ürün yönetimi modülünün detayları bulunmaktadır.

## Genel Özellikler

### 1. Ana Ürün Listesi Formu (UrunlerForm)
- **Dosya**: `UrunlerForm.cs` ve `UrunlerForm.Designer.cs`
- **Özellikler**:
  - Üst kısımda başlık ve "Yeni Ürün" butonu
  - Arama ve filtreleme paneli (ürün adı/kodu, kategori, sayfa boyutu)
  - DataGridView ile ürün listesi
  - Alt kısımda istatistikler (toplam, aktif, pasif)

### 2. Yeni Ürün Ekleme Formu (UrunEkleForm)
- **Dosya**: `UrunEkleForm.cs` ve `UrunEkleForm.Designer.cs`
- **Alanlar**:
  - Ürün Kodu (zorunlu)
  - Ürün Adı (zorunlu)
  - Kategori (opsiyonel)
  - Birim (zorunlu)
  - Satış Fiyatı (zorunlu)
  - Alış Fiyatı (zorunlu)
  - KDV Oranı
  - Min/Max Stok Seviyeleri
  - Aktif/Pasif durumu

### 3. Ürün Detayları Formu (UrunDetayForm)
- **Dosya**: `UrunDetayForm.cs` ve `UrunDetayForm.Designer.cs`
- **Görüntülenen Bilgiler**:
  - Temel bilgiler (kod, ad, kategori, birim)
  - Fiyat bilgileri (satış, alış, KDV)
  - Stok bilgileri (mevcut, rezerve, kullanılabilir, min/max)
  - Durum bilgileri (aktif/pasif, oluşturma tarihi)

### 4. Ürün Düzenleme Formu (UrunDuzenleForm)
- **Dosya**: `UrunDuzenleForm.cs` ve `UrunDuzenleForm.Designer.cs`
- **Özellikler**:
  - Ürün kodu görüntülenir (değiştirilemez)
  - Diğer tüm alanlar düzenlenebilir
  - Mevcut veriler otomatik yüklenir

## Rol Tabanlı Yetkilendirme

Sistem, kullanıcı rollerine göre aşağıdaki yetkilendirmeleri uygular:

| Rol       | Yetkiler |
|-----------|----------|
| Admin     | CRUD (Tüm işlemler) |
| Manager   | CRUD (Tüm işlemler) |
| Sales     | Read (Sadece okuma) |
| Purchase  | CRUD (Tüm işlemler) |
| Finance   | Yok (Erişim engellendi) |
| Warehouse | Read (Sadece okuma) |

### Yetkilendirme Uygulamaları:
- **Finance** rolü: Ürün formuna hiç erişemez
- **Sales ve Warehouse** rolleri: Sadece görüntüleme, düzenleme ve silme butonları gizli
- **Create yetkisi olmayanlar**: "Yeni Ürün" butonu gizli/deaktif
- **Update/Delete yetkisi olmayanlar**: İlgili işlem butonları context menüde görünmez

## Teknik Detaylar

### API Entegrasyonu:
- `ProductDto`, `CreateProductDto`, `UpdateProductDto` sınıfları
- `ProductCategoryDto`, `UnitDto` için destek sınıfları
- Sayfalama desteği ile performanslı listeleme
- Async/await pattern kullanımı

### Kullanıcı Arayüzü:
- Modern ve responsive tasarım
- Icon'lu butonlar ve anlamlı renkler
- Context menü ile işlem seçenekleri
- Stok seviyelerine göre renk kodları
- Form validation ve kullanıcı dostu hata mesajları

### Güvenlik:
- Null reference kontrolleri
- Input validation
- Role-based access control
- Safe navigation operators kullanımı

## Kullanım

1. Ana formdan "Ürünler" butonuna tıklayın
2. Ürün listesi açılacak
3. Arama yapabilir, filtreleyebilirsiniz
4. Yeni ürün eklemek için "Yeni Ürün" butonunu kullanın
5. Mevcut ürünler üzerinde sağ tıklayarak işlemler menüsüne erişin
6. İşlemler: Detaylar, Düzenle, Sil (yetki durumuna göre)

## Bağımlılıklar

- MiniERP.WinForms.Services.ApiService
- MiniERP.WinForms.DTOs.*
- System.Windows.Forms
- Newtonsoft.Json (API çağrıları için)

## Notlar

- Tüm formlar responsive tasarım ile yapılmıştır
- Kullanıcı deneyimi için loading göstergeleri eklenebilir
- Gelecekte export/import özelikleri eklenebilir
- Stok hareketleri için ayrı modül entegrasyonu planlanabilir
