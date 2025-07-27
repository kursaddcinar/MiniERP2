using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class AlisFaturaDetayForm : Form
    {
        private readonly ApiService _apiService;
        private readonly UserDto _currentUser;
        private readonly PurchaseInvoiceDto _invoice;
        private List<PurchaseInvoiceDetailDto> _invoiceDetails = new();

        // Event for notifying parent when invoice is deleted
        public event EventHandler? InvoiceDeleted;

        public AlisFaturaDetayForm(ApiService apiService, UserDto currentUser, PurchaseInvoiceDto invoice)
        {
            InitializeComponent();
            _apiService = apiService;
            _currentUser = currentUser;
            _invoice = invoice;
            
            SetupForm();
            SetupDataGridView();
            SetupRoleBasedAccess();
            LoadInvoiceDetails();
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
            this.Text = $"Alış Faturası Detayı - {_invoice.InvoiceNo}";
            
            // Fill form data
            FillInvoiceData();
        }

        private void FillInvoiceData()
        {
            // Fatura Bilgileri
            lblFaturaNo.Text = _invoice.InvoiceNo ?? "";
            lblFaturaTarihi.Text = _invoice.InvoiceDate.ToString("dd.MM.yyyy");
            lblVadeTarihi.Text = _invoice.DueDate?.ToString("dd.MM.yyyy") ?? DateTime.Now.AddDays(30).ToString("dd.MM.yyyy");
            lblDurum.Text = GetStatusText(_invoice.Status);

            // Tedarikçi Bilgileri
            lblTedarikciKodu.Text = _invoice.CariCode ?? "";
            lblTedarikciAdi.Text = _invoice.CariName ?? "";
            lblDepo.Text = _invoice.WarehouseName ?? "";
            lblKayitTarihi.Text = _invoice.CreatedDate.ToString("dd.MM.yyyy HH:mm");

            // Açıklama
            txtAciklama.Text = _invoice.Description ?? "";
            txtAciklama.ReadOnly = true;

            // Toplamlar
            lblAraToplam.Text = Helpers.CurrencyHelper.FormatCurrency(_invoice.SubTotal);
            lblKDVTutari.Text = Helpers.CurrencyHelper.FormatCurrency(_invoice.VatAmount);
            lblGenelToplam.Text = Helpers.CurrencyHelper.FormatCurrency(_invoice.Total);
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
                DefaultCellStyle = new DataGridViewCellStyle { Format = Helpers.CurrencyHelper.GetDataGridViewCurrencyFormat(), Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // KDV %
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VatRate",
                HeaderText = "KDV %",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Satır Toplam (miktar * fiyat - KDV hariç)
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SubTotal",
                HeaderText = "Satır Toplam",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = Helpers.CurrencyHelper.GetDataGridViewCurrencyFormat(), Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // KDV Tutarı
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VatAmount",
                HeaderText = "KDV Tutarı",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = Helpers.CurrencyHelper.GetDataGridViewCurrencyFormat(), Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Net Toplam (satır toplam + KDV)
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NetTotal",
                HeaderText = "Net Toplam",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = Helpers.CurrencyHelper.GetDataGridViewCurrencyFormat(), Alignment = DataGridViewContentAlignment.MiddleRight }
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

        private async void LoadInvoiceDetails()
        {
            try
            {
                if (_invoice.Details != null && _invoice.Details.Any())
                {
                    _invoiceDetails = _invoice.Details;
                }
                else
                {
                    // API'den detayları yükle
                    var response = await _apiService.GetAsync<PurchaseInvoiceDto>($"PurchaseInvoices/{_invoice.InvoiceID}/details");
                    if (response?.Success == true && response.Data?.Details != null)
                    {
                        _invoiceDetails = response.Data.Details;
                    }
                    else
                    {
                        _invoiceDetails = new List<PurchaseInvoiceDetailDto>();
                    }
                }

                // DataGridView'e bind et
                dataGridViewKalemler.DataSource = null;
                dataGridViewKalemler.DataSource = _invoiceDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura detayları yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupRoleBasedAccess()
        {
            var role = GetUserRole();

            // Onay butonu sadece yetkili roller için görünür
            bool canApprove = role == "Admin" || role == "Manager" || role == "Purchase";
            btnOnayla.Visible = canApprove;

            // Düzenle butonu sadece yetkili roller için görünür
            bool canEdit = role == "Admin" || role == "Manager" || role == "Purchase";
            btnDuzenle.Visible = canEdit;

            // Sil butonu sadece Admin ve Manager için görünür
            btnSil.Visible = role == "Admin" || role == "Manager";

            // Yazdır ve PDF butonları tüm roller için görünür
            btnYazdir.Visible = true;
            btnPDF.Visible = true;

            // Geri butonu tüm roller için görünür
            btnGeri.Visible = true;

            // Fatura durumuna göre buton durumları
            string invoiceStatus = _invoice.Status?.ToUpper() ?? "";
            
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
            }
            else if (invoiceStatus == "APPROVED")
            {
                // Onaylı durumunda: Onayla butonu devre dışı, düzenle butonu gizli
                btnOnayla.Enabled = false;
                btnOnayla.Text = "Onaylandı";
                btnDuzenle.Visible = false; // Onaylı faturaları düzenleyemez
            }
            else if (invoiceStatus == "CANCELLED")
            {
                // İptal edilmiş durumunda: Tüm işlem butonları devre dışı
                btnOnayla.Enabled = false;
                btnDuzenle.Enabled = false;
                btnSil.Enabled = false;
            }
        }

        private async void btnOnayla_Click(object sender, EventArgs e)
        {
            if (_invoice.Status?.ToUpper() == "APPROVED")
            {
                MessageBox.Show("Bu fatura zaten onaylanmış.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_invoice.Status?.ToUpper() != "DRAFT")
            {
                MessageBox.Show("Sadece taslak faturalar onaylanabilir.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bu faturayı onaylamak istediğinizden emin misiniz?", 
                "Fatura Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var approvalDto = new
                    {
                        InvoiceID = _invoice.InvoiceID,
                        ApprovalNote = "WinForms uygulamasından onaylandı"
                    };

                    var approveResponse = await _apiService.PostAsync<bool>($"PurchaseInvoices/{_invoice.InvoiceID}/approve", approvalDto);
                    
                    if (approveResponse != null && approveResponse.Success)
                    {
                        MessageBox.Show("Fatura başarıyla onaylandı.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Update invoice status and refresh UI
                        _invoice.Status = "APPROVED";
                        FillInvoiceData();
                        SetupRoleBasedAccess();
                        
                        // Parent formu bilgilendir ve kapat
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Fatura onaylanırken hata oluştu: {approveResponse?.Message}", "Hata", 
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
            if (_invoice.Status?.ToUpper() == "APPROVED")
            {
                MessageBox.Show("Onaylanmış fatura düzenlenemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_invoice.Status?.ToUpper() == "CANCELLED")
            {
                MessageBox.Show("İptal edilmiş fatura düzenlenemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Düzenleme formunu aç
            var editForm = new AlisFaturaDuzenleForm(_currentUser, _apiService, _invoice);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Form başarıyla güncellenirse, bu formu kapat ve ana listeye dön
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            // Yazdırma işlemi - implement if needed
            MessageBox.Show("Yazdırma özelliği yakında eklenecek.", "Bilgi", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            // PDF oluşturma işlemi - implement if needed
            MessageBox.Show("PDF oluşturma özelliği yakında eklenecek.", "Bilgi", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                var silForm = new AlisFaturaSilForm(_currentUser, _apiService, _invoice);
                if (silForm.ShowDialog() == DialogResult.OK)
                {
                    // Silme başarılı olursa event'i tetikle ve formu kapat
                    InvoiceDeleted?.Invoke(this, EventArgs.Empty);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme formu açılırken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


