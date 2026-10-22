using QLNhaHang.Classes;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLNhaHang.Controls.Admin;
using QLNhaHang.Controls.Bep;
using QLNhaHang.Controls.ThuNgan;
using QLNhaHang.Controls.PhucVu;
namespace QLNhaHang.Forms.Main
{
    public partial class MainForm : Form
    {
        private Button? btnActive;

        // true khi người dùng bấm Đăng xuất (Program.cs đọc để mở lại LoginForm)
        public bool DangXuat { get; private set; }

        public MainForm()
        {
            InitializeComponent();
        }

        // ===== KHỞI ĐỘNG: Session đã được LoginForm gán sẵn =====
        private void MainForm_Load(object? sender, EventArgs e)
        {
            lblUser.Text = Session.HoTen + " - " + Session.Role;

            ApplyRole();   // ẩn các menu không thuộc quyền

            // Mở màn hình đầu tiên mà role được phép (theo thứ tự trên sidebar)
            Button[] thuTu =
            {
                btnTongQuan, btnCheBien, btnThucDon, btnNguyenLieu,
                btnQuanLyBan, btnTaoDon, btnMonChoPhucVu,
                btnHoaDon, btnThanhToan, btnTaiKhoan
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
        private void btnDangXuat_Click(object? sender, EventArgs e)
        {
            DangXuat = true;
            Session.Clear();
            Close();   // Program.cs sẽ mở lại LoginForm
        }

        // ===== PHÂN QUYỀN MENU =====
        // Tên role phải khớp cột TenVaiTro trong bảng VAI_TRO: ADMIN, BEP, KHO, PHUCVU, THUNGAN
        private void ApplyRole()
        {
            string r = Session.Role ?? "";
            bool admin = r == "ADMIN";

            btnTongQuan.Visible =
                btnCheBien.Visible =
                btnThucDon.Visible =
                btnNguyenLieu.Visible =
                (r == "BEP" || admin);

            btnQuanLyBan.Visible =
                btnTaoDon.Visible =
                btnMonChoPhucVu.Visible =
                (r == "PHUCVU" || admin);

            btnHoaDon.Visible =
                btnThanhToan.Visible =
                (r == "THUNGAN" || admin);

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
        private void Open(Button btn, string title, UserControl? uc = null)
        {
            if (btnActive != null)
            {
                btnActive.BackColor = Color.White;
            }

            btnActive = btn;
            btnActive.BackColor = Color.FromArgb(220, 230, 245);

            lblScreen.Text = title;

            uc ??= Placeholder(title);

            SetContent(uc);
        }
        // ===== MỞ MÀN HÌNH DUYỆT TÀI KHOẢN =====
        public void MoDuyetTaiKhoan(int taiKhoanID)
        {
            if (Session.Role != "ADMIN")
            {
                MessageBox.Show("Bạn không có quyền duyệt tài khoản!");
                return;
            }

            BeginInvoke(new Action(() =>
            {
                lblScreen.Text = "Duyệt tài khoản";

                SetContent(new ucDuyetNhanVien(taiKhoanID));
            }));
        }

        // ===== QUAY LẠI DANH SÁCH TÀI KHOẢN =====
        public void MoDanhSachTaiKhoan()
        {
            BeginInvoke(new Action(() =>
            {
                Open(btnTaiKhoan, "Tài khoản", new ucTaiKhoan());
            }));
        }

        // ===== GIAO DIỆN TẠM THỜI (cho các màn chưa làm) =====
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

        // ===== QUẢN LÝ BÀN -> TẠO ĐƠN =====
        // ucQuanLyBan báo (banId, donId) khi bấm bàn Trống / "Thêm món" -> mở thẳng đơn đó ở màn Tạo đơn
        private void MoTaoDon(int banId, int donId)
        {
            // Hoãn lại sau khi sự kiện Click của ucQuanLyBan chạy xong, vì màn Quản lý bàn sắp bị giải phóng
            BeginInvoke(new Action(() =>
                Open(btnTaoDon, "Tạo đơn", new ucTaoDon(banId, donId))));
        }

        // ===== CÁC NÚT MENU =====
        private void btnTongQuan_Click(object sender, EventArgs e) { 
            Open(btnTongQuan, "Tổng quan"); }
        private void btnCheBien_Click(object sender, EventArgs e) { 
            Open(btnCheBien, "Chế biến", new ucCheBien()); }
        private void btnThucDon_Click(object sender, EventArgs e) { 
            Open(btnThucDon, "Thực đơn", new ucThucDon()); }
        private void btnNguyenLieu_Click(object sender, EventArgs e) {
            Open(btnNguyenLieu, "Nguyên liệu", new ucNguyenLieu()); }
        private void btnQuanLyBan_Click(object sender, EventArgs e) { 
            Open(btnQuanLyBan, "Quản lý bàn",new ucQuanLyBan()); }
        private void btnTaoDon_Click(object sender, EventArgs e) {
            Open(btnTaoDon, "Tạo đơn", new ucTaoDon()); }
        private void btnMonChoPhucVu_Click(object sender, EventArgs e) { 
            Open(btnMonChoPhucVu, "Món chờ phục vụ",new ucMonChoPhucVu()); }
        private void btnHoaDon_Click(object sender, EventArgs e) { 
            Open(btnHoaDon, "Hóa đơn", new ucHoaDon()); }
        private void btnThanhToan_Click(object sender, EventArgs e) { 
            Open(btnThanhToan, "Thanh toán", new ucThanhToan()); }
        private void btnTaiKhoan_Click(object sender, EventArgs e) { 
            Open(btnTaiKhoan, "Tài khoản", new ucTaiKhoan()); }
    }
}
