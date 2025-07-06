using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private readonly ApiService _apiService;

        public LoginForm() : this(new ApiService())
        {
        }

        public LoginForm(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
            _authService = new AuthService(_apiService);
        }

        public UserDto? LoggedInUser { get; private set; }
        public string? AuthToken { get; private set; }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre gereklidir!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                var response = await _authService.LoginAsync(loginDto);

                // Debug: Raw response kontrolü
                Console.WriteLine($"LoginForm: AuthService response success: {response.Success}");
                Console.WriteLine($"LoginForm: AuthService response message: {response.Message}");
                Console.WriteLine($"LoginForm: AuthService response data null: {response.Data == null}");
                
                if (response.Data != null)
                {
                    Console.WriteLine($"LoginForm: AuthService token length: {response.Data.Token?.Length ?? 0}");
                    Console.WriteLine($"LoginForm: AuthService user null: {response.Data.User == null}");
                }

                if (response.Success && response.Data != null)
                {
                    LoggedInUser = response.Data.User;
                    AuthToken = response.Data.Token;
                    
                    // Debug için response'u kontrol et
                    Console.WriteLine($"Login response success: {response.Success}");
                    Console.WriteLine($"Login response data is null: {response.Data == null}");
                    Console.WriteLine($"User received: {LoggedInUser?.Username ?? "NULL"}");
                    Console.WriteLine($"Token received: {AuthToken?.Length ?? 0} characters");
                    Console.WriteLine($"Token preview: {AuthToken?.Substring(0, Math.Min(50, AuthToken?.Length ?? 0)) ?? "NULL"}...");
                    
                    _apiService.SetAuthToken(AuthToken);

                    MessageBox.Show($"Hoş geldiniz, {LoggedInUser.FirstName ?? LoggedInUser.Username}!", 
                        "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    string errorMessage = response.Message;
                    if (response.Errors.Any())
                    {
                        errorMessage += "\n\nDetaylar:\n" + string.Join("\n", response.Errors);
                    }

                    MessageBox.Show(errorMessage, "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Giriş Yap";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
} 