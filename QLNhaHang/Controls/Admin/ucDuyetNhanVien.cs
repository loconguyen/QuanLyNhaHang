using System.Data;
using QLNhaHang.Classes;

namespace QLNhaHang.Controls.Admin
{
    public partial class ucDuyetNhanVien : UserControl
    {
        private readonly int taiKhoanID;
        private readonly QuanLyTaiKhoan qltk = new QuanLyTaiKhoan();
        private bool daDuyet;

        public ucDuyetNhanVien()
        {
            InitializeComponent();
        }

        public ucDuyetNhanVien(int taiKhoanID) : this()
        {
            this.taiKhoanID = taiKhoanID;
            LoadThongTinDangKy();
        }

        private void LoadThongTinDangKy()
        {
            try
            {
                DataRow? row = qltk.LayThongTinDangKy(taiKhoanID);
                if (row == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản đang chờ duyệt!");
                    return;
                }

                txtTenDangNhap.Text = row["TenDangNhap"].ToString();
                txtHoTenDK.Text = txtHoTenNVM.Text = row["HoTenDangKy"].ToString();
                txtSDTDK.Text = txtSDTNVM.Text = row["SDTDangKy"].ToString();
                txtThoiGianDK.Text = row["NgayDangKy"] == DBNull.Value
                    ? "" : Convert.ToDateTime(row["NgayDangKy"]).ToString("dd/MM/yyyy HH:mm");
                txtTrangThai.Text = row["TrangThai"].ToString();
                comboBox1.DisplayMember = "TenHienThi";
                comboBox1.ValueMember = "RoleID";
                comboBox1.DataSource = qltk.LayVaiTro();
                comboBox1.SelectedIndex = -1;
                gbNhanVienMoi.Enabled = true;
                btnXacNhanDuyet.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin đăng ký: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object? sender, EventArgs e)
        {
            if (FindForm() is QLNhaHang.Forms.Main.MainForm main)
                main.MoDanhSachTaiKhoan();
        }

        private void btnXacNhanDuyet_Click(object? sender, EventArgs e)
        {
            if (daDuyet) return;
            if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò!");
                return;
            }
            if (cbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return;
            }

            var thongTin = new ThongTinNhanVien
            {
                HoTen = txtHoTenNVM.Text.Trim(),
                SDT = txtSDTNVM.Text.Trim(),
                NgaySinh = dateTimePicker1.Value.Date,
                GioiTinh = cbGioiTinh.Text,
                Email = txtEmail.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                NgayVaoLam = dateTimePicker2.Value.Date
            };
            if (MessageBox.Show("Tạo hồ sơ nhân viên mới và duyệt tài khoản này?",
                "Xác nhận duyệt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                btnXacNhanDuyet.Enabled = false;
                int maNV = qltk.DuyetNhanVienMoi(taiKhoanID,
                    Convert.ToInt32(comboBox1.SelectedValue), thongTin);
                daDuyet = true;
                gbNhanVienMoi.Enabled = false;
                MessageBox.Show("Duyệt tài khoản thành công!\nMã nhân viên mới: " + maNV,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnQuayLai_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyệt tài khoản thất bại!\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnXacNhanDuyet.Enabled = !daDuyet;
            }
        }
    }
}
