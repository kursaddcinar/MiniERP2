using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class ProductEditForm : Form
    {
        private readonly ProductService _productService;
        private readonly List<ProductCategoryDto> _categories;
        private readonly List<UnitDto> _units;
        private readonly ProductDto? _editingProduct;
        private bool _isEditMode;

        public ProductEditForm(ProductService productService, List<ProductCategoryDto> categories, List<UnitDto> units, ProductDto? editingProduct = null)
        {
            InitializeComponent();
            _productService = productService;
            _categories = categories;
            _units = units;
            _editingProduct = editingProduct;
            _isEditMode = editingProduct != null;
            
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Form başlığını ayarla
            this.Text = _isEditMode ? "Ürün Düzenle" : "Yeni Ürün Ekle";
            lblTitle.Text = _isEditMode ? "Ürün Düzenle" : "Yeni Ürün Ekle";

            // ComboBox'ları doldur
            LoadCategories();
            LoadUnits();

            // Eğer düzenleme modundaysa verileri yükle
            if (_isEditMode && _editingProduct != null)
            {
                LoadProductData();
            }
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add(new { Text = "Kategori Seçiniz", Value = (int?)null });
            
            foreach (var category in _categories)
            {
                cmbCategory.Items.Add(new { Text = category.CategoryName, Value = (int?)category.CategoryID });
            }
            
            cmbCategory.DisplayMember = "Text";
            cmbCategory.ValueMember = "Value";
            cmbCategory.SelectedIndex = 0;
        }

        private void LoadUnits()
        {
            cmbUnit.Items.Clear();
            
            foreach (var unit in _units)
            {
                cmbUnit.Items.Add(new { Text = unit.UnitName, Value = unit.UnitID });
            }
            
            cmbUnit.DisplayMember = "Text";
            cmbUnit.ValueMember = "Value";
            
            if (cmbUnit.Items.Count > 0)
                cmbUnit.SelectedIndex = 0;
        }

        private void LoadProductData()
        {
            if (_editingProduct == null) return;

            txtProductCode.Text = _editingProduct.ProductCode;
            txtProductName.Text = _editingProduct.ProductName;
            numSalePrice.Value = _editingProduct.SalePrice;
            numPurchasePrice.Value = _editingProduct.PurchasePrice;
            numVatRate.Value = _editingProduct.VatRate;
            numMinStock.Value = _editingProduct.MinStockLevel;
            numMaxStock.Value = _editingProduct.MaxStockLevel;
            chkIsActive.Checked = _editingProduct.IsActive;

            // Kategori seçimi
            if (_editingProduct.CategoryID.HasValue)
            {
                for (int i = 0; i < cmbCategory.Items.Count; i++)
                {
                    var item = (dynamic)cmbCategory.Items[i];
                    if (item.Value == _editingProduct.CategoryID)
                    {
                        cmbCategory.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Birim seçimi
            for (int i = 0; i < cmbUnit.Items.Count; i++)
            {
                var item = (dynamic)cmbUnit.Items[i];
                if (item.Value == _editingProduct.UnitID)
                {
                    cmbUnit.SelectedIndex = i;
                    break;
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            btnSave.Enabled = false;
            btnSave.Text = "Kaydediliyor...";

            try
            {
                if (_isEditMode)
                {
                    await UpdateProduct();
                }
                else
                {
                    await CreateProduct();
                }
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "Kaydet";
            }
        }

        private async Task CreateProduct()
        {
            var createDto = new CreateProductDto
            {
                ProductCode = txtProductCode.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                CategoryID = GetSelectedCategoryId(),
                UnitID = GetSelectedUnitId(),
                SalePrice = numSalePrice.Value,
                PurchasePrice = numPurchasePrice.Value,
                VatRate = numVatRate.Value,
                MinStockLevel = numMinStock.Value,
                MaxStockLevel = numMaxStock.Value
            };

            var response = await _productService.CreateProductAsync(createDto);
            if (response.Success)
            {
                MessageBox.Show("Ürün başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                ShowError("Ürün eklenemedi", response.Message, response.Errors);
            }
        }

        private async Task UpdateProduct()
        {
            if (_editingProduct == null) return;

            var updateDto = new UpdateProductDto
            {
                ProductName = txtProductName.Text.Trim(),
                CategoryID = GetSelectedCategoryId(),
                UnitID = GetSelectedUnitId(),
                SalePrice = numSalePrice.Value,
                PurchasePrice = numPurchasePrice.Value,
                VatRate = numVatRate.Value,
                MinStockLevel = numMinStock.Value,
                MaxStockLevel = numMaxStock.Value,
                IsActive = chkIsActive.Checked
            };

            var response = await _productService.UpdateProductAsync(_editingProduct.ProductID, updateDto);
            if (response.Success)
            {
                MessageBox.Show("Ürün başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                ShowError("Ürün güncellenemedi", response.Message, response.Errors);
            }
        }

        private int? GetSelectedCategoryId()
        {
            if (cmbCategory.SelectedItem != null)
            {
                var item = (dynamic)cmbCategory.SelectedItem;
                return item.Value;
            }
            return null;
        }

        private int GetSelectedUnitId()
        {
            if (cmbUnit.SelectedItem != null)
            {
                var item = (dynamic)cmbUnit.SelectedItem;
                return item.Value;
            }
            return 0;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtProductCode.Text))
            {
                MessageBox.Show("Ürün kodu gereklidir.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Ürün adı gereklidir.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }

            if (cmbUnit.SelectedItem == null)
            {
                MessageBox.Show("Birim seçimi gereklidir.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUnit.Focus();
                return false;
            }

            return true;
        }

        private void ShowError(string title, string message, List<string> errors)
        {
            string errorMessage = message;
            if (errors.Any())
            {
                errorMessage += "\n\nDetaylar:\n" + string.Join("\n", errors);
            }

            MessageBox.Show(errorMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 