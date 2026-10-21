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
    // Giai đoạn 4: Bếp làm xong (Hoàn thành) -> Phục vụ mang ra bàn -> bấm "Đã phục vụ"
    public partial class ucMonChoPhucVu : UserControl
    {
        static readonly string ConnStr = DataProcesser.strConnect;

        const string HOAN_THANH = "Hoàn thành";
        const string DA_PHUC_VU = "Đã phục vụ";

        bool _dangXuLy;                                 // đang hiện hộp thoại / đang cập nhật thì timer không làm mới
        bool _daCoDuLieu;                               // đã tải ít nhất một lần
        HashSet<(int, int)> _keyCu = new HashSet<(int, int)>();   // (DonHangID, MonID) của lần tải trước

        static bool CoQuyen => Session.Role == "PHUCVU" || Session.Role == "ADMIN";
        static bool XemTatCa => Session.Role == "ADMIN";   // Admin thấy hết, Phục vụ chỉ thấy đơn của mình

        public ucMonChoPhucVu()
        {
            InitializeComponent();

            // Không chạy truy vấn khi đang mở trong Designer
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            btnDaPhucVu.Enabled = CoQuyen;
            LoadMon(false);
            tmrLamMoi.Start();
        }

        // ===== TẢI DANH SÁCH MÓN ĐÃ HOÀN THÀNH, CHỜ MANG RA BÀN =====
        void LoadMon(bool tuDong)
        {
            // Nhớ dòng đang chọn và vị trí cuộn để làm mới xong không bị mất
            var daChon = new HashSet<(int, int)>();
            foreach (DataGridViewRow r in dgvMon.SelectedRows)
                if (r.DataBoundItem is DataRowView v)
                    daChon.Add((Convert.ToInt32(v["DonHangID"]), Convert.ToInt32(v["MonID"])));
            int dongDau = dgvMon.Rows.Count > 0 ? dgvMon.FirstDisplayedScrollingRowIndex : -1;

            var dt = new DataTable();
            try
            {
                using var conn = new SqlConnection(ConnStr);
                using var da = new SqlDataAdapter(@"
                    SELECT c.DonHangID, c.MonID, b.SoBan, ISNULL(b.ViTri, N'') AS ViTri,
                           m.TenMon, c.SoLuong, c.GhiChu, dh.ThoiGianTao,
                           CONCAT(
                               (SELECT COUNT(*) FROM CHI_TIET_DON_HANG x
                                WHERE x.DonHangID = c.DonHangID AND x.TrangThaiMon = N'Đã phục vụ'),
                               N'/',
                               (SELECT COUNT(*) FROM CHI_TIET_DON_HANG x
                                WHERE x.DonHangID = c.DonHangID AND x.TrangThaiMon <> N'Đã hủy')
                           ) AS TienDo
                    FROM CHI_TIET_DON_HANG c
                    JOIN DON_HANG dh ON dh.DonHangID = c.DonHangID
                    JOIN BAN_AN b    ON b.BanID = dh.BanID
                    JOIN MON_AN m    ON m.MonID = c.MonID
                    WHERE c.TrangThaiMon = N'Hoàn thành'
                      AND dh.TrangThaiDon = N'Đang xử lý'
                      AND (@all = 1 OR dh.NhanVienPhucVuID = @nv)
                    ORDER BY dh.ThoiGianTao, b.SoBan, m.TenMon", conn);
                da.SelectCommand.Parameters.AddWithValue("@all", XemTatCa ? 1 : 0);
                da.SelectCommand.Parameters.AddWithValue("@nv", Session.NhanVienID);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                if (!tuDong)   // timer chạy nền thì không spam hộp thoại lỗi
                    MessageBox.Show("Không tải được danh sách món:\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var keyMoi = dt.AsEnumerable()
                .Select(r => (Convert.ToInt32(r["DonHangID"]), Convert.ToInt32(r["MonID"])))
                .ToHashSet();
            bool coMonMoi = _daCoDuLieu && keyMoi.Any(k => !_keyCu.Contains(k));
            _keyCu = keyMoi;
            _daCoDuLieu = true;

            dgvMon.DataSource = dt;
            dgvMon.Columns["MonID"]!.Visible = false;
            dgvMon.Columns["DonHangID"]!.HeaderText = "Mã đơn";
            dgvMon.Columns["DonHangID"]!.FillWeight = 40;
            dgvMon.Columns["SoBan"]!.HeaderText = "Bàn";
            dgvMon.Columns["SoBan"]!.FillWeight = 40;
            dgvMon.Columns["ViTri"]!.HeaderText = "Khu vực";
            dgvMon.Columns["TenMon"]!.HeaderText = "Món";
            dgvMon.Columns["TenMon"]!.FillWeight = 120;
            dgvMon.Columns["SoLuong"]!.HeaderText = "SL";
            dgvMon.Columns["SoLuong"]!.FillWeight = 25;
            dgvMon.Columns["GhiChu"]!.HeaderText = "Ghi chú";
            dgvMon.Columns["ThoiGianTao"]!.HeaderText = "Đơn tạo lúc";
            dgvMon.Columns["ThoiGianTao"]!.DefaultCellStyle.Format = "dd/MM HH:mm";
            dgvMon.Columns["TienDo"]!.HeaderText = "Đã phục vụ / tổng món";
            dgvMon.Columns["TienDo"]!.FillWeight = 60;

            // Khôi phục dòng đã chọn; không tự chọn dòng đầu để tránh bấm nhầm
            dgvMon.ClearSelection();
            foreach (DataGridViewRow r in dgvMon.Rows)
            {
                if (r.DataBoundItem is DataRowView v &&
                    daChon.Contains((Convert.ToInt32(v["DonHangID"]), Convert.ToInt32(v["MonID"]))))
                    r.Selected = true;
            }
            if (dongDau >= 0 && dongDau < dgvMon.Rows.Count)
            {
                try { dgvMon.FirstDisplayedScrollingRowIndex = dongDau; } catch { }
            }

            lblThongKe.Text = dt.Rows.Count == 0
                ? "Không có món nào đang chờ mang ra."
                : $"{dt.Rows.Count} món đã xong, đang chờ mang ra bàn.";

            if (coMonMoi)
            {
                lblThongKe.Text += "   ● Có món mới từ Bếp!";
                System.Media.SystemSounds.Asterisk.Play();
            }
        }

        // ===== ĐÃ PHỤC VỤ: Hoàn thành -> Đã phục vụ =====
        private void btnDaPhucVu_Click(object? sender, EventArgs e)
        {
            if (!CoQuyen)
            {
                MessageBox.Show("Bạn không có quyền xác nhận phục vụ món.");
                return;
            }

            var dong = new List<(int DonId, int MonId, string TenMon, string SoBan)>();
            foreach (DataGridViewRow r in dgvMon.SelectedRows)
            {
                if (r.DataBoundItem is DataRowView v)
                    dong.Add((Convert.ToInt32(v["DonHangID"]), Convert.ToInt32(v["MonID"]),
                              v["TenMon"].ToString() ?? "", v["SoBan"].ToString() ?? ""));
            }
            if (dong.Count == 0)
            {
                MessageBox.Show("Chọn ít nhất một món trong danh sách.");
                return;
            }

            _dangXuLy = true;
            try
            {
                string hoi = dong.Count == 1
                    ? $"Xác nhận đã mang món {dong[0].TenMon} ra bàn {dong[0].SoBan}?"
                    : $"Xác nhận đã mang {dong.Count} món ra bàn?";
                if (MessageBox.Show(hoi, "Đã phục vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    != DialogResult.Yes) return;

                int thanhCong = CapNhatDaPhucVu(dong);

                if (thanhCong < dong.Count)
                    MessageBox.Show($"{dong.Count - thanhCong} món không cập nhật được " +
                                    "(món không còn ở trạng thái Hoàn thành, hoặc đơn không còn thuộc quyền của bạn).\n" +
                                    "Danh sách sẽ được làm mới.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _dangXuLy = false;
            }

            LoadMon(false);
        }

        // Cập nhật trong 1 transaction; trả về số dòng thực sự được đổi trạng thái
        int CapNhatDaPhucVu(List<(int DonId, int MonId, string TenMon, string SoBan)> dong)
        {
            using var conn = new SqlConnection(ConnStr);
            conn.Open();
            using var tran = conn.BeginTransaction();

            try
            {
                int ok = 0;
                foreach (var d in dong)
                {
                    // Kiểm tra lại trạng thái ngay trong câu lệnh (tránh ghi đè khi dữ liệu đã đổi)
                    using var cmd = new SqlCommand(@"
                        UPDATE c SET TrangThaiMon = N'Đã phục vụ'
                        FROM CHI_TIET_DON_HANG c
                        JOIN DON_HANG dh ON dh.DonHangID = c.DonHangID
                        WHERE c.DonHangID = @d AND c.MonID = @m
                          AND c.TrangThaiMon = N'Hoàn thành'
                          AND dh.TrangThaiDon = N'Đang xử lý'
                          AND (@all = 1 OR dh.NhanVienPhucVuID = @nv)", conn, tran);
                    cmd.Parameters.AddWithValue("@d", d.DonId);
                    cmd.Parameters.AddWithValue("@m", d.MonId);
                    cmd.Parameters.AddWithValue("@all", XemTatCa ? 1 : 0);
                    cmd.Parameters.AddWithValue("@nv", Session.NhanVienID);
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

        // Nhấp đúp một dòng = phục vụ nhanh món đó (vẫn có hỏi xác nhận)
        private void dgvMon_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !CoQuyen) return;
            dgvMon.ClearSelection();
            dgvMon.Rows[e.RowIndex].Selected = true;
            btnDaPhucVu_Click(sender, EventArgs.Empty);
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            LoadMon(false);
        }

        // Tự làm mới để thấy món Bếp vừa xong
        private void tmrLamMoi_Tick(object? sender, EventArgs e)
        {
            if (_dangXuLy || !Visible || Parent == null) return;
            LoadMon(true);
        }
    }
}