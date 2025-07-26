using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class UrunlerForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private readonly string _userRole;
        private List<ProductDto> _allProducts = new();
        private List<ProductCategoryDto> _categories = new();
        private int _totalCount = 0;
        private int _activeCount = 0;
        private int _inactiveCount = 0;

        // Role-based permissions for products
        private readonly Dictionary<string, List<string>> _rolePermissions = new()
        {
            ["Admin"] = new() { "Create", "Read", "Update", "Delete" },
            ["Manager"] = new() { "Create", "Read", "Update", "Delete" },
            ["Sales"] = new() { "Read" },
            ["Purchase"] = new() { "Create", "Read", "Update", "Delete" },
            ["Finance"] = new() { }, // No access
            ["Warehouse"] = new() { "Read" }
        };

        public UrunlerForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            _userRole = GetPrimaryRole();
            
            SetupRoleBasedAccess();
            SetupDataGridView();
        }

        private string GetPrimaryRole()
        {
            if (_currentUser.Roles.Contains("Admin")) return "Admin";
            if (_currentUser.Roles.Contains("Manager")) return "Manager";
            if (_currentUser.Roles.Contains("Sales")) return "Sales";
            if (_currentUser.Roles.Contains("Purchase")) return "Purchase";
            if (_currentUser.Roles.Contains("Finance")) return "Finance";
            if (_currentUser.Roles.Contains("Warehouse")) return "Warehouse";
            return "Employee";
        }

        private bool HasPermission(string action)
        {
            return _rolePermissions.ContainsKey(_userRole) && 
                   _rolePermissions[_userRole].Contains(action);
        }

        private void SetupRoleBasedAccess()
        {
            // Finance users should not access this form at all
            if (_userRole == "Finance")
            {
                MessageBox.Show("Bu modüle erişim yetkiniz bulunmamaktadır.", "Erişim Engellendi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            bool canCreate = HasPermission("Create");
            bool canUpdate = HasPermission("Update");
            bool canDelete = HasPermission("Delete");

            // Control button visibility based on permissions
            btnYeniUrun.Visible = canCreate;
            
            // Set button colors based on permissions
            if (!canCreate)
            {
                btnYeniUrun.BackColor = Color.FromArgb(156, 163, 175);
                btnYeniUrun.Enabled = false;
            }

            // Update title based on user role
            if (_userRole == "Sales" || _userRole == "Warehouse")
            {
                lblTitle.Text = "📦 ÜRÜN YÖNETİMİ (Sadece Görüntüleme)";
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewUrunler.Columns.Clear();
            dataGridViewUrunler.AutoGenerateColumns = false;

            // Product Code column
            dataGridViewUrunler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductCode",
                HeaderText = "Ürün Kodu",
                Name = "ProductCode",
                Width = 120
            });

            // Product Name column
            dataGridViewUrunler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Ürün Adı",
                Name = "ProductName",
                Width = 200
            });

            // Category column
            dataGridViewUrunler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CategoryName",
                HeaderText = "Kategori",
                Name = "CategoryName",
                Width = 150
            });

            // Sale Price column
            dataGridViewUrunler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SalePrice",
                HeaderText = "Satış Fiyatı",
                Name = "SalePrice",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = Helpers.CurrencyHelper.GetDataGridViewCurrencyFormat() }
            });

            // Stock column
            dataGridViewUrunler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CurrentStock",
                HeaderText = "Stok",
                Name = "CurrentStock",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            // Status column
            dataGridViewUrunler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IsActive",
                HeaderText = "Durum",
                Name = "IsActive",
                Width = 80
            });

            // Actions column
            var actionsColumn = new DataGridViewButtonColumn
            {
                HeaderText = "İşlemler",
                Name = "Actions",
                Text = "İşlemler",
                UseColumnTextForButtonValue = true,
                Width = 150
            };
            dataGridViewUrunler.Columns.Add(actionsColumn);

            // Handle cell click for action buttons
            dataGridViewUrunler.CellClick += DataGridViewUrunler_CellClick;
            
            // Format status display
            dataGridViewUrunler.CellFormatting += DataGridViewUrunler_CellFormatting;
        }

        private void DataGridViewUrunler_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewUrunler.Columns[e.ColumnIndex].Name == "IsActive")
            {
                if (e.Value != null && e.Value is bool isActive)
                {
                    e.Value = isActive ? "Aktif" : "Pasif";
                    if (e.CellStyle != null)
                    {
                        e.CellStyle.ForeColor = isActive ? Color.Green : Color.Red;
                    }
                    e.FormattingApplied = true;
                }
            }
        }

        private void DataGridViewUrunler_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var columnName = dataGridViewUrunler.Columns[e.ColumnIndex].Name;
                
                if (columnName == "Actions")
                {
                    var product = (ProductDto)dataGridViewUrunler.Rows[e.RowIndex].DataBoundItem;
                    ShowProductActions(product);
                }
            }
        }

        private void ShowProductActions(ProductDto product)
        {
            var contextMenu = new ContextMenuStrip();

            // Details option - always available for users with Read permission
            if (HasPermission("Read"))
            {
                var detailsItem = new ToolStripMenuItem("🔍 Detaylar", null, (s, e) => 
                {
                    var detailForm = new UrunDetayForm(product, _apiService);
                    detailForm.ShowDialog();
                });
                contextMenu.Items.Add(detailsItem);
            }

            // Edit option - only for users with Update permission
            if (HasPermission("Update"))
            {
                var editItem = new ToolStripMenuItem("✏️ Düzenle", null, async (s, e) => 
                {
                    var editForm = new UrunDuzenleForm(product, _currentUser, _apiService);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        await LoadProductsAsync();
                    }
                });
                contextMenu.Items.Add(editItem);
            }

            // Delete option - only for users with Delete permission
            if (HasPermission("Delete"))
            {
                contextMenu.Items.Add(new ToolStripSeparator());
                var deleteItem = new ToolStripMenuItem("🗑️ Sil", null, async (s, e) => 
                {
                    await DeleteProductAsync(product);
                });
                deleteItem.ForeColor = Color.Red;
                contextMenu.Items.Add(deleteItem);
            }

            if (contextMenu.Items.Count > 0)
            {
                contextMenu.Show(dataGridViewUrunler, dataGridViewUrunler.PointToClient(Cursor.Position));
            }
        }

        private async Task DeleteProductAsync(ProductDto product)
        {
            var result = MessageBox.Show(
                $"'{product.ProductName}' ürününü silmek istediğinizden emin misiniz?",
                "Ürün Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var response = await _apiService.DeleteAsync<object>($"products/{product.ProductID}");
                    if (response.Success)
                    {
                        MessageBox.Show("Ürün başarıyla silindi.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadProductsAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Ürün silinirken hata oluştu: {response.Message}", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Beklenmeyen hata: {ex.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void UrunlerForm_Load(object sender, EventArgs e)
        {
            // Initialize page size combo
            cmbSayfaBoyutu.SelectedIndex = 0; // Select "10" by default
            
            await LoadCategoriesAsync();
            await LoadProductsAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                // ProductCategory endpoint List<ProductCategoryDto> döndürüyor, PagedResult değil
                var response = await _apiService.GetAsync<List<ProductCategoryDto>>("ProductCategory");
                if (response != null && response.Success && response.Data != null)
                {
                    _categories = response.Data;
                    PopulateCategoriesCombo();
                    System.Diagnostics.Debug.WriteLine($"Loaded {_categories.Count} categories");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Failed to load categories: {response?.Message}");
                    // Fallback - boş kategoriler listesi ile devam et
                    _categories = new List<ProductCategoryDto>();
                    PopulateCategoriesCombo();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Category loading exception: {ex.Message}");
                MessageBox.Show($"Kategoriler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _categories = new List<ProductCategoryDto>();
                PopulateCategoriesCombo();
            }
        }

        private void PopulateCategoriesCombo()
        {
            cmbKategori.Items.Clear();
            cmbKategori.Items.Add(new { Text = "Tüm Kategoriler", Value = -1 });
            
            var activeCategories = _categories.Where(c => c.IsActive).ToList();
            System.Diagnostics.Debug.WriteLine($"Active categories: {activeCategories.Count} out of {_categories.Count}");
            
            foreach (var category in activeCategories)
            {
                cmbKategori.Items.Add(new { Text = category.CategoryName, Value = category.CategoryID });
                System.Diagnostics.Debug.WriteLine($"Added category: {category.CategoryName} (ID: {category.CategoryID})");
            }
            
            cmbKategori.DisplayMember = "Text";
            cmbKategori.ValueMember = "Value";
            cmbKategori.SelectedIndex = 0;
            
            System.Diagnostics.Debug.WriteLine($"ComboBox populated with {cmbKategori.Items.Count} items");
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                // Build query parameters
                var queryParams = new List<string>();
                
                // Add search filter - API'de searchTerm parametresi kullanılıyor
                if (!string.IsNullOrWhiteSpace(txtArama.Text))
                {
                    queryParams.Add($"searchTerm={Uri.EscapeDataString(txtArama.Text)}");
                }
                
                // Add category filter
                if (cmbKategori.SelectedItem != null)
                {
                    var selectedCategory = (dynamic)cmbKategori.SelectedItem;
                    if (selectedCategory.Value != -1)
                    {
                        queryParams.Add($"categoryId={selectedCategory.Value}");
                    }
                }
                
                // Add page size
                var pageSize = int.Parse(cmbSayfaBoyutu.Text);
                queryParams.Add($"pageSize={pageSize}");
                queryParams.Add("pageNumber=1");
                
                var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
                
                System.Diagnostics.Debug.WriteLine($"API çağrısı: products{queryString}");
                
                var response = await _apiService.GetAsync<PagedResult<ProductDto>>($"products{queryString}");
                if (response != null && response.Success && response.Data?.Data != null)
                {
                    _allProducts = response.Data.Data;
                    _totalCount = response.Data.TotalCount;
                    
                    System.Diagnostics.Debug.WriteLine($"Yüklenen ürün sayısı: {_allProducts.Count}/{_totalCount}");
                    
                    dataGridViewUrunler.DataSource = _allProducts;
                    UpdateStatistics();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Ürün yükleme hatası: {response?.Message}");
                    MessageBox.Show("Ürünler yüklenirken hata oluştu: " + (response?.Message ?? "Bilinmeyen hata"), "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoadProductsAsync Exception: {ex.Message}");
                MessageBox.Show($"Ürünler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            _activeCount = _allProducts.Count(p => p.IsActive);
            _inactiveCount = _allProducts.Count(p => !p.IsActive);
            
            lblToplam.Text = $"Toplam: {_totalCount}";
            lblAktif.Text = $"Aktif: {_activeCount}";
            lblPasif.Text = $"Pasif: {_inactiveCount}";
        }

        private async void btnAra_Click(object sender, EventArgs e)
        {
            await LoadProductsAsync();
        }

        private async void btnTemizle_Click(object sender, EventArgs e)
        {
            txtArama.Clear();
            cmbKategori.SelectedIndex = 0;
            cmbSayfaBoyutu.SelectedIndex = 0;
            await LoadProductsAsync();
        }

        private async void btnYeniUrun_Click(object sender, EventArgs e)
        {
            if (!HasPermission("Create"))
            {
                MessageBox.Show("Yeni ürün ekleme yetkiniz bulunmamaktadır.", "Erişim Engellendi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var addForm = new UrunEkleForm(_currentUser, _apiService);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await LoadProductsAsync();
            }
        }

        private async void txtArama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                await LoadProductsAsync();
                e.Handled = true;
            }
        }

        private async void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKategori.SelectedIndex >= 0)
            {
                await LoadProductsAsync();
            }
        }

        private async void cmbSayfaBoyutu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSayfaBoyutu.SelectedIndex >= 0)
            {
                await LoadProductsAsync();
            }
        }
    }
}


