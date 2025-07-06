using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class SettingsForm : Form
    {
        // UI Controls
        private TabControl tabControl;
        private TabPage tabGeneral;
        private TabPage tabUser;
        private TabPage tabSystem;
        private TabPage tabAbout;
        private Panel pnlButtons;
        private Button btnSave;
        private Button btnCancel;
        private Button btnApply;

        // General Tab Controls
        private Label lblCompanyName;
        private TextBox txtCompanyName;
        private Label lblCompanyAddress;
        private TextBox txtCompanyAddress;
        private Label lblCompanyPhone;
        private TextBox txtCompanyPhone;
        private Label lblCompanyEmail;
        private TextBox txtCompanyEmail;
        private Label lblTaxNumber;
        private TextBox txtTaxNumber;

        // User Tab Controls
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnChangePassword;

        // System Tab Controls
        private Label lblApiUrl;
        private TextBox txtApiUrl;
        private Button btnTestConnection;
        private Label lblConnectionStatus;
        private CheckBox chkAutoLogin;
        private CheckBox chkRememberMe;
        private Label lblSessionTimeout;
        private NumericUpDown numSessionTimeout;

        // About Tab Controls
        private Label lblAppName;
        private Label lblAppVersion;
        private Label lblAppDescription;
        private Label lblDeveloper;
        private Label lblCopyright;

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void InitializeComponent()
        {
            this.Text = "Ayarlar";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Tab Control
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Padding = new Point(10, 10)
            };

            // Bottom panel for buttons
            pnlButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.LightGray
            };

            // Buttons
            btnSave = new Button
            {
                Text = "Kaydet",
                Size = new Size(80, 30),
                Location = new Point(330, 10),
                BackColor = Color.LightGreen,
                DialogResult = DialogResult.OK
            };

            btnCancel = new Button
            {
                Text = "İptal",
                Size = new Size(80, 30),
                Location = new Point(420, 10),
                BackColor = Color.LightCoral,
                DialogResult = DialogResult.Cancel
            };

            btnApply = new Button
            {
                Text = "Uygula",
                Size = new Size(80, 30),
                Location = new Point(510, 10),
                BackColor = Color.LightBlue
            };

            // Add button event handlers
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnApply.Click += BtnApply_Click;

            // Create tabs
            CreateGeneralTab();
            CreateUserTab();
            CreateSystemTab();
            CreateAboutTab();

            // Add controls to form
            pnlButtons.Controls.AddRange(new Control[] { btnSave, btnCancel, btnApply });
            this.Controls.AddRange(new Control[] { tabControl, pnlButtons });
        }

        private void CreateGeneralTab()
        {
            tabGeneral = new TabPage("Genel");
            tabGeneral.BackColor = Color.White;

            // Company Name
            lblCompanyName = new Label
            {
                Text = "Şirket Adı:",
                Location = new Point(20, 30),
                Size = new Size(100, 20)
            };

            txtCompanyName = new TextBox
            {
                Location = new Point(130, 28),
                Size = new Size(300, 23),
                Text = "MiniERP Şirketi"
            };

            // Company Address
            lblCompanyAddress = new Label
            {
                Text = "Adres:",
                Location = new Point(20, 70),
                Size = new Size(100, 20)
            };

            txtCompanyAddress = new TextBox
            {
                Location = new Point(130, 68),
                Size = new Size(300, 60),
                Multiline = true,
                Text = "Örnek Mahallesi, Örnek Sokak No:1\nÖrnek İlçe / Örnek İl"
            };

            // Company Phone
            lblCompanyPhone = new Label
            {
                Text = "Telefon:",
                Location = new Point(20, 150),
                Size = new Size(100, 20)
            };

            txtCompanyPhone = new TextBox
            {
                Location = new Point(130, 148),
                Size = new Size(200, 23),
                Text = "+90 (212) 123 45 67"
            };

            // Company Email
            lblCompanyEmail = new Label
            {
                Text = "E-posta:",
                Location = new Point(20, 190),
                Size = new Size(100, 20)
            };

            txtCompanyEmail = new TextBox
            {
                Location = new Point(130, 188),
                Size = new Size(200, 23),
                Text = "info@minierp.com"
            };

            // Tax Number
            lblTaxNumber = new Label
            {
                Text = "Vergi No:",
                Location = new Point(20, 230),
                Size = new Size(100, 20)
            };

            txtTaxNumber = new TextBox
            {
                Location = new Point(130, 228),
                Size = new Size(200, 23),
                Text = "1234567890"
            };

            tabGeneral.Controls.AddRange(new Control[] {
                lblCompanyName, txtCompanyName,
                lblCompanyAddress, txtCompanyAddress,
                lblCompanyPhone, txtCompanyPhone,
                lblCompanyEmail, txtCompanyEmail,
                lblTaxNumber, txtTaxNumber
            });

            tabControl.TabPages.Add(tabGeneral);
        }

        private void CreateUserTab()
        {
            tabUser = new TabPage("Kullanıcı");
            tabUser.BackColor = Color.White;

            // Username
            lblUsername = new Label
            {
                Text = "Kullanıcı Adı:",
                Location = new Point(20, 30),
                Size = new Size(100, 20)
            };

            txtUsername = new TextBox
            {
                Location = new Point(130, 28),
                Size = new Size(200, 23),
                ReadOnly = true,
                Text = "admin"
            };

            // Email
            lblEmail = new Label
            {
                Text = "E-posta:",
                Location = new Point(20, 70),
                Size = new Size(100, 20)
            };

            txtEmail = new TextBox
            {
                Location = new Point(130, 68),
                Size = new Size(200, 23),
                Text = "admin@minierp.com"
            };

            // Current Password
            lblCurrentPassword = new Label
            {
                Text = "Mevcut Şifre:",
                Location = new Point(20, 120),
                Size = new Size(100, 20)
            };

            txtCurrentPassword = new TextBox
            {
                Location = new Point(130, 118),
                Size = new Size(200, 23),
                PasswordChar = '*'
            };

            // New Password
            lblNewPassword = new Label
            {
                Text = "Yeni Şifre:",
                Location = new Point(20, 160),
                Size = new Size(100, 20)
            };

            txtNewPassword = new TextBox
            {
                Location = new Point(130, 158),
                Size = new Size(200, 23),
                PasswordChar = '*'
            };

            // Confirm Password
            lblConfirmPassword = new Label
            {
                Text = "Şifre Tekrarı:",
                Location = new Point(20, 200),
                Size = new Size(100, 20)
            };

            txtConfirmPassword = new TextBox
            {
                Location = new Point(130, 198),
                Size = new Size(200, 23),
                PasswordChar = '*'
            };

            // Change Password Button
            btnChangePassword = new Button
            {
                Text = "Şifre Değiştir",
                Location = new Point(130, 240),
                Size = new Size(100, 30),
                BackColor = Color.LightBlue
            };

            btnChangePassword.Click += BtnChangePassword_Click;

            tabUser.Controls.AddRange(new Control[] {
                lblUsername, txtUsername,
                lblEmail, txtEmail,
                lblCurrentPassword, txtCurrentPassword,
                lblNewPassword, txtNewPassword,
                lblConfirmPassword, txtConfirmPassword,
                btnChangePassword
            });

            tabControl.TabPages.Add(tabUser);
        }

        private void CreateSystemTab()
        {
            tabSystem = new TabPage("Sistem");
            tabSystem.BackColor = Color.White;

            // API URL
            lblApiUrl = new Label
            {
                Text = "API URL:",
                Location = new Point(20, 30),
                Size = new Size(100, 20)
            };

            txtApiUrl = new TextBox
            {
                Location = new Point(130, 28),
                Size = new Size(250, 23),
                Text = "https://localhost:7073/api"
            };

            // Test Connection Button
            btnTestConnection = new Button
            {
                Text = "Bağlantı Test",
                Location = new Point(390, 28),
                Size = new Size(100, 25),
                BackColor = Color.LightYellow
            };

            btnTestConnection.Click += BtnTestConnection_Click;

            // Connection Status
            lblConnectionStatus = new Label
            {
                Text = "Bağlantı durumu: Bilinmiyor",
                Location = new Point(130, 60),
                Size = new Size(200, 20),
                ForeColor = Color.DarkGray
            };

            // Auto Login
            chkAutoLogin = new CheckBox
            {
                Text = "Otomatik giriş",
                Location = new Point(20, 100),
                Size = new Size(150, 20)
            };

            // Remember Me
            chkRememberMe = new CheckBox
            {
                Text = "Beni hatırla",
                Location = new Point(20, 130),
                Size = new Size(150, 20),
                Checked = true
            };

            // Session Timeout
            lblSessionTimeout = new Label
            {
                Text = "Oturum Süresi (dk):",
                Location = new Point(20, 170),
                Size = new Size(120, 20)
            };

            numSessionTimeout = new NumericUpDown
            {
                Location = new Point(150, 168),
                Size = new Size(80, 23),
                Minimum = 15,
                Maximum = 480,
                Value = 60
            };

            tabSystem.Controls.AddRange(new Control[] {
                lblApiUrl, txtApiUrl, btnTestConnection,
                lblConnectionStatus,
                chkAutoLogin, chkRememberMe,
                lblSessionTimeout, numSessionTimeout
            });

            tabControl.TabPages.Add(tabSystem);
        }

        private void CreateAboutTab()
        {
            tabAbout = new TabPage("Hakkında");
            tabAbout.BackColor = Color.White;

            // App Name
            lblAppName = new Label
            {
                Text = "MiniERP Windows Forms",
                Location = new Point(20, 30),
                Size = new Size(400, 30),
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };

            // App Version
            lblAppVersion = new Label
            {
                Text = "Versiyon: 1.0.0",
                Location = new Point(20, 70),
                Size = new Size(200, 20),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            // App Description
            lblAppDescription = new Label
            {
                Text = "Küçük ve orta ölçekli işletmeler için tasarlanmış\nBasit ERP çözümü",
                Location = new Point(20, 110),
                Size = new Size(400, 40),
                Font = new Font("Arial", 9, FontStyle.Regular)
            };

            // Developer
            lblDeveloper = new Label
            {
                Text = "Geliştirici: MiniERP Ekibi",
                Location = new Point(20, 170),
                Size = new Size(200, 20),
                Font = new Font("Arial", 9, FontStyle.Regular)
            };

            // Copyright
            lblCopyright = new Label
            {
                Text = "© 2024 MiniERP. Tüm hakları saklıdır.",
                Location = new Point(20, 210),
                Size = new Size(300, 20),
                Font = new Font("Arial", 9, FontStyle.Regular),
                ForeColor = Color.DarkGray
            };

            tabAbout.Controls.AddRange(new Control[] {
                lblAppName, lblAppVersion, lblAppDescription,
                lblDeveloper, lblCopyright
            });

            tabControl.TabPages.Add(tabAbout);
        }

        private void LoadSettings()
        {
            // Load settings from configuration or database
            // This is a placeholder implementation
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveSettings())
            {
                MessageBox.Show("Ayarlar başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (SaveSettings())
            {
                MessageBox.Show("Ayarlar uygulandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool SaveSettings()
        {
            try
            {
                // Save settings to configuration or database
                // This is a placeholder implementation
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ayarlar kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text) ||
                string.IsNullOrEmpty(txtNewPassword.Text) ||
                string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Lütfen tüm şifre alanlarını doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Yeni şifre ve tekrarı eşleşmiyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Yeni şifre en az 6 karakter olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Change password logic here
                MessageBox.Show("Şifre başarıyla değiştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Clear password fields
                txtCurrentPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şifre değiştirirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                lblConnectionStatus.Text = "Bağlantı test ediliyor...";
                lblConnectionStatus.ForeColor = Color.Blue;
                btnTestConnection.Enabled = false;

                // Test connection logic here
                await Task.Delay(1000); // Simulate API call

                lblConnectionStatus.Text = "Bağlantı başarılı";
                lblConnectionStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblConnectionStatus.Text = $"Bağlantı başarısız: {ex.Message}";
                lblConnectionStatus.ForeColor = Color.Red;
            }
            finally
            {
                btnTestConnection.Enabled = true;
            }
        }
    }
} 