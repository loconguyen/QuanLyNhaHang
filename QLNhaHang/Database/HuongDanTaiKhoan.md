# Quản lý tài khoản Admin

## Luồng dữ liệu

- Đăng ký ghi trực tiếp vào `TAI_KHOAN`: `TrangThai = N'Chờ duyệt'`, `NhanVienID = NULL`, `RoleID = NULL`.
- `HoTenDangKy`, `SDTDangKy` giữ thông tin trước khi có hồ sơ nhân viên.
- Khi duyệt, một transaction thêm `NHAN_VIEN` (mã `IDENTITY`), cập nhật chính tài khoản đang chờ và chuyển trạng thái thành `Hoạt động`.
- Từ chối giữ tài khoản ở trạng thái `Từ chối`, không tạo nhân viên. Tên đăng nhập vẫn được giữ lại.
- `NhanVienID` dùng unique filtered index để cho nhiều dòng NULL nhưng mỗi nhân viên có tối đa một tài khoản.
- Không xóa tài khoản đã duyệt: dùng Khóa để giữ liên kết với hồ sơ nhân viên và lịch sử nghiệp vụ.
- Số điện thoại được dùng để kiểm tra trùng người đăng ký trong phạm vi bài nhóm; đây không phải bước xác minh danh tính qua OTP.

## Mở giao diện

Đăng nhập Admin → **Tài khoản**. Tìm theo tên đăng nhập, họ tên, SĐT hoặc mã nhân viên; lọc theo trạng thái/vai trò.

- **Duyệt đăng ký**: chọn dòng chờ duyệt, chọn vai trò và duyệt. Thông báo sẽ hiện mã nhân viên được cấp.
- **Từ chối**: chỉ áp dụng cho dòng chờ duyệt.
- **Lưu thay đổi**: chỉnh tên đăng nhập hoặc quyền của tài khoản đã duyệt.
- **Khóa / Mở khóa**: không được tự khóa tài khoản đang đăng nhập. Nhân viên phải đang làm mới mở khóa được.
- Tab **Mật khẩu**: nhập và xác nhận mật khẩu mới, bấm Đặt lại mật khẩu.
- **Cấp tài khoản**: tạo tài khoản hoạt động cho nhân viên đang làm đã có hồ sơ nhưng chưa có tài khoản.

Các vai trò cấp qua màn hình này: ADMIN, BEP, PHUCVU, THUNGAN, phù hợp MainForm hiện tại. Vai trò KHO trong dữ liệu cũ chưa có màn hình riêng.

## Designer

Bố cục dùng control WinForms chuẩn, khai báo trong `ucTaiKhoan.Designer.cs` và `frmTaoTaiKhoan.Designer.cs`, không tạo control bằng vòng lặp lúc chạy. Mở **View Designer** để kéo thả, chỉnh thuộc tính, thêm control. File `.cs` chứa sự kiện và xử lý dữ liệu. Công cụ điều khiển Visual Studio trong phiên này không thao tác được ổn định nên các control được khai báo qua mã Designer, không được kéo thả trực tiếp trong IDE.

## Database trên máy thành viên khác

1. Sửa chuỗi kết nối trong `Classes/DataProcesser.cs` theo tên SQL Server của máy.
2. Database đã có dữ liệu: chạy **Database/DangKyTaiKhoan.sql**, không chạy lại toàn bộ file tạo database.
3. Database mới: dùng **Database/QLNhaHang.sql**. Cần có tài khoản Admin ban đầu trước khi sử dụng quản trị.

Script cập nhật có transaction, giữ dữ liệu cũ và chạy lại được. Nếu đã dùng bảng `YEU_CAU_DANG_KY` ở phiên bản trước, script chuyển yêu cầu chờ duyệt/từ chối chưa có tên trong TAI_KHOAN, giữ bảng cũ làm lịch sử. Nếu tên đã tồn tại, ưu tiên tài khoản hiện tại; kiểm tra yêu cầu cũ trùng tên trong bảng lịch sử.

## Kiểm tra

```powershell
dotnet build --no-restore
dotnet run --project Tests/TaiKhoan/TaiKhoan.Checks.csproj -- '.\SQLEXPRESS'
```

Bài kiểm tra cần quyền tạo database kiểm thử trên SQL Server. Nó tạo database tên ngẫu nhiên bắt đầu bằng `QLNH_KiemTraTaiKhoan_`, chạy các trường hợp chức năng và tự xóa đúng database tạm đó. Không chạy thao tác kiểm thử trên database nhà hàng. Ảnh bố cục bằng dữ liệu giả được xuất vào `obj/TaiKhoanPreview.png` và `obj/TaiKhoanPreviewSmall.png`.

Mật khẩu mới dùng PBKDF2-SHA256 với salt ngẫu nhiên. Tài khoản cũ đang lưu mật khẩu thô được chuyển sang hash sau lần đăng nhập đúng đầu tiên. Không hiển thị hash trong danh sách quản trị.


TAI_KHOAN không dùng cột PhienBan nữa. Với database cũ, chạy Database/XoaPhienBanTaiKhoan.sql. Thay đổi tên/quyền dùng nguyên tắc lần lưu sau ghi đè lần trước; kiểm tra quyền, trạng thái và transaction khi duyệt vẫn được giữ.

