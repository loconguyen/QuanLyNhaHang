using System.Data;
using Microsoft.Data.SqlClient;

namespace QLNhaHang.Classes
{
    internal static class QuanLyThucDon
    {
        private static void KiemTraQuyen()
        {
            if (Session.Role != "ADMIN") throw new UnauthorizedAccessException("Chỉ Admin được quản lý thực đơn.");
        }
        public static int Luu(int? id, string ten, int danhMuc, decimal gia, string donVi, string moTa, string trangThai)
        {
            KiemTraQuyen();
            ten = ten.Trim(); donVi = donVi.Trim(); moTa = moTa.Trim();
            if (ten.Length == 0 || ten.Length > 100 || donVi.Length == 0 || donVi.Length > 30 || moTa.Length > 255)
                throw new ArgumentException("Nhập tên món (tối đa 100 ký tự), đơn vị tính (30 ký tự) và mô tả (255 ký tự).");
            if (danhMuc <= 0 || gia < 0 || gia > 9999999999999999.99m || Array.IndexOf(TrangThaiMonAn.TatCa, trangThai) < 0)
                throw new ArgumentException("Danh mục, đơn giá hoặc trạng thái không hợp lệ.");
            using var cn = new SqlConnection(DataProcesser.strConnect);
            cn.Open();
            using var cmd = cn.CreateCommand();
            cmd.CommandText = id.HasValue
                ? @"UPDATE dbo.MON_AN SET TenMon=@ten,DanhMucID=@dm,DonGia=@gia,DonViTinh=@dv,MoTa=@mota,TrangThaiMon=@tt OUTPUT INSERTED.MonID WHERE MonID=@id;"
                : @"INSERT dbo.MON_AN(TenMon,DanhMucID,DonGia,DonViTinh,MoTa,TrangThaiMon) OUTPUT INSERTED.MonID VALUES(@ten,@dm,@gia,@dv,@mota,@tt);";
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = ten;
            cmd.Parameters.Add("@dm", SqlDbType.Int).Value = danhMuc;
            var price = cmd.Parameters.Add("@gia", SqlDbType.Decimal); price.Precision = 18; price.Scale = 2; price.Value = gia;
            cmd.Parameters.Add("@dv", SqlDbType.NVarChar, 30).Value = donVi;
            cmd.Parameters.Add("@mota", SqlDbType.NVarChar, 255).Value = moTa;
            cmd.Parameters.Add("@tt", SqlDbType.NVarChar, 30).Value = trangThai;
            if (id.HasValue) cmd.Parameters.Add("@id", SqlDbType.Int).Value = id.Value;
            object? result = cmd.ExecuteScalar();
            if (result == null) throw new InvalidOperationException("Món đã bị xóa. Hãy tải lại danh sách.");
            return Convert.ToInt32(result);
        }
        public static void Xoa(int id)
        {
            KiemTraQuyen();
            using var cn = new SqlConnection(DataProcesser.strConnect); cn.Open();
            using var cmd = new SqlCommand("DELETE FROM dbo.MON_AN WHERE MonID=@id;", cn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            try
            {
                if (cmd.ExecuteNonQuery() == 0) throw new InvalidOperationException("Món đã bị xóa. Hãy tải lại danh sách.");
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new InvalidOperationException("Món đang được tham chiếu trong dữ liệu nhà hàng nên không thể xóa. Bạn có thể sửa trạng thái thành “Ngừng bán” để giữ lịch sử đơn hàng.", ex);
            }
        }
        public static int ThemDanhMuc(string ten)
        {
            KiemTraQuyen(); ten = ten.Trim();
            if (ten.Length == 0 || ten.Length > 100) throw new ArgumentException("Tên danh mục cần từ 1 đến 100 ký tự.");
            using var cn = new SqlConnection(DataProcesser.strConnect); cn.Open();
            using var cmd = new SqlCommand("INSERT dbo.DANH_MUC_MON(TenDanhMuc) OUTPUT INSERTED.DanhMucID VALUES(@ten);", cn);
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = ten;
            try { return Convert.ToInt32(cmd.ExecuteScalar()); }
            catch (SqlException ex) when (ex.Number is 2601 or 2627) { throw new ArgumentException("Danh mục này đã tồn tại.", ex); }
        }
    }
}
