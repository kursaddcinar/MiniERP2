namespace MiniERP.WinForms.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new Panel();
            this.lblWelcome = new Label();
            this.lblDateTime = new Label();
            this.btnProfile = new Button();
            this.lblUserWelcome = new Label();
            this.panelSidebar = new Panel();
            this.btnDashboard = new Button();
            this.btnCariHesaplar = new Button();
            this.btnUrunler = new Button();
            this.btnStokYonetimi = new Button();
            this.btnSatisFaturaları = new Button();
            this.btnAlisFaturalari = new Button();
            this.btnOdemeler = new Button();
            this.btnTahsilatlar = new Button();
            this.btnRaporlar = new Button();
            this.btnKullaniciYonetimi = new Button();
            this.btnApiTest = new Button();
            this.panelMain = new Panel();
            this.panelDashboard = new Panel();
            this.panelStats = new Panel();
            this.panelQuickAccess = new Panel();
            this.lblQuickAccess = new Label();
            this.panelActivities = new Panel();
            this.lblActivities = new Label();
            this.panelSystemInfo = new Panel();
            this.lblSystemInfo = new Label();
            this.contextMenuProfile = new ContextMenuStrip();
            this.toolStripMenuProfile = new ToolStripMenuItem();
            this.toolStripMenuLogout = new ToolStripMenuItem();
            this.panelTop.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            this.contextMenuProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = Color.FromArgb(37, 99, 235);
            this.panelTop.Controls.Add(this.lblWelcome);
            this.panelTop.Controls.Add(this.lblDateTime);
            this.panelTop.Controls.Add(this.btnProfile);
            this.panelTop.Controls.Add(this.lblUserWelcome);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(1200, 70);
            this.panelTop.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.Location = new Point(250, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(101, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "🏢 MiniERP";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new Font("Segoe UI", 10F);
            this.lblDateTime.ForeColor = Color.White;
            this.lblDateTime.Location = new Point(250, 45);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new Size(65, 19);
            this.lblDateTime.TabIndex = 1;
            this.lblDateTime.Text = "Tarih/Saat";
            // 
            // btnProfile
            // 
            this.btnProfile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnProfile.BackColor = Color.FromArgb(59, 130, 246);
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = FlatStyle.Flat;
            this.btnProfile.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnProfile.ForeColor = Color.White;
            this.btnProfile.Location = new Point(1050, 20);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new Size(40, 30);
            this.btnProfile.TabIndex = 2;
            this.btnProfile.Text = "👤";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += this.BtnProfile_Click;
            // 
            // lblUserWelcome
            // 
            this.lblUserWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblUserWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblUserWelcome.ForeColor = Color.White;
            this.lblUserWelcome.Location = new Point(800, 25);
            this.lblUserWelcome.Name = "lblUserWelcome";
            this.lblUserWelcome.Size = new Size(240, 20);
            this.lblUserWelcome.TabIndex = 3;
            this.lblUserWelcome.Text = "Hoş geldiniz, Kullanıcı";
            this.lblUserWelcome.TextAlign = ContentAlignment.TopRight;
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = Color.FromArgb(30, 58, 138);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.btnCariHesaplar);
            this.panelSidebar.Controls.Add(this.btnUrunler);
            this.panelSidebar.Controls.Add(this.btnStokYonetimi);
            this.panelSidebar.Controls.Add(this.btnSatisFaturaları);
            this.panelSidebar.Controls.Add(this.btnAlisFaturalari);
            this.panelSidebar.Controls.Add(this.btnOdemeler);
            this.panelSidebar.Controls.Add(this.btnTahsilatlar);
            this.panelSidebar.Controls.Add(this.btnRaporlar);
            this.panelSidebar.Controls.Add(this.btnKullaniciYonetimi);
            this.panelSidebar.Controls.Add(this.btnApiTest);
            this.panelSidebar.Dock = DockStyle.Left;
            this.panelSidebar.Location = new Point(0, 70);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new Size(220, 630);
            this.panelSidebar.TabIndex = 1;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = Color.FromArgb(37, 99, 235);
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = FlatStyle.Flat;
            this.btnDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnDashboard.ForeColor = Color.White;
            this.btnDashboard.Location = new Point(10, 20);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new Size(200, 45);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "📊 Dashboard";
            this.btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += this.BtnDashboard_Click;
            // 
            // btnCariHesaplar
            // 
            this.btnCariHesaplar.BackColor = Color.FromArgb(59, 130, 246);
            this.btnCariHesaplar.FlatAppearance.BorderSize = 0;
            this.btnCariHesaplar.FlatStyle = FlatStyle.Flat;
            this.btnCariHesaplar.Font = new Font("Segoe UI", 11F);
            this.btnCariHesaplar.ForeColor = Color.White;
            this.btnCariHesaplar.Location = new Point(10, 75);
            this.btnCariHesaplar.Name = "btnCariHesaplar";
            this.btnCariHesaplar.Size = new Size(200, 45);
            this.btnCariHesaplar.TabIndex = 1;
            this.btnCariHesaplar.Text = "👥 Cari Hesaplar";
            this.btnCariHesaplar.TextAlign = ContentAlignment.MiddleLeft;
            this.btnCariHesaplar.UseVisualStyleBackColor = false;
            this.btnCariHesaplar.Click += this.BtnCariHesaplar_Click;
            // 
            // btnUrunler
            // 
            this.btnUrunler.BackColor = Color.FromArgb(59, 130, 246);
            this.btnUrunler.FlatAppearance.BorderSize = 0;
            this.btnUrunler.FlatStyle = FlatStyle.Flat;
            this.btnUrunler.Font = new Font("Segoe UI", 11F);
            this.btnUrunler.ForeColor = Color.White;
            this.btnUrunler.Location = new Point(10, 130);
            this.btnUrunler.Name = "btnUrunler";
            this.btnUrunler.Size = new Size(200, 45);
            this.btnUrunler.TabIndex = 2;
            this.btnUrunler.Text = "📦 Ürünler";
            this.btnUrunler.TextAlign = ContentAlignment.MiddleLeft;
            this.btnUrunler.UseVisualStyleBackColor = false;
            this.btnUrunler.Click += this.BtnUrunler_Click;
            // 
            // btnStokYonetimi
            // 
            this.btnStokYonetimi.BackColor = Color.FromArgb(59, 130, 246);
            this.btnStokYonetimi.FlatAppearance.BorderSize = 0;
            this.btnStokYonetimi.FlatStyle = FlatStyle.Flat;
            this.btnStokYonetimi.Font = new Font("Segoe UI", 11F);
            this.btnStokYonetimi.ForeColor = Color.White;
            this.btnStokYonetimi.Location = new Point(10, 185);
            this.btnStokYonetimi.Name = "btnStokYonetimi";
            this.btnStokYonetimi.Size = new Size(200, 45);
            this.btnStokYonetimi.TabIndex = 3;
            this.btnStokYonetimi.Text = "📊 Stok Yönetimi";
            this.btnStokYonetimi.TextAlign = ContentAlignment.MiddleLeft;
            this.btnStokYonetimi.UseVisualStyleBackColor = false;
            this.btnStokYonetimi.Click += this.BtnStokYonetimi_Click;
            // 
            // btnSatisFaturaları
            // 
            this.btnSatisFaturaları.BackColor = Color.FromArgb(59, 130, 246);
            this.btnSatisFaturaları.FlatAppearance.BorderSize = 0;
            this.btnSatisFaturaları.FlatStyle = FlatStyle.Flat;
            this.btnSatisFaturaları.Font = new Font("Segoe UI", 11F);
            this.btnSatisFaturaları.ForeColor = Color.White;
            this.btnSatisFaturaları.Location = new Point(10, 240);
            this.btnSatisFaturaları.Name = "btnSatisFaturaları";
            this.btnSatisFaturaları.Size = new Size(200, 45);
            this.btnSatisFaturaları.TabIndex = 4;
            this.btnSatisFaturaları.Text = "🛒 Satış Faturaları";
            this.btnSatisFaturaları.TextAlign = ContentAlignment.MiddleLeft;
            this.btnSatisFaturaları.UseVisualStyleBackColor = false;
            this.btnSatisFaturaları.Click += this.BtnSatisFaturaları_Click;
            // 
            // btnAlisFaturalari
            // 
            this.btnAlisFaturalari.BackColor = Color.FromArgb(59, 130, 246);
            this.btnAlisFaturalari.FlatAppearance.BorderSize = 0;
            this.btnAlisFaturalari.FlatStyle = FlatStyle.Flat;
            this.btnAlisFaturalari.Font = new Font("Segoe UI", 11F);
            this.btnAlisFaturalari.ForeColor = Color.White;
            this.btnAlisFaturalari.Location = new Point(10, 295);
            this.btnAlisFaturalari.Name = "btnAlisFaturalari";
            this.btnAlisFaturalari.Size = new Size(200, 45);
            this.btnAlisFaturalari.TabIndex = 5;
            this.btnAlisFaturalari.Text = "🛍️ Alış Faturaları";
            this.btnAlisFaturalari.TextAlign = ContentAlignment.MiddleLeft;
            this.btnAlisFaturalari.UseVisualStyleBackColor = false;
            this.btnAlisFaturalari.Click += this.BtnAlisFaturalari_Click;
            // 
            // btnOdemeler
            // 
            this.btnOdemeler.BackColor = Color.FromArgb(59, 130, 246);
            this.btnOdemeler.FlatAppearance.BorderSize = 0;
            this.btnOdemeler.FlatStyle = FlatStyle.Flat;
            this.btnOdemeler.Font = new Font("Segoe UI", 11F);
            this.btnOdemeler.ForeColor = Color.White;
            this.btnOdemeler.Location = new Point(10, 350);
            this.btnOdemeler.Name = "btnOdemeler";
            this.btnOdemeler.Size = new Size(200, 45);
            this.btnOdemeler.TabIndex = 6;
            this.btnOdemeler.Text = "💳 Ödemeler";
            this.btnOdemeler.TextAlign = ContentAlignment.MiddleLeft;
            this.btnOdemeler.UseVisualStyleBackColor = false;
            this.btnOdemeler.Click += this.BtnOdemeler_Click;
            // 
            // btnTahsilatlar
            // 
            this.btnTahsilatlar.BackColor = Color.FromArgb(59, 130, 246);
            this.btnTahsilatlar.FlatAppearance.BorderSize = 0;
            this.btnTahsilatlar.FlatStyle = FlatStyle.Flat;
            this.btnTahsilatlar.Font = new Font("Segoe UI", 11F);
            this.btnTahsilatlar.ForeColor = Color.White;
            this.btnTahsilatlar.Location = new Point(10, 405);
            this.btnTahsilatlar.Name = "btnTahsilatlar";
            this.btnTahsilatlar.Size = new Size(200, 45);
            this.btnTahsilatlar.TabIndex = 7;
            this.btnTahsilatlar.Text = "💰 Tahsilatlar";
            this.btnTahsilatlar.TextAlign = ContentAlignment.MiddleLeft;
            this.btnTahsilatlar.UseVisualStyleBackColor = false;
            this.btnTahsilatlar.Click += this.BtnTahsilatlar_Click;
            // 
            // btnRaporlar
            // 
            this.btnRaporlar.BackColor = Color.FromArgb(59, 130, 246);
            this.btnRaporlar.FlatAppearance.BorderSize = 0;
            this.btnRaporlar.FlatStyle = FlatStyle.Flat;
            this.btnRaporlar.Font = new Font("Segoe UI", 11F);
            this.btnRaporlar.ForeColor = Color.White;
            this.btnRaporlar.Location = new Point(10, 460);
            this.btnRaporlar.Name = "btnRaporlar";
            this.btnRaporlar.Size = new Size(200, 45);
            this.btnRaporlar.TabIndex = 8;
            this.btnRaporlar.Text = "📈 Raporlar";
            this.btnRaporlar.TextAlign = ContentAlignment.MiddleLeft;
            this.btnRaporlar.UseVisualStyleBackColor = false;
            this.btnRaporlar.Click += this.BtnRaporlar_Click;
            // 
            // btnKullaniciYonetimi
            // 
            this.btnKullaniciYonetimi.BackColor = Color.FromArgb(59, 130, 246);
            this.btnKullaniciYonetimi.FlatAppearance.BorderSize = 0;
            this.btnKullaniciYonetimi.FlatStyle = FlatStyle.Flat;
            this.btnKullaniciYonetimi.Font = new Font("Segoe UI", 11F);
            this.btnKullaniciYonetimi.ForeColor = Color.White;
            this.btnKullaniciYonetimi.Location = new Point(10, 515);
            this.btnKullaniciYonetimi.Name = "btnKullaniciYonetimi";
            this.btnKullaniciYonetimi.Size = new Size(200, 45);
            this.btnKullaniciYonetimi.TabIndex = 9;
            this.btnKullaniciYonetimi.Text = "👤 Kullanıcı Yönetimi";
            this.btnKullaniciYonetimi.TextAlign = ContentAlignment.MiddleLeft;
            this.btnKullaniciYonetimi.UseVisualStyleBackColor = false;
            this.btnKullaniciYonetimi.Click += this.BtnKullaniciYonetimi_Click;
            // 
            // btnApiTest
            // 
            this.btnApiTest.BackColor = Color.FromArgb(59, 130, 246);
            this.btnApiTest.FlatAppearance.BorderSize = 0;
            this.btnApiTest.FlatStyle = FlatStyle.Flat;
            this.btnApiTest.Font = new Font("Segoe UI", 11F);
            this.btnApiTest.ForeColor = Color.White;
            this.btnApiTest.Location = new Point(10, 570);
            this.btnApiTest.Name = "btnApiTest";
            this.btnApiTest.Size = new Size(200, 45);
            this.btnApiTest.TabIndex = 10;
            this.btnApiTest.Text = "🔧 API Test";
            this.btnApiTest.TextAlign = ContentAlignment.MiddleLeft;
            this.btnApiTest.UseVisualStyleBackColor = false;
            this.btnApiTest.Click += this.BtnApiTest_Click;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = Color.FromArgb(249, 250, 251);
            this.panelMain.Controls.Add(this.panelDashboard);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(220, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new Size(980, 630);
            this.panelMain.TabIndex = 2;
            // 
            // panelDashboard
            // 
            this.panelDashboard.Controls.Add(this.panelStats);
            this.panelDashboard.Controls.Add(this.panelQuickAccess);
            this.panelDashboard.Controls.Add(this.lblQuickAccess);
            this.panelDashboard.Controls.Add(this.panelActivities);
            this.panelDashboard.Controls.Add(this.lblActivities);
            this.panelDashboard.Controls.Add(this.panelSystemInfo);
            this.panelDashboard.Controls.Add(this.lblSystemInfo);
            this.panelDashboard.Dock = DockStyle.Fill;
            this.panelDashboard.Location = new Point(0, 0);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Padding = new Padding(20);
            this.panelDashboard.Size = new Size(980, 630);
            this.panelDashboard.TabIndex = 0;
            // 
            // panelStats
            // 
            this.panelStats.BackColor = Color.White;
            this.panelStats.Location = new Point(20, 20);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new Size(940, 120);
            this.panelStats.TabIndex = 0;
            // 
            // panelQuickAccess
            // 
            this.panelQuickAccess.BackColor = Color.White;
            this.panelQuickAccess.Location = new Point(20, 180);
            this.panelQuickAccess.Name = "panelQuickAccess";
            this.panelQuickAccess.Size = new Size(460, 180);
            this.panelQuickAccess.TabIndex = 1;
            // 
            // lblQuickAccess
            // 
            this.lblQuickAccess.AutoSize = true;
            this.lblQuickAccess.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblQuickAccess.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblQuickAccess.Location = new Point(20, 150);
            this.lblQuickAccess.Name = "lblQuickAccess";
            this.lblQuickAccess.Size = new Size(118, 25);
            this.lblQuickAccess.TabIndex = 2;
            this.lblQuickAccess.Text = "Hızlı Erişim";
            // 
            // panelActivities
            // 
            this.panelActivities.BackColor = Color.White;
            this.panelActivities.Location = new Point(500, 180);
            this.panelActivities.Name = "panelActivities";
            this.panelActivities.Size = new Size(460, 180);
            this.panelActivities.TabIndex = 3;
            // 
            // lblActivities
            // 
            this.lblActivities.AutoSize = true;
            this.lblActivities.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblActivities.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblActivities.Location = new Point(500, 150);
            this.lblActivities.Name = "lblActivities";
            this.lblActivities.Size = new Size(139, 25);
            this.lblActivities.TabIndex = 4;
            this.lblActivities.Text = "Son Aktiviteler";
            // 
            // panelSystemInfo
            // 
            this.panelSystemInfo.BackColor = Color.White;
            this.panelSystemInfo.Location = new Point(20, 400);
            this.panelSystemInfo.Name = "panelSystemInfo";
            this.panelSystemInfo.Size = new Size(940, 210);
            this.panelSystemInfo.TabIndex = 5;
            // 
            // lblSystemInfo
            // 
            this.lblSystemInfo.AutoSize = true;
            this.lblSystemInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblSystemInfo.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblSystemInfo.Location = new Point(20, 370);
            this.lblSystemInfo.Name = "lblSystemInfo";
            this.lblSystemInfo.Size = new Size(123, 25);
            this.lblSystemInfo.TabIndex = 6;
            this.lblSystemInfo.Text = "Sistem Bilgisi";
            // 
            // contextMenuProfile
            // 
            this.contextMenuProfile.Items.AddRange(new ToolStripItem[] {
            this.toolStripMenuProfile,
            this.toolStripMenuLogout});
            this.contextMenuProfile.Name = "contextMenuProfile";
            this.contextMenuProfile.Size = new Size(104, 48);
            // 
            // toolStripMenuProfile
            // 
            this.toolStripMenuProfile.Name = "toolStripMenuProfile";
            this.toolStripMenuProfile.Size = new Size(103, 22);
            this.toolStripMenuProfile.Text = "Profil";
            this.toolStripMenuProfile.Click += this.ToolStripMenuProfile_Click;
            // 
            // toolStripMenuLogout
            // 
            this.toolStripMenuLogout.Name = "toolStripMenuLogout";
            this.toolStripMenuLogout.Size = new Size(103, 22);
            this.toolStripMenuLogout.Text = "Çıkış";
            this.toolStripMenuLogout.Click += this.ToolStripMenuLogout_Click;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new Size(1200, 700);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "MiniERP - Ana Ekran";
            this.WindowState = FormWindowState.Maximized;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelDashboard.ResumeLayout(false);
            this.panelDashboard.PerformLayout();
            this.contextMenuProfile.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblWelcome;
        private Label lblDateTime;
        private Button btnProfile;
        private Label lblUserWelcome;
        private Panel panelSidebar;
        private Button btnDashboard;
        private Button btnCariHesaplar;
        private Button btnUrunler;
        private Button btnStokYonetimi;
        private Button btnSatisFaturaları;
        private Button btnAlisFaturalari;
        private Button btnOdemeler;
        private Button btnTahsilatlar;
        private Button btnRaporlar;
        private Button btnKullaniciYonetimi;
        private Button btnApiTest;
        private Panel panelMain;
        private Panel panelDashboard;
        private Panel panelStats;
        private Panel panelQuickAccess;
        private Label lblQuickAccess;
        private Panel panelActivities;
        private Label lblActivities;
        private Panel panelSystemInfo;
        private Label lblSystemInfo;
        private ContextMenuStrip contextMenuProfile;
        private ToolStripMenuItem toolStripMenuProfile;
        private ToolStripMenuItem toolStripMenuLogout;
    }
}


