namespace MiniERP.WinForms.Forms
{
    partial class StokKartiEkleFormNew
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
            this.panelContent = new Panel();
            this.panelCard3 = new Panel();
            this.lblIpuclariBaslik = new Label();
            this.lblIpucu1 = new Label();
            this.lblIpucu2 = new Label();
            this.lblIpucu3 = new Label();
            this.panelCard2 = new Panel();
            this.lblBilgilendirmeBaslik = new Label();
            this.lblBilgiUrun = new Label();
            this.lblBilgiDepo = new Label();
            this.lblBilgiMevcutStok = new Label();
            this.lblBilgiRezerve = new Label();
            this.panelCard1 = new Panel();
            this.panelButtons = new Panel();
            this.btnKaydet = new Button();
            this.btnIptal = new Button();
            this.panelForm = new Panel();
            this.lblRezerveStok = new Label();
            this.numRezerveStok = new NumericUpDown();
            this.lblMevcutStok = new Label();
            this.numMevcutStok = new NumericUpDown();
            this.lblDepo = new Label();
            this.cmbDepo = new ComboBox();
            this.lblUrun = new Label();
            this.cmbUrun = new ComboBox();
            this.panelHeader = new Panel();
            this.lblBaslik = new Label();
            this.lblDurum = new Label();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelCard3.SuspendLayout();
            this.panelCard2.SuspendLayout();
            this.panelCard1.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRezerveStok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMevcutStok)).BeginInit();
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
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(800, 600);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelCard3);
            this.panelContent.Controls.Add(this.panelCard2);
            this.panelContent.Controls.Add(this.panelCard1);
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Location = new Point(20, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new Size(760, 500);
            this.panelContent.TabIndex = 1;
            // 
            // panelCard3
            // 
            this.panelCard3.BackColor = Color.FromArgb(240, 253, 244);
            this.panelCard3.BorderStyle = BorderStyle.FixedSingle;
            this.panelCard3.Controls.Add(this.lblIpuclariBaslik);
            this.panelCard3.Controls.Add(this.lblIpucu1);
            this.panelCard3.Controls.Add(this.lblIpucu2);
            this.panelCard3.Controls.Add(this.lblIpucu3);
            this.panelCard3.Location = new Point(510, 10);
            this.panelCard3.Name = "panelCard3";
            this.panelCard3.Padding = new Padding(15);
            this.panelCard3.Size = new Size(240, 380);
            this.panelCard3.TabIndex = 2;
            // 
            // lblIpuclariBaslik
            // 
            this.lblIpuclariBaslik.AutoSize = true;
            this.lblIpuclariBaslik.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblIpuclariBaslik.ForeColor = Color.FromArgb(22, 101, 52);
            this.lblIpuclariBaslik.Location = new Point(15, 15);
            this.lblIpuclariBaslik.Name = "lblIpuclariBaslik";
            this.lblIpuclariBaslik.Size = new Size(69, 21);
            this.lblIpuclariBaslik.TabIndex = 0;
            this.lblIpuclariBaslik.Text = "💡 İpuçları";
            // 
            // lblIpucu1
            // 
            this.lblIpucu1.Font = new Font("Segoe UI", 9F);
            this.lblIpucu1.ForeColor = Color.FromArgb(22, 101, 52);
            this.lblIpucu1.Location = new Point(15, 50);
            this.lblIpucu1.Name = "lblIpucu1";
            this.lblIpucu1.Size = new Size(200, 40);
            this.lblIpucu1.TabIndex = 1;
            this.lblIpucu1.Text = "✓ Ürün ve depo seçimi zorunludur";
            // 
            // lblIpucu2
            // 
            this.lblIpucu2.Font = new Font("Segoe UI", 9F);
            this.lblIpucu2.ForeColor = Color.FromArgb(22, 101, 52);
            this.lblIpucu2.Location = new Point(15, 100);
            this.lblIpucu2.Name = "lblIpucu2";
            this.lblIpucu2.Size = new Size(200, 40);
            this.lblIpucu2.TabIndex = 2;
            this.lblIpucu2.Text = "✓ Başlangıç stok 0 olabilir";
            // 
            // lblIpucu3
            // 
            this.lblIpucu3.Font = new Font("Segoe UI", 9F);
            this.lblIpucu3.ForeColor = Color.FromArgb(22, 101, 52);
            this.lblIpucu3.Location = new Point(15, 150);
            this.lblIpucu3.Name = "lblIpucu3";
            this.lblIpucu3.Size = new Size(200, 40);
            this.lblIpucu3.TabIndex = 3;
            this.lblIpucu3.Text = "✓ Stok sonradan güncellenebilir";
            // 
            // panelCard2
            // 
            this.panelCard2.BackColor = Color.FromArgb(239, 246, 255);
            this.panelCard2.BorderStyle = BorderStyle.FixedSingle;
            this.panelCard2.Controls.Add(this.lblBilgilendirmeBaslik);
            this.panelCard2.Controls.Add(this.lblBilgiUrun);
            this.panelCard2.Controls.Add(this.lblBilgiDepo);
            this.panelCard2.Controls.Add(this.lblBilgiMevcutStok);
            this.panelCard2.Controls.Add(this.lblBilgiRezerve);
            this.panelCard2.Location = new Point(260, 10);
            this.panelCard2.Name = "panelCard2";
            this.panelCard2.Padding = new Padding(15);
            this.panelCard2.Size = new Size(240, 380);
            this.panelCard2.TabIndex = 1;
            // 
            // lblBilgilendirmeBaslik
            // 
            this.lblBilgilendirmeBaslik.AutoSize = true;
            this.lblBilgilendirmeBaslik.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblBilgilendirmeBaslik.ForeColor = Color.FromArgb(30, 64, 175);
            this.lblBilgilendirmeBaslik.Location = new Point(15, 15);
            this.lblBilgilendirmeBaslik.Name = "lblBilgilendirmeBaslik";
            this.lblBilgilendirmeBaslik.Size = new Size(110, 21);
            this.lblBilgilendirmeBaslik.TabIndex = 0;
            this.lblBilgilendirmeBaslik.Text = "ℹ️ Bilgilendirme";
            // 
            // lblBilgiUrun
            // 
            this.lblBilgiUrun.Font = new Font("Segoe UI", 9F);
            this.lblBilgiUrun.ForeColor = Color.FromArgb(30, 64, 175);
            this.lblBilgiUrun.Location = new Point(15, 50);
            this.lblBilgiUrun.Name = "lblBilgiUrun";
            this.lblBilgiUrun.Size = new Size(200, 50);
            this.lblBilgiUrun.TabIndex = 1;
            this.lblBilgiUrun.Text = "📦 Ürün: Stok takibi yapılacak ürün";
            // 
            // lblBilgiDepo
            // 
            this.lblBilgiDepo.Font = new Font("Segoe UI", 9F);
            this.lblBilgiDepo.ForeColor = Color.FromArgb(30, 64, 175);
            this.lblBilgiDepo.Location = new Point(15, 110);
            this.lblBilgiDepo.Name = "lblBilgiDepo";
            this.lblBilgiDepo.Size = new Size(200, 50);
            this.lblBilgiDepo.TabIndex = 2;
            this.lblBilgiDepo.Text = "🏪 Depo: Ürünün bulunduğu depo";
            // 
            // lblBilgiMevcutStok
            // 
            this.lblBilgiMevcutStok.Font = new Font("Segoe UI", 9F);
            this.lblBilgiMevcutStok.ForeColor = Color.FromArgb(30, 64, 175);
            this.lblBilgiMevcutStok.Location = new Point(15, 170);
            this.lblBilgiMevcutStok.Name = "lblBilgiMevcutStok";
            this.lblBilgiMevcutStok.Size = new Size(200, 50);
            this.lblBilgiMevcutStok.TabIndex = 3;
            this.lblBilgiMevcutStok.Text = "📊 Mevcut Stok: Depodaki toplam miktar";
            // 
            // lblBilgiRezerve
            // 
            this.lblBilgiRezerve.Font = new Font("Segoe UI", 9F);
            this.lblBilgiRezerve.ForeColor = Color.FromArgb(30, 64, 175);
            this.lblBilgiRezerve.Location = new Point(15, 230);
            this.lblBilgiRezerve.Name = "lblBilgiRezerve";
            this.lblBilgiRezerve.Size = new Size(200, 50);
            this.lblBilgiRezerve.TabIndex = 4;
            this.lblBilgiRezerve.Text = "🔒 Rezerve Stok: Satışa ayrılmış miktar";
            // 
            // panelCard1
            // 
            this.panelCard1.BackColor = Color.White;
            this.panelCard1.BorderStyle = BorderStyle.FixedSingle;
            this.panelCard1.Controls.Add(this.panelButtons);
            this.panelCard1.Controls.Add(this.panelForm);
            this.panelCard1.Location = new Point(10, 10);
            this.panelCard1.Name = "panelCard1";
            this.panelCard1.Size = new Size(240, 380);
            this.panelCard1.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnKaydet);
            this.panelButtons.Controls.Add(this.btnIptal);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(0, 320);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new Padding(15, 10, 15, 15);
            this.panelButtons.Size = new Size(238, 58);
            this.panelButtons.TabIndex = 1;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = Color.FromArgb(34, 197, 94);
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = FlatStyle.Flat;
            this.btnKaydet.ForeColor = Color.White;
            this.btnKaydet.Location = new Point(15, 10);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(80, 32);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "💾 Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = Color.FromArgb(107, 114, 128);
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(105, 10);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new Size(80, 32);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "❌ İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.lblRezerveStok);
            this.panelForm.Controls.Add(this.numRezerveStok);
            this.panelForm.Controls.Add(this.lblMevcutStok);
            this.panelForm.Controls.Add(this.numMevcutStok);
            this.panelForm.Controls.Add(this.lblDepo);
            this.panelForm.Controls.Add(this.cmbDepo);
            this.panelForm.Controls.Add(this.lblUrun);
            this.panelForm.Controls.Add(this.cmbUrun);
            this.panelForm.Dock = DockStyle.Fill;
            this.panelForm.Location = new Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new Padding(15);
            this.panelForm.Size = new Size(238, 320);
            this.panelForm.TabIndex = 0;
            // 
            // lblRezerveStok
            // 
            this.lblRezerveStok.AutoSize = true;
            this.lblRezerveStok.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblRezerveStok.Location = new Point(15, 230);
            this.lblRezerveStok.Name = "lblRezerveStok";
            this.lblRezerveStok.Size = new Size(82, 15);
            this.lblRezerveStok.TabIndex = 6;
            this.lblRezerveStok.Text = "Rezerve Stok *";
            // 
            // numRezerveStok
            // 
            this.numRezerveStok.DecimalPlaces = 2;
            this.numRezerveStok.Location = new Point(15, 250);
            this.numRezerveStok.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.numRezerveStok.Name = "numRezerveStok";
            this.numRezerveStok.Size = new Size(200, 23);
            this.numRezerveStok.TabIndex = 7;
            // 
            // lblMevcutStok
            // 
            this.lblMevcutStok.AutoSize = true;
            this.lblMevcutStok.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblMevcutStok.Location = new Point(15, 160);
            this.lblMevcutStok.Name = "lblMevcutStok";
            this.lblMevcutStok.Size = new Size(81, 15);
            this.lblMevcutStok.TabIndex = 4;
            this.lblMevcutStok.Text = "Mevcut Stok *";
            // 
            // numMevcutStok
            // 
            this.numMevcutStok.DecimalPlaces = 2;
            this.numMevcutStok.Location = new Point(15, 180);
            this.numMevcutStok.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.numMevcutStok.Name = "numMevcutStok";
            this.numMevcutStok.Size = new Size(200, 23);
            this.numMevcutStok.TabIndex = 5;
            // 
            // lblDepo
            // 
            this.lblDepo.AutoSize = true;
            this.lblDepo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDepo.Location = new Point(15, 90);
            this.lblDepo.Name = "lblDepo";
            this.lblDepo.Size = new Size(40, 15);
            this.lblDepo.TabIndex = 2;
            this.lblDepo.Text = "Depo *";
            // 
            // cmbDepo
            // 
            this.cmbDepo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDepo.FormattingEnabled = true;
            this.cmbDepo.Location = new Point(15, 110);
            this.cmbDepo.Name = "cmbDepo";
            this.cmbDepo.Size = new Size(200, 23);
            this.cmbDepo.TabIndex = 3;
            // 
            // lblUrun
            // 
            this.lblUrun.AutoSize = true;
            this.lblUrun.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblUrun.Location = new Point(15, 20);
            this.lblUrun.Name = "lblUrun";
            this.lblUrun.Size = new Size(41, 15);
            this.lblUrun.TabIndex = 0;
            this.lblUrun.Text = "Ürün *";
            // 
            // cmbUrun
            // 
            this.cmbUrun.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbUrun.FormattingEnabled = true;
            this.cmbUrun.Location = new Point(15, 40);
            this.cmbUrun.Name = "cmbUrun";
            this.cmbUrun.Size = new Size(200, 23);
            this.cmbUrun.TabIndex = 1;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(59, 130, 246);
            this.panelHeader.Controls.Add(this.lblDurum);
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(20, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new Padding(20, 15, 20, 15);
            this.panelHeader.Size = new Size(760, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.White;
            this.lblBaslik.Location = new Point(20, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(204, 30);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Yeni Stok Kartı Oluştur";
            // 
            // lblDurum
            // 
            this.lblDurum.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new Font("Segoe UI", 10F);
            this.lblDurum.ForeColor = Color.White;
            this.lblDurum.Location = new Point(680, 22);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new Size(35, 19);
            this.lblDurum.TabIndex = 1;
            this.lblDurum.Text = "Hazır";
            // 
            // StokKartiEkleFormNew
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(243, 244, 246);
            this.ClientSize = new Size(800, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StokKartiEkleFormNew";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Yeni Stok Kartı";
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelCard3.ResumeLayout(false);
            this.panelCard3.PerformLayout();
            this.panelCard2.ResumeLayout(false);
            this.panelCard2.PerformLayout();
            this.panelCard1.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRezerveStok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMevcutStok)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMain;
        private Panel panelContent;
        private Panel panelCard3;
        private Panel panelCard2;
        private Panel panelCard1;
        private Panel panelHeader;
        private Label lblBaslik;
        private Label lblDurum;
        private Panel panelForm;
        private Label lblUrun;
        private ComboBox cmbUrun;
        private Label lblDepo;
        private ComboBox cmbDepo;
        private Label lblMevcutStok;
        private NumericUpDown numMevcutStok;
        private Label lblRezerveStok;
        private NumericUpDown numRezerveStok;
        private Panel panelButtons;
        private Button btnKaydet;
        private Button btnIptal;
        private Label lblIpuclariBaslik;
        private Label lblIpucu1;
        private Label lblIpucu2;
        private Label lblIpucu3;
        private Label lblBilgilendirmeBaslik;
        private Label lblBilgiUrun;
        private Label lblBilgiDepo;
        private Label lblBilgiMevcutStok;
        private Label lblBilgiRezerve;
    }
}


