using System.Data;
using Microsoft.Data.SqlClient;
using QLNhaHang.Classes;
using System.Reflection;
using System.Drawing;
using QLNhaHang.Controls.Admin;

internal static class Program
{
    private static int soKiemTra;
    private static string chuoi = "";
    private static QuanLyTaiKhoan xuLy = null!;
    [STAThread]
    static void Main(string[] args)
    {
        if (args.Contains("--giao-dien")) { KiemTraTenCot(); return; }
        string goc = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
        string mayChu = args.Length > 0 ? args[0] : @".\SQLEXPRESS";
        string tenDB = "QLNH_KiemTraTaiKhoan_" + Guid.NewGuid().ToString("N");
        var builder = new SqlConnectionStringBuilder { DataSource=mayChu, InitialCatalog="master", IntegratedSecurity=true, TrustServerCertificate=true, ConnectTimeout=5 };
        using var master = new SqlConnection(builder.ConnectionString);
        master.Open();
        using (var tao = new SqlCommand($"CREATE DATABASE [{tenDB}]", master)) tao.ExecuteNonQuery();
        builder.InitialCatalog = tenDB;
        chuoi = builder.ConnectionString;
        try
        {
            Chay(@"
                CREATE TABLE dbo.VAI_TRO(RoleID INT IDENTITY PRIMARY KEY,TenVaiTro VARCHAR(30) NOT NULL UNIQUE);
                CREATE TABLE dbo.NHAN_VIEN(NhanVienID INT IDENTITY PRIMARY KEY,HoTen NVARCHAR(100) NOT NULL,
                    SDT VARCHAR(15),ChucVu NVARCHAR(50) NOT NULL,NgayVaoLam DATE NOT NULL DEFAULT GETDATE(),
                    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Đang làm');
                CREATE TABLE dbo.TAI_KHOAN(TaiKhoanID INT IDENTITY PRIMARY KEY,TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
                    MatKhauHash VARCHAR(255) NOT NULL,TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Hoạt động',
                    RoleID INT NOT NULL REFERENCES dbo.VAI_TRO(RoleID),NhanVienID INT NOT NULL UNIQUE REFERENCES dbo.NHAN_VIEN(NhanVienID),
                    CONSTRAINT CK_TK_TrangThai CHECK(TrangThai IN (N'Hoạt động',N'Bị khóa')));
                INSERT dbo.VAI_TRO(TenVaiTro) VALUES ('ADMIN'),('BEP'),('PHUCVU'),('THUNGAN');
                INSERT dbo.NHAN_VIEN(HoTen,SDT,ChucVu) VALUES (N'Admin kiểm thử','0900000001',N'Quản lý'),(N'Nhân viên có sẵn','0900000002',N'Bếp');
                INSERT dbo.TAI_KHOAN(TenDangNhap,MatKhauHash,RoleID,NhanVienID) VALUES ('admin_test','CuMatKhau123',1,1);
                CREATE TABLE dbo.YEU_CAU_DANG_KY(YeuCauID INT IDENTITY PRIMARY KEY,HoTen NVARCHAR(100),SDT VARCHAR(15),TenDangNhap VARCHAR(50),
                    MatKhauHash VARCHAR(255),NgayDangKy DATETIME2 DEFAULT SYSDATETIME(),TrangThai NVARCHAR(20));
                INSERT dbo.YEU_CAU_DANG_KY(HoTen,SDT,TenDangNhap,MatKhauHash,TrangThai)
                    VALUES (N'Yêu cầu cũ','0900000010','yeucau_cu','hashcu',N'Chờ duyệt'),(N'Từ chối cũ','0900000011','tuchoi_cu','hashcu',N'Từ chối');
            ");
            string migration = File.ReadAllText(Path.Combine(goc,"Database","DangKyTaiKhoan.sql"));
            Chay("ALTER TABLE dbo.TAI_KHOAN ADD PhienBan ROWVERSION;");
            Chay(migration);
            Chay(migration);
            Dung(So("SELECT COUNT(*) FROM sys.columns WHERE object_id=OBJECT_ID('dbo.TAI_KHOAN') AND name='PhienBan'")==0,
                "Migration bỏ cột phiên bản và chạy lại được");
            Dung(So("SELECT COUNT(*) FROM dbo.TAI_KHOAN") == 3, "Migration chạy lại không nhân đôi, giữ tài khoản và chuyển yêu cầu cũ");
            Dung(So("SELECT COUNT(*) FROM dbo.TAI_KHOAN WHERE NhanVienID IS NULL AND RoleID IS NULL") == 2, "Nhiều tài khoản chưa có mã và quyền");
            Session.Role = "ADMIN"; Session.TaiKhoanID = 1;
            xuLy = new QuanLyTaiKhoan(chuoi);
            Dung(xuLy.DangNhap("admin_test","ADMIN","CuMatKhau123") != null, "Đăng nhập mật khẩu cũ");
            Dung(Chuoi("SELECT MatKhauHash FROM dbo.TAI_KHOAN WHERE TaiKhoanID=1").StartsWith("PBKDF2-SHA256$"), "Tự chuyển mật khẩu cũ thành hash");
            xuLy.GuiYeuCau("Đăng ký một","0900000020","dangky_mot","MatKhau123!");
            xuLy.GuiYeuCau("Đăng ký hai","0900000021","dangky_hai","MatKhau123!");
            DataRow mot = Dong("dangky_mot");
            int ma = (int)mot["TaiKhoanID"];
            Dung(mot.IsNull("NhanVienID") && mot.IsNull("RoleID") && mot.Field<string>("TrangThai")=="Chờ duyệt", "Đăng ký lưu trực tiếp vào TAI_KHOAN với mã NULL");
            Dung(xuLy.DangNhap("dangky_mot","ADMIN","MatKhau123!") == null, "Chờ duyệt không đăng nhập được");
            Chan(() => xuLy.GuiYeuCau("Trùng tên","0900000022","dangky_mot","MatKhau123!"),"Chặn trùng tên đăng nhập");
            Chan(() => xuLy.GuiYeuCau("Trùng SĐT","0900000020","ten_khac","MatKhau123!"),"Chặn trùng SĐT chờ duyệt");
            Chan(() => xuLy.GuiYeuCau("Trùng NV","0900000002","ten_khac","MatKhau123!"),"Chặn SĐT nhân viên có sẵn");
            Chan(() => xuLy.GuiYeuCau("Sai tên","0900000022","x'; DROP TABLE dbo.TAI_KHOAN;--","MatKhau123!"),"Kiểm tra tên không hợp lệ");
            int soNV = So("SELECT COUNT(*) FROM dbo.NHAN_VIEN");
            int nv = xuLy.Duyet(ma,2);
            Dung(So("SELECT COUNT(*) FROM dbo.NHAN_VIEN") == soNV+1 && (int)Dong("dangky_mot")["NhanVienID"] == nv, "Duyệt sinh mã nhân viên và liên kết tài khoản cũ");
            Dung(xuLy.DangNhap("dangky_mot","BEP","MatKhau123!") != null, "Tài khoản đã duyệt đăng nhập bằng hash");
            Dung(xuLy.DangNhap("dangky_mot","BEP","SaiMatKhau") == null, "Chặn sai mật khẩu");
            Chan(() => xuLy.Duyet(ma,2),"Chặn duyệt lặp theo trạng thái");
            mot=Dong("dangky_mot");
            xuLy.CapNhat(ma,"doi_ten",4);
            Dung(Dong("doi_ten").Field<string>("TenVaiTro")=="THUNGAN", "Đổi tên đăng nhập và quyền");
            mot=Dong("doi_ten"); xuLy.DatLaiMatKhau(ma,"MatKhauMoi123");
            Dung(xuLy.DangNhap("doi_ten","THUNGAN","MatKhau123!")==null && xuLy.DangNhap("doi_ten","THUNGAN","MatKhauMoi123")!=null, "Đặt lại mật khẩu: mật khẩu cũ hết hiệu lực");
            mot=Dong("doi_ten"); xuLy.DoiTrangThai(ma,true);
            Dung(xuLy.DangNhap("doi_ten","THUNGAN","MatKhauMoi123")==null,"Tài khoản khóa không đăng nhập được");
            mot=Dong("doi_ten"); xuLy.DoiTrangThai(ma,false);
            Dung(xuLy.DangNhap("doi_ten","THUNGAN","MatKhauMoi123")!=null,"Mở khóa đăng nhập lại được");
            DataRow admin=Dong("admin_test");
            Chan(() => xuLy.DoiTrangThai(1,true),"Không tự khóa Admin đang dùng");
            Chan(() => xuLy.CapNhat(1,"admin_test",2),"Không tự hạ quyền Admin cuối cùng");
            DataRow hai=Dong("dangky_hai"); xuLy.TuChoi((int)hai["TaiKhoanID"]);
            Dung(Dong("dangky_hai").Field<string>("TrangThai")=="Từ chối" && Dong("dangky_hai").IsNull("NhanVienID"),"Từ chối không sinh nhân viên");
            xuLy.TaoTaiKhoan(2,"cap_san",2,"MatKhauCap123");
            Dung(xuLy.DangNhap("cap_san","BEP","MatKhauCap123")!=null,"Admin cấp tài khoản cho nhân viên có sẵn");
            Chan(() => xuLy.TaoTaiKhoan(2,"cap_trung",2,"MatKhauCap123"),"Mỗi nhân viên chỉ có một tài khoản");
            xuLy.GuiYeuCau("Rollback","0900000030","rollback_test","MatKhau123!");
            soNV=So("SELECT COUNT(*) FROM dbo.NHAN_VIEN");
            Chay("CREATE TRIGGER dbo.TestRollback ON dbo.TAI_KHOAN AFTER UPDATE AS IF EXISTS(SELECT 1 FROM inserted WHERE TenDangNhap='rollback_test') THROW 50001,N'Lỗi kiểm thử sau khi tạo nhân viên',1;");
            var rollback=Dong("rollback_test");
            Chan(() => xuLy.Duyet((int)rollback["TaiKhoanID"],2),"Lỗi sau INSERT nhân viên làm rollback transaction");
            Dung(So("SELECT COUNT(*) FROM dbo.NHAN_VIEN")==soNV && Dong("rollback_test").IsNull("NhanVienID"),"Rollback không để nhân viên mồ côi");
            Chay("DROP TRIGGER dbo.TestRollback;");
            xuLy.GuiYeuCau("Đồng thời","0900000040","dong_thoi","MatKhau123!");
            var dongThoi=Dong("dong_thoi"); int thanhCong=0;
            soNV=So("SELECT COUNT(*) FROM dbo.NHAN_VIEN");
            Task.WaitAll(Enumerable.Range(0,2).Select(_ => Task.Run(() => {
                try { xuLy.Duyet((int)dongThoi["TaiKhoanID"],2); Interlocked.Increment(ref thanhCong); }
                catch(SqlException ex) when(ex.Number is 50001 or 1205) { }
            })).ToArray());
            Dung(thanhCong==1 && So("SELECT COUNT(*) FROM dbo.NHAN_VIEN")==soNV+1,"Hai lần duyệt đồng thời chỉ tạo một nhân viên");
            Session.Role="BEP";
            Chan(() => xuLy.DanhSach(),"Người không phải Admin không được đọc quản trị");
            Session.Role="ADMIN"; Session.TaiKhoanID=ma;
            Chan(() => xuLy.DanhSach(),"Không tin Session nếu database đã đổi quyền");
            Session.TaiKhoanID=1;
            // Kiểm tra bố cục bằng dữ liệu giả, không mở phiên database thật.
            ApplicationConfiguration.Initialize();
            using var uc=new TaiKhoanKhongTaiDuLieu();
            typeof(ucTaiKhoan).GetField("danhSach",BindingFlags.Instance|BindingFlags.NonPublic)!.SetValue(uc,xuLy.DanhSach());
            var cboQuyen=(ComboBox)typeof(ucTaiKhoan).GetField("cbVaiTro",BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
            cboQuyen.DisplayMember="TenHienThi"; cboQuyen.ValueMember="RoleID"; cboQuyen.DataSource=xuLy.LayVaiTro();
            foreach(var cap in new[] { ("lblTongSo","8"),("lblChoDuyet","2"),("lblHoatDong","4"),("lblBiKhoa","0") })
                ((Label)typeof(ucTaiKhoan).GetField(cap.Item1,BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!).Text=cap.Item2;
            using var form=new Form { ClientSize=new Size(1280,850), AutoScaleMode=AutoScaleMode.None, ShowInTaskbar=false, Opacity=0 };
            uc.Dock=DockStyle.Fill; form.Controls.Add(uc);
            form.Show(); Application.DoEvents(); uc.PerformLayout();
            typeof(ucTaiKhoan).GetMethod("LocDanhSach",BindingFlags.Instance|BindingFlags.NonPublic)!.Invoke(uc,new object?[]{null});
            var grid=(DataGridView)typeof(ucTaiKhoan).GetField("dgvTaiKhoan",BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
            Dung(!grid.AutoGenerateColumns && grid.Columns.Count==7,"Lưới chỉ hiển thị cột cho phép, không lộ hash hoặc phiên bản");
            var tim=(TextBox)typeof(ucTaiKhoan).GetField("txtTimKiem",BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
            tim.Text="'[%*";
            Dung(grid.Rows.Count==0,"Tìm kiếm ký tự đặc biệt không làm lỗi bộ lọc");
            tim.Clear();
            var loc=(ComboBox)typeof(ucTaiKhoan).GetField("cbLocTrangThai",BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
            loc.SelectedIndex=1;
            Dung(grid.Rows.Cast<DataGridViewRow>().All(r => r.Cells["colTrangThai"].Value?.ToString()=="Chờ duyệt"),"Bộ lọc chờ duyệt hoạt động");
            string anh=Path.Combine(goc,"obj","TaiKhoanPreview.png");
            loc.SelectedIndex=0;
            var nutDuyet=(Button)typeof(ucTaiKhoan).GetField("btnDuyet",BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
            var chiTiet=(FlowLayoutPanel)typeof(ucTaiKhoan).GetField("pnlChiTiet",BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
            Dung(chiTiet.RectangleToClient(nutDuyet.RectangleToScreen(nutDuyet.ClientRectangle)).Bottom <= chiTiet.ClientSize.Height,
                "Nút duyệt không bị cắt ở cửa sổ 1280x850");
            using var bitmap=new Bitmap(uc.Width,uc.Height); uc.DrawToBitmap(bitmap,uc.ClientRectangle); bitmap.Save(anh);
            Console.WriteLine("PREVIEW: "+anh);
            grid.CurrentCell=grid.Rows.Cast<DataGridViewRow>().Single(r=>r.Cells["colTenDangNhap"].Value?.ToString()=="cap_san").Cells["colTenDangNhap"];
            var nutKhoa=(Button)typeof(ucTaiKhoan).GetField("btnKhoa",BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
            Dung(chiTiet.RectangleToClient(nutKhoa.RectangleToScreen(nutKhoa.ClientRectangle)).Bottom<=chiTiet.ClientSize.Height,
                "Nút lưu/khóa hiển thị đầy đủ cho tài khoản đã duyệt");
            var tab=(TabControl)typeof(ucTaiKhoan).GetField("tabChiTiet",BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
            tab.SelectedIndex=1; Application.DoEvents();
            var nutDatLai=(Button)typeof(ucTaiKhoan).GetField("btnDatLaiMatKhau",BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
            var khungMatKhau=(FlowLayoutPanel)typeof(ucTaiKhoan).GetField("pnlMatKhau",BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
            Dung(khungMatKhau.RectangleToClient(nutDatLai.RectangleToScreen(nutDatLai.ClientRectangle)).Bottom<=khungMatKhau.ClientSize.Height,
                "Tab mật khẩu hiển thị đầy đủ nút đặt lại");
            tab.SelectedIndex=0;
            form.ClientSize=new Size(1120,720); Application.DoEvents(); uc.PerformLayout();
            using var nho=new Bitmap(uc.Width,uc.Height); uc.DrawToBitmap(nho,uc.ClientRectangle);
            nho.Save(Path.Combine(goc,"obj","TaiKhoanPreviewSmall.png"));
            form.Close();
            Console.WriteLine($"PASS: {soKiemTra} kiểm tra.");
        }
        finally
        {
            SqlConnection.ClearAllPools();
            using var don = new SqlCommand($"ALTER DATABASE [{tenDB}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{tenDB}];",master);
            don.ExecuteNonQuery();
        }
    }
    private static void KiemTraTenCot()
    {
        ApplicationConfiguration.Initialize();
        using var uc = new TaiKhoanKhongTaiDuLieu();
        using var form = new Form { ClientSize=new Size(1280,850),ShowInTaskbar=false,Opacity=0 };
        form.Controls.Add(uc); uc.Dock=DockStyle.Fill;
        form.Show(); Application.DoEvents();
        var kieu=typeof(ucTaiKhoan);
        var grid=(DataGridView)kieu.GetField("dgvTaiKhoan",BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
        Dung(!grid.AutoGenerateColumns && grid.Columns.Count==7 && grid.Columns.Contains("colTenDangNhap"), "Designer có đủ cột và không tự sinh cột ngoài ý muốn");
        var bang=new DataTable();
        foreach(string cot in new[]{"TaiKhoanID","NhanVienID","RoleID"}) bang.Columns.Add(cot,typeof(int));
        foreach(string cot in new[]{"TenDangNhap","HoTen","SDT","TrangThai","TenVaiTro"}) bang.Columns.Add(cot,typeof(string));
        foreach(int id in new[]{10,20})
        {
            DataRow dong=bang.NewRow(); dong["TaiKhoanID"]=id;dong["TenDangNhap"]="taikhoan_"+id;
            dong["HoTen"]="Nhân viên mẫu";dong["SDT"]="0900000000";dong["TrangThai"]="Chờ duyệt";
            bang.Rows.Add(dong);
        }
        kieu.GetField("danhSach",BindingFlags.Instance|BindingFlags.NonPublic)!.SetValue(uc,bang);
        var loc=kieu.GetMethod("LocDanhSach",BindingFlags.Instance|BindingFlags.NonPublic)!;
        loc.Invoke(uc,new object?[]{null});
        Dung(grid.Rows.Count==2 && grid.CurrentCell?.OwningColumn.DataPropertyName=="TenDangNhap", "Tải danh sách và chọn dòng đầu không lỗi");
        foreach(DataGridViewColumn cot in grid.Columns) cot.Name="tenDesigner_"+cot.Index;
        loc.Invoke(uc,new object?[]{20});
        Dung(((DataRowView)grid.CurrentRow!.DataBoundItem!).Row.Field<int>("TaiKhoanID")==20,
            "Đổi tên component cột vẫn chọn lại đúng tài khoản theo dữ liệu");
        grid.Columns.Cast<DataGridViewColumn>().Single(c=>c.DataPropertyName=="TenDangNhap").Visible=false;
        loc.Invoke(uc,new object?[]{10});
        Dung(grid.CurrentCell != null && grid.CurrentCell.OwningColumn.Visible,"Ẩn cột tên đăng nhập vẫn chọn được cột hiển thị khác");
        var tim=(TextBox)kieu.GetField("txtTimKiem",BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
        tim.Text="khong_co_tai_khoan";
        Dung(grid.Rows.Count==0 && grid.CurrentCell==null,"Danh sách rỗng không gây lỗi chọn dòng");
        tim.Clear();
        grid.Columns.Cast<DataGridViewColumn>().Single(c=>c.DataPropertyName=="TenDangNhap").Visible=true;
        foreach (var cap in new[] { ("lblTongSo","2"),("lblChoDuyet","2"),("lblHoatDong","0"),("lblBiKhoa","0") })
            ((Label)kieu.GetField(cap.Item1,BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!).Text=cap.Item2;
        form.ClientSize = new Size(1536, 760);
        Application.DoEvents();
        foreach (string tenNhan in new[] { "lblTieuDe", "lblNguoiDung", "lblMaNhanVien", "lblTrangThai", "lblNhanTen", "lblNhanVaiTro", "lblTongSo", "lblNhanTongSo" })
        {
            var nhan = (Label)kieu.GetField(tenNhan,BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(uc)!;
            Dung(nhan.AutoSize && nhan.Height >= nhan.GetPreferredSize(new Size(nhan.Width,0)).Height,
                "Label không cắt chữ: " + tenNhan);
        }
        string goc = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory,"..","..","..","..",".."));
        using (var anh = new Bitmap(uc.Width,uc.Height))
        {
            uc.DrawToBitmap(anh,uc.ClientRectangle);
            anh.Save(Path.Combine(goc,"obj","TaiKhoanSuaBoCuc.png"));
        }
        Console.WriteLine($"PASS: {soKiemTra} kiểm tra giao diện, không truy cập database.");
        form.Close();
    }

    private static void Chay(string sql) { using var kn=new SqlConnection(chuoi);kn.Open();using var lenh=new SqlCommand(sql,kn);lenh.ExecuteNonQuery(); }
    private static int So(string sql) => Convert.ToInt32(GiaTri(sql));
    private static string Chuoi(string sql) => Convert.ToString(GiaTri(sql))!;
    private static object? GiaTri(string sql) { using var kn=new SqlConnection(chuoi);kn.Open();using var lenh=new SqlCommand(sql,kn);return lenh.ExecuteScalar(); }
    private static DataRow Dong(string ten) => xuLy.DanhSach().AsEnumerable().Single(r => r.Field<string>("TenDangNhap")==ten);
    private static void Dung(bool dung,string ten) { if(!dung) throw new Exception("FAIL: "+ten); soKiemTra++;Console.WriteLine("PASS: "+ten); }
    private static void Chan(Action thaoTac,string ten) { try { thaoTac(); } catch(Exception ex) when(ex is InvalidOperationException || ex is SqlException sql && sql.Number is 50001 or 2601 or 2627) { Dung(true,ten);return; } throw new Exception("FAIL: "+ten); }

    private sealed class TaiKhoanKhongTaiDuLieu : ucTaiKhoan
    {
        protected override void OnLoad(EventArgs e) { }
    }
}

