namespace MiniERP.WinForms.Forms
{
    partial class CariBalancesForm
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
            this.dgvBalances = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkIncludeZeroBalance = new System.Windows.Forms.CheckBox();
            this.txtTotalReceivables = new System.Windows.Forms.TextBox();
            this.txtTotalPayables = new System.Windows.Forms.TextBox();
            this.txtNetBalance = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnPrintBalances = new System.Windows.Forms.Button();
            this.lblTotalReceivables = new System.Windows.Forms.Label();
            this.lblTotalPayables = new System.Windows.Forms.Label();
            this.lblNetBalance = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalances)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(119, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cari Bakiyeler";
            // 
            // chkIncludeZeroBalance
            // 
            this.chkIncludeZeroBalance.AutoSize = true;
            this.chkIncludeZeroBalance.Location = new System.Drawing.Point(12, 60);
            this.chkIncludeZeroBalance.Name = "chkIncludeZeroBalance";
            this.chkIncludeZeroBalance.Size = new System.Drawing.Size(160, 19);
            this.chkIncludeZeroBalance.TabIndex = 1;
            this.chkIncludeZeroBalance.Text = "Sıfır bakiyelileri de göster";
            this.chkIncludeZeroBalance.UseVisualStyleBackColor = true;
            this.chkIncludeZeroBalance.CheckedChanged += new System.EventHandler(this.chkIncludeZeroBalance_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(200, 58);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvBalances
            // 
            this.dgvBalances.AllowUserToAddRows = false;
            this.dgvBalances.AllowUserToDeleteRows = false;
            this.dgvBalances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBalances.Location = new System.Drawing.Point(12, 100);
            this.dgvBalances.Name = "dgvBalances";
            this.dgvBalances.ReadOnly = true;
            this.dgvBalances.RowHeadersWidth = 51;
            this.dgvBalances.RowTemplate.Height = 25;
            this.dgvBalances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalances.Size = new System.Drawing.Size(850, 350);
            this.dgvBalances.TabIndex = 3;
            // 
            // lblTotalReceivables
            // 
            this.lblTotalReceivables.AutoSize = true;
            this.lblTotalReceivables.Location = new System.Drawing.Point(12, 470);
            this.lblTotalReceivables.Name = "lblTotalReceivables";
            this.lblTotalReceivables.Size = new System.Drawing.Size(89, 15);
            this.lblTotalReceivables.TabIndex = 4;
            this.lblTotalReceivables.Text = "Toplam Alacak:";
            // 
            // txtTotalReceivables
            // 
            this.txtTotalReceivables.Location = new System.Drawing.Point(107, 467);
            this.txtTotalReceivables.Name = "txtTotalReceivables";
            this.txtTotalReceivables.ReadOnly = true;
            this.txtTotalReceivables.Size = new System.Drawing.Size(100, 23);
            this.txtTotalReceivables.TabIndex = 5;
            // 
            // lblTotalPayables
            // 
            this.lblTotalPayables.AutoSize = true;
            this.lblTotalPayables.Location = new System.Drawing.Point(230, 470);
            this.lblTotalPayables.Name = "lblTotalPayables";
            this.lblTotalPayables.Size = new System.Drawing.Size(77, 15);
            this.lblTotalPayables.TabIndex = 6;
            this.lblTotalPayables.Text = "Toplam Borç:";
            // 
            // txtTotalPayables
            // 
            this.txtTotalPayables.Location = new System.Drawing.Point(313, 467);
            this.txtTotalPayables.Name = "txtTotalPayables";
            this.txtTotalPayables.ReadOnly = true;
            this.txtTotalPayables.Size = new System.Drawing.Size(100, 23);
            this.txtTotalPayables.TabIndex = 7;
            // 
            // lblNetBalance
            // 
            this.lblNetBalance.AutoSize = true;
            this.lblNetBalance.Location = new System.Drawing.Point(440, 470);
            this.lblNetBalance.Name = "lblNetBalance";
            this.lblNetBalance.Size = new System.Drawing.Size(71, 15);
            this.lblNetBalance.TabIndex = 8;
            this.lblNetBalance.Text = "Net Bakiye:";
            // 
            // txtNetBalance
            // 
            this.txtNetBalance.Location = new System.Drawing.Point(517, 467);
            this.txtNetBalance.Name = "txtNetBalance";
            this.txtNetBalance.ReadOnly = true;
            this.txtNetBalance.Size = new System.Drawing.Size(100, 23);
            this.txtNetBalance.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 500);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 10;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(700, 58);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcel.TabIndex = 11;
            this.btnExportExcel.Text = "Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnPrintBalances
            // 
            this.btnPrintBalances.Location = new System.Drawing.Point(790, 58);
            this.btnPrintBalances.Name = "btnPrintBalances";
            this.btnPrintBalances.Size = new System.Drawing.Size(75, 23);
            this.btnPrintBalances.TabIndex = 12;
            this.btnPrintBalances.Text = "Yazdır";
            this.btnPrintBalances.UseVisualStyleBackColor = true;
            this.btnPrintBalances.Click += new System.EventHandler(this.btnPrintBalances_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(787, 467);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CariBalancesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 530);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrintBalances);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtNetBalance);
            this.Controls.Add(this.lblNetBalance);
            this.Controls.Add(this.txtTotalPayables);
            this.Controls.Add(this.lblTotalPayables);
            this.Controls.Add(this.txtTotalReceivables);
            this.Controls.Add(this.lblTotalReceivables);
            this.Controls.Add(this.dgvBalances);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.chkIncludeZeroBalance);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CariBalancesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cari Bakiyeler";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalances)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvBalances;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkIncludeZeroBalance;
        private System.Windows.Forms.TextBox txtTotalReceivables;
        private System.Windows.Forms.TextBox txtTotalPayables;
        private System.Windows.Forms.TextBox txtNetBalance;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnPrintBalances;
        private System.Windows.Forms.Label lblTotalReceivables;
        private System.Windows.Forms.Label lblTotalPayables;
        private System.Windows.Forms.Label lblNetBalance;
    }
} 