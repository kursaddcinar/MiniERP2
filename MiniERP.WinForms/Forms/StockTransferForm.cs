using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class StockTransferForm : Form
    {
        private readonly StockService _stockService;
        private readonly StockCardDto _sourceStock;
        private List<WarehouseDto> _warehouses = new List<WarehouseDto>();

        // UI Controls
        private Panel pnlTop;
        private Panel pnlInfo;
        private Panel pnlTransfer;
        private Panel pnlButtons;
        private Label lblTitle;
        private GroupBox gbSourceInfo;
        private Label lblSourceProduct;
        private Label lblSourceWarehouse;
        private Label lblCurrentStock;
        private TextBox txtSourceProduct;
        private TextBox txtSourceWarehouse;
        private TextBox txtCurrentStock;
        private GroupBox gbTransferInfo;
        private Label lblTargetWarehouse;
        private Label lblTransferQuantity;
        private Label lblNotes;
        private ComboBox cmbTargetWarehouse;
        private NumericUpDown nudTransferQuantity;
        private TextBox txtNotes;
        private Button btnTransfer;
        private Button btnCancel;

        public StockTransferForm(StockService stockService, StockCardDto sourceStock)
        {
            _stockService = stockService;
            _sourceStock = sourceStock;
            
            InitializeComponent();
            _ = LoadWarehousesAsync();
        }

        private void InitializeComponent()
        {
            this.Text = "Stok Transfer";
            this.Size = new Size(600, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Top panel
            pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.LightGray
            };

            lblTitle = new Label
            {
                Text = "Stok Transfer",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 15),
                Size = new Size(200, 25)
            };

            pnlTop.Controls.Add(lblTitle);

            // Info panel
            pnlInfo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 150,
                Padding = new Padding(20, 10, 20, 10)
            };

            // Source info group
            gbSourceInfo = new GroupBox
            {
                Text = "Kaynak Bilgileri",
                Location = new Point(10, 10),
                Size = new Size(540, 130)
            };

            lblSourceProduct = new Label { Text = "Ürün:", Location = new Point(20, 30), Size = new Size(80, 23) };
            txtSourceProduct = new TextBox { Location = new Point(105, 27), Size = new Size(400, 23), ReadOnly = true };

            lblSourceWarehouse = new Label { Text = "Kaynak Depo:", Location = new Point(20, 60), Size = new Size(80, 23) };
            txtSourceWarehouse = new TextBox { Location = new Point(105, 57), Size = new Size(200, 23), ReadOnly = true };

            lblCurrentStock = new Label { Text = "Mevcut Stok:", Location = new Point(320, 60), Size = new Size(80, 23) };
            txtCurrentStock = new TextBox { Location = new Point(405, 57), Size = new Size(100, 23), ReadOnly = true };

            gbSourceInfo.Controls.AddRange(new Control[] {
                lblSourceProduct, txtSourceProduct, lblSourceWarehouse, txtSourceWarehouse,
                lblCurrentStock, txtCurrentStock
            });

            pnlInfo.Controls.Add(gbSourceInfo);

            // Transfer panel
            pnlTransfer = new Panel
            {
                Dock = DockStyle.Top,
                Height = 200,
                Padding = new Padding(20, 10, 20, 10)
            };

            // Transfer info group
            gbTransferInfo = new GroupBox
            {
                Text = "Transfer Bilgileri",
                Location = new Point(10, 10),
                Size = new Size(540, 180)
            };

            lblTargetWarehouse = new Label { Text = "Hedef Depo:", Location = new Point(20, 30), Size = new Size(80, 23) };
            cmbTargetWarehouse = new ComboBox 
            { 
                Location = new Point(105, 27), 
                Size = new Size(200, 23), 
                DropDownStyle = ComboBoxStyle.DropDownList 
            };

            lblTransferQuantity = new Label { Text = "Transfer Miktarı:", Location = new Point(20, 70), Size = new Size(80, 23) };
            nudTransferQuantity = new NumericUpDown 
            { 
                Location = new Point(105, 67), 
                Size = new Size(120, 23),
                DecimalPlaces = 2,
                Minimum = 0.01m,
                Maximum = 999999m
            };

            lblNotes = new Label { Text = "Açıklama:", Location = new Point(20, 110), Size = new Size(80, 23) };
            txtNotes = new TextBox 
            { 
                Location = new Point(105, 107), 
                Size = new Size(400, 50), 
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            gbTransferInfo.Controls.AddRange(new Control[] {
                lblTargetWarehouse, cmbTargetWarehouse, lblTransferQuantity, nudTransferQuantity,
                lblNotes, txtNotes
            });

            pnlTransfer.Controls.Add(gbTransferInfo);

            // Buttons panel
            pnlButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                Padding = new Padding(20, 10, 20, 10)
            };

            btnTransfer = new Button
            {
                Text = "Transfer Yap",
                Location = new Point(350, 15),
                Size = new Size(100, 30),
                BackColor = Color.LightGreen
            };

            btnCancel = new Button
            {
                Text = "İptal",
                Location = new Point(460, 15),
                Size = new Size(80, 30),
                DialogResult = DialogResult.Cancel
            };

            pnlButtons.Controls.AddRange(new Control[] { btnTransfer, btnCancel });

            // Add all panels to form
            this.Controls.AddRange(new Control[] { pnlButtons, pnlTransfer, pnlInfo, pnlTop });

            // Set initial values
            LoadSourceInfo();

            // Event handlers
            btnTransfer.Click += BtnTransfer_Click;
            btnCancel.Click += BtnCancel_Click;
            cmbTargetWarehouse.SelectedIndexChanged += CmbTargetWarehouse_SelectedIndexChanged;
        }

        private void LoadSourceInfo()
        {
            txtSourceProduct.Text = $"{_sourceStock.ProductCode} - {_sourceStock.ProductName}";
            txtSourceWarehouse.Text = _sourceStock.WarehouseName;
            txtCurrentStock.Text = _sourceStock.CurrentStock.ToString("N2") + " " + _sourceStock.UnitName;
            nudTransferQuantity.Maximum = _sourceStock.CurrentStock;
        }

        private async Task LoadWarehousesAsync()
        {
            try
            {
                var response = await _stockService.GetWarehousesAsync();
                
                if (response.Success && response.Data != null)
                {
                    var allWarehouses = response.Data.Data ?? new List<WarehouseDto>();
                    _warehouses = allWarehouses.Where(w => w.WarehouseID != _sourceStock.WarehouseID).ToList();
                    
                    cmbTargetWarehouse.Items.Clear();
                    cmbTargetWarehouse.Items.Add(new { Text = "Seçiniz...", Value = -1 });
                    
                    foreach (var warehouse in _warehouses)
                    {
                        cmbTargetWarehouse.Items.Add(new { Text = warehouse.WarehouseName, Value = warehouse.WarehouseID });
                    }
                    
                    cmbTargetWarehouse.DisplayMember = "Text";
                    cmbTargetWarehouse.ValueMember = "Value";
                    cmbTargetWarehouse.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Depolar yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbTargetWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnTransfer.Enabled = cmbTargetWarehouse.SelectedValue != null && (int)cmbTargetWarehouse.SelectedValue != -1;
        }

        private async void BtnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                // Validations
                if (cmbTargetWarehouse.SelectedValue == null || (int)cmbTargetWarehouse.SelectedValue == -1)
                {
                    MessageBox.Show("Lütfen hedef depo seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nudTransferQuantity.Value <= 0)
                {
                    MessageBox.Show("Transfer miktarı 0'dan büyük olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nudTransferQuantity.Value > _sourceStock.CurrentStock)
                {
                    MessageBox.Show($"Transfer miktarı mevcut stoktan ({_sourceStock.CurrentStock:N2}) fazla olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var targetWarehouseId = (int)cmbTargetWarehouse.SelectedValue;
                var transferQuantity = nudTransferQuantity.Value;
                var notes = txtNotes.Text.Trim();

                var confirmMessage = $"Bu transfer işlemini onaylıyor musunuz?\n\n" +
                                   $"Ürün: {_sourceStock.ProductName}\n" +
                                   $"Kaynak Depo: {_sourceStock.WarehouseName}\n" +
                                   $"Hedef Depo: {((dynamic)cmbTargetWarehouse.SelectedItem).Text}\n" +
                                   $"Miktar: {transferQuantity:N2} {_sourceStock.UnitName}";

                var result = MessageBox.Show(confirmMessage, "Transfer Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    btnTransfer.Enabled = false;
                    btnTransfer.Text = "İşleniyor...";

                    // Çıkış hareketi (kaynak depodan)
                    var outTransaction = new CreateStockTransactionDto
                    {
                        ProductID = _sourceStock.ProductID,
                        WarehouseID = _sourceStock.WarehouseID,
                        TransactionType = "OUT",
                        Quantity = -transferQuantity,
                        UnitPrice = 0,
                        ReferenceType = "TRANSFER",
                        Notes = $"Transfer çıkış - Hedef: {((dynamic)cmbTargetWarehouse.SelectedItem).Text}. {notes}",
                        TransactionDate = DateTime.Now
                    };

                    var outResponse = await _stockService.CreateStockTransactionAsync(outTransaction);
                    
                    if (outResponse.Success)
                    {
                        // Giriş hareketi (hedef depoya)
                        var inTransaction = new CreateStockTransactionDto
                        {
                            ProductID = _sourceStock.ProductID,
                            WarehouseID = targetWarehouseId,
                            TransactionType = "IN",
                            Quantity = transferQuantity,
                            UnitPrice = 0,
                            ReferenceType = "TRANSFER",
                            Notes = $"Transfer giriş - Kaynak: {_sourceStock.WarehouseName}. {notes}",
                            TransactionDate = DateTime.Now
                        };

                        var inResponse = await _stockService.CreateStockTransactionAsync(inTransaction);
                        
                        if (inResponse.Success)
                        {
                            MessageBox.Show("Stok transfer işlemi başarıyla tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Giriş hareketi oluşturulamadı: {inResponse.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Çıkış hareketi oluşturulamadı: {outResponse.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Transfer işlemi sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTransfer.Enabled = true;
                btnTransfer.Text = "Transfer Yap";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
} 