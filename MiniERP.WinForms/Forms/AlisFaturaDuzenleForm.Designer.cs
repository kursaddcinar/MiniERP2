namespace MiniERP.WinForms.Forms
{
    partial class AlisFaturaDuzenleForm
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
            this.dataGridViewKalemler = new System.Windows.Forms.DataGridView();
            this.pnlKalemlerTop = new System.Windows.Forms.Panel();
            this.btnKalemEkle = new System.Windows.Forms.Button();
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
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDurum = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
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
            this.pnlTop.Size = new System.Drawing.Size(1184, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(266, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📝 ALIŞ FATURASI DÜZENLE";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpKalemler);
            this.pnlMain.Controls.Add(this.grpFaturaBilgileri);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMain.Size = new System.Drawing.Size(1184, 540);
            this.pnlMain.TabIndex = 1;
            // 
            // grpKalemler
            // 
            this.grpKalemler.Controls.Add(this.pnlKalemlerBottom);
            this.grpKalemler.Controls.Add(this.dataGridViewKalemler);
            this.grpKalemler.Controls.Add(this.pnlKalemlerTop);
            this.grpKalemler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKalemler.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpKalemler.Location = new System.Drawing.Point(15, 253);
            this.grpKalemler.Name = "grpKalemler";
            this.grpKalemler.Padding = new System.Windows.Forms.Padding(15);
            this.grpKalemler.Size = new System.Drawing.Size(1154, 272);
            this.grpKalemler.TabIndex = 1;
            this.grpKalemler.TabStop = false;
            this.grpKalemler.Text = "Fatura Detayları";
            // 
            // pnlKalemlerBottom
            // 
            this.pnlKalemlerBottom.Controls.Add(this.tableLayoutPanel2);
            this.pnlKalemlerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlKalemlerBottom.Location = new System.Drawing.Point(15, 217);
            this.pnlKalemlerBottom.Name = "pnlKalemlerBottom";
            this.pnlKalemlerBottom.Size = new System.Drawing.Size(1124, 40);
            this.pnlKalemlerBottom.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1124, 40);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(664, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 19);
            this.label13.TabIndex = 0;
            this.label13.Text = "Ara Toplam:";
            // 
            // lblAraToplam
            // 
            this.lblAraToplam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAraToplam.AutoSize = true;
            this.lblAraToplam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAraToplam.Location = new System.Drawing.Point(803, 10);
            this.lblAraToplam.Name = "lblAraToplam";
            this.lblAraToplam.Size = new System.Drawing.Size(44, 19);
            this.lblAraToplam.TabIndex = 1;
            this.lblAraToplam.Text = "₺0.00";
            this.lblAraToplam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(865, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 19);
            this.label15.TabIndex = 2;
            this.label15.Text = "KDV Tutarı:";
            // 
            // lblKdvTutari
            // 
            this.lblKdvTutari.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblKdvTutari.AutoSize = true;
            this.lblKdvTutari.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKdvTutari.Location = new System.Drawing.Point(1003, 10);
            this.lblKdvTutari.Name = "lblKdvTutari";
            this.lblKdvTutari.Size = new System.Drawing.Size(44, 19);
            this.lblKdvTutari.TabIndex = 3;
            this.lblKdvTutari.Text = "₺0.00";
            this.lblKdvTutari.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(1050, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 19);
            this.label17.TabIndex = 4;
            this.label17.Text = "G.Toplam:";
            // 
            // lblGenelToplam
            // 
            this.lblGenelToplam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGenelToplam.AutoSize = true;
            this.lblGenelToplam.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGenelToplam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblGenelToplam.Location = new System.Drawing.Point(1127, 9);
            this.lblGenelToplam.Name = "lblGenelToplam";
            this.lblGenelToplam.Size = new System.Drawing.Size(48, 20);
            this.lblGenelToplam.TabIndex = 5;
            this.lblGenelToplam.Text = "₺0.00";
            this.lblGenelToplam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewKalemler
            // 
            this.dataGridViewKalemler.AllowUserToAddRows = false;
            this.dataGridViewKalemler.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewKalemler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewKalemler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKalemler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewKalemler.Location = new System.Drawing.Point(15, 65);
            this.dataGridViewKalemler.Name = "dataGridViewKalemler";
            this.dataGridViewKalemler.RowHeadersWidth = 51;
            this.dataGridViewKalemler.Size = new System.Drawing.Size(1124, 152);
            this.dataGridViewKalemler.TabIndex = 1;
            // 
            // pnlKalemlerTop
            // 
            this.pnlKalemlerTop.Controls.Add(this.btnKalemEkle);
            this.pnlKalemlerTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKalemlerTop.Location = new System.Drawing.Point(15, 25);
            this.pnlKalemlerTop.Name = "pnlKalemlerTop";
            this.pnlKalemlerTop.Size = new System.Drawing.Size(1124, 40);
            this.pnlKalemlerTop.TabIndex = 0;
            // 
            // btnKalemEkle
            // 
            this.btnKalemEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnKalemEkle.FlatAppearance.BorderSize = 0;
            this.btnKalemEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKalemEkle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnKalemEkle.ForeColor = System.Drawing.Color.White;
            this.btnKalemEkle.Location = new System.Drawing.Point(0, 5);
            this.btnKalemEkle.Name = "btnKalemEkle";
            this.btnKalemEkle.Size = new System.Drawing.Size(120, 30);
            this.btnKalemEkle.TabIndex = 0;
            this.btnKalemEkle.Text = "+ Kalem Ekle";
            this.btnKalemEkle.UseVisualStyleBackColor = false;
            this.btnKalemEkle.Click += new System.EventHandler(this.btnKalemEkle_Click);
            // 
            // grpFaturaBilgileri
            // 
            this.grpFaturaBilgileri.Controls.Add(this.tableLayoutPanel1);
            this.grpFaturaBilgileri.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFaturaBilgileri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpFaturaBilgileri.Location = new System.Drawing.Point(15, 15);
            this.grpFaturaBilgileri.Name = "grpFaturaBilgileri";
            this.grpFaturaBilgileri.Padding = new System.Windows.Forms.Padding(15);
            this.grpFaturaBilgileri.Size = new System.Drawing.Size(1154, 238);
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
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbDurum, 3, 2);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1124, 196);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fatura No:";
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFaturaNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFaturaNo.Location = new System.Drawing.Point(153, 7);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.ReadOnly = true;
            this.txtFaturaNo.Size = new System.Drawing.Size(300, 25);
            this.txtFaturaNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(565, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fatura Tarihi:";
            // 
            // dtpFaturaTarihi
            // 
            this.dtpFaturaTarihi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFaturaTarihi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFaturaTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFaturaTarihi.Location = new System.Drawing.Point(715, 7);
            this.dtpFaturaTarihi.Name = "dtpFaturaTarihi";
            this.dtpFaturaTarihi.Size = new System.Drawing.Size(300, 25);
            this.dtpFaturaTarihi.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
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
            this.dtpVadeTarihi.Size = new System.Drawing.Size(300, 25);
            this.dtpVadeTarihi.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(565, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tedarikçi:";
            // 
            // cmbTedarikci
            // 
            this.cmbTedarikci.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbTedarikci.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTedarikci.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTedarikci.FormattingEnabled = true;
            this.cmbTedarikci.Location = new System.Drawing.Point(715, 47);
            this.cmbTedarikci.Name = "cmbTedarikci";
            this.cmbTedarikci.Size = new System.Drawing.Size(300, 25);
            this.cmbTedarikci.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(3, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 19);
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
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(565, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Durum:";
            // 
            // cmbDurum
            // 
            this.cmbDurum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDurum.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDurum.FormattingEnabled = true;
            this.cmbDurum.Location = new System.Drawing.Point(715, 87);
            this.cmbDurum.Name = "cmbDurum";
            this.cmbDurum.Size = new System.Drawing.Size(300, 25);
            this.cmbDurum.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.Location = new System.Drawing.Point(3, 158);
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
            this.txtAciklama.Size = new System.Drawing.Size(968, 70);
            this.txtAciklama.TabIndex = 11;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnGeri);
            this.pnlBottom.Controls.Add(this.btnGuncelle);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 600);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(15);
            this.pnlBottom.Size = new System.Drawing.Size(1184, 61);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnGeri.FlatAppearance.BorderSize = 0;
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGeri.ForeColor = System.Drawing.Color.White;
            this.btnGeri.Location = new System.Drawing.Point(15, 15);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(100, 35);
            this.btnGeri.TabIndex = 0;
            this.btnGeri.Text = "◀ Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnGuncelle.FlatAppearance.BorderSize = 0;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Location = new System.Drawing.Point(1069, 15);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(100, 35);
            this.btnGuncelle.TabIndex = 1;
            this.btnGuncelle.Text = "💾 Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // AlisFaturaDuzenleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "AlisFaturaDuzenleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alış Faturası Düzenle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.GroupBox grpKalemler;
        private System.Windows.Forms.Panel pnlKalemlerBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblAraToplam;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblKdvTutari;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblGenelToplam;
        private System.Windows.Forms.DataGridView dataGridViewKalemler;
        private System.Windows.Forms.Panel pnlKalemlerTop;
        private System.Windows.Forms.Button btnKalemEkle;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDurum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button btnGuncelle;
    }
}


