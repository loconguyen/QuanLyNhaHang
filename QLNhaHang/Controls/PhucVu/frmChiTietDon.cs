using Microsoft.Data.SqlClient;
using QLNhaHang.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLNhaHang.Controls.PhucVu
{
    public partial class frmChiTietDon : Form
    {
        static readonly string ConnStr = DataProcesser.strConnect;

        readonly int _donId;
        readonly string _soBan;
        readonly string _viTri;
        readonly int _sucChua;

        bool _donDaThanhToan;
        bool _daYeuCau;
        bool _dangXuLy;
        string _nhanVien = "";
        string _gioTao = "";

        // Hành động người dùng chọn để ucQuanLyBan xử lý tiếp: modon, yeucau, chuyen, donban
        public string HanhDong { get; private set; } = "";

        // Đọc giá trị của một dòng trong bảng trực tiếp từ DataTable nguồn
        // (không phụ thuộc tên cột đang hiển thị trên lưới)
        static string Chuoi(DataGridViewRow r, string cot)
        {
            if (r.DataBoundItem is DataRowView rv && rv[cot] != DBNull.Value)
                return rv[cot].ToString() ?? "";
            return "";
        }

        static int So(DataGridViewRow r, string cot)
        {
            return r.DataBoundItem is DataRowView rv && rv[cot] != DBNull.Value
                ? Convert.ToInt32(rv[cot])
                : -1;
        }

        // Constructor rỗng cho Designer
        public frmChiTietDon() : this(0, "", "", 0) { }

        public frmChiTietDon(int donId, string soBan, string viTri, int sucChua)
        {
            InitializeComponent();

            _donId = donId;
            _soBan = soBan;
            _viTri = viTri;
            _sucChua = sucChua;

            // Không truy vấn khi đang mở trong Designer
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            Text = $"Bàn {soBan} - Đơn #{donId}";
            TaiThongTin();
            TaiMon();
            CapNhatNut();
            tmrLamMoi.Start();   // tự nạp lại để thấy món Bếp vừa nấu xong
        }

        // ===== THÔNG TIN ĐƠN =====
        void TaiThongTin()
        {
            using var conn = new SqlConnection(ConnStr);
            using var cmd = new SqlCommand(@"
                SELECT dh.ThoiGianTao, nv.HoTen, dh.TrangThaiDon, dh.YeuCauThanhToan
                FROM DON_HANG dh
                JOIN NHAN_VIEN nv ON nv.NhanVienID = dh.NhanVienPhucVuID
                WHERE dh.DonHangID = @d", conn);
            cmd.Parameters.AddWithValue("@d", _donId);
            conn.Open();

            using var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                _nhanVien = rd["HoTen"].ToString() ?? "";
                _gioTao = Convert.ToDateTime(rd["ThoiGianTao"]).ToString("dd/MM/yyyy HH:mm");
                _donDaThanhToan = (rd["TrangThaiDon"].ToString() ?? "") == "Hoàn thành";
                _daYeuCau = Convert.ToBoolean(rd["YeuCauThanhToan"]);
            }

            lblInfo.Text = $"Bàn {_soBan}  ·  {_viTri}  ·  {_sucChua} chỗ\n" +
                           $"Đơn #{_donId}  ·  Phục vụ: {_nhanVien}  ·  Tạo lúc {_gioTao}" +
                           (_donDaThanhToan ? "\nĐơn đã thanh toán"
                            : _daYeuCau ? "\nĐã gửi yêu cầu thanh toán cho Thu ngân" : "");
        }

        // ===== BẢNG MÓN (giữ các dòng đang chọn khi nạp lại) =====
        void TaiMon()
        {
            var daChon = new HashSet<int>(dgvMon.SelectedRows.Cast<DataGridViewRow>()
                .Select(r => So(r, "DongID")));

            var dt = new DataTable();
            using (var conn = new SqlConnection(ConnStr))
            using (var da = new SqlDataAdapter(@"
                SELECT c.DongID, m.TenMon, c.SoLuong, c.DonGia,
                       c.SoLuong * c.DonGia AS ThanhTien,
                       c.TrangThaiMon, c.ThoiGianGuiBep, c.GhiChu
                FROM CHI_TIET_DON_HANG c
                JOIN MON_AN m ON m.MonID = c.MonID
                WHERE c.DonHangID = @d
                ORDER BY CASE c.TrangThaiMon
                            WHEN N'Hoàn thành' THEN 0
                            WHEN N'Đang chế biến' THEN 1
                            WHEN N'Chờ chế biến' THEN 2
                            WHEN N'Chưa gửi bếp' THEN 3
                            ELSE 4 END, c.DongID", conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@d", _donId);
                da.Fill(dt);
            }

            dgvMon.DataSource = dt;
            CauHinhCot();   // đặt lại tiêu đề tiếng Việt, định dạng (cột được sinh lại sau mỗi lần nạp)

            dgvMon.ClearSelection();
            foreach (DataGridViewRow r in dgvMon.Rows)
                if (daChon.Contains(So(r, "DongID")))
                    r.Selected = true;

            decimal tong = dt.AsEnumerable()
                .Where(r => r.Field<string>("TrangThaiMon") != "Đã hủy")
                .Sum(r => r.Field<decimal>("ThanhTien"));
            lblTong.Text = $"Tổng tiền tạm tính: {tong:N0} đ";
        }

        // Tiêu đề tiếng Việt + định dạng + độ rộng cho từng cột
        void CauHinhCot()
        {
            void Cot(string ten, string tieuDe, float trongSo,
                     string? dinhDang = null, DataGridViewContentAlignment? canh = null)
            {
                var c = dgvMon.Columns[ten];
                if (c == null) return;
                c.HeaderText = tieuDe;
                c.FillWeight = trongSo;
                c.MinimumWidth = 60;
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (dinhDang != null) c.DefaultCellStyle.Format = dinhDang;
                if (canh != null)
                {
                    c.DefaultCellStyle.Alignment = canh.Value;
                    c.HeaderCell.Style.Alignment = canh.Value;
                }
            }

            var phai = DataGridViewContentAlignment.MiddleRight;
            var giua = DataGridViewContentAlignment.MiddleCenter;

            if (dgvMon.Columns["DongID"] is DataGridViewColumn id) id.Visible = false;   // mã nội bộ
            Cot("TenMon", "Tên món", 26);
            Cot("SoLuong", "Số lượng", 9, null, giua);
            Cot("DonGia", "Đơn giá", 14, "N0", phai);
            Cot("ThanhTien", "Thành tiền", 15, "N0", phai);
            Cot("TrangThaiMon", "Trạng thái", 16);
            Cot("ThoiGianGuiBep", "Giờ gửi bếp", 15, "dd/MM HH:mm");
            Cot("GhiChu", "Ghi chú", 20);
        }

        // Nút nào hiện theo vai trò và trạng thái đơn
        void CapNhatNut()
        {
            bool laPhucVu = Session.Role == "PHUCVU" || Session.Role == "ADMIN";
            btnThemMon.Visible = laPhucVu && !_donDaThanhToan;
            btnChuyenBan.Visible = laPhucVu && !_donDaThanhToan;
            btnDaPhucVu.Visible = laPhucVu && !_donDaThanhToan;
            btnDonBan.Visible = laPhucVu;
        }

        // Tô màu dòng theo trạng thái món
        private void dgvMon_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvMon.Rows.Count) return;

            string tt = Chuoi(dgvMon.Rows[e.RowIndex], "TrangThaiMon");
            if (tt == "Hoàn thành") e.CellStyle.BackColor = Color.FromArgb(200, 230, 201);
            else if (tt == "Chưa gửi bếp") e.CellStyle.BackColor = Color.FromArgb(255, 249, 196);
            else if (tt == "Đã phục vụ") e.CellStyle.ForeColor = Color.Gray;
        }

        // ===== ĐÃ PHỤC VỤ: Hoàn thành -> Đã phục vụ (không đóng hộp thoại) =====
        private void btnDaPhucVu_Click(object? sender, EventArgs e)
        {
            var chon = dgvMon.SelectedRows.Cast<DataGridViewRow>()
                .Where(r => Chuoi(r, "TrangThaiMon") == "Hoàn thành")
                .Select(r => So(r, "DongID"))
                .ToList();

            if (chon.Count == 0)
            {
                MessageBox.Show("Chọn món có trạng thái Hoàn thành (dòng xanh lá) để xác nhận đã phục vụ.");
                return;
            }

            _dangXuLy = true;
            try
            {
                int ok = DanhDauDaPhucVu(chon);
                if (ok < chon.Count)
                    MessageBox.Show($"Chỉ cập nhật được {ok}/{chon.Count} món, các món còn lại đã đổi trạng thái.");
                TaiMon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _dangXuLy = false;
            }
        }

        int DanhDauDaPhucVu(List<int> dsDong)
        {
            using var conn = new SqlConnection(ConnStr);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                int ok = 0;
                foreach (int dongId in dsDong)
                {
                    using var cmd = new SqlCommand(@"
                        UPDATE c SET TrangThaiMon = N'Đã phục vụ'
                        FROM CHI_TIET_DON_HANG c
                        JOIN DON_HANG dh ON dh.DonHangID = c.DonHangID
                        WHERE c.DongID = @id AND c.DonHangID = @d
                          AND c.TrangThaiMon = N'Hoàn thành'
                          AND dh.TrangThaiDon = N'Đang xử lý'", conn, tran);
                    cmd.Parameters.AddWithValue("@id", dongId);
                    cmd.Parameters.AddWithValue("@d", _donId);
                    ok += cmd.ExecuteNonQuery();
                }
                tran.Commit();
                return ok;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        // ===== CÁC NÚT KHÁC: báo hành động rồi đóng, ucQuanLyBan xử lý tiếp =====
        private void btnThemMon_Click(object? sender, EventArgs e) { Chon("modon"); }
        private void btnChuyenBan_Click(object? sender, EventArgs e) { Chon("chuyen"); }
        private void btnDonBan_Click(object? sender, EventArgs e) { Chon("donban"); }

        void Chon(string hanhDong)
        {
            HanhDong = hanhDong;
            Close();
        }

        // ===== TỰ NẠP LẠI =====
        private void tmrLamMoi_Tick(object? sender, EventArgs e)
        {
            if (_dangXuLy) return;
            try { TaiMon(); } catch { }
        }
    }
}