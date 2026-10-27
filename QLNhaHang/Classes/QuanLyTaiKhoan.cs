using System.Data;
using Microsoft.Data.SqlClient;

namespace QLNhaHang.Classes
{
   
    internal sealed class QuanLyTaiKhoan
    {
        private readonly DataProcesser db = new DataProcesser();
        private readonly string? chuoiKetNoi;

        internal QuanLyTaiKhoan(string? chuoiKetNoi = null)
        {
            this.chuoiKetNoi = chuoiKetNoi;
        }

        private SqlConnection TaoKetNoi() => chuoiKetNoi == null
            ? db.TaoKetNoi() : new SqlConnection(chuoiKetNoi);

        private static void KiemTraTen(string ten)
        {
            if (ten.Length < 3 || ten.Length > 50 ||
                !ten.All(c => char.IsAsciiLetterOrDigit(c) || c == '_' || c == '.'))
                throw new InvalidOperationException("Tên đăng nhập gồm 3–50 chữ không dấu, số, dấu chấm hoặc gạch dưới.");
        }

        private static void KiemTraMatKhau(string matKhau)
        {
            if (string.IsNullOrWhiteSpace(matKhau) || matKhau.Length < 8 || matKhau.Length > 128)
                throw new InvalidOperationException("Mật khẩu phải có từ 8 đến 128 ký tự.");
        }

        public DataRow? DangNhap(string ten, string vaiTro, string matKhau)
        {
            if (ten.Length > 50 || string.IsNullOrEmpty(matKhau)) return null;
            using var ketNoi = TaoKetNoi();
            ketNoi.Open();
            using var giaoDich = ketNoi.BeginTransaction(IsolationLevel.Serializable);
            using var lenh = new SqlCommand(@"
                SELECT tk.TaiKhoanID,tk.NhanVienID,tk.MatKhauHash,nv.HoTen,vt.TenVaiTro
                FROM dbo.TAI_KHOAN tk WITH (UPDLOCK,HOLDLOCK)
                JOIN dbo.NHAN_VIEN nv ON nv.NhanVienID=tk.NhanVienID
                JOIN dbo.VAI_TRO vt ON vt.RoleID=tk.RoleID
                WHERE tk.TenDangNhap=@ten AND vt.TenVaiTro=@vaiTro
                  AND tk.TrangThai=N'Hoạt động' AND nv.TrangThai=N'Đang làm';", ketNoi, giaoDich);
            lenh.Parameters.Add("@ten", SqlDbType.VarChar, 50).Value = ten;
            lenh.Parameters.Add("@vaiTro", SqlDbType.VarChar, 30).Value = vaiTro;
            DataTable bang = DocBang(lenh);
            if (bang.Rows.Count != 1) return null;
            DataRow dong = bang.Rows[0];
            string hash = dong.Field<string>("MatKhauHash")!;
            bool daBam = hash.StartsWith("PBKDF2-SHA256$", StringComparison.Ordinal);
            bool hopLe = daBam ? BaoMatMatKhau.KiemTraMatKhau(matKhau, hash) : hash == matKhau;
            if (!hopLe) return null;
            // Giữ tài khoản cũ dùng được, chuyển mật khẩu thô sang hash sau khi xác thực đúng.
            if (!daBam)
            {
                using var capNhat = new SqlCommand("UPDATE dbo.TAI_KHOAN SET MatKhauHash=@hash WHERE TaiKhoanID=@id", ketNoi, giaoDich);
                capNhat.Parameters.Add("@hash", SqlDbType.VarChar, 255).Value = BaoMatMatKhau.BamMatKhau(matKhau);
                capNhat.Parameters.Add("@id", SqlDbType.Int).Value = dong["TaiKhoanID"];
                capNhat.ExecuteNonQuery();
            }
            bang.Columns.Remove("MatKhauHash");
            giaoDich.Commit();
            return dong;
        }

        public void GuiYeuCau(
    string hoTen,
    string sdt,
    string tenDangNhap,
    string matKhau)
        {
            tenDangNhap = tenDangNhap.Trim();
            hoTen = hoTen.Trim();
            sdt = sdt.Trim();

            KiemTraTen(tenDangNhap);
            KiemTraMatKhau(matKhau);

            // 1. Kiểm tra thông tin đăng ký
            if (string.IsNullOrWhiteSpace(hoTen) ||
                hoTen.Length > 100 ||
                sdt.Length != 10 ||
                sdt[0] != '0' ||
                !sdt.All(c => c >= '0' && c <= '9'))
            {
                throw new InvalidOperationException(
                    "Họ tên tối đa 100 ký tự. Số điện thoại gồm 10 chữ số, bắt đầu bằng 0.");
            }

            // 3. Băm mật khẩu
            string maBam = BaoMatMatKhau.BamMatKhau(matKhau);

            using var ketNoi = TaoKetNoi();
            ketNoi.Open();

            using var giaoDich =
                ketNoi.BeginTransaction(IsolationLevel.Serializable);

            using var lenh = new SqlCommand(@"

        -- Kiểm tra tên đăng nhập
        IF EXISTS (
            SELECT 1
            FROM dbo.TAI_KHOAN WITH (UPDLOCK, HOLDLOCK)
            WHERE TenDangNhap = @ten
        )
            THROW 50001,
                N'Tên đăng nhập đã tồn tại. Hãy chọn tên khác.', 1;

        -- Kiểm tra SĐT đang có yêu cầu chờ duyệt
        IF EXISTS (
            SELECT 1
            FROM dbo.TAI_KHOAN WITH (UPDLOCK, HOLDLOCK)
            WHERE TrangThai = N'Chờ duyệt'
              AND SDTDangKy = @sdt
        )
            THROW 50001,
                N'Số điện thoại đã có yêu cầu đăng ký đang chờ duyệt.', 1;

        -- Nhân viên có sẵn dùng chức năng cấp tài khoản
        IF EXISTS (
            SELECT 1
            FROM dbo.NHAN_VIEN WITH (UPDLOCK, HOLDLOCK) WHERE SDT = @sdt
        )
            THROW 50001,
                N'Nhân viên đã có trong danh sách. Vui lòng liên hệ quản lý để được cấp tài khoản.', 1;

        -- Tạo yêu cầu đăng ký
        INSERT INTO dbo.TAI_KHOAN
        (
            TenDangNhap,
            MatKhauHash,
            TrangThai,
            RoleID,
            NhanVienID,
            HoTenDangKy,
            SDTDangKy
        )
        VALUES
        (
            @ten,
            @hash,
            N'Chờ duyệt',
            NULL,
            NULL,
            @hoTen,
            @sdt
        );

    ", ketNoi, giaoDich);

            // 4. Truyền tham số SQL
            lenh.Parameters.Add(
                "@ten", SqlDbType.VarChar, 50
            ).Value = tenDangNhap;

            lenh.Parameters.Add(
                "@hoTen", SqlDbType.NVarChar, 100
            ).Value = hoTen;

            lenh.Parameters.Add(
                "@sdt", SqlDbType.VarChar, 15
            ).Value = sdt;

            lenh.Parameters.Add(
                "@hash", SqlDbType.VarChar, 255
            ).Value = maBam;

// 5. Thực hiện INSERT
            lenh.ExecuteNonQuery();

            giaoDich.Commit();
        }

        // Khóa các Admin đang hoạt động để hai phiên không đồng thời vô hiệu hóa Admin cuối cùng.
        private const string BaoVeAdmin = @"
            DECLARE @soAdmin INT;
            SELECT @soAdmin=COUNT(*) FROM dbo.TAI_KHOAN tk WITH (UPDLOCK,HOLDLOCK)
                JOIN dbo.VAI_TRO vt ON vt.RoleID=tk.RoleID
                WHERE vt.TenVaiTro='ADMIN' AND tk.TrangThai=N'Hoạt động';
            IF NOT EXISTS (SELECT 1 FROM dbo.TAI_KHOAN tk JOIN dbo.VAI_TRO vt ON vt.RoleID=tk.RoleID
                JOIN dbo.NHAN_VIEN nv ON nv.NhanVienID=tk.NhanVienID
                WHERE tk.TaiKhoanID=@admin AND tk.TrangThai=N'Hoạt động' AND vt.TenVaiTro='ADMIN' AND nv.TrangThai=N'Đang làm')
                THROW 50001, N'Phiên hiện tại không còn quyền Admin. Vui lòng đăng nhập lại.', 1;";

        private static void KiemTraSession()
        {
            if (Session.Role != "ADMIN" || Session.TaiKhoanID <= 0)
                throw new InvalidOperationException("Chỉ Admin được quản lý tài khoản.");
        }

        private T DocQuanTri<T>(Func<SqlConnection, SqlTransaction, int, T> thaoTac)
        {
            int maAdmin = Session.TaiKhoanID;
            KiemTraSession();
            using var ketNoi = TaoKetNoi();
            ketNoi.Open();
            using var giaoDich = ketNoi.BeginTransaction(IsolationLevel.Serializable);
            using (var lenh = new SqlCommand(BaoVeAdmin, ketNoi, giaoDich))
            {
                lenh.Parameters.Add("@admin", SqlDbType.Int).Value = maAdmin;
                lenh.ExecuteNonQuery();
            }
            T ketQua = thaoTac(ketNoi, giaoDich, maAdmin);
            giaoDich.Commit();
            return ketQua;
        }

        private static DataTable DocBang(SqlCommand lenh)
        {
            using var adapter = new SqlDataAdapter(lenh);
            var bang = new DataTable();
            adapter.Fill(bang);
            return bang;
        }

        public DataTable DanhSach() => DocQuanTri((kn, gd, maAdmin) =>
        {
            using var lenh = new SqlCommand(@"
                SELECT tk.TaiKhoanID,tk.TenDangNhap,tk.NhanVienID,
                       COALESCE(nv.HoTen,tk.HoTenDangKy) AS HoTen,
                       COALESCE(nv.SDT,tk.SDTDangKy) AS SDT,
                       tk.RoleID,vt.TenVaiTro,tk.TrangThai,tk.NgayDangKy
                FROM dbo.TAI_KHOAN tk LEFT JOIN dbo.NHAN_VIEN nv ON nv.NhanVienID=tk.NhanVienID
                LEFT JOIN dbo.VAI_TRO vt ON vt.RoleID=tk.RoleID
                ORDER BY CASE WHEN tk.TrangThai=N'Chờ duyệt' THEN 0 ELSE 1 END,tk.TaiKhoanID DESC;", kn, gd);
            return DocBang(lenh);
        });

        public DataTable LayVaiTro() => DocQuanTri((kn, gd, maAdmin) =>
        {
            // KHO chưa có màn hình riêng trong MainForm nên không cấp qua màn hình này.
            using var lenh = new SqlCommand(@"SELECT RoleID,TenVaiTro,
                CASE TenVaiTro WHEN 'ADMIN' THEN N'Quản lý' WHEN 'BEP' THEN N'Bếp'
                WHEN 'PHUCVU' THEN N'Phục vụ' WHEN 'THUNGAN' THEN N'Thu ngân' END AS TenHienThi
                FROM dbo.VAI_TRO WHERE TenVaiTro IN ('ADMIN','BEP','PHUCVU','THUNGAN') ORDER BY RoleID", kn, gd);
            return DocBang(lenh);
        });

        public DataTable LayNhanVienChuaCoTaiKhoan() => DocQuanTri((kn, gd, maAdmin) =>
        {
            using var lenh = new SqlCommand(@"SELECT nv.NhanVienID,
                CONCAT(nv.NhanVienID,N' — ',nv.HoTen) AS TenHienThi
                FROM dbo.NHAN_VIEN nv WHERE nv.TrangThai=N'Đang làm' AND NOT EXISTS
                (SELECT 1 FROM dbo.TAI_KHOAN tk WHERE tk.NhanVienID=nv.NhanVienID) ORDER BY nv.HoTen", kn, gd);
            return DocBang(lenh);
        });

        private const string KiemTraTaiKhoan = @"
            IF NOT EXISTS (SELECT 1 FROM dbo.TAI_KHOAN WITH (UPDLOCK,HOLDLOCK) WHERE TaiKhoanID=@id)
                THROW 50001, N'Tài khoản không còn tồn tại. Hãy tải lại danh sách.', 1;";
        private const string KiemTraVaiTro = @"
            IF NOT EXISTS (SELECT 1 FROM dbo.VAI_TRO WHERE RoleID=@role AND TenVaiTro IN ('ADMIN','BEP','PHUCVU','THUNGAN'))
                THROW 50001, N'Vai trò được chọn không hợp lệ.', 1;";

        private T ThayDoi<T>(int ma, string sql, Action<SqlCommand>? ganThamSo, Func<SqlCommand,T> chay)
        {
            return DocQuanTri((kn, gd, maAdmin) =>
            {
                using var lenh = new SqlCommand(KiemTraTaiKhoan + sql, kn, gd);
                lenh.Parameters.Add("@id", SqlDbType.Int).Value = ma;
                lenh.Parameters.Add("@admin", SqlDbType.Int).Value = maAdmin;
                ganThamSo?.Invoke(lenh);
                return chay(lenh);
            });
        }

        public int Duyet(int ma, int roleID) => ThayDoi(ma, KiemTraVaiTro + @"
            DECLARE @hoTen NVARCHAR(100),@sdt VARCHAR(15),@vaiTro VARCHAR(30);
            SELECT @hoTen=HoTenDangKy,@sdt=SDTDangKy FROM dbo.TAI_KHOAN
                WHERE TaiKhoanID=@id AND TrangThai=N'Chờ duyệt' AND NhanVienID IS NULL;
            IF @hoTen IS NULL OR @sdt IS NULL THROW 50001, N'Tài khoản không ở trạng thái chờ duyệt hoặc thiếu thông tin.', 1;
            IF EXISTS (SELECT 1 FROM dbo.NHAN_VIEN WITH (UPDLOCK,HOLDLOCK) WHERE SDT=@sdt)
                THROW 50001, N'Số điện thoại đã có nhân viên sử dụng. Hãy kiểm tra lại trước khi duyệt.', 1;
            SELECT @vaiTro=TenVaiTro FROM dbo.VAI_TRO WHERE RoleID=@role;
            INSERT dbo.NHAN_VIEN(HoTen,SDT,ChucVu) VALUES (@hoTen,@sdt,
                CASE @vaiTro WHEN 'ADMIN' THEN N'Quản lý' WHEN 'BEP' THEN N'Đầu bếp'
                WHEN 'PHUCVU' THEN N'Phục vụ' ELSE N'Thu ngân' END);
            DECLARE @maNV INT=CAST(SCOPE_IDENTITY() AS INT);
            UPDATE dbo.TAI_KHOAN SET NhanVienID=@maNV,RoleID=@role,TrangThai=N'Hoạt động' WHERE TaiKhoanID=@id;
            SELECT @maNV;", l => l.Parameters.Add("@role", SqlDbType.Int).Value = roleID,
            l => Convert.ToInt32(l.ExecuteScalar()));

        public void TuChoi(int ma) => ThayDoi(ma, @"
            UPDATE dbo.TAI_KHOAN SET TrangThai=N'Từ chối' WHERE TaiKhoanID=@id AND TrangThai=N'Chờ duyệt';
            IF @@ROWCOUNT<>1 THROW 50001, N'Chỉ được từ chối tài khoản chờ duyệt.', 1;", null, l => l.ExecuteNonQuery());

        public void CapNhat(int ma, string ten, int roleID)
        {
            ten = ten.Trim();
            KiemTraTen(ten);
            ThayDoi(ma, KiemTraVaiTro + @"
                IF NOT EXISTS (SELECT 1 FROM dbo.TAI_KHOAN WHERE TaiKhoanID=@id AND NhanVienID IS NOT NULL)
                    THROW 50001, N'Chỉ sửa tài khoản đã được duyệt.', 1;
                IF EXISTS (SELECT 1 FROM dbo.TAI_KHOAN WITH (UPDLOCK,HOLDLOCK) WHERE TenDangNhap=@ten AND TaiKhoanID<>@id)
                    THROW 50001, N'Tên đăng nhập đã tồn tại.', 1;
                IF @id=@admin AND NOT EXISTS (SELECT 1 FROM dbo.VAI_TRO WHERE RoleID=@role AND TenVaiTro='ADMIN')
                    THROW 50001, N'Không thể tự hạ quyền tài khoản đang đăng nhập.', 1;
                IF EXISTS (SELECT 1 FROM dbo.TAI_KHOAN tk JOIN dbo.VAI_TRO vt ON vt.RoleID=tk.RoleID
                    WHERE tk.TaiKhoanID=@id AND vt.TenVaiTro='ADMIN' AND tk.TrangThai=N'Hoạt động')
                    AND NOT EXISTS (SELECT 1 FROM dbo.VAI_TRO WHERE RoleID=@role AND TenVaiTro='ADMIN')
                    AND (SELECT COUNT(*) FROM dbo.TAI_KHOAN tk JOIN dbo.VAI_TRO vt ON vt.RoleID=tk.RoleID
                         WHERE vt.TenVaiTro='ADMIN' AND tk.TrangThai=N'Hoạt động')<=1
                    THROW 50001, N'Phải giữ ít nhất một Admin hoạt động.', 1;
                UPDATE dbo.TAI_KHOAN SET TenDangNhap=@ten,RoleID=@role WHERE TaiKhoanID=@id;", l =>
                {
                    l.Parameters.Add("@ten", SqlDbType.VarChar, 50).Value = ten;
                    l.Parameters.Add("@role", SqlDbType.Int).Value = roleID;
                }, l => l.ExecuteNonQuery());
        }

        public void DoiTrangThai(int ma, bool khoa) => ThayDoi(ma, @"
            IF @id=@admin THROW 50001, N'Không thể khóa/mở khóa tài khoản đang đăng nhập.', 1;
            IF @khoa=1 AND EXISTS (SELECT 1 FROM dbo.TAI_KHOAN tk JOIN dbo.VAI_TRO vt ON vt.RoleID=tk.RoleID
                WHERE tk.TaiKhoanID=@id AND vt.TenVaiTro='ADMIN' AND tk.TrangThai=N'Hoạt động')
                AND (SELECT COUNT(*) FROM dbo.TAI_KHOAN tk JOIN dbo.VAI_TRO vt ON vt.RoleID=tk.RoleID
                     WHERE vt.TenVaiTro='ADMIN' AND tk.TrangThai=N'Hoạt động')<=1
                THROW 50001, N'Không thể khóa Admin hoạt động cuối cùng.', 1;
            IF @khoa=0 AND NOT EXISTS (SELECT 1 FROM dbo.TAI_KHOAN tk JOIN dbo.NHAN_VIEN nv ON nv.NhanVienID=tk.NhanVienID
                WHERE tk.TaiKhoanID=@id AND nv.TrangThai=N'Đang làm')
                THROW 50001, N'Chỉ mở khóa được tài khoản của nhân viên đang làm.', 1;
            UPDATE dbo.TAI_KHOAN SET TrangThai=CASE WHEN @khoa=1 THEN N'Bị khóa' ELSE N'Hoạt động' END
                WHERE TaiKhoanID=@id AND TrangThai=CASE WHEN @khoa=1 THEN N'Hoạt động' ELSE N'Bị khóa' END;
            IF @@ROWCOUNT<>1 THROW 50001, N'Trạng thái tài khoản không phù hợp. Hãy tải lại danh sách.', 1;",
            l => l.Parameters.Add("@khoa", SqlDbType.Bit).Value = khoa, l => l.ExecuteNonQuery());

        public void DatLaiMatKhau(int ma, string matKhau)
        {
            KiemTraMatKhau(matKhau);
            string hash = BaoMatMatKhau.BamMatKhau(matKhau);
            ThayDoi(ma, @"
                UPDATE dbo.TAI_KHOAN SET MatKhauHash=@hash WHERE TaiKhoanID=@id AND NhanVienID IS NOT NULL;
                IF @@ROWCOUNT<>1 THROW 50001, N'Chỉ đặt lại mật khẩu cho tài khoản đã duyệt.', 1;",
                l => l.Parameters.Add("@hash", SqlDbType.VarChar, 255).Value = hash, l => l.ExecuteNonQuery());
        }

        public void TaoTaiKhoan(int maNV, string ten, int roleID, string matKhau)
        {
            ten = ten.Trim();
            KiemTraTen(ten);
            KiemTraMatKhau(matKhau);
            string hash = BaoMatMatKhau.BamMatKhau(matKhau);
            DocQuanTri((kn, gd, maAdmin) =>
            {
                using var lenh = new SqlCommand(KiemTraVaiTro + @"
                    IF NOT EXISTS (SELECT 1 FROM dbo.NHAN_VIEN WITH (UPDLOCK,HOLDLOCK) WHERE NhanVienID=@nv AND TrangThai=N'Đang làm')
                        THROW 50001, N'Nhân viên không tồn tại hoặc không còn đang làm.', 1;
                    IF EXISTS (SELECT 1 FROM dbo.TAI_KHOAN WITH (UPDLOCK,HOLDLOCK) WHERE NhanVienID=@nv OR TenDangNhap=@ten)
                        THROW 50001, N'Nhân viên đã có tài khoản hoặc tên đăng nhập đã tồn tại.', 1;
                    INSERT dbo.TAI_KHOAN(TenDangNhap,MatKhauHash,TrangThai,RoleID,NhanVienID)
                        VALUES (@ten,@hash,N'Hoạt động',@role,@nv);", kn, gd);
                lenh.Parameters.Add("@ten", SqlDbType.VarChar, 50).Value = ten;
                lenh.Parameters.Add("@role", SqlDbType.Int).Value = roleID;
                lenh.Parameters.Add("@hash", SqlDbType.VarChar, 255).Value = hash;
                return lenh.ExecuteNonQuery();
            });
        }

        public int DuyetNhanVienMoi(
            int taiKhoanID,
            int roleID,
            ThongTinNhanVien thongTin)
        {
            if (thongTin == null)
                throw new ArgumentNullException(nameof(thongTin));

            if (string.IsNullOrWhiteSpace(thongTin.HoTen))
                throw new InvalidOperationException(
                    "Họ tên nhân viên không được để trống.");

            if (string.IsNullOrWhiteSpace(thongTin.SDT) ||
                thongTin.SDT.Length != 10 ||
                thongTin.SDT[0] != '0' ||
                !thongTin.SDT.All(char.IsDigit))
                throw new InvalidOperationException(
                    "Số điện thoại phải gồm 10 chữ số, bắt đầu bằng 0.");

            return ThayDoi(
                taiKhoanID,
                KiemTraVaiTro + @"
            DECLARE @vaiTro VARCHAR(30);
            DECLARE @hoTenDangKy NVARCHAR(100);
            DECLARE @sdtDangKy VARCHAR(15);

            -- Kiểm tra yêu cầu đăng ký
            SELECT
                @hoTenDangKy = HoTenDangKy,
                @sdtDangKy = SDTDangKy
            FROM dbo.TAI_KHOAN WITH (UPDLOCK, HOLDLOCK)
            WHERE TaiKhoanID = @id
              AND TrangThai = N'Chờ duyệt'
              AND NhanVienID IS NULL;

            IF @hoTenDangKy IS NULL OR @sdtDangKy IS NULL
                THROW 50001,
                    N'Tài khoản không hợp lệ hoặc đã được xử lý.', 1;

            -- Chống trùng số điện thoại
            IF EXISTS (
                SELECT 1
                FROM dbo.NHAN_VIEN WITH (UPDLOCK, HOLDLOCK)
                WHERE SDT = @sdt
            )
                THROW 50001,
                    N'Số điện thoại đã tồn tại trong hồ sơ nhân viên.', 1;

            SELECT @vaiTro = TenVaiTro
            FROM dbo.VAI_TRO
            WHERE RoleID = @role;
IF LTRIM(RTRIM(@hoTenDangKy)) <> LTRIM(RTRIM(@hoTen))
   OR @sdtDangKy <> @sdt
    THROW 50001,
        N'Họ tên hoặc số điện thoại không khớp với thông tin đăng ký.', 1;
            -- Tạo hồ sơ nhân viên
            INSERT INTO dbo.NHAN_VIEN
            (
                HoTen,
                SDT,
                NgaySinh,
                GioiTinh,
                Email,
                DiaChi,
                ChucVu,
                NgayVaoLam,
                TrangThai
            )
            VALUES
            (
                @hoTen,
                @sdt,
                @ngaySinh,
                @gioiTinh,
                @email,
                @diaChi,
                CASE @vaiTro
                    WHEN 'ADMIN' THEN N'Quản lý'
                    WHEN 'BEP' THEN N'Đầu bếp'
                    WHEN 'PHUCVU' THEN N'Phục vụ'
                    WHEN 'THUNGAN' THEN N'Thu ngân'
                END,
                @ngayVaoLam,
                N'Đang làm'
            );

            -- Lấy mã nhân viên tự sinh
            DECLARE @maNV INT =
                CAST(SCOPE_IDENTITY() AS INT);

            -- Liên kết tài khoản
            UPDATE dbo.TAI_KHOAN
            SET NhanVienID = @maNV,
                RoleID = @role,
                TrangThai = N'Hoạt động'
            WHERE TaiKhoanID = @id
              AND TrangThai = N'Chờ duyệt'
              AND NhanVienID IS NULL;

            IF @@ROWCOUNT <> 1
                THROW 50001,
                    N'Không thể liên kết tài khoản.', 1;

            SELECT @maNV;
        ",
                lenh =>
                {
                    lenh.Parameters.Add("@role", SqlDbType.Int)
                        .Value = roleID;

                    lenh.Parameters.Add("@hoTen", SqlDbType.NVarChar, 100)
                        .Value = thongTin.HoTen.Trim();

                    lenh.Parameters.Add("@sdt", SqlDbType.VarChar, 15)
                        .Value = thongTin.SDT.Trim();

                    lenh.Parameters.Add("@ngaySinh", SqlDbType.Date)
                        .Value = (object?)thongTin.NgaySinh ?? DBNull.Value;

                    lenh.Parameters.Add("@gioiTinh", SqlDbType.NVarChar, 10)
                        .Value = (object?)thongTin.GioiTinh ?? DBNull.Value;

                    lenh.Parameters.Add("@email", SqlDbType.VarChar, 100)
                        .Value = (object?)thongTin.Email ?? DBNull.Value;

                    lenh.Parameters.Add("@diaChi", SqlDbType.NVarChar, 255)
                        .Value = (object?)thongTin.DiaChi ?? DBNull.Value;

                    lenh.Parameters.Add("@ngayVaoLam", SqlDbType.Date)
                        .Value = thongTin.NgayVaoLam;
                },
                lenh => Convert.ToInt32(lenh.ExecuteScalar())
            );
        }
        // load panel thong tin dang ki
        public DataRow? LayThongTinDangKy(int taiKhoanID)
        {
            return DocQuanTri((conn, tran, adminID) =>
            {
                const string sql = @"
            SELECT
                TaiKhoanID,
                TenDangNhap,
                HoTenDangKy,
                SDTDangKy,
                NgayDangKy,
                TrangThai
            FROM dbo.TAI_KHOAN
            WHERE TaiKhoanID = @TaiKhoanID
              AND TrangThai = N'Chờ duyệt'";

                using SqlCommand cmd = new SqlCommand(sql, conn, tran);

                cmd.Parameters.Add("@TaiKhoanID", SqlDbType.Int)
                              .Value = taiKhoanID;

                DataTable dt = DocBang(cmd);

                if (dt.Rows.Count == 0)
                    return null;

                return dt.Rows[0];
            });
        }

        // cac phuong thuc cho button xac nhan duyet



    }
}
