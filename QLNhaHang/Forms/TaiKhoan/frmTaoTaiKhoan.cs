using Microsoft.Data.SqlClient;
using QLNhaHang.Classes;

namespace QLNhaHang.Forms.TaiKhoan
{
    public partial class frmTaoTaiKhoan : Form
    {
        private readonly QuanLyTaiKhoan xuLy = new QuanLyTaiKhoan();
        private bool dangLuu;
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }
        private async void frmTaoTaiKhoan_Load(object? sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            btnTao.Enabled = false;
            UseWaitCursor = true;
            try
            {
                var ketQua = await Task.Run(() => (NhanVien: xuLy.LayNhanVienChuaCoTaiKhoan(), VaiTro: xuLy.LayVaiTro()));
                if (IsDisposed) return;
                cbNhanVien.DisplayMember = "TenHienThi";
                cbNhanVien.ValueMember = "NhanVienID";
                cbNhanVien.DataSource = ketQua.NhanVien;
                cbNhanVien.SelectedIndex = -1;
                cbVaiTro.DisplayMember = "TenHienThi";
                cbVaiTro.ValueMember = "RoleID";
                cbVaiTro.DataSource = ketQua.VaiTro;
                cbVaiTro.SelectedIndex = -1;
                btnTao.Enabled = ketQua.NhanVien.Rows.Count > 0;
                lblThongBao.Text = ketQua.NhanVien.Rows.Count == 0
                    ? "Không có nhân viên đang làm chưa được cấp tài khoản."
                    : "Chọn nhân viên và quyền truy cập phù hợp.";
            }
            catch (Exception ex) when (ex is SqlException || ex is InvalidOperationException)
            {
                if (!IsDisposed) HienLoi(ex);
            }
            finally { if (!IsDisposed) UseWaitCursor = false; }
        }
        private async void btnTao_Click(object? sender, EventArgs e)
        {
            if (dangLuu) return;
            if (cbNhanVien.SelectedValue is not int maNV || cbVaiTro.SelectedValue is not int role)
            { lblThongBao.Text = "Vui lòng chọn nhân viên và vai trò."; return; }
            if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
            { lblThongBao.Text = "Mật khẩu nhập lại chưa khớp."; return; }
            string ten = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            dangLuu = true;
            btnTao.Enabled = btnHuy.Enabled = false;
            UseWaitCursor = true;
            try
            {
                await Task.Run(() => xuLy.TaoTaiKhoan(maNV, ten, role, matKhau));
                if (IsDisposed) return;
                dangLuu = false;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) when (ex is SqlException || ex is InvalidOperationException)
            {
                if (!IsDisposed) HienLoi(ex);
            }
            finally
            {
                dangLuu = false;
                if (!IsDisposed) { btnTao.Enabled = btnHuy.Enabled = true; UseWaitCursor = false; }
            }
        }
        private void HienLoi(Exception ex)
        {
            lblThongBao.ForeColor = Color.FromArgb(170, 60, 30);
            lblThongBao.Text = ex is SqlException sql && sql.Number < 50000
                ? sql.Number is 2601 or 2627 ? "Nhân viên hoặc tên đăng nhập đã có tài khoản."
                : "Không thể cấp tài khoản. Kiểm tra kết nối và cấu trúc database."
                : ex.Message;
        }
        private void chkHienMatKhau_CheckedChanged(object? sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = txtXacNhanMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }
        private void frmTaoTaiKhoan_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (dangLuu) e.Cancel = true;
        }
    }
}
