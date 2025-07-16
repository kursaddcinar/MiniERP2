/*
namespace MiniERP.WinForms.Forms
{
    partial class StokTransferiForm
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblMessage = new Label();
            this.btnKapat = new Button();
            this.SuspendLayout();

            this.lblMessage.Dock = DockStyle.Top;
            this.lblMessage.Font = new Font("Segoe UI", 12F);
            this.lblMessage.Location = new Point(20, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new Size(360, 50);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "🔄 Stok Transferi modülü geliştirilmektedir...";
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            this.btnKapat.BackColor = Color.FromArgb(107, 114, 128);
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(160, 90);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(80, 35);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(249, 250, 251);
            this.ClientSize = new Size(400, 150);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StokTransferiForm";
            this.Padding = new Padding(20);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Stok Transferi";
            this.ResumeLayout(false);
        }
        #endregion

        private Label lblMessage;
        private Button btnKapat;
    }

    partial class StokOzetForm
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblMessage = new Label();
            this.btnKapat = new Button();
            this.SuspendLayout();

            this.lblMessage.Dock = DockStyle.Top;
            this.lblMessage.Font = new Font("Segoe UI", 12F);
            this.lblMessage.Location = new Point(20, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new Size(360, 50);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "📋 Stok Özet modülü geliştirilmektedir...";
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            this.btnKapat.BackColor = Color.FromArgb(107, 114, 128);
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(160, 90);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(80, 35);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(249, 250, 251);
            this.ClientSize = new Size(400, 150);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StokOzetForm";
            this.Padding = new Padding(20);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Stok Özet";
            this.ResumeLayout(false);
        }
        #endregion

        private Label lblMessage;
        private Button btnKapat;
    }

    partial class StokRaporForm
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblMessage = new Label();
            this.btnKapat = new Button();
            this.SuspendLayout();

            this.lblMessage.Dock = DockStyle.Top;
            this.lblMessage.Font = new Font("Segoe UI", 12F);
            this.lblMessage.Location = new Point(20, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new Size(360, 50);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "📊 Stok Raporu modülü geliştirilmektedir...";
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            this.btnKapat.BackColor = Color.FromArgb(107, 114, 128);
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(160, 90);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(80, 35);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(249, 250, 251);
            this.ClientSize = new Size(400, 150);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StokRaporForm";
            this.Padding = new Padding(20);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Stok Raporu";
            this.ResumeLayout(false);
        }
        #endregion

        private Label lblMessage;
        private Button btnKapat;
    }

    partial class KritikStokDetayForm
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblMessage = new Label();
            this.btnKapat = new Button();
            this.SuspendLayout();

            this.lblMessage.Dock = DockStyle.Top;
            this.lblMessage.Font = new Font("Segoe UI", 12F);
            this.lblMessage.Location = new Point(20, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new Size(360, 50);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "⚠️ Kritik Stok Detayları modülü geliştirilmektedir...";
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            this.btnKapat.BackColor = Color.FromArgb(107, 114, 128);
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(160, 90);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(80, 35);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(249, 250, 251);
            this.ClientSize = new Size(400, 150);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KritikStokDetayForm";
            this.Padding = new Padding(20);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Kritik Stok Detayları";
            this.ResumeLayout(false);
        }
        #endregion

        private Label lblMessage;
        private Button btnKapat;
    }

    partial class StokYokDetayForm
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblMessage = new Label();
            this.btnKapat = new Button();
            this.SuspendLayout();

            this.lblMessage.Dock = DockStyle.Top;
            this.lblMessage.Font = new Font("Segoe UI", 12F);
            this.lblMessage.Location = new Point(20, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new Size(360, 50);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "❌ Stokta Yok Detayları modülü geliştirilmektedir...";
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            this.btnKapat.BackColor = Color.FromArgb(107, 114, 128);
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(160, 90);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(80, 35);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(249, 250, 251);
            this.ClientSize = new Size(400, 150);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StokYokDetayForm";
            this.Padding = new Padding(20);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Stokta Yok Detayları";
            this.ResumeLayout(false);
        }
        #endregion

        private Label lblMessage;
        private Button btnKapat;
    }

    partial class StokHareketleriForm
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblMessage = new Label();
            this.btnKapat = new Button();
            this.SuspendLayout();

            this.lblMessage.Dock = DockStyle.Top;
            this.lblMessage.Font = new Font("Segoe UI", 12F);
            this.lblMessage.Location = new Point(20, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new Size(360, 50);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "🔄 Stok Hareketleri modülü geliştirilmektedir...";
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            this.btnKapat.BackColor = Color.FromArgb(107, 114, 128);
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(160, 90);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(80, 35);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(249, 250, 251);
            this.ClientSize = new Size(400, 150);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StokHareketleriForm";
            this.Padding = new Padding(20);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Stok Hareketleri";
            this.ResumeLayout(false);
        }
        #endregion

        private Label lblMessage;
        private Button btnKapat;
    }

    partial class StokDetayForm
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblMessage = new Label();
            this.btnKapat = new Button();
            this.SuspendLayout();

            this.lblMessage.Dock = DockStyle.Top;
            this.lblMessage.Font = new Font("Segoe UI", 12F);
            this.lblMessage.Location = new Point(20, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new Size(360, 50);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "👁️ Stok Detayları modülü geliştirilmektedir...";
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            this.btnKapat.BackColor = Color.FromArgb(107, 114, 128);
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(160, 90);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(80, 35);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(249, 250, 251);
            this.ClientSize = new Size(400, 150);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StokDetayForm";
            this.Padding = new Padding(20);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Stok Detayları";
            this.ResumeLayout(false);
        }
        #endregion

        private Label lblMessage;
        private Button btnKapat;
    }

    partial class StokKartiDuzenleForm
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblMessage = new Label();
            this.btnKapat = new Button();
            this.SuspendLayout();

            this.lblMessage.Dock = DockStyle.Top;
            this.lblMessage.Font = new Font("Segoe UI", 12F);
            this.lblMessage.Location = new Point(20, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new Size(360, 50);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "✏️ Stok Kartı Düzenleme modülü geliştirilmektedir...";
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            this.btnKapat.BackColor = Color.FromArgb(107, 114, 128);
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(160, 90);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(80, 35);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(249, 250, 251);
            this.ClientSize = new Size(400, 150);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StokKartiDuzenleForm";
            this.Padding = new Padding(20);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Stok Kartı Düzenle";
            this.ResumeLayout(false);
        }
        #endregion

        private Label lblMessage;
        private Button btnKapat;
    }
}
*/