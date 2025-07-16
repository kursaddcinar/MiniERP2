using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class UrunDetayForm : Form
    {
        private readonly ProductDto _product;
        private readonly ApiService _apiService;

        public UrunDetayForm(ProductDto product, ApiService apiService)
        {
            InitializeComponent();
            _product = product;
            _apiService = apiService;
        }

        private void UrunDetayForm_Load(object sender, EventArgs e)
        {
            LoadProductDetails();
        }

        private void LoadProductDetails()
        {
            // Basic Information
            lblProductCodeValue.Text = _product.ProductCode;
            lblProductNameValue.Text = _product.ProductName;
            lblCategoryValue.Text = _product.CategoryName ?? "Kategorisiz";
            lblUnitValue.Text = _product.UnitName;
            
            // Pricing Information
            lblSalePriceValue.Text = _product.SalePrice.ToString("C2");
            lblPurchasePriceValue.Text = _product.PurchasePrice.ToString("C2");
            lblVatRateValue.Text = _product.VatRate.ToString("N2") + "%";
            
            // Stock Information
            lblCurrentStockValue.Text = _product.CurrentStock.ToString("N2");
            lblReservedStockValue.Text = _product.ReservedStock.ToString("N2");
            lblAvailableStockValue.Text = _product.AvailableStock.ToString("N2");
            lblMinStockValue.Text = _product.MinStockLevel.ToString("N2");
            lblMaxStockValue.Text = _product.MaxStockLevel.ToString("N2");
            
            // Status and Date
            lblStatusValue.Text = _product.IsActive ? "Aktif" : "Pasif";
            lblStatusValue.ForeColor = _product.IsActive ? Color.Green : Color.Red;
            lblCreatedDateValue.Text = _product.CreatedDate.ToString("dd.MM.yyyy HH:mm");
            
            // Set stock status colors
            SetStockStatusColors();
        }

        private void SetStockStatusColors()
        {
            // Check stock levels and set warning colors
            if (_product.CurrentStock <= _product.MinStockLevel && _product.MinStockLevel > 0)
            {
                lblCurrentStockValue.ForeColor = Color.Red;
                lblCurrentStockValue.Font = new Font(lblCurrentStockValue.Font, FontStyle.Bold);
            }
            else if (_product.CurrentStock <= (_product.MinStockLevel * 1.2m) && _product.MinStockLevel > 0)
            {
                lblCurrentStockValue.ForeColor = Color.Orange;
                lblCurrentStockValue.Font = new Font(lblCurrentStockValue.Font, FontStyle.Bold);
            }
            else
            {
                lblCurrentStockValue.ForeColor = Color.Green;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
