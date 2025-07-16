using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class UrunEkleForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private List<ProductCategoryDto> _categories = new();
        private List<UnitDto> _units = new();

        public UrunEkleForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
        }

        private async void UrunEkleForm_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadUnitsAsync();
            
            // Set default values
            numVatRate.Value = 18; // Default VAT rate
            numMinStock.Value = 0;
            numMaxStock.Value = 0;
            chkIsActive.Checked = true;
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
                    cmbCategory.SelectedIndex = 0;
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
                    cmbUnit.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Birimler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (selectedCategory == null || selectedUnit == null)
                {
                    MessageBox.Show("Lütfen gerekli alanları doldurun.", "Doğrulama Hatası", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var createDto = new CreateProductDto
                {
                    ProductCode = txtProductCode.Text.Trim(),
                    ProductName = txtProductName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    CategoryID = selectedCategory?.Value != -1 ? (int?)selectedCategory?.Value : null,
                    UnitID = selectedUnit?.Value ?? 0,
                    SalePrice = numSalePrice.Value,
                    PurchasePrice = numPurchasePrice.Value,
                    VatRate = numVatRate.Value,
                    MinStockLevel = numMinStock.Value,
                    MaxStockLevel = numMaxStock.Value
                };

                var response = await _apiService.PostAsync<ProductDto>("products", createDto);
                if (response.Success)
                {
                    MessageBox.Show("Ürün başarıyla eklendi.", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Ürün eklenirken hata oluştu: {response.Message}", "Hata", 
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
            if (string.IsNullOrWhiteSpace(txtProductCode.Text))
            {
                MessageBox.Show("Ürün kodu zorunludur.", "Doğrulama Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductCode.Focus();
                return false;
            }

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
