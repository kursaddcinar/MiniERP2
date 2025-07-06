using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class PurchaseInvoiceEditForm : Form
    {
        private readonly PurchaseService _purchaseService;
        private readonly CariAccountService _cariAccountService;
        private readonly ProductService _productService;
        private readonly PurchaseInvoiceDto _invoice;

        // UI Controls
        private Panel pnlTop;
        private Label lblTitle;
        private Label lblInvoiceNumber;
        private TextBox txtInvoiceNumber;
        private Label lblMessage;
        private Button btnClose;

        public PurchaseInvoiceEditForm(PurchaseService purchaseService, CariAccountService cariAccountService, ProductService productService, PurchaseInvoiceDto invoice)
        {
            _purchaseService = purchaseService;
            _cariAccountService = cariAccountService;
            _productService = productService;
            _invoice = invoice;
            
            InitializeComponent();
            LoadInvoiceData();
        }

        private void InitializeComponent()
        {
            this.Text = "Alış Faturası Düzenle";
            this.Size = new Size(600, 300);
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
                Text = "Alış Faturası Düzenle",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 15),
                Size = new Size(300, 25)
            };

            pnlTop.Controls.Add(lblTitle);

            // Invoice number
            lblInvoiceNumber = new Label
            {
                Text = "Fatura No:",
                Location = new Point(20, 70),
                Size = new Size(80, 23)
            };

            txtInvoiceNumber = new TextBox
            {
                Location = new Point(105, 67),
                Size = new Size(150, 23),
                ReadOnly = true
            };

            // Message
            lblMessage = new Label
            {
                Text = "Alış faturası düzenleme formu henüz tamamlanmamıştır.\n\nForm yakında eklenecektir.",
                Location = new Point(20, 110),
                Size = new Size(520, 60),
                Font = new Font("Segoe UI", 10)
            };

            // Close button
            btnClose = new Button
            {
                Text = "Kapat",
                Location = new Point(500, 200),
                Size = new Size(80, 30),
                DialogResult = DialogResult.Cancel
            };

            // Add controls to form
            this.Controls.AddRange(new Control[] { pnlTop, lblInvoiceNumber, txtInvoiceNumber, lblMessage, btnClose });

            // Event handlers
            btnClose.Click += BtnClose_Click;
        }

        private void LoadInvoiceData()
        {
            txtInvoiceNumber.Text = _invoice.InvoiceNumber;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
} 