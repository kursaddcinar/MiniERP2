namespace MiniERP.WinForms.Forms
{
    partial class CariSilForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.lblWarningIcon = new System.Windows.Forms.Label();
            this.lblWarningTitle = new System.Windows.Forms.Label();
            this.lblWarningText = new System.Windows.Forms.Label();
            this.pnlCariInfo = new System.Windows.Forms.Panel();
            this.lblCariKodu = new System.Windows.Forms.Label();
            this.lblCariKoduValue = new System.Windows.Forms.Label();
            this.lblCariTipi = new System.Windows.Forms.Label();
            this.lblCariTipiValue = new System.Windows.Forms.Label();
            this.lblCariAdi = new System.Windows.Forms.Label();
            this.lblCariAdiValue = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.lblDurumValue = new System.Windows.Forms.Label();
            this.lblIletisim = new System.Windows.Forms.Label();
            this.lblIletisimValue = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.lblTelefonValue = new System.Windows.Forms.Label();
            this.lblGuncelBakiye = new System.Windows.Forms.Label();
            this.lblGuncelBakiyeValue = new System.Windows.Forms.Label();
            this.lblKayitTarihi = new System.Windows.Forms.Label();
            this.lblKayitTarihiValue = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnDetayGoruntule = new System.Windows.Forms.Button();
            this.btnEvetSil = new System.Windows.Forms.Button();
            this.pnlBalanceWarning = new System.Windows.Forms.Panel();
            this.lblBalanceWarningIcon = new System.Windows.Forms.Label();
            this.lblBalanceWarningText = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.pnlWarning.SuspendLayout();
            this.pnlCariInfo.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlBalanceWarning.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlHeader.Size = new System.Drawing.Size(650, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(297, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🗑️ Cari Hesap Sil";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.pnlCard);
            this.pnlMain.Controls.Add(this.pnlActions);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(30);
            this.pnlMain.Size = new System.Drawing.Size(650, 540);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.pnlWarning);
            this.pnlCard.Controls.Add(this.pnlCariInfo);
            this.pnlCard.Controls.Add(this.pnlBalanceWarning);
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Location = new System.Drawing.Point(30, 30);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(1);
            this.pnlCard.Size = new System.Drawing.Size(590, 420);
            this.pnlCard.TabIndex = 0;
            // 
            // pnlWarning
            // 
            this.pnlWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(205)))));
            this.pnlWarning.Controls.Add(this.lblWarningIcon);
            this.pnlWarning.Controls.Add(this.lblWarningTitle);
            this.pnlWarning.Controls.Add(this.lblWarningText);
            this.pnlWarning.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWarning.Location = new System.Drawing.Point(1, 1);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlWarning.Size = new System.Drawing.Size(588, 100);
            this.pnlWarning.TabIndex = 0;
            // 
            // lblWarningIcon
            // 
            this.lblWarningIcon.AutoSize = true;
            this.lblWarningIcon.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblWarningIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(77)))), ((int)(((byte)(14)))));
            this.lblWarningIcon.Location = new System.Drawing.Point(20, 15);
            this.lblWarningIcon.Name = "lblWarningIcon";
            this.lblWarningIcon.Size = new System.Drawing.Size(31, 25);
            this.lblWarningIcon.TabIndex = 0;
            this.lblWarningIcon.Text = "⚠️";
            // 
            // lblWarningTitle
            // 
            this.lblWarningTitle.AutoSize = true;
            this.lblWarningTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWarningTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(77)))), ((int)(((byte)(14)))));
            this.lblWarningTitle.Location = new System.Drawing.Point(55, 17);
            this.lblWarningTitle.Name = "lblWarningTitle";
            this.lblWarningTitle.Size = new System.Drawing.Size(113, 21);
            this.lblWarningTitle.TabIndex = 1;
            this.lblWarningTitle.Text = "Silme Onayı";
            // 
            // lblWarningText
            // 
            this.lblWarningText.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWarningText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(77)))), ((int)(((byte)(14)))));
            this.lblWarningText.Location = new System.Drawing.Point(55, 45);
            this.lblWarningText.Name = "lblWarningText";
            this.lblWarningText.Size = new System.Drawing.Size(500, 40);
            this.lblWarningText.TabIndex = 2;
            this.lblWarningText.Text = "Bu işlem geri alınamaz. Cari hesabı silmek istediğinizden emin misiniz?";
            // 
            // pnlCariInfo
            // 
            this.pnlCariInfo.Controls.Add(this.lblCariKodu);
            this.pnlCariInfo.Controls.Add(this.lblCariKoduValue);
            this.pnlCariInfo.Controls.Add(this.lblCariTipi);
            this.pnlCariInfo.Controls.Add(this.lblCariTipiValue);
            this.pnlCariInfo.Controls.Add(this.lblCariAdi);
            this.pnlCariInfo.Controls.Add(this.lblCariAdiValue);
            this.pnlCariInfo.Controls.Add(this.lblDurum);
            this.pnlCariInfo.Controls.Add(this.lblDurumValue);
            this.pnlCariInfo.Controls.Add(this.lblIletisim);
            this.pnlCariInfo.Controls.Add(this.lblIletisimValue);
            this.pnlCariInfo.Controls.Add(this.lblTelefon);
            this.pnlCariInfo.Controls.Add(this.lblTelefonValue);
            this.pnlCariInfo.Controls.Add(this.lblGuncelBakiye);
            this.pnlCariInfo.Controls.Add(this.lblGuncelBakiyeValue);
            this.pnlCariInfo.Controls.Add(this.lblKayitTarihi);
            this.pnlCariInfo.Controls.Add(this.lblKayitTarihiValue);
            this.pnlCariInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCariInfo.Location = new System.Drawing.Point(1, 101);
            this.pnlCariInfo.Name = "pnlCariInfo";
            this.pnlCariInfo.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlCariInfo.Size = new System.Drawing.Size(588, 252);
            this.pnlCariInfo.TabIndex = 1;
            // 
            // lblCariKodu
            // 
            this.lblCariKodu.AutoSize = true;
            this.lblCariKodu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCariKodu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblCariKodu.Location = new System.Drawing.Point(30, 30);
            this.lblCariKodu.Name = "lblCariKodu";
            this.lblCariKodu.Size = new System.Drawing.Size(80, 19);
            this.lblCariKodu.TabIndex = 0;
            this.lblCariKodu.Text = "Cari Kodu:";
            // 
            // lblCariKoduValue
            // 
            this.lblCariKoduValue.AutoSize = true;
            this.lblCariKoduValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCariKoduValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblCariKoduValue.Location = new System.Drawing.Point(200, 30);
            this.lblCariKoduValue.Name = "lblCariKoduValue";
            this.lblCariKoduValue.Size = new System.Drawing.Size(16, 19);
            this.lblCariKoduValue.TabIndex = 1;
            this.lblCariKoduValue.Text = "-";
            // 
            // lblCariTipi
            // 
            this.lblCariTipi.AutoSize = true;
            this.lblCariTipi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCariTipi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblCariTipi.Location = new System.Drawing.Point(320, 30);
            this.lblCariTipi.Name = "lblCariTipi";
            this.lblCariTipi.Size = new System.Drawing.Size(70, 19);
            this.lblCariTipi.TabIndex = 2;
            this.lblCariTipi.Text = "Cari Tipi:";
            // 
            // lblCariTipiValue
            // 
            this.lblCariTipiValue.AutoSize = true;
            this.lblCariTipiValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCariTipiValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblCariTipiValue.Location = new System.Drawing.Point(420, 30);
            this.lblCariTipiValue.Name = "lblCariTipiValue";
            this.lblCariTipiValue.Size = new System.Drawing.Size(16, 19);
            this.lblCariTipiValue.TabIndex = 3;
            this.lblCariTipiValue.Text = "-";
            // 
            // lblCariAdi
            // 
            this.lblCariAdi.AutoSize = true;
            this.lblCariAdi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCariAdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblCariAdi.Location = new System.Drawing.Point(30, 70);
            this.lblCariAdi.Name = "lblCariAdi";
            this.lblCariAdi.Size = new System.Drawing.Size(70, 19);
            this.lblCariAdi.TabIndex = 4;
            this.lblCariAdi.Text = "Cari Adı:";
            // 
            // lblCariAdiValue
            // 
            this.lblCariAdiValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCariAdiValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblCariAdiValue.Location = new System.Drawing.Point(200, 70);
            this.lblCariAdiValue.Name = "lblCariAdiValue";
            this.lblCariAdiValue.Size = new System.Drawing.Size(350, 19);
            this.lblCariAdiValue.TabIndex = 5;
            this.lblCariAdiValue.Text = "-";
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDurum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblDurum.Location = new System.Drawing.Point(30, 110);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(60, 19);
            this.lblDurum.TabIndex = 6;
            this.lblDurum.Text = "Durum:";
            // 
            // lblDurumValue
            // 
            this.lblDurumValue.AutoSize = true;
            this.lblDurumValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDurumValue.Location = new System.Drawing.Point(200, 110);
            this.lblDurumValue.Name = "lblDurumValue";
            this.lblDurumValue.Size = new System.Drawing.Size(16, 19);
            this.lblDurumValue.TabIndex = 7;
            this.lblDurumValue.Text = "-";
            // 
            // lblIletisim
            // 
            this.lblIletisim.AutoSize = true;
            this.lblIletisim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIletisim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblIletisim.Location = new System.Drawing.Point(320, 110);
            this.lblIletisim.Name = "lblIletisim";
            this.lblIletisim.Size = new System.Drawing.Size(68, 19);
            this.lblIletisim.TabIndex = 8;
            this.lblIletisim.Text = "İletişim:";
            // 
            // lblIletisimValue
            // 
            this.lblIletisimValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblIletisimValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblIletisimValue.Location = new System.Drawing.Point(420, 110);
            this.lblIletisimValue.Name = "lblIletisimValue";
            this.lblIletisimValue.Size = new System.Drawing.Size(130, 19);
            this.lblIletisimValue.TabIndex = 9;
            this.lblIletisimValue.Text = "-";
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTelefon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblTelefon.Location = new System.Drawing.Point(30, 150);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(68, 19);
            this.lblTelefon.TabIndex = 10;
            this.lblTelefon.Text = "Telefon:";
            // 
            // lblTelefonValue
            // 
            this.lblTelefonValue.AutoSize = true;
            this.lblTelefonValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTelefonValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTelefonValue.Location = new System.Drawing.Point(200, 150);
            this.lblTelefonValue.Name = "lblTelefonValue";
            this.lblTelefonValue.Size = new System.Drawing.Size(16, 19);
            this.lblTelefonValue.TabIndex = 11;
            this.lblTelefonValue.Text = "-";
            // 
            // lblGuncelBakiye
            // 
            this.lblGuncelBakiye.AutoSize = true;
            this.lblGuncelBakiye.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGuncelBakiye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblGuncelBakiye.Location = new System.Drawing.Point(320, 150);
            this.lblGuncelBakiye.Name = "lblGuncelBakiye";
            this.lblGuncelBakiye.Size = new System.Drawing.Size(115, 19);
            this.lblGuncelBakiye.TabIndex = 12;
            this.lblGuncelBakiye.Text = "Güncel Bakiye:";
            // 
            // lblGuncelBakiyeValue
            // 
            this.lblGuncelBakiyeValue.AutoSize = true;
            this.lblGuncelBakiyeValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGuncelBakiyeValue.Location = new System.Drawing.Point(445, 150);
            this.lblGuncelBakiyeValue.Name = "lblGuncelBakiyeValue";
            this.lblGuncelBakiyeValue.Size = new System.Drawing.Size(16, 19);
            this.lblGuncelBakiyeValue.TabIndex = 13;
            this.lblGuncelBakiyeValue.Text = "-";
            // 
            // lblKayitTarihi
            // 
            this.lblKayitTarihi.AutoSize = true;
            this.lblKayitTarihi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKayitTarihi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblKayitTarihi.Location = new System.Drawing.Point(30, 190);
            this.lblKayitTarihi.Name = "lblKayitTarihi";
            this.lblKayitTarihi.Size = new System.Drawing.Size(98, 19);
            this.lblKayitTarihi.TabIndex = 14;
            this.lblKayitTarihi.Text = "Kayıt Tarihi:";
            // 
            // lblKayitTarihiValue
            // 
            this.lblKayitTarihiValue.AutoSize = true;
            this.lblKayitTarihiValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKayitTarihiValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblKayitTarihiValue.Location = new System.Drawing.Point(200, 190);
            this.lblKayitTarihiValue.Name = "lblKayitTarihiValue";
            this.lblKayitTarihiValue.Size = new System.Drawing.Size(16, 19);
            this.lblKayitTarihiValue.TabIndex = 15;
            this.lblKayitTarihiValue.Text = "-";
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnIptal);
            this.pnlActions.Controls.Add(this.btnDetayGoruntule);
            this.pnlActions.Controls.Add(this.btnEvetSil);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(30, 450);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.pnlActions.Size = new System.Drawing.Size(590, 60);
            this.pnlActions.TabIndex = 1;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(0, 10);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(120, 40);
            this.btnIptal.TabIndex = 0;
            this.btnIptal.Text = "↩️ İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.BtnIptal_Click);
            // 
            // btnDetayGoruntule
            // 
            this.btnDetayGoruntule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnDetayGoruntule.FlatAppearance.BorderSize = 0;
            this.btnDetayGoruntule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetayGoruntule.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDetayGoruntule.ForeColor = System.Drawing.Color.White;
            this.btnDetayGoruntule.Location = new System.Drawing.Point(235, 10);
            this.btnDetayGoruntule.Name = "btnDetayGoruntule";
            this.btnDetayGoruntule.Size = new System.Drawing.Size(140, 40);
            this.btnDetayGoruntule.TabIndex = 1;
            this.btnDetayGoruntule.Text = "📄 Detay Görüntüle";
            this.btnDetayGoruntule.UseVisualStyleBackColor = false;
            this.btnDetayGoruntule.Click += new System.EventHandler(this.BtnDetayGoruntule_Click);
            // 
            // btnEvetSil
            // 
            this.btnEvetSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEvetSil.FlatAppearance.BorderSize = 0;
            this.btnEvetSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvetSil.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEvetSil.ForeColor = System.Drawing.Color.White;
            this.btnEvetSil.Location = new System.Drawing.Point(470, 10);
            this.btnEvetSil.Name = "btnEvetSil";
            this.btnEvetSil.Size = new System.Drawing.Size(120, 40);
            this.btnEvetSil.TabIndex = 2;
            this.btnEvetSil.Text = "🗑️ Evet, Sil";
            this.btnEvetSil.UseVisualStyleBackColor = false;
            this.btnEvetSil.Click += new System.EventHandler(this.BtnEvetSil_Click);
            // 
            // pnlBalanceWarning
            // 
            this.pnlBalanceWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.pnlBalanceWarning.Controls.Add(this.lblBalanceWarningIcon);
            this.pnlBalanceWarning.Controls.Add(this.lblBalanceWarningText);
            this.pnlBalanceWarning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBalanceWarning.Location = new System.Drawing.Point(1, 353);
            this.pnlBalanceWarning.Name = "pnlBalanceWarning";
            this.pnlBalanceWarning.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlBalanceWarning.Size = new System.Drawing.Size(588, 66);
            this.pnlBalanceWarning.TabIndex = 2;
            this.pnlBalanceWarning.Visible = false;
            // 
            // lblBalanceWarningIcon
            // 
            this.lblBalanceWarningIcon.AutoSize = true;
            this.lblBalanceWarningIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBalanceWarningIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.lblBalanceWarningIcon.Location = new System.Drawing.Point(20, 20);
            this.lblBalanceWarningIcon.Name = "lblBalanceWarningIcon";
            this.lblBalanceWarningIcon.Size = new System.Drawing.Size(25, 21);
            this.lblBalanceWarningIcon.TabIndex = 0;
            this.lblBalanceWarningIcon.Text = "⚠️";
            // 
            // lblBalanceWarningText
            // 
            this.lblBalanceWarningText.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBalanceWarningText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.lblBalanceWarningText.Location = new System.Drawing.Point(50, 15);
            this.lblBalanceWarningText.Name = "lblBalanceWarningText";
            this.lblBalanceWarningText.Size = new System.Drawing.Size(520, 36);
            this.lblBalanceWarningText.TabIndex = 1;
            this.lblBalanceWarningText.Text = "Uyarı: Bu cari hesabın bakiyesi sıfır değil ($278,200.00). Silmeden önce bakiyey" +
    "i sıfırlamanız önerilir.";
            // 
            // CariSilForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 600);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CariSilForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cari Hesap Sil";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.pnlWarning.ResumeLayout(false);
            this.pnlWarning.PerformLayout();
            this.pnlCariInfo.ResumeLayout(false);
            this.pnlCariInfo.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlBalanceWarning.ResumeLayout(false);
            this.pnlBalanceWarning.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Label lblWarningIcon;
        private System.Windows.Forms.Label lblWarningTitle;
        private System.Windows.Forms.Label lblWarningText;
        private System.Windows.Forms.Panel pnlCariInfo;
        private System.Windows.Forms.Label lblCariKodu;
        private System.Windows.Forms.Label lblCariKoduValue;
        private System.Windows.Forms.Label lblCariTipi;
        private System.Windows.Forms.Label lblCariTipiValue;
        private System.Windows.Forms.Label lblCariAdi;
        private System.Windows.Forms.Label lblCariAdiValue;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Label lblDurumValue;
        private System.Windows.Forms.Label lblIletisim;
        private System.Windows.Forms.Label lblIletisimValue;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.Label lblTelefonValue;
        private System.Windows.Forms.Label lblGuncelBakiye;
        private System.Windows.Forms.Label lblGuncelBakiyeValue;
        private System.Windows.Forms.Label lblKayitTarihi;
        private System.Windows.Forms.Label lblKayitTarihiValue;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnDetayGoruntule;
        private System.Windows.Forms.Button btnEvetSil;
        private System.Windows.Forms.Panel pnlBalanceWarning;
        private System.Windows.Forms.Label lblBalanceWarningIcon;
        private System.Windows.Forms.Label lblBalanceWarningText;
    }
}
