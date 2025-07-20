namespace MiniERP.WinForms.Forms
{
    partial class KullaniciYonetimiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new Panel();
            this.lblBaslik = new Label();
            this.btnYenile = new Button();
            this.btnYeniKullanici = new Button();
            this.btnDetay = new Button();
            this.btnDuzenle = new Button();
            this.btnSil = new Button();
            this.panelArama = new Panel();
            this.txtArama = new TextBox();
            this.lblArama = new Label();
            this.cmbRol = new ComboBox();
            this.lblRol = new Label();
            this.btnAra = new Button();
            this.panelMain = new Panel();
            this.dgvKullanicilar = new DataGridView();
            this.panelBottom = new Panel();
            this.lblToplam = new Label();
            this.panelHeader.SuspendLayout();
            this.panelArama.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Controls.Add(this.btnYenile);
            this.panelHeader.Controls.Add(this.btnYeniKullanici);
            this.panelHeader.Controls.Add(this.btnDetay);
            this.panelHeader.Controls.Add(this.btnDuzenle);
            this.panelHeader.Controls.Add(this.btnSil);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(1200, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Anchor = AnchorStyles.Left;
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.White;
            this.lblBaslik.Location = new Point(15, 17);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(193, 30);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Kullanıcı Yönetimi";
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = AnchorStyles.Right;
            this.btnYenile.BackColor = Color.FromArgb(52, 152, 219);
            this.btnYenile.FlatAppearance.BorderSize = 0;
            this.btnYenile.FlatStyle = FlatStyle.Flat;
            this.btnYenile.Font = new Font("Segoe UI", 9F);
            this.btnYenile.ForeColor = Color.White;
            this.btnYenile.Location = new Point(1020, 15);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new Size(80, 30);
            this.btnYenile.TabIndex = 2;
            this.btnYenile.Text = "🔄 Yenile";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new EventHandler(this.btnYenile_Click);
            // 
            // btnYeniKullanici
            // 
            this.btnYeniKullanici.Anchor = AnchorStyles.Right;
            this.btnYeniKullanici.BackColor = Color.FromArgb(46, 204, 113);
            this.btnYeniKullanici.FlatAppearance.BorderSize = 0;
            this.btnYeniKullanici.FlatStyle = FlatStyle.Flat;
            this.btnYeniKullanici.Font = new Font("Segoe UI", 9F);
            this.btnYeniKullanici.ForeColor = Color.White;
            this.btnYeniKullanici.Location = new Point(1110, 15);
            this.btnYeniKullanici.Name = "btnYeniKullanici";
            this.btnYeniKullanici.Size = new Size(75, 30);
            this.btnYeniKullanici.TabIndex = 1;
            this.btnYeniKullanici.Text = "➕ Yeni";
            this.btnYeniKullanici.UseVisualStyleBackColor = false;
            this.btnYeniKullanici.Click += new EventHandler(this.btnYeniKullanici_Click);
            // 
            // btnDetay
            // 
            this.btnDetay.Anchor = AnchorStyles.Right;
            this.btnDetay.BackColor = Color.FromArgb(52, 152, 219);
            this.btnDetay.FlatAppearance.BorderSize = 0;
            this.btnDetay.FlatStyle = FlatStyle.Flat;
            this.btnDetay.Font = new Font("Segoe UI", 9F);
            this.btnDetay.ForeColor = Color.White;
            this.btnDetay.Location = new Point(940, 15);
            this.btnDetay.Name = "btnDetay";
            this.btnDetay.Size = new Size(75, 30);
            this.btnDetay.TabIndex = 3;
            this.btnDetay.Text = "👁️ Detay";
            this.btnDetay.UseVisualStyleBackColor = false;
            this.btnDetay.Click += new EventHandler(this.btnDetay_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Anchor = AnchorStyles.Right;
            this.btnDuzenle.BackColor = Color.FromArgb(243, 156, 18);
            this.btnDuzenle.FlatAppearance.BorderSize = 0;
            this.btnDuzenle.FlatStyle = FlatStyle.Flat;
            this.btnDuzenle.Font = new Font("Segoe UI", 9F);
            this.btnDuzenle.ForeColor = Color.White;
            this.btnDuzenle.Location = new Point(860, 15);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new Size(75, 30);
            this.btnDuzenle.TabIndex = 4;
            this.btnDuzenle.Text = "✏️ Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Click += new EventHandler(this.btnDuzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Anchor = AnchorStyles.Right;
            this.btnSil.BackColor = Color.FromArgb(231, 76, 60);
            this.btnSil.FlatAppearance.BorderSize = 0;
            this.btnSil.FlatStyle = FlatStyle.Flat;
            this.btnSil.Font = new Font("Segoe UI", 9F);
            this.btnSil.ForeColor = Color.White;
            this.btnSil.Location = new Point(780, 15);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new Size(75, 30);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "🗑️ Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new EventHandler(this.btnSil_Click);
            // 
            // panelArama
            // 
            this.panelArama.BackColor = Color.FromArgb(236, 240, 241);
            this.panelArama.Controls.Add(this.txtArama);
            this.panelArama.Controls.Add(this.lblArama);
            this.panelArama.Controls.Add(this.cmbRol);
            this.panelArama.Controls.Add(this.lblRol);
            this.panelArama.Controls.Add(this.btnAra);
            this.panelArama.Dock = DockStyle.Top;
            this.panelArama.Location = new Point(0, 60);
            this.panelArama.Name = "panelArama";
            this.panelArama.Size = new Size(1200, 50);
            this.panelArama.TabIndex = 1;
            // 
            // txtArama
            // 
            this.txtArama.Font = new Font("Segoe UI", 9F);
            this.txtArama.Location = new Point(80, 15);
            this.txtArama.Name = "txtArama";
            this.txtArama.PlaceholderText = "Kullanıcı adı, ad soyad veya email ara...";
            this.txtArama.Size = new Size(300, 23);
            this.txtArama.TabIndex = 1;
            this.txtArama.KeyPress += new KeyPressEventHandler(this.txtArama_KeyPress);
            // 
            // lblArama
            // 
            this.lblArama.AutoSize = true;
            this.lblArama.Font = new Font("Segoe UI", 9F);
            this.lblArama.Location = new Point(15, 18);
            this.lblArama.Name = "lblArama";
            this.lblArama.Size = new Size(40, 15);
            this.lblArama.TabIndex = 0;
            this.lblArama.Text = "Arama:";
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRol.Font = new Font("Segoe UI", 9F);
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new Point(440, 15);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new Size(150, 23);
            this.cmbRol.TabIndex = 3;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new Font("Segoe UI", 9F);
            this.lblRol.Location = new Point(400, 18);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new Size(27, 15);
            this.lblRol.TabIndex = 2;
            this.lblRol.Text = "Rol:";
            // 
            // btnAra
            // 
            this.btnAra.BackColor = Color.FromArgb(52, 152, 219);
            this.btnAra.FlatAppearance.BorderSize = 0;
            this.btnAra.FlatStyle = FlatStyle.Flat;
            this.btnAra.Font = new Font("Segoe UI", 9F);
            this.btnAra.ForeColor = Color.White;
            this.btnAra.Location = new Point(610, 14);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new Size(60, 25);
            this.btnAra.TabIndex = 4;
            this.btnAra.Text = "🔍 Ara";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new EventHandler(this.btnAra_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dgvKullanicilar);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 110);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(10);
            this.panelMain.Size = new Size(1200, 390);
            this.panelMain.TabIndex = 2;
            // 
            // dgvKullanicilar
            // 
            this.dgvKullanicilar.AllowUserToAddRows = false;
            this.dgvKullanicilar.AllowUserToDeleteRows = false;
            this.dgvKullanicilar.AllowUserToResizeRows = false;
            this.dgvKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKullanicilar.BackgroundColor = Color.White;
            this.dgvKullanicilar.BorderStyle = BorderStyle.None;
            this.dgvKullanicilar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKullanicilar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvKullanicilar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            this.dgvKullanicilar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvKullanicilar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvKullanicilar.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 73, 94);
            this.dgvKullanicilar.ColumnHeadersHeight = 35;
            this.dgvKullanicilar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvKullanicilar.DefaultCellStyle.BackColor = Color.White;
            this.dgvKullanicilar.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            this.dgvKullanicilar.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            this.dgvKullanicilar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(174, 214, 241);
            this.dgvKullanicilar.DefaultCellStyle.SelectionForeColor = Color.FromArgb(44, 62, 80);
            this.dgvKullanicilar.Dock = DockStyle.Fill;
            this.dgvKullanicilar.EnableHeadersVisualStyles = false;
            this.dgvKullanicilar.GridColor = Color.FromArgb(189, 195, 199);
            this.dgvKullanicilar.Location = new Point(10, 10);
            this.dgvKullanicilar.MultiSelect = false;
            this.dgvKullanicilar.Name = "dgvKullanicilar";
            this.dgvKullanicilar.ReadOnly = true;
            this.dgvKullanicilar.RowHeadersVisible = false;
            this.dgvKullanicilar.RowTemplate.Height = 30;
            this.dgvKullanicilar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvKullanicilar.Size = new Size(1180, 370);
            this.dgvKullanicilar.TabIndex = 0;
            this.dgvKullanicilar.CellClick += new DataGridViewCellEventHandler(this.dgvKullanicilar_CellClick);
            this.dgvKullanicilar.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvKullanicilar_CellDoubleClick);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = Color.FromArgb(236, 240, 241);
            this.panelBottom.Controls.Add(this.lblToplam);
            this.panelBottom.Dock = DockStyle.Bottom;
            this.panelBottom.Location = new Point(0, 500);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new Size(1200, 30);
            this.panelBottom.TabIndex = 3;
            // 
            // lblToplam
            // 
            this.lblToplam.Anchor = AnchorStyles.Left;
            this.lblToplam.AutoSize = true;
            this.lblToplam.Font = new Font("Segoe UI", 9F);
            this.lblToplam.Location = new Point(15, 8);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new Size(105, 15);
            this.lblToplam.TabIndex = 0;
            this.lblToplam.Text = "Toplam: 0 kullanıcı";
            // 
            // KullaniciYonetimiForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1200, 530);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelArama);
            this.Controls.Add(this.panelHeader);
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "KullaniciYonetimiForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Kullanıcı Yönetimi";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelArama.ResumeLayout(false);
            this.panelArama.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblBaslik;
        private Button btnYenile;
        private Button btnYeniKullanici;
        private Button btnDetay;
        private Button btnDuzenle;
        private Button btnSil;
        private Panel panelArama;
        private TextBox txtArama;
        private Label lblArama;
        private ComboBox cmbRol;
        private Label lblRol;
        private Button btnAra;
        private Panel panelMain;
        private DataGridView dgvKullanicilar;
        private Panel panelBottom;
        private Label lblToplam;
    }
}
