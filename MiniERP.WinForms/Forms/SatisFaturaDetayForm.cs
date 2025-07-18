using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class SatisFaturaDetayForm : Form
    {
        private readonly ApiService _apiService;
        private readonly UserDto _currentUser;
        private readonly SalesInvoiceDto _invoice;
        private List<SalesInvoiceDetailDto> _invoiceDetails = new();

        public SatisFaturaDetayForm(ApiService apiService, UserDto currentUser, SalesInvoiceDto invoice)
        {
            InitializeComponent();
            _apiService = apiService;
            _currentUser = currentUser;
            _invoice = invoice;
            
            // Debug bilgisi
            System.Diagnostics.Debug.WriteLine($"Invoice received: {invoice.InvoiceNo}, Details count: {invoice.Details?.Count ?? 0}");
            System.Diagnostics.Debug.WriteLine($"Customer: {invoice.CariName}, Warehouse: {invoice.WarehouseName}");
            System.Diagnostics.Debug.WriteLine($"Totals: SubTotal={invoice.SubTotal}, VatAmount={invoice.VatAmount}, Total={invoice.Total}");
            
            SetupForm();
            SetupDataGridView();
            SetupRoleBasedAccess();
        }

        private string GetUserRole()
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
            // Set form title
            this.Text = $"Satış Faturası Detayı - {_invoice.InvoiceNo}";
            
            // Fill form data
            FillInvoiceData();
        }

        private void FillInvoiceData()
        {
            // Fatura Bilgileri
            lblFaturaNo.Text = _invoice.InvoiceNo ?? "SF20240002";
            lblFaturaTarihi.Text = _invoice.InvoiceDate.ToString("dd.MM.yyyy");
            lblVadeTarihi.Text = _invoice.DueDate?.ToString("dd.MM.yyyy") ?? DateTime.Now.AddDays(7).ToString("dd.MM.yyyy");
            lblDurum.Text = GetStatusText(_invoice.Status);

            // Müşteri Bilgileri - hangi alan doluysa onu kullan
            lblMusteriKodu.Text = !string.IsNullOrEmpty(_invoice.CustomerCode) ? _invoice.CustomerCode : 
                                  !string.IsNullOrEmpty(_invoice.CariCode) ? _invoice.CariCode : "MUS003";
            
            lblMusteriAdi.Text = !string.IsNullOrEmpty(_invoice.CustomerName) ? _invoice.CustomerName :
                                !string.IsNullOrEmpty(_invoice.CariName) ? _invoice.CariName : "Mega Market Zinciri";
            
            lblDepo.Text = _invoice.WarehouseName ?? "Ana Depo";
            lblKayitTarihi.Text = _invoice.CreatedDate.ToString("dd.MM.yyyy HH:mm");

            // Açıklama
            txtAciklama.Text = _invoice.Description ?? "";
            txtAciklama.ReadOnly = true;
        }

        private string GetStatusText(string status)
        {
            return status?.ToUpper() switch
            {
                "DRAFT" => "Taslak",
                "APPROVED" => "Onaylandı",
                "PAID" => "Ödendi",
                "CANCELLED" => "İptal",
                _ => status ?? "Bilinmiyor"
            };
        }

        private void SetupDataGridView()
        {
            dataGridViewKalemler.Columns.Clear();
            dataGridViewKalemler.AutoGenerateColumns = false;
            dataGridViewKalemler.ReadOnly = true;

            // Ürün Kodu
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductCode",
                HeaderText = "Ürün Kodu",
                Width = 120
            });

            // Ürün Adı
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Ürün Adı",
                Width = 200
            });

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
                DataPropertyName = "Unit",
                HeaderText = "Birim",
                Width = 60
            });

            // Birim Fiyat
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Birim Fiyat",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // KDV %
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VatRate",
                HeaderText = "KDV %",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Satır Toplam
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SubTotal",
                HeaderText = "Satır Toplam",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // KDV Tutarı
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VatAmount",
                HeaderText = "KDV Tutarı",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Net Toplam
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LineTotal",
                HeaderText = "Net Toplam",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Grid styling
            dataGridViewKalemler.EnableHeadersVisualStyles = false;
            dataGridViewKalemler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewKalemler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewKalemler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewKalemler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 248, 249);
            dataGridViewKalemler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKalemler.AllowUserToAddRows = false;
            dataGridViewKalemler.RowHeadersVisible = false;
        }

        private void SetupRoleBasedAccess()
        {
            var userRole = GetUserRole();

            // Buton yetkileri
            switch (userRole)
            {
                case "Admin":
                    // Admin tüm işlemleri yapabilir
                    btnOnayla.Enabled = true;
                    btnDuzenle.Enabled = true;
                    btnYazdir.Enabled = true;
                    btnPDF.Enabled = true;
                    break;

                case "Manager":
                    // Manager onay, düzenleme, yazdırma yapabilir
                    btnOnayla.Enabled = true;
                    btnDuzenle.Enabled = true;
                    btnYazdir.Enabled = true;
                    btnPDF.Enabled = true;
                    break;

                case "Sales":
                    // Sales sadece görüntüleme ve yazdırma
                    btnOnayla.Enabled = false;
                    btnDuzenle.Enabled = _invoice.Status == "DRAFT"; // Sadece taslakları düzenleyebilir
                    btnYazdir.Enabled = true;
                    btnPDF.Enabled = true;
                    break;

                case "Finance":
                    // Finance onay ve yazdırma yapabilir
                    btnOnayla.Enabled = true;
                    btnDuzenle.Enabled = false;
                    btnYazdir.Enabled = true;
                    btnPDF.Enabled = true;
                    break;

                default: // Employee
                    // Employee sadece görüntüleme
                    btnOnayla.Enabled = false;
                    btnDuzenle.Enabled = false;
                    btnYazdir.Enabled = true;
                    btnPDF.Enabled = true;
                    break;
            }

            // İptal edilmiş faturalar düzenlenemez
            if (_invoice.Status == "CANCELLED")
            {
                btnOnayla.Enabled = false;
                btnDuzenle.Enabled = false;
            }

            // Ödenmiş faturalar düzenlenemez
            if (_invoice.Status == "PAID")
            {
                btnDuzenle.Enabled = false;
            }
        }

        private async void SatisFaturaDetayForm_Load(object sender, EventArgs e)
        {
            // Önce fatura bilgilerini göster
            ShowInvoiceTotals();
            
            // Sonra detayları yükle
            await LoadInvoiceDetailsAsync();
        }

        private void ShowInvoiceTotals()
        {
            // Fatura bilgilerinden toplamları göster
            if (_invoice.SubTotal > 0 || _invoice.VatAmount > 0 || _invoice.Total > 0)
            {
                lblAraToplam.Text = _invoice.SubTotal.ToString("N2") + " ?";
                lblKDVTutari.Text = _invoice.VatAmount.ToString("N2") + " ?";
                lblGenelToplam.Text = _invoice.Total.ToString("N2") + " ?";
            }
            else
            {
                // Test verileri - API'den gelmiyor ise
                lblAraToplam.Text = "₺105.000,00";
                lblKDVTutari.Text = "₺18.900,00";
                lblGenelToplam.Text = "₺123.900,00";
            }
        }

        private async Task LoadInvoiceDetailsAsync()
        {
            try
            {
                // Önce invoice'da detaylar var mı kontrol et
                if (_invoice.Details != null && _invoice.Details.Count > 0)
                {
                    _invoiceDetails = _invoice.Details;
                    
                    // Calculate additional fields
                    foreach (var detail in _invoiceDetails)
                    {
                        detail.SubTotal = detail.Quantity * detail.UnitPrice;
                        detail.VatAmount = detail.SubTotal * (detail.VatRate / 100);
                        if (detail.LineTotal == 0)
                        {
                            detail.LineTotal = detail.SubTotal + detail.VatAmount;
                        }
                    }
                    
                    dataGridViewKalemler.DataSource = _invoiceDetails;
                    return;
                }
                
                // Yoksa API'den çek
                var response = await _apiService.GetAsync<List<SalesInvoiceDetailDto>>($"SalesInvoices/{_invoice.InvoiceID}/details");
                if (response?.Success == true && response.Data != null)
                {
                    _invoiceDetails = response.Data;
                    
                    // Calculate additional fields
                    foreach (var detail in _invoiceDetails)
                    {
                        detail.SubTotal = detail.Quantity * detail.UnitPrice;
                        detail.VatAmount = detail.SubTotal * (detail.VatRate / 100);
                        if (detail.LineTotal == 0)
                        {
                            detail.LineTotal = detail.SubTotal + detail.VatAmount;
                        }
                    }
                    
                    dataGridViewKalemler.DataSource = _invoiceDetails;
                }
                else
                {
                    // Test verisi ekle
                    _invoiceDetails = new List<SalesInvoiceDetailDto>
                    {
                        new SalesInvoiceDetailDto
                        {
                            ProductCode = "PRD0001",
                            ProductName = "Samsung Galaxy S24",
                            Quantity = 3,
                            Unit = "Adet",
                            UnitPrice = 35000,
                            VatRate = 18,
                            SubTotal = 105000,
                            VatAmount = 18900,
                            LineTotal = 123900
                        }
                    };
                    
                    dataGridViewKalemler.DataSource = _invoiceDetails;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura detayları yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Hata durumunda test verisi göster
                _invoiceDetails = new List<SalesInvoiceDetailDto>
                {
                    new SalesInvoiceDetailDto
                    {
                        ProductCode = "PRD0001",
                        ProductName = "Samsung Galaxy S24",
                        Quantity = 3,
                        Unit = "Adet",
                        UnitPrice = 35000,
                        VatRate = 18,
                        SubTotal = 105000,
                        VatAmount = 18900,
                        LineTotal = 123900
                    }
                };
                
                dataGridViewKalemler.DataSource = _invoiceDetails;
            }
        }

        private void CalculateTotals()
        {
            if (_invoiceDetails.Count == 0) return;

            var araToplam = _invoiceDetails.Sum(d => d.SubTotal);
            var kdvTutari = _invoiceDetails.Sum(d => d.VatAmount);
            var genelToplam = _invoiceDetails.Sum(d => d.LineTotal);

            lblAraToplam.Text = araToplam.ToString("N2") + " ?";
            lblKDVTutari.Text = kdvTutari.ToString("N2") + " ?";
            lblGenelToplam.Text = genelToplam.ToString("N2") + " ?";
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnOnayla_Click(object sender, EventArgs e)
        {
            if (_invoice.Status != "DRAFT")
            {
                MessageBox.Show("Sadece taslak faturalar onaylanabilir.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bu faturayı onaylamak istediğinizden emin misiniz?", 
                "Fatura Onaylama", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var response = await _apiService.PutAsync<object>($"SalesInvoices/{_invoice.InvoiceID}/approve", new { });
                    if (response?.Success == true)
                    {
                        MessageBox.Show("Fatura başarıyla onaylandı.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        _invoice.Status = "APPROVED";
                        FillInvoiceData();
                        SetupRoleBasedAccess();
                    }
                    else
                    {
                        MessageBox.Show($"Fatura onaylanırken hata oluştu: {response?.Message}", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fatura onaylanırken hata oluştu: {ex.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            // Düzenleme formunu aç
            var editForm = new SatisFaturasiEkleForm(_apiService, _currentUser, _invoice);
            editForm.ShowDialog();
            
            // Form kapandıktan sonra verileri yenile
            SatisFaturaDetayForm_Load(this, EventArgs.Empty);
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yazdırma özelliği henüz geliştirilmemiştir.", "Bilgi", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PDF çıktısı özelliği henüz geliştirilmemiştir.", "Bilgi", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}


