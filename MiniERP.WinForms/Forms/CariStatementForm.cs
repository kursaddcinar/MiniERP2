using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class CariStatementForm : Form
    {
        private readonly CariAccountService _cariAccountService;
        private readonly CariAccountDto _cariAccount;
        private CariStatementDto? _statement;

        public CariStatementForm(CariAccountService cariAccountService, CariAccountDto cariAccount)
        {
            InitializeComponent();
            _cariAccountService = cariAccountService;
            _cariAccount = cariAccount;
            
            this.Text = $"Hesap Özeti - {_cariAccount.CariName}";
            lblTitle.Text = $"Hesap Özeti - {_cariAccount.CariName}";
            
            InitializeForm();
        }

        private async void InitializeForm()
        {
            SetupDatePickers();
            SetupDataGridView();
            await LoadStatement();
        }

        private void SetupDatePickers()
        {
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
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
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }
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
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreditAmount",
                HeaderText = "Alacak",
                DataPropertyName = "CreditAmount",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Balance",
                HeaderText = "Bakiye",
                DataPropertyName = "Balance",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReferenceNumber",
                HeaderText = "Referans",
                DataPropertyName = "ReferenceNumber",
                Width = 120
            });
        }

        private async Task LoadStatement()
        {
            try
            {
                btnRefresh.Enabled = false;
                btnRefresh.Text = "Yükleniyor...";

                var response = await _cariAccountService.GetCariStatementAsync(_cariAccount.CariAccountID, dtpStartDate.Value, dtpEndDate.Value);
                
                if (response.Success && response.Data != null)
                {
                    _statement = response.Data;
                    
                    // Update summary info
                    txtOpeningBalance.Text = _statement.OpeningBalance.ToString("C2");
                    txtClosingBalance.Text = _statement.ClosingBalance.ToString("C2");
                    txtTotalDebit.Text = _statement.TotalDebit.ToString("C2");
                    txtTotalCredit.Text = _statement.TotalCredit.ToString("C2");
                    
                    // Set colors based on balance
                    if (_statement.OpeningBalance >= 0)
                    {
                        txtOpeningBalance.BackColor = Color.LightGreen;
                        txtOpeningBalance.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        txtOpeningBalance.BackColor = Color.LightCoral;
                        txtOpeningBalance.ForeColor = Color.DarkRed;
                    }
                    
                    if (_statement.ClosingBalance >= 0)
                    {
                        txtClosingBalance.BackColor = Color.LightGreen;
                        txtClosingBalance.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        txtClosingBalance.BackColor = Color.LightCoral;
                        txtClosingBalance.ForeColor = Color.DarkRed;
                    }
                    
                    // Load transactions
                    dgvTransactions.DataSource = _statement.Transactions;
                    
                    lblStatus.Text = $"Dönem: {dtpStartDate.Value:dd.MM.yyyy} - {dtpEndDate.Value:dd.MM.yyyy} | Toplam {_statement.Transactions.Count} hareket";
                }
                else
                {
                    ShowError("Hesap özeti yüklenemedi", response.Message, response.Errors);
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

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadStatement();
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

        private void btnPrintStatement_Click(object sender, EventArgs e)
        {
            if (_statement == null)
            {
                MessageBox.Show("Önce hesap özetini yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simple print implementation - can be enhanced later
            MessageBox.Show("Yazdırma özelliği yakında eklenecek.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (_statement == null)
            {
                MessageBox.Show("Önce hesap özetini yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simple export implementation - can be enhanced later
            MessageBox.Show("Excel'e aktarma özelliği yakında eklenecek.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
} 