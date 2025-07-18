namespace MiniERP.WinForms.Forms
{
    partial class StokGuncelleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMain = new Panel();
            this.panelButtons = new Panel();
            this.btnIptal = new Button();
            this.btnKaydet = new Button();
            this.panelContent = new Panel();
            this.dgvStockUpdates = new DataGridView();
            this.colProductName = new DataGridViewTextBoxColumn();
            this.colWarehouse = new DataGridViewTextBoxColumn();
            this.colCurrentStock = new DataGridViewTextBoxColumn();
            this.colUpdateQuantity = new DataGridViewTextBoxColumn();
            this.colNewStock = new DataGridViewTextBoxColumn();
            this.colUpdateType = new DataGridViewTextBoxColumn();
            this.panelAdd = new Panel();
            this.btnCikar = new Button();
            this.btnEkle = new Button();
            this.numMiktar = new NumericUpDown();
            this.lblMiktar = new Label();
            this.lblUrunBilgi = new Label();
            this.lblMevcutStok = new Label();
            this.cmbStockCard = new ComboBox();
            this.lblStokKarti = new Label();
            this.panelHeader = new Panel();
            this.lblBaslik = new Label();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockUpdates)).BeginInit();
            this.panelAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMiktar)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelAdd);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(800, 600);
            this.panelMain.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnIptal);
            this.panelButtons.Controls.Add(this.btnKaydet);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(20, 530);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(760, 50);
            this.panelButtons.TabIndex = 3;
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnIptal.BackColor = Color.FromArgb(107, 114, 128);
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(660, 10);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new Size(90, 35);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnKaydet.BackColor = Color.FromArgb(34, 197, 94);
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = FlatStyle.Flat;
            this.btnKaydet.ForeColor = Color.White;
            this.btnKaydet.Location = new Point(560, 10);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(90, 35);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.dgvStockUpdates);
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Location = new Point(20, 220);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new Size(760, 310);
            this.panelContent.TabIndex = 2;
            // 
            // dgvStockUpdates
            // 
            this.dgvStockUpdates.AllowUserToAddRows = false;
            this.dgvStockUpdates.AllowUserToDeleteRows = false;
            this.dgvStockUpdates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockUpdates.BackgroundColor = Color.White;
            this.dgvStockUpdates.BorderStyle = BorderStyle.None;
            this.dgvStockUpdates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockUpdates.Columns.AddRange(new DataGridViewColumn[] {
            this.colProductName,
            this.colWarehouse,
            this.colCurrentStock,
            this.colUpdateQuantity,
            this.colNewStock,
            this.colUpdateType});
            this.dgvStockUpdates.Dock = DockStyle.Fill;
            this.dgvStockUpdates.Location = new Point(0, 0);
            this.dgvStockUpdates.Name = "dgvStockUpdates";
            this.dgvStockUpdates.ReadOnly = true;
            this.dgvStockUpdates.RowHeadersVisible = false;
            this.dgvStockUpdates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockUpdates.Size = new Size(760, 310);
            this.dgvStockUpdates.TabIndex = 0;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "Ürün";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colWarehouse
            // 
            this.colWarehouse.DataPropertyName = "WarehouseName";
            this.colWarehouse.HeaderText = "Depo";
            this.colWarehouse.Name = "colWarehouse";
            this.colWarehouse.ReadOnly = true;
            // 
            // colCurrentStock
            // 
            this.colCurrentStock.DataPropertyName = "CurrentStock";
            this.colCurrentStock.HeaderText = "Mevcut";
            this.colCurrentStock.Name = "colCurrentStock";
            this.colCurrentStock.ReadOnly = true;
            // 
            // colUpdateQuantity
            // 
            this.colUpdateQuantity.DataPropertyName = "UpdateQuantity";
            this.colUpdateQuantity.HeaderText = "Güncelleme";
            this.colUpdateQuantity.Name = "colUpdateQuantity";
            this.colUpdateQuantity.ReadOnly = true;
            // 
            // colNewStock
            // 
            this.colNewStock.DataPropertyName = "NewStock";
            this.colNewStock.HeaderText = "Yeni Stok";
            this.colNewStock.Name = "colNewStock";
            this.colNewStock.ReadOnly = true;
            // 
            // colUpdateType
            // 
            this.colUpdateType.DataPropertyName = "UpdateType";
            this.colUpdateType.HeaderText = "Tür";
            this.colUpdateType.Name = "colUpdateType";
            this.colUpdateType.ReadOnly = true;
            // 
            // panelAdd
            // 
            this.panelAdd.BackColor = Color.White;
            this.panelAdd.BorderStyle = BorderStyle.FixedSingle;
            this.panelAdd.Controls.Add(this.btnCikar);
            this.panelAdd.Controls.Add(this.btnEkle);
            this.panelAdd.Controls.Add(this.numMiktar);
            this.panelAdd.Controls.Add(this.lblMiktar);
            this.panelAdd.Controls.Add(this.lblUrunBilgi);
            this.panelAdd.Controls.Add(this.lblMevcutStok);
            this.panelAdd.Controls.Add(this.cmbStockCard);
            this.panelAdd.Controls.Add(this.lblStokKarti);
            this.panelAdd.Dock = DockStyle.Top;
            this.panelAdd.Location = new Point(20, 70);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new Size(760, 150);
            this.panelAdd.TabIndex = 1;
            // 
            // btnCikar
            // 
            this.btnCikar.BackColor = Color.FromArgb(239, 68, 68);
            this.btnCikar.FlatAppearance.BorderSize = 0;
            this.btnCikar.FlatStyle = FlatStyle.Flat;
            this.btnCikar.ForeColor = Color.White;
            this.btnCikar.Location = new Point(520, 100);
            this.btnCikar.Name = "btnCikar";
            this.btnCikar.Size = new Size(100, 35);
            this.btnCikar.TabIndex = 7;
            this.btnCikar.Text = "Çıkar";
            this.btnCikar.UseVisualStyleBackColor = false;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = Color.FromArgb(59, 130, 246);
            this.btnEkle.FlatAppearance.BorderSize = 0;
            this.btnEkle.FlatStyle = FlatStyle.Flat;
            this.btnEkle.ForeColor = Color.White;
            this.btnEkle.Location = new Point(410, 100);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new Size(100, 35);
            this.btnEkle.TabIndex = 6;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            // 
            // numMiktar
            // 
            this.numMiktar.DecimalPlaces = 2;
            this.numMiktar.Location = new Point(20, 110);
            this.numMiktar.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numMiktar.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numMiktar.Name = "numMiktar";
            this.numMiktar.Size = new Size(150, 23);
            this.numMiktar.TabIndex = 5;
            this.numMiktar.TextAlign = HorizontalAlignment.Right;
            // 
            // lblMiktar
            // 
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new Point(20, 90);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new Size(120, 15);
            this.lblMiktar.TabIndex = 4;
            this.lblMiktar.Text = "Miktar (+Giriş/-Çıkış):";
            // 
            // lblUrunBilgi
            // 
            this.lblUrunBilgi.BackColor = Color.FromArgb(249, 250, 251);
            this.lblUrunBilgi.BorderStyle = BorderStyle.FixedSingle;
            this.lblUrunBilgi.Location = new Point(220, 60);
            this.lblUrunBilgi.Name = "lblUrunBilgi";
            this.lblUrunBilgi.Size = new Size(300, 23);
            this.lblUrunBilgi.TabIndex = 3;
            this.lblUrunBilgi.Text = "Ürün bilgisi...";
            this.lblUrunBilgi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMevcutStok
            // 
            this.lblMevcutStok.BackColor = Color.FromArgb(249, 250, 251);
            this.lblMevcutStok.BorderStyle = BorderStyle.FixedSingle;
            this.lblMevcutStok.Location = new Point(20, 60);
            this.lblMevcutStok.Name = "lblMevcutStok";
            this.lblMevcutStok.Size = new Size(180, 23);
            this.lblMevcutStok.TabIndex = 2;
            this.lblMevcutStok.Text = "Mevcut stok...";
            this.lblMevcutStok.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbStockCard
            // 
            this.cmbStockCard.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStockCard.FormattingEnabled = true;
            this.cmbStockCard.Location = new Point(20, 30);
            this.cmbStockCard.Name = "cmbStockCard";
            this.cmbStockCard.Size = new Size(500, 23);
            this.cmbStockCard.TabIndex = 1;
            // 
            // lblStokKarti
            // 
            this.lblStokKarti.AutoSize = true;
            this.lblStokKarti.Location = new Point(20, 10);
            this.lblStokKarti.Name = "lblStokKarti";
            this.lblStokKarti.Size = new Size(63, 15);
            this.lblStokKarti.TabIndex = 0;
            this.lblStokKarti.Text = "Stok Kartı:";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(34, 197, 94);
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(20, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(760, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Dock = DockStyle.Fill;
            this.lblBaslik.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.White;
            this.lblBaslik.Location = new Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(760, 50);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "🔧 Stok Güncelle";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StokGuncelleForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(249, 250, 251);
            this.ClientSize = new Size(800, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StokGuncelleForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Stok Güncelle";
            this.panelMain.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockUpdates)).EndInit();
            this.panelAdd.ResumeLayout(false);
            this.panelAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMiktar)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMain;
        private Panel panelButtons;
        private Button btnIptal;
        private Button btnKaydet;
        private Panel panelContent;
        private DataGridView dgvStockUpdates;
        private Panel panelAdd;
        private Button btnCikar;
        private Button btnEkle;
        private NumericUpDown numMiktar;
        private Label lblMiktar;
        private Label lblUrunBilgi;
        private Label lblMevcutStok;
        private ComboBox cmbStockCard;
        private Label lblStokKarti;
        private Panel panelHeader;
        private Label lblBaslik;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colWarehouse;
        private DataGridViewTextBoxColumn colCurrentStock;
        private DataGridViewTextBoxColumn colUpdateQuantity;
        private DataGridViewTextBoxColumn colNewStock;
        private DataGridViewTextBoxColumn colUpdateType;
    }
}


