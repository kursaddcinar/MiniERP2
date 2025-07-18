namespace MiniERP.WinForms.Forms
{
    partial class SatisFaturasiEkleForm
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnIptal = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDetaylar = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAraToplam = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblKDV = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblGenelToplam = new System.Windows.Forms.Label();
            this.pnlDetayGrid = new System.Windows.Forms.Panel();
            this.dataGridViewDetaylar = new System.Windows.Forms.DataGridView();
            this.pnlDetayButtons = new System.Windows.Forms.Panel();
            this.btnSatirEkle = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlBilgiler = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFaturaNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFaturaTarihi = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpVadeTarihi = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDepo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlDetaylar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlDetayGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetaylar)).BeginInit();
            this.pnlDetayButtons.SuspendLayout();
            this.pnlBilgiler.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlTop.Controls.Add(this.btnIptal);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(1120, 12);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(68, 35);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "← Geri";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1100, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📄 YENİ SATIŞ FATURASI";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlDetaylar);
            this.pnlMain.Controls.Add(this.pnlBilgiler);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(1200, 590);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlDetaylar
            // 
            this.pnlDetaylar.Controls.Add(this.groupBox2);
            this.pnlDetaylar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetaylar.Location = new System.Drawing.Point(20, 220);
            this.pnlDetaylar.Name = "pnlDetaylar";
            this.pnlDetaylar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlDetaylar.Size = new System.Drawing.Size(1160, 350);
            this.pnlDetaylar.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Controls.Add(this.pnlDetayGrid);
            this.groupBox2.Controls.Add(this.pnlDetayButtons);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.groupBox2.Location = new System.Drawing.Point(0, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(15);
            this.groupBox2.Size = new System.Drawing.Size(1160, 340);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fatura Detayları";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblAraToplam, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label13, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblKDV, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label15, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblGenelToplam, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(15, 250);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1130, 45);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // lblAraToplam
            // 
            this.lblAraToplam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblAraToplam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAraToplam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAraToplam.Location = new System.Drawing.Point(498, 0);
            this.lblAraToplam.Name = "lblAraToplam";
            this.lblAraToplam.Size = new System.Drawing.Size(114, 30);
            this.lblAraToplam.TabIndex = 0;
            this.lblAraToplam.Text = "₺0,00";
            this.lblAraToplam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.Location = new System.Drawing.Point(398, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 30);
            this.label12.TabIndex = 1;
            this.label12.Text = "Ara Toplam:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label13.Location = new System.Drawing.Point(618, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 30);
            this.label13.TabIndex = 2;
            this.label13.Text = "KDV:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKDV
            // 
            this.lblKDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblKDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKDV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKDV.Location = new System.Drawing.Point(718, 0);
            this.lblKDV.Name = "lblKDV";
            this.lblKDV.Size = new System.Drawing.Size(114, 30);
            this.lblKDV.TabIndex = 3;
            this.lblKDV.Text = "₺0,00";
            this.lblKDV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.label15.Location = new System.Drawing.Point(398, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 15);
            this.label15.TabIndex = 4;
            this.label15.Text = "Genel Toplam:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGenelToplam
            // 
            this.lblGenelToplam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.tableLayoutPanel2.SetColumnSpan(this.lblGenelToplam, 3);
            this.lblGenelToplam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGenelToplam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGenelToplam.ForeColor = System.Drawing.Color.White;
            this.lblGenelToplam.Location = new System.Drawing.Point(498, 30);
            this.lblGenelToplam.Name = "lblGenelToplam";
            this.lblGenelToplam.Size = new System.Drawing.Size(334, 15);
            this.lblGenelToplam.TabIndex = 5;
            this.lblGenelToplam.Text = "₺0,00";
            this.lblGenelToplam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlDetayGrid
            // 
            this.pnlDetayGrid.Controls.Add(this.dataGridViewDetaylar);
            this.pnlDetayGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetayGrid.Location = new System.Drawing.Point(15, 65);
            this.pnlDetayGrid.Name = "pnlDetayGrid";
            this.pnlDetayGrid.Size = new System.Drawing.Size(1130, 215);
            this.pnlDetayGrid.TabIndex = 1;
            // 
            // dataGridViewDetaylar
            // 
            this.dataGridViewDetaylar.AllowUserToAddRows = false;
            this.dataGridViewDetaylar.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDetaylar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDetaylar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetaylar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetaylar.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDetaylar.Name = "dataGridViewDetaylar";
            this.dataGridViewDetaylar.RowHeadersWidth = 51;
            this.dataGridViewDetaylar.Size = new System.Drawing.Size(1130, 185);
            this.dataGridViewDetaylar.TabIndex = 0;
            this.dataGridViewDetaylar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetaylar_CellClick);
            this.dataGridViewDetaylar.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetaylar_CellValueChanged);
            // 
            // pnlDetayButtons
            // 
            this.pnlDetayButtons.Controls.Add(this.btnSatirEkle);
            this.pnlDetayButtons.Controls.Add(this.label11);
            this.pnlDetayButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetayButtons.Location = new System.Drawing.Point(15, 30);
            this.pnlDetayButtons.Name = "pnlDetayButtons";
            this.pnlDetayButtons.Size = new System.Drawing.Size(1130, 35);
            this.pnlDetayButtons.TabIndex = 0;
            // 
            // btnSatirEkle
            // 
            this.btnSatirEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSatirEkle.FlatAppearance.BorderSize = 0;
            this.btnSatirEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatirEkle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSatirEkle.ForeColor = System.Drawing.Color.White;
            this.btnSatirEkle.Location = new System.Drawing.Point(0, 0);
            this.btnSatirEkle.Name = "btnSatirEkle";
            this.btnSatirEkle.Size = new System.Drawing.Size(150, 35);
            this.btnSatirEkle.TabIndex = 0;
            this.btnSatirEkle.Text = "+ Satır Ekle";
            this.btnSatirEkle.UseVisualStyleBackColor = false;
            this.btnSatirEkle.Click += new System.EventHandler(this.btnSatirEkle_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.label11.Location = new System.Drawing.Point(156, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(423, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "Ürün seçtikten sonra fiyat ve KDV bilgileri otomatik olarak yüklenecektir.";
            // 
            // pnlBilgiler
            // 
            this.pnlBilgiler.Controls.Add(this.groupBox1);
            this.pnlBilgiler.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBilgiler.Location = new System.Drawing.Point(20, 20);
            this.pnlBilgiler.Name = "pnlBilgiler";
            this.pnlBilgiler.Size = new System.Drawing.Size(1160, 200);
            this.pnlBilgiler.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(15);
            this.groupBox1.Size = new System.Drawing.Size(1160, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fatura Bilgileri";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFaturaNo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbMusteri, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpFaturaTarihi, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpVadeTarihi, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbDepo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAciklama, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1130, 155);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fatura No";
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFaturaNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFaturaNo.Location = new System.Drawing.Point(3, 28);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.ReadOnly = true;
            this.txtFaturaNo.Size = new System.Drawing.Size(276, 25);
            this.txtFaturaNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(285, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Müşteri";
            // 
            // cmbMusteri
            // 
            this.cmbMusteri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMusteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusteri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMusteri.FormattingEnabled = true;
            this.cmbMusteri.Location = new System.Drawing.Point(285, 28);
            this.cmbMusteri.Name = "cmbMusteri";
            this.cmbMusteri.Size = new System.Drawing.Size(276, 25);
            this.cmbMusteri.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(567, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fatura Tarihi";
            // 
            // dtpFaturaTarihi
            // 
            this.dtpFaturaTarihi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFaturaTarihi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFaturaTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFaturaTarihi.Location = new System.Drawing.Point(567, 28);
            this.dtpFaturaTarihi.Name = "dtpFaturaTarihi";
            this.dtpFaturaTarihi.Size = new System.Drawing.Size(276, 25);
            this.dtpFaturaTarihi.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(849, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vade Tarihi";
            // 
            // dtpVadeTarihi
            // 
            this.dtpVadeTarihi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpVadeTarihi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpVadeTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVadeTarihi.Location = new System.Drawing.Point(849, 28);
            this.dtpVadeTarihi.Name = "dtpVadeTarihi";
            this.dtpVadeTarihi.Size = new System.Drawing.Size(278, 25);
            this.dtpVadeTarihi.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(3, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Depo";
            // 
            // cmbDepo
            // 
            this.cmbDepo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDepo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDepo.FormattingEnabled = true;
            this.cmbDepo.Location = new System.Drawing.Point(3, 88);
            this.cmbDepo.Name = "cmbDepo";
            this.cmbDepo.Size = new System.Drawing.Size(276, 25);
            this.cmbDepo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(285, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtAciklama, 3);
            this.txtAciklama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAciklama.Location = new System.Drawing.Point(285, 88);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.PlaceholderText = "Fatura ile ilgili açıklama...";
            this.txtAciklama.Size = new System.Drawing.Size(842, 64);
            this.txtAciklama.TabIndex = 11;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnKaydet);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 650);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBottom.Size = new System.Drawing.Size(1200, 70);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(1040, 20);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(140, 40);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "💾 Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // SatisFaturasiEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "SatisFaturasiEkleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Satış Faturası";
            this.Load += new System.EventHandler(this.SatisFaturasiEkleForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlDetaylar.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnlDetayGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetaylar)).EndInit();
            this.pnlDetayButtons.ResumeLayout(false);
            this.pnlDetayButtons.PerformLayout();
            this.pnlBilgiler.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlTop;
        private Button btnIptal;
        private Label lblTitle;
        private Panel pnlMain;
        private Panel pnlDetaylar;
        private GroupBox groupBox2;
        private Panel pnlDetayGrid;
        private DataGridView dataGridViewDetaylar;
        private Panel pnlDetayButtons;
        private Button btnSatirEkle;
        private Label label11;
        private Panel pnlBilgiler;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox txtFaturaNo;
        private Label label2;
        private ComboBox cmbMusteri;
        private Label label3;
        private DateTimePicker dtpFaturaTarihi;
        private Label label4;
        private DateTimePicker dtpVadeTarihi;
        private Label label5;
        private ComboBox cmbDepo;
        private Label label6;
        private TextBox txtAciklama;
        private Panel pnlBottom;
        private Button btnKaydet;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblAraToplam;
        private Label label12;
        private Label label13;
        private Label lblKDV;
        private Label label15;
        private Label lblGenelToplam;
    }
}


