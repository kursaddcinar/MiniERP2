using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System.ComponentModel;

namespace MiniERP.WinForms.Forms
{
    public partial class SatisFaturalariForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private readonly string _userRole;
        private List<SalesInvoiceDto> _allInvoices = new();
        private InvoiceSummaryDto _summary = new();

        // Role-based permissions aligned with web project
        private readonly Dictionary<string, List<string>> _rolePermissions = new()
        {
            ["Admin"] = new() { "Create", "Read", "Update", "Delete" },
            ["Manager"] = new() { "Create", "Read", "Update", "Delete" },
            ["Sales"] = new() { "Create", "Read", "Update", "Delete" },
            ["Purchase"] = new() { }, // No access
            ["Finance"] = new() { "Read" }, // Read only
            ["Warehouse"] = new() { } // No access
        };

        public SatisFaturalariForm(UserDto currentUser, ApiService apiService)
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
            // Purchase and Warehouse users should not access this form at all
            if (_userRole == "Purchase" || _userRole == "Warehouse")
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
                lblTitle.Text = "📄 SATIŞ FATURALARI (Sadece Görüntüleme)";
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
                HeaderText = "Cari",
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
                    Format = "C2",
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

        private async void SatisFaturalariForm_Load(object sender, EventArgs e)
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
                var response = await _apiService.GetAsync<InvoiceSummaryDto>("SalesInvoices/summary");
                if (response?.Success == true && response.Data != null)
                {
                    _summary = response.Data;
                    UpdateSummaryCards();
                }
                else
                {
                    // Set default values if API call fails
                    _summary = new InvoiceSummaryDto();
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
            lblToplamTutar.Text = _summary.TotalAmount.ToString("C2");
            lblTaslakFatura.Text = _summary.DraftInvoices.ToString();
            lblOnaylaFatura.Text = _summary.ApprovedInvoices.ToString();
        }

        private async Task LoadInvoicesAsync()
        {
            try
            {
                btnAra.Enabled = false;
                btnAra.Text = "Yükleniyor...";

                var response = await _apiService.GetAsync<PagedResult<SalesInvoiceDto>>("SalesInvoices?pageNumber=1&pageSize=1000");

                if (response?.Success == true && response.Data != null)
                {
                    _allInvoices = response.Data.Data;
                    
                    // Debug - ilk faturayı kontrol et
                    if (_allInvoices.Count > 0)
                    {
                        var firstInvoice = _allInvoices[0];
                        System.Diagnostics.Debug.WriteLine($"First Invoice: {firstInvoice.InvoiceNo}");
                        System.Diagnostics.Debug.WriteLine($"Customer: CariName='{firstInvoice.CariName}', CustomerName='{firstInvoice.CustomerName}'");
                        System.Diagnostics.Debug.WriteLine($"Codes: CariCode='{firstInvoice.CariCode}', CustomerCode='{firstInvoice.CustomerCode}'");
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

            // Filter by search term (Invoice No or Cari Name)
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
                if (row.DataBoundItem is SalesInvoiceDto invoice)
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

        private void btnYeniFatura_Click(object sender, EventArgs e)
        {
            if (!HasPermission("Create"))
            {
                MessageBox.Show("Yeni fatura oluşturma yetkiniz bulunmamaktadır.", "Yetki Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var yeniFaturaForm = new SatisFaturasiEkleForm(_currentUser, _apiService);
            var result = yeniFaturaForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Refresh the invoice list
                _ = LoadInvoicesAsync();
                _ = LoadInvoiceSummaryAsync();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtArama.Clear();
            cmbDurum.SelectedIndex = 0; // "Tümü"
            dtpBaslangic.Checked = false;
            dtpBitis.Checked = false;
            ApplyFilters();
        }

        private void dataGridViewFaturalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewFaturalar.Columns.Count - 1) // Actions column
            {
                var invoice = (SalesInvoiceDto)dataGridViewFaturalar.Rows[e.RowIndex].DataBoundItem;
                ShowInvoiceActions(invoice);
            }
        }

        private void ShowInvoiceActions(SalesInvoiceDto invoice)
        {
            var contextMenu = new ContextMenuStrip();

            // Detay görüntüleme - herkese açık
            contextMenu.Items.Add("Detay Görüntüle", null, (s, e) => ShowInvoiceDetails(invoice));

            // Düzenleme - sadece yetkili rollere ve taslak faturalar için
            if (HasPermission("Update") && invoice.Status.ToUpper() == "DRAFT")
            {
                contextMenu.Items.Add("Düzenle", null, (s, e) => EditInvoice(invoice));
            }

            // Onaylama - sadece yetkili rollere ve taslak faturalar için
            if (HasPermission("Update") && invoice.Status.ToUpper() == "DRAFT")
            {
                contextMenu.Items.Add("Onayla", null, (s, e) => ApproveInvoice(invoice));
            }

            // Silme - sadece yetkili rollere
            if (HasPermission("Delete"))
            {
                contextMenu.Items.Add("Sil", null, (s, e) => DeleteInvoice(invoice));
            }

            contextMenu.Show(Cursor.Position);
        }

        private async void ShowInvoiceDetails(SalesInvoiceDto invoice)
        {
            try
            {
                // Önce tam fatura bilgisini API'den çek (detaylarıyla birlikte)
                var response = await _apiService.GetAsync<SalesInvoiceDto>($"SalesInvoices/{invoice.InvoiceID}");
                if (response?.Success == true && response.Data != null)
                {
                    var fullInvoice = response.Data;
                    var detayForm = new SatisFaturaDetayForm(_apiService, _currentUser, fullInvoice);
                    detayForm.ShowDialog();
                    
                    // Form kapandıktan sonra listeyi yenile
                    _ = LoadInvoicesAsync();
                    _ = LoadInvoiceSummaryAsync();
                }
                else
                {
                    // API'den çekemediyse mevcut invoice ile aç
                    var detayForm = new SatisFaturaDetayForm(_apiService, _currentUser, invoice);
                    detayForm.ShowDialog();
                    
                    // Form kapandıktan sonra listeyi yenile
                    _ = LoadInvoicesAsync();
                    _ = LoadInvoiceSummaryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura detayları açılırken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditInvoice(SalesInvoiceDto invoice)
        {
            if (!HasPermission("Update"))
            {
                MessageBox.Show("Fatura düzenleme yetkiniz bulunmamaktadır.", "Yetki Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var editForm = new SatisFaturasiEkleForm(_apiService, _currentUser, invoice);
                editForm.Text = $"Satış Faturası Düzenle - {invoice.InvoiceNo}";
                
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadInvoicesAsync(); // Liste güncellensin
                    _ = LoadInvoiceSummaryAsync(); // Özet kartlar güncellensin
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura düzenleme formu açılırken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ApproveInvoice(SalesInvoiceDto invoice)
        {
            if (!HasPermission("Update"))
            {
                MessageBox.Show("Fatura onaylama yetkiniz bulunmamaktadır.", "Yetki Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Fatura {invoice.InvoiceNo} onaylanacak. Emin misiniz?", 
                "Fatura Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var approvalDto = new InvoiceApprovalDto { ApprovalNote = "Windows Forms'dan onaylandı" };
                    var response = await _apiService.PostAsync<bool>($"SalesInvoices/{invoice.InvoiceID}/approve", approvalDto);

                    if (response?.Success == true)
                    {
                        MessageBox.Show("Fatura başarıyla onaylandı.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadInvoicesAsync();
                        await LoadInvoiceSummaryAsync();
                    }
                    else
                    {
                        MessageBox.Show(response?.Message ?? "Fatura onaylanırken hata oluştu.", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fatura onaylanırken hata oluştu: {ex.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void DeleteInvoice(SalesInvoiceDto invoice)
        {
            if (!HasPermission("Delete"))
            {
                MessageBox.Show("Fatura silme yetkiniz bulunmamaktadır.", "Yetki Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yeni silme formunu aç
            var deleteForm = new SatisFaturasiSilForm(_currentUser, _apiService, invoice);
            
            if (deleteForm.ShowDialog() == DialogResult.OK)
            {
                // Fatura başarıyla silindi, listeyi yenile
                await LoadInvoicesAsync();
                await LoadInvoiceSummaryAsync();
            }
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            // Auto-filter after 500ms delay
            if (_searchTimer != null)
            {
                _searchTimer.Stop();
                _searchTimer.Dispose();
            }

            _searchTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _searchTimer.Tick += (s, args) =>
            {
                _searchTimer.Stop();
                ApplyFilters();
            };
            _searchTimer.Start();
        }

        private System.Windows.Forms.Timer? _searchTimer;

        private void cmbDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpBaslangic_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpBitis_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _searchTimer?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
