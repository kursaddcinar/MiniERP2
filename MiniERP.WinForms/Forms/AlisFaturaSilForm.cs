using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class AlisFaturaSilForm : Form
    {
        private readonly ApiService _apiService;
        private readonly UserDto _currentUser;
        private readonly PurchaseInvoiceDto _invoice;

        public AlisFaturaSilForm(UserDto currentUser, ApiService apiService, PurchaseInvoiceDto invoice)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            _invoice = invoice;

            InitializeForm();
            LoadInvoiceData();
        }

        private void InitializeForm()
        {
            this.Text = $"Alış Faturası Sil - {_invoice.InvoiceNo}";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(900, 700);
            
            // Disable delete button initially
            btnSil.Enabled = false;
            
            // Setup DataGridView
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dataGridViewKalemler.Columns.Clear();
            dataGridViewKalemler.AutoGenerateColumns = false;
            dataGridViewKalemler.AllowUserToAddRows = false;
            dataGridViewKalemler.AllowUserToDeleteRows = false;
            dataGridViewKalemler.ReadOnly = true;

            // Ürün Column
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Urun",
                HeaderText = "Ürün",
                Width = 300,
                DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True }
            });

            // Miktar Column
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Miktar",
                HeaderText = "Miktar",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Format = "N2", 
                    Alignment = DataGridViewContentAlignment.MiddleRight 
                }
            });

            // Birim Fiyat Column
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BirimFiyat",
                HeaderText = "Birim Fiyat",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Format = "C2", 
                    Alignment = DataGridViewContentAlignment.MiddleRight 
                }
            });

            // Net Toplam Column
            dataGridViewKalemler.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NetToplam",
                HeaderText = "Net Toplam",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Format = "C2", 
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                }
            });

            // Grid styling
            dataGridViewKalemler.EnableHeadersVisualStyles = false;
            dataGridViewKalemler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewKalemler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewKalemler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewKalemler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 248, 249);
            dataGridViewKalemler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKalemler.RowHeadersVisible = false;
            dataGridViewKalemler.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 250);
            dataGridViewKalemler.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void LoadInvoiceData()
        {
            if (_invoice == null) return;

            // Fatura Bilgileri
            lblFaturaNo.Text = _invoice.InvoiceNo;
            lblFaturaTarihi.Text = _invoice.InvoiceDate.ToString("dd.MM.yyyy");
            lblTedarikci.Text = $"{_invoice.CariCode} - {_invoice.CariName}";
            lblDepo.Text = _invoice.WarehouseName;
            lblDurum.Text = GetStatusText(_invoice.Status);
            lblAraToplam.Text = _invoice.SubTotal.ToString("C2");
            lblKdvTutari.Text = _invoice.VatAmount.ToString("C2");
            lblGenelToplam.Text = _invoice.Total.ToString("C2");

            // Set status color
            SetStatusColor();

            // Load invoice details
            LoadInvoiceDetails();
        }

        private string GetStatusText(string status)
        {
            return status switch
            {
                "DRAFT" => "Taslak",
                "APPROVED" => "Onaylı",
                "CANCELLED" => "İptal",
                _ => status
            };
        }

        private void SetStatusColor()
        {
            switch (_invoice.Status)
            {
                case "DRAFT":
                    lblDurum.ForeColor = Color.Orange;
                    break;
                case "APPROVED":
                    lblDurum.ForeColor = Color.Green;
                    break;
                case "CANCELLED":
                    lblDurum.ForeColor = Color.Red;
                    break;
                default:
                    lblDurum.ForeColor = Color.Black;
                    break;
            }
        }

        private void LoadInvoiceDetails()
        {
            dataGridViewKalemler.Rows.Clear();

            if (_invoice.Details != null && _invoice.Details.Any())
            {
                foreach (var detail in _invoice.Details)
                {
                    var rowIndex = dataGridViewKalemler.Rows.Add();
                    var row = dataGridViewKalemler.Rows[rowIndex];

                    row.Cells["Urun"].Value = $"{detail.ProductCode}\n{detail.ProductName}";
                    row.Cells["Miktar"].Value = detail.Quantity.ToString("N2");
                    row.Cells["BirimFiyat"].Value = detail.UnitPrice.ToString("C2");
                    row.Cells["NetToplam"].Value = detail.LineTotal.ToString("C2");
                }

                lblKalemSayisi.Text = $"({_invoice.Details.Count} adet)";
            }
            else
            {
                lblKalemSayisi.Text = "(0 adet)";
            }
        }

        private void chkOnay_CheckedChanged(object? sender, EventArgs e)
        {
            btnSil.Enabled = chkOnay.Checked;
        }

        private async void btnSil_Click(object? sender, EventArgs e)
        {
            if (!chkOnay.Checked)
            {
                MessageBox.Show("Silme işlemini onaylamanız gerekiyor.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                "Bu faturayı silmek istediğinizden kesinlikle emin misiniz?\n\n" +
                "Bu işlem GERİ ALINAMAZ!\n\n" +
                "• Fatura tamamen silinecek\n" +
                "• Stok hareketleri etkilenecek\n" +
                "• Tedarikçi bakiyesi güncellenecek\n" +
                "• Raporlar etkilenecek",
                "Fatura Sil - Son Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnSil.Enabled = false;

                var result = await _apiService.DeleteAsync<object>($"PurchaseInvoices/{_invoice.InvoiceID}");

                if (result.Success)
                {
                    MessageBox.Show("Fatura başarıyla silindi!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Fatura silinirken hata oluştu:\n{result.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSil.Enabled = chkOnay.Checked;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura silinirken hata oluştu:\n{ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSil.Enabled = chkOnay.Checked;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnDetaylar_Click(object? sender, EventArgs e)
        {
            var detayForm = new AlisFaturaDetayForm(_apiService, _currentUser, _invoice);
            detayForm.ShowDialog();
        }

        private void btnGeri_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
