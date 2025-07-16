using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class SatisFaturasiSilForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private readonly SalesInvoiceDto _invoice;

        public SatisFaturasiSilForm(UserDto currentUser, ApiService apiService, SalesInvoiceDto invoice)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            _invoice = invoice;
            
            SetupForm();
            LoadInvoiceData();
        }

        private void SetupForm()
        {
            this.Text = $"Satış Faturası Sil - {_invoice.InvoiceNo}";
            
            // Form'u modal olarak aç ve büyük boyutta
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
            
            // Checkbox başlangıçta kapalı
            chkOnay.Checked = false;
            
            // Buton durumları
            UpdateButtonStates();
        }

        private async void LoadInvoiceData()
        {
            try
            {
                // Fatura bilgilerini yükle
                LoadInvoiceHeader();
                
                // Fatura detaylarını yükle
                await LoadInvoiceDetailsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura bilgileri yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInvoiceHeader()
        {
            // Fatura bilgilerini form alanlarına yükle
            lblFaturaNo.Text = _invoice.InvoiceNo;
            lblFaturaTarihi.Text = _invoice.InvoiceDate.ToString("dd.MM.yyyy");
            lblMusteri.Text = $"{_invoice.CustomerCode} - {_invoice.CustomerName}";
            lblDepo.Text = _invoice.WarehouseName;
            lblDurum.Text = _invoice.Status;
            lblAraToplam.Text = _invoice.SubTotal.ToString("N2") + " ₺";
            lblKdvTutari.Text = _invoice.VatAmount.ToString("N2") + " ₺";
            lblGenelToplam.Text = _invoice.Total.ToString("N2") + " ₺";
            
            // Duruma göre renk ayarla
            SetStatusColor(lblDurum, _invoice.Status);
        }

        private void SetStatusColor(Label statusLabel, string status)
        {
            switch (status.ToUpper())
            {
                case "DRAFT":
                    statusLabel.BackColor = Color.FromArgb(249, 115, 22); // Turuncu
                    statusLabel.ForeColor = Color.White;
                    break;
                case "APPROVED":
                    statusLabel.BackColor = Color.FromArgb(34, 197, 94); // Yeşil
                    statusLabel.ForeColor = Color.White;
                    break;
                case "CANCELLED":
                    statusLabel.BackColor = Color.FromArgb(239, 68, 68); // Kırmızı
                    statusLabel.ForeColor = Color.White;
                    break;
                default:
                    statusLabel.BackColor = Color.FromArgb(107, 114, 128); // Gri
                    statusLabel.ForeColor = Color.White;
                    break;
            }
            statusLabel.Padding = new Padding(10, 5, 10, 5);
            statusLabel.AutoSize = false;
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
        }

        private async Task LoadInvoiceDetailsAsync()
        {
            try
            {
                // API'den fatura detaylarını çek
                var response = await _apiService.GetAsync<SalesInvoiceDto>($"SalesInvoices/{_invoice.InvoiceID}/details");
                if (response?.Success == true && response.Data?.Details != null)
                {
                    var detailsForGrid = response.Data.Details.Select(d => new
                    {
                        Ürün = $"{d.ProductCode} - {d.ProductName}",
                        Miktar = d.Quantity.ToString("N2") + " " + d.UnitName,
                        NetToplam = d.NetTotal.ToString("N2") + " ₺"
                    }).ToList();

                    dgvDetaylar.DataSource = detailsForGrid;
                    
                    // Grid sütun ayarları
                    if (dgvDetaylar.Columns.Count > 0)
                    {
                        dgvDetaylar.Columns[0].Width = 300; // Ürün
                        dgvDetaylar.Columns[1].Width = 120; // Miktar
                        dgvDetaylar.Columns[2].Width = 120; // Net Toplam
                        dgvDetaylar.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura detayları yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkOnay_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            btnFaturayiSil.Enabled = chkOnay.Checked;
            btnFaturayiSil.BackColor = chkOnay.Checked ? 
                Color.FromArgb(239, 68, 68) : Color.FromArgb(156, 163, 175);
        }

        private async void btnFaturayiSil_Click(object sender, EventArgs e)
        {
            if (!chkOnay.Checked)
            {
                MessageBox.Show("Silme işlemini onaylamadan devam edemezsiniz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"'{_invoice.InvoiceNo}' numaralı faturayı silmek istediğinizden emin misiniz?\n\n" +
                "Bu işlem geri alınamaz ve aşağıdaki etkileri olacaktır:\n" +
                "• Fatura tamamen silinecek\n" +
                "• Stok hareketleri etkilenecek\n" +
                "• Cari hesap bakiyesi güncellenecek\n" +
                "• Raporlar etkilenecek", 
                "Fatura Silme Onayı", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                await DeleteInvoiceAsync();
            }
        }

        private async Task DeleteInvoiceAsync()
        {
            try
            {
                btnFaturayiSil.Enabled = false;
                btnFaturayiSil.Text = "Siliniyor...";

                var response = await _apiService.DeleteAsync<bool>($"SalesInvoices/{_invoice.InvoiceID}");
                
                if (response?.Success == true)
                {
                    MessageBox.Show("Satış faturası başarıyla silindi.", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response?.Message ?? "Fatura silinirken hata oluştu.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura silinirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFaturayiSil.Enabled = chkOnay.Checked;
                btnFaturayiSil.Text = "🗑️ Faturayı Sil";
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDetaylariGor_Click(object sender, EventArgs e)
        {
            try
            {
                var detailForm = new SatisFaturaDetayForm(_apiService, _currentUser, _invoice);
                detailForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura detayları açılırken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
