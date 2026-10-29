using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using QLNhaHang.Classes;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.Text;

namespace QLNhaHang.Controls.ThuNgan
{
    // Màn hình "Quản lý hóa đơn" của Thu ngân (danh sách + chi tiết + thanh toán).
    // Giao diện nằm trong ucHoaDon.Designer.cs (kéo thả được); file này chỉ chứa xử lý.
    public partial class ucHoaDon : UserControl
    {
        static readonly string ConnStr = DataProcesser.strConnect;
        static readonly CultureInfo Vi = new("vi-VN");

        // ===== Bảng màu =====
        static readonly Color cBorder = Color.FromArgb(226, 232, 240);
        static readonly Color cText = Color.FromArgb(15, 23, 42);
        static readonly Color cMuted = Color.FromArgb(100, 116, 139);
        static readonly Color cBlue = Color.FromArgb(37, 99, 235);
        static readonly Color cGreen = Color.FromArgb(22, 163, 74);
        static readonly Color cGreenSoft = Color.FromArgb(220, 247, 230);
        static readonly Color cAmber = Color.FromArgb(217, 119, 6);
        static readonly Color cAmberSoft = Color.FromArgb(255, 240, 214);
        static readonly Color cHeader = Color.FromArgb(243, 246, 250);

        // ===== Trạng thái lưu trong DB =====
        const string TT_CHO = "Chưa thanh toán";
        const string TT_DA = "Đã thanh toán";
        static readonly string[] TabTT = { TT_CHO, TT_DA };

        // Ngày dùng để lọc: hóa đơn đã thanh toán -> ngày thanh toán, còn lại -> ngày lập
        const string SqlNgayHD =
            "cast(case when hd.TrangThaiThanhToan = N'Đã thanh toán' " +
            "then isnull(hd.NgayThanhToan, hd.NgayLap) else hd.NgayLap end as date)";

        const string PT_TIENMAT = "Tiền mặt";
        const string PT_CK = "Chuyển khoản";
        const string PT_THE = "Thẻ";
        static readonly string[] PtNames = { PT_TIENMAT, PT_CK, PT_THE };

        // Giao diện được thiết kế ở ~125% DPI (120 dpi). Đổi font sang đơn vị pixel theo mốc này
        // để chữ luôn khớp với kích thước control (tính bằng pixel) trên mọi máy / mọi mức DPI.
        const float DesignDpi = 120f;

        sealed class HoaDonRow
        {
            public int Id, DonHangId, BanId;
            public string SoBan = "", TrangThai = "";
            public DateTime Gio;            // giờ vào (giờ tạo đơn)
            public DateTime? NgayTT;        // giờ thanh toán
            public decimal Tong, Giam, Thanh;
            public string? Pttt;
        }

        Button[] tabBtns = Array.Empty<Button>();
        Button[] ptBtns = Array.Empty<Button>();

        int _tab = 0;                       // 0..1 = tab, -1 = tất cả
        bool _ready, _loading, _sync, _formatting;
        HoaDonRow? _cur;
        DataTable _items = new();
        string _pttt = PT_TIENMAT;

        public ucHoaDon()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            ChuanHoaFont(this);

            tabBtns = new[] { btnTabCho, btnTabDa };
            ptBtns = new[] { btnTienMat, btnChuyenKhoan, btnThe };

            StyleGrid(dgvHD);
            StyleGrid(dgvMon);
            dgvHD.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;   // cho tiêu đề xuống dòng
            dgvHD.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            dgvHD.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);

            colMa.FillWeight = 18; colMa.MinimumWidth = 100;
            colBan.FillWeight = 11; colBan.MinimumWidth = 70;
            colGio.FillWeight = 20; colGio.MinimumWidth = 115;
            colTong.FillWeight = 21; colTong.MinimumWidth = 115;
            colTT.FillWeight = 30; colTT.MinimumWidth = 165;

            // Căn cột tiền sang phải (cả tiêu đề lẫn ô) để thẳng hàng với nhau
            colTong.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mSL.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            mSL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            mGia.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            mGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mTien.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            mTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            lblGiamGia.ForeColor = cBlue;
            new ToolTip().SetToolTip(lblGiamGia, "Bấm để nhập số tiền giảm giá");

            cboTrangThai.SelectedIndex = 1;         // Chờ thanh toán
            CapNhatTab();
            ChonPhuongThuc(PT_TIENMAT);
        }

        // Chặn form cha phóng to control và các control con
        protected override bool ScaleChildren => false;
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified) { }

        // ---------- Font theo pixel ----------
        static Font F(float pt, FontStyle st = FontStyle.Regular, string family = "Segoe UI")
            => new Font(family, pt * DesignDpi / 72f, st, GraphicsUnit.Pixel);

        static void ChuanHoaFont(Control c)
        {
            if (c.Font.Unit == GraphicsUnit.Point)
                c.Font = new Font(c.Font.FontFamily, c.Font.Size * DesignDpi / 72f, c.Font.Style, GraphicsUnit.Pixel);
            foreach (Control ch in c.Controls) ChuanHoaFont(ch);
        }

        static string CaLamViec()
        {
            int h = DateTime.Now.Hour;
            return h < 11 ? "Ca sáng" : h < 17 ? "Ca chiều" : "Ca tối";
        }

        // =====================================================================
        //  SỰ KIỆN (được gắn trong Designer)
        // =====================================================================
        private void ucHoaDon_Load(object? sender, EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            _ready = true;
            TaoHoaDonTuDong();
            LoadDanhSach();
        }

        private void txtTim_TextChanged(object? sender, EventArgs e) => LoadDanhSach();

        private void dtpNgay_ValueChanged(object? sender, EventArgs e) => LoadDanhSach();

        private void cboTrangThai_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_sync) return;
            _tab = cboTrangThai.SelectedIndex - 1;      // -1 = Tất cả trạng thái
            CapNhatTab();
            LoadDanhSach();
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            TaoHoaDonTuDong();
            LoadDanhSach();
        }

        private void btnTab_Click(object? sender, EventArgs e)
        {
            int idx = Array.IndexOf(tabBtns, sender);
            if (idx < 0) return;
            _tab = idx;
            CapNhatTab();
            _sync = true; cboTrangThai.SelectedIndex = idx + 1; _sync = false;
            LoadDanhSach();
        }

        // Gạch xanh dưới tab đang chọn
        private void btnTab_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Button b) return;
            int idx = Array.IndexOf(tabBtns, b);
            if (idx != _tab) return;
            using var br = new SolidBrush(cBlue);
            e.Graphics.FillRectangle(br, 10, b.Height - 3, b.Width - 20, 3);
        }

        private void dgvHD_SelectionChanged(object? sender, EventArgs e)
        {
            if (_loading || !_ready) return;
            _cur = dgvHD.CurrentRow?.Tag as HoaDonRow;
            HienChiTiet();
        }

        private void dgvMon_SelectionChanged(object? sender, EventArgs e) => dgvMon.ClearSelection();

        private void lblGiamGia_Click(object? sender, EventArgs e) => SuaGiamGia();

        private void btnPhuongThuc_Click(object? sender, EventArgs e)
        {
            int idx = Array.IndexOf(ptBtns, sender);
            if (idx >= 0) ChonPhuongThuc(PtNames[idx]);
        }

        private void txtDua_TextChanged(object? sender, EventArgs e)
        {
            if (_formatting) return;
            _formatting = true;
            decimal v = ParseMoney(txtDua.Text);
            txtDua.Text = txtDua.Text.Length == 0 ? "" : v.ToString("N0", Vi);
            txtDua.SelectionStart = txtDua.Text.Length;
            _formatting = false;
            TinhTienThua();
        }

        private void btnIn_Click(object? sender, EventArgs e) => InTamTinh();

        // Vẽ cột Trạng thái dạng "pill" màu
        private void dgvHD_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colTT.Index) return;
            e.Handled = true;
            e.PaintBackground(e.ClipBounds, true);

            string st = Convert.ToString(e.Value) ?? "";
            Color fg, bg; string text, glyph;
            switch (st)
            {
                case TT_DA: fg = cGreen; bg = cGreenSoft; text = "Đã thanh toán"; glyph = "✓"; break;
                default: fg = cAmber; bg = cAmberSoft; text = "Chờ thanh toán"; glyph = "◔"; break;
            }

            var g = e.Graphics!;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var r = new Rectangle(e.CellBounds.X + 6, e.CellBounds.Y + 9, e.CellBounds.Width - 14, e.CellBounds.Height - 18);
            using (var path = RoundedRect(r, 10))
            using (var br = new SolidBrush(bg))
                g.FillPath(br, path);

            using var f = F(9.5F);
            using var fs = F(9.5F, FontStyle.Bold, "Segoe UI Symbol");
            const TextFormatFlags fl = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding;
            TextRenderer.DrawText(g, glyph, fs, new Rectangle(r.X + 8, r.Y, 22, r.Height), fg, fl);
            TextRenderer.DrawText(g, text, f, new Rectangle(r.X + 32, r.Y, Math.Max(0, r.Width - 34), r.Height), fg, fl | TextFormatFlags.EndEllipsis);
        }

        // =====================================================================
        //  TRUY VẤN
        // =====================================================================
        static DataTable Query(string sql, params SqlParameter[] ps)
        {
            using var cn = new SqlConnection(ConnStr);
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddRange(ps);
            var dt = new DataTable();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        static int Exec(string sql, params SqlParameter[] ps)
        {
            using var cn = new SqlConnection(ConnStr);
            cn.Open();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddRange(ps);
            return cmd.ExecuteNonQuery();
        }

        static SqlParameter P(string name, object? value, SqlDbType type)
            => new SqlParameter(name, type) { Value = value ?? DBNull.Value };

        DateTime? NgayLoc => dtpNgay.Checked ? dtpNgay.Value.Date : null;

        // Đơn có thêm / bớt món sau khi lập hóa đơn thì tổng tiền hóa đơn CHƯA THANH TOÁN
        // phải tính lại theo các món hiện có (bỏ món đã hủy). Hóa đơn đã thanh toán giữ nguyên.
        static void DongBoTongTien()
        {
            Exec(@"
                update hd
                set hd.TongTien = isnull(t.Tong, 0),
                    hd.GiamGia = case when hd.GiamGia > isnull(t.Tong, 0)
                                      then isnull(t.Tong, 0) else hd.GiamGia end
                from HOA_DON hd
                outer apply (select sum(ct.SoLuong * ct.DonGia) as Tong
                             from CHI_TIET_DON_HANG ct
                             where ct.DonHangID = hd.DonHangID
                               and ct.TrangThaiMon <> N'Đã hủy') t
                where hd.TrangThaiThanhToan = N'Chưa thanh toán'
                  and (hd.TongTien <> isnull(t.Tong, 0) or hd.GiamGia > isnull(t.Tong, 0))");
        }

        void LoadDanhSach()
        {
            if (!_ready || _loading) return;
            int? giuId = _cur?.Id;

            try
            {
                DongBoTongTien();
                CapNhatThongKe();

                var sb = new StringBuilder(@"
                    select hd.HoaDonID, hd.DonHangID, dh.BanID, b.SoBan, dh.ThoiGianTao,
                           hd.TongTien, hd.GiamGia, hd.ThanhTien,
                           hd.PhuongThucThanhToan, hd.TrangThaiThanhToan, hd.NgayThanhToan
                    from HOA_DON hd
                    join DON_HANG dh on dh.DonHangID = hd.DonHangID
                    join BAN_AN b on b.BanID = dh.BanID
                    where hd.TrangThaiThanhToan in (N'Chưa thanh toán', N'Đã thanh toán') ");
                var ps = new List<SqlParameter>();

                if (NgayLoc != null)
                {
                    sb.Append(" and " + SqlNgayHD + " = @ngay ");
                    ps.Add(P("@ngay", NgayLoc, SqlDbType.Date));
                }
                if (_tab >= 0)
                {
                    sb.Append(" and hd.TrangThaiThanhToan = @tt ");
                    ps.Add(P("@tt", TabTT[_tab], SqlDbType.NVarChar));
                }
                string kw = txtTim.Text.Trim();
                if (kw.Length > 0)
                {
                    sb.Append(@" and ( ('HD' + right('0000' + cast(hd.HoaDonID as varchar(10)), 4)) like @kw
                                       or b.SoBan like @kw
                                       or cast(hd.DonHangID as varchar(10)) = @kwExact ) ");
                    ps.Add(P("@kw", "%" + kw + "%", SqlDbType.NVarChar));
                    ps.Add(P("@kwExact", kw, SqlDbType.NVarChar));
                }
                sb.Append(" order by isnull(hd.NgayThanhToan, hd.NgayLap) desc, hd.HoaDonID desc");

                DataTable dt = Query(sb.ToString(), ps.ToArray());

                _loading = true;
                dgvHD.Rows.Clear();
                int chon = -1;
                foreach (DataRow r in dt.Rows)
                {
                    var h = new HoaDonRow
                    {
                        Id = Convert.ToInt32(r["HoaDonID"]),
                        DonHangId = Convert.ToInt32(r["DonHangID"]),
                        BanId = Convert.ToInt32(r["BanID"]),
                        SoBan = Convert.ToString(r["SoBan"]) ?? "",
                        Gio = Convert.ToDateTime(r["ThoiGianTao"]),
                        NgayTT = r["NgayThanhToan"] == DBNull.Value ? null : Convert.ToDateTime(r["NgayThanhToan"]),
                        Tong = Convert.ToDecimal(r["TongTien"]),
                        Giam = Convert.ToDecimal(r["GiamGia"]),
                        Thanh = Convert.ToDecimal(r["ThanhTien"]),
                        Pttt = r["PhuongThucThanhToan"] == DBNull.Value ? null : Convert.ToString(r["PhuongThucThanhToan"]),
                        TrangThai = Convert.ToString(r["TrangThaiThanhToan"]) ?? ""
                    };

                    // Chờ thanh toán -> giờ vào (giờ tạo đơn); đã thanh toán -> giờ thanh toán
                    string gio = (h.TrangThai == TT_DA && h.NgayTT != null)
                        ? h.NgayTT.Value.ToString("HH:mm dd/MM")
                        : h.Gio.ToString("HH:mm dd/MM");

                    int i = dgvHD.Rows.Add(Ma(h.Id), h.SoBan, gio, Money(h.Thanh), h.TrangThai);
                    dgvHD.Rows[i].Tag = h;
                    if (giuId == h.Id) chon = i;
                }
                _loading = false;

                lblFooter.Text = $"{dt.Rows.Count} hóa đơn  •  Chọn một hóa đơn để xem chi tiết";

                if (dgvHD.Rows.Count > 0)
                {
                    if (chon < 0) chon = 0;
                    dgvHD.ClearSelection();
                    dgvHD.CurrentCell = dgvHD.Rows[chon].Cells[0];
                    dgvHD.Rows[chon].Selected = true;
                    _cur = (HoaDonRow)dgvHD.Rows[chon].Tag!;
                }
                else _cur = null;
                HienChiTiet();
            }
            catch (Exception ex)
            {
                _loading = false;
                MessageBox.Show("Lỗi tải danh sách hóa đơn:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CapNhatThongKe()
        {
            DataTable dt = Query(@"
                select
                    isnull(sum(case when hd.TrangThaiThanhToan = N'Chưa thanh toán' then 1 else 0 end), 0) as Cho,
                    isnull(sum(case when hd.TrangThaiThanhToan = N'Đã thanh toán' then 1 else 0 end), 0) as Da
                from HOA_DON hd
                where (@ngay is null or " + SqlNgayHD + " = @ngay)",
                P("@ngay", NgayLoc, SqlDbType.Date));
            lblSoCho.Text = Convert.ToInt32(dt.Rows[0]["Cho"]).ToString("00");
            lblSoDa.Text = Convert.ToInt32(dt.Rows[0]["Da"]).ToString("00");

            DataTable thu = Query(@"
                select isnull(sum(ThanhTien), 0)
                from HOA_DON
                where TrangThaiThanhToan = N'Đã thanh toán'
                  and cast(isnull(NgayThanhToan, NgayLap) as date) = cast(getdate() as date)");
            lblThuNay.Text = Money(Convert.ToDecimal(thu.Rows[0][0]));
        }

        // Đơn đang xử lý mà MỌI món đã phục vụ hoặc hủy (và có ít nhất một món) thì tự lập
        // hóa đơn CHƯA THANH TOÁN. Không cần Phục vụ bấm yêu cầu.
        void TaoHoaDonTuDong()
        {
            if (Session.NhanVienID <= 0) return;
            try
            {
                Exec(@"
            insert into HOA_DON (DonHangID, ThuNganID, NgayLap, TongTien, GiamGia, TrangThaiThanhToan)
            select dh.DonHangID, @tn, sysdatetime(),
                   sum(ct.SoLuong * ct.DonGia), 0, N'Chưa thanh toán'
            from DON_HANG dh
            join CHI_TIET_DON_HANG ct
                 on ct.DonHangID = dh.DonHangID and ct.TrangThaiMon <> N'Đã hủy'
            where dh.TrangThaiDon = N'Đang xử lý'
              and not exists (select 1 from HOA_DON h where h.DonHangID = dh.DonHangID)
            group by dh.DonHangID",
                    P("@tn", Session.NhanVienID, SqlDbType.Int));
            }
            catch
            {
                // Không chặn màn hình nếu có lỗi nhỏ khi lập hóa đơn tự động
            }
        }

        // =====================================================================
        //  CHI TIẾT HÓA ĐƠN
        // =====================================================================
        void HienChiTiet()
        {
            dgvMon.Rows.Clear();
            _items = new DataTable();

            if (_cur == null)
            {
                lblCT.Text = "Chi tiết hóa đơn";
                lblTienMon.Text = lblGiamGia.Text = lblPhuThu.Text = lblCan.Text = Money(0);
                _formatting = true; txtDua.Text = ""; _formatting = false;
                txtThua.Text = "";
                CapNhatTrangThaiNut();
                return;
            }

            lblCT.Text = "Chi tiết hóa đơn " + Ma(_cur.Id);

            try
            {
                // Gộp các lần gọi cùng một món (cùng đơn giá) thành một dòng
                _items = Query(@"
                    select ma.TenMon,
                           sum(ct.SoLuong) as SoLuong,
                           ct.DonGia,
                           sum(ct.SoLuong * ct.DonGia) as ThanhTien
                    from CHI_TIET_DON_HANG ct
                    join MON_AN ma on ma.MonID = ct.MonID
                    where ct.DonHangID = @dh and ct.TrangThaiMon <> N'Đã hủy'
                    group by ma.TenMon, ct.DonGia
                    order by ma.TenMon", P("@dh", _cur.DonHangId, SqlDbType.Int));
                foreach (DataRow r in _items.Rows)
                    dgvMon.Rows.Add(r["TenMon"], r["SoLuong"],
                        Money(Convert.ToDecimal(r["DonGia"])), Money(Convert.ToDecimal(r["ThanhTien"])));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết hóa đơn:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblTienMon.Text = Money(_cur.Tong);
            lblGiamGia.Text = Money(_cur.Giam);
            lblPhuThu.Text = Money(0);
            lblCan.Text = Money(_cur.Thanh);

            bool choTT = _cur.TrangThai == TT_CHO;
            ChonPhuongThuc(choTT ? PT_TIENMAT : (_cur.Pttt ?? PT_TIENMAT));

            _formatting = true;
            txtDua.Text = choTT ? "" : Money0(_cur.Thanh);
            _formatting = false;
            TinhTienThua();
            CapNhatTrangThaiNut();
        }

        void CapNhatTab()
        {
            for (int i = 0; i < tabBtns.Length; i++)
            {
                tabBtns[i].ForeColor = (i == _tab) ? cBlue : cMuted;
                tabBtns[i].Invalidate();
            }

            // Tiêu đề cột giờ đổi theo tab đang xem
            colGio.HeaderText = _tab == 0 ? "Giờ vào"
                              : _tab == 1 ? "Giờ thanh toán"
                              : "Thời gian";
        }

        void CapNhatTrangThaiNut()
        {
            bool choTT = _cur != null && _cur.TrangThai == TT_CHO;
            foreach (var b in ptBtns) b.Enabled = choTT;
            lblGiamGia.Cursor = choTT ? Cursors.Hand : Cursors.Default;
            lblGiamGia.ForeColor = choTT ? cBlue : cText;
            txtDua.Enabled = choTT && _pttt == PT_TIENMAT;
            btnXacNhan.Enabled = choTT;
            btnXacNhan.BackColor = choTT ? cBlue : Color.FromArgb(148, 163, 184);
            btnIn.Enabled = _cur != null;
        }

        void ChonPhuongThuc(string name)
        {
            _pttt = name;
            for (int i = 0; i < ptBtns.Length; i++)
            {
                bool on = PtNames[i] == name;
                var b = ptBtns[i];
                b.BackColor = on ? cBlue : Color.White;
                b.ForeColor = on ? Color.White : cText;
                b.FlatAppearance.BorderSize = on ? 0 : 1;
                b.FlatAppearance.BorderColor = cBorder;
            }

            bool choTT = _cur != null && _cur.TrangThai == TT_CHO;
            txtDua.Enabled = choTT && name == PT_TIENMAT;
            if (choTT && name != PT_TIENMAT)
            {
                // Chuyển khoản / thẻ: khách trả đúng số tiền
                _formatting = true;
                txtDua.Text = Money0(_cur!.Thanh);
                _formatting = false;
            }
            TinhTienThua();
        }

        void TinhTienThua()
        {
            if (_cur == null) { txtThua.Text = ""; return; }
            decimal dua = ParseMoney(txtDua.Text);
            decimal thua = dua > _cur.Thanh ? dua - _cur.Thanh : 0;
            txtThua.Text = (_cur.TrangThai == TT_CHO && txtDua.Text.Length == 0) ? "" : thua.ToString("N0", Vi);
        }

        // =====================================================================
        //  GIẢM GIÁ / THANH TOÁN / IN
        // =====================================================================
        void SuaGiamGia()
        {
            if (_cur == null || _cur.TrangThai != TT_CHO) return;

            string nhap = Interaction.InputBox(
                "Nhập số tiền giảm giá (đ).\nTiền món: " + Money(_cur.Tong),
                "Giảm giá hóa đơn " + Ma(_cur.Id),
                _cur.Giam.ToString("0", CultureInfo.InvariantCulture));
            if (string.IsNullOrWhiteSpace(nhap)) return;

            decimal giam = ParseMoney(nhap);
            if (giam < 0 || giam > _cur.Tong)
            {
                MessageBox.Show("Giảm giá phải từ 0 đến tiền món (" + Money(_cur.Tong) + ").",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int n = Exec(@"update HOA_DON set GiamGia = @g
                               where HoaDonID = @id and TrangThaiThanhToan = N'Chưa thanh toán'",
                    P("@g", giam, SqlDbType.Decimal), P("@id", _cur.Id, SqlDbType.Int));
                if (n == 0) MessageBox.Show("Không sửa được: hóa đơn đã được xử lý.");
                LoadDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa giảm giá:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXacNhan_Click(object? sender, EventArgs e)
        {
            if (_cur == null || _cur.TrangThai != TT_CHO)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn đang chờ thanh toán.");
                return;
            }
            if (Session.NhanVienID <= 0)
            {
                MessageBox.Show("Không xác định được nhân viên đăng nhập. Vui lòng đăng nhập lại!");
                return;
            }

            try
            {
                // Tính lại tổng tiền theo TẤT CẢ món đã gọi (không bỏ món chưa ra);
                // nếu khác số đang hiển thị thì báo để kiểm tra lại
                DongBoTongTien();
                DataTable moi = Query(
                    "select ThanhTien from HOA_DON where HoaDonID = @id",
                    P("@id", _cur.Id, SqlDbType.Int));
                if (moi.Rows.Count > 0 && Convert.ToDecimal(moi.Rows[0]["ThanhTien"]) != _cur.Thanh)
                {
                    MessageBox.Show("Đơn vừa thay đổi món nên số tiền đã được cập nhật.\n" +
                                    "Vui lòng kiểm tra lại rồi xác nhận thanh toán.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSach();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra hóa đơn:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal can = _cur.Thanh;
            if (_pttt == PT_TIENMAT && ParseMoney(txtDua.Text) < can)
            {
                MessageBox.Show("Khách đưa chưa đủ. Cần thanh toán " + Money(can) + ".",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDua.Focus();
                return;
            }

            var xn = MessageBox.Show(
                $"Hóa đơn: {Ma(_cur.Id)}  •  Bàn {_cur.SoBan}\n" +
                $"Cần thanh toán: {Money(can)}\n" +
                $"Phương thức: {_pttt}\n\nXác nhận thanh toán?",
                "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xn != DialogResult.Yes) return;

            try
            {
                using var cn = new SqlConnection(ConnStr);
                cn.Open();
                using var tx = cn.BeginTransaction();

                int n;
                using (var c1 = new SqlCommand(@"
                    update HOA_DON
                    set PhuongThucThanhToan = @pt,
                        TrangThaiThanhToan = N'Đã thanh toán',
                        NgayThanhToan = sysdatetime()
                    where HoaDonID = @id and TrangThaiThanhToan = N'Chưa thanh toán'", cn, tx))
                {
                    c1.Parameters.Add(P("@pt", _pttt, SqlDbType.NVarChar));
                    c1.Parameters.Add(P("@id", _cur.Id, SqlDbType.Int));
                    n = c1.ExecuteNonQuery();
                }

                if (n == 0)
                {
                    tx.Rollback();
                    MessageBox.Show("Hóa đơn đã được thanh toán hoặc bị hủy trước đó.");
                    LoadDanhSach();
                    return;
                }

                using (var c2 = new SqlCommand(@"
                    update DON_HANG set TrangThaiDon = N'Hoàn thành' where DonHangID = @dh;
                    update BAN_AN set TrangThai = N'Chờ dọn' where BanID = @ban;", cn, tx))
                {
                    c2.Parameters.Add(P("@dh", _cur.DonHangId, SqlDbType.Int));
                    c2.Parameters.Add(P("@ban", _cur.BanId, SqlDbType.Int));
                    c2.ExecuteNonQuery();
                }
                tx.Commit();

                decimal thua = _pttt == PT_TIENMAT ? Math.Max(0, ParseMoney(txtDua.Text) - can) : 0;
                MessageBox.Show(
                    "Thanh toán thành công!" + (thua > 0 ? "\nTiền thừa trả khách: " + Money(thua) : ""),
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _cur = null;
                LoadDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void InTamTinh()
        {
            if (_cur == null) return;
            var h = _cur;
            var items = _items;

            var pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("Bill", 315, 800);   // ~80mm
            pd.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
            pd.PrintPage += (s, e) =>
            {
                var g = e.Graphics!;
                float w = e.MarginBounds.Width, x = e.MarginBounds.Left, y = e.MarginBounds.Top;
                using var fB = new Font("Segoe UI", 12F, FontStyle.Bold);
                using var fN = new Font("Segoe UI", 9F);
                using var fS = new Font("Segoe UI", 9F, FontStyle.Bold);
                using var center = new StringFormat { Alignment = StringAlignment.Center };
                using var right = new StringFormat { Alignment = StringAlignment.Far };

                g.DrawString("PHIẾU TẠM TÍNH", fB, Brushes.Black, new RectangleF(x, y, w, 24), center); y += 28;
                g.DrawString($"{Ma(h.Id)}  •  Bàn {h.SoBan}", fN, Brushes.Black, new RectangleF(x, y, w, 18), center); y += 18;
                g.DrawString(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fN, Brushes.Black, new RectangleF(x, y, w, 18), center); y += 24;
                g.DrawLine(Pens.Black, x, y, x + w, y); y += 6;

                foreach (DataRow r in items.Rows)
                {
                    decimal dg = Convert.ToDecimal(r["DonGia"]), tt = Convert.ToDecimal(r["ThanhTien"]);
                    g.DrawString(Convert.ToString(r["TenMon"]), fS, Brushes.Black, new RectangleF(x, y, w, 18)); y += 18;
                    g.DrawString($"{r["SoLuong"]} x {dg.ToString("N0", Vi)}", fN, Brushes.Black, x + 8, y);
                    g.DrawString(tt.ToString("N0", Vi), fN, Brushes.Black, new RectangleF(x, y, w, 18), right); y += 20;
                }
                y += 4;
                g.DrawLine(Pens.Black, x, y, x + w, y); y += 6;

                void Dong(string a, string b, Font f)
                {
                    g.DrawString(a, f, Brushes.Black, x, y);
                    g.DrawString(b, f, Brushes.Black, new RectangleF(x, y, w, 20), right);
                    y += 22;
                }
                Dong("Tiền món", Money(h.Tong), fN);
                Dong("Giảm giá", Money(h.Giam), fN);
                Dong("Phụ thu", Money(0), fN);
                Dong("CẦN THANH TOÁN", Money(h.Thanh), fB);
                y += 8;
                g.DrawString("Cảm ơn quý khách!", fN, Brushes.Black, new RectangleF(x, y, w, 18), center);
            };

            try
            {
                using var dlg = new PrintPreviewDialog { Document = pd, Width = 520, Height = 780 };
                dlg.ShowDialog(FindForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không in được: " + ex.Message);
            }
        }

        // =====================================================================
        //  TIỆN ÍCH
        // =====================================================================
        static string Ma(int id) => "HD" + id.ToString("0000");
        static string Money(decimal v) => v.ToString("N0", Vi) + " đ";
        static string Money0(decimal v) => v.ToString("N0", Vi);

        static decimal ParseMoney(string? s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            string d = new string(s.Where(char.IsDigit).ToArray());
            if (d.Length == 0) return 0;
            if (d.Length > 12) d = d.Substring(0, 12);
            return decimal.Parse(d, CultureInfo.InvariantCulture);
        }

        // Màu/font header + dòng chọn của 2 bảng (phần Designer không đặt được gọn)
        static void StyleGrid(DataGridView g)
        {
            g.ColumnHeadersDefaultCellStyle.BackColor = cHeader;
            g.ColumnHeadersDefaultCellStyle.ForeColor = cText;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = cHeader;
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = cText;
            g.ColumnHeadersDefaultCellStyle.Font = F(10.5F, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            g.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            g.DefaultCellStyle.BackColor = Color.White;
            g.DefaultCellStyle.ForeColor = cText;
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            g.DefaultCellStyle.SelectionForeColor = cText;
            g.DefaultCellStyle.Font = F(10.5F);
            g.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
        }

        static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            int d = radius * 2;
            var p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }
    }
}