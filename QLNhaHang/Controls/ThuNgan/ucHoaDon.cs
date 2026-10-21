using QLNhaHang.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            if (dgv.Columns[tenCot] != null) dgv.Columns[tenCot].DefaultCellStyle.Format = "NO";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadHoaDon("");
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
    }
}
