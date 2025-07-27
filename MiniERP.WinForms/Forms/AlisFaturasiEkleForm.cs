using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System.ComponentModel;
using MiniERP.WinForms.Models;

namespace MiniERP.WinForms.Forms
{
    public partial class AlisFaturasiEkleForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private readonly InvoiceNumberGeneratorService _invoiceNumberGenerator;
        private List<CariAccountDto> _suppliers = new();
        private List<WarehouseDto> _warehouses = new();
        private List<ProductDto> _products = new();
        private BindingList<PurchaseInvoiceDetailItem> _invoiceDetails = new();
        private bool _isEditMode = false;
        private PurchaseInvoiceDto? _editingInvoice;

        // Event for notifying parent when invoice is created
        public event EventHandler? InvoiceCreated;

        public AlisFaturasiEkleForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            _invoiceNumberGenerator = new InvoiceNumberGeneratorService();
            
            InitializeForm();
            LoadComboBoxData();
            
            // Form gösterildikten sonra grid başlıklarını kontrol et
            this.Shown += (s, e) => EnsureGridHeaders();
        }

        // Edit constructor
        public AlisFaturasiEkleForm(UserDto currentUser, ApiService apiService, PurchaseInvoiceDto invoice)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            _invoiceNumberGenerator = new InvoiceNumberGeneratorService();
            _editingInvoice = invoice;
            _isEditMode = true;
            
            InitializeForm();
            LoadComboBoxData();
            LoadInvoiceForEdit();
            
            // Form gösterildikten sonra grid başlıklarını kontrol et
            this.Shown += (s, e) => EnsureGridHeaders();
        }

        private void InitializeForm()
        {
            // Set default values
            dtpFaturaTarihi.Value = DateTime.Now;
            dtpVadeTarihi.Value = DateTime.Now.AddDays(30); // 30 gün vade
            
            // Generate invoice number using service
            if (!_isEditMode)
            {
                txtFaturaNo.Text = _invoiceNumberGenerator.GeneratePurchaseInvoiceNumber();
                txtFaturaNo.ReadOnly = true;
            }
            
            SetupDataGridView();
        }

        private async void LoadComboBoxData()
        {
            try
            {
                // Show loading status
                this.Cursor = Cursors.WaitCursor;
                
                // Load suppliers
                try
                {
                    var cariResponse = await _apiService.GetAsync<List<CariAccountDto>>("CariAccounts/suppliers");
                    
                    if (cariResponse.Success && cariResponse.Data != null)
                    {
                        _suppliers = cariResponse.Data;
                        
                        cmbTedarikci.DataSource = _suppliers;
                        cmbTedarikci.ValueMember = "CariAccountID";
                        cmbTedarikci.DisplayMember = "CariName";
                        cmbTedarikci.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Tedarikçiler yüklenirken hata oluştu: {ex.Message}");
                }

                // Load warehouses
                try
                {
                    var warehouseResponse = await _apiService.GetAsync<List<WarehouseDto>>("Stock/warehouses/active");
                    
                    if (warehouseResponse.Success && warehouseResponse.Data != null)
                    {
                        _warehouses = warehouseResponse.Data;
                        
                        cmbDepo.DataSource = _warehouses;
                        cmbDepo.ValueMember = "WarehouseID";
                        cmbDepo.DisplayMember = "WarehouseName";
                        cmbDepo.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Depolar yüklenirken hata oluştu: {ex.Message}");
                }

                // Load products
                try
                {
                    var productResponse = await _apiService.GetAsync<PagedResult<ProductDto>>("Products?pageSize=1000");
                    
                    if (productResponse.Success && productResponse.Data != null)
                    {
                        _products = productResponse.Data.Data;
                        UpdateProductColumnDataSource();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ürünler yüklenirken hata oluştu: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                
                // Edit mode ise verileri yükle
                if (_isEditMode)
                {
                    SetEditModeValues();
                }
                
                // Grid başlıklarını yeniden ayarla (herhangi bir sorun varsa)
                EnsureGridHeaders();
            }
        }

        private void UpdateProductColumnDataSource()
        {
            if (dataGridViewKalemler.Columns[0] is DataGridViewComboBoxColumn productColumn)
            {
                productColumn.DataSource = _products;
            }
        }

        private void EnsureGridHeaders()
        {
            System.Diagnostics.Debug.WriteLine("EnsureGridHeaders called");
            System.Diagnostics.Debug.WriteLine($"Column count: {dataGridViewKalemler.Columns.Count}");
            
            // Eğer sütun başlıkları kaybolmuşsa yeniden ayarla
            if (dataGridViewKalemler.Columns.Count > 0)
            {
                if (dataGridViewKalemler.Columns.Count >= 6)
                {
                    dataGridViewKalemler.Columns[0].HeaderText = "Ürün";
                    dataGridViewKalemler.Columns[1].HeaderText = "Miktar";
                    dataGridViewKalemler.Columns[2].HeaderText = "Birim Fiyat";
                    dataGridViewKalemler.Columns[3].HeaderText = "KDV %";
                    dataGridViewKalemler.Columns[4].HeaderText = "Toplam";
                    dataGridViewKalemler.Columns[5].HeaderText = "İşlem";
                    
                    System.Diagnostics.Debug.WriteLine("Grid headers set successfully");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Not enough columns: {dataGridViewKalemler.Columns.Count}");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No columns found, calling SetupDataGridView");
                SetupDataGridView();
            }
        }

        private void SetupDataGridView()
        {
            System.Diagnostics.Debug.WriteLine("SetupDataGridView called");
            
            dataGridViewKalemler.Columns.Clear();
            dataGridViewKalemler.AutoGenerateColumns = false;

            // Product ComboBox Column - WITH DataPropertyName
            var productColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "ProductID",
                HeaderText = "Ürün",
                Width = 200,
                DisplayMember = "ProductName",
                ValueMember = "ProductID"
            };
            dataGridViewKalemler.Columns.Add(productColumn);

            // Quantity Column
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Miktar",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            // Unit Price Column
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Birim Fiyat",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            // VAT Rate Column
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VatRate",
                HeaderText = "KDV %",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // Line Total Column (Read-only)
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LineTotal",
                HeaderText = "Toplam",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            // Delete Button Column
            var deleteColumn = new DataGridViewButtonColumn
            {
                HeaderText = "İşlem",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            dataGridViewKalemler.Columns.Add(deleteColumn);

            // Grid settings - EXACTLY like SatisFaturasi
            dataGridViewKalemler.EnableHeadersVisualStyles = false;
            dataGridViewKalemler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewKalemler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewKalemler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewKalemler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 248, 249);
            dataGridViewKalemler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKalemler.AllowUserToAddRows = false;
            dataGridViewKalemler.RowHeadersVisible = false;

            // Events
            dataGridViewKalemler.CellValueChanged += DataGridViewKalemler_CellValueChanged;
            dataGridViewKalemler.CellClick += DataGridViewKalemler_CellClick;
            dataGridViewKalemler.CurrentCellDirtyStateChanged += DataGridViewKalemler_CurrentCellDirtyStateChanged;
            dataGridViewKalemler.DataError += DataGridViewKalemler_DataError;
            
            // Final check for headers - debug
            System.Diagnostics.Debug.WriteLine($"Headers visible: {dataGridViewKalemler.ColumnHeadersVisible}");
            System.Diagnostics.Debug.WriteLine($"Column count after setup: {dataGridViewKalemler.Columns.Count}");
            for (int i = 0; i < dataGridViewKalemler.Columns.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine($"Column {i}: '{dataGridViewKalemler.Columns[i].HeaderText}'");
            }
        }

        private void DataGridViewKalemler_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            // Handle ComboBox value errors gracefully
            e.ThrowException = false;
            e.Cancel = false;
        }

        private void DataGridViewKalemler_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dataGridViewKalemler.IsCurrentCellDirty)
            {
                dataGridViewKalemler.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridViewKalemler_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _invoiceDetails.Count) return;

            var detail = _invoiceDetails[e.RowIndex];

            // Get the row
            var row = dataGridViewKalemler.Rows[e.RowIndex];

            // Update the detail object based on which column changed
            switch (e.ColumnIndex)
            {
                case 0: // Product
                    if (row.Cells[0].Value != null)
                    {
                        var productId = Convert.ToInt32(row.Cells[0].Value);
                        var product = _products.FirstOrDefault(p => p.ProductID == productId);
                        if (product != null)
                        {
                            detail.ProductID = productId;
                            detail.UnitPrice = product.SalePrice; // Or PurchasePrice if available
                            detail.VatRate = 20; // Default VAT rate
                            
                            // Update UI
                            row.Cells[2].Value = detail.UnitPrice;
                            row.Cells[3].Value = detail.VatRate;
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

            // Recalculate line total
            CalculateLineTotal(detail);
            
            // Update UI with calculated values
            row.Cells[4].Value = detail.LineTotal;
            
            // Recalculate invoice totals
            CalculateTotals();
        }

        private void CalculateLineTotal(PurchaseInvoiceDetailItem detail)
        {
            var netAmount = detail.Quantity * detail.UnitPrice;
            detail.VatAmount = netAmount * (detail.VatRate / 100);
            detail.LineTotal = netAmount + detail.VatAmount;
        }

        private void CalculateTotals()
        {
            decimal subTotal = _invoiceDetails.Sum(d => d.Quantity * d.UnitPrice);
            decimal vatAmount = _invoiceDetails.Sum(d => d.Quantity * d.UnitPrice * d.VatRate / 100);
            decimal total = subTotal + vatAmount;

            lblAraToplam.Text = subTotal.ToString("N2") + " TL";
            lblKdvTutari.Text = vatAmount.ToString("N2") + " TL";
            lblGenelToplam.Text = total.ToString("N2") + " TL";
        }

        private void DataGridViewKalemler_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5) // Delete column is index 5
            {
                var result = MessageBox.Show("Bu kalemi silmek istediğinizden emin misiniz?", 
                    "Kalem Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    _invoiceDetails.RemoveAt(e.RowIndex);
                    RefreshGrid();
                }
            }
        }

        private void btnKalemEkle_Click(object? sender, EventArgs e)
        {
            try
            {
                // Ensure products are loaded before adding new row
                if (_products == null || !_products.Any())
                {
                    MessageBox.Show("Önce ürünler yüklenmelidir. Lütfen bekleyin.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newDetail = new PurchaseInvoiceDetailItem
                {
                    ProductID = 0,
                    Quantity = 1,
                    UnitPrice = 0,
                    VatRate = 20,
                    VatAmount = 0,
                    LineTotal = 0
                };

                _invoiceDetails.Add(newDetail);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kalem eklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrid()
        {
            // Temporarily disable events to prevent loops
            dataGridViewKalemler.CellValueChanged -= DataGridViewKalemler_CellValueChanged;
            
            dataGridViewKalemler.Rows.Clear();
            
            foreach (var detail in _invoiceDetails)
            {
                var rowIndex = dataGridViewKalemler.Rows.Add();
                var row = dataGridViewKalemler.Rows[rowIndex];
                
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
            dataGridViewKalemler.CellValueChanged += DataGridViewKalemler_CellValueChanged;
            
            CalculateTotals();
        }

        private async void btnKaydet_Click(object? sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                if (_isEditMode && _editingInvoice != null)
                {
                    // Edit mode - PUT request
                    var updateDto = new UpdatePurchaseInvoiceDto
                    {
                        CariID = (int)cmbTedarikci.SelectedValue!,
                        WarehouseID = (int)cmbDepo.SelectedValue!,
                        InvoiceDate = dtpFaturaTarihi.Value,
                        DueDate = dtpVadeTarihi.Value,
                        Description = txtAciklama.Text,
                        Details = _invoiceDetails.Where(d => d.ProductID > 0).Select(d => new CreatePurchaseInvoiceDetailDto
                        {
                            ProductID = d.ProductID,
                            Quantity = d.Quantity,
                            UnitPrice = d.UnitPrice,
                            VatRate = d.VatRate
                        }).ToList()
                    };

                    var result = await _apiService.PutAsync<object>($"PurchaseInvoices/{_editingInvoice.InvoiceID}", updateDto);
                    
                    if (result.Success)
                    {
                        MessageBox.Show("Alış faturası başarıyla güncellendi.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Fatura güncellenemedi: {result.Message}", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Create mode - POST request
                    var invoice = new CreatePurchaseInvoiceDto
                    {
                        InvoiceNo = txtFaturaNo.Text,
                        InvoiceDate = dtpFaturaTarihi.Value,
                        DueDate = dtpVadeTarihi.Value,
                        CariID = (int)cmbTedarikci.SelectedValue!,
                        WarehouseID = (int)cmbDepo.SelectedValue!,
                        Description = txtAciklama.Text,
                        Details = _invoiceDetails.Where(d => d.ProductID > 0).Select(d => new CreatePurchaseInvoiceDetailDto
                        {
                            ProductID = d.ProductID,
                            Quantity = d.Quantity,
                            UnitPrice = d.UnitPrice,
                            VatRate = d.VatRate
                        }).ToList()
                    };

                    var result = await _apiService.PostAsync<object>("PurchaseInvoices", invoice);
                    
                    if (result.Success)
                    {
                        MessageBox.Show("Alış faturası başarıyla kaydedildi.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InvoiceCreated?.Invoke(this, EventArgs.Empty);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Fatura kaydedilemedi: {result.Message}", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                string operation = _isEditMode ? "güncellenirken" : "kaydedilirken";
                MessageBox.Show($"Fatura {operation} hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFaturaNo.Text))
            {
                MessageBox.Show("Fatura numarası boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFaturaNo.Focus();
                return false;
            }

            if (cmbTedarikci.SelectedValue == null || (int)cmbTedarikci.SelectedValue <= 0)
            {
                MessageBox.Show("Tedarikçi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTedarikci.Focus();
                return false;
            }

            if (cmbDepo.SelectedValue == null || (int)cmbDepo.SelectedValue <= 0)
            {
                MessageBox.Show("Depo seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepo.Focus();
                return false;
            }

            if (!_invoiceDetails.Any(d => d.ProductID > 0))
            {
                MessageBox.Show("En az bir kalem eklemelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnIptal_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadInvoiceForEdit()
        {
            if (_editingInvoice == null) return;

            // Form title'ını güncelle
            this.Text = $"Alış Faturası Düzenle - {_editingInvoice.InvoiceNo}";

            // Form verilerini doldur
            txtFaturaNo.Text = _editingInvoice.InvoiceNo;
            dtpFaturaTarihi.Value = _editingInvoice.InvoiceDate;
            dtpVadeTarihi.Value = _editingInvoice.DueDate ?? DateTime.Now.AddDays(30);
            txtAciklama.Text = _editingInvoice.Description ?? "";

            // ComboBox'ları ayarla (veriler yüklendikten sonra)
            // Bu işlem LoadComboBoxData tamamlandıktan sonra yapılacak
        }

        private void SetEditModeValues()
        {
            if (_editingInvoice == null) return;

            // Tedarikçi seç
            if (_editingInvoice.CariID > 0)
            {
                cmbTedarikci.SelectedValue = _editingInvoice.CariID;
            }

            // Depo seç
            if (_editingInvoice.WarehouseID > 0)
            {
                cmbDepo.SelectedValue = _editingInvoice.WarehouseID;
            }

            // Fatura detaylarını yükle
            if (_editingInvoice.Details != null)
            {
                _invoiceDetails.Clear();
                foreach (var detail in _editingInvoice.Details)
                {
                    _invoiceDetails.Add(new PurchaseInvoiceDetailItem
                    {
                        ProductID = detail.ProductID,
                        Quantity = detail.Quantity,
                        UnitPrice = detail.UnitPrice,
                        VatRate = detail.VatRate,
                        VatAmount = detail.VatAmount,
                        LineTotal = detail.LineTotal
                    });
                }
                RefreshGrid();
            }
        }

        // ...existing code...
    }
}


