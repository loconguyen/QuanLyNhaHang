#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Linq;

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

    // MON_AN.TrangThaiMon (khớp CHECK constraint CK_Mon_TrangThai)
    public static class TrangThaiMonAn
    {
        public const string DangBan = "Đang bán";
        public const string TamHet = "Tạm hết";
        public const string NgungBan = "Ngừng bán";
        public static readonly string[] TatCa = { DangBan, TamHet, NgungBan };
    }
    // Một thông báo cho Bếp (món chờ lâu, nguyên liệu sắp hết, nguyên liệu sắp hết hạn)
    public class CanhBaoBep
    {
        public const string ChoLau = "ChoLau";
        public const string NguyenLieuSapHet = "NLSapHet";
        public const string NguyenLieuHetHan = "NLHetHan";

        public string Loai;
        public string NoiDung;
    }
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
        // Biểu thức giờ món được gửi xuống bếp: cột ThoiGianGui (sau khi chạy Setup_Bep.sql),
        // chưa có cột thì tạm dùng giờ tạo đơn (khi đó chưa tách được "gọi thêm").
        private static string _bieuThucGio;
        private static string GioGui
        {
            get
            {
                if (_bieuThucGio == null)
                {
                    try
                    {
                        Dp.DocBang("Select Top 0 ThoiGianGuiBep From CHI_TIET_DON_HANG");
                        _bieuThucGio = "Coalesce(ct.ThoiGianGuiBep, dh.ThoiGianTao)";
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.IndexOf("ThoiGianGuiBep", StringComparison.OrdinalIgnoreCase) < 0) throw;   // lỗi kết nối: không ghi nhớ
                        _bieuThucGio = "dh.ThoiGianTao";
                    }
                }
                return _bieuThucGio;
            }
        }
        // Các món của đơn đang xử lý. Có cả món "Đã phục vụ" để xác định món nào thuộc lần gọi nào
        // (màn hình chỉ hiển thị Chờ chế biến / Đang chế biến / Hoàn thành).
        public static DataTable LayMonCanCheBien()
        {
            string sql =
                "Select ct.DongID, ct.DonHangID, ct.MonID, 'DH' + Right('000' + Cast(ct.DonHangID AS VARCHAR(10)), 3) AS MaDon, " +
                "b.SoBan, dh.ThoiGianTao, " + GioGui + " AS ThoiGianGui, m.TenMon, ct.SoLuong, ct.GhiChu, ct.TrangThaiMon, " +
                "ct.TrangThaiMon AS TrangThaiText " +
                "From CHI_TIET_DON_HANG ct " +
                "Join DON_HANG dh On ct.DonHangID = dh.DonHangID " +
                "Join BAN_AN b On dh.BanID = b.BanID " +
                "Join MON_AN m On ct.MonID = m.MonID " +
                "Where dh.TrangThaiDon = " + Q(TrangThaiMon.DonDangXuLy) + " " +
                "And ct.TrangThaiMon In (" + Q(TrangThaiMon.ChoCheBien) + ", " + Q(TrangThaiMon.DangCheBien) + ", " +
                    Q(TrangThaiMon.DaHoanThanh) + ", " + Q(TrangThaiMon.DaPhucVu) + ") " +
                "Order By " + GioGui + ", ct.DonHangID, m.TenMon";
            return Dp.DocBang(sql);
        }

        // Các hàm dưới nhận DongID = CHI_TIET_DON_HANG.DongID (mỗi dòng món một mã riêng, nên cùng một món gọi nhiều lần trong một đơn vẫn tách được).

        // Chờ chế biến -> Đang chế biến (ghi giờ bắt đầu). False nếu món không còn ở trạng thái chờ.
        public static bool BatDauCheBien(int dongID)
        {
            return DoiTrangThai(new List<int> { dongID }, TrangThaiMon.ChoCheBien, TrangThaiMon.DangCheBien, "ThoiGianBatDau");
        }

        // Đang chế biến -> Hoàn thành (ghi giờ hoàn thành). False nếu món không ở trạng thái đang chế biến.
        public static bool HoanThanh(int dongID)
        {
            return DoiTrangThai(new List<int> { dongID }, TrangThaiMon.DangCheBien, TrangThaiMon.DaHoanThanh, "ThoiGianHoanThanh");
        }

        // Nhiều dòng món cùng lúc (nút "tất cả" trên thẻ)
        public static bool BatDauNhieuMon(IList<int> dongIDs)
        {
            return DoiTrangThai(dongIDs, TrangThaiMon.ChoCheBien, TrangThaiMon.DangCheBien, "ThoiGianBatDau");
        }

        public static bool HoanThanhNhieuMon(IList<int> dongIDs)
        {
            return DoiTrangThai(dongIDs, TrangThaiMon.DangCheBien, TrangThaiMon.DaHoanThanh, "ThoiGianHoanThanh");
        }

        // cotGio là tên cột do code truyền vào (không phải dữ liệu người dùng nhập)
        private static bool DoiTrangThai(IList<int> dongIDs, string tuTrangThai, string denTrangThai, string cotGio)
        {
            if (dongIDs == null || dongIDs.Count == 0) return false;
            string sql = "Update CHI_TIET_DON_HANG Set TrangThaiMon = " + Q(denTrangThai) + ", " + cotGio + " = SysDateTime() " +
                "Where DongID In (" + string.Join(", ", dongIDs) + ") And TrangThaiMon = " + Q(tuTrangThai) + " " +
                "And DonHangID In (Select DonHangID From DON_HANG Where TrangThaiDon = " + Q(TrangThaiMon.DonDangXuLy) + ")";
            return Dp.CapNhapDuLieu(sql) > 0;
        }
        public static bool CapNhatGhiChu(int dongID, string ghiChu)
        {
            string sql = "Update CHI_TIET_DON_HANG Set GhiChu = " + Q(ghiChu) +
                " Where DongID = " + dongID +
                " And TrangThaiMon In (" + Q(TrangThaiMon.ChoCheBien) + ", " + Q(TrangThaiMon.DangCheBien) + ")" +
                " And DonHangID In (Select DonHangID From DON_HANG Where TrangThaiDon = " + Q(TrangThaiMon.DonDangXuLy) + ")";
            return Dp.CapNhapDuLieu(sql) > 0;
        }

        //Thực đơn

        public static DataTable LayDanhMuc()
        {
            return Dp.DocBang("Select DanhMucID, TenDanhMuc From DANH_MUC_MON Order By TenDanhMuc Collate Vietnamese_CI_AS"); //Sắp theo theo ABC
        }
        public static DataTable LayThucDon()
        {
            const string sql = @"Select m.MonID, m.DanhMucID, m.TenMon, d.TenDanhMuc, m.DonGia, m.DonViTinh, m.MoTa, m.TrangThaiMon
                From MON_AN m
                Left Join DANH_MUC_MON d On m.DanhMucID = d.DanhMucID
                Order By d.TenDanhMuc Collate Vietnamese_CI_AS, m.TenMon Collate Vietnamese_CI_AS";
            return Dp.DocBang(sql);
        }

        // Bếp được đổi trạng thái kinh doanh của món (ví dụ hết nguyên liệu -> Tạm hết).
        public static bool CapNhatTrangThaiMonAn(int monId, string trangThai)
        {
            if (Array.IndexOf(TrangThaiMonAn.TatCa, trangThai) < 0) return false;   // chỉ nhận 3 giá trị hợp lệ
            string sql = "Update MON_AN Set TrangThaiMon = " + Q(trangThai) + " Where MonID = " + monId;
            return Dp.CapNhapDuLieu(sql) > 0;
        }

        //Nguyên liệu

        public static DataTable LayNguyenLieu()
        {
            const string sql = @"Select NguyenLieuID, TenNguyenLieu, DonViTinh, SoLuongTon, MucCanhBao, HanSuDung, TrangThai
                From NGUYEN_LIEU
                Order By TenNguyenLieu";
            return Dp.DocBang(sql);
        }

        // Bếp chỉ được sửa: SoLuongTon, MucCanhBao, HanSuDung (TrangThai tự cập nhật theo số lượng).
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
        public const int NguongPhut = 15;       // món chờ chế biến quá số phút này thì cảnh báo
        public const int NgayBaoHetHan = 7;     // nguyên liệu còn tối đa số ngày này là báo sắp hết hạn

        // Toàn bộ cảnh báo hiện có (mỗi màn hình tự lọc loại cần hiện)
        public static List<CanhBaoBep> LayCanhBao()
        {
            var ds = new List<CanhBaoBep>();
            ds.AddRange(CanhBaoChoLau());
            ds.AddRange(CanhBaoNguyenLieu());
            return ds;
        }
        // Món Chờ chế biến quá NguongPhut phút kể từ lúc Phục vụ gửi bếp (gộp theo đơn)
        private static List<CanhBaoBep> CanhBaoChoLau()
        {
            string sql =
                "Select ct.DonHangID, b.SoBan, m.TenMon, Datediff(Minute, " + GioGui + ", GetDate()) As Phut " +
                "From CHI_TIET_DON_HANG ct " +
                "Join DON_HANG dh On ct.DonHangID = dh.DonHangID " +
                "Join BAN_AN b On dh.BanID = b.BanID " +
                "Join MON_AN m On ct.MonID = m.MonID " +
                "Where dh.TrangThaiDon = " + Q(TrangThaiMon.DonDangXuLy) + " " +
                "And ct.TrangThaiMon = " + Q(TrangThaiMon.ChoCheBien) + " " +
                "And Datediff(Minute, " + GioGui + ", GetDate()) > " + NguongPhut + " " +
                "Order By Phut Desc";
            DataTable dt = Dp.DocBang(sql);

            var kq = new List<CanhBaoBep>();
            foreach (var g in dt.AsEnumerable().GroupBy(r => Convert.ToInt32(r["DonHangID"])))
            {
                var dong = g.ToList();
                int max = dong.Max(r => Convert.ToInt32(r["Phut"]));
                string ten = string.Join(", ", dong.Select(r => Convert.ToString(r["TenMon"])).Take(3).ToArray())
                             + (dong.Count > 3 ? "..." : "");
                kq.Add(new CanhBaoBep
                {
                    Loai = CanhBaoBep.ChoLau,
                    NoiDung = "Bàn " + Convert.ToString(dong[0]["SoBan"]) + " · DH" + g.Key.ToString("000") + ": " +
                              dong.Count + " món chờ chế biến quá " + NguongPhut +
                              " phút (lâu nhất " + max + " phút) - " + ten
                });
            }
            return kq;
        }
        // Nguyên liệu tồn kho ≤ mức cảnh báo, hoặc còn hạn tối đa NgayBaoHetHan ngày / đã quá hạn (khi còn tồn)
        private static List<CanhBaoBep> CanhBaoNguyenLieu()
        {
            string sql =
                "Select TenNguyenLieu, DonViTinh, SoLuongTon, MucCanhBao, HanSuDung From NGUYEN_LIEU " +
                "Where TrangThai <> " + Q("Ngừng sử dụng") + " " +
                "And (SoLuongTon <= MucCanhBao Or (HanSuDung Is Not Null And SoLuongTon > 0 " +
                "And HanSuDung <= DateAdd(Day, " + NgayBaoHetHan + ", Cast(GetDate() As Date)))) " +
                "Order By TenNguyenLieu";
            DataTable dt = Dp.DocBang(sql);

            var sapHet = new List<KeyValuePair<int, CanhBaoBep>>();
            var hetHan = new List<KeyValuePair<int, CanhBaoBep>>();
            foreach (DataRow r in dt.Rows)
            {
                string ten = Convert.ToString(r["TenNguyenLieu"]);
                string dvt = Convert.ToString(r["DonViTinh"]);
                decimal ton = Convert.ToDecimal(r["SoLuongTon"]);
                decimal mc = Convert.ToDecimal(r["MucCanhBao"]);

                if (ton <= mc)
                {
                    string nd = ton <= 0
                        ? ten + " đã HẾT HÀNG (mức cảnh báo " + mc.ToString("0.##") + " " + dvt +
                          "). Món nào dùng nguyên liệu này: vào Thực đơn chỉnh sang Tạm hết."
                        : ten + " sắp hết: còn " + ton.ToString("0.##") + " " + dvt +
                          " (dưới mức cảnh báo " + mc.ToString("0.##") + ").";
                    sapHet.Add(new KeyValuePair<int, CanhBaoBep>(ton <= 0 ? 0 : 1,
                        new CanhBaoBep { Loai = CanhBaoBep.NguyenLieuSapHet, NoiDung = nd }));
                }

                if (r["HanSuDung"] != DBNull.Value && ton > 0)
                {
                    DateTime han = Convert.ToDateTime(r["HanSuDung"]).Date;
                    int ngay = (han - DateTime.Today).Days;
                    if (ngay <= NgayBaoHetHan)
                    {
                        string nd = ngay < 0
                            ? ten + " ĐÃ HẾT HẠN từ " + han.ToString("dd/MM/yyyy") + " (quá " + (-ngay) + " ngày), còn " +
                              ton.ToString("0.##") + " " + dvt + " - cần loại bỏ."
                            : ngay == 0
                                ? ten + " HẾT HẠN HÔM NAY (" + han.ToString("dd/MM/yyyy") + "), còn " + ton.ToString("0.##") + " " + dvt + "."
                                : ten + " sắp hết hạn: " + han.ToString("dd/MM/yyyy") + " (còn " + ngay + " ngày), còn " +
                                  ton.ToString("0.##") + " " + dvt + ".";
                        hetHan.Add(new KeyValuePair<int, CanhBaoBep>(ngay,
                            new CanhBaoBep { Loai = CanhBaoBep.NguyenLieuHetHan, NoiDung = nd }));
                    }
                }
            }

            var kq = new List<CanhBaoBep>();
            kq.AddRange(sapHet.OrderBy(k => k.Key).Select(k => k.Value));
            kq.AddRange(hetHan.OrderBy(k => k.Key).Select(k => k.Value));
            return kq;
        }

        //Tổng quan

        // Số món theo trạng thái (đơn đang xử lý): cột TrangThaiMon, SoMon.
        public static DataTable DemMonTheoTrangThai()
        {
            string sql =
                "Select ct.TrangThaiMon, Count(*) As SoMon " +
                "From CHI_TIET_DON_HANG ct " +
                "Join DON_HANG dh On dh.DonHangID = ct.DonHangID " +
                "Where dh.TrangThaiDon = " + Q(TrangThaiMon.DonDangXuLy) + " " +
                "And ct.TrangThaiMon In (" + Q(TrangThaiMon.ChoCheBien) + ", " + Q(TrangThaiMon.DangCheBien) + ", " + Q(TrangThaiMon.DaHoanThanh) + ") " +
                "Group By ct.TrangThaiMon";
            return Dp.DocBang(sql);
        }

        // Các món chờ chế biến lâu nhất.
        public static DataTable LayMonChoLauNhat(int top)
        {
            int n = Math.Max(1, top);
            string sql =
                "Select Top (" + n + ") 'DH' + Right('000' + Cast(ct.DonHangID AS VARCHAR(10)), 3) AS MaDon, " +
                "b.SoBan, m.TenMon, ct.SoLuong, " +
                "Datediff(Minute, " + GioGui + ", GetDate()) As PhutCho " +
                "From CHI_TIET_DON_HANG ct " +
                "Join DON_HANG dh On ct.DonHangID = dh.DonHangID " +
                "Join BAN_AN b On dh.BanID = b.BanID " +
                "Join MON_AN m On ct.MonID = m.MonID " +
                "Where dh.TrangThaiDon = " + Q(TrangThaiMon.DonDangXuLy) + " " +
                "And ct.TrangThaiMon = " + Q(TrangThaiMon.ChoCheBien) + " " +
                "Order By " + GioGui;
            return Dp.DocBang(sql);
        }

        // Nguyên liệu sắp hết hoặc sắp/đã hết hạn(trong 7 ngày).
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
