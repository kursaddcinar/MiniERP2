using AutoMapper;
using Microsoft.Extensions.Logging;
using MiniERP.API.DTOs;
using MiniERP.API.Models;
using MiniERP.API.Repositories;

namespace MiniERP.API.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<StockService> _logger;

        public StockService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<StockService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        #region StockCard İşlemleri

        public async Task<ApiResponse<PagedResult<StockCardDto>>> GetStockCardsAsync(PaginationParameters parameters)
        {
            try
            {
                var (stockCards, totalCount) = await _unitOfWork.StockCards.GetPagedWithCountAsync(parameters.PageNumber, parameters.PageSize, parameters.SearchTerm);
                var stockCardDtos = _mapper.Map<List<StockCardDto>>(stockCards);
                var pagedResult = new PagedResult<StockCardDto>(stockCardDtos, totalCount, parameters.PageNumber, parameters.PageSize);
                return ApiResponse<PagedResult<StockCardDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stok kartları getirilirken hata oluştu");
                return ApiResponse<PagedResult<StockCardDto>>.ErrorResult("Stok kartları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<StockCardDto>> GetStockCardByIdAsync(int id)
        {
            try
            {
                var stockCard = await _unitOfWork.StockCards.GetByIdWithIncludesAsync(id);
                if (stockCard == null)
                    return ApiResponse<StockCardDto>.ErrorResult("Stok kartı bulunamadı");

                var stockCardDto = _mapper.Map<StockCardDto>(stockCard);
                return ApiResponse<StockCardDto>.SuccessResult(stockCardDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stok kartı {StockCardId} getirilirken hata oluştu", id);
                return ApiResponse<StockCardDto>.ErrorResult("Stok kartı getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<StockCardDto>> GetStockCardByProductAndWarehouseAsync(int productId, int warehouseId)
        {
            try
            {
                var stockCard = await _unitOfWork.StockCards.GetByProductAndWarehouseAsync(productId, warehouseId);
                if (stockCard == null)
                    return ApiResponse<StockCardDto>.ErrorResult("Stok kartı bulunamadı");

                var stockCardDto = _mapper.Map<StockCardDto>(stockCard);
                return ApiResponse<StockCardDto>.SuccessResult(stockCardDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün {ProductId} ve depo {WarehouseId} için stok kartı getirilirken hata oluştu", productId, warehouseId);
                return ApiResponse<StockCardDto>.ErrorResult("Stok kartı getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<StockCardDto>>> GetStockCardsByProductIdAsync(int productId)
        {
            try
            {
                var stockCards = await _unitOfWork.StockCards.GetByProductIdAsync(productId);
                var stockCardDtos = _mapper.Map<List<StockCardDto>>(stockCards);
                return ApiResponse<List<StockCardDto>>.SuccessResult(stockCardDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün {ProductId} için stok kartları getirilirken hata oluştu", productId);
                return ApiResponse<List<StockCardDto>>.ErrorResult("Stok kartları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<StockCardDto>>> GetStockCardsByWarehouseIdAsync(int warehouseId)
        {
            try
            {
                var stockCards = await _unitOfWork.StockCards.GetByWarehouseIdAsync(warehouseId);
                var stockCardDtos = _mapper.Map<List<StockCardDto>>(stockCards);
                return ApiResponse<List<StockCardDto>>.SuccessResult(stockCardDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Depo {WarehouseId} için stok kartları getirilirken hata oluştu", warehouseId);
                return ApiResponse<List<StockCardDto>>.ErrorResult("Stok kartları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<StockCardDto>> CreateStockCardAsync(CreateStockCardDto createStockCardDto)
        {
            try
            {
                var stockCard = _mapper.Map<StockCard>(createStockCardDto);
                stockCard.CreatedDate = DateTime.Now;

                await _unitOfWork.StockCards.AddAsync(stockCard);
                await _unitOfWork.SaveChangesAsync();

                var result = await GetStockCardByIdAsync(stockCard.StockCardID);
                _logger.LogInformation("Stok kartı {StockCardId} başarıyla oluşturuldu", stockCard.StockCardID);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stok kartı oluşturulurken hata oluştu");
                return ApiResponse<StockCardDto>.ErrorResult("Stok kartı oluşturulurken hata oluştu");
            }
        }

        public async Task<ApiResponse<StockCardDto>> UpdateStockCardAsync(int id, UpdateStockCardDto updateStockCardDto)
        {
            try
            {
                var stockCard = await _unitOfWork.StockCards.GetByIdAsync(id);
                if (stockCard == null)
                    return ApiResponse<StockCardDto>.ErrorResult("Stok kartı bulunamadı");

                _mapper.Map(updateStockCardDto, stockCard);
                await _unitOfWork.StockCards.UpdateAsync(stockCard);
                await _unitOfWork.SaveChangesAsync();

                var result = await GetStockCardByIdAsync(id);
                _logger.LogInformation("Stok kartı {StockCardId} başarıyla güncellendi", id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stok kartı {StockCardId} güncellenirken hata oluştu", id);
                return ApiResponse<StockCardDto>.ErrorResult("Stok kartı güncellenirken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> DeleteStockCardAsync(int id)
        {
            try
            {
                var stockCard = await _unitOfWork.StockCards.GetByIdAsync(id);
                if (stockCard == null)
                    return ApiResponse<bool>.ErrorResult("Stok kartı bulunamadı");

                await _unitOfWork.StockCards.DeleteAsync(stockCard);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Stok kartı {StockCardId} başarıyla silindi", id);
                return ApiResponse<bool>.SuccessResult(true, "Stok kartı başarıyla silindi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stok kartı {StockCardId} silinirken hata oluştu", id);
                return ApiResponse<bool>.ErrorResult("Stok kartı silinirken hata oluştu");
            }
        }

        #endregion

        #region Stok Durumu İşlemleri

        public async Task<ApiResponse<List<StockCardDto>>> GetCriticalStockCardsAsync()
        {
            try
            {
                var stockCards = await _unitOfWork.StockCards.GetCriticalStockCardsAsync();
                var stockCardDtos = _mapper.Map<List<StockCardDto>>(stockCards);
                return ApiResponse<List<StockCardDto>>.SuccessResult(stockCardDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kritik stok kartları getirilirken hata oluştu");
                return ApiResponse<List<StockCardDto>>.ErrorResult("Kritik stok kartları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<StockCardDto>>> GetOverStockCardsAsync()
        {
            try
            {
                var stockCards = await _unitOfWork.StockCards.GetOverStockCardsAsync();
                var stockCardDtos = _mapper.Map<List<StockCardDto>>(stockCards);
                return ApiResponse<List<StockCardDto>>.SuccessResult(stockCardDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fazla stok kartları getirilirken hata oluştu");
                return ApiResponse<List<StockCardDto>>.ErrorResult("Fazla stok kartları getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<StockCardDto>>> GetOutOfStockCardsAsync()
        {
            try
            {
                var stockCards = await _unitOfWork.StockCards.GetOutOfStockCardsAsync();
                var stockCardDtos = _mapper.Map<List<StockCardDto>>(stockCards);
                return ApiResponse<List<StockCardDto>>.SuccessResult(stockCardDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stokta tükenen kartlar getirilirken hata oluştu");
                return ApiResponse<List<StockCardDto>>.ErrorResult("Stokta tükenen kartlar getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> UpdateStockAsync(int productId, int warehouseId, decimal quantity, string transactionType)
        {
            try
            {
                var result = await _unitOfWork.StockCards.UpdateStockAsync(productId, warehouseId, quantity, transactionType);
                if (!result)
                    return ApiResponse<bool>.ErrorResult("Stok güncellenirken hata oluştu");

                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Stok başarıyla güncellendi: Ürün {ProductId}, Depo {WarehouseId}, Miktar {Quantity}, Tür {TransactionType}", 
                    productId, warehouseId, quantity, transactionType);
                return ApiResponse<bool>.SuccessResult(true, "Stok başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stok güncellenirken hata oluştu");
                return ApiResponse<bool>.ErrorResult("Stok güncellenirken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> UpdateStockWithTransactionAsync(DetailedUpdateStockDto updateStockDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // Otomatik belge numarası oluştur (eğer girilmediyse)
                string documentNo = updateStockDto.DocumentNo ?? string.Empty;
                if (string.IsNullOrEmpty(documentNo))
                {
                    documentNo = $"STK-{DateTime.Now:yyyyMMddHHmmss}";
                }

                // Stok işlemi kaydı oluştur
                var transaction = new StockTransaction
                {
                    ProductID = updateStockDto.ProductID,
                    WarehouseID = updateStockDto.WarehouseID,
                    TransactionType = updateStockDto.TransactionType,
                    Quantity = updateStockDto.Quantity,
                    UnitPrice = updateStockDto.UnitPrice,
                    TotalAmount = updateStockDto.Quantity * updateStockDto.UnitPrice,
                    TransactionDate = DateTime.Now,
                    DocumentType = "MANUEL",
                    DocumentNo = documentNo,
                    Description = updateStockDto.Notes
                };

                await _unitOfWork.StockTransactions.AddAsync(transaction);

                // Stok kartını güncelle
                var stockUpdateResult = await _unitOfWork.StockCards.UpdateStockAsync(
                    updateStockDto.ProductID, 
                    updateStockDto.WarehouseID, 
                    updateStockDto.Quantity, 
                    updateStockDto.TransactionType);

                if (!stockUpdateResult)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return ApiResponse<bool>.ErrorResult("Stok güncellenirken hata oluştu");
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                _logger.LogInformation("Detaylı stok güncelleme başarıyla tamamlandı: Ürün {ProductId}, Depo {WarehouseId}, Miktar {Quantity}, Belge No {DocumentNo}", 
                    updateStockDto.ProductID, updateStockDto.WarehouseID, updateStockDto.Quantity, documentNo);
                
                return ApiResponse<bool>.SuccessResult(true, "Stok başarıyla güncellendi ve işlem kaydı oluşturuldu");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError(ex, "Detaylı stok güncellenirken hata oluştu");
                return ApiResponse<bool>.ErrorResult("Stok güncellenirken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> ReserveStockAsync(int productId, int warehouseId, decimal quantity)
        {
            try
            {
                var result = await _unitOfWork.StockCards.ReserveStockAsync(productId, warehouseId, quantity);
                if (!result)
                    return ApiResponse<bool>.ErrorResult("Stok rezerve edilirken hata oluştu");

                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResult(true, "Stok başarıyla rezerve edildi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stok rezerve edilirken hata oluştu");
                return ApiResponse<bool>.ErrorResult("Stok rezerve edilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> ReleaseReservedStockAsync(int productId, int warehouseId, decimal quantity)
        {
            try
            {
                var result = await _unitOfWork.StockCards.ReleaseReservedStockAsync(productId, warehouseId, quantity);
                if (!result)
                    return ApiResponse<bool>.ErrorResult("Rezerve stok serbest bırakılırken hata oluştu");

                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResult(true, "Rezerve stok başarıyla serbest bırakıldı");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Rezerve stok serbest bırakılırken hata oluştu");
                return ApiResponse<bool>.ErrorResult("Rezerve stok serbest bırakılırken hata oluştu");
            }
        }

        #endregion

        #region StockTransaction İşlemleri

        public async Task<ApiResponse<PagedResult<StockTransactionDto>>> GetStockTransactionsAsync(PaginationParameters parameters)
        {
            try
            {
                var (transactions, totalCount) = await _unitOfWork.StockTransactions.GetPagedWithCountAsync(parameters.PageNumber, parameters.PageSize);
                var transactionDtos = _mapper.Map<List<StockTransactionDto>>(transactions);
                var pagedResult = new PagedResult<StockTransactionDto>(transactionDtos, totalCount, parameters.PageNumber, parameters.PageSize);
                return ApiResponse<PagedResult<StockTransactionDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stok işlemleri getirilirken hata oluştu");
                return ApiResponse<PagedResult<StockTransactionDto>>.ErrorResult("Stok işlemleri getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<StockTransactionDto>> GetStockTransactionByIdAsync(int id)
        {
            try
            {
                var transaction = await _unitOfWork.StockTransactions.GetByIdAsync(id);
                if (transaction == null)
                    return ApiResponse<StockTransactionDto>.ErrorResult("Stok işlemi bulunamadı");

                var transactionDto = _mapper.Map<StockTransactionDto>(transaction);
                return ApiResponse<StockTransactionDto>.SuccessResult(transactionDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stok işlemi {TransactionId} getirilirken hata oluştu", id);
                return ApiResponse<StockTransactionDto>.ErrorResult("Stok işlemi getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<StockTransactionDto>> CreateStockTransactionAsync(CreateStockTransactionDto createTransactionDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var transaction = _mapper.Map<StockTransaction>(createTransactionDto);
                transaction.TransactionDate = DateTime.Now;
                transaction.TotalAmount = transaction.Quantity * transaction.UnitPrice;

                await _unitOfWork.StockTransactions.AddAsync(transaction);
                await _unitOfWork.StockCards.UpdateStockAsync(transaction.ProductID, transaction.WarehouseID, 
                    transaction.Quantity, transaction.TransactionType);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                var result = await GetStockTransactionByIdAsync(transaction.TransactionID);
                _logger.LogInformation("Stok işlemi {TransactionId} başarıyla oluşturuldu", transaction.TransactionID);
                return result;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError(ex, "Stok işlemi oluşturulurken hata oluştu");
                return ApiResponse<StockTransactionDto>.ErrorResult("Stok işlemi oluşturulurken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<StockTransactionDto>>> GetTransactionsByProductIdAsync(int productId)
        {
            try
            {
                var transactions = await _unitOfWork.StockTransactions.GetByProductIdAsync(productId);
                var transactionDtos = _mapper.Map<List<StockTransactionDto>>(transactions);
                return ApiResponse<List<StockTransactionDto>>.SuccessResult(transactionDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün {ProductId} için stok işlemleri getirilirken hata oluştu", productId);
                return ApiResponse<List<StockTransactionDto>>.ErrorResult("Stok işlemleri getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<StockTransactionDto>>> GetTransactionsByWarehouseIdAsync(int warehouseId)
        {
            try
            {
                var transactions = await _unitOfWork.StockTransactions.GetByWarehouseIdAsync(warehouseId);
                var transactionDtos = _mapper.Map<List<StockTransactionDto>>(transactions);
                return ApiResponse<List<StockTransactionDto>>.SuccessResult(transactionDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Depo {WarehouseId} için stok işlemleri getirilirken hata oluştu", warehouseId);
                return ApiResponse<List<StockTransactionDto>>.ErrorResult("Stok işlemleri getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<StockTransactionDto>>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var transactions = await _unitOfWork.StockTransactions.GetByDateRangeAsync(startDate, endDate);
                var transactionDtos = _mapper.Map<List<StockTransactionDto>>(transactions);
                return ApiResponse<List<StockTransactionDto>>.SuccessResult(transactionDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Tarih aralığı {StartDate} - {EndDate} için stok işlemleri getirilirken hata oluştu", startDate, endDate);
                return ApiResponse<List<StockTransactionDto>>.ErrorResult("Stok işlemleri getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<StockTransactionDto>>> GetIncomingTransactionsAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                var transactions = await _unitOfWork.StockTransactions.GetIncomingTransactionsAsync(fromDate, toDate);
                var transactionDtos = _mapper.Map<List<StockTransactionDto>>(transactions);
                return ApiResponse<List<StockTransactionDto>>.SuccessResult(transactionDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Giren stok işlemleri getirilirken hata oluştu");
                return ApiResponse<List<StockTransactionDto>>.ErrorResult("Giren stok işlemleri getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<StockTransactionDto>>> GetOutgoingTransactionsAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                var transactions = await _unitOfWork.StockTransactions.GetOutgoingTransactionsAsync(fromDate, toDate);
                var transactionDtos = _mapper.Map<List<StockTransactionDto>>(transactions);
                return ApiResponse<List<StockTransactionDto>>.SuccessResult(transactionDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Çıkan stok işlemleri getirilirken hata oluştu");
                return ApiResponse<List<StockTransactionDto>>.ErrorResult("Çıkan stok işlemleri getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> ProcessStockMovementAsync(CreateStockMovementDto movementDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // Çıkış işlemi
                var outgoingTransaction = new StockTransaction
                {
                    ProductID = movementDto.ProductID,
                    WarehouseID = movementDto.FromWarehouseID,
                    TransactionType = "CIKIS",
                    Quantity = movementDto.Quantity,
                    UnitPrice = 0,
                    TotalAmount = 0,
                    TransactionDate = movementDto.MovementDate,
                    DocumentType = "TRANSFER",
                    DocumentNo = $"TRF-{DateTime.Now:yyyyMMddHHmmss}",
                    Description = movementDto.Description
                };

                await _unitOfWork.StockTransactions.AddAsync(outgoingTransaction);
                await _unitOfWork.StockCards.UpdateStockAsync(movementDto.ProductID, movementDto.FromWarehouseID, 
                    movementDto.Quantity, "CIKIS");

                // Giriş işlemi
                var incomingTransaction = new StockTransaction
                {
                    ProductID = movementDto.ProductID,
                    WarehouseID = movementDto.ToWarehouseID,
                    TransactionType = "GIRIS",
                    Quantity = movementDto.Quantity,
                    UnitPrice = 0,
                    TotalAmount = 0,
                    TransactionDate = movementDto.MovementDate,
                    DocumentType = "TRANSFER",
                    DocumentNo = $"TRF-{DateTime.Now:yyyyMMddHHmmss}",
                    Description = movementDto.Description
                };

                await _unitOfWork.StockTransactions.AddAsync(incomingTransaction);
                await _unitOfWork.StockCards.UpdateStockAsync(movementDto.ProductID, movementDto.ToWarehouseID, 
                    movementDto.Quantity, "GIRIS");

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                _logger.LogInformation("Stok transferi başarıyla gerçekleştirildi: Ürün {ProductId}, {FromWarehouse} -> {ToWarehouse}", 
                    movementDto.ProductID, movementDto.FromWarehouseID, movementDto.ToWarehouseID);
                return ApiResponse<bool>.SuccessResult(true, "Stok transferi başarıyla gerçekleştirildi");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError(ex, "Stok transferi gerçekleştirilirken hata oluştu");
                return ApiResponse<bool>.ErrorResult("Stok transferi gerçekleştirilirken hata oluştu");
            }
        }

        #endregion

        #region Warehouse İşlemleri

        public async Task<ApiResponse<PagedResult<WarehouseDto>>> GetWarehousesAsync(PaginationParameters parameters)
        {
            try
            {
                var (warehouses, totalCount) = await _unitOfWork.Warehouses.GetPagedWithCountAsync(parameters.PageNumber, parameters.PageSize);
                var warehouseDtos = _mapper.Map<List<WarehouseDto>>(warehouses);
                var pagedResult = new PagedResult<WarehouseDto>(warehouseDtos, totalCount, parameters.PageNumber, parameters.PageSize);
                return ApiResponse<PagedResult<WarehouseDto>>.SuccessResult(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Depolar getirilirken hata oluştu");
                return ApiResponse<PagedResult<WarehouseDto>>.ErrorResult("Depolar getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<WarehouseDto>> GetWarehouseByIdAsync(int id)
        {
            try
            {
                var warehouse = await _unitOfWork.Warehouses.GetByIdAsync(id);
                if (warehouse == null)
                    return ApiResponse<WarehouseDto>.ErrorResult("Depo bulunamadı");

                var warehouseDto = _mapper.Map<WarehouseDto>(warehouse);
                return ApiResponse<WarehouseDto>.SuccessResult(warehouseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Depo {WarehouseId} getirilirken hata oluştu", id);
                return ApiResponse<WarehouseDto>.ErrorResult("Depo getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<WarehouseDto>> GetWarehouseByCodeAsync(string warehouseCode)
        {
            try
            {
                var warehouse = await _unitOfWork.Warehouses.GetByCodeAsync(warehouseCode);
                if (warehouse == null)
                    return ApiResponse<WarehouseDto>.ErrorResult("Depo bulunamadı");

                var warehouseDto = _mapper.Map<WarehouseDto>(warehouse);
                return ApiResponse<WarehouseDto>.SuccessResult(warehouseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Depo {WarehouseCode} getirilirken hata oluştu", warehouseCode);
                return ApiResponse<WarehouseDto>.ErrorResult("Depo getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<WarehouseDto>> CreateWarehouseAsync(CreateWarehouseDto createWarehouseDto)
        {
            try
            {
                if (!await _unitOfWork.Warehouses.IsWarehouseCodeUniqueAsync(createWarehouseDto.WarehouseCode))
                {
                    return ApiResponse<WarehouseDto>.ErrorResult("Bu depo kodu zaten kullanılıyor");
                }

                var warehouse = _mapper.Map<Warehouse>(createWarehouseDto);
                warehouse.CreatedDate = DateTime.Now;
                warehouse.IsActive = true;

                await _unitOfWork.Warehouses.AddAsync(warehouse);
                await _unitOfWork.SaveChangesAsync();

                var result = await GetWarehouseByIdAsync(warehouse.WarehouseID);
                _logger.LogInformation("Depo {WarehouseId} başarıyla oluşturuldu", warehouse.WarehouseID);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Depo oluşturulurken hata oluştu");
                return ApiResponse<WarehouseDto>.ErrorResult("Depo oluşturulurken hata oluştu");
            }
        }

        public async Task<ApiResponse<WarehouseDto>> UpdateWarehouseAsync(int id, UpdateWarehouseDto updateWarehouseDto)
        {
            try
            {
                var warehouse = await _unitOfWork.Warehouses.GetByIdAsync(id);
                if (warehouse == null)
                    return ApiResponse<WarehouseDto>.ErrorResult("Depo bulunamadı");

                // Note: Warehouse code is not updated as it's typically immutable

                _mapper.Map(updateWarehouseDto, warehouse);
                await _unitOfWork.Warehouses.UpdateAsync(warehouse);
                await _unitOfWork.SaveChangesAsync();

                var result = await GetWarehouseByIdAsync(id);
                _logger.LogInformation("Depo {WarehouseId} başarıyla güncellendi", id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Depo {WarehouseId} güncellenirken hata oluştu", id);
                return ApiResponse<WarehouseDto>.ErrorResult("Depo güncellenirken hata oluştu");
            }
        }

        public async Task<ApiResponse<bool>> DeleteWarehouseAsync(int id)
        {
            try
            {
                var warehouse = await _unitOfWork.Warehouses.GetByIdAsync(id);
                if (warehouse == null)
                    return ApiResponse<bool>.ErrorResult("Depo bulunamadı");

                await _unitOfWork.Warehouses.DeleteAsync(warehouse);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Depo {WarehouseId} başarıyla silindi", id);
                return ApiResponse<bool>.SuccessResult(true, "Depo başarıyla silindi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Depo {WarehouseId} silinirken hata oluştu", id);
                return ApiResponse<bool>.ErrorResult("Depo silinirken hata oluştu");
            }
        }

        public async Task<ApiResponse<List<WarehouseDto>>> GetActiveWarehousesAsync()
        {
            try
            {
                var warehouses = await _unitOfWork.Warehouses.GetActiveWarehousesAsync();
                var warehouseDtos = _mapper.Map<List<WarehouseDto>>(warehouses);
                return ApiResponse<List<WarehouseDto>>.SuccessResult(warehouseDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aktif depolar getirilirken hata oluştu");
                return ApiResponse<List<WarehouseDto>>.ErrorResult("Aktif depolar getirilirken hata oluştu");
            }
        }

        #endregion

        #region Raporlar ve İstatistikler

        public async Task<ApiResponse<StockSummaryDto>> GetStockSummaryAsync()
        {
            try
            {
                var totalStockValue = await _unitOfWork.StockCards.GetTotalStockValueAsync();
                var criticalStockCount = (await _unitOfWork.StockCards.GetCriticalStockCardsAsync()).Count();
                var outOfStockCount = (await _unitOfWork.StockCards.GetOutOfStockCardsAsync()).Count();
                var totalIncomingValue = await _unitOfWork.StockTransactions.GetTotalIncomingValueAsync();
                var totalOutgoingValue = await _unitOfWork.StockTransactions.GetTotalOutgoingValueAsync();

                var summary = new StockSummaryDto
                {
                    TotalStockValue = totalStockValue,
                    CriticalStockProducts = criticalStockCount,
                    OutOfStockProducts = outOfStockCount,
                    TotalIncomingValue = totalIncomingValue,
                    TotalOutgoingValue = totalOutgoingValue
                };

                return ApiResponse<StockSummaryDto>.SuccessResult(summary);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stok özeti getirilirken hata oluştu");
                return ApiResponse<StockSummaryDto>.ErrorResult("Stok özeti getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<StockReportDto>> GetStockReportAsync(int? warehouseId = null, int? categoryId = null)
        {
            try
            {
                var stockCards = await _unitOfWork.StockCards.GetStockCardsWithProductsAsync();
                
                // Filtreleme
                if (warehouseId.HasValue)
                    stockCards = stockCards.Where(sc => sc.WarehouseID == warehouseId.Value);
                
                if (categoryId.HasValue)
                    stockCards = stockCards.Where(sc => sc.Product.CategoryID == categoryId.Value);

                var stockCardDtos = _mapper.Map<List<StockCardDto>>(stockCards);
                var totalValue = stockCards.Sum(sc => sc.CurrentStock * sc.Product.PurchasePrice);

                var report = new StockReportDto
                {
                    StockCards = stockCardDtos,
                    TotalValue = totalValue,
                    TotalItems = stockCardDtos.Count
                };

                return ApiResponse<StockReportDto>.SuccessResult(report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stok raporu getirilirken hata oluştu");
                return ApiResponse<StockReportDto>.ErrorResult("Stok raporu getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<decimal>> GetTotalStockValueAsync()
        {
            try
            {
                var totalValue = await _unitOfWork.StockCards.GetTotalStockValueAsync();
                return ApiResponse<decimal>.SuccessResult(totalValue);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Toplam stok değeri getirilirken hata oluştu");
                return ApiResponse<decimal>.ErrorResult("Toplam stok değeri getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<decimal>> GetTotalStockValueByWarehouseAsync(int warehouseId)
        {
            try
            {
                var totalValue = await _unitOfWork.StockCards.GetTotalStockValueByWarehouseAsync(warehouseId);
                return ApiResponse<decimal>.SuccessResult(totalValue);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Depo {WarehouseId} toplam stok değeri getirilirken hata oluştu", warehouseId);
                return ApiResponse<decimal>.ErrorResult("Depo toplam stok değeri getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<decimal>> GetTotalIncomingValueAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                var totalValue = await _unitOfWork.StockTransactions.GetTotalIncomingValueAsync(fromDate, toDate);
                return ApiResponse<decimal>.SuccessResult(totalValue);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Toplam giriş değeri getirilirken hata oluştu");
                return ApiResponse<decimal>.ErrorResult("Toplam giriş değeri getirilirken hata oluştu");
            }
        }

        public async Task<ApiResponse<decimal>> GetTotalOutgoingValueAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                var totalValue = await _unitOfWork.StockTransactions.GetTotalOutgoingValueAsync(fromDate, toDate);
                return ApiResponse<decimal>.SuccessResult(totalValue);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Toplam çıkış değeri getirilirken hata oluştu");
                return ApiResponse<decimal>.ErrorResult("Toplam çıkış değeri getirilirken hata oluştu");
            }
        }

        #endregion
    }
} 