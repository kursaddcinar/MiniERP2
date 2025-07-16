using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP.WinForms.Forms
{
    public partial class CariHareketleriForm : Form
    {
        private readonly ApiService _apiService;
        private readonly string _userRole;
        private CariAccountDto _cariAccount;

        public CariHareketleriForm(CariAccountDto cariAccount, string userRole)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _userRole = userRole ?? "Kullanici";
            _cariAccount = cariAccount;
            
            // Set auth token from TokenManager
            if (TokenManager.HasToken())
            {
                _apiService.SetAuthToken(TokenManager.GetToken()!);
            }
            
            SetupForm();
            LoadCariInfo();
            LoadHareketler();
            SetupDataGrid();
        }

        private void SetupForm()
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadCariInfo()
        {
            if (_cariAccount != null)
            {
                // Başlık kartı
                lblCariTitle.Text = $"🔄 {_cariAccount.CariName} ({_cariAccount.CariCode}) Hareketleri";
                
                // Güncel bakiye
                decimal guncelBakiye = _cariAccount.CurrentBalance;
                lblGuncelBakiye.Text = $"₺{guncelBakiye:N2}\nGüncel Bakiye";
                
                // Bakiye rengini ayarla
                lblGuncelBakiye.ForeColor = guncelBakiye >= 0 ? 
                    Color.FromArgb(34, 197, 94) : Color.FromArgb(239, 68, 68);
            }
        }

        private void SetupDataGrid()
        {
            // Grid stilini ayarla
            dataGridViewHareketler.EnableHeadersVisualStyles = false;
            dataGridViewHareketler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 130, 246);
            dataGridViewHareketler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewHareketler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewHareketler.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dataGridViewHareketler.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewHareketler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            
            // Sütun hizalamalarını ayarla
            colTarih.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBelgeTipi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBelgeNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBorc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAlacak.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colBakiye.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            // Para formatları
            colBorc.DefaultCellStyle.Format = "N2";
            colAlacak.DefaultCellStyle.Format = "N2";
            colBakiye.DefaultCellStyle.Format = "N2";
        }

        private void LoadHareketler()
        {
            try
            {
                // Örnek veriler - gerçek API'den gelecek
                LoadSampleData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hareketler yüklenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSampleData()
        {
            // Resimde görülen örnek verileri ekle
            decimal bakiye = 0;
            
            // İlk hareket - Satış Faturası (Alacak)
            bakiye += 578200.00m;
            dataGridViewHareketler.Rows.Add(
                "25.01.2024\n00:00",
                "FATURA",
                "SF2024001",
                "Satış Faturası: SF2024001",
                "-",
                "₺578,200.00",
                $"₺{bakiye:N2}"
            );

            // İkinci hareket - Tahsilat (Borç)
            bakiye -= 300000.00m;
            dataGridViewHareketler.Rows.Add(
                "05.02.2024\n00:00",
                "TAHSİLAT",
                "TAH2024001",
                "Tahsilat: TAH2024001",
                "₺300,000.00",
                "-",
                $"₺{bakiye:N2}"
            );

            // TOPLAM satırını ekle
            int toplamRowIndex = dataGridViewHareketler.Rows.Add(
                "TOPLAM",
                "",
                "",
                "",
                "₺300,000.00",
                "₺578,200.00",
                "₺278,200.00"
            );

            // TOPLAM satırının stilini ayarla
            DataGridViewRow toplamRow = dataGridViewHareketler.Rows[toplamRowIndex];
            toplamRow.DefaultCellStyle.BackColor = Color.FromArgb(219, 234, 254);
            toplamRow.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toplamRow.DefaultCellStyle.ForeColor = Color.FromArgb(30, 58, 138);

            // Bakiye sütunu renklerini ayarla
            foreach (DataGridViewRow row in dataGridViewHareketler.Rows)
            {
                if (row.Cells[colBakiye.Index].Value != null)
                {
                    string? bakiyeText = row.Cells[colBakiye.Index].Value?.ToString();
                    if (!string.IsNullOrEmpty(bakiyeText) && bakiyeText.Contains("₺") && !bakiyeText.Contains("-"))
                    {
                        row.Cells[colBakiye.Index].Style.ForeColor = Color.FromArgb(34, 197, 94);
                    }
                }
                
                // Borç sütunu kırmızı
                if (row.Cells[colBorc.Index].Value != null && 
                    row.Cells[colBorc.Index].Value.ToString() != "-")
                {
                    row.Cells[colBorc.Index].Style.ForeColor = Color.FromArgb(239, 68, 68);
                }
                
                // Alacak sütunu yeşil
                if (row.Cells[colAlacak.Index].Value != null && 
                    row.Cells[colAlacak.Index].Value.ToString() != "-")
                {
                    row.Cells[colAlacak.Index].Style.ForeColor = Color.FromArgb(34, 197, 94);
                }
            }
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnTarihFiltresi_Click(object sender, EventArgs e)
        {
            try
            {
                // Tarih filtresi formu açılacak
                MessageBox.Show("Tarih filtresi özelliği yakında eklenecek.", 
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tarih filtresi açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEkstre_Click(object sender, EventArgs e)
        {
            try
            {
                // Ekstre formu aç
                var ekstreForm = new CariEkstreForm(_cariAccount, _userRole);
                ekstreForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ekstre oluşturulurken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCariDetay_Click(object sender, EventArgs e)
        {
            try
            {
                // Cari detay formu aç
                var detayForm = new CariDetayForm(_cariAccount, _userRole);
                detayForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari detay formu açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
