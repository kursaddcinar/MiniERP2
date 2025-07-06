namespace MiniERP.WinForms.Forms
{
    partial class ProductEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label lblTitle;
        private Label lblProductCode;
        private TextBox txtProductCode;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblUnit;
        private ComboBox cmbUnit;
        private Label lblSalePrice;
        private NumericUpDown numSalePrice;
        private Label lblPurchasePrice;
        private NumericUpDown numPurchasePrice;
        private Label lblVatRate;
        private NumericUpDown numVatRate;
        private Label lblMinStock;
        private NumericUpDown numMinStock;
        private Label lblMaxStock;
        private NumericUpDown numMaxStock;
        private CheckBox chkIsActive;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new Panel();
            this.lblTitle = new Label();
            this.lblProductCode = new Label();
            this.txtProductCode = new TextBox();
            this.lblProductName = new Label();
            this.txtProductName = new TextBox();
            this.lblCategory = new Label();
            this.cmbCategory = new ComboBox();
            this.lblUnit = new Label();
            this.cmbUnit = new ComboBox();
            this.lblSalePrice = new Label();
            this.numSalePrice = new NumericUpDown();
            this.lblPurchasePrice = new Label();
            this.numPurchasePrice = new NumericUpDown();
            this.lblVatRate = new Label();
            this.numVatRate = new NumericUpDown();
            this.lblMinStock = new Label();
            this.numMinStock = new NumericUpDown();
            this.lblMaxStock = new Label();
            this.numMaxStock = new NumericUpDown();
            this.chkIsActive = new CheckBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVatRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStock)).BeginInit();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = Color.FromArgb(0, 122, 255);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(500, 60);
            this.panelTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(154, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ürün Düzenle";

            // lblProductCode
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblProductCode.Location = new Point(30, 80);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new Size(80, 19);
            this.lblProductCode.TabIndex = 1;
            this.lblProductCode.Text = "Ürün Kodu:";

            // txtProductCode
            this.txtProductCode.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtProductCode.Location = new Point(150, 77);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new Size(200, 25);
            this.txtProductCode.TabIndex = 2;

            // lblProductName
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblProductName.Location = new Point(30, 120);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new Size(70, 19);
            this.lblProductName.TabIndex = 3;
            this.lblProductName.Text = "Ürün Adı:";

            // txtProductName
            this.txtProductName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtProductName.Location = new Point(150, 117);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new Size(300, 25);
            this.txtProductName.TabIndex = 4;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblCategory.Location = new Point(30, 160);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new Size(63, 19);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Kategori:";

            // cmbCategory
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new Point(150, 157);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new Size(200, 25);
            this.cmbCategory.TabIndex = 6;

            // lblUnit
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblUnit.Location = new Point(30, 200);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new Size(42, 19);
            this.lblUnit.TabIndex = 7;
            this.lblUnit.Text = "Birim:";

            // cmbUnit
            this.cmbUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbUnit.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new Point(150, 197);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new Size(200, 25);
            this.cmbUnit.TabIndex = 8;

            // lblSalePrice
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblSalePrice.Location = new Point(30, 240);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new Size(85, 19);
            this.lblSalePrice.TabIndex = 9;
            this.lblSalePrice.Text = "Satış Fiyatı:";

            // numSalePrice
            this.numSalePrice.DecimalPlaces = 2;
            this.numSalePrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.numSalePrice.Location = new Point(150, 237);
            this.numSalePrice.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numSalePrice.Name = "numSalePrice";
            this.numSalePrice.Size = new Size(120, 25);
            this.numSalePrice.TabIndex = 10;

            // lblPurchasePrice
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblPurchasePrice.Location = new Point(30, 280);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new Size(95, 19);
            this.lblPurchasePrice.TabIndex = 11;
            this.lblPurchasePrice.Text = "Alış Fiyatı:";

            // numPurchasePrice
            this.numPurchasePrice.DecimalPlaces = 2;
            this.numPurchasePrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.numPurchasePrice.Location = new Point(150, 277);
            this.numPurchasePrice.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numPurchasePrice.Name = "numPurchasePrice";
            this.numPurchasePrice.Size = new Size(120, 25);
            this.numPurchasePrice.TabIndex = 12;

            // lblVatRate
            this.lblVatRate.AutoSize = true;
            this.lblVatRate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblVatRate.Location = new Point(30, 320);
            this.lblVatRate.Name = "lblVatRate";
            this.lblVatRate.Size = new Size(79, 19);
            this.lblVatRate.TabIndex = 13;
            this.lblVatRate.Text = "KDV Oranı:";

            // numVatRate
            this.numVatRate.DecimalPlaces = 2;
            this.numVatRate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.numVatRate.Location = new Point(150, 317);
            this.numVatRate.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numVatRate.Name = "numVatRate";
            this.numVatRate.Size = new Size(120, 25);
            this.numVatRate.TabIndex = 14;
            this.numVatRate.Value = new decimal(new int[] { 18, 0, 0, 0 });

            // lblMinStock
            this.lblMinStock.AutoSize = true;
            this.lblMinStock.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblMinStock.Location = new Point(30, 360);
            this.lblMinStock.Name = "lblMinStock";
            this.lblMinStock.Size = new Size(95, 19);
            this.lblMinStock.TabIndex = 15;
            this.lblMinStock.Text = "Min. Stok:";

            // numMinStock
            this.numMinStock.DecimalPlaces = 2;
            this.numMinStock.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.numMinStock.Location = new Point(150, 357);
            this.numMinStock.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numMinStock.Name = "numMinStock";
            this.numMinStock.Size = new Size(120, 25);
            this.numMinStock.TabIndex = 16;

            // lblMaxStock
            this.lblMaxStock.AutoSize = true;
            this.lblMaxStock.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblMaxStock.Location = new Point(30, 400);
            this.lblMaxStock.Name = "lblMaxStock";
            this.lblMaxStock.Size = new Size(95, 19);
            this.lblMaxStock.TabIndex = 17;
            this.lblMaxStock.Text = "Max. Stok:";

            // numMaxStock
            this.numMaxStock.DecimalPlaces = 2;
            this.numMaxStock.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.numMaxStock.Location = new Point(150, 397);
            this.numMaxStock.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numMaxStock.Name = "numMaxStock";
            this.numMaxStock.Size = new Size(120, 25);
            this.numMaxStock.TabIndex = 18;

            // chkIsActive
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = CheckState.Checked;
            this.chkIsActive.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.chkIsActive.Location = new Point(150, 440);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new Size(57, 23);
            this.chkIsActive.TabIndex = 19;
            this.chkIsActive.Text = "Aktif";
            this.chkIsActive.UseVisualStyleBackColor = true;

            // btnSave
            this.btnSave.BackColor = Color.FromArgb(40, 167, 69);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(150, 480);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(100, 35);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(270, 480);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(100, 35);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // ProductEditForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(500, 540);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.numMaxStock);
            this.Controls.Add(this.lblMaxStock);
            this.Controls.Add(this.numMinStock);
            this.Controls.Add(this.lblMinStock);
            this.Controls.Add(this.numVatRate);
            this.Controls.Add(this.lblVatRate);
            this.Controls.Add(this.numPurchasePrice);
            this.Controls.Add(this.lblPurchasePrice);
            this.Controls.Add(this.numSalePrice);
            this.Controls.Add(this.lblSalePrice);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductEditForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Ürün Düzenle";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVatRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
} 