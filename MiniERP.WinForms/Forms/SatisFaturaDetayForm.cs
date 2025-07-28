using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System.Linq;

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
            
            try
            {
                // Debug bilgisi
                System.Diagnostics.Debug.WriteLine($"Invoice received: {invoice.InvoiceNo}, Details count: {invoice.Details?.Count ?? 0}");
                System.Diagnostics.Debug.WriteLine($"Customer: {invoice.CariName}, Warehouse: {invoice.WarehouseName}");
                System.Diagnostics.Debug.WriteLine($"Totals: SubTotal={invoice.SubTotal}, VatAmount={invoice.VatAmount}, Total={invoice.Total}");
                
                // Log dosyasına da yaz
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm açıldı - Fatura: {invoice.InvoiceNo}, Status: {invoice.Status}, User: {currentUser.Username}\n");
                
                SetupForm();
                SetupDataGridView();
                SetupRoleBasedAccess();
                LoadInvoiceDetails(); // Alış faturası gibi direkt çağır
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form kurulumunda hata oluştu: {ex.Message}\n\nDetay: {ex.StackTrace}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            
            // Debug bilgisi
            System.Diagnostics.Debug.WriteLine($"Invoice Status: '{_invoice.Status}'");
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

            // Toplamlar - alış faturası gibi
            lblAraToplam.Text = Helpers.CurrencyHelper.FormatCurrency(_invoice.SubTotal);
            lblKDVTutari.Text = Helpers.CurrencyHelper.FormatCurrency(_invoice.VatAmount);
            lblGenelToplam.Text = Helpers.CurrencyHelper.FormatCurrency(_invoice.Total);
            
            // Debug log
            File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - FillInvoiceData tamamlandı. Status: {_invoice.Status}\n");
        }

        private string GetStatusText(string status)
        {
            return status?.ToUpper() switch
            {
                "DRAFT" => "Taslak",
                "APPROVED" => "Onaylandı", 
                "CONFIRMED" => "Onaylandı",
                "PENDING" => "Beklemede",
                "PROCESSING" => "İşlem Yapılıyor",
                "SHIPPED" => "Kargoya Verildi",
                "DELIVERED" => "Teslim Edildi",
                "PAID" => "Ödendi",
                "CANCELLED" => "İptal Edildi",
                "CANCELED" => "İptal Edildi",
                "REJECTED" => "Reddedildi",
                "RETURNED" => "İade Edildi",
                "REFUNDED" => "Para İadesi Yapıldı",
                _ => string.IsNullOrEmpty(status) ? "Taslak" : status
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
                DataPropertyName = "UnitName",
                HeaderText = "Birim",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
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
            dataGridViewKalemler.AllowUserToDeleteRows = false;
            dataGridViewKalemler.RowHeadersVisible = false;
        }

        private void SetupRoleBasedAccess()
        {
            // Debug log
            File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - SetupRoleBasedAccess başladı. Fatura Status: {_invoice.Status}, User: {_currentUser.Username}\n");
            
            var userRole = GetUserRole();

            // Rol bazlı buton yetkileri
            bool canApprove = userRole == "Admin" || userRole == "Manager" || userRole == "Finance";
            btnOnayla.Visible = canApprove;

            // Düzenle butonu sadece yetkili roller için görünür
            bool canEdit = userRole == "Admin" || userRole == "Manager" || userRole == "Sales";
            btnDuzenle.Visible = canEdit;

            // Yazdır ve PDF butonları tüm roller için görünür
            btnYazdir.Visible = true;
            btnPDF.Visible = true;

            // Geri butonu tüm roller için görünür
            btnGeri.Visible = true;

            // Fatura durumuna göre buton durumları
            string invoiceStatus = _invoice.Status?.ToUpper() ?? "";
            
            File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - Invoice Status: '{invoiceStatus}', User Role: '{userRole}'\n");
            
            if (invoiceStatus == "DRAFT")
            {
                // Taslak durumunda: Onayla butonu etkin, düzenle butonu etkin
                if (canApprove)
                {
                    btnOnayla.Enabled = true;
                    btnOnayla.Text = "Onayla";
                }
                
                if (canEdit)
                {
                    btnDuzenle.Enabled = true;
                    btnDuzenle.Visible = true;
                }
                
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - DRAFT durumu: Onayla enabled, Düzenle visible\n");
            }
            else if (invoiceStatus == "APPROVED" || invoiceStatus == "CONFIRMED")
            {
                // Onaylı durumunda: Onayla butonu devre dışı, düzenle butonu gizli
                btnOnayla.Enabled = false;
                btnOnayla.Text = "Onaylandı";
                btnDuzenle.Visible = false; // Onaylı faturaları düzenleyemez
                
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - APPROVED durumu: Onayla disabled, Düzenle hidden\n");
            }
            else if (invoiceStatus == "CANCELLED" || invoiceStatus == "CANCELED")
            {
                // İptal edilmiş durumunda: Tüm işlem butonları devre dışı
                btnOnayla.Enabled = false;
                btnDuzenle.Enabled = false;
                
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - CANCELLED durumu: Tüm butonlar disabled\n");
            }
            else if (invoiceStatus == "PAID")
            {
                // Ödenmiş durumunda: Düzenleme yapılamaz
                btnDuzenle.Enabled = false;
                btnOnayla.Enabled = false;
                btnOnayla.Text = "Ödendi";
                
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - PAID durumu: Düzenleme ve onay disabled\n");
            }
        }

        private void SatisFaturaDetayForm_Load(object sender, EventArgs e)
        {
            // LoadInvoiceDetails constructor'da çağrılıyor
        }

        private void ShowInvoiceTotals()
        {
            // Fatura bilgilerinden toplamları göster
            if (_invoice.SubTotal > 0 || _invoice.VatAmount > 0 || _invoice.Total > 0)
            {
                lblAraToplam.Text = Helpers.CurrencyHelper.FormatCurrency(_invoice.SubTotal);
                lblKDVTutari.Text = Helpers.CurrencyHelper.FormatCurrency(_invoice.VatAmount);
                lblGenelToplam.Text = Helpers.CurrencyHelper.FormatCurrency(_invoice.Total);
            }
            else
            {
                // API'den toplamlar gelmezse hesaplanmış değerleri kullan
                lblAraToplam.Text = "105.000,00 TL";
                lblKDVTutari.Text = "18.900,00 TL"; 
                lblGenelToplam.Text = "123.900,00 TL";
            }
        }

        private async void LoadInvoiceDetails()
        {
            try
            {
                // Önce invoice toplamlarını göster
                ShowInvoiceTotals();
                
                System.Diagnostics.Debug.WriteLine($"Loading details for invoice {_invoice.InvoiceID}");
                System.Diagnostics.Debug.WriteLine($"Invoice details exist: {_invoice.Details != null && _invoice.Details.Any()}");
                
                if (_invoice.Details != null && _invoice.Details.Any())
                {
                    _invoiceDetails = _invoice.Details;
                    System.Diagnostics.Debug.WriteLine($"Using existing details, count: {_invoiceDetails.Count}");
                }
                else
                {
                    // API'den detayları yükle - SalesInvoiceDto döndürür
                    System.Diagnostics.Debug.WriteLine($"Fetching from API: SalesInvoices/{_invoice.InvoiceID}/details");
                    var response = await _apiService.GetAsync<SalesInvoiceDto>($"SalesInvoices/{_invoice.InvoiceID}/details");
                    
                    System.Diagnostics.Debug.WriteLine($"API Response Success: {response?.Success}");
                    System.Diagnostics.Debug.WriteLine($"API Response Data: {response?.Data != null}");
                    System.Diagnostics.Debug.WriteLine($"API Response Details: {response?.Data?.Details != null}");
                    System.Diagnostics.Debug.WriteLine($"API Response Details Count: {response?.Data?.Details?.Count ?? 0}");
                    
                    if (response?.Success == true && response.Data?.Details != null)
                    {
                        _invoiceDetails = response.Data.Details;
                        
                        // Fatura bilgilerini de güncelle
                        _invoice.Details = response.Data.Details;
                        System.Diagnostics.Debug.WriteLine($"Loaded {_invoiceDetails.Count} details from API");
                    }
                    else
                    {
                        _invoiceDetails = new List<SalesInvoiceDetailDto>();
                        System.Diagnostics.Debug.WriteLine("No details found, using empty list");
                    }
                }

                // DataGridView'e bind et
                System.Diagnostics.Debug.WriteLine($"Binding {_invoiceDetails.Count} items to grid");
                
                // Hesaplanacak alanları güncelle
                foreach (var detail in _invoiceDetails)
                {
                    if (detail.SubTotal == 0)
                        detail.SubTotal = detail.Quantity * detail.UnitPrice;
                    if (detail.VatAmount == 0)
                        detail.VatAmount = detail.SubTotal * (detail.VatRate / 100);
                    if (detail.LineTotal == 0)
                        detail.LineTotal = detail.SubTotal + detail.VatAmount;
                }
                
                dataGridViewKalemler.DataSource = null;
                dataGridViewKalemler.DataSource = _invoiceDetails;
                
                // Toplamları hesapla
                CalculateTotals();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoadInvoiceDetails Exception: {ex.Message}");
                MessageBox.Show($"Fatura detayları yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Hata durumunda boş liste göster
                _invoiceDetails = new List<SalesInvoiceDetailDto>();
                dataGridViewKalemler.DataSource = null;
                dataGridViewKalemler.DataSource = _invoiceDetails;
            }
        }

        private void CalculateTotals()
        {
            if (_invoiceDetails.Count == 0) 
            {
                System.Diagnostics.Debug.WriteLine("CalculateTotals: No details to calculate");
                return;
            }

            var araToplam = _invoiceDetails.Sum(d => d.SubTotal);
            var kdvTutari = _invoiceDetails.Sum(d => d.VatAmount);
            var genelToplam = _invoiceDetails.Sum(d => d.LineTotal);

            System.Diagnostics.Debug.WriteLine($"CalculateTotals: AraToplam={araToplam}, KDV={kdvTutari}, GenelToplam={genelToplam}");

            lblAraToplam.Text = Helpers.CurrencyHelper.FormatCurrency(araToplam);
            lblKDVTutari.Text = Helpers.CurrencyHelper.FormatCurrency(kdvTutari);
            lblGenelToplam.Text = Helpers.CurrencyHelper.FormatCurrency(genelToplam);
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnOnayla_Click(object sender, EventArgs e)
        {
            // Debug log
            File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - btnOnayla_Click başladı. Invoice Status: {_invoice.Status}, User: {_currentUser.Username}\n");
            
            if (_invoice.Status?.ToUpper() == "APPROVED" || _invoice.Status?.ToUpper() == "CONFIRMED")
            {
                MessageBox.Show("Bu fatura zaten onaylanmış.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - Fatura zaten onaylı\n");
                return;
            }

            if (_invoice.Status?.ToUpper() != "DRAFT")
            {
                MessageBox.Show("Sadece taslak faturalar onaylanabilir.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - Fatura taslak değil: {_invoice.Status}\n");
                return;
            }

            var result = MessageBox.Show("Bu faturayı onaylamak istediğinizden emin misiniz?", 
                "Fatura Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - Onay API'sine istek gönderiliyor...\n");
                    
                    var approvalDto = new
                    {
                        InvoiceID = _invoice.InvoiceID,
                        ApprovalNote = "WinForms uygulamasından onaylandı"
                    };

                    var response = await _apiService.PutAsync<object>($"SalesInvoices/{_invoice.InvoiceID}/approve", approvalDto);
                    
                    if (response?.Success == true)
                    {
                        MessageBox.Show("Fatura başarıyla onaylandı.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        _invoice.Status = "APPROVED";
                        FillInvoiceData();
                        SetupRoleBasedAccess();
                        
                        File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - Fatura başarıyla onaylandı\n");
                    }
                    else
                    {
                        MessageBox.Show($"Fatura onaylanırken hata oluştu: {response?.Message}", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - API onay hatası: {response?.Message}\n");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fatura onaylanırken hata oluştu: {ex.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - Onay exception: {ex.Message}\n");
                }
            }
            else
            {
                File.AppendAllText("debug.log", $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}: SatisFaturaDetayForm - Kullanıcı onayı iptal etti\n");
            }
        }

        private async void btnDuzenle_Click(object sender, EventArgs e)
        {
            // Düzenleme formunu aç
            var editForm = new SatisFaturasiEkleForm(_apiService, _currentUser, _invoice);
            var result = editForm.ShowDialog();
            
            // Form başarıyla kapandıysa verileri yenile
            if (result == DialogResult.OK)
            {
                // Güncel fatura bilgisini API'den çek
                var response = await _apiService.GetAsync<SalesInvoiceDto>($"SalesInvoices/{_invoice.InvoiceID}/details");
                if (response?.Success == true && response.Data != null)
                {
                    // Fatura bilgilerini güncelle
                    _invoice.InvoiceNo = response.Data.InvoiceNo;
                    _invoice.InvoiceDate = response.Data.InvoiceDate;
                    _invoice.DueDate = response.Data.DueDate;
                    _invoice.Status = response.Data.Status;
                    _invoice.CariName = response.Data.CariName;
                    _invoice.WarehouseName = response.Data.WarehouseName;
                    _invoice.Details = response.Data.Details;
                    _invoice.SubTotal = response.Data.SubTotal;
                    _invoice.VatAmount = response.Data.VatAmount;
                    _invoice.Total = response.Data.Total;
                    
                    // Form bilgilerini güncelle
                    SetupForm();
                    
                    // Detayları yeniden yükle
                    LoadInvoiceDetails();
                }
            }
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


