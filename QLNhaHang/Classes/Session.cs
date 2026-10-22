using System;
using System.Collections.Generic;
using System.Text;

namespace QLNhaHang.Classes
{
    internal class Session
    {
        public static int TaiKhoanID;
        public static int NhanVienID;
        public static string HoTen = string.Empty;
        public static string Role = string.Empty;   // "BEP", "PHUC_VU", "THU_NGAN", "ADMIN"

        public static void Clear()
        {
            TaiKhoanID = 0;
            NhanVienID = 0;
            HoTen = string.Empty;
            Role = string.Empty;
        }
    }
}
