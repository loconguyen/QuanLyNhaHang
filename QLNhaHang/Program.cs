
using QLNhaHang.Forms.DangNhap;
using QLNhaHang.Forms.Main;
namespace QLNhaHang
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            while (true)
            {
                using (var login = new DangNhapForm())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        break;
                }

                using (var main = new MainForm())
                {
                    Application.Run(main);

                    if (!main.DangXuat)
                        break;
                }
            }
        }
    }
}