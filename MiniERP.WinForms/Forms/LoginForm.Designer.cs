namespace MiniERP.WinForms.Forms
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new Panel();
            this.panelLogin = new Panel();
            this.lblMiniERP = new Label();
            this.lblSubtitle = new Label();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.lblTestUsers = new Label();
            this.btnTestCreate = new Button();
            this.btnQuickTest = new Label();
            this.panelTestButtons = new Panel();
            this.btnAdmin = new Button();
            this.btnManager = new Button();
            this.btnSales = new Button();
            this.btnPurchase = new Button();
            this.btnFinance = new Button();
            this.btnWarehouse = new Button();
            this.btnEmployee = new Button();
            this.lblTestInfo = new Label();
            this.panelMain.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.panelTestButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = Color.FromArgb(240, 244, 248);
            this.panelMain.Controls.Add(this.panelLogin);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new Size(900, 700);
            this.panelMain.TabIndex = 0;
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = Color.White;
            this.panelLogin.Controls.Add(this.lblMiniERP);
            this.panelLogin.Controls.Add(this.lblSubtitle);
            this.panelLogin.Controls.Add(this.lblUsername);
            this.panelLogin.Controls.Add(this.txtUsername);
            this.panelLogin.Controls.Add(this.lblPassword);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.lblTestUsers);
            this.panelLogin.Controls.Add(this.btnTestCreate);
            this.panelLogin.Controls.Add(this.btnQuickTest);
            this.panelLogin.Controls.Add(this.panelTestButtons);
            this.panelLogin.Controls.Add(this.lblTestInfo);
            this.panelLogin.Location = new Point(250, 50);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new Size(400, 600);
            this.panelLogin.TabIndex = 0;
            this.panelLogin.Paint += this.PanelLogin_Paint;
            // 
            // lblMiniERP
            // 
            this.lblMiniERP.AutoSize = true;
            this.lblMiniERP.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            this.lblMiniERP.ForeColor = Color.FromArgb(37, 99, 235);
            this.lblMiniERP.Location = new Point(130, 40);
            this.lblMiniERP.Name = "lblMiniERP";
            this.lblMiniERP.Size = new Size(140, 51);
            this.lblMiniERP.TabIndex = 0;
            this.lblMiniERP.Text = "MiniERP";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblSubtitle.Location = new Point(165, 95);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new Size(70, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Lütfen giriş yapın";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new Font("Segoe UI", 10F);
            this.lblUsername.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblUsername.Location = new Point(50, 140);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(83, 19);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Kullanıcı Adı";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new Font("Segoe UI", 11F);
            this.txtUsername.Location = new Point(50, 165);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(300, 27);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.BorderStyle = BorderStyle.FixedSingle;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI", 10F);
            this.lblPassword.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblPassword.Location = new Point(50, 210);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(37, 19);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Şifre";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new Font("Segoe UI", 11F);
            this.txtPassword.Location = new Point(50, 235);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(300, 27);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = Color.FromArgb(37, 99, 235);
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Location = new Point(50, 285);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new Size(300, 40);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "→ Giriş Yap";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += this.BtnLogin_Click;
            // 
            // lblTestUsers
            // 
            this.lblTestUsers.AutoSize = true;
            this.lblTestUsers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTestUsers.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblTestUsers.Location = new Point(50, 345);
            this.lblTestUsers.Name = "lblTestUsers";
            this.lblTestUsers.Size = new Size(0, 19);
            this.lblTestUsers.TabIndex = 7;
            // 
            // btnTestCreate
            // 
            this.btnTestCreate.BackColor = Color.FromArgb(59, 130, 246);
            this.btnTestCreate.FlatAppearance.BorderSize = 0;
            this.btnTestCreate.FlatStyle = FlatStyle.Flat;
            this.btnTestCreate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnTestCreate.ForeColor = Color.White;
            this.btnTestCreate.Location = new Point(50, 340);
            this.btnTestCreate.Name = "btnTestCreate";
            this.btnTestCreate.Size = new Size(300, 30);
            this.btnTestCreate.TabIndex = 8;
            this.btnTestCreate.Text = "👥 Test Kullanıcılarını Oluştur";
            this.btnTestCreate.UseVisualStyleBackColor = false;
            this.btnTestCreate.Click += this.BtnTestCreate_Click;
            // 
            // btnQuickTest
            // 
            this.btnQuickTest.AutoSize = true;
            this.btnQuickTest.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnQuickTest.ForeColor = Color.FromArgb(239, 68, 68);
            this.btnQuickTest.Location = new Point(50, 385);
            this.btnQuickTest.Name = "btnQuickTest";
            this.btnQuickTest.Size = new Size(88, 15);
            this.btnQuickTest.TabIndex = 9;
            this.btnQuickTest.Text = "⚡ Hızlı Test Giriş";
            // 
            // panelTestButtons
            // 
            this.panelTestButtons.Controls.Add(this.btnAdmin);
            this.panelTestButtons.Controls.Add(this.btnManager);
            this.panelTestButtons.Controls.Add(this.btnSales);
            this.panelTestButtons.Controls.Add(this.btnPurchase);
            this.panelTestButtons.Controls.Add(this.btnFinance);
            this.panelTestButtons.Controls.Add(this.btnWarehouse);
            this.panelTestButtons.Controls.Add(this.btnEmployee);
            this.panelTestButtons.Location = new Point(50, 410);
            this.panelTestButtons.Name = "panelTestButtons";
            this.panelTestButtons.Size = new Size(300, 120);
            this.panelTestButtons.TabIndex = 10;
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = Color.FromArgb(220, 38, 38);
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = FlatStyle.Flat;
            this.btnAdmin.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnAdmin.ForeColor = Color.White;
            this.btnAdmin.Location = new Point(0, 0);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new Size(90, 25);
            this.btnAdmin.TabIndex = 0;
            this.btnAdmin.Text = "👑 Admin";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += this.BtnRole_Click;
            // 
            // btnManager
            // 
            this.btnManager.BackColor = Color.FromArgb(59, 130, 246);
            this.btnManager.FlatAppearance.BorderSize = 0;
            this.btnManager.FlatStyle = FlatStyle.Flat;
            this.btnManager.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnManager.ForeColor = Color.White;
            this.btnManager.Location = new Point(105, 0);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new Size(90, 25);
            this.btnManager.TabIndex = 1;
            this.btnManager.Text = "📊 Manager";
            this.btnManager.UseVisualStyleBackColor = false;
            this.btnManager.Click += this.BtnRole_Click;
            // 
            // btnSales
            // 
            this.btnSales.BackColor = Color.FromArgb(34, 197, 94);
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatStyle = FlatStyle.Flat;
            this.btnSales.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnSales.ForeColor = Color.White;
            this.btnSales.Location = new Point(210, 0);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new Size(90, 25);
            this.btnSales.TabIndex = 2;
            this.btnSales.Text = "🛒 Sales";
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += this.BtnRole_Click;
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackColor = Color.FromArgb(168, 85, 247);
            this.btnPurchase.FlatAppearance.BorderSize = 0;
            this.btnPurchase.FlatStyle = FlatStyle.Flat;
            this.btnPurchase.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnPurchase.ForeColor = Color.White;
            this.btnPurchase.Location = new Point(0, 35);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new Size(90, 25);
            this.btnPurchase.TabIndex = 3;
            this.btnPurchase.Text = "🛍️ Purchase";
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += this.BtnRole_Click;
            // 
            // btnFinance
            // 
            this.btnFinance.BackColor = Color.FromArgb(245, 158, 11);
            this.btnFinance.FlatAppearance.BorderSize = 0;
            this.btnFinance.FlatStyle = FlatStyle.Flat;
            this.btnFinance.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnFinance.ForeColor = Color.White;
            this.btnFinance.Location = new Point(105, 35);
            this.btnFinance.Name = "btnFinance";
            this.btnFinance.Size = new Size(90, 25);
            this.btnFinance.TabIndex = 4;
            this.btnFinance.Text = "📊 Finance";
            this.btnFinance.UseVisualStyleBackColor = false;
            this.btnFinance.Click += this.BtnRole_Click;
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.BackColor = Color.FromArgb(107, 114, 128);
            this.btnWarehouse.FlatAppearance.BorderSize = 0;
            this.btnWarehouse.FlatStyle = FlatStyle.Flat;
            this.btnWarehouse.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnWarehouse.ForeColor = Color.White;
            this.btnWarehouse.Location = new Point(210, 35);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new Size(90, 25);
            this.btnWarehouse.TabIndex = 5;
            this.btnWarehouse.Text = "📦 Warehouse";
            this.btnWarehouse.UseVisualStyleBackColor = false;
            this.btnWarehouse.Click += this.BtnRole_Click;
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = Color.FromArgb(156, 163, 175);
            this.btnEmployee.FlatAppearance.BorderSize = 0;
            this.btnEmployee.FlatStyle = FlatStyle.Flat;
            this.btnEmployee.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnEmployee.ForeColor = Color.White;
            this.btnEmployee.Location = new Point(105, 70);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new Size(90, 25);
            this.btnEmployee.TabIndex = 6;
            this.btnEmployee.Text = "👤 Employee";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += this.BtnRole_Click;
            // 
            // lblTestInfo
            // 
            this.lblTestInfo.Font = new Font("Segoe UI", 8F);
            this.lblTestInfo.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblTestInfo.Location = new Point(50, 540);
            this.lblTestInfo.Name = "lblTestInfo";
            this.lblTestInfo.Size = new Size(300, 40);
            this.lblTestInfo.TabIndex = 11;
            this.lblTestInfo.Text = "Test Kullanıcıları:\nadmin, manager, sales, purchase, finance, warehouse, employee\nTüm şifreler kullanıcı adı ile aynı";
            this.lblTestInfo.TextAlign = ContentAlignment.TopCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 700);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "MiniERP - Giriş";
            this.panelMain.ResumeLayout(false);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelTestButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelLogin;
        private Label lblMiniERP;
        private Label lblSubtitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblTestUsers;
        private Button btnTestCreate;
        private Label btnQuickTest;
        private Panel panelTestButtons;
        private Button btnAdmin;
        private Button btnManager;
        private Button btnSales;
        private Button btnPurchase;
        private Button btnFinance;
        private Button btnWarehouse;
        private Button btnEmployee;
        private Label lblTestInfo;
    }
}
