namespace MiniERP.WinForms.Forms
{
    partial class StokKartiEkleForm
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
            this.lblDurum = new Label();
            this.btnIptal = new Button();
            this.btnKaydet = new Button();
            this.panelForm = new Panel();
            this.groupBoxStokSeviyeleri = new GroupBox();
            this.numMaxStok = new NumericUpDown();
            this.lblMaxStok = new Label();
            this.numMinStok = new NumericUpDown();
            this.lblMinStok = new Label();
            this.groupBoxStokBilgileri = new GroupBox();
            this.numRezerveStok = new NumericUpDown();
            this.lblRezerveStok = new Label();
            this.numMevcutStok = new NumericUpDown();
            this.lblMevcutStok = new Label();
            this.groupBoxUrunBilgileri = new GroupBox();
            this.txtBirim = new TextBox();
            this.lblBirim = new Label();
            this.txtUrunKodu = new TextBox();
            this.lblUrunKodu = new Label();
            this.cmbWarehouse = new ComboBox();
            this.lblDepo = new Label();
            this.cmbProduct = new ComboBox();
            this.lblUrun = new Label();
            this.panelHeader = new Panel();
            this.lblBaslik = new Label();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.groupBoxStokSeviyeleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStok)).BeginInit();
            this.groupBoxStokBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRezerveStok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMevcutStok)).BeginInit();
            this.groupBoxUrunBilgileri.SuspendLayout();
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
            this.panelMain.Size = new Size(500, 600);
            this.panelMain.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.lblDurum);
            this.panelButtons.Controls.Add(this.btnIptal);
            this.panelButtons.Controls.Add(this.btnKaydet);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(20, 530);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(460, 50);
            this.panelButtons.TabIndex = 2;
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new Point(10, 18);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new Size(35, 15);
            this.lblDurum.TabIndex = 2;
            this.lblDurum.Text = "Hazır";
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnIptal.BackColor = Color.FromArgb(107, 114, 128);
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(360, 10);
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
            this.btnKaydet.Location = new Point(260, 10);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(90, 35);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.groupBoxStokSeviyeleri);
            this.panelForm.Controls.Add(this.groupBoxStokBilgileri);
            this.panelForm.Controls.Add(this.groupBoxUrunBilgileri);
            this.panelForm.Dock = DockStyle.Fill;
            this.panelForm.Location = new Point(20, 70);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new Size(460, 460);
            this.panelForm.TabIndex = 1;
            // 
            // groupBoxStokSeviyeleri
            // 
            this.groupBoxStokSeviyeleri.Controls.Add(this.numMaxStok);
            this.groupBoxStokSeviyeleri.Controls.Add(this.lblMaxStok);
            this.groupBoxStokSeviyeleri.Controls.Add(this.numMinStok);
            this.groupBoxStokSeviyeleri.Controls.Add(this.lblMinStok);
            this.groupBoxStokSeviyeleri.Dock = DockStyle.Top;
            this.groupBoxStokSeviyeleri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.groupBoxStokSeviyeleri.Location = new Point(0, 300);
            this.groupBoxStokSeviyeleri.Name = "groupBoxStokSeviyeleri";
            this.groupBoxStokSeviyeleri.Padding = new Padding(15);
            this.groupBoxStokSeviyeleri.Size = new Size(460, 120);
            this.groupBoxStokSeviyeleri.TabIndex = 2;
            this.groupBoxStokSeviyeleri.TabStop = false;
            this.groupBoxStokSeviyeleri.Text = "Stok Seviyeleri";
            // 
            // numMaxStok
            // 
            this.numMaxStok.Font = new Font("Segoe UI", 9F);
            this.numMaxStok.Location = new Point(230, 70);
            this.numMaxStok.Name = "numMaxStok";
            this.numMaxStok.Size = new Size(200, 23);
            this.numMaxStok.TabIndex = 3;
            this.numMaxStok.TextAlign = HorizontalAlignment.Right;
            // 
            // lblMaxStok
            // 
            this.lblMaxStok.AutoSize = true;
            this.lblMaxStok.Font = new Font("Segoe UI", 9F);
            this.lblMaxStok.Location = new Point(230, 50);
            this.lblMaxStok.Name = "lblMaxStok";
            this.lblMaxStok.Size = new Size(119, 15);
            this.lblMaxStok.TabIndex = 2;
            this.lblMaxStok.Text = "Maksimum Stok Seviyesi:";
            // 
            // numMinStok
            // 
            this.numMinStok.Font = new Font("Segoe UI", 9F);
            this.numMinStok.Location = new Point(20, 70);
            this.numMinStok.Name = "numMinStok";
            this.numMinStok.Size = new Size(200, 23);
            this.numMinStok.TabIndex = 1;
            this.numMinStok.TextAlign = HorizontalAlignment.Right;
            // 
            // lblMinStok
            // 
            this.lblMinStok.AutoSize = true;
            this.lblMinStok.Font = new Font("Segoe UI", 9F);
            this.lblMinStok.Location = new Point(20, 50);
            this.lblMinStok.Name = "lblMinStok";
            this.lblMinStok.Size = new Size(113, 15);
            this.lblMinStok.TabIndex = 0;
            this.lblMinStok.Text = "Minimum Stok Seviyesi:";
            // 
            // groupBoxStokBilgileri
            // 
            this.groupBoxStokBilgileri.Controls.Add(this.numRezerveStok);
            this.groupBoxStokBilgileri.Controls.Add(this.lblRezerveStok);
            this.groupBoxStokBilgileri.Controls.Add(this.numMevcutStok);
            this.groupBoxStokBilgileri.Controls.Add(this.lblMevcutStok);
            this.groupBoxStokBilgileri.Dock = DockStyle.Top;
            this.groupBoxStokBilgileri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.groupBoxStokBilgileri.Location = new Point(0, 180);
            this.groupBoxStokBilgileri.Name = "groupBoxStokBilgileri";
            this.groupBoxStokBilgileri.Padding = new Padding(15);
            this.groupBoxStokBilgileri.Size = new Size(460, 120);
            this.groupBoxStokBilgileri.TabIndex = 1;
            this.groupBoxStokBilgileri.TabStop = false;
            this.groupBoxStokBilgileri.Text = "Stok Bilgileri";
            // 
            // numRezerveStok
            // 
            this.numRezerveStok.Font = new Font("Segoe UI", 9F);
            this.numRezerveStok.Location = new Point(230, 70);
            this.numRezerveStok.Name = "numRezerveStok";
            this.numRezerveStok.Size = new Size(200, 23);
            this.numRezerveStok.TabIndex = 3;
            this.numRezerveStok.TextAlign = HorizontalAlignment.Right;
            // 
            // lblRezerveStok
            // 
            this.lblRezerveStok.AutoSize = true;
            this.lblRezerveStok.Font = new Font("Segoe UI", 9F);
            this.lblRezerveStok.Location = new Point(230, 50);
            this.lblRezerveStok.Name = "lblRezerveStok";
            this.lblRezerveStok.Size = new Size(76, 15);
            this.lblRezerveStok.TabIndex = 2;
            this.lblRezerveStok.Text = "Rezerve Stok:";
            // 
            // numMevcutStok
            // 
            this.numMevcutStok.Font = new Font("Segoe UI", 9F);
            this.numMevcutStok.Location = new Point(20, 70);
            this.numMevcutStok.Name = "numMevcutStok";
            this.numMevcutStok.Size = new Size(200, 23);
            this.numMevcutStok.TabIndex = 1;
            this.numMevcutStok.TextAlign = HorizontalAlignment.Right;
            // 
            // lblMevcutStok
            // 
            this.lblMevcutStok.AutoSize = true;
            this.lblMevcutStok.Font = new Font("Segoe UI", 9F);
            this.lblMevcutStok.Location = new Point(20, 50);
            this.lblMevcutStok.Name = "lblMevcutStok";
            this.lblMevcutStok.Size = new Size(77, 15);
            this.lblMevcutStok.TabIndex = 0;
            this.lblMevcutStok.Text = "Mevcut Stok:";
            // 
            // groupBoxUrunBilgileri
            // 
            this.groupBoxUrunBilgileri.Controls.Add(this.txtBirim);
            this.groupBoxUrunBilgileri.Controls.Add(this.lblBirim);
            this.groupBoxUrunBilgileri.Controls.Add(this.txtUrunKodu);
            this.groupBoxUrunBilgileri.Controls.Add(this.lblUrunKodu);
            this.groupBoxUrunBilgileri.Controls.Add(this.cmbWarehouse);
            this.groupBoxUrunBilgileri.Controls.Add(this.lblDepo);
            this.groupBoxUrunBilgileri.Controls.Add(this.cmbProduct);
            this.groupBoxUrunBilgileri.Controls.Add(this.lblUrun);
            this.groupBoxUrunBilgileri.Dock = DockStyle.Top;
            this.groupBoxUrunBilgileri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.groupBoxUrunBilgileri.Location = new Point(0, 0);
            this.groupBoxUrunBilgileri.Name = "groupBoxUrunBilgileri";
            this.groupBoxUrunBilgileri.Padding = new Padding(15);
            this.groupBoxUrunBilgileri.Size = new Size(460, 180);
            this.groupBoxUrunBilgileri.TabIndex = 0;
            this.groupBoxUrunBilgileri.TabStop = false;
            this.groupBoxUrunBilgileri.Text = "Ürün Bilgileri";
            // 
            // txtBirim
            // 
            this.txtBirim.Font = new Font("Segoe UI", 9F);
            this.txtBirim.Location = new Point(230, 140);
            this.txtBirim.Name = "txtBirim";
            this.txtBirim.ReadOnly = true;
            this.txtBirim.Size = new Size(200, 23);
            this.txtBirim.TabIndex = 7;
            // 
            // lblBirim
            // 
            this.lblBirim.AutoSize = true;
            this.lblBirim.Font = new Font("Segoe UI", 9F);
            this.lblBirim.Location = new Point(230, 120);
            this.lblBirim.Name = "lblBirim";
            this.lblBirim.Size = new Size(35, 15);
            this.lblBirim.TabIndex = 6;
            this.lblBirim.Text = "Birim:";
            // 
            // txtUrunKodu
            // 
            this.txtUrunKodu.Font = new Font("Segoe UI", 9F);
            this.txtUrunKodu.Location = new Point(20, 140);
            this.txtUrunKodu.Name = "txtUrunKodu";
            this.txtUrunKodu.ReadOnly = true;
            this.txtUrunKodu.Size = new Size(200, 23);
            this.txtUrunKodu.TabIndex = 5;
            // 
            // lblUrunKodu
            // 
            this.lblUrunKodu.AutoSize = true;
            this.lblUrunKodu.Font = new Font("Segoe UI", 9F);
            this.lblUrunKodu.Location = new Point(20, 120);
            this.lblUrunKodu.Name = "lblUrunKodu";
            this.lblUrunKodu.Size = new Size(68, 15);
            this.lblUrunKodu.TabIndex = 4;
            this.lblUrunKodu.Text = "Ürün Kodu:";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbWarehouse.Font = new Font("Segoe UI", 9F);
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new Point(230, 70);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new Size(200, 23);
            this.cmbWarehouse.TabIndex = 3;
            // 
            // lblDepo
            // 
            this.lblDepo.AutoSize = true;
            this.lblDepo.Font = new Font("Segoe UI", 9F);
            this.lblDepo.Location = new Point(230, 50);
            this.lblDepo.Name = "lblDepo";
            this.lblDepo.Size = new Size(37, 15);
            this.lblDepo.TabIndex = 2;
            this.lblDepo.Text = "Depo:";
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProduct.Font = new Font("Segoe UI", 9F);
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new Point(20, 70);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new Size(200, 23);
            this.cmbProduct.TabIndex = 1;
            // 
            // lblUrun
            // 
            this.lblUrun.AutoSize = true;
            this.lblUrun.Font = new Font("Segoe UI", 9F);
            this.lblUrun.Location = new Point(20, 50);
            this.lblUrun.Name = "lblUrun";
            this.lblUrun.Size = new Size(33, 15);
            this.lblUrun.TabIndex = 0;
            this.lblUrun.Text = "Ürün:";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(59, 130, 246);
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(20, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(460, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Dock = DockStyle.Fill;
            this.lblBaslik.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.White;
            this.lblBaslik.Location = new Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(460, 50);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "➕ Yeni Stok Kartı";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StokKartiEkleForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(249, 250, 251);
            this.ClientSize = new Size(500, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StokKartiEkleForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Yeni Stok Kartı";
            this.panelMain.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.groupBoxStokSeviyeleri.ResumeLayout(false);
            this.groupBoxStokSeviyeleri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStok)).EndInit();
            this.groupBoxStokBilgileri.ResumeLayout(false);
            this.groupBoxStokBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRezerveStok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMevcutStok)).EndInit();
            this.groupBoxUrunBilgileri.ResumeLayout(false);
            this.groupBoxUrunBilgileri.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMain;
        private Panel panelButtons;
        private Label lblDurum;
        private Button btnIptal;
        private Button btnKaydet;
        private Panel panelForm;
        private GroupBox groupBoxStokSeviyeleri;
        private NumericUpDown numMaxStok;
        private Label lblMaxStok;
        private NumericUpDown numMinStok;
        private Label lblMinStok;
        private GroupBox groupBoxStokBilgileri;
        private NumericUpDown numRezerveStok;
        private Label lblRezerveStok;
        private NumericUpDown numMevcutStok;
        private Label lblMevcutStok;
        private GroupBox groupBoxUrunBilgileri;
        private TextBox txtBirim;
        private Label lblBirim;
        private TextBox txtUrunKodu;
        private Label lblUrunKodu;
        private ComboBox cmbWarehouse;
        private Label lblDepo;
        private ComboBox cmbProduct;
        private Label lblUrun;
        private Panel panelHeader;
        private Label lblBaslik;
    }
}