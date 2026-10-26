namespace QLNhaHang.Forms.Main
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblScreen = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnTaoDon = new System.Windows.Forms.Button();
            this.btnQuanLyBan = new System.Windows.Forms.Button();
            this.btnNguyenLieu = new System.Windows.Forms.Button();
            this.btnThucDon = new System.Windows.Forms.Button();
            this.btnCheBien = new System.Windows.Forms.Button();
            this.btnTongQuan = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(24, 38, 66);
            this.pnlHeader.Controls.Add(this.lblUser);
            this.pnlHeader.Controls.Add(this.lblScreen);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1280, 60);
            this.pnlHeader.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Restaurant Management";
            //
            // lblScreen
            //
            this.lblScreen.AutoSize = true;
            this.lblScreen.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblScreen.ForeColor = System.Drawing.Color.LightGray;
            this.lblScreen.Location = new System.Drawing.Point(320, 19);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Text = "Màn hình";
            //
            // lblUser
            //
            this.lblUser.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(1060, 20);
            this.lblUser.Name = "lblUser";
            this.lblUser.Text = "Tên - Role";
            //
            // pnlSidebar
            //
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.btnDangXuat);
            this.pnlSidebar.Controls.Add(this.btnTaiKhoan);
            this.pnlSidebar.Controls.Add(this.btnHoaDon);
            this.pnlSidebar.Controls.Add(this.btnTaoDon);
            this.pnlSidebar.Controls.Add(this.btnQuanLyBan);
            this.pnlSidebar.Controls.Add(this.btnNguyenLieu);
            this.pnlSidebar.Controls.Add(this.btnThucDon);
            this.pnlSidebar.Controls.Add(this.btnCheBien);
            this.pnlSidebar.Controls.Add(this.btnTongQuan);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 60);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 660);
            this.pnlSidebar.TabIndex = 1;
            //
            // btnTongQuan
            //
            this.btnTongQuan.BackColor = System.Drawing.Color.White;
            this.btnTongQuan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTongQuan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTongQuan.FlatAppearance.BorderSize = 0;
            this.btnTongQuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTongQuan.Name = "btnTongQuan";
            this.btnTongQuan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTongQuan.Size = new System.Drawing.Size(200, 45);
            this.btnTongQuan.Text = "Tổng quan";
            this.btnTongQuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTongQuan.UseVisualStyleBackColor = false;
            this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);
            //
            // btnCheBien
            //
            this.btnCheBien.BackColor = System.Drawing.Color.White;
            this.btnCheBien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheBien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCheBien.FlatAppearance.BorderSize = 0;
            this.btnCheBien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheBien.Name = "btnCheBien";
            this.btnCheBien.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCheBien.Size = new System.Drawing.Size(200, 45);
            this.btnCheBien.Text = "Chế biến";
            this.btnCheBien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheBien.UseVisualStyleBackColor = false;
            this.btnCheBien.Click += new System.EventHandler(this.btnCheBien_Click);
            //
            // btnThucDon
            //
            this.btnThucDon.BackColor = System.Drawing.Color.White;
            this.btnThucDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThucDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThucDon.FlatAppearance.BorderSize = 0;
            this.btnThucDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThucDon.Name = "btnThucDon";
            this.btnThucDon.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThucDon.Size = new System.Drawing.Size(200, 45);
            this.btnThucDon.Text = "Thực đơn";
            this.btnThucDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThucDon.UseVisualStyleBackColor = false;
            this.btnThucDon.Click += new System.EventHandler(this.btnThucDon_Click);
            //
            // btnNguyenLieu
            //
            this.btnNguyenLieu.BackColor = System.Drawing.Color.White;
            this.btnNguyenLieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNguyenLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNguyenLieu.FlatAppearance.BorderSize = 0;
            this.btnNguyenLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNguyenLieu.Name = "btnNguyenLieu";
            this.btnNguyenLieu.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNguyenLieu.Size = new System.Drawing.Size(200, 45);
            this.btnNguyenLieu.Text = "Nguyên liệu";
            this.btnNguyenLieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNguyenLieu.UseVisualStyleBackColor = false;
            this.btnNguyenLieu.Click += new System.EventHandler(this.btnNguyenLieu_Click);
            //
            // btnQuanLyBan
            //
            this.btnQuanLyBan.BackColor = System.Drawing.Color.White;
            this.btnQuanLyBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLyBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyBan.FlatAppearance.BorderSize = 0;
            this.btnQuanLyBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyBan.Name = "btnQuanLyBan";
            this.btnQuanLyBan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnQuanLyBan.Size = new System.Drawing.Size(200, 45);
            this.btnQuanLyBan.Text = "Quản lý bàn";
            this.btnQuanLyBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyBan.UseVisualStyleBackColor = false;
            this.btnQuanLyBan.Click += new System.EventHandler(this.btnQuanLyBan_Click);
            //
            // btnTaoDon
            //
            this.btnTaoDon.BackColor = System.Drawing.Color.White;
            this.btnTaoDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaoDon.FlatAppearance.BorderSize = 0;
            this.btnTaoDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoDon.Name = "btnTaoDon";
            this.btnTaoDon.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTaoDon.Size = new System.Drawing.Size(200, 45);
            this.btnTaoDon.Text = "Tạo đơn";
            this.btnTaoDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoDon.UseVisualStyleBackColor = false;
            this.btnTaoDon.Click += new System.EventHandler(this.btnTaoDon_Click);
            //
            // btnHoaDon
            //
            this.btnHoaDon.BackColor = System.Drawing.Color.White;
            this.btnHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnHoaDon.Size = new System.Drawing.Size(200, 45);
            this.btnHoaDon.Text = "Hóa đơn";
            this.btnHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoaDon.UseVisualStyleBackColor = false;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            //
            // btnTaiKhoan
            //
            this.btnTaiKhoan.BackColor = System.Drawing.Color.White;
            this.btnTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTaiKhoan.Size = new System.Drawing.Size(200, 45);
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.UseVisualStyleBackColor = false;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            //
            // btnDangXuat (nằm đáy sidebar)
            //
            this.btnDangXuat.BackColor = System.Drawing.Color.White;
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDangXuat.Size = new System.Drawing.Size(200, 45);
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            //
            // pnlContent
            //
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1080, 660);
            this.pnlContent.TabIndex = 2;
            //
            // pnlFooter
            //
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(24, 38, 66);
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 690);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1280, 30);
            this.pnlFooter.TabIndex = 3;
            //
            // lblFooter
            //
            this.lblFooter.AutoSize = true;
            this.lblFooter.ForeColor = System.Drawing.Color.LightGray;
            this.lblFooter.Location = new System.Drawing.Point(15, 6);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Text = "© 2026 Restaurant Management";
            //
            // MainForm (thứ tự add: Fill -> Left -> Bottom -> Top)
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant Management";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnTaoDon;
        private System.Windows.Forms.Button btnQuanLyBan;
        private System.Windows.Forms.Button btnNguyenLieu;
        private System.Windows.Forms.Button btnThucDon;
        private System.Windows.Forms.Button btnCheBien;
        private System.Windows.Forms.Button btnTongQuan;
    }
}