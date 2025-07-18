using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class CariEkleForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;
        private readonly string _userRole;
        private List<CariTypeDto> _cariTypes = new();

        public bool IsDataSaved { get; private set; } = false;

        public CariEkleForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            _userRole = GetPrimaryRole();
            
            SetupForm();
            
            // Load cari types asynchronously
            Task.Run(async () => await LoadCariTypesAsync());
        }

        private string GetPrimaryRole()
        {
            if (_currentUser.Roles.Contains("Admin")) return "Admin";
            if (_currentUser.Roles.Contains("Manager")) return "Manager";
            if (_currentUser.Roles.Contains("Sales")) return "Sales";
            if (_currentUser.Roles.Contains("Purchase")) return "Purchase";
            if (_currentUser.Roles.Contains("Finance")) return "Finance";
            if (_currentUser.Roles.Contains("Warehouse")) return "Warehouse";
            return "Employee";
        }

        private void SetupForm()
        {
            // Generate auto cari code
            GenerateCariCode();
            
            // Set focus to cari name
            txtCariAdi.Focus();
            
            // Setup tax number validation (only numbers, max 10 digits)
            txtVergiNo.KeyPress += TxtVergiNo_KeyPress;
            txtVergiNo.MaxLength = 10;
            
            // Setup phone number validation (only numbers and formatting chars)
            txtTelefon.KeyPress += TxtTelefon_KeyPress;
            
            // Set default values
            chkAktif.Checked = true;
        }

        private void GenerateCariCode()
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            txtCariKodu.Text = $"C{timestamp}";
        }

        private async void CariEkleForm_Load(object sender, EventArgs e)
        {
            await LoadCariTypesAsync();
        }

        private async Task LoadCariTypesAsync()
        {
            try
            {
                // Use the same endpoint as web application
                var response = await _apiService.GetAsync<PagedResult<CariTypeDto>>("CariAccounts/types?pageSize=100");
                
                // Debug: Check response
                Console.WriteLine($"CariTypes API Response - Success: {response?.Success}, Data: {response?.Data?.Data?.Count ?? 0} items");
                
                if (response != null && response.Success && response.Data?.Data != null)
                {
                    _cariTypes = response.Data.Data.Where(t => t.IsActive).ToList();
                    
                    Console.WriteLine($"Active CariTypes loaded: {_cariTypes.Count}");
                    
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => PopulateCariTypesCombo()));
                    }
                    else
                    {
                        PopulateCariTypesCombo();
                    }
                }
                else
                {
                    Console.WriteLine($"CariTypes API Error - Success: {response?.Success}, Message: {response?.Message}");
                    _cariTypes = new List<CariTypeDto>();
                    MessageBox.Show("Cari tipleri yüklenemedi. Lütfen daha sonra tekrar deneyin.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CariTypes Exception: {ex.Message}");
                MessageBox.Show($"Cari tipleri yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _cariTypes = new List<CariTypeDto>();
            }
        }

        private void PopulateCariTypesCombo()
        {
            cmbCariTipi.Items.Clear();
            foreach (var type in _cariTypes)
            {
                cmbCariTipi.Items.Add(new ComboBoxItem { Text = type.TypeName, Value = type.TypeID });
            }
            
            if (cmbCariTipi.Items.Count > 0)
            {
                cmbCariTipi.SelectedIndex = 0;
            }
        }

        private async void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                var selectedType = cmbCariTipi.SelectedItem as ComboBoxItem;
                if (selectedType?.Value == null)
                {
                    MessageBox.Show("Lütfen cari tipi seçiniz.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var createDto = new CreateCariAccountDto
                {
                    CariCode = txtCariKodu.Text.Trim(),
                    CariName = txtCariAdi.Text.Trim(),
                    TypeID = (int)selectedType.Value,
                    TaxNumber = txtVergiNo.Text.Trim(),
                    TaxOffice = txtVergiDairesi.Text.Trim(),
                    ContactPerson = txtIletisimKisi.Text.Trim(),
                    Phone = txtTelefon.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAdres.Text.Trim(),
                    CreditLimit = numKrediLimiti.Value,
                    IsActive = chkAktif.Checked
                };

                btnKaydet.Enabled = false;
                btnKaydet.Text = "Kaydediliyor...";

                var response = await _apiService.PostAsync<CariAccountDto>("CariAccounts", createDto);
                
                if (response.Success)
                {
                    IsDataSaved = true;
                    MessageBox.Show("Cari hesap başarıyla oluşturuldu.", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Cari hesap oluşturulurken hata oluştu:\n{response.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cari hesap oluşturulurken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnKaydet.Enabled = true;
                btnKaydet.Text = "💾 Kaydet";
            }
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            if (HasUnsavedChanges())
            {
                var result = MessageBox.Show("Kaydedilmemiş değişiklikler var. Çıkmak istediğinizden emin misiniz?", 
                    "Kaydedilmemiş Değişiklikler", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.No)
                    return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            var errors = new List<string>();

            // Required fields (as shown in the image)
            if (string.IsNullOrWhiteSpace(txtCariKodu.Text))
                errors.Add("Cari Kodu gereklidir.");

            if (string.IsNullOrWhiteSpace(txtCariAdi.Text))
                errors.Add("Cari Adı gereklidir.");

            if (string.IsNullOrWhiteSpace(txtIletisimKisi.Text))
                errors.Add("İletişim Kişisi gereklidir.");

            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
                errors.Add("Telefon gereklidir.");

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                errors.Add("E-posta gereklidir.");

            if (cmbCariTipi.SelectedItem == null)
                errors.Add("Cari Tipi seçimi gereklidir.");

            if (string.IsNullOrWhiteSpace(txtVergiNo.Text))
                errors.Add("Vergi Numarası gereklidir.");
            else if (txtVergiNo.Text.Length != 10)
                errors.Add("Vergi Numarası tam olarak 10 hane olmalıdır.");

            if (string.IsNullOrWhiteSpace(txtVergiDairesi.Text))
                errors.Add("Vergi Dairesi gereklidir.");

            if (string.IsNullOrWhiteSpace(txtAdres.Text))
                errors.Add("Adres gereklidir.");

            // Email validation
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
                errors.Add("Geçerli bir email adresi giriniz.");

            // Phone validation
            if (!string.IsNullOrWhiteSpace(txtTelefon.Text) && txtTelefon.Text.Length < 7)
                errors.Add("Telefon numarası en az 7 karakter olmalıdır.");

            if (errors.Any())
            {
                MessageBox.Show($"Aşağıdaki hatalar düzeltilmelidir:\n\n{string.Join("\n", errors)}", 
                    "Form Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private bool HasUnsavedChanges()
        {
            return !string.IsNullOrWhiteSpace(txtCariAdi.Text) ||
                   !string.IsNullOrWhiteSpace(txtIletisimKisi.Text) ||
                   !string.IsNullOrWhiteSpace(txtTelefon.Text) ||
                   !string.IsNullOrWhiteSpace(txtEmail.Text) ||
                   !string.IsNullOrWhiteSpace(txtAdres.Text) ||
                   !string.IsNullOrWhiteSpace(txtVergiNo.Text) ||
                   !string.IsNullOrWhiteSpace(txtVergiDairesi.Text) ||
                   numKrediLimiti.Value > 0;
        }

        private void TxtVergiNo_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Allow only digits, backspace and control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtTelefon_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Allow digits, backspace, control keys, space, dash, parentheses
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && 
                e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')')
            {
                e.Handled = true;
            }
        }

        public class ComboBoxItem
        {
            public string Text { get; set; } = string.Empty;
            public object? Value { get; set; }

            public override string ToString() => Text;
        }
    }
}


