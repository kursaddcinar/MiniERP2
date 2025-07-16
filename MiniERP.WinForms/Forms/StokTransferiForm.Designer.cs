namespace MiniERP.WinForms.Forms
{
    partial class StokTransferiForm
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
            this.panelButtons = new Panel();
            this.btnIptal = new Button();
            this.btnTransfer = new Button();
            this.panelForm = new Panel();
            this.txtAciklama = new TextBox();
            this.lblAciklama = new Label();
            this.lblMevcutStok = new Label();
            this.numMiktar = new NumericUpDown();
            this.lblMiktar = new Label();
            this.cmbToWarehouse = new ComboBox();
            this.lblToWarehouse = new Label();
            this.cmbFromWarehouse = new ComboBox();
            this.lblFromWarehouse = new Label();
            this.cmbProduct = new ComboBox();
            this.lblProduct = new Label();
            this.panelHeader = new Panel();
            this.lblBaslik = new Label();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMiktar)).BeginInit();
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
            this.panelMain.Size = new Size(600, 400);
            this.panelMain.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnIptal);
            this.panelButtons.Controls.Add(this.btnTransfer);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(20, 330);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(560, 50);
            this.panelButtons.TabIndex = 2;
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnIptal.BackColor = Color.FromArgb(107, 114, 128);
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(460, 10);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new Size(90, 35);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnTransfer.BackColor = Color.FromArgb(168, 85, 247);
            this.btnTransfer.FlatAppearance.BorderSize = 0;
            this.btnTransfer.FlatStyle = FlatStyle.Flat;
            this.btnTransfer.ForeColor = Color.White;
            this.btnTransfer.Location = new Point(360, 10);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new Size(90, 35);
            this.btnTransfer.TabIndex = 0;
            this.btnTransfer.Text = "Transfer Et";
            this.btnTransfer.UseVisualStyleBackColor = false;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = Color.White;
            this.panelForm.BorderStyle = BorderStyle.FixedSingle;
            this.panelForm.Controls.Add(this.txtAciklama);
            this.panelForm.Controls.Add(this.lblAciklama);
            this.panelForm.Controls.Add(this.lblMevcutStok);
            this.panelForm.Controls.Add(this.numMiktar);
            this.panelForm.Controls.Add(this.lblMiktar);
            this.panelForm.Controls.Add(this.cmbToWarehouse);
            this.panelForm.Controls.Add(this.lblToWarehouse);
            this.panelForm.Controls.Add(this.cmbFromWarehouse);
            this.panelForm.Controls.Add(this.lblFromWarehouse);
            this.panelForm.Controls.Add(this.cmbProduct);
            this.panelForm.Controls.Add(this.lblProduct);
            this.panelForm.Dock = DockStyle.Fill;
            this.panelForm.Location = new Point(20, 70);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new Padding(20);
            this.panelForm.Size = new Size(560, 260);
            this.panelForm.TabIndex = 1;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new Point(20, 200);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new Size(500, 40);
            this.txtAciklama.TabIndex = 10;
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new Point(20, 180);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new Size(59, 15);
            this.lblAciklama.TabIndex = 9;
            this.lblAciklama.Text = "Açıklama:";
            // 
            // lblMevcutStok
            // 
            this.lblMevcutStok.BackColor = Color.FromArgb(249, 250, 251);
            this.lblMevcutStok.BorderStyle = BorderStyle.FixedSingle;
            this.lblMevcutStok.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblMevcutStok.ForeColor = Color.FromArgb(59, 130, 246);
            this.lblMevcutStok.Location = new Point(280, 140);
            this.lblMevcutStok.Name = "lblMevcutStok";
            this.lblMevcutStok.Size = new Size(240, 23);
            this.lblMevcutStok.TabIndex = 8;
            this.lblMevcutStok.Text = "Mevcut Stok: -";
            this.lblMevcutStok.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numMiktar
            // 
            this.numMiktar.DecimalPlaces = 2;
            this.numMiktar.Location = new Point(20, 140);
            this.numMiktar.Name = "numMiktar";
            this.numMiktar.Size = new Size(240, 23);
            this.numMiktar.TabIndex = 7;
            this.numMiktar.TextAlign = HorizontalAlignment.Right;
            // 
            // lblMiktar
            // 
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new Point(20, 120);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new Size(97, 15);
            this.lblMiktar.TabIndex = 6;
            this.lblMiktar.Text = "Transfer Miktarı:";
            // 
            // cmbToWarehouse
            // 
            this.cmbToWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbToWarehouse.FormattingEnabled = true;
            this.cmbToWarehouse.Location = new Point(280, 85);
            this.cmbToWarehouse.Name = "cmbToWarehouse";
            this.cmbToWarehouse.Size = new Size(240, 23);
            this.cmbToWarehouse.TabIndex = 5;
            // 
            // lblToWarehouse
            // 
            this.lblToWarehouse.AutoSize = true;
            this.lblToWarehouse.Location = new Point(280, 65);
            this.lblToWarehouse.Name = "lblToWarehouse";
            this.lblToWarehouse.Size = new Size(70, 15);
            this.lblToWarehouse.TabIndex = 4;
            this.lblToWarehouse.Text = "Hedef Depo:";
            // 
            // cmbFromWarehouse
            // 
            this.cmbFromWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFromWarehouse.FormattingEnabled = true;
            this.cmbFromWarehouse.Location = new Point(20, 85);
            this.cmbFromWarehouse.Name = "cmbFromWarehouse";
            this.cmbFromWarehouse.Size = new Size(240, 23);
            this.cmbFromWarehouse.TabIndex = 3;
            // 
            // lblFromWarehouse
            // 
            this.lblFromWarehouse.AutoSize = true;
            this.lblFromWarehouse.Location = new Point(20, 65);
            this.lblFromWarehouse.Name = "lblFromWarehouse";
            this.lblFromWarehouse.Size = new Size(78, 15);
            this.lblFromWarehouse.TabIndex = 2;
            this.lblFromWarehouse.Text = "Kaynak Depo:";
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new Point(20, 30);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new Size(500, 23);
            this.cmbProduct.TabIndex = 1;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new Point(20, 10);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new Size(33, 15);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "Ürün:";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(168, 85, 247);
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(20, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(560, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Dock = DockStyle.Fill;
            this.lblBaslik.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.White;
            this.lblBaslik.Location = new Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(560, 50);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "🔄 Stok Transferi";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StokTransferiForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(249, 250, 251);
            this.ClientSize = new Size(600, 400);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StokTransferiForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Stok Transferi";
            this.panelMain.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMiktar)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelButtons;
        private Button btnIptal;
        private Button btnTransfer;
        private Panel panelForm;
        private TextBox txtAciklama;
        private Label lblAciklama;
        private Label lblMevcutStok;
        private NumericUpDown numMiktar;
        private Label lblMiktar;
        private ComboBox cmbToWarehouse;
        private Label lblToWarehouse;
        private ComboBox cmbFromWarehouse;
        private Label lblFromWarehouse;
        private ComboBox cmbProduct;
        private Label lblProduct;
        private Panel panelHeader;
        private Label lblBaslik;
    }
}
