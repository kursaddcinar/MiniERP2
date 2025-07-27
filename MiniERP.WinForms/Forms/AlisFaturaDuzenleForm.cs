using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System.ComponentModel;
using MiniERP.WinForms.Models;

namespace MiniERP.WinForms.Forms
{
    public partial class AlisFaturaDuzenleForm : Form
    {
        private readonly ApiService _apiService;
        private readonly UserDto _currentUser;
        private readonly PurchaseInvoiceDto _invoice;
        private List<CariAccountDto> _suppliers = new();
        private List<WarehouseDto> _warehouses = new();
        private List<ProductDto> _products = new();
        private List<PurchaseInvoiceDetailItem> _invoiceDetails = new();

        // Event for notifying parent when invoice is updated
        public event EventHandler? InvoiceUpdated;

        public AlisFaturaDuzenleForm(UserDto currentUser, ApiService apiService, PurchaseInvoiceDto invoice)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            _invoice = invoice;
            
            InitializeForm();
            LoadInvoiceForEdit();
        }

        private async void AlisFaturaDuzenleForm_Load(object sender, EventArgs e)
        {
            await LoadComboBoxData();
            
            // Fatura detaylarını yükle
            await LoadInvoiceDetails();
            
            // Form verilerini ayarla (ComboBox verileri yüklendikten sonra)
            SetEditModeValues();
        }

        private void InitializeForm()
        {
            // Set form title
            this.Text = $"Alış Faturası Düzenle - {_invoice.InvoiceNo}";
            
            // Setup durum ComboBox
            SetupDurumComboBox();
            
            SetupDataGridView();
        }

        private void SetupDurumComboBox()
        {
            cmbDurum.Items.Clear();
            cmbDurum.Items.Add(new { Text = "Taslak", Value = "DRAFT" });
            cmbDurum.Items.Add(new { Text = "Onaylandı", Value = "APPROVED" });
            cmbDurum.Items.Add(new { Text = "İptal Edildi", Value = "CANCELLED" });
            
            cmbDurum.DisplayMember = "Text";
            cmbDurum.ValueMember = "Value";
        }

        private async Task LoadComboBoxData()
        {
            try
            {
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
                
                // Ürün kolonunun datasource'unu güncelle
                UpdateProductColumnDataSource();
                
                // ComboBox verileri yüklendikten sonra fatura verilerini ayarla - KALDIRILDI
                // SetEditModeValues(); // Bu artık Form_Load'da yapılacak
            }
        }

        private void LoadInvoiceForEdit()
        {
            if (_invoice == null) return;

            // Form verilerini doldur
            txtFaturaNo.Text = _invoice.InvoiceNo;
            dtpFaturaTarihi.Value = _invoice.InvoiceDate;
            dtpVadeTarihi.Value = _invoice.DueDate ?? DateTime.Now.AddDays(30);
            txtAciklama.Text = _invoice.Description ?? "";
        }

        private void SetEditModeValues()
        {
            if (_invoice == null) return;

            try
            {
                // Tedarikçi seç
                if (_invoice.CariID > 0 && _suppliers.Any())
                {
                    cmbTedarikci.SelectedValue = _invoice.CariID;
                    if (cmbTedarikci.SelectedValue == null)
                    {
                        // Debug: Tedarikçi seçilemedi
                        var supplier = _suppliers.FirstOrDefault(s => s.CariAccountID == _invoice.CariID);
                        if (supplier != null)
                        {
                            cmbTedarikci.SelectedItem = supplier;
                        }
                    }
                }

                // Depo seç
                if (_invoice.WarehouseID > 0 && _warehouses.Any())
                {
                    cmbDepo.SelectedValue = _invoice.WarehouseID;
                    if (cmbDepo.SelectedValue == null)
                    {
                        // Debug: Depo seçilemedi
                        var warehouse = _warehouses.FirstOrDefault(w => w.WarehouseID == _invoice.WarehouseID);
                        if (warehouse != null)
                        {
                            cmbDepo.SelectedItem = warehouse;
                        }
                    }
                }

                // Durum seç
                if (!string.IsNullOrEmpty(_invoice.Status))
                {
                    for (int i = 0; i < cmbDurum.Items.Count; i++)
                    {
                        var item = cmbDurum.Items[i];
                        if (item != null)
                        {
                            var value = item.GetType().GetProperty("Value")?.GetValue(item)?.ToString();
                            if (value == _invoice.Status)
                            {
                                cmbDurum.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form değerleri ayarlanırken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Fatura detayları Form_Load'da yüklenecek
        }

        private async Task LoadInvoiceDetails()
        {
            try
            {
                _invoiceDetails.Clear();

                // Fatura detaylarını API'den çek - details endpoint'ini kullan
                var response = await _apiService.GetAsync<PurchaseInvoiceDto>($"PurchaseInvoices/{_invoice.InvoiceID}/details");
                if (response?.Success == true && response.Data != null)
                {
                    var invoice = response.Data;
                    
                    // Fatura detaylarını yükle
                    if (invoice.Details != null && invoice.Details.Count > 0)
                    {
                        foreach (var detail in invoice.Details)
                        {
                            // Ürün bilgilerini API'den al
                            var product = _products?.FirstOrDefault(p => p.ProductID == detail.ProductID);
                            
                            _invoiceDetails.Add(new PurchaseInvoiceDetailItem
                            {
                                ProductID = detail.ProductID,
                                ProductCode = detail.ProductCode,
                                ProductName = detail.ProductName,
                                UnitName = product?.UnitName ?? "Adet",
                                Quantity = detail.Quantity,
                                UnitPrice = detail.UnitPrice,
                                VatRate = detail.VatRate,
                                VatAmount = detail.VatAmount,
                                LineTotal = detail.LineTotal
                            });
                        }
                        
                        // DataGridView'i güncelle - SATIŞTA OLDUĞU GİBİ
                        RefreshGrid();
                        
                        // Toplamları hesapla
                        CalculateTotals();
                    }
                    else
                    {
                        // Detay yok, boş grid göster
                        RefreshGrid();
                    }
                }
                else
                {
                    // Fallback: Fatura ile gelen detayları kontrol et
                    if (_invoice.Details != null && _invoice.Details.Any())
                    {
                        foreach (var detail in _invoice.Details)
                        {
                            // Ürün bilgilerini API'den al
                            var product = _products?.FirstOrDefault(p => p.ProductID == detail.ProductID);
                            
                            _invoiceDetails.Add(new PurchaseInvoiceDetailItem
                            {
                                ProductID = detail.ProductID,
                                ProductCode = detail.ProductCode,
                                ProductName = detail.ProductName,
                                UnitName = product?.UnitName ?? "Adet",
                                Quantity = detail.Quantity,
                                UnitPrice = detail.UnitPrice,
                                VatRate = detail.VatRate,
                                VatAmount = detail.VatAmount,
                                LineTotal = detail.LineTotal
                            });
                        }
                        
                        // DataGridView'i güncelle - SATIŞTA OLDUĞU GİBİ
                        RefreshGrid();
                        
                        // Toplamları hesapla
                        CalculateTotals();
                    }
                    else
                    {
                        // Detay yok, boş grid göster
                        RefreshGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura detayları yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Hata durumunda da boş grid göster
                RefreshGrid();
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewKalemler.Columns.Clear();
            dataGridViewKalemler.AutoGenerateColumns = false;
            dataGridViewKalemler.AllowUserToAddRows = false;

            // Ürün column (ComboBox)
            var productColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "ProductID",
                HeaderText = "Ürün",
                Width = 250,
                DataSource = _products,
                ValueMember = "ProductID",
                DisplayMember = "ProductName"
            };
            dataGridViewKalemler.Columns.Add(productColumn);

            // Miktar
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Miktar",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Birim
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitName",
                HeaderText = "Birim",
                Width = 60,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Birim Fiyat
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Birim Fiyat",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = Helpers.CurrencyHelper.GetDataGridViewCurrencyFormat(), Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // KDV %
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VatRate",
                HeaderText = "KDV %",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Tutar
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LineTotal",
                HeaderText = "Tutar",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = Helpers.CurrencyHelper.GetDataGridViewCurrencyFormat(), Alignment = DataGridViewContentAlignment.MiddleRight },
                ReadOnly = true
            });

            // İşlem (Sil) button
            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "İşlem",
                Text = "Sil",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            dataGridViewKalemler.Columns.Add(deleteButtonColumn);

            // Grid styling
            dataGridViewKalemler.EnableHeadersVisualStyles = false;
            dataGridViewKalemler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewKalemler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewKalemler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewKalemler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 248, 249);
            dataGridViewKalemler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKalemler.RowHeadersVisible = false;

            // Events
            dataGridViewKalemler.CellValueChanged += DataGridViewKalemler_CellValueChanged;
            dataGridViewKalemler.CellClick += DataGridViewKalemler_CellClick;
            dataGridViewKalemler.DataError += DataGridViewKalemler_DataError;
            dataGridViewKalemler.CurrentCellDirtyStateChanged += DataGridViewKalemler_CurrentCellDirtyStateChanged;
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

        private void UpdateProductColumnDataSource()
        {
            if (dataGridViewKalemler.Columns.Count > 0 && dataGridViewKalemler.Columns[0] is DataGridViewComboBoxColumn productColumn)
            {
                productColumn.DataSource = _products;
                productColumn.ValueMember = "ProductID";
                productColumn.DisplayMember = "ProductName";
            }
        }

        private void RefreshGrid()
        {
            // DataGridView'i güncelle - SATIŞTA OLDUĞU GİBİ
            dataGridViewKalemler.DataSource = null;
            dataGridViewKalemler.DataSource = _invoiceDetails;
            
            CalculateTotals();
        }

        private void DataGridViewKalemler_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _invoiceDetails.Count) return;

            var detail = _invoiceDetails[e.RowIndex];
            var row = dataGridViewKalemler.Rows[e.RowIndex];

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
                            detail.ProductCode = product.ProductCode;
                            detail.ProductName = product.ProductName;
                            detail.UnitName = product.UnitName ?? "Adet";
                            detail.UnitPrice = product.PurchasePrice > 0 ? product.PurchasePrice : product.SalePrice;
                            detail.VatRate = 20; // Default KDV
                            
                            // Update UI
                            row.Cells[2].Value = detail.UnitName;
                            row.Cells[3].Value = detail.UnitPrice;
                            row.Cells[4].Value = detail.VatRate;
                        }
                    }
                    break;
                case 1: // Quantity
                    if (row.Cells[1].Value != null && decimal.TryParse(row.Cells[1].Value.ToString(), out decimal quantity))
                    {
                        detail.Quantity = quantity;
                    }
                    break;
                case 3: // Unit Price (birim sütunu readonly olduğu için 2 değil 3)
                    if (row.Cells[3].Value != null && decimal.TryParse(row.Cells[3].Value.ToString(), out decimal unitPrice))
                    {
                        detail.UnitPrice = unitPrice;
                    }
                    break;
                case 4: // VAT Rate
                    if (row.Cells[4].Value != null && decimal.TryParse(row.Cells[4].Value.ToString(), out decimal vatRate))
                    {
                        detail.VatRate = vatRate;
                    }
                    break;
            }

            // Calculate line total
            var subTotal = detail.Quantity * detail.UnitPrice;
            var vatAmount = subTotal * (detail.VatRate / 100);
            detail.VatAmount = vatAmount;
            detail.LineTotal = subTotal + vatAmount;

            // Update UI with calculated values
            row.Cells[5].Value = detail.LineTotal;

            CalculateTotals();
        }

        private void DataGridViewKalemler_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 6) // Sil butonu (son kolon)
            {
                if (e.RowIndex < _invoiceDetails.Count)
                {
                    _invoiceDetails.RemoveAt(e.RowIndex);
                    RefreshGrid(); // DataSource kullanacak
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
                    LineTotal = 0,
                    UnitName = "Adet"
                };

                _invoiceDetails.Add(newDetail);
                RefreshGrid(); // DataSource kullanacak
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kalem eklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotals()
        {
            var subTotal = _invoiceDetails.Sum(d => d.Quantity * d.UnitPrice);
            var vatAmount = _invoiceDetails.Sum(d => d.VatAmount);
            var total = subTotal + vatAmount;

            lblAraToplam.Text = Helpers.CurrencyHelper.FormatCurrency(subTotal);
            lblKdvTutari.Text = Helpers.CurrencyHelper.FormatCurrency(vatAmount);
            lblGenelToplam.Text = Helpers.CurrencyHelper.FormatCurrency(total);
        }

        private async void btnGuncelle_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                    return;

                this.Cursor = Cursors.WaitCursor;

                // Get selected status
                var selectedStatus = cmbDurum.SelectedItem;
                var statusValue = selectedStatus?.GetType().GetProperty("Value")?.GetValue(selectedStatus)?.ToString() ?? "DRAFT";

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
                        VatRate = d.VatRate,
                        Description = ""
                    }).ToList()
                };

                var result = await _apiService.PutAsync<object>($"PurchaseInvoices/{_invoice.InvoiceID}", updateDto);
                
                if (result.Success)
                {
                    MessageBox.Show("Fatura başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InvoiceUpdated?.Invoke(this, EventArgs.Empty);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Fatura güncellenirken hata oluştu: {result.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura güncellenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFaturaNo.Text))
            {
                MessageBox.Show("Fatura numarası boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbTedarikci.SelectedValue == null)
            {
                MessageBox.Show("Tedarikçi seçilmelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbDepo.SelectedValue == null)
            {
                MessageBox.Show("Depo seçilmelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_invoiceDetails.Any(d => d.ProductID > 0))
            {
                MessageBox.Show("En az bir kalem eklenmelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnGeri_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}


