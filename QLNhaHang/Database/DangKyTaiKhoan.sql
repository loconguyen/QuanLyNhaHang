-- Chạy trong database QuanLyNhaHang. Có thể chạy lại; không xóa tài khoản hoặc yêu cầu cũ.
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
SET XACT_ABORT ON;
BEGIN TRY
    BEGIN TRANSACTION;
    IF OBJECT_ID(N'dbo.TAI_KHOAN', N'U') IS NULL
        THROW 50001, N'Chưa có bảng TAI_KHOAN. Chạy QLNhaHang.sql trước.', 1;

    DECLARE @sql NVARCHAR(MAX) = N'';
    -- SQL Server chỉ cho một NULL trong UNIQUE thông thường: thay bằng filtered index.
    SELECT @sql = @sql + N'ALTER TABLE dbo.TAI_KHOAN DROP CONSTRAINT ' + QUOTENAME(k.name) + N';'
    FROM sys.key_constraints k
    WHERE k.parent_object_id=OBJECT_ID(N'dbo.TAI_KHOAN') AND k.type='UQ'
      AND (SELECT COUNT(*) FROM sys.index_columns ic WHERE ic.object_id=k.parent_object_id
           AND ic.index_id=k.unique_index_id AND ic.key_ordinal>0)=1
      AND EXISTS (SELECT 1 FROM sys.index_columns ic JOIN sys.columns c
                  ON c.object_id=ic.object_id AND c.column_id=ic.column_id
                  WHERE ic.object_id=k.parent_object_id AND ic.index_id=k.unique_index_id AND c.name=N'NhanVienID');
    EXEC sys.sp_executesql @sql;
    SET @sql=N'';
    SELECT @sql=@sql+N'DROP INDEX '+QUOTENAME(i.name)+N' ON dbo.TAI_KHOAN;'
    FROM sys.indexes i WHERE i.object_id=OBJECT_ID(N'dbo.TAI_KHOAN')
      AND i.is_unique=1 AND i.is_unique_constraint=0 AND i.is_primary_key=0
      AND i.has_filter=0
      AND (SELECT COUNT(*) FROM sys.index_columns ic WHERE ic.object_id=i.object_id AND ic.index_id=i.index_id AND ic.key_ordinal>0)=1
      AND EXISTS (SELECT 1 FROM sys.index_columns ic JOIN sys.columns c ON c.object_id=ic.object_id AND c.column_id=ic.column_id
                  WHERE ic.object_id=i.object_id AND ic.index_id=i.index_id AND c.name=N'NhanVienID');
    EXEC sys.sp_executesql @sql;
    IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id=OBJECT_ID(N'dbo.TAI_KHOAN') AND name=N'NhanVienID' AND is_nullable=0)
        ALTER TABLE dbo.TAI_KHOAN ALTER COLUMN NhanVienID INT NULL;
    IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id=OBJECT_ID(N'dbo.TAI_KHOAN') AND name=N'RoleID' AND is_nullable=0)
        ALTER TABLE dbo.TAI_KHOAN ALTER COLUMN RoleID INT NULL;

    IF COL_LENGTH(N'dbo.TAI_KHOAN', N'HoTenDangKy') IS NULL
        ALTER TABLE dbo.TAI_KHOAN ADD HoTenDangKy NVARCHAR(100) NULL;
    IF COL_LENGTH(N'dbo.TAI_KHOAN', N'SDTDangKy') IS NULL
        ALTER TABLE dbo.TAI_KHOAN ADD SDTDangKy VARCHAR(15) NULL;
    IF COL_LENGTH(N'dbo.TAI_KHOAN', N'NgayDangKy') IS NULL
        ALTER TABLE dbo.TAI_KHOAN ADD NgayDangKy DATETIME2(0) NOT NULL CONSTRAINT DF_TK_NgayDangKy DEFAULT SYSDATETIME();

    SET @sql=N'';
    SELECT @sql=@sql+N'ALTER TABLE dbo.TAI_KHOAN DROP CONSTRAINT '+QUOTENAME(name)+N';'
    FROM sys.check_constraints WHERE parent_object_id=OBJECT_ID(N'dbo.TAI_KHOAN')
        AND (definition LIKE N'%TrangThai%' OR name=N'CK_TK_Duyet');
    SELECT @sql=@sql+N'ALTER TABLE dbo.TAI_KHOAN DROP CONSTRAINT '+QUOTENAME(d.name)+N';'
    FROM sys.default_constraints d JOIN sys.columns c ON c.object_id=d.parent_object_id AND c.column_id=d.parent_column_id
    WHERE d.parent_object_id=OBJECT_ID(N'dbo.TAI_KHOAN') AND c.name=N'TrangThai';
    EXEC sys.sp_executesql @sql;
    ALTER TABLE dbo.TAI_KHOAN ADD CONSTRAINT DF_TK_TrangThai DEFAULT N'Chờ duyệt' FOR TrangThai;
    ALTER TABLE dbo.TAI_KHOAN WITH CHECK ADD CONSTRAINT CK_TK_TrangThai
        CHECK (TrangThai IN (N'Chờ duyệt', N'Hoạt động', N'Bị khóa', N'Từ chối'));
    ALTER TABLE dbo.TAI_KHOAN WITH CHECK ADD CONSTRAINT CK_TK_Duyet CHECK (
        (TrangThai IN (N'Chờ duyệt', N'Từ chối') AND NhanVienID IS NULL AND RoleID IS NULL)
        OR (TrangThai IN (N'Hoạt động', N'Bị khóa') AND NhanVienID IS NOT NULL AND RoleID IS NOT NULL));

    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE object_id=OBJECT_ID(N'dbo.TAI_KHOAN') AND name=N'UX_TaiKhoan_NhanVienID')
        EXEC(N'CREATE UNIQUE INDEX UX_TaiKhoan_NhanVienID ON dbo.TAI_KHOAN(NhanVienID) WHERE NhanVienID IS NOT NULL;');

    IF COL_LENGTH(N'dbo.TAI_KHOAN', N'PhienBan') IS NOT NULL
        ALTER TABLE dbo.TAI_KHOAN DROP COLUMN PhienBan;

    -- Chuyển yêu cầu cũ chưa duyệt, nếu đã chạy bản script trước. Giữ bảng cũ làm lịch sử.
    IF OBJECT_ID(N'dbo.YEU_CAU_DANG_KY', N'U') IS NOT NULL
        EXEC(N'INSERT dbo.TAI_KHOAN(TenDangNhap, MatKhauHash, TrangThai, HoTenDangKy, SDTDangKy, NgayDangKy)
            SELECT y.TenDangNhap, y.MatKhauHash, y.TrangThai, y.HoTen, y.SDT, y.NgayDangKy
            FROM dbo.YEU_CAU_DANG_KY y
            WHERE y.TrangThai IN (N''Chờ duyệt'', N''Từ chối'')
              AND NOT EXISTS (SELECT 1 FROM dbo.TAI_KHOAN tk WHERE tk.TenDangNhap=y.TenDangNhap);');

    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE object_id=OBJECT_ID(N'dbo.TAI_KHOAN') AND name=N'UX_TK_SDTChoDuyet')
        EXEC(N'CREATE UNIQUE INDEX UX_TK_SDTChoDuyet ON dbo.TAI_KHOAN(SDTDangKy)
            WHERE TrangThai=N''Chờ duyệt'' AND SDTDangKy IS NOT NULL;');
    EXEC(N'ALTER TABLE dbo.TAI_KHOAN WITH CHECK ADD CONSTRAINT CK_TK_ThongTinDangKy CHECK
        (TrangThai <> N''Chờ duyệt'' OR (HoTenDangKy IS NOT NULL AND LEN(LTRIM(RTRIM(HoTenDangKy)))>0 AND SDTDangKy IS NOT NULL));');
    COMMIT;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT>0 ROLLBACK;
    THROW;
END CATCH;


