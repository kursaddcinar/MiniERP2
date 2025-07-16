namespace MiniERP.WinForms.Forms
{
    partial class CariHareketleriForm
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
            this.cardHareketler = new Panel();
            this.panelHareketlerHeader = new Panel();
            this.lblHareketlerTitle = new Label();
            this.panelFilters = new Panel();
            this.btnTarihFiltresi = new Button();
            this.btnEkstre = new Button();
            this.btnCariDetay = new Button();
            this.dataGridViewHareketler = new DataGridView();
            this.colTarih = new DataGridViewTextBoxColumn();
            this.colBelgeTipi = new DataGridViewTextBoxColumn();
            this.colBelgeNo = new DataGridViewTextBoxColumn();
            this.colAciklama = new DataGridViewTextBoxColumn();
            this.colBorc = new DataGridViewTextBoxColumn();
            this.colAlacak = new DataGridViewTextBoxColumn();
            this.colBakiye = new DataGridViewTextBoxColumn();
            this.cardCariInfo = new Panel();
            this.lblCariTitle = new Label();
            this.lblGuncelBakiye = new Label();
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.btnGeri = new Button();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.cardHareketler.SuspendLayout();
            this.panelHareketlerHeader.SuspendLayout();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHareketler)).BeginInit();
            this.cardCariInfo.SuspendLayout();
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
            this.panelMain.Size = new Size(1400, 800);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.cardHareketler);
            this.panelContent.Controls.Add(this.cardCariInfo);
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Location = new Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new Padding(20);
            this.panelContent.Size = new Size(1400, 740);
            this.panelContent.TabIndex = 1;
            // 
            // cardHareketler
            // 
            this.cardHareketler.BackColor = Color.White;
            this.cardHareketler.BorderStyle = BorderStyle.FixedSingle;
            this.cardHareketler.Controls.Add(this.dataGridViewHareketler);
            this.cardHareketler.Controls.Add(this.panelFilters);
            this.cardHareketler.Controls.Add(this.panelHareketlerHeader);
            this.cardHareketler.Dock = DockStyle.Fill;
            this.cardHareketler.Location = new Point(20, 120);
            this.cardHareketler.Name = "cardHareketler";
            this.cardHareketler.Size = new Size(1360, 600);
            this.cardHareketler.TabIndex = 1;
            // 
            // panelHareketlerHeader
            // 
            this.panelHareketlerHeader.BackColor = Color.FromArgb(59, 130, 246);
            this.panelHareketlerHeader.Controls.Add(this.lblHareketlerTitle);
            this.panelHareketlerHeader.Dock = DockStyle.Top;
            this.panelHareketlerHeader.Location = new Point(0, 0);
            this.panelHareketlerHeader.Name = "panelHareketlerHeader";
            this.panelHareketlerHeader.Size = new Size(1358, 40);
            this.panelHareketlerHeader.TabIndex = 0;
            // 
            // lblHareketlerTitle
            // 
            this.lblHareketlerTitle.Dock = DockStyle.Fill;
            this.lblHareketlerTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblHareketlerTitle.ForeColor = Color.White;
            this.lblHareketlerTitle.Location = new Point(0, 0);
            this.lblHareketlerTitle.Name = "lblHareketlerTitle";
            this.lblHareketlerTitle.Size = new Size(1358, 40);
            this.lblHareketlerTitle.TabIndex = 0;
            this.lblHareketlerTitle.Text = "🔄 Cari Hareketleri";
            this.lblHareketlerTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = Color.FromArgb(249, 250, 251);
            this.panelFilters.Controls.Add(this.btnTarihFiltresi);
            this.panelFilters.Controls.Add(this.btnEkstre);
            this.panelFilters.Controls.Add(this.btnCariDetay);
            this.panelFilters.Dock = DockStyle.Top;
            this.panelFilters.Location = new Point(0, 40);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Padding = new Padding(15, 10, 15, 10);
            this.panelFilters.Size = new Size(1358, 60);
            this.panelFilters.TabIndex = 1;
            // 
            // btnTarihFiltresi
            // 
            this.btnTarihFiltresi.BackColor = Color.FromArgb(99, 102, 241);
            this.btnTarihFiltresi.FlatAppearance.BorderSize = 0;
            this.btnTarihFiltresi.FlatStyle = FlatStyle.Flat;
            this.btnTarihFiltresi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnTarihFiltresi.ForeColor = Color.White;
            this.btnTarihFiltresi.Location = new Point(15, 15);
            this.btnTarihFiltresi.Name = "btnTarihFiltresi";
            this.btnTarihFiltresi.Size = new Size(140, 30);
            this.btnTarihFiltresi.TabIndex = 0;
            this.btnTarihFiltresi.Text = "📅 Tarih Filtresi";
            this.btnTarihFiltresi.UseVisualStyleBackColor = false;
            this.btnTarihFiltresi.Click += this.BtnTarihFiltresi_Click;
            // 
            // btnEkstre
            // 
            this.btnEkstre.BackColor = Color.FromArgb(16, 185, 129);
            this.btnEkstre.FlatAppearance.BorderSize = 0;
            this.btnEkstre.FlatStyle = FlatStyle.Flat;
            this.btnEkstre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnEkstre.ForeColor = Color.White;
            this.btnEkstre.Location = new Point(165, 15);
            this.btnEkstre.Name = "btnEkstre";
            this.btnEkstre.Size = new Size(120, 30);
            this.btnEkstre.TabIndex = 1;
            this.btnEkstre.Text = "📋 Ekstre";
            this.btnEkstre.UseVisualStyleBackColor = false;
            this.btnEkstre.Click += this.BtnEkstre_Click;
            // 
            // btnCariDetay
            // 
            this.btnCariDetay.BackColor = Color.FromArgb(245, 158, 11);
            this.btnCariDetay.FlatAppearance.BorderSize = 0;
            this.btnCariDetay.FlatStyle = FlatStyle.Flat;
            this.btnCariDetay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCariDetay.ForeColor = Color.White;
            this.btnCariDetay.Location = new Point(295, 15);
            this.btnCariDetay.Name = "btnCariDetay";
            this.btnCariDetay.Size = new Size(120, 30);
            this.btnCariDetay.TabIndex = 2;
            this.btnCariDetay.Text = "👤 Cari Detay";
            this.btnCariDetay.UseVisualStyleBackColor = false;
            this.btnCariDetay.Click += this.BtnCariDetay_Click;
            // 
            // dataGridViewHareketler
            // 
            this.dataGridViewHareketler.AllowUserToAddRows = false;
            this.dataGridViewHareketler.AllowUserToDeleteRows = false;
            this.dataGridViewHareketler.BackgroundColor = Color.White;
            this.dataGridViewHareketler.BorderStyle = BorderStyle.None;
            this.dataGridViewHareketler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHareketler.ColumnHeadersHeight = 35;
            this.dataGridViewHareketler.Columns.AddRange(new DataGridViewColumn[] {
            this.colTarih,
            this.colBelgeTipi,
            this.colBelgeNo,
            this.colAciklama,
            this.colBorc,
            this.colAlacak,
            this.colBakiye});
            this.dataGridViewHareketler.Dock = DockStyle.Fill;
            this.dataGridViewHareketler.Location = new Point(0, 100);
            this.dataGridViewHareketler.Name = "dataGridViewHareketler";
            this.dataGridViewHareketler.ReadOnly = true;
            this.dataGridViewHareketler.RowHeadersVisible = false;
            this.dataGridViewHareketler.RowTemplate.Height = 30;
            this.dataGridViewHareketler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHareketler.Size = new Size(1358, 498);
            this.dataGridViewHareketler.TabIndex = 2;
            // 
            // colTarih
            // 
            this.colTarih.HeaderText = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.ReadOnly = true;
            this.colTarih.Width = 120;
            // 
            // colBelgeTipi
            // 
            this.colBelgeTipi.HeaderText = "Belge Tipi";
            this.colBelgeTipi.Name = "colBelgeTipi";
            this.colBelgeTipi.ReadOnly = true;
            this.colBelgeTipi.Width = 150;
            // 
            // colBelgeNo
            // 
            this.colBelgeNo.HeaderText = "Belge No";
            this.colBelgeNo.Name = "colBelgeNo";
            this.colBelgeNo.ReadOnly = true;
            this.colBelgeNo.Width = 150;
            // 
            // colAciklama
            // 
            this.colAciklama.HeaderText = "Açıklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.ReadOnly = true;
            this.colAciklama.Width = 400;
            // 
            // colBorc
            // 
            this.colBorc.HeaderText = "Borç";
            this.colBorc.Name = "colBorc";
            this.colBorc.ReadOnly = true;
            this.colBorc.Width = 150;
            // 
            // colAlacak
            // 
            this.colAlacak.HeaderText = "Alacak";
            this.colAlacak.Name = "colAlacak";
            this.colAlacak.ReadOnly = true;
            this.colAlacak.Width = 150;
            // 
            // colBakiye
            // 
            this.colBakiye.HeaderText = "Bakiye";
            this.colBakiye.Name = "colBakiye";
            this.colBakiye.ReadOnly = true;
            this.colBakiye.Width = 150;
            // 
            // cardCariInfo
            // 
            this.cardCariInfo.BackColor = Color.White;
            this.cardCariInfo.BorderStyle = BorderStyle.FixedSingle;
            this.cardCariInfo.Controls.Add(this.lblGuncelBakiye);
            this.cardCariInfo.Controls.Add(this.lblCariTitle);
            this.cardCariInfo.Dock = DockStyle.Top;
            this.cardCariInfo.Location = new Point(20, 20);
            this.cardCariInfo.Name = "cardCariInfo";
            this.cardCariInfo.Size = new Size(1360, 100);
            this.cardCariInfo.TabIndex = 0;
            // 
            // lblCariTitle
            // 
            this.lblCariTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblCariTitle.ForeColor = Color.FromArgb(30, 41, 59);
            this.lblCariTitle.Location = new Point(20, 20);
            this.lblCariTitle.Name = "lblCariTitle";
            this.lblCariTitle.Size = new Size(800, 35);
            this.lblCariTitle.TabIndex = 0;
            this.lblCariTitle.Text = "🔄 ABC Teknoloji Ltd. Şti. Hareketleri";
            this.lblCariTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGuncelBakiye
            // 
            this.lblGuncelBakiye.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblGuncelBakiye.ForeColor = Color.FromArgb(34, 197, 94);
            this.lblGuncelBakiye.Location = new Point(850, 20);
            this.lblGuncelBakiye.Name = "lblGuncelBakiye";
            this.lblGuncelBakiye.Size = new Size(480, 60);
            this.lblGuncelBakiye.TabIndex = 1;
            this.lblGuncelBakiye.Text = "$278,200.00\nGüncel Bakiye";
            this.lblGuncelBakiye.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(30, 41, 59);
            this.panelHeader.Controls.Add(this.btnGeri);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(1400, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(1200, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔄 Cari Hareketleri";
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = Color.FromArgb(156, 163, 175);
            this.btnGeri.FlatAppearance.BorderSize = 0;
            this.btnGeri.FlatStyle = FlatStyle.Flat;
            this.btnGeri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnGeri.ForeColor = Color.White;
            this.btnGeri.Location = new Point(1280, 15);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new Size(100, 30);
            this.btnGeri.TabIndex = 1;
            this.btnGeri.Text = "🔙 Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += this.BtnGeri_Click;
            // 
            // CariHareketleriForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.ClientSize = new Size(1400, 800);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CariHareketleriForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Cari Hareketleri";
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.cardHareketler.ResumeLayout(false);
            this.panelHareketlerHeader.ResumeLayout(false);
            this.panelFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHareketler)).EndInit();
            this.cardCariInfo.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelContent;
        private Panel cardHareketler;
        private Panel panelHareketlerHeader;
        private Label lblHareketlerTitle;
        private Panel panelFilters;
        private Button btnTarihFiltresi;
        private Button btnEkstre;
        private Button btnCariDetay;
        private DataGridView dataGridViewHareketler;
        private DataGridViewTextBoxColumn colTarih;
        private DataGridViewTextBoxColumn colBelgeTipi;
        private DataGridViewTextBoxColumn colBelgeNo;
        private DataGridViewTextBoxColumn colAciklama;
        private DataGridViewTextBoxColumn colBorc;
        private DataGridViewTextBoxColumn colAlacak;
        private DataGridViewTextBoxColumn colBakiye;
        private Panel cardCariInfo;
        private Label lblCariTitle;
        private Label lblGuncelBakiye;
        private Panel panelHeader;
        private Label lblTitle;
        private Button btnGeri;
    }
}
