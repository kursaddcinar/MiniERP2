using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class KullaniciDetayForm : Form
    {
        private readonly UserDto _kullanici;
        private readonly UserService _userService;
        private readonly string _currentUserRole;
        private readonly int _currentUserId;

        public KullaniciDetayForm(UserDto kullanici, string currentUserRole)
        {
            InitializeComponent();
            _kullanici = kullanici;
            _userService = new UserService(new ApiService());
            _currentUserRole = currentUserRole;
            _currentUserId = kullanici.UserID;
            
            LoadUserDetails();
            SetRoleBasedAccess();
        }

        private void LoadUserDetails()
        {
            lblKullaniciAdi.Text = _kullanici.Username;
            lblAdSoyad.Text = _kullanici.FullName;
            lblEmail.Text = !string.IsNullOrEmpty(_kullanici.Email) ? _kullanici.Email : "-";
            
            // Rol etiketleri
            flowLayoutRoller.Controls.Clear();
            foreach (var role in _kullanici.Roles)
            {
                var lblRole = new Label
                {
                    Text = role,
                    AutoSize = true,
                    Padding = new Padding(8, 4, 8, 4),
                    Margin = new Padding(3),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = GetRoleColor(role),
                    BorderStyle = BorderStyle.None
                };
                flowLayoutRoller.Controls.Add(lblRole);
            }

            // Durum
            lblDurum.Text = _kullanici.IsActive ? "✅ Aktif" : "❌ Pasif";
            lblDurum.ForeColor = _kullanici.IsActive ? Color.Green : Color.Red;

            // Tarihler
            lblOlusturmaTarihi.Text = _kullanici.CreatedDate.ToString("dd.MM.yyyy HH:mm");
            lblSonGiris.Text = _kullanici.LastLoginDate?.ToString("dd.MM.yyyy HH:mm") ?? "Hiç giriş yapmamış";
        }

        private Color GetRoleColor(string role)
        {
            return role switch
            {
                "Admin" => Color.FromArgb(220, 53, 69),
                "Manager" => Color.FromArgb(255, 193, 7),
                "Sales" => Color.FromArgb(40, 167, 69),
                "Purchase" => Color.FromArgb(108, 117, 125),
                "Finance" => Color.FromArgb(23, 162, 184),
                "Warehouse" => Color.FromArgb(111, 66, 193),
                _ => Color.FromArgb(13, 110, 253)
            };
        }

        private void SetRoleBasedAccess()
        {
            // Düzenle butonu sadece Admin ve Manager için
            btnDuzenle.Visible = _currentUserRole == "Admin" || _currentUserRole == "Manager";
            
            // Pasifleştir butonu sadece Admin ve Manager için
            btnPasiflik.Visible = _currentUserRole == "Admin" || _currentUserRole == "Manager";
            
            // Kendi hesabını değiştiremez
            if (_kullanici.UserID == _currentUserId)
            {
                btnPasiflik.Visible = false;
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            var form = new KullaniciDuzenleForm(_userService, _kullanici.UserID);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async void btnPasiflik_Click(object sender, EventArgs e)
        {
            if (_kullanici.UserID == _currentUserId)
            {
                MessageBox.Show("Kendi hesabınızın durumunu değiştiremezsiniz.", 
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string action = _kullanici.IsActive ? "pasifleştirmek" : "aktifleştirmek";
            var result = MessageBox.Show($"{_kullanici.Username} kullanıcısını {action} istediğinizden emin misiniz?", 
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    btnPasiflik.Enabled = false;

                    var response = await _userService.ToggleUserActivationAsync(_kullanici.UserID);
                    
                    if (response.Success)
                    {
                        MessageBox.Show(response.Message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    btnPasiflik.Enabled = true;
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
