# MiniERP Docker Container Kurulum Rehberi

Bu rehber, MiniERP projesini Docker container'ları olarak çalıştırmak için gerekli adımları açıklar.

## Gereksinimler

- Docker Desktop (Windows/Mac) veya Docker Engine (Linux)
- Docker Compose
- Minimum 4GB RAM
- Minimum 10GB disk alanı

## Proje Yapısı

Projede 3 ana servis bulunmaktadır:

1. **SQL Server** - Veritabanı servisi
2. **MiniERP.API** - Backend API servisi (.NET 8.0)
3. **MiniERP.Web** - Frontend Web servisi (.NET 9.0)

**Not:** Windows Forms uygulaması (MiniERP.WinForms) GUI gerektirdiği için Docker'da çalıştırılamaz.

## Hızlı Başlangıç

### Windows Kullanıcıları

```cmd
# İlk kurulum için
docker-setup.bat init

# Sadece container'ları başlatmak için
docker-setup.bat up

# Container'ları durdurmak için
docker-setup.bat down
```

### Linux/MacOS Kullanıcıları

```bash
# Script'i çalıştırılabilir yap
chmod +x docker-setup.sh

# İlk kurulum için
./docker-setup.sh init

# Sadece container'ları başlatmak için
./docker-setup.sh up

# Container'ları durdurmak için
./docker-setup.sh down
```

## Manuel Kurulum

### 1. Image'ları Build Et

```bash
docker-compose build --no-cache
```

### 2. Container'ları Başlat

```bash
docker-compose up -d
```

### 3. Veritabanını Initialize Et

SQL Server container'ı başlatıldıktan sonra veritabanını oluşturmak için:

```bash
# Windows
docker exec -i minierp-sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P MiniERP123! -C < Database/MiniERP_Clean.sql

# Linux/MacOS
docker exec -i minierp-sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P MiniERP123! -C < Database/MiniERP_Clean.sql
```

## Servis URL'leri

Container'lar başarıyla çalıştıktan sonra aşağıdaki URL'lerden erişebilirsiniz:

- **Web Frontend**: http://localhost:5001
- **API Backend**: http://localhost:5000
- **API Swagger**: http://localhost:5000/swagger
- **SQL Server**: localhost:1433 (sa/MiniERP123!)

## Kullanışlı Komutlar

### Container Durumlarını Kontrol Et

```bash
docker-compose ps
```

### Logları Görüntüle

```bash
# Tüm servislerin logları
docker-compose logs -f

# Sadece API logları
docker-compose logs -f minierp-api

# Sadece Web logları
docker-compose logs -f minierp-web
```

### Container'ları Yeniden Başlat

```bash
docker-compose restart
```

### Container'ları Durdur ve Kaldır

```bash
docker-compose down
```

### Volume'lar ile Birlikte Temizle

```bash
docker-compose down -v
```

## Veritabanı Bağlantısı

Container içindeki uygulamalar için:
- **Connection String**: `Data Source=sqlserver,1433;Initial Catalog=MiniERPTrial;User ID=sa;Password=MiniERP123!;TrustServerCertificate=true`

Dış erişim için (SQL Server Management Studio, etc.):
- **Server**: `localhost,1433`
- **Authentication**: SQL Server Authentication
- **Login**: `sa`
- **Password**: `MiniERP123!`

## Environment Variables

### API Container
- `ASPNETCORE_ENVIRONMENT=Production`
- `ASPNETCORE_URLS=http://+:8080`
- `ConnectionStrings__DefaultConnection`: SQL Server bağlantı string'i

### Web Container
- `ASPNETCORE_ENVIRONMENT=Production`
- `ASPNETCORE_URLS=http://+:8080`
- `ApiBaseUrl=http://minierp-api:8080`

## Volume'lar

- `sqlserver_data`: SQL Server veritabanı dosyaları
- `api_logs`: API uygulama logları

## Network

Tüm container'lar `minierp-network` adlı bridge network üzerinde haberleşir.

## Sorun Giderme

### Container'lar başlamıyor

```bash
# Logları kontrol et
docker-compose logs

# Port çakışması kontrolü
netstat -tulpn | grep :5000
netstat -tulpn | grep :5001
netstat -tulpn | grep :1433
```

### Veritabanı bağlantı sorunu

```bash
# SQL Server container'ının sağlıklı olup olmadığını kontrol et
docker exec minierp-sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P MiniERP123! -C -Q "SELECT 1"
```

### Temiz başlangıç

```bash
# Tüm container, image ve volume'ları temizle
docker-compose down -v --rmi all
docker system prune -a -f

# Yeniden build et
docker-compose build --no-cache
docker-compose up -d
```

### Performance Sorunları

- Docker Desktop için memory ayarını en az 4GB yap
- Windows'ta WSL2 backend kullandığınızdan emin olun
- Antivirus yazılımının Docker folder'larını exclude ettiğinden emin olun

## Güvenlik Notları

- Production ortamında `SA_PASSWORD` değiştirilmelidir
- JWT secret key production için değiştirilmelidir
- Firewall kuralları container portlarını koruyacak şekilde ayarlanmalıdır

## Development için

Development ortamında çalışırken:

```bash
# Development mode
docker-compose -f docker-compose.yml -f docker-compose.dev.yml up -d
```

Bu durumda kod değişiklikleri için volume mount kullanabilirsiniz.
