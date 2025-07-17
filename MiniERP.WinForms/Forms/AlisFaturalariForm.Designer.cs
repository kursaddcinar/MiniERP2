namespace MiniERP.WinForms.Forms
{
    partial class AlisFaturalariForm
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
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.pnlSummaryCard1 = new System.Windows.Forms.Panel();
            this.lblToplamFatura = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSummaryCard2 = new System.Windows.Forms.Panel();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSummaryCard3 = new System.Windows.Forms.Panel();
            this.lblTaslakFatura = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlSummaryCard4 = new System.Windows.Forms.Panel();
            this.lblOnaylaFatura = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnYeniFatura = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbDurum = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.btnAra = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dataGridViewFaturalar = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlSummaryCard1.SuspendLayout();
            this.pnlSummaryCard2.SuspendLayout();
            this.pnlSummaryCard3.SuspendLayout();
            this.pnlSummaryCard4.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaturalar)).BeginInit();
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
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1176, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📝 ALIŞ FATURALARI";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.pnlSummaryCard4);
            this.pnlSummary.Controls.Add(this.pnlSummaryCard3);
            this.pnlSummary.Controls.Add(this.pnlSummaryCard2);
            this.pnlSummary.Controls.Add(this.pnlSummaryCard1);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(0, 60);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlSummary.Size = new System.Drawing.Size(1200, 120);
            this.pnlSummary.TabIndex = 1;
            // 
            // pnlSummaryCard1
            // 
            this.pnlSummaryCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlSummaryCard1.Controls.Add(this.lblToplamFatura);
            this.pnlSummaryCard1.Controls.Add(this.label1);
            this.pnlSummaryCard1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSummaryCard1.Location = new System.Drawing.Point(20, 15);
            this.pnlSummaryCard1.Name = "pnlSummaryCard1";
            this.pnlSummaryCard1.Padding = new System.Windows.Forms.Padding(15);
            this.pnlSummaryCard1.Size = new System.Drawing.Size(280, 90);
            this.pnlSummaryCard1.TabIndex = 0;
            // 
            // lblToplamFatura
            // 
            this.lblToplamFatura.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblToplamFatura.ForeColor = System.Drawing.Color.White;
            this.lblToplamFatura.Location = new System.Drawing.Point(15, 10);
            this.lblToplamFatura.Name = "lblToplamFatura";
            this.lblToplamFatura.Size = new System.Drawing.Size(100, 40);
            this.lblToplamFatura.TabIndex = 0;
            this.lblToplamFatura.Text = "0";
            this.lblToplamFatura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Toplam Fatura";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSummaryCard2
            // 
            this.pnlSummaryCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnlSummaryCard2.Controls.Add(this.lblToplamTutar);
            this.pnlSummaryCard2.Controls.Add(this.label3);
            this.pnlSummaryCard2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSummaryCard2.Location = new System.Drawing.Point(300, 15);
            this.pnlSummaryCard2.Name = "pnlSummaryCard2";
            this.pnlSummaryCard2.Padding = new System.Windows.Forms.Padding(15);
            this.pnlSummaryCard2.Size = new System.Drawing.Size(280, 90);
            this.pnlSummaryCard2.TabIndex = 1;
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblToplamTutar.ForeColor = System.Drawing.Color.White;
            this.lblToplamTutar.Location = new System.Drawing.Point(15, 10);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(250, 40);
            this.lblToplamTutar.TabIndex = 0;
            this.lblToplamTutar.Text = "₺0,00";
            this.lblToplamTutar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Toplam Tutar";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSummaryCard3
            // 
            this.pnlSummaryCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.pnlSummaryCard3.Controls.Add(this.lblTaslakFatura);
            this.pnlSummaryCard3.Controls.Add(this.label5);
            this.pnlSummaryCard3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSummaryCard3.Location = new System.Drawing.Point(580, 15);
            this.pnlSummaryCard3.Name = "pnlSummaryCard3";
            this.pnlSummaryCard3.Padding = new System.Windows.Forms.Padding(15);
            this.pnlSummaryCard3.Size = new System.Drawing.Size(280, 90);
            this.pnlSummaryCard3.TabIndex = 2;
            // 
            // lblTaslakFatura
            // 
            this.lblTaslakFatura.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTaslakFatura.ForeColor = System.Drawing.Color.White;
            this.lblTaslakFatura.Location = new System.Drawing.Point(15, 10);
            this.lblTaslakFatura.Name = "lblTaslakFatura";
            this.lblTaslakFatura.Size = new System.Drawing.Size(100, 40);
            this.lblTaslakFatura.TabIndex = 0;
            this.lblTaslakFatura.Text = "0";
            this.lblTaslakFatura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Taslak Fatura";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSummaryCard4
            // 
            this.pnlSummaryCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlSummaryCard4.Controls.Add(this.lblOnaylaFatura);
            this.pnlSummaryCard4.Controls.Add(this.label7);
            this.pnlSummaryCard4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSummaryCard4.Location = new System.Drawing.Point(860, 15);
            this.pnlSummaryCard4.Name = "pnlSummaryCard4";
            this.pnlSummaryCard4.Padding = new System.Windows.Forms.Padding(15);
            this.pnlSummaryCard4.Size = new System.Drawing.Size(280, 90);
            this.pnlSummaryCard4.TabIndex = 3;
            // 
            // lblOnaylaFatura
            // 
            this.lblOnaylaFatura.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblOnaylaFatura.ForeColor = System.Drawing.Color.White;
            this.lblOnaylaFatura.Location = new System.Drawing.Point(15, 10);
            this.lblOnaylaFatura.Name = "lblOnaylaFatura";
            this.lblOnaylaFatura.Size = new System.Drawing.Size(100, 40);
            this.lblOnaylaFatura.TabIndex = 0;
            this.lblOnaylaFatura.Text = "0";
            this.lblOnaylaFatura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(15, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "Onaylanmış Fatura";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.White;
            this.pnlFilters.Controls.Add(this.tableLayoutPanel1);
            this.pnlFilters.Controls.Add(this.btnYeniFatura);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 180);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(20);
            this.pnlFilters.Size = new System.Drawing.Size(1200, 150);
            this.pnlFilters.TabIndex = 2;
            // 
            // btnYeniFatura
            // 
            this.btnYeniFatura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnYeniFatura.FlatAppearance.BorderSize = 0;
            this.btnYeniFatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniFatura.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYeniFatura.ForeColor = System.Drawing.Color.White;
            this.btnYeniFatura.Location = new System.Drawing.Point(20, 20);
            this.btnYeniFatura.Name = "btnYeniFatura";
            this.btnYeniFatura.Size = new System.Drawing.Size(200, 40);
            this.btnYeniFatura.TabIndex = 0;
            this.btnYeniFatura.Text = "➕ Yeni Fatura";
            this.btnYeniFatura.UseVisualStyleBackColor = false;
            this.btnYeniFatura.Click += new System.EventHandler(this.btnYeniFatura_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtArama, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbDurum, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpBaslangic, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label11, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpBitis, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAra, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnTemizle, 5, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1160, 60);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Fatura No / Tedarikçi Adı:";
            // 
            // txtArama
            // 
            this.txtArama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArama.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtArama.Location = new System.Drawing.Point(3, 28);
            this.txtArama.Name = "txtArama";
            this.txtArama.PlaceholderText = "Aranacak kelimeyi giriniz...";
            this.txtArama.Size = new System.Drawing.Size(284, 23);
            this.txtArama.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(293, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Durum:";
            // 
            // cmbDurum
            // 
            this.cmbDurum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDurum.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDurum.FormattingEnabled = true;
            this.cmbDurum.Items.AddRange(new object[] {
            "Tümü",
            "Draft",
            "Approved",
            "Cancelled"});
            this.cmbDurum.Location = new System.Drawing.Point(293, 28);
            this.cmbDurum.Name = "cmbDurum";
            this.cmbDurum.Size = new System.Drawing.Size(168, 23);
            this.cmbDurum.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(467, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Başlangıç Tarihi:";
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBaslangic.Checked = false;
            this.dtpBaslangic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBaslangic.Location = new System.Drawing.Point(467, 28);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.ShowCheckBox = true;
            this.dtpBaslangic.Size = new System.Drawing.Size(168, 23);
            this.dtpBaslangic.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(641, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 15);
            this.label11.TabIndex = 6;
            this.label11.Text = "Bitiş Tarihi:";
            // 
            // dtpBitis
            // 
            this.dtpBitis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBitis.Checked = false;
            this.dtpBitis.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBitis.Location = new System.Drawing.Point(641, 28);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.ShowCheckBox = true;
            this.dtpBitis.Size = new System.Drawing.Size(168, 23);
            this.dtpBitis.TabIndex = 7;
            // 
            // btnAra
            // 
            this.btnAra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAra.FlatAppearance.BorderSize = 0;
            this.btnAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAra.ForeColor = System.Drawing.Color.White;
            this.btnAra.Location = new System.Drawing.Point(815, 28);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(168, 29);
            this.btnAra.TabIndex = 8;
            this.btnAra.Text = "🔍 Ara";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnTemizle.FlatAppearance.BorderSize = 0;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemizle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTemizle.ForeColor = System.Drawing.Color.White;
            this.btnTemizle.Location = new System.Drawing.Point(989, 28);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(168, 29);
            this.btnTemizle.TabIndex = 9;
            this.btnTemizle.Text = "🧹 Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.dataGridViewFaturalar);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 330);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(1200, 370);
            this.pnlMain.TabIndex = 3;
            // 
            // dataGridViewFaturalar
            // 
            this.dataGridViewFaturalar.AllowUserToAddRows = false;
            this.dataGridViewFaturalar.AllowUserToDeleteRows = false;
            this.dataGridViewFaturalar.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFaturalar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewFaturalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFaturalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFaturalar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.dataGridViewFaturalar.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewFaturalar.MultiSelect = false;
            this.dataGridViewFaturalar.Name = "dataGridViewFaturalar";
            this.dataGridViewFaturalar.ReadOnly = true;
            this.dataGridViewFaturalar.RowHeadersVisible = false;
            this.dataGridViewFaturalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFaturalar.Size = new System.Drawing.Size(1160, 330);
            this.dataGridViewFaturalar.TabIndex = 0;
            this.dataGridViewFaturalar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFaturalar_CellClick);
            this.dataGridViewFaturalar.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewFaturalar_CellFormatting);
            // 
            // AlisFaturalariForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "AlisFaturalariForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alış Faturaları";
            this.Load += new System.EventHandler(this.AlisFaturalariForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummaryCard1.ResumeLayout(false);
            this.pnlSummaryCard2.ResumeLayout(false);
            this.pnlSummaryCard3.ResumeLayout(false);
            this.pnlSummaryCard4.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaturalar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlTop;
        private Label lblTitle;
        private Panel pnlSummary;
        private Panel pnlSummaryCard4;
        private Label lblOnaylaFatura;
        private Label label7;
        private Panel pnlSummaryCard3;
        private Label lblTaslakFatura;
        private Label label5;
        private Panel pnlSummaryCard2;
        private Label lblToplamTutar;
        private Label label3;
        private Panel pnlSummaryCard1;
        private Label lblToplamFatura;
        private Label label1;
        private Panel pnlFilters;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label8;
        private TextBox txtArama;
        private Label label9;
        private ComboBox cmbDurum;
        private Label label10;
        private DateTimePicker dtpBaslangic;
        private Label label11;
        private DateTimePicker dtpBitis;
        private Button btnAra;
        private Button btnTemizle;
        private Button btnYeniFatura;
        private Panel pnlMain;
        private DataGridView dataGridViewFaturalar;
    }
}
