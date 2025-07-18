namespace MiniERP.WinForms.Forms
{
    partial class CariHesaplarForm
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
            this.dataGridViewCari = new DataGridView();
            this.panelSearch = new Panel();
            this.btnTemizle = new Button();
            this.btnAra = new Button();
            this.cmbCariTipi = new ComboBox();
            this.txtArama = new TextBox();
            this.lblCariTipi = new Label();
            this.lblArama = new Label();
            this.panelButtons = new Panel();
            this.btnTedarikcilar = new Button();
            this.btnMusteriler = new Button();
            this.btnYeniCari = new Button();
            this.panelStats = new Panel();
            this.cardAktifCari = new Panel();
            this.lblAktifCariSayi = new Label();
            this.lblAktifCari = new Label();
            this.cardTedarikci = new Panel();
            this.lblTedarikciSayi = new Label();
            this.lblTedarikci = new Label();
            this.cardMusteri = new Panel();
            this.lblMusteriSayi = new Label();
            this.lblMusteri = new Label();
            this.cardToplamCari = new Panel();
            this.lblToplamCariSayi = new Label();
            this.lblToplamCari = new Label();
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCari)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.cardAktifCari.SuspendLayout();
            this.cardTedarikci.SuspendLayout();
            this.cardMusteri.SuspendLayout();
            this.cardToplamCari.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Controls.Add(this.panelStats);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(1200, 800);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.dataGridViewCari);
            this.panelContent.Controls.Add(this.panelSearch);
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Location = new Point(20, 220);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new Size(1160, 560);
            this.panelContent.TabIndex = 3;
            // 
            // dataGridViewCari
            // 
            this.dataGridViewCari.AllowUserToAddRows = false;
            this.dataGridViewCari.AllowUserToDeleteRows = false;
            this.dataGridViewCari.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCari.BackgroundColor = Color.White;
            this.dataGridViewCari.BorderStyle = BorderStyle.None;
            this.dataGridViewCari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCari.Dock = DockStyle.Fill;
            this.dataGridViewCari.GridColor = Color.FromArgb(230, 230, 230);
            this.dataGridViewCari.Location = new Point(0, 80);
            this.dataGridViewCari.MultiSelect = false;
            this.dataGridViewCari.Name = "dataGridViewCari";
            this.dataGridViewCari.ReadOnly = true;
            this.dataGridViewCari.RowHeadersVisible = false;
            this.dataGridViewCari.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCari.Size = new Size(1160, 480);
            this.dataGridViewCari.TabIndex = 1;
            this.dataGridViewCari.CellFormatting += this.DataGridViewCari_CellFormatting;
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = Color.White;
            this.panelSearch.Controls.Add(this.btnTemizle);
            this.panelSearch.Controls.Add(this.btnAra);
            this.panelSearch.Controls.Add(this.cmbCariTipi);
            this.panelSearch.Controls.Add(this.txtArama);
            this.panelSearch.Controls.Add(this.lblCariTipi);
            this.panelSearch.Controls.Add(this.lblArama);
            this.panelSearch.Dock = DockStyle.Top;
            this.panelSearch.Location = new Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Padding = new Padding(20);
            this.panelSearch.Size = new Size(1160, 80);
            this.panelSearch.TabIndex = 0;
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = Color.FromArgb(156, 163, 175);
            this.btnTemizle.FlatAppearance.BorderSize = 0;
            this.btnTemizle.FlatStyle = FlatStyle.Flat;
            this.btnTemizle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnTemizle.ForeColor = Color.White;
            this.btnTemizle.Location = new Point(730, 25);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new Size(100, 35);
            this.btnTemizle.TabIndex = 5;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += this.BtnTemizle_Click;
            // 
            // btnAra
            // 
            this.btnAra.BackColor = Color.FromArgb(59, 130, 246);
            this.btnAra.FlatAppearance.BorderSize = 0;
            this.btnAra.FlatStyle = FlatStyle.Flat;
            this.btnAra.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAra.ForeColor = Color.White;
            this.btnAra.Location = new Point(620, 25);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new Size(100, 35);
            this.btnAra.TabIndex = 4;
            this.btnAra.Text = "🔍 Ara";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += this.BtnAra_Click;
            // 
            // cmbCariTipi
            // 
            this.cmbCariTipi.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCariTipi.Font = new Font("Segoe UI", 10F);
            this.cmbCariTipi.FormattingEnabled = true;
            this.cmbCariTipi.Location = new Point(400, 30);
            this.cmbCariTipi.Name = "cmbCariTipi";
            this.cmbCariTipi.Size = new Size(200, 25);
            this.cmbCariTipi.TabIndex = 3;
            // 
            // txtArama
            // 
            this.txtArama.Font = new Font("Segoe UI", 10F);
            this.txtArama.Location = new Point(100, 30);
            this.txtArama.Name = "txtArama";
            this.txtArama.PlaceholderText = "Cari Adı, Kodu, Telefon arayın...";
            this.txtArama.Size = new Size(250, 25);
            this.txtArama.TabIndex = 2;
            this.txtArama.KeyPress += this.TxtArama_KeyPress;
            // 
            // lblCariTipi
            // 
            this.lblCariTipi.AutoSize = true;
            this.lblCariTipi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCariTipi.Location = new Point(400, 10);
            this.lblCariTipi.Name = "lblCariTipi";
            this.lblCariTipi.Size = new Size(64, 19);
            this.lblCariTipi.TabIndex = 1;
            this.lblCariTipi.Text = "Cari Tipi";
            // 
            // lblArama
            // 
            this.lblArama.AutoSize = true;
            this.lblArama.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblArama.Location = new Point(100, 10);
            this.lblArama.Name = "lblArama";
            this.lblArama.Size = new Size(47, 19);
            this.lblArama.TabIndex = 0;
            this.lblArama.Text = "Arama";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnTedarikcilar);
            this.panelButtons.Controls.Add(this.btnMusteriler);
            this.panelButtons.Controls.Add(this.btnYeniCari);
            this.panelButtons.Dock = DockStyle.Top;
            this.panelButtons.Location = new Point(20, 170);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(1160, 50);
            this.panelButtons.TabIndex = 2;
            // 
            // btnTedarikcilar
            // 
            this.btnTedarikcilar.BackColor = Color.FromArgb(168, 85, 247);
            this.btnTedarikcilar.FlatAppearance.BorderSize = 0;
            this.btnTedarikcilar.FlatStyle = FlatStyle.Flat;
            this.btnTedarikcilar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnTedarikcilar.ForeColor = Color.White;
            this.btnTedarikcilar.Location = new Point(280, 10);
            this.btnTedarikcilar.Name = "btnTedarikcilar";
            this.btnTedarikcilar.Size = new Size(130, 40);
            this.btnTedarikcilar.TabIndex = 2;
            this.btnTedarikcilar.Text = "🛍️ Tedarikçiler";
            this.btnTedarikcilar.UseVisualStyleBackColor = false;
            this.btnTedarikcilar.Click += this.BtnTedarikcilar_Click;
            // 
            // btnMusteriler
            // 
            this.btnMusteriler.BackColor = Color.FromArgb(34, 197, 94);
            this.btnMusteriler.FlatAppearance.BorderSize = 0;
            this.btnMusteriler.FlatStyle = FlatStyle.Flat;
            this.btnMusteriler.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnMusteriler.ForeColor = Color.White;
            this.btnMusteriler.Location = new Point(140, 10);
            this.btnMusteriler.Name = "btnMusteriler";
            this.btnMusteriler.Size = new Size(130, 40);
            this.btnMusteriler.TabIndex = 1;
            this.btnMusteriler.Text = "👥 Müşteriler";
            this.btnMusteriler.UseVisualStyleBackColor = false;
            this.btnMusteriler.Click += this.BtnMusteriler_Click;
            // 
            // btnYeniCari
            // 
            this.btnYeniCari.BackColor = Color.FromArgb(59, 130, 246);
            this.btnYeniCari.FlatAppearance.BorderSize = 0;
            this.btnYeniCari.FlatStyle = FlatStyle.Flat;
            this.btnYeniCari.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnYeniCari.ForeColor = Color.White;
            this.btnYeniCari.Location = new Point(0, 10);
            this.btnYeniCari.Name = "btnYeniCari";
            this.btnYeniCari.Size = new Size(130, 40);
            this.btnYeniCari.TabIndex = 0;
            this.btnYeniCari.Text = "➕ Yeni Cari";
            this.btnYeniCari.UseVisualStyleBackColor = false;
            this.btnYeniCari.Click += this.BtnYeniCari_Click;
            // 
            // panelStats
            // 
            this.panelStats.Controls.Add(this.cardAktifCari);
            this.panelStats.Controls.Add(this.cardTedarikci);
            this.panelStats.Controls.Add(this.cardMusteri);
            this.panelStats.Controls.Add(this.cardToplamCari);
            this.panelStats.Dock = DockStyle.Top;
            this.panelStats.Location = new Point(20, 70);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new Size(1160, 100);
            this.panelStats.TabIndex = 1;
            // 
            // cardAktifCari
            // 
            this.cardAktifCari.BackColor = Color.FromArgb(249, 115, 22);
            this.cardAktifCari.Controls.Add(this.lblAktifCariSayi);
            this.cardAktifCari.Controls.Add(this.lblAktifCari);
            this.cardAktifCari.Location = new Point(870, 10);
            this.cardAktifCari.Name = "cardAktifCari";
            this.cardAktifCari.Size = new Size(280, 80);
            this.cardAktifCari.TabIndex = 3;
            // 
            // lblAktifCariSayi
            // 
            this.lblAktifCariSayi.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblAktifCariSayi.ForeColor = Color.White;
            this.lblAktifCariSayi.Location = new Point(200, 20);
            this.lblAktifCariSayi.Name = "lblAktifCariSayi";
            this.lblAktifCariSayi.Size = new Size(70, 40);
            this.lblAktifCariSayi.TabIndex = 1;
            this.lblAktifCariSayi.Text = "0";
            this.lblAktifCariSayi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAktifCari
            // 
            this.lblAktifCari.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblAktifCari.ForeColor = Color.White;
            this.lblAktifCari.Location = new Point(10, 10);
            this.lblAktifCari.Name = "lblAktifCari";
            this.lblAktifCari.Size = new Size(180, 60);
            this.lblAktifCari.TabIndex = 0;
            this.lblAktifCari.Text = "⚡ AKTİF CARİ";
            this.lblAktifCari.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cardTedarikci
            // 
            this.cardTedarikci.BackColor = Color.FromArgb(14, 165, 233);
            this.cardTedarikci.Controls.Add(this.lblTedarikciSayi);
            this.cardTedarikci.Controls.Add(this.lblTedarikci);
            this.cardTedarikci.Location = new Point(580, 10);
            this.cardTedarikci.Name = "cardTedarikci";
            this.cardTedarikci.Size = new Size(280, 80);
            this.cardTedarikci.TabIndex = 2;
            // 
            // lblTedarikciSayi
            // 
            this.lblTedarikciSayi.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTedarikciSayi.ForeColor = Color.White;
            this.lblTedarikciSayi.Location = new Point(200, 20);
            this.lblTedarikciSayi.Name = "lblTedarikciSayi";
            this.lblTedarikciSayi.Size = new Size(70, 40);
            this.lblTedarikciSayi.TabIndex = 1;
            this.lblTedarikciSayi.Text = "0";
            this.lblTedarikciSayi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTedarikci
            // 
            this.lblTedarikci.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTedarikci.ForeColor = Color.White;
            this.lblTedarikci.Location = new Point(10, 10);
            this.lblTedarikci.Name = "lblTedarikci";
            this.lblTedarikci.Size = new Size(180, 60);
            this.lblTedarikci.TabIndex = 0;
            this.lblTedarikci.Text = "🚚 TEDARİKÇİ";
            this.lblTedarikci.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cardMusteri
            // 
            this.cardMusteri.BackColor = Color.FromArgb(34, 197, 94);
            this.cardMusteri.Controls.Add(this.lblMusteriSayi);
            this.cardMusteri.Controls.Add(this.lblMusteri);
            this.cardMusteri.Location = new Point(290, 10);
            this.cardMusteri.Name = "cardMusteri";
            this.cardMusteri.Size = new Size(280, 80);
            this.cardMusteri.TabIndex = 1;
            // 
            // lblMusteriSayi
            // 
            this.lblMusteriSayi.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblMusteriSayi.ForeColor = Color.White;
            this.lblMusteriSayi.Location = new Point(200, 20);
            this.lblMusteriSayi.Name = "lblMusteriSayi";
            this.lblMusteriSayi.Size = new Size(70, 40);
            this.lblMusteriSayi.TabIndex = 1;
            this.lblMusteriSayi.Text = "0";
            this.lblMusteriSayi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMusteri
            // 
            this.lblMusteri.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblMusteri.ForeColor = Color.White;
            this.lblMusteri.Location = new Point(10, 10);
            this.lblMusteri.Name = "lblMusteri";
            this.lblMusteri.Size = new Size(180, 60);
            this.lblMusteri.TabIndex = 0;
            this.lblMusteri.Text = "👥 MÜŞTERİ";
            this.lblMusteri.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cardToplamCari
            // 
            this.cardToplamCari.BackColor = Color.FromArgb(139, 69, 19);
            this.cardToplamCari.Controls.Add(this.lblToplamCariSayi);
            this.cardToplamCari.Controls.Add(this.lblToplamCari);
            this.cardToplamCari.Location = new Point(0, 10);
            this.cardToplamCari.Name = "cardToplamCari";
            this.cardToplamCari.Size = new Size(280, 80);
            this.cardToplamCari.TabIndex = 0;
            // 
            // lblToplamCariSayi
            // 
            this.lblToplamCariSayi.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblToplamCariSayi.ForeColor = Color.White;
            this.lblToplamCariSayi.Location = new Point(200, 20);
            this.lblToplamCariSayi.Name = "lblToplamCariSayi";
            this.lblToplamCariSayi.Size = new Size(70, 40);
            this.lblToplamCariSayi.TabIndex = 1;
            this.lblToplamCariSayi.Text = "0";
            this.lblToplamCariSayi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblToplamCari
            // 
            this.lblToplamCari.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblToplamCari.ForeColor = Color.White;
            this.lblToplamCari.Location = new Point(10, 10);
            this.lblToplamCari.Name = "lblToplamCari";
            this.lblToplamCari.Size = new Size(180, 60);
            this.lblToplamCari.TabIndex = 0;
            this.lblToplamCari.Text = "📊 TOPLAM CARİ";
            this.lblToplamCari.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(59, 130, 246);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(20, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(1160, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(1160, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👥 CARİ HESAPLAR";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CariHesaplarForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(243, 244, 246);
            this.ClientSize = new Size(1200, 800);
            this.Controls.Add(this.panelMain);
            this.Name = "CariHesaplarForm";
            this.Text = "Cari Hesaplar";
            this.Load += this.CariHesaplarForm_Load;
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCari)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.cardAktifCari.ResumeLayout(false);
            this.cardTedarikci.ResumeLayout(false);
            this.cardMusteri.ResumeLayout(false);
            this.cardToplamCari.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelStats;
        private Panel cardToplamCari;
        private Label lblToplamCariSayi;
        private Label lblToplamCari;
        private Panel cardMusteri;
        private Label lblMusteriSayi;
        private Label lblMusteri;
        private Panel cardTedarikci;
        private Label lblTedarikciSayi;
        private Label lblTedarikci;
        private Panel cardAktifCari;
        private Label lblAktifCariSayi;
        private Label lblAktifCari;
        private Panel panelButtons;
        private Button btnYeniCari;
        private Button btnMusteriler;
        private Button btnTedarikcilar;
        private Panel panelContent;
        private Panel panelSearch;
        private Label lblArama;
        private Label lblCariTipi;
        private TextBox txtArama;
        private ComboBox cmbCariTipi;
        private Button btnAra;
        private Button btnTemizle;
        private DataGridView dataGridViewCari;
    }
}


