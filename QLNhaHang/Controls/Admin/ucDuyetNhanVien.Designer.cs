namespace QLNhaHang.Controls.Admin
{
    partial class ucDuyetNhanVien
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            Font = new Font("Segoe UI", 10F);
            BackColor = Color.FromArgb(248, 249, 251);
            ForeColor = Color.FromArgb(23, 38, 62);
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            Padding = new Padding(24);
            Size = new Size(1080, 660);
            Name = "ucDuyetNhanVien";

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Top, AutoSize = true, ColumnCount = 1,
                Padding = new Padding(0), Margin = new Padding(0)
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            var title = new Label
            {
                Text = "Duyệt tài khoản nhân viên mới", AutoSize = true,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Margin = new Padding(0, 0, 0, 8)
            };
            var note = new Label
            {
                Text = "Tạo hồ sơ cho người đăng ký mới. Nhân viên đã có hồ sơ được cấp tài khoản tại mục Tài khoản.",
                AutoSize = true, Margin = new Padding(0, 0, 0, 20)
            };
            layout.Controls.Add(title);
            layout.Controls.Add(note);

            txtTenDangNhap = TaoO(true);
            txtHoTenDK = TaoO(true);
            txtSDTDK = TaoO(true);
            txtThoiGianDK = TaoO(true);
            txtTrangThai = TaoO(true);
            var dangKy = TaoBang();
            ThemDong(dangKy, "Tên đăng nhập", txtTenDangNhap, "Họ tên đăng ký", txtHoTenDK);
            ThemDong(dangKy, "Số điện thoại", txtSDTDK, "Ngày đăng ký", txtThoiGianDK);
            ThemDong(dangKy, "Trạng thái", txtTrangThai, "", new Label());
            var gbDangKy = new GroupBox
            {
                Text = "Thông tin đăng ký", Dock = DockStyle.Top, AutoSize = true,
                Padding = new Padding(16, 24, 16, 12), Margin = new Padding(0, 0, 0, 20)
            };
            gbDangKy.Controls.Add(dangKy);
            layout.Controls.Add(gbDangKy);

            txtHoTenNVM = TaoO(true);
            txtSDTNVM = TaoO(true);
            txtEmail = TaoO(false);
            txtDiaChi = TaoO(false);
            txtEmail.MaxLength = 100;
            txtDiaChi.MaxLength = 255;
            cbGioiTinh = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
            cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            comboBox1 = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
            dateTimePicker1 = new DateTimePicker { Format = DateTimePickerFormat.Short, Dock = DockStyle.Fill };
            dateTimePicker2 = new DateTimePicker { Format = DateTimePickerFormat.Short, Dock = DockStyle.Fill };
            var hoSo = TaoBang();
            ThemDong(hoSo, "Họ và tên", txtHoTenNVM, "Số điện thoại", txtSDTNVM);
            ThemDong(hoSo, "Ngày sinh", dateTimePicker1, "Giới tính", cbGioiTinh);
            ThemDong(hoSo, "Email", txtEmail, "Địa chỉ", txtDiaChi);
            ThemDong(hoSo, "Ngày vào làm", dateTimePicker2, "Vai trò", comboBox1);
            gbNhanVienMoi = new GroupBox
            {
                Text = "Hồ sơ nhân viên mới", Dock = DockStyle.Top, AutoSize = true, Enabled = false,
                Padding = new Padding(16, 24, 16, 12), Margin = new Padding(0, 0, 0, 20)
            };
            gbNhanVienMoi.Controls.Add(hoSo);
            layout.Controls.Add(gbNhanVienMoi);

            var actions = new FlowLayoutPanel
            {
                Dock = DockStyle.Top, AutoSize = true, FlowDirection = FlowDirection.RightToLeft,
                Margin = new Padding(0), Padding = new Padding(0, 4, 0, 8)
            };
            btnXacNhanDuyet = new Button
            {
                Text = "Xác nhận duyệt", AutoSize = true, Height = 42, Enabled = false,
                BackColor = Color.FromArgb(23, 38, 62), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Padding = new Padding(16, 8, 16, 8)
            };
            btnQuayLai = new Button { Text = "Quay lại", AutoSize = true, Padding = new Padding(16, 8, 16, 8) };
            btnXacNhanDuyet.Click += btnXacNhanDuyet_Click;
            btnQuayLai.Click += btnQuayLai_Click;
            actions.Controls.Add(btnXacNhanDuyet);
            actions.Controls.Add(btnQuayLai);
            layout.Controls.Add(actions);
            Controls.Add(layout);
            ResumeLayout(true);
        }

        private static TextBox TaoO(bool chiDoc) => new TextBox
        {
            ReadOnly = chiDoc, Dock = DockStyle.Fill,
            BackColor = chiDoc ? Color.FromArgb(241, 245, 249) : Color.White
        };

        private static TableLayoutPanel TaoBang()
        {
            var bang = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 4 };
            bang.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140));
            bang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            bang.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140));
            bang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            return bang;
        }

        private static void ThemDong(TableLayoutPanel bang, string ten1, Control o1, string ten2, Control o2)
        {
            int dong = bang.RowCount++;
            bang.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bang.Controls.Add(new Label { Text = ten1, AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(0, 8, 8, 12) }, 0, dong);
            o1.Margin = new Padding(0, 4, 20, 12);
            bang.Controls.Add(o1, 1, dong);
            bang.Controls.Add(new Label { Text = ten2, AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(0, 8, 8, 12) }, 2, dong);
            o2.Margin = new Padding(0, 4, 0, 12);
            bang.Controls.Add(o2, 3, dong);
        }

        private TextBox txtTenDangNhap, txtHoTenDK, txtSDTDK, txtThoiGianDK, txtTrangThai;
        private TextBox txtHoTenNVM, txtSDTNVM, txtEmail, txtDiaChi;
        private ComboBox cbGioiTinh, comboBox1;
        private DateTimePicker dateTimePicker1, dateTimePicker2;
        private GroupBox gbNhanVienMoi;
        private Button btnXacNhanDuyet, btnQuayLai;
    }
}
