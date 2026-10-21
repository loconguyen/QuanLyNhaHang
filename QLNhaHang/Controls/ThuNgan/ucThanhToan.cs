using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            cbPhuongThuc.Items.Clear();

        }

        private void ucHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDonChuaThanhToan();
        }
        public void LoadHoaDonChuaThanhToan()
        {
            string sql = @"select HoaDonID from HOA_DON
                where TrangThaiThanhToan=N'Chưa thanh toán'
                order by HoaDonID desc";
            DataTable dt = db.DocBang(sql);
            cbMaHD.DataSource = dt;
            cbMaHD.DisplayMember = "HoaDonID";
            cbMaHD.ValueMember = "HoaDonID";
            cbMaHD.SelectedIndex = -1;

            dgvChiTiet.DataSource = null;
            txtTrangThai.Clear();
            txtTongTien.Clear();
            txtGiamGia.Clear();
            txtThanhTien.Clear();
            cbPhuongThuc.SelectedIndex = -1;

        }

        private void cbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaHD.SelectedValue == null || cbMaHD.SelectedValue is DataRowView) { return; }
            if (!int.TryParse(cbMaHD.SelectedValue.ToString(), out int hoaDonID)) { return; }
            string sql = $@"select HoaDonID, DonHangID,TongTien, GiamGia, ThanhTien,TrangThaiThanhToan
                from HOA_DON
                where HoaDonID = {hoaDonID}";
            DataTable dt = db.DocBang(sql);
            if (dt.Rows.Count == 0) { return; }
            DataRow row = dt.Rows[0];
            decimal tongTien = Convert.ToDecimal(row["TongTien"]);
            decimal giamGiaTien = Convert.ToDecimal(row["GiamGia"]);
            txtTongTien.Text = tongTien.ToString("NO");

            decimal phamTramGiam = tongTien > 0 ? giamGiaTien * 100 / tongTien : 0;
            txtGiamGia.Text = phamTramGiam.ToString("0.##");
            txtThanhTien.Text = Convert.ToDecimal(row["ThanhTien"]).ToString("NO");
            txtTrangThai.Text = row["TrangThaiThanhToan"].ToString();
            LoadChiTietHoaDon(hoaDonID);
        }
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
                join CHI_TIET_DON_HANG ct on hd.DonHangID = ct.DonHangID
                join MON_AN ma on ct.MonID = ma.MonID
                where hd.HoaDonID = {hoaDonID} and ct.TrangThaiMon <> N'Đã hủy'
                order by ma.TenMon";
            dgvChiTiet.DataSource = db.DocBang(sql);
            if (dgvChiTiet.Columns["Đơn giá"] != null) dgvChiTiet.Columns["Đơn giá"].DefaultCellStyle.Format = "NO";
            if (dgvChiTiet.Columns["Thành tiền"] != null) dgvChiTiet.Columns["Thành tiền"].DefaultCellStyle.Format = "NO";
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTongTien.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal tongTien)) return;
            if (!decimal.TryParse(txtGiamGia.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal phanTramGiam))
            {
                if (string.IsNullOrWhiteSpace(txtGiamGia.Text)) phanTramGiam = 0;
                else
                {
                    txtThanhTien.Clear();
                    return;
                }
            }
            if (phanTramGiam < 0 || phanTramGiam > 100)
            {
                txtThanhTien.Clear();
                return;
            }
            decimal thanhTien = tongTien - (tongTien * phanTramGiam) / 100;
            txtThanhTien.Text = thanhTien.ToString("NO");
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(cbMaHD.SelectedValue==null||cbMaHD.SelectedValue is DataRowView)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
                return;
            }
            if(!int.TryParse(cbMaHD.SelectedValue.ToString(), out int hoaDonID))
            {
                MessageBox.Show("Mã hóa đơn không hợp lệ");
                return;
            }
            if (cbPhuongThuc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui long chọn phương thức thanh toán");
                return;
            }
            if (!decimal.TryParse(
                txtTongTien.Text,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out decimal tongTien))
            {
                MessageBox.Show("Tổng tiền không hợp lệ!");
                return;
            }
            if (!decimal.TryParse(txtGiamGia.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal phanTramGiam))
            {
                if (string.IsNullOrWhiteSpace(txtGiamGia.Text)) phanTramGiam = 0;
                else
                {
                    MessageBox.Show("Phần trăm giảm giá không hợp lệ!");
                    return;
                }
            }
            if (phanTramGiam < 0 || phanTramGiam > 100)
            {
                MessageBox.Show("Giảm giá phải từ 0 đến 100%!");
                return;
            }
            if (Session.NhanVienID <= 0)
            {
                MessageBox.Show("Không xác định được nhân viên đăng nhập!");
                return;
            }

            decimal giamGiaTien = tongTien * phanTramGiam / 100;
            string giamGiaSql=giamGiaTien.ToString(CultureInfo.InvariantCulture);
            string phuongThuc = cbPhuongThuc.SelectedItem.ToString().Replace("'", "''");
            DialogResult xacNhan = MessageBox.Show("Bạn có chắc chắn muốn xác nhận thanh toán?","Xác nhận thanh toán",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(xacNhan != DialogResult.Yes) return;
            string sql = $@"
                update HOA_DON
                set GiamGia = {giamGiaSql},
                    PhuongThucThanhToan = N'{phuongThuc}',
                    TrangThaiThanhToan = N'Đã thanh toán'
                where HoaDonID = {hoaDonID} and TrangThaiThanhToan = N'Chưa thanh toán'";
            try
            {
                int ketQua = db.CapNhapDuLieu(sql);

                if (ketQua > 0)
                {
                    MessageBox.Show("Thanh toán thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadHoaDonChuaThanhToan();
                }
                else
                {
                    MessageBox.Show("Không cập nhật được hóa đơn. " +
                        "Hóa đơn có thể đã được thanh toán trước đó.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi thanh toán: " + ex.Message);
            }
        }
    }

}
