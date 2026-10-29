using System.Drawing;
using System.Windows.Forms;
using QLNhaHang.Forms.ThucDon;
internal static class Program
{
 [STAThread] static void Main()
 {
  ApplicationConfiguration.Initialize();
  foreach(int size in new[]{10,12,14})
  {
   using var form=new frmMonAn();
   form.Font=new Font("Segoe UI",size);
   form.ClientSize=new Size(460,650);
   var events = (System.ComponentModel.EventHandlerList)typeof(System.ComponentModel.Component).GetProperty("Events",System.Reflection.BindingFlags.Instance|System.Reflection.BindingFlags.NonPublic)!.GetValue(form)!;
   foreach(var field in typeof(Form).GetFields(System.Reflection.BindingFlags.Static|System.Reflection.BindingFlags.NonPublic).Where(f=>f.Name.Contains("load",StringComparison.OrdinalIgnoreCase)))
   {
    var key=field.GetValue(null); if(key!=null && events[key]!=null) events.RemoveHandler(key,events[key]);
   }
   form.Opacity=0; form.ShowInTaskbar=false; form.Show(); Application.DoEvents();
   void Layout(Control c){c.PerformLayout(); foreach(Control child in c.Controls) Layout(child);}
   Layout(form);
   using var bitmap=new Bitmap(form.Width,form.Height);
   form.DrawToBitmap(bitmap,new Rectangle(Point.Empty,form.Size));
   void Check(Control c)
   {
    if(c is Label l && l.Text.Length>0 && l.Height<l.GetPreferredSize(new Size(l.Width,0)).Height)
     throw new Exception("Clipped label: "+l.Text);
    if(c is TableLayoutPanel p)
    {
     var children=p.Controls.Cast<Control>().Where(x=>x.Visible).ToArray();
     for(int i=0;i<children.Length;i++) for(int j=i+1;j<children.Length;j++)
      if(children[i].Bounds.IntersectsWith(children[j].Bounds)) throw new Exception("Overlapping controls");
    }
    foreach(Control child in c.Controls) Check(child);
   }
   Check(form);
   bitmap.Save(Path.GetFullPath($"obj/menu-layout-{size}.png"));
  }
  Console.WriteLine("PASS: labels and control bounds at font sizes 10, 12, 14. No database calls.");
 }
}
