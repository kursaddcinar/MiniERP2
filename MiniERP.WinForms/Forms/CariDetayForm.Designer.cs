namespace MiniERP.WinForms.Forms
{
    partial class CariDetayForm
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
            this.panelMain = new Panel();
            this.panelContent = new Panel();
            this.panelCards = new Panel();
            this.cardHizliIslemler = new Panel();
            this.lblHizliIslemlerTitle = new Label();
            this.btnCariHareketleri = new Button();
            this.btnCariEkstresi = new Button();
            this.btnYeniHareket = new Button();
            this.cardBakiye = new Panel();
            this.lblBakiyeTitle = new Label();
            this.lblGuncelBakiye = new Label();
            this.lblGuncelBakiyeValue = new Label();
            this.lblKrediLimiti = new Label();
            this.lblKrediLimitiValue = new Label();
            this.lblKullanilabilirLimit = new Label();
            this.lblKullanilabilirLimitValue = new Label();
            this.cardCariDetay = new Panel();
            this.lblCariTitle = new Label();
            this.panelCariInfo = new Panel();
            this.lblCariKodu = new Label();
            this.lblCariKoduValue = new Label();
            this.lblCariAdi = new Label();
            this.lblCariAdiValue = new Label();
            this.lblIletisimKisi = new Label();
            this.lblIletisimKisiValue = new Label();
            this.lblTelefon = new Label();
            this.lblTelefonValue = new Label();
            this.lblEmail = new Label();
            this.lblEmailValue = new Label();
            this.lblCariTipi = new Label();
            this.lblCariTipiValue = new Label();
            this.lblVergiDairesi = new Label();
            this.lblVergiDairesiValue = new Label();
            this.lblVergiNo = new Label();
            this.lblVergiNoValue = new Label();
            this.lblKrediLimitDetay = new Label();
            this.lblKrediLimitDetayValue = new Label();
            this.lblKayitTarihi = new Label();
            this.lblKayitTarihiValue = new Label();
            this.panelButtons = new Panel();
            this.btnGeri = new Button();
            this.btnHareketler = new Button();
            this.btnDuzenle = new Button();
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelCards.SuspendLayout();
            this.cardHizliIslemler.SuspendLayout();
            this.cardBakiye.SuspendLayout();
            this.cardCariDetay.SuspendLayout();
            this.panelCariInfo.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new Size(1200, 800);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelCards);
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Location = new Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new Padding(20);
            this.panelContent.Size = new Size(1200, 740);
            this.panelContent.TabIndex = 1;
            // 
            // panelCards
            // 
            this.panelCards.Controls.Add(this.cardHizliIslemler);
            this.panelCards.Controls.Add(this.cardBakiye);
            this.panelCards.Controls.Add(this.cardCariDetay);
            this.panelCards.Dock = DockStyle.Fill;
            this.panelCards.Location = new Point(20, 20);
            this.panelCards.Name = "panelCards";
            this.panelCards.Size = new Size(1160, 700);
            this.panelCards.TabIndex = 0;
            // 
            // cardHizliIslemler
            // 
            this.cardHizliIslemler.BackColor = Color.White;
            this.cardHizliIslemler.BorderStyle = BorderStyle.FixedSingle;
            this.cardHizliIslemler.Controls.Add(this.lblHizliIslemlerTitle);
            this.cardHizliIslemler.Controls.Add(this.btnCariHareketleri);
            this.cardHizliIslemler.Controls.Add(this.btnCariEkstresi);
            this.cardHizliIslemler.Controls.Add(this.btnYeniHareket);
            this.cardHizliIslemler.Location = new Point(780, 10);
            this.cardHizliIslemler.Name = "cardHizliIslemler";
            this.cardHizliIslemler.Size = new Size(370, 200);
            this.cardHizliIslemler.TabIndex = 2;
            // 
            // lblHizliIslemlerTitle
            // 
            this.lblHizliIslemlerTitle.BackColor = Color.FromArgb(59, 130, 246);
            this.lblHizliIslemlerTitle.Dock = DockStyle.Top;
            this.lblHizliIslemlerTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblHizliIslemlerTitle.ForeColor = Color.White;
            this.lblHizliIslemlerTitle.Location = new Point(0, 0);
            this.lblHizliIslemlerTitle.Name = "lblHizliIslemlerTitle";
            this.lblHizliIslemlerTitle.Size = new Size(368, 40);
            this.lblHizliIslemlerTitle.TabIndex = 0;
            this.lblHizliIslemlerTitle.Text = "⚡ Hızlı İşlemler";
            this.lblHizliIslemlerTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCariHareketleri
            // 
            this.btnCariHareketleri.BackColor = Color.FromArgb(16, 185, 129);
            this.btnCariHareketleri.FlatAppearance.BorderSize = 0;
            this.btnCariHareketleri.FlatStyle = FlatStyle.Flat;
            this.btnCariHareketleri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCariHareketleri.ForeColor = Color.White;
            this.btnCariHareketleri.Location = new Point(20, 60);
            this.btnCariHareketleri.Name = "btnCariHareketleri";
            this.btnCariHareketleri.Size = new Size(328, 35);
            this.btnCariHareketleri.TabIndex = 1;
            this.btnCariHareketleri.Text = "📊 Cari Hareketleri";
            this.btnCariHareketleri.UseVisualStyleBackColor = false;
            this.btnCariHareketleri.Click += this.BtnCariHareketleri_Click;
            // 
            // btnCariEkstresi
            // 
            this.btnCariEkstresi.BackColor = Color.FromArgb(245, 158, 11);
            this.btnCariEkstresi.FlatAppearance.BorderSize = 0;
            this.btnCariEkstresi.FlatStyle = FlatStyle.Flat;
            this.btnCariEkstresi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCariEkstresi.ForeColor = Color.White;
            this.btnCariEkstresi.Location = new Point(20, 105);
            this.btnCariEkstresi.Name = "btnCariEkstresi";
            this.btnCariEkstresi.Size = new Size(328, 35);
            this.btnCariEkstresi.TabIndex = 2;
            this.btnCariEkstresi.Text = "📋 Cari Ekstresi";
            this.btnCariEkstresi.UseVisualStyleBackColor = false;
            this.btnCariEkstresi.Click += this.BtnCariEkstresi_Click;
            // 
            // btnYeniHareket
            // 
            this.btnYeniHareket.BackColor = Color.FromArgb(139, 69, 19);
            this.btnYeniHareket.FlatAppearance.BorderSize = 0;
            this.btnYeniHareket.FlatStyle = FlatStyle.Flat;
            this.btnYeniHareket.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnYeniHareket.ForeColor = Color.White;
            this.btnYeniHareket.Location = new Point(20, 150);
            this.btnYeniHareket.Name = "btnYeniHareket";
            this.btnYeniHareket.Size = new Size(328, 35);
            this.btnYeniHareket.TabIndex = 3;
            this.btnYeniHareket.Text = "➕ Yeni Hareket";
            this.btnYeniHareket.UseVisualStyleBackColor = false;
            this.btnYeniHareket.Click += this.BtnYeniHareket_Click;
            // 
            // cardBakiye
            // 
            this.cardBakiye.BackColor = Color.White;
            this.cardBakiye.BorderStyle = BorderStyle.FixedSingle;
            this.cardBakiye.Controls.Add(this.lblBakiyeTitle);
            this.cardBakiye.Controls.Add(this.lblGuncelBakiye);
            this.cardBakiye.Controls.Add(this.lblGuncelBakiyeValue);
            this.cardBakiye.Controls.Add(this.lblKrediLimiti);
            this.cardBakiye.Controls.Add(this.lblKrediLimitiValue);
            this.cardBakiye.Controls.Add(this.lblKullanilabilirLimit);
            this.cardBakiye.Controls.Add(this.lblKullanilabilirLimitValue);
            this.cardBakiye.Location = new Point(390, 10);
            this.cardBakiye.Name = "cardBakiye";
            this.cardBakiye.Size = new Size(380, 200);
            this.cardBakiye.TabIndex = 1;
            // 
            // lblBakiyeTitle
            // 
            this.lblBakiyeTitle.BackColor = Color.FromArgb(34, 197, 94);
            this.lblBakiyeTitle.Dock = DockStyle.Top;
            this.lblBakiyeTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblBakiyeTitle.ForeColor = Color.White;
            this.lblBakiyeTitle.Location = new Point(0, 0);
            this.lblBakiyeTitle.Name = "lblBakiyeTitle";
            this.lblBakiyeTitle.Size = new Size(378, 40);
            this.lblBakiyeTitle.TabIndex = 0;
            this.lblBakiyeTitle.Text = "💰 Bakiye Bilgileri";
            this.lblBakiyeTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGuncelBakiye
            // 
            this.lblGuncelBakiye.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblGuncelBakiye.Location = new Point(20, 60);
            this.lblGuncelBakiye.Name = "lblGuncelBakiye";
            this.lblGuncelBakiye.Size = new Size(150, 25);
            this.lblGuncelBakiye.TabIndex = 1;
            this.lblGuncelBakiye.Text = "Güncel Bakiye:";
            // 
            // lblGuncelBakiyeValue
            // 
            this.lblGuncelBakiyeValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblGuncelBakiyeValue.ForeColor = Color.FromArgb(34, 197, 94);
            this.lblGuncelBakiyeValue.Location = new Point(180, 60);
            this.lblGuncelBakiyeValue.Name = "lblGuncelBakiyeValue";
            this.lblGuncelBakiyeValue.Size = new Size(180, 25);
            this.lblGuncelBakiyeValue.TabIndex = 2;
            this.lblGuncelBakiyeValue.Text = "₺278,200.00";
            this.lblGuncelBakiyeValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblKrediLimiti
            // 
            this.lblKrediLimiti.Font = new Font("Segoe UI", 10F);
            this.lblKrediLimiti.Location = new Point(20, 100);
            this.lblKrediLimiti.Name = "lblKrediLimiti";
            this.lblKrediLimiti.Size = new Size(150, 25);
            this.lblKrediLimiti.TabIndex = 3;
            this.lblKrediLimiti.Text = "Kredi Limiti:";
            // 
            // lblKrediLimitiValue
            // 
            this.lblKrediLimitiValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblKrediLimitiValue.ForeColor = Color.FromArgb(59, 130, 246);
            this.lblKrediLimitiValue.Location = new Point(180, 100);
            this.lblKrediLimitiValue.Name = "lblKrediLimitiValue";
            this.lblKrediLimitiValue.Size = new Size(180, 25);
            this.lblKrediLimitiValue.TabIndex = 4;
            this.lblKrediLimitiValue.Text = "₺100,001.00";
            this.lblKrediLimitiValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblKullanilabilirLimit
            // 
            this.lblKullanilabilirLimit.Font = new Font("Segoe UI", 10F);
            this.lblKullanilabilirLimit.Location = new Point(20, 140);
            this.lblKullanilabilirLimit.Name = "lblKullanilabilirLimit";
            this.lblKullanilabilirLimit.Size = new Size(150, 25);
            this.lblKullanilabilirLimit.TabIndex = 5;
            this.lblKullanilabilirLimit.Text = "Kullanılabilir Limit:";
            // 
            // lblKullanilabilirLimitValue
            // 
            this.lblKullanilabilirLimitValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblKullanilabilirLimitValue.ForeColor = Color.FromArgb(239, 68, 68);
            this.lblKullanilabilirLimitValue.Location = new Point(180, 140);
            this.lblKullanilabilirLimitValue.Name = "lblKullanilabilirLimitValue";
            this.lblKullanilabilirLimitValue.Size = new Size(180, 25);
            this.lblKullanilabilirLimitValue.TabIndex = 6;
            this.lblKullanilabilirLimitValue.Text = "-₺178,199.00";
            this.lblKullanilabilirLimitValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cardCariDetay
            // 
            this.cardCariDetay.BackColor = Color.White;
            this.cardCariDetay.BorderStyle = BorderStyle.FixedSingle;
            this.cardCariDetay.Controls.Add(this.lblCariTitle);
            this.cardCariDetay.Controls.Add(this.panelCariInfo);
            this.cardCariDetay.Controls.Add(this.panelButtons);
            this.cardCariDetay.Location = new Point(10, 10);
            this.cardCariDetay.Name = "cardCariDetay";
            this.cardCariDetay.Size = new Size(370, 680);
            this.cardCariDetay.TabIndex = 0;
            // 
            // lblCariTitle
            // 
            this.lblCariTitle.BackColor = Color.FromArgb(99, 102, 241);
            this.lblCariTitle.Dock = DockStyle.Top;
            this.lblCariTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblCariTitle.ForeColor = Color.White;
            this.lblCariTitle.Location = new Point(0, 0);
            this.lblCariTitle.Name = "lblCariTitle";
            this.lblCariTitle.Size = new Size(368, 40);
            this.lblCariTitle.TabIndex = 0;
            this.lblCariTitle.Text = "👤 ABC Teknoloji Ltd. Şti. (MUS001)";
            this.lblCariTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCariInfo
            // 
            this.panelCariInfo.Controls.Add(this.lblCariKodu);
            this.panelCariInfo.Controls.Add(this.lblCariKoduValue);
            this.panelCariInfo.Controls.Add(this.lblCariAdi);
            this.panelCariInfo.Controls.Add(this.lblCariAdiValue);
            this.panelCariInfo.Controls.Add(this.lblIletisimKisi);
            this.panelCariInfo.Controls.Add(this.lblIletisimKisiValue);
            this.panelCariInfo.Controls.Add(this.lblTelefon);
            this.panelCariInfo.Controls.Add(this.lblTelefonValue);
            this.panelCariInfo.Controls.Add(this.lblEmail);
            this.panelCariInfo.Controls.Add(this.lblEmailValue);
            this.panelCariInfo.Controls.Add(this.lblCariTipi);
            this.panelCariInfo.Controls.Add(this.lblCariTipiValue);
            this.panelCariInfo.Controls.Add(this.lblVergiDairesi);
            this.panelCariInfo.Controls.Add(this.lblVergiDairesiValue);
            this.panelCariInfo.Controls.Add(this.lblVergiNo);
            this.panelCariInfo.Controls.Add(this.lblVergiNoValue);
            this.panelCariInfo.Controls.Add(this.lblKrediLimitDetay);
            this.panelCariInfo.Controls.Add(this.lblKrediLimitDetayValue);
            this.panelCariInfo.Controls.Add(this.lblKayitTarihi);
            this.panelCariInfo.Controls.Add(this.lblKayitTarihiValue);
            this.panelCariInfo.Dock = DockStyle.Fill;
            this.panelCariInfo.Location = new Point(0, 40);
            this.panelCariInfo.Name = "panelCariInfo";
            this.panelCariInfo.Padding = new Padding(15);
            this.panelCariInfo.Size = new Size(368, 580);
            this.panelCariInfo.TabIndex = 1;
            // 
            // lblCariKodu
            // 
            this.lblCariKodu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCariKodu.Location = new Point(15, 20);
            this.lblCariKodu.Name = "lblCariKodu";
            this.lblCariKodu.Size = new Size(120, 20);
            this.lblCariKodu.TabIndex = 0;
            this.lblCariKodu.Text = "Cari Kodu:";
            // 
            // lblCariKoduValue
            // 
            this.lblCariKoduValue.Font = new Font("Segoe UI", 9F);
            this.lblCariKoduValue.Location = new Point(140, 20);
            this.lblCariKoduValue.Name = "lblCariKoduValue";
            this.lblCariKoduValue.Size = new Size(213, 20);
            this.lblCariKoduValue.TabIndex = 1;
            this.lblCariKoduValue.Text = "MUS001";
            // 
            // lblCariAdi
            // 
            this.lblCariAdi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCariAdi.Location = new Point(15, 50);
            this.lblCariAdi.Name = "lblCariAdi";
            this.lblCariAdi.Size = new Size(120, 20);
            this.lblCariAdi.TabIndex = 2;
            this.lblCariAdi.Text = "Cari Adı:";
            // 
            // lblCariAdiValue
            // 
            this.lblCariAdiValue.Font = new Font("Segoe UI", 9F);
            this.lblCariAdiValue.Location = new Point(140, 50);
            this.lblCariAdiValue.Name = "lblCariAdiValue";
            this.lblCariAdiValue.Size = new Size(213, 20);
            this.lblCariAdiValue.TabIndex = 3;
            this.lblCariAdiValue.Text = "ABC Teknoloji Ltd. Şti.";
            // 
            // lblIletisimKisi
            // 
            this.lblIletisimKisi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblIletisimKisi.Location = new Point(15, 80);
            this.lblIletisimKisi.Name = "lblIletisimKisi";
            this.lblIletisimKisi.Size = new Size(120, 20);
            this.lblIletisimKisi.TabIndex = 4;
            this.lblIletisimKisi.Text = "İletişim Kişisi:";
            // 
            // lblIletisimKisiValue
            // 
            this.lblIletisimKisiValue.Font = new Font("Segoe UI", 9F);
            this.lblIletisimKisiValue.Location = new Point(140, 80);
            this.lblIletisimKisiValue.Name = "lblIletisimKisiValue";
            this.lblIletisimKisiValue.Size = new Size(213, 20);
            this.lblIletisimKisiValue.TabIndex = 5;
            this.lblIletisimKisiValue.Text = "Ahmet Yılmaz";
            // 
            // lblTelefon
            // 
            this.lblTelefon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblTelefon.Location = new Point(15, 110);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new Size(120, 20);
            this.lblTelefon.TabIndex = 6;
            this.lblTelefon.Text = "Telefon:";
            // 
            // lblTelefonValue
            // 
            this.lblTelefonValue.Font = new Font("Segoe UI", 9F);
            this.lblTelefonValue.Location = new Point(140, 110);
            this.lblTelefonValue.Name = "lblTelefonValue";
            this.lblTelefonValue.Size = new Size(213, 20);
            this.lblTelefonValue.TabIndex = 7;
            this.lblTelefonValue.Text = "0212 123 45 63";
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblEmail.Location = new Point(15, 140);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(120, 20);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "E-posta:";
            // 
            // lblEmailValue
            // 
            this.lblEmailValue.Font = new Font("Segoe UI", 9F);
            this.lblEmailValue.Location = new Point(140, 140);
            this.lblEmailValue.Name = "lblEmailValue";
            this.lblEmailValue.Size = new Size(213, 20);
            this.lblEmailValue.TabIndex = 9;
            this.lblEmailValue.Text = "info@abctek.com";
            // 
            // lblCariTipi
            // 
            this.lblCariTipi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCariTipi.Location = new Point(15, 170);
            this.lblCariTipi.Name = "lblCariTipi";
            this.lblCariTipi.Size = new Size(120, 20);
            this.lblCariTipi.TabIndex = 10;
            this.lblCariTipi.Text = "Cari Tipi:";
            // 
            // lblCariTipiValue
            // 
            this.lblCariTipiValue.Font = new Font("Segoe UI", 9F);
            this.lblCariTipiValue.Location = new Point(140, 170);
            this.lblCariTipiValue.Name = "lblCariTipiValue";
            this.lblCariTipiValue.Size = new Size(213, 20);
            this.lblCariTipiValue.TabIndex = 11;
            this.lblCariTipiValue.Text = "Müşteri";
            // 
            // lblVergiDairesi
            // 
            this.lblVergiDairesi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblVergiDairesi.Location = new Point(15, 200);
            this.lblVergiDairesi.Name = "lblVergiDairesi";
            this.lblVergiDairesi.Size = new Size(120, 20);
            this.lblVergiDairesi.TabIndex = 12;
            this.lblVergiDairesi.Text = "Vergi Dairesi:";
            // 
            // lblVergiDairesiValue
            // 
            this.lblVergiDairesiValue.Font = new Font("Segoe UI", 9F);
            this.lblVergiDairesiValue.Location = new Point(140, 200);
            this.lblVergiDairesiValue.Name = "lblVergiDairesiValue";
            this.lblVergiDairesiValue.Size = new Size(213, 20);
            this.lblVergiDairesiValue.TabIndex = 13;
            this.lblVergiDairesiValue.Text = "Beşiktaş VD";
            // 
            // lblVergiNo
            // 
            this.lblVergiNo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblVergiNo.Location = new Point(15, 230);
            this.lblVergiNo.Name = "lblVergiNo";
            this.lblVergiNo.Size = new Size(120, 20);
            this.lblVergiNo.TabIndex = 14;
            this.lblVergiNo.Text = "Vergi Numarası:";
            // 
            // lblVergiNoValue
            // 
            this.lblVergiNoValue.Font = new Font("Segoe UI", 9F);
            this.lblVergiNoValue.Location = new Point(140, 230);
            this.lblVergiNoValue.Name = "lblVergiNoValue";
            this.lblVergiNoValue.Size = new Size(213, 20);
            this.lblVergiNoValue.TabIndex = 15;
            this.lblVergiNoValue.Text = "-";
            // 
            // lblKrediLimitDetay
            // 
            this.lblKrediLimitDetay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblKrediLimitDetay.Location = new Point(15, 260);
            this.lblKrediLimitDetay.Name = "lblKrediLimitDetay";
            this.lblKrediLimitDetay.Size = new Size(120, 20);
            this.lblKrediLimitDetay.TabIndex = 16;
            this.lblKrediLimitDetay.Text = "Kredi Limiti:";
            // 
            // lblKrediLimitDetayValue
            // 
            this.lblKrediLimitDetayValue.Font = new Font("Segoe UI", 9F);
            this.lblKrediLimitDetayValue.Location = new Point(140, 260);
            this.lblKrediLimitDetayValue.Name = "lblKrediLimitDetayValue";
            this.lblKrediLimitDetayValue.Size = new Size(213, 20);
            this.lblKrediLimitDetayValue.TabIndex = 17;
            this.lblKrediLimitDetayValue.Text = "₺100,001.00";
            // 
            // lblKayitTarihi
            // 
            this.lblKayitTarihi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblKayitTarihi.Location = new Point(15, 290);
            this.lblKayitTarihi.Name = "lblKayitTarihi";
            this.lblKayitTarihi.Size = new Size(120, 20);
            this.lblKayitTarihi.TabIndex = 18;
            this.lblKayitTarihi.Text = "Kayıt Tarihi:";
            // 
            // lblKayitTarihiValue
            // 
            this.lblKayitTarihiValue.Font = new Font("Segoe UI", 9F);
            this.lblKayitTarihiValue.Location = new Point(140, 290);
            this.lblKayitTarihiValue.Name = "lblKayitTarihiValue";
            this.lblKayitTarihiValue.Size = new Size(213, 20);
            this.lblKayitTarihiValue.TabIndex = 19;
            this.lblKayitTarihiValue.Text = "14.07.2025 21:21";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnGeri);
            this.panelButtons.Controls.Add(this.btnHareketler);
            this.panelButtons.Controls.Add(this.btnDuzenle);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(0, 620);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(368, 58);
            this.panelButtons.TabIndex = 2;
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = Color.FromArgb(156, 163, 175);
            this.btnGeri.FlatAppearance.BorderSize = 0;
            this.btnGeri.FlatStyle = FlatStyle.Flat;
            this.btnGeri.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnGeri.ForeColor = Color.White;
            this.btnGeri.Location = new Point(15, 15);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new Size(80, 30);
            this.btnGeri.TabIndex = 0;
            this.btnGeri.Text = "🔙 Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += this.BtnGeri_Click;
            // 
            // btnHareketler
            // 
            this.btnHareketler.BackColor = Color.FromArgb(59, 130, 246);
            this.btnHareketler.FlatAppearance.BorderSize = 0;
            this.btnHareketler.FlatStyle = FlatStyle.Flat;
            this.btnHareketler.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnHareketler.ForeColor = Color.White;
            this.btnHareketler.Location = new Point(105, 15);
            this.btnHareketler.Name = "btnHareketler";
            this.btnHareketler.Size = new Size(120, 30);
            this.btnHareketler.TabIndex = 1;
            this.btnHareketler.Text = "📊 Hareketler";
            this.btnHareketler.UseVisualStyleBackColor = false;
            this.btnHareketler.Click += this.BtnHareketler_Click;
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.BackColor = Color.FromArgb(245, 158, 11);
            this.btnDuzenle.FlatAppearance.BorderSize = 0;
            this.btnDuzenle.FlatStyle = FlatStyle.Flat;
            this.btnDuzenle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnDuzenle.ForeColor = Color.White;
            this.btnDuzenle.Location = new Point(235, 15);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new Size(120, 30);
            this.btnDuzenle.TabIndex = 2;
            this.btnDuzenle.Text = "✏️ Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Click += this.BtnDuzenle_Click;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(30, 41, 59);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(1200, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(1200, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👤 Cari Hesap Detayı";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CariDetayForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.ClientSize = new Size(1200, 800);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CariDetayForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Cari Hesap Detayı";
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelCards.ResumeLayout(false);
            this.cardHizliIslemler.ResumeLayout(false);
            this.cardBakiye.ResumeLayout(false);
            this.cardCariDetay.ResumeLayout(false);
            this.panelCariInfo.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelContent;
        private Panel panelCards;
        private Panel cardHizliIslemler;
        private Label lblHizliIslemlerTitle;
        private Button btnCariHareketleri;
        private Button btnCariEkstresi;
        private Button btnYeniHareket;
        private Panel cardBakiye;
        private Label lblBakiyeTitle;
        private Label lblGuncelBakiye;
        private Label lblGuncelBakiyeValue;
        private Label lblKrediLimiti;
        private Label lblKrediLimitiValue;
        private Label lblKullanilabilirLimit;
        private Label lblKullanilabilirLimitValue;
        private Panel cardCariDetay;
        private Label lblCariTitle;
        private Panel panelCariInfo;
        private Label lblCariKodu;
        private Label lblCariKoduValue;
        private Label lblCariAdi;
        private Label lblCariAdiValue;
        private Label lblIletisimKisi;
        private Label lblIletisimKisiValue;
        private Label lblTelefon;
        private Label lblTelefonValue;
        private Label lblEmail;
        private Label lblEmailValue;
        private Label lblCariTipi;
        private Label lblCariTipiValue;
        private Label lblVergiDairesi;
        private Label lblVergiDairesiValue;
        private Label lblVergiNo;
        private Label lblVergiNoValue;
        private Label lblKrediLimitDetay;
        private Label lblKrediLimitDetayValue;
        private Label lblKayitTarihi;
        private Label lblKayitTarihiValue;
        private Panel panelButtons;
        private Button btnGeri;
        private Button btnHareketler;
        private Button btnDuzenle;
        private Panel panelHeader;
        private Label lblTitle;
    }
}


