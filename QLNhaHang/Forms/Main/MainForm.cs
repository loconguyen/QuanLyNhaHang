using QLNhaHang.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLNhaHang.Forms.Main
{
    public partial class MainForm : Form
    {
        private Button btnActive;

        // true khi người dùng bấm Đăng xuất (Program.cs đọc để mở lại LoginForm)
        public bool DangXuat { get; private set; }

        public MainForm()
        {
            InitializeComponent();
        }

        // ===== KHỞI ĐỘNG: Session đã được LoginForm gán sẵn =====
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = Session.HoTen + " - " + Session.Role;

            ApplyRole();   // ẩn các menu không thuộc quyền

            // Mở màn hình đầu tiên mà role được phép
            Button[] thuTu =
            {
                btnTongQuan,
                btnQuanLyBan,
                btnHoaDon,
                btnTaiKhoan
            };

            foreach (Button b in thuTu)
            {
                if (b.Visible)
                {
                    b.PerformClick();
                    break;
                }
            }
        }

        // ===== ĐĂNG XUẤT =====
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat = true;
            Session.Clear();
            Close();   // Program.cs sẽ mở lại LoginForm
        }

        // ===== PHÂN QUYỀN MENU =====
        private void ApplyRole()
        {
            string r = Session.Role;
            bool admin = r == "ADMIN";

            btnTongQuan.Visible =
                btnCheBien.Visible =
                btnThucDon.Visible =
                btnNguyenLieu.Visible =
                (r == "BEP" || admin);

            btnQuanLyBan.Visible =
                btnTaoDon.Visible =
                btnMonChoPhucVu.Visible =
                (r == "PHUC_VU" || admin);

            btnHoaDon.Visible =
                btnThanhToan.Visible =
                (r == "THU_NGAN" || admin);

            btnTaiKhoan.Visible = admin;
        }

        // ===== HIỂN THỊ NỘI DUNG =====
        private void SetContent(UserControl uc)
        {
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
        }

        // ===== MỞ MÀN HÌNH =====
        private void Open(Button btn, string title, UserControl uc = null)
        {
            if (btnActive != null)
            {
                btnActive.BackColor = Color.White;
            }

            btnActive = btn;
            btnActive.BackColor = Color.FromArgb(220, 230, 245);

            lblScreen.Text = title;

            if (uc == null)
            {
                uc = Placeholder(title);
            }

            SetContent(uc);
        }

        // ===== GIAO DIỆN TẠM THỜI =====
        private UserControl Placeholder(string text)
        {
            UserControl uc = new UserControl();

            Label lbl = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 30)
            };

            uc.Controls.Add(lbl);
            return uc;
        }

        // ===== CÁC NÚT MENU =====
        private void btnTongQuan_Click(object sender, EventArgs e) { Open(btnTongQuan, "Tổng quan"); }
        private void btnCheBien_Click(object sender, EventArgs e) { Open(btnCheBien, "Chế biến"); }
        private void btnThucDon_Click(object sender, EventArgs e) { Open(btnThucDon, "Thực đơn"); }
        private void btnNguyenLieu_Click(object sender, EventArgs e) { Open(btnNguyenLieu, "Nguyên liệu"); }
        private void btnQuanLyBan_Click(object sender, EventArgs e) { Open(btnQuanLyBan, "Quản lý bàn"); }
        private void btnTaoDon_Click(object sender, EventArgs e) { Open(btnTaoDon, "Tạo đơn"); }
        private void btnMonChoPhucVu_Click(object sender, EventArgs e) { Open(btnMonChoPhucVu, "Món chờ phục vụ"); }
        private void btnHoaDon_Click(object sender, EventArgs e) { Open(btnHoaDon, "Hóa đơn"); }
        private void btnThanhToan_Click(object sender, EventArgs e) { Open(btnThanhToan, "Thanh toán"); }
        private void btnTaiKhoan_Click(object sender, EventArgs e) { Open(btnTaiKhoan, "Tài khoản"); }
    }
}