using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class StokTransferiForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private List<StockCardDto> _stockCards = new();
        private List<WarehouseDto> _warehouses = new();

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

                // Stok kartlarını yükle
                var stockResponse = await _apiService.GetAsync<PagedResult<StockCardDto>>("Stock/cards?PageNumber=1&PageSize=1000");
                if (stockResponse != null && stockResponse.Success && stockResponse.Data != null)
                {
                    _stockCards = stockResponse.Data.Data.ToList();
                    var products = _stockCards.Select(x => new { x.ProductID, x.ProductName, x.ProductCode }).Distinct().ToList();
                    
                    cmbProduct.DataSource = products;
                    cmbProduct.DisplayMember = "ProductName";
                    cmbProduct.ValueMember = "ProductID";
                    cmbProduct.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Stok kartları yüklenemedi. API bağlantısını kontrol edin.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _stockCards = new List<StockCardDto>();
                }
                
                // Depoları API'den yükle
                var warehouseResponse = await _apiService.GetAsync<List<WarehouseDto>>("Stock/warehouses/active");
                if (warehouseResponse != null && warehouseResponse.Success && warehouseResponse.Data != null)
                {
                    _warehouses = warehouseResponse.Data;
                }
                else
                {
                    MessageBox.Show("Depolar yüklenemedi. API bağlantısını kontrol edin.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _warehouses = new List<WarehouseDto>();
                }

                cmbFromWarehouse.DataSource = _warehouses.ToList();
                cmbFromWarehouse.DisplayMember = "WarehouseName";
                cmbFromWarehouse.ValueMember = "WarehouseID";
                cmbFromWarehouse.SelectedIndex = -1;

                cmbToWarehouse.DataSource = _warehouses.ToList();
                cmbToWarehouse.DisplayMember = "WarehouseName";
                cmbToWarehouse.ValueMember = "WarehouseID";
                cmbToWarehouse.SelectedIndex = -1;

                btnTransfer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbProduct_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateWarehouseOptions();
        }

        private void CmbFromWarehouse_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateStockInfo();
        }

        private void UpdateWarehouseOptions()
        {
            if (cmbProduct.SelectedValue != null)
            {
                int productId = (int)cmbProduct.SelectedValue;
                var availableWarehouses = _stockCards
                    .Where(x => x.ProductID == productId && x.CurrentStock > 0)
                    .Select(x => _warehouses.FirstOrDefault(w => w.WarehouseID == x.WarehouseID))
                    .Where(x => x != null)
                    .Distinct()
                    .ToList();

                // ComboBox binding'lerini güvenli şekilde güncelle
                cmbFromWarehouse.SelectedIndex = -1;
                cmbFromWarehouse.DataSource = null;
                cmbFromWarehouse.DataSource = availableWarehouses;
                cmbFromWarehouse.DisplayMember = "WarehouseName";
                cmbFromWarehouse.ValueMember = "WarehouseID";
                cmbFromWarehouse.SelectedIndex = -1;

                // ToWarehouse için tüm depoları göster
                cmbToWarehouse.SelectedIndex = -1;
                cmbToWarehouse.DataSource = null;
                cmbToWarehouse.DataSource = _warehouses.ToList();
                cmbToWarehouse.DisplayMember = "WarehouseName";
                cmbToWarehouse.ValueMember = "WarehouseID";
                cmbToWarehouse.SelectedIndex = -1;
            }
        }

        private void UpdateStockInfo()
        {
            try
            {
                if (cmbProduct.SelectedValue != null && cmbFromWarehouse.SelectedValue != null)
                {
                    int productId = (int)cmbProduct.SelectedValue;
                    int warehouseId = (int)cmbFromWarehouse.SelectedValue;

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

                var movement = new CreateStockMovementDto
                {
                    ProductID = (int)cmbProduct.SelectedValue!,
                    FromWarehouseID = (int)cmbFromWarehouse.SelectedValue!,
                    ToWarehouseID = (int)cmbToWarehouse.SelectedValue!,
                    Quantity = numMiktar.Value,
                    Description = txtAciklama.Text,
                    MovementDate = DateTime.Now
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
            if (cmbProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbFromWarehouse.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen kaynak depo seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbToWarehouse.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen hedef depo seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbFromWarehouse.SelectedValue != null && cmbToWarehouse.SelectedValue != null && 
                (int)cmbFromWarehouse.SelectedValue == (int)cmbToWarehouse.SelectedValue)
            {
                MessageBox.Show("Kaynak ve hedef depo aynı olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numMiktar.Value <= 0)
            {
                MessageBox.Show("Transfer miktarı 0'dan büyük olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}

