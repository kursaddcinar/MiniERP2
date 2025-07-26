using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP.WinForms.Forms
{
    public partial class CariDetayForm : Form
    {
        private readonly ApiService _apiService;
        private readonly string _userRole;
        private CariAccountDto _cariAccount;

        public CariDetayForm(CariAccountDto cariAccount, string userRole)
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
            LoadCariDetails();
            SetRoleBasedPermissions();
        }

        private void SetupForm()
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadCariDetails()
        {
            try
            {
                if (_cariAccount != null)
                {
                    // Başlık ve temel bilgiler
                    lblCariTitle.Text = $"👤 {_cariAccount.CariName} ({_cariAccount.CariCode})";
                    
                    // Cari detay bilgileri
                    lblCariKoduValue.Text = _cariAccount.CariCode;
                    lblCariAdiValue.Text = _cariAccount.CariName;
                    lblIletisimKisiValue.Text = _cariAccount.ContactPerson ?? "-";
                    lblTelefonValue.Text = _cariAccount.Phone ?? "-";
                    lblEmailValue.Text = _cariAccount.Email ?? "-";
                    lblCariTipiValue.Text = _cariAccount.TypeName;
                    lblVergiDairesiValue.Text = _cariAccount.TaxOffice ?? "-";
                    lblVergiNoValue.Text = _cariAccount.TaxNo ?? "-";
                    lblKrediLimitDetayValue.Text = $"₺{_cariAccount.CreditLimit:N2}";
                    lblKayitTarihiValue.Text = _cariAccount.CreatedDate.ToString("dd.MM.yyyy HH:mm");

                    // Bakiye bilgilerini yükle
                    LoadBakiyeBilgileri();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari detayları yüklenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBakiyeBilgileri()
        {
            try
            {
                // API'den bakiye bilgilerini al - basit olarak mevcut bakiyeyi kullan
                decimal guncelBakiye = _cariAccount.CurrentBalance;
                decimal krediLimiti = _cariAccount.CreditLimit;
                decimal kullanilabilirLimit = krediLimiti - guncelBakiye;

                lblGuncelBakiyeValue.Text = $"₺{guncelBakiye:N2}";
                lblKrediLimitiValue.Text = $"₺{krediLimiti:N2}";
                lblKullanilabilirLimitValue.Text = $"₺{kullanilabilirLimit:N2}";

                // Renkleri ayarla
                lblGuncelBakiyeValue.ForeColor = guncelBakiye >= 0 ? 
                    Color.FromArgb(34, 197, 94) : Color.FromArgb(239, 68, 68);
                
                lblKullanilabilirLimitValue.ForeColor = kullanilabilirLimit >= 0 ? 
                    Color.FromArgb(34, 197, 94) : Color.FromArgb(239, 68, 68);
            }
            catch (Exception)
            {
                // Hata durumunda varsayılan değerleri göster
                lblGuncelBakiyeValue.Text = "₺0.00";
                lblKrediLimitiValue.Text = $"₺{_cariAccount.CreditLimit:N2}";
                lblKullanilabilirLimitValue.Text = $"₺{_cariAccount.CreditLimit:N2}";
            }
        }

        private void SetRoleBasedPermissions()
        {
            // Rol bazında yetkilendirme (güncel rol sistemi)
            var rolePermissions = new Dictionary<string, List<string>>
            {
                ["Admin"] = new() { "Create", "Read", "Update", "Delete" },
                ["Manager"] = new() { "Create", "Read", "Update", "Delete" },
                ["Sales"] = new() { "Create", "Read", "Update", "Delete" },
                ["Purchase"] = new() { "Create", "Read", "Update", "Delete" },
                ["Finance"] = new() { "Read" }, // Finance can only read
                ["Warehouse"] = new() { } // Warehouse has no access
            };

            var permissions = rolePermissions.GetValueOrDefault(_userRole, new List<string>());
            
            // Update yetkisi yoksa düzenleme butonu devre dışı
            if (!permissions.Contains("Update"))
            {
                btnDuzenle.Enabled = false;
                btnDuzenle.BackColor = Color.FromArgb(156, 163, 175);
            }
            
            // Create yetkisi yoksa yeni hareket butonu devre dışı  
            if (!permissions.Contains("Create"))
            {
                btnYeniHareket.Enabled = false;
                btnYeniHareket.BackColor = Color.FromArgb(156, 163, 175);
            }
            
            // Finance için özel başlık
            if (_userRole == "Finance")
            {
                lblCariTitle.Text += " (Sadece Görüntüleme)";
            }
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnHareketler_Click(object sender, EventArgs e)
        {
            try
            {
                // Cari hareketleri formu açılacak
                var hareketlerForm = new CariHareketleriForm(_cariAccount, _userRole);
                hareketlerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hareketler açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                // Cari düzenleme formu aç
                var duzenleForm = new CariDuzenleForm(_cariAccount, _userRole);
                var result = duzenleForm.ShowDialog();
                
                if (result == DialogResult.OK && duzenleForm.IsUpdated && duzenleForm.UpdatedCari != null)
                {
                    // Güncellenmiş veriyi al ve formu yenile - mesaj gösterme kaldırıldı, form kendi mesajını gösteriyor
                    _cariAccount = duzenleForm.UpdatedCari;
                    LoadCariDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Düzenleme formu açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCariHareketleri_Click(object sender, EventArgs e)
        {
            try
            {
                // Cari hareketleri sayfası açılacak
                var hareketlerForm = new CariHareketleriForm(_cariAccount, _userRole);
                hareketlerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari hareketleri açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCariEkstresi_Click(object sender, EventArgs e)
        {
            try
            {
                // Cari ekstresini açık
                var ekstreForm = new CariEkstreForm(_cariAccount, _userRole);
                ekstreForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari ekstresi oluşturulurken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnYeniHareket_Click(object sender, EventArgs e)
        {
            try
            {
                // Yeni hareket formu açılacak
                MessageBox.Show("Yeni hareket özelliği yakında eklenecek.", 
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yeni hareket formu açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


