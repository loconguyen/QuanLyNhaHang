
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using QLNhaHang.Classes;

namespace QLNhaHang.Controls.ThuNgan
{
    public partial class ucThanhToan : UserControl
    {
        private readonly DataProcesser db = new DataProcesser();

        public ucThanhToan()
        {
            InitializeComponent();

            // Không xóa Items của cbPhuongThuc
            // vì phương thức thanh toán đã được khai báo trong Designer.
        }

        private void ucHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDonChuaThanhToan();
        }

        // Tải danh sách hóa đơn chưa thanh toán
        public void LoadHoaDonChuaThanhToan()
        {
            try
            {
                string sql = @"
                    select HoaDonID
                    from HOA_DON
                    where TrangThaiThanhToan = N'Chưa thanh toán'
                    order by HoaDonID desc";

                DataTable dt = db.DocBang(sql);

                cbMaHD.DataSource = null;
                cbMaHD.DisplayMember = "HoaDonID";
                cbMaHD.ValueMember = "HoaDonID";
                cbMaHD.DataSource = dt;
                cbMaHD.SelectedIndex = -1;

                dgvChiTiet.DataSource = null;

                txtTrangThai.Clear();
                txtTongTien.Clear();
                txtGiamGia.Clear();
                txtThanhTien.Clear();

                cbPhuongThuc.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải danh sách hóa đơn: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Khi chọn hóa đơn, tải thông tin và chi tiết hóa đơn
        private void cbMaHD_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (cbMaHD.SelectedValue == null ||
                cbMaHD.SelectedValue is DataRowView)
            {
                return;
            }

            if (!int.TryParse(
                cbMaHD.SelectedValue.ToString(),
                out int hoaDonID))
            {
                return;
            }

            try
            {
                string sql = $@"
                    select HoaDonID, DonHangID, TongTien,
                           GiamGia, ThanhTien, TrangThaiThanhToan
                    from HOA_DON
                    where HoaDonID = {hoaDonID}";

                DataTable dt = db.DocBang(sql);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }

                DataRow row = dt.Rows[0];

                decimal tongTien = row["TongTien"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(row["TongTien"]);

                decimal giamGiaTien = row["GiamGia"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(row["GiamGia"]);

                decimal thanhTien = row["ThanhTien"] == DBNull.Value
                    ? tongTien - giamGiaTien
                    : Convert.ToDecimal(row["ThanhTien"]);

                // Hiển thị số tiền, không phải phần trăm
                txtTongTien.Text = tongTien.ToString("N0");
                txtGiamGia.Text = giamGiaTien.ToString("N0");
                txtThanhTien.Text = thanhTien.ToString("N0");

                txtTrangThai.Text =
                    row["TrangThaiThanhToan"].ToString();

                LoadChiTietHoaDon(hoaDonID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải thông tin hóa đơn: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Tải chi tiết món ăn của hóa đơn
        private void LoadChiTietHoaDon(int hoaDonID)
        {
            string sql = $@"
                select
                    ma.TenMon as [Tên món],
                    ct.SoLuong as [Số lượng],
                    ct.DonGia as [Đơn giá],
                    ct.SoLuong * ct.DonGia as [Thành tiền],
                    ct.TrangThaiMon as [Trạng thái món]
                from HOA_DON hd
                join CHI_TIET_DON_HANG ct
                    on hd.DonHangID = ct.DonHangID
                join MON_AN ma
                    on ct.MonID = ma.MonID
                where hd.HoaDonID = {hoaDonID}
                    and ct.TrangThaiMon <> N'Đã hủy'
                order by ma.TenMon";

            try
            {
                DataTable dt = db.DocBang(sql);

                dgvChiTiet.AutoGenerateColumns = true;
                dgvChiTiet.DataSource = dt;

                if (dgvChiTiet.Columns["Đơn giá"] != null)
                {
                    dgvChiTiet.Columns["Đơn giá"]
                        .DefaultCellStyle.Format = "N0";
                }

                if (dgvChiTiet.Columns["Thành tiền"] != null)
                {
                    dgvChiTiet.Columns["Thành tiền"]
                        .DefaultCellStyle.Format = "N0";
                }

                if (dgvChiTiet.Columns["Số lượng"] != null)
                {
                    dgvChiTiet.Columns["Số lượng"]
                        .DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải chi tiết hóa đơn: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Tự động tính thành tiền khi thay đổi số tiền giảm giá
        private void txtGiamGia_TextChanged(
            object sender, EventArgs e)
        {
            if (!decimal.TryParse(
                txtTongTien.Text,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out decimal tongTien))
            {
                return;
            }

            decimal giamGiaTien = 0;

            if (!string.IsNullOrWhiteSpace(txtGiamGia.Text))
            {
                if (!decimal.TryParse(
                    txtGiamGia.Text,
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out giamGiaTien))
                {
                    txtThanhTien.Clear();
                    return;
                }
            }

            if (giamGiaTien < 0 || giamGiaTien > tongTien)
            {
                txtThanhTien.Clear();
                return;
            }

            decimal thanhTien = tongTien - giamGiaTien;

            txtThanhTien.Text = thanhTien.ToString("N0");
        }

        // Xác nhận thanh toán
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (cbMaHD.SelectedValue == null ||
                cbMaHD.SelectedValue is DataRowView)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn.");
                return;
            }

            if (!int.TryParse(
                cbMaHD.SelectedValue.ToString(),
                out int hoaDonID))
            {
                MessageBox.Show("Mã hóa đơn không hợp lệ.");
                return;
            }

            if (cbPhuongThuc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán.");
                return;
            }

            if (!decimal.TryParse(
                txtTongTien.Text,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out decimal tongTien))
            {
                MessageBox.Show("Tổng tiền không hợp lệ.");
                return;
            }

            decimal giamGiaTien = 0;

            if (!string.IsNullOrWhiteSpace(txtGiamGia.Text))
            {
                if (!decimal.TryParse(
                    txtGiamGia.Text,
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out giamGiaTien))
                {
                    MessageBox.Show("Số tiền giảm giá không hợp lệ.");
                    return;
                }
            }

            if (giamGiaTien < 0 || giamGiaTien > tongTien)
            {
                MessageBox.Show(
                    "Tiền giảm giá phải từ 0 đến tổng tiền hóa đơn.");
                return;
            }

            if (Session.NhanVienID <= 0)
            {
                MessageBox.Show(
                    "Không xác định được nhân viên đăng nhập.");
                return;
            }

            decimal thanhTien = tongTien - giamGiaTien;

            string giamGiaSql =
                giamGiaTien.ToString(CultureInfo.InvariantCulture);

            string thanhTienSql =
                thanhTien.ToString(CultureInfo.InvariantCulture);

            string phuongThuc = cbPhuongThuc
                .GetItemText(cbPhuongThuc.SelectedItem)
                .Replace("'", "''");

            DialogResult xacNhan = MessageBox.Show(
                "Tổng tiền: " + tongTien.ToString("N0") + " đồng\n" +
                "Giảm giá: " + giamGiaTien.ToString("N0") + " đồng\n" +
                "Thành tiền: " + thanhTien.ToString("N0") + " đồng\n\n" +
                "Bạn có chắc chắn muốn xác nhận thanh toán?",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            string sql = $@"
                update HOA_DON
                set GiamGia = {giamGiaSql},
                    ThanhTien = {thanhTienSql},
                    PhuongThucThanhToan = N'{phuongThuc}',
                    TrangThaiThanhToan = N'Đã thanh toán'
                where HoaDonID = {hoaDonID}
                    and TrangThaiThanhToan = N'Chưa thanh toán'";

            try
            {
                int ketQua = db.CapNhapDuLieu(sql);

                if (ketQua > 0)
                {
                    MessageBox.Show(
                        "Thanh toán thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadHoaDonChuaThanhToan();
                }
                else
                {
                    MessageBox.Show(
                        "Không cập nhật được hóa đơn. " +
                        "Hóa đơn có thể đã được thanh toán trước đó.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi thanh toán: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
