namespace MiniERP.WinForms.Forms
{
    partial class UrunDetayForm
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
            this.groupBoxBasic = new System.Windows.Forms.GroupBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.lblProductCodeValue = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductNameValue = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblCategoryValue = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblUnitValue = new System.Windows.Forms.Label();
            this.groupBoxPricing = new System.Windows.Forms.GroupBox();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.lblSalePriceValue = new System.Windows.Forms.Label();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.lblPurchasePriceValue = new System.Windows.Forms.Label();
            this.lblVatRate = new System.Windows.Forms.Label();
            this.lblVatRateValue = new System.Windows.Forms.Label();
            this.groupBoxStock = new System.Windows.Forms.GroupBox();
            this.lblCurrentStock = new System.Windows.Forms.Label();
            this.lblCurrentStockValue = new System.Windows.Forms.Label();
            this.lblReservedStock = new System.Windows.Forms.Label();
            this.lblReservedStockValue = new System.Windows.Forms.Label();
            this.lblAvailableStock = new System.Windows.Forms.Label();
            this.lblAvailableStockValue = new System.Windows.Forms.Label();
            this.lblMinStock = new System.Windows.Forms.Label();
            this.lblMinStockValue = new System.Windows.Forms.Label();
            this.lblMaxStock = new System.Windows.Forms.Label();
            this.lblMaxStockValue = new System.Windows.Forms.Label();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lblCreatedDateValue = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnKapat = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxBasic.SuspendLayout();
            this.groupBoxPricing.SuspendLayout();
            this.groupBoxStock.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
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
            this.panelHeader.Size = new System.Drawing.Size(700, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(154, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔍 Ürün Detayları";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.groupBoxStatus);
            this.panelMain.Controls.Add(this.groupBoxStock);
            this.panelMain.Controls.Add(this.groupBoxPricing);
            this.panelMain.Controls.Add(this.groupBoxBasic);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(700, 500);
            this.panelMain.TabIndex = 1;
            // 
            // groupBoxBasic
            // 
            this.groupBoxBasic.Controls.Add(this.lblUnit);
            this.groupBoxBasic.Controls.Add(this.lblUnitValue);
            this.groupBoxBasic.Controls.Add(this.lblCategory);
            this.groupBoxBasic.Controls.Add(this.lblCategoryValue);
            this.groupBoxBasic.Controls.Add(this.lblProductName);
            this.groupBoxBasic.Controls.Add(this.lblProductNameValue);
            this.groupBoxBasic.Controls.Add(this.lblProductCode);
            this.groupBoxBasic.Controls.Add(this.lblProductCodeValue);
            this.groupBoxBasic.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxBasic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.groupBoxBasic.Location = new System.Drawing.Point(23, 23);
            this.groupBoxBasic.Name = "groupBoxBasic";
            this.groupBoxBasic.Size = new System.Drawing.Size(654, 120);
            this.groupBoxBasic.TabIndex = 0;
            this.groupBoxBasic.TabStop = false;
            this.groupBoxBasic.Text = "📋 Temel Bilgiler";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblProductCode.Location = new System.Drawing.Point(20, 30);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(68, 15);
            this.lblProductCode.TabIndex = 0;
            this.lblProductCode.Text = "Ürün Kodu:";
            // 
            // lblProductCodeValue
            // 
            this.lblProductCodeValue.AutoSize = true;
            this.lblProductCodeValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProductCodeValue.Location = new System.Drawing.Point(120, 30);
            this.lblProductCodeValue.Name = "lblProductCodeValue";
            this.lblProductCodeValue.Size = new System.Drawing.Size(12, 15);
            this.lblProductCodeValue.TabIndex = 1;
            this.lblProductCodeValue.Text = "-";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblProductName.Location = new System.Drawing.Point(350, 30);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(59, 15);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Ürün Adı:";
            // 
            // lblProductNameValue
            // 
            this.lblProductNameValue.AutoSize = true;
            this.lblProductNameValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProductNameValue.Location = new System.Drawing.Point(450, 30);
            this.lblProductNameValue.Name = "lblProductNameValue";
            this.lblProductNameValue.Size = new System.Drawing.Size(12, 15);
            this.lblProductNameValue.TabIndex = 3;
            this.lblProductNameValue.Text = "-";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblCategory.Location = new System.Drawing.Point(20, 70);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(55, 15);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Kategori:";
            // 
            // lblCategoryValue
            // 
            this.lblCategoryValue.AutoSize = true;
            this.lblCategoryValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoryValue.Location = new System.Drawing.Point(120, 70);
            this.lblCategoryValue.Name = "lblCategoryValue";
            this.lblCategoryValue.Size = new System.Drawing.Size(12, 15);
            this.lblCategoryValue.TabIndex = 5;
            this.lblCategoryValue.Text = "-";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblUnit.Location = new System.Drawing.Point(350, 70);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(39, 15);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "Birim:";
            // 
            // lblUnitValue
            // 
            this.lblUnitValue.AutoSize = true;
            this.lblUnitValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUnitValue.Location = new System.Drawing.Point(450, 70);
            this.lblUnitValue.Name = "lblUnitValue";
            this.lblUnitValue.Size = new System.Drawing.Size(12, 15);
            this.lblUnitValue.TabIndex = 7;
            this.lblUnitValue.Text = "-";
            // 
            // groupBoxPricing
            // 
            this.groupBoxPricing.Controls.Add(this.lblVatRate);
            this.groupBoxPricing.Controls.Add(this.lblVatRateValue);
            this.groupBoxPricing.Controls.Add(this.lblPurchasePrice);
            this.groupBoxPricing.Controls.Add(this.lblPurchasePriceValue);
            this.groupBoxPricing.Controls.Add(this.lblSalePrice);
            this.groupBoxPricing.Controls.Add(this.lblSalePriceValue);
            this.groupBoxPricing.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxPricing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.groupBoxPricing.Location = new System.Drawing.Point(23, 159);
            this.groupBoxPricing.Name = "groupBoxPricing";
            this.groupBoxPricing.Size = new System.Drawing.Size(654, 100);
            this.groupBoxPricing.TabIndex = 1;
            this.groupBoxPricing.TabStop = false;
            this.groupBoxPricing.Text = "💰 Fiyat Bilgileri";
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSalePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblSalePrice.Location = new System.Drawing.Point(20, 30);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(73, 15);
            this.lblSalePrice.TabIndex = 0;
            this.lblSalePrice.Text = "Satış Fiyatı:";
            // 
            // lblSalePriceValue
            // 
            this.lblSalePriceValue.AutoSize = true;
            this.lblSalePriceValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSalePriceValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblSalePriceValue.Location = new System.Drawing.Point(120, 30);
            this.lblSalePriceValue.Name = "lblSalePriceValue";
            this.lblSalePriceValue.Size = new System.Drawing.Size(12, 15);
            this.lblSalePriceValue.TabIndex = 1;
            this.lblSalePriceValue.Text = "-";
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPurchasePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblPurchasePrice.Location = new System.Drawing.Point(250, 30);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(65, 15);
            this.lblPurchasePrice.TabIndex = 2;
            this.lblPurchasePrice.Text = "Alış Fiyatı:";
            // 
            // lblPurchasePriceValue
            // 
            this.lblPurchasePriceValue.AutoSize = true;
            this.lblPurchasePriceValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPurchasePriceValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblPurchasePriceValue.Location = new System.Drawing.Point(350, 30);
            this.lblPurchasePriceValue.Name = "lblPurchasePriceValue";
            this.lblPurchasePriceValue.Size = new System.Drawing.Size(12, 15);
            this.lblPurchasePriceValue.TabIndex = 3;
            this.lblPurchasePriceValue.Text = "-";
            // 
            // lblVatRate
            // 
            this.lblVatRate.AutoSize = true;
            this.lblVatRate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVatRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblVatRate.Location = new System.Drawing.Point(480, 30);
            this.lblVatRate.Name = "lblVatRate";
            this.lblVatRate.Size = new System.Drawing.Size(68, 15);
            this.lblVatRate.TabIndex = 4;
            this.lblVatRate.Text = "KDV Oranı:";
            // 
            // lblVatRateValue
            // 
            this.lblVatRateValue.AutoSize = true;
            this.lblVatRateValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVatRateValue.Location = new System.Drawing.Point(580, 30);
            this.lblVatRateValue.Name = "lblVatRateValue";
            this.lblVatRateValue.Size = new System.Drawing.Size(12, 15);
            this.lblVatRateValue.TabIndex = 5;
            this.lblVatRateValue.Text = "-";
            // 
            // groupBoxStock
            // 
            this.groupBoxStock.Controls.Add(this.lblMaxStock);
            this.groupBoxStock.Controls.Add(this.lblMaxStockValue);
            this.groupBoxStock.Controls.Add(this.lblMinStock);
            this.groupBoxStock.Controls.Add(this.lblMinStockValue);
            this.groupBoxStock.Controls.Add(this.lblAvailableStock);
            this.groupBoxStock.Controls.Add(this.lblAvailableStockValue);
            this.groupBoxStock.Controls.Add(this.lblReservedStock);
            this.groupBoxStock.Controls.Add(this.lblReservedStockValue);
            this.groupBoxStock.Controls.Add(this.lblCurrentStock);
            this.groupBoxStock.Controls.Add(this.lblCurrentStockValue);
            this.groupBoxStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.groupBoxStock.Location = new System.Drawing.Point(23, 275);
            this.groupBoxStock.Name = "groupBoxStock";
            this.groupBoxStock.Size = new System.Drawing.Size(654, 120);
            this.groupBoxStock.TabIndex = 2;
            this.groupBoxStock.TabStop = false;
            this.groupBoxStock.Text = "📦 Stok Bilgileri";
            // 
            // lblCurrentStock
            // 
            this.lblCurrentStock.AutoSize = true;
            this.lblCurrentStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCurrentStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblCurrentStock.Location = new System.Drawing.Point(20, 30);
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new System.Drawing.Size(80, 15);
            this.lblCurrentStock.TabIndex = 0;
            this.lblCurrentStock.Text = "Mevcut Stok:";
            // 
            // lblCurrentStockValue
            // 
            this.lblCurrentStockValue.AutoSize = true;
            this.lblCurrentStockValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCurrentStockValue.Location = new System.Drawing.Point(120, 30);
            this.lblCurrentStockValue.Name = "lblCurrentStockValue";
            this.lblCurrentStockValue.Size = new System.Drawing.Size(12, 15);
            this.lblCurrentStockValue.TabIndex = 1;
            this.lblCurrentStockValue.Text = "-";
            // 
            // lblReservedStock
            // 
            this.lblReservedStock.AutoSize = true;
            this.lblReservedStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReservedStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblReservedStock.Location = new System.Drawing.Point(250, 30);
            this.lblReservedStock.Name = "lblReservedStock";
            this.lblReservedStock.Size = new System.Drawing.Size(78, 15);
            this.lblReservedStock.TabIndex = 2;
            this.lblReservedStock.Text = "Rezerve Stok:";
            // 
            // lblReservedStockValue
            // 
            this.lblReservedStockValue.AutoSize = true;
            this.lblReservedStockValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReservedStockValue.Location = new System.Drawing.Point(350, 30);
            this.lblReservedStockValue.Name = "lblReservedStockValue";
            this.lblReservedStockValue.Size = new System.Drawing.Size(12, 15);
            this.lblReservedStockValue.TabIndex = 3;
            this.lblReservedStockValue.Text = "-";
            // 
            // lblAvailableStock
            // 
            this.lblAvailableStock.AutoSize = true;
            this.lblAvailableStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAvailableStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblAvailableStock.Location = new System.Drawing.Point(480, 30);
            this.lblAvailableStock.Name = "lblAvailableStock";
            this.lblAvailableStock.Size = new System.Drawing.Size(82, 15);
            this.lblAvailableStock.TabIndex = 4;
            this.lblAvailableStock.Text = "Kullanılabilir:";
            // 
            // lblAvailableStockValue
            // 
            this.lblAvailableStockValue.AutoSize = true;
            this.lblAvailableStockValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAvailableStockValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblAvailableStockValue.Location = new System.Drawing.Point(580, 30);
            this.lblAvailableStockValue.Name = "lblAvailableStockValue";
            this.lblAvailableStockValue.Size = new System.Drawing.Size(12, 15);
            this.lblAvailableStockValue.TabIndex = 5;
            this.lblAvailableStockValue.Text = "-";
            // 
            // lblMinStock
            // 
            this.lblMinStock.AutoSize = true;
            this.lblMinStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMinStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblMinStock.Location = new System.Drawing.Point(20, 70);
            this.lblMinStock.Name = "lblMinStock";
            this.lblMinStock.Size = new System.Drawing.Size(92, 15);
            this.lblMinStock.TabIndex = 6;
            this.lblMinStock.Text = "Minimum Stok:";
            // 
            // lblMinStockValue
            // 
            this.lblMinStockValue.AutoSize = true;
            this.lblMinStockValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMinStockValue.Location = new System.Drawing.Point(120, 70);
            this.lblMinStockValue.Name = "lblMinStockValue";
            this.lblMinStockValue.Size = new System.Drawing.Size(12, 15);
            this.lblMinStockValue.TabIndex = 7;
            this.lblMinStockValue.Text = "-";
            // 
            // lblMaxStock
            // 
            this.lblMaxStock.AutoSize = true;
            this.lblMaxStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaxStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblMaxStock.Location = new System.Drawing.Point(250, 70);
            this.lblMaxStock.Name = "lblMaxStock";
            this.lblMaxStock.Size = new System.Drawing.Size(95, 15);
            this.lblMaxStock.TabIndex = 8;
            this.lblMaxStock.Text = "Maksimum Stok:";
            // 
            // lblMaxStockValue
            // 
            this.lblMaxStockValue.AutoSize = true;
            this.lblMaxStockValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaxStockValue.Location = new System.Drawing.Point(350, 70);
            this.lblMaxStockValue.Name = "lblMaxStockValue";
            this.lblMaxStockValue.Size = new System.Drawing.Size(12, 15);
            this.lblMaxStockValue.TabIndex = 9;
            this.lblMaxStockValue.Text = "-";
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.lblCreatedDate);
            this.groupBoxStatus.Controls.Add(this.lblCreatedDateValue);
            this.groupBoxStatus.Controls.Add(this.lblStatus);
            this.groupBoxStatus.Controls.Add(this.lblStatusValue);
            this.groupBoxStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.groupBoxStatus.Location = new System.Drawing.Point(23, 411);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(654, 80);
            this.groupBoxStatus.TabIndex = 3;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "ℹ️ Durum Bilgileri";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblStatus.Location = new System.Drawing.Point(20, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Durum:";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.Location = new System.Drawing.Point(120, 30);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(12, 15);
            this.lblStatusValue.TabIndex = 1;
            this.lblStatusValue.Text = "-";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreatedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblCreatedDate.Location = new System.Drawing.Point(350, 30);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(90, 15);
            this.lblCreatedDate.TabIndex = 2;
            this.lblCreatedDate.Text = "Oluşturma Tar.:";
            // 
            // lblCreatedDateValue
            // 
            this.lblCreatedDateValue.AutoSize = true;
            this.lblCreatedDateValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCreatedDateValue.Location = new System.Drawing.Point(450, 30);
            this.lblCreatedDateValue.Name = "lblCreatedDateValue";
            this.lblCreatedDateValue.Size = new System.Drawing.Size(12, 15);
            this.lblCreatedDateValue.TabIndex = 3;
            this.lblCreatedDateValue.Text = "-";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelButtons.Controls.Add(this.btnKapat);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 560);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(20);
            this.panelButtons.Size = new System.Drawing.Size(700, 60);
            this.panelButtons.TabIndex = 2;
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Location = new System.Drawing.Point(580, 23);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(100, 35);
            this.btnKapat.TabIndex = 0;
            this.btnKapat.Text = "❌ Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // UrunDetayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 620);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrunDetayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ürün Detayları";
            this.Load += new System.EventHandler(this.UrunDetayForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupBoxBasic.ResumeLayout(false);
            this.groupBoxBasic.PerformLayout();
            this.groupBoxPricing.ResumeLayout(false);
            this.groupBoxPricing.PerformLayout();
            this.groupBoxStock.ResumeLayout(false);
            this.groupBoxStock.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxBasic;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label lblProductCodeValue;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductNameValue;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblCategoryValue;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblUnitValue;
        private System.Windows.Forms.GroupBox groupBoxPricing;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.Label lblSalePriceValue;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.Label lblPurchasePriceValue;
        private System.Windows.Forms.Label lblVatRate;
        private System.Windows.Forms.Label lblVatRateValue;
        private System.Windows.Forms.GroupBox groupBoxStock;
        private System.Windows.Forms.Label lblCurrentStock;
        private System.Windows.Forms.Label lblCurrentStockValue;
        private System.Windows.Forms.Label lblReservedStock;
        private System.Windows.Forms.Label lblReservedStockValue;
        private System.Windows.Forms.Label lblAvailableStock;
        private System.Windows.Forms.Label lblAvailableStockValue;
        private System.Windows.Forms.Label lblMinStock;
        private System.Windows.Forms.Label lblMinStockValue;
        private System.Windows.Forms.Label lblMaxStock;
        private System.Windows.Forms.Label lblMaxStockValue;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblCreatedDateValue;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnKapat;
    }
}


