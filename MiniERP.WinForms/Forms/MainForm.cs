using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private readonly ApiService _apiService;
        private readonly AuthService _authService;
        private readonly ProductService _productService;
        private readonly CariAccountService _cariAccountService;
        private UserDto _currentUser;

        public MainForm(ApiService apiService, UserDto currentUser)
        {
            InitializeComponent();
            _apiService = apiService;
            _currentUser = currentUser;
            _authService = new AuthService(_apiService);
            _productService = new ProductService(_apiService);
            _cariAccountService = new CariAccountService(_apiService);
            
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Kullanıcı bilgilerini göster
            lblUserInfo.Text = $"Hoş geldiniz: {_currentUser.FirstName ?? _currentUser.Username}";
            
            // Menü butonları için event handler'ları ekle
            btnProducts.Click += BtnProducts_Click;
            btnCariAccounts.Click += BtnCariAccounts_Click;
            btnStock.Click += BtnStock_Click;
            btnSales.Click += BtnSales_Click;
            btnPurchases.Click += BtnPurchases_Click;
            btnReports.Click += BtnReports_Click;
            btnSettings.Click += BtnSettings_Click;
            btnLogout.Click += BtnLogout_Click;

            // Status bar'ı güncelle
            UpdateStatusBar();
        }

        private void UpdateStatusBar()
        {
            statusLabelDateTime.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            statusLabelUser.Text = _currentUser.Username;
            statusLabelApiStatus.Text = _apiService.IsAuthenticated ? "Bağlı" : "Bağlantı Kesildi";
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            var productListForm = new ProductListForm(_productService);
            productListForm.ShowDialog();
        }

        private void BtnCariAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                var cariAccountListForm = new CariAccountListForm(_cariAccountService);
                cariAccountListForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari hesaplar formu açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnStock_Click(object sender, EventArgs e)
        {
            try
            {
                var stockForm = new StockListForm(_apiService);
                stockForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok formu açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSales_Click(object sender, EventArgs e)
        {
            try
            {
                var salesForm = new SalesListForm(_apiService);
                salesForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış formu açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPurchases_Click(object sender, EventArgs e)
        {
            try
            {
                var purchaseForm = new PurchaseListForm(_apiService);
                purchaseForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Alış formu açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            try
            {
                var stockService = new StockService(_apiService);
                var salesService = new SalesService(_apiService);
                var purchaseService = new PurchaseService(_apiService);
                var reportsForm = new ReportsForm(stockService, salesService, purchaseService);
                reportsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Raporlar formu açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                var settingsForm = new SettingsForm();
                settingsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ayarlar formu açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", "Çıkış", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _authService.Logout();
                Close();
            }
        }

        private void timerStatusBar_Tick(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _authService.Logout();
        }
    }
} 