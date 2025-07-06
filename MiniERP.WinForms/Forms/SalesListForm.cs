using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class SalesListForm : Form
    {
        private readonly SalesService _salesService;
        private List<SalesInvoiceDto> _salesInvoices = new List<SalesInvoiceDto>();

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
        private DataGridView dgvSalesInvoices;
        private Button btnRefresh;
        private Button btnNew;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnApprove;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;

        public SalesListForm(ApiService apiService)
        {
            _salesService = new SalesService(apiService);
            InitializeComponent();
            SetupEventHandlers();
        }

        private void InitializeComponent()
        {
            this.Text = "Satış Faturaları";
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
                PlaceholderText = "Fatura no, müşteri adı..."
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
            dgvSalesInvoices = new DataGridView
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
            this.Controls.AddRange(new Control[] { dgvSalesInvoices, pnlTop, statusStrip });
        }

        private void InitializeDataGridView()
        {
            dgvSalesInvoices.Columns.Clear();

            dgvSalesInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InvoiceNumber",
                HeaderText = "Fatura No",
                DataPropertyName = "InvoiceNumber",
                Width = 120
            });

            dgvSalesInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InvoiceDate",
                HeaderText = "Fatura Tarihi",
                DataPropertyName = "InvoiceDate",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }
            });

            dgvSalesInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CariName",
                HeaderText = "Müşteri",
                DataPropertyName = "CariName",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvSalesInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "WarehouseName",
                HeaderText = "Depo",
                DataPropertyName = "WarehouseName",
                Width = 120
            });

            dgvSalesInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SubtotalAmount",
                HeaderText = "Ara Toplam",
                DataPropertyName = "SubtotalAmount",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "C2" }
            });

            dgvSalesInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "VatAmount",
                HeaderText = "KDV",
                DataPropertyName = "VatAmount",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "C2" }
            });

            dgvSalesInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Toplam",
                DataPropertyName = "TotalAmount",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "C2" }
            });

            dgvSalesInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Durum",
                DataPropertyName = "Status",
                Width = 80
            });

            dgvSalesInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedBy",
                HeaderText = "Oluşturan",
                DataPropertyName = "CreatedBy",
                Width = 100
            });
        }

        private void SetupEventHandlers()
        {
            Load += SalesListForm_Load;
            btnRefresh.Click += BtnRefresh_Click;
            btnSearch.Click += BtnSearch_Click;
            btnClearFilter.Click += BtnClearFilter_Click;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnApprove.Click += BtnApprove_Click;
            txtSearch.KeyDown += TxtSearch_KeyDown;
            dgvSalesInvoices.CellFormatting += DgvSalesInvoices_CellFormatting;
        }

        private async void SalesListForm_Load(object sender, EventArgs e)
        {
            await LoadSalesInvoicesAsync();
        }

        private async Task LoadSalesInvoicesAsync()
        {
            try
            {
                lblStatus.Text = "Satış faturaları yükleniyor...";
                dgvSalesInvoices.DataSource = null;

                var response = await _salesService.GetSalesInvoicesAsync(1, 1000, txtSearch.Text.Trim());
                
                if (response.Success && response.Data != null)
                {
                    _salesInvoices = response.Data.Data ?? new List<SalesInvoiceDto>();
                    ApplyFilters();
                    lblStatus.Text = $"Toplam {_salesInvoices.Count} satış faturası";
                }
                else
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = "Satış faturaları yüklenemedi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış faturaları yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Hata oluştu";
            }
        }

        private void ApplyFilters()
        {
            var filteredInvoices = _salesInvoices.Where(x => 
                x.InvoiceDate >= dtpStartDate.Value.Date && 
                x.InvoiceDate <= dtpEndDate.Value.Date).ToList();

            dgvSalesInvoices.DataSource = filteredInvoices;
            lblStatus.Text = $"{filteredInvoices.Count} / {_salesInvoices.Count} satış faturası gösteriliyor";
        }

        private void DgvSalesInvoices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSalesInvoices.Rows[e.RowIndex].DataBoundItem is SalesInvoiceDto invoice)
            {
                // Status sütununu Türkçe göster
                if (dgvSalesInvoices.Columns[e.ColumnIndex].Name == "Status")
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
                        dgvSalesInvoices.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                    case "APPROVED":
                        dgvSalesInvoices.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    case "CANCELLED":
                        dgvSalesInvoices.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                        break;
                }
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadSalesInvoicesAsync();
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await LoadSalesInvoicesAsync();
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
                await LoadSalesInvoicesAsync();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                var apiService = new ApiService();
                var cariAccountService = new CariAccountService(apiService);
                var productService = new ProductService(apiService);
                
                var createForm = new SalesInvoiceCreateForm(_salesService, cariAccountService, productService);
                if (createForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the sales invoices after creation
                    _ = LoadSalesInvoicesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSalesInvoices.SelectedRows.Count > 0)
            {
                var selectedInvoice = dgvSalesInvoices.SelectedRows[0].DataBoundItem as SalesInvoiceDto;
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
                        
                        var editForm = new SalesInvoiceEditForm(_salesService, cariAccountService, productService, selectedInvoice);
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            // Refresh the sales invoices after editing
                            _ = LoadSalesInvoicesAsync();
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
            if (dgvSalesInvoices.SelectedRows.Count > 0)
            {
                var selectedInvoice = dgvSalesInvoices.SelectedRows[0].DataBoundItem as SalesInvoiceDto;
                if (selectedInvoice != null)
                {
                    var result = MessageBox.Show($"'{selectedInvoice.InvoiceNumber}' numaralı faturayı silmek istediğinizden emin misiniz?", 
                        "Fatura Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            var response = await _salesService.DeleteSalesInvoiceAsync(selectedInvoice.SalesInvoiceID);
                            if (response.Success)
                            {
                                MessageBox.Show("Fatura başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                await LoadSalesInvoicesAsync();
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
            if (dgvSalesInvoices.SelectedRows.Count > 0)
            {
                var selectedInvoice = dgvSalesInvoices.SelectedRows[0].DataBoundItem as SalesInvoiceDto;
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
                            var response = await _salesService.ApproveSalesInvoiceAsync(selectedInvoice.SalesInvoiceID);
                            if (response.Success)
                            {
                                MessageBox.Show("Fatura başarıyla onaylandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                await LoadSalesInvoicesAsync();
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