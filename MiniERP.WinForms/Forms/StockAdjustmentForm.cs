using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class StockAdjustmentForm : Form
    {
        private readonly StockService _stockService;
        private readonly ProductService _productService;
        private readonly StockCardDto _stockCard;

        // UI Controls
        private Panel pnlMain;
        private GroupBox grpStockInfo;
        private GroupBox grpAdjustment;
        private Label lblProductCode;
        private Label lblProductName;
        private Label lblCurrentStock;
        private Label lblWarehouse;
        private TextBox txtProductCode;
        private TextBox txtProductName;
        private TextBox txtCurrentStock;
        private TextBox txtWarehouse;
        private Label lblAdjustmentType;
        private ComboBox cmbAdjustmentType;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblNewStock;
        private TextBox txtNewStock;
        private Label lblReason;
        private TextBox txtReason;
        private Button btnSave;
        private Button btnCancel;

        public StockAdjustmentForm(StockService stockService, ProductService productService, StockCardDto stockCard)
        {
            _stockService = stockService;
            _productService = productService;
            _stockCard = stockCard;
            
            InitializeComponent();
            LoadStockInfo();
        }

        private void InitializeComponent()
        {
            this.Text = "Stok Düzeltme";
            this.Size = new Size(500, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Main panel
            pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            // Stock info group
            grpStockInfo = new GroupBox
            {
                Text = "Stok Bilgileri",
                Location = new Point(10, 10),
                Size = new Size(460, 150)
            };

            lblProductCode = new Label { Text = "Ürün Kodu:", Location = new Point(15, 25), Size = new Size(80, 23) };
            txtProductCode = new TextBox { Location = new Point(100, 22), Size = new Size(120, 23), ReadOnly = true };

            lblProductName = new Label { Text = "Ürün Adı:", Location = new Point(15, 55), Size = new Size(80, 23) };
            txtProductName = new TextBox { Location = new Point(100, 52), Size = new Size(340, 23), ReadOnly = true };

            lblCurrentStock = new Label { Text = "Mevcut Stok:", Location = new Point(15, 85), Size = new Size(80, 23) };
            txtCurrentStock = new TextBox { Location = new Point(100, 82), Size = new Size(120, 23), ReadOnly = true };

            lblWarehouse = new Label { Text = "Depo:", Location = new Point(240, 85), Size = new Size(50, 23) };
            txtWarehouse = new TextBox { Location = new Point(295, 82), Size = new Size(145, 23), ReadOnly = true };

            // Adjustment group
            grpAdjustment = new GroupBox
            {
                Text = "Düzeltme Bilgileri",
                Location = new Point(10, 170),
                Size = new Size(460, 180)
            };

            lblAdjustmentType = new Label { Text = "Düzeltme Tipi:", Location = new Point(15, 25), Size = new Size(100, 23) };
            cmbAdjustmentType = new ComboBox 
            { 
                Location = new Point(120, 22), 
                Size = new Size(150, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbAdjustmentType.Items.AddRange(new string[] { "ARTTIR", "AZALT", "SIFIRLA" });
            cmbAdjustmentType.SelectedIndex = 0;

            lblQuantity = new Label { Text = "Miktar:", Location = new Point(15, 55), Size = new Size(100, 23) };
            numQuantity = new NumericUpDown 
            { 
                Location = new Point(120, 52), 
                Size = new Size(150, 23),
                DecimalPlaces = 2,
                Minimum = 0,
                Maximum = 999999,
                Value = 1
            };

            lblNewStock = new Label { Text = "Yeni Stok:", Location = new Point(15, 85), Size = new Size(100, 23) };
            txtNewStock = new TextBox { Location = new Point(120, 82), Size = new Size(150, 23), ReadOnly = true };

            lblReason = new Label { Text = "Açıklama:", Location = new Point(15, 115), Size = new Size(100, 23) };
            txtReason = new TextBox 
            { 
                Location = new Point(120, 112), 
                Size = new Size(320, 50),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            // Buttons
            btnSave = new Button
            {
                Text = "Kaydet",
                Location = new Point(300, 360),
                Size = new Size(80, 30)
            };

            btnCancel = new Button
            {
                Text = "İptal",
                Location = new Point(390, 360),
                Size = new Size(80, 30)
            };

            // Add controls
            grpStockInfo.Controls.AddRange(new Control[] {
                lblProductCode, txtProductCode, lblProductName, txtProductName,
                lblCurrentStock, txtCurrentStock, lblWarehouse, txtWarehouse
            });

            grpAdjustment.Controls.AddRange(new Control[] {
                lblAdjustmentType, cmbAdjustmentType, lblQuantity, numQuantity,
                lblNewStock, txtNewStock, lblReason, txtReason
            });

            pnlMain.Controls.AddRange(new Control[] { grpStockInfo, grpAdjustment, btnSave, btnCancel });
            this.Controls.Add(pnlMain);

            // Event handlers
            cmbAdjustmentType.SelectedIndexChanged += CmbAdjustmentType_SelectedIndexChanged;
            numQuantity.ValueChanged += NumQuantity_ValueChanged;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void LoadStockInfo()
        {
            txtProductCode.Text = _stockCard.ProductCode;
            txtProductName.Text = _stockCard.ProductName;
            txtCurrentStock.Text = _stockCard.CurrentStock.ToString("N2");
            txtWarehouse.Text = _stockCard.WarehouseName;
            
            CalculateNewStock();
        }

        private void CmbAdjustmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateNewStock();
        }

        private void NumQuantity_ValueChanged(object sender, EventArgs e)
        {
            CalculateNewStock();
        }

        private void CalculateNewStock()
        {
            decimal currentStock = _stockCard.CurrentStock;
            decimal quantity = numQuantity.Value;
            decimal newStock = currentStock;

            switch (cmbAdjustmentType.Text)
            {
                case "ARTTIR":
                    newStock = currentStock + quantity;
                    break;
                case "AZALT":
                    newStock = Math.Max(0, currentStock - quantity);
                    break;
                case "SIFIRLA":
                    newStock = 0;
                    break;
            }

            txtNewStock.Text = newStock.ToString("N2");
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Lütfen düzeltme açıklaması giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReason.Focus();
                return;
            }

            try
            {
                btnSave.Enabled = false;
                btnSave.Text = "Kaydediliyor...";

                decimal adjustmentQuantity = 0;
                switch (cmbAdjustmentType.Text)
                {
                    case "ARTTIR":
                        adjustmentQuantity = numQuantity.Value;
                        break;
                    case "AZALT":
                        adjustmentQuantity = -numQuantity.Value;
                        break;
                    case "SIFIRLA":
                        adjustmentQuantity = -_stockCard.CurrentStock;
                        break;
                }

                var response = await _stockService.AdjustStockAsync(
                    _stockCard.ProductID,
                    _stockCard.WarehouseID,
                    adjustmentQuantity,
                    cmbAdjustmentType.Text,
                    txtReason.Text.Trim());

                if (response.Success)
                {
                    MessageBox.Show("Stok düzeltmesi başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show($"Hata: {response.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "Kaydet";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }


} 