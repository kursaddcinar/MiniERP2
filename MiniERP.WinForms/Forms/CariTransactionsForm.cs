using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class CariTransactionsForm : Form
    {
        private readonly CariAccountService _cariAccountService;
        private readonly CariAccountDto _cariAccount;
        private List<CariTransactionDto> _transactions = new List<CariTransactionDto>();
        private int _currentPage = 1;
        private int _pageSize = 50;
        private int _totalPages = 1;

        public CariTransactionsForm(CariAccountService cariAccountService, CariAccountDto cariAccount)
        {
            InitializeComponent();
            _cariAccountService = cariAccountService;
            _cariAccount = cariAccount;
            
            this.Text = $"Cari Hareketler - {_cariAccount.CariName}";
            lblTitle.Text = $"Cari Hareketler - {_cariAccount.CariName}";
            
            InitializeForm();
        }

        private async void InitializeForm()
        {
            SetupDataGridView();
            await LoadTransactions();
            UpdateUI();
        }

        private void SetupDataGridView()
        {
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.MultiSelect = false;
            dgvTransactions.ReadOnly = true;

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TransactionDate",
                HeaderText = "Tarih",
                DataPropertyName = "TransactionDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TransactionType",
                HeaderText = "Tip",
                DataPropertyName = "TransactionType",
                Width = 100
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Açıklama",
                DataPropertyName = "Description",
                Width = 200
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DebitAmount",
                HeaderText = "Borç",
                DataPropertyName = "DebitAmount",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreditAmount",
                HeaderText = "Alacak",
                DataPropertyName = "CreditAmount",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Balance",
                HeaderText = "Bakiye",
                DataPropertyName = "Balance",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReferenceNumber",
                HeaderText = "Referans No",
                DataPropertyName = "ReferenceNumber",
                Width = 120
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedDate",
                HeaderText = "Oluşturulma",
                DataPropertyName = "CreatedDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy HH:mm" }
            });
        }

        private async Task LoadTransactions()
        {
            try
            {
                btnRefresh.Enabled = false;
                btnRefresh.Text = "Yükleniyor...";

                var response = await _cariAccountService.GetCariTransactionsAsync(_cariAccount.CariAccountID, _currentPage, _pageSize);
                
                if (response.Success && response.Data != null)
                {
                    _transactions = response.Data.Data;
                    _totalPages = response.Data.TotalPages;
                    
                    dgvTransactions.DataSource = _transactions;
                    
                    lblStatus.Text = $"Toplam {response.Data.TotalCount} hareket. Sayfa {_currentPage}/{_totalPages}";
                }
                else
                {
                    ShowError("Hareketler yüklenemedi", response.Message, response.Errors);
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
            btnPreviousPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPages;
            
            lblPageInfo.Text = $"Sayfa {_currentPage} / {_totalPages}";
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadTransactions();
        }

        private async void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadTransactions();
                UpdateUI();
            }
        }

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadTransactions();
                UpdateUI();
            }
        }

        private void ShowError(string title, string message, List<string>? errors = null)
        {
            var errorMessage = message;
            if (errors != null && errors.Any())
            {
                errorMessage += "\n\nDetaylar:\n" + string.Join("\n", errors);
            }
            
            MessageBox.Show(errorMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
} 