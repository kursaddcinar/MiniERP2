namespace MiniERP.WinForms.Forms
{
    partial class CariAccountDetailsForm
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpBasicInfo = new System.Windows.Forms.GroupBox();
            this.btnCopyCode = new System.Windows.Forms.Button();
            this.txtCariCode = new System.Windows.Forms.TextBox();
            this.lblCariCode = new System.Windows.Forms.Label();
            this.txtCariName = new System.Windows.Forms.TextBox();
            this.lblCariName = new System.Windows.Forms.Label();
            this.txtCariType = new System.Windows.Forms.TextBox();
            this.lblCariType = new System.Windows.Forms.Label();
            this.txtIsActive = new System.Windows.Forms.TextBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.grpTaxInfo = new System.Windows.Forms.GroupBox();
            this.btnCopyTaxNumber = new System.Windows.Forms.Button();
            this.txtTaxNumber = new System.Windows.Forms.TextBox();
            this.lblTaxNumber = new System.Windows.Forms.Label();
            this.txtTaxOffice = new System.Windows.Forms.TextBox();
            this.lblTaxOffice = new System.Windows.Forms.Label();
            this.grpContactInfo = new System.Windows.Forms.GroupBox();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnCallPhone = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.grpFinancialInfo = new System.Windows.Forms.GroupBox();
            this.btnRefreshBalance = new System.Windows.Forms.Button();
            this.txtCreditLimit = new System.Windows.Forms.TextBox();
            this.lblCreditLimit = new System.Windows.Forms.Label();
            this.txtCurrentBalance = new System.Windows.Forms.TextBox();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.txtBalanceType = new System.Windows.Forms.TextBox();
            this.lblBalanceType = new System.Windows.Forms.Label();
            this.grpSystemInfo = new System.Windows.Forms.GroupBox();
            this.txtCreatedDate = new System.Windows.Forms.TextBox();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnViewTransactions = new System.Windows.Forms.Button();
            this.btnViewStatement = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnActivateDeactivate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpBasicInfo.SuspendLayout();
            this.grpTaxInfo.SuspendLayout();
            this.grpContactInfo.SuspendLayout();
            this.grpFinancialInfo.SuspendLayout();
            this.grpSystemInfo.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(800, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(149, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cari Hesap Detayı";
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.grpSystemInfo);
            this.pnlMain.Controls.Add(this.grpFinancialInfo);
            this.pnlMain.Controls.Add(this.grpContactInfo);
            this.pnlMain.Controls.Add(this.grpTaxInfo);
            this.pnlMain.Controls.Add(this.grpBasicInfo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(650, 540);
            this.pnlMain.TabIndex = 1;
            // 
            // grpBasicInfo
            // 
            this.grpBasicInfo.Controls.Add(this.lblIsActive);
            this.grpBasicInfo.Controls.Add(this.txtIsActive);
            this.grpBasicInfo.Controls.Add(this.lblCariType);
            this.grpBasicInfo.Controls.Add(this.txtCariType);
            this.grpBasicInfo.Controls.Add(this.lblCariName);
            this.grpBasicInfo.Controls.Add(this.txtCariName);
            this.grpBasicInfo.Controls.Add(this.lblCariCode);
            this.grpBasicInfo.Controls.Add(this.txtCariCode);
            this.grpBasicInfo.Controls.Add(this.btnCopyCode);
            this.grpBasicInfo.Location = new System.Drawing.Point(12, 12);
            this.grpBasicInfo.Name = "grpBasicInfo";
            this.grpBasicInfo.Size = new System.Drawing.Size(620, 120);
            this.grpBasicInfo.TabIndex = 0;
            this.grpBasicInfo.TabStop = false;
            this.grpBasicInfo.Text = "Temel Bilgiler";
            // 
            // btnCopyCode
            // 
            this.btnCopyCode.Location = new System.Drawing.Point(320, 25);
            this.btnCopyCode.Name = "btnCopyCode";
            this.btnCopyCode.Size = new System.Drawing.Size(80, 23);
            this.btnCopyCode.TabIndex = 2;
            this.btnCopyCode.Text = "Kopyala";
            this.btnCopyCode.UseVisualStyleBackColor = true;
            this.btnCopyCode.Click += new System.EventHandler(this.btnCopyCode_Click);
            // 
            // txtCariCode
            // 
            this.txtCariCode.Location = new System.Drawing.Point(120, 25);
            this.txtCariCode.Name = "txtCariCode";
            this.txtCariCode.ReadOnly = true;
            this.txtCariCode.Size = new System.Drawing.Size(190, 23);
            this.txtCariCode.TabIndex = 1;
            // 
            // lblCariCode
            // 
            this.lblCariCode.AutoSize = true;
            this.lblCariCode.Location = new System.Drawing.Point(15, 28);
            this.lblCariCode.Name = "lblCariCode";
            this.lblCariCode.Size = new System.Drawing.Size(69, 15);
            this.lblCariCode.TabIndex = 0;
            this.lblCariCode.Text = "Cari Kodu:";
            // 
            // txtCariName
            // 
            this.txtCariName.Location = new System.Drawing.Point(120, 55);
            this.txtCariName.Name = "txtCariName";
            this.txtCariName.ReadOnly = true;
            this.txtCariName.Size = new System.Drawing.Size(300, 23);
            this.txtCariName.TabIndex = 4;
            // 
            // lblCariName
            // 
            this.lblCariName.AutoSize = true;
            this.lblCariName.Location = new System.Drawing.Point(15, 58);
            this.lblCariName.Name = "lblCariName";
            this.lblCariName.Size = new System.Drawing.Size(61, 15);
            this.lblCariName.TabIndex = 3;
            this.lblCariName.Text = "Cari Adı:";
            // 
            // txtCariType
            // 
            this.txtCariType.Location = new System.Drawing.Point(120, 85);
            this.txtCariType.Name = "txtCariType";
            this.txtCariType.ReadOnly = true;
            this.txtCariType.Size = new System.Drawing.Size(150, 23);
            this.txtCariType.TabIndex = 6;
            // 
            // lblCariType
            // 
            this.lblCariType.AutoSize = true;
            this.lblCariType.Location = new System.Drawing.Point(15, 88);
            this.lblCariType.Name = "lblCariType";
            this.lblCariType.Size = new System.Drawing.Size(58, 15);
            this.lblCariType.TabIndex = 5;
            this.lblCariType.Text = "Cari Tipi:";
            // 
            // txtIsActive
            // 
            this.txtIsActive.Location = new System.Drawing.Point(350, 85);
            this.txtIsActive.Name = "txtIsActive";
            this.txtIsActive.ReadOnly = true;
            this.txtIsActive.Size = new System.Drawing.Size(80, 23);
            this.txtIsActive.TabIndex = 8;
            this.txtIsActive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(290, 88);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(45, 15);
            this.lblIsActive.TabIndex = 7;
            this.lblIsActive.Text = "Durum:";
            // 
            // grpTaxInfo
            // 
            this.grpTaxInfo.Controls.Add(this.lblTaxOffice);
            this.grpTaxInfo.Controls.Add(this.txtTaxOffice);
            this.grpTaxInfo.Controls.Add(this.lblTaxNumber);
            this.grpTaxInfo.Controls.Add(this.txtTaxNumber);
            this.grpTaxInfo.Controls.Add(this.btnCopyTaxNumber);
            this.grpTaxInfo.Location = new System.Drawing.Point(12, 140);
            this.grpTaxInfo.Name = "grpTaxInfo";
            this.grpTaxInfo.Size = new System.Drawing.Size(620, 80);
            this.grpTaxInfo.TabIndex = 1;
            this.grpTaxInfo.TabStop = false;
            this.grpTaxInfo.Text = "Vergi Bilgileri";
            // 
            // txtTaxNumber
            // 
            this.txtTaxNumber.Location = new System.Drawing.Point(120, 25);
            this.txtTaxNumber.Name = "txtTaxNumber";
            this.txtTaxNumber.ReadOnly = true;
            this.txtTaxNumber.Size = new System.Drawing.Size(190, 23);
            this.txtTaxNumber.TabIndex = 1;
            // 
            // lblTaxNumber
            // 
            this.lblTaxNumber.AutoSize = true;
            this.lblTaxNumber.Location = new System.Drawing.Point(15, 28);
            this.lblTaxNumber.Name = "lblTaxNumber";
            this.lblTaxNumber.Size = new System.Drawing.Size(88, 15);
            this.lblTaxNumber.TabIndex = 0;
            this.lblTaxNumber.Text = "Vergi Numarası:";
            // 
            // txtTaxOffice
            // 
            this.txtTaxOffice.Location = new System.Drawing.Point(120, 50);
            this.txtTaxOffice.Name = "txtTaxOffice";
            this.txtTaxOffice.ReadOnly = true;
            this.txtTaxOffice.Size = new System.Drawing.Size(300, 23);
            this.txtTaxOffice.TabIndex = 3;
            // 
            // lblTaxOffice
            // 
            this.lblTaxOffice.AutoSize = true;
            this.lblTaxOffice.Location = new System.Drawing.Point(15, 53);
            this.lblTaxOffice.Name = "lblTaxOffice";
            this.lblTaxOffice.Size = new System.Drawing.Size(74, 15);
            this.lblTaxOffice.TabIndex = 2;
            this.lblTaxOffice.Text = "Vergi Dairesi:";
            // 
            // btnCopyTaxNumber
            // 
            this.btnCopyTaxNumber.Location = new System.Drawing.Point(320, 25);
            this.btnCopyTaxNumber.Name = "btnCopyTaxNumber";
            this.btnCopyTaxNumber.Size = new System.Drawing.Size(80, 23);
            this.btnCopyTaxNumber.TabIndex = 2;
            this.btnCopyTaxNumber.Text = "Kopyala";
            this.btnCopyTaxNumber.UseVisualStyleBackColor = true;
            this.btnCopyTaxNumber.Click += new System.EventHandler(this.btnCopyTaxNumber_Click);
            // 
            // grpContactInfo
            // 
            this.grpContactInfo.Controls.Add(this.lblContactPerson);
            this.grpContactInfo.Controls.Add(this.txtContactPerson);
            this.grpContactInfo.Controls.Add(this.btnSendEmail);
            this.grpContactInfo.Controls.Add(this.lblEmail);
            this.grpContactInfo.Controls.Add(this.txtEmail);
            this.grpContactInfo.Controls.Add(this.btnCallPhone);
            this.grpContactInfo.Controls.Add(this.lblPhone);
            this.grpContactInfo.Controls.Add(this.txtPhone);
            this.grpContactInfo.Controls.Add(this.lblAddress);
            this.grpContactInfo.Controls.Add(this.txtAddress);
            this.grpContactInfo.Location = new System.Drawing.Point(12, 230);
            this.grpContactInfo.Name = "grpContactInfo";
            this.grpContactInfo.Size = new System.Drawing.Size(620, 150);
            this.grpContactInfo.TabIndex = 2;
            this.grpContactInfo.TabStop = false;
            this.grpContactInfo.Text = "İletişim Bilgileri";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(120, 25);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(480, 60);
            this.txtAddress.TabIndex = 1;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(15, 28);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(44, 15);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Adres:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(120, 95);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(150, 23);
            this.txtPhone.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(15, 98);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(53, 15);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Telefon:";
            // 
            // btnCallPhone
            // 
            this.btnCallPhone.Location = new System.Drawing.Point(280, 95);
            this.btnCallPhone.Name = "btnCallPhone";
            this.btnCallPhone.Size = new System.Drawing.Size(60, 23);
            this.btnCallPhone.TabIndex = 4;
            this.btnCallPhone.Text = "Ara";
            this.btnCallPhone.UseVisualStyleBackColor = true;
            this.btnCallPhone.Click += new System.EventHandler(this.btnCallPhone_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 120);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(220, 23);
            this.txtEmail.TabIndex = 6;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 123);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 15);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "E-mail:";
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(350, 120);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(80, 23);
            this.btnSendEmail.TabIndex = 7;
            this.btnSendEmail.Text = "E-mail Gönder";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(450, 95);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.ReadOnly = true;
            this.txtContactPerson.Size = new System.Drawing.Size(150, 23);
            this.txtContactPerson.TabIndex = 9;
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.Location = new System.Drawing.Point(360, 98);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(89, 15);
            this.lblContactPerson.TabIndex = 8;
            this.lblContactPerson.Text = "İletişim Kişisi:";
            // 
            // grpFinancialInfo
            // 
            this.grpFinancialInfo.Controls.Add(this.lblBalanceType);
            this.grpFinancialInfo.Controls.Add(this.txtBalanceType);
            this.grpFinancialInfo.Controls.Add(this.lblCurrentBalance);
            this.grpFinancialInfo.Controls.Add(this.txtCurrentBalance);
            this.grpFinancialInfo.Controls.Add(this.btnRefreshBalance);
            this.grpFinancialInfo.Controls.Add(this.lblCreditLimit);
            this.grpFinancialInfo.Controls.Add(this.txtCreditLimit);
            this.grpFinancialInfo.Location = new System.Drawing.Point(12, 390);
            this.grpFinancialInfo.Name = "grpFinancialInfo";
            this.grpFinancialInfo.Size = new System.Drawing.Size(620, 80);
            this.grpFinancialInfo.TabIndex = 3;
            this.grpFinancialInfo.TabStop = false;
            this.grpFinancialInfo.Text = "Mali Bilgiler";
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.Location = new System.Drawing.Point(120, 25);
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.ReadOnly = true;
            this.txtCreditLimit.Size = new System.Drawing.Size(150, 23);
            this.txtCreditLimit.TabIndex = 1;
            // 
            // lblCreditLimit
            // 
            this.lblCreditLimit.AutoSize = true;
            this.lblCreditLimit.Location = new System.Drawing.Point(15, 28);
            this.lblCreditLimit.Name = "lblCreditLimit";
            this.lblCreditLimit.Size = new System.Drawing.Size(75, 15);
            this.lblCreditLimit.TabIndex = 0;
            this.lblCreditLimit.Text = "Kredi Limiti:";
            // 
            // btnRefreshBalance
            // 
            this.btnRefreshBalance.Location = new System.Drawing.Point(480, 50);
            this.btnRefreshBalance.Name = "btnRefreshBalance";
            this.btnRefreshBalance.Size = new System.Drawing.Size(120, 23);
            this.btnRefreshBalance.TabIndex = 6;
            this.btnRefreshBalance.Text = "Bakiye Yenile";
            this.btnRefreshBalance.UseVisualStyleBackColor = true;
            this.btnRefreshBalance.Click += new System.EventHandler(this.btnRefreshBalance_Click);
            // 
            // txtCurrentBalance
            // 
            this.txtCurrentBalance.Location = new System.Drawing.Point(120, 50);
            this.txtCurrentBalance.Name = "txtCurrentBalance";
            this.txtCurrentBalance.ReadOnly = true;
            this.txtCurrentBalance.Size = new System.Drawing.Size(150, 23);
            this.txtCurrentBalance.TabIndex = 3;
            this.txtCurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.Location = new System.Drawing.Point(15, 53);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(89, 15);
            this.lblCurrentBalance.TabIndex = 2;
            this.lblCurrentBalance.Text = "Güncel Bakiye:";
            // 
            // txtBalanceType
            // 
            this.txtBalanceType.Location = new System.Drawing.Point(350, 50);
            this.txtBalanceType.Name = "txtBalanceType";
            this.txtBalanceType.ReadOnly = true;
            this.txtBalanceType.Size = new System.Drawing.Size(120, 23);
            this.txtBalanceType.TabIndex = 5;
            this.txtBalanceType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBalanceType
            // 
            this.lblBalanceType.AutoSize = true;
            this.lblBalanceType.Location = new System.Drawing.Point(290, 53);
            this.lblBalanceType.Name = "lblBalanceType";
            this.lblBalanceType.Size = new System.Drawing.Size(70, 15);
            this.lblBalanceType.TabIndex = 4;
            this.lblBalanceType.Text = "Bakiye Tipi:";
            // 
            // grpSystemInfo
            // 
            this.grpSystemInfo.Controls.Add(this.lblCreatedBy);
            this.grpSystemInfo.Controls.Add(this.txtCreatedBy);
            this.grpSystemInfo.Controls.Add(this.lblCreatedDate);
            this.grpSystemInfo.Controls.Add(this.txtCreatedDate);
            this.grpSystemInfo.Location = new System.Drawing.Point(12, 480);
            this.grpSystemInfo.Name = "grpSystemInfo";
            this.grpSystemInfo.Size = new System.Drawing.Size(620, 80);
            this.grpSystemInfo.TabIndex = 4;
            this.grpSystemInfo.TabStop = false;
            this.grpSystemInfo.Text = "Sistem Bilgileri";
            // 
            // txtCreatedDate
            // 
            this.txtCreatedDate.Location = new System.Drawing.Point(120, 25);
            this.txtCreatedDate.Name = "txtCreatedDate";
            this.txtCreatedDate.ReadOnly = true;
            this.txtCreatedDate.Size = new System.Drawing.Size(150, 23);
            this.txtCreatedDate.TabIndex = 1;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(15, 28);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(96, 15);
            this.lblCreatedDate.TabIndex = 0;
            this.lblCreatedDate.Text = "Oluşturma Tarihi:";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Location = new System.Drawing.Point(120, 50);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(150, 23);
            this.txtCreatedBy.TabIndex = 3;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(15, 53);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(67, 15);
            this.lblCreatedBy.TabIndex = 2;
            this.lblCreatedBy.Text = "Oluşturan:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnActivateDeactivate);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnViewStatement);
            this.pnlButtons.Controls.Add(this.btnViewTransactions);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtons.Location = new System.Drawing.Point(650, 60);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(150, 540);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnViewTransactions
            // 
            this.btnViewTransactions.Location = new System.Drawing.Point(12, 20);
            this.btnViewTransactions.Name = "btnViewTransactions";
            this.btnViewTransactions.Size = new System.Drawing.Size(120, 35);
            this.btnViewTransactions.TabIndex = 0;
            this.btnViewTransactions.Text = "Hareketler";
            this.btnViewTransactions.UseVisualStyleBackColor = true;
            this.btnViewTransactions.Click += new System.EventHandler(this.btnViewTransactions_Click);
            // 
            // btnViewStatement
            // 
            this.btnViewStatement.Location = new System.Drawing.Point(12, 65);
            this.btnViewStatement.Name = "btnViewStatement";
            this.btnViewStatement.Size = new System.Drawing.Size(120, 35);
            this.btnViewStatement.TabIndex = 1;
            this.btnViewStatement.Text = "Hesap Özeti";
            this.btnViewStatement.UseVisualStyleBackColor = true;
            this.btnViewStatement.Click += new System.EventHandler(this.btnViewStatement_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 110);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 35);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Düzenle";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnActivateDeactivate
            // 
            this.btnActivateDeactivate.Location = new System.Drawing.Point(12, 155);
            this.btnActivateDeactivate.Name = "btnActivateDeactivate";
            this.btnActivateDeactivate.Size = new System.Drawing.Size(120, 35);
            this.btnActivateDeactivate.TabIndex = 3;
            this.btnActivateDeactivate.Text = "Durum Değiştir";
            this.btnActivateDeactivate.UseVisualStyleBackColor = true;
            this.btnActivateDeactivate.Click += new System.EventHandler(this.btnActivateDeactivate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 480);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CariAccountDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CariAccountDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cari Hesap Detayı";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.grpBasicInfo.ResumeLayout(false);
            this.grpBasicInfo.PerformLayout();
            this.grpTaxInfo.ResumeLayout(false);
            this.grpTaxInfo.PerformLayout();
            this.grpContactInfo.ResumeLayout(false);
            this.grpContactInfo.PerformLayout();
            this.grpFinancialInfo.ResumeLayout(false);
            this.grpFinancialInfo.PerformLayout();
            this.grpSystemInfo.ResumeLayout(false);
            this.grpSystemInfo.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpBasicInfo;
        private System.Windows.Forms.Button btnCopyCode;
        private System.Windows.Forms.TextBox txtCariCode;
        private System.Windows.Forms.Label lblCariCode;
        private System.Windows.Forms.TextBox txtCariName;
        private System.Windows.Forms.Label lblCariName;
        private System.Windows.Forms.TextBox txtCariType;
        private System.Windows.Forms.Label lblCariType;
        private System.Windows.Forms.TextBox txtIsActive;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.GroupBox grpTaxInfo;
        private System.Windows.Forms.Button btnCopyTaxNumber;
        private System.Windows.Forms.TextBox txtTaxNumber;
        private System.Windows.Forms.Label lblTaxNumber;
        private System.Windows.Forms.TextBox txtTaxOffice;
        private System.Windows.Forms.Label lblTaxOffice;
        private System.Windows.Forms.GroupBox grpContactInfo;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnCallPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Label lblContactPerson;
        private System.Windows.Forms.GroupBox grpFinancialInfo;
        private System.Windows.Forms.Button btnRefreshBalance;
        private System.Windows.Forms.TextBox txtCreditLimit;
        private System.Windows.Forms.Label lblCreditLimit;
        private System.Windows.Forms.TextBox txtCurrentBalance;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.TextBox txtBalanceType;
        private System.Windows.Forms.Label lblBalanceType;
        private System.Windows.Forms.GroupBox grpSystemInfo;
        private System.Windows.Forms.TextBox txtCreatedDate;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.TextBox txtCreatedBy;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnViewTransactions;
        private System.Windows.Forms.Button btnViewStatement;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnActivateDeactivate;
        private System.Windows.Forms.Button btnClose;
    }
} 