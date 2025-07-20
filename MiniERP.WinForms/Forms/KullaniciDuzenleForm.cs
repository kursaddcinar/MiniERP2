using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniERP.WinForms.Services;
using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Helpers;

namespace MiniERP.WinForms.Forms
{
    public partial class KullaniciDuzenleForm : Form
    {
        private readonly UserService _userService;
        private readonly int _userId;
        private UserDto? _user;

        public KullaniciDuzenleForm(UserService userService, int userId)
        {
            _userService = userService;
            _userId = userId;
            InitializeComponent();
            LoadUserData();
            LoadRoles();
        }

        private async void LoadUserData()
        {
            try
            {
                var response = await _userService.GetUserByIdAsync(_userId);
                if (response.Success && response.Data != null)
                {
                    _user = response.Data;
                    txtKullaniciAdi.Text = _user.Username;
                    txtEmail.Text = _user.Email;
                    txtAd.Text = _user.FirstName;
                    txtSoyad.Text = _user.LastName;
                    chkAktif.Checked = _user.IsActive;
                    
                    // Rol seçimi
                    if (!string.IsNullOrEmpty(_user.Role))
                    {
                        for (int i = 0; i < cmbRol.Items.Count; i++)
                        {
                            if (cmbRol.Items[i]?.ToString() == _user.Role)
                            {
                                cmbRol.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Kullanıcı bulunamadı: {response.Message}", 
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı bilgileri yüklenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoles()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Admin");
            cmbRol.Items.Add("User");
            cmbRol.Items.Add("Manager");
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    var updateDto = new UpdateUserDto
                    {
                        Id = _userId,
                        Username = txtKullaniciAdi.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        FirstName = txtAd.Text.Trim(),
                        LastName = txtSoyad.Text.Trim(),
                        Role = cmbRol.SelectedItem?.ToString() ?? "User",
                        IsActive = chkAktif.Checked
                    };

                    // Şifre alanı dolu ise şifreyi de güncelle
                    if (!string.IsNullOrEmpty(txtSifre.Text))
                    {
                        updateDto.Password = txtSifre.Text;
                    }

                    var response = await _userService.UpdateUserAsync(_userId, updateDto);
                    if (response.Success)
                    {
                        MessageBox.Show("Kullanıcı başarıyla güncellendi.", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı güncellenirken hata oluştu.", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("E-posta adresi boş olamaz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Geçerli bir e-posta adresi giriniz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                MessageBox.Show("Ad boş olamaz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAd.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Soyad boş olamaz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoyad.Focus();
                return false;
            }

            if (cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir rol seçiniz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            // Kullanıcı adı değişikliği takibi için
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Rol değişikliği takibi için
        }
    }
}
