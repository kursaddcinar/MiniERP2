/*
using MiniERP.WinForms.DTOs;
using MiniERP.WinForms.Services;

namespace MiniERP.WinForms.Forms
{
    public partial class StokTransferiForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;

        public StokTransferiForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Stok Transferi";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            btnKapat.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }
    }

    public partial class StokOzetForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;

        public StokOzetForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Stok Özet";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            btnKapat.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }
    }

    public partial class StokRaporForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;

        public StokRaporForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Stok Raporu";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            btnKapat.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }
    }

    public partial class KritikStokDetayForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;

        public KritikStokDetayForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Kritik Stok Detayları";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            btnKapat.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }
    }

    public partial class StokYokDetayForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;

        public StokYokDetayForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Stokta Yok Detayları";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            btnKapat.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }
    }

    public partial class StokHareketleriForm : Form
    {
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;

        public StokHareketleriForm(UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _apiService = apiService;
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Stok Hareketleri";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            btnKapat.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }
    }

    public partial class StokDetayForm : Form
    {
        private readonly int _stockCardId;
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;

        public StokDetayForm(int stockCardId, UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _stockCardId = stockCardId;
            _currentUser = currentUser;
            _apiService = apiService;
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Stok Detayları";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            btnKapat.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }
    }

    public partial class StokKartiDuzenleForm : Form
    {
        private readonly int _stockCardId;
        private readonly UserDto _currentUser;
        private readonly ApiService _apiService;

        public StokKartiDuzenleForm(int stockCardId, UserDto currentUser, ApiService apiService)
        {
            InitializeComponent();
            _stockCardId = stockCardId;
            _currentUser = currentUser;
            _apiService = apiService;
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Stok Kartı Düzenle";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            btnKapat.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }
    }
}
*/

