using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class SalesInvoiceCreateForm : Form
    {
        private readonly SalesService _salesService;
        private readonly CariAccountService _cariAccountService;
        private readonly ProductService _productService;
        private List<CariAccountDto> _customers = new List<CariAccountDto>();
        private List<ProductDto> _products = new List<ProductDto>();
        private List<CreateSalesInvoiceDetailDto> _invoiceItems = new List<CreateSalesInvoiceDetailDto>();

        // UI Controls
        private Panel pnlTop;
        private Panel pnlInvoiceInfo;
        private Panel pnlItems;
        private Panel pnlSummary;
        private Panel pnlButtons;
        private GroupBox gbInvoiceInfo;
        private GroupBox gbItems;
        private GroupBox gbSummary;
        private Label lblTitle;
        private Label lblCustomer;
        private Label lblInvoiceDate;
        private Label lblWarehouse;
        private Label lblNotes;
        private ComboBox cmbCustomer;
        private DateTimePicker dtpInvoiceDate;
        private ComboBox cmbWarehouse;
        private TextBox txtNotes;
        private DataGridView dgvItems;
        private Button btnAddItem;
        private Button btnDeleteItem;
        private Label lblSubtotal;
        private Label lblVatAmount;
        private Label lblTotal;
        private TextBox txtSubtotal;
        private TextBox txtVatAmount;
        private TextBox txtTotal;
        private Button btnSave;
        private Button btnCancel;

        public SalesInvoiceCreateForm(SalesService salesService, CariAccountService cariAccountService, ProductService productService)
        {
            _salesService = salesService;
            _cariAccountService = cariAccountService;
            _productService = productService;
            
            InitializeComponent();
            _ = LoadDataAsync();
        }

        private void InitializeComponent()
        {
            this.Text = "Yeni Satış Faturası";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimumSize = new Size(800, 600);

            // Top panel
            pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.LightGray
            };

            lblTitle = new Label
            {
                Text = "Yeni Satış Faturası",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 15),
                Size = new Size(300, 25)
            };

            pnlTop.Controls.Add(lblTitle);

            // Invoice info panel
            pnlInvoiceInfo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 150,
                Padding = new Padding(20, 10, 20, 10)
            };

            gbInvoiceInfo = new GroupBox
            {
                Text = "Fatura Bilgileri",
                Dock = DockStyle.Fill
            };

            lblCustomer = new Label { Text = "Müşteri:", Location = new Point(20, 30), Size = new Size(60, 23) };
            cmbCustomer = new ComboBox { Location = new Point(85, 27), Size = new Size(300, 23), DropDownStyle = ComboBoxStyle.DropDownList };

            lblInvoiceDate = new Label { Text = "Fatura Tarihi:", Location = new Point(20, 70), Size = new Size(80, 23) };
            dtpInvoiceDate = new DateTimePicker { Location = new Point(105, 67), Size = new Size(150, 23) };

            lblWarehouse = new Label { Text = "Depo:", Location = new Point(280, 70), Size = new Size(50, 23) };
            cmbWarehouse = new ComboBox { Location = new Point(335, 67), Size = new Size(200, 23), DropDownStyle = ComboBoxStyle.DropDownList };

            lblNotes = new Label { Text = "Notlar:", Location = new Point(20, 110), Size = new Size(50, 23) };
            txtNotes = new TextBox { Location = new Point(85, 107), Size = new Size(450, 23) };

            gbInvoiceInfo.Controls.AddRange(new Control[] {
                lblCustomer, cmbCustomer, lblInvoiceDate, dtpInvoiceDate,
                lblWarehouse, cmbWarehouse, lblNotes, txtNotes
            });

            pnlInvoiceInfo.Controls.Add(gbInvoiceInfo);

            // Items panel
            pnlItems = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 10, 20, 10)
            };

            gbItems = new GroupBox
            {
                Text = "Fatura Kalemleri",
                Dock = DockStyle.Fill
            };

            dgvItems = new DataGridView
            {
                Location = new Point(10, 25),
                Size = new Size(920, 300),
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            InitializeItemsDataGridView();

            btnAddItem = new Button
            {
                Text = "Ürün Ekle",
                Location = new Point(10, 335),
                Size = new Size(100, 30),
                BackColor = Color.LightGreen
            };

            btnDeleteItem = new Button
            {
                Text = "Ürün Sil",
                Location = new Point(120, 335),
                Size = new Size(100, 30),
                BackColor = Color.LightCoral
            };

            gbItems.Controls.AddRange(new Control[] { dgvItems, btnAddItem, btnDeleteItem });
            pnlItems.Controls.Add(gbItems);

            // Summary panel
            pnlSummary = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 120,
                Padding = new Padding(20, 10, 20, 10)
            };

            gbSummary = new GroupBox
            {
                Text = "Fatura Toplamı",
                Dock = DockStyle.Fill
            };

            lblSubtotal = new Label { Text = "Ara Toplam:", Location = new Point(600, 30), Size = new Size(80, 23) };
            txtSubtotal = new TextBox { Location = new Point(685, 27), Size = new Size(120, 23), ReadOnly = true, TextAlign = HorizontalAlignment.Right };

            lblVatAmount = new Label { Text = "KDV Tutarı:", Location = new Point(600, 55), Size = new Size(80, 23) };
            txtVatAmount = new TextBox { Location = new Point(685, 52), Size = new Size(120, 23), ReadOnly = true, TextAlign = HorizontalAlignment.Right };

            lblTotal = new Label { Text = "Genel Toplam:", Location = new Point(600, 80), Size = new Size(80, 23), Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            txtTotal = new TextBox { Location = new Point(685, 77), Size = new Size(120, 23), ReadOnly = true, TextAlign = HorizontalAlignment.Right, Font = new Font("Segoe UI", 9, FontStyle.Bold) };

            gbSummary.Controls.AddRange(new Control[] {
                lblSubtotal, txtSubtotal, lblVatAmount, txtVatAmount, lblTotal, txtTotal
            });

            pnlSummary.Controls.Add(gbSummary);

            // Buttons panel
            pnlButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                Padding = new Padding(20, 10, 20, 10)
            };

            btnSave = new Button
            {
                Text = "Kaydet",
                Location = new Point(800, 15),
                Size = new Size(80, 30),
                BackColor = Color.LightGreen
            };

            btnCancel = new Button
            {
                Text = "İptal",
                Location = new Point(890, 15),
                Size = new Size(80, 30),
                DialogResult = DialogResult.Cancel
            };

            pnlButtons.Controls.AddRange(new Control[] { btnSave, btnCancel });

            // Add all panels to form
            this.Controls.AddRange(new Control[] { pnlButtons, pnlSummary, pnlItems, pnlInvoiceInfo, pnlTop });

            // Set initial values
            dtpInvoiceDate.Value = DateTime.Now;

            // Event handlers
            btnAddItem.Click += BtnAddItem_Click;
            btnDeleteItem.Click += BtnDeleteItem_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void InitializeItemsDataGridView()
        {
            dgvItems.Columns.Clear();

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductCode",
                HeaderText = "Ürün Kodu",
                Width = 120,
                ReadOnly = true
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Ürün Adı",
                Width = 200,
                ReadOnly = true
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Miktar",
                DataPropertyName = "Quantity",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitPrice",
                HeaderText = "Birim Fiyat",
                DataPropertyName = "UnitPrice",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Toplam",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvItems.CellValueChanged += DgvItems_CellValueChanged;
        }

        private async Task LoadDataAsync()
        {
            try
            {
                await LoadCustomersAsync();
                await LoadProductsAsync();
                await LoadWarehousesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCustomersAsync()
        {
            var response = await _cariAccountService.GetCariAccountsAsync(1, 1000);
            
            if (response.Success && response.Data != null)
            {
                _customers = response.Data.Data ?? new List<CariAccountDto>();
                
                cmbCustomer.Items.Clear();
                cmbCustomer.Items.Add(new { Text = "Müşteri Seçiniz...", Value = -1 });
                
                foreach (var customer in _customers)
                {
                    cmbCustomer.Items.Add(new { Text = $"{customer.CariCode} - {customer.CariName}", Value = customer.CariAccountID });
                }
                
                cmbCustomer.DisplayMember = "Text";
                cmbCustomer.ValueMember = "Value";
                cmbCustomer.SelectedIndex = 0;
            }
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                // Placeholder - will be implemented later
                await Task.Delay(1);
                _products = new List<ProductDto>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler yüklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadWarehousesAsync()
        {
            try
            {
                // Placeholder - will be implemented later
                await Task.Delay(1);
                cmbWarehouse.Items.Clear();
                cmbWarehouse.Items.Add(new { Text = "Depo Seçiniz...", Value = -1 });
                cmbWarehouse.Items.Add(new { Text = "Ana Depo", Value = 1 });
                
                cmbWarehouse.DisplayMember = "Text";
                cmbWarehouse.ValueMember = "Value";
                cmbWarehouse.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Depolar yüklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (_products.Count == 0)
            {
                MessageBox.Show("Önce ürünler yüklenmelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productSelectionForm = new ProductSelectionForm(_products);
            if (productSelectionForm.ShowDialog() == DialogResult.OK)
            {
                var selectedProduct = productSelectionForm.SelectedProduct;
                if (selectedProduct != null)
                {
                    // Check if product already exists
                    var existingItem = _invoiceItems.FirstOrDefault(x => x.ProductID == selectedProduct.ProductID);
                    if (existingItem != null)
                    {
                        MessageBox.Show("Bu ürün zaten faturada mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newItem = new CreateSalesInvoiceDetailDto
                    {
                        ProductID = selectedProduct.ProductID,
                        Quantity = 1,
                        UnitPrice = selectedProduct.SalePrice,
                        DiscountRate = 0
                    };

                    _invoiceItems.Add(newItem);
                    RefreshItemsGrid();
                    CalculateTotals();
                }
            }
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                var selectedIndex = dgvItems.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < _invoiceItems.Count)
                {
                    _invoiceItems.RemoveAt(selectedIndex);
                    RefreshItemsGrid();
                    CalculateTotals();
                }
            }
            else
            {
                MessageBox.Show("Silmek için bir kalem seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _invoiceItems.Count)
            {
                var item = _invoiceItems[e.RowIndex];
                var columnName = dgvItems.Columns[e.ColumnIndex].Name;

                try
                {
                    switch (columnName)
                    {
                        case "Quantity":
                            if (decimal.TryParse(dgvItems.Rows[e.RowIndex].Cells["Quantity"].Value?.ToString(), out decimal quantity))
                            {
                                item.Quantity = quantity;
                            }
                            break;
                        case "UnitPrice":
                            if (decimal.TryParse(dgvItems.Rows[e.RowIndex].Cells["UnitPrice"].Value?.ToString(), out decimal unitPrice))
                            {
                                item.UnitPrice = unitPrice;
                            }
                            break;
                    }
                    
                    RefreshItemsGrid();
                    CalculateTotals();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hesaplama hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshItemsGrid()
        {
            dgvItems.Rows.Clear();
            
            foreach (var item in _invoiceItems)
            {
                var product = _products.FirstOrDefault(p => p.ProductID == item.ProductID);
                if (product != null)
                {
                    var total = item.Quantity * item.UnitPrice;
                    dgvItems.Rows.Add(product.ProductCode, product.ProductName, item.Quantity, item.UnitPrice, total);
                }
            }
        }

        private void CalculateTotals()
        {
            decimal subtotal = _invoiceItems.Sum(x => x.Quantity * x.UnitPrice);
            decimal vatAmount = subtotal * 0.18m; // 18% VAT
            decimal total = subtotal + vatAmount;

            txtSubtotal.Text = subtotal.ToString("C2");
            txtVatAmount.Text = vatAmount.ToString("C2");
            txtTotal.Text = total.ToString("C2");
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validations
                if (cmbCustomer.SelectedValue == null || (int)cmbCustomer.SelectedValue == -1)
                {
                    MessageBox.Show("Müşteri seçilmelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbWarehouse.SelectedValue == null || (int)cmbWarehouse.SelectedValue == -1)
                {
                    MessageBox.Show("Depo seçilmelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_invoiceItems.Count == 0)
                {
                    MessageBox.Show("En az bir ürün eklenmelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnSave.Enabled = false;
                btnSave.Text = "Kaydediliyor...";

                var invoice = new CreateSalesInvoiceDto
                {
                    InvoiceDate = dtpInvoiceDate.Value,
                    CariAccountID = (int)cmbCustomer.SelectedValue,
                    WarehouseID = (int)cmbWarehouse.SelectedValue,
                    DiscountRate = 0,
                    Notes = txtNotes.Text.Trim(),
                    Details = _invoiceItems
                };

                var response = await _salesService.CreateSalesInvoiceAsync(invoice);

                if (response.Success)
                {
                    MessageBox.Show("Satış faturası başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "Kaydet";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    // Helper form for product selection
    public partial class ProductSelectionForm : Form
    {
        public ProductDto? SelectedProduct { get; private set; }
        private List<ProductDto> _products;
        private DataGridView dgvProducts;
        private Button btnSelect;
        private Button btnCancel;

        public ProductSelectionForm(List<ProductDto> products)
        {
            _products = products;
            InitializeComponent();
            LoadProducts();
        }

        private void InitializeComponent()
        {
            this.Text = "Ürün Seçimi";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            dgvProducts = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(760, 400),
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductCode", HeaderText = "Ürün Kodu", DataPropertyName = "ProductCode", Width = 120 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductName", HeaderText = "Ürün Adı", DataPropertyName = "ProductName", Width = 300 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "SalePrice", HeaderText = "Satış Fiyatı", DataPropertyName = "SalePrice", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });

            btnSelect = new Button
            {
                Text = "Seç",
                Location = new Point(620, 420),
                Size = new Size(70, 30),
                BackColor = Color.LightGreen
            };

            btnCancel = new Button
            {
                Text = "İptal",
                Location = new Point(700, 420),
                Size = new Size(70, 30),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[] { dgvProducts, btnSelect, btnCancel });

            btnSelect.Click += BtnSelect_Click;
            dgvProducts.DoubleClick += DgvProducts_DoubleClick;
        }

        private void LoadProducts()
        {
            dgvProducts.DataSource = _products;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            SelectProduct();
        }

        private void DgvProducts_DoubleClick(object sender, EventArgs e)
        {
            SelectProduct();
        }

        private void SelectProduct()
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                SelectedProduct = dgvProducts.SelectedRows[0].DataBoundItem as ProductDto;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
} 