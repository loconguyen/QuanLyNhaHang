namespace QLNhaHang.Forms.DangKy
{
    partial class frmDangKy
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            pnlDangKy = new Panel();
            lblTieuDe = new Label();
            lblMoTa = new Label();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            lblNhapLaiMatKhau = new Label();
            txtNhapLaiMatKhau = new TextBox();
            chkHienMatKhau = new CheckBox();
            lblChoDuyet = new Label();
            btnDangKy = new Button();
            lnkDangNhap = new LinkLabel();
            lblThongBao = new Label();
            pnlDangKy.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDangKy
            // 
            pnlDangKy.BackColor = Color.White;
            pnlDangKy.Controls.Add(lblTieuDe);
            pnlDangKy.Controls.Add(lblMoTa);
            pnlDangKy.Controls.Add(lblHoTen);
            pnlDangKy.Controls.Add(txtHoTen);
            pnlDangKy.Controls.Add(lblSoDienThoai);
            pnlDangKy.Controls.Add(txtSoDienThoai);
            pnlDangKy.Controls.Add(lblTenDangNhap);
            pnlDangKy.Controls.Add(txtTenDangNhap);
            pnlDangKy.Controls.Add(lblMatKhau);
            pnlDangKy.Controls.Add(txtMatKhau);
            pnlDangKy.Controls.Add(lblNhapLaiMatKhau);
            pnlDangKy.Controls.Add(txtNhapLaiMatKhau);
            pnlDangKy.Controls.Add(chkHienMatKhau);
            pnlDangKy.Controls.Add(lblChoDuyet);
            pnlDangKy.Controls.Add(btnDangKy);
            pnlDangKy.Controls.Add(lnkDangNhap);
            pnlDangKy.Location = new Point(32, 24);
            pnlDangKy.Name = "pnlDangKy";
            pnlDangKy.Size = new Size(496, 712);
            pnlDangKy.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(23, 38, 62);
            lblTieuDe.Location = new Point(32, 24);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(432, 50);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Tạo tài khoản";
            lblTieuDe.Click += lblTieuDe_Click;
            // 
            // lblMoTa
            // 
            lblMoTa.ForeColor = Color.FromArgb(100, 112, 130);
            lblMoTa.Location = new Point(34, 80);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(430, 28);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Đăng ký để tham gia hệ thống quản lý nhà hàng.";
            // 
            // lblHoTen
            // 
            lblHoTen.Location = new Point(34, 120);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(430, 24);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ và tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 12F);
            txtHoTen.Location = new Point(34, 146);
            txtHoTen.MaxLength = 100;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.PlaceholderText = "Nhập họ tên đầy đủ";
            txtHoTen.Size = new Size(428, 39);
            txtHoTen.TabIndex = 0;
            txtHoTen.TextChanged += txtHoTen_TextChanged;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.Location = new Point(34, 196);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(430, 24);
            lblSoDienThoai.TabIndex = 3;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Font = new Font("Segoe UI", 12F);
            txtSoDienThoai.Location = new Point(34, 222);
            txtSoDienThoai.MaxLength = 10;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.PlaceholderText = "Nhập số điện thoại";
            txtSoDienThoai.Size = new Size(428, 39);
            txtSoDienThoai.TabIndex = 1;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.Location = new Point(34, 272);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(430, 24);
            lblTenDangNhap.TabIndex = 4;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Segoe UI", 12F);
            txtTenDangNhap.Location = new Point(34, 298);
            txtTenDangNhap.MaxLength = 50;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.PlaceholderText = "Nhập tên đăng nhập";
            txtTenDangNhap.Size = new Size(428, 39);
            txtTenDangNhap.TabIndex = 2;
            // 
            // lblMatKhau
            // 
            lblMatKhau.Location = new Point(34, 348);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(430, 24);
            lblMatKhau.TabIndex = 5;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 12F);
            txtMatKhau.Location = new Point(34, 374);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PlaceholderText = "Ít nhất 8 ký tự";
            txtMatKhau.Size = new Size(428, 39);
            txtMatKhau.TabIndex = 3;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // lblNhapLaiMatKhau
            // 
            lblNhapLaiMatKhau.Location = new Point(34, 424);
            lblNhapLaiMatKhau.Name = "lblNhapLaiMatKhau";
            lblNhapLaiMatKhau.Size = new Size(430, 24);
            lblNhapLaiMatKhau.TabIndex = 6;
            lblNhapLaiMatKhau.Text = "Nhập lại mật khẩu";
            // 
            // txtNhapLaiMatKhau
            // 
            txtNhapLaiMatKhau.Font = new Font("Segoe UI", 12F);
            txtNhapLaiMatKhau.Location = new Point(34, 450);
            txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            txtNhapLaiMatKhau.PlaceholderText = "Xác nhận mật khẩu";
            txtNhapLaiMatKhau.Size = new Size(428, 39);
            txtNhapLaiMatKhau.TabIndex = 4;
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.Location = new Point(34, 499);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(200, 26);
            chkHienMatKhau.TabIndex = 5;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // lblChoDuyet
            // 
            lblChoDuyet.BackColor = Color.FromArgb(239, 244, 251);
            lblChoDuyet.ForeColor = Color.FromArgb(23, 38, 62);
            lblChoDuyet.Location = new Point(34, 535);
            lblChoDuyet.Name = "lblChoDuyet";
            lblChoDuyet.Padding = new Padding(12, 8, 12, 8);
            lblChoDuyet.Size = new Size(428, 58);
            lblChoDuyet.TabIndex = 7;
            lblChoDuyet.Text = "Tài khoản cần được Admin phê duyệt trước khi đăng nhập.";
            // 
            // btnDangKy
            // 
            btnDangKy.BackColor = Color.FromArgb(23, 38, 62);
            btnDangKy.Cursor = Cursors.Hand;
            btnDangKy.FlatAppearance.BorderSize = 0;
            btnDangKy.FlatStyle = FlatStyle.Flat;
            btnDangKy.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDangKy.ForeColor = Color.White;
            btnDangKy.Location = new Point(34, 605);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(428, 44);
            btnDangKy.TabIndex = 6;
            btnDangKy.Text = "Gửi yêu cầu đăng ký";
            btnDangKy.UseVisualStyleBackColor = false;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // lnkDangNhap
            // 
            lnkDangNhap.LinkArea = new LinkArea(17, 9);
            lnkDangNhap.LinkColor = Color.FromArgb(60, 115, 201);
            lnkDangNhap.Location = new Point(34, 662);
            lnkDangNhap.Name = "lnkDangNhap";
            lnkDangNhap.Size = new Size(428, 28);
            lnkDangNhap.TabIndex = 7;
            lnkDangNhap.TabStop = true;
            lnkDangNhap.Text = "Đã có tài khoản? Đăng nhập";
            lnkDangNhap.TextAlign = ContentAlignment.MiddleCenter;
            lnkDangNhap.UseCompatibleTextRendering = true;
            lnkDangNhap.LinkClicked += lnkDangNhap_LinkClicked;
            // 
            // lblThongBao
            // 
            lblThongBao.ForeColor = Color.FromArgb(170, 60, 30);
            lblThongBao.Location = new Point(32, 746);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(496, 52);
            lblThongBao.TabIndex = 1;
            lblThongBao.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmDangKy
            // 
            AcceptButton = btnDangKy;
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(248, 249, 251);
            ClientSize = new Size(1098, 804);
            Controls.Add(pnlDangKy);
            Controls.Add(lblThongBao);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(23, 38, 62);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDangKy";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đăng ký tài khoản";
            pnlDangKy.ResumeLayout(false);
            pnlDangKy.PerformLayout();
            ResumeLayout(false);
        }
        private Panel pnlDangKy;
        private Label lblTieuDe;
        private Label lblMoTa;
        private Label lblChoDuyet;
        private Label lblThongBao;
        private CheckBox chkHienMatKhau;
        private Button btnDangKy;
        private LinkLabel lnkDangNhap;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblNhapLaiMatKhau;
        private TextBox txtNhapLaiMatKhau;
    }
}

