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
                var response = await _apiService.GetAsync<PagedResult<ProductDto>>("Products?pageNumber=1&pageSize=1000");
                if (response?.Success == true && response.Data != null)
                {
                    _products = response.Data.Data.Where(p => p.IsActive).ToList();
                    
                    cmbUrun.DataSource = _products;
                    cmbUrun.DisplayMember = "ProductName";
                    cmbUrun.ValueMember = "ProductID";
                    cmbUrun.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadWarehousesAsync()
        {
            try
            {
                var response = await _apiService.GetAsync<List<WarehouseDto>>("Stock/warehouses/active");
                if (response?.Success == true && response.Data != null)
                {
                    _warehouses = response.Data;
                    
                    cmbDepo.DataSource = _warehouses;
                    cmbDepo.DisplayMember = "WarehouseName";
                    cmbDepo.ValueMember = "WarehouseID";
                    cmbDepo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Depolar yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUrun.SelectedValue != null && cmbUrun.SelectedValue is int productId && productId > 0)
            {
                var selectedProduct = _products.FirstOrDefault(p => p.ProductID == productId);
                if (selectedProduct != null)
                {
                    // Otomatik bilgileri doldur
                    txtBirimFiyat.Text = selectedProduct.CostPrice.ToString("F2");
                    
                    // Depo seçiliyse stok bilgisini yükle
                    if (cmbDepo.SelectedValue != null)
                    {
                        await LoadCurrentStockAsync();
                    }
                }
            }
        }

        private async void cmbDepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepo.SelectedValue != null && cmbUrun.SelectedValue != null)
            {
                await LoadCurrentStockAsync();
            }
        }

        private async Task LoadCurrentStockAsync()
        {
            try
            {
                if (cmbUrun.SelectedValue is int productId && cmbDepo.SelectedValue is int warehouseId)
                {
                    var response = await _apiService.GetAsync<StockCardDto>($"Stock/product/{productId}/warehouse/{warehouseId}");
                    if (response?.Success == true && response.Data != null)
                    {
                        _currentStock = response.Data;
                        
                        // Mevcut stok bilgilerini göster
                        lblMevcutStokBilgi.Text = $"Mevcut Stok: {_currentStock.CurrentStock:N2} {_currentStock.UnitName ?? "Adet"}";
                        
                        // Kart2'yi görünür yap
                        groupBox2.Visible = true;
                    }
                    else
                    {
                        // Stok bulunamadı
                        _currentStock = null;
                        lblMevcutStokBilgi.Text = "Bu ürün için bu depoda stok kaydı bulunamadı. İlk giriş yapılacak.";
                        groupBox2.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok bilgisi yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                _currentStock = null;
                lblMevcutStokBilgi.Text = "Stok bilgisi yüklenemedi.";
                groupBox2.Visible = true;
            }
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

                // API'ye gönderilecek DTO
                var updateDto = new DTOs.UpdateStockDto
                {
                    ProductID = (int)cmbUrun.SelectedValue,
                    WarehouseID = (int)cmbDepo.SelectedValue,
                    Quantity = cmbIslemTuru.SelectedItem?.ToString() == "Giriş" ? miktar : -miktar,
                    UnitPrice = birimFiyat,
                    MovementType = cmbIslemTuru.SelectedItem?.ToString() == "Giriş" ? "IN" : "OUT",
                    Description = txtAciklama.Text
                };

                var response = await _apiService.PostAsync<bool>("Stock/update", updateDto);
                if (response?.Success == true)
                {
                    MessageBox.Show("Stok başarıyla güncellendi.", "Başarılı", 
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
            cmbIslemTuru.SelectedIndex = 0;
            
            // Birim fiyatı ürün seçiminden sonra otomatik doldurulacak
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
