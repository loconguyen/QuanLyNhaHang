
using System;
using System.Windows.Forms;
using QLNhaHang.Classes;

namespace QLNhaHang.Forms.DangKy
{
    public partial class frmDangKy : Form
    {
        // Đối tượng xử lý nghiệp vụ tài khoản
        private readonly QuanLyTaiKhoan qlTaiKhoan =
            new QuanLyTaiKhoan();

        public frmDangKy()
        {
            InitializeComponent();

            // Gắn sự kiện nếu chưa gắn trong Designer
            btnDangKy.Click -= btnDangKy_Click;
            btnDangKy.Click += btnDangKy_Click;

            linkDangNhap.LinkClicked -= linkDangNhap_LinkClicked;
            linkDangNhap.LinkClicked += linkDangNhap_LinkClicked;

            txtMatKhau.UseSystemPasswordChar = true;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;
        }

   
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            //  Lấy dữ liệu
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string xacNhanMatKhau = txtXacNhanMatKhau.Text;

            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                txtHoTen.Focus();
                return;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                txtSDT.Focus();
                return;
            }

            // Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                txtTenDangNhap.Focus();
                return;
            }

            //  Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus();
                return;
            }

            //Kiểm tra xác nhận mật khẩu
            if (string.IsNullOrWhiteSpace(xacNhanMatKhau))
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu!");
                txtXacNhanMatKhau.Focus();
                return;
            }

            if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show(
                    "Mật khẩu xác nhận không khớp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtXacNhanMatKhau.Clear();
                txtXacNhanMatKhau.Focus();
                return;
            }

            //  Lưu thông tin đăng ký
            try
            {
                btnDangKy.Enabled = false;

                qlTaiKhoan.GuiYeuCau(
                    hoTen,
                    sdt,
                    tenDangNhap,
                    matKhau
                );

                MessageBox.Show(
                    "Đăng ký thành công!\n" +
                    "Tài khoản đang chờ quản lý phê duyệt.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Đóng Form đăng ký
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đăng ký thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnDangKy.Enabled = true;
            }
        }

        // QUAY LẠI ĐĂNG NHẬP
        
        private void linkDangNhap_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
