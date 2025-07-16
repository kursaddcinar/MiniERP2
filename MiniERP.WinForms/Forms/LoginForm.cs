using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class LoginForm : Form
    {
        private readonly ApiService _apiService;

        public LoginForm()
        {
            InitializeComponent();
            _apiService = new ApiService();
            
            // Enter key events
            this.KeyPreview = true;
            this.KeyDown += LoginForm_KeyDown;
            txtPassword.KeyDown += TxtPassword_KeyDown;
        }

        private void LoginForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void TxtPassword_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void PanelLogin_Paint(object sender, PaintEventArgs e)
        {
            // Add border radius effect
            var panel = sender as Panel;
            if (panel != null)
            {
                var rect = new Rectangle(0, 0, panel.Width, panel.Height);
                var radius = 10;
                
                using (var path = GetRoundedRectangle(rect, radius))
                {
                    panel.Region = new Region(path);
                }
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        private async void BtnLogin_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Giriş yapılıyor...";

            try
            {
                var loginDto = new LoginDto
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text
                };

                var result = await _apiService.LoginAsync(loginDto);

                if (result.Success && result.Data != null)
                {
                    _apiService.SetAuthToken(result.Data.Token);
                    TokenManager.SetToken(result.Data.Token); // Store token globally
                    
                    MessageBox.Show($"Hoş geldiniz, {result.Data.User.Username}!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Open main form
                    var mainForm = new MainForm(result.Data.User, _apiService);
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show(result.Message, "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "→ Giriş Yap";
            }
        }

        private void BtnRole_Click(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                var roleName = button.Text.Split(' ')[1]; // Get role name after emoji
                txtUsername.Text = roleName.ToLower();
                txtPassword.Text = roleName.ToLower();
                
                // Auto login
                BtnLogin_Click(sender, e);
            }
        }

        private async void BtnTestCreate_Click(object? sender, EventArgs e)
        {
            btnTestCreate.Enabled = false;
            btnTestCreate.Text = "Kullanıcılar oluşturuluyor...";

            try
            {
                // In a real application, you would call an API to create test users
                // For now, we'll just show a message
                await Task.Delay(1000); // Simulate API call
                
                MessageBox.Show("Test kullanıcıları başarıyla oluşturuldu!\n\nKullanıcılar: admin, manager, sales, purchase, finance, warehouse, employee\nTüm şifreler kullanıcı adı ile aynıdır.", 
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Test kullanıcıları oluşturulurken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTestCreate.Enabled = true;
                btnTestCreate.Text = "👥 Test Kullanıcılarını Oluştur";
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _apiService?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
