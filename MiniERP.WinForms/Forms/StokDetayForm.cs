using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class StokDetayForm : Form
    {
        private readonly int _stockCardId;
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private StockCardDto? _stockCard;
        
        // Parent form'u yenileme için event
        public event EventHandler? StockDataChanged;

        public StokDetayForm(int stockCardId, string productCode)
        {
            InitializeComponent();
            _stockCardId = stockCardId;
            _currentUser = new UserDto { Username = "System" }; // Default user
            _apiService = new ApiService(); // Default API service
            
            // Token'ı set et (mevcut oturumdan)
            if (TokenManager.HasToken())
            {
                _apiService.SetAuthToken(TokenManager.GetToken()!);
            }
            
            SetupForm();
            LoadStockCardData();
        }

        // Önerilen constructor - ApiService ve CurrentUser parametreli
        public StokDetayForm(int stockCardId, string productCode, UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _stockCardId = stockCardId;
            _currentUser = currentUser;
            _apiService = apiService;
            
            SetupForm();
            LoadStockCardData();
        }

        private void SetupForm()
        {
            this.Text = "Stok Kartı Detayı";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimumSize = new Size(800, 600);

            // DataGridView ayarları
            dgvStockTransactions.AutoGenerateColumns = true; // Otomatik kolon oluştur
            dgvStockTransactions.AllowUserToAddRows = false;
            dgvStockTransactions.AllowUserToDeleteRows = false;
            dgvStockTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStockTransactions.MultiSelect = false;
            dgvStockTransactions.ReadOnly = true;
        }

        private async void LoadStockCardData()
        {
            try
            {
                lblDurum.Text = "Stok kartı bilgileri yükleniyor...";
                lblDurum.ForeColor = Color.Blue;

                var response = await _apiService.GetAsync<StockCardDto>($"Stock/cards/{_stockCardId}");
                if (response != null && response.Success && response.Data != null)
                {
                    _stockCard = response.Data;
                    PopulateStockDetails();
                    LoadStockTransactionHistory();
                    lblDurum.Text = "Veriler yüklendi";
                    lblDurum.ForeColor = Color.Green;
                }
                else
                {
                    throw new Exception($"API Hatası: {response?.Message ?? "Stok kartı bulunamadı"}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok kartı bilgileri yüklenirken hata oluştu:\n{ex.Message}\n\nLütfen API bağlantısını kontrol edin.", 
                    "API Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                lblDurum.Text = "API bağlantı hatası";
                lblDurum.ForeColor = Color.Red;
                
                // Form'u kapat
                this.Close();
            }
        }

        private void PopulateStockDetails()
        {
            if (_stockCard == null) return;

            // Başlık
            lblStockTitle.Text = $"{_stockCard.ProductCode} - {_stockCard.ProductName}";

            // Ürün Bilgileri
            lblProductCodeValue.Text = _stockCard.ProductCode;
            lblProductNameValue.Text = _stockCard.ProductName;
            lblCategoryValue.Text = "-"; // Kategori bilgisi DTO'da yok
            lblUnitValue.Text = _stockCard.UnitName ?? "Adet";

            // Depo Bilgileri  
            lblWarehouseCodeValue.Text = _stockCard.WarehouseCode ?? "-";
            lblWarehouseNameValue.Text = _stockCard.WarehouseName;
            lblLocationValue.Text = "-"; // Lokasyon bilgisi DTO'da yok
            lblLastUpdateValue.Text = _stockCard.LastTransactionDate?.ToString("dd.MM.yyyy HH:mm") ?? "Henüz işlem yapılmamış";

            // Stok Durumu
            lblCurrentStockValue.Text = $"{_stockCard.CurrentStock:N2} {_stockCard.UnitName}";
            lblReservedStockValue.Text = $"{_stockCard.ReservedStock:N2} {_stockCard.UnitName}";
            lblAvailableStockValue.Text = $"{_stockCard.AvailableStock:N2} {_stockCard.UnitName}";
            lblMinStockValue.Text = $"{_stockCard.MinStockLevel:N2} {_stockCard.UnitName}";

            // Durum renklerini ayarla
            SetStockStatusColors();

            // Son İşlem
            if (_stockCard.LastTransactionDate.HasValue)
            {
                lblLastTransactionValue.Text = _stockCard.LastTransactionDate.Value.ToString("dd.MM.yyyy HH:mm");
            }
            else
            {
                lblLastTransactionValue.Text = "Hiç işlem yok";
            }

            // Stok Durumu Badge
            string status = GetStockStatusText(_stockCard.StockStatus);
            lblStockStatus.Text = status;
            SetStatusColor(status);
        }

        private void SetStockStatusColors()
        {
            if (_stockCard == null) return;

            // Mevcut stok rengi
            if (_stockCard.CurrentStock <= 0)
                lblCurrentStockValue.ForeColor = Color.FromArgb(220, 38, 127); // Kırmızı
            else if (_stockCard.CurrentStock <= _stockCard.MinStockLevel)
                lblCurrentStockValue.ForeColor = Color.FromArgb(249, 115, 22); // Turuncu
            else
                lblCurrentStockValue.ForeColor = Color.FromArgb(34, 197, 94); // Yeşil

            // Rezerve stok rengi
            lblReservedStockValue.ForeColor = _stockCard.ReservedStock > 0 ? 
                Color.FromArgb(59, 130, 246) : Color.FromArgb(107, 114, 128);

            // Müsait stok rengi
            lblAvailableStockValue.ForeColor = _stockCard.AvailableStock > 0 ? 
                Color.FromArgb(34, 197, 94) : Color.FromArgb(220, 38, 127);

            // Minimum stok rengi
            lblMinStockValue.ForeColor = Color.FromArgb(239, 68, 68);
        }

        private void SetStatusColor(string status)
        {
            lblStockStatus.ForeColor = status switch
            {
                "Normal" => Color.FromArgb(34, 197, 94),
                "Kritik" => Color.FromArgb(249, 115, 22),
                "Yok" => Color.FromArgb(220, 38, 127),
                "Fazla" => Color.FromArgb(59, 130, 246),
                _ => Color.FromArgb(107, 114, 128)
            };
        }

        private string GetStockStatusText(string status)
        {
            return status switch
            {
                "CRITICAL" => "Kritik",
                "OUT" => "Yok", 
                "NORMAL" => "Normal",
                "OVER" => "Fazla",
                _ => "Normal"
            };
        }

        private async void LoadStockTransactionHistory()
        {
            try
            {
                // Son 10 stok hareketini yükle - Yeni endpoint kullan
                var response = await _apiService.GetAsync<List<StockTransactionDto>>($"Stock/transactions/by-stockcard/{_stockCardId}");
                
                if (response != null && response.Success && response.Data != null)
                {
                    var transactions = response.Data.Select(t => new
                    {
                        TransactionDate = t.TransactionDate.ToString("dd.MM.yyyy HH:mm"),
                        TransactionType = GetTransactionTypeText(t.TransactionType),
                        DocumentNumber = t.DocumentNo ?? "-",
                        Quantity = $"{t.Quantity:N2}",
                        UnitPrice = $"₺{t.UnitPrice:N2}",
                        RemainingStock = "-" // RemainingStock DTO'da yok
                    }).ToList();

                    // UI thread'inde güncelle
                    if (dgvStockTransactions.InvokeRequired)
                    {
                        dgvStockTransactions.Invoke(new Action(() => {
                            dgvStockTransactions.DataSource = transactions;
                            SetupDataGridViewColumns();
                        }));
                    }
                    else
                    {
                        dgvStockTransactions.DataSource = transactions;
                        SetupDataGridViewColumns();
                    }
                    
                    // DataGridView kolonlarını ayarla
                    SetupDataGridViewColumns();
                    
                    System.Diagnostics.Debug.WriteLine("Stok hareketleri başarıyla yüklendi");
                }
                else
                {
                    // API hatası durumunda boş liste göster
                    dgvStockTransactions.DataSource = new List<object>();
                    MessageBox.Show("Stok hareketleri yüklenemedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Stok hareketleri yüklenirken hata: {ex.Message}");
                dgvStockTransactions.DataSource = new List<object>();
            }
        }

        private void SetupDataGridViewColumns()
        {
            // DataGridView kolonlarını ayarla
            if (dgvStockTransactions.Columns.Count > 0)
            {
                if (dgvStockTransactions.Columns.Contains("TransactionDate"))
                    dgvStockTransactions.Columns["TransactionDate"].HeaderText = "Tarih";
                
                if (dgvStockTransactions.Columns.Contains("TransactionType"))
                    dgvStockTransactions.Columns["TransactionType"].HeaderText = "Hareket Türü";
                
                if (dgvStockTransactions.Columns.Contains("DocumentNumber"))
                    dgvStockTransactions.Columns["DocumentNumber"].HeaderText = "Belge No";
                
                if (dgvStockTransactions.Columns.Contains("Quantity"))
                    dgvStockTransactions.Columns["Quantity"].HeaderText = "Miktar";
                
                if (dgvStockTransactions.Columns.Contains("UnitPrice"))
                    dgvStockTransactions.Columns["UnitPrice"].HeaderText = "Birim Fiyat";
                
                if (dgvStockTransactions.Columns.Contains("RemainingStock"))
                    dgvStockTransactions.Columns["RemainingStock"].HeaderText = "Kalan Stok";
                
                // Kolonları otomatik boyutlandır
                dgvStockTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private string GetTransactionTypeText(string transactionType)
        {
            return transactionType switch
            {
                "IN" => "Giriş",
                "OUT" => "Çıkış",
                "GIRIS" => "Giriş", // Backend'den gelen format
                "CIKIS" => "Çıkış", // Backend'den gelen format
                "TRANSFER_IN" => "Transfer Giriş",
                "TRANSFER_OUT" => "Transfer Çıkış",
                "ADJUSTMENT" => "Düzeltme",
                _ => transactionType
            };
        }

        private void BtnKapat_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnDuzenle_Click(object? sender, EventArgs e)
        {
            if (_stockCard != null)
            {
                var form = new StokKartiDuzenleForm(_stockCard.StockCardID, _currentUser, _apiService);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Stok kartını yeniden yükle
                    LoadStockCardData();
                }
            }
        }

        private void BtnStokGirisi_Click(object? sender, EventArgs e)
        {
            if (_stockCard != null)
            {
                var form = new StokGuncellemeForm(_apiService, _currentUser, _stockCard, "IN");
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Stok bilgilerini yenile
                    LoadStockCardData();
                    // Parent form'u bilgilendir
                    StockDataChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void BtnStokCikisi_Click(object? sender, EventArgs e)
        {
            if (_stockCard != null)
            {
                var form = new StokGuncellemeForm(_apiService, _currentUser, _stockCard, "OUT");
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Stok bilgilerini yenile
                    LoadStockCardData();
                    // Parent form'u bilgilendir
                    StockDataChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void BtnYazdir_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Yazdırma özelliği yakında eklenecek.", "Bilgi", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
