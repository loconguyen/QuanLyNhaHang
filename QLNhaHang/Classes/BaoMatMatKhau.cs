using System;
using System.Security.Cryptography;

namespace QLNhaHang.Classes
{
    public static class BaoMatMatKhau
    {
        private const int SoVongLap = 600_000;
        private const int DoDaiMuoi = 16;
        private const int DoDaiMaBam = 32;

        // Lưu toàn bộ chuỗi trả về vào cột MatKhauHash.
        public static string BamMatKhau(string matKhau)
        {
            ArgumentException.ThrowIfNullOrEmpty(matKhau);

            byte[] muoi = RandomNumberGenerator.GetBytes(DoDaiMuoi);
            byte[] maBam = Rfc2898DeriveBytes.Pbkdf2(
                matKhau, muoi, SoVongLap, HashAlgorithmName.SHA256, DoDaiMaBam);

            return $"PBKDF2-SHA256${SoVongLap}${Convert.ToBase64String(muoi)}${Convert.ToBase64String(maBam)}";
        }

        // Kiểm tra mật khẩu nhập vào với chuỗi đã lưu trong database.
        public static bool KiemTraMatKhau(string matKhau, string maBamDaLuu)
        {
            if (string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(maBamDaLuu))
                return false;

            string[] cacPhan = maBamDaLuu.Split('$');
            if (cacPhan.Length != 4 || cacPhan[0] != "PBKDF2-SHA256" ||
                !int.TryParse(cacPhan[1], out int soVongLap) || soVongLap != SoVongLap)
                return false;

            try
            {
                byte[] muoi = Convert.FromBase64String(cacPhan[2]);
                byte[] maBamMongDoi = Convert.FromBase64String(cacPhan[3]);
                if (muoi.Length != DoDaiMuoi || maBamMongDoi.Length != DoDaiMaBam)
                    return false;

                byte[] maBamThucTe = Rfc2898DeriveBytes.Pbkdf2(
                    matKhau, muoi, soVongLap, HashAlgorithmName.SHA256, DoDaiMaBam);

                return CryptographicOperations.FixedTimeEquals(maBamThucTe, maBamMongDoi);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}

