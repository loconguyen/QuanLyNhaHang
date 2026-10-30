using System.Data;
using QLNhaHang.Classes;

namespace QLNhaHang.Forms.TaiKhoan
{
    internal sealed class frmChiTietNhanVien : Form
    {
        internal frmChiTietNhanVien(DataRow thongTin)
        {
            Text = "Thông tin chi tiết nhân viên";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(640, 720);
            MinimumSize = new Size(480, 420);
            Font = new Font("Segoe UI", 10F);
            BackColor = Theme.Background;
            MinimizeBox = false;
            MaximizeBox = false;

            var boCuc = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3,
                Padding = new Padding(20)
            };
            boCuc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            boCuc.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            boCuc.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            boCuc.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bool coHoSo = !thongTin.IsNull("NhanVienID");
            boCuc.Controls.Add(new Label
            {
                Text = coHoSo ? "Hồ sơ nhân viên" : "Thông tin đăng ký — chưa có hồ sơ nhân viên",
                AutoSize = true, Dock = DockStyle.Top,
                Font = new Font(Font, FontStyle.Bold), Margin = new Padding(0, 0, 0, 16)
            }, 0, 0);

            var cuon = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            var bang = new TableLayoutPanel
            {
                Dock = DockStyle.Top, AutoSize = true, ColumnCount = 2,
                Padding = new Padding(0, 0, 16, 0)
            };
            bang.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155));
            bang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            (string Cot, string Nhan)[] cacTruong =
            {
                ("NhanVienID", "Mã nhân viên"), ("HoTen", "Họ và tên"),
                ("NgaySinh", "Ngày sinh"), ("GioiTinh", "Giới tính"),
                ("SDT", "Số điện thoại"), ("Email", "Email"), ("DiaChi", "Địa chỉ"),
                ("ChucVu", "Chức vụ"), ("NgayVaoLam", "Ngày vào làm"),
                ("TrangThaiNhanVien", "Trạng thái nhân viên"),
                ("TenDangNhap", "Tên đăng nhập"), ("TenVaiTro", "Vai trò"),
                ("TrangThaiTaiKhoan", "Trạng thái tài khoản"), ("NgayDangKy", "Ngày đăng ký")
            };
            foreach (var (cot, nhan) in cacTruong)
            {
                int hang = bang.RowCount++;
                bang.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                bang.Controls.Add(new Label
                {
                    Text = nhan, AutoSize = true, Anchor = AnchorStyles.Left,
                    Margin = new Padding(0, 8, 8, 8)
                }, 0, hang);
                object giaTri = thongTin[cot];
                string noiDung = giaTri == DBNull.Value || string.IsNullOrWhiteSpace(Convert.ToString(giaTri))
                    ? "Chưa có thông tin"
                    : giaTri is DateTime ngay ? ngay.ToString(cot == "NgayDangKy" ? "dd/MM/yyyy HH:mm" : "dd/MM/yyyy")
                    : Convert.ToString(giaTri)!;
                if (cot == "TenVaiTro" && giaTri != DBNull.Value)
                    noiDung = noiDung switch
                    {
                        "ADMIN" => "Quản lý", "BEP" => "Bếp", "PHUCVU" => "Phục vụ",
                        "THUNGAN" => "Thu ngân", "KHO" => "Kho", _ => noiDung
                    };
                bang.Controls.Add(new TextBox
                {
                    Text = noiDung, ReadOnly = true, Multiline = true,
                    Height = cot == "DiaChi" ? 64 : 44,
                    Dock = DockStyle.Fill, Margin = new Padding(0, 4, 0, 4),
                    BackColor = Color.White, ScrollBars = ScrollBars.Vertical,
                    AccessibleName = nhan
                }, 1, hang);
            }
            cuon.Controls.Add(bang);
            boCuc.Controls.Add(cuon, 0, 1);
            var dong = new Button
            {
                Text = "Đóng", AutoSize = true, Anchor = AnchorStyles.Right,
                DialogResult = DialogResult.Cancel, Padding = new Padding(16, 5, 16, 5),
                Margin = new Padding(0, 12, 0, 0)
            };
            boCuc.Controls.Add(dong, 0, 2);
            CancelButton = dong;
            Controls.Add(boCuc);
        }
    }
}
