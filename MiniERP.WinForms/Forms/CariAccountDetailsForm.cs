using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class CariAccountDetailsForm : Form
    {
        private readonly CariAccountService _cariAccountService;
        private readonly CariAccountDto _cariAccount;

        public CariAccountDetailsForm(CariAccountService cariAccountService, CariAccountDto cariAccount)
        {
            InitializeComponent();
            _cariAccountService = cariAccountService;
            _cariAccount = cariAccount;
            
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.Text = $"Cari Hesap Detayı - {_cariAccount.CariName}";
            lblTitle.Text = $"Cari Hesap Detayı - {_cariAccount.CariName}";
            
            LoadAccountDetails();
            SetupStatusColors();
        }

        private void LoadAccountDetails()
        {
            // Basic Information
            txtCariCode.Text = _cariAccount.CariCode;
            txtCariName.Text = _cariAccount.CariName;
            txtCariType.Text = _cariAccount.TypeName;
            txtIsActive.Text = _cariAccount.IsActive ? "Aktif" : "Pasif";
            
            // Tax Information
            txtTaxNumber.Text = _cariAccount.TaxNumber;
            txtTaxOffice.Text = _cariAccount.TaxOffice;
            
            // Contact Information
            txtAddress.Text = _cariAccount.Address;
            txtPhone.Text = _cariAccount.Phone;
            txtEmail.Text = _cariAccount.Email;
            txtContactPerson.Text = _cariAccount.ContactPerson;
            
            // Financial Information
            txtCreditLimit.Text = _cariAccount.CreditLimit.ToString("C2");
            txtCurrentBalance.Text = _cariAccount.CurrentBalance.ToString("C2");
            txtBalanceType.Text = _cariAccount.BalanceType;
            
            // System Information
            txtCreatedDate.Text = _cariAccount.CreatedDate.ToString("dd.MM.yyyy HH:mm");
            txtCreatedBy.Text = _cariAccount.CreatedBy;
        }

        private void SetupStatusColors()
        {
            // Set color based on account status
            if (_cariAccount.IsActive)
            {
                txtIsActive.BackColor = Color.LightGreen;
                txtIsActive.ForeColor = Color.DarkGreen;
            }
            else
            {
                txtIsActive.BackColor = Color.LightCoral;
                txtIsActive.ForeColor = Color.DarkRed;
            }
            
            // Set color based on balance type
            if (_cariAccount.BalanceType == "ALACAK")
            {
                txtCurrentBalance.BackColor = Color.LightGreen;
                txtCurrentBalance.ForeColor = Color.DarkGreen;
            }
            else if (_cariAccount.BalanceType == "BORC")
            {
                txtCurrentBalance.BackColor = Color.LightCoral;
                txtCurrentBalance.ForeColor = Color.DarkRed;
            }
            else
            {
                txtCurrentBalance.BackColor = Color.LightGray;
                txtCurrentBalance.ForeColor = Color.Black;
            }
        }

        private void btnViewTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                var transactionsForm = new CariTransactionsForm(_cariAccountService, _cariAccount);
                transactionsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hareketler formu açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewStatement_Click(object sender, EventArgs e)
        {
            try
            {
                var statementForm = new CariStatementForm(_cariAccountService, _cariAccount);
                statementForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hesap özeti formu açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var cariTypes = new List<CariTypeDto>
                {
                    new CariTypeDto { TypeID = 1, TypeName = "Müşteri" },
                    new CariTypeDto { TypeID = 2, TypeName = "Tedarikçi" }
                };

                var editForm = new CariAccountEditForm(_cariAccountService, cariTypes, _cariAccount);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Cari hesap başarıyla güncellendi. Lütfen ana listeyi yenileyin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Düzenleme formu açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefreshBalance_Click(object sender, EventArgs e)
        {
            try
            {
                btnRefreshBalance.Enabled = false;
                btnRefreshBalance.Text = "Yenileniyor...";
                
                var response = await _cariAccountService.GetCariAccountByIdAsync(_cariAccount.CariAccountID);
                if (response.Success && response.Data != null)
                {
                    txtCurrentBalance.Text = response.Data.CurrentBalance.ToString("C2");
                    txtBalanceType.Text = response.Data.BalanceType;
                    
                    // Update balance type color
                    if (response.Data.BalanceType == "ALACAK")
                    {
                        txtCurrentBalance.BackColor = Color.LightGreen;
                        txtCurrentBalance.ForeColor = Color.DarkGreen;
                    }
                    else if (response.Data.BalanceType == "BORC")
                    {
                        txtCurrentBalance.BackColor = Color.LightCoral;
                        txtCurrentBalance.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        txtCurrentBalance.BackColor = Color.LightGray;
                        txtCurrentBalance.ForeColor = Color.Black;
                    }
                    
                    MessageBox.Show("Bakiye bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bakiye bilgisi güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bakiye yenilenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRefreshBalance.Enabled = true;
                btnRefreshBalance.Text = "Bakiye Yenile";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCopyCode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCariCode.Text))
            {
                Clipboard.SetText(txtCariCode.Text);
                MessageBox.Show("Cari kodu panoya kopyalandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCopyTaxNumber_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTaxNumber.Text))
            {
                Clipboard.SetText(txtTaxNumber.Text);
                MessageBox.Show("Vergi numarası panoya kopyalandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = $"mailto:{txtEmail.Text}",
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"E-mail uygulaması açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCallPhone_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPhone.Text))
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = $"tel:{txtPhone.Text}",
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Telefon uygulaması açılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnActivateDeactivate_Click(object sender, EventArgs e)
        {
            try
            {
                var action = _cariAccount.IsActive ? "devre dışı bırakmak" : "aktif hale getirmek";
                var result = MessageBox.Show($"Bu cari hesabı {action} istediğinizden emin misiniz?", 
                    "Durum Değiştirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    btnActivateDeactivate.Enabled = false;
                    btnActivateDeactivate.Text = "İşleniyor...";

                    ApiResponse response;
                    if (_cariAccount.IsActive)
                    {
                        response = await _cariAccountService.DeactivateCariAccountAsync(_cariAccount.CariAccountID);
                    }
                    else
                    {
                        response = await _cariAccountService.ActivateCariAccountAsync(_cariAccount.CariAccountID);
                    }

                    if (response.Success)
                    {
                        MessageBox.Show("Cari hesap durumu başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show($"Durum güncellenemedi: {response.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Durum değiştirme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnActivateDeactivate.Enabled = true;
                btnActivateDeactivate.Text = _cariAccount.IsActive ? "Devre Dışı Bırak" : "Aktif Hale Getir";
            }
        }
    }
} 