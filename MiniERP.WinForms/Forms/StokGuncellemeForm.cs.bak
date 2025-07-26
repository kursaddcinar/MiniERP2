using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class StokGuncellemeForm : Form
    {
        private readonly ApiService _apiService;
        private readonly UserDto _currentUser;
        private List<ProductDto> _products = new();
        private List<WarehouseDto> _warehouses = new();
        private StockCardDto? _currentStock;
        private bool _isLoading = false; // Loading flag eklendi

        public StokGuncellemeForm(ApiService apiService, UserDto currentUser)
        {
            InitializeComponent();
            _apiService = apiService;
            _currentUser = currentUser;
            
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Stok Güncelleme";
            this.WindowState = FormWindowState.Maximized;
            
            // Default values
            cmbIslemTuru.Items.AddRange(new string[] { "Giriş", "Çıkış" });
            cmbIslemTuru.SelectedIndex = 0;
            
            txtMiktar.Text = "0";
            txtBirimFiyat.Text = "0";
            
            // Stok bilgi panelini başlangıçta gizle
            groupBox2.Visible = false;
            
            // Belge numarası hakkında bilgilendirme tooltipini ekle
            var tooltip = new ToolTip();
            tooltip.SetToolTip(groupBox3, "Belge Numarası: Boş bırakırsanız sistem otomatik olarak oluşturacaktır. " +
                "Manuel belge numarası girmek isterseniz benzersiz olmasına dikkat ediniz.");
            
            // Bilgilendirme mesajını sadece başlığa ekle
            this.Text = "Stok Güncelleme - Mevcut Stok Görüntüleme ve Hareket Takibi";
            
            System.Diagnostics.Debug.WriteLine("SetupForm tamamlandı, groupBox2 gizlendi");
        }

        private async void StokGuncellemeForm_Load(object sender, EventArgs e)
        {
            await LoadProductsAsync();
            await LoadWarehousesAsync();
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                _isLoading = true;
                System.Diagnostics.Debug.WriteLine("Ürünler yükleniyor...");
                var response = await _apiService.GetAsync<PagedResult<ProductDto>>("Products?pageNumber=1&pageSize=1000");
                if (response?.Success == true && response.Data != null)
                {
                    _products = response.Data.Data.Where(p => p.IsActive).ToList();
                    
                    cmbUrun.DataSource = _products;
                    cmbUrun.DisplayMember = "ProductName";
                    cmbUrun.ValueMember = "ProductID";
                    cmbUrun.SelectedIndex = -1;
                    
                    System.Diagnostics.Debug.WriteLine($"{_products.Count} ürün yüklendi");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ürün yükleme hatası: {ex.Message}");
                MessageBox.Show($"Ürünler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private async Task LoadWarehousesAsync()
        {
            try
            {
                _isLoading = true;
                System.Diagnostics.Debug.WriteLine("Depolar yükleniyor...");
                var response = await _apiService.GetAsync<List<WarehouseDto>>("Stock/warehouses/active");
                if (response?.Success == true && response.Data != null)
                {
                    _warehouses = response.Data;
                    
                    cmbDepo.DataSource = _warehouses;
                    cmbDepo.DisplayMember = "WarehouseName";
                    cmbDepo.ValueMember = "WarehouseID";
                    cmbDepo.SelectedIndex = -1;
                    
                    System.Diagnostics.Debug.WriteLine($"{_warehouses.Count} depo yüklendi");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Depo yükleme hatası: {ex.Message}");
                MessageBox.Show($"Depolar yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private async void cmbUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return; // Loading sırasında çalışma
            
            try
            {
                // Debug: Seçim durumunu kontrol et
                System.Diagnostics.Debug.WriteLine($"Ürün seçimi değişti. SelectedValue: {cmbUrun.SelectedValue}");
                
                if (cmbUrun.SelectedValue != null && cmbUrun.SelectedValue is int productId && productId > 0)
                {
                    var selectedProduct = _products.FirstOrDefault(p => p.ProductID == productId);
                    if (selectedProduct != null)
                    {
                        // Otomatik bilgileri doldur
                        txtBirimFiyat.Text = selectedProduct.CostPrice.ToString("F2");
                        
                        System.Diagnostics.Debug.WriteLine($"Ürün seçildi: {selectedProduct.ProductName}, Depo seçimi: {cmbDepo.SelectedValue}");
                        
                        // Depo seçiliyse stok bilgisini yükle
                        if (cmbDepo.SelectedValue != null && cmbDepo.SelectedValue is int warehouseId && warehouseId > 0)
                        {
                            System.Diagnostics.Debug.WriteLine("Stok bilgisi yüklenecek...");
                            await LoadCurrentStockAsync();
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Depo henüz seçilmemiş veya geçersiz");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün seçimi sırasında hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbDepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return; // Loading sırasında çalışma
            
            try
            {
                // Debug: Seçim durumunu kontrol et
                System.Diagnostics.Debug.WriteLine($"Depo seçimi değişti. SelectedValue: {cmbDepo.SelectedValue}");
                
                if (cmbDepo.SelectedValue != null && cmbDepo.SelectedValue is int warehouseId && warehouseId > 0 &&
                    cmbUrun.SelectedValue != null && cmbUrun.SelectedValue is int productId && productId > 0)
                {
                    System.Diagnostics.Debug.WriteLine($"Hem ürün ({productId}) hem depo ({warehouseId}) seçili, stok bilgisi yüklenecek...");
                    await LoadCurrentStockAsync();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Depo: {cmbDepo.SelectedValue}, Ürün: {cmbUrun.SelectedValue} - Stok bilgisi yüklenmeyecek");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Depo seçimi sırasında hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCurrentStockAsync()
        {
            try
            {
                if (cmbUrun.SelectedValue is int productId && cmbDepo.SelectedValue is int warehouseId)
                {
                    // Web projesi ile aynı endpoint'i kullan (api/ prefix'i ApiService tarafından ekleniyor)
                    var apiUrl = $"Stock/cards/by-product-warehouse?productId={productId}&warehouseId={warehouseId}";
                    System.Diagnostics.Debug.WriteLine($"API çağrısı yapılıyor: {apiUrl}");
                    Console.WriteLine($"[DEBUG] API çağrısı: {apiUrl}");
                    Console.WriteLine($"[DEBUG] Full URL will be: http://localhost:5135/api/{apiUrl}");
                    
                    var response = await _apiService.GetAsync<StockCardDto>(apiUrl);
                    
                    System.Diagnostics.Debug.WriteLine($"API yanıtı: Success={response?.Success}, Data={response?.Data != null}, Message={response?.Message}");
                    Console.WriteLine($"[DEBUG] API yanıtı: Success={response?.Success}, Data={response?.Data != null}, Message={response?.Message}");
                    
                    if (response?.Success == true && response.Data != null)
                    {
                        _currentStock = response.Data;
                        
                        // Mevcut stok bilgilerini detaylı göster
                        var lastTransactionText = _currentStock.LastTransactionDate.HasValue 
                            ? _currentStock.LastTransactionDate.Value.ToString("dd.MM.yyyy HH:mm")
                            : "Hiç işlem yok";
                            
                        lblMevcutStokBilgi.Text = $"Mevcut Stok: {_currentStock.CurrentStock:N2} {_currentStock.UnitName ?? "Adet"}\n" +
                                                $"Kullanılabilir: {_currentStock.AvailableStock:N2} (Rezerve: {_currentStock.ReservedStock:N2})\n" +
                                                $"Son İşlem: {lastTransactionText}\n" +
                                                $"Durum: {GetStockStatusText(_currentStock.StockStatus)}";
                        
                        System.Diagnostics.Debug.WriteLine($"Stok bilgisi güncellendi: {lblMevcutStokBilgi.Text}");
                        Console.WriteLine($"[DEBUG] Stok bilgisi güncellendi, groupBox2 görünür yapılıyor");
                        
                        // Kart2'yi görünür yap
                        groupBox2.Visible = true;
                    }
                    else
                    {
                        // Stok bulunamadı
                        _currentStock = null;
                        lblMevcutStokBilgi.Text = "Bu ürün için bu depoda stok kaydı bulunamadı.\n" +
                                                "İlk giriş yapılacak. Sistem yeni stok kartı oluşturacaktır.";
                        groupBox2.Visible = true;
                        
                        System.Diagnostics.Debug.WriteLine($"Stok bulunamadı: {response?.Message}");
                        Console.WriteLine($"[DEBUG] Stok bulunamadı, yeni stok kartı mesajı gösteriliyor");
                    }
                }
                else
                {
                    var debugMsg = $"Geçersiz seçim - ProductID: {cmbUrun.SelectedValue}, WarehouseID: {cmbDepo.SelectedValue}";
                    System.Diagnostics.Debug.WriteLine(debugMsg);
                    Console.WriteLine($"[DEBUG] {debugMsg}");
                }
            }
            catch (Exception ex)
            {
                var errorMsg = $"LoadCurrentStockAsync Hata: {ex.Message}";
                System.Diagnostics.Debug.WriteLine(errorMsg);
                Console.WriteLine($"[ERROR] {errorMsg}");
                
                MessageBox.Show($"Stok bilgisi yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                _currentStock = null;
                lblMevcutStokBilgi.Text = "Stok bilgisi yüklenemedi.\nLütfen ürün ve depo seçimini kontrol ediniz.";
                groupBox2.Visible = true;
            }
        }

        private string GetStockStatusText(string status)
        {
            return status switch
            {
                "NORMAL" => "Normal",
                "CRITICAL" => "Kritik Seviye",
                "OVER" => "Fazla Stok",
                "OUT" => "Stok Yok",
                _ => "Bilinmiyor"
            };
        }

        private async void btnStokGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasyon
                if (cmbUrun.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbDepo.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen depo seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtMiktar.Text, out decimal miktar) || miktar <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir miktar giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtBirimFiyat.Text, out decimal birimFiyat) || birimFiyat < 0)
                {
                    MessageBox.Show("Lütfen geçerli bir birim fiyat giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Çıkış işlemi kontrolü
                if (cmbIslemTuru.SelectedItem?.ToString() == "Çıkış")
                {
                    if (_currentStock == null || _currentStock.CurrentStock < miktar)
                    {
                        var mevcutMiktar = _currentStock?.CurrentStock ?? 0;
                        MessageBox.Show($"Yetersiz stok! Mevcut miktar: {mevcutMiktar:N2}", "Uyarı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Onay isteği
                var movementTypeText = cmbIslemTuru.SelectedItem?.ToString() == "Giriş" ? "giriş" : "çıkış";
                var result = MessageBox.Show($"Stok {movementTypeText} işlemi gerçekleştirilecek.\n\n" +
                    $"Ürün: {cmbUrun.Text}\n" +
                    $"Depo: {cmbDepo.Text}\n" +
                    $"Miktar: {miktar:N2}\n" +
                    $"Birim Fiyat: {birimFiyat:N2} TL\n\n" +
                    "Devam etmek istiyor musunuz?", 
                    "Stok Güncelleme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                // API'ye gönderilecek DetailedUpdateStockDto (API ile uyumlu alan adları)
                var updateDto = new DTOs.DetailedUpdateStockDto
                {
                    ProductID = (int)cmbUrun.SelectedValue,
                    WarehouseID = (int)cmbDepo.SelectedValue,
                    Quantity = miktar, // Pozitif miktar, yön TransactionType ile belirtiliyor
                    UnitPrice = birimFiyat,
                    TransactionType = cmbIslemTuru.SelectedItem?.ToString() == "Giriş" ? "GIRIS" : "CIKIS", // API'nin beklediği format
                    Notes = txtAciklama.Text, // API'nin beklediği alan adı
                    DocumentNo = null // txtBelgeNo eklendikten sonra: string.IsNullOrWhiteSpace(txtBelgeNo.Text) ? null : txtBelgeNo.Text,
                };

                Console.WriteLine($"[DEBUG] Gönderilecek DTO: ProductID={updateDto.ProductID}, WarehouseID={updateDto.WarehouseID}, Quantity={updateDto.Quantity}, TransactionType={updateDto.TransactionType}");

                // Yeni API endpoint'ini kullan (transaction logging ile)
                var response = await _apiService.PostAsync<bool>("Stock/update-stock-detailed", updateDto);
                
                Console.WriteLine($"[DEBUG] Update Response: Success={response?.Success}, Message={response?.Message}");
                
                if (response?.Success == true)
                {
                    MessageBox.Show("Stok başarıyla güncellendi ve işlem kaydedildi.", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Formu temizle ve stok bilgisini yenile
                    await LoadCurrentStockAsync();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show($"Stok güncellenirken hata oluştu: {response?.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok güncellenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtMiktar.Text = "0";
            txtAciklama.Clear();
            // txtBelgeNo.Clear(); // Designer'a eklendikten sonra bu satırı açacağız
            cmbIslemTuru.SelectedIndex = 0;
            
            // Stok bilgi panelini gizle
            groupBox2.Visible = false;
            
            // Birim fiyatı ürün seçiminden sonra otomatik doldurulacak
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


