namespace MiniERP.WinForms.Forms
{
    partial class UrunlerForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnYeniUrun = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblArama = new System.Windows.Forms.Label();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.lblKategori = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.lblSayfaBoyutu = new System.Windows.Forms.Label();
            this.cmbSayfaBoyutu = new System.Windows.Forms.ComboBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.dataGridViewUrunler = new System.Windows.Forms.DataGridView();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblToplam = new System.Windows.Forms.Label();
            this.lblAktif = new System.Windows.Forms.Label();
            this.lblPasif = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).BeginInit();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.btnYeniUrun);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📦 ÜRÜN YÖNETİMİ";
            // 
            // btnYeniUrun
            // 
            this.btnYeniUrun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYeniUrun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnYeniUrun.FlatAppearance.BorderSize = 0;
            this.btnYeniUrun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniUrun.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYeniUrun.ForeColor = System.Drawing.Color.White;
            this.btnYeniUrun.Location = new System.Drawing.Point(1050, 20);
            this.btnYeniUrun.Name = "btnYeniUrun";
            this.btnYeniUrun.Size = new System.Drawing.Size(130, 40);
            this.btnYeniUrun.TabIndex = 1;
            this.btnYeniUrun.Text = "+ Yeni Ürün";
            this.btnYeniUrun.UseVisualStyleBackColor = false;
            this.btnYeniUrun.Click += new System.EventHandler(this.btnYeniUrun_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelSearch.Controls.Add(this.lblArama);
            this.panelSearch.Controls.Add(this.txtArama);
            this.panelSearch.Controls.Add(this.lblKategori);
            this.panelSearch.Controls.Add(this.cmbKategori);
            this.panelSearch.Controls.Add(this.lblSayfaBoyutu);
            this.panelSearch.Controls.Add(this.cmbSayfaBoyutu);
            this.panelSearch.Controls.Add(this.btnAra);
            this.panelSearch.Controls.Add(this.btnTemizle);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 80);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Padding = new System.Windows.Forms.Padding(20);
            this.panelSearch.Size = new System.Drawing.Size(1200, 80);
            this.panelSearch.TabIndex = 1;
            // 
            // lblArama
            // 
            this.lblArama.AutoSize = true;
            this.lblArama.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblArama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblArama.Location = new System.Drawing.Point(23, 10);
            this.lblArama.Name = "lblArama";
            this.lblArama.Size = new System.Drawing.Size(85, 15);
            this.lblArama.TabIndex = 0;
            this.lblArama.Text = "Ürün Adı/Kodu";
            // 
            // txtArama
            // 
            this.txtArama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArama.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtArama.Location = new System.Drawing.Point(23, 28);
            this.txtArama.Name = "txtArama";
            this.txtArama.PlaceholderText = "Ürün adı veya kodu ara...";
            this.txtArama.Size = new System.Drawing.Size(250, 23);
            this.txtArama.TabIndex = 1;
            this.txtArama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArama_KeyPress);
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKategori.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblKategori.Location = new System.Drawing.Point(293, 10);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(51, 15);
            this.lblKategori.TabIndex = 2;
            this.lblKategori.Text = "Kategori";
            // 
            // cmbKategori
            // 
            this.cmbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategori.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(293, 28);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(180, 23);
            this.cmbKategori.TabIndex = 3;
            this.cmbKategori.SelectedIndexChanged += new System.EventHandler(this.cmbKategori_SelectedIndexChanged);
            // 
            // lblSayfaBoyutu
            // 
            this.lblSayfaBoyutu.AutoSize = true;
            this.lblSayfaBoyutu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSayfaBoyutu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblSayfaBoyutu.Location = new System.Drawing.Point(493, 10);
            this.lblSayfaBoyutu.Name = "lblSayfaBoyutu";
            this.lblSayfaBoyutu.Size = new System.Drawing.Size(73, 15);
            this.lblSayfaBoyutu.TabIndex = 4;
            this.lblSayfaBoyutu.Text = "Sayfa Boyutu";
            // 
            // cmbSayfaBoyutu
            // 
            this.cmbSayfaBoyutu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSayfaBoyutu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSayfaBoyutu.FormattingEnabled = true;
            this.cmbSayfaBoyutu.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "100"});
            this.cmbSayfaBoyutu.Location = new System.Drawing.Point(493, 28);
            this.cmbSayfaBoyutu.Name = "cmbSayfaBoyutu";
            this.cmbSayfaBoyutu.Size = new System.Drawing.Size(100, 23);
            this.cmbSayfaBoyutu.TabIndex = 5;
            this.cmbSayfaBoyutu.SelectedIndexChanged += new System.EventHandler(this.cmbSayfaBoyutu_SelectedIndexChanged);
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAra.FlatAppearance.BorderSize = 0;
            this.btnAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAra.ForeColor = System.Drawing.Color.White;
            this.btnAra.Location = new System.Drawing.Point(613, 26);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(80, 28);
            this.btnAra.TabIndex = 6;
            this.btnAra.Text = "🔍 Ara";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnTemizle.FlatAppearance.BorderSize = 0;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemizle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTemizle.ForeColor = System.Drawing.Color.White;
            this.btnTemizle.Location = new System.Drawing.Point(703, 26);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(80, 28);
            this.btnTemizle.TabIndex = 7;
            this.btnTemizle.Text = "🗑️ Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dataGridViewUrunler);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 160);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1200, 390);
            this.panelMain.TabIndex = 2;
            // 
            // dataGridViewUrunler
            // 
            this.dataGridViewUrunler.AllowUserToAddRows = false;
            this.dataGridViewUrunler.AllowUserToDeleteRows = false;
            this.dataGridViewUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUrunler.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUrunler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUrunler.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewUrunler.MultiSelect = false;
            this.dataGridViewUrunler.Name = "dataGridViewUrunler";
            this.dataGridViewUrunler.ReadOnly = true;
            this.dataGridViewUrunler.RowHeadersVisible = false;
            this.dataGridViewUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUrunler.Size = new System.Drawing.Size(1160, 350);
            this.dataGridViewUrunler.TabIndex = 0;
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelStats.Controls.Add(this.lblToplam);
            this.panelStats.Controls.Add(this.lblAktif);
            this.panelStats.Controls.Add(this.lblPasif);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStats.Location = new System.Drawing.Point(0, 550);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelStats.Size = new System.Drawing.Size(1200, 50);
            this.panelStats.TabIndex = 3;
            // 
            // lblToplam
            // 
            this.lblToplam.AutoSize = true;
            this.lblToplam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblToplam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblToplam.Location = new System.Drawing.Point(23, 17);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(65, 15);
            this.lblToplam.TabIndex = 0;
            this.lblToplam.Text = "Toplam: 0";
            // 
            // lblAktif
            // 
            this.lblAktif.AutoSize = true;
            this.lblAktif.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAktif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblAktif.Location = new System.Drawing.Point(120, 17);
            this.lblAktif.Name = "lblAktif";
            this.lblAktif.Size = new System.Drawing.Size(47, 15);
            this.lblAktif.TabIndex = 1;
            this.lblAktif.Text = "Aktif: 0";
            // 
            // lblPasif
            // 
            this.lblPasif.AutoSize = true;
            this.lblPasif.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPasif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblPasif.Location = new System.Drawing.Point(200, 17);
            this.lblPasif.Name = "lblPasif";
            this.lblPasif.Size = new System.Drawing.Size(47, 15);
            this.lblPasif.TabIndex = 2;
            this.lblPasif.Text = "Pasif: 0";
            // 
            // UrunlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelHeader);
            this.Name = "UrunlerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Yönetimi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UrunlerForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).EndInit();
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnYeniUrun;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblArama;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Label lblSayfaBoyutu;
        private System.Windows.Forms.ComboBox cmbSayfaBoyutu;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dataGridViewUrunler;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblToplam;
        private System.Windows.Forms.Label lblAktif;
        private System.Windows.Forms.Label lblPasif;
    }
}
