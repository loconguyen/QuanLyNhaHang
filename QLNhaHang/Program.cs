using System;
using System.Windows.Forms;
using QLNhaHang.Forms.DangNhap;
using QLNhaHang.Forms.Main;

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
                using (DangNhapForm login = new DangNhapForm())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        return;
                }

                using (MainForm main = new MainForm())
                {
                    Application.Run(main);

                    if (!main.DangXuat)
                        return;
                }
            }
        }
    }
}