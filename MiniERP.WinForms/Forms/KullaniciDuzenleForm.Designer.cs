using System.ComponentModel;

namespace MiniERP.WinForms.Forms
{
    partial class KullaniciDuzenleForm : Form
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
            this.lblSifreUyari = new Label();
            this.lblRolAciklama = new Label();
            this.chkAktif = new CheckBox();
            this.cmbRol = new ComboBox();
            this.lblRol = new Label();
            this.txtSifreTekrar = new TextBox();
            this.lblSifreTekrar = new Label();
            this.txtSifre = new TextBox();
            this.lblSifre = new Label();
            this.txtEmail = new TextBox();
            this.lblEmail = new Label();
            this.txtSoyad = new TextBox();
            this.lblSoyad = new Label();
            this.txtAd = new TextBox();
            this.lblAd = new Label();
            this.txtKullaniciAdi = new TextBox();
            this.lblKullaniciAdi = new Label();
            this.panelButtons = new Panel();
            this.btnIptal = new Button();
            this.btnKaydet = new Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxBilgiler.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(52, 152, 219);
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
            this.lblBaslik.Size = new Size(187, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Kullanıcı Düzenle";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxBilgiler);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 50);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(500, 510);
            this.panelMain.TabIndex = 1;
            // 
            // groupBoxBilgiler
            // 
            this.groupBoxBilgiler.Controls.Add(this.lblSifreUyari);
            this.groupBoxBilgiler.Controls.Add(this.lblRolAciklama);
            this.groupBoxBilgiler.Controls.Add(this.chkAktif);
            this.groupBoxBilgiler.Controls.Add(this.cmbRol);
            this.groupBoxBilgiler.Controls.Add(this.lblRol);
            this.groupBoxBilgiler.Controls.Add(this.txtSifreTekrar);
            this.groupBoxBilgiler.Controls.Add(this.lblSifreTekrar);
            this.groupBoxBilgiler.Controls.Add(this.txtSifre);
            this.groupBoxBilgiler.Controls.Add(this.lblSifre);
            this.groupBoxBilgiler.Controls.Add(this.txtEmail);
            this.groupBoxBilgiler.Controls.Add(this.lblEmail);
            this.groupBoxBilgiler.Controls.Add(this.txtSoyad);
            this.groupBoxBilgiler.Controls.Add(this.lblSoyad);
            this.groupBoxBilgiler.Controls.Add(this.txtAd);
            this.groupBoxBilgiler.Controls.Add(this.lblAd);
            this.groupBoxBilgiler.Controls.Add(this.txtKullaniciAdi);
            this.groupBoxBilgiler.Controls.Add(this.lblKullaniciAdi);
            this.groupBoxBilgiler.Dock = DockStyle.Fill;
            this.groupBoxBilgiler.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.groupBoxBilgiler.Location = new Point(20, 20);
            this.groupBoxBilgiler.Name = "groupBoxBilgiler";
            this.groupBoxBilgiler.Size = new Size(460, 470);
            this.groupBoxBilgiler.TabIndex = 0;
            this.groupBoxBilgiler.TabStop = false;
            this.groupBoxBilgiler.Text = "Kullanıcı Bilgileri";
            // 
            // lblSifreUyari
            // 
            this.lblSifreUyari.AutoSize = true;
            this.lblSifreUyari.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblSifreUyari.ForeColor = Color.FromArgb(230, 126, 34);
            this.lblSifreUyari.Location = new Point(20, 205);
            this.lblSifreUyari.Name = "lblSifreUyari";
            this.lblSifreUyari.Size = new Size(172, 13);
            this.lblSifreUyari.TabIndex = 16;
            this.lblSifreUyari.Text = "Şifreyi değiştirmek için doldurun";
            // 
            // lblRolAciklama
            // 
            this.lblRolAciklama.AutoSize = true;
            this.lblRolAciklama.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblRolAciklama.ForeColor = Color.FromArgb(108, 117, 125);
            this.lblRolAciklama.Location = new Point(20, 365);
            this.lblRolAciklama.Name = "lblRolAciklama";
            this.lblRolAciklama.Size = new Size(81, 13);
            this.lblRolAciklama.TabIndex = 15;
            this.lblRolAciklama.Text = "Rol açıklaması";
            // 
            // chkAktif
            // 
            this.chkAktif.AutoSize = true;
            this.chkAktif.Font = new Font("Segoe UI", 9F);
            this.chkAktif.Location = new Point(20, 395);
            this.chkAktif.Name = "chkAktif";
            this.chkAktif.Size = new Size(54, 19);
            this.chkAktif.TabIndex = 8;
            this.chkAktif.Text = "Aktif";
            this.chkAktif.UseVisualStyleBackColor = true;
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRol.Font = new Font("Segoe UI", 9F);
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new Point(20, 330);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new Size(200, 23);
            this.cmbRol.TabIndex = 7;
            this.cmbRol.SelectedIndexChanged += new EventHandler(this.cmbRol_SelectedIndexChanged);
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblRol.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblRol.Location = new Point(20, 310);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new Size(27, 15);
            this.lblRol.TabIndex = 12;
            this.lblRol.Text = "Rol";
            // 
            // txtSifreTekrar
            // 
            this.txtSifreTekrar.Font = new Font("Segoe UI", 9F);
            this.txtSifreTekrar.Location = new Point(240, 270);
            this.txtSifreTekrar.Name = "txtSifreTekrar";
            this.txtSifreTekrar.Size = new Size(200, 23);
            this.txtSifreTekrar.TabIndex = 6;
            this.txtSifreTekrar.UseSystemPasswordChar = true;
            // 
            // lblSifreTekrar
            // 
            this.lblSifreTekrar.AutoSize = true;
            this.lblSifreTekrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblSifreTekrar.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblSifreTekrar.Location = new Point(240, 250);
            this.lblSifreTekrar.Name = "lblSifreTekrar";
            this.lblSifreTekrar.Size = new Size(76, 15);
            this.lblSifreTekrar.TabIndex = 10;
            this.lblSifreTekrar.Text = "Şifre Tekrarı";
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new Font("Segoe UI", 9F);
            this.txtSifre.Location = new Point(20, 270);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new Size(200, 23);
            this.txtSifre.TabIndex = 5;
            this.txtSifre.UseSystemPasswordChar = true;
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblSifre.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblSifre.Location = new Point(20, 250);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new Size(68, 15);
            this.lblSifre.TabIndex = 8;
            this.lblSifre.Text = "Yeni Şifre";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new Font("Segoe UI", 9F);
            this.txtEmail.Location = new Point(20, 185);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "ornek@email.com (opsiyonel)";
            this.txtEmail.Size = new Size(420, 23);
            this.txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblEmail.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblEmail.Location = new Point(20, 165);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(36, 15);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            // 
            // txtSoyad
            // 
            this.txtSoyad.Font = new Font("Segoe UI", 9F);
            this.txtSoyad.Location = new Point(240, 125);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new Size(200, 23);
            this.txtSoyad.TabIndex = 3;
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblSoyad.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblSoyad.Location = new Point(240, 105);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new Size(48, 15);
            this.lblSoyad.TabIndex = 4;
            this.lblSoyad.Text = "Soyad *";
            // 
            // txtAd
            // 
            this.txtAd.Font = new Font("Segoe UI", 9F);
            this.txtAd.Location = new Point(20, 125);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new Size(200, 23);
            this.txtAd.TabIndex = 2;
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblAd.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblAd.Location = new Point(20, 105);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new Size(27, 15);
            this.lblAd.TabIndex = 2;
            this.lblAd.Text = "Ad *";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Font = new Font("Segoe UI", 9F);
            this.txtKullaniciAdi.Location = new Point(20, 65);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.ReadOnly = true;
            this.txtKullaniciAdi.Size = new Size(420, 23);
            this.txtKullaniciAdi.TabIndex = 1;
            this.txtKullaniciAdi.TextChanged += new EventHandler(this.txtKullaniciAdi_TextChanged);
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblKullaniciAdi.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblKullaniciAdi.Location = new Point(20, 45);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new Size(152, 15);
            this.lblKullaniciAdi.TabIndex = 0;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı (değiştirilemez)";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = Color.FromArgb(236, 240, 241);
            this.panelButtons.Controls.Add(this.btnIptal);
            this.panelButtons.Controls.Add(this.btnKaydet);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(0, 560);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(500, 60);
            this.panelButtons.TabIndex = 2;
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = AnchorStyles.Right;
            this.btnIptal.BackColor = Color.FromArgb(108, 117, 125);
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.Font = new Font("Segoe UI", 9F);
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(415, 15);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new Size(75, 30);
            this.btnIptal.TabIndex = 10;
            this.btnIptal.Text = "✖️ İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = AnchorStyles.Right;
            this.btnKaydet.BackColor = Color.FromArgb(52, 152, 219);
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = FlatStyle.Flat;
            this.btnKaydet.Font = new Font("Segoe UI", 9F);
            this.btnKaydet.ForeColor = Color.White;
            this.btnKaydet.Location = new Point(325, 15);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(80, 30);
            this.btnKaydet.TabIndex = 9;
            this.btnKaydet.Text = "💾 Güncelle";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new EventHandler(this.btnKaydet_Click);
            // 
            // KullaniciDuzenleForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(500, 620);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KullaniciDuzenleForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Kullanıcı Düzenle";
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
        private TextBox txtKullaniciAdi;
        private Label lblAd;
        private TextBox txtAd;
        private Label lblSoyad;
        private TextBox txtSoyad;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblSifre;
        private TextBox txtSifre;
        private Label lblSifreTekrar;
        private TextBox txtSifreTekrar;
        private Label lblRol;
        private ComboBox cmbRol;
        private CheckBox chkAktif;
        private Label lblRolAciklama;
        private Label lblSifreUyari;
        private Panel panelButtons;
        private Button btnIptal;
        private Button btnKaydet;
    }
}
