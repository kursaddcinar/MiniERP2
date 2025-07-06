using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class CariAccountEditForm : Form
    {
        private readonly CariAccountService _cariAccountService;
        private readonly List<CariTypeDto> _cariTypes;
        private readonly CariAccountDto? _editingAccount;
        private readonly bool _isEditMode;

        public CariAccountEditForm(CariAccountService cariAccountService, List<CariTypeDto> cariTypes, CariAccountDto? editingAccount = null)
        {
            InitializeComponent();
            _cariAccountService = cariAccountService;
            _cariTypes = cariTypes;
            _editingAccount = editingAccount;
            _isEditMode = editingAccount != null;
            
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Set form title
            this.Text = _isEditMode ? "Cari Hesap Düzenle" : "Yeni Cari Hesap";
            lblTitle.Text = _isEditMode ? "Cari Hesap Düzenle" : "Yeni Cari Hesap Ekle";

            // Setup combo boxes
            SetupCariTypeCombo();
            SetupBalanceTypeCombo();

            // Load data if editing
            if (_isEditMode && _editingAccount != null)
            {
                LoadAccountData();
            }
            else
            {
                // Set default values for new account
                chkIsActive.Checked = true;
                dtpCreatedDate.Value = DateTime.Now;
                txtCreatedBy.Text = Environment.UserName;
                txtCreatedBy.ReadOnly = true;
                
                // Generate new code
                GenerateNewCode();
            }

            // Set field focus
            txtCariName.Focus();
        }

        private void SetupCariTypeCombo()
        {
            cmbCariType.DataSource = _cariTypes;
            cmbCariType.DisplayMember = "TypeName";
            cmbCariType.ValueMember = "TypeID";
            cmbCariType.SelectedIndex = 0;
        }

        private void SetupBalanceTypeCombo()
        {
            cmbBalanceType.Items.Clear();
            cmbBalanceType.Items.Add("ALACAK");
            cmbBalanceType.Items.Add("BORC");
            cmbBalanceType.Items.Add("BAKIYE YOK");
            cmbBalanceType.SelectedIndex = 2; // Default to "BAKIYE YOK"
        }

        private void LoadAccountData()
        {
            if (_editingAccount == null) return;

            txtCariCode.Text = _editingAccount.CariCode;
            txtCariName.Text = _editingAccount.CariName;
            cmbCariType.SelectedValue = _editingAccount.TypeID;
            txtTaxNumber.Text = _editingAccount.TaxNumber;
            txtTaxOffice.Text = _editingAccount.TaxOffice;
            txtAddress.Text = _editingAccount.Address;
            txtPhone.Text = _editingAccount.Phone;
            txtEmail.Text = _editingAccount.Email;
            txtContactPerson.Text = _editingAccount.ContactPerson;
            numCreditLimit.Value = _editingAccount.CreditLimit;
            numCurrentBalance.Value = _editingAccount.CurrentBalance;
            
            // Set balance type
            if (!string.IsNullOrEmpty(_editingAccount.BalanceType))
            {
                cmbBalanceType.SelectedItem = _editingAccount.BalanceType;
            }
            
            chkIsActive.Checked = _editingAccount.IsActive;
            dtpCreatedDate.Value = _editingAccount.CreatedDate;
            txtCreatedBy.Text = _editingAccount.CreatedBy;
            txtCreatedBy.ReadOnly = true;

            // Disable code editing for existing accounts
            txtCariCode.ReadOnly = true;
        }

        private async void GenerateNewCode()
        {
            try
            {
                // Generate a simple code based on type and timestamp
                var selectedType = (CariTypeDto)cmbCariType.SelectedItem;
                var prefix = selectedType.TypeName.Substring(0, 1).ToUpper();
                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                txtCariCode.Text = $"{prefix}{timestamp}";
            }
            catch (Exception ex)
            {
                // If generation fails, use a simple default
                txtCariCode.Text = "C" + DateTime.Now.ToString("yyyyMMddHHmmss");
            }
        }

        private void cmbCariType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                GenerateNewCode();
            }
        }

        private bool ValidateForm()
        {
            var errors = new List<string>();

            // Required fields
            if (string.IsNullOrWhiteSpace(txtCariCode.Text))
                errors.Add("Cari kodu zorunludur.");

            if (string.IsNullOrWhiteSpace(txtCariName.Text))
                errors.Add("Cari adı zorunludur.");

            if (cmbCariType.SelectedValue == null)
                errors.Add("Cari tipi seçilmelidir.");

            // Email validation
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
                errors.Add("Geçerli bir e-mail adresi giriniz.");

            // Tax number validation (if provided)
            if (!string.IsNullOrWhiteSpace(txtTaxNumber.Text))
            {
                if (txtTaxNumber.Text.Length < 10 || txtTaxNumber.Text.Length > 11)
                    errors.Add("Vergi numarası 10 veya 11 haneli olmalıdır.");
            }

            // Credit limit validation
            if (numCreditLimit.Value < 0)
                errors.Add("Kredi limiti negatif olamaz.");

            if (errors.Any())
            {
                MessageBox.Show(string.Join("\n", errors), "Doğrulama Hataları", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                btnSave.Enabled = false;
                btnSave.Text = "Kaydediliyor...";

                if (_isEditMode)
                {
                    await UpdateAccount();
                }
                else
                {
                    await CreateAccount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kaydetme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "Kaydet";
            }
        }

        private async Task CreateAccount()
        {
            var createDto = new CreateCariAccountDto
            {
                CariCode = txtCariCode.Text.Trim(),
                CariName = txtCariName.Text.Trim(),
                TypeID = (int)cmbCariType.SelectedValue,
                TaxNumber = txtTaxNumber.Text.Trim(),
                TaxOffice = txtTaxOffice.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                ContactPerson = txtContactPerson.Text.Trim(),
                CreditLimit = numCreditLimit.Value
            };

            var response = await _cariAccountService.CreateCariAccountAsync(createDto);

            if (response.Success)
            {
                MessageBox.Show("Cari hesap başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                ShowError("Oluşturma hatası", response.Message, response.Errors);
            }
        }

        private async Task UpdateAccount()
        {
            if (_editingAccount == null) return;

            var updateDto = new UpdateCariAccountDto
            {
                CariName = txtCariName.Text.Trim(),
                TypeID = (int)cmbCariType.SelectedValue,
                TaxNumber = txtTaxNumber.Text.Trim(),
                TaxOffice = txtTaxOffice.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                ContactPerson = txtContactPerson.Text.Trim(),
                CreditLimit = numCreditLimit.Value,
                IsActive = chkIsActive.Checked
            };

            var response = await _cariAccountService.UpdateCariAccountAsync(_editingAccount.CariAccountID, updateDto);

            if (response.Success)
            {
                MessageBox.Show("Cari hesap başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                ShowError("Güncelleme hatası", response.Message, response.Errors);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowError(string title, string message, List<string>? errors = null)
        {
            var errorText = message;
            if (errors != null && errors.Any())
            {
                errorText += "\n\nDetaylar:\n" + string.Join("\n", errors);
            }

            MessageBox.Show(errorText, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtCariCode_Leave(object sender, EventArgs e)
        {
            if (!_isEditMode && !string.IsNullOrWhiteSpace(txtCariCode.Text))
            {
                // Check if code already exists
                _ = CheckCodeAvailability();
            }
        }

        private async Task CheckCodeAvailability()
        {
            try
            {
                var response = await _cariAccountService.GetCariAccountByCodeAsync(txtCariCode.Text.Trim());
                if (response.Success && response.Data != null)
                {
                    MessageBox.Show("Bu kod zaten kullanılmaktadır. Lütfen farklı bir kod giriniz.", "Kod Mevcudu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCariCode.Focus();
                    txtCariCode.SelectAll();
                }
            }
            catch (Exception ex)
            {
                // Code check failed, but we can continue
                Console.WriteLine($"Code availability check failed: {ex.Message}");
            }
        }

        private void txtTaxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, spaces, dashes, parentheses, and plus sign
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '(' && 
                e.KeyChar != ')' && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                GenerateNewCode();
            }
        }

        private async void btnCheckBalance_Click(object sender, EventArgs e)
        {
            if (_isEditMode && _editingAccount != null)
            {
                try
                {
                    var response = await _cariAccountService.GetCariAccountByIdAsync(_editingAccount.CariAccountID);
                    if (response.Success && response.Data != null)
                    {
                        numCurrentBalance.Value = response.Data.CurrentBalance;
                        cmbBalanceType.SelectedItem = response.Data.BalanceType;
                        MessageBox.Show("Bakiye bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bakiye kontrol edilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
} 