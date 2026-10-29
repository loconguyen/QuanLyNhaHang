using Microsoft.Data.SqlClient;
using QLNhaHang.Classes;
using QLNhaHang.Forms.Main;
using System.Data;

namespace QLNhaHang.Controls.Admin
{
    public partial class ucTaiKhoan : UserControl
    {
        private readonly QuanLyTaiKhoan xuLy = new QuanLyTaiKhoan();
        private DataTable? danhSach;
        private bool dangTai;
        private bool dangXuLy;
        private DataRow? dongDangChon;

        public ucTaiKhoan()
        {
            InitializeComponent();

            ThietLapBoCuc();

            dgvTaiKhoan.AutoGenerateColumns = false;

            cbLocTrangThai.SelectedIndex = 0;
            cbLocVaiTro.SelectedIndex = 0;

            CapNhatNut();
        }

        private async void ucTaiKhoan_Load(object? sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime && !DesignMode)
                await TaiDanhSach();
        }

        private async Task TaiDanhSach(int? maCanChon = null)
        {
            if (dangXuLy) return;
            dangXuLy = true;
            CapNhatNut();
            UseWaitCursor = true;
            lblThongBao.Text = "Đang tải danh sách tài khoản…";
            try
            {
                var ketQua = await Task.Run(() => (TaiKhoan: xuLy.DanhSach(), VaiTro: xuLy.LayVaiTro()));
                if (IsDisposed) return;
                dangTai = true;
                danhSach = ketQua.TaiKhoan;
                cbVaiTro.DisplayMember = "TenHienThi";
                cbVaiTro.ValueMember = "RoleID";
                cbVaiTro.DataSource = ketQua.VaiTro;
                cbVaiTro.SelectedIndex = -1;
                lblTongSo.Text = danhSach.Rows.Count.ToString();
                lblChoDuyet.Text = Dem("Chờ duyệt").ToString();
                lblHoatDong.Text = Dem("Hoạt động").ToString();
                lblBiKhoa.Text = Dem("Bị khóa").ToString();
                dangTai = false;
                LocDanhSach(maCanChon);
            }
            catch (Exception ex) when (ex is SqlException || ex is InvalidOperationException)
            {
                if (IsDisposed) return;
                danhSach = null;
                dgvTaiKhoan.DataSource = null;
                dongDangChon = null;
                HienChiTiet();
                lblTongSo.Text = lblChoDuyet.Text = lblHoatDong.Text = lblBiKhoa.Text = "—";
                HienLoi(ex);
            }
            finally
            {
                dangTai = false;
                dangXuLy = false;
                if (!IsDisposed) { UseWaitCursor = false; CapNhatNut(); }
            }
        }

        private int Dem(string trangThai) => danhSach!.AsEnumerable().Count(r => r.Field<string>("TrangThai") == trangThai);

        private void LocDanhSach(int? maCanChon = null)
        {
            if (dangTai || danhSach == null) return;
            string tuKhoa = txtTimKiem.Text.Trim();
            string trangThai = cbLocTrangThai.SelectedIndex <= 0 ? "" : cbLocTrangThai.Text;
            string vaiTro = cbLocVaiTro.SelectedIndex switch { 1 => "ADMIN", 2 => "BEP", 3 => "PHUCVU", 4 => "THUNGAN", _ => "" };
            var ketQua = danhSach.Clone();
            foreach (DataRow dong in danhSach.Rows)
            {
                if (trangThai != "" && dong["TrangThai"].ToString() != trangThai) continue;
                if (vaiTro != "" && dong["TenVaiTro"].ToString() != vaiTro) continue;
                if (tuKhoa != "" && !new[] { "TaiKhoanID", "NhanVienID", "TenDangNhap", "HoTen", "SDT" }
                    .Any(c => (dong[c].ToString() ?? "").Contains(tuKhoa, StringComparison.CurrentCultureIgnoreCase))) continue;
                ketQua.ImportRow(dong);
            }
            dangTai = true;
            try
            {
                dgvTaiKhoan.DataSource = ketQua;
                dgvTaiKhoan.ClearSelection();
                dgvTaiKhoan.CurrentCell = null;
                DataGridViewRow? chon = maCanChon.HasValue
                    ? dgvTaiKhoan.Rows.Cast<DataGridViewRow>().FirstOrDefault(r =>
                        r.DataBoundItem is DataRowView duLieu && Convert.ToInt32(duLieu["TaiKhoanID"]) == maCanChon.Value)
                    : dgvTaiKhoan.Rows.Cast<DataGridViewRow>().FirstOrDefault();
                DataGridViewColumn? cotChon = dgvTaiKhoan.Columns.Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => c.Visible && c.DataPropertyName == "TenDangNhap")
                    ?? dgvTaiKhoan.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Visible);
                if (chon != null && cotChon != null)
                {
                    dgvTaiKhoan.CurrentCell = chon.Cells[cotChon.Index];
                    chon.Selected = true;
                }
            }
            finally { dangTai = false; }
            ChonDong();
            lblThongBao.ForeColor = Theme.TextMuted;
            lblThongBao.Text = ketQua.Rows.Count == 0
                ? "Không có tài khoản phù hợp. Thử đổi bộ lọc hoặc từ khóa."
                : $"Hiển thị {ketQua.Rows.Count}/{danhSach.Rows.Count} tài khoản. Chọn một dòng để xem và quản lý.";
        }

        private void BoLoc_Changed(object? sender, EventArgs e)
        {
            if (!dangXuLy) LocDanhSach();
        }

        private void dgvTaiKhoan_SelectionChanged(object? sender, EventArgs e)
        {
            if (!dangTai) ChonDong();
        }

        private void ChonDong()
        {
            dongDangChon = (dgvTaiKhoan.CurrentRow?.DataBoundItem as DataRowView)?.Row;
            HienChiTiet();
            CapNhatNut();
        }

        private void HienChiTiet()
        {
            txtMatKhauMoi.Clear();
            txtXacNhanMatKhau.Clear();
            chkHienMatKhau.Checked = false;
            txtTenDangNhap.Text = dongDangChon?["TenDangNhap"].ToString() ?? "";
            lblNguoiDung.Text = dongDangChon == null ? "Chưa chọn tài khoản" : dongDangChon["HoTen"].ToString();
            lblMaNhanVien.Text = dongDangChon == null ? "Chọn một tài khoản trong danh sách."
                : dongDangChon.IsNull("NhanVienID") ? "Chưa cấp mã nhân viên · " + dongDangChon["SDT"]
                : "Mã nhân viên: " + dongDangChon["NhanVienID"] + " · " + dongDangChon["SDT"];
            lblTrangThai.Text = dongDangChon?["TrangThai"].ToString() ?? "—";
            lblTrangThai.ForeColor = lblTrangThai.Text switch {
                "Hoạt động" => Theme.Green, "Chờ duyệt" => Theme.OrangeText,
                _ => Theme.Danger };
            if (dongDangChon != null && !dongDangChon.IsNull("RoleID")) cbVaiTro.SelectedValue = dongDangChon["RoleID"];
            else cbVaiTro.SelectedIndex = -1;
        }

        private void CapNhatNut()
        {
            string trangThai = dongDangChon?["TrangThai"].ToString() ?? "";
            bool daDuyet = trangThai == "Hoạt động" || trangThai == "Bị khóa";
            bool sanSang = !dangXuLy && dongDangChon != null;
            pnlDuyet.Visible = trangThai == "Chờ duyệt";
            pnlQuanTri.Visible = daDuyet;
            btnLuu.Visible = btnKhoa.Visible = daDuyet;
            tabMatKhau.Enabled = daDuyet;
            btnDuyet.Enabled = btnTuChoi.Enabled = sanSang && trangThai == "Chờ duyệt";
            btnLuu.Enabled = sanSang && daDuyet;
            bool taiKhoanHienTai = dongDangChon != null && Convert.ToInt32(dongDangChon["TaiKhoanID"]) == Session.TaiKhoanID;
            btnKhoa.Enabled = sanSang && daDuyet && !taiKhoanHienTai;
            btnKhoa.Text = trangThai == "Bị khóa" ? "Mở khóa" : "Khóa";
            btnDatLaiMatKhau.Enabled = sanSang && daDuyet;
            txtTenDangNhap.ReadOnly = !sanSang || !daDuyet;
            cbVaiTro.Enabled = sanSang && (daDuyet || trangThai == "Chờ duyệt");
            txtMatKhauMoi.Enabled = txtXacNhanMatKhau.Enabled = chkHienMatKhau.Enabled = sanSang && daDuyet;
            btnThem.Enabled = btnTaiLai.Enabled = txtTimKiem.Enabled = cbLocTrangThai.Enabled = cbLocVaiTro.Enabled = !dangXuLy;
            dgvTaiKhoan.Enabled = !dangXuLy;
        }

        private bool XacNhan(string noiDung) => MessageBox.Show(FindForm(), noiDung, "Quản lý tài khoản",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        private async Task ThucHien(Func<string> thaoTac, int ma)
        {
            if (dangXuLy) return;
            dangXuLy = true;
            UseWaitCursor = true;
            CapNhatNut();
            string? thongBao = null;
            try { thongBao = await Task.Run(thaoTac); }
            catch (Exception ex) when (ex is SqlException || ex is InvalidOperationException)
            {
                if (!IsDisposed) HienLoi(ex);
            }
            finally
            {
                dangXuLy = false;
                if (!IsDisposed) { UseWaitCursor = false; CapNhatNut(); }
            }
            if (IsDisposed) return;
            if (thongBao != null)
            {
                await TaiDanhSach(ma);
                if (!IsDisposed && danhSach != null)
                {
                    lblThongBao.ForeColor = Theme.Green;
                    lblThongBao.Text = thongBao;
                }
            }
        }

        private bool LayTaiKhoan(out int ma)
        {
            ma = 0;

            if (dongDangChon == null || dangXuLy)
                return false;

            ma = Convert.ToInt32(dongDangChon["TaiKhoanID"]);

            return true;
        }

        private bool LayVaiTro(out int roleID)
        {
            roleID = 0;
            if (cbVaiTro.SelectedValue is int id) { roleID = id; return true; }
            lblThongBao.ForeColor = Theme.Danger;
            lblThongBao.Text = "Vui lòng chọn vai trò cần cấp.";
            return false;
        }

        private async void btnTaiLai_Click(object? sender, EventArgs e) => await TaiDanhSach();
        private async void btnDuyet_Click(object? sender, EventArgs e)
        {
            // 1. Kiểm tra tài khoản được chọn
            if (dongDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần duyệt!");
                return;
            }

            // 2. Kiểm tra trạng thái tài khoản
            string trangThai = dongDangChon["TrangThai"].ToString() ?? "";

            if (trangThai != "Chờ duyệt")
            {
                MessageBox.Show("Chỉ được duyệt tài khoản đang chờ duyệt!");
                return;
            }

            // 3. Lấy mã tài khoản
            int taiKhoanID = Convert.ToInt32(dongDangChon["TaiKhoanID"]);

            // 4. Chuyển sang ucDuyetNhanVien
            if (FindForm() is MainForm main)
            {
                main.MoDuyetTaiKhoan(taiKhoanID);
            }
        }
        private async void btnTuChoi_Click(object? sender, EventArgs e)
        {
            if (!LayTaiKhoan(out int ma)) return;
            if (Convert.ToString(dongDangChon!["TrangThai"]) != "Chờ duyệt")
            {
                HienLoi(new InvalidOperationException("Chỉ được từ chối tài khoản đang chờ duyệt."));
                return;
            }
            if (!XacNhan($"Từ chối yêu cầu đăng ký của '{dongDangChon["TenDangNhap"]}'?")) return;
            await ThucHien(() =>
            {
                xuLy.TuChoi(ma);
                return "Đã từ chối yêu cầu đăng ký.";
            }, ma);
        }
        private async void btnLuu_Click(object? sender, EventArgs e)
        {
            if (!LayTaiKhoan(out int ma) || !LayVaiTro(out int role)) return;
            if (dongDangChon!.IsNull("NhanVienID"))
            {
                HienLoi(new InvalidOperationException("Chỉ sửa tài khoản đã được duyệt."));
                return;
            }
            string ten = txtTenDangNhap.Text.Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                HienLoi(new ArgumentException("Vui lòng nhập tên đăng nhập."));
                txtTenDangNhap.Focus();
                return;
            }
            if (!XacNhan($"Lưu tên đăng nhập '{ten}' và vai trò {cbVaiTro.Text}?")) return;
            await ThucHien(() =>
            {
                xuLy.CapNhat(ma, ten, role);
                return "Đã lưu tên đăng nhập và vai trò.";
            }, ma);
        }
        private async void btnKhoa_Click(object? sender, EventArgs e)
        {
            if (!LayTaiKhoan(out int ma))
                return;

            bool khoa = dongDangChon!["TrangThai"].ToString() == "Hoạt động";

            if (!XacNhan(
                $"{(khoa ? "Khóa" : "Mở khóa")} tài khoản '{dongDangChon["TenDangNhap"]}'?"))
                return;

            await ThucHien(() =>
            {
                xuLy.DoiTrangThai(ma, khoa);

                return khoa
                    ? "Đã khóa tài khoản."
                    : "Đã mở khóa tài khoản.";
            }, ma);
        }
        private async void btnDatLaiMatKhau_Click(object? sender, EventArgs e)
        {
            // 1. Lấy mã tài khoản đang chọn
            if (!LayTaiKhoan(out int ma))
                return;

            // 2. Lấy mật khẩu mới
            string matKhau = txtMatKhauMoi.Text;

            // 3. Kiểm tra mật khẩu hợp lệ
            if (matKhau.Length < 8 ||
                matKhau.Length > 128 ||
                string.IsNullOrWhiteSpace(matKhau))
            {
                lblThongBao.Text = "Mật khẩu mới cần có từ 8 đến 128 ký tự.";
                return;
            }

            // 4. Kiểm tra xác nhận mật khẩu
            if (matKhau != txtXacNhanMatKhau.Text)
            {
                lblThongBao.Text = "Mật khẩu xác nhận chưa khớp.";
                return;
            }

            // 5. Xác nhận thao tác
            if (!XacNhan(
                $"Đặt lại mật khẩu cho '{dongDangChon!["TenDangNhap"]}'?"))
                return;

            // 6. Gọi phương thức xử lý
            await ThucHien(() =>
            {
                xuLy.DatLaiMatKhau(ma, matKhau);

                return "Đã đặt lại mật khẩu.";
            }, ma);
        }
        private void chkHienMatKhau_CheckedChanged(object? sender, EventArgs e)
        {
            txtMatKhauMoi.UseSystemPasswordChar = txtXacNhanMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }
        private async void btnThem_Click(object? sender, EventArgs e)
        {
            using var form = new QLNhaHang.Forms.TaiKhoan.frmTaoTaiKhoan();
            if (form.ShowDialog(FindForm()) == DialogResult.OK) await TaiDanhSach();
        }
        private void dgvTaiKhoan_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvTaiKhoan.Columns[e.ColumnIndex].DataPropertyName == "TenVaiTro" && e.Value is string vaiTro)
            {
                e.Value = vaiTro switch { "ADMIN" => "Quản lý", "BEP" => "Bếp", "PHUCVU" => "Phục vụ", "THUNGAN" => "Thu ngân", "KHO" => "Kho", _ => vaiTro };
                e.FormattingApplied = true;
            }
        }
        private void HienLoi(Exception ex)
        {
            lblThongBao.ForeColor = Theme.Danger;
            lblThongBao.Text = ex is SqlException sql && sql.Number < 50000
                ? sql.Number is 2601 or 2627 ? "Tên đăng nhập, số điện thoại hoặc nhân viên đã được sử dụng. Hãy tải lại danh sách."
                : sql.Number == 1205 ? "Có thao tác đồng thời. Hãy tải lại danh sách và thử lại."
                : "Không xử lý được dữ liệu. Kiểm tra kết nối và chạy Database/DangKyTaiKhoan.sql."
                : ex.Message;
        }


        //giao dien
        private void ThietLapBoCuc()
        {
            SuspendLayout();
            pnlBoCuc.SuspendLayout();
            for (int i = 0; i < pnlBoCuc.RowStyles.Count; i++)
                pnlBoCuc.RowStyles[i].SizeType = i == 3 ? SizeType.Percent : SizeType.AutoSize;
            pnlBoCuc.RowStyles[3].Height = 100;

            pnlTieuDe.AutoSize = true;
            pnlTieuDe.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            foreach (RowStyle hang in pnlTieuDe.RowStyles) hang.SizeType = SizeType.AutoSize;
            lblTieuDe.AutoSize = true;
            lblTieuDe.Margin = new Padding(0, 4, 12, 12);
            btnThem.AutoSize = true;
            btnThem.Padding = new Padding(10, 6, 10, 6);
            btnThem.Margin = new Padding(0, 4, 0, 12);
            pnlTieuDe.ColumnStyles[1].Width = TextRenderer.MeasureText(btnThem.Text, btnThem.Font).Width
                + btnThem.Padding.Horizontal + 24;

            pnlThongKe.AutoSize = true;
            pnlThongKe.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlThongKe.RowStyles[0].SizeType = SizeType.AutoSize;
            BoTriThongKe(pnlTongSo, lblTongSo, lblNhanTongSo);
            BoTriThongKe(pnlChoDuyet, lblChoDuyet, lblNhanChoDuyet);
            BoTriThongKe(pnlHoatDong, lblHoatDong, lblNhanHoatDong);
            BoTriThongKe(pnlBiKhoa, lblBiKhoa, lblNhanBiKhoa);

            pnlBoLoc.AutoSize = true;
            pnlBoLoc.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlBoLoc.RowStyles[0].SizeType = SizeType.AutoSize;
            txtTimKiem.Dock = cbLocTrangThai.Dock = cbLocVaiTro.Dock = DockStyle.Top;
            btnTaiLai.AutoSize = true;
            btnTaiLai.Padding = new Padding(6, 3, 6, 3);
            pnlBoLoc.ColumnStyles[1].Width = RongBoLoc(cbLocTrangThai);
            pnlBoLoc.ColumnStyles[2].Width = RongBoLoc(cbLocVaiTro);
            pnlBoLoc.ColumnStyles[3].Width = TextRenderer.MeasureText(btnTaiLai.Text, btnTaiLai.Font).Width + 28;
            pnlNoiDung.ColumnStyles[1].Width = Math.Max(320,
                TextRenderer.MeasureText(new string('0', 24), Font).Width + 64);

            foreach (FlowLayoutPanel khung in new[] { pnlChiTiet, pnlMatKhau })
            {
                khung.AutoScroll = true;
                khung.WrapContents = false;
                foreach (Control thanhPhan in khung.Controls)
                {
                    if (thanhPhan is Label nhan)
                    {
                        nhan.AutoSize = true;
                        nhan.AutoEllipsis = false;
                        nhan.Margin = new Padding(0, 0, 0, 8);
                    }
                    else if (thanhPhan is CheckBox hopChon)
                        hopChon.AutoSize = true;
                }
                khung.SizeChanged += (_, _) => CanChinhChiTiet(khung);
                CanChinhChiTiet(khung);
            }
            foreach (FlowLayoutPanel hangNut in new[] { pnlDuyet, pnlQuanTri })
            {
                hangNut.AutoSize = true;
                hangNut.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                hangNut.WrapContents = true;
                foreach (Button nut in hangNut.Controls.OfType<Button>())
                {
                    nut.AutoSize = true;
                    nut.Padding = new Padding(8, 5, 8, 5);
                    nut.Margin = new Padding(0, 0, 6, 6);
                }
            }
            btnDatLaiMatKhau.AutoSize = true;
            btnDatLaiMatKhau.Padding = new Padding(8, 5, 8, 5);
            lblThongBao.AutoSize = true;

            KhoiPhucCotNeuThieu();
            pnlBoCuc.ResumeLayout(true);
            ResumeLayout(true);
        }

        private static void BoTriThongKe(Panel khung, Label soLuong, Label moTa)
        {
            // Dock theo thứ tự: số ở trên, chú thích ở dưới, không dựa vào tọa độ cố định.
            khung.SuspendLayout();
            khung.AutoSize = true;
            khung.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            khung.Padding = new Padding(14, 8, 14, 10);
            soLuong.AutoSize = moTa.AutoSize = true;
            soLuong.Dock = moTa.Dock = DockStyle.Top;
            khung.Controls.SetChildIndex(soLuong, 1);
            khung.Controls.SetChildIndex(moTa, 0);
            khung.ResumeLayout(true);
        }

        private static int RongBoLoc(ComboBox boLoc) => boLoc.Items.Cast<object>()
            .Select(muc => TextRenderer.MeasureText(muc.ToString(), boLoc.Font).Width)
            .DefaultIfEmpty(100).Max() + SystemInformation.VerticalScrollBarWidth + boLoc.Margin.Horizontal + 18;

        private static void CanChinhChiTiet(FlowLayoutPanel khung)
        {
            int rong = Math.Max(80, khung.ClientSize.Width - khung.Padding.Horizontal
                - SystemInformation.VerticalScrollBarWidth - 2);
            khung.SuspendLayout();
            foreach (Control thanhPhan in khung.Controls)
            {
                if (thanhPhan is Label nhan)
                {
                    nhan.MinimumSize = new Size(rong, 0);
                    nhan.MaximumSize = new Size(rong, 0);
                }
                else
                {
                    thanhPhan.Width = rong;
                    if (thanhPhan is FlowLayoutPanel hangNut)
                        hangNut.MaximumSize = new Size(rong, 0);
                }
            }
            khung.ResumeLayout(true);
        }

        private void KhoiPhucCotNeuThieu()
        {
            if (dgvTaiKhoan.Columns.Count != 0) return;
            // Giữ lưới hoạt động nếu Designer làm mất collection Columns khi lưu.
            colMaTaiKhoan = new DataGridViewTextBoxColumn { Name = "colMaTaiKhoan", DataPropertyName = "TaiKhoanID", HeaderText = "Mã TK", Visible = false };
            colTenDangNhap = new DataGridViewTextBoxColumn { Name = "colTenDangNhap", DataPropertyName = "TenDangNhap", HeaderText = "Tên đăng nhập", MinimumWidth = 130 };
            colHoTen = new DataGridViewTextBoxColumn { Name = "colHoTen", DataPropertyName = "HoTen", HeaderText = "Họ tên", MinimumWidth = 155 };
            colMaNhanVien = new DataGridViewTextBoxColumn { Name = "colMaNhanVien", DataPropertyName = "NhanVienID", HeaderText = "Mã NV", Visible = false };
            colSDT = new DataGridViewTextBoxColumn { Name = "colSDT", DataPropertyName = "SDT", HeaderText = "Điện thoại", MinimumWidth = 100 };
            colVaiTro = new DataGridViewTextBoxColumn { Name = "colVaiTro", DataPropertyName = "TenVaiTro", HeaderText = "Vai trò", MinimumWidth = 85 };
            colTrangThai = new DataGridViewTextBoxColumn { Name = "colTrangThai", DataPropertyName = "TrangThai", HeaderText = "Trạng thái", MinimumWidth = 100 };
            dgvTaiKhoan.Columns.AddRange(colMaTaiKhoan, colTenDangNhap, colHoTen, colMaNhanVien, colSDT, colVaiTro, colTrangThai);
        }
    }
}
