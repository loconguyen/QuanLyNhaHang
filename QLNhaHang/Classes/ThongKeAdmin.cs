using System.Data;
using Microsoft.Data.SqlClient;

namespace QLNhaHang.Classes
{
    // Read-only dashboard queries. Dates use an exclusive upper bound so the whole final day is included.
    internal static class ThongKeAdmin
    {
        public static async Task<DataSet> TaiAsync(DateTime tuNgay, DateTime denNgay)
        {
            if (Session.Role != "ADMIN") throw new UnauthorizedAccessException("Chỉ Admin được xem thống kê.");
            if (tuNgay.Date > denNgay.Date) throw new ArgumentException("Ngày bắt đầu phải trước hoặc bằng ngày kết thúc.");
            using var connection = new SqlConnection(DataProcesser.strConnect);
            await connection.OpenAsync();
            using var command = connection.CreateCommand();
            command.CommandTimeout = 30;
            command.Parameters.Add("@tu", SqlDbType.DateTime2).Value = tuNgay.Date;
            command.Parameters.Add("@den", SqlDbType.DateTime2).Value = denNgay.Date.AddDays(1);
            command.CommandText = @"
-- Materialize paid invoices once; every revenue chart uses the same population.
SELECT h.DonHangID, h.ThanhTien, h.PhuongThucThanhToan,
       ISNULL(h.NgayThanhToan, h.NgayLap) AS NgayThu
INTO #DaThu FROM dbo.HOA_DON h
WHERE h.TrangThaiThanhToan = N'Đã thanh toán'
  AND ISNULL(h.NgayThanhToan,h.NgayLap) >= @tu
  AND ISNULL(h.NgayThanhToan,h.NgayLap) < @den;

SELECT ISNULL((SELECT SUM(ThanhTien) FROM #DaThu),0) AS DoanhThu,
 (SELECT COUNT(*) FROM dbo.DON_HANG WHERE ThoiGianTao>=@tu AND ThoiGianTao<@den) AS SoDon,
 ISNULL((SELECT SUM(CAST(c.SoLuong AS BIGINT)) FROM dbo.CHI_TIET_DON_HANG c
 JOIN #DaThu t ON t.DonHangID=c.DonHangID WHERE c.TrangThaiMon<>N'Đã hủy'),0) AS SoMon;

;WITH Tien AS (SELECT CAST(NgayThu AS DATE) AS Ngay, SUM(ThanhTien) AS Tien FROM #DaThu GROUP BY CAST(NgayThu AS DATE)),
 Don AS (SELECT CAST(ThoiGianTao AS DATE) AS Ngay,COUNT(*) AS SoDon FROM dbo.DON_HANG
 WHERE ThoiGianTao>=@tu AND ThoiGianTao<@den GROUP BY CAST(ThoiGianTao AS DATE))
SELECT COALESCE(t.Ngay,d.Ngay) AS Ngay,ISNULL(t.Tien,0) AS Tien,ISNULL(d.SoDon,0) AS SoDon
FROM Tien t FULL JOIN Don d ON t.Ngay=d.Ngay ORDER BY Ngay;

SELECT TOP (5) m.TenMon,SUM(CAST(c.SoLuong AS BIGINT)) AS SoLuong
FROM dbo.CHI_TIET_DON_HANG c JOIN #DaThu t ON t.DonHangID=c.DonHangID
JOIN dbo.MON_AN m ON m.MonID=c.MonID WHERE c.TrangThaiMon<>N'Đã hủy'
GROUP BY m.MonID,m.TenMon ORDER BY SoLuong DESC,m.TenMon;

SELECT TOP (10) 'DH'+RIGHT('000000'+CAST(d.DonHangID AS VARCHAR(10)),6) AS MaDon,
 b.SoBan,d.ThoiGianTao,ISNULL(h.ThanhTien,ISNULL(ct.Tong,0)) AS TongTien,
 CASE WHEN d.TrangThaiDon=N'Đã hủy' THEN N'Đã hủy' ELSE ISNULL(h.TrangThaiThanhToan,d.TrangThaiDon) END AS TrangThai
FROM dbo.DON_HANG d JOIN dbo.BAN_AN b ON b.BanID=d.BanID
LEFT JOIN dbo.HOA_DON h ON h.DonHangID=d.DonHangID
OUTER APPLY (SELECT SUM(c.SoLuong*c.DonGia) AS Tong FROM dbo.CHI_TIET_DON_HANG c
 WHERE c.DonHangID=d.DonHangID AND c.TrangThaiMon<>N'Đã hủy') ct
WHERE d.ThoiGianTao>=@tu AND d.ThoiGianTao<@den ORDER BY d.ThoiGianTao DESC,d.DonHangID DESC;

SELECT ISNULL(PhuongThucThanhToan,N'Chưa xác định') AS PhuongThuc,SUM(ThanhTien) AS Tien
FROM #DaThu GROUP BY PhuongThucThanhToan ORDER BY Tien DESC;
SELECT TrangThai,COUNT(*) AS SoBan FROM dbo.BAN_AN GROUP BY TrangThai;
DROP TABLE #DaThu;";
            using var reader = await command.ExecuteReaderAsync();
            var result = new DataSet();
            string[] names = { "Tong", "TheoNgay", "TopMon", "DonMoi", "ThanhToan", "Ban" };
            foreach (string name in names)
            {
                var table = new DataTable(name);
                for (int i = 0; i < reader.FieldCount; i++) table.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                while (await reader.ReadAsync())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    table.Rows.Add(values);
                }
                result.Tables.Add(table);
                if (!await reader.NextResultAsync()) break;
            }
            return result;
        }
    }
}
