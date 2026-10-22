namespace QLNhaHang.Controls.PhucVu
{
    partial class ucMonChoPhucVu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvMon = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.btnDaPhucVu = new System.Windows.Forms.Button();
            this.tmrLamMoi = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMon)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTieuDe);
            this.pnlTop.Controls.Add(this.lblThongKe);
            this.pnlTop.Controls.Add(this.btnLamMoi);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1080, 70);
            this.pnlTop.TabIndex = 0;
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(24, 38, 66);
            this.lblTieuDe.Location = new System.Drawing.Point(20, 10);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "Món chờ phục vụ";
            //
            // lblThongKe
            //
            this.lblThongKe.AutoSize = true;
            this.lblThongKe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThongKe.ForeColor = System.Drawing.Color.FromArgb(24, 38, 66);
            this.lblThongKe.Location = new System.Drawing.Point(22, 43);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Text = "";
            //
            // btnLamMoi
            //
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(24, 38, 66);
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(960, 12);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 30);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            //
            // dgvMon
            //
            this.dgvMon.AllowUserToAddRows = false;
            this.dgvMon.AllowUserToDeleteRows = false;
            this.dgvMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMon.BackgroundColor = System.Drawing.Color.White;
            this.dgvMon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMon.MultiSelect = true;
            this.dgvMon.Name = "dgvMon";
            this.dgvMon.ReadOnly = true;
            this.dgvMon.RowHeadersVisible = false;
            this.dgvMon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMon.TabIndex = 1;
            this.dgvMon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMon_CellDoubleClick);
            //
            // pnlBottom
            //
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.lblHuongDan);
            this.pnlBottom.Controls.Add(this.btnDaPhucVu);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 560);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1080, 70);
            this.pnlBottom.TabIndex = 2;
            //
            // btnDaPhucVu
            //
            this.btnDaPhucVu.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.btnDaPhucVu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDaPhucVu.FlatAppearance.BorderSize = 0;
            this.btnDaPhucVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaPhucVu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDaPhucVu.ForeColor = System.Drawing.Color.White;
            this.btnDaPhucVu.Location = new System.Drawing.Point(20, 16);
            this.btnDaPhucVu.Name = "btnDaPhucVu";
            this.btnDaPhucVu.Size = new System.Drawing.Size(170, 38);
            this.btnDaPhucVu.TabIndex = 0;
            this.btnDaPhucVu.Text = "Đã phục vụ";
            this.btnDaPhucVu.UseVisualStyleBackColor = false;
            this.btnDaPhucVu.Click += new System.EventHandler(this.btnDaPhucVu_Click);
            //
            // lblHuongDan
            //
            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.ForeColor = System.Drawing.Color.DimGray;
            this.lblHuongDan.Location = new System.Drawing.Point(210, 26);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Text = "Chọn món (giữ Ctrl/Shift để chọn nhiều), mang ra bàn rồi bấm Đã phục vụ. Danh sách tự làm mới mỗi 10 giây.";
            //
            // tmrLamMoi
            //
            this.tmrLamMoi.Interval = 10000;
            this.tmrLamMoi.Tick += new System.EventHandler(this.tmrLamMoi_Tick);
            //
            // ucMonChoPhucVu (thứ tự add: Fill -> Bottom -> Top)
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMon);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "ucMonChoPhucVu";
            this.Size = new System.Drawing.Size(1080, 630);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMon)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvMon;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Button btnDaPhucVu;
        private System.Windows.Forms.Timer tmrLamMoi;
    }
}