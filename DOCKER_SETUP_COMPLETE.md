# MiniERP Docker Kurulum Tamamlandı

## Sistem Durumu

✅ **Container'lar Başarıyla Çalışıyor:**
- **SQL Server**: `minierp-sqlserver` (Port: 1433) - Healthy
- **MiniERP API**: `minierp-api` (Port: 5000) - Running
- **MiniERP Web**: `minierp-web` (Port: 5001) - Running

✅ **Veritabanı**: MiniERPTrial veritabanı başarıyla oluşturuldu

✅ **Ağ ve Volume'lar**: Düzgün şekilde yapılandırıldı

## Erişim Bilgileri

### Web Uygulamaları
- **Web Frontend**: http://localhost:5001
- **API Backend**: http://localhost:5000
- **API Swagger**: http://localhost:5000/swagger

### Veritabanı
- **Sunucu**: localhost:1433
- **Kullanıcı**: sa
- **Şifre**: MiniERP123!
- **Veritabanı**: MiniERPTrial

## Kullanılabilir Komutlar

### Windows (Batch Script)
```cmd
# Container'ları başlat
docker-setup.bat up

# Container'ları durdur
docker-setup.bat down

# Container'ları yeniden başlat
docker-setup.bat restart

# Durumu kontrol et
docker-setup.bat status

# Logları görüntüle
docker-setup.bat logs

# Temizlik
docker-setup.bat clean
```

### Linux/MacOS (Shell Script)
```bash
# Container'ları başlat
./docker-setup.sh up

# Container'ları durdur
./docker-setup.sh down

# Container'ları yeniden başlat
./docker-setup.sh restart

# Durumu kontrol et
./docker-setup.sh status

# Logları görüntüle
./docker-setup.sh logs

# Temizlik
./docker-setup.sh clean
```

### Doğrudan Docker Compose
```bash
# Container'ları başlat
docker-compose up -d

# Container'ları durdur
docker-compose down

# Durumu kontrol et
docker-compose ps

# Logları görüntüle
docker-compose logs -f
```

## Oluşturulan Dosyalar

1. **Dockerfile'lar**:
   - `MiniERP.API/Dockerfile` - .NET 8.0 API container
   - `MiniERP.Web/Dockerfile` - .NET 9.0 Web container

2. **Docker Compose**:
   - `docker-compose.yml` - Production yapılandırması
   - `docker-compose.dev.yml` - Development override

3. **Yapılandırma**:
   - `.dockerignore` - Docker build exclude listesi
   - `MiniERP.API/appsettings.Production.json` - API production ayarları
   - `MiniERP.Web/appsettings.Production.json` - Web production ayarları

4. **Yönetim Scriptleri**:
   - `docker-setup.bat` - Windows yönetim scripti
   - `docker-setup.sh` - Linux/MacOS yönetim scripti

5. **Dokümantasyon**:
   - `DOCKER_README.md` - Detaylı kullanım rehberi

## Teknik Detaylar

### Container Yapılandırması
- **Base Images**: Microsoft resmi .NET runtime ve SDK image'ları
- **Multi-stage Build**: Optimum container boyutu için
- **Health Checks**: SQL Server için otomatik sağlık kontrolü
- **Volume Mounts**: Persistent data ve log depolama
- **Network**: Isolated bridge network (`minierp-network`)

### Güvenlik
- SQL Server: Custom password ile yapılandırıldı
- Network isolation: Container'lar arası izole haberleşme
- TLS: Production için TrustServerCertificate ayarı

### Performance
- .NET AOT compilation: Hızlı başlangıç için
- Layer caching: Docker build optimizasyonu
- Volume separation: Log ve data ayrımı

## Development Modu

Development için ayrı yapılandırma:
```bash
docker-compose -f docker-compose.yml -f docker-compose.dev.yml up -d
```

Bu modda:
- Environment: Development
- Farklı portlar (1434 SQL, 5002/5003 debug)
- Volume mount: Kod değişiklikleri için
- Detaylı logging

## Önemli Notlar

1. **Windows Forms**: GUI gerektirdiği için Docker'da çalıştırılamaz
2. **Memory**: En az 4GB RAM gerekli
3. **Port Conflicts**: 1433, 5000, 5001 portları kullanılıyor
4. **SQL Tools**: sqlcmd v18 kullanılıyor (son sürüm SQL Server için)

Container'lar başarıyla çalışıyor ve sistem production-ready durumda!
