using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace QLNhaHang.Classes
{
    public static class TrangThaiMon
    {
        public const string ChuaGuiBep = "Chưa gửi bếp";
        public const string ChoCheBien = "Chờ chế biến";
        public const string DangCheBien = "Đang chế biến";
        public const string DaHoanThanh = "Hoàn thành";
        public const string DaPhucVu = "Đã phục vụ";
        public const string DaHuy = "Đã hủy";
        public const string DonDangXuLy = "Đang xử lý";
    }
    // Mỗi lần gọi dùng một DataProcesser mới (mỗi đối tượng giữ 1 kết nối riêng)
    // Bếp chỉ được: xem đơn, đổi trạng thái món (theo quy trình), sửa ghi chú,
    // xem thực đơn, cập nhật tồn kho / mức cảnh báo / hạn sử dụng nguyên liệu.
    // Không đọc cột DonGia của chi tiết đơn.
    public static class BepRepository
    {
        // Mỗi lần gọi dùng một DataProcesser mới(mỗi đối tượng giữ 1 kết nối riêng)
        private static DataProcesser Dp
        {
            get { return new DataProcesser(); }
        }
        private static string Q(string s)
        {
            if (s == null) return "NULL";
            return "N'" + s.Replace("'", "''") + "'";
        }

        //Số thập phân -> chuỗi dùng dấu chấm, không phụ thuộc ngôn ngữ Windows.
        private static string Num(decimal d)
        {
            return d.ToString("0.00", CultureInfo.InvariantCulture);
        }
        private static string Ngay(DateTime? d)
        {
            return d.HasValue ? "'" + d.Value.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + "'" : "NULL";
        }

        //Chế biến
        public static DataTable LayMonCanCheBien()
        {
            string sql =
                "Select ct.DonHangID, ct.MonID, 'DH' + Right('000' + Cast(ct.DonHangID AS VARCHAR(10)), 3) AS MaDon, " +
                "b.SoBan, dh.ThoiGianTao, m.TenMon, ct.SoLuong, ct.GhiChu, ct.TrangThaiMon, " +
                "ct.TrangThaiMon AS TrangThaiText " +
                "From CHI_TIET_DON_HANG ct " +
                "Join DON_HANG dh On ct.DonHangID = dh.DonHangID " +
                "Join BAN_AN b On dh.BanID = b.BanID " +
                "Join MON_AN m On ct.MonID = m.MonID " +
                "Where dh.TrangThaiDon = " + Q(TrangThaiMon.DonDangXuLy) + " " +
                "And ct.TrangThaiMon In (" + Q(TrangThaiMon.ChoCheBien) + ", " + Q(TrangThaiMon.DangCheBien) + ", " + Q(TrangThaiMon.DaHoanThanh) + ") " +
                "Order By Case ct.TrangThaiMon " +
                "When " + Q(TrangThaiMon.DangCheBien) + " Then 1 " +
                "When " + Q(TrangThaiMon.ChoCheBien) + " Then 2 " +
                "Else 3 End, " +
                "dh.ThoiGianTao, ct.DonHangID, m.TenMon";
            return Dp.DocBang(sql);
        }

        //CHO_CHE_BIEN -> DANG_CHE_BIEN. False nếu món không còn ở trạng thái chờ.

        public static bool BatDauCheBien(int donHangID, int monID)
        {
            string sql = "Update CHI_TIET_DON_HANG Set TrangThaiMon = " + Q(TrangThaiMon.DangCheBien) +
                " Where DonHangID = " + donHangID + " And MonID = " + monID + " And TrangThaiMon = " + Q(TrangThaiMon.ChoCheBien) +
                " And DonHangID In(Select DonHangID From DON_HANG Where TrangThaiDon = " + Q(TrangThaiMon.DonDangXuLy) + ")";
            return Dp.CapNhapDuLieu(sql) > 0;
        }

        //DANG_CHE_BIEN -> DA_HOAN_THANH. False nếu món không ở trạng thái đang chế biến.

        public static bool HoanThanh(int donHangID, int monID)
        {
            string sql = "Update CHI_TIET_DON_HANG Set TrangThaiMon = " + Q(TrangThaiMon.DaHoanThanh) +
                " Where DonHangID = " + donHangID + " And MonID = " + monID +
                " And TrangThaiMon = " + Q(TrangThaiMon.DangCheBien) +
                " And DonHangID In (Select DonHangID From DON_HANG Where TrangThaiDon = " + Q(TrangThaiMon.DonDangXuLy) + ")";
            return Dp.CapNhapDuLieu(sql) > 0;
        }

        public static bool CapNhatGhiChu(int donHangID, int monID, string ghiChu)
        {
            string sql = "Update CHI_TIET_DON_HANG Set GhiChu = " + Q(ghiChu) +
                " Where DonHangID = " + donHangID + " And MonID = " + monID +
                " And TrangThaiMon In (" + Q(TrangThaiMon.ChoCheBien) + ", " + Q(TrangThaiMon.DangCheBien) + ")" +
                " And DonHangID In (Select DonHangID From DON_HANG Where TrangThaiDon = " + Q(TrangThaiMon.DonDangXuLy) + ")";
            return Dp.CapNhapDuLieu(sql) > 0;
        }

        //Thực đơn

        public static DataTable LayDanhMuc()
        {
            return Dp.DocBang("Select DanhMucID, TenDanhMuc From DANH_MUC_MON Order By TenDanhMuc");
        }
        public static DataTable LayThucDon()
        {
            const string sql = @"Select m.MonID, m.DanhMucID, m.TenMon, d.TenDanhMuc, m.DonGia, m.DonViTinh, m.MoTa, m.TrangThaiMon
                From MON_AN m
                Left Join DANH_MUC_MON d On m.DanhMucID = d.DanhMucID
                Order By d.TenDanhMuc, m.TenMon";
            return Dp.DocBang(sql);
        }

        //Nguyên liệu

        public static DataTable LayNguyenLieu()
        {
            const string sql = @"Select NguyenLieuID, TenNguyenLieu, DonViTinh, SoLuongTon, MucCanhBao, HanSuDung, TrangThai
                From NGUYEN_LIEU
                Order By TenNguyenLieu";
            return Dp.DocBang(sql);
        }

        //Bếp chỉ được sửa: SoLuongTon, MucCanhBao, HanSuDung.

        public static bool CapNhatNguyenLieu(int id, decimal soLuongTon, decimal mucCanhBao, DateTime? hanSuDung)
        {
            string ton = Num(soLuongTon), cb = Num(mucCanhBao);
            string sql = "Update NGUYEN_LIEU Set SoLuongTon = " + ton + ", MucCanhBao = " + cb +
                ", HanSuDung = " + Ngay(hanSuDung) +
                ", TrangThai = Case When TrangThai = N'Ngừng sử dụng' Then TrangThai" +
                " When " + ton + " <= 0 Then N'Hết hàng'" +
                " When " + ton + " <= " + cb + " Then N'Sắp hết'" +
                " Else N'Còn hàng' End" +
                " Where NguyenLieuID = " + id;
            return Dp.CapNhapDuLieu(sql) > 0;
        }

        //Tổng quan

        //Số món theo trạng thái (đơn đang xử lý): cột TrangThaiMon, SoMon.
        public static DataTable DemMonTheoTrangThai()
        {
            string sql = $@"Select ct.TrangThaiMon, Count(*) As SoMon
                From CHI_TIET_DON_HANG ct
                Join DON_HANG dh On dh.DonHangID = ct.DonHangID
                Where dh.TrangThaiDon = {Q(TrangThaiMon.DonDangXuLy)}
                    And ct.TrangThaiMon In ({Q(TrangThaiMon.ChoCheBien)}, {Q(TrangThaiMon.DangCheBien)}, {Q(TrangThaiMon.DaHoanThanh)})
                Group By ct.TrangThaiMon";
            return Dp.DocBang(sql);
        }

        //Các món chờ chế biến lâu nhất.
        public static DataTable LayMonChoLauNhat(int top)
        {
            int n = Math.Max(1, top);
            string sql = $@"Select Top ({n}) 'DH' + Right('000' + Cast(ct.DonHangID AS VARCHAR(10)), 3) AS MaDon,
                b.SoBan, m.TenMon, ct.SoLuong,
                Datediff(Minute, dh.ThoiGianTao, GetDate()) As PhutCho
                From CHI_TIET_DON_HANG ct
                Join DON_HANG dh On ct.DonHangID = dh.DonHangID
                Join BAN_AN b On dh.BanID = b.BanID
                Join MON_AN m On ct.MonID = m.MonID
                Where dh.TrangThaiDon = {Q(TrangThaiMon.DonDangXuLy)}
                    And ct.TrangThaiMon = {Q(TrangThaiMon.ChoCheBien)}
                Order By dh.ThoiGianTao";
            return Dp.DocBang(sql);
        }

        //Nguyên liệu sắp hết hoặc sắp/đã hết hạn (trong 7 ngày).

        public static DataTable LayNguyenLieuCanChuY()
        {
            const string sql = @"Select TenNguyenLieu, DonViTinh, SoLuongTon, MucCanhBao, HanSuDung,
                Case
                    When HanSuDung Is Not Null And HanSuDung < Cast(GetDate() As Date) Then N'Đã hết hạn'
                    When SoLuongTon <= MucCanhBao Then N'Sắp hết hàng'
                    Else N'Sắp hết hạn' End As LyDo
                From NGUYEN_LIEU
                Where SoLuongTon <= MucCanhBao Or (HanSuDung Is Not Null And HanSuDung <= DateAdd(Day, 7, Cast(GetDate() As Date)))
                Order By TenNguyenLieu";
            return Dp.DocBang(sql);
        }
    }
}
