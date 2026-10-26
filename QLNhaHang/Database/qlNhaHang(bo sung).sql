-- 1. Cột yêu cầu thanh toán
IF COL_LENGTH('dbo.DON_HANG', 'YeuCauThanhToan') IS NULL
    ALTER TABLE dbo.DON_HANG ADD
        YeuCauThanhToan BIT NOT NULL CONSTRAINT DF_DH_YeuCauTT DEFAULT 0,
        ThoiGianYeuCau  DATETIME2(0) NULL;
GO

-- 2. Trạng thái món "Chưa gửi bếp"
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints
               WHERE name = 'CK_CTDH_TrangThai' AND definition LIKE N'%Chưa gửi bếp%')
BEGIN
    ALTER TABLE dbo.CHI_TIET_DON_HANG DROP CONSTRAINT CK_CTDH_TrangThai;
    ALTER TABLE dbo.CHI_TIET_DON_HANG ADD CONSTRAINT CK_CTDH_TrangThai
        CHECK (TrangThaiMon IN (N'Chưa gửi bếp', N'Chờ chế biến', N'Đang chế biến',
                                N'Hoàn thành', N'Đã phục vụ', N'Đã hủy'));
END
GO

-- 3. Thời gian gửi, bắt đầu, hoàn thành của từng món
IF COL_LENGTH('dbo.CHI_TIET_DON_HANG', 'ThoiGianGuiBep') IS NULL
    ALTER TABLE dbo.CHI_TIET_DON_HANG ADD
        ThoiGianGuiBep    DATETIME2(0) NULL,
        ThoiGianBatDau    DATETIME2(0) NULL,
        ThoiGianHoanThanh DATETIME2(0) NULL;
GO

UPDATE c SET c.ThoiGianGuiBep = dh.ThoiGianTao
FROM dbo.CHI_TIET_DON_HANG c
JOIN dbo.DON_HANG dh ON dh.DonHangID = c.DonHangID
WHERE c.TrangThaiMon <> N'Chưa gửi bếp' AND c.ThoiGianGuiBep IS NULL;
GO

-- 4. Mỗi dòng món một mã riêng (DongID) để gọi lại được đúng món đã gửi
IF COL_LENGTH('dbo.CHI_TIET_DON_HANG', 'DongID') IS NULL
BEGIN
    ALTER TABLE dbo.CHI_TIET_DON_HANG DROP CONSTRAINT PK_CTDH;
    ALTER TABLE dbo.CHI_TIET_DON_HANG ADD DongID INT IDENTITY(1,1) NOT NULL;
    ALTER TABLE dbo.CHI_TIET_DON_HANG ADD CONSTRAINT PK_CTDH PRIMARY KEY (DongID);
    CREATE INDEX IX_CTDH_DonMon ON dbo.CHI_TIET_DON_HANG (DonHangID, MonID);
END
GO