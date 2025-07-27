namespace MiniERP.WinForms.Forms
{
    partial class StokDetayForm
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
            this.tabControl = new TabControl();
            this.tabPageDetails = new TabPage();
            this.panelDetails = new Panel();
            this.groupBoxStockStatus = new GroupBox();
            this.tableLayoutPanelStock = new TableLayoutPanel();
            this.lblCurrentStock = new Label();
            this.lblCurrentStockValue = new Label();
            this.lblReservedStock = new Label();
            this.lblReservedStockValue = new Label();
            this.lblAvailableStock = new Label();
            this.lblAvailableStockValue = new Label();
            this.lblMinStock = new Label();
            this.lblMinStockValue = new Label();
            this.lblStockStatus = new Label();
            this.groupBoxWarehouse = new GroupBox();
            this.tableLayoutPanelWarehouse = new TableLayoutPanel();
            this.lblWarehouseCode = new Label();
            this.lblWarehouseCodeValue = new Label();
            this.lblWarehouseName = new Label();
            this.lblWarehouseNameValue = new Label();
            this.lblLocation = new Label();
            this.lblLocationValue = new Label();
            this.lblLastUpdate = new Label();
            this.lblLastUpdateValue = new Label();
            this.groupBoxProduct = new GroupBox();
            this.tableLayoutPanelProduct = new TableLayoutPanel();
            this.lblProductCode = new Label();
            this.lblProductCodeValue = new Label();
            this.lblProductName = new Label();
            this.lblProductNameValue = new Label();
            this.lblCategory = new Label();
            this.lblCategoryValue = new Label();
            this.lblUnit = new Label();
            this.lblUnitValue = new Label();
            this.tabPageTransactions = new TabPage();
            this.dgvStockTransactions = new DataGridView();
            this.colTransactionDate = new DataGridViewTextBoxColumn();
            this.colTransactionType = new DataGridViewTextBoxColumn();
            this.colDocumentNumber = new DataGridViewTextBoxColumn();
            this.colQuantity = new DataGridViewTextBoxColumn();
            this.colUnitPrice = new DataGridViewTextBoxColumn();
            this.colRemainingStock = new DataGridViewTextBoxColumn();
            this.panelHeader = new Panel();
            this.panelButtons = new Panel();
            this.btnYazdir = new Button();
            this.btnStokCikisi = new Button();
            this.btnStokGirisi = new Button();
            this.btnDuzenle = new Button();
            this.btnKapat = new Button();
            this.panelTitle = new Panel();
            this.lblStockTitle = new Label();
            this.lblLastTransaction = new Label();
            this.lblLastTransactionValue = new Label();
            this.panelStatus = new Panel();
            this.lblDurum = new Label();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageDetails.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.groupBoxStockStatus.SuspendLayout();
            this.tableLayoutPanelStock.SuspendLayout();
            this.groupBoxWarehouse.SuspendLayout();
            this.tableLayoutPanelWarehouse.SuspendLayout();
            this.groupBoxProduct.SuspendLayout();
            this.tableLayoutPanelProduct.SuspendLayout();
            this.tabPageTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockTransactions)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelStatus);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(10);
            this.panelMain.Size = new Size(1000, 700);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.tabControl);
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Location = new Point(10, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new Size(980, 590);
            this.panelContent.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageDetails);
            this.tabControl.Controls.Add(this.tabPageTransactions);
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Font = new Font("Segoe UI", 10F);
            this.tabControl.Location = new Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new Size(980, 590);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.Controls.Add(this.panelDetails);
            this.tabPageDetails.Location = new Point(4, 28);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Padding = new Padding(3);
            this.tabPageDetails.Size = new Size(972, 558);
            this.tabPageDetails.TabIndex = 0;
            this.tabPageDetails.Text = "📊 Stok Bilgileri";
            this.tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.groupBoxStockStatus);
            this.panelDetails.Controls.Add(this.groupBoxWarehouse);
            this.panelDetails.Controls.Add(this.groupBoxProduct);
            this.panelDetails.Dock = DockStyle.Fill;
            this.panelDetails.Location = new Point(3, 3);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new Padding(10);
            this.panelDetails.Size = new Size(966, 552);
            this.panelDetails.TabIndex = 0;
            // 
            // groupBoxStockStatus
            // 
            this.groupBoxStockStatus.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.groupBoxStockStatus.Controls.Add(this.tableLayoutPanelStock);
            this.groupBoxStockStatus.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.groupBoxStockStatus.ForeColor = Color.FromArgb(59, 130, 246);
            this.groupBoxStockStatus.Location = new Point(10, 350);
            this.groupBoxStockStatus.Name = "groupBoxStockStatus";
            this.groupBoxStockStatus.Padding = new Padding(15);
            this.groupBoxStockStatus.Size = new Size(946, 180);
            this.groupBoxStockStatus.TabIndex = 2;
            this.groupBoxStockStatus.TabStop = false;
            this.groupBoxStockStatus.Text = "📈 Stok Durumu";
            // 
            // tableLayoutPanelStock
            // 
            this.tableLayoutPanelStock.ColumnCount = 4;
            this.tableLayoutPanelStock.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanelStock.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanelStock.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanelStock.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanelStock.Controls.Add(this.lblCurrentStock, 0, 0);
            this.tableLayoutPanelStock.Controls.Add(this.lblCurrentStockValue, 0, 1);
            this.tableLayoutPanelStock.Controls.Add(this.lblReservedStock, 1, 0);
            this.tableLayoutPanelStock.Controls.Add(this.lblReservedStockValue, 1, 1);
            this.tableLayoutPanelStock.Controls.Add(this.lblAvailableStock, 2, 0);
            this.tableLayoutPanelStock.Controls.Add(this.lblAvailableStockValue, 2, 1);
            this.tableLayoutPanelStock.Controls.Add(this.lblMinStock, 3, 0);
            this.tableLayoutPanelStock.Controls.Add(this.lblMinStockValue, 3, 1);
            this.tableLayoutPanelStock.Controls.Add(this.lblStockStatus, 0, 2);
            this.tableLayoutPanelStock.Dock = DockStyle.Fill;
            this.tableLayoutPanelStock.Font = new Font("Segoe UI", 9F);
            this.tableLayoutPanelStock.Location = new Point(15, 29);
            this.tableLayoutPanelStock.Name = "tableLayoutPanelStock";
            this.tableLayoutPanelStock.RowCount = 3;
            this.tableLayoutPanelStock.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanelStock.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tableLayoutPanelStock.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanelStock.Size = new Size(916, 136);
            this.tableLayoutPanelStock.TabIndex = 0;
            // 
            // lblCurrentStock
            // 
            this.lblCurrentStock.AutoSize = true;
            this.lblCurrentStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCurrentStock.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblCurrentStock.Location = new Point(3, 0);
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new Size(82, 15);
            this.lblCurrentStock.TabIndex = 0;
            this.lblCurrentStock.Text = "Mevcut Stok:";
            // 
            // lblCurrentStockValue
            // 
            this.lblCurrentStockValue.AutoSize = true;
            this.lblCurrentStockValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblCurrentStockValue.ForeColor = Color.FromArgb(34, 197, 94);
            this.lblCurrentStockValue.Location = new Point(3, 30);
            this.lblCurrentStockValue.Name = "lblCurrentStockValue";
            this.lblCurrentStockValue.Size = new Size(83, 25);
            this.lblCurrentStockValue.TabIndex = 1;
            this.lblCurrentStockValue.Text = "620.00";
            // 
            // lblReservedStock
            // 
            this.lblReservedStock.AutoSize = true;
            this.lblReservedStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblReservedStock.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblReservedStock.Location = new Point(232, 0);
            this.lblReservedStock.Name = "lblReservedStock";
            this.lblReservedStock.Size = new Size(83, 15);
            this.lblReservedStock.TabIndex = 2;
            this.lblReservedStock.Text = "Rezerve Stok:";
            // 
            // lblReservedStockValue
            // 
            this.lblReservedStockValue.AutoSize = true;
            this.lblReservedStockValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblReservedStockValue.ForeColor = Color.FromArgb(59, 130, 246);
            this.lblReservedStockValue.Location = new Point(232, 30);
            this.lblReservedStockValue.Name = "lblReservedStockValue";
            this.lblReservedStockValue.Size = new Size(83, 25);
            this.lblReservedStockValue.TabIndex = 3;
            this.lblReservedStockValue.Text = "100.00";
            // 
            // lblAvailableStock
            // 
            this.lblAvailableStock.AutoSize = true;
            this.lblAvailableStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblAvailableStock.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblAvailableStock.Location = new Point(461, 0);
            this.lblAvailableStock.Name = "lblAvailableStock";
            this.lblAvailableStock.Size = new Size(106, 15);
            this.lblAvailableStock.TabIndex = 4;
            this.lblAvailableStock.Text = "Kullanılabilir Stok:";
            // 
            // lblAvailableStockValue
            // 
            this.lblAvailableStockValue.AutoSize = true;
            this.lblAvailableStockValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblAvailableStockValue.ForeColor = Color.FromArgb(34, 197, 94);
            this.lblAvailableStockValue.Location = new Point(461, 30);
            this.lblAvailableStockValue.Name = "lblAvailableStockValue";
            this.lblAvailableStockValue.Size = new Size(83, 25);
            this.lblAvailableStockValue.TabIndex = 5;
            this.lblAvailableStockValue.Text = "520.00";
            // 
            // lblMinStock
            // 
            this.lblMinStock.AutoSize = true;
            this.lblMinStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblMinStock.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblMinStock.Location = new Point(690, 0);
            this.lblMinStock.Name = "lblMinStock";
            this.lblMinStock.Size = new Size(92, 15);
            this.lblMinStock.TabIndex = 6;
            this.lblMinStock.Text = "Minimum Stok:";
            // 
            // lblMinStockValue
            // 
            this.lblMinStockValue.AutoSize = true;
            this.lblMinStockValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblMinStockValue.ForeColor = Color.FromArgb(239, 68, 68);
            this.lblMinStockValue.Location = new Point(690, 30);
            this.lblMinStockValue.Name = "lblMinStockValue";
            this.lblMinStockValue.Size = new Size(70, 25);
            this.lblMinStockValue.TabIndex = 7;
            this.lblMinStockValue.Text = "40.00";
            // 
            // lblStockStatus
            // 
            this.lblStockStatus.AutoSize = true;
            this.tableLayoutPanelStock.SetColumnSpan(this.lblStockStatus, 4);
            this.lblStockStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblStockStatus.ForeColor = Color.FromArgb(34, 197, 94);
            this.lblStockStatus.Location = new Point(3, 70);
            this.lblStockStatus.Name = "lblStockStatus";
            this.lblStockStatus.Size = new Size(203, 21);
            this.lblStockStatus.TabIndex = 8;
            this.lblStockStatus.Text = "✅ Stok Durumu Normal";
            // 
            // groupBoxWarehouse
            // 
            this.groupBoxWarehouse.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.groupBoxWarehouse.Controls.Add(this.tableLayoutPanelWarehouse);
            this.groupBoxWarehouse.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.groupBoxWarehouse.ForeColor = Color.FromArgb(16, 185, 129);
            this.groupBoxWarehouse.Location = new Point(10, 180);
            this.groupBoxWarehouse.Name = "groupBoxWarehouse";
            this.groupBoxWarehouse.Padding = new Padding(15);
            this.groupBoxWarehouse.Size = new Size(946, 160);
            this.groupBoxWarehouse.TabIndex = 1;
            this.groupBoxWarehouse.TabStop = false;
            this.groupBoxWarehouse.Text = "🏢 Depo Bilgileri";
            // 
            // tableLayoutPanelWarehouse
            // 
            this.tableLayoutPanelWarehouse.ColumnCount = 2;
            this.tableLayoutPanelWarehouse.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelWarehouse.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelWarehouse.Controls.Add(this.lblWarehouseCode, 0, 0);
            this.tableLayoutPanelWarehouse.Controls.Add(this.lblWarehouseCodeValue, 0, 1);
            this.tableLayoutPanelWarehouse.Controls.Add(this.lblWarehouseName, 1, 0);
            this.tableLayoutPanelWarehouse.Controls.Add(this.lblWarehouseNameValue, 1, 1);
            this.tableLayoutPanelWarehouse.Controls.Add(this.lblLocation, 0, 2);
            this.tableLayoutPanelWarehouse.Controls.Add(this.lblLocationValue, 0, 3);
            this.tableLayoutPanelWarehouse.Controls.Add(this.lblLastUpdate, 1, 2);
            this.tableLayoutPanelWarehouse.Controls.Add(this.lblLastUpdateValue, 1, 3);
            this.tableLayoutPanelWarehouse.Dock = DockStyle.Fill;
            this.tableLayoutPanelWarehouse.Font = new Font("Segoe UI", 9F);
            this.tableLayoutPanelWarehouse.Location = new Point(15, 29);
            this.tableLayoutPanelWarehouse.Name = "tableLayoutPanelWarehouse";
            this.tableLayoutPanelWarehouse.RowCount = 4;
            this.tableLayoutPanelWarehouse.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            this.tableLayoutPanelWarehouse.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanelWarehouse.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            this.tableLayoutPanelWarehouse.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanelWarehouse.Size = new Size(916, 116);
            this.tableLayoutPanelWarehouse.TabIndex = 0;
            // 
            // lblWarehouseCode
            // 
            this.lblWarehouseCode.AutoSize = true;
            this.lblWarehouseCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblWarehouseCode.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblWarehouseCode.Location = new Point(3, 0);
            this.lblWarehouseCode.Name = "lblWarehouseCode";
            this.lblWarehouseCode.Size = new Size(76, 15);
            this.lblWarehouseCode.TabIndex = 0;
            this.lblWarehouseCode.Text = "Depo Kodu:";
            // 
            // lblWarehouseCodeValue
            // 
            this.lblWarehouseCodeValue.AutoSize = true;
            this.lblWarehouseCodeValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblWarehouseCodeValue.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblWarehouseCodeValue.Location = new Point(3, 25);
            this.lblWarehouseCodeValue.Name = "lblWarehouseCodeValue";
            this.lblWarehouseCodeValue.Size = new Size(40, 20);
            this.lblWarehouseCodeValue.TabIndex = 1;
            this.lblWarehouseCodeValue.Text = "ANA";
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.AutoSize = true;
            this.lblWarehouseName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblWarehouseName.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblWarehouseName.Location = new Point(461, 0);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.Size = new Size(66, 15);
            this.lblWarehouseName.TabIndex = 2;
            this.lblWarehouseName.Text = "Depo Adı:";
            // 
            // lblWarehouseNameValue
            // 
            this.lblWarehouseNameValue.AutoSize = true;
            this.lblWarehouseNameValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblWarehouseNameValue.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblWarehouseNameValue.Location = new Point(461, 25);
            this.lblWarehouseNameValue.Name = "lblWarehouseNameValue";
            this.lblWarehouseNameValue.Size = new Size(76, 20);
            this.lblWarehouseNameValue.TabIndex = 3;
            this.lblWarehouseNameValue.Text = "Ana Depo";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblLocation.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblLocation.Location = new Point(3, 55);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new Size(64, 15);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "Lokasyon:";
            // 
            // lblLocationValue
            // 
            this.lblLocationValue.AutoSize = true;
            this.lblLocationValue.Font = new Font("Segoe UI", 10F);
            this.lblLocationValue.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblLocationValue.Location = new Point(3, 80);
            this.lblLocationValue.Name = "lblLocationValue";
            this.lblLocationValue.Size = new Size(13, 19);
            this.lblLocationValue.TabIndex = 5;
            this.lblLocationValue.Text = "-";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblLastUpdate.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblLastUpdate.Location = new Point(461, 55);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new Size(77, 15);
            this.lblLastUpdate.TabIndex = 6;
            this.lblLastUpdate.Text = "Güncelleme:";
            // 
            // lblLastUpdateValue
            // 
            this.lblLastUpdateValue.AutoSize = true;
            this.lblLastUpdateValue.Font = new Font("Segoe UI", 10F);
            this.lblLastUpdateValue.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblLastUpdateValue.Location = new Point(461, 80);
            this.lblLastUpdateValue.Name = "lblLastUpdateValue";
            this.lblLastUpdateValue.Size = new Size(130, 19);
            this.lblLastUpdateValue.TabIndex = 7;
            this.lblLastUpdateValue.Text = "01.01.0001 00:00";
            // 
            // groupBoxProduct
            // 
            this.groupBoxProduct.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.groupBoxProduct.Controls.Add(this.tableLayoutPanelProduct);
            this.groupBoxProduct.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.groupBoxProduct.ForeColor = Color.FromArgb(168, 85, 247);
            this.groupBoxProduct.Location = new Point(10, 10);
            this.groupBoxProduct.Name = "groupBoxProduct";
            this.groupBoxProduct.Padding = new Padding(15);
            this.groupBoxProduct.Size = new Size(946, 160);
            this.groupBoxProduct.TabIndex = 0;
            this.groupBoxProduct.TabStop = false;
            this.groupBoxProduct.Text = "📦 Ürün Bilgileri";
            // 
            // tableLayoutPanelProduct
            // 
            this.tableLayoutPanelProduct.ColumnCount = 2;
            this.tableLayoutPanelProduct.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelProduct.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelProduct.Controls.Add(this.lblProductCode, 0, 0);
            this.tableLayoutPanelProduct.Controls.Add(this.lblProductCodeValue, 0, 1);
            this.tableLayoutPanelProduct.Controls.Add(this.lblProductName, 1, 0);
            this.tableLayoutPanelProduct.Controls.Add(this.lblProductNameValue, 1, 1);
            this.tableLayoutPanelProduct.Controls.Add(this.lblCategory, 0, 2);
            this.tableLayoutPanelProduct.Controls.Add(this.lblCategoryValue, 0, 3);
            this.tableLayoutPanelProduct.Controls.Add(this.lblUnit, 1, 2);
            this.tableLayoutPanelProduct.Controls.Add(this.lblUnitValue, 1, 3);
            this.tableLayoutPanelProduct.Dock = DockStyle.Fill;
            this.tableLayoutPanelProduct.Font = new Font("Segoe UI", 9F);
            this.tableLayoutPanelProduct.Location = new Point(15, 29);
            this.tableLayoutPanelProduct.Name = "tableLayoutPanelProduct";
            this.tableLayoutPanelProduct.RowCount = 4;
            this.tableLayoutPanelProduct.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            this.tableLayoutPanelProduct.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanelProduct.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            this.tableLayoutPanelProduct.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanelProduct.Size = new Size(916, 116);
            this.tableLayoutPanelProduct.TabIndex = 0;
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblProductCode.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblProductCode.Location = new Point(3, 0);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new Size(74, 15);
            this.lblProductCode.TabIndex = 0;
            this.lblProductCode.Text = "Ürün Kodu:";
            // 
            // lblProductCodeValue
            // 
            this.lblProductCodeValue.AutoSize = true;
            this.lblProductCodeValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblProductCodeValue.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblProductCodeValue.Location = new Point(3, 25);
            this.lblProductCodeValue.Name = "lblProductCodeValue";
            this.lblProductCodeValue.Size = new Size(68, 20);
            this.lblProductCodeValue.TabIndex = 1;
            this.lblProductCodeValue.Text = "CAY001";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblProductName.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblProductName.Location = new Point(461, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new Size(63, 15);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Ürün Adı:";
            // 
            // lblProductNameValue
            // 
            this.lblProductNameValue.AutoSize = true;
            this.lblProductNameValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblProductNameValue.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblProductNameValue.Location = new Point(461, 25);
            this.lblProductNameValue.Name = "lblProductNameValue";
            this.lblProductNameValue.Size = new Size(198, 20);
            this.lblProductNameValue.TabIndex = 3;
            this.lblProductNameValue.Text = "Bergamot Aromalı Çay 25li";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCategory.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblCategory.Location = new Point(3, 55);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new Size(61, 15);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Kategori:";
            // 
            // lblCategoryValue
            // 
            this.lblCategoryValue.AutoSize = true;
            this.lblCategoryValue.Font = new Font("Segoe UI", 10F);
            this.lblCategoryValue.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblCategoryValue.Location = new Point(3, 80);
            this.lblCategoryValue.Name = "lblCategoryValue";
            this.lblCategoryValue.Size = new Size(13, 19);
            this.lblCategoryValue.TabIndex = 5;
            this.lblCategoryValue.Text = "-";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblUnit.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblUnit.Location = new Point(461, 55);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new Size(40, 15);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "Birim:";
            // 
            // lblUnitValue
            // 
            this.lblUnitValue.AutoSize = true;
            this.lblUnitValue.Font = new Font("Segoe UI", 10F);
            this.lblUnitValue.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblUnitValue.Location = new Point(461, 80);
            this.lblUnitValue.Name = "lblUnitValue";
            this.lblUnitValue.Size = new Size(37, 19);
            this.lblUnitValue.TabIndex = 7;
            this.lblUnitValue.Text = "Adet";
            // 
            // tabPageTransactions
            // 
            this.tabPageTransactions.Controls.Add(this.dgvStockTransactions);
            this.tabPageTransactions.Location = new Point(4, 28);
            this.tabPageTransactions.Name = "tabPageTransactions";
            this.tabPageTransactions.Padding = new Padding(3);
            this.tabPageTransactions.Size = new Size(972, 558);
            this.tabPageTransactions.TabIndex = 1;
            this.tabPageTransactions.Text = "🔄 Son Stok Hareketleri";
            this.tabPageTransactions.UseVisualStyleBackColor = true;
            // 
            // dgvStockTransactions
            // 
            this.dgvStockTransactions.AllowUserToAddRows = false;
            this.dgvStockTransactions.AllowUserToDeleteRows = false;
            this.dgvStockTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockTransactions.BackgroundColor = Color.White;
            this.dgvStockTransactions.BorderStyle = BorderStyle.None;
            this.dgvStockTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockTransactions.Columns.AddRange(new DataGridViewColumn[] {
            this.colTransactionDate,
            this.colTransactionType,
            this.colDocumentNumber,
            this.colQuantity,
            this.colUnitPrice,
            this.colRemainingStock});
            this.dgvStockTransactions.Dock = DockStyle.Fill;
            this.dgvStockTransactions.GridColor = Color.FromArgb(229, 231, 235);
            this.dgvStockTransactions.Location = new Point(3, 3);
            this.dgvStockTransactions.Name = "dgvStockTransactions";
            this.dgvStockTransactions.ReadOnly = true;
            this.dgvStockTransactions.RowHeadersVisible = false;
            this.dgvStockTransactions.RowTemplate.Height = 25;
            this.dgvStockTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockTransactions.Size = new Size(966, 552);
            this.dgvStockTransactions.TabIndex = 0;
            // 
            // colTransactionDate
            // 
            this.colTransactionDate.DataPropertyName = "TransactionDate";
            this.colTransactionDate.FillWeight = 120F;
            this.colTransactionDate.HeaderText = "Tarih";
            this.colTransactionDate.Name = "colTransactionDate";
            this.colTransactionDate.ReadOnly = true;
            // 
            // colTransactionType
            // 
            this.colTransactionType.DataPropertyName = "TransactionType";
            this.colTransactionType.FillWeight = 100F;
            this.colTransactionType.HeaderText = "Hareket Türü";
            this.colTransactionType.Name = "colTransactionType";
            this.colTransactionType.ReadOnly = true;
            // 
            // colDocumentNumber
            // 
            this.colDocumentNumber.DataPropertyName = "DocumentNumber";
            this.colDocumentNumber.FillWeight = 120F;
            this.colDocumentNumber.HeaderText = "Belge No";
            this.colDocumentNumber.Name = "colDocumentNumber";
            this.colDocumentNumber.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.FillWeight = 80F;
            this.colQuantity.HeaderText = "Miktar";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.FillWeight = 80F;
            this.colUnitPrice.HeaderText = "Birim Fiyat";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // colRemainingStock
            // 
            this.colRemainingStock.DataPropertyName = "RemainingStock";
            this.colRemainingStock.FillWeight = 80F;
            this.colRemainingStock.HeaderText = "Kalan Stok";
            this.colRemainingStock.Name = "colRemainingStock";
            this.colRemainingStock.ReadOnly = true;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.panelButtons);
            this.panelHeader.Controls.Add(this.panelTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(10, 10);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(980, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.lblLastTransaction);
            this.panelButtons.Controls.Add(this.lblLastTransactionValue);
            this.panelButtons.Controls.Add(this.btnYazdir);
            this.panelButtons.Controls.Add(this.btnStokCikisi);
            this.panelButtons.Controls.Add(this.btnStokGirisi);
            this.panelButtons.Controls.Add(this.btnDuzenle);
            this.panelButtons.Controls.Add(this.btnKapat);
            this.panelButtons.Dock = DockStyle.Right;
            this.panelButtons.Location = new Point(400, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(580, 70);
            this.panelButtons.TabIndex = 1;
            // 
            // lblLastTransaction
            // 
            this.lblLastTransaction.AutoSize = true;
            this.lblLastTransaction.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblLastTransaction.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblLastTransaction.Location = new Point(10, 10);
            this.lblLastTransaction.Name = "lblLastTransaction";
            this.lblLastTransaction.Size = new Size(72, 15);
            this.lblLastTransaction.TabIndex = 8;
            this.lblLastTransaction.Text = "Son İşlem:";
            // 
            // lblLastTransactionValue
            // 
            this.lblLastTransactionValue.AutoSize = true;
            this.lblLastTransactionValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblLastTransactionValue.ForeColor = Color.FromArgb(59, 130, 246);
            this.lblLastTransactionValue.Location = new Point(10, 30);
            this.lblLastTransactionValue.Name = "lblLastTransactionValue";
            this.lblLastTransactionValue.Size = new Size(130, 19);
            this.lblLastTransactionValue.TabIndex = 7;
            this.lblLastTransactionValue.Text = "01.01.0001 00:00";
            // 
            // btnYazdir
            // 
            this.btnYazdir.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnYazdir.BackColor = Color.FromArgb(107, 114, 128);
            this.btnYazdir.FlatAppearance.BorderSize = 0;
            this.btnYazdir.FlatStyle = FlatStyle.Flat;
            this.btnYazdir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnYazdir.ForeColor = Color.White;
            this.btnYazdir.Location = new Point(190, 35);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new Size(80, 30);
            this.btnYazdir.TabIndex = 6;
            this.btnYazdir.Text = "📄 Yazdır";
            this.btnYazdir.UseVisualStyleBackColor = false;
            this.btnYazdir.Click += new EventHandler(this.BtnYazdir_Click);
            // 
            // btnStokCikisi
            // 
            this.btnStokCikisi.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnStokCikisi.BackColor = Color.FromArgb(239, 68, 68);
            this.btnStokCikisi.FlatAppearance.BorderSize = 0;
            this.btnStokCikisi.FlatStyle = FlatStyle.Flat;
            this.btnStokCikisi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnStokCikisi.ForeColor = Color.White;
            this.btnStokCikisi.Location = new Point(280, 35);
            this.btnStokCikisi.Name = "btnStokCikisi";
            this.btnStokCikisi.Size = new Size(90, 30);
            this.btnStokCikisi.TabIndex = 5;
            this.btnStokCikisi.Text = "📤 Çıkış";
            this.btnStokCikisi.UseVisualStyleBackColor = false;
            this.btnStokCikisi.Click += new EventHandler(this.BtnStokCikisi_Click);
            // 
            // btnStokGirisi
            // 
            this.btnStokGirisi.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnStokGirisi.BackColor = Color.FromArgb(34, 197, 94);
            this.btnStokGirisi.FlatAppearance.BorderSize = 0;
            this.btnStokGirisi.FlatStyle = FlatStyle.Flat;
            this.btnStokGirisi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnStokGirisi.ForeColor = Color.White;
            this.btnStokGirisi.Location = new Point(380, 35);
            this.btnStokGirisi.Name = "btnStokGirisi";
            this.btnStokGirisi.Size = new Size(90, 30);
            this.btnStokGirisi.TabIndex = 4;
            this.btnStokGirisi.Text = "📥 Giriş";
            this.btnStokGirisi.UseVisualStyleBackColor = false;
            this.btnStokGirisi.Click += new EventHandler(this.BtnStokGirisi_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnDuzenle.BackColor = Color.FromArgb(59, 130, 246);
            this.btnDuzenle.FlatAppearance.BorderSize = 0;
            this.btnDuzenle.FlatStyle = FlatStyle.Flat;
            this.btnDuzenle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDuzenle.ForeColor = Color.White;
            this.btnDuzenle.Location = new Point(480, 35);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new Size(90, 30);
            this.btnDuzenle.TabIndex = 3;
            this.btnDuzenle.Text = "✏️ Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Click += new EventHandler(this.BtnDuzenle_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnKapat.BackColor = Color.FromArgb(107, 114, 128);
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(580, 35);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(70, 30);
            this.btnKapat.TabIndex = 2;
            this.btnKapat.Text = "❌ Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new EventHandler(this.BtnKapat_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.lblStockTitle);
            this.panelTitle.Dock = DockStyle.Left;
            this.panelTitle.Location = new Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new Size(400, 70);
            this.panelTitle.TabIndex = 0;
            // 
            // lblStockTitle
            // 
            this.lblStockTitle.AutoSize = true;
            this.lblStockTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblStockTitle.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblStockTitle.Location = new Point(0, 20);
            this.lblStockTitle.Name = "lblStockTitle";
            this.lblStockTitle.Size = new Size(389, 30);
            this.lblStockTitle.TabIndex = 0;
            this.lblStockTitle.Text = "📦 CAY001 - Bergamot Aromalı Çay";
            // 
            // panelStatus
            // 
            this.panelStatus.Controls.Add(this.lblDurum);
            this.panelStatus.Dock = DockStyle.Bottom;
            this.panelStatus.Location = new Point(10, 670);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new Size(980, 20);
            this.panelStatus.TabIndex = 2;
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblDurum.Location = new Point(0, 2);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new Size(42, 15);
            this.lblDurum.TabIndex = 0;
            this.lblDurum.Text = "Hazır...";
            // 
            // StokDetayForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(249, 250, 251);
            this.ClientSize = new Size(1000, 700);
            this.Controls.Add(this.panelMain);
            this.Name = "StokDetayForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Stok Kartı Detayı";
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageDetails.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.groupBoxStockStatus.ResumeLayout(false);
            this.tableLayoutPanelStock.ResumeLayout(false);
            this.tableLayoutPanelStock.PerformLayout();
            this.groupBoxWarehouse.ResumeLayout(false);
            this.tableLayoutPanelWarehouse.ResumeLayout(false);
            this.tableLayoutPanelWarehouse.PerformLayout();
            this.groupBoxProduct.ResumeLayout(false);
            this.tableLayoutPanelProduct.ResumeLayout(false);
            this.tableLayoutPanelProduct.PerformLayout();
            this.tabPageTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockTransactions)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelContent;
        private TabControl tabControl;
        private TabPage tabPageDetails;
        private Panel panelDetails;
        private GroupBox groupBoxStockStatus;
        private TableLayoutPanel tableLayoutPanelStock;
        private Label lblCurrentStock;
        private Label lblCurrentStockValue;
        private Label lblReservedStock;
        private Label lblReservedStockValue;
        private Label lblAvailableStock;
        private Label lblAvailableStockValue;
        private Label lblMinStock;
        private Label lblMinStockValue;
        private Label lblStockStatus;
        private GroupBox groupBoxWarehouse;
        private TableLayoutPanel tableLayoutPanelWarehouse;
        private Label lblWarehouseCode;
        private Label lblWarehouseCodeValue;
        private Label lblWarehouseName;
        private Label lblWarehouseNameValue;
        private Label lblLocation;
        private Label lblLocationValue;
        private Label lblLastUpdate;
        private Label lblLastUpdateValue;
        private GroupBox groupBoxProduct;
        private TableLayoutPanel tableLayoutPanelProduct;
        private Label lblProductCode;
        private Label lblProductCodeValue;
        private Label lblProductName;
        private Label lblProductNameValue;
        private Label lblCategory;
        private Label lblCategoryValue;
        private Label lblUnit;
        private Label lblUnitValue;
        private TabPage tabPageTransactions;
        private DataGridView dgvStockTransactions;
        private DataGridViewTextBoxColumn colTransactionDate;
        private DataGridViewTextBoxColumn colTransactionType;
        private DataGridViewTextBoxColumn colDocumentNumber;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colRemainingStock;
        private Panel panelHeader;
        private Panel panelButtons;
        private Label lblLastTransaction;
        private Label lblLastTransactionValue;
        private Button btnYazdir;
        private Button btnStokCikisi;
        private Button btnStokGirisi;
        private Button btnDuzenle;
        private Button btnKapat;
        private Panel panelTitle;
        private Label lblStockTitle;
        private Panel panelStatus;
        private Label lblDurum;
    }
}
