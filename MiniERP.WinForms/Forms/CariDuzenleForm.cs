using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP.WinForms.Forms
{
    public partial class CariDuzenleForm : Form
    {
        private readonly ApiService _apiService;
        private readonly string _userRole;
        private CariAccountDto _originalCari;
        public CariAccountDto? UpdatedCari { get; private set; }
        public bool IsUpdated { get; private set; } = false;

        public CariDuzenleForm(CariAccountDto cariAccount, string userRole)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _userRole = userRole ?? "Kullanici";
            _originalCari = cariAccount;
            
            // Set auth token from TokenManager
            if (TokenManager.HasToken())
            {
                _apiService.SetAuthToken(TokenManager.GetToken()!);
            }
            
            SetupForm();
            LoadCariTypes();
            LoadCariData();
        }

        private void SetupForm()
        {
            // Form özellikleri
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            // Cari kodu değiştirilemez
            txtCariKodu.ReadOnly = true;
            txtCariKodu.BackColor = Color.FromArgb(249, 250, 251);
            
            // Başlığı güncelle
            lblSubtitle.Text = $"{_originalCari.CariName} ({_originalCari.CariCode}) Bilgilerini Düzenle";
        }

        private async void LoadCariTypes()
        {
            try
            {
                var response = await _apiService.GetAsync<List<CariTypeDto>>("CariType");
                if (response != null && response.Data != null)
                {
                    cmbCariTipi.DataSource = response.Data;
                    cmbCariTipi.DisplayMember = "TypeName";
                    cmbCariTipi.ValueMember = "TypeID";
                }
                else
                {
                    // Fallback cari tipleri
                    var fallbackTypes = new List<CariTypeDto>
                    {
                        new CariTypeDto { TypeID = 1, TypeName = "Müşteri" },
                        new CariTypeDto { TypeID = 2, TypeName = "Tedarikçi" },
                        new CariTypeDto { TypeID = 3, TypeName = "Hem Müşteri Hem Tedarikçi" }
                    };
                    cmbCariTipi.DataSource = fallbackTypes;
                    cmbCariTipi.DisplayMember = "TypeName";
                    cmbCariTipi.ValueMember = "TypeID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari tipleri yüklenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                // Fallback cari tipleri
                var fallbackTypes = new List<CariTypeDto>
                {
                    new CariTypeDto { TypeID = 1, TypeName = "Müşteri" },
                    new CariTypeDto { TypeID = 2, TypeName = "Tedarikçi" },
                    new CariTypeDto { TypeID = 3, TypeName = "Hem Müşteri Hem Tedarikçi" }
                };
                cmbCariTipi.DataSource = fallbackTypes;
                cmbCariTipi.DisplayMember = "TypeName";
                cmbCariTipi.ValueMember = "TypeID";
            }
        }

        private void LoadCariData()
        {
            if (_originalCari != null)
            {
                // Form alanlarını doldur
                txtCariKodu.Text = _originalCari.CariCode;
                txtCariAdi.Text = _originalCari.CariName;
                txtIletisimKisi.Text = _originalCari.ContactPerson ?? "";
                txtTelefon.Text = _originalCari.Phone ?? "";
                txtEPosta.Text = _originalCari.Email ?? "";
                txtVergiNumarasi.Text = _originalCari.TaxNumber ?? "";
                txtVergiDairesi.Text = _originalCari.TaxOffice ?? "";
                txtKrediLimiti.Text = _originalCari.CreditLimit.ToString("F2");
                txtAdres.Text = _originalCari.Address ?? "";
                chkAktifCari.Checked = _originalCari.IsActive;
                
                // Cari tipini seç
                if (cmbCariTipi.DataSource != null)
                {
                    cmbCariTipi.SelectedValue = _originalCari.TypeID;
                }
            }
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            try
            {
                btnGuncelle.Enabled = false;
                btnGuncelle.Text = "⏳ Güncelleniyor...";

                var updateDto = new UpdateCariAccountDto
                {
                    CariName = txtCariAdi.Text.Trim(),
                    ContactPerson = string.IsNullOrWhiteSpace(txtIletisimKisi.Text) ? null : txtIletisimKisi.Text.Trim(),
                    Phone = string.IsNullOrWhiteSpace(txtTelefon.Text) ? null : txtTelefon.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEPosta.Text) ? null : txtEPosta.Text.Trim(),
                    TaxNo = string.IsNullOrWhiteSpace(txtVergiNumarasi.Text) ? null : txtVergiNumarasi.Text.Trim(),
                    TaxOffice = string.IsNullOrWhiteSpace(txtVergiDairesi.Text) ? null : txtVergiDairesi.Text.Trim(),
                    CreditLimit = decimal.TryParse(txtKrediLimiti.Text, out decimal limit) ? limit : 0,
                    Address = string.IsNullOrWhiteSpace(txtAdres.Text) ? null : txtAdres.Text.Trim(),
                    IsActive = chkAktifCari.Checked,
                    TypeID = (int)(cmbCariTipi.SelectedValue ?? 1)
                };

                var response = await _apiService.PutAsync<CariAccountDto>($"CariAccounts/{_originalCari.CariID}", updateDto);
                
                if (response != null && response.Success && response.Data != null)
                {
                    UpdatedCari = response.Data;
                    IsUpdated = true;
                    
                    MessageBox.Show("Cari hesap başarıyla güncellendi!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response?.Message ?? "Cari hesap güncellenirken hata oluştu.", 
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuncelle.Enabled = true;
                btnGuncelle.Text = "✏️ Güncelle";
            }
        }

        private bool ValidateForm()
        {
            // Cari adı zorunlu
            if (string.IsNullOrWhiteSpace(txtCariAdi.Text))
            {
                MessageBox.Show("Cari adı boş bırakılamaz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCariAdi.Focus();
                return false;
            }

            // Kredi limiti kontrolü
            if (!decimal.TryParse(txtKrediLimiti.Text, out decimal limit) || limit < 0)
            {
                MessageBox.Show("Geçerli bir kredi limiti giriniz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKrediLimiti.Focus();
                return false;
            }

            // Email formatı kontrolü (eğer girilmişse)
            if (!string.IsNullOrWhiteSpace(txtEPosta.Text))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(txtEPosta.Text);
                    if (addr.Address != txtEPosta.Text)
                    {
                        throw new FormatException();
                    }
                }
                catch
                {
                    MessageBox.Show("Geçerli bir e-posta adresi giriniz!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEPosta.Focus();
                    return false;
                }
            }

            // Cari tipi seçimi
            if (cmbCariTipi.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir cari tipi seçiniz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCariTipi.Focus();
                return false;
            }

            return true;
        }
    }

    // DTO'lar
    public class UpdateCariAccountDto
    {
        public string CariName { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? TaxNo { get; set; } // API'deki field adı
        public string? TaxOffice { get; set; }
        public decimal CreditLimit { get; set; }
        public bool IsActive { get; set; } = true;
        public int TypeID { get; set; }
    }
}
