namespace MiniERP.WinForms.Forms
{
    partial class AlisFaturasiEkleForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpKalemler = new System.Windows.Forms.GroupBox();
            this.pnlKalemlerBottom = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.lblAraToplam = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblKdvTutari = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblGenelToplam = new System.Windows.Forms.Label();
            this.pnlKalemlerTop = new System.Windows.Forms.Panel();
            this.btnKalemEkle = new System.Windows.Forms.Button();
            this.dataGridViewKalemler = new System.Windows.Forms.DataGridView();
            this.grpFaturaBilgileri = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFaturaNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFaturaTarihi = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpVadeTarihi = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTedarikci = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDepo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpKalemler.SuspendLayout();
            this.pnlKalemlerBottom.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlKalemlerTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKalemler)).BeginInit();
            this.grpFaturaBilgileri.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(203, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Yeni Alış Faturası";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpKalemler);
            this.pnlMain.Controls.Add(this.grpFaturaBilgileri);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(1200, 640);
            this.pnlMain.TabIndex = 1;
            // 
            // grpKalemler
            // 
            this.grpKalemler.Controls.Add(this.pnlKalemlerBottom);
            this.grpKalemler.Controls.Add(this.pnlKalemlerTop);
            this.grpKalemler.Controls.Add(this.dataGridViewKalemler);
            this.grpKalemler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKalemler.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpKalemler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpKalemler.Location = new System.Drawing.Point(20, 240);
            this.grpKalemler.Name = "grpKalemler";
            this.grpKalemler.Padding = new System.Windows.Forms.Padding(15);
            this.grpKalemler.Size = new System.Drawing.Size(1160, 380);
            this.grpKalemler.TabIndex = 1;
            this.grpKalemler.TabStop = false;
            this.grpKalemler.Text = "Fatura Kalemleri";
            // 
            // pnlKalemlerBottom
            // 
            this.pnlKalemlerBottom.Controls.Add(this.tableLayoutPanel2);
            this.pnlKalemlerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlKalemlerBottom.Location = new System.Drawing.Point(15, 315);
            this.pnlKalemlerBottom.Name = "pnlKalemlerBottom";
            this.pnlKalemlerBottom.Size = new System.Drawing.Size(1130, 50);
            this.pnlKalemlerBottom.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.Controls.Add(this.label13, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblAraToplam, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label15, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblKdvTutari, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label17, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblGenelToplam, 6, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1130, 50);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label13.Location = new System.Drawing.Point(682, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 19);
            this.label13.TabIndex = 0;
            this.label13.Text = "Ara Toplam:";
            // 
            // lblAraToplam
            // 
            this.lblAraToplam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAraToplam.AutoSize = true;
            this.lblAraToplam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAraToplam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblAraToplam.Location = new System.Drawing.Point(778, 15);
            this.lblAraToplam.Name = "lblAraToplam";
            this.lblAraToplam.Size = new System.Drawing.Size(39, 19);
            this.lblAraToplam.TabIndex = 1;
            this.lblAraToplam.Text = "0,00";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label15.Location = new System.Drawing.Point(827, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 19);
            this.label15.TabIndex = 2;
            this.label15.Text = "KDV:";
            // 
            // lblKdvTutari
            // 
            this.lblKdvTutari.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblKdvTutari.AutoSize = true;
            this.lblKdvTutari.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKdvTutari.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblKdvTutari.Location = new System.Drawing.Point(958, 15);
            this.lblKdvTutari.Name = "lblKdvTutari";
            this.lblKdvTutari.Size = new System.Drawing.Size(39, 19);
            this.lblKdvTutari.TabIndex = 3;
            this.lblKdvTutari.Text = "0,00";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label17.Location = new System.Drawing.Point(1007, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 19);
            this.label17.TabIndex = 4;
            this.label17.Text = "Toplam:";
            // 
            // lblGenelToplam
            // 
            this.lblGenelToplam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGenelToplam.AutoSize = true;
            this.lblGenelToplam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGenelToplam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblGenelToplam.Location = new System.Drawing.Point(1083, 14);
            this.lblGenelToplam.Name = "lblGenelToplam";
            this.lblGenelToplam.Size = new System.Drawing.Size(44, 21);
            this.lblGenelToplam.TabIndex = 5;
            this.lblGenelToplam.Text = "0,00";
            // 
            // pnlKalemlerTop
            // 
            this.pnlKalemlerTop.Controls.Add(this.btnKalemEkle);
            this.pnlKalemlerTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKalemlerTop.Location = new System.Drawing.Point(15, 27);
            this.pnlKalemlerTop.Name = "pnlKalemlerTop";
            this.pnlKalemlerTop.Size = new System.Drawing.Size(1130, 40);
            this.pnlKalemlerTop.TabIndex = 1;
            // 
            // btnKalemEkle
            // 
            this.btnKalemEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnKalemEkle.FlatAppearance.BorderSize = 0;
            this.btnKalemEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKalemEkle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKalemEkle.ForeColor = System.Drawing.Color.White;
            this.btnKalemEkle.Location = new System.Drawing.Point(0, 5);
            this.btnKalemEkle.Name = "btnKalemEkle";
            this.btnKalemEkle.Size = new System.Drawing.Size(120, 35);
            this.btnKalemEkle.TabIndex = 0;
            this.btnKalemEkle.Text = "Kalem Ekle";
            this.btnKalemEkle.UseVisualStyleBackColor = false;
            this.btnKalemEkle.Click += new System.EventHandler(this.btnKalemEkle_Click);
            // 
            // dataGridViewKalemler
            // 
            this.dataGridViewKalemler.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewKalemler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewKalemler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKalemler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewKalemler.Location = new System.Drawing.Point(15, 67);
            this.dataGridViewKalemler.Name = "dataGridViewKalemler";
            this.dataGridViewKalemler.Size = new System.Drawing.Size(1130, 248);
            this.dataGridViewKalemler.TabIndex = 0;
            // 
            // grpFaturaBilgileri
            // 
            this.grpFaturaBilgileri.Controls.Add(this.tableLayoutPanel1);
            this.grpFaturaBilgileri.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFaturaBilgileri.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpFaturaBilgileri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpFaturaBilgileri.Location = new System.Drawing.Point(20, 20);
            this.grpFaturaBilgileri.Name = "grpFaturaBilgileri";
            this.grpFaturaBilgileri.Padding = new System.Windows.Forms.Padding(15);
            this.grpFaturaBilgileri.Size = new System.Drawing.Size(1160, 220);
            this.grpFaturaBilgileri.TabIndex = 0;
            this.grpFaturaBilgileri.TabStop = false;
            this.grpFaturaBilgileri.Text = "Fatura Bilgileri";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFaturaNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpFaturaTarihi, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpVadeTarihi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbTedarikci, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbDepo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.SetColumnSpan(this.txtAciklama, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtAciklama, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1130, 178);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fatura No:";
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFaturaNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFaturaNo.Location = new System.Drawing.Point(153, 7);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.Size = new System.Drawing.Size(200, 25);
            this.txtFaturaNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(568, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fatura Tarihi:";
            // 
            // dtpFaturaTarihi
            // 
            this.dtpFaturaTarihi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFaturaTarihi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFaturaTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFaturaTarihi.Location = new System.Drawing.Point(721, 7);
            this.dtpFaturaTarihi.Name = "dtpFaturaTarihi";
            this.dtpFaturaTarihi.Size = new System.Drawing.Size(200, 25);
            this.dtpFaturaTarihi.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vade Tarihi:";
            // 
            // dtpVadeTarihi
            // 
            this.dtpVadeTarihi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpVadeTarihi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpVadeTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVadeTarihi.Location = new System.Drawing.Point(153, 47);
            this.dtpVadeTarihi.Name = "dtpVadeTarihi";
            this.dtpVadeTarihi.Size = new System.Drawing.Size(200, 25);
            this.dtpVadeTarihi.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(568, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tedarikçi:";
            // 
            // cmbTedarikci
            // 
            this.cmbTedarikci.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbTedarikci.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTedarikci.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTedarikci.FormattingEnabled = true;
            this.cmbTedarikci.Location = new System.Drawing.Point(721, 47);
            this.cmbTedarikci.Name = "cmbTedarikci";
            this.cmbTedarikci.Size = new System.Drawing.Size(300, 25);
            this.cmbTedarikci.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label5.Location = new System.Drawing.Point(3, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Depo:";
            // 
            // cmbDepo
            // 
            this.cmbDepo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbDepo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDepo.FormattingEnabled = true;
            this.cmbDepo.Location = new System.Drawing.Point(153, 87);
            this.cmbDepo.Name = "cmbDepo";
            this.cmbDepo.Size = new System.Drawing.Size(300, 25);
            this.cmbDepo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label6.Location = new System.Drawing.Point(3, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Açıklama:";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtAciklama, 3);
            this.txtAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAciklama.Location = new System.Drawing.Point(153, 123);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAciklama.Size = new System.Drawing.Size(974, 52);
            this.txtAciklama.TabIndex = 11;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnIptal);
            this.pnlBottom.Controls.Add(this.btnKaydet);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 700);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBottom.Size = new System.Drawing.Size(1200, 80);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(950, 20);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(120, 40);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(1080, 20);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(120, 40);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // AlisFaturasiEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 780);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlisFaturasiEkleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Alış Faturası";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.grpKalemler.ResumeLayout(false);
            this.pnlKalemlerBottom.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnlKalemlerTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKalemler)).EndInit();
            this.grpFaturaBilgileri.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpFaturaBilgileri;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFaturaNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFaturaTarihi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpVadeTarihi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTedarikci;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDepo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.GroupBox grpKalemler;
        private System.Windows.Forms.DataGridView dataGridViewKalemler;
        private System.Windows.Forms.Panel pnlKalemlerTop;
        private System.Windows.Forms.Button btnKalemEkle;
        private System.Windows.Forms.Panel pnlKalemlerBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblAraToplam;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblKdvTutari;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblGenelToplam;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnKaydet;
    }
}


