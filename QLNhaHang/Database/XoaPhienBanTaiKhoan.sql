-- Chỉ bỏ cột kỹ thuật rowversion, không xóa tài khoản.
IF COL_LENGTH(N'dbo.TAI_KHOAN', N'PhienBan') IS NOT NULL
    ALTER TABLE dbo.TAI_KHOAN DROP COLUMN PhienBan;
