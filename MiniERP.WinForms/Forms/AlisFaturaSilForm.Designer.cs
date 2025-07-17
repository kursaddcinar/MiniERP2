namespace MiniERP.WinForms.Forms
{
    partial class AlisFaturaSilForm
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
            this.groupBoxOnay = new GroupBox();
            this.btnDetaylar = new Button();
            this.btnGeri = new Button();
            this.btnSil = new Button();
            this.chkOnay = new CheckBox();
            this.groupBoxEtkiler = new GroupBox();
            this.lblEtki4 = new Label();
            this.lblEtki3 = new Label();
            this.lblEtki2 = new Label();
            this.lblEtki1 = new Label();
            this.groupBoxKalemler = new GroupBox();
            this.dataGridViewKalemler = new DataGridView();
            this.lblKalemSayisi = new Label();
            this.groupBoxFaturaBilgi = new GroupBox();
            this.tableLayoutPanelBilgi = new TableLayoutPanel();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.lblFaturaNo = new Label();
            this.lblFaturaTarihi = new Label();
            this.lblTedarikci = new Label();
            this.lblDepo = new Label();
            this.lblDurum = new Label();
            this.lblAraToplam = new Label();
            this.lblKdvTutari = new Label();
            this.lblGenelToplam = new Label();
            this.lblBaslik = new Label();
            this.panelMain.SuspendLayout();
            this.groupBoxOnay.SuspendLayout();
            this.groupBoxEtkiler.SuspendLayout();
            this.groupBoxKalemler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKalemler)).BeginInit();
            this.groupBoxFaturaBilgi.SuspendLayout();
            this.tableLayoutPanelBilgi.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Controls.Add(this.groupBoxOnay);
            this.panelMain.Controls.Add(this.groupBoxEtkiler);
            this.panelMain.Controls.Add(this.groupBoxKalemler);
            this.panelMain.Controls.Add(this.groupBoxFaturaBilgi);
            this.panelMain.Controls.Add(this.lblBaslik);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(900, 700);
            this.panelMain.TabIndex = 0;
            // 
            // groupBoxOnay
            // 
            this.groupBoxOnay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.groupBoxOnay.Controls.Add(this.btnDetaylar);
            this.groupBoxOnay.Controls.Add(this.btnGeri);
            this.groupBoxOnay.Controls.Add(this.btnSil);
            this.groupBoxOnay.Controls.Add(this.chkOnay);
            this.groupBoxOnay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.groupBoxOnay.ForeColor = Color.DarkRed;
            this.groupBoxOnay.Location = new Point(23, 580);
            this.groupBoxOnay.Name = "groupBoxOnay";
            this.groupBoxOnay.Size = new Size(854, 100);
            this.groupBoxOnay.TabIndex = 4;
            this.groupBoxOnay.TabStop = false;
            this.groupBoxOnay.Text = "Silme Onayı";
            // 
            // btnDetaylar
            // 
            this.btnDetaylar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnDetaylar.BackColor = Color.FromArgb(23, 162, 184);
            this.btnDetaylar.FlatAppearance.BorderSize = 0;
            this.btnDetaylar.FlatStyle = FlatStyle.Flat;
            this.btnDetaylar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnDetaylar.ForeColor = Color.White;
            this.btnDetaylar.Location = new Point(586, 60);
            this.btnDetaylar.Name = "btnDetaylar";
            this.btnDetaylar.Size = new Size(120, 32);
            this.btnDetaylar.TabIndex = 3;
            this.btnDetaylar.Text = "🔍 Detayları Gör";
            this.btnDetaylar.UseVisualStyleBackColor = false;
            this.btnDetaylar.Click += this.btnDetaylar_Click;
            // 
            // btnGeri
            // 
            this.btnGeri.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnGeri.BackColor = Color.FromArgb(108, 117, 125);
            this.btnGeri.FlatAppearance.BorderSize = 0;
            this.btnGeri.FlatStyle = FlatStyle.Flat;
            this.btnGeri.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnGeri.ForeColor = Color.White;
            this.btnGeri.Location = new Point(15, 60);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new Size(80, 32);
            this.btnGeri.TabIndex = 1;
            this.btnGeri.Text = "← Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += this.btnGeri_Click;
            // 
            // btnSil
            // 
            this.btnSil.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnSil.BackColor = Color.FromArgb(220, 53, 69);
            this.btnSil.FlatAppearance.BorderSize = 0;
            this.btnSil.FlatStyle = FlatStyle.Flat;
            this.btnSil.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSil.ForeColor = Color.White;
            this.btnSil.Location = new Point(712, 60);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new Size(120, 32);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "🗑️ Faturayı Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += this.btnSil_Click;
            // 
            // chkOnay
            // 
            this.chkOnay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.chkOnay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.chkOnay.ForeColor = Color.DarkRed;
            this.chkOnay.Location = new Point(15, 25);
            this.chkOnay.Name = "chkOnay";
            this.chkOnay.Size = new Size(825, 25);
            this.chkOnay.TabIndex = 0;
            this.chkOnay.Text = "Yukarıdaki uyarıları okudum ve anladım. Bu faturayı silmek istediğimi onaylıyorum.";
            this.chkOnay.UseVisualStyleBackColor = true;
            this.chkOnay.CheckedChanged += this.chkOnay_CheckedChanged;
            // 
            // groupBoxEtkiler
            // 
            this.groupBoxEtkiler.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.groupBoxEtkiler.Controls.Add(this.lblEtki4);
            this.groupBoxEtkiler.Controls.Add(this.lblEtki3);
            this.groupBoxEtkiler.Controls.Add(this.lblEtki2);
            this.groupBoxEtkiler.Controls.Add(this.lblEtki1);
            this.groupBoxEtkiler.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.groupBoxEtkiler.ForeColor = Color.DarkOrange;
            this.groupBoxEtkiler.Location = new Point(23, 450);
            this.groupBoxEtkiler.Name = "groupBoxEtkiler";
            this.groupBoxEtkiler.Size = new Size(854, 120);
            this.groupBoxEtkiler.TabIndex = 3;
            this.groupBoxEtkiler.TabStop = false;
            this.groupBoxEtkiler.Text = "⚠️ Silme İşlemi Etkileri";
            // 
            // lblEtki4
            // 
            this.lblEtki4.AutoSize = true;
            this.lblEtki4.Font = new Font("Segoe UI", 9F);
            this.lblEtki4.ForeColor = Color.Black;
            this.lblEtki4.Location = new Point(15, 90);
            this.lblEtki4.Name = "lblEtki4";
            this.lblEtki4.Size = new Size(427, 15);
            this.lblEtki4.TabIndex = 3;
            this.lblEtki4.Text = "→ Raporlar etkilenecektir - Satın alma raporları ve analizler güncellenecek.";
            // 
            // lblEtki3
            // 
            this.lblEtki3.AutoSize = true;
            this.lblEtki3.Font = new Font("Segoe UI", 9F);
            this.lblEtki3.ForeColor = Color.Black;
            this.lblEtki3.Location = new Point(15, 68);
            this.lblEtki3.Name = "lblEtki3";
            this.lblEtki3.Size = new Size(496, 15);
            this.lblEtki3.TabIndex = 2;
            this.lblEtki3.Text = "→ Tedarikçi hesap bakiyesi güncellenecektir - Tedarikçi bakiyesinden düşülecek.";
            // 
            // lblEtki2
            // 
            this.lblEtki2.AutoSize = true;
            this.lblEtki2.Font = new Font("Segoe UI", 9F);
            this.lblEtki2.ForeColor = Color.Black;
            this.lblEtki2.Location = new Point(15, 46);
            this.lblEtki2.Name = "lblEtki2";
            this.lblEtki2.Size = new Size(423, 15);
            this.lblEtki2.TabIndex = 1;
            this.lblEtki2.Text = "→ Stok hareketleri etkilenebilir - Stok miktarları tekrar hesaplanacak.";
            // 
            // lblEtki1
            // 
            this.lblEtki1.AutoSize = true;
            this.lblEtki1.Font = new Font("Segoe UI", 9F);
            this.lblEtki1.ForeColor = Color.Black;
            this.lblEtki1.Location = new Point(15, 24);
            this.lblEtki1.Name = "lblEtki1";
            this.lblEtki1.Size = new Size(351, 15);
            this.lblEtki1.TabIndex = 0;
            this.lblEtki1.Text = "→ Fatura tamamen silinecektir ve geri getirilemez.";
            // 
            // groupBoxKalemler
            // 
            this.groupBoxKalemler.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.groupBoxKalemler.Controls.Add(this.dataGridViewKalemler);
            this.groupBoxKalemler.Controls.Add(this.lblKalemSayisi);
            this.groupBoxKalemler.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.groupBoxKalemler.ForeColor = Color.FromArgb(52, 73, 94);
            this.groupBoxKalemler.Location = new Point(23, 220);
            this.groupBoxKalemler.Name = "groupBoxKalemler";
            this.groupBoxKalemler.Size = new Size(854, 220);
            this.groupBoxKalemler.TabIndex = 2;
            this.groupBoxKalemler.TabStop = false;
            this.groupBoxKalemler.Text = "Fatura Kalemleri";
            // 
            // dataGridViewKalemler
            // 
            this.dataGridViewKalemler.AllowUserToAddRows = false;
            this.dataGridViewKalemler.AllowUserToDeleteRows = false;
            this.dataGridViewKalemler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dataGridViewKalemler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewKalemler.BackgroundColor = Color.White;
            this.dataGridViewKalemler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKalemler.Location = new Point(15, 45);
            this.dataGridViewKalemler.MultiSelect = false;
            this.dataGridViewKalemler.Name = "dataGridViewKalemler";
            this.dataGridViewKalemler.ReadOnly = true;
            this.dataGridViewKalemler.RowHeadersVisible = false;
            this.dataGridViewKalemler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKalemler.Size = new Size(825, 160);
            this.dataGridViewKalemler.TabIndex = 1;
            // 
            // lblKalemSayisi
            // 
            this.lblKalemSayisi.AutoSize = true;
            this.lblKalemSayisi.Font = new Font("Segoe UI", 9F);
            this.lblKalemSayisi.ForeColor = Color.Gray;
            this.lblKalemSayisi.Location = new Point(130, 0);
            this.lblKalemSayisi.Name = "lblKalemSayisi";
            this.lblKalemSayisi.Size = new Size(0, 15);
            this.lblKalemSayisi.TabIndex = 0;
            // 
            // groupBoxFaturaBilgi
            // 
            this.groupBoxFaturaBilgi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.groupBoxFaturaBilgi.Controls.Add(this.tableLayoutPanelBilgi);
            this.groupBoxFaturaBilgi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.groupBoxFaturaBilgi.ForeColor = Color.FromArgb(52, 73, 94);
            this.groupBoxFaturaBilgi.Location = new Point(23, 60);
            this.groupBoxFaturaBilgi.Name = "groupBoxFaturaBilgi";
            this.groupBoxFaturaBilgi.Size = new Size(854, 150);
            this.groupBoxFaturaBilgi.TabIndex = 1;
            this.groupBoxFaturaBilgi.TabStop = false;
            this.groupBoxFaturaBilgi.Text = "Silinecek Fatura Bilgileri";
            // 
            // tableLayoutPanelBilgi
            // 
            this.tableLayoutPanelBilgi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.tableLayoutPanelBilgi.ColumnCount = 4;
            this.tableLayoutPanelBilgi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            this.tableLayoutPanelBilgi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            this.tableLayoutPanelBilgi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            this.tableLayoutPanelBilgi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            this.tableLayoutPanelBilgi.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelBilgi.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanelBilgi.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanelBilgi.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanelBilgi.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanelBilgi.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanelBilgi.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanelBilgi.Controls.Add(this.label8, 2, 3);
            this.tableLayoutPanelBilgi.Controls.Add(this.lblFaturaNo, 1, 0);
            this.tableLayoutPanelBilgi.Controls.Add(this.lblFaturaTarihi, 1, 1);
            this.tableLayoutPanelBilgi.Controls.Add(this.lblTedarikci, 1, 2);
            this.tableLayoutPanelBilgi.Controls.Add(this.lblDepo, 1, 3);
            this.tableLayoutPanelBilgi.Controls.Add(this.lblDurum, 3, 0);
            this.tableLayoutPanelBilgi.Controls.Add(this.lblAraToplam, 3, 1);
            this.tableLayoutPanelBilgi.Controls.Add(this.lblKdvTutari, 3, 2);
            this.tableLayoutPanelBilgi.Controls.Add(this.lblGenelToplam, 3, 3);
            this.tableLayoutPanelBilgi.Location = new Point(15, 25);
            this.tableLayoutPanelBilgi.Name = "tableLayoutPanelBilgi";
            this.tableLayoutPanelBilgi.RowCount = 4;
            this.tableLayoutPanelBilgi.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableLayoutPanelBilgi.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableLayoutPanelBilgi.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableLayoutPanelBilgi.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableLayoutPanelBilgi.Size = new Size(825, 110);
            this.tableLayoutPanelBilgi.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 9F);
            this.label1.ForeColor = Color.Black;
            this.label1.Location = new Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new Size(64, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fatura No:";
            // 
            // label2
            // 
            this.label2.Anchor = AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI", 9F);
            this.label2.ForeColor = Color.Black;
            this.label2.Location = new Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new Size(77, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fatura Tarihi:";
            // 
            // label3
            // 
            this.label3.Anchor = AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Segoe UI", 9F);
            this.label3.ForeColor = Color.Black;
            this.label3.Location = new Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new Size(58, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tedarikçi:";
            // 
            // label4
            // 
            this.label4.Anchor = AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Segoe UI", 9F);
            this.label4.ForeColor = Color.Black;
            this.label4.Location = new Point(3, 89);
            this.label4.Name = "label4";
            this.label4.Size = new Size(37, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Depo:";
            // 
            // label5
            // 
            this.label5.Anchor = AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Segoe UI", 9F);
            this.label5.ForeColor = Color.Black;
            this.label5.Location = new Point(415, 7);
            this.label5.Name = "label5";
            this.label5.Size = new Size(45, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Durum:";
            // 
            // label6
            // 
            this.label6.Anchor = AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Segoe UI", 9F);
            this.label6.ForeColor = Color.Black;
            this.label6.Location = new Point(415, 34);
            this.label6.Name = "label6";
            this.label6.Size = new Size(70, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ara Toplam:";
            // 
            // label7
            // 
            this.label7.Anchor = AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new Font("Segoe UI", 9F);
            this.label7.ForeColor = Color.Black;
            this.label7.Location = new Point(415, 62);
            this.label7.Name = "label7";
            this.label7.Size = new Size(67, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "KDV Tutarı:";
            // 
            // label8
            // 
            this.label8.Anchor = AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.label8.ForeColor = Color.Black;
            this.label8.Location = new Point(415, 89);
            this.label8.Name = "label8";
            this.label8.Size = new Size(88, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Genel Toplam:";
            // 
            // lblFaturaNo
            // 
            this.lblFaturaNo.Anchor = AnchorStyles.Left;
            this.lblFaturaNo.AutoSize = true;
            this.lblFaturaNo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblFaturaNo.ForeColor = Color.FromArgb(0, 123, 255);
            this.lblFaturaNo.Location = new Point(126, 7);
            this.lblFaturaNo.Name = "lblFaturaNo";
            this.lblFaturaNo.Size = new Size(12, 15);
            this.lblFaturaNo.TabIndex = 8;
            this.lblFaturaNo.Text = "-";
            // 
            // lblFaturaTarihi
            // 
            this.lblFaturaTarihi.Anchor = AnchorStyles.Left;
            this.lblFaturaTarihi.AutoSize = true;
            this.lblFaturaTarihi.Font = new Font("Segoe UI", 9F);
            this.lblFaturaTarihi.ForeColor = Color.Black;
            this.lblFaturaTarihi.Location = new Point(126, 34);
            this.lblFaturaTarihi.Name = "lblFaturaTarihi";
            this.lblFaturaTarihi.Size = new Size(12, 15);
            this.lblFaturaTarihi.TabIndex = 9;
            this.lblFaturaTarihi.Text = "-";
            // 
            // lblTedarikci
            // 
            this.lblTedarikci.Anchor = AnchorStyles.Left;
            this.lblTedarikci.AutoSize = true;
            this.lblTedarikci.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblTedarikci.ForeColor = Color.Black;
            this.lblTedarikci.Location = new Point(126, 62);
            this.lblTedarikci.Name = "lblTedarikci";
            this.lblTedarikci.Size = new Size(12, 15);
            this.lblTedarikci.TabIndex = 10;
            this.lblTedarikci.Text = "-";
            // 
            // lblDepo
            // 
            this.lblDepo.Anchor = AnchorStyles.Left;
            this.lblDepo.AutoSize = true;
            this.lblDepo.Font = new Font("Segoe UI", 9F);
            this.lblDepo.ForeColor = Color.Black;
            this.lblDepo.Location = new Point(126, 89);
            this.lblDepo.Name = "lblDepo";
            this.lblDepo.Size = new Size(12, 15);
            this.lblDepo.TabIndex = 11;
            this.lblDepo.Text = "-";
            // 
            // lblDurum
            // 
            this.lblDurum.Anchor = AnchorStyles.Left;
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDurum.ForeColor = Color.Orange;
            this.lblDurum.Location = new Point(537, 7);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new Size(12, 15);
            this.lblDurum.TabIndex = 12;
            this.lblDurum.Text = "-";
            // 
            // lblAraToplam
            // 
            this.lblAraToplam.Anchor = AnchorStyles.Left;
            this.lblAraToplam.AutoSize = true;
            this.lblAraToplam.Font = new Font("Segoe UI", 9F);
            this.lblAraToplam.ForeColor = Color.Black;
            this.lblAraToplam.Location = new Point(537, 34);
            this.lblAraToplam.Name = "lblAraToplam";
            this.lblAraToplam.Size = new Size(12, 15);
            this.lblAraToplam.TabIndex = 13;
            this.lblAraToplam.Text = "-";
            // 
            // lblKdvTutari
            // 
            this.lblKdvTutari.Anchor = AnchorStyles.Left;
            this.lblKdvTutari.AutoSize = true;
            this.lblKdvTutari.Font = new Font("Segoe UI", 9F);
            this.lblKdvTutari.ForeColor = Color.Black;
            this.lblKdvTutari.Location = new Point(537, 62);
            this.lblKdvTutari.Name = "lblKdvTutari";
            this.lblKdvTutari.Size = new Size(12, 15);
            this.lblKdvTutari.TabIndex = 14;
            this.lblKdvTutari.Text = "-";
            // 
            // lblGenelToplam
            // 
            this.lblGenelToplam.Anchor = AnchorStyles.Left;
            this.lblGenelToplam.AutoSize = true;
            this.lblGenelToplam.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblGenelToplam.ForeColor = Color.FromArgb(220, 53, 69);
            this.lblGenelToplam.Location = new Point(537, 89);
            this.lblGenelToplam.Name = "lblGenelToplam";
            this.lblGenelToplam.Size = new Size(12, 15);
            this.lblGenelToplam.TabIndex = 15;
            this.lblGenelToplam.Text = "-";
            // 
            // lblBaslik
            // 
            this.lblBaslik.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.lblBaslik.BackColor = Color.FromArgb(220, 53, 69);
            this.lblBaslik.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.White;
            this.lblBaslik.Location = new Point(23, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(854, 35);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "⚠️ Dikkat! Satın Alma Faturası Silme İşlemi";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AlisFaturaSilForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(900, 700);
            this.Controls.Add(this.panelMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlisFaturaSilForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Alış Faturası Sil";
            this.panelMain.ResumeLayout(false);
            this.groupBoxOnay.ResumeLayout(false);
            this.groupBoxEtkiler.ResumeLayout(false);
            this.groupBoxEtkiler.PerformLayout();
            this.groupBoxKalemler.ResumeLayout(false);
            this.groupBoxKalemler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKalemler)).EndInit();
            this.groupBoxFaturaBilgi.ResumeLayout(false);
            this.tableLayoutPanelBilgi.ResumeLayout(false);
            this.tableLayoutPanelBilgi.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Label lblBaslik;
        private GroupBox groupBoxFaturaBilgi;
        private TableLayoutPanel tableLayoutPanelBilgi;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblFaturaNo;
        private Label lblFaturaTarihi;
        private Label lblTedarikci;
        private Label lblDepo;
        private Label lblDurum;
        private Label lblAraToplam;
        private Label lblKdvTutari;
        private Label lblGenelToplam;
        private GroupBox groupBoxKalemler;
        private DataGridView dataGridViewKalemler;
        private Label lblKalemSayisi;
        private GroupBox groupBoxEtkiler;
        private Label lblEtki4;
        private Label lblEtki3;
        private Label lblEtki2;
        private Label lblEtki1;
        private GroupBox groupBoxOnay;
        private CheckBox chkOnay;
        private Button btnSil;
        private Button btnGeri;
        private Button btnDetaylar;
    }
}
