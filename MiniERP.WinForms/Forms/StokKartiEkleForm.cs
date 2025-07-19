using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class StokKartiEkleForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private List<ProductDto> _products = new();
        private List<WarehouseDto> _warehouses = new();

        public StokKartiEkleForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;

            SetupForm();
            LoadComboBoxData();
        }

        private void SetupForm()
        {
            this.Text = "Yeni Stok Kartı (Temel)";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Event handlers
            btnKaydet.Click += BtnKaydet_Click;
            btnIptal.Click += BtnIptal_Click;
            cmbProduct.SelectedIndexChanged += CmbProduct_SelectedIndexChanged;

            // Numeric değerler için ayarlar
            numMevcutStok.Minimum = 0;
            numMevcutStok.Maximum = 999999999;
            numMevcutStok.DecimalPlaces = 2;

            numRezerveStok.Minimum = 0;
            numRezerveStok.Maximum = 999999999;
            numRezerveStok.DecimalPlaces = 2;
        }

        private async void LoadComboBoxData()
        {
            try
            {
                btnKaydet.Enabled = false;
                lblDurum.Text = "Veriler yükleniyor...";

                // Ürünleri yükle
                var productResponse = await _apiService.GetAsync<PagedResult<ProductDto>>("api/Products?pageSize=1000");
                if (productResponse != null && productResponse.Success && productResponse.Data != null)
                {
                    _products = productResponse.Data.Data.ToList();
                    cmbProduct.DataSource = _products;
                    cmbProduct.DisplayMember = "ProductName";
                    cmbProduct.ValueMember = "ProductID";
                    cmbProduct.SelectedIndex = -1;
                }

                // Depoları yükle - Basit test verisi oluşturalım
                _warehouses = new List<WarehouseDto>
                {
                    new WarehouseDto { WarehouseID = 1, WarehouseName = "Ana Depo", WarehouseCode = "ANA" },
                    new WarehouseDto { WarehouseID = 2, WarehouseName = "Şube Deposu", WarehouseCode = "SUBE" },
                    new WarehouseDto { WarehouseID = 3, WarehouseName = "Transit Depo", WarehouseCode = "TRANSIT" }
                };
                
                cmbWarehouse.DataSource = _warehouses;
                cmbWarehouse.DisplayMember = "WarehouseName";
                cmbWarehouse.ValueMember = "WarehouseID";
                cmbWarehouse.SelectedIndex = -1;

                lblDurum.Text = "Hazır";
                btnKaydet.Enabled = true;
            }
            catch (Exception ex)
            {
                lblDurum.Text = "Hata oluştu";
                MessageBox.Show($"Veriler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbProduct_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem is ProductDto selectedProduct)
            {
                txtUrunKodu.Text = selectedProduct.ProductCode;
                txtBirim.Text = selectedProduct.UnitName;
            }
            else
            {
                txtUrunKodu.Clear();
                txtBirim.Clear();
            }
        }

        private async void BtnKaydet_Click(object? sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                btnKaydet.Enabled = false;
                lblDurum.Text = "Kaydediliyor...";

                var dto = new CreateStockCardDto
                {
                    ProductID = cmbProduct.SelectedValue != null ? (int)cmbProduct.SelectedValue : 0,
                    WarehouseID = cmbWarehouse.SelectedValue != null ? (int)cmbWarehouse.SelectedValue : 0,
                    CurrentStock = numMevcutStok.Value,
                    ReservedStock = numRezerveStok.Value,
                    MinStockLevel = numMinStok.Value,
                    MaxStockLevel = numMaxStok.Value
                };

                var response = await _apiService.PostAsync<object>("api/Stock/cards", dto);
                if (response != null && response.Success)
                {
                    MessageBox.Show("Stok kartı başarıyla eklendi.", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response?.Message ?? "Stok kartı eklenirken hata oluştu.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok kartı eklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnKaydet.Enabled = true;
                lblDurum.Text = "Hazır";
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
                cmbProduct.Focus();
                return false;
            }

            if (cmbWarehouse.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir depo seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
                return false;
            }

            if (numMaxStok.Value > 0 && numMinStok.Value > numMaxStok.Value)
            {
                MessageBox.Show("Minimum stok seviyesi maksimum stok seviyesinden büyük olamaz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMinStok.Focus();
                return false;
            }

            if (numRezerveStok.Value > numMevcutStok.Value)
            {
                MessageBox.Show("Rezerve stok miktarı mevcut stoktan fazla olamaz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numRezerveStok.Focus();
                return false;
            }

            return true;
        }
    }
}


