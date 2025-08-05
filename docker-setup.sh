#!/bin/bash

# MiniERP Docker Setup ve Yönetim Scripti

set -e

# Renkli output için
RED='\033[0;31m'
GREEN='\033[0;32m'
BLUE='\033[0;34m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

echo -e "${BLUE}=== MiniERP Docker Setup Script ===${NC}"

# Function to show help
show_help() {
    echo "Kullanım: $0 [SEÇENEK]"
    echo ""
    echo "Seçenekler:"
    echo "  build     - Docker image'larını build et"
    echo "  up        - Container'ları başlat"
    echo "  down      - Container'ları durdur"
    echo "  restart   - Container'ları yeniden başlat"
    echo "  logs      - Container loglarını göster"
    echo "  status    - Container durumlarını göster"
    echo "  clean     - Tüm container, image ve volume'ları temizle"
    echo "  init      - İlk kurulum (build + up + database init)"
    echo "  help      - Bu yardım mesajını göster"
}

# Function to build images
build_images() {
    echo -e "${YELLOW}Docker image'ları build ediliyor...${NC}"
    docker-compose build --no-cache
    echo -e "${GREEN}Build tamamlandı!${NC}"
}

# Function to start containers
start_containers() {
    echo -e "${YELLOW}Container'lar başlatılıyor...${NC}"
    docker-compose up -d
    echo -e "${GREEN}Container'lar başlatıldı!${NC}"
    echo -e "${BLUE}Servis URL'leri:${NC}"
    echo -e "  API: http://localhost:5000"
    echo -e "  Web: http://localhost:5001"
    echo -e "  SQL Server: localhost:1433"
}

# Function to stop containers
stop_containers() {
    echo -e "${YELLOW}Container'lar durduruluyor...${NC}"
    docker-compose down
    echo -e "${GREEN}Container'lar durduruldu!${NC}"
}

# Function to restart containers
restart_containers() {
    echo -e "${YELLOW}Container'lar yeniden başlatılıyor...${NC}"
    docker-compose restart
    echo -e "${GREEN}Container'lar yeniden başlatıldı!${NC}"
}

# Function to show logs
show_logs() {
    echo -e "${BLUE}Container logları:${NC}"
    docker-compose logs -f
}

# Function to show status
show_status() {
    echo -e "${BLUE}Container durumları:${NC}"
    docker-compose ps
    echo ""
    echo -e "${BLUE}Disk kullanımı:${NC}"
    docker system df
}

# Function to clean everything
clean_all() {
    echo -e "${RED}TÜM container, image ve volume'lar silinecek. Emin misiniz? (y/N)${NC}"
    read -r response
    if [[ "$response" =~ ^([yY][eE][sS]|[yY])$ ]]; then
        echo -e "${YELLOW}Temizleniyor...${NC}"
        docker-compose down -v --rmi all
        docker system prune -a -f
        echo -e "${GREEN}Temizlik tamamlandı!${NC}"
    else
        echo -e "${YELLOW}İptal edildi.${NC}"
    fi
}

# Function to initialize (first setup)
initialize() {
    echo -e "${BLUE}İlk kurulum başlatılıyor...${NC}"
    
    echo -e "${YELLOW}1. Docker image'ları build ediliyor...${NC}"
    build_images
    
    echo -e "${YELLOW}2. Container'lar başlatılıyor...${NC}"
    start_containers
    
    echo -e "${YELLOW}3. SQL Server'ın hazır olması bekleniyor...${NC}"
    sleep 30
    
    echo -e "${YELLOW}4. Veritabanı oluşturuluyor...${NC}"
    # SQL Script'i çalıştırmak için
    docker exec -i minierp-sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P MiniERP123! -C < Database/MiniERP_Clean.sql
    
    echo -e "${GREEN}İlk kurulum tamamlandı!${NC}"
    echo -e "${BLUE}Servis URL'leri:${NC}"
    echo -e "  API: http://localhost:5000"
    echo -e "  Web: http://localhost:5001"
    echo -e "  SQL Server: localhost:1433 (sa/MiniERP123!)"
}

# Main script logic
case "${1:-}" in
    build)
        build_images
        ;;
    up)
        start_containers
        ;;
    down)
        stop_containers
        ;;
    restart)
        restart_containers
        ;;
    logs)
        show_logs
        ;;
    status)
        show_status
        ;;
    clean)
        clean_all
        ;;
    init)
        initialize
        ;;
    help|--help|-h)
        show_help
        ;;
    *)
        echo -e "${RED}Geçersiz seçenek: $1${NC}"
        show_help
        exit 1
        ;;
esac
