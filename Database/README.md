# 🗄️ MiniERP Database Kurulumu

## 🚀 Hızlı Başlangıç

### 1️⃣ Database Kurulumu
```sql
-- SQL Server Management Studio'da çalıştırın:
```
1. `MiniERP_Clean.sql` dosyasını SQL Server'da çalıştırın
2. (Opsiyonel) `Test_Data_Insert.sql` dosyasını çalıştırın

### 2️⃣ Projelen Çalıştırma
```bash
# 1. API'yi başlatın (Terminal 1)
cd MiniERP.API
dotnet run

# 2. Web'i başlatın (Terminal 2)  
cd MiniERP.Web
dotnet run
```

### 3️⃣ Giriş Yapın
- **URL**: http://localhost:5000
- **Kullanıcı**: admin
- **Şifre**: 123456

## 📁 Dosya Açıklaması

| Dosya | Açıklama | Zorunlu |
|-------|----------|---------|
| `MiniERP_Clean.sql` | Ana database script | ✅ |
| `Test_Data_Insert.sql` | Örnek veriler | ❌ |
| `Database_Documentation.md` | Detaylı dokümantasyon | ❌ |

## 🔑 Test Kullanıcıları

| Kullanıcı | Şifre | Rol | Yetki |
|-----------|-------|-----|-------|
| admin | 123456 | Admin | Tam yetki |
| manager | 123456 | Manager | Yönetici |
| sales | 123456 | Sales | Satış |
| purchase | 123456 | Purchase | Satın alma |
| finance | 123456 | Finance | Finans |
| warehouse | 123456 | Warehouse | Depo |

## ❗ Önemli Notlar

- Database adı: **MiniERPTrial**
- SQL Server Express desteklenir
- API Swagger: http://localhost:5135/swagger
- **Prodüksiyonda şifreleri değiştirin!**

## 🆘 Sorun Giderme

**Database bağlantı hatası?**
- Connection string'i kontrol edin (appsettings.json)
- SQL Server servisinin çalıştığından emin olun

**Login olmuyor?**
- Test kullanıcılarının oluştuğunu kontrol edin
- Browser cache'ini temizleyin

**API çalışmıyor?**
- Port 5135'in boş olduğundan emin olun
- Database bağlantısını kontrol edin
