using QLNhaHang.Classes;
using QLNhaHang.Forms.DangNhap;
using QLNhaHang.Forms.Main;
using System;
using System.Windows.Forms;

namespace QLNhaHang
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                Session.Clear();

                using (DangNhapForm login = new DangNhapForm())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }
                }

                using (MainForm main = new MainForm())
                {
                    Application.Run(main);

                    // Nếu MainForm đóng do đăng xuất,
                    // quay về màn hình đăng nhập.
                    if (!main.DangXuat)
                    {
                        break;
                    }
                }

            }
        }
    }
}