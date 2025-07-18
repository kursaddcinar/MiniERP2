using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System.ComponentModel;

namespace MiniERP.WinForms.Forms
{
    public partial class StokGuncelleForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private List<StockCardDto> _stockCards = new();
        private BindingList<StockUpdateItem> _updateItems = new();

        public StokGuncelleForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            SetupForm();
            LoadStockCards();
        }

        private void SetupForm()
        {
            this.Text = "Stok Güncelle";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // DataGridView ayarları
            dgvStockUpdates.AutoGenerateColumns = false;
            dgvStockUpdates.AllowUserToAddRows = false;
            dgvStockUpdates.AllowUserToDeleteRows = false;
            dgvStockUpdates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStockUpdates.MultiSelect = false;
            dgvStockUpdates.DataSource = _updateItems;

            // Event handlers
            btnEkle.Click += BtnEkle_Click;
            btnCikar.Click += BtnCikar_Click;
            btnKaydet.Click += BtnKaydet_Click;
            btnIptal.Click += BtnIptal_Click;
            cmbStockCard.SelectedIndexChanged += CmbStockCard_SelectedIndexChanged;
        }

        private async void LoadStockCards()
        {
            try
            {
                var response = await _apiService.GetAsync<PagedResult<StockCardDto>>("Stock/cards?PageNumber=1&PageSize=1000");
                if (response != null && response.Success && response.Data != null)
                {
                    _stockCards = response.Data.Data.ToList();
                    cmbStockCard.DataSource = _stockCards;
                    cmbStockCard.DisplayMember = "ProductName";
                    cmbStockCard.ValueMember = "StockCardID";
                    cmbStockCard.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Stok kartları yüklenemedi. API bağlantısını kontrol edin.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok kartları yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbStockCard_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbStockCard.SelectedItem is StockCardDto selected)
            {
                lblMevcutStok.Text = $"Mevcut: {selected.CurrentStock} {selected.UnitName}";
                lblUrunBilgi.Text = $"{selected.ProductCode} - {selected.WarehouseName}";
            }
        }

        private void BtnEkle_Click(object? sender, EventArgs e)
        {
            if (cmbStockCard.SelectedItem is StockCardDto selected && numMiktar.Value != 0)
            {
                var item = new StockUpdateItem
                {
                    StockCardID = selected.StockCardID,
                    ProductName = selected.ProductName,
                    WarehouseName = selected.WarehouseName,
                    CurrentStock = selected.CurrentStock,
                    UpdateQuantity = numMiktar.Value,
                    NewStock = selected.CurrentStock + numMiktar.Value,
                    UpdateType = numMiktar.Value > 0 ? "Giriş" : "Çıkış"
                };

                _updateItems.Add(item);
                numMiktar.Value = 0;
                cmbStockCard.SelectedIndex = -1;
            }
        }

        private void BtnCikar_Click(object? sender, EventArgs e)
        {
            if (dgvStockUpdates.SelectedRows.Count > 0)
            {
                var selectedIndex = dgvStockUpdates.SelectedRows[0].Index;
                _updateItems.RemoveAt(selectedIndex);
            }
        }

        private async void BtnKaydet_Click(object? sender, EventArgs e)
        {
            if (_updateItems.Count == 0)
            {
                MessageBox.Show("Güncellenecek stok bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnKaydet.Enabled = false;
                
                foreach (var item in _updateItems)
                {
                    var transaction = new CreateStockTransactionDto
                    {
                        ProductID = _stockCards.First(x => x.StockCardID == item.StockCardID).ProductID,
                        WarehouseID = _stockCards.First(x => x.StockCardID == item.StockCardID).WarehouseID,
                        TransactionDate = DateTime.Now,
                        TransactionType = item.UpdateQuantity > 0 ? "GIRIS" : "CIKIS",
                        Quantity = Math.Abs(item.UpdateQuantity),
                        Description = "Toplu stok güncelleme"
                    };

                    await _apiService.PostAsync<object>("api/Stock/transactions", transaction);
                }

                MessageBox.Show("Stok güncellemeleri başarıyla kaydedildi.", "Başarılı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok güncellenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnKaydet.Enabled = true;
            }
        }

        private void BtnIptal_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    public class StockUpdateItem
    {
        public int StockCardID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;
        public decimal CurrentStock { get; set; }
        public decimal UpdateQuantity { get; set; }
        public decimal NewStock { get; set; }
        public string UpdateType { get; set; } = string.Empty;
    }
}


