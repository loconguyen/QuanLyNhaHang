using QLNhaHang.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using Microsoft.VisualBasic;
using System.IO;
using System.Text;

namespace QLNhaHang.Controls.ThuNgan
{
    public partial class ucHoaDon : UserControl
    {
        private readonly DataProcesser db = new DataProcesser();
        public ucHoaDon()
        {
            InitializeComponent();
        }

        private void ucHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon("");
            LoadDonHangChuaCoHoaDon();
        }
        public void LoadHoaDon(string tuKhoa)
        {
            string dieuKien = "";
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                if (!int.TryParse(tuKhoa, out int ma))
                {
                    MessageBox.Show("Mã hóa đơn phải là số");
                    return;
                }
                dieuKien = $@"and (hd.HoaDonID = {ma} or hd.DonHangID = {ma})";
            }
            string sql = $@"
                select
                    hd.HoaDonID as [Mã hóa đơn],
                    hd.DonHangID as [Mã đơn hàng],
                    hd.NgayLap as [Ngày lập],
                    hd.TongTien as [Tổng tiền],
                    hd.GiamGia as [Giảm giá],
                    hd.ThanhTien as [Thành tiền],
                    hd.PhuongThucThanhToan as [Phương thức thanh toán],
                    hd.TrangThaiThanhToan as [Trạng thái]
                from HOA_DON hd
                where 1 = 1
                {dieuKien}
                order by hd.HoaDonID desc";
            try
            {
                dgvHoaDon.DataSource = db.DocBang(sql);
                dgvChiTietHD.DataSource = null;
                DinhDangTien(dgvHoaDon, "Tổng tiền");
                DinhDangTien(dgvHoaDon, "Giảm giá");
                DinhDangTien(dgvHoaDon, "Thành tiền");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn");
            }
        }
        private void DinhDangTien(DataGridView dgv, string tenCot)
        {
            if (dgv.Columns[tenCot] != null) dgv.Columns[tenCot].DefaultCellStyle.Format = "N0";
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                LoadHoaDon("");
                return;
            }

            if (!int.TryParse(tuKhoa, out int ma))
            {
                MessageBox.Show(
                    "Vui lòng nhập mã hóa đơn hoặc mã đơn hàng là số!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTimKiem.Focus();
                txtTimKiem.SelectAll();
                return;
            }

            LoadHoaDon(ma.ToString());
        }


        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            object giaTri = dgvHoaDon.Rows[e.RowIndex].Cells["Mã hóa đơn"].Value;
            if (giaTri == null || !int.TryParse(giaTri.ToString(), out int hoaDonID)) return;
            LoadChiTietHoaDon(hoaDonID);
        }
        private void LoadChiTietHoaDon(int hoaDonID)
        {
            string sql = $@"
                select
                    ma.TenMon AS [Tên món],
                    ct.SoLuong AS [Số lượng],
                    ct.DonGia AS [Đơn giá],
                    ct.SoLuong * ct.DonGia AS [Thành tiền],
                    ct.TrangThaiMon AS [Trạng thái món]
                from HOA_DON hd
                join CHI_TIET_DON_HANG ct on hd.DonHangID = ct.DonHangID
                join MON_AN ma on ct.MonID = ma.MonID
                where hd.HoaDonID = {hoaDonID}
                order by ma.TenMon";

            try
            {
                dgvChiTietHD.DataSource = db.DocBang(sql);

                DinhDangTien(dgvChiTietHD, "Đơn giá");
                DinhDangTien(dgvChiTietHD, "Thành tiền");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải chi tiết hóa đơn:\n" + ex.Message);
            }
        }
        private void LoadDonHangChuaCoHoaDon()
        {
            string sql = @"
                select dh.DonHangID
                from DON_HANG dh
                where not exists
                (
                    select 1
                    from HOA_DON hd
                    where hd.DonHangID = dh.DonHangID
                )
                and dh.TrangThaiDon = N'Hoàn thành'
                order by dh.DonHangID";

            try
            {
                DataTable dt = db.DocBang(sql);

                cbDonHang.DataSource = dt;
                cbDonHang.DisplayMember = "DonHangID";
                cbDonHang.ValueMember = "DonHangID";
                cbDonHang.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách đơn hàng: " + ex.Message);
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đã chọn đơn hàng chưa
            if (cbDonHang.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn đơn hàng cần tạo hóa đơn!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy mã đơn hàng
            if (!int.TryParse(cbDonHang.SelectedValue.ToString(), out int donHangID))
            {
                MessageBox.Show("Mã đơn hàng không hợp lệ!");
                return;
            }

            // 3. Lấy mã nhân viên thu ngân đang đăng nhập
            int thuNganID = Session.NhanVienID;

            if (thuNganID <= 0)
            {
                MessageBox.Show(
                    "Không xác định được nhân viên thu ngân. Vui lòng đăng nhập lại!");
                return;
            }

            // 4. Xác nhận trước khi tạo hóa đơn
            DialogResult xacNhan = MessageBox.Show(
                "Bạn có muốn tạo hóa đơn cho đơn hàng "
                + donHangID + " không?",
                "Xác nhận tạo hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            // 5. Tạo hóa đơn trong cơ sở dữ liệu
            string sql = $@"
                insert into HOA_DON
                (
                    DonHangID,
                    ThuNganID,
                    NgayLap,
                    TongTien,
                    GiamGia,
                    ThanhTien,
                    TrangThaiThanhToan
                )
                select
                    dh.DonHangID,
                    {thuNganID},
                    getdate(),
                    coalesce(sum(ct.SoLuong * ct.DonGia), 0),
                    0,
                    coalesce(sum(ct.SoLuong * ct.DonGia), 0),
                    N'Chưa thanh toán'
                from DON_HANG dh
                left join CHI_TIET_DON_HANG ct
                    on dh.DonHangID = ct.DonHangID
                    and ct.TrangThaiMon <> N'Đã hủy'
                where dh.DonHangID = {donHangID}
                    and dh.TrangThaiDon = N'Hoàn thành'
                    and not exists
                    (
                        select 1
                        from HOA_DON hd
                        where hd.DonHangID = dh.DonHangID
                    )
                group by dh.DonHangID;";

            try
            {
                int ketQua = db.CapNhapDuLieu(sql);

                if (ketQua > 0)
                {
                    MessageBox.Show(
                        "Tạo hóa đơn thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // 6. Tải lại danh sách hóa đơn
                    LoadHoaDon("");

                    // 7. Cập nhật danh sách đơn hàng chưa có hóa đơn
                    LoadDonHangChuaCoHoaDon();
                }
                else
                {
                    MessageBox.Show(
                        "Không tạo được hóa đơn!\n"
                        + "Đơn hàng có thể chưa hoàn thành "
                        + "hoặc đã có hóa đơn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tạo hóa đơn:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra hóa đơn được chọn
            if (dgvHoaDon.CurrentRow == null ||
                dgvHoaDon.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!");
                return;
            }

            if (!int.TryParse(
                Convert.ToString(
                    dgvHoaDon.CurrentRow.Cells["Mã hóa đơn"].Value),
                out int hoaDonID))
            {
                MessageBox.Show("Mã hóa đơn không hợp lệ!");
                return;
            }

            try
            {
                // 2. Lấy thông tin hóa đơn từ SQL
                string sqlKiemTra = $@"
                    select TongTien, GiamGia, TrangThaiThanhToan
                    from HOA_DON
                    where HoaDonID = {hoaDonID}";

                DataTable dt = db.DocBang(sqlKiemTra);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!");
                    return;
                }

                DataRow hoaDon = dt.Rows[0];

                // 3. Chỉ cho sửa hóa đơn chưa thanh toán
                if (hoaDon["TrangThaiThanhToan"] == DBNull.Value ||
                    hoaDon["TrangThaiThanhToan"].ToString()
                        != "Chưa thanh toán")
                {
                    MessageBox.Show(
                        "Không thể sửa hóa đơn đã thanh toán!");
                    return;
                }

                decimal tongTien = Convert.ToDecimal(hoaDon["TongTien"]);

                decimal giamGiaHienTai = hoaDon["GiamGia"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(hoaDon["GiamGia"]);

                // 4. Nhập số tiền giảm giá
                string nhap = Interaction.InputBox(
                    "Nhập số tiền giảm giá (VNĐ).\n"
                    + "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ",
                    "Sửa hóa đơn",
                    giamGiaHienTai.ToString(
                        CultureInfo.InvariantCulture));

                if (string.IsNullOrWhiteSpace(nhap))
                    return;

                // Hỗ trợ nhập số tiền có dấu chấm hoặc dấu phẩy
                nhap = nhap.Trim()
                           .Replace(".", "")
                           .Replace(",", "");

                if (!decimal.TryParse(
                    nhap,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal giamGia))
                {
                    MessageBox.Show(
                        "Số tiền giảm giá không hợp lệ! "
                        + "Vui lòng nhập số nguyên, ví dụ: 20000.");
                    return;
                }

                // 5. Kiểm tra mức giảm giá
                if (giamGia < 0 || giamGia > tongTien)
                {
                    MessageBox.Show(
                        "Tiền giảm giá phải từ 0 đến tổng tiền hóa đơn!");
                    return;
                }

                // 6. Tính thành tiền
                decimal thanhTien = tongTien - giamGia;

                string giamGiaSql =
                    giamGia.ToString(CultureInfo.InvariantCulture);

                string thanhTienSql =
                    thanhTien.ToString(CultureInfo.InvariantCulture);

                // 7. Cập nhật hóa đơn chưa thanh toán
                string sql = $@"
            update HOA_DON
            set GiamGia = {giamGiaSql},
                ThanhTien = {thanhTienSql}
            where HoaDonID = {hoaDonID}
                and TrangThaiThanhToan = N'Chưa thanh toán'";

                int ketQua = db.CapNhapDuLieu(sql);

                if (ketQua > 0)
                {
                    MessageBox.Show(
                        "Sửa hóa đơn thành công!\n"
                        + "Giảm giá: " + giamGia.ToString("N0") + " VNĐ\n"
                        + "Thành tiền: " + thanhTien.ToString("N0") + " VNĐ");

                    LoadHoaDon("");
                }
                else
                {
                    MessageBox.Show(
                        "Không sửa được hóa đơn. "
                        + "Có thể hóa đơn đã được thanh toán.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi sửa hóa đơn: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count == 0 ||
                (dgvHoaDon.Rows.Count == 1 &&
                 dgvHoaDon.Rows[0].IsNewRow))
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Excel (*.csv)|*.csv";
                sfd.FileName = "DanhSachHoaDon.csv";
                sfd.Title = "Chọn nơi lưu danh sách hóa đơn";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (StreamWriter sw = new StreamWriter(
                        sfd.FileName, false, new UTF8Encoding(true)))
                    {
                        // Xuất tiêu đề cột
                        for (int i = 0; i < dgvHoaDon.Columns.Count; i++)
                        {
                            if (i > 0) sw.Write(",");

                            sw.Write("\"" +
                                dgvHoaDon.Columns[i].HeaderText
                                    .Replace("\"", "\"\"") +
                                "\"");
                        }

                        sw.WriteLine();

                        // Xuất dữ liệu đang hiển thị trong dgvHoaDon
                        foreach (DataGridViewRow row in dgvHoaDon.Rows)
                        {
                            if (row.IsNewRow) continue;

                            for (int i = 0; i < dgvHoaDon.Columns.Count; i++)
                            {
                                if (i > 0) sw.Write(",");

                                string giaTri =
                                    Convert.ToString(row.Cells[i].Value) ?? "";

                                sw.Write("\"" +
                                    giaTri.Replace("\"", "\"\"") +
                                    "\"");
                            }

                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show(
                        "Xuất danh sách hóa đơn thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message);
                }
            }
        }
    }
}
