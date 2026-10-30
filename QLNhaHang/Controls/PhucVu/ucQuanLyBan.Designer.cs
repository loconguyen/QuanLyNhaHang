using QLNhaHang.Classes;
namespace QLNhaHang.Controls.PhucVu
{
    partial class ucQuanLyBan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            lblTieuDe = new Label();
            cboLoc = new ComboBox();
            btnLamMoi = new Button();
            btnThemBan = new Button();
            lblTrong = new Label();
            lblDangPhucVu = new Label();
            lblChoDon = new Label();
            flpBan = new FlowLayoutPanel();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(255, 255, 255);
            pnlTop.Controls.Add(lblTieuDe);
            pnlTop.Controls.Add(cboLoc);
            pnlTop.Controls.Add(btnLamMoi);
            pnlTop.Controls.Add(btnThemBan);
            pnlTop.Controls.Add(lblTrong);
            pnlTop.Controls.Add(lblDangPhucVu);
            pnlTop.Controls.Add(lblChoDon);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(3, 4, 3, 4);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1234, 107);
            pnlTop.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(23, 38, 62);
            lblTieuDe.Location = new Point(23, 13);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(129, 32);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Sơ đồ bàn";
            // 
            // cboLoc
            // 
            cboLoc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoc.Font = new Font("Segoe UI", 10F);
            cboLoc.Items.AddRange(new object[] { "Tất cả", "Trống", "Đang phục vụ", "Chờ dọn" });
            cboLoc.Location = new Point(914, 19);
            cboLoc.Margin = new Padding(3, 4, 3, 4);
            cboLoc.Name = "cboLoc";
            cboLoc.Size = new Size(171, 31);
            cboLoc.TabIndex = 0;
            cboLoc.SelectedIndexChanged += cboLoc_SelectedIndexChanged;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(23, 38, 62);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.ForeColor = Color.FromArgb(255, 255, 255);
            btnLamMoi.Location = new Point(1097, 16);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(109, 40);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThemBan
            // 
            btnThemBan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThemBan.BackColor = Color.FromArgb(21, 128, 61);
            btnThemBan.Cursor = Cursors.Hand;
            btnThemBan.FlatAppearance.BorderSize = 0;
            btnThemBan.FlatStyle = FlatStyle.Flat;
            btnThemBan.ForeColor = Color.FromArgb(255, 255, 255);
            btnThemBan.Location = new Point(743, 16);
            btnThemBan.Margin = new Padding(3, 4, 3, 4);
            btnThemBan.Name = "btnThemBan";
            btnThemBan.Size = new Size(149, 40);
            btnThemBan.TabIndex = 2;
            btnThemBan.Text = "+ Thêm bàn";
            btnThemBan.UseVisualStyleBackColor = false;
            btnThemBan.Click += btnThemBan_Click;
            // 
            // lblTrong
            // 
            lblTrong.BackColor = Color.FromArgb(221, 245, 227);
            lblTrong.Location = new Point(23, 61);
            lblTrong.Name = "lblTrong";
            lblTrong.Size = new Size(126, 32);
            lblTrong.TabIndex = 3;
            lblTrong.Text = "Trống";
            lblTrong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDangPhucVu
            // 
            lblDangPhucVu.BackColor = Color.FromArgb(255, 237, 213);
            lblDangPhucVu.Location = new Point(160, 61);
            lblDangPhucVu.Name = "lblDangPhucVu";
            lblDangPhucVu.Size = new Size(126, 32);
            lblDangPhucVu.TabIndex = 4;
            lblDangPhucVu.Text = "Đang phục vụ";
            lblDangPhucVu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblChoDon
            // 
            lblChoDon.BackColor = Color.FromArgb(254, 249, 195);
            lblChoDon.Location = new Point(297, 61);
            lblChoDon.Name = "lblChoDon";
            lblChoDon.Size = new Size(126, 32);
            lblChoDon.TabIndex = 5;
            lblChoDon.Text = "Chờ dọn";
            lblChoDon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpBan
            // 
            flpBan.AutoScroll = true;
            flpBan.BackColor = Color.FromArgb(244, 247, 251);
            flpBan.Dock = DockStyle.Fill;
            flpBan.Location = new Point(0, 107);
            flpBan.Margin = new Padding(3, 4, 3, 4);
            flpBan.Name = "flpBan";
            flpBan.Padding = new Padding(17, 20, 17, 20);
            flpBan.Size = new Size(1234, 733);
            flpBan.TabIndex = 1;
            // 
            // ucQuanLyBan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpBan);
            Controls.Add(pnlTop);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucQuanLyBan";
            Size = new Size(1234, 840);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.ComboBox cboLoc;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThemBan;
        private System.Windows.Forms.Label lblTrong;
        private System.Windows.Forms.Label lblDangPhucVu;
        private System.Windows.Forms.Label lblChoDon;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
    }
}