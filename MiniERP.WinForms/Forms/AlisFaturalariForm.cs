using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System.ComponentModel;

namespace MiniERP.WinForms.Forms
{
    public partial class AlisFaturalariForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private readonly string _userRole;
        private List<PurchaseInvoiceDto> _allInvoices = new();
        private PurchaseInvoiceSummaryDto _summary = new();

        // Role-based permissions aligned with purchase invoice requirements
        private readonly Dictionary<string, List<string>> _rolePermissions = new()
        {
            ["Admin"] = new() { "Create", "Read", "Update", "Delete" },
            ["Manager"] = new() { "Create", "Read", "Update", "Delete" },
            ["Sales"] = new() { }, // No access
            ["Purchase"] = new() { "Create", "Read", "Update", "Delete" },
            ["Finance"] = new() { "Read" }, // Read only
            ["Warehouse"] = new() { } // No access
        };

        public AlisFaturalariForm(UserDto currentUser, ApiService apiService)
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
            // Sales and Warehouse users should not access this form at all
            if (_userRole == "Sales" || _userRole == "Warehouse")
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
            btnYeniFatura.Visible = canCreate;
            btnYeniFatura.Enabled = canCreate;
            
            // Set button colors based on permissions
            if (!canCreate)
            {
                btnYeniFatura.BackColor = Color.FromArgb(156, 163, 175);
            }

            // Update title based on user role
            if (_userRole == "Finance")
            {
                lblTitle.Text = "📝 ALIŞ FATURALARI (Sadece Görüntüleme)";
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewFaturalar.Columns.Clear();
            dataGridViewFaturalar.AutoGenerateColumns = false;

            // Add columns
            dataGridViewFaturalar.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InvoiceNo",
                HeaderText = "Fatura No",
                Width = 120,
                ReadOnly = true
            });

            dataGridViewFaturalar.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CariName",
                HeaderText = "Tedarikçi",
                Width = 200,
                ReadOnly = true
            });

            dataGridViewFaturalar.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InvoiceDate",
                HeaderText = "Tarih",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }
            });

            dataGridViewFaturalar.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Toplam Tutar",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dataGridViewFaturalar.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Durum",
                Width = 100,
                ReadOnly = true
            });

            // Actions column
            var actionsColumn = new DataGridViewButtonColumn
            {
                HeaderText = "İşlemler",
                Text = "Detay",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dataGridViewFaturalar.Columns.Add(actionsColumn);

            // Set grid appearance
            dataGridViewFaturalar.EnableHeadersVisualStyles = false;
            dataGridViewFaturalar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewFaturalar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewFaturalar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewFaturalar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 248, 249);
            dataGridViewFaturalar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFaturalar.MultiSelect = false;
            dataGridViewFaturalar.ReadOnly = false;
            dataGridViewFaturalar.AllowUserToAddRows = false;
            dataGridViewFaturalar.AllowUserToDeleteRows = false;
            dataGridViewFaturalar.RowHeadersVisible = false;
        }

        private async void AlisFaturalariForm_Load(object sender, EventArgs e)
        {
            // Set default values
            cmbDurum.SelectedIndex = 0; // "Tümü"
            
            await LoadInvoiceSummaryAsync();
            await LoadInvoicesAsync();
        }

        private async Task LoadInvoiceSummaryAsync()
        {
            try
            {
                var response = await _apiService.GetAsync<PurchaseInvoiceSummaryDto>("PurchaseInvoices/summary");
                if (response?.Success == true && response.Data != null)
                {
                    _summary = response.Data;
                    UpdateSummaryCards();
                }
                else
                {
                    // Set default values if API call fails
                    _summary = new PurchaseInvoiceSummaryDto();
                    UpdateSummaryCards();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Özet veriler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateSummaryCards()
        {
            // Update summary cards
            lblToplamFatura.Text = _summary.TotalInvoices.ToString();
            lblToplamTutar.Text = _summary.TotalAmount.ToString("N2") + " ?";
            lblTaslakFatura.Text = _summary.DraftInvoices.ToString();
            lblOnaylaFatura.Text = _summary.ApprovedInvoices.ToString();
        }

        private async Task LoadInvoicesAsync()
        {
            try
            {
                btnAra.Enabled = false;
                btnAra.Text = "Yükleniyor...";

                var response = await _apiService.GetAsync<PagedResult<PurchaseInvoiceDto>>("PurchaseInvoices?pageNumber=1&pageSize=1000");

                if (response?.Success == true && response.Data != null)
                {
                    _allInvoices = response.Data.Data;
                    
                    // Debug - ilk faturayı kontrol et
                    if (_allInvoices.Count > 0)
                    {
                        var firstInvoice = _allInvoices[0];
                        System.Diagnostics.Debug.WriteLine($"First Invoice: {firstInvoice.InvoiceNo}");
                        System.Diagnostics.Debug.WriteLine($"Supplier: CariName='{firstInvoice.CariName}', SupplierName='{firstInvoice.SupplierName}'");
                        System.Diagnostics.Debug.WriteLine($"Codes: CariCode='{firstInvoice.CariCode}', SupplierCode='{firstInvoice.SupplierCode}'");
                        System.Diagnostics.Debug.WriteLine($"Warehouse: {firstInvoice.WarehouseName}");
                        System.Diagnostics.Debug.WriteLine($"Totals: SubTotal={firstInvoice.SubTotal}, VatAmount={firstInvoice.VatAmount}, Total={firstInvoice.Total}");
                    }
                    
                    ApplyFilters();
                }
                else
                {
                    MessageBox.Show(response?.Message ?? "Faturalar yüklenirken hata oluştu.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Faturalar yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAra.Enabled = true;
                btnAra.Text = "🔍 Ara";
            }
        }

        private void ApplyFilters()
        {
            var filteredInvoices = _allInvoices.AsEnumerable();

            // Filter by search term (Invoice No or Supplier Name)
            string searchTerm = txtArama.Text.Trim();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                filteredInvoices = filteredInvoices.Where(i => 
                    i.InvoiceNo.ToLower().Contains(searchTerm.ToLower()) ||
                    i.CariName.ToLower().Contains(searchTerm.ToLower()));
            }

            // Filter by status
            if (cmbDurum.SelectedItem != null && cmbDurum.SelectedItem.ToString() != "Tümü")
            {
                string selectedStatus = cmbDurum.SelectedItem.ToString() ?? "";
                if (!string.IsNullOrEmpty(selectedStatus))
                {
                    filteredInvoices = filteredInvoices.Where(i => i.Status == selectedStatus);
                }
            }

            // Filter by date range
            if (dtpBaslangic.Checked)
            {
                filteredInvoices = filteredInvoices.Where(i => i.InvoiceDate >= dtpBaslangic.Value.Date);
            }

            if (dtpBitis.Checked)
            {
                filteredInvoices = filteredInvoices.Where(i => i.InvoiceDate <= dtpBitis.Value.Date);
            }

            dataGridViewFaturalar.DataSource = filteredInvoices.ToList();
            
            // Update status colors
            UpdateRowColors();
        }

        private void UpdateRowColors()
        {
            foreach (DataGridViewRow row in dataGridViewFaturalar.Rows)
            {
                if (row.DataBoundItem is PurchaseInvoiceDto invoice)
                {
                    switch (invoice.Status.ToUpper())
                    {
                        case "DRAFT":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 225); // Light yellow
                            break;
                        case "APPROVED":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(220, 252, 231); // Light green
                            break;
                        case "CANCELLED":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226); // Light red
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White;
                            break;
                    }
                }
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            // Clear all filters
            txtArama.Clear();
            cmbDurum.SelectedIndex = 0; // "Tümü"
            dtpBaslangic.Checked = false;
            dtpBitis.Checked = false;
            
            ApplyFilters();
        }

        private async void btnYeniFatura_Click(object sender, EventArgs e)
        {
            if (!HasPermission("Create"))
            {
                MessageBox.Show("Yeni fatura oluşturma yetkiniz bulunmamaktadır.", "Erişim Engellendi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var yeniFaturaForm = new AlisFaturasiEkleForm(_currentUser, _apiService);
            yeniFaturaForm.InvoiceCreated += async (s, e) => await LoadInvoicesAsync();
            if (yeniFaturaForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh the invoice list after successful save
                await LoadInvoicesAsync();
                await LoadInvoiceSummaryAsync();
            }
        }

        private void dataGridViewFaturalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Check if clicked on actions column
            if (e.ColumnIndex == dataGridViewFaturalar.Columns.Count - 1)
            {
                var invoice = dataGridViewFaturalar.Rows[e.RowIndex].DataBoundItem as PurchaseInvoiceDto;
                if (invoice != null)
                {
                    ShowInvoiceActions(invoice);
                }
            }
        }

        private void ShowInvoiceActions(PurchaseInvoiceDto invoice)
        {
            bool canUpdate = HasPermission("Update");
            bool canDelete = HasPermission("Delete");

            var actions = new List<string> { "Detayları Görüntüle" };
            
            if (canUpdate && invoice.Status != "Approved")
            {
                actions.Add("Düzenle");
            }
            
            if (canDelete && invoice.Status == "Draft")
            {
                actions.Add("Sil");
            }

            // Grid'den açılan context menu'ye ekstra sil seçeneği ekle
            // (Detayları Görüntüle'de de sil butonu olacak ama hızlı erişim için)
            if (canDelete && invoice.Status != "Cancelled" && !actions.Contains("Sil"))
            {
                actions.Add("Hızlı Sil");
            }

            // Create context menu
            var contextMenu = new ContextMenuStrip();
            
            foreach (var action in actions)
            {
                var menuItem = new ToolStripMenuItem(action);
                menuItem.Click += (s, e) => HandleInvoiceAction(action, invoice);
                contextMenu.Items.Add(menuItem);
            }

            contextMenu.Show(Cursor.Position);
        }

        private async void HandleInvoiceAction(string action, PurchaseInvoiceDto invoice)
        {
            switch (action)
            {
                case "Detayları Görüntüle":
                    try
                    {
                        var detayForm = new AlisFaturaDetayForm(_apiService, _currentUser, invoice);
                        detayForm.InvoiceDeleted += async (s, e) => await LoadInvoicesAsync();
                        detayForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Detay formu açılırken hata oluştu: {ex.Message}", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Düzenle":
                    try
                    {
                        var editForm = new AlisFaturaDuzenleForm(_currentUser, _apiService, invoice);
                        editForm.InvoiceUpdated += async (s, e) => await LoadInvoicesAsync();
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            await LoadInvoicesAsync(); // Listeyi yenile
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Düzenleme formu açılırken hata oluştu: {ex.Message}", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Sil":
                case "Hızlı Sil":
                    try
                    {
                        var silForm = new AlisFaturaSilForm(_currentUser, _apiService, invoice);
                        if (silForm.ShowDialog() == DialogResult.OK)
                        {
                            await LoadInvoicesAsync(); // Listeyi yenile
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Silme formu açılırken hata oluştu: {ex.Message}", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void dataGridViewFaturalar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Format status column
            if (dataGridViewFaturalar.Columns[e.ColumnIndex].DataPropertyName == "Status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString() ?? "";
                    switch (status.ToUpper())
                    {
                        case "DRAFT":
                            e.Value = "Taslak";
                            if (e.CellStyle != null)
                                e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
                            break;
                        case "APPROVED":
                            e.Value = "Onaylandı";
                            if (e.CellStyle != null)
                                e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74);
                            break;
                        case "CANCELLED":
                            e.Value = "İptal Edildi";
                            if (e.CellStyle != null)
                                e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                            break;
                    }
                }
            }
        }
    }
}


