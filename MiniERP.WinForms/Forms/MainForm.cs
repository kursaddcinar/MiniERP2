using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System.ComponentModel;

namespace MiniERP.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private System.Windows.Forms.Timer? _timeTimer;
        private System.Windows.Forms.Timer? _dashboardTimer;
        
        // Access control matrix
        private readonly Dictionary<string, Dictionary<string, string>> _accessMatrix = new()
        {
            ["Dashboard"] = new() {
                ["Admin"] = "Tam", ["Manager"] = "Tam", ["Sales"] = "Satış",
                ["Purchase"] = "Alış", ["Finance"] = "Mali", ["Warehouse"] = "Stok"
            },
            ["Cari Hesaplar"] = new() {
                ["Admin"] = "CRUD", ["Manager"] = "CRUD", ["Sales"] = "CRUD",
                ["Purchase"] = "CRUD", ["Finance"] = "Read", ["Warehouse"] = "Yok"
            },
            ["Ürünler"] = new() {
                ["Admin"] = "CRUD", ["Manager"] = "CRUD", ["Sales"] = "Read",
                ["Purchase"] = "CRUD", ["Finance"] = "Yok", ["Warehouse"] = "Read"
            },
            ["Stok"] = new() {
                ["Admin"] = "CRUD", ["Manager"] = "CRUD", ["Sales"] = "Read",
                ["Purchase"] = "Read", ["Finance"] = "Yok", ["Warehouse"] = "CRUD"
            },
            ["Satış Faturaları"] = new() {
                ["Admin"] = "CRUD", ["Manager"] = "CRUD", ["Sales"] = "CRUD",
                ["Purchase"] = "Yok", ["Finance"] = "Read", ["Warehouse"] = "Yok"
            },
            ["Alış Faturaları"] = new() {
                ["Admin"] = "CRUD", ["Manager"] = "CRUD", ["Sales"] = "Yok",
                ["Purchase"] = "CRUD", ["Finance"] = "Read", ["Warehouse"] = "Yok"
            },
            ["Kullanıcı Yönetimi"] = new() {
                ["Admin"] = "CRUD", ["Manager"] = "RU", ["Sales"] = "Yok",
                ["Purchase"] = "Yok", ["Finance"] = "Yok", ["Warehouse"] = "Yok"
            }
        };

        public MainForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            
            // Bind FormClosing event
            this.FormClosing += MainForm_FormClosing;
            
            InitializeUserInterface();
            SetupAccessControl();
            InitializeTimer();
            LoadDashboardData();
        }

        private void InitializeUserInterface()
        {
            // Set user welcome message
            lblUserWelcome.Text = $"Hoş geldiniz, {_currentUser.Username}";
            
            // Initialize dashboard based on user role
            ShowDashboard();
        }

        private void InitializeTimer()
        {
            // Saat timer'ı
            _timeTimer = new System.Windows.Forms.Timer();
            _timeTimer.Interval = 1000; // 1 second
            _timeTimer.Tick += (s, e) => UpdateDateTime();
            _timeTimer.Start();
            UpdateDateTime();
            
            // Dashboard yenileme timer'ı - 5 dakikada bir
            _dashboardTimer = new System.Windows.Forms.Timer();
            _dashboardTimer.Interval = 300000; // 5 minutes
            _dashboardTimer.Tick += async (s, e) => await LoadDashboardDataAsync();
            _dashboardTimer.Start();
        }

        private void UpdateDateTime()
        {
            lblDateTime.Text = $"📅 {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
        }

        private void SetupAccessControl()
        {
            var userRole = GetPrimaryRole();
            
            // Check access for each menu button
            btnCariHesaplar.Enabled = HasAccess("Cari Hesaplar", userRole);
            btnUrunler.Enabled = HasAccess("Ürünler", userRole);
            btnStokYonetimi.Enabled = HasAccess("Stok", userRole);
            btnSatisFaturaları.Enabled = HasAccess("Satış Faturaları", userRole);
            btnAlisFaturalari.Enabled = HasAccess("Alış Faturaları", userRole);
            btnKullaniciYonetimi.Enabled = HasAccess("Kullanıcı Yönetimi", userRole);

            // Admin always has API Test access
            btnApiTest.Enabled = userRole == "Admin";

            // Update button colors based on access
            UpdateButtonStyles();
        }

        private string GetPrimaryRole()
        {
            if (_currentUser.Roles.Contains("Admin")) return "Admin";
            if (_currentUser.Roles.Contains("Manager")) return "Manager";
            if (_currentUser.Roles.Contains("Sales")) return "Sales";
            if (_currentUser.Roles.Contains("Purchase")) return "Purchase";
            if (_currentUser.Roles.Contains("Finance")) return "Finance";
            if (_currentUser.Roles.Contains("Warehouse")) return "Warehouse";
            return "Employee";
        }

        private bool HasAccess(string module, string role)
        {
            if (_accessMatrix.ContainsKey(module) && _accessMatrix[module].ContainsKey(role))
            {
                return _accessMatrix[module][role] != "Yok";
            }
            return false;
        }

        private void UpdateButtonStyles()
        {
            var buttons = new[] { btnCariHesaplar, btnUrunler, btnStokYonetimi, 
                                btnSatisFaturaları, btnAlisFaturalari, btnOdemeler, 
                                btnTahsilatlar, btnRaporlar, btnKullaniciYonetimi, btnApiTest };

            foreach (var btn in buttons)
            {
                if (!btn.Enabled)
                {
                    btn.BackColor = Color.FromArgb(107, 114, 128);
                    btn.ForeColor = Color.FromArgb(156, 163, 175);
                }
            }
        }

        private void LoadDashboardData()
        {
            // Dashboard verilerini asenkron olarak yükle
            Task.Run(async () => await LoadDashboardDataAsync());
        }

        private async Task LoadDashboardDataAsync()
        {
            try
            {
                var stats = await GetDashboardStatsAsync();
                
                // UI thread'de dashboard kartlarını oluştur
                if (InvokeRequired)
                {
                    Invoke(new Action(() => CreateStatsCards(stats)));
                }
                else
                {
                    CreateStatsCards(stats);
                }
                
                // Diğer UI bileşenlerini oluştur
                if (InvokeRequired)
                {
                    Invoke(new Action(() => {
                        CreateQuickAccessButtons();
                        CreateRecentActivities();
                        CreateSystemInfo();
                    }));
                }
                else
                {
                    CreateQuickAccessButtons();
                    CreateRecentActivities();
                    CreateSystemInfo();
                }
            }
            catch (Exception)
            {
                // Hata durumunda varsayılan değerlerle devam et
                var defaultStats = new DashboardStatsDto();
                if (InvokeRequired)
                {
                    Invoke(new Action(() => CreateStatsCards(defaultStats)));
                }
                else
                {
                    CreateStatsCards(defaultStats);
                }
            }
        }

        private async Task<DashboardStatsDto> GetDashboardStatsAsync()
        {
            var stats = new DashboardStatsDto();
            
            try
            {
                // Paralel olarak API çağrılarını yap
                var tasks = new List<Task>();
                
                // Ürün sayısını al
                tasks.Add(Task.Run(async () => {
                    try
                    {
                        var productsResponse = await _apiService.GetAsync<PagedResult<ProductDto>>("Products?pageSize=1");
                        if (productsResponse?.Success == true && productsResponse.Data != null)
                        {
                            stats.TotalProducts = productsResponse.Data.TotalCount;
                        }
                    }
                    catch { /* Ignore individual failures */ }
                }));
                
                // Cari hesap sayılarını al
                tasks.Add(Task.Run(async () => {
                    try
                    {
                        var cariResponse = await _apiService.GetAsync<PagedResult<CariAccountDto>>("CariAccounts?pageSize=10000");
                        if (cariResponse?.Success == true && cariResponse.Data?.Data != null)
                        {
                            var allCari = cariResponse.Data.Data;
                            stats.TotalCariAccounts = allCari.Count;
                            stats.ActiveCustomers = allCari.Count(c => c.IsCustomer || 
                                (c.TypeName != null && c.TypeName.ToLower().Contains("müşteri")));
                            stats.ActiveSuppliers = allCari.Count(c => c.IsSupplier || 
                                (c.TypeName != null && c.TypeName.ToLower().Contains("tedarikçi")));
                        }
                    }
                    catch { /* Ignore individual failures */ }
                }));
                
                // Satış faturalarını al
                tasks.Add(Task.Run(async () => {
                    try
                    {
                        var salesResponse = await _apiService.GetAsync<PagedResult<object>>("SalesInvoices?pageSize=1");
                        if (salesResponse?.Success == true && salesResponse.Data != null)
                        {
                            stats.TotalSalesInvoices = salesResponse.Data.TotalCount;
                        }
                    }
                    catch { /* Ignore individual failures */ }
                }));
                
                // Alış faturalarını al
                tasks.Add(Task.Run(async () => {
                    try
                    {
                        var purchaseResponse = await _apiService.GetAsync<PagedResult<object>>("PurchaseInvoices?pageSize=1");
                        if (purchaseResponse?.Success == true && purchaseResponse.Data != null)
                        {
                            stats.TotalPurchaseInvoices = purchaseResponse.Data.TotalCount;
                        }
                    }
                    catch { /* Ignore individual failures */ }
                }));
                
                // Kritik stok sayısını al
                tasks.Add(Task.Run(async () => {
                    try
                    {
                        var stockResponse = await _apiService.GetAsync<List<object>>("Stock/cards/critical");
                        if (stockResponse?.Success == true && stockResponse.Data != null)
                        {
                            stats.CriticalStockCount = stockResponse.Data.Count;
                        }
                    }
                    catch { /* Ignore individual failures */ }
                }));
                
                // Tüm task'lerin tamamlanmasını bekle
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                // Genel hata durumunda log'la ama devam et
                System.Diagnostics.Debug.WriteLine($"Dashboard stats error: {ex.Message}");
            }
            
            return stats;
        }

        private void CreateStatsCards(DashboardStatsDto stats)
        {
            panelStats.Controls.Clear();
            var userRole = GetPrimaryRole();
            var cards = GetStatsCardsForRole(userRole, stats);
            
            int cardWidth = 220;
            int cardHeight = 100;
            int spacing = 20;
            
            // Refresh butonu ekle
            var refreshButton = new Button
            {
                Text = "🔄 Yenile",
                Size = new Size(80, 30),
                Location = new Point(panelStats.Width - 100, 5),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8F)
            };
            refreshButton.FlatAppearance.BorderSize = 0;
            refreshButton.Click += async (s, e) => {
                refreshButton.Enabled = false;
                refreshButton.Text = "⏳ Yükleniyor...";
                try
                {
                    await LoadDashboardDataAsync();
                }
                finally
                {
                    refreshButton.Enabled = true;
                    refreshButton.Text = "🔄 Yenile";
                }
            };
            panelStats.Controls.Add(refreshButton);
            
            // Dashboard kartlarını ekle
            for (int i = 0; i < cards.Count; i++)
            {
                var card = CreateStatCard(cards[i].Title, cards[i].Value, cards[i].Icon, cards[i].Color);
                card.Location = new Point(20 + (i * (cardWidth + spacing)), 10);
                card.Size = new Size(cardWidth, cardHeight);
                panelStats.Controls.Add(card);
            }
        }

        private List<DashboardCardDto> GetStatsCardsForRole(string role, DashboardStatsDto stats)
        {
            return role switch
            {
                "Admin" => new List<DashboardCardDto>
                {
                    new() { Title = "TOPLAM ÜRÜN", Value = stats.TotalProducts.ToString(), Icon = "📦", Color = Color.FromArgb(139, 69, 19) },
                    new() { Title = "SATIŞ FATURALARI", Value = stats.TotalSalesInvoices.ToString(), Icon = "🛒", Color = Color.FromArgb(34, 197, 94) },
                    new() { Title = "ALIŞ FATURALARI", Value = stats.TotalPurchaseInvoices.ToString(), Icon = "🛍️", Color = Color.FromArgb(59, 130, 246) },
                    new() { Title = "KRİTİK STOK", Value = stats.CriticalStockCount.ToString(), Icon = "⚠️", Color = Color.FromArgb(249, 115, 22) }
                },
                "Finance" => new List<DashboardCardDto>
                {
                    new() { Title = "SATIŞ FATURALARI", Value = stats.TotalSalesInvoices.ToString(), Icon = "🛒", Color = Color.FromArgb(34, 197, 94) },
                    new() { Title = "ALIŞ FATURALARI", Value = stats.TotalPurchaseInvoices.ToString(), Icon = "🛍️", Color = Color.FromArgb(59, 130, 246) }
                },
                "Sales" => new List<DashboardCardDto>
                {
                    new() { Title = "SATIŞ FATURALARI", Value = stats.TotalSalesInvoices.ToString(), Icon = "🛒", Color = Color.FromArgb(34, 197, 94) },
                    new() { Title = "TOPLAM CARİ", Value = stats.ActiveCustomers.ToString(), Icon = "👥", Color = Color.FromArgb(168, 85, 247) }
                },
                "Purchase" => new List<DashboardCardDto>
                {
                    new() { Title = "ALIŞ FATURALARI", Value = stats.TotalPurchaseInvoices.ToString(), Icon = "🛍️", Color = Color.FromArgb(59, 130, 246) },
                    new() { Title = "TOPLAM CARİ", Value = stats.ActiveSuppliers.ToString(), Icon = "👥", Color = Color.FromArgb(168, 85, 247) }
                },
                "Warehouse" => new List<DashboardCardDto>
                {
                    new() { Title = "TOPLAM ÜRÜN", Value = stats.TotalProducts.ToString(), Icon = "📦", Color = Color.FromArgb(139, 69, 19) },
                    new() { Title = "KRİTİK STOK", Value = stats.CriticalStockCount.ToString(), Icon = "⚠️", Color = Color.FromArgb(249, 115, 22) }
                },
                _ => new List<DashboardCardDto>
                {
                    new() { Title = "TOPLAM ÜRÜN", Value = stats.TotalProducts.ToString(), Icon = "📦", Color = Color.FromArgb(139, 69, 19) }
                }
            };
        }

        private Panel CreateStatCard(string title, string value, string icon, Color color)
        {
            var card = new Panel
            {
                BackColor = color,
                Size = new Size(220, 100)
            };

            var iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 24F),
                ForeColor = Color.White,
                Location = new Point(15, 15),
                Size = new Size(50, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(80, 15),
                Size = new Size(120, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                Location = new Point(80, 50),
                Size = new Size(120, 35),
                TextAlign = ContentAlignment.MiddleLeft
            };

            card.Controls.AddRange(new Control[] { iconLabel, valueLabel, titleLabel });
            return card;
        }

        private void CreateQuickAccessButtons()
        {
            panelQuickAccess.Controls.Clear();
            var userRole = GetPrimaryRole();
            
            var quickButtons = new List<(string Text, string Icon, Action Action)>();
            
            if (HasAccess("Cari Hesaplar", userRole))
                quickButtons.Add(("Cari Ekle", "👥", () => MessageBox.Show("Cari Hesap Ekleme")));
            
            if (HasAccess("Ürünler", userRole))
                quickButtons.Add(("Ürün Ekle", "📦", () => MessageBox.Show("Ürün Ekleme")));
            
            if (HasAccess("Satış Faturaları", userRole))
                quickButtons.Add(("Satış Faturası", "🛒", () => MessageBox.Show("Satış Faturası")));

            int buttonWidth = 120;
            int buttonHeight = 40;
            int spacing = 15;
            
            for (int i = 0; i < quickButtons.Count && i < 3; i++)
            {
                var btn = new Button
                {
                    Text = $"{quickButtons[i].Icon} {quickButtons[i].Text}",
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(20, 20 + (i * (buttonHeight + spacing))),
                    BackColor = Color.FromArgb(59, 130, 246),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F)
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += (s, e) => quickButtons[i].Action();
                panelQuickAccess.Controls.Add(btn);
            }
        }

        private void CreateRecentActivities()
        {
            panelActivities.Controls.Clear();
            
            var activities = new[]
            {
                "✅ Sistem başlatıldı",
                "👤 Admin kullanıcısı giriş yaptı",
                "📊 Dashboard erişimi"
            };

            for (int i = 0; i < activities.Length; i++)
            {
                var activityLabel = new Label
                {
                    Text = activities[i],
                    Location = new Point(15, 15 + (i * 25)),
                    Size = new Size(420, 20),
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(55, 65, 81)
                };
                panelActivities.Controls.Add(activityLabel);
            }
        }

        private void CreateSystemInfo()
        {
            panelSystemInfo.Controls.Clear();
            
            var infoText = $@"🖥️ Sistem: MiniERP v2.0
👤 Rol: {string.Join(", ", _currentUser.Roles)}
📅 Son Güncelleme: {DateTime.Now:dd.MM.yyyy}
🔄 Durum: ✅ Online
📊 Hızlı İstatistikler:
   • Bu ay satış +15%
   • Aktif ürün sayısı: 21";

            var infoLabel = new Label
            {
                Text = infoText,
                Location = new Point(20, 20),
                Size = new Size(900, 170),
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(55, 65, 81)
            };
            
            panelSystemInfo.Controls.Add(infoLabel);
        }

        private void ShowDashboard()
        {
            // Hide all panels first
            foreach (Control control in panelMain.Controls)
            {
                control.Visible = false;
            }
            
            // Show dashboard
            panelDashboard.Visible = true;
            
            // Update active button style
            ResetButtonStyles();
            btnDashboard.BackColor = Color.FromArgb(37, 99, 235);
            btnDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        }

        private void ResetButtonStyles()
        {
            var buttons = panelSidebar.Controls.OfType<Button>();
            foreach (var btn in buttons)
            {
                if (btn.Enabled)
                {
                    btn.BackColor = Color.FromArgb(59, 130, 246);
                    btn.Font = new Font("Segoe UI", 11F);
                }
            }
        }

        // Event Handlers
        private void BtnProfile_Click(object? sender, EventArgs e)
        {
            contextMenuProfile.Show(btnProfile, new Point(0, btnProfile.Height));
        }

        private void ToolStripMenuProfile_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Profil sayfası açılacak", "Profil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToolStripMenuLogout_Click(object? sender, EventArgs e)
        {
            BtnLogout_Click(sender, e);
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", 
                "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                _timeTimer?.Stop();
                this.Close();
            }
        }

        private void BtnDashboard_Click(object? sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void BtnCariHesaplar_Click(object? sender, EventArgs e)
        {
            try
            {
                var cariForm = new CariHesaplarForm(_currentUser, _apiService);
                cariForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari hesaplar formu açılırken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUrunler_Click(object? sender, EventArgs e)
        {
            try
            {
                var urunlerForm = new UrunlerForm(_currentUser, _apiService);
                urunlerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler formu açılırken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnStokYonetimi_Click(object? sender, EventArgs e)
        {
            try
            {
                var form = new StokYonetimiForm(_currentUser, _apiService);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok Yönetimi formu açılırken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSatisFaturaları_Click(object? sender, EventArgs e)
        {
            var satisFaturalariForm = new SatisFaturalariForm(_currentUser, _apiService);
            satisFaturalariForm.Show();
        }

        private void BtnAlisFaturalari_Click(object? sender, EventArgs e)
        {
            var alisFaturalariForm = new AlisFaturalariForm(_currentUser, _apiService);
            alisFaturalariForm.Show();
        }

        private void BtnOdemeler_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Ödemeler modülü açılacak", "Ödemeler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnTahsilatlar_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Tahsilatlar modülü açılacak", "Tahsilatlar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnRaporlar_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Raporlar modülü açılacak", "Raporlar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnKullaniciYonetimi_Click(object? sender, EventArgs e)
        {
            try
            {
                var userService = new UserService(_apiService);
                var kullaniciYonetimiForm = new KullaniciYonetimiForm(userService, _currentUser.Role, _currentUser.UserID);
                kullaniciYonetimiForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı yönetimi formu açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnApiTest_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("API Test modülü açılacak", "API Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _timeTimer?.Stop();
            _timeTimer?.Dispose();
            _dashboardTimer?.Stop();
            _dashboardTimer?.Dispose();
            _apiService?.Dispose();
        }
    }
}


