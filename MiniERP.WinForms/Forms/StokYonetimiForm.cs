using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System.ComponentModel;

namespace MiniERP.WinForms.Forms
{
    public partial class StokYonetimiForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private readonly string _userRole;
        private readonly string _accessLevel;
        private BindingList<StockCardDisplayDto> _stockCards;
        private BindingList<StockCardDisplayDto> _filteredStockCards;
        private int _currentPage = 1;
        private int _pageSize = 10;
        private int _totalPages = 1;
        private int _totalRecords = 0;

        public StokYonetimiForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            _userRole = currentUser.Roles?.FirstOrDefault() ?? "Sales";
            _accessLevel = GetAccessLevel(_userRole);
            _stockCards = new BindingList<StockCardDisplayDto>();
            _filteredStockCards = new BindingList<StockCardDisplayDto>();

            SetupForm();
            SetupAccessControl();
            LoadStockSummary();
            LoadStockData();
        }

        private string GetAccessLevel(string role)
        {
            return role switch
            {
                "Admin" => "CRUD",
                "Manager" => "CRUD",
                "Sales" => "Read",
                "Purchase" => "Read",
                "Finance" => "Yok",
                "Warehouse" => "CRUD",
                _ => "Read"
            };
        }

        private void SetupForm()
        {
            this.Text = "Stok Yönetimi";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            // DataGridView ayarları
            dgvStockCards.AutoGenerateColumns = false;
            dgvStockCards.AllowUserToAddRows = false;
            dgvStockCards.AllowUserToDeleteRows = false;
            dgvStockCards.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStockCards.MultiSelect = false;
            dgvStockCards.DataSource = _filteredStockCards;

            // ComboBox ayarları
            cmbPageSize.Items.AddRange(new object[] { 10, 25, 50, 100 });
            cmbPageSize.SelectedItem = _pageSize;
            cmbPageSize.SelectedIndexChanged += CmbPageSize_SelectedIndexChanged;

            // Event handlers
            btnYeniStokKarti.Click += BtnYeniStokKarti_Click;
            btnStokGuncelle.Click += BtnStokGuncelle_Click;
            btnStokTransferi.Click += BtnStokTransferi_Click;
            btnAra.Click += BtnAra_Click;
            btnTemizle.Click += BtnTemizle_Click;
            btnOzet.Click += BtnOzet_Click;
            btnRapor.Click += BtnRapor_Click;
            btnKritikStokDetay.Click += BtnKritikStokDetay_Click;
            btnStokYokDetay.Click += BtnStokYokDetay_Click;
            btnHareketlerDetay.Click += BtnHareketlerDetay_Click;
            btnOncekiSayfa.Click += BtnOncekiSayfa_Click;
            btnSonrakiSayfa.Click += BtnSonrakiSayfa_Click;

            // Grid click events
            dgvStockCards.CellClick += DgvStockCards_CellClick;
        }

        private void SetupAccessControl()
        {
            bool canCreate = _accessLevel.Contains("C");
            bool canUpdate = _accessLevel.Contains("U");
            bool canDelete = _accessLevel.Contains("D");
            bool canRead = _accessLevel != "Yok";

            // Finans rolü hiçbir şey görmez
            if (_accessLevel == "Yok")
            {
                MessageBox.Show("Bu modüle erişim yetkiniz bulunmamaktadır.", "Erişim Engellendi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Buton yetkilerini ayarla
            btnYeniStokKarti.Enabled = canCreate;
            btnStokGuncelle.Enabled = canUpdate;
            btnStokTransferi.Enabled = canUpdate;

            // Grid için action column'ları
            if (!canUpdate)
            {
                // Düzenle buttonunu gizle
                if (dgvStockCards.Columns["colEdit"] != null)
                    dgvStockCards.Columns["colEdit"].Visible = false;
            }

            if (!canDelete)
            {
                // Sil buttonunu gizle
                if (dgvStockCards.Columns["colDelete"] != null)
                    dgvStockCards.Columns["colDelete"].Visible = false;
            }

            // Read-only kullanıcılar için bilgi mesajı
            if (_accessLevel == "Read")
            {
                lblAccessInfo.Text = $"👁️ Sadece görüntüleme yetkisine sahipsiniz ({_userRole})";
                lblAccessInfo.ForeColor = Color.FromArgb(59, 130, 246);
            }
            else
            {
                lblAccessInfo.Text = $"✅ Tam yetki ({_userRole})";
                lblAccessInfo.ForeColor = Color.FromArgb(34, 197, 94);
            }
        }

        private async void LoadStockSummary()
        {
            try
            {
                var response = await _apiService.GetAsync<StockSummaryDto>("Stock/summary");
                if (response != null && response.Success && response.Data != null)
                {
                    var data = response.Data;
                    
                    // Summary kartlarını güncelle
                    lblToplamStok.Text = data.TotalStock.ToString();
                    lblKritikStok.Text = data.CriticalStock.ToString();
                    lblStokYok.Text = data.OutOfStock.ToString();
                    lblHareketler.Text = data.TodayMovements.ToString();
                }
                else
                {
                    // API çağrısı başarısız - summary kartlarını sıfırla
                    lblToplamStok.Text = "0";
                    lblKritikStok.Text = "0";
                    lblStokYok.Text = "0";
                    lblHareketler.Text = "0";
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda summary kartlarını sıfırla
                lblToplamStok.Text = "0";
                lblKritikStok.Text = "0";
                lblStokYok.Text = "0";
                lblHareketler.Text = "0";
                
                MessageBox.Show($"Stok özeti yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadSummaryTestData()
        {
            // Test özet verileri
            lblToplamStok.Text = "20";
            lblKritikStok.Text = "3";
            lblStokYok.Text = "2";
            lblHareketler.Text = "15";
        }

        private async void LoadStockData()
        {
            try
            {
                btnAra.Enabled = false;
                lblDurum.Text = "Veriler yükleniyor...";

                var queryParams = new List<string>
                {
                    $"page={_currentPage}",
                    $"pageSize={_pageSize}"
                };

                // Arama filtrelerini ekle
                if (!string.IsNullOrWhiteSpace(txtUrunAdi.Text))
                    queryParams.Add($"productName={Uri.EscapeDataString(txtUrunAdi.Text)}");

                if (!string.IsNullOrWhiteSpace(txtUrunKodu.Text))
                    queryParams.Add($"productCode={Uri.EscapeDataString(txtUrunKodu.Text)}");

                var queryString = string.Join("&", queryParams);
                
                // Gerçek API çağrısı
                var response = await _apiService.GetAsync<PagedResult<StockCardDto>>($"Stock/cards?{queryString}");
                
                if (response != null && response.Success && response.Data != null)
                {
                    _stockCards.Clear();
                    _filteredStockCards.Clear();

                    foreach (var apiItem in response.Data.Data)
                    {
                        var displayItem = new StockCardDisplayDto
                        {
                            StockCardID = apiItem.StockCardID,
                            ProductCode = apiItem.ProductCode,
                            ProductName = apiItem.ProductName,
                            WarehouseName = apiItem.WarehouseName,
                            CurrentStock = apiItem.CurrentStock,
                            ReservedStock = apiItem.ReservedStock,
                            AvailableStock = apiItem.AvailableStock,
                            StockStatus = GetStockStatusText(apiItem.StockStatus),
                            LastTransactionDate = apiItem.LastTransactionDate?.ToString("dd.MM.yyyy") ?? "-",
                            UnitName = apiItem.UnitName
                        };
                        
                        _stockCards.Add(displayItem);
                        _filteredStockCards.Add(displayItem);
                    }
                    
                    _totalRecords = response.Data.TotalCount;
                    _totalPages = response.Data.TotalPages;
                    _currentPage = response.Data.PageNumber;
                    
                    UpdatePaginationInfo();
                    lblDurum.Text = $"Veriler yüklendi: {_totalRecords} kayıt";
                }
                else
                {
                    // API çağrısı başarısız - verileri temizle
                    _stockCards.Clear();
                    _filteredStockCards.Clear();
                    lblDurum.Text = "API bağlantısı kurulamadı - Veri yüklenemedi";
                    lblDurum.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda verileri temizle
                _stockCards.Clear();
                _filteredStockCards.Clear();
                lblDurum.Text = $"API hatası: {ex.Message}";
                lblDurum.ForeColor = Color.Red;
            }
            finally
            {
                btnAra.Enabled = true;
            }
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

        private void UpdatePaginationInfo()
        {
            lblSayfaBilgisi.Text = $"Sayfa {_currentPage} / {_totalPages}";
            btnOncekiSayfa.Enabled = _currentPage > 1;
            btnSonrakiSayfa.Enabled = _currentPage < _totalPages;
        }

        #region Event Handlers

        private void BtnYeniStokKarti_Click(object? sender, EventArgs e)
        {
            if (_accessLevel.Contains("C"))
            {
                var form = new StokKartiEkleFormNew(_currentUser, _apiService);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadStockData();
                    LoadStockSummary();
                }
            }
        }

        private void BtnStokGuncelle_Click(object? sender, EventArgs e)
        {
            if (_accessLevel.Contains("U"))
            {
                var form = new StokGuncellemeForm(_apiService, _currentUser);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadStockData();
                    LoadStockSummary();
                }
            }
        }

        private void BtnStokTransferi_Click(object? sender, EventArgs e)
        {
            if (_accessLevel.Contains("U"))
            {
                var form = new StokTransferiForm(_currentUser, _apiService);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadStockData();
                    LoadStockSummary();
                }
            }
        }

        private void BtnAra_Click(object? sender, EventArgs e)
        {
            _currentPage = 1;
            LoadStockData();
        }

        private void BtnTemizle_Click(object? sender, EventArgs e)
        {
            txtUrunAdi.Clear();
            txtUrunKodu.Clear();
            _currentPage = 1;
            LoadStockData();
        }

        private void BtnOzet_Click(object? sender, EventArgs e)
        {
            // Stok özet raporunu göster
            var ozet = $"STOK ÖZETİ\n\n" +
                      $"Toplam Stok Türü: {lblToplamStok.Text}\n" +
                      $"Kritik Stok: {lblKritikStok.Text}\n" +
                      $"Stokta Yok: {lblStokYok.Text}\n" +
                      $"Bugünkü Hareketler: {lblHareketler.Text}\n\n" +
                      $"Toplam Kayıt: {_totalRecords}\n" +
                      $"Mevcut Sayfa: {_currentPage} / {_totalPages}";
                      
            MessageBox.Show(ozet, "Stok Özeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnRapor_Click(object? sender, EventArgs e)
        {
            // Excel formatında rapor oluştur
            try
            {
                var rapor = "STOK RAPORU\n\n";
                rapor += "Ürün Kodu\tÜrün Adı\tDepo\tMevcut Stok\tRezerve\tMüsait\tDurum\tSon İşlem\n";
                
                foreach (var item in _filteredStockCards)
                {
                    rapor += $"{item.ProductCode}\t{item.ProductName}\t{item.WarehouseName}\t" +
                            $"{item.CurrentStock}\t{item.ReservedStock}\t{item.AvailableStock}\t" +
                            $"{item.StockStatus}\t{item.LastTransactionDate}\n";
                }
                
                // Raporu clipboard'a kopyala
                Clipboard.SetText(rapor);
                MessageBox.Show("Stok raporu clipboard'a kopyalandı. Excel'e yapıştırabilirsiniz.", 
                    "Rapor Hazır", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rapor oluşturulurken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnKritikStokDetay_Click(object? sender, EventArgs e)
        {
            // TODO: KritikStokDetayForm henüz oluşturulmadı
            // var form = new KritikStokDetayForm(_currentUser, _apiService);
            // form.ShowDialog();
            MessageBox.Show("Kritik Stok Detay formu henüz geliştirilme aşamasında.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnStokYokDetay_Click(object? sender, EventArgs e)
        {
            // TODO: StokYokDetayForm henüz oluşturulmadı
            // var form = new StokYokDetayForm(_currentUser, _apiService);
            // form.ShowDialog();
            MessageBox.Show("Stok Yok Detay formu henüz geliştirilme aşamasında.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnHareketlerDetay_Click(object? sender, EventArgs e)
        {
            // TODO: StokHareketleriForm henüz oluşturulmadı
            // var form = new StokHareketleriForm(_currentUser, _apiService);
            // form.ShowDialog();
            MessageBox.Show("Stok Hareketleri formu henüz geliştirilme aşamasında.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CmbPageSize_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (int.TryParse(cmbPageSize.SelectedItem?.ToString(), out int newPageSize))
            {
                _pageSize = newPageSize;
                _currentPage = 1;
                LoadStockData();
            }
        }

        private void DgvStockCards_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedItem = _filteredStockCards[e.RowIndex];

            if (e.ColumnIndex == dgvStockCards.Columns["colView"]?.Index)
            {
                // TODO: StokDetayForm henüz oluşturulmadı
                // var form = new StokDetayForm(selectedItem.StockCardID, _currentUser, _apiService);
                // form.ShowDialog();
                MessageBox.Show($"Stok Detay formu henüz geliştirilme aşamasında.\nSeçilen Stok ID: {selectedItem.StockCardID}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (e.ColumnIndex == dgvStockCards.Columns["colEdit"]?.Index && _accessLevel.Contains("U"))
            {
                // Stok kartı düzenleme formu aç
                var form = new StokKartiDuzenleForm(selectedItem.StockCardID, _currentUser, _apiService);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadStockData();
                    LoadStockSummary();
                }
            }
            else if (e.ColumnIndex == dgvStockCards.Columns["colDelete"]?.Index && _accessLevel.Contains("D"))
            {
                // Sil
                if (MessageBox.Show($"{selectedItem.ProductName} stok kartını silmek istediğinizden emin misiniz?", 
                    "Stok Kartı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteStockCard(selectedItem.StockCardID);
                }
            }
        }

        private async void DeleteStockCard(int stockCardId)
        {
            try
            {
                var response = await _apiService.DeleteAsync<object>($"Stock/cards/{stockCardId}");
                if (response != null && response.Success)
                {
                    MessageBox.Show("Stok kartı başarıyla silindi.", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStockData();
                    LoadStockSummary();
                }
                else
                {
                    MessageBox.Show(response?.Message ?? "Stok kartı silinirken hata oluştu.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok kartı silinirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTestData()
        {
            _stockCards.Clear();
            _filteredStockCards.Clear();

            var testItems = new List<StockCardDisplayDto>
            {
                new StockCardDisplayDto
                {
                    StockCardID = 1,
                    ProductCode = "CAY001",
                    ProductName = "Bergamot Aromalı Çay (50 Gr)",
                    WarehouseName = "Ana Depo", 
                    CurrentStock = 100,
                    ReservedStock = 10,
                    AvailableStock = 90,
                    StockStatus = "Normal",
                    LastTransactionDate = DateTime.Now.ToString("dd.MM.yyyy"),
                    UnitName = "Adet"
                },
                new StockCardDisplayDto
                {
                    StockCardID = 2,
                    ProductCode = "DETERJAN001", 
                    ProductName = "Laundry Detergent (3kg)",
                    WarehouseName = "Ana Depo",
                    CurrentStock = 0,
                    ReservedStock = 0,
                    AvailableStock = 0,
                    StockStatus = "Yok",
                    LastTransactionDate = DateTime.Now.AddDays(-5).ToString("dd.MM.yyyy"),
                    UnitName = "Adet"
                },
                new StockCardDisplayDto
                {
                    StockCardID = 3,
                    ProductCode = "BISKUVI001",
                    ProductName = "Milk Chocolate Biscuits (150g)",
                    WarehouseName = "Ana Depo",
                    CurrentStock = 5,
                    ReservedStock = 0,
                    AvailableStock = 5,
                    StockStatus = "Kritik",
                    LastTransactionDate = DateTime.Now.AddDays(-2).ToString("dd.MM.yyyy"),
                    UnitName = "Adet"
                },
                new StockCardDisplayDto
                {
                    StockCardID = 4,
                    ProductCode = "LAPTOP001",
                    ProductName = "Dell Laptop 15.6 inch",
                    WarehouseName = "Ana Depo",
                    CurrentStock = 15,
                    ReservedStock = 0,
                    AvailableStock = 15,
                    StockStatus = "Normal",
                    LastTransactionDate = DateTime.Now.AddDays(-1).ToString("dd.MM.yyyy"),
                    UnitName = "Adet"
                }
            };

            foreach (var item in testItems)
            {
                _stockCards.Add(item);
                _filteredStockCards.Add(item);
            }
            
            _totalRecords = testItems.Count;
            _totalPages = 1;
            _currentPage = 1;
            
            UpdatePaginationInfo();
        }

        private void BtnOncekiSayfa_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadStockData();
            }
        }

        private void BtnSonrakiSayfa_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadStockData();
            }
        }

        #endregion
    }

    public class StockCardDisplayDto
    {
        public int StockCardID { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;
        public decimal CurrentStock { get; set; }
        public decimal ReservedStock { get; set; }
        public decimal AvailableStock { get; set; }
        public string StockStatus { get; set; } = string.Empty;
        public string LastTransactionDate { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
    }
}


