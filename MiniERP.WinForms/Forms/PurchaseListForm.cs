using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class PurchaseListForm : Form
    {
        private readonly PurchaseService _purchaseService;
        private List<PurchaseInvoiceDto> _purchaseInvoices = new List<PurchaseInvoiceDto>();

        // UI Controls
        private Panel pnlTop;
        private Panel pnlButtons;
        private Panel pnlFilters;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClearFilter;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label lblStartDate;
        private Label lblEndDate;
        private DataGridView dgvPurchaseInvoices;
        private Button btnRefresh;
        private Button btnNew;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnApprove;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;

        public PurchaseListForm(ApiService apiService)
        {
            _purchaseService = new PurchaseService(apiService);
            InitializeComponent();
            SetupEventHandlers();
        }

        private void InitializeComponent()
        {
            this.Text = "Alış Faturaları";
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
                PlaceholderText = "Fatura no, tedarikçi adı..."
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

            // Date filters
            lblStartDate = new Label
            {
                Text = "Başlangıç:",
                Location = new Point(10, 45),
                Size = new Size(70, 23)
            };

            dtpStartDate = new DateTimePicker
            {
                Location = new Point(90, 42),
                Size = new Size(120, 23),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today.AddDays(-30)
            };

            lblEndDate = new Label
            {
                Text = "Bitiş:",
                Location = new Point(220, 45),
                Size = new Size(40, 23)
            };

            dtpEndDate = new DateTimePicker
            {
                Location = new Point(270, 42),
                Size = new Size(120, 23),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today
            };

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

            btnNew = new Button
            {
                Text = "Yeni Fatura",
                Location = new Point(100, 8),
                Size = new Size(100, 30),
                BackColor = Color.LightGreen
            };

            btnEdit = new Button
            {
                Text = "Düzenle",
                Location = new Point(210, 8),
                Size = new Size(80, 30)
            };

            btnDelete = new Button
            {
                Text = "Sil",
                Location = new Point(300, 8),
                Size = new Size(80, 30),
                BackColor = Color.LightCoral
            };

            btnApprove = new Button
            {
                Text = "Onayla",
                Location = new Point(390, 8),
                Size = new Size(80, 30),
                BackColor = Color.LightBlue
            };

            // DataGridView
            dgvPurchaseInvoices = new DataGridView
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
            pnlFilters.Controls.AddRange(new Control[] { lblSearch, txtSearch, btnSearch, btnClearFilter, lblStartDate, dtpStartDate, lblEndDate, dtpEndDate });
            pnlButtons.Controls.AddRange(new Control[] { btnRefresh, btnNew, btnEdit, btnDelete, btnApprove });
            this.Controls.AddRange(new Control[] { dgvPurchaseInvoices, pnlTop, statusStrip });
        }

        private void InitializeDataGridView()
        {
            dgvPurchaseInvoices.Columns.Clear();

            dgvPurchaseInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InvoiceNumber",
                HeaderText = "Fatura No",
                DataPropertyName = "InvoiceNumber",
                Width = 120
            });

            dgvPurchaseInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InvoiceDate",
                HeaderText = "Fatura Tarihi",
                DataPropertyName = "InvoiceDate",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }
            });

            dgvPurchaseInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CariName",
                HeaderText = "Tedarikçi",
                DataPropertyName = "CariName",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvPurchaseInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "WarehouseName",
                HeaderText = "Depo",
                DataPropertyName = "WarehouseName",
                Width = 120
            });

            dgvPurchaseInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SubtotalAmount",
                HeaderText = "Ara Toplam",
                DataPropertyName = "SubtotalAmount",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "C2" }
            });

            dgvPurchaseInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "VatAmount",
                HeaderText = "KDV",
                DataPropertyName = "VatAmount",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "C2" }
            });

            dgvPurchaseInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Toplam",
                DataPropertyName = "TotalAmount",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "C2" }
            });

            dgvPurchaseInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Durum",
                DataPropertyName = "Status",
                Width = 80
            });

            dgvPurchaseInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedBy",
                HeaderText = "Oluşturan",
                DataPropertyName = "CreatedBy",
                Width = 100
            });
        }

        private void SetupEventHandlers()
        {
            Load += PurchaseListForm_Load;
            btnRefresh.Click += BtnRefresh_Click;
            btnSearch.Click += BtnSearch_Click;
            btnClearFilter.Click += BtnClearFilter_Click;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnApprove.Click += BtnApprove_Click;
            txtSearch.KeyDown += TxtSearch_KeyDown;
            dgvPurchaseInvoices.CellFormatting += DgvPurchaseInvoices_CellFormatting;
        }

        private async void PurchaseListForm_Load(object sender, EventArgs e)
        {
            await LoadPurchaseInvoicesAsync();
        }

        private async Task LoadPurchaseInvoicesAsync()
        {
            try
            {
                lblStatus.Text = "Alış faturaları yükleniyor...";
                dgvPurchaseInvoices.DataSource = null;

                var response = await _purchaseService.GetPurchaseInvoicesAsync(1, 1000, txtSearch.Text.Trim());
                
                if (response.Success && response.Data != null)
                {
                    _purchaseInvoices = response.Data.Data ?? new List<PurchaseInvoiceDto>();
                    ApplyFilters();
                    lblStatus.Text = $"Toplam {_purchaseInvoices.Count} alış faturası";
                }
                else
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = "Alış faturaları yüklenemedi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Alış faturaları yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Hata oluştu";
            }
        }

        private void ApplyFilters()
        {
            var filteredInvoices = _purchaseInvoices.Where(x => 
                x.InvoiceDate >= dtpStartDate.Value.Date && 
                x.InvoiceDate <= dtpEndDate.Value.Date).ToList();

            dgvPurchaseInvoices.DataSource = filteredInvoices;
            lblStatus.Text = $"{filteredInvoices.Count} / {_purchaseInvoices.Count} alış faturası gösteriliyor";
        }

        private void DgvPurchaseInvoices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPurchaseInvoices.Rows[e.RowIndex].DataBoundItem is PurchaseInvoiceDto invoice)
            {
                // Status sütununu Türkçe göster
                if (dgvPurchaseInvoices.Columns[e.ColumnIndex].Name == "Status")
                {
                    switch (invoice.Status)
                    {
                        case "DRAFT":
                            e.Value = "Taslak";
                            break;
                        case "APPROVED":
                            e.Value = "Onaylandı";
                            break;
                        case "CANCELLED":
                            e.Value = "İptal Edildi";
                            break;
                        default:
                            e.Value = invoice.Status;
                            break;
                    }
                    e.FormattingApplied = true;
                }

                // Durum göre renklendirme
                switch (invoice.Status)
                {
                    case "DRAFT":
                        dgvPurchaseInvoices.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                    case "APPROVED":
                        dgvPurchaseInvoices.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    case "CANCELLED":
                        dgvPurchaseInvoices.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                        break;
                }
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadPurchaseInvoicesAsync();
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await LoadPurchaseInvoicesAsync();
        }

        private void BtnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dtpStartDate.Value = DateTime.Today.AddDays(-30);
            dtpEndDate.Value = DateTime.Today;
            ApplyFilters();
        }

        private async void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await LoadPurchaseInvoicesAsync();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                var apiService = new ApiService();
                var cariAccountService = new CariAccountService(apiService);
                var productService = new ProductService(apiService);
                
                var createForm = new PurchaseInvoiceCreateForm(_purchaseService, cariAccountService, productService);
                if (createForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the purchase invoices after creation
                    _ = LoadPurchaseInvoicesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseInvoices.SelectedRows.Count > 0)
            {
                var selectedInvoice = dgvPurchaseInvoices.SelectedRows[0].DataBoundItem as PurchaseInvoiceDto;
                if (selectedInvoice != null)
                {
                    if (selectedInvoice.Status != "DRAFT")
                    {
                        MessageBox.Show("Sadece taslak durumundaki faturalar düzenlenebilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        var apiService = new ApiService();
                        var cariAccountService = new CariAccountService(apiService);
                        var productService = new ProductService(apiService);
                        
                        var editForm = new PurchaseInvoiceEditForm(_purchaseService, cariAccountService, productService, selectedInvoice);
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            // Refresh the purchase invoices after editing
                            _ = LoadPurchaseInvoicesAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Form açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir fatura seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseInvoices.SelectedRows.Count > 0)
            {
                var selectedInvoice = dgvPurchaseInvoices.SelectedRows[0].DataBoundItem as PurchaseInvoiceDto;
                if (selectedInvoice != null)
                {
                    var result = MessageBox.Show($"'{selectedInvoice.InvoiceNumber}' numaralı faturayı silmek istediğinizden emin misiniz?", 
                        "Fatura Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            var response = await _purchaseService.DeletePurchaseInvoiceAsync(selectedInvoice.PurchaseInvoiceID);
                            if (response.Success)
                            {
                                MessageBox.Show("Fatura başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                await LoadPurchaseInvoicesAsync();
                            }
                            else
                            {
                                MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Fatura silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir fatura seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseInvoices.SelectedRows.Count > 0)
            {
                var selectedInvoice = dgvPurchaseInvoices.SelectedRows[0].DataBoundItem as PurchaseInvoiceDto;
                if (selectedInvoice != null)
                {
                    if (selectedInvoice.Status != "DRAFT")
                    {
                        MessageBox.Show("Sadece taslak durumundaki faturalar onaylanabilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var result = MessageBox.Show($"'{selectedInvoice.InvoiceNumber}' numaralı faturayı onaylamak istediğinizden emin misiniz?", 
                        "Fatura Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            var response = await _purchaseService.ApprovePurchaseInvoiceAsync(selectedInvoice.PurchaseInvoiceID);
                            if (response.Success)
                            {
                                MessageBox.Show("Fatura başarıyla onaylandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                await LoadPurchaseInvoicesAsync();
                            }
                            else
                            {
                                MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Fatura onaylanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir fatura seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
} 