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
            this.components = new System.ComponentModel.Container();
            this.panelTop = new Panel();
            this.lblUserInfo = new Label();
            this.lblTitle = new Label();
            this.panelSidebar = new Panel();
            this.btnLogout = new Button();
            this.btnSettings = new Button();
            this.btnReports = new Button();
            this.btnPurchases = new Button();
            this.btnSales = new Button();
            this.btnStock = new Button();
            this.btnCariAccounts = new Button();
            this.btnProducts = new Button();
            this.panelMain = new Panel();
            this.lblWelcome = new Label();
            this.statusStrip = new StatusStrip();
            this.statusLabelDateTime = new ToolStripStatusLabel();
            this.statusLabelUser = new ToolStripStatusLabel();
            this.statusLabelApiStatus = new ToolStripStatusLabel();
            this.timerStatusBar = new System.Windows.Forms.Timer(this.components);
            this.panelTop.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = Color.FromArgb(0, 122, 255);
            this.panelTop.Controls.Add(this.lblUserInfo);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(1200, 80);
            this.panelTop.TabIndex = 0;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblUserInfo.ForeColor = Color.White;
            this.lblUserInfo.Location = new Point(1050, 50);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new Size(135, 19);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "Hoş geldiniz: Kullanıcı";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(136, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MiniERP";
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = Color.FromArgb(52, 58, 64);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnSettings);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnPurchases);
            this.panelSidebar.Controls.Add(this.btnSales);
            this.panelSidebar.Controls.Add(this.btnStock);
            this.panelSidebar.Controls.Add(this.btnCariAccounts);
            this.panelSidebar.Controls.Add(this.btnProducts);
            this.panelSidebar.Dock = DockStyle.Left;
            this.panelSidebar.Location = new Point(0, 80);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new Size(200, 520);
            this.panelSidebar.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = Color.FromArgb(220, 53, 69);
            this.btnLogout.Dock = DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new Point(0, 470);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new Size(200, 50);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Çıkış";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = Color.FromArgb(52, 58, 64);
            this.btnSettings.Dock = DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = FlatStyle.Flat;
            this.btnSettings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnSettings.ForeColor = Color.White;
            this.btnSettings.Location = new Point(0, 250);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new Size(200, 50);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "Ayarlar";
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnReports
            // 
            this.btnReports.BackColor = Color.FromArgb(52, 58, 64);
            this.btnReports.Dock = DockStyle.Top;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = FlatStyle.Flat;
            this.btnReports.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnReports.ForeColor = Color.White;
            this.btnReports.Location = new Point(0, 200);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new Size(200, 50);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "Raporlar";
            this.btnReports.UseVisualStyleBackColor = false;
            // 
            // btnPurchases
            // 
            this.btnPurchases.BackColor = Color.FromArgb(52, 58, 64);
            this.btnPurchases.Dock = DockStyle.Top;
            this.btnPurchases.FlatAppearance.BorderSize = 0;
            this.btnPurchases.FlatStyle = FlatStyle.Flat;
            this.btnPurchases.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnPurchases.ForeColor = Color.White;
            this.btnPurchases.Location = new Point(0, 150);
            this.btnPurchases.Name = "btnPurchases";
            this.btnPurchases.Size = new Size(200, 50);
            this.btnPurchases.TabIndex = 3;
            this.btnPurchases.Text = "Satın Alma";
            this.btnPurchases.UseVisualStyleBackColor = false;
            // 
            // btnSales
            // 
            this.btnSales.BackColor = Color.FromArgb(52, 58, 64);
            this.btnSales.Dock = DockStyle.Top;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatStyle = FlatStyle.Flat;
            this.btnSales.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnSales.ForeColor = Color.White;
            this.btnSales.Location = new Point(0, 100);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new Size(200, 50);
            this.btnSales.TabIndex = 2;
            this.btnSales.Text = "Satış";
            this.btnSales.UseVisualStyleBackColor = false;
            // 
            // btnStock
            // 
            this.btnStock.BackColor = Color.FromArgb(52, 58, 64);
            this.btnStock.Dock = DockStyle.Top;
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatStyle = FlatStyle.Flat;
            this.btnStock.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnStock.ForeColor = Color.White;
            this.btnStock.Location = new Point(0, 50);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new Size(200, 50);
            this.btnStock.TabIndex = 1;
            this.btnStock.Text = "Stok Yönetimi";
            this.btnStock.UseVisualStyleBackColor = false;
            // 
            // btnCariAccounts
            // 
            this.btnCariAccounts.BackColor = Color.FromArgb(52, 58, 64);
            this.btnCariAccounts.Dock = DockStyle.Top;
            this.btnCariAccounts.FlatAppearance.BorderSize = 0;
            this.btnCariAccounts.FlatStyle = FlatStyle.Flat;
            this.btnCariAccounts.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCariAccounts.ForeColor = Color.White;
            this.btnCariAccounts.Location = new Point(0, 50);
            this.btnCariAccounts.Name = "btnCariAccounts";
            this.btnCariAccounts.Size = new Size(200, 50);
            this.btnCariAccounts.TabIndex = 7;
            this.btnCariAccounts.Text = "Cari Hesaplar";
            this.btnCariAccounts.UseVisualStyleBackColor = false;
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = Color.FromArgb(52, 58, 64);
            this.btnProducts.Dock = DockStyle.Top;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = FlatStyle.Flat;
            this.btnProducts.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnProducts.ForeColor = Color.White;
            this.btnProducts.Location = new Point(0, 0);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new Size(200, 50);
            this.btnProducts.TabIndex = 0;
            this.btnProducts.Text = "Ürün Yönetimi";
            this.btnProducts.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = Color.White;
            this.panelMain.Controls.Add(this.lblWelcome);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(200, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new Size(1000, 520);
            this.panelMain.TabIndex = 2;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblWelcome.ForeColor = Color.FromArgb(52, 58, 64);
            this.lblWelcome.Location = new Point(50, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(600, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "MiniERP sistemine hoş geldiniz! Soldaki menüden işlemlerinizi seçin.";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.statusLabelDateTime,
                this.statusLabelUser,
                this.statusLabelApiStatus});
            this.statusStrip.Location = new Point(0, 600);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(1200, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabelDateTime
            // 
            this.statusLabelDateTime.Name = "statusLabelDateTime";
            this.statusLabelDateTime.Size = new Size(32, 17);
            this.statusLabelDateTime.Text = "Tarih";
            // 
            // statusLabelUser
            // 
            this.statusLabelUser.Name = "statusLabelUser";
            this.statusLabelUser.Size = new Size(48, 17);
            this.statusLabelUser.Text = "Kullanıcı";
            // 
            // statusLabelApiStatus
            // 
            this.statusLabelApiStatus.Name = "statusLabelApiStatus";
            this.statusLabelApiStatus.Size = new Size(69, 17);
            this.statusLabelApiStatus.Text = "API Durumu";
            // 
            // timerStatusBar
            // 
            this.timerStatusBar.Enabled = true;
            this.timerStatusBar.Interval = 1000;
            this.timerStatusBar.Tick += new EventHandler(this.timerStatusBar_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 622);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelTop);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "MiniERP - Ana Ekran";
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Panel panelTop;
        private Label lblUserInfo;
        private Label lblTitle;
        private Panel panelSidebar;
        private Button btnLogout;
        private Button btnSettings;
        private Button btnReports;
        private Button btnPurchases;
        private Button btnSales;
        private Button btnStock;
        private Button btnCariAccounts;
        private Button btnProducts;
        private Panel panelMain;
        private Label lblWelcome;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabelDateTime;
        private ToolStripStatusLabel statusLabelUser;
        private ToolStripStatusLabel statusLabelApiStatus;
        private System.Windows.Forms.Timer timerStatusBar;
    }
} 