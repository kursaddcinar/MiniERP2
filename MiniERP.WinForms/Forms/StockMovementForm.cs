using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class StockMovementForm : Form
    {
        private readonly StockService _stockService;
        private readonly StockCardDto _stockCard;
        private List<StockTransactionDto> _transactions = new List<StockTransactionDto>();

        // UI Controls
        private Panel pnlTop;
        private Panel pnlInfo;
        private Label lblTitle;
        private Label lblProductCode;
        private Label lblProductName;
        private Label lblWarehouse;
        private Label lblCurrentStock;
        private TextBox txtProductCode;
        private TextBox txtProductName;
        private TextBox txtWarehouse;
        private TextBox txtCurrentStock;
        private DataGridView dgvTransactions;
        private Button btnRefresh;
        private Button btnClose;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;

        public StockMovementForm(StockService stockService, StockCardDto stockCard)
        {
            _stockService = stockService;
            _stockCard = stockCard;
            
            InitializeComponent();
            LoadStockInfo();
            _ = LoadStockTransactionsAsync();
        }

        private void InitializeComponent()
        {
            this.Text = "Stok Hareketleri";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimumSize = new Size(800, 500);

            // Top panel
            pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.LightGray
            };

            // Info panel
            pnlInfo = new Panel
            {
                Dock = DockStyle.Fill,
                Parent = pnlTop,
                Padding = new Padding(10)
            };

            lblTitle = new Label
            {
                Text = "Stok Hareketleri",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 5),
                Size = new Size(200, 25)
            };

            lblProductCode = new Label { Text = "Ürün Kodu:", Location = new Point(10, 35), Size = new Size(80, 23) };
            txtProductCode = new TextBox { Location = new Point(95, 32), Size = new Size(120, 23), ReadOnly = true };

            lblProductName = new Label { Text = "Ürün Adı:", Location = new Point(230, 35), Size = new Size(70, 23) };
            txtProductName = new TextBox { Location = new Point(305, 32), Size = new Size(250, 23), ReadOnly = true };

            lblWarehouse = new Label { Text = "Depo:", Location = new Point(570, 35), Size = new Size(50, 23) };
            txtWarehouse = new TextBox { Location = new Point(625, 32), Size = new Size(120, 23), ReadOnly = true };

            lblCurrentStock = new Label { Text = "Mevcut Stok:", Location = new Point(760, 35), Size = new Size(80, 23) };
            txtCurrentStock = new TextBox { Location = new Point(845, 32), Size = new Size(100, 23), ReadOnly = true };

            btnRefresh = new Button
            {
                Text = "Yenile",
                Location = new Point(10, 65),
                Size = new Size(80, 25)
            };

            btnClose = new Button
            {
                Text = "Kapat",
                Location = new Point(865, 65),
                Size = new Size(80, 25)
            };

            // DataGridView
            dgvTransactions = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            InitializeDataGridView();

            // Status strip
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel("Hazır");
            statusStrip.Items.Add(lblStatus);

            // Add controls
            pnlInfo.Controls.AddRange(new Control[] {
                lblTitle, lblProductCode, txtProductCode, lblProductName, txtProductName,
                lblWarehouse, txtWarehouse, lblCurrentStock, txtCurrentStock,
                btnRefresh, btnClose
            });

            this.Controls.AddRange(new Control[] { dgvTransactions, pnlTop, statusStrip });

            // Event handlers
            btnRefresh.Click += BtnRefresh_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void InitializeDataGridView()
        {
            dgvTransactions.Columns.Clear();

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TransactionDate",
                HeaderText = "Tarih",
                DataPropertyName = "TransactionDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy HH:mm" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TransactionType",
                HeaderText = "İşlem Tipi",
                DataPropertyName = "TransactionType",
                Width = 120
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Miktar",
                DataPropertyName = "Quantity",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitName",
                HeaderText = "Birim",
                DataPropertyName = "UnitName",
                Width = 80
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Notes",
                HeaderText = "Açıklama",
                DataPropertyName = "Notes",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReferenceType",
                HeaderText = "Referans Tipi",
                DataPropertyName = "ReferenceType",
                Width = 120
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedBy",
                HeaderText = "Oluşturan",
                DataPropertyName = "CreatedBy",
                Width = 100
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedDate",
                HeaderText = "Oluşturma Tarihi",
                DataPropertyName = "CreatedDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy HH:mm" }
            });
        }

        private void LoadStockInfo()
        {
            txtProductCode.Text = _stockCard.ProductCode;
            txtProductName.Text = _stockCard.ProductName;
            txtWarehouse.Text = _stockCard.WarehouseName;
            txtCurrentStock.Text = _stockCard.CurrentStock.ToString("N2") + " " + _stockCard.UnitName;
        }

        private async Task LoadStockTransactionsAsync()
        {
            try
            {
                lblStatus.Text = "Stok hareketleri yükleniyor...";
                dgvTransactions.DataSource = null;

                var response = await _stockService.GetStockTransactionsByProductIdAsync(_stockCard.ProductID);
                
                if (response.Success && response.Data != null)
                {
                    _transactions = response.Data.Where(t => t.WarehouseID == _stockCard.WarehouseID).ToList();
                    dgvTransactions.DataSource = _transactions;
                    lblStatus.Text = $"Toplam {_transactions.Count} hareket yüklendi";
                }
                else
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = "Hareketler yüklenemedi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hareketler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Hata oluştu";
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadStockTransactionsAsync();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
} 