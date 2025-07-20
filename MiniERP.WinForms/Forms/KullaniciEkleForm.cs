using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class KullaniciEkleForm : Form
    {
        private readonly UserService _userService;
        private readonly string _currentUserRole;
        private Dictionary<string, string> _roleDescriptions = new();

        public UserDto? CreatedUser { get; private set; }

        public KullaniciEkleForm(UserService userService, string currentUserRole)
        {
            InitializeComponent();
            _userService = userService;
            _currentUserRole = currentUserRole;
            InitializeRoleDescriptions();
            InitializeForm();
        }

        private void InitializeRoleDescriptions()
        {
            _roleDescriptions = new Dictionary<string, string>
            {
                { "Admin", "Sistemin tüm özelliklerine tam erişim" },
                { "Manager", "Yönetim düzeyinde işlemler ve raporlama" },
                { "Sales", "Satış işlemleri ve müşteri yönetimi" },
                { "Purchase", "Satın alma işlemleri ve tedarikçi yönetimi" },
                { "Finance", "Finansal işlemler ve muhasebe" },
                { "Warehouse", "Depo yönetimi ve stok işlemleri" },
                { "Employee", "Temel işlemler ve raporlar" }
            };
        }

        private void InitializeForm()
        {
            // Rol ComboBox'ını doldur
            cmbRol.Items.Clear();
            cmbRol.Items.AddRange(_userService.GetAvailableRoles().ToArray());
            cmbRol.SelectedIndex = 6; // Employee default
            
            // Aktif checkbox default true
            chkAktif.Checked = true;
        }

        private bool ValidateForm()
        {
            // Kullanıcı adı kontrolü
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Focus();
                return false;
            }

            if (txtKullaniciAdi.Text.Length < 3)
            {
                MessageBox.Show("Kullanıcı adı en az 3 karakter olmalıdır.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Focus();
                return false;
            }

            // Ad kontrolü
            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                MessageBox.Show("Ad boş olamaz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAd.Focus();
                return false;
            }

            // Soyad kontrolü
            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Soyad boş olamaz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoyad.Focus();
                return false;
            }

            // Email kontrolü (opsiyonel ama geçerli olmalı)
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Geçerli bir email adresi giriniz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            // Şifre kontrolü
            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Şifre boş olamaz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Focus();
                return false;
            }

            if (txtSifre.Text.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakter olmalıdır.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Focus();
                return false;
            }

            // Şifre tekrarı kontrolü
            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler eşleşmiyor.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifreTekrar.Focus();
                return false;
            }

            // Rol kontrolü
            if (cmbRol.SelectedIndex < 0)
            {
                MessageBox.Show("Bir rol seçiniz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnKaydet.Enabled = false;
                btnIptal.Enabled = false;

                var createDto = new CreateUserDto
                {
                    Username = txtKullaniciAdi.Text.Trim(),
                    FirstName = txtAd.Text.Trim(),
                    LastName = txtSoyad.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtSifre.Text,
                    ConfirmPassword = txtSifreTekrar.Text,
                    Role = cmbRol.SelectedItem?.ToString() ?? string.Empty
                };

                var response = await _userService.CreateUserAsync(createDto);

                if (response.Success)
                {
                    MessageBox.Show("Kullanıcı başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem sırasında hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnKaydet.Enabled = true;
                btnIptal.Enabled = true;
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            // Kullanıcı adında Türkçe karakter ve özel karakter kontrolü
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                string text = textBox.Text;
                string newText = "";
                
                foreach (char c in text)
                {
                    if (char.IsLetterOrDigit(c) || c == '_' || c == '.')
                    {
                        newText += c;
                    }
                }
                
                if (newText != text)
                {
                    textBox.Text = newText;
                    textBox.SelectionStart = newText.Length;
                }
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Rol açıklamalarını göster
            if (cmbRol.SelectedItem != null)
            {
                string role = cmbRol.SelectedItem.ToString() ?? string.Empty;
                string description = GetRoleDescription(role);
                lblRolAciklama.Text = description;
            }
        }

        private string GetRoleDescription(string role)
        {
            return role switch
            {
                "Admin" => "Tam yetki - Tüm modüllere erişim",
                "Manager" => "Yönetici - Çoğu modüle erişim",
                "Sales" => "Satış - Satış ve cari işlemleri",
                "Purchase" => "Satın Alma - Alış ve stok işlemleri",
                "Finance" => "Finans - Ödeme ve tahsilat işlemleri",
                "Warehouse" => "Depo - Stok ve depo işlemleri",
                "Employee" => "Çalışan - Temel erişim",
                _ => "Özel rol"
            };
        }
    }
}
