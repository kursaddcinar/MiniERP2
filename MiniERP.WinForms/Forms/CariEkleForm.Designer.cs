namespace MiniERP.WinForms.Forms
{
    partial class CariEkleForm
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
            this.panelButtons = new Panel();
            this.btnIptal = new Button();
            this.btnKaydet = new Button();
            this.panelForm = new Panel();
            this.groupBoxContact = new GroupBox();
            this.txtEmail = new TextBox();
            this.lblEmail = new Label();
            this.txtTelefon = new TextBox();
            this.lblTelefon = new Label();
            this.txtAdres = new TextBox();
            this.lblAdres = new Label();
            this.txtIletisimKisi = new TextBox();
            this.lblIletisimKisi = new Label();
            this.groupBoxTax = new GroupBox();
            this.numKrediLimiti = new NumericUpDown();
            this.lblKrediLimiti = new Label();
            this.txtVergiDairesi = new TextBox();
            this.lblVergiDairesi = new Label();
            this.txtVergiNo = new TextBox();
            this.lblVergiNo = new Label();
            this.groupBoxBasic = new GroupBox();
            this.chkAktif = new CheckBox();
            this.cmbCariTipi = new ComboBox();
            this.lblCariTipi = new Label();
            this.txtCariAdi = new TextBox();
            this.lblCariAdi = new Label();
            this.txtCariKodu = new TextBox();
            this.lblCariKodu = new Label();
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.groupBoxContact.SuspendLayout();
            this.groupBoxTax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKrediLimiti)).BeginInit();
            this.groupBoxBasic.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Controls.Add(this.panelForm);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(800, 700);
            this.panelMain.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnIptal);
            this.panelButtons.Controls.Add(this.btnKaydet);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(20, 620);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(760, 60);
            this.panelButtons.TabIndex = 2;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = Color.FromArgb(156, 163, 175);
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(550, 10);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new Size(100, 40);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "❌ İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += this.BtnIptal_Click;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = Color.FromArgb(59, 130, 246);
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = FlatStyle.Flat;
            this.btnKaydet.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnKaydet.ForeColor = Color.White;
            this.btnKaydet.Location = new Point(660, 10);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(100, 40);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "💾 Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += this.BtnKaydet_Click;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.groupBoxContact);
            this.panelForm.Controls.Add(this.groupBoxTax);
            this.panelForm.Controls.Add(this.groupBoxBasic);
            this.panelForm.Dock = DockStyle.Fill;
            this.panelForm.Location = new Point(20, 70);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new Size(760, 550);
            this.panelForm.TabIndex = 1;
            // 
            // groupBoxContact
            // 
            this.groupBoxContact.Controls.Add(this.txtEmail);
            this.groupBoxContact.Controls.Add(this.lblEmail);
            this.groupBoxContact.Controls.Add(this.txtTelefon);
            this.groupBoxContact.Controls.Add(this.lblTelefon);
            this.groupBoxContact.Controls.Add(this.txtAdres);
            this.groupBoxContact.Controls.Add(this.lblAdres);
            this.groupBoxContact.Controls.Add(this.txtIletisimKisi);
            this.groupBoxContact.Controls.Add(this.lblIletisimKisi);
            this.groupBoxContact.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.groupBoxContact.Location = new Point(10, 360);
            this.groupBoxContact.Name = "groupBoxContact";
            this.groupBoxContact.Size = new Size(740, 180);
            this.groupBoxContact.TabIndex = 2;
            this.groupBoxContact.TabStop = false;
            this.groupBoxContact.Text = "İletişim Bilgileri";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new Font("Segoe UI", 10F);
            this.txtEmail.Location = new Point(400, 95);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(320, 25);
            this.txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI", 10F);
            this.lblEmail.Location = new Point(400, 75);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(41, 19);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Font = new Font("Segoe UI", 10F);
            this.txtTelefon.Location = new Point(400, 45);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new Size(320, 25);
            this.txtTelefon.TabIndex = 5;
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Font = new Font("Segoe UI", 10F);
            this.lblTelefon.Location = new Point(400, 25);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new Size(55, 19);
            this.lblTelefon.TabIndex = 4;
            this.lblTelefon.Text = "Telefon";
            // 
            // txtAdres
            // 
            this.txtAdres.Font = new Font("Segoe UI", 10F);
            this.txtAdres.Location = new Point(20, 95);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new Size(360, 60);
            this.txtAdres.TabIndex = 3;
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.lblAdres.Font = new Font("Segoe UI", 10F);
            this.lblAdres.Location = new Point(20, 75);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new Size(44, 19);
            this.lblAdres.TabIndex = 2;
            this.lblAdres.Text = "Adres";
            // 
            // txtIletisimKisi
            // 
            this.txtIletisimKisi.Font = new Font("Segoe UI", 10F);
            this.txtIletisimKisi.Location = new Point(20, 45);
            this.txtIletisimKisi.Name = "txtIletisimKisi";
            this.txtIletisimKisi.Size = new Size(360, 25);
            this.txtIletisimKisi.TabIndex = 1;
            // 
            // lblIletisimKisi
            // 
            this.lblIletisimKisi.AutoSize = true;
            this.lblIletisimKisi.Font = new Font("Segoe UI", 10F);
            this.lblIletisimKisi.Location = new Point(20, 25);
            this.lblIletisimKisi.Name = "lblIletisimKisi";
            this.lblIletisimKisi.Size = new Size(85, 19);
            this.lblIletisimKisi.TabIndex = 0;
            this.lblIletisimKisi.Text = "İletişim Kişisi";
            // 
            // groupBoxTax
            // 
            this.groupBoxTax.Controls.Add(this.numKrediLimiti);
            this.groupBoxTax.Controls.Add(this.lblKrediLimiti);
            this.groupBoxTax.Controls.Add(this.txtVergiDairesi);
            this.groupBoxTax.Controls.Add(this.lblVergiDairesi);
            this.groupBoxTax.Controls.Add(this.txtVergiNo);
            this.groupBoxTax.Controls.Add(this.lblVergiNo);
            this.groupBoxTax.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.groupBoxTax.Location = new Point(10, 210);
            this.groupBoxTax.Name = "groupBoxTax";
            this.groupBoxTax.Size = new Size(740, 140);
            this.groupBoxTax.TabIndex = 1;
            this.groupBoxTax.TabStop = false;
            this.groupBoxTax.Text = "Mali Bilgiler";
            // 
            // numKrediLimiti
            // 
            this.numKrediLimiti.DecimalPlaces = 2;
            this.numKrediLimiti.Font = new Font("Segoe UI", 10F);
            this.numKrediLimiti.Location = new Point(400, 95);
            this.numKrediLimiti.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numKrediLimiti.Name = "numKrediLimiti";
            this.numKrediLimiti.Size = new Size(320, 25);
            this.numKrediLimiti.TabIndex = 5;
            // 
            // lblKrediLimiti
            // 
            this.lblKrediLimiti.AutoSize = true;
            this.lblKrediLimiti.Font = new Font("Segoe UI", 10F);
            this.lblKrediLimiti.Location = new Point(400, 75);
            this.lblKrediLimiti.Name = "lblKrediLimiti";
            this.lblKrediLimiti.Size = new Size(83, 19);
            this.lblKrediLimiti.TabIndex = 4;
            this.lblKrediLimiti.Text = "Kredi Limiti";
            // 
            // txtVergiDairesi
            // 
            this.txtVergiDairesi.Font = new Font("Segoe UI", 10F);
            this.txtVergiDairesi.Location = new Point(400, 45);
            this.txtVergiDairesi.Name = "txtVergiDairesi";
            this.txtVergiDairesi.Size = new Size(320, 25);
            this.txtVergiDairesi.TabIndex = 3;
            // 
            // lblVergiDairesi
            // 
            this.lblVergiDairesi.AutoSize = true;
            this.lblVergiDairesi.Font = new Font("Segoe UI", 10F);
            this.lblVergiDairesi.Location = new Point(400, 25);
            this.lblVergiDairesi.Name = "lblVergiDairesi";
            this.lblVergiDairesi.Size = new Size(91, 19);
            this.lblVergiDairesi.TabIndex = 2;
            this.lblVergiDairesi.Text = "Vergi Dairesi";
            // 
            // txtVergiNo
            // 
            this.txtVergiNo.Font = new Font("Segoe UI", 10F);
            this.txtVergiNo.Location = new Point(20, 45);
            this.txtVergiNo.Name = "txtVergiNo";
            this.txtVergiNo.Size = new Size(360, 25);
            this.txtVergiNo.TabIndex = 1;
            // 
            // lblVergiNo
            // 
            this.lblVergiNo.AutoSize = true;
            this.lblVergiNo.Font = new Font("Segoe UI", 10F);
            this.lblVergiNo.Location = new Point(20, 25);
            this.lblVergiNo.Name = "lblVergiNo";
            this.lblVergiNo.Size = new Size(103, 19);
            this.lblVergiNo.TabIndex = 0;
            this.lblVergiNo.Text = "Vergi Numarası";
            // 
            // groupBoxBasic
            // 
            this.groupBoxBasic.Controls.Add(this.chkAktif);
            this.groupBoxBasic.Controls.Add(this.cmbCariTipi);
            this.groupBoxBasic.Controls.Add(this.lblCariTipi);
            this.groupBoxBasic.Controls.Add(this.txtCariAdi);
            this.groupBoxBasic.Controls.Add(this.lblCariAdi);
            this.groupBoxBasic.Controls.Add(this.txtCariKodu);
            this.groupBoxBasic.Controls.Add(this.lblCariKodu);
            this.groupBoxBasic.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.groupBoxBasic.Location = new Point(10, 10);
            this.groupBoxBasic.Name = "groupBoxBasic";
            this.groupBoxBasic.Size = new Size(740, 190);
            this.groupBoxBasic.TabIndex = 0;
            this.groupBoxBasic.TabStop = false;
            this.groupBoxBasic.Text = "Temel Bilgiler";
            // 
            // chkAktif
            // 
            this.chkAktif.AutoSize = true;
            this.chkAktif.Checked = true;
            this.chkAktif.CheckState = CheckState.Checked;
            this.chkAktif.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.chkAktif.Location = new Point(400, 140);
            this.chkAktif.Name = "chkAktif";
            this.chkAktif.Size = new Size(59, 23);
            this.chkAktif.TabIndex = 6;
            this.chkAktif.Text = "Aktif";
            this.chkAktif.UseVisualStyleBackColor = true;
            // 
            // cmbCariTipi
            // 
            this.cmbCariTipi.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCariTipi.Font = new Font("Segoe UI", 10F);
            this.cmbCariTipi.FormattingEnabled = true;
            this.cmbCariTipi.Location = new Point(20, 140);
            this.cmbCariTipi.Name = "cmbCariTipi";
            this.cmbCariTipi.Size = new Size(360, 25);
            this.cmbCariTipi.TabIndex = 5;
            // 
            // lblCariTipi
            // 
            this.lblCariTipi.AutoSize = true;
            this.lblCariTipi.Font = new Font("Segoe UI", 10F);
            this.lblCariTipi.Location = new Point(20, 120);
            this.lblCariTipi.Name = "lblCariTipi";
            this.lblCariTipi.Size = new Size(64, 19);
            this.lblCariTipi.TabIndex = 4;
            this.lblCariTipi.Text = "Cari Tipi*";
            // 
            // txtCariAdi
            // 
            this.txtCariAdi.Font = new Font("Segoe UI", 10F);
            this.txtCariAdi.Location = new Point(20, 90);
            this.txtCariAdi.Name = "txtCariAdi";
            this.txtCariAdi.Size = new Size(700, 25);
            this.txtCariAdi.TabIndex = 3;
            // 
            // lblCariAdi
            // 
            this.lblCariAdi.AutoSize = true;
            this.lblCariAdi.Font = new Font("Segoe UI", 10F);
            this.lblCariAdi.Location = new Point(20, 70);
            this.lblCariAdi.Name = "lblCariAdi";
            this.lblCariAdi.Size = new Size(61, 19);
            this.lblCariAdi.TabIndex = 2;
            this.lblCariAdi.Text = "Cari Adı*";
            // 
            // txtCariKodu
            // 
            this.txtCariKodu.Font = new Font("Segoe UI", 10F);
            this.txtCariKodu.Location = new Point(20, 40);
            this.txtCariKodu.Name = "txtCariKodu";
            this.txtCariKodu.Size = new Size(700, 25);
            this.txtCariKodu.TabIndex = 1;
            // 
            // lblCariKodu
            // 
            this.lblCariKodu.AutoSize = true;
            this.lblCariKodu.Font = new Font("Segoe UI", 10F);
            this.lblCariKodu.Location = new Point(20, 20);
            this.lblCariKodu.Name = "lblCariKodu";
            this.lblCariKodu.Size = new Size(77, 19);
            this.lblCariKodu.TabIndex = 0;
            this.lblCariKodu.Text = "Cari Kodu*";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(59, 130, 246);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(20, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(760, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(760, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "➕ YENİ CARİ HESAP";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CariEkleForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(243, 244, 246);
            this.ClientSize = new Size(800, 700);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CariEkleForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Yeni Cari Hesap";
            this.Load += this.CariEkleForm_Load;
            this.panelMain.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.groupBoxContact.ResumeLayout(false);
            this.groupBoxContact.PerformLayout();
            this.groupBoxTax.ResumeLayout(false);
            this.groupBoxTax.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKrediLimiti)).EndInit();
            this.groupBoxBasic.ResumeLayout(false);
            this.groupBoxBasic.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelForm;
        private GroupBox groupBoxBasic;
        private TextBox txtCariKodu;
        private Label lblCariKodu;
        private TextBox txtCariAdi;
        private Label lblCariAdi;
        private ComboBox cmbCariTipi;
        private Label lblCariTipi;
        private CheckBox chkAktif;
        private GroupBox groupBoxTax;
        private TextBox txtVergiNo;
        private Label lblVergiNo;
        private TextBox txtVergiDairesi;
        private Label lblVergiDairesi;
        private NumericUpDown numKrediLimiti;
        private Label lblKrediLimiti;
        private GroupBox groupBoxContact;
        private TextBox txtIletisimKisi;
        private Label lblIletisimKisi;
        private TextBox txtAdres;
        private Label lblAdres;
        private TextBox txtTelefon;
        private Label lblTelefon;
        private TextBox txtEmail;
        private Label lblEmail;
        private Panel panelButtons;
        private Button btnKaydet;
        private Button btnIptal;
    }
}


