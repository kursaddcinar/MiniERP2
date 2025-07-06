using MiniERP.WinForms.Services;
using MiniERP.WinForms.Models;

namespace MiniERP.WinForms.Forms
{
    public partial class CariBalancesForm : Form
    {
        private readonly CariAccountService _cariAccountService;
        private List<CariBalanceDto> _balances = new List<CariBalanceDto>();

        public CariBalancesForm(CariAccountService cariAccountService)
        {
            InitializeComponent();
            _cariAccountService = cariAccountService;
            
            this.Text = "Cari Bakiyeler";
            lblTitle.Text = "Cari Bakiyeler";
            
            InitializeForm();
        }

        private async void InitializeForm()
        {
            SetupDataGridView();
            SetupControls();
            await LoadBalances();
        }

        private void SetupControls()
        {
            chkIncludeZeroBalance.Checked = false;
        }

        private void SetupDataGridView()
        {
            dgvBalances.AutoGenerateColumns = false;
            dgvBalances.AllowUserToAddRows = false;
            dgvBalances.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBalances.MultiSelect = false;
            dgvBalances.ReadOnly = true;

            dgvBalances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CariCode",
                HeaderText = "Cari Kodu",
                DataPropertyName = "CariCode",
                Width = 120
            });

            dgvBalances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CariName",
                HeaderText = "Cari Adı",
                DataPropertyName = "CariName",
                Width = 200
            });

            dgvBalances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Balance",
                HeaderText = "Bakiye",
                DataPropertyName = "Balance",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvBalances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BalanceType",
                HeaderText = "Bakiye Tipi",
                DataPropertyName = "BalanceType",
                Width = 100
            });

            dgvBalances.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LastTransactionDate",
                HeaderText = "Son Hareket",
                DataPropertyName = "LastTransactionDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }
            });

            // Color coding for balance types
            dgvBalances.CellFormatting += DgvBalances_CellFormatting;
        }

        private void DgvBalances_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var balance = _balances[e.RowIndex];
                
                // Color code balance column
                if (dgvBalances.Columns[e.ColumnIndex].Name == "Balance")
                {
                    if (balance.BalanceType == "ALACAK")
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.DarkGreen;
                    }
                    else if (balance.BalanceType == "BORC")
                    {
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.DarkRed;
                    }
                }
                
                // Color code balance type column
                if (dgvBalances.Columns[e.ColumnIndex].Name == "BalanceType")
                {
                    if (balance.BalanceType == "ALACAK")
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.DarkGreen;
                    }
                    else if (balance.BalanceType == "BORC")
                    {
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.DarkRed;
                    }
                }
            }
        }

        private async Task LoadBalances()
        {
            try
            {
                btnRefresh.Enabled = false;
                btnRefresh.Text = "Yükleniyor...";

                var response = await _cariAccountService.GetCariBalancesAsync(chkIncludeZeroBalance.Checked);
                
                if (response.Success && response.Data != null)
                {
                    _balances = response.Data;
                    dgvBalances.DataSource = _balances;
                    
                    // Calculate summary
                    var totalReceivables = _balances.Where(b => b.BalanceType == "ALACAK").Sum(b => b.Balance);
                    var totalPayables = _balances.Where(b => b.BalanceType == "BORC").Sum(b => Math.Abs(b.Balance));
                    var netBalance = totalReceivables - totalPayables;
                    
                    txtTotalReceivables.Text = totalReceivables.ToString("C2");
                    txtTotalPayables.Text = totalPayables.ToString("C2");
                    txtNetBalance.Text = netBalance.ToString("C2");
                    
                    // Color code net balance
                    if (netBalance >= 0)
                    {
                        txtNetBalance.BackColor = Color.LightGreen;
                        txtNetBalance.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        txtNetBalance.BackColor = Color.LightCoral;
                        txtNetBalance.ForeColor = Color.DarkRed;
                    }
                    
                    lblStatus.Text = $"Toplam {_balances.Count} cari hesap bakiyesi";
                }
                else
                {
                    ShowError("Bakiyeler yüklenemedi", response.Message, response.Errors);
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
            await LoadBalances();
        }

        private async void chkIncludeZeroBalance_CheckedChanged(object sender, EventArgs e)
        {
            await LoadBalances();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excel'e aktarma özelliği yakında eklenecek.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPrintBalances_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yazdırma özelliği yakında eklenecek.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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