CREATE TABLE dbo.VAI_TRO (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    TenVaiTro VARCHAR(30) NOT NULL UNIQUE,
    MoTa NVARCHAR(255) NULL
);
CREATE TABLE dbo.NHAN_VIEN (
    NhanVienID INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NULL,
    GioiTinh NVARCHAR(10) NULL,
    SDT VARCHAR(15) NULL,
    Email VARCHAR(100) NULL,
    DiaChi NVARCHAR(255) NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    NgayVaoLam DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Đang làm',
    CONSTRAINT CK_NV_TrangThai CHECK (TrangThai IN (N'Đang làm', N'Nghỉ việc', N'Tạm nghỉ'))
);
CREATE TABLE dbo.TAI_KHOAN (
    TaiKhoanID INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhauHash VARCHAR(255) NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Hoạt động',
    RoleID INT NOT NULL,
    NhanVienID INT NOT NULL UNIQUE,
    CONSTRAINT FK_TK_Role FOREIGN KEY (RoleID) REFERENCES dbo.VAI_TRO(RoleID),
    CONSTRAINT FK_TK_NV FOREIGN KEY (NhanVienID) REFERENCES dbo.NHAN_VIEN(NhanVienID),
    CONSTRAINT CK_TK_TrangThai CHECK (TrangThai IN (N'Hoạt động', N'Bị khóa'))
);
CREATE TABLE dbo.BAN_AN (
    BanID INT IDENTITY(1,1) PRIMARY KEY,
    SoBan VARCHAR(10) NOT NULL UNIQUE,
    SucChua INT NOT NULL CHECK (SucChua > 0),
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Trống',
    ViTri NVARCHAR(100) NULL,
    CONSTRAINT CK_Ban_TrangThai CHECK (TrangThai IN (N'Trống', N'Đang phục vụ', N'Chờ dọn', N'Bảo trì'))
);
CREATE TABLE dbo.DANH_MUC_MON (
    DanhMucID INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(255) NULL
);
CREATE TABLE dbo.MON_AN (
    MonID INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    DonViTinh NVARCHAR(30) NOT NULL,
    MoTa NVARCHAR(255) NULL,
    TrangThaiMon NVARCHAR(30) NOT NULL DEFAULT N'Đang bán',
    DanhMucID INT NOT NULL,
    CONSTRAINT FK_Mon_DanhMuc FOREIGN KEY (DanhMucID) REFERENCES dbo.DANH_MUC_MON(DanhMucID),
    CONSTRAINT CK_Mon_TrangThai CHECK (TrangThaiMon IN (N'Đang bán', N'Tạm hết', N'Ngừng bán'))
);
CREATE TABLE dbo.DON_HANG (
    DonHangID INT IDENTITY(1,1) PRIMARY KEY,
    BanID INT NOT NULL,
    NhanVienPhucVuID INT NOT NULL,
    ThoiGianTao DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    TrangThaiDon NVARCHAR(30) NOT NULL DEFAULT N'Đang xử lý',
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT FK_DH_Ban FOREIGN KEY (BanID) REFERENCES dbo.BAN_AN(BanID),
    CONSTRAINT FK_DH_NV FOREIGN KEY (NhanVienPhucVuID) REFERENCES dbo.NHAN_VIEN(NhanVienID),
    CONSTRAINT CK_DH_TrangThai CHECK (TrangThaiDon IN (N'Đang xử lý', N'Hoàn thành', N'Đã hủy'))
);
CREATE TABLE dbo.CHI_TIET_DON_HANG (
    DonHangID INT NOT NULL,
    MonID INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    TrangThaiMon NVARCHAR(30) NOT NULL DEFAULT N'Chờ chế biến',
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT PK_CTDH PRIMARY KEY (DonHangID, MonID),
    CONSTRAINT FK_CTDH_DH FOREIGN KEY (DonHangID) REFERENCES dbo.DON_HANG(DonHangID),
    CONSTRAINT FK_CTDH_Mon FOREIGN KEY (MonID) REFERENCES dbo.MON_AN(MonID),
    CONSTRAINT CK_CTDH_TrangThai CHECK (TrangThaiMon IN (N'Chờ chế biến', N'Đang chế biến', N'Hoàn thành', N'Đã phục vụ', N'Đã hủy'))
);
CREATE TABLE dbo.HOA_DON (
    HoaDonID INT IDENTITY(1,1) PRIMARY KEY,
    DonHangID INT NOT NULL UNIQUE,
    ThuNganID INT NOT NULL,
    NgayLap DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    TongTien DECIMAL(18,2) NOT NULL CHECK (TongTien >= 0),
    GiamGia DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (GiamGia >= 0),
    ThanhTien AS (TongTien - GiamGia) PERSISTED,
    PhuongThucThanhToan NVARCHAR(30) NULL,
    TrangThaiThanhToan NVARCHAR(30) NOT NULL DEFAULT N'Chưa thanh toán',
    CONSTRAINT FK_HD_DH FOREIGN KEY (DonHangID) REFERENCES dbo.DON_HANG(DonHangID),
    CONSTRAINT FK_HD_ThuNgan FOREIGN KEY (ThuNganID) REFERENCES dbo.NHAN_VIEN(NhanVienID),
    CONSTRAINT CK_HD_GiamGia CHECK (GiamGia <= TongTien),
    CONSTRAINT CK_HD_PTTT CHECK (PhuongThucThanhToan IS NULL OR PhuongThucThanhToan IN (N'Tiền mặt', N'Chuyển khoản', N'Thẻ')),
    CONSTRAINT CK_HD_TrangThai CHECK (TrangThaiThanhToan IN (N'Chưa thanh toán', N'Đã thanh toán', N'Đã hủy'))
);
CREATE TABLE dbo.NHA_CUNG_CAP (
    NhaCungCapID INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(120) NOT NULL,
    SDT VARCHAR(15) NULL,
    Email VARCHAR(100) NULL,
    DiaChi NVARCHAR(255) NULL
);
CREATE TABLE dbo.NGUYEN_LIEU (
    NguyenLieuID INT IDENTITY(1,1) PRIMARY KEY,
    TenNguyenLieu NVARCHAR(100) NOT NULL,
    DonViTinh NVARCHAR(30) NOT NULL,
    SoLuongTon DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (SoLuongTon >= 0),
    MucCanhBao DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (MucCanhBao >= 0),
    HanSuDung DATE NULL,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Còn hàng',
    CONSTRAINT CK_NL_TrangThai CHECK (TrangThai IN (N'Còn hàng', N'Sắp hết', N'Hết hàng', N'Ngừng sử dụng'))
);
CREATE TABLE dbo.PHIEU_NHAP (
    PhieuNhapID INT IDENTITY(1,1) PRIMARY KEY,
    NhaCungCapID INT NOT NULL,
    NhanVienKhoID INT NOT NULL,
    NgayNhap DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TongTien >= 0),
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT FK_PN_NCC FOREIGN KEY (NhaCungCapID) REFERENCES dbo.NHA_CUNG_CAP(NhaCungCapID),
    CONSTRAINT FK_PN_NV FOREIGN KEY (NhanVienKhoID) REFERENCES dbo.NHAN_VIEN(NhanVienID)
);
CREATE TABLE dbo.CHI_TIET_PHIEU_NHAP (
    PhieuNhapID INT NOT NULL,
    NguyenLieuID INT NOT NULL,
    SoLuong DECIMAL(18,2) NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    CONSTRAINT PK_CTPN PRIMARY KEY (PhieuNhapID, NguyenLieuID),
    CONSTRAINT FK_CTPN_PN FOREIGN KEY (PhieuNhapID) REFERENCES dbo.PHIEU_NHAP(PhieuNhapID),
    CONSTRAINT FK_CTPN_NL FOREIGN KEY (NguyenLieuID) REFERENCES dbo.NGUYEN_LIEU(NguyenLieuID)
);
CREATE TABLE dbo.PHIEU_XUAT (
    PhieuXuatID INT IDENTITY(1,1) PRIMARY KEY,
    NhanVienKhoID INT NOT NULL,
    NgayXuat DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    LyDo NVARCHAR(200) NOT NULL,
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT FK_PX_NV FOREIGN KEY (NhanVienKhoID) REFERENCES dbo.NHAN_VIEN(NhanVienID)
);
CREATE TABLE dbo.CHI_TIET_PHIEU_XUAT (
    PhieuXuatID INT NOT NULL,
    NguyenLieuID INT NOT NULL,
    SoLuong DECIMAL(18,2) NOT NULL CHECK (SoLuong > 0),
    CONSTRAINT PK_CTPX PRIMARY KEY (PhieuXuatID, NguyenLieuID),
    CONSTRAINT FK_CTPX_PX FOREIGN KEY (PhieuXuatID) REFERENCES dbo.PHIEU_XUAT(PhieuXuatID),
    CONSTRAINT FK_CTPX_NL FOREIGN KEY (NguyenLieuID) REFERENCES dbo.NGUYEN_LIEU(NguyenLieuID)
);
INSERT dbo.VAI_TRO (TenVaiTro, MoTa) VALUES
('ADMIN',N'Quản trị hệ thống'),('BEP',N'Tiếp nhận và chế biến món'),
('KHO',N'Quản lý nguyên liệu'),('PHUCVU',N'Gọi món và phục vụ'),
('THUNGAN',N'Lập hóa đơn và thanh toán');
INSERT dbo.NHAN_VIEN (HoTen,NgaySinh,GioiTinh,SDT,Email,DiaChi,ChucVu,NgayVaoLam,TrangThai) VALUES
(N'Nguyễn Minh Anh','1994-06-12',N'Nữ','0901000001','admin@nhahang.test',N'Hà Nội',N'Quản lý','2024-01-15',N'Đang làm'),
(N'Trần Văn Bình','1998-03-21',N'Nam','0901000002','bep@nhahang.test',N'Hà Nội',N'Đầu bếp','2024-03-01',N'Đang làm'),
(N'Lê Thu Hà','1997-08-09',N'Nữ','0901000003','kho@nhahang.test',N'Hà Nội',N'Nhân viên kho','2024-06-10',N'Đang làm'),
(N'Phạm Quốc Huy','2001-01-19',N'Nam','0901000004','pv1@nhahang.test',N'Hà Nội',N'Phục vụ','2025-01-01',N'Đang làm'),
(N'Đỗ Ngọc Lan','2000-11-04',N'Nữ','0901000005','tn@nhahang.test',N'Hà Nội',N'Thu ngân','2025-02-15',N'Đang làm'),
(N'Hoàng Minh Tuấn','2002-05-26',N'Nam','0901000006','pv2@nhahang.test',N'Hà Nội',N'Phục vụ','2025-03-01',N'Đang làm');
INSERT dbo.BAN_AN (SoBan,SucChua,TrangThai,ViTri) VALUES
('B01',2,N'Đang phục vụ',N'Tầng 1'),('B02',4,N'Đang phục vụ',N'Tầng 1'),
('B03',4,N'Chờ dọn',N'Tầng 1'),('B04',6,N'Trống',N'Tầng 2'),
('B05',8,N'Đang phục vụ',N'Tầng 2'),('B06',2,N'Đang phục vụ',N'Sân vườn');
INSERT dbo.DANH_MUC_MON (TenDanhMuc,MoTa) VALUES
(N'Khai vị',N'Món ăn đầu bữa'),(N'Món chính',N'Món ăn no'),
(N'Món canh',N'Canh và súp'),(N'Món nướng',N'Món chế biến nướng'),
(N'Đồ uống',N'Nước giải khát');
INSERT dbo.MON_AN (TenMon,DonGia,DonViTinh,MoTa,TrangThaiMon,DanhMucID) VALUES
(N'Gỏi cuốn',45000,N'Đĩa',N'Gỏi cuốn tôm thịt',N'Đang bán',1),
(N'Cơm rang hải sản',85000,N'Đĩa',N'Cơm chiên cùng hải sản',N'Đang bán',2),
(N'Canh chua cá',95000,N'Tô',N'Canh chua kiểu miền Nam',N'Đang bán',3),
(N'Ba chỉ nướng',120000,N'Đĩa',N'Ba chỉ nướng sốt đặc biệt',N'Đang bán',4),
(N'Trà đào',35000,N'Ly',N'Trà đào mát lạnh',N'Đang bán',5),
(N'Nước cam',40000,N'Ly',N'Cam tươi',N'Tạm hết',5);
INSERT dbo.DON_HANG (BanID,NhanVienPhucVuID,ThoiGianTao,TrangThaiDon,GhiChu) VALUES
(1,4,'2026-10-09T11:30:00',N'Đang xử lý',N'Ít cay'),
(2,6,'2026-10-09T12:00:00',N'Đang xử lý',N'Khách có trẻ em'),
(3,4,'2026-10-08T19:10:00',N'Hoàn thành',N'Đã giao món'),
(5,6,'2026-10-09T18:20:00',N'Đang xử lý',N'Phục vụ theo thứ tự'),
(6,4,'2026-10-09T19:00:00',N'Đang xử lý',NULL);
INSERT dbo.CHI_TIET_DON_HANG (DonHangID,MonID,SoLuong,DonGia,TrangThaiMon,GhiChu) VALUES
(1,1,2,45000,N'Đã phục vụ',N'Không hành'),
(1,2,1,85000,N'Đang chế biến',N'Ít dầu'),
(2,3,1,95000,N'Chờ chế biến',N'Không quá chua'),
(3,4,2,120000,N'Đã phục vụ',NULL),
(4,5,3,35000,N'Hoàn thành',N'Ít đá'),
(5,2,2,85000,N'Chờ chế biến',NULL);
INSERT dbo.HOA_DON (DonHangID,ThuNganID,NgayLap,TongTien,GiamGia,PhuongThucThanhToan,TrangThaiThanhToan) VALUES
(1,5,'2026-10-09T12:20:00',175000,0,NULL,N'Chưa thanh toán'),
(2,5,'2026-10-09T12:40:00',95000,0,NULL,N'Chưa thanh toán'),
(3,5,'2026-10-08T20:10:00',240000,20000,N'Chuyển khoản',N'Đã thanh toán'),
(4,5,'2026-10-09T19:00:00',105000,0,NULL,N'Chưa thanh toán'),
(5,5,'2026-10-09T19:40:00',170000,0,NULL,N'Chưa thanh toán');
INSERT dbo.NHA_CUNG_CAP (TenNCC,SDT,Email,DiaChi) VALUES
(N'Thực phẩm An Phát','0243000001','anphat@demo.test',N'Hà Nội'),
(N'Rau sạch Minh Tâm','0243000002','minhtam@demo.test',N'Hà Nội'),
(N'Hải sản Biển Xanh','0243000003','bienxanh@demo.test',N'Hải Phòng'),
(N'Đồ uống Hồng Hà','0243000004','hongha@demo.test',N'Hà Nội'),
(N'Thịt sạch Việt','0243000005','thitsach@demo.test',N'Hà Nội');
INSERT dbo.NGUYEN_LIEU (TenNguyenLieu,DonViTinh,SoLuongTon,MucCanhBao,HanSuDung,TrangThai) VALUES
(N'Tôm tươi',N'kg',12.50,5,'2026-10-13',N'Còn hàng'),
(N'Gạo',N'kg',35,10,'2027-04-01',N'Còn hàng'),
(N'Cá',N'kg',8,4,'2026-10-12',N'Còn hàng'),
(N'Thịt ba chỉ',N'kg',4,5,'2026-10-13',N'Sắp hết'),
(N'Trà đào',N'lít',16,5,'2026-11-01',N'Còn hàng'),
(N'Cam tươi',N'kg',0,3,'2026-10-11',N'Hết hàng');
INSERT dbo.PHIEU_NHAP (NhaCungCapID,NhanVienKhoID,NgayNhap,TongTien,GhiChu) VALUES
(3,3,'2026-10-07T08:00:00',1500000,N'Nhập tôm'),
(1,3,'2026-10-07T08:30:00',600000,N'Nhập gạo'),
(3,3,'2026-10-08T07:40:00',960000,N'Nhập cá'),
(5,3,'2026-10-08T09:00:00',1000000,N'Nhập thịt'),
(4,3,'2026-10-09T07:30:00',400000,N'Nhập trà');
INSERT dbo.CHI_TIET_PHIEU_NHAP (PhieuNhapID,NguyenLieuID,SoLuong,DonGia) VALUES
(1,1,10,150000),
(2,2,30,20000),
(3,3,8,120000),
(4,4,10,100000),
(5,5,20,20000);
INSERT dbo.PHIEU_XUAT (NhanVienKhoID,NgayXuat,LyDo,GhiChu) VALUES
(3,'2026-10-09T09:00:00',N'Cấp nguyên liệu cho bếp',N'Ca sáng'),
(3,'2026-10-09T09:10:00',N'Cấp nguyên liệu cho bếp',N'Chuẩn bị cơm'),
(3,'2026-10-09T09:15:00',N'Cấp nguyên liệu cho bếp',N'Chuẩn bị canh'),
(3,'2026-10-09T16:00:00',N'Cấp nguyên liệu cho bếp',N'Ca chiều'),
(3,'2026-10-09T16:30:00',N'Cấp nguyên liệu cho quầy',N'Pha chế');
INSERT dbo.CHI_TIET_PHIEU_XUAT (PhieuXuatID,NguyenLieuID,SoLuong) VALUES
(1,1,2),(2,2,5),(3,3,2),(4,4,3),(5,5,4);
ALTER TABLE dbo.CHI_TIET_DON_HANG DROP CONSTRAINT CK_CTDH_TrangThai;
ALTER TABLE dbo.CHI_TIET_DON_HANG ADD CONSTRAINT CK_CTDH_TrangThai
    CHECK (TrangThaiMon IN (N'Chưa gửi bếp', N'Chờ chế biến', N'Đang chế biến',
                            N'Hoàn thành', N'Đã phục vụ', N'Đã hủy'));
ALTER TABLE dbo.DON_HANG ADD YeuCauThanhToan BIT NOT NULL DEFAULT 0,
                             ThoiGianYeuCau DATETIME2(0) NULL;

select * from NHAN_VIEN
