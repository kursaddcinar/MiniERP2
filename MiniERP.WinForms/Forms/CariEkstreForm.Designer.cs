namespace MiniERP.WinForms.Forms
{
    partial class CariEkstreForm
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
            this.cardGrid = new Panel();
            this.dataGridViewHareketler = new DataGridView();
            this.colTarih = new DataGridViewTextBoxColumn();
            this.colBelgeTipi = new DataGridViewTextBoxColumn();
            this.colBelgeNo = new DataGridViewTextBoxColumn();
            this.colAciklama = new DataGridViewTextBoxColumn();
            this.colBorc = new DataGridViewTextBoxColumn();
            this.colAlacak = new DataGridViewTextBoxColumn();
            this.colBakiye = new DataGridViewTextBoxColumn();
            this.panelGridButtons = new Panel();
            this.btnCariListesi = new Button();
            this.btnTumHareketler = new Button();
            this.btnCariDetay = new Button();
            this.lblGridTitle = new Label();
            this.cardSummary = new Panel();
            this.lblSummaryTitle = new Label();
            this.panelSummaryBoxes = new Panel();
            this.boxDonemSonu = new Panel();
            this.lblDonemSonuValue = new Label();
            this.lblDonemSonu = new Label();
            this.boxToplamAlacak = new Panel();
            this.lblToplamAlacakValue = new Label();
            this.lblToplamAlacak = new Label();
            this.boxToplamBorc = new Panel();
            this.lblToplamBorcValue = new Label();
            this.lblToplamBorc = new Label();
            this.boxDonemBasi = new Panel();
            this.lblDonemBasiValue = new Label();
            this.lblDonemBasi = new Label();
            this.cardCariInfo = new Panel();
            this.panelCariButtons = new Panel();
            this.btnYazdir = new Button();
            this.btnExcel = new Button();
            this.btnCariDetayTop = new Button();
            this.panelCariDetails = new Panel();
            this.lblDonemSonuBakiye = new Label();
            this.lblDonemSonuBakiyeValue = new Label();
            this.lblDonemBasiBakiye = new Label();
            this.lblDonemBasiBakiyeValue = new Label();
            this.lblCariAdi = new Label();
            this.lblCariAdiValue = new Label();
            this.lblCariKodu = new Label();
            this.lblCariKoduValue = new Label();
            this.lblCariTitle = new Label();
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.cardGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHareketler)).BeginInit();
            this.panelGridButtons.SuspendLayout();
            this.cardSummary.SuspendLayout();
            this.panelSummaryBoxes.SuspendLayout();
            this.boxDonemSonu.SuspendLayout();
            this.boxToplamAlacak.SuspendLayout();
            this.boxToplamBorc.SuspendLayout();
            this.boxDonemBasi.SuspendLayout();
            this.cardCariInfo.SuspendLayout();
            this.panelCariButtons.SuspendLayout();
            this.panelCariDetails.SuspendLayout();
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
            this.panelMain.Size = new Size(1400, 900);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.cardGrid);
            this.panelContent.Controls.Add(this.cardSummary);
            this.panelContent.Controls.Add(this.cardCariInfo);
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Location = new Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new Padding(20);
            this.panelContent.Size = new Size(1400, 840);
            this.panelContent.TabIndex = 1;
            // 
            // cardGrid
            // 
            this.cardGrid.BackColor = Color.White;
            this.cardGrid.BorderStyle = BorderStyle.FixedSingle;
            this.cardGrid.Controls.Add(this.dataGridViewHareketler);
            this.cardGrid.Controls.Add(this.panelGridButtons);
            this.cardGrid.Controls.Add(this.lblGridTitle);
            this.cardGrid.Dock = DockStyle.Fill;
            this.cardGrid.Location = new Point(20, 310);
            this.cardGrid.Name = "cardGrid";
            this.cardGrid.Size = new Size(1360, 510);
            this.cardGrid.TabIndex = 2;
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
            this.dataGridViewHareketler.Location = new Point(0, 40);
            this.dataGridViewHareketler.Name = "dataGridViewHareketler";
            this.dataGridViewHareketler.ReadOnly = true;
            this.dataGridViewHareketler.RowHeadersVisible = false;
            this.dataGridViewHareketler.RowTemplate.Height = 30;
            this.dataGridViewHareketler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHareketler.Size = new Size(1358, 410);
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
            // panelGridButtons
            // 
            this.panelGridButtons.Controls.Add(this.btnCariListesi);
            this.panelGridButtons.Controls.Add(this.btnTumHareketler);
            this.panelGridButtons.Controls.Add(this.btnCariDetay);
            this.panelGridButtons.Dock = DockStyle.Bottom;
            this.panelGridButtons.Location = new Point(0, 450);
            this.panelGridButtons.Name = "panelGridButtons";
            this.panelGridButtons.Padding = new Padding(15);
            this.panelGridButtons.Size = new Size(1358, 58);
            this.panelGridButtons.TabIndex = 3;
            // 
            // btnCariListesi
            // 
            this.btnCariListesi.BackColor = Color.FromArgb(156, 163, 175);
            this.btnCariListesi.FlatAppearance.BorderSize = 0;
            this.btnCariListesi.FlatStyle = FlatStyle.Flat;
            this.btnCariListesi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCariListesi.ForeColor = Color.White;
            this.btnCariListesi.Location = new Point(15, 15);
            this.btnCariListesi.Name = "btnCariListesi";
            this.btnCariListesi.Size = new Size(150, 30);
            this.btnCariListesi.TabIndex = 0;
            this.btnCariListesi.Text = "🔙 Cari Listesine Dön";
            this.btnCariListesi.UseVisualStyleBackColor = false;
            this.btnCariListesi.Click += this.BtnCariListesi_Click;
            // 
            // btnTumHareketler
            // 
            this.btnTumHareketler.BackColor = Color.FromArgb(16, 185, 129);
            this.btnTumHareketler.FlatAppearance.BorderSize = 0;
            this.btnTumHareketler.FlatStyle = FlatStyle.Flat;
            this.btnTumHareketler.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnTumHareketler.ForeColor = Color.White;
            this.btnTumHareketler.Location = new Point(175, 15);
            this.btnTumHareketler.Name = "btnTumHareketler";
            this.btnTumHareketler.Size = new Size(150, 30);
            this.btnTumHareketler.TabIndex = 1;
            this.btnTumHareketler.Text = "📊 Tüm Hareketler";
            this.btnTumHareketler.UseVisualStyleBackColor = false;
            this.btnTumHareketler.Click += this.BtnTumHareketler_Click;
            // 
            // btnCariDetay
            // 
            this.btnCariDetay.BackColor = Color.FromArgb(245, 158, 11);
            this.btnCariDetay.FlatAppearance.BorderSize = 0;
            this.btnCariDetay.FlatStyle = FlatStyle.Flat;
            this.btnCariDetay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCariDetay.ForeColor = Color.White;
            this.btnCariDetay.Location = new Point(335, 15);
            this.btnCariDetay.Name = "btnCariDetay";
            this.btnCariDetay.Size = new Size(120, 30);
            this.btnCariDetay.TabIndex = 2;
            this.btnCariDetay.Text = "👤 Cari Detay";
            this.btnCariDetay.UseVisualStyleBackColor = false;
            this.btnCariDetay.Click += this.BtnCariDetay_Click;
            // 
            // lblGridTitle
            // 
            this.lblGridTitle.BackColor = Color.FromArgb(30, 41, 59);
            this.lblGridTitle.Dock = DockStyle.Top;
            this.lblGridTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblGridTitle.ForeColor = Color.White;
            this.lblGridTitle.Location = new Point(0, 0);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new Size(1358, 40);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "📊 Hareket Detayları";
            this.lblGridTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardSummary
            // 
            this.cardSummary.BackColor = Color.White;
            this.cardSummary.BorderStyle = BorderStyle.FixedSingle;
            this.cardSummary.Controls.Add(this.panelSummaryBoxes);
            this.cardSummary.Controls.Add(this.lblSummaryTitle);
            this.cardSummary.Dock = DockStyle.Top;
            this.cardSummary.Location = new Point(20, 160);
            this.cardSummary.Name = "cardSummary";
            this.cardSummary.Size = new Size(1360, 150);
            this.cardSummary.TabIndex = 1;
            // 
            // lblSummaryTitle
            // 
            this.lblSummaryTitle.BackColor = Color.FromArgb(34, 197, 94);
            this.lblSummaryTitle.Dock = DockStyle.Top;
            this.lblSummaryTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblSummaryTitle.ForeColor = Color.White;
            this.lblSummaryTitle.Location = new Point(0, 0);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new Size(1358, 40);
            this.lblSummaryTitle.TabIndex = 0;
            this.lblSummaryTitle.Text = "💰 Özet Bilgileri";
            this.lblSummaryTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSummaryBoxes
            // 
            this.panelSummaryBoxes.Controls.Add(this.boxDonemSonu);
            this.panelSummaryBoxes.Controls.Add(this.boxToplamAlacak);
            this.panelSummaryBoxes.Controls.Add(this.boxToplamBorc);
            this.panelSummaryBoxes.Controls.Add(this.boxDonemBasi);
            this.panelSummaryBoxes.Dock = DockStyle.Fill;
            this.panelSummaryBoxes.Location = new Point(0, 40);
            this.panelSummaryBoxes.Name = "panelSummaryBoxes";
            this.panelSummaryBoxes.Padding = new Padding(20);
            this.panelSummaryBoxes.Size = new Size(1358, 108);
            this.panelSummaryBoxes.TabIndex = 1;
            // 
            // boxDonemSonu
            // 
            this.boxDonemSonu.BackColor = Color.FromArgb(245, 158, 11);
            this.boxDonemSonu.Controls.Add(this.lblDonemSonuValue);
            this.boxDonemSonu.Controls.Add(this.lblDonemSonu);
            this.boxDonemSonu.Location = new Point(1022, 20);
            this.boxDonemSonu.Name = "boxDonemSonu";
            this.boxDonemSonu.Size = new Size(314, 68);
            this.boxDonemSonu.TabIndex = 3;
            // 
            // lblDonemSonuValue
            // 
            this.lblDonemSonuValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblDonemSonuValue.ForeColor = Color.White;
            this.lblDonemSonuValue.Location = new Point(10, 5);
            this.lblDonemSonuValue.Name = "lblDonemSonuValue";
            this.lblDonemSonuValue.Size = new Size(294, 35);
            this.lblDonemSonuValue.TabIndex = 1;
            this.lblDonemSonuValue.Text = "$278,200.00";
            this.lblDonemSonuValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDonemSonu
            // 
            this.lblDonemSonu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDonemSonu.ForeColor = Color.White;
            this.lblDonemSonu.Location = new Point(10, 40);
            this.lblDonemSonu.Name = "lblDonemSonu";
            this.lblDonemSonu.Size = new Size(294, 23);
            this.lblDonemSonu.TabIndex = 0;
            this.lblDonemSonu.Text = "Dönem Sonu Bakiye";
            this.lblDonemSonu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // boxToplamAlacak
            // 
            this.boxToplamAlacak.BackColor = Color.FromArgb(34, 197, 94);
            this.boxToplamAlacak.Controls.Add(this.lblToplamAlacakValue);
            this.boxToplamAlacak.Controls.Add(this.lblToplamAlacak);
            this.boxToplamAlacak.Location = new Point(688, 20);
            this.boxToplamAlacak.Name = "boxToplamAlacak";
            this.boxToplamAlacak.Size = new Size(314, 68);
            this.boxToplamAlacak.TabIndex = 2;
            // 
            // lblToplamAlacakValue
            // 
            this.lblToplamAlacakValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblToplamAlacakValue.ForeColor = Color.White;
            this.lblToplamAlacakValue.Location = new Point(10, 5);
            this.lblToplamAlacakValue.Name = "lblToplamAlacakValue";
            this.lblToplamAlacakValue.Size = new Size(294, 35);
            this.lblToplamAlacakValue.TabIndex = 1;
            this.lblToplamAlacakValue.Text = "$578,200.00";
            this.lblToplamAlacakValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblToplamAlacak
            // 
            this.lblToplamAlacak.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblToplamAlacak.ForeColor = Color.White;
            this.lblToplamAlacak.Location = new Point(10, 40);
            this.lblToplamAlacak.Name = "lblToplamAlacak";
            this.lblToplamAlacak.Size = new Size(294, 23);
            this.lblToplamAlacak.TabIndex = 0;
            this.lblToplamAlacak.Text = "Toplam Alacak";
            this.lblToplamAlacak.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // boxToplamBorc
            // 
            this.boxToplamBorc.BackColor = Color.FromArgb(239, 68, 68);
            this.boxToplamBorc.Controls.Add(this.lblToplamBorcValue);
            this.boxToplamBorc.Controls.Add(this.lblToplamBorc);
            this.boxToplamBorc.Location = new Point(354, 20);
            this.boxToplamBorc.Name = "boxToplamBorc";
            this.boxToplamBorc.Size = new Size(314, 68);
            this.boxToplamBorc.TabIndex = 1;
            // 
            // lblToplamBorcValue
            // 
            this.lblToplamBorcValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblToplamBorcValue.ForeColor = Color.White;
            this.lblToplamBorcValue.Location = new Point(10, 5);
            this.lblToplamBorcValue.Name = "lblToplamBorcValue";
            this.lblToplamBorcValue.Size = new Size(294, 35);
            this.lblToplamBorcValue.TabIndex = 1;
            this.lblToplamBorcValue.Text = "$300,000.00";
            this.lblToplamBorcValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblToplamBorc
            // 
            this.lblToplamBorc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblToplamBorc.ForeColor = Color.White;
            this.lblToplamBorc.Location = new Point(10, 40);
            this.lblToplamBorc.Name = "lblToplamBorc";
            this.lblToplamBorc.Size = new Size(294, 23);
            this.lblToplamBorc.TabIndex = 0;
            this.lblToplamBorc.Text = "Toplam Borç";
            this.lblToplamBorc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // boxDonemBasi
            // 
            this.boxDonemBasi.BackColor = Color.FromArgb(59, 130, 246);
            this.boxDonemBasi.Controls.Add(this.lblDonemBasiValue);
            this.boxDonemBasi.Controls.Add(this.lblDonemBasi);
            this.boxDonemBasi.Location = new Point(20, 20);
            this.boxDonemBasi.Name = "boxDonemBasi";
            this.boxDonemBasi.Size = new Size(314, 68);
            this.boxDonemBasi.TabIndex = 0;
            // 
            // lblDonemBasiValue
            // 
            this.lblDonemBasiValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblDonemBasiValue.ForeColor = Color.White;
            this.lblDonemBasiValue.Location = new Point(10, 5);
            this.lblDonemBasiValue.Name = "lblDonemBasiValue";
            this.lblDonemBasiValue.Size = new Size(294, 35);
            this.lblDonemBasiValue.TabIndex = 1;
            this.lblDonemBasiValue.Text = "$0.00";
            this.lblDonemBasiValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDonemBasi
            // 
            this.lblDonemBasi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDonemBasi.ForeColor = Color.White;
            this.lblDonemBasi.Location = new Point(10, 40);
            this.lblDonemBasi.Name = "lblDonemBasi";
            this.lblDonemBasi.Size = new Size(294, 23);
            this.lblDonemBasi.TabIndex = 0;
            this.lblDonemBasi.Text = "Dönem Başı Bakiye";
            this.lblDonemBasi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardCariInfo
            // 
            this.cardCariInfo.BackColor = Color.White;
            this.cardCariInfo.BorderStyle = BorderStyle.FixedSingle;
            this.cardCariInfo.Controls.Add(this.panelCariDetails);
            this.cardCariInfo.Controls.Add(this.panelCariButtons);
            this.cardCariInfo.Controls.Add(this.lblCariTitle);
            this.cardCariInfo.Dock = DockStyle.Top;
            this.cardCariInfo.Location = new Point(20, 20);
            this.cardCariInfo.Name = "cardCariInfo";
            this.cardCariInfo.Size = new Size(1360, 140);
            this.cardCariInfo.TabIndex = 0;
            // 
            // panelCariButtons
            // 
            this.panelCariButtons.Controls.Add(this.btnYazdir);
            this.panelCariButtons.Controls.Add(this.btnExcel);
            this.panelCariButtons.Controls.Add(this.btnCariDetayTop);
            this.panelCariButtons.Dock = DockStyle.Right;
            this.panelCariButtons.Location = new Point(1000, 40);
            this.panelCariButtons.Name = "panelCariButtons";
            this.panelCariButtons.Padding = new Padding(15, 10, 15, 10);
            this.panelCariButtons.Size = new Size(358, 98);
            this.panelCariButtons.TabIndex = 2;
            // 
            // btnYazdir
            // 
            this.btnYazdir.BackColor = Color.FromArgb(34, 197, 94);
            this.btnYazdir.FlatAppearance.BorderSize = 0;
            this.btnYazdir.FlatStyle = FlatStyle.Flat;
            this.btnYazdir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnYazdir.ForeColor = Color.White;
            this.btnYazdir.Location = new Point(15, 15);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new Size(100, 30);
            this.btnYazdir.TabIndex = 0;
            this.btnYazdir.Text = "🖨️ Yazdır";
            this.btnYazdir.UseVisualStyleBackColor = false;
            this.btnYazdir.Click += this.BtnYazdir_Click;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = Color.FromArgb(59, 130, 246);
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatStyle = FlatStyle.Flat;
            this.btnExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnExcel.ForeColor = Color.White;
            this.btnExcel.Location = new Point(125, 15);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new Size(100, 30);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.Text = "📊 Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += this.BtnExcel_Click;
            // 
            // btnCariDetayTop
            // 
            this.btnCariDetayTop.BackColor = Color.FromArgb(156, 163, 175);
            this.btnCariDetayTop.FlatAppearance.BorderSize = 0;
            this.btnCariDetayTop.FlatStyle = FlatStyle.Flat;
            this.btnCariDetayTop.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCariDetayTop.ForeColor = Color.White;
            this.btnCariDetayTop.Location = new Point(235, 15);
            this.btnCariDetayTop.Name = "btnCariDetayTop";
            this.btnCariDetayTop.Size = new Size(108, 30);
            this.btnCariDetayTop.TabIndex = 2;
            this.btnCariDetayTop.Text = "👤 Cari Detay";
            this.btnCariDetayTop.UseVisualStyleBackColor = false;
            this.btnCariDetayTop.Click += this.BtnCariDetayTop_Click;
            // 
            // panelCariDetails
            // 
            this.panelCariDetails.Controls.Add(this.lblDonemSonuBakiye);
            this.panelCariDetails.Controls.Add(this.lblDonemSonuBakiyeValue);
            this.panelCariDetails.Controls.Add(this.lblDonemBasiBakiye);
            this.panelCariDetails.Controls.Add(this.lblDonemBasiBakiyeValue);
            this.panelCariDetails.Controls.Add(this.lblCariAdi);
            this.panelCariDetails.Controls.Add(this.lblCariAdiValue);
            this.panelCariDetails.Controls.Add(this.lblCariKodu);
            this.panelCariDetails.Controls.Add(this.lblCariKoduValue);
            this.panelCariDetails.Dock = DockStyle.Fill;
            this.panelCariDetails.Location = new Point(0, 40);
            this.panelCariDetails.Name = "panelCariDetails";
            this.panelCariDetails.Padding = new Padding(20, 10, 20, 10);
            this.panelCariDetails.Size = new Size(1000, 98);
            this.panelCariDetails.TabIndex = 1;
            // 
            // lblDonemSonuBakiye
            // 
            this.lblDonemSonuBakiye.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDonemSonuBakiye.Location = new Point(520, 50);
            this.lblDonemSonuBakiye.Name = "lblDonemSonuBakiye";
            this.lblDonemSonuBakiye.Size = new Size(150, 25);
            this.lblDonemSonuBakiye.TabIndex = 6;
            this.lblDonemSonuBakiye.Text = "Dönem Sonu Bakiye:";
            // 
            // lblDonemSonuBakiyeValue
            // 
            this.lblDonemSonuBakiyeValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDonemSonuBakiyeValue.ForeColor = Color.FromArgb(34, 197, 94);
            this.lblDonemSonuBakiyeValue.Location = new Point(680, 50);
            this.lblDonemSonuBakiyeValue.Name = "lblDonemSonuBakiyeValue";
            this.lblDonemSonuBakiyeValue.Size = new Size(300, 25);
            this.lblDonemSonuBakiyeValue.TabIndex = 7;
            this.lblDonemSonuBakiyeValue.Text = "$278,200.00";
            // 
            // lblDonemBasiBakiye
            // 
            this.lblDonemBasiBakiye.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDonemBasiBakiye.Location = new Point(520, 15);
            this.lblDonemBasiBakiye.Name = "lblDonemBasiBakiye";
            this.lblDonemBasiBakiye.Size = new Size(150, 25);
            this.lblDonemBasiBakiye.TabIndex = 4;
            this.lblDonemBasiBakiye.Text = "Dönem Başı Bakiye:";
            // 
            // lblDonemBasiBakiyeValue
            // 
            this.lblDonemBasiBakiyeValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDonemBasiBakiyeValue.ForeColor = Color.FromArgb(59, 130, 246);
            this.lblDonemBasiBakiyeValue.Location = new Point(680, 15);
            this.lblDonemBasiBakiyeValue.Name = "lblDonemBasiBakiyeValue";
            this.lblDonemBasiBakiyeValue.Size = new Size(300, 25);
            this.lblDonemBasiBakiyeValue.TabIndex = 5;
            this.lblDonemBasiBakiyeValue.Text = "$0.00";
            // 
            // lblCariAdi
            // 
            this.lblCariAdi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCariAdi.Location = new Point(20, 50);
            this.lblCariAdi.Name = "lblCariAdi";
            this.lblCariAdi.Size = new Size(100, 25);
            this.lblCariAdi.TabIndex = 2;
            this.lblCariAdi.Text = "Cari Adı:";
            // 
            // lblCariAdiValue
            // 
            this.lblCariAdiValue.Font = new Font("Segoe UI", 10F);
            this.lblCariAdiValue.Location = new Point(130, 50);
            this.lblCariAdiValue.Name = "lblCariAdiValue";
            this.lblCariAdiValue.Size = new Size(370, 25);
            this.lblCariAdiValue.TabIndex = 3;
            this.lblCariAdiValue.Text = "ABC Teknoloji Ltd. Şti.";
            // 
            // lblCariKodu
            // 
            this.lblCariKodu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCariKodu.Location = new Point(20, 15);
            this.lblCariKodu.Name = "lblCariKodu";
            this.lblCariKodu.Size = new Size(100, 25);
            this.lblCariKodu.TabIndex = 0;
            this.lblCariKodu.Text = "Cari Kodu:";
            // 
            // lblCariKoduValue
            // 
            this.lblCariKoduValue.Font = new Font("Segoe UI", 10F);
            this.lblCariKoduValue.Location = new Point(130, 15);
            this.lblCariKoduValue.Name = "lblCariKoduValue";
            this.lblCariKoduValue.Size = new Size(370, 25);
            this.lblCariKoduValue.TabIndex = 1;
            this.lblCariKoduValue.Text = "MUS001";
            // 
            // lblCariTitle
            // 
            this.lblCariTitle.BackColor = Color.FromArgb(99, 102, 241);
            this.lblCariTitle.Dock = DockStyle.Top;
            this.lblCariTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblCariTitle.ForeColor = Color.White;
            this.lblCariTitle.Location = new Point(0, 0);
            this.lblCariTitle.Name = "lblCariTitle";
            this.lblCariTitle.Size = new Size(1358, 40);
            this.lblCariTitle.TabIndex = 0;
            this.lblCariTitle.Text = "📋 ABC Teknoloji Ltd. Şti. (MUS001) - Cari Ekstre";
            this.lblCariTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(30, 41, 59);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(1400, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(1400, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 Cari Ekstre";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CariEkstreForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.ClientSize = new Size(1400, 900);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CariEkstreForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Cari Ekstre";
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.cardGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHareketler)).EndInit();
            this.panelGridButtons.ResumeLayout(false);
            this.cardSummary.ResumeLayout(false);
            this.panelSummaryBoxes.ResumeLayout(false);
            this.boxDonemSonu.ResumeLayout(false);
            this.boxToplamAlacak.ResumeLayout(false);
            this.boxToplamBorc.ResumeLayout(false);
            this.boxDonemBasi.ResumeLayout(false);
            this.cardCariInfo.ResumeLayout(false);
            this.panelCariButtons.ResumeLayout(false);
            this.panelCariDetails.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelContent;
        private Panel cardGrid;
        private DataGridView dataGridViewHareketler;
        private DataGridViewTextBoxColumn colTarih;
        private DataGridViewTextBoxColumn colBelgeTipi;
        private DataGridViewTextBoxColumn colBelgeNo;
        private DataGridViewTextBoxColumn colAciklama;
        private DataGridViewTextBoxColumn colBorc;
        private DataGridViewTextBoxColumn colAlacak;
        private DataGridViewTextBoxColumn colBakiye;
        private Panel panelGridButtons;
        private Button btnCariListesi;
        private Button btnTumHareketler;
        private Button btnCariDetay;
        private Label lblGridTitle;
        private Panel cardSummary;
        private Label lblSummaryTitle;
        private Panel panelSummaryBoxes;
        private Panel boxDonemSonu;
        private Label lblDonemSonuValue;
        private Label lblDonemSonu;
        private Panel boxToplamAlacak;
        private Label lblToplamAlacakValue;
        private Label lblToplamAlacak;
        private Panel boxToplamBorc;
        private Label lblToplamBorcValue;
        private Label lblToplamBorc;
        private Panel boxDonemBasi;
        private Label lblDonemBasiValue;
        private Label lblDonemBasi;
        private Panel cardCariInfo;
        private Panel panelCariButtons;
        private Button btnYazdir;
        private Button btnExcel;
        private Button btnCariDetayTop;
        private Panel panelCariDetails;
        private Label lblDonemSonuBakiye;
        private Label lblDonemSonuBakiyeValue;
        private Label lblDonemBasiBakiye;
        private Label lblDonemBasiBakiyeValue;
        private Label lblCariAdi;
        private Label lblCariAdiValue;
        private Label lblCariKodu;
        private Label lblCariKoduValue;
        private Label lblCariTitle;
        private Panel panelHeader;
        private Label lblTitle;
    }
}


