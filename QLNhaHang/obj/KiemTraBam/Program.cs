using QLNhaHang.Classes;
string a = BaoMatMatKhau.BamMatKhau("MatKhau123!");
string b = BaoMatMatKhau.BamMatKhau("MatKhau123!");
if (a == b || !BaoMatMatKhau.KiemTraMatKhau("MatKhau123!", a) || BaoMatMatKhau.KiemTraMatKhau("Sai", a) || BaoMatMatKhau.KiemTraMatKhau("MatKhau123!", "PBKDF2-SHA256$600000$loi$loi")) throw new Exception("FAIL");
Console.WriteLine("PASS: correct/wrong password, random salt, malformed hash.");
