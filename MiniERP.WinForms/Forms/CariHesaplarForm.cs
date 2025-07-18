using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System.ComponentModel;

namespace MiniERP.WinForms.Forms
{
    public partial class CariHesaplarForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private readonly string _userRole;
        private List<CariAccountDto> _allCariAccounts = new();
        private List<CariTypeDto> _cariTypes = new();
        private int _totalCount = 0;
        private int _customerCount = 0;
        private int _supplierCount = 0;
        private int _activeCount = 0;

        // Access control for role-based permissions
        private readonly Dictionary<string, List<string>> _rolePermissions = new()
        {
            ["Admin"] = new() { "Create", "Read", "Update", "Delete" },
            ["Manager"] = new() { "Create", "Read", "Update", "Delete" },
            ["Sales"] = new() { "Create", "Read", "Update", "Delete" },
            ["Purchase"] = new() { "Create", "Read", "Update", "Delete" },
            ["Finance"] = new() { "Read" }, // Finance can only read
            ["Warehouse"] = new() { } // Warehouse has no access
        };

        public CariHesaplarForm(UserDto currentUser, ApiService apiService)
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
            // Warehouse users should not access this form at all
            if (_userRole == "Warehouse")
            {
                MessageBox.Show("Bu modüle erişim yetkiniz bulunmamaktadır.", "Erişim Engellendi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Finance users only get read access
            bool canCreate = HasPermission("Create");
            bool canUpdate = HasPermission("Update");
            bool canDelete = HasPermission("Delete");

            // Control button visibility based on permissions
            btnYeniCari.Visible = canCreate;
            
            // Set button colors based on permissions
            if (!canCreate)
            {
                btnYeniCari.BackColor = Color.FromArgb(156, 163, 175);
                btnYeniCari.Enabled = false;
            }

            // Update title based on user role
            if (_userRole == "Finance")
            {
                lblTitle.Text = "👥 CARİ HESAPLAR (Sadece Görüntüleme)";
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewCari.Columns.Clear();
            dataGridViewCari.AutoGenerateColumns = false;

            // Add columns
            dataGridViewCari.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CariCode",
                HeaderText = "Cari Kodu",
                Name = "CariCode",
                Width = 100
            });

            dataGridViewCari.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CariName",
                HeaderText = "Cari Adı",
                Name = "CariName",
                Width = 200
            });

            dataGridViewCari.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Telefon",
                Name = "Phone",
                Width = 120
            });

            dataGridViewCari.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "E-mail",
                Name = "Email",
                Width = 150
            });

            dataGridViewCari.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TypeName",
                HeaderText = "Tip",
                Name = "TypeName",
                Width = 100
            });

            dataGridViewCari.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CurrentBalance",
                HeaderText = "Bakiye",
                Name = "CurrentBalance",
                Width = 120
            });

            dataGridViewCari.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IsActive",
                HeaderText = "Durum",
                Name = "IsActive",
                Width = 80
            });

            // Action buttons column
            var actionsColumn = new DataGridViewButtonColumn
            {
                HeaderText = "İşlemler",
                Name = "Actions",
                Text = "İşlemler",
                UseColumnTextForButtonValue = true,
                Width = 150
            };
            dataGridViewCari.Columns.Add(actionsColumn);

            // Handle cell click for action buttons
            dataGridViewCari.CellClick += DataGridViewCari_CellClick;
        }

        private async void CariHesaplarForm_Load(object sender, EventArgs e)
        {
            await LoadCariTypesAsync();
            await LoadDashboardDataAsync();
            await LoadCariAccountsAsync();
        }

        private async Task LoadCariTypesAsync()
        {
            try
            {
                // Use the same endpoint as web application
                var response = await _apiService.GetAsync<PagedResult<CariTypeDto>>("CariAccounts/types?pageSize=100");
                if (response != null && response.Success && response.Data?.Data != null)
                {
                    _cariTypes = response.Data.Data;
                    
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => PopulateCariTypesCombo()));
                    }
                    else
                    {
                        PopulateCariTypesCombo();
                    }
                }
                else
                {
                    _cariTypes = new List<CariTypeDto>();
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => PopulateCariTypesCombo()));
                    }
                    else
                    {
                        PopulateCariTypesCombo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari tipleri yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _cariTypes = new List<CariTypeDto>();
                if (InvokeRequired)
                {
                    Invoke(new Action(() => PopulateCariTypesCombo()));
                }
                else
                {
                    PopulateCariTypesCombo();
                }
            }
        }

        private void PopulateCariTypesCombo()
        {
            cmbCariTipi.Items.Clear();
            cmbCariTipi.Items.Add(new ComboBoxItem { Text = "Tüm Tipler", Value = null });
            
            foreach (var type in _cariTypes)
            {
                cmbCariTipi.Items.Add(new ComboBoxItem { Text = type.TypeName, Value = type.TypeID });
            }
            cmbCariTipi.SelectedIndex = 0;
        }

        private async Task LoadDashboardDataAsync()
        {
            try
            {
                // Get all cari accounts with large page size to get all records
                var response = await _apiService.GetAsync<PagedResult<CariAccountDto>>("CariAccounts?pageSize=10000");
                
                // Debug: Check response
                Console.WriteLine($"Dashboard API Response - Success: {response?.Success}, Data: {response?.Data?.Data?.Count ?? 0} items");
                
                if (response != null && response.Success && response.Data?.Data != null)
                {
                    var allCari = response.Data.Data;
                    
                    _totalCount = allCari.Count;
                    
                    // Count by type names (more reliable than contains check)
                    _customerCount = allCari.Count(c => c.IsCustomer || 
                        (c.TypeName != null && (c.TypeName.ToLower().Contains("müşteri") || c.TypeName.ToLower().Contains("customer"))));
                    _supplierCount = allCari.Count(c => c.IsSupplier || 
                        (c.TypeName != null && (c.TypeName.ToLower().Contains("tedarikçi") || c.TypeName.ToLower().Contains("supplier"))));
                    _activeCount = allCari.Count(c => c.IsActive);

                    // Debug: Log counts
                    Console.WriteLine($"Dashboard Counts - Total: {_totalCount}, Customer: {_customerCount}, Supplier: {_supplierCount}, Active: {_activeCount}");

                    // Update dashboard cards on UI thread
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            lblToplamCariSayi.Text = _totalCount.ToString();
                            lblMusteriSayi.Text = _customerCount.ToString();
                            lblTedarikciSayi.Text = _supplierCount.ToString();
                            lblAktifCariSayi.Text = _activeCount.ToString();
                        }));
                    }
                    else
                    {
                        lblToplamCariSayi.Text = _totalCount.ToString();
                        lblMusteriSayi.Text = _customerCount.ToString();
                        lblTedarikciSayi.Text = _supplierCount.ToString();
                        lblAktifCariSayi.Text = _activeCount.ToString();
                    }
                }
                else
                {
                    Console.WriteLine($"Dashboard API Error - Success: {response?.Success}, Message: {response?.Message}");
                    // Set default values if no data or API error
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => SetDefaultDashboardValues()));
                    }
                    else
                    {
                        SetDefaultDashboardValues();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Dashboard Exception: {ex.Message}");
                MessageBox.Show($"Dashboard verileri yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Set default values on error
                if (InvokeRequired)
                {
                    Invoke(new Action(() => SetDefaultDashboardValues()));
                }
                else
                {
                    SetDefaultDashboardValues();
                }
            }
        }

        private void SetDefaultDashboardValues()
        {
            lblToplamCariSayi.Text = "0";
            lblMusteriSayi.Text = "0";
            lblTedarikciSayi.Text = "0";
            lblAktifCariSayi.Text = "0";
        }

        private async Task LoadCariAccountsAsync(string searchTerm = "", int? typeId = null)
        {
            try
            {
                string url = "CariAccounts?pageSize=1000";
                
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    url += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";
                }
                
                if (typeId.HasValue)
                {
                    url += $"&typeId={typeId.Value}";
                }

                var response = await _apiService.GetAsync<PagedResult<CariAccountDto>>(url);
                if (response.Success && response.Data?.Data != null)
                {
                    _allCariAccounts = response.Data.Data;
                    
                    // DataSource'u güvenli bir şekilde güncelle
                    UpdateDataGridSafely(_allCariAccounts);
                }
                else
                {
                    _allCariAccounts.Clear();
                    UpdateDataGridSafely(new List<CariAccountDto>());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari hesaplar yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataGridSafely(List<CariAccountDto> data)
        {
            try
            {
                // Event handler'ları geçici olarak kaldır
                dataGridViewCari.CellClick -= DataGridViewCari_CellClick;
                
                // Selection'ı temizle
                dataGridViewCari.ClearSelection();
                
                // DataSource'u güvenli güncelle
                dataGridViewCari.DataSource = null;
                
                if (data?.Count > 0)
                {
                    dataGridViewCari.DataSource = data;
                }
                
                // Grid'i yenile
                dataGridViewCari.Refresh();
                dataGridViewCari.Update();
                
                // Event handler'ları geri ekle
                dataGridViewCari.CellClick += DataGridViewCari_CellClick;
            }
            catch (Exception ex)
            {
                // Grid güncelleme hatası durumunda log yaz ama UI'ı bozmayı
                System.Diagnostics.Debug.WriteLine($"Grid update error: {ex.Message}");
            }
        }

        private async void BtnAra_Click(object sender, EventArgs e)
        {
            var selectedType = cmbCariTipi.SelectedItem as ComboBoxItem;
            int? typeId = selectedType?.Value as int?;
            
            await LoadCariAccountsAsync(txtArama.Text.Trim(), typeId);
        }

        private async void BtnTemizle_Click(object sender, EventArgs e)
        {
            txtArama.Clear();
            cmbCariTipi.SelectedIndex = 0;
            await LoadCariAccountsAsync();
        }

        private void TxtArama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                BtnAra_Click(sender, e);
            }
        }

        private async void BtnMusteriler_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await _apiService.GetAsync<List<CariAccountDto>>("CariAccounts/customers");
                if (response.Success && response.Data != null)
                {
                    _allCariAccounts = response.Data;
                    dataGridViewCari.DataSource = _allCariAccounts;
                    lblTitle.Text = "👥 MÜŞTERİLER";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müşteriler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnTedarikcilar_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await _apiService.GetAsync<List<CariAccountDto>>("CariAccounts/suppliers");
                if (response.Success && response.Data != null)
                {
                    _allCariAccounts = response.Data;
                    dataGridViewCari.DataSource = _allCariAccounts;
                    lblTitle.Text = "🛍️ TEDARİKÇİLER";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tedarikçiler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnYeniCari_Click(object sender, EventArgs e)
        {
            if (!HasPermission("Create"))
            {
                MessageBox.Show("Yeni cari oluşturma yetkiniz bulunmamaktadır.", "Erişim Engellendi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cariEkleForm = new CariEkleForm(_currentUser, _apiService);
                var result = cariEkleForm.ShowDialog();
                
                if (result == DialogResult.OK && cariEkleForm.IsDataSaved)
                {
                    // Refresh data after successful save
                    await LoadCariAccountsAsync();
                    await LoadDashboardDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari ekleme formu açılırken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewCari_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.RowIndex >= _allCariAccounts.Count) return;

            if (dataGridViewCari.Columns[e.ColumnIndex].Name == "Actions")
            {
                var selectedCari = _allCariAccounts[e.RowIndex];
                ShowActionMenu(selectedCari);
            }
        }

        private void ShowActionMenu(CariAccountDto cari)
        {
            var contextMenu = new ContextMenuStrip();

            // Always available actions
            contextMenu.Items.Add("📄 Detayları Görüntüle", null, (s, e) => ShowCariDetails(cari));
            contextMenu.Items.Add("📊 Hareketler", null, (s, e) => ShowCariTransactions(cari));
            contextMenu.Items.Add("📋 Cari Ekstresi", null, (s, e) => ShowCariEkstresi(cari));

            // Permission-based actions
            if (HasPermission("Update"))
            {
                contextMenu.Items.Add(new ToolStripSeparator());
                contextMenu.Items.Add("✏️ Düzenle", null, (s, e) => EditCari(cari));
            }

            if (HasPermission("Delete"))
            {
                contextMenu.Items.Add("🗑️ Sil", null, (s, e) => DeleteCari(cari));
            }

            // Additional finance-specific actions
            if (_userRole == "Finance" || _userRole == "Admin" || _userRole == "Manager")
            {
                contextMenu.Items.Add(new ToolStripSeparator());
                contextMenu.Items.Add("💰 Bakiye Detayı", null, (s, e) => ShowBalanceDetails(cari));
            }

            contextMenu.Show(dataGridViewCari, dataGridViewCari.PointToClient(Cursor.Position));
        }

        private void ShowCariDetails(CariAccountDto cari)
        {
            try
            {
                var detayForm = new CariDetayForm(cari, _userRole);
                detayForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari detay formu açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowCariTransactions(CariAccountDto cari)
        {
            try
            {
                var hareketlerForm = new CariHareketleriForm(cari, _userRole);
                hareketlerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari hareketleri formu açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowCariEkstresi(CariAccountDto cari)
        {
            try
            {
                var ekstreForm = new CariEkstreForm(cari, _userRole);
                ekstreForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari ekstresi formu açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void EditCari(CariAccountDto cari)
        {
            if (!HasPermission("Update"))
            {
                MessageBox.Show("Cari düzenleme yetkiniz bulunmamaktadır.", "Erişim Engellendi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var duzenleForm = new CariDuzenleForm(cari, _userRole);
                var result = duzenleForm.ShowDialog();
                
                if (result == DialogResult.OK && duzenleForm.IsUpdated)
                {
                    // Grid'i yenile
                    await LoadCariAccountsAsync();
                    MessageBox.Show("Cari bilgileri başarıyla güncellendi!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Düzenleme formu açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DeleteCari(CariAccountDto cari)
        {
            if (!HasPermission("Delete"))
            {
                MessageBox.Show("Cari silme yetkiniz bulunmamaktadır.", "Erişim Engellendi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Silme öncesi grid'i güvenli hale getir
                dataGridViewCari.ClearSelection();
                
                // CariSilForm'u aç
                var silForm = new CariSilForm(cari, _userRole);
                var result = silForm.ShowDialog();
                
                if (result == DialogResult.OK && silForm.IsDeleted)
                {
                    try
                    {
                        // Grid'i ve dashboard'u yenile
                        await LoadCariAccountsAsync();
                        await LoadDashboardDataAsync();
                        
                        MessageBox.Show("Cari hesap başarıyla silindi.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception refreshEx)
                    {
                        // Silme başarılı ama yenileme hatası
                        MessageBox.Show($"Silme başarılı ancak liste güncellenirken hata oluştu: {refreshEx.Message}\n\nLütfen sayfayı yenileyiniz.", 
                            "Yenileme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme formu açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowBalanceDetails(CariAccountDto cari)
        {
            string balanceInfo = $"Bakiye Detayları\n\n" +
                               $"Cari: {cari.CariName}\n" +
                               $"Güncel Bakiye: {cari.CurrentBalance:C}\n" +
                               $"Kredi Limiti: {cari.CreditLimit:C}\n" +
                               $"Kullanılabilir Limit: {(cari.CreditLimit - Math.Max(0, cari.CurrentBalance)):C}\n" +
                               $"Bakiye Durumu: {cari.BalanceType}";

            MessageBox.Show(balanceInfo, "Bakiye Detayları", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DataGridViewCari_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _allCariAccounts.Count) return;

            var cari = _allCariAccounts[e.RowIndex];

            // Format balance column
            if (dataGridViewCari.Columns[e.ColumnIndex].Name == "CurrentBalance")
            {
                if (e.Value is decimal balance)
                {
                    e.Value = balance.ToString("C");
                    e.FormattingApplied = true;

                    // Color code based on balance
                    if (balance > 0)
                        e.CellStyle!.ForeColor = Color.Green;
                    else if (balance < 0)
                        e.CellStyle!.ForeColor = Color.Red;
                }
            }

            // Format status column
            if (dataGridViewCari.Columns[e.ColumnIndex].Name == "IsActive")
            {
                if (e.Value is bool isActive)
                {
                    e.Value = isActive ? "Aktif" : "Pasif";
                    e.CellStyle!.ForeColor = isActive ? Color.Green : Color.Red;
                    e.FormattingApplied = true;
                }
            }

            // Highlight inactive rows
            if (!cari.IsActive)
            {
                e.CellStyle!.BackColor = Color.FromArgb(248, 248, 248);
                e.CellStyle!.ForeColor = Color.FromArgb(128, 128, 128);
            }
        }

        public class ComboBoxItem
        {
            public string Text { get; set; } = string.Empty;
            public object? Value { get; set; }

            public override string ToString() => Text;
        }
    }
}


