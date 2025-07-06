using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class ProductListForm : Form
    {
        private readonly ProductService _productService;
        private List<ProductDto> _products = new List<ProductDto>();
        private List<ProductCategoryDto> _categories = new List<ProductCategoryDto>();
        private List<UnitDto> _units = new List<UnitDto>();
        private int _currentPage = 1;
        private int _pageSize = 50;
        private int _totalPages = 1;
        private string _currentSearchTerm = "";
        private int? _currentCategoryFilter = null;

        public ProductListForm(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            InitializeForm();
        }

        private async void InitializeForm()
        {
            await LoadCategoriesAndUnits();
            SetupFilters();
            SetupDataGridView();
            await LoadProducts();
            UpdateUI();
        }

        private async Task LoadCategoriesAndUnits()
        {
            try
            {
                // Kategorileri yükle
                var categoriesResponse = await _productService.GetCategoriesAsync();
                if (categoriesResponse.Success && categoriesResponse.Data != null)
                {
                    _categories = categoriesResponse.Data;
                }

                // Birimleri yükle
                var unitsResponse = await _productService.GetUnitsAsync();
                if (unitsResponse.Success && unitsResponse.Data != null)
                {
                    _units = unitsResponse.Data;
                }
            }
            catch (Exception ex)
            {
                ShowError("Veri yükleme hatası", ex.Message, new List<string> { ex.ToString() });
            }
        }

        private void SetupFilters()
        {
            // Category filter setup will be implemented when UI controls are added
        }

        private async Task LoadProducts()
        {
            try
            {
                btnRefresh.Enabled = false;
                btnRefresh.Text = "Yükleniyor...";
                
                var response = await _productService.GetProductsPagedAsync(_currentPage, _pageSize, _currentSearchTerm, _currentCategoryFilter);
                
                if (response.Success && response.Data != null)
                {
                    _products = response.Data.Data;
                    _totalPages = response.Data.TotalPages;
                    
                    dgvProducts.DataSource = _products;
                    
                    lblStatus.Text = $"Toplam {response.Data.TotalCount} ürün. Sayfa {_currentPage}/{_totalPages}";
                }
                else
                {
                    ShowError("Ürünler yüklenemedi", response.Message, response.Errors);
                }
            }
            catch (Exception ex)
            {
                ShowError("Veri yükleme hatası", ex.Message, new List<string> { ex.ToString() });
            }
            finally
            {
                btnRefresh.Enabled = true;
                btnRefresh.Text = "Yenile";
            }
        }

        private void UpdateUI()
        {
            bool hasSelection = dgvProducts.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private void SetupDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;

            // Sütunları tanımla
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductCode",
                HeaderText = "Ürün Kodu",
                DataPropertyName = "ProductCode",
                Width = 120
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Ürün Adı",
                DataPropertyName = "ProductName",
                Width = 200
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                HeaderText = "Kategori",
                DataPropertyName = "CategoryName",
                Width = 150
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitName",
                HeaderText = "Birim",
                DataPropertyName = "UnitName",
                Width = 80
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SalePrice",
                HeaderText = "Satış Fiyatı",
                DataPropertyName = "SalePrice",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CurrentStock",
                HeaderText = "Stok",
                DataPropertyName = "CurrentStock",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dgvProducts.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Aktif",
                DataPropertyName = "IsActive",
                Width = 60
            });
        }

        private void LoadProductsToGrid()
        {
            dgvProducts.DataSource = _products;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _ = RefreshData();
        }

        private async Task RefreshData()
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "Yükleniyor...";
            
            try
            {
                await LoadData();
                LoadProductsToGrid();
                lblStatus.Text = $"Toplam {_products.Count} ürün yüklendi.";
            }
            finally
            {
                btnRefresh.Enabled = true;
                btnRefresh.Text = "Yenile";
            }
        }

        private async Task LoadData()
        {
            await LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new ProductEditForm(_productService, _categories, _units);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                _ = RefreshData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var selectedProduct = (ProductDto)dgvProducts.SelectedRows[0].DataBoundItem;
                var editForm = new ProductEditForm(_productService, _categories, _units, selectedProduct);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _ = RefreshData();
                }
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz ürünü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var selectedProduct = (ProductDto)dgvProducts.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"'{selectedProduct.ProductName}' ürününü silmek istediğinizden emin misiniz?", 
                    "Ürün Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var deleteResponse = await _productService.DeleteProductAsync(selectedProduct.ProductID);
                        if (deleteResponse.Success)
                        {
                            MessageBox.Show("Ürün başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await RefreshData();
                        }
                        else
                        {
                            ShowError("Ürün silinemedi", deleteResponse.Message, deleteResponse.Errors);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError("Silme hatası", ex.Message, new List<string> { ex.ToString() });
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void FilterProducts()
        {
            var searchText = txtSearch.Text.ToLower();
            var filteredProducts = _products.Where(p => 
                p.ProductName.ToLower().Contains(searchText) || 
                p.ProductCode.ToLower().Contains(searchText) ||
                (p.CategoryName?.ToLower().Contains(searchText) ?? false)
            ).ToList();

            dgvProducts.DataSource = filteredProducts;
            lblStatus.Text = $"{filteredProducts.Count} ürün gösteriliyor.";
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

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }
    }
} 