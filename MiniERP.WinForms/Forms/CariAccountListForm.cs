using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class CariAccountListForm : Form
    {
        private readonly CariAccountService _cariAccountService;
        private List<CariAccountDto> _cariAccounts = new List<CariAccountDto>();
        private List<CariTypeDto> _cariTypes = new List<CariTypeDto>();
        private int _currentPage = 1;
        private int _pageSize = 50;
        private int _totalPages = 1;
        private string _currentSearchTerm = "";
        private int? _currentTypeFilter = null;

        public CariAccountListForm(CariAccountService cariAccountService)
        {
            InitializeComponent();
            _cariAccountService = cariAccountService;
            InitializeForm();
        }

        private async void InitializeForm()
        {
            await LoadCariTypes();
            SetupDataGridView();
            SetupFilters();
            await LoadCariAccounts();
            UpdateUI();
        }

        private async Task LoadCariTypes()
        {
            try
            {
                var response = await _cariAccountService.GetCariTypesAsync();
                if (response.Success && response.Data != null)
                {
                    _cariTypes = response.Data.Data;
                }
            }
            catch (Exception ex)
            {
                ShowError("Cari türleri yüklenemedi", ex.Message);
            }
        }

        private void SetupFilters()
        {
            cmbTypeFilter.Items.Clear();
            cmbTypeFilter.Items.Add(new { Text = "Tümü", Value = (int?)null });
            
            foreach (var type in _cariTypes)
            {
                cmbTypeFilter.Items.Add(new { Text = type.TypeName, Value = (int?)type.TypeID });
            }
            
            cmbTypeFilter.DisplayMember = "Text";
            cmbTypeFilter.ValueMember = "Value";
            cmbTypeFilter.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            dgvCariAccounts.AutoGenerateColumns = false;
            dgvCariAccounts.AllowUserToAddRows = false;
            dgvCariAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCariAccounts.MultiSelect = false;
            dgvCariAccounts.ReadOnly = true;

            // ID sütunu (gizli)
            dgvCariAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CariAccountID",
                HeaderText = "ID",
                DataPropertyName = "CariAccountID",
                Width = 50,
                Visible = false
            });

            dgvCariAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CariCode",
                HeaderText = "Cari Kodu",
                DataPropertyName = "CariCode",
                Width = 120
            });

            dgvCariAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CariName",
                HeaderText = "Cari Adı",
                DataPropertyName = "CariName",
                Width = 200
            });

            dgvCariAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TypeName",
                HeaderText = "Tip",
                DataPropertyName = "TypeName",
                Width = 100
            });

            dgvCariAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TaxNumber",
                HeaderText = "Vergi No",
                DataPropertyName = "TaxNumber",
                Width = 120
            });

            dgvCariAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Phone",
                HeaderText = "Telefon",
                DataPropertyName = "Phone",
                Width = 120
            });

            dgvCariAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "E-mail",
                DataPropertyName = "Email",
                Width = 150
            });

            dgvCariAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CurrentBalance",
                HeaderText = "Bakiye",
                DataPropertyName = "CurrentBalance",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvCariAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BalanceType",
                HeaderText = "Bakiye Tipi",
                DataPropertyName = "BalanceType",
                Width = 100
            });

            dgvCariAccounts.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Aktif",
                DataPropertyName = "IsActive",
                Width = 60
            });

            dgvCariAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedDate",
                HeaderText = "Oluşturma Tarihi",
                DataPropertyName = "CreatedDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }
            });
        }

        private async Task LoadCariAccounts()
        {
            try
            {
                btnRefresh.Enabled = false;
                btnRefresh.Text = "Yükleniyor...";
                
                var response = await _cariAccountService.GetCariAccountsAsync(_currentPage, _pageSize, _currentSearchTerm, _currentTypeFilter);
                
                if (response.Success && response.Data != null)
                {
                    _cariAccounts = response.Data.Data;
                    _totalPages = response.Data.TotalPages;
                    
                    dgvCariAccounts.DataSource = _cariAccounts;
                    
                    lblStatus.Text = $"Toplam {response.Data.TotalCount} kayıt. Sayfa {_currentPage}/{_totalPages}";
                }
                else
                {
                    ShowError("Cari hesaplar yüklenemedi", response.Message, response.Errors);
                }
            }
            catch (Exception ex)
            {
                ShowError("Veri yükleme hatası", ex.Message);
            }
            finally
            {
                btnRefresh.Enabled = true;
                btnRefresh.Text = "Yenile";
            }
        }

        private void UpdateUI()
        {
            bool hasSelection = dgvCariAccounts.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
            btnViewDetails.Enabled = hasSelection;
            btnTransactions.Enabled = hasSelection;
            btnStatement.Enabled = hasSelection;
            
            btnPreviousPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPages;
            
            lblPageInfo.Text = $"Sayfa {_currentPage} / {_totalPages}";
        }

        private void dgvCariAccounts_SelectionChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadCariAccounts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new CariAccountEditForm(_cariAccountService, _cariTypes);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                _ = LoadCariAccounts();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCariAccounts.SelectedRows.Count > 0)
            {
                var selectedAccount = (CariAccountDto)dgvCariAccounts.SelectedRows[0].DataBoundItem;
                
                // Debug: Check ID value
                Console.WriteLine($"DEBUG: Selected account ID = {selectedAccount.CariAccountID}, Name = {selectedAccount.CariName}");
                
                var editForm = new CariAccountEditForm(_cariAccountService, _cariTypes, selectedAccount);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadCariAccounts();
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCariAccounts.SelectedRows.Count > 0)
            {
                var selectedAccount = (CariAccountDto)dgvCariAccounts.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"'{selectedAccount.CariName}' cari hesabını silmek istediğinizden emin misiniz?", 
                    "Cari Hesap Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var deleteResponse = await _cariAccountService.DeleteCariAccountAsync(selectedAccount.CariAccountID);
                        if (deleteResponse.Success)
                        {
                            MessageBox.Show("Cari hesap başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadCariAccounts();
                        }
                        else
                        {
                            ShowError("Silme hatası", deleteResponse.Message, deleteResponse.Errors);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError("Silme hatası", ex.Message);
                    }
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvCariAccounts.SelectedRows.Count > 0)
            {
                var selectedAccount = (CariAccountDto)dgvCariAccounts.SelectedRows[0].DataBoundItem;
                var detailsForm = new CariAccountDetailsForm(_cariAccountService, selectedAccount);
                detailsForm.ShowDialog();
            }
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            if (dgvCariAccounts.SelectedRows.Count > 0)
            {
                var selectedAccount = (CariAccountDto)dgvCariAccounts.SelectedRows[0].DataBoundItem;
                
                // Debug: Check ID value
                Console.WriteLine($"DEBUG: Selected account ID for transactions = {selectedAccount.CariAccountID}, Name = {selectedAccount.CariName}");
                
                var transactionsForm = new CariTransactionsForm(_cariAccountService, selectedAccount);
                transactionsForm.ShowDialog();
            }
        }

        private void btnStatement_Click(object sender, EventArgs e)
        {
            if (dgvCariAccounts.SelectedRows.Count > 0)
            {
                var selectedAccount = (CariAccountDto)dgvCariAccounts.SelectedRows[0].DataBoundItem;
                var statementForm = new CariStatementForm(_cariAccountService, selectedAccount);
                statementForm.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PerformSearch();
            }
        }

        private void PerformSearch()
        {
            _currentSearchTerm = txtSearch.Text.Trim();
            _currentPage = 1;
            _ = LoadCariAccounts();
        }

        private void cmbTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeFilter.SelectedItem != null)
            {
                dynamic selectedItem = cmbTypeFilter.SelectedItem;
                _currentTypeFilter = selectedItem.Value;
                _currentPage = 1;
                _ = LoadCariAccounts();
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                _ = LoadCariAccounts();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                _ = LoadCariAccounts();
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            _currentTypeFilter = 1; // Customer type
            cmbTypeFilter.SelectedIndex = 1; // Assuming customers are at index 1
            _currentPage = 1;
            _ = LoadCariAccounts();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            _currentTypeFilter = 2; // Supplier type
            cmbTypeFilter.SelectedIndex = 2; // Assuming suppliers are at index 2
            _currentPage = 1;
            _ = LoadCariAccounts();
        }

        private void dgvCariAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnViewDetails_Click(sender, e);
            }
        }

        private void ShowError(string title, string message, List<string>? errors = null)
        {
            var errorText = message;
            if (errors != null && errors.Any())
            {
                errorText += "\n\nDetaylar:\n" + string.Join("\n", errors);
            }

            MessageBox.Show(errorText, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnBalances_Click(object sender, EventArgs e)
        {
            try
            {
                var balancesForm = new CariBalancesForm(_cariAccountService);
                balancesForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError("Bakiye formu açılamadı", ex.Message);
            }
        }
    }
} 