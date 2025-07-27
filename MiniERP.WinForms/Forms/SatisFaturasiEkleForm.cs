using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class SatisFaturasiEkleForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private readonly InvoiceNumberGeneratorService _invoiceNumberGenerator;
        private readonly string _userRole;
        private readonly SalesInvoiceDto? _editingInvoice;
        private readonly bool _isEditMode;
        
        private List<CariAccountDto> _customers = new();
        private List<WarehouseDto> _warehouses = new();
        private List<ProductDto> _products = new();
        private List<SalesInvoiceDetailDto> _invoiceDetails = new();

        public SatisFaturasiEkleForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            _invoiceNumberGenerator = new InvoiceNumberGeneratorService();
            _userRole = GetPrimaryRole();
            _isEditMode = false;
            
            SetupForm();
            SetupDataGridView();
        }

        // Constructor for editing existing invoice
        public SatisFaturasiEkleForm(ApiService apiService, UserDto currentUser, SalesInvoiceDto invoice)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            _invoiceNumberGenerator = new InvoiceNumberGeneratorService();
            _userRole = GetPrimaryRole();
            _editingInvoice = invoice;
            _isEditMode = true;
            
            SetupForm();
            SetupDataGridView();
        }

        private string GetPrimaryRole()
        {
            if (_currentUser.Roles.Contains("Admin")) return "Admin";
            if (_currentUser.Roles.Contains("Manager")) return "Manager";
            if (_currentUser.Roles.Contains("Sales")) return "Sales";
            if (_currentUser.Roles.Contains("Purchase")) return "Purchase";
            if (_currentUser.Roles.Contains("Finance")) return "Finance";
            if (_currentUser.Roles.Contains("Warehouse")) return "Warehouse";
            return "Employee";
        }

        private void SetupForm()
        {
            if (_isEditMode && _editingInvoice != null)
            {
                // Edit mode - load invoice data
                this.Text = "Satış Faturası Düzenle - " + _editingInvoice.InvoiceNo;
                lblTitle.Text = "📄 SATIŞ FATURASI DÜZENLE";
                LoadInvoiceData(_editingInvoice);
            }
            else
            {
                // Add mode - set default values
                this.Text = "Yeni Satış Faturası";
                lblTitle.Text = "📄 YENİ SATIŞ FATURASI";
                dtpFaturaTarihi.Value = DateTime.Now;
                dtpVadeTarihi.Value = DateTime.Now.AddDays(30);
                
                // Generate invoice number
                txtFaturaNo.Text = _invoiceNumberGenerator.GenerateSalesInvoiceNumber();
                txtFaturaNo.ReadOnly = true;
            }
        }

        private void LoadInvoiceData(SalesInvoiceDto invoice)
        {
            txtFaturaNo.Text = invoice.InvoiceNo;
            txtFaturaNo.ReadOnly = true;
            dtpFaturaTarihi.Value = invoice.InvoiceDate;
            dtpVadeTarihi.Value = invoice.DueDate ?? DateTime.Now.AddDays(30);
            txtAciklama.Text = invoice.Description ?? "";
            
            // Set customer and warehouse will be done after loading data
        }

        private void RegenerateInvoiceNumber()
        {
            if (!_isEditMode)
            {
                txtFaturaNo.Text = _invoiceNumberGenerator.GenerateSalesInvoiceNumber();
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewDetaylar.Columns.Clear();
            dataGridViewDetaylar.AutoGenerateColumns = false;

            // Product ComboBox Column
            var productColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "ProductID",
                HeaderText = "Ürün",
                Width = 200,
                DisplayMember = "ProductName",
                ValueMember = "ProductID"
            };
            dataGridViewDetaylar.Columns.Add(productColumn);

            // Quantity Column
            dataGridViewDetaylar.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Miktar",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            // Unit Price Column
            dataGridViewDetaylar.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Birim Fiyat",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = Helpers.CurrencyHelper.GetDataGridViewCurrencyFormat() }
            });

            // VAT Rate Column
            dataGridViewDetaylar.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VatRate",
                HeaderText = "KDV %",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // Line Total Column (Read-only)
            dataGridViewDetaylar.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LineTotal",
                HeaderText = "Toplam",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = Helpers.CurrencyHelper.GetDataGridViewCurrencyFormat() }
            });

            // Delete Button Column
            var deleteColumn = new DataGridViewButtonColumn
            {
                HeaderText = "İşlem",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            dataGridViewDetaylar.Columns.Add(deleteColumn);

            // Grid settings
            dataGridViewDetaylar.EnableHeadersVisualStyles = false;
            dataGridViewDetaylar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewDetaylar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewDetaylar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewDetaylar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 248, 249);
            dataGridViewDetaylar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDetaylar.AllowUserToAddRows = false;
            dataGridViewDetaylar.RowHeadersVisible = false;
        }

        private async void SatisFaturasiEkleForm_Load(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
            await LoadWarehousesAsync();
            await LoadProductsAsync();
            
            // Edit mode ise fatura detaylarını yükle
            if (_isEditMode && _editingInvoice != null)
            {
                await LoadInvoiceDetailsAsync();
            }
        }

        private async Task LoadCustomersAsync()
        {
            try
            {
                var response = await _apiService.GetAsync<PagedResult<CariAccountDto>>("CariAccounts?pageNumber=1&pageSize=1000");
                if (response?.Success == true && response.Data != null)
                {
                    // Filter only customers
                    _customers = response.Data.Data.Where(c => c.IsCustomer).ToList();
                    
                    // If no customers found, take all active cari accounts
                    if (_customers.Count == 0)
                    {
                        _customers = response.Data.Data.Where(c => c.IsActive).ToList();
                    }
                    
                    cmbMusteri.DataSource = _customers;
                    cmbMusteri.DisplayMember = "CariName";
                    cmbMusteri.ValueMember = "CariID";
                    cmbMusteri.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müşteriler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadWarehousesAsync()
        {
            try
            {
                var response = await _apiService.GetAsync<List<WarehouseDto>>("Stock/warehouses/active");
                if (response?.Success == true && response.Data != null)
                {
                    _warehouses = response.Data;
                    
                    cmbDepo.DataSource = _warehouses;
                    cmbDepo.DisplayMember = "WarehouseName";
                    cmbDepo.ValueMember = "WarehouseID";
                    cmbDepo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Depolar yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                var response = await _apiService.GetAsync<PagedResult<ProductDto>>("Products?pageNumber=1&pageSize=1000");
                if (response?.Success == true && response.Data != null)
                {
                    _products = response.Data.Data.Where(p => p.IsActive).ToList();
                    
                    // Update product column in DataGridView
                    if (dataGridViewDetaylar.Columns[0] is DataGridViewComboBoxColumn productColumn)
                    {
                        productColumn.DataSource = _products;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadInvoiceDetailsAsync()
        {
            try
            {
                // Fatura detaylarını API'den çek - details endpoint'ini kullan
                var response = await _apiService.GetAsync<SalesInvoiceDto>($"SalesInvoices/{_editingInvoice!.InvoiceID}/details");
                if (response?.Success == true && response.Data != null)
                {
                    var invoice = response.Data;
                    
                    // Müşteri seç
                    var customer = _customers.FirstOrDefault(c => c.CariID == invoice.CariID);
                    if (customer != null)
                    {
                        cmbMusteri.SelectedValue = customer.CariID;
                        cmbMusteri.SelectedItem = customer;
                    }
                    
                    // Depo seç
                    var warehouse = _warehouses.FirstOrDefault(w => w.WarehouseID == invoice.WarehouseID);
                    if (warehouse != null)
                    {
                        cmbDepo.SelectedValue = warehouse.WarehouseID;
                        cmbDepo.SelectedItem = warehouse;
                    }
                    
                    // Fatura detaylarını yükle
                    if (invoice.Details != null && invoice.Details.Count > 0)
                    {
                        _invoiceDetails.Clear();
                        foreach (var detail in invoice.Details)
                        {
                            _invoiceDetails.Add(detail);
                        }
                        
                        // DataGridView'i güncelle
                        dataGridViewDetaylar.DataSource = null;
                        dataGridViewDetaylar.DataSource = _invoiceDetails;
                        
                        // Toplamları hesapla
                        CalculateTotals();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura detayları yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSatirEkle_Click(object sender, EventArgs e)
        {
            var newDetail = new SalesInvoiceDetailDto
            {
                ProductID = 0,
                Quantity = 1,
                UnitPrice = 0,
                VatRate = 18,
                LineTotal = 0
            };

            _invoiceDetails.Add(newDetail);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            // Temporarily disable events to prevent loops
            dataGridViewDetaylar.CellValueChanged -= dataGridViewDetaylar_CellValueChanged;
            
            dataGridViewDetaylar.Rows.Clear();
            
            foreach (var detail in _invoiceDetails)
            {
                var rowIndex = dataGridViewDetaylar.Rows.Add();
                var row = dataGridViewDetaylar.Rows[rowIndex];
                
                // Set values safely
                try
                {
                    // Product ComboBox - only set if product exists in list
                    if (detail.ProductID > 0 && _products.Any(p => p.ProductID == detail.ProductID))
                    {
                        row.Cells[0].Value = detail.ProductID;
                    }
                    
                    row.Cells[1].Value = detail.Quantity;
                    row.Cells[2].Value = detail.UnitPrice;
                    row.Cells[3].Value = detail.VatRate;
                    row.Cells[4].Value = detail.LineTotal;
                    row.Cells[5].Value = "Sil";
                }
                catch
                {
                    // If there's an error setting ComboBox value, leave it empty
                    row.Cells[1].Value = detail.Quantity;
                    row.Cells[2].Value = detail.UnitPrice;
                    row.Cells[3].Value = detail.VatRate;
                    row.Cells[4].Value = detail.LineTotal;
                    row.Cells[5].Value = "Sil";
                }
            }
            
            // Re-enable events
            dataGridViewDetaylar.CellValueChanged += dataGridViewDetaylar_CellValueChanged;
            
            CalculateTotals();
        }

        private void dataGridViewDetaylar_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = dataGridViewDetaylar.Rows[e.RowIndex];
                var detail = _invoiceDetails[e.RowIndex];

                // Update the detail object
                switch (e.ColumnIndex)
                {
                    case 0: // Product
                        if (row.Cells[0].Value != null)
                        {
                            var productId = Convert.ToInt32(row.Cells[0].Value);
                            var product = _products.FirstOrDefault(p => p.ProductID == productId);
                            if (product != null)
                            {
                                detail.ProductID = product.ProductID;
                                detail.ProductName = product.ProductName;
                                detail.UnitPrice = product.SalePrice;
                                detail.VatRate = product.VatRate;
                                
                                // Update the row with product values
                                row.Cells[2].Value = product.SalePrice; // Unit Price
                                row.Cells[3].Value = product.VatRate;   // VAT Rate
                            }
                        }
                        break;
                    case 1: // Quantity
                        if (row.Cells[1].Value != null)
                        {
                            detail.Quantity = Convert.ToDecimal(row.Cells[1].Value);
                        }
                        break;
                    case 2: // Unit Price
                        if (row.Cells[2].Value != null)
                        {
                            detail.UnitPrice = Convert.ToDecimal(row.Cells[2].Value);
                        }
                        break;
                    case 3: // VAT Rate
                        if (row.Cells[3].Value != null)
                        {
                            detail.VatRate = Convert.ToDecimal(row.Cells[3].Value);
                        }
                        break;
                }

                // Calculate line total
                detail.LineTotal = detail.Quantity * detail.UnitPrice * (1 + detail.VatRate / 100);
                row.Cells[4].Value = detail.LineTotal; // Update Total column

                CalculateTotals();
            }
        }

        private void dataGridViewDetaylar_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5) // Delete button column
            {
                var result = MessageBox.Show("Bu satırı silmek istediğinizden emin misiniz?", 
                    "Satır Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _invoiceDetails.RemoveAt(e.RowIndex);
                    RefreshGrid();
                }
            }
        }

        private void CalculateTotals()
        {
            decimal subTotal = _invoiceDetails.Sum(d => d.Quantity * d.UnitPrice);
            decimal vatAmount = _invoiceDetails.Sum(d => d.Quantity * d.UnitPrice * d.VatRate / 100);
            decimal total = subTotal + vatAmount;

            lblAraToplam.Text = Helpers.CurrencyHelper.FormatCurrency(subTotal);
            lblKDV.Text = Helpers.CurrencyHelper.FormatCurrency(vatAmount);
            lblGenelToplam.Text = Helpers.CurrencyHelper.FormatCurrency(total);
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                btnKaydet.Enabled = false;
                btnKaydet.Text = _isEditMode ? "Güncelleniyor..." : "Kaydediliyor...";

                if (_isEditMode && _editingInvoice != null)
                {
                    // Edit mode - PUT API kullan
                    var updateDto = new UpdateSalesInvoiceDto
                    {
                        CariID = cmbMusteri.SelectedValue != null ? (int)cmbMusteri.SelectedValue : 0,
                        WarehouseID = cmbDepo.SelectedValue != null ? (int)cmbDepo.SelectedValue : 0,
                        InvoiceDate = dtpFaturaTarihi.Value,
                        DueDate = dtpVadeTarihi.Value,
                        Description = txtAciklama.Text,
                        Details = _invoiceDetails.Select(d => new CreateSalesInvoiceDetailDto
                        {
                            ProductID = d.ProductID,
                            Quantity = d.Quantity,
                            UnitPrice = d.UnitPrice,
                            VatRate = d.VatRate,
                            Description = d.Description
                        }).ToList()
                    };

                    var response = await _apiService.PutAsync<SalesInvoiceDto>($"SalesInvoices/{_editingInvoice.InvoiceID}", updateDto);

                    if (response?.Success == true)
                    {
                        MessageBox.Show("Satış faturası başarıyla güncellendi.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(response?.Message ?? "Fatura güncellenirken hata oluştu.", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Add mode - POST API kullan
                    var createDto = new CreateSalesInvoiceDto
                    {
                        InvoiceNo = txtFaturaNo.Text,
                        CariID = cmbMusteri.SelectedValue != null ? (int)cmbMusteri.SelectedValue : 0,
                        WarehouseID = cmbDepo.SelectedValue != null ? (int)cmbDepo.SelectedValue : 0,
                        InvoiceDate = dtpFaturaTarihi.Value,
                        DueDate = dtpVadeTarihi.Value,
                        Description = txtAciklama.Text,
                        Details = _invoiceDetails.Select(d => new CreateSalesInvoiceDetailDto
                        {
                            ProductID = d.ProductID,
                            Quantity = d.Quantity,
                            UnitPrice = d.UnitPrice,
                            VatRate = d.VatRate,
                            Description = d.Description
                        }).ToList()
                    };

                    var response = await _apiService.PostAsync<SalesInvoiceDto>("SalesInvoices", createDto);

                    if (response?.Success == true)
                    {
                        MessageBox.Show("Satış faturası başarıyla oluşturuldu.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(response?.Message ?? "Fatura oluşturulurken hata oluştu.", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura oluşturulurken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnKaydet.Enabled = true;
                btnKaydet.Text = "💾 Kaydet";
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFaturaNo.Text))
            {
                MessageBox.Show("Fatura numarası boş olamaz.", "Doğrulama Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbMusteri.SelectedValue == null)
            {
                MessageBox.Show("Müşteri seçiniz.", "Doğrulama Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMusteri.Focus();
                return false;
            }

            if (cmbDepo.SelectedValue == null)
            {
                MessageBox.Show("Depo seçiniz.", "Doğrulama Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepo.Focus();
                return false;
            }

            if (_invoiceDetails.Count == 0)
            {
                MessageBox.Show("En az bir ürün ekleyiniz.", "Doğrulama Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (var detail in _invoiceDetails)
            {
                if (detail.ProductID == 0)
                {
                    MessageBox.Show("Tüm satırlarda ürün seçilmelidir.", "Doğrulama Hatası", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (detail.Quantity <= 0)
                {
                    MessageBox.Show("Miktar sıfırdan büyük olmalıdır.", "Doğrulama Hatası", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (detail.UnitPrice <= 0)
                {
                    MessageBox.Show("Birim fiyat sıfırdan büyük olmalıdır.", "Doğrulama Hatası", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Fatura oluşturma işlemini iptal etmek istediğinizden emin misiniz?", 
                "İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

    }
}


