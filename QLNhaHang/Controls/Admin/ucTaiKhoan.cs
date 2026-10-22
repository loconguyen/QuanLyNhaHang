using System.Data;
using Microsoft.Data.SqlClient;
using QLNhaHang.Classes;

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
            // Designer có thể bỏ thuộc tính AutoGenerateColumns khi lưu lại.
            dgvTaiKhoan.AutoGenerateColumns = false;
            ThietLapBoCuc();
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
            lblThongBao.ForeColor = Color.FromArgb(100, 112, 130);
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
                "Hoạt động" => Color.FromArgb(20, 130, 75), "Chờ duyệt" => Color.FromArgb(170, 108, 20),
                _ => Color.FromArgb(160, 65, 55) };
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
                    lblThongBao.ForeColor = Color.FromArgb(20, 130, 75);
                    lblThongBao.Text = thongBao;
                }
            }
        }

        private bool LayTaiKhoan(out int ma, out byte[] phienBan)
        {
            ma = 0; phienBan = Array.Empty<byte>();
            if (dongDangChon == null || dangXuLy) return false;
            ma = Convert.ToInt32(dongDangChon["TaiKhoanID"]);
            phienBan = (byte[])dongDangChon["PhienBan"];
            return true;
        }

        private bool LayVaiTro(out int roleID)
        {
            roleID = 0;
            if (cbVaiTro.SelectedValue is int id) { roleID = id; return true; }
            lblThongBao.ForeColor = Color.FromArgb(170, 60, 30);
            lblThongBao.Text = "Vui lòng chọn vai trò cần cấp.";
            return false;
        }

        private async void btnTaiLai_Click(object? sender, EventArgs e) => await TaiDanhSach();
        private async void btnDuyet_Click(object? sender, EventArgs e)
        {
            if (!LayTaiKhoan(out int ma, out byte[] pb) || !LayVaiTro(out int role)) return;
            if (!XacNhan($"Duyệt tài khoản '{dongDangChon!["TenDangNhap"]}' với quyền {cbVaiTro.Text}?")) return;
            await ThucHien(() => $"Đã duyệt tài khoản. Mã nhân viên mới: {xuLy.Duyet(ma, pb, role)}.", ma);
        }
        private async void btnTuChoi_Click(object? sender, EventArgs e)
        {
            if (!LayTaiKhoan(out int ma, out byte[] pb) || !XacNhan("Từ chối yêu cầu đăng ký đang chọn?")) return;
            await ThucHien(() => { xuLy.TuChoi(ma, pb); return "Đã từ chối yêu cầu đăng ký."; }, ma);
        }
        private async void btnLuu_Click(object? sender, EventArgs e)
        {
            if (!LayTaiKhoan(out int ma, out byte[] pb) || !LayVaiTro(out int role)) return;
            string ten = txtTenDangNhap.Text.Trim();
            if (!XacNhan($"Lưu tên đăng nhập '{ten}' và vai trò {cbVaiTro.Text}?")) return;
            await ThucHien(() => { xuLy.CapNhat(ma, pb, ten, role); return "Đã lưu tên đăng nhập và vai trò."; }, ma);
        }
        private async void btnKhoa_Click(object? sender, EventArgs e)
        {
            if (!LayTaiKhoan(out int ma, out byte[] pb)) return;
            bool khoa = dongDangChon!["TrangThai"].ToString() == "Hoạt động";
            if (!XacNhan($"{(khoa ? "Khóa" : "Mở khóa")} tài khoản '{dongDangChon["TenDangNhap"]}'?")) return;
            await ThucHien(() => { xuLy.DoiTrangThai(ma, pb, khoa); return khoa ? "Đã khóa tài khoản." : "Đã mở khóa tài khoản."; }, ma);
        }
        private async void btnDatLaiMatKhau_Click(object? sender, EventArgs e)
        {
            if (!LayTaiKhoan(out int ma, out byte[] pb)) return;
            string matKhau = txtMatKhauMoi.Text;
            if (matKhau.Length < 8 || matKhau.Length > 128 || string.IsNullOrWhiteSpace(matKhau))
            { lblThongBao.Text = "Mật khẩu mới cần có từ 8 đến 128 ký tự."; return; }
            if (matKhau != txtXacNhanMatKhau.Text)
            { lblThongBao.Text = "Mật khẩu xác nhận chưa khớp."; return; }
            if (!XacNhan($"Đặt lại mật khẩu cho '{dongDangChon!["TenDangNhap"]}'?")) return;
            await ThucHien(() => { xuLy.DatLaiMatKhau(ma, pb, matKhau); return "Đã đặt lại mật khẩu."; }, ma);
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
            lblThongBao.ForeColor = Color.FromArgb(170, 60, 30);
            lblThongBao.Text = ex is SqlException sql && sql.Number < 50000
                ? sql.Number is 2601 or 2627 ? "Tên đăng nhập, số điện thoại hoặc nhân viên đã được sử dụng. Hãy tải lại danh sách."
                : sql.Number == 1205 ? "Có thao tác đồng thời. Hãy tải lại danh sách và thử lại."
                : "Không xử lý được dữ liệu. Kiểm tra kết nối và chạy Database/DangKyTaiKhoan.sql."
                : ex.Message;
        }
    }
}
