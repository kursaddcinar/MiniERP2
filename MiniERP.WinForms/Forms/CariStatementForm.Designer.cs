namespace MiniERP.WinForms.Forms
{
    partial class CariStatementForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtOpeningBalance = new System.Windows.Forms.TextBox();
            this.txtClosingBalance = new System.Windows.Forms.TextBox();
            this.txtTotalDebit = new System.Windows.Forms.TextBox();
            this.txtTotalCredit = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPrintStatement = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblOpeningBalance = new System.Windows.Forms.Label();
            this.lblClosingBalance = new System.Windows.Forms.Label();
            this.lblTotalDebit = new System.Windows.Forms.Label();
            this.lblTotalCredit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(107, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hesap Özeti";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(12, 60);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(86, 15);
            this.lblStartDate.TabIndex = 1;
            this.lblStartDate.Text = "Başlangıç Tarihi:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(105, 57);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 23);
            this.dtpStartDate.TabIndex = 2;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(250, 60);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(64, 15);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "Bitiş Tarihi:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(320, 57);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 23);
            this.dtpEndDate.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(460, 57);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(12, 100);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersWidth = 51;
            this.dgvTransactions.RowTemplate.Height = 25;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(950, 350);
            this.dgvTransactions.TabIndex = 6;
            // 
            // lblOpeningBalance
            // 
            this.lblOpeningBalance.AutoSize = true;
            this.lblOpeningBalance.Location = new System.Drawing.Point(12, 470);
            this.lblOpeningBalance.Name = "lblOpeningBalance";
            this.lblOpeningBalance.Size = new System.Drawing.Size(90, 15);
            this.lblOpeningBalance.TabIndex = 7;
            this.lblOpeningBalance.Text = "Açılış Bakiyesi:";
            // 
            // txtOpeningBalance
            // 
            this.txtOpeningBalance.Location = new System.Drawing.Point(105, 467);
            this.txtOpeningBalance.Name = "txtOpeningBalance";
            this.txtOpeningBalance.ReadOnly = true;
            this.txtOpeningBalance.Size = new System.Drawing.Size(100, 23);
            this.txtOpeningBalance.TabIndex = 8;
            // 
            // lblClosingBalance
            // 
            this.lblClosingBalance.AutoSize = true;
            this.lblClosingBalance.Location = new System.Drawing.Point(230, 470);
            this.lblClosingBalance.Name = "lblClosingBalance";
            this.lblClosingBalance.Size = new System.Drawing.Size(88, 15);
            this.lblClosingBalance.TabIndex = 9;
            this.lblClosingBalance.Text = "Kapanış Bakiyesi:";
            // 
            // txtClosingBalance
            // 
            this.txtClosingBalance.Location = new System.Drawing.Point(325, 467);
            this.txtClosingBalance.Name = "txtClosingBalance";
            this.txtClosingBalance.ReadOnly = true;
            this.txtClosingBalance.Size = new System.Drawing.Size(100, 23);
            this.txtClosingBalance.TabIndex = 10;
            // 
            // lblTotalDebit
            // 
            this.lblTotalDebit.AutoSize = true;
            this.lblTotalDebit.Location = new System.Drawing.Point(450, 470);
            this.lblTotalDebit.Name = "lblTotalDebit";
            this.lblTotalDebit.Size = new System.Drawing.Size(77, 15);
            this.lblTotalDebit.TabIndex = 11;
            this.lblTotalDebit.Text = "Toplam Borç:";
            // 
            // txtTotalDebit
            // 
            this.txtTotalDebit.Location = new System.Drawing.Point(533, 467);
            this.txtTotalDebit.Name = "txtTotalDebit";
            this.txtTotalDebit.ReadOnly = true;
            this.txtTotalDebit.Size = new System.Drawing.Size(100, 23);
            this.txtTotalDebit.TabIndex = 12;
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.AutoSize = true;
            this.lblTotalCredit.Location = new System.Drawing.Point(660, 470);
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Size = new System.Drawing.Size(89, 15);
            this.lblTotalCredit.TabIndex = 13;
            this.lblTotalCredit.Text = "Toplam Alacak:";
            // 
            // txtTotalCredit
            // 
            this.txtTotalCredit.Location = new System.Drawing.Point(755, 467);
            this.txtTotalCredit.Name = "txtTotalCredit";
            this.txtTotalCredit.ReadOnly = true;
            this.txtTotalCredit.Size = new System.Drawing.Size(100, 23);
            this.txtTotalCredit.TabIndex = 14;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 500);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 15;
            // 
            // btnPrintStatement
            // 
            this.btnPrintStatement.Location = new System.Drawing.Point(710, 57);
            this.btnPrintStatement.Name = "btnPrintStatement";
            this.btnPrintStatement.Size = new System.Drawing.Size(75, 23);
            this.btnPrintStatement.TabIndex = 16;
            this.btnPrintStatement.Text = "Yazdır";
            this.btnPrintStatement.UseVisualStyleBackColor = true;
            this.btnPrintStatement.Click += new System.EventHandler(this.btnPrintStatement_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(800, 57);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcel.TabIndex = 17;
            this.btnExportExcel.Text = "Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(887, 467);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CariStatementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 530);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnPrintStatement);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtTotalCredit);
            this.Controls.Add(this.lblTotalCredit);
            this.Controls.Add(this.txtTotalDebit);
            this.Controls.Add(this.lblTotalDebit);
            this.Controls.Add(this.txtClosingBalance);
            this.Controls.Add(this.lblClosingBalance);
            this.Controls.Add(this.txtOpeningBalance);
            this.Controls.Add(this.lblOpeningBalance);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CariStatementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hesap Özeti";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtOpeningBalance;
        private System.Windows.Forms.TextBox txtClosingBalance;
        private System.Windows.Forms.TextBox txtTotalDebit;
        private System.Windows.Forms.TextBox txtTotalCredit;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnPrintStatement;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblOpeningBalance;
        private System.Windows.Forms.Label lblClosingBalance;
        private System.Windows.Forms.Label lblTotalDebit;
        private System.Windows.Forms.Label lblTotalCredit;
    }
} 