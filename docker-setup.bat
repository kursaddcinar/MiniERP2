@echo off
REM MiniERP Docker Setup ve Yönetim Batch Scripti

setlocal enabledelayedexpansion

echo === MiniERP Docker Setup Script ===
echo.

REM Function to show help
if "%1"=="help" goto :show_help
if "%1"=="--help" goto :show_help
if "%1"=="-h" goto :show_help

REM Main script logic
if "%1"=="build" goto :build_images
if "%1"=="up" goto :start_containers
if "%1"=="down" goto :stop_containers
if "%1"=="restart" goto :restart_containers
if "%1"=="logs" goto :show_logs
if "%1"=="status" goto :show_status
if "%1"=="clean" goto :clean_all
if "%1"=="init" goto :initialize

echo Gecersiz secenek: %1
goto :show_help

:show_help
echo Kullanim: %0 [SECENEK]
echo.
echo Secenekler:
echo   build     - Docker image'larini build et
echo   up        - Container'lari baslat
echo   down      - Container'lari durdur
echo   restart   - Container'lari yeniden baslat
echo   logs      - Container loglarini goster
echo   status    - Container durumlarini goster
echo   clean     - Tum container, image ve volume'lari temizle
echo   init      - Ilk kurulum (build + up + database init)
echo   help      - Bu yardim mesajini goster
goto :end

:build_images
echo Docker image'lari build ediliyor...
docker-compose build --no-cache
if %errorlevel% equ 0 (
    echo Build tamamlandi!
) else (
    echo Build sirasinda hata olustu!
)
goto :end

:start_containers
echo Container'lar baslatiliyor...
docker-compose up -d
if %errorlevel% equ 0 (
    echo Container'lar baslatildi!
    echo.
    echo Servis URL'leri:
    echo   API: http://localhost:5000
    echo   Web: http://localhost:5001
    echo   SQL Server: localhost:1433
) else (
    echo Container'lar baslatilirken hata olustu!
)
goto :end

:stop_containers
echo Container'lar durduruluyor...
docker-compose down
if %errorlevel% equ 0 (
    echo Container'lar durduruldu!
) else (
    echo Container'lar durdurulurken hata olustu!
)
goto :end

:restart_containers
echo Container'lar yeniden baslatiliyor...
docker-compose restart
if %errorlevel% equ 0 (
    echo Container'lar yeniden baslatildi!
) else (
    echo Container'lar yeniden baslatilirken hata olustu!
)
goto :end

:show_logs
echo Container loglari:
docker-compose logs -f
goto :end

:show_status
echo Container durumlari:
docker-compose ps
echo.
echo Disk kullanimi:
docker system df
goto :end

:clean_all
echo TUM container, image ve volume'lar silinecek. Emin misiniz? (y/N)
set /p response=
if /i "!response!"=="y" (
    echo Temizleniyor...
    docker-compose down -v --rmi all
    docker system prune -a -f
    echo Temizlik tamamlandi!
) else (
    echo Iptal edildi.
)
goto :end

:initialize
echo Ilk kurulum baslatiliyor...
echo.

echo 1. Docker image'lari build ediliyor...
docker-compose build --no-cache
if not %errorlevel% equ 0 (
    echo Build sirasinda hata olustu!
    goto :end
)

echo 2. Container'lar baslatiliyor...
docker-compose up -d
if not %errorlevel% equ 0 (
    echo Container'lar baslatilirken hata olustu!
    goto :end
)

echo 3. SQL Server'in hazir olmasi bekleniyor...
timeout /t 30 /nobreak >nul

echo 4. Veritabani olusturuluyor...
docker exec -i minierp-sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P MiniERP123! -C -i /docker-entrypoint-initdb.d/MiniERP_Clean.sql

echo.
echo Ilk kurulum tamamlandi!
echo.
echo Servis URL'leri:
echo   API: http://localhost:5000
echo   Web: http://localhost:5001
echo   SQL Server: localhost:1433 (sa/MiniERP123!)
goto :end

:end
pause
