namespace MiniERP.WinForms.Forms
{
    partial class CariAccountEditForm
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
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.txtCariCode = new System.Windows.Forms.TextBox();
            this.lblCariCode = new System.Windows.Forms.Label();
            this.txtCariName = new System.Windows.Forms.TextBox();
            this.lblCariName = new System.Windows.Forms.Label();
            this.cmbCariType = new System.Windows.Forms.ComboBox();
            this.lblCariType = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.grpTaxInfo = new System.Windows.Forms.GroupBox();
            this.txtTaxNumber = new System.Windows.Forms.TextBox();
            this.lblTaxNumber = new System.Windows.Forms.Label();
            this.txtTaxOffice = new System.Windows.Forms.TextBox();
            this.lblTaxOffice = new System.Windows.Forms.Label();
            this.grpContactInfo = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.grpFinancialInfo = new System.Windows.Forms.GroupBox();
            this.numCreditLimit = new System.Windows.Forms.NumericUpDown();
            this.lblCreditLimit = new System.Windows.Forms.Label();
            this.btnCheckBalance = new System.Windows.Forms.Button();
            this.numCurrentBalance = new System.Windows.Forms.NumericUpDown();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.cmbBalanceType = new System.Windows.Forms.ComboBox();
            this.lblBalanceType = new System.Windows.Forms.Label();
            this.grpSystemInfo = new System.Windows.Forms.GroupBox();
            this.dtpCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpBasicInfo.SuspendLayout();
            this.grpTaxInfo.SuspendLayout();
            this.grpContactInfo.SuspendLayout();
            this.grpFinancialInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCreditLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentBalance)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(193, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cari Hesap Düzenle";
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
            this.pnlMain.Size = new System.Drawing.Size(800, 640);
            this.pnlMain.TabIndex = 1;
            // 
            // grpBasicInfo
            // 
            this.grpBasicInfo.Controls.Add(this.chkIsActive);
            this.grpBasicInfo.Controls.Add(this.lblCariType);
            this.grpBasicInfo.Controls.Add(this.cmbCariType);
            this.grpBasicInfo.Controls.Add(this.lblCariName);
            this.grpBasicInfo.Controls.Add(this.txtCariName);
            this.grpBasicInfo.Controls.Add(this.lblCariCode);
            this.grpBasicInfo.Controls.Add(this.txtCariCode);
            this.grpBasicInfo.Controls.Add(this.btnGenerateCode);
            this.grpBasicInfo.Location = new System.Drawing.Point(12, 12);
            this.grpBasicInfo.Name = "grpBasicInfo";
            this.grpBasicInfo.Size = new System.Drawing.Size(760, 120);
            this.grpBasicInfo.TabIndex = 0;
            this.grpBasicInfo.TabStop = false;
            this.grpBasicInfo.Text = "Temel Bilgiler";
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Location = new System.Drawing.Point(320, 25);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(100, 23);
            this.btnGenerateCode.TabIndex = 2;
            this.btnGenerateCode.Text = "Kod Oluştur";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // txtCariCode
            // 
            this.txtCariCode.Location = new System.Drawing.Point(120, 25);
            this.txtCariCode.Name = "txtCariCode";
            this.txtCariCode.Size = new System.Drawing.Size(190, 23);
            this.txtCariCode.TabIndex = 1;
            this.txtCariCode.Leave += new System.EventHandler(this.txtCariCode_Leave);
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
            // cmbCariType
            // 
            this.cmbCariType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCariType.FormattingEnabled = true;
            this.cmbCariType.Location = new System.Drawing.Point(120, 85);
            this.cmbCariType.Name = "cmbCariType";
            this.cmbCariType.Size = new System.Drawing.Size(200, 23);
            this.cmbCariType.TabIndex = 6;
            this.cmbCariType.SelectedIndexChanged += new System.EventHandler(this.cmbCariType_SelectedIndexChanged);
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
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(450, 87);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(54, 19);
            this.chkIsActive.TabIndex = 7;
            this.chkIsActive.Text = "Aktif";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // grpTaxInfo
            // 
            this.grpTaxInfo.Controls.Add(this.lblTaxOffice);
            this.grpTaxInfo.Controls.Add(this.txtTaxOffice);
            this.grpTaxInfo.Controls.Add(this.lblTaxNumber);
            this.grpTaxInfo.Controls.Add(this.txtTaxNumber);
            this.grpTaxInfo.Location = new System.Drawing.Point(12, 140);
            this.grpTaxInfo.Name = "grpTaxInfo";
            this.grpTaxInfo.Size = new System.Drawing.Size(760, 80);
            this.grpTaxInfo.TabIndex = 1;
            this.grpTaxInfo.TabStop = false;
            this.grpTaxInfo.Text = "Vergi Bilgileri";
            // 
            // txtTaxNumber
            // 
            this.txtTaxNumber.Location = new System.Drawing.Point(120, 25);
            this.txtTaxNumber.MaxLength = 11;
            this.txtTaxNumber.Name = "txtTaxNumber";
            this.txtTaxNumber.Size = new System.Drawing.Size(200, 23);
            this.txtTaxNumber.TabIndex = 1;
            this.txtTaxNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaxNumber_KeyPress);
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
            // grpContactInfo
            // 
            this.grpContactInfo.Controls.Add(this.lblContactPerson);
            this.grpContactInfo.Controls.Add(this.txtContactPerson);
            this.grpContactInfo.Controls.Add(this.lblEmail);
            this.grpContactInfo.Controls.Add(this.txtEmail);
            this.grpContactInfo.Controls.Add(this.lblPhone);
            this.grpContactInfo.Controls.Add(this.txtPhone);
            this.grpContactInfo.Controls.Add(this.lblAddress);
            this.grpContactInfo.Controls.Add(this.txtAddress);
            this.grpContactInfo.Location = new System.Drawing.Point(12, 230);
            this.grpContactInfo.Name = "grpContactInfo";
            this.grpContactInfo.Size = new System.Drawing.Size(760, 150);
            this.grpContactInfo.TabIndex = 2;
            this.grpContactInfo.TabStop = false;
            this.grpContactInfo.Text = "İletişim Bilgileri";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(120, 25);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(600, 60);
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
            this.txtPhone.Size = new System.Drawing.Size(200, 23);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
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
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(380, 95);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 23);
            this.txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(340, 98);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 15);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(120, 120);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(300, 23);
            this.txtContactPerson.TabIndex = 7;
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.Location = new System.Drawing.Point(15, 123);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(89, 15);
            this.lblContactPerson.TabIndex = 6;
            this.lblContactPerson.Text = "İletişim Kişisi:";
            // 
            // grpFinancialInfo
            // 
            this.grpFinancialInfo.Controls.Add(this.lblBalanceType);
            this.grpFinancialInfo.Controls.Add(this.cmbBalanceType);
            this.grpFinancialInfo.Controls.Add(this.lblCurrentBalance);
            this.grpFinancialInfo.Controls.Add(this.numCurrentBalance);
            this.grpFinancialInfo.Controls.Add(this.btnCheckBalance);
            this.grpFinancialInfo.Controls.Add(this.lblCreditLimit);
            this.grpFinancialInfo.Controls.Add(this.numCreditLimit);
            this.grpFinancialInfo.Location = new System.Drawing.Point(12, 390);
            this.grpFinancialInfo.Name = "grpFinancialInfo";
            this.grpFinancialInfo.Size = new System.Drawing.Size(760, 100);
            this.grpFinancialInfo.TabIndex = 3;
            this.grpFinancialInfo.TabStop = false;
            this.grpFinancialInfo.Text = "Mali Bilgiler";
            // 
            // numCreditLimit
            // 
            this.numCreditLimit.DecimalPlaces = 2;
            this.numCreditLimit.Location = new System.Drawing.Point(120, 25);
            this.numCreditLimit.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numCreditLimit.Name = "numCreditLimit";
            this.numCreditLimit.Size = new System.Drawing.Size(200, 23);
            this.numCreditLimit.TabIndex = 1;
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
            // btnCheckBalance
            // 
            this.btnCheckBalance.Location = new System.Drawing.Point(580, 53);
            this.btnCheckBalance.Name = "btnCheckBalance";
            this.btnCheckBalance.Size = new System.Drawing.Size(120, 23);
            this.btnCheckBalance.TabIndex = 6;
            this.btnCheckBalance.Text = "Bakiye Kontrol Et";
            this.btnCheckBalance.UseVisualStyleBackColor = true;
            this.btnCheckBalance.Click += new System.EventHandler(this.btnCheckBalance_Click);
            // 
            // numCurrentBalance
            // 
            this.numCurrentBalance.DecimalPlaces = 2;
            this.numCurrentBalance.Location = new System.Drawing.Point(120, 55);
            this.numCurrentBalance.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numCurrentBalance.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numCurrentBalance.Name = "numCurrentBalance";
            this.numCurrentBalance.ReadOnly = true;
            this.numCurrentBalance.Size = new System.Drawing.Size(200, 23);
            this.numCurrentBalance.TabIndex = 3;
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.Location = new System.Drawing.Point(15, 58);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(89, 15);
            this.lblCurrentBalance.TabIndex = 2;
            this.lblCurrentBalance.Text = "Güncel Bakiye:";
            // 
            // cmbBalanceType
            // 
            this.cmbBalanceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBalanceType.FormattingEnabled = true;
            this.cmbBalanceType.Location = new System.Drawing.Point(450, 55);
            this.cmbBalanceType.Name = "cmbBalanceType";
            this.cmbBalanceType.Size = new System.Drawing.Size(120, 23);
            this.cmbBalanceType.TabIndex = 5;
            // 
            // lblBalanceType
            // 
            this.lblBalanceType.AutoSize = true;
            this.lblBalanceType.Location = new System.Drawing.Point(370, 58);
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
            this.grpSystemInfo.Controls.Add(this.dtpCreatedDate);
            this.grpSystemInfo.Location = new System.Drawing.Point(12, 500);
            this.grpSystemInfo.Name = "grpSystemInfo";
            this.grpSystemInfo.Size = new System.Drawing.Size(760, 80);
            this.grpSystemInfo.TabIndex = 4;
            this.grpSystemInfo.TabStop = false;
            this.grpSystemInfo.Text = "Sistem Bilgileri";
            // 
            // dtpCreatedDate
            // 
            this.dtpCreatedDate.Enabled = false;
            this.dtpCreatedDate.Location = new System.Drawing.Point(120, 25);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(200, 23);
            this.dtpCreatedDate.TabIndex = 1;
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
            this.txtCreatedBy.Size = new System.Drawing.Size(200, 23);
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
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 700);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(800, 50);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(600, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(700, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CariAccountEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 750);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CariAccountEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cari Hesap Düzenle";
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
            ((System.ComponentModel.ISupportInitialize)(this.numCreditLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentBalance)).EndInit();
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
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblCariType;
        private System.Windows.Forms.ComboBox cmbCariType;
        private System.Windows.Forms.Label lblCariName;
        private System.Windows.Forms.TextBox txtCariName;
        private System.Windows.Forms.Label lblCariCode;
        private System.Windows.Forms.TextBox txtCariCode;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.GroupBox grpTaxInfo;
        private System.Windows.Forms.Label lblTaxOffice;
        private System.Windows.Forms.TextBox txtTaxOffice;
        private System.Windows.Forms.Label lblTaxNumber;
        private System.Windows.Forms.TextBox txtTaxNumber;
        private System.Windows.Forms.GroupBox grpContactInfo;
        private System.Windows.Forms.Label lblContactPerson;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.GroupBox grpFinancialInfo;
        private System.Windows.Forms.Label lblBalanceType;
        private System.Windows.Forms.ComboBox cmbBalanceType;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.NumericUpDown numCurrentBalance;
        private System.Windows.Forms.Button btnCheckBalance;
        private System.Windows.Forms.Label lblCreditLimit;
        private System.Windows.Forms.NumericUpDown numCreditLimit;
        private System.Windows.Forms.GroupBox grpSystemInfo;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.TextBox txtCreatedBy;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.DateTimePicker dtpCreatedDate;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
} 