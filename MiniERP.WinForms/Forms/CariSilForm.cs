using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP.WinForms.Forms
{
    public partial class CariSilForm : Form
    {
        private readonly ApiService _apiService;
        private readonly string _userRole;
        private CariAccountDto _cariAccount;
        private decimal _currentBalance = 0;
        public bool IsDeleted { get; private set; } = false;

        public CariSilForm(CariAccountDto cariAccount, string userRole)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _userRole = userRole ?? "Kullanici";
            _cariAccount = cariAccount;
            
            // Set auth token from TokenManager
            if (TokenManager.HasToken())
            {
                _apiService.SetAuthToken(TokenManager.GetToken()!);
            }
            
            SetupForm();
            LoadCariData();
            LoadBalance();
        }

        private void SetupForm()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void LoadCariData()
        {
            if (_cariAccount != null)
            {
                // Cari bilgilerini doldur
                lblCariKoduValue.Text = _cariAccount.CariCode;
                lblCariTipiValue.Text = _cariAccount.TypeName;
                lblCariAdiValue.Text = _cariAccount.CariName;
                
                // Durum
                if (_cariAccount.IsActive)
                {
                    lblDurumValue.Text = "Aktif";
                    lblDurumValue.ForeColor = Color.FromArgb(25, 135, 84); // Bootstrap success color
                }
                else
                {
                    lblDurumValue.Text = "Pasif";
                    lblDurumValue.ForeColor = Color.FromArgb(220, 53, 69); // Bootstrap danger color
                }
                
                lblIletisimValue.Text = _cariAccount.ContactPerson ?? "-";
                lblTelefonValue.Text = _cariAccount.Phone ?? "-";
                lblKayitTarihiValue.Text = _cariAccount.CreatedDate.ToString("dd.MM.yyyy");
            }
        }

        private async void LoadBalance()
        {
            try
            {
                // API'den cari bakiyesini al
                var response = await _apiService.GetAsync<CariBalanceDto>($"CariAccounts/{_cariAccount.CariID}/balance");
                
                if (response != null && response.Success && response.Data != null)
                {
                    _currentBalance = response.Data.CurrentBalance;
                    
                    // Bakiye rengini ayarla
                    if (_currentBalance > 0)
                    {
                        lblGuncelBakiyeValue.ForeColor = Color.FromArgb(25, 135, 84); // Positive - Green
                        lblGuncelBakiyeValue.Text = $"₺{_currentBalance:N2}";
                    }
                    else if (_currentBalance < 0)
                    {
                        lblGuncelBakiyeValue.ForeColor = Color.FromArgb(220, 53, 69); // Negative - Red
                        lblGuncelBakiyeValue.Text = $"₺{_currentBalance:N2}";
                    }
                    else
                    {
                        lblGuncelBakiyeValue.ForeColor = Color.FromArgb(108, 117, 125); // Zero - Gray
                        lblGuncelBakiyeValue.Text = "₺0,00";
                    }
                    
                    // Sıfır olmayan bakiye uyarısı göster
                    if (_currentBalance != 0)
                    {
                        pnlBalanceWarning.Visible = true;
                        lblBalanceWarningText.Text = $"Uyarı: Bu cari hesabın bakiyesi sıfır değil (₺{_currentBalance:N2}). Silmeden önce bakiyeyi sıfırlamanız önerilir.";
                    }
                }
                else
                {
                    lblGuncelBakiyeValue.Text = "₺0,00";
                    lblGuncelBakiyeValue.ForeColor = Color.FromArgb(108, 117, 125);
                }
            }
            catch (Exception ex)
            {
                lblGuncelBakiyeValue.Text = "₺0,00";
                lblGuncelBakiyeValue.ForeColor = Color.FromArgb(108, 117, 125);
                // Hata durumunda log yaz ama UI'ı etkileme
                System.Diagnostics.Debug.WriteLine($"Balance loading error: {ex.Message}");
            }
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnDetayGoruntule_Click(object sender, EventArgs e)
        {
            try
            {
                // Cari detay formunu aç
                var detayForm = new CariDetayForm(_cariAccount, _userRole);
                detayForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Detay formu açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEvetSil_Click(object sender, EventArgs e)
        {
            // Son onay iste
            var confirmResult = MessageBox.Show(
                $"'{_cariAccount.CariName}' adlı cari hesabı kalıcı olarak silmek istediğinizden emin misiniz?\n\n" +
                "Bu işlem geri alınamaz!",
                "Son Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                btnEvetSil.Enabled = false;
                btnEvetSil.Text = "⏳ Siliniyor...";

                var response = await _apiService.DeleteAsync<bool>($"CariAccounts/{_cariAccount.CariID}");
                
                if (response != null && response.Success)
                {
                    IsDeleted = true;
                    
                    MessageBox.Show("Cari hesap başarıyla silindi!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response?.Message ?? "Cari hesap silinirken hata oluştu.", 
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme işlemi sırasında hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEvetSil.Enabled = true;
                btnEvetSil.Text = "🗑️ Evet, Sil";
            }
        }
    }

    // Balance DTO
    public class CariBalanceDto
    {
        public int CariID { get; set; }
        public string CariCode { get; set; } = string.Empty;
        public string CariName { get; set; } = string.Empty;
        public decimal CurrentBalance { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public DateTime LastTransactionDate { get; set; }
    }
}


