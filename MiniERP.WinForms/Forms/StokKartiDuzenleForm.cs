using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class StokKartiDuzenleForm : Form
    {
        private readonly int _stockCardId;
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private StockCardDto? _currentStockCard;

        public StokKartiDuzenleForm(int stockCardId, UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _stockCardId = stockCardId;
            _currentUser = currentUser;
            _apiService = apiService;

            SetupForm();
            LoadStockCardData();
        }

        private void SetupForm()
        {
            this.Text = "Stok Kartı Düzenle";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Event handlers
            btnKaydet.Click += BtnKaydet_Click;
            btnIptal.Click += BtnIptal_Click;
        }

        private async void LoadStockCardData()
        {
            try
            {
                lblDurum.Text = "Stok kartı bilgileri yükleniyor...";

                var response = await _apiService.GetAsync<StockCardDto>($"Stock/cards/{_stockCardId}");
                if (response != null && response.Success && response.Data != null)
                {
                    _currentStockCard = response.Data;
                    PopulateFormData();
                    lblDurum.Text = "Veriler yüklendi";
                    lblDurum.ForeColor = Color.Green;
                }
                else
                {
                    lblDurum.Text = "Stok kartı yüklenemedi";
                    lblDurum.ForeColor = Color.Red;
                    MessageBox.Show("Stok kartı bilgileri yüklenemedi.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblDurum.Text = "Hata oluştu";
                lblDurum.ForeColor = Color.Red;
                MessageBox.Show($"Stok kartı yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateFormData()
        {
            if (_currentStockCard == null) return;

            // Temel bilgiler (salt okunur)
            txtUrunKodu.Text = _currentStockCard.ProductCode;
            txtUrunAdi.Text = _currentStockCard.ProductName;
            txtDepo.Text = _currentStockCard.WarehouseName;
            txtBirim.Text = _currentStockCard.UnitName;

            // Düzenlenebilir alanlar
            numMevcutStok.Value = _currentStockCard.CurrentStock;
            numRezerveStok.Value = _currentStockCard.ReservedStock;

            // Hesaplanan alanlar
            lblMusaitStok.Text = (_currentStockCard.CurrentStock - _currentStockCard.ReservedStock).ToString("N2");
            lblMinStok.Text = _currentStockCard.MinStockLevel.ToString("N2");
            lblMaxStok.Text = _currentStockCard.MaxStockLevel.ToString("N2");

            // Geliştirilmekte olan alanlar - devre dışı
            txtLokasyon.Text = "Bu kısım geliştirilecektir...";
            txtLokasyon.ReadOnly = true;
            txtLokasyon.BackColor = Color.LightGray;

            txtNotlar.Text = "Bu kısım geliştirilecektir...";
            txtNotlar.ReadOnly = true;
            txtNotlar.BackColor = Color.LightGray;

            chkAktif.Checked = true; // Varsayılan
            chkAktif.Enabled = false;

            // Bilgilendirme
            lblBilgi.Text = "ℹ️ Sadece 'Mevcut Stok' ve 'Rezerve Stok' alanları düzenlenebilir.\n" +
                           "Diğer özellikler geliştirilme aşamasındadır.";
            lblBilgi.ForeColor = Color.Blue;
        }

        private async void BtnKaydet_Click(object? sender, EventArgs e)
        {
            if (_currentStockCard == null) return;

            try
            {
                btnKaydet.Enabled = false;
                lblDurum.Text = "Kaydediliyor...";

                // Sadece düzenlenebilir alanları gönder
                var updateData = new
                {
                    CurrentStock = numMevcutStok.Value,
                    ReservedStock = numRezerveStok.Value
                };

                var response = await _apiService.PutAsync<StockCardDto>($"Stock/cards/{_stockCardId}", updateData);
                
                if (response != null && response.Success)
                {
                    lblDurum.Text = "Başarıyla kaydedildi";
                    lblDurum.ForeColor = Color.Green;
                    
                    MessageBox.Show("Stok kartı başarıyla güncellendi.", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblDurum.Text = "Kaydetme başarısız";
                    lblDurum.ForeColor = Color.Red;
                    MessageBox.Show(response?.Message ?? "Stok kartı güncellenirken hata oluştu.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblDurum.Text = "Hata oluştu";
                lblDurum.ForeColor = Color.Red;
                MessageBox.Show($"Kaydetme sırasında hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnKaydet.Enabled = true;
            }
        }

        private void BtnIptal_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
