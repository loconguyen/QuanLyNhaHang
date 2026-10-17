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
            pnlHeader = new Panel();
            lblUser = new Label();
            lblScreen = new Label();
            lblTitle = new Label();
            pnlSidebar = new Panel();
            btnDangXuat = new Button();
            btnTaiKhoan = new Button();
            btnThanhToan = new Button();
            btnHoaDon = new Button();
            btnMonChoPhucVu = new Button();
            btnTaoDon = new Button();
            btnQuanLyBan = new Button();
            btnNguyenLieu = new Button();
            btnThucDon = new Button();
            btnCheBien = new Button();
            btnTongQuan = new Button();
            pnlContent = new Panel();
            pnlFooter = new Panel();
            lblFooter = new Label();
            pnlHeader.SuspendLayout();
            pnlSidebar.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(24, 38, 66);
            pnlHeader.Controls.Add(lblUser);
            pnlHeader.Controls.Add(lblScreen);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(4, 5, 4, 5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1829, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUser.AutoSize = true;
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(1514, 33);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(89, 25);
            lblUser.TabIndex = 0;
            lblUser.Text = "Tên - Role";
            // 
            // lblScreen
            // 
            lblScreen.AutoSize = true;
            lblScreen.Font = new Font("Segoe UI", 11F);
            lblScreen.ForeColor = Color.LightGray;
            lblScreen.Location = new Point(457, 32);
            lblScreen.Margin = new Padding(4, 0, 4, 0);
            lblScreen.Name = "lblScreen";
            lblScreen.Size = new Size(103, 30);
            lblScreen.TabIndex = 1;
            lblScreen.Text = "Màn hình";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(21, 27);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(316, 36);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Restaurant Management";
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.White;
            pnlSidebar.Controls.Add(btnDangXuat);
            pnlSidebar.Controls.Add(btnTaiKhoan);
            pnlSidebar.Controls.Add(btnThanhToan);
            pnlSidebar.Controls.Add(btnHoaDon);
            pnlSidebar.Controls.Add(btnMonChoPhucVu);
            pnlSidebar.Controls.Add(btnTaoDon);
            pnlSidebar.Controls.Add(btnQuanLyBan);
            pnlSidebar.Controls.Add(btnNguyenLieu);
            pnlSidebar.Controls.Add(btnThucDon);
            pnlSidebar.Controls.Add(btnCheBien);
            pnlSidebar.Controls.Add(btnTongQuan);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 100);
            pnlSidebar.Margin = new Padding(4, 5, 4, 5);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(286, 1050);
            pnlSidebar.TabIndex = 1;
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.White;
            btnDangXuat.Cursor = Cursors.Hand;
            btnDangXuat.Dock = DockStyle.Bottom;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.ForeColor = Color.Firebrick;
            btnDangXuat.Location = new Point(0, 975);
            btnDangXuat.Margin = new Padding(4, 5, 4, 5);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Padding = new Padding(21, 0, 0, 0);
            btnDangXuat.Size = new Size(286, 75);
            btnDangXuat.TabIndex = 0;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.TextAlign = ContentAlignment.MiddleLeft;
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnTaiKhoan
            // 
            btnTaiKhoan.BackColor = Color.White;
            btnTaiKhoan.Cursor = Cursors.Hand;
            btnTaiKhoan.Dock = DockStyle.Top;
            btnTaiKhoan.FlatAppearance.BorderSize = 0;
            btnTaiKhoan.FlatStyle = FlatStyle.Flat;
            btnTaiKhoan.Location = new Point(0, 675);
            btnTaiKhoan.Margin = new Padding(4, 5, 4, 5);
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.Padding = new Padding(21, 0, 0, 0);
            btnTaiKhoan.Size = new Size(286, 75);
            btnTaiKhoan.TabIndex = 1;
            btnTaiKhoan.Text = "Tài khoản";
            btnTaiKhoan.TextAlign = ContentAlignment.MiddleLeft;
            btnTaiKhoan.UseVisualStyleBackColor = false;
            btnTaiKhoan.Click += btnTaiKhoan_Click;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.White;
            btnThanhToan.Cursor = Cursors.Hand;
            btnThanhToan.Dock = DockStyle.Top;
            btnThanhToan.FlatAppearance.BorderSize = 0;
            btnThanhToan.FlatStyle = FlatStyle.Flat;
            btnThanhToan.Location = new Point(0, 600);
            btnThanhToan.Margin = new Padding(4, 5, 4, 5);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Padding = new Padding(21, 0, 0, 0);
            btnThanhToan.Size = new Size(286, 75);
            btnThanhToan.TabIndex = 2;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.TextAlign = ContentAlignment.MiddleLeft;
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnHoaDon
            // 
            btnHoaDon.BackColor = Color.White;
            btnHoaDon.Cursor = Cursors.Hand;
            btnHoaDon.Dock = DockStyle.Top;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatStyle = FlatStyle.Flat;
            btnHoaDon.Location = new Point(0, 525);
            btnHoaDon.Margin = new Padding(4, 5, 4, 5);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Padding = new Padding(21, 0, 0, 0);
            btnHoaDon.Size = new Size(286, 75);
            btnHoaDon.TabIndex = 3;
            btnHoaDon.Text = "Hóa đơn";
            btnHoaDon.TextAlign = ContentAlignment.MiddleLeft;
            btnHoaDon.UseVisualStyleBackColor = false;
            btnHoaDon.Click += btnHoaDon_Click;
            // 
            // btnMonChoPhucVu
            // 
            btnMonChoPhucVu.BackColor = Color.White;
            btnMonChoPhucVu.Cursor = Cursors.Hand;
            btnMonChoPhucVu.Dock = DockStyle.Top;
            btnMonChoPhucVu.FlatAppearance.BorderSize = 0;
            btnMonChoPhucVu.FlatStyle = FlatStyle.Flat;
            btnMonChoPhucVu.Location = new Point(0, 450);
            btnMonChoPhucVu.Margin = new Padding(4, 5, 4, 5);
            btnMonChoPhucVu.Name = "btnMonChoPhucVu";
            btnMonChoPhucVu.Padding = new Padding(21, 0, 0, 0);
            btnMonChoPhucVu.Size = new Size(286, 75);
            btnMonChoPhucVu.TabIndex = 4;
            btnMonChoPhucVu.Text = "Món chờ phục vụ";
            btnMonChoPhucVu.TextAlign = ContentAlignment.MiddleLeft;
            btnMonChoPhucVu.UseVisualStyleBackColor = false;
            btnMonChoPhucVu.Click += btnMonChoPhucVu_Click;
            // 
            // btnTaoDon
            // 
            btnTaoDon.BackColor = Color.White;
            btnTaoDon.Cursor = Cursors.Hand;
            btnTaoDon.Dock = DockStyle.Top;
            btnTaoDon.FlatAppearance.BorderSize = 0;
            btnTaoDon.FlatStyle = FlatStyle.Flat;
            btnTaoDon.Location = new Point(0, 375);
            btnTaoDon.Margin = new Padding(4, 5, 4, 5);
            btnTaoDon.Name = "btnTaoDon";
            btnTaoDon.Padding = new Padding(21, 0, 0, 0);
            btnTaoDon.Size = new Size(286, 75);
            btnTaoDon.TabIndex = 5;
            btnTaoDon.Text = "Tạo đơn";
            btnTaoDon.TextAlign = ContentAlignment.MiddleLeft;
            btnTaoDon.UseVisualStyleBackColor = false;
            btnTaoDon.Click += btnTaoDon_Click;
            // 
            // btnQuanLyBan
            // 
            btnQuanLyBan.BackColor = Color.White;
            btnQuanLyBan.Cursor = Cursors.Hand;
            btnQuanLyBan.Dock = DockStyle.Top;
            btnQuanLyBan.FlatAppearance.BorderSize = 0;
            btnQuanLyBan.FlatStyle = FlatStyle.Flat;
            btnQuanLyBan.Location = new Point(0, 300);
            btnQuanLyBan.Margin = new Padding(4, 5, 4, 5);
            btnQuanLyBan.Name = "btnQuanLyBan";
            btnQuanLyBan.Padding = new Padding(21, 0, 0, 0);
            btnQuanLyBan.Size = new Size(286, 75);
            btnQuanLyBan.TabIndex = 6;
            btnQuanLyBan.Text = "Quản lý bàn";
            btnQuanLyBan.TextAlign = ContentAlignment.MiddleLeft;
            btnQuanLyBan.UseVisualStyleBackColor = false;
            btnQuanLyBan.Click += btnQuanLyBan_Click;
            // 
            // btnNguyenLieu
            // 
            btnNguyenLieu.BackColor = Color.White;
            btnNguyenLieu.Cursor = Cursors.Hand;
            btnNguyenLieu.Dock = DockStyle.Top;
            btnNguyenLieu.FlatAppearance.BorderSize = 0;
            btnNguyenLieu.FlatStyle = FlatStyle.Flat;
            btnNguyenLieu.Location = new Point(0, 225);
            btnNguyenLieu.Margin = new Padding(4, 5, 4, 5);
            btnNguyenLieu.Name = "btnNguyenLieu";
            btnNguyenLieu.Padding = new Padding(21, 0, 0, 0);
            btnNguyenLieu.Size = new Size(286, 75);
            btnNguyenLieu.TabIndex = 7;
            btnNguyenLieu.Text = "Nguyên liệu";
            btnNguyenLieu.TextAlign = ContentAlignment.MiddleLeft;
            btnNguyenLieu.UseVisualStyleBackColor = false;
            btnNguyenLieu.Click += btnNguyenLieu_Click;
            // 
            // btnThucDon
            // 
            btnThucDon.BackColor = Color.White;
            btnThucDon.Cursor = Cursors.Hand;
            btnThucDon.Dock = DockStyle.Top;
            btnThucDon.FlatAppearance.BorderSize = 0;
            btnThucDon.FlatStyle = FlatStyle.Flat;
            btnThucDon.Location = new Point(0, 150);
            btnThucDon.Margin = new Padding(4, 5, 4, 5);
            btnThucDon.Name = "btnThucDon";
            btnThucDon.Padding = new Padding(21, 0, 0, 0);
            btnThucDon.Size = new Size(286, 75);
            btnThucDon.TabIndex = 8;
            btnThucDon.Text = "Thực đơn";
            btnThucDon.TextAlign = ContentAlignment.MiddleLeft;
            btnThucDon.UseVisualStyleBackColor = false;
            btnThucDon.Click += btnThucDon_Click;
            // 
            // btnCheBien
            // 
            btnCheBien.BackColor = Color.White;
            btnCheBien.Cursor = Cursors.Hand;
            btnCheBien.Dock = DockStyle.Top;
            btnCheBien.FlatAppearance.BorderSize = 0;
            btnCheBien.FlatStyle = FlatStyle.Flat;
            btnCheBien.Location = new Point(0, 75);
            btnCheBien.Margin = new Padding(4, 5, 4, 5);
            btnCheBien.Name = "btnCheBien";
            btnCheBien.Padding = new Padding(21, 0, 0, 0);
            btnCheBien.Size = new Size(286, 75);
            btnCheBien.TabIndex = 9;
            btnCheBien.Text = "Chế biến";
            btnCheBien.TextAlign = ContentAlignment.MiddleLeft;
            btnCheBien.UseVisualStyleBackColor = false;
            btnCheBien.Click += btnCheBien_Click;
            // 
            // btnTongQuan
            // 
            btnTongQuan.BackColor = Color.White;
            btnTongQuan.Cursor = Cursors.Hand;
            btnTongQuan.Dock = DockStyle.Top;
            btnTongQuan.FlatAppearance.BorderSize = 0;
            btnTongQuan.FlatStyle = FlatStyle.Flat;
            btnTongQuan.Location = new Point(0, 0);
            btnTongQuan.Margin = new Padding(4, 5, 4, 5);
            btnTongQuan.Name = "btnTongQuan";
            btnTongQuan.Padding = new Padding(21, 0, 0, 0);
            btnTongQuan.Size = new Size(286, 75);
            btnTongQuan.TabIndex = 10;
            btnTongQuan.Text = "Tổng quan";
            btnTongQuan.TextAlign = ContentAlignment.MiddleLeft;
            btnTongQuan.UseVisualStyleBackColor = false;
            btnTongQuan.Click += btnTongQuan_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(286, 100);
            pnlContent.Margin = new Padding(4, 5, 4, 5);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1543, 1050);
            pnlContent.TabIndex = 2;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(24, 38, 66);
            pnlFooter.Controls.Add(lblFooter);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 1150);
            pnlFooter.Margin = new Padding(4, 5, 4, 5);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1829, 50);
            pnlFooter.TabIndex = 3;
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.ForeColor = Color.LightGray;
            lblFooter.Location = new Point(21, 10);
            lblFooter.Margin = new Padding(4, 0, 4, 0);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(271, 25);
            lblFooter.TabIndex = 0;
            lblFooter.Text = "© 2026 Restaurant Management";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1829, 1200);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Restaurant Management";
            Load += MainForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSidebar.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
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
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnMonChoPhucVu;
        private System.Windows.Forms.Button btnTaoDon;
        private System.Windows.Forms.Button btnQuanLyBan;
        private System.Windows.Forms.Button btnNguyenLieu;
        private System.Windows.Forms.Button btnThucDon;
        private System.Windows.Forms.Button btnCheBien;
        private System.Windows.Forms.Button btnTongQuan;
    }
}