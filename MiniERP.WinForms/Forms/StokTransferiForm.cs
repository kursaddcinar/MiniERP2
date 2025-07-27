using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public class ComboBoxItem
    {
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
        
        public override string ToString()
        {
            return Text;
        }
    }

    public partial class StokTransferiForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private List<StockCardDto> _stockCards = new();
        private List<WarehouseDto> _warehouses = new();
        private bool _isInitializing = true;

        public StokTransferiForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            SetupForm();
            LoadComboBoxData();
        }

        private void SetupForm()
        {
            this.Text = "Stok Transferi";
            
            // Event handlers
            btnTransfer.Click += BtnTransfer_Click;
            btnIptal.Click += BtnIptal_Click;
            cmbProduct.SelectedIndexChanged += CmbProduct_SelectedIndexChanged;
            cmbFromWarehouse.SelectedIndexChanged += CmbFromWarehouse_SelectedIndexChanged;

            // Numeric ayarları
            numMiktar.Minimum = 0.01m;
            numMiktar.Maximum = 999999999;
            numMiktar.DecimalPlaces = 2;
        }

        private async void LoadComboBoxData()
        {
            try
            {
                btnTransfer.Enabled = false;

                // Debug log
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: StokTransferiForm LoadComboBoxData başlatıldı\n");

                // Stok kartlarını yükle
                var stockResponse = await _apiService.GetAsync<PagedResult<StockCardDto>>("Stock/cards?PageNumber=1&PageSize=1000");
                if (stockResponse != null && stockResponse.Success && stockResponse.Data != null)
                {
                    _stockCards = stockResponse.Data.Data.ToList();
                    
                    // Debug log
                    File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: Stok kartları yüklendi: {_stockCards.Count} adet\n");
                    
                    // İlk birkaç stok kartının detayını log'la
                    foreach (var sc in _stockCards.Take(5))
                    {
                        File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: StokKart - ProductID: {sc.ProductID}, WarehouseID: {sc.WarehouseID}, CurrentStock: {sc.CurrentStock}, ProductName: {sc.ProductName}\n");
                    }
                    
                    // Ürünleri benzersiz şekilde al ve ComboBoxItem'e çevir
                    var products = _stockCards
                        .GroupBy(x => x.ProductID)
                        .Select(g => new ComboBoxItem 
                        { 
                            Value = g.Key, 
                            Text = g.First().ProductName 
                        })
                        .ToList();
                    
                    cmbProduct.DataSource = products;
                    cmbProduct.DisplayMember = "Text";
                    cmbProduct.ValueMember = "Value";
                    cmbProduct.SelectedIndex = -1;
                }
                else
                {
                    File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: Stok kartları yüklenemedi - Response: {stockResponse?.Success}, Data: {stockResponse?.Data != null}\n");
                    MessageBox.Show("Stok kartları yüklenemedi. API bağlantısını kontrol edin.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _stockCards = new List<StockCardDto>();
                }
                
                // Depoları API'den yükle - HEPSİNİ ComboBoxItem OLARAK YAP
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: Depolar yüklenmeye başlanıyor - API çağrısı yapılıyor\n");
                var warehouseResponse = await _apiService.GetAsync<List<WarehouseDto>>("Stock/warehouses/active");
                
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: Warehouse API Response - Success: {warehouseResponse?.Success}, Data: {warehouseResponse?.Data != null}, Count: {warehouseResponse?.Data?.Count ?? 0}\n");
                
                if (warehouseResponse != null && warehouseResponse.Success && warehouseResponse.Data != null)
                {
                    _warehouses = warehouseResponse.Data;
                    
                    File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: Depolar başarıyla yüklendi: {_warehouses.Count} adet\n");
                    foreach (var warehouse in _warehouses)
                    {
                        File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: Depo: ID={warehouse.WarehouseID}, Name={warehouse.WarehouseName}, Active={warehouse.IsActive}\n");
                    }
                    
                    // İlk yükleme sırasında boş ComboBox'lar
                    cmbFromWarehouse.DataSource = null;
                    cmbFromWarehouse.Items.Clear();
                    cmbFromWarehouse.SelectedIndex = -1;

                    cmbToWarehouse.DataSource = null;
                    cmbToWarehouse.Items.Clear();
                    cmbToWarehouse.SelectedIndex = -1;
                }
                else
                {
                    File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: Depolar yüklenemedi - API hatası\n");
                    MessageBox.Show("Depolar yüklenemedi. API bağlantısını kontrol edin.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _warehouses = new List<WarehouseDto>();
                }

                btnTransfer.Enabled = true;
                _isInitializing = false; // İlk yükleme tamamlandı
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: LoadComboBoxData tamamlandı, _isInitializing = false\n");
            }
            catch (Exception ex)
            {
                _isInitializing = false;
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: LoadComboBoxData hatası: {ex.Message}\n");
                MessageBox.Show($"Veriler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbProduct_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isInitializing) return;
            UpdateWarehouseOptions();
        }

        private void CmbFromWarehouse_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isInitializing) return;
            UpdateStockInfo();
            UpdateToWarehouseOptions();
        }

        private void UpdateToWarehouseOptions()
        {
            if (cmbFromWarehouse.SelectedItem is ComboBoxItem selectedFromItem)
            {
                // ToWarehouse için seçilen FromWarehouse hariç tüm depoları göster
                var availableToWarehouses = _warehouses
                    .Where(w => w.WarehouseID != selectedFromItem.Value)
                    .Select(w => new ComboBoxItem 
                    { 
                        Value = w.WarehouseID, 
                        Text = w.WarehouseName 
                    }).ToList();
                
                cmbToWarehouse.DataSource = null;
                cmbToWarehouse.DataSource = availableToWarehouses;
                cmbToWarehouse.DisplayMember = "Text";
                cmbToWarehouse.ValueMember = "Value";
                cmbToWarehouse.SelectedIndex = -1;
            }
            else
            {
                // FromWarehouse seçilmemişse ToWarehouse'u temizle
                cmbToWarehouse.DataSource = null;
                cmbToWarehouse.Items.Clear();
            }
        }

        private void UpdateWarehouseOptions()
        {
            if (cmbProduct.SelectedItem is ComboBoxItem productItem)
            {
                int productId = productItem.Value;
                
                var availableWarehouses = _stockCards
                    .Where(x => x.ProductID == productId && x.CurrentStock > 0)
                    .Select(x => _warehouses.FirstOrDefault(w => w.WarehouseID == x.WarehouseID))
                    .Where(x => x != null)
                    .Distinct()
                    .Select(w => new ComboBoxItem { Value = w!.WarehouseID, Text = w.WarehouseName })
                    .ToList();

                // FromWarehouse ComboBox'ını güncelle
                cmbFromWarehouse.DataSource = null;
                cmbFromWarehouse.DataSource = availableWarehouses;
                cmbFromWarehouse.DisplayMember = "Text";
                cmbFromWarehouse.ValueMember = "Value";
                cmbFromWarehouse.SelectedIndex = -1;

                // ToWarehouse'u temizle - FromWarehouse seçildikten sonra dolacak
                cmbToWarehouse.DataSource = null;
                cmbToWarehouse.Items.Clear();
                cmbToWarehouse.SelectedIndex = -1;
            }
            else
            {
                // Product seçilmemişse her iki depo ComboBox'ını da temizle
                cmbFromWarehouse.DataSource = null;
                cmbFromWarehouse.Items.Clear();
                cmbToWarehouse.DataSource = null;
                cmbToWarehouse.Items.Clear();
            }
        }

        private void UpdateStockInfo()
        {
            try
            {
                if (cmbProduct.SelectedItem is ComboBoxItem productItem && 
                    cmbFromWarehouse.SelectedItem is ComboBoxItem warehouseItem)
                {
                    int productId = productItem.Value;
                    int warehouseId = warehouseItem.Value;

                    var stockCard = _stockCards.FirstOrDefault(x => x.ProductID == productId && x.WarehouseID == warehouseId);
                    if (stockCard != null)
                    {
                        lblMevcutStok.Text = $"Mevcut Stok: {stockCard.CurrentStock} {stockCard.UnitName}";
                        numMiktar.Maximum = stockCard.CurrentStock;
                    }
                    else
                    {
                        lblMevcutStok.Text = "Mevcut Stok: 0";
                        numMiktar.Maximum = 0;
                    }
                }
                else
                {
                    lblMevcutStok.Text = "Mevcut Stok: -";
                    numMiktar.Maximum = 0;
                }
            }
            catch
            {
                lblMevcutStok.Text = "Mevcut Stok: Hata";
                numMiktar.Maximum = 0;
            }
        }

        private async void BtnTransfer_Click(object? sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                btnTransfer.Enabled = false;

                // SelectedItem kullanarak güvenli value alımları
                if (!(cmbProduct.SelectedItem is ComboBoxItem productItem) ||
                    !(cmbFromWarehouse.SelectedItem is ComboBoxItem fromItem) ||
                    !(cmbToWarehouse.SelectedItem is ComboBoxItem toItem))
                {
                    MessageBox.Show("Lütfen tüm alanları doğru şekilde doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var movement = new CreateStockMovementDto
                {
                    ProductID = productItem.Value,
                    FromWarehouseID = fromItem.Value,
                    ToWarehouseID = toItem.Value,
                    Quantity = numMiktar.Value,
                    Description = txtAciklama.Text,
                    MovementDate = DateTime.Now,
                    Notes = txtAciklama.Text
                };

                var response = await _apiService.PostAsync<object>("Stock/transfer", movement);
                if (response != null && response.Success)
                {
                    MessageBox.Show("Stok transferi başarıyla gerçekleştirildi.", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response?.Message ?? "Stok transferi yapılırken hata oluştu.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok transferi yapılırken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTransfer.Enabled = true;
            }
        }

        private void BtnIptal_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            if (cmbProduct.SelectedIndex == -1 || cmbProduct.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbFromWarehouse.SelectedIndex == -1 || cmbFromWarehouse.SelectedItem == null)
            {
                MessageBox.Show("Lütfen kaynak depo seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbToWarehouse.SelectedIndex == -1 || cmbToWarehouse.SelectedItem == null)
            {
                MessageBox.Show("Lütfen hedef depo seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // ComboBoxItem kontrolü - SelectedItem kullan
            if (!(cmbProduct.SelectedItem is ComboBoxItem productItem))
            {
                MessageBox.Show("Ürün seçiminde hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!(cmbFromWarehouse.SelectedItem is ComboBoxItem fromItem))
            {
                MessageBox.Show("Kaynak depo seçiminde hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!(cmbToWarehouse.SelectedItem is ComboBoxItem toItem))
            {
                MessageBox.Show("Hedef depo seçiminde hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (fromItem.Value == toItem.Value)
            {
                MessageBox.Show("Kaynak ve hedef depo aynı olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numMiktar.Value <= 0)
            {
                MessageBox.Show("Transfer miktarı 0'dan büyük olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Mevcut stoklardan büyük transfer miktarı kontrolü
            try
            {
                var stockCard = _stockCards.FirstOrDefault(x => x.ProductID == productItem.Value && x.WarehouseID == fromItem.Value);
                if (stockCard != null && numMiktar.Value > stockCard.CurrentStock)
                {
                    MessageBox.Show($"Transfer miktarı mevcut stoktan ({stockCard.CurrentStock}) fazla olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                // Stok kontrolünde hata olursa devam et
            }

            return true;
        }
    }
}

