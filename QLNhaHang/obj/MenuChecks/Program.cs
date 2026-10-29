using QLNhaHang.Classes;
int checks=0;
void Blocked(Action action, Type expected) { try { action(); throw new Exception("Operation unexpectedly allowed"); } catch(Exception ex) when(expected.IsInstanceOfType(ex)) { checks++; } }
foreach(string role in new[]{"BEP","PHUCVU","THUNGAN",""})
{
 Session.Role=role;
 Blocked(()=>QuanLyThucDon.Luu(null,"Món thử",1,10000,"Phần","","Đang bán"),typeof(UnauthorizedAccessException));
 Blocked(()=>QuanLyThucDon.Xoa(1),typeof(UnauthorizedAccessException));
 Blocked(()=>QuanLyThucDon.ThemDanhMuc("Danh mục thử"),typeof(UnauthorizedAccessException));
}
Session.Role="ADMIN";
Blocked(()=>QuanLyThucDon.Luu(null," ",1,10000,"Phần","","Đang bán"),typeof(ArgumentException));
Blocked(()=>QuanLyThucDon.Luu(1,"Món",1,-1,"Phần","","Đang bán"),typeof(ArgumentException));
Blocked(()=>QuanLyThucDon.Luu(1,"Món",0,10000,"Phần","","Đang bán"),typeof(ArgumentException));
Blocked(()=>QuanLyThucDon.Luu(1,"Món",1,10000,"Phần","","Không hợp lệ"),typeof(ArgumentException));
Blocked(()=>QuanLyThucDon.ThemDanhMuc(" "),typeof(ArgumentException));
Console.WriteLine($"PASS: {checks} authorization and validation checks; no database writes.");
