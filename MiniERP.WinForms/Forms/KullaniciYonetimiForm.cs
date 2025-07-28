using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class KullaniciYonetimiForm : Form
    {
        private readonly UserService _userService;
        private List<UserDto> _kullanicilar = new List<UserDto>();
        private string _currentUserRole = "";
        private int _currentUserId = 0;

        public KullaniciYonetimiForm(UserService userService, string currentUserRole, int currentUserId)
        {
            InitializeComponent();
            _userService = userService;
            _currentUserRole = currentUserRole;
            _currentUserId = currentUserId;
            
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Rol tabanlı buton erişimi
            SetRoleBasedAccess();
            
            // ComboBox'ı doldur
            FillRoleComboBox();
            
            // DataGridView kolonlarını ayarla
            SetupDataGridView();
            
            // Kullanıcıları yükle
            LoadUsers();
        }

        private void SetRoleBasedAccess()
        {
            // Sadece Admin yeni kullanıcı oluşturabilir
            btnYeniKullanici.Visible = _currentUserRole == "Admin";
            
            // Form başlığına rol bilgisi ekle
            this.Text = $"Kullanıcı Yönetimi - {_currentUserRole}";
        }

        private void FillRoleComboBox()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Tümü");
            cmbRol.Items.AddRange(_userService.GetAvailableRoles().ToArray());
            cmbRol.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            dgvKullanicilar.Columns.Clear();
            dgvKullanicilar.AutoGenerateColumns = false;
            
            // Kullanıcı Adı
            dgvKullanicilar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Kullanıcı Adı",
                Width = 120,
                ReadOnly = true
            });

            // Ad Soyad
            dgvKullanicilar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "Ad Soyad",
                Width = 150,
                ReadOnly = true
            });

            // Email
            dgvKullanicilar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                Width = 180,
                ReadOnly = true
            });

            // Rol
            dgvKullanicilar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Role",
                HeaderText = "Rol",
                Width = 100,
                ReadOnly = true
            });

            // Durum
            dgvKullanicilar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Durum",
                Width = 80,
                ReadOnly = true
            });

            // Son Giriş
            dgvKullanicilar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LastLogin",
                HeaderText = "Son Giriş",
                Width = 120,
                ReadOnly = true
            });

            // Detay Butonu
            dgvKullanicilar.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "DetailButton",
                HeaderText = "Detay",
                Text = "👁️ Detay",
                UseColumnTextForButtonValue = true,
                Width = 80
            });

            // Düzenle Butonu (Admin ve Manager için)
            if (_currentUserRole == "Admin" || _currentUserRole == "Manager")
            {
                dgvKullanicilar.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "EditButton",
                    HeaderText = "Düzenle",
                    Text = "✏️ Düzenle",
                    UseColumnTextForButtonValue = true,
                    Width = 90
                });
            }

            // Durum Değiştir Butonu (Admin ve Manager için)
            if (_currentUserRole == "Admin" || _currentUserRole == "Manager")
            {
                dgvKullanicilar.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "StatusButton",
                    HeaderText = "Durum",
                    Text = "🔄 Değiştir",
                    UseColumnTextForButtonValue = true,
                    Width = 90
                });
            }

            // Sil Butonu (Sadece Admin için)
            if (_currentUserRole == "Admin")
            {
                dgvKullanicilar.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "DeleteButton",
                    HeaderText = "Sil",
                    Text = "🗑️ Sil",
                    UseColumnTextForButtonValue = true,
                    Width = 70
                });
            }

            // CellFormatting event'ini ekle - Manager için Admin kullanıcılarına butonları disable etmek için
            dgvKullanicilar.CellFormatting += DgvKullanicilar_CellFormatting;
        }

        private void DgvKullanicilar_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _kullanicilar.Count)
            {
                var user = _kullanicilar[e.RowIndex];
                var columnName = dgvKullanicilar.Columns[e.ColumnIndex].Name;

                // Manager için Admin kullanıcılarına edit ve status butonlarını disable et
                if (_currentUserRole == "Manager" && user.Roles.Contains("Admin"))
                {
                    if (columnName == "EditButton" || columnName == "StatusButton")
                    {
                        e.Value = "🚫 Yetki Yok";
                        e.FormattingApplied = true;
                        
                        // Cell'in style'ını değiştir
                        var cell = dgvKullanicilar.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.DarkGray;
                    }
                }
            }
        }

        private string TranslateApiMessage(string? message)
        {
            if (string.IsNullOrEmpty(message))
                return "Bilinmeyen hata oluştu.";

            // API'den gelen İngilizce mesajları Türkçe'ye çevir
            var translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "User not found", "Kullanıcı bulunamadı" },
                { "Invalid username or password", "Kullanıcı adı veya şifre hatalı" },
                { "You cannot delete your own account", "Kendi hesabınızı silemezsiniz" },
                { "You cannot change your own activation status", "Kendi hesabınızın durumunu değiştiremezsiniz" },
                { "Manager yetkisindeki kullanıcılar Admin yetkisindeki kullanıcıları düzenleyemez", "Manager yetkisindeki kullanıcılar Admin yetkisindeki kullanıcıları düzenleyemez" },
                { "Manager yetkisindeki kullanıcılar Admin yetkisindeki kullanıcıların aktiflik durumunu değiştiremez", "Manager yetkisindeki kullanıcılar Admin yetkisindeki kullanıcıların aktiflik durumunu değiştiremez" },
                { "Invalid input data", "Geçersiz veri girişi" },
                { "User activated successfully", "Kullanıcı başarıyla aktifleştirildi" },
                { "User deactivated successfully", "Kullanıcı başarıyla pasifleştirildi" },
                { "User deleted successfully", "Kullanıcı başarıyla silindi" },
                { "User updated successfully", "Kullanıcı başarıyla güncellendi" },
                { "User created successfully", "Kullanıcı başarıyla oluşturuldu" },
                { "Access denied", "Erişim reddedildi" },
                { "Forbidden", "Yasaklı işlem" },
                { "Bad Request", "Geçersiz istek" },
                { "Internal Server Error", "Sunucu hatası" },
                { "An error occurred", "Bir hata oluştu" }
            };

            // Tam eşleşme ara
            if (translations.ContainsKey(message))
            {
                return translations[message];
            }

            // Kısmi eşleşme ara
            foreach (var translation in translations)
            {
                if (message.Contains(translation.Key, StringComparison.OrdinalIgnoreCase))
                {
                    return message.Replace(translation.Key, translation.Value, StringComparison.OrdinalIgnoreCase);
                }
            }

            // Çeviri bulunamazsa orijinal mesajı döndür
            return message;
        }

        private async void LoadUsers()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnYenile.Enabled = false;

                string searchTerm = txtArama.Text.Trim();
                string? selectedRole = cmbRol.SelectedItem?.ToString();
                if (selectedRole == "Tümü") selectedRole = "";

                var result = await _userService.GetUsersAsync(1, 100, searchTerm, selectedRole ?? string.Empty);
                
                _kullanicilar = result.Data.ToList();
                
                // DataGridView'ı temizle
                dgvKullanicilar.Rows.Clear();
                
                // Manuel olarak satır ekle
                foreach (var user in _kullanicilar)
                {
                    string status = user.IsActive ? "Aktif" : "Pasif";
                    string lastLogin = user.LastLoginDate?.ToString("dd.MM.yyyy HH:mm") ?? "Hiç giriş yapmamış";
                    
                    dgvKullanicilar.Rows.Add(
                        user.Username,
                        user.FullName,
                        user.Email,
                        user.Role,
                        status,
                        lastLogin
                    );
                }
                
                lblToplam.Text = $"Toplam: {result.TotalCount} kullanıcı";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcılar yüklenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnYenile.Enabled = true;
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnYeniKullanici_Click(object sender, EventArgs e)
        {
            if (_currentUserRole != "Admin")
            {
                MessageBox.Show("Sadece Admin kullanıcıları yeni kullanıcı oluşturabilir.", 
                    "Yetkisiz İşlem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new KullaniciEkleForm(_userService, _currentUserRole);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void txtArama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadUsers();
                e.Handled = true;
            }
        }

        private void dgvKullanicilar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _kullanicilar.Count)
            {
                var selectedUser = _kullanicilar[e.RowIndex];
                ShowUserDetails(selectedUser);
            }
        }

        private async void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _kullanicilar.Count)
            {
                var selectedUser = _kullanicilar[e.RowIndex];
                var columnName = dgvKullanicilar.Columns[e.ColumnIndex].Name;

                // Manager için Admin kullanıcılarına butonları tamamen engelle
                if (_currentUserRole == "Manager" && selectedUser.Roles.Contains("Admin"))
                {
                    if (columnName == "EditButton" || columnName == "StatusButton")
                    {
                        MessageBox.Show("Manager yetkisindeki kullanıcılar Admin yetkisindeki kullanıcıları yönetemez.", 
                            "Yetkisiz İşlem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                switch (columnName)
                {
                    case "DetailButton":
                        ShowUserDetails(selectedUser);
                        break;

                    case "EditButton":
                        if (_currentUserRole == "Admin" || _currentUserRole == "Manager")
                        {
                            EditUser(selectedUser);
                        }
                        break;

                    case "StatusButton":
                        if (_currentUserRole == "Admin" || _currentUserRole == "Manager")
                        {
                            await ToggleUserActivation(selectedUser);
                        }
                        break;

                    case "DeleteButton":
                        if (_currentUserRole == "Admin")
                        {
                            await DeleteUser(selectedUser);
                        }
                        break;
                }
            }
        }

        private void ShowUserDetails(UserDto kullanici)
        {
            var form = new KullaniciDetayForm(kullanici, _currentUserRole);
            form.ShowDialog();
        }

        private void EditUser(UserDto kullanici)
        {
            var form = new KullaniciDuzenleForm(_userService, kullanici.UserID);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private async Task ToggleUserActivation(UserDto kullanici)
        {
            if (kullanici.UserID == _currentUserId)
            {
                MessageBox.Show("Kendi hesabınızın durumunu değiştiremezsiniz.", 
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Manager yetkisindeki kullanıcı Admin yetkisindeki kullanıcının aktiflik durumunu değiştiremez
            // Bu kontrol CellClick'te yapılıyor artık

            string action = kullanici.IsActive ? "pasifleştirmek" : "aktifleştirmek";
            var result = MessageBox.Show($"{kullanici.Username} kullanıcısını {action} istediğinizden emin misiniz?", 
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    var response = await _userService.ToggleUserActivationAsync(kullanici.UserID);
                    
                    if (response.Success)
                    {
                        MessageBox.Show(TranslateApiMessage(response.Message), "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show(TranslateApiMessage(response.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }
            }
        }        private async Task DeleteUser(UserDto kullanici)
        {
            if (kullanici.UserID == _currentUserId)
            {
                MessageBox.Show("Kendi hesabınızı silemezsiniz.", 
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"{kullanici.Username} kullanıcısını silmek istediğinizden emin misiniz?\n\nBu işlem geri alınamaz!", 
                "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    var response = await _userService.DeleteUserAsync(kullanici.UserID);
                    
                    if (response.Success)
                    {
                        MessageBox.Show("Kullanıcı başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show(TranslateApiMessage(response.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }
            }
        }

        private void btnDetay_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen detayını görmek istediğiniz kullanıcıyı seçiniz.", "Seçim Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUser = _kullanicilar[dgvKullanicilar.SelectedRows[0].Index];
            
            using (var detayForm = new KullaniciDetayForm(selectedUser, _currentUserRole))
            {
                detayForm.ShowDialog();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz kullanıcıyı seçiniz.", "Seçim Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yetki kontrolü
            if (_currentUserRole != "Admin" && _currentUserRole != "Manager")
            {
                MessageBox.Show("Kullanıcı düzenleme yetkiniz bulunmamaktadır.", "Yetkisiz İşlem", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUser = _kullanicilar[dgvKullanicilar.SelectedRows[0].Index];

            // Manager yetkisindeki kullanıcı Admin yetkisindeki kullanıcıyı düzenleyemez
            if (_currentUserRole == "Manager" && selectedUser.Roles.Contains("Admin"))
            {
                MessageBox.Show("Manager yetkisindeki kullanıcılar Admin yetkisindeki kullanıcıları düzenleyemez.", 
                    "Yetkisiz İşlem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            using (var duzenleForm = new KullaniciDuzenleForm(_userService, selectedUser.UserID))
            {
                if (duzenleForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz kullanıcıyı seçiniz.", "Seçim Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sadece Admin silebilir
            if (_currentUserRole != "Admin")
            {
                MessageBox.Show("Kullanıcı silme yetkiniz bulunmamaktadır.", "Yetkisiz İşlem", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUser = _kullanicilar[dgvKullanicilar.SelectedRows[0].Index];

            var result = MessageBox.Show($"{selectedUser.FirstName} {selectedUser.LastName} kullanıcısını silmek istediğinizden emin misiniz?\n\nBu işlem geri alınamaz!",
                "Kullanıcı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteUser(selectedUser.UserID);
            }
        }

        private async void DeleteUser(int userId)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                var response = await _userService.DeleteUserAsync(userId);
                
                if (response.Success)
                {
                    MessageBox.Show("Kullanıcı başarıyla silindi.", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show(TranslateApiMessage(response.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme işlemi sırasında hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
