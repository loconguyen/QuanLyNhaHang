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
    public partial class ucTaoDon : UserControl
    {
        static readonly string ConnStr = DataProcesser.strConnect;

        const string CHUA_GUI = "Chưa gửi bếp";

        int _donId;
        bool _dangNap;
        DataTable _dtMon = new DataTable();

        // Vào từ menu Tạo đơn: hiện danh sách đơn đang xử lý để chọn
        public ucTaoDon()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            HienDanhSach();
        }

        // Vào từ Quản lý bàn: mở thẳng đơn của bàn đó
        public ucTaoDon(int banId, int donId) : this()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            MoChiTiet(donId);
        }

        // =====================================================================
        //  MÀN 1: DANH SÁCH ĐƠN ĐANG XỬ LÝ
        // =====================================================================
        void HienDanhSach()
        {
            pnlChiTiet.Visible = false;
            pnlDanhSach.Visible = true;
            LoadDanhSach();
        }

        void LoadDanhSach()
        {
            try
            {
                bool tatCa = Session.Role == "ADMIN";   // Admin thấy hết, Phục vụ chỉ thấy đơn của mình
                var dt = new DataTable();

                using (var conn = new SqlConnection(ConnStr))
                using (var da = new SqlDataAdapter(@"
                    SELECT dh.DonHangID, b.SoBan, ISNULL(b.ViTri, N'') AS ViTri, dh.ThoiGianTao,
                           COUNT(CASE WHEN c.TrangThaiMon <> N'Đã hủy' THEN 1 END) AS SoMon,
                           ISNULL(SUM(CASE WHEN c.TrangThaiMon <> N'Đã hủy'
                                           THEN c.SoLuong * c.DonGia END), 0) AS TongTien
                    FROM DON_HANG dh
                    JOIN BAN_AN b ON b.BanID = dh.BanID
                    LEFT JOIN CHI_TIET_DON_HANG c ON c.DonHangID = dh.DonHangID
                    WHERE dh.TrangThaiDon = N'Đang xử lý'
                      AND (@all = 1 OR dh.NhanVienPhucVuID = @nv)
                    GROUP BY dh.DonHangID, b.SoBan, b.ViTri, dh.ThoiGianTao
                    ORDER BY dh.ThoiGianTao DESC", conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@all", tatCa ? 1 : 0);
                    da.SelectCommand.Parameters.AddWithValue("@nv", Session.NhanVienID);
                    da.Fill(dt);
                }

                dgvDon.DataSource = dt;
                dgvDon.Columns["DonHangID"]!.HeaderText = "Mã đơn";
                dgvDon.Columns["SoBan"]!.HeaderText = "Bàn";
                dgvDon.Columns["ViTri"]!.HeaderText = "Khu vực";
                dgvDon.Columns["ThoiGianTao"]!.HeaderText = "Tạo lúc";
                dgvDon.Columns["ThoiGianTao"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvDon.Columns["SoMon"]!.HeaderText = "Số món";
                dgvDon.Columns["TongTien"]!.HeaderText = "Tổng tiền (đ)";
                dgvDon.Columns["TongTien"]!.DefaultCellStyle.Format = "N0";

                lblHuongDan.Text = dt.Rows.Count == 0
                    ? "Chưa có đơn nào. Muốn tạo đơn mới: sang Quản lý bàn, bấm vào bàn Trống."
                    : $"{dt.Rows.Count} đơn đang xử lý. Nhấp đúp vào một đơn để thêm, sửa món. " +
                      "Muốn tạo đơn mới: sang Quản lý bàn, bấm vào bàn Trống.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách đơn:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoiDS_Click(object? sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void dgvDon_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvDon.Rows[e.RowIndex].DataBoundItem is DataRowView rv)
                MoChiTiet(Convert.ToInt32(rv["DonHangID"]));
        }

        // =====================================================================
        //  MÀN 2: CHI TIẾT ĐƠN (THÊM / SỬA / XÓA MÓN, GỬI BẾP)
        // =====================================================================
        void MoChiTiet(int donId)
        {
            _donId = donId;
            TaiThucDon();
            pnlDanhSach.Visible = false;
            pnlChiTiet.Visible = true;
            LoadChiTiet();
        }

        private void btnQuayLai_Click(object? sender, EventArgs e)
        {
            HienDanhSach();
        }

        // ----- Thực đơn (chỉ món đang bán) -----
        void TaiThucDon()
        {
            if (_dtMon.Rows.Count > 0) return;

            try
            {
                using var conn = new SqlConnection(ConnStr);
                using var da = new SqlDataAdapter(@"
                    SELECT m.MonID, m.TenMon, m.DonViTinh, m.DonGia, d.TenDanhMuc
                    FROM MON_AN m
                    JOIN DANH_MUC_MON d ON d.DanhMucID = m.DanhMucID
                    WHERE m.TrangThaiMon = N'Đang bán'
                    ORDER BY d.TenDanhMuc, m.TenMon", conn);
                var dt = new DataTable();
                da.Fill(dt);
                _dtMon = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được thực đơn:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dangNap = true;
            cboDanhMuc.Items.Clear();
            cboDanhMuc.Items.Add("Tất cả");
            foreach (string tenDm in _dtMon.AsEnumerable().Select(r => r.Field<string>("TenDanhMuc")!).Distinct())
                cboDanhMuc.Items.Add(tenDm);
            cboDanhMuc.SelectedIndex = 0;
            _dangNap = false;

            dgvMon.DataSource = _dtMon.DefaultView;
            dgvMon.Columns["MonID"]!.Visible = false;
            dgvMon.Columns["TenMon"]!.HeaderText = "Món";
            dgvMon.Columns["DonViTinh"]!.HeaderText = "ĐVT";
            dgvMon.Columns["DonViTinh"]!.FillWeight = 40;
            dgvMon.Columns["DonGia"]!.HeaderText = "Đơn giá";
            dgvMon.Columns["DonGia"]!.DefaultCellStyle.Format = "N0";
            dgvMon.Columns["TenDanhMuc"]!.HeaderText = "Danh mục";
        }

        static string EscEq(string s) => s.Replace("'", "''");
        static string EscLike(string s) =>
            s.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");

        void LocMon()
        {
            var dk = new List<string>();
            if (cboDanhMuc.SelectedIndex > 0)
                dk.Add($"TenDanhMuc = '{EscEq(cboDanhMuc.SelectedItem!.ToString()!)}'");
            string tim = txtTim.Text.Trim();
            if (tim != "")
                dk.Add($"TenMon LIKE '%{EscLike(tim)}%'");
            _dtMon.DefaultView.RowFilter = string.Join(" AND ", dk);
        }

        private void cboDanhMuc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!_dangNap) LocMon();
        }

        private void txtTim_TextChanged(object? sender, EventArgs e)
        {
            if (!_dangNap) LocMon();
        }

        // ----- Tải thông tin đơn và danh sách món trong đơn -----
        void LoadChiTiet()
        {
            try
            {
                string soBan = "", viTri = "", ttDon = "";
                DateTime gioTao = DateTime.Now;
                bool daYeuCau = false;
                var dt = new DataTable();

                using (var conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    using (var cmd = new SqlCommand(@"
                        SELECT b.SoBan, ISNULL(b.ViTri, N'') AS ViTri, dh.ThoiGianTao,
                               dh.TrangThaiDon, dh.YeuCauThanhToan
                        FROM DON_HANG dh
                        JOIN BAN_AN b ON b.BanID = dh.BanID
                        WHERE dh.DonHangID = @d", conn))
                    {
                        cmd.Parameters.AddWithValue("@d", _donId);
                        using var rd = cmd.ExecuteReader();
                        if (!rd.Read())
                        {
                            MessageBox.Show("Không tìm thấy đơn.");
                            HienDanhSach();
                            return;
                        }
                        soBan = rd["SoBan"].ToString() ?? "";
                        viTri = rd["ViTri"].ToString() ?? "";
                        gioTao = Convert.ToDateTime(rd["ThoiGianTao"]);
                        ttDon = rd["TrangThaiDon"].ToString() ?? "";
                        daYeuCau = Convert.ToBoolean(rd["YeuCauThanhToan"]);
                    }

                    using var da = new SqlDataAdapter(@"
                        SELECT c.MonID, m.TenMon, c.SoLuong, c.DonGia,
                               c.SoLuong * c.DonGia AS ThanhTien, c.TrangThaiMon, c.GhiChu
                        FROM CHI_TIET_DON_HANG c
                        JOIN MON_AN m ON m.MonID = c.MonID
                        WHERE c.DonHangID = @d
                        ORDER BY CASE WHEN c.TrangThaiMon = N'Chưa gửi bếp' THEN 1 ELSE 0 END, m.TenMon", conn);
                    da.SelectCommand.Parameters.AddWithValue("@d", _donId);
                    da.Fill(dt);
                }

                bool laPhucVu = Session.Role == "PHUCVU" || Session.Role == "ADMIN";
                bool choPhepSua = laPhucVu && ttDon == "Đang xử lý" && !daYeuCau;

                lblThongTinDon.Text = $"Bàn {soBan}  ·  {viTri}  ·  Đơn #{_donId}  ·  Tạo lúc {gioTao:dd/MM/yyyy HH:mm}";
                lblTrangThaiDon.Text =
                    !laPhucVu ? "Chỉ xem."
                    : ttDon != "Đang xử lý" ? $"Đơn {ttDon.ToLower()}, không thể sửa."
                    : daYeuCau ? "Đã yêu cầu thanh toán, không thể thêm hoặc sửa món."
                    : "";

                dgvCT.DataSource = dt;
                dgvCT.Columns["MonID"]!.Visible = false;
                dgvCT.Columns["TenMon"]!.HeaderText = "Món";
                dgvCT.Columns["SoLuong"]!.HeaderText = "SL";
                dgvCT.Columns["SoLuong"]!.FillWeight = 30;
                dgvCT.Columns["DonGia"]!.HeaderText = "Đơn giá";
                dgvCT.Columns["DonGia"]!.DefaultCellStyle.Format = "N0";
                dgvCT.Columns["ThanhTien"]!.HeaderText = "Thành tiền";
                dgvCT.Columns["ThanhTien"]!.DefaultCellStyle.Format = "N0";
                dgvCT.Columns["TrangThaiMon"]!.HeaderText = "Trạng thái";
                dgvCT.Columns["GhiChu"]!.HeaderText = "Ghi chú";

                // Tô vàng món chưa gửi bếp
                foreach (DataGridViewRow r in dgvCT.Rows)
                {
                    if (r.Cells["TrangThaiMon"].Value?.ToString() == CHUA_GUI)
                        r.DefaultCellStyle.BackColor = Color.FromArgb(255, 249, 196);
                }

                decimal tong = dt.AsEnumerable()
                    .Where(r => r.Field<string>("TrangThaiMon") != "Đã hủy")
                    .Sum(r => r.Field<decimal>("ThanhTien"));
                int chuaGui = dt.AsEnumerable().Count(r => r.Field<string>("TrangThaiMon") == CHUA_GUI);

                lblTong.Text = $"Tổng tiền tạm tính: {tong:N0} đ";

                nudSoLuong.Enabled = txtGhiChu.Enabled = btnThem.Enabled = choPhepSua;
                btnSua.Enabled = btnXoa.Enabled = choPhepSua;
                btnGuiBep.Enabled = choPhepSua && chuaGui > 0;
                btnHuyDon.Visible = choPhepSua && dt.Rows.Count == 0;   // chỉ hủy được đơn chưa có món
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được đơn:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đơn còn cho phép sửa không (đang xử lý, chưa yêu cầu thanh toán). Khóa dòng trong transaction.
        bool DonConSua(SqlConnection conn, SqlTransaction tran)
        {
            using var cmd = new SqlCommand(@"
                SELECT COUNT(*) FROM DON_HANG WITH (UPDLOCK)
                WHERE DonHangID = @d AND TrangThaiDon = N'Đang xử lý' AND YeuCauThanhToan = 0", conn, tran);
            cmd.Parameters.AddWithValue("@d", _donId);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        (int MonId, string TenMon, string TrangThai, int SoLuong, string GhiChu)? DongDangChon()
        {
            if (dgvCT.CurrentRow?.DataBoundItem is not DataRowView rv) return null;
            return (Convert.ToInt32(rv["MonID"]),
                    rv["TenMon"].ToString() ?? "",
                    rv["TrangThaiMon"].ToString() ?? "",
                    Convert.ToInt32(rv["SoLuong"]),
                    rv["GhiChu"] == DBNull.Value ? "" : rv["GhiChu"].ToString() ?? "");
        }

        // ----- THÊM MÓN -----
        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (dgvMon.CurrentRow?.DataBoundItem is not DataRowView rv)
            {
                MessageBox.Show("Chọn một món trong thực đơn.");
                return;
            }
            ThemMon(Convert.ToInt32(rv["MonID"]), rv["TenMon"].ToString() ?? "",
                    (int)nudSoLuong.Value, txtGhiChu.Text.Trim());
        }

        private void dgvMon_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && btnThem.Enabled) btnThem_Click(sender, EventArgs.Empty);
        }

        void ThemMon(int monId, string tenMon, int soLuong, string ghiChu)
        {
            try
            {
                using var conn = new SqlConnection(ConnStr);
                conn.Open();
                using var tran = conn.BeginTransaction();

                try
                {
                    // 1. Đơn còn sửa được không
                    if (!DonConSua(conn, tran))
                    {
                        tran.Rollback();
                        MessageBox.Show("Đơn không còn cho phép thêm món.");
                        LoadChiTiet();
                        return;
                    }

                    // 2. Đơn giá hiện tại từ MON_AN, món phải còn bán (Phục vụ không tự nhập giá)
                    decimal donGia;
                    using (var c1 = new SqlCommand(
                        "SELECT DonGia FROM MON_AN WHERE MonID = @m AND TrangThaiMon = N'Đang bán'", conn, tran))
                    {
                        c1.Parameters.AddWithValue("@m", monId);
                        object? kq = c1.ExecuteScalar();
                        if (kq == null)
                        {
                            tran.Rollback();
                            MessageBox.Show($"Món {tenMon} hiện không bán.");
                            return;
                        }
                        donGia = Convert.ToDecimal(kq);
                    }

                    // 3. Món đã có trong đơn chưa
                    string? ttCu = null;
                    using (var c2 = new SqlCommand(
                        "SELECT TrangThaiMon FROM CHI_TIET_DON_HANG WHERE DonHangID = @d AND MonID = @m", conn, tran))
                    {
                        c2.Parameters.AddWithValue("@d", _donId);
                        c2.Parameters.AddWithValue("@m", monId);
                        ttCu = c2.ExecuteScalar()?.ToString();
                    }

                    object gc = ghiChu == "" ? DBNull.Value : ghiChu;

                    if (ttCu == null)
                    {
                        using var ins = new SqlCommand(@"
                            INSERT INTO CHI_TIET_DON_HANG (DonHangID, MonID, SoLuong, DonGia, TrangThaiMon, GhiChu)
                            VALUES (@d, @m, @sl, @dg, N'Chưa gửi bếp', @gc)", conn, tran);
                        ins.Parameters.AddWithValue("@d", _donId);
                        ins.Parameters.AddWithValue("@m", monId);
                        ins.Parameters.AddWithValue("@sl", soLuong);
                        ins.Parameters.AddWithValue("@dg", donGia);
                        ins.Parameters.AddWithValue("@gc", gc);
                        ins.ExecuteNonQuery();
                    }
                    else if (ttCu == CHUA_GUI)
                    {
                        using var upd = new SqlCommand(@"
                            UPDATE CHI_TIET_DON_HANG
                            SET SoLuong = SoLuong + @sl,
                                GhiChu = CASE WHEN @gc IS NULL THEN GhiChu ELSE @gc END
                            WHERE DonHangID = @d AND MonID = @m", conn, tran);
                        upd.Parameters.AddWithValue("@sl", soLuong);
                        upd.Parameters.AddWithValue("@gc", gc);
                        upd.Parameters.AddWithValue("@d", _donId);
                        upd.Parameters.AddWithValue("@m", monId);
                        upd.ExecuteNonQuery();
                    }
                    else
                    {
                        tran.Rollback();
                        MessageBox.Show($"Món {tenMon} đã gửi bếp, không thể cộng thêm số lượng vào dòng đó.\n" +
                                        "Muốn thay đổi phải theo nghiệp vụ điều chỉnh, hủy món.");
                        return;
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nudSoLuong.Value = 1;
            txtGhiChu.Clear();
            LoadChiTiet();
        }

        // ----- SỬA MÓN (số lượng, ghi chú) - chỉ món chưa gửi bếp -----
        private void btnSua_Click(object? sender, EventArgs e)
        {
            var dong = DongDangChon();
            if (dong == null)
            {
                MessageBox.Show("Chọn một món trong đơn.");
                return;
            }
            if (dong.Value.TrangThai != CHUA_GUI)
            {
                MessageBox.Show("Món này đã gửi bếp, không sửa trực tiếp.\n" +
                                "Muốn thay đổi hoặc hủy phải theo nghiệp vụ điều chỉnh, hủy món.");
                return;
            }

            using var f = new Form
            {
                Text = $"Sửa món: {dong.Value.TenMon}",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(340, 170)
            };
            var lblSl = new Label { Text = "Số lượng", AutoSize = true, Location = new Point(15, 15) };
            var nud = new NumericUpDown
            {
                Location = new Point(15, 38),
                Width = 80,
                Minimum = 1,
                Maximum = 99,
                Value = Math.Clamp(dong.Value.SoLuong, 1, 99)
            };
            var lblGc = new Label { Text = "Ghi chú", AutoSize = true, Location = new Point(120, 15) };
            var txt = new TextBox { Location = new Point(120, 38), Width = 200, MaxLength = 255, Text = dong.Value.GhiChu };
            var ok = new Button { Text = "Lưu", DialogResult = DialogResult.OK, Location = new Point(155, 120), Size = new Size(80, 30) };
            var huy = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new Point(245, 120), Size = new Size(80, 30) };
            f.Controls.AddRange(new Control[] { lblSl, nud, lblGc, txt, ok, huy });
            f.AcceptButton = ok;
            f.CancelButton = huy;

            if (f.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var conn = new SqlConnection(ConnStr);
                using var cmd = new SqlCommand(@"
                    UPDATE c SET SoLuong = @sl, GhiChu = @gc
                    FROM CHI_TIET_DON_HANG c
                    JOIN DON_HANG dh ON dh.DonHangID = c.DonHangID
                    WHERE c.DonHangID = @d AND c.MonID = @m
                      AND c.TrangThaiMon = N'Chưa gửi bếp'
                      AND dh.TrangThaiDon = N'Đang xử lý' AND dh.YeuCauThanhToan = 0", conn);
                cmd.Parameters.AddWithValue("@sl", (int)nud.Value);
                cmd.Parameters.AddWithValue("@gc", txt.Text.Trim() == "" ? DBNull.Value : (object)txt.Text.Trim());
                cmd.Parameters.AddWithValue("@d", _donId);
                cmd.Parameters.AddWithValue("@m", dong.Value.MonId);
                conn.Open();

                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("Không sửa được: món đã được gửi bếp hoặc đơn không còn sửa được.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadChiTiet();
        }

        // ----- XÓA MÓN - chỉ món chưa gửi bếp -----
        private void btnXoa_Click(object? sender, EventArgs e)
        {
            var dong = DongDangChon();
            if (dong == null)
            {
                MessageBox.Show("Chọn một món trong đơn.");
                return;
            }
            if (dong.Value.TrangThai != CHUA_GUI)
            {
                MessageBox.Show("Món này đã gửi bếp, không xóa trực tiếp.\n" +
                                "Muốn hủy món phải theo nghiệp vụ điều chỉnh, hủy món.");
                return;
            }

            var hoi = MessageBox.Show($"Xóa món {dong.Value.TenMon} khỏi đơn?", "Xóa món",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            try
            {
                using var conn = new SqlConnection(ConnStr);
                using var cmd = new SqlCommand(@"
                    DELETE c
                    FROM CHI_TIET_DON_HANG c
                    JOIN DON_HANG dh ON dh.DonHangID = c.DonHangID
                    WHERE c.DonHangID = @d AND c.MonID = @m
                      AND c.TrangThaiMon = N'Chưa gửi bếp'
                      AND dh.TrangThaiDon = N'Đang xử lý' AND dh.YeuCauThanhToan = 0", conn);
                cmd.Parameters.AddWithValue("@d", _donId);
                cmd.Parameters.AddWithValue("@m", dong.Value.MonId);
                conn.Open();

                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("Không xóa được: món đã được gửi bếp hoặc đơn không còn sửa được.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadChiTiet();
        }

        // ----- GỬI BẾP -----
        private void btnGuiBep_Click(object? sender, EventArgs e)
        {
            try
            {
                using var conn = new SqlConnection(ConnStr);
                conn.Open();
                using var tran = conn.BeginTransaction();

                try
                {
                    if (!DonConSua(conn, tran))
                    {
                        tran.Rollback();
                        MessageBox.Show("Đơn không còn cho phép gửi bếp.");
                        LoadChiTiet();
                        return;
                    }

                    // 1. Phải có ít nhất một món chưa gửi
                    int soMon;
                    using (var c1 = new SqlCommand(@"
                        SELECT COUNT(*) FROM CHI_TIET_DON_HANG
                        WHERE DonHangID = @d AND TrangThaiMon = N'Chưa gửi bếp'", conn, tran))
                    {
                        c1.Parameters.AddWithValue("@d", _donId);
                        soMon = Convert.ToInt32(c1.ExecuteScalar());
                    }
                    if (soMon == 0)
                    {
                        tran.Rollback();
                        MessageBox.Show("Chưa có món nào để gửi bếp.");
                        return;
                    }

                    // 2. Kiểm tra trạng thái kinh doanh của các món sắp gửi
                    var khongBan = new List<string>();
                    using (var c2 = new SqlCommand(@"
                        SELECT m.TenMon
                        FROM CHI_TIET_DON_HANG c
                        JOIN MON_AN m ON m.MonID = c.MonID
                        WHERE c.DonHangID = @d AND c.TrangThaiMon = N'Chưa gửi bếp'
                          AND m.TrangThaiMon <> N'Đang bán'", conn, tran))
                    {
                        c2.Parameters.AddWithValue("@d", _donId);
                        using var rd = c2.ExecuteReader();
                        while (rd.Read()) khongBan.Add(rd["TenMon"].ToString() ?? "");
                    }
                    if (khongBan.Count > 0)
                    {
                        tran.Rollback();
                        MessageBox.Show("Các món sau hiện không bán, hãy xóa khỏi đơn rồi gửi lại:\n- " +
                                        string.Join("\n- ", khongBan));
                        return;
                    }

                    // 3. Gửi: Chưa gửi bếp -> Chờ chế biến (đơn vẫn Đang xử lý)
                    using (var c3 = new SqlCommand(@"
                        UPDATE CHI_TIET_DON_HANG SET TrangThaiMon = N'Chờ chế biến'
                        WHERE DonHangID = @d AND TrangThaiMon = N'Chưa gửi bếp'", conn, tran))
                    {
                        c3.Parameters.AddWithValue("@d", _donId);
                        c3.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show($"Đã gửi {soMon} món xuống Bếp.");
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadChiTiet();
        }

        // ----- HỦY ĐƠN RỖNG: đơn chưa có món nào, trả bàn về Trống -----
        private void btnHuyDon_Click(object? sender, EventArgs e)
        {
            var hoi = MessageBox.Show("Hủy đơn này? Bàn sẽ trở về trạng thái Trống.", "Hủy đơn",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            try
            {
                using var conn = new SqlConnection(ConnStr);
                conn.Open();
                using var tran = conn.BeginTransaction();

                try
                {
                    using (var c1 = new SqlCommand(
                        "SELECT COUNT(*) FROM CHI_TIET_DON_HANG WHERE DonHangID = @d", conn, tran))
                    {
                        c1.Parameters.AddWithValue("@d", _donId);
                        if (Convert.ToInt32(c1.ExecuteScalar()) > 0)
                        {
                            tran.Rollback();
                            MessageBox.Show("Đơn đã có món, không thể hủy.");
                            LoadChiTiet();
                            return;
                        }
                    }

                    using (var c2 = new SqlCommand(@"
                        UPDATE DON_HANG SET TrangThaiDon = N'Đã hủy'
                        WHERE DonHangID = @d AND TrangThaiDon = N'Đang xử lý'", conn, tran))
                    {
                        c2.Parameters.AddWithValue("@d", _donId);
                        c2.ExecuteNonQuery();
                    }

                    using (var c3 = new SqlCommand(@"
                        UPDATE BAN_AN SET TrangThai = N'Trống'
                        WHERE BanID = (SELECT BanID FROM DON_HANG WHERE DonHangID = @d)
                          AND TrangThai = N'Đang phục vụ'", conn, tran))
                    {
                        c3.Parameters.AddWithValue("@d", _donId);
                        c3.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đã hủy đơn.");
            HienDanhSach();
        }
    }
}