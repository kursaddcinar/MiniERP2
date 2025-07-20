namespace MiniERP.WinForms.Forms
{
    partial class KullaniciDetayForm
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
            this.panelHeader = new Panel();
            this.lblBaslik = new Label();
            this.panelMain = new Panel();
            this.groupBoxBilgiler = new GroupBox();
            this.flowLayoutRoller = new FlowLayoutPanel();
            this.lblRollerBaslik = new Label();
            this.lblSonGiris = new Label();
            this.lblSonGirisBaslik = new Label();
            this.lblOlusturmaTarihi = new Label();
            this.lblOlusturmaTarihiBaslik = new Label();
            this.lblDurum = new Label();
            this.lblDurumBaslik = new Label();
            this.lblEmail = new Label();
            this.lblEmailBaslik = new Label();
            this.lblAdSoyad = new Label();
            this.lblAdSoyadBaslik = new Label();
            this.lblKullaniciAdi = new Label();
            this.lblKullaniciAdiBaslik = new Label();
            this.panelButtons = new Panel();
            this.btnKapat = new Button();
            this.btnPasiflik = new Button();
            this.btnDuzenle = new Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxBilgiler.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(500, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Anchor = AnchorStyles.Left;
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.White;
            this.lblBaslik.Location = new Point(15, 13);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(155, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Kullanıcı Detayları";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxBilgiler);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 50);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(500, 400);
            this.panelMain.TabIndex = 1;
            // 
            // groupBoxBilgiler
            // 
            this.groupBoxBilgiler.Controls.Add(this.flowLayoutRoller);
            this.groupBoxBilgiler.Controls.Add(this.lblRollerBaslik);
            this.groupBoxBilgiler.Controls.Add(this.lblSonGiris);
            this.groupBoxBilgiler.Controls.Add(this.lblSonGirisBaslik);
            this.groupBoxBilgiler.Controls.Add(this.lblOlusturmaTarihi);
            this.groupBoxBilgiler.Controls.Add(this.lblOlusturmaTarihiBaslik);
            this.groupBoxBilgiler.Controls.Add(this.lblDurum);
            this.groupBoxBilgiler.Controls.Add(this.lblDurumBaslik);
            this.groupBoxBilgiler.Controls.Add(this.lblEmail);
            this.groupBoxBilgiler.Controls.Add(this.lblEmailBaslik);
            this.groupBoxBilgiler.Controls.Add(this.lblAdSoyad);
            this.groupBoxBilgiler.Controls.Add(this.lblAdSoyadBaslik);
            this.groupBoxBilgiler.Controls.Add(this.lblKullaniciAdi);
            this.groupBoxBilgiler.Controls.Add(this.lblKullaniciAdiBaslik);
            this.groupBoxBilgiler.Dock = DockStyle.Fill;
            this.groupBoxBilgiler.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.groupBoxBilgiler.Location = new Point(20, 20);
            this.groupBoxBilgiler.Name = "groupBoxBilgiler";
            this.groupBoxBilgiler.Size = new Size(460, 360);
            this.groupBoxBilgiler.TabIndex = 0;
            this.groupBoxBilgiler.TabStop = false;
            this.groupBoxBilgiler.Text = "Kullanıcı Bilgileri";
            // 
            // flowLayoutRoller
            // 
            this.flowLayoutRoller.AutoSize = true;
            this.flowLayoutRoller.FlowDirection = FlowDirection.LeftToRight;
            this.flowLayoutRoller.Location = new Point(130, 180);
            this.flowLayoutRoller.MaximumSize = new Size(300, 0);
            this.flowLayoutRoller.Name = "flowLayoutRoller";
            this.flowLayoutRoller.Size = new Size(300, 0);
            this.flowLayoutRoller.TabIndex = 13;
            this.flowLayoutRoller.WrapContents = true;
            // 
            // lblRollerBaslik
            // 
            this.lblRollerBaslik.AutoSize = true;
            this.lblRollerBaslik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblRollerBaslik.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblRollerBaslik.Location = new Point(20, 180);
            this.lblRollerBaslik.Name = "lblRollerBaslik";
            this.lblRollerBaslik.Size = new Size(48, 15);
            this.lblRollerBaslik.TabIndex = 12;
            this.lblRollerBaslik.Text = "Roller:";
            // 
            // lblSonGiris
            // 
            this.lblSonGiris.AutoSize = true;
            this.lblSonGiris.Font = new Font("Segoe UI", 9F);
            this.lblSonGiris.Location = new Point(130, 285);
            this.lblSonGiris.Name = "lblSonGiris";
            this.lblSonGiris.Size = new Size(12, 15);
            this.lblSonGiris.TabIndex = 11;
            this.lblSonGiris.Text = "-";
            // 
            // lblSonGirisBaslik
            // 
            this.lblSonGirisBaslik.AutoSize = true;
            this.lblSonGirisBaslik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblSonGirisBaslik.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblSonGirisBaslik.Location = new Point(20, 285);
            this.lblSonGirisBaslik.Name = "lblSonGirisBaslik";
            this.lblSonGirisBaslik.Size = new Size(63, 15);
            this.lblSonGirisBaslik.TabIndex = 10;
            this.lblSonGirisBaslik.Text = "Son Giriş:";
            // 
            // lblOlusturmaTarihi
            // 
            this.lblOlusturmaTarihi.AutoSize = true;
            this.lblOlusturmaTarihi.Font = new Font("Segoe UI", 9F);
            this.lblOlusturmaTarihi.Location = new Point(130, 255);
            this.lblOlusturmaTarihi.Name = "lblOlusturmaTarihi";
            this.lblOlusturmaTarihi.Size = new Size(12, 15);
            this.lblOlusturmaTarihi.TabIndex = 9;
            this.lblOlusturmaTarihi.Text = "-";
            // 
            // lblOlusturmaTarihiBaslik
            // 
            this.lblOlusturmaTarihiBaslik.AutoSize = true;
            this.lblOlusturmaTarihiBaslik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblOlusturmaTarihiBaslik.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblOlusturmaTarihiBaslik.Location = new Point(20, 255);
            this.lblOlusturmaTarihiBaslik.Name = "lblOlusturmaTarihiBaslik";
            this.lblOlusturmaTarihiBaslik.Size = new Size(95, 15);
            this.lblOlusturmaTarihiBaslik.TabIndex = 8;
            this.lblOlusturmaTarihiBaslik.Text = "Oluşturma T.:";
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDurum.Location = new Point(130, 150);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new Size(12, 15);
            this.lblDurum.TabIndex = 7;
            this.lblDurum.Text = "-";
            // 
            // lblDurumBaslik
            // 
            this.lblDurumBaslik.AutoSize = true;
            this.lblDurumBaslik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDurumBaslik.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblDurumBaslik.Location = new Point(20, 150);
            this.lblDurumBaslik.Name = "lblDurumBaslik";
            this.lblDurumBaslik.Size = new Size(48, 15);
            this.lblDurumBaslik.TabIndex = 6;
            this.lblDurumBaslik.Text = "Durum:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI", 9F);
            this.lblEmail.Location = new Point(130, 120);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(12, 15);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "-";
            // 
            // lblEmailBaslik
            // 
            this.lblEmailBaslik.AutoSize = true;
            this.lblEmailBaslik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblEmailBaslik.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblEmailBaslik.Location = new Point(20, 120);
            this.lblEmailBaslik.Name = "lblEmailBaslik";
            this.lblEmailBaslik.Size = new Size(42, 15);
            this.lblEmailBaslik.TabIndex = 4;
            this.lblEmailBaslik.Text = "Email:";
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.AutoSize = true;
            this.lblAdSoyad.Font = new Font("Segoe UI", 9F);
            this.lblAdSoyad.Location = new Point(130, 90);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new Size(12, 15);
            this.lblAdSoyad.TabIndex = 3;
            this.lblAdSoyad.Text = "-";
            // 
            // lblAdSoyadBaslik
            // 
            this.lblAdSoyadBaslik.AutoSize = true;
            this.lblAdSoyadBaslik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblAdSoyadBaslik.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblAdSoyadBaslik.Location = new Point(20, 90);
            this.lblAdSoyadBaslik.Name = "lblAdSoyadBaslik";
            this.lblAdSoyadBaslik.Size = new Size(68, 15);
            this.lblAdSoyadBaslik.TabIndex = 2;
            this.lblAdSoyadBaslik.Text = "Ad Soyad:";
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblKullaniciAdi.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblKullaniciAdi.Location = new Point(130, 60);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new Size(12, 15);
            this.lblKullaniciAdi.TabIndex = 1;
            this.lblKullaniciAdi.Text = "-";
            // 
            // lblKullaniciAdiBaslik
            // 
            this.lblKullaniciAdiBaslik.AutoSize = true;
            this.lblKullaniciAdiBaslik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblKullaniciAdiBaslik.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblKullaniciAdiBaslik.Location = new Point(20, 60);
            this.lblKullaniciAdiBaslik.Name = "lblKullaniciAdiBaslik";
            this.lblKullaniciAdiBaslik.Size = new Size(86, 15);
            this.lblKullaniciAdiBaslik.TabIndex = 0;
            this.lblKullaniciAdiBaslik.Text = "Kullanıcı Adı:";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = Color.FromArgb(236, 240, 241);
            this.panelButtons.Controls.Add(this.btnKapat);
            this.panelButtons.Controls.Add(this.btnPasiflik);
            this.panelButtons.Controls.Add(this.btnDuzenle);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(0, 450);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(500, 60);
            this.panelButtons.TabIndex = 2;
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = AnchorStyles.Right;
            this.btnKapat.BackColor = Color.FromArgb(108, 117, 125);
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.Font = new Font("Segoe UI", 9F);
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(415, 15);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(75, 30);
            this.btnKapat.TabIndex = 2;
            this.btnKapat.Text = "✖️ Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new EventHandler(this.btnKapat_Click);
            // 
            // btnPasiflik
            // 
            this.btnPasiflik.Anchor = AnchorStyles.Right;
            this.btnPasiflik.BackColor = Color.FromArgb(255, 193, 7);
            this.btnPasiflik.FlatAppearance.BorderSize = 0;
            this.btnPasiflik.FlatStyle = FlatStyle.Flat;
            this.btnPasiflik.Font = new Font("Segoe UI", 9F);
            this.btnPasiflik.ForeColor = Color.White;
            this.btnPasiflik.Location = new Point(225, 15);
            this.btnPasiflik.Name = "btnPasiflik";
            this.btnPasiflik.Size = new Size(90, 30);
            this.btnPasiflik.TabIndex = 1;
            this.btnPasiflik.Text = "🔄 Durum";
            this.btnPasiflik.UseVisualStyleBackColor = false;
            this.btnPasiflik.Click += new EventHandler(this.btnPasiflik_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Anchor = AnchorStyles.Right;
            this.btnDuzenle.BackColor = Color.FromArgb(40, 167, 69);
            this.btnDuzenle.FlatAppearance.BorderSize = 0;
            this.btnDuzenle.FlatStyle = FlatStyle.Flat;
            this.btnDuzenle.Font = new Font("Segoe UI", 9F);
            this.btnDuzenle.ForeColor = Color.White;
            this.btnDuzenle.Location = new Point(325, 15);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new Size(80, 30);
            this.btnDuzenle.TabIndex = 0;
            this.btnDuzenle.Text = "✏️ Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Click += new EventHandler(this.btnDuzenle_Click);
            // 
            // KullaniciDetayForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(500, 510);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KullaniciDetayForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Kullanıcı Detayları";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupBoxBilgiler.ResumeLayout(false);
            this.groupBoxBilgiler.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblBaslik;
        private Panel panelMain;
        private GroupBox groupBoxBilgiler;
        private Label lblKullaniciAdi;
        private Label lblKullaniciAdiBaslik;
        private Label lblAdSoyad;
        private Label lblAdSoyadBaslik;
        private Label lblEmail;
        private Label lblEmailBaslik;
        private Label lblDurum;
        private Label lblDurumBaslik;
        private Label lblOlusturmaTarihi;
        private Label lblOlusturmaTarihiBaslik;
        private Label lblSonGiris;
        private Label lblSonGirisBaslik;
        private Label lblRollerBaslik;
        private FlowLayoutPanel flowLayoutRoller;
        private Panel panelButtons;
        private Button btnKapat;
        private Button btnPasiflik;
        private Button btnDuzenle;
    }
}
