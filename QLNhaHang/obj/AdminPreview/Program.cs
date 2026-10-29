using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using QLNhaHang.Controls.Admin;
internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        using var dashboard = new ucAdmin();
        var flags = BindingFlags.NonPublic | BindingFlags.Instance;
        var type = typeof(ucAdmin);
        var values = (Label[])type.GetField("giaTri", flags)!.GetValue(dashboard)!;
        string[] texts = { "12.450.000 ₫", "68", "183", "3" };
        for(int i=0;i<4;i++) values[i].Text=texts[i];
        void Chart(string name, List<(string,decimal,decimal)> data)
        {
            var c=type.GetField(name,flags)!.GetValue(dashboard)!;
            c.GetType().GetMethod("SetData")!.Invoke(c,new object[]{data});
        }
        Chart("doanhThu", new(){("22/10",3200000,4),("23/10",4800000,6),("24/10",2700000,4),("25/10",5100000,6),("26/10",6400000,7),("27/10",8200000,9),("28/10",7100000,8)});
        Chart("topMon",new(){("Phở bò",120,0),("Cơm rang hải sản",98,0),("Gà nướng mật ong",76,0),("Bún chả",65,0),("Nem rán",52,0)});
        Chart("thanhToan",new(){("Chuyển khoản",8400000,0),("Tiền mặt",3200000,0),("Thẻ",850000,0)});
        foreach(int width in new[]{1280,1024})
        {
            dashboard.Size=new Size(width,900);
            dashboard.CreateControl();
            void Layout(Control c){c.PerformLayout();foreach(Control child in c.Controls) Layout(child);}
            Layout(dashboard);
            using var bitmap=new Bitmap(width,900);
            dashboard.DrawToBitmap(bitmap,new Rectangle(0,0,width,900));
            foreach(var value in values) Console.WriteLine($"VALUE {value.Text} bounds={value.Bounds} parent={value.Parent!.Bounds} font={value.Font.Size}");
            bitmap.Save(Path.GetFullPath($"obj/admin-dashboard-{width}.png"));
        }
        Console.WriteLine("Rendered admin dashboard at 1280 and 1024 pixels with preview-only data.");
    }
}
