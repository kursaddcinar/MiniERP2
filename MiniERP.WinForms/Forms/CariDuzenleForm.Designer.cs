namespace MiniERP.WinForms.Forms
{
    partial class CariDuzenleForm
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
            this.panelMain = new Panel();
            this.panelContent = new Panel();
            this.panelButtons = new Panel();
            this.chkAktifCari = new CheckBox();
            this.btnGeri = new Button();
            this.btnGuncelle = new Button();
            this.panelForm = new Panel();
            this.txtAdres = new TextBox();
            this.lblAdres = new Label();
            this.txtKrediLimiti = new TextBox();
            this.lblKrediLimiti = new Label();
            this.txtVergiDairesi = new TextBox();
            this.lblVergiDairesi = new Label();
            this.txtVergiNumarasi = new TextBox();
            this.lblVergiNumarasi = new Label();
            this.cmbCariTipi = new ComboBox();
            this.lblCariTipi = new Label();
            this.txtEPosta = new TextBox();
            this.lblEPosta = new Label();
            this.txtTelefon = new TextBox();
            this.lblTelefon = new Label();
            this.txtIletisimKisi = new TextBox();
            this.lblIletisimKisi = new Label();
            this.txtCariAdi = new TextBox();
            this.lblCariAdi = new Label();
            this.txtCariKodu = new TextBox();
            this.lblCariKodu = new Label();
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new Size(800, 700);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelButtons);
            this.panelContent.Controls.Add(this.panelForm);
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Location = new Point(0, 120);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new Padding(30);
            this.panelContent.Size = new Size(800, 580);
            this.panelContent.TabIndex = 1;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.chkAktifCari);
            this.panelButtons.Controls.Add(this.btnGeri);
            this.panelButtons.Controls.Add(this.btnGuncelle);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(30, 490);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(740, 60);
            this.panelButtons.TabIndex = 1;
            // 
            // chkAktifCari
            // 
            this.chkAktifCari.AutoSize = true;
            this.chkAktifCari.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.chkAktifCari.ForeColor = Color.FromArgb(34, 197, 94);
            this.chkAktifCari.Location = new Point(10, 18);
            this.chkAktifCari.Name = "chkAktifCari";
            this.chkAktifCari.Size = new Size(123, 24);
            this.chkAktifCari.TabIndex = 0;
            this.chkAktifCari.Text = "✓ Aktif Cari Hesap";
            this.chkAktifCari.UseVisualStyleBackColor = true;
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = Color.FromArgb(156, 163, 175);
            this.btnGeri.FlatAppearance.BorderSize = 0;
            this.btnGeri.FlatStyle = FlatStyle.Flat;
            this.btnGeri.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnGeri.ForeColor = Color.White;
            this.btnGeri.Location = new Point(520, 15);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new Size(100, 35);
            this.btnGeri.TabIndex = 1;
            this.btnGeri.Text = "🔙 Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += this.BtnGeri_Click;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = Color.FromArgb(59, 130, 246);
            this.btnGuncelle.FlatAppearance.BorderSize = 0;
            this.btnGuncelle.FlatStyle = FlatStyle.Flat;
            this.btnGuncelle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnGuncelle.ForeColor = Color.White;
            this.btnGuncelle.Location = new Point(630, 15);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new Size(100, 35);
            this.btnGuncelle.TabIndex = 2;
            this.btnGuncelle.Text = "✏️ Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += this.BtnGuncelle_Click;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = Color.White;
            this.panelForm.BorderStyle = BorderStyle.FixedSingle;
            this.panelForm.Controls.Add(this.txtAdres);
            this.panelForm.Controls.Add(this.lblAdres);
            this.panelForm.Controls.Add(this.txtKrediLimiti);
            this.panelForm.Controls.Add(this.lblKrediLimiti);
            this.panelForm.Controls.Add(this.txtVergiDairesi);
            this.panelForm.Controls.Add(this.lblVergiDairesi);
            this.panelForm.Controls.Add(this.txtVergiNumarasi);
            this.panelForm.Controls.Add(this.lblVergiNumarasi);
            this.panelForm.Controls.Add(this.cmbCariTipi);
            this.panelForm.Controls.Add(this.lblCariTipi);
            this.panelForm.Controls.Add(this.txtEPosta);
            this.panelForm.Controls.Add(this.lblEPosta);
            this.panelForm.Controls.Add(this.txtTelefon);
            this.panelForm.Controls.Add(this.lblTelefon);
            this.panelForm.Controls.Add(this.txtIletisimKisi);
            this.panelForm.Controls.Add(this.lblIletisimKisi);
            this.panelForm.Controls.Add(this.txtCariAdi);
            this.panelForm.Controls.Add(this.lblCariAdi);
            this.panelForm.Controls.Add(this.txtCariKodu);
            this.panelForm.Controls.Add(this.lblCariKodu);
            this.panelForm.Dock = DockStyle.Fill;
            this.panelForm.Location = new Point(30, 30);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new Padding(20);
            this.panelForm.Size = new Size(740, 460);
            this.panelForm.TabIndex = 0;
            // 
            // txtAdres
            // 
            this.txtAdres.Font = new Font("Segoe UI", 10F);
            this.txtAdres.Location = new Point(380, 400);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.ScrollBars = ScrollBars.Vertical;
            this.txtAdres.Size = new Size(320, 40);
            this.txtAdres.TabIndex = 19;
            this.txtAdres.Text = "Levent Mah. Teknoloji Cad. No:1 Beşiktaş";
            // 
            // lblAdres
            // 
            this.lblAdres.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblAdres.Location = new Point(380, 375);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new Size(100, 20);
            this.lblAdres.TabIndex = 18;
            this.lblAdres.Text = "Adres";
            // 
            // txtKrediLimiti
            // 
            this.txtKrediLimiti.Font = new Font("Segoe UI", 10F);
            this.txtKrediLimiti.Location = new Point(30, 400);
            this.txtKrediLimiti.Name = "txtKrediLimiti";
            this.txtKrediLimiti.Size = new Size(320, 25);
            this.txtKrediLimiti.TabIndex = 17;
            this.txtKrediLimiti.Text = "100001,00";
            // 
            // lblKrediLimiti
            // 
            this.lblKrediLimiti.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblKrediLimiti.Location = new Point(30, 375);
            this.lblKrediLimiti.Name = "lblKrediLimiti";
            this.lblKrediLimiti.Size = new Size(100, 20);
            this.lblKrediLimiti.TabIndex = 16;
            this.lblKrediLimiti.Text = "Kredi Limiti";
            // 
            // txtVergiDairesi
            // 
            this.txtVergiDairesi.Font = new Font("Segoe UI", 10F);
            this.txtVergiDairesi.Location = new Point(380, 335);
            this.txtVergiDairesi.Name = "txtVergiDairesi";
            this.txtVergiDairesi.Size = new Size(320, 25);
            this.txtVergiDairesi.TabIndex = 15;
            this.txtVergiDairesi.Text = "Beşiktaş VD";
            // 
            // lblVergiDairesi
            // 
            this.lblVergiDairesi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblVergiDairesi.Location = new Point(380, 310);
            this.lblVergiDairesi.Name = "lblVergiDairesi";
            this.lblVergiDairesi.Size = new Size(100, 20);
            this.lblVergiDairesi.TabIndex = 14;
            this.lblVergiDairesi.Text = "Vergi Dairesi";
            // 
            // txtVergiNumarasi
            // 
            this.txtVergiNumarasi.Font = new Font("Segoe UI", 10F);
            this.txtVergiNumarasi.Location = new Point(30, 335);
            this.txtVergiNumarasi.Name = "txtVergiNumarasi";
            this.txtVergiNumarasi.Size = new Size(320, 25);
            this.txtVergiNumarasi.TabIndex = 13;
            this.txtVergiNumarasi.Text = "Vergi numarası";
            // 
            // lblVergiNumarasi
            // 
            this.lblVergiNumarasi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblVergiNumarasi.Location = new Point(30, 310);
            this.lblVergiNumarasi.Name = "lblVergiNumarasi";
            this.lblVergiNumarasi.Size = new Size(120, 20);
            this.lblVergiNumarasi.TabIndex = 12;
            this.lblVergiNumarasi.Text = "Vergi Numarası";
            // 
            // cmbCariTipi
            // 
            this.cmbCariTipi.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCariTipi.Font = new Font("Segoe UI", 10F);
            this.cmbCariTipi.FormattingEnabled = true;
            this.cmbCariTipi.Location = new Point(380, 270);
            this.cmbCariTipi.Name = "cmbCariTipi";
            this.cmbCariTipi.Size = new Size(320, 25);
            this.cmbCariTipi.TabIndex = 11;
            // 
            // lblCariTipi
            // 
            this.lblCariTipi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCariTipi.Location = new Point(380, 245);
            this.lblCariTipi.Name = "lblCariTipi";
            this.lblCariTipi.Size = new Size(100, 20);
            this.lblCariTipi.TabIndex = 10;
            this.lblCariTipi.Text = "Cari Tipi";
            // 
            // txtEPosta
            // 
            this.txtEPosta.Font = new Font("Segoe UI", 10F);
            this.txtEPosta.Location = new Point(30, 270);
            this.txtEPosta.Name = "txtEPosta";
            this.txtEPosta.Size = new Size(320, 25);
            this.txtEPosta.TabIndex = 9;
            this.txtEPosta.Text = "info@abctek.com";
            // 
            // lblEPosta
            // 
            this.lblEPosta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblEPosta.Location = new Point(30, 245);
            this.lblEPosta.Name = "lblEPosta";
            this.lblEPosta.Size = new Size(100, 20);
            this.lblEPosta.TabIndex = 8;
            this.lblEPosta.Text = "E-posta";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Font = new Font("Segoe UI", 10F);
            this.txtTelefon.Location = new Point(380, 205);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new Size(320, 25);
            this.txtTelefon.TabIndex = 7;
            this.txtTelefon.Text = "0212 123 45 63";
            // 
            // lblTelefon
            // 
            this.lblTelefon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTelefon.Location = new Point(380, 180);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new Size(100, 20);
            this.lblTelefon.TabIndex = 6;
            this.lblTelefon.Text = "Telefon";
            // 
            // txtIletisimKisi
            // 
            this.txtIletisimKisi.Font = new Font("Segoe UI", 10F);
            this.txtIletisimKisi.Location = new Point(30, 205);
            this.txtIletisimKisi.Name = "txtIletisimKisi";
            this.txtIletisimKisi.Size = new Size(320, 25);
            this.txtIletisimKisi.TabIndex = 5;
            this.txtIletisimKisi.Text = "Ahmet Yılmaz";
            // 
            // lblIletisimKisi
            // 
            this.lblIletisimKisi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblIletisimKisi.Location = new Point(30, 180);
            this.lblIletisimKisi.Name = "lblIletisimKisi";
            this.lblIletisimKisi.Size = new Size(100, 20);
            this.lblIletisimKisi.TabIndex = 4;
            this.lblIletisimKisi.Text = "İletişim Kişisi";
            // 
            // txtCariAdi
            // 
            this.txtCariAdi.Font = new Font("Segoe UI", 10F);
            this.txtCariAdi.Location = new Point(380, 140);
            this.txtCariAdi.Name = "txtCariAdi";
            this.txtCariAdi.Size = new Size(320, 25);
            this.txtCariAdi.TabIndex = 3;
            this.txtCariAdi.Text = "ABC Teknoloji Ltd. Şti.";
            // 
            // lblCariAdi
            // 
            this.lblCariAdi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCariAdi.Location = new Point(380, 115);
            this.lblCariAdi.Name = "lblCariAdi";
            this.lblCariAdi.Size = new Size(100, 20);
            this.lblCariAdi.TabIndex = 2;
            this.lblCariAdi.Text = "Cari Adı";
            // 
            // txtCariKodu
            // 
            this.txtCariKodu.BackColor = Color.FromArgb(249, 250, 251);
            this.txtCariKodu.Font = new Font("Segoe UI", 10F);
            this.txtCariKodu.Location = new Point(30, 140);
            this.txtCariKodu.Name = "txtCariKodu";
            this.txtCariKodu.ReadOnly = true;
            this.txtCariKodu.Size = new Size(320, 25);
            this.txtCariKodu.TabIndex = 1;
            this.txtCariKodu.Text = "MUS001";
            // 
            // lblCariKodu
            // 
            this.lblCariKodu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCariKodu.Location = new Point(30, 115);
            this.lblCariKodu.Name = "lblCariKodu";
            this.lblCariKodu.Size = new Size(100, 20);
            this.lblCariKodu.TabIndex = 0;
            this.lblCariKodu.Text = "Cari Kodu";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(30, 41, 59);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(800, 120);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(740, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "✏️ Cari Hesap Düzenle";
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new Font("Segoe UI", 12F);
            this.lblSubtitle.ForeColor = Color.FromArgb(203, 213, 225);
            this.lblSubtitle.Location = new Point(30, 70);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new Size(740, 30);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Cari Hesap Bilgilerini Düzenle";
            this.lblSubtitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CariDuzenleForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.ClientSize = new Size(800, 700);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CariDuzenleForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Cari Hesap Düzenle";
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelContent;
        private Panel panelButtons;
        private CheckBox chkAktifCari;
        private Button btnGeri;
        private Button btnGuncelle;
        private Panel panelForm;
        private TextBox txtAdres;
        private Label lblAdres;
        private TextBox txtKrediLimiti;
        private Label lblKrediLimiti;
        private TextBox txtVergiDairesi;
        private Label lblVergiDairesi;
        private TextBox txtVergiNumarasi;
        private Label lblVergiNumarasi;
        private ComboBox cmbCariTipi;
        private Label lblCariTipi;
        private TextBox txtEPosta;
        private Label lblEPosta;
        private TextBox txtTelefon;
        private Label lblTelefon;
        private TextBox txtIletisimKisi;
        private Label lblIletisimKisi;
        private TextBox txtCariAdi;
        private Label lblCariAdi;
        private TextBox txtCariKodu;
        private Label lblCariKodu;
        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;
    }
}


