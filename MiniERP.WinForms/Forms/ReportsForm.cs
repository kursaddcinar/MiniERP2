using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class ReportsForm : Form
    {
        private readonly StockService _stockService;
        private readonly SalesService _salesService;
        private readonly PurchaseService _purchaseService;

        // UI Controls
        private Panel pnlLeft;
        private Panel pnlRight;
        private Panel pnlTop;
        private Panel pnlBottom;
        private TreeView tvReports;
        private DataGridView dgvReport;
        private Button btnGenerate;
        private Button btnExport;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label lblStartDate;
        private Label lblEndDate;
        private Label lblReportTitle;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;

        public ReportsForm(StockService stockService, SalesService salesService, PurchaseService purchaseService)
        {
            _stockService = stockService;
            _salesService = salesService;
            _purchaseService = purchaseService;
            InitializeComponent();
            SetupEventHandlers();
        }

        private void InitializeComponent()
        {
            this.Text = "Raporlar";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Left panel for TreeView
            pnlLeft = new Panel
            {
                Dock = DockStyle.Left,
                Width = 300,
                BackColor = Color.LightGray
            };

            // Right panel for DataGridView
            pnlRight = new Panel
            {
                Dock = DockStyle.Fill
            };

            // Top panel for filters
            pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.LightBlue,
                Parent = pnlRight
            };

            // Bottom panel for buttons
            pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.LightGray,
                Parent = pnlRight
            };

            // TreeView for reports
            tvReports = new TreeView
            {
                Dock = DockStyle.Fill,
                Parent = pnlLeft
            };

            InitializeTreeView();

            // Report title
            lblReportTitle = new Label
            {
                Text = "Rapor Seçiniz",
                Location = new Point(10, 10),
                Size = new Size(200, 20),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            // Date filters
            lblStartDate = new Label
            {
                Text = "Başlangıç:",
                Location = new Point(10, 35),
                Size = new Size(70, 20)
            };

            dtpStartDate = new DateTimePicker
            {
                Location = new Point(90, 32),
                Size = new Size(120, 23),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today.AddDays(-30)
            };

            lblEndDate = new Label
            {
                Text = "Bitiş:",
                Location = new Point(220, 35),
                Size = new Size(40, 20)
            };

            dtpEndDate = new DateTimePicker
            {
                Location = new Point(270, 32),
                Size = new Size(120, 23),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today
            };

            // Buttons
            btnGenerate = new Button
            {
                Text = "Rapor Oluştur",
                Location = new Point(10, 8),
                Size = new Size(100, 30),
                BackColor = Color.LightGreen
            };

            btnExport = new Button
            {
                Text = "Excel'e Aktar",
                Location = new Point(120, 8),
                Size = new Size(100, 30),
                BackColor = Color.LightYellow
            };

            // DataGridView
            dgvReport = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                Parent = pnlRight
            };

            // Status strip
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel("Hazır");
            statusStrip.Items.Add(lblStatus);

            // Add controls to panels
            pnlTop.Controls.AddRange(new Control[] { lblReportTitle, lblStartDate, dtpStartDate, lblEndDate, dtpEndDate });
            pnlBottom.Controls.AddRange(new Control[] { btnGenerate, btnExport });
            this.Controls.AddRange(new Control[] { pnlRight, pnlLeft, statusStrip });
        }

        private void InitializeTreeView()
        {
            tvReports.BeginUpdate();
            tvReports.Nodes.Clear();

            // Sales Reports
            var salesNode = tvReports.Nodes.Add("sales", "Satış Raporları");
            salesNode.Nodes.Add("sales_summary", "Satış Özeti");
            salesNode.Nodes.Add("sales_customers", "Müşteri Bazlı Satış");
            salesNode.Nodes.Add("sales_products", "Ürün Bazlı Satış");
            salesNode.Nodes.Add("sales_monthly", "Aylık Satış");

            // Purchase Reports
            var purchaseNode = tvReports.Nodes.Add("purchase", "Alış Raporları");
            purchaseNode.Nodes.Add("purchase_summary", "Alış Özeti");
            purchaseNode.Nodes.Add("purchase_suppliers", "Tedarikçi Bazlı Alış");
            purchaseNode.Nodes.Add("purchase_products", "Ürün Bazlı Alış");
            purchaseNode.Nodes.Add("purchase_monthly", "Aylık Alış");

            // Stock Reports
            var stockNode = tvReports.Nodes.Add("stock", "Stok Raporları");
            stockNode.Nodes.Add("stock_current", "Mevcut Stok");
            stockNode.Nodes.Add("stock_critical", "Kritik Stok");
            stockNode.Nodes.Add("stock_movements", "Stok Hareketleri");
            stockNode.Nodes.Add("stock_warehouse", "Depo Bazlı Stok");

            // Financial Reports
            var financialNode = tvReports.Nodes.Add("financial", "Mali Raporlar");
            financialNode.Nodes.Add("financial_summary", "Mali Özet");
            financialNode.Nodes.Add("financial_receivables", "Alacaklar");
            financialNode.Nodes.Add("financial_payables", "Borçlar");

            tvReports.ExpandAll();
            tvReports.EndUpdate();
        }

        private void SetupEventHandlers()
        {
            Load += ReportsForm_Load;
            tvReports.AfterSelect += TvReports_AfterSelect;
            btnGenerate.Click += BtnGenerate_Click;
            btnExport.Click += BtnExport_Click;
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Rapor türünü seçiniz";
        }

        private void TvReports_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Level > 0)
            {
                lblReportTitle.Text = e.Node.Text;
                lblStatus.Text = $"Seçilen rapor: {e.Node.Text}";
            }
        }

        private async void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (tvReports.SelectedNode == null || tvReports.SelectedNode.Level == 0)
            {
                MessageBox.Show("Lütfen bir rapor türü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lblStatus.Text = "Rapor oluşturuluyor...";
                btnGenerate.Enabled = false;
                dgvReport.DataSource = null;

                var reportKey = tvReports.SelectedNode.Name;
                var data = await GenerateReportDataAsync(reportKey);

                dgvReport.DataSource = data;
                lblStatus.Text = $"Rapor oluşturuldu - {data?.Count ?? 0} kayıt";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rapor oluşturulurken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Rapor oluşturulamadı";
            }
            finally
            {
                btnGenerate.Enabled = true;
            }
        }

        private async Task<List<object>?> GenerateReportDataAsync(string reportKey)
        {
            var startDate = dtpStartDate.Value.Date;
            var endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1);

            return reportKey switch
            {
                "sales_summary" => await GenerateSalesSummaryAsync(startDate, endDate),
                "purchase_summary" => await GeneratePurchaseSummaryAsync(startDate, endDate),
                "stock_current" => await GenerateCurrentStockAsync(),
                "stock_critical" => await GenerateCriticalStockAsync(),
                _ => new List<object> { new { Message = "Bu rapor henüz hazırlanmamıştır." } }
            };
        }

        private async Task<List<object>?> GenerateSalesSummaryAsync(DateTime startDate, DateTime endDate)
        {
            var response = await _salesService.GetSalesInvoicesAsync(1, 1000, "");
            if (response.Success && response.Data?.Data != null)
            {
                var filteredData = response.Data.Data
                    .Where(x => x.InvoiceDate >= startDate && x.InvoiceDate <= endDate)
                    .GroupBy(x => x.InvoiceDate.Date)
                    .Select(g => new
                    {
                        Tarih = g.Key.ToString("dd.MM.yyyy"),
                        FaturaSayisi = g.Count(),
                        ToplamTutar = g.Sum(x => x.TotalAmount)
                    })
                    .OrderBy(x => x.Tarih)
                    .ToList<object>();

                return filteredData;
            }
            return null;
        }

        private async Task<List<object>?> GeneratePurchaseSummaryAsync(DateTime startDate, DateTime endDate)
        {
            var response = await _purchaseService.GetPurchaseInvoicesAsync(1, 1000, "");
            if (response.Success && response.Data?.Data != null)
            {
                var filteredData = response.Data.Data
                    .Where(x => x.InvoiceDate >= startDate && x.InvoiceDate <= endDate)
                    .GroupBy(x => x.InvoiceDate.Date)
                    .Select(g => new
                    {
                        Tarih = g.Key.ToString("dd.MM.yyyy"),
                        FaturaSayisi = g.Count(),
                        ToplamTutar = g.Sum(x => x.TotalAmount)
                    })
                    .OrderBy(x => x.Tarih)
                    .ToList<object>();

                return filteredData;
            }
            return null;
        }

        private async Task<List<object>?> GenerateCurrentStockAsync()
        {
            var response = await _stockService.GetStockCardsAsync(1, 1000, "");
            if (response.Success && response.Data?.Data != null)
            {
                var stockData = response.Data.Data
                    .Select(x => new
                    {
                        UrunKodu = x.ProductCode,
                        UrunAdi = x.ProductName,
                        DepoAdi = x.WarehouseName,
                        MevcutMiktar = x.CurrentStock,
                        BirimFiyat = 0m, // Unit price is not available in StockCardDto
                        ToplamDeger = x.CurrentStock * 0m, // Cannot calculate without unit price
                        Durum = x.StockStatus
                    })
                    .OrderBy(x => x.UrunAdi)
                    .ToList<object>();

                return stockData;
            }
            return null;
        }

        private async Task<List<object>?> GenerateCriticalStockAsync()
        {
            var response = await _stockService.GetCriticalStockAsync();
            if (response.Success && response.Data != null)
            {
                var criticalData = response.Data
                    .Select(x => new
                    {
                        UrunKodu = x.ProductCode,
                        UrunAdi = x.ProductName,
                        DepoAdi = x.WarehouseName,
                        MevcutMiktar = x.CurrentStock,
                        MinimumMiktar = x.MinStockLevel,
                        Eksik = x.MinStockLevel - x.CurrentStock,
                        Durum = x.StockStatus
                    })
                    .OrderBy(x => x.UrunAdi)
                    .ToList<object>();

                return criticalData;
            }
            return null;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (dgvReport.DataSource == null)
            {
                MessageBox.Show("Önce rapor oluşturunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Excel export özelliği geliştirilecek.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
} 