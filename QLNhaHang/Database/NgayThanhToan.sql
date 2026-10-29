IF COL_LENGTH('dbo.HOA_DON', 'NgayThanhToan') IS NULL
    ALTER TABLE dbo.HOA_DON ADD NgayThanhToan DATETIME2(0) NULL;
GO

-- Hóa đơn đã thanh toán từ trước chưa có giờ thanh toán: tạm lấy giờ lập
UPDATE dbo.HOA_DON SET NgayThanhToan = NgayLap
WHERE TrangThaiThanhToan = N'Đã thanh toán' AND NgayThanhToan IS NULL;
GO