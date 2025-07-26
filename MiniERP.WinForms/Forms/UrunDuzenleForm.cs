using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class UrunDuzenleForm : Form
    {
        private readonly ProductDto _product;
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private List<ProductCategoryDto> _categories = new();
        private List<UnitDto> _units = new();

        public UrunDuzenleForm(ProductDto product, UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _product = product;
            _currentUser = currentUser;
            _apiService = apiService;
        }

        private async void UrunDuzenleForm_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadUnitsAsync();
            LoadProductData();
            
            // Maksimum stok kontrolünün görünür olduğundan emin olalım
            lblMaxStock.Visible = true;
            numMaxStock.Visible = true;
            
            // Panel otomatik scroll özelliğini etkinleştir
            panelMain.AutoScroll = true;
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var response = await _apiService.GetAsync<List<ProductCategoryDto>>("ProductCategory");
                if (response != null && response.Success && response.Data != null)
                {
                    _categories = response.Data.Where(c => c.IsActive).ToList();
                    
                    cmbCategory.Items.Clear();
                    cmbCategory.Items.Add(new { Text = "Kategori Seçiniz", Value = -1 });
                    
                    foreach (var category in _categories)
                    {
                        cmbCategory.Items.Add(new { Text = category.CategoryName, Value = category.CategoryID });
                    }
                    
                    cmbCategory.DisplayMember = "Text";
                    cmbCategory.ValueMember = "Value";
                    
                    // Set default selection
                    if (cmbCategory.Items.Count > 0)
                        cmbCategory.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Kategoriler yüklenemedi. API yanıtı boş veya başarısız.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadUnitsAsync()
        {
            try
            {
                var response = await _apiService.GetAsync<List<UnitDto>>("Unit");
                if (response != null && response.Success && response.Data != null)
                {
                    _units = response.Data.Where(u => u.IsActive).ToList();
                    
                    cmbUnit.Items.Clear();
                    cmbUnit.Items.Add(new { Text = "Birim Seçiniz", Value = -1 });
                    
                    foreach (var unit in _units)
                    {
                        cmbUnit.Items.Add(new { Text = unit.UnitName, Value = unit.UnitID });
                    }
                    
                    cmbUnit.DisplayMember = "Text";
                    cmbUnit.ValueMember = "Value";
                    
                    // Set default selection
                    if (cmbUnit.Items.Count > 0)
                        cmbUnit.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Birimler yüklenemedi. API yanıtı boş veya başarısız.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Birimler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductData()
        {
            // Load existing product data
            lblProductCode.Text = _product.ProductCode; // Product code is not editable
            txtProductName.Text = _product.ProductName;
            txtDescription.Text = _product.Description ?? "";
            numSalePrice.Value = _product.SalePrice;
            numPurchasePrice.Value = _product.PurchasePrice;
            numVatRate.Value = _product.VatRate;
            numMinStock.Value = _product.MinStockLevel;
            numMaxStock.Value = _product.MaxStockLevel;
            chkIsActive.Checked = _product.IsActive;

            // Set category selection
            if (_product.CategoryID.HasValue)
            {
                for (int i = 0; i < cmbCategory.Items.Count; i++)
                {
                    var item = cmbCategory.Items[i] as dynamic;
                    if (item?.Value == _product.CategoryID.Value)
                    {
                        cmbCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                cmbCategory.SelectedIndex = 0; // "Kategori Seçiniz"
            }

            // Set unit selection
            bool unitFound = false;
            for (int i = 0; i < cmbUnit.Items.Count; i++)
            {
                var item = cmbUnit.Items[i] as dynamic;
                if (item?.Value == _product.UnitID)
                {
                    cmbUnit.SelectedIndex = i;
                    unitFound = true;
                    break;
                }
            }
            
            // If unit not found, select the first option (Birim Seçiniz)
            if (!unitFound && cmbUnit.Items.Count > 0)
            {
                cmbUnit.SelectedIndex = 0;
            }
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                var selectedCategory = cmbCategory.SelectedItem as dynamic;
                var selectedUnit = cmbUnit.SelectedItem as dynamic;

                if (selectedUnit == null)
                {
                    MessageBox.Show("Lütfen gerekli alanları doldurun.", "Doğrulama Hatası", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var updateDto = new UpdateProductDto
                {
                    ProductName = txtProductName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    CategoryID = selectedCategory?.Value != -1 ? (int?)selectedCategory?.Value : null,
                    UnitID = selectedUnit?.Value ?? 0,
                    SalePrice = numSalePrice.Value,
                    PurchasePrice = numPurchasePrice.Value,
                    VatRate = numVatRate.Value,
                    MinStockLevel = numMinStock.Value,
                    MaxStockLevel = numMaxStock.Value,
                    IsActive = chkIsActive.Checked
                };

                var response = await _apiService.PutAsync<ProductDto>($"products/{_product.ProductID}", updateDto);
                if (response.Success)
                {
                    MessageBox.Show("Ürün başarıyla güncellendi.", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Ürün güncellenirken hata oluştu: {response.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Ürün adı zorunludur.", "Doğrulama Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }

            var selectedUnit = cmbUnit.SelectedItem as dynamic;
            if (selectedUnit == null || selectedUnit?.Value == -1)
            {
                MessageBox.Show("Birim seçimi zorunludur.", "Doğrulama Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUnit.Focus();
                return false;
            }

            if (numSalePrice.Value <= 0)
            {
                MessageBox.Show("Satış fiyatı sıfırdan büyük olmalıdır.", "Doğrulama Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSalePrice.Focus();
                return false;
            }

            if (numPurchasePrice.Value <= 0)
            {
                MessageBox.Show("Alış fiyatı sıfırdan büyük olmalıdır.", "Doğrulama Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPurchasePrice.Focus();
                return false;
            }

            if (numMaxStock.Value > 0 && numMinStock.Value > numMaxStock.Value)
            {
                MessageBox.Show("Minimum stok, maksimum stoktan büyük olamaz.", "Doğrulama Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMinStock.Focus();
                return false;
            }

            return true;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}


