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

        // true khi bấm Đăng xuất (Program.cs đọc để mở lại form đăng nhập)
        public bool DangXuat { get; private set; }

        public MainForm()
        {
            InitializeComponent();
        }

        // ===== KHỞI ĐỘNG: Session đã được form đăng nhập gán sẵn =====
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session.Role))
            {
                Close();   // chưa đăng nhập thì không vào
                return;
            }

            lblUser.Text = Session.HoTen + " - " + Session.Role;
            ApplyRole();

            // Mở màn hình đầu tiên mà role được phép
            Button[] thuTu = { btnTongQuan, btnQuanLyBan, btnHoaDon, btnTaiKhoan };
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
            Close();
        }

        // ===== PHÂN QUYỀN MENU =====
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
                (r == "PHUCVU" || admin);

            btnHoaDon.Visible = (r == "THUNGAN" || admin);

            btnTaiKhoan.Visible = admin;
        }

        // ===== HIỂN THỊ NỘI DUNG =====
        private void SetContent(UserControl uc)
        {
            // Chép màn cũ ra mảng trước, rồi mới gỡ và giải phóng (dừng Timer của nó)
            var cu = pnlContent.Controls.Cast<Control>().ToArray();
            pnlContent.Controls.Clear();
            foreach (var c in cu) c.Dispose();

            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
        }

        // ===== MỞ MÀN HÌNH =====
        private void Open(Button btn, string title, UserControl? uc = null)
        {
            if (btnActive != null)
                btnActive.BackColor = Color.White;

            btnActive = btn;
            btnActive.BackColor = Color.FromArgb(220, 230, 245);

            lblScreen.Text = title;
            SetContent(uc ?? Placeholder(title));
        }
        // ===== MỞ MÀN HÌNH DUYỆT TÀI KHOẢN =====
        public void MoDuyetTaiKhoan(int taiKhoanID)
        {
            if (Session.Role != "ADMIN")
            {
                MessageBox.Show("Bạn không có quyền duyệt tài khoản!");
                return;
            }

        // ===== GIAO DIỆN TẠM CHO MÀN CHƯA LÀM =====
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
            var uc = new UserControl();
            uc.Controls.Add(new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 30)
            });
            return uc;
        }

        // ===== CÁC NÚT MENU =====
        // Màn nào đã làm xong thì thêm new ucXxx() vào Open(...)
        private void btnTongQuan_Click(object sender, EventArgs e) { Open(btnTongQuan, "Tổng quan", new ucTongQuan()); }
        private void btnCheBien_Click(object sender, EventArgs e) { Open(btnCheBien, "Chế biến", new ucCheBien()); }
        private void btnThucDon_Click(object sender, EventArgs e) { Open(btnThucDon, "Thực đơn", new ucThucDon()); }
        private void btnNguyenLieu_Click(object sender, EventArgs e) { Open(btnNguyenLieu, "Nguyên liệu", new ucNguyenLieu()); }

        // --- Phục vụ ---
        private void btnQuanLyBan_Click(object sender, EventArgs e)
        private void btnTongQuan_Click(object sender, EventArgs e) { 
            Open(btnTongQuan, "Tổng quan"); }
        private void btnCheBien_Click(object sender, EventArgs e) { 
            Open(btnCheBien, "Chế biến", new ucCheBien()); }
        private void btnThucDon_Click(object sender, EventArgs e) { 
            Open(btnThucDon, "Thực đơn", new ucThucDon()); }
        private void btnNguyenLieu_Click(object sender, EventArgs e) {
            Open(btnNguyenLieu, "Nguyên liệu", new ucNguyenLieu()); }
        
        private void btnQuanLyBan_Click(object? sender, EventArgs e)
        {
            var uc = new ucQuanLyBan();

            // Bấm bàn Trống (tạo đơn mới) hoặc nút Thêm món: sang thẳng màn Tạo đơn của đơn đó
            uc.MoDon += (banId, donId) =>
                BeginInvoke(new Action(() =>
                    Open(btnTaoDon, "Tạo đơn", new ucTaoDon(banId, donId))));

            Open(btnQuanLyBan, "Quản lý bàn", uc);
        }

        private void btnTaoDon_Click(object sender, EventArgs e)
        {
            Open(btnTaoDon, "Tạo đơn", new ucTaoDon());   // danh sách đơn đang xử lý
        }

        // --- Thu ngân ---
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            Open(btnHoaDon, "Hóa đơn", new ucHoaDon());
        }

        // --- Admin ---
        private void btnTaiKhoan_Click(object sender, EventArgs e) { Open(btnTaiKhoan, "Tài khoản"); }
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
