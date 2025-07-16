namespace MiniERP.WinForms.Forms
{
    partial class UrunDuzenleForm
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblProductCodeLabel = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.numSalePrice = new System.Windows.Forms.NumericUpDown();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.numPurchasePrice = new System.Windows.Forms.NumericUpDown();
            this.lblVatRate = new System.Windows.Forms.Label();
            this.numVatRate = new System.Windows.Forms.NumericUpDown();
            this.lblMinStock = new System.Windows.Forms.Label();
            this.numMinStock = new System.Windows.Forms.NumericUpDown();
            this.lblMaxStock = new System.Windows.Forms.Label();
            this.numMaxStock = new System.Windows.Forms.NumericUpDown();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVatRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStock)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(600, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(161, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "✏️ Ürün Düzenle";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.chkIsActive);
            this.panelMain.Controls.Add(this.lblMaxStock);
            this.panelMain.Controls.Add(this.numMaxStock);
            this.panelMain.Controls.Add(this.lblMinStock);
            this.panelMain.Controls.Add(this.numMinStock);
            this.panelMain.Controls.Add(this.lblVatRate);
            this.panelMain.Controls.Add(this.numVatRate);
            this.panelMain.Controls.Add(this.lblPurchasePrice);
            this.panelMain.Controls.Add(this.numPurchasePrice);
            this.panelMain.Controls.Add(this.lblSalePrice);
            this.panelMain.Controls.Add(this.numSalePrice);
            this.panelMain.Controls.Add(this.lblUnit);
            this.panelMain.Controls.Add(this.cmbUnit);
            this.panelMain.Controls.Add(this.lblCategory);
            this.panelMain.Controls.Add(this.cmbCategory);
            this.panelMain.Controls.Add(this.lblProductName);
            this.panelMain.Controls.Add(this.txtProductName);
            this.panelMain.Controls.Add(this.lblDescription);
            this.panelMain.Controls.Add(this.txtDescription);
            this.panelMain.Controls.Add(this.lblProductCodeLabel);
            this.panelMain.Controls.Add(this.lblProductCode);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30);
            this.panelMain.Size = new System.Drawing.Size(600, 480);
            this.panelMain.TabIndex = 1;
            // 
            // lblProductCodeLabel
            // 
            this.lblProductCodeLabel.AutoSize = true;
            this.lblProductCodeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblProductCodeLabel.Location = new System.Drawing.Point(33, 20);
            this.lblProductCodeLabel.Name = "lblProductCodeLabel";
            this.lblProductCodeLabel.Size = new System.Drawing.Size(68, 15);
            this.lblProductCodeLabel.TabIndex = 0;
            this.lblProductCodeLabel.Text = "Ürün Kodu:";
            // 
            // lblProductCode
            // 
            this.lblProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProductCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProductCode.Location = new System.Drawing.Point(33, 38);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(250, 25);
            this.lblProductCode.TabIndex = 1;
            this.lblProductCode.Text = "-";
            this.lblProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProductCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblProductName.Location = new System.Drawing.Point(313, 20);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(64, 15);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Ürün Adı *";
            // 
            // txtProductName
            // 
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProductName.Location = new System.Drawing.Point(313, 38);
            this.txtProductName.MaxLength = 100;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(250, 25);
            this.txtProductName.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblDescription.Location = new System.Drawing.Point(33, 70);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(57, 15);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Açıklama";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(33, 88);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(530, 60);
            this.txtDescription.TabIndex = 5;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblCategory.Location = new System.Drawing.Point(33, 160);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(51, 15);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Kategori";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(33, 178);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(250, 25);
            this.cmbCategory.TabIndex = 7;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblUnit.Location = new System.Drawing.Point(313, 160);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(43, 15);
            this.lblUnit.TabIndex = 8;
            this.lblUnit.Text = "Birim *";
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(313, 178);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(250, 25);
            this.cmbUnit.TabIndex = 9;
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSalePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblSalePrice.Location = new System.Drawing.Point(33, 223);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(78, 15);
            this.lblSalePrice.TabIndex = 10;
            this.lblSalePrice.Text = "Satış Fiyatı *";
            // 
            // numSalePrice
            // 
            this.numSalePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSalePrice.DecimalPlaces = 2;
            this.numSalePrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numSalePrice.Location = new System.Drawing.Point(33, 241);
            this.numSalePrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSalePrice.Name = "numSalePrice";
            this.numSalePrice.Size = new System.Drawing.Size(250, 25);
            this.numSalePrice.TabIndex = 11;
            this.numSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSalePrice.ThousandsSeparator = true;
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPurchasePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblPurchasePrice.Location = new System.Drawing.Point(313, 223);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(70, 15);
            this.lblPurchasePrice.TabIndex = 12;
            this.lblPurchasePrice.Text = "Alış Fiyatı *";
            // 
            // numPurchasePrice
            // 
            this.numPurchasePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPurchasePrice.DecimalPlaces = 2;
            this.numPurchasePrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPurchasePrice.Location = new System.Drawing.Point(313, 241);
            this.numPurchasePrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPurchasePrice.Name = "numPurchasePrice";
            this.numPurchasePrice.Size = new System.Drawing.Size(250, 25);
            this.numPurchasePrice.TabIndex = 13;
            this.numPurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPurchasePrice.ThousandsSeparator = true;
            // 
            // lblVatRate
            // 
            this.lblVatRate.AutoSize = true;
            this.lblVatRate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVatRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblVatRate.Location = new System.Drawing.Point(33, 286);
            this.lblVatRate.Name = "lblVatRate";
            this.lblVatRate.Size = new System.Drawing.Size(64, 15);
            this.lblVatRate.TabIndex = 14;
            this.lblVatRate.Text = "KDV Oranı";
            // 
            // numVatRate
            // 
            this.numVatRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numVatRate.DecimalPlaces = 2;
            this.numVatRate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numVatRate.Location = new System.Drawing.Point(33, 304);
            this.numVatRate.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numVatRate.Name = "numVatRate";
            this.numVatRate.Size = new System.Drawing.Size(250, 25);
            this.numVatRate.TabIndex = 15;
            this.numVatRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numVatRate.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // lblMinStock
            // 
            this.lblMinStock.AutoSize = true;
            this.lblMinStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMinStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblMinStock.Location = new System.Drawing.Point(313, 286);
            this.lblMinStock.Name = "lblMinStock";
            this.lblMinStock.Size = new System.Drawing.Size(92, 15);
            this.lblMinStock.TabIndex = 16;
            this.lblMinStock.Text = "Minimum Stok";
            // 
            // numMinStock
            // 
            this.numMinStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMinStock.DecimalPlaces = 2;
            this.numMinStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numMinStock.Location = new System.Drawing.Point(313, 304);
            this.numMinStock.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMinStock.Name = "numMinStock";
            this.numMinStock.Size = new System.Drawing.Size(250, 25);
            this.numMinStock.TabIndex = 17;
            this.numMinStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMinStock.ThousandsSeparator = true;
            // 
            // lblMaxStock
            // 
            this.lblMaxStock.AutoSize = true;
            this.lblMaxStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaxStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblMaxStock.Location = new System.Drawing.Point(33, 349);
            this.lblMaxStock.Name = "lblMaxStock";
            this.lblMaxStock.Size = new System.Drawing.Size(95, 15);
            this.lblMaxStock.TabIndex = 18;
            this.lblMaxStock.Text = "Maksimum Stok";
            // 
            // numMaxStock
            // 
            this.numMaxStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMaxStock.DecimalPlaces = 2;
            this.numMaxStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numMaxStock.Location = new System.Drawing.Point(33, 367);
            this.numMaxStock.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMaxStock.Name = "numMaxStock";
            this.numMaxStock.Size = new System.Drawing.Size(250, 25);
            this.numMaxStock.TabIndex = 19;
            this.numMaxStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMaxStock.ThousandsSeparator = true;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkIsActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.chkIsActive.Location = new System.Drawing.Point(313, 367);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(64, 23);
            this.chkIsActive.TabIndex = 20;
            this.chkIsActive.Text = "Aktif";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelButtons.Controls.Add(this.btnIptal);
            this.panelButtons.Controls.Add(this.btnKaydet);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 540);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(20);
            this.panelButtons.Size = new System.Drawing.Size(600, 80);
            this.panelButtons.TabIndex = 2;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(360, 23);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 35);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "💾 Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(480, 23);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(100, 35);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "❌ İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // UrunDuzenleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrunDuzenleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ürün Düzenle";
            this.Load += new System.EventHandler(this.UrunDuzenleForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVatRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStock)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblProductCodeLabel;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.NumericUpDown numSalePrice;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.NumericUpDown numPurchasePrice;
        private System.Windows.Forms.Label lblVatRate;
        private System.Windows.Forms.NumericUpDown numVatRate;
        private System.Windows.Forms.Label lblMinStock;
        private System.Windows.Forms.NumericUpDown numMinStock;
        private System.Windows.Forms.Label lblMaxStock;
        private System.Windows.Forms.NumericUpDown numMaxStock;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
    }
}
