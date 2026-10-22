using System.Data;
using QLNhaHang.Classes;

namespace QLNhaHang.Forms.DangNhap
{
    public partial class DangNhapForm : Form
    {
        private bool dangDangNhap;

        public DangNhapForm()
        {
            InitializeComponent();
            FormClosing += (_, e) => { if (dangDangNhap) e.Cancel = true; };
            txtMatKhau.UseSystemPasswordChar = true;
            linkDK.LinkClicked += linkDK_LinkClicked;
            LoadBoPhan();
            heading.Font = Theme.H1;
            Theme.StyleForm(this);
            Theme.StyleButton(btnDangNhap);
            Theme.StyleComboBox(cbRole);
            Theme.StyleTextBox(txtDangNhap);
            Theme.StyleTextBox(txtMaNhanVien);
            Theme.StyleTextBox(txtMatKhau);
            Theme.StyleLink(linkDK);
            Theme.StyleLink(linkMatKhau);
            pnlDangNhap.Left = (ClientSize.Width - pnlDangNhap.Width) / 2;
            pnlDangNhap.Top = (ClientSize.Height - pnlDangNhap.Height) / 2;
            pnlDangNhap.BackColor = Color.White;
        }

        private void linkDK_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dangDangNhap) return;
            using var dangKy = new QLNhaHang.Forms.DangKy.frmDangKy();
            dangKy.ShowDialog(this);
        }

        private void LoadBoPhan()
        {
            cbRole.DataSource = new[]
            {
                new { Text = "Quản lý", Value = "ADMIN" },
                new { Text = "Bếp", Value = "BEP" },
                new { Text = "Thu ngân", Value = "THUNGAN" },
                new { Text = "Phục vụ", Value = "PHUCVU" }
            };
            cbRole.DisplayMember = "Text";
            cbRole.ValueMember = "Value";
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRole.SelectedIndex = -1;
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (dangDangNhap) return;
            if (string.IsNullOrWhiteSpace(txtDangNhap.Text) || string.IsNullOrWhiteSpace(txtMaNhanVien.Text)
                || string.IsNullOrEmpty(txtMatKhau.Text) || cbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (!int.TryParse(txtMaNhanVien.Text, out int maNV) || maNV <= 0)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ!");
                return;
            }
            string ten = txtDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string vaiTro = cbRole.SelectedValue!.ToString()!;
            DataRow? taiKhoan;
            dangDangNhap = true;
            btnDangNhap.Enabled = false;
            UseWaitCursor = true;
            try
            {
                taiKhoan = await Task.Run(() => new QuanLyTaiKhoan().DangNhap(ten, maNV, vaiTro, matKhau));
                if (IsDisposed) return;
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                if (!IsDisposed) MessageBox.Show("Không thể đọc dữ liệu đăng nhập. Vui lòng kiểm tra kết nối và cấu trúc database.");
                return;
            }
            finally
            {
                dangDangNhap = false;
                if (!IsDisposed) { btnDangNhap.Enabled = true; UseWaitCursor = false; }
            }
            if (taiKhoan == null)
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác hoặc tài khoản chưa được duyệt/đã bị khóa!");
                return;
            }
            Session.TaiKhoanID = Convert.ToInt32(taiKhoan["TaiKhoanID"]);
            Session.NhanVienID = Convert.ToInt32(taiKhoan["NhanVienID"]);
            Session.HoTen = taiKhoan["HoTen"].ToString()!;
            Session.Role = taiKhoan["TenVaiTro"].ToString() switch
            {
                "PHUCVU" => "PHUC_VU",
                "THUNGAN" => "THU_NGAN",
                var quyen => quyen!
            };
            MessageBox.Show("Đăng nhập thành công!");
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
