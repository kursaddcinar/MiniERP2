using MiniERP.WinForms.Models;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class PurchaseInvoiceCreateForm : Form
    {
        private readonly PurchaseService _purchaseService;
        private readonly CariAccountService _cariAccountService;
        private readonly ProductService _productService;

        // UI Controls
        private Panel pnlTop;
        private Label lblTitle;
        private Label lblMessage;
        private Button btnClose;

        public PurchaseInvoiceCreateForm(PurchaseService purchaseService, CariAccountService cariAccountService, ProductService productService)
        {
            _purchaseService = purchaseService;
            _cariAccountService = cariAccountService;
            _productService = productService;
            
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Yeni Alış Faturası";
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
                Text = "Yeni Alış Faturası",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 15),
                Size = new Size(300, 25)
            };

            pnlTop.Controls.Add(lblTitle);

            // Message
            lblMessage = new Label
            {
                Text = "Alış faturası oluşturma formu henüz tamamlanmamıştır.\n\nForm yakında eklenecektir.",
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
            this.Controls.AddRange(new Control[] { pnlTop, lblMessage, btnClose });

            // Event handlers
            btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
} 