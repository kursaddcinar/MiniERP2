using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP.WinForms.Forms
{
    public partial class CariEkstreForm : Form
    {
        private readonly ApiService _apiService;
        private readonly string _userRole;
        private CariAccountDto _cariAccount;

        public CariEkstreForm(CariAccountDto cariAccount, string userRole)
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
            LoadSummaryData();
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
                // Üst kart başlık
                lblCariTitle.Text = $"📋 {_cariAccount.CariName} ({_cariAccount.CariCode}) - Cari Ekstre";
                
                // Cari bilgileri
                lblCariKoduValue.Text = _cariAccount.CariCode;
                lblCariAdiValue.Text = _cariAccount.CariName;
                
                // Dönem başı ve sonu bakiyeleri
                lblDonemBasiBakiyeValue.Text = "₺0.00"; // API'den gelecek
                lblDonemSonuBakiyeValue.Text = $"₺{_cariAccount.CurrentBalance:N2}";
                
                // Renkleri ayarla
                lblDonemSonuBakiyeValue.ForeColor = _cariAccount.CurrentBalance >= 0 ? 
                    Color.FromArgb(34, 197, 94) : Color.FromArgb(239, 68, 68);
            }
        }

        private void LoadSummaryData()
        {
            // Resimde görülen değerleri kullan
            decimal donemBasi = 0.00m;
            decimal toplamBorc = 300000.00m;
            decimal toplamAlacak = 578200.00m;
            decimal donemSonu = 278200.00m;

            // 4 kutucuğu doldur
            lblDonemBasiValue.Text = $"₺{donemBasi:N2}";
            lblToplamBorcValue.Text = $"₺{toplamBorc:N2}";
            lblToplamAlacakValue.Text = $"₺{toplamAlacak:N2}";
            lblDonemSonuValue.Text = $"₺{donemSonu:N2}";
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
        }

        private void LoadHareketler()
        {
            try
            {
                // Örnek veriler - resimde görülenler
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
            // DÖNEM BAŞI BAKİYE satırı
            int donemBasiIndex = dataGridViewHareketler.Rows.Add(
                "DÖNEM BAŞI BAKİYE", "", "", "", "-", "-", "₺0.00"
            );
            DataGridViewRow donemBasiRow = dataGridViewHareketler.Rows[donemBasiIndex];
            donemBasiRow.DefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230); // Açık mavi
            donemBasiRow.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            decimal bakiye = 0;
            
            // İlk hareket - Satış Faturası (Alacak)
            bakiye += 578200.00m;
            dataGridViewHareketler.Rows.Add(
                "25.01.2024",
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
                "05.02.2024",
                "TAHSİLAT",
                "TAH2024001",
                "Tahsilat: TAH2024001",
                "₺300,000.00",
                "-",
                $"₺{bakiye:N2}"
            );

            // DÖNEM SONU BAKİYE satırı
            int donemSonuIndex = dataGridViewHareketler.Rows.Add(
                "DÖNEM SONU BAKİYE", "", "", "", "₺300,000.00", "₺578,200.00", "₺278,200.00"
            );
            DataGridViewRow donemSonuRow = dataGridViewHareketler.Rows[donemSonuIndex];
            donemSonuRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 228, 181); // Açık turuncu
            donemSonuRow.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            // Renkleri ayarla
            SetRowColors();
        }

        private void SetRowColors()
        {
            foreach (DataGridViewRow row in dataGridViewHareketler.Rows)
            {
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
                
                // Bakiye sütunu yeşil
                if (row.Cells[colBakiye.Index].Value != null)
                {
                    string? bakiyeText = row.Cells[colBakiye.Index].Value?.ToString();
                    if (!string.IsNullOrEmpty(bakiyeText) && bakiyeText.Contains("₺"))
                    {
                        row.Cells[colBakiye.Index].Style.ForeColor = Color.FromArgb(34, 197, 94);
                    }
                }
            }
        }

        private void BtnCariListesi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnTumHareketler_Click(object sender, EventArgs e)
        {
            try
            {
                // Tüm hareketler formu açılacak (CariHareketleriForm)
                var hareketlerForm = new CariHareketleriForm(_cariAccount, _userRole);
                hareketlerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hareketler formu açılırken hata oluştu: {ex.Message}", 
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

        private void BtnCariDetayTop_Click(object sender, EventArgs e)
        {
            try
            {
                // Üst kısımdaki cari detay butonu
                var detayForm = new CariDetayForm(_cariAccount, _userRole);
                detayForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari detay formu açılırken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnYazdir_Click(object sender, EventArgs e)
        {
            try
            {
                // Yazdırma işlemi
                MessageBox.Show("Yazdırma özelliği yakında eklenecek.", 
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yazdırma işlemi sırasında hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Excel'e aktarma işlemi
                MessageBox.Show("Excel'e aktarma özelliği yakında eklenecek.", 
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excel'e aktarma sırasında hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


