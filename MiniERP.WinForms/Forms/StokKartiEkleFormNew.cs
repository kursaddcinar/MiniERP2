using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class StokKartiEkleFormNew : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private List<ProductDto> _products = new();
        private List<WarehouseDto> _warehouses = new();

        public StokKartiEkleFormNew(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;

            SetupForm();
            LoadComboBoxData();
        }

        private void SetupForm()
        {
            this.Text = "Yeni Stok Kartı";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Event handlers
            btnKaydet.Click += BtnKaydet_Click;
            btnIptal.Click += BtnIptal_Click;
            cmbUrun.SelectedIndexChanged += CmbUrun_SelectedIndexChanged;

            // Numeric değerler için ayarlar
            numMevcutStok.Minimum = 0;
            numMevcutStok.Maximum = 999999999;
            numMevcutStok.DecimalPlaces = 2;
            numMevcutStok.Value = 0;

            numRezerveStok.Minimum = 0;
            numRezerveStok.Maximum = 999999999;
            numRezerveStok.DecimalPlaces = 2;
            numRezerveStok.Value = 0;
        }

        private async void LoadComboBoxData()
        {
            try
            {
                btnKaydet.Enabled = false;
                lblDurum.Text = "Veriler yükleniyor...";
                lblDurum.ForeColor = Color.FromArgb(234, 179, 8);

                // Ürünleri yükle
                var productResponse = await _apiService.GetAsync<PagedResult<ProductDto>>("Products?PageNumber=1&PageSize=1000");
                if (productResponse != null && productResponse.Success && productResponse.Data != null)
                {
                    _products = productResponse.Data.Data.ToList();
                    cmbUrun.DataSource = _products;
                    cmbUrun.DisplayMember = "ProductName";
                    cmbUrun.ValueMember = "ProductID";
                    cmbUrun.SelectedIndex = -1;
                }
                else
                {
                    // Ürün API'si başarısız
                    MessageBox.Show("Ürünler yüklenemedi. API bağlantısını kontrol edin.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblDurum.Text = "Ürün API Hatası";
                    lblDurum.ForeColor = Color.Red;
                    btnKaydet.Enabled = false;
                    return;
                }

                // Depoları yükle (Web projesindeki endpoint'i kullan)
                var warehouseResponse = await _apiService.GetAsync<List<WarehouseDto>>("Stock/warehouses/active");
                if (warehouseResponse != null && warehouseResponse.Success && warehouseResponse.Data != null)
                {
                    _warehouses = warehouseResponse.Data;
                }
                else
                {
                    // Depo API'si başarısız - minimum test depoları
                    MessageBox.Show("Depolar yüklenemedi. API bağlantısını kontrol edin.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _warehouses = new List<WarehouseDto>();
                }
                
                cmbDepo.DataSource = _warehouses;
                cmbDepo.DisplayMember = "WarehouseName";
                cmbDepo.ValueMember = "WarehouseID";
                cmbDepo.SelectedIndex = -1;

                lblDurum.Text = "Hazır";
                lblDurum.ForeColor = Color.White;
                btnKaydet.Enabled = true;
            }
            catch (Exception ex)
            {
                lblDurum.Text = "Hata oluştu";
                lblDurum.ForeColor = Color.FromArgb(239, 68, 68);
                MessageBox.Show($"Veriler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                btnKaydet.Enabled = false;
            }
        }

        private void LoadTestData()
        {
            _products = new List<ProductDto>
            {
                new ProductDto { ProductID = 1, ProductCode = "CAY001", ProductName = "Bergamot Aromalı Çay (50 Gr)", UnitName = "Adet" },
                new ProductDto { ProductID = 2, ProductCode = "DETERJAN001", ProductName = "Laundry Detergent (3kg)", UnitName = "Adet" },
                new ProductDto { ProductID = 3, ProductCode = "BISKUVI001", ProductName = "Milk Chocolate Biscuits (150g)", UnitName = "Adet" },
                new ProductDto { ProductID = 4, ProductCode = "LAPTOP001", ProductName = "Dell Laptop 15.6 inch", UnitName = "Adet" }
            };
            
            _warehouses = new List<WarehouseDto>
            {
                new WarehouseDto { WarehouseID = 1, WarehouseName = "Ana Depo", WarehouseCode = "ANA" },
                new WarehouseDto { WarehouseID = 2, WarehouseName = "Şube Deposu", WarehouseCode = "SUBE" },
                new WarehouseDto { WarehouseID = 3, WarehouseName = "Transit Depo", WarehouseCode = "TRANSIT" }
            };
            
            cmbUrun.DataSource = _products;
            cmbUrun.DisplayMember = "ProductName";
            cmbUrun.ValueMember = "ProductID";
            cmbUrun.SelectedIndex = -1;
            
            cmbDepo.DataSource = _warehouses;
            cmbDepo.DisplayMember = "WarehouseName";
            cmbDepo.ValueMember = "WarehouseID";
            cmbDepo.SelectedIndex = -1;

            lblDurum.Text = "Test Verisi Yüklendi";
            lblDurum.ForeColor = Color.White;
            btnKaydet.Enabled = true;
        }

        private void CmbUrun_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbUrun.SelectedItem is ProductDto selectedProduct)
            {
                // Ürün seçildiğinde ek bilgiler güncellenebilir
                // Şu an için boş
            }
        }

        private async void BtnKaydet_Click(object? sender, EventArgs e)
        {
            try
            {
                // Validasyon
                if (cmbUrun.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbUrun.Focus();
                    return;
                }

                if (cmbDepo.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir depo seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDepo.Focus();
                    return;
                }

                if (numRezerveStok.Value > numMevcutStok.Value)
                {
                    MessageBox.Show("Rezerve stok, mevcut stoktan fazla olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numRezerveStok.Focus();
                    return;
                }

                btnKaydet.Enabled = false;
                lblDurum.Text = "Kaydediliyor...";
                lblDurum.ForeColor = Color.FromArgb(234, 179, 8);

                var createDto = new CreateStockCardDto
                {
                    ProductID = (int)cmbUrun.SelectedValue!,
                    WarehouseID = (int)cmbDepo.SelectedValue!,
                    CurrentStock = numMevcutStok.Value,
                    ReservedStock = numRezerveStok.Value
                };

                var response = await _apiService.PostAsync<StockCardDto>("Stock/cards", createDto);

                if (response != null && response.Success)
                {
                    MessageBox.Show("Stok kartı başarıyla oluşturuldu.", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response?.Message ?? "Stok kartı oluşturulurken hata oluştu.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblDurum.Text = "Hata oluştu";
                    lblDurum.ForeColor = Color.FromArgb(239, 68, 68);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok kartı oluşturulurken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblDurum.Text = "Hata oluştu";
                lblDurum.ForeColor = Color.FromArgb(239, 68, 68);
            }
            finally
            {
                btnKaydet.Enabled = true;
            }
        }

        private void BtnIptal_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}


