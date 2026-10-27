using System.Data;
using System.Windows.Forms;
using QLNhaHang.Classes;
using Microsoft.Data.SqlClient;
namespace QLNhaHang.Forms.DangNhap
{
    public partial class DangNhapForm : Form
    {
        private bool dangDangNhap;
        Classes.DataProcesser db = new DataProcesser();

        public DangNhapForm()
        {
            
            InitializeComponent();
            FormClosing += (_, e) => { if (dangDangNhap) e.Cancel = true; };
            txtMatKhau.UseSystemPasswordChar = true;
            linkDK.LinkClicked += linkDK_LinkClicked;
            LoadBoPhan();
           
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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (dangDangNhap)
                return;

            // 1. Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(txtDangNhap.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text) ||
                cbRole.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 3. Lấy dữ liệu
            string username = txtDangNhap.Text.Trim();
            string password = txtMatKhau.Text;
            string role = cbRole.SelectedValue!.ToString()!;

            try
            {
                dangDangNhap = true;
                btnDangNhap.Enabled = false;

                // 4. Kết nối SQL Server
                using var conn = db.TaoKetNoi();
                conn.Open();

                string sql = @"
            SELECT
                tk.TaiKhoanID,
                tk.NhanVienID,
                tk.TenDangNhap,
                tk.MatKhauHash,
                tk.TrangThai,
                nv.HoTen,
                vt.TenVaiTro
            FROM dbo.TAI_KHOAN tk
            JOIN dbo.NHAN_VIEN nv
                ON tk.NhanVienID = nv.NhanVienID
            JOIN dbo.VAI_TRO vt
                ON tk.RoleID = vt.RoleID
            WHERE tk.TenDangNhap = @username
              AND vt.TenVaiTro = @role";

                using var cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@username", SqlDbType.VarChar, 50)
                    .Value = username;

cmd.Parameters.Add("@role", SqlDbType.VarChar, 30)
                    .Value = role;

                // 5. Truy vấn tài khoản
                using var reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show(
                        "Tên đăng nhập hoặc vai trò không chính xác!",
                        "Đăng nhập thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 6. Kiểm tra trạng thái tài khoản
                string trangThai = reader["TrangThai"].ToString()!;
                string matKhauHash = reader["MatKhauHash"].ToString()!;

                if (trangThai != "Hoạt động")
                {
                    MessageBox.Show(
                        "Tài khoản chưa được duyệt hoặc đã bị khóa!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 7. Kiểm tra mật khẩu đã băm
                if (!BaoMatMatKhau.KiemTraMatKhau(password, matKhauHash))
                {
                    MessageBox.Show(
                        "Mật khẩu không chính xác!",
                        "Đăng nhập thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8. Lưu thông tin vào Session
                Session.TaiKhoanID =
                    Convert.ToInt32(reader["TaiKhoanID"]);

                Session.NhanVienID =
                    Convert.ToInt32(reader["NhanVienID"]);

                Session.HoTen =
                    reader["HoTen"].ToString()!;

                Session.Role =
                    reader["TenVaiTro"].ToString()!;

                // 9. Đăng nhập thành công
                MessageBox.Show(
                    "Đăng nhập thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Cho phép đóng form để Program mở MainForm sau khi xác thực xong.
                dangDangNhap = false;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi đăng nhập:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dangDangNhap = false;
                btnDangNhap.Enabled = true;
            }

        }
           

        }
    
}
