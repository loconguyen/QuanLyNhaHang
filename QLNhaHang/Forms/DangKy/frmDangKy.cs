using System;
using System.Windows.Forms;

namespace QLNhaHang.Forms.DangKy
{
    public partial class frmDangKy : Form
    {
        private bool dangGui;
        public frmDangKy()
        {
            InitializeComponent();
            FormClosing += (_, e) => { if (dangGui) e.Cancel = true; };
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            txtNhapLaiMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void lnkDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            if (dangGui) return;
            lblThongBao.Text = "";
            foreach (TextBox oNhap in new[] { txtHoTen, txtSoDienThoai, txtTenDangNhap, txtMatKhau, txtNhapLaiMatKhau })
            {
                if (string.IsNullOrWhiteSpace(oNhap.Text))
                {
                    lblThongBao.Text = "Vui lòng nhập đầy đủ thông tin.";
                    oNhap.Focus();
                    return;
                }
            }
            string soDienThoai = txtSoDienThoai.Text.Trim();
            if (soDienThoai.Length != 10 || soDienThoai[0] != '0' ||
                !System.Linq.Enumerable.All(soDienThoai, c => c >= '0' && c <= '9'))
            {
                lblThongBao.Text = "Số điện thoại cần có 10 chữ số và bắt đầu bằng 0.";
                txtSoDienThoai.Focus();
                return;
            }
            if (txtMatKhau.Text.Length < 8)
            {
                lblThongBao.Text = "Mật khẩu cần có ít nhất 8 ký tự.";
                txtMatKhau.Focus();
                return;
            }
            if (txtMatKhau.Text != txtNhapLaiMatKhau.Text)
            {
                lblThongBao.Text = "Mật khẩu nhập lại chưa khớp.";
                txtNhapLaiMatKhau.Focus();
                return;
            }
            btnDangKy.Enabled = false;
            dangGui = true;
            string hoTen = txtHoTen.Text.Trim();
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            UseWaitCursor = true;
            try
            {
                await System.Threading.Tasks.Task.Run(() =>
                    new Classes.QuanLyTaiKhoan().GuiYeuCau(hoTen, soDienThoai, tenDangNhap, matKhau));
                if (IsDisposed) return;
                dangGui = false;
                MessageBox.Show("Đã gửi yêu cầu đăng ký. Vui lòng chờ Admin duyệt và cấp mã nhân viên.",
                    "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (InvalidOperationException ex)
            {
                lblThongBao.Text = ex.Message;
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                lblThongBao.Text = ex.Number >= 50000 ? ex.Message
                    : ex.Number == 2601 || ex.Number == 2627
                    ? "Tên đăng nhập hoặc số điện thoại đã có yêu cầu chờ duyệt."
                    : "Không gửi được yêu cầu. Kiểm tra kết nối và chạy Database/DangKyTaiKhoan.sql.";
            }
            finally
            {
                dangGui = false;
                if (!IsDisposed)
                {
                    btnDangKy.Enabled = true;
                    UseWaitCursor = false;
                }
            }
        }

        private void lblTieuDe_Click(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }
    }
}
