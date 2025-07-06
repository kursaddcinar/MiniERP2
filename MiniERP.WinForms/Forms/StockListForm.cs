using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class StockListForm : Form
    {
        private readonly StockService _stockService;
        private readonly ProductService _productService;
        private List<StockCardDto> _stockCards = new List<StockCardDto>();
        private List<WarehouseDto> _warehouses = new List<WarehouseDto>();

        // UI Controls
        private Panel pnlTop;
        private Panel pnlButtons;
        private Panel pnlFilters;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClearFilter;
        private ComboBox cmbWarehouse;
        private ComboBox cmbStockStatus;
        private Label lblWarehouse;
        private Label lblStockStatus;
        private DataGridView dgvStockCards;
        private Button btnRefresh;
        private Button btnStockMovement;
        private Button btnStockTransfer;
        private Button btnStockAdjustment;
        private Button btnCriticalStock;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;

        public StockListForm(ApiService apiService)
        {
            _stockService = new StockService(apiService);
            _productService = new ProductService(apiService);
            InitializeComponent();
            SetupEventHandlers();
        }

        private void InitializeComponent()
        {
            this.Text = "Stok Yönetimi";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Top panel
            pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.LightGray
            };

            // Filters panel
            pnlFilters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                Parent = pnlTop
            };

            // Search controls
            var lblSearch = new Label
            {
                Text = "Arama:",
                Location = new Point(10, 15),
                Size = new Size(50, 23)
            };

            txtSearch = new TextBox
            {
                Location = new Point(70, 12),
                Size = new Size(200, 23),
                PlaceholderText = "Ürün kodu veya adı ile arama..."
            };

            btnSearch = new Button
            {
                Text = "Ara",
                Location = new Point(280, 12),
                Size = new Size(70, 25)
            };

            btnClearFilter = new Button
            {
                Text = "Temizle",
                Location = new Point(360, 12),
                Size = new Size(70, 25)
            };

            // Warehouse filter
            lblWarehouse = new Label
            {
                Text = "Depo:",
                Location = new Point(10, 45),
                Size = new Size(50, 23)
            };

            cmbWarehouse = new ComboBox
            {
                Location = new Point(70, 42),
                Size = new Size(150, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Stock status filter
            lblStockStatus = new Label
            {
                Text = "Durum:",
                Location = new Point(240, 45),
                Size = new Size(50, 23)
            };

            cmbStockStatus = new ComboBox
            {
                Location = new Point(300, 42),
                Size = new Size(120, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStockStatus.Items.AddRange(new string[] { "Tümü", "NORMAL", "CRITICAL", "OVER" });
            cmbStockStatus.SelectedIndex = 0;

            // Buttons panel
            pnlButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                Parent = pnlTop
            };

            btnRefresh = new Button
            {
                Text = "Yenile",
                Location = new Point(10, 8),
                Size = new Size(80, 30)
            };

            btnStockMovement = new Button
            {
                Text = "Stok Hareketi",
                Location = new Point(100, 8),
                Size = new Size(100, 30)
            };

            btnStockTransfer = new Button
            {
                Text = "Stok Transfer",
                Location = new Point(210, 8),
                Size = new Size(100, 30)
            };

            btnStockAdjustment = new Button
            {
                Text = "Stok Düzeltme",
                Location = new Point(320, 8),
                Size = new Size(100, 30)
            };

            btnCriticalStock = new Button
            {
                Text = "Kritik Stoklar",
                Location = new Point(430, 8),
                Size = new Size(100, 30),
                BackColor = Color.Orange
            };

            // DataGridView
            dgvStockCards = new DataGridView
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

            // Add controls to form
            pnlFilters.Controls.AddRange(new Control[] { lblSearch, txtSearch, btnSearch, btnClearFilter, lblWarehouse, cmbWarehouse, lblStockStatus, cmbStockStatus });
            pnlButtons.Controls.AddRange(new Control[] { btnRefresh, btnStockMovement, btnStockTransfer, btnStockAdjustment, btnCriticalStock });
            this.Controls.AddRange(new Control[] { dgvStockCards, pnlTop, statusStrip });
        }

        private void InitializeDataGridView()
        {
            dgvStockCards.Columns.Clear();

            dgvStockCards.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductCode",
                HeaderText = "Ürün Kodu",
                DataPropertyName = "ProductCode",
                Width = 120
            });

            dgvStockCards.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Ürün Adı",
                DataPropertyName = "ProductName",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvStockCards.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "WarehouseName",
                HeaderText = "Depo",
                DataPropertyName = "WarehouseName",
                Width = 120
            });

            dgvStockCards.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitName",
                HeaderText = "Birim",
                DataPropertyName = "UnitName",
                Width = 80
            });

            dgvStockCards.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CurrentStock",
                HeaderText = "Mevcut Stok",
                DataPropertyName = "CurrentStock",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
            });

            dgvStockCards.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReservedStock",
                HeaderText = "Rezerve Stok",
                DataPropertyName = "ReservedStock",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
            });

            dgvStockCards.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AvailableStock",
                HeaderText = "Kullanılabilir Stok",
                DataPropertyName = "AvailableStock",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
            });

            dgvStockCards.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MinStockLevel",
                HeaderText = "Min. Seviye",
                DataPropertyName = "MinStockLevel",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
            });

            dgvStockCards.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StockStatus",
                HeaderText = "Durum",
                DataPropertyName = "StockStatus",
                Width = 100
            });
        }

        private void SetupEventHandlers()
        {
            Load += StockListForm_Load;
            btnRefresh.Click += BtnRefresh_Click;
            btnSearch.Click += BtnSearch_Click;
            btnClearFilter.Click += BtnClearFilter_Click;
            btnStockMovement.Click += BtnStockMovement_Click;
            btnStockTransfer.Click += BtnStockTransfer_Click;
            btnStockAdjustment.Click += BtnStockAdjustment_Click;
            btnCriticalStock.Click += BtnCriticalStock_Click;
            txtSearch.KeyDown += TxtSearch_KeyDown;
            cmbWarehouse.SelectedIndexChanged += CmbWarehouse_SelectedIndexChanged;
            cmbStockStatus.SelectedIndexChanged += CmbStockStatus_SelectedIndexChanged;
            dgvStockCards.CellFormatting += DgvStockCards_CellFormatting;
        }

        private async void StockListForm_Load(object sender, EventArgs e)
        {
            await LoadWarehousesAsync();
            await LoadStockCardsAsync();
        }

        private async Task LoadWarehousesAsync()
        {
            try
            {
                var response = await _stockService.GetActiveWarehousesAsync();
                if (response.Success && response.Data != null)
                {
                    _warehouses = response.Data;
                    
                    cmbWarehouse.Items.Clear();
                    cmbWarehouse.Items.Add(new { Text = "Tüm Depolar", Value = -1 });
                    
                    foreach (var warehouse in _warehouses)
                    {
                        cmbWarehouse.Items.Add(new { Text = warehouse.WarehouseName, Value = warehouse.WarehouseID });
                    }
                    
                    cmbWarehouse.DisplayMember = "Text";
                    cmbWarehouse.ValueMember = "Value";
                    cmbWarehouse.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Depolar yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadStockCardsAsync()
        {
            try
            {
                lblStatus.Text = "Stok kartları yükleniyor...";
                dgvStockCards.DataSource = null;

                var response = await _stockService.GetStockCardsAsync(1, 1000, txtSearch.Text.Trim());
                
                if (response.Success && response.Data != null)
                {
                    _stockCards = response.Data.Data ?? new List<StockCardDto>();
                    ApplyFilters();
                    lblStatus.Text = $"Toplam {_stockCards.Count} stok kartı";
                }
                else
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = "Stok kartları yüklenemedi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok kartları yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Hata oluştu";
            }
        }

        private void ApplyFilters()
        {
            var filteredCards = _stockCards.AsEnumerable();

            // Depo filtresi
            if (cmbWarehouse.SelectedValue != null && (int)cmbWarehouse.SelectedValue != -1)
            {
                var warehouseId = (int)cmbWarehouse.SelectedValue;
                filteredCards = filteredCards.Where(x => x.WarehouseID == warehouseId);
            }

            // Stok durumu filtresi
            if (!string.IsNullOrWhiteSpace(cmbStockStatus.Text) && cmbStockStatus.Text != "Tümü")
            {
                filteredCards = filteredCards.Where(x => x.StockStatus == cmbStockStatus.Text);
            }

            dgvStockCards.DataSource = filteredCards.ToList();
            lblStatus.Text = $"{filteredCards.Count()} / {_stockCards.Count} stok kartı gösteriliyor";
        }

        private void DgvStockCards_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStockCards.Rows[e.RowIndex].DataBoundItem is StockCardDto stockCard)
            {
                // Stok durumuna göre renklendirme
                if (stockCard.StockStatus == "CRITICAL")
                {
                    dgvStockCards.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else if (stockCard.StockStatus == "OVER")
                {
                    dgvStockCards.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else if (stockCard.CurrentStock <= 0)
                {
                    dgvStockCards.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private async void BtnRefresh_Click(object? sender, EventArgs e)
        {
            await LoadStockCardsAsync();
        }

        private async void BtnSearch_Click(object? sender, EventArgs e)
        {
            await LoadStockCardsAsync();
        }

        private void BtnClearFilter_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbWarehouse.SelectedIndex = 0;
            cmbStockStatus.SelectedIndex = 0;
            ApplyFilters();
        }

        private async void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await LoadStockCardsAsync();
            }
        }

        private void CmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void CmbStockStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void BtnStockMovement_Click(object sender, EventArgs e)
        {
            if (dgvStockCards.SelectedRows.Count > 0)
            {
                var selectedCard = dgvStockCards.SelectedRows[0].DataBoundItem as StockCardDto;
                if (selectedCard != null)
                {
                    var movementForm = new StockMovementForm(_stockService, selectedCard);
                    movementForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir stok kartı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnStockTransfer_Click(object sender, EventArgs e)
        {
            if (dgvStockCards.SelectedRows.Count > 0)
            {
                var selectedCard = dgvStockCards.SelectedRows[0].DataBoundItem as StockCardDto;
                if (selectedCard != null)
                {
                    if (selectedCard.CurrentStock <= 0)
                    {
                        MessageBox.Show("Stok miktarı 0 veya daha az olan ürünler transfer edilemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var transferForm = new StockTransferForm(_stockService, selectedCard);
                    if (transferForm.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh the stock cards after transfer
                        _ = LoadStockCardsAsync();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir stok kartı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnStockAdjustment_Click(object sender, EventArgs e)
        {
            if (dgvStockCards.SelectedRows.Count > 0)
            {
                var selectedCard = dgvStockCards.SelectedRows[0].DataBoundItem as StockCardDto;
                if (selectedCard != null)
                {
                    var adjustmentForm = new StockAdjustmentForm(_stockService, _productService, selectedCard);
                    if (adjustmentForm.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh the stock cards after adjustment
                        _ = LoadStockCardsAsync();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir stok kartı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void BtnCriticalStock_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Kritik stok kartları yükleniyor...";
                
                var response = await _stockService.GetCriticalStockAsync();
                
                if (response.Success && response.Data != null)
                {
                    dgvStockCards.DataSource = response.Data;
                    lblStatus.Text = $"{response.Data.Count} kritik stok kartı";
                    
                    if (response.Data.Count == 0)
                    {
                        MessageBox.Show("Kritik seviyede stok bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kritik stoklar yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 