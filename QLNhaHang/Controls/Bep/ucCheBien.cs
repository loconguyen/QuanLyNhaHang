#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLNhaHang.Classes;

namespace QLNhaHang.Controls.Bep
{
    /// <summary>
    /// Quản lý chế biến: mỗi bàn / mã đơn là một thẻ (TheDonBep) liệt kê đủ các món gửi xuống bếp.
    /// Giao diện nằm trong ucCheBien.Designer.cs, các thẻ được tạo lúc chạy.
    /// </summary>
    public partial class ucCheBien : UserControl
    {
        private int _soChoTruoc = -1;
        private string _chuKy = "";      // "chữ ký" dữ liệu lần vẽ trước: không đổi thì không vẽ lại
        private const int NguongGoiThemGiay = 10;
        private class DotGoi
        {
            public int DonId;
            public int Lan;            // 1 = đơn gốc, 2.. = gọi thêm
            public DateTime Gio;       // giờ gửi bếp của lần gọi này
            public List<DataRow> Rows = new List<DataRow>();
        }
        private static bool CoQuyen
        {
            get { return Session.Role == "BEP" || Session.Role == "ADMIN"; }
        }

        public ucCheBien()
        {
            InitializeComponent();
            //Thông báo: món chờ chế biến quá 15 phút, nguyên liệu sắp hết, nguyên liệu sắp hết hạn
            if (!DangThietKe)
                Controls.Add(new BangThongBaoBep(CanhBaoBep.ChoLau, CanhBaoBep.NguyenLieuSapHet, CanhBaoBep.NguyenLieuHetHan));
        }
        private bool DangThietKe
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        // ===================== Sự kiện (nối trong Designer) =====================
        private void ucCheBien_Load(object sender, EventArgs e)
        {
            if (DangThietKe) return;
            LamMoiMon(false);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LamMoiMon(true);
        }

        // ===================== Nạp và vẽ =====================
        private static int Dem(DataTable dt, string trangThai)
        {
            return Convert.ToInt32(dt.Compute("COUNT(DonHangID)", "TrangThaiMon = '" + trangThai + "'"));
        }

        private void LamMoiMon(bool baoMonMoi)
        {
            lblThongBao.ForeColor = Color.DimGray;
            DataTable dt;
            try
            {
                dt = BepRepository.LayMonCanCheBien();
            }
            catch (Exception ex)
            {
                lblThongBao.Text = "Lỗi kết nối CSDL: " + ex.Message;
                return;
            }

            int cho = Dem(dt, TrangThaiMon.ChoCheBien);
            lblCho.Text = cho.ToString("00");
            lblDang.Text = Dem(dt, TrangThaiMon.DangCheBien).ToString("00");
            lblXong.Text = Dem(dt, TrangThaiMon.DaHoanThanh).ToString("00");

            if (baoMonMoi && _soChoTruoc >= 0 && cho > _soChoTruoc)
            {
                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Text = "Có món mới gửi xuống bếp lúc " + DateTime.Now.ToString("HH:mm:ss");
            }
            _soChoTruoc = cho;

            string chuKy = TaoChuKy(dt);
            if (chuKy == _chuKy) return;     // dữ liệu không đổi -> giữ nguyên màn hình, không nhấp nháy
            _chuKy = chuKy;
            VeCacThe(dt);
        }

        private static string TaoChuKy(DataTable dt)
        {
            var sb = new StringBuilder();
            foreach (DataRow r in dt.Rows)
                sb.Append(r["DonHangID"]).Append('|').Append(r["DongID"]).Append('|')
                  .Append(r["TrangThaiMon"]).Append('|').Append(r["SoLuong"]).Append('|')
                  .Append(r["GhiChu"]).Append('|').Append(r["ThoiGianGui"]).Append(';');
            return sb.ToString();
        }

        private static bool CanXuLy(DataRow r)
        {
            string tt = Convert.ToString(r["TrangThaiMon"]);
            return tt == TrangThaiMon.ChoCheBien || tt == TrangThaiMon.DangCheBien;
        }
        // Món "Đã phục vụ" chỉ dùng để xác định lần gọi, không hiển thị trên thẻ
        private static bool HienThi(DataRow r)
        {
            string tt = Convert.ToString(r["TrangThaiMon"]);
            return tt == TrangThaiMon.ChoCheBien || tt == TrangThaiMon.DangCheBien || tt == TrangThaiMon.DaHoanThanh;
        }

        private static int ThuTu(DataRow r)
        {
            string tt = Convert.ToString(r["TrangThaiMon"]);
            return tt == TrangThaiMon.DangCheBien ? 0 : tt == TrangThaiMon.ChoCheBien ? 1 : 2;
        }

        private void VeCacThe(DataTable dt)
        {
            Point viTri = flpDon.AutoScrollPosition;   // nhớ vị trí cuộn
            flpDon.SuspendLayout();
            try
            {
                foreach (Control c in flpDon.Controls.Cast<Control>().ToList())
                {
                    flpDon.Controls.Remove(c);
                    c.Dispose();
                }

                // Chia món của từng đơn thành các lần gọi theo giờ gửi bếp: lần đầu = đơn gốc, sau đó = gọi thêm
                var cacDot = new List<DotGoi>();
                foreach (var g in dt.AsEnumerable().GroupBy(r => Convert.ToInt32(r["DonHangID"])))
                {
                    DotGoi cur = null;
                    int lan = 0;
                    foreach (DataRow r in g.OrderBy(x => Convert.ToDateTime(x["ThoiGianGui"])).ThenBy(x => Convert.ToInt32(x["MonID"])))
                    {
                        DateTime t = Convert.ToDateTime(r["ThoiGianGui"]);
                        if (cur == null || (t - cur.Gio).TotalSeconds > NguongGoiThemGiay)
                        {
                            cur = new DotGoi { DonId = g.Key, Lan = ++lan, Gio = t };
                            cacDot.Add(cur);
                        }
                        cur.Rows.Add(r);
                    }
                }

                // Thẻ còn món cần làm lên trước; trong đó ai gọi trước hiện trước, thẻ gọi thêm xếp theo giờ gọi thêm
                var cacThe = cacDot
                    .Where(d => d.Rows.Any(HienThi))
                    .OrderBy(d => d.Rows.Any(CanXuLy) ? 0 : 1)
                    .ThenBy(d => d.Gio)
                    .ThenBy(d => d.DonId)
                    .ThenBy(d => d.Lan);

                foreach (var d in cacThe)
                {
                    var mon = d.Rows.Where(HienThi).OrderBy(ThuTu).ThenBy(r => Convert.ToString(r["TenMon"])).ToList();
                    var the = new TheDonBep(
                        d.DonId,
                        Convert.ToString(mon[0]["MaDon"]),
                        Convert.ToString(mon[0]["SoBan"]),
                        d.Gio, d.Lan, mon, CoQuyen);
                    the.DoiMon += TheDoiMon;
                    the.DoiTatCa += TheDoiTatCa;
                    the.SuaGhiChu += TheSuaGhiChu;
                    flpDon.Controls.Add(the);
                }
            }
            finally
            {
                flpDon.ResumeLayout(true);
            }
            flpDon.AutoScrollPosition = new Point(-viTri.X, -viTri.Y);   // trả lại vị trí cuộn
        }

        // Vẽ lại sau khi sự kiện click kết thúc (thẻ chứa nút vừa bấm sắp bị hủy)
        private void LamLai()
        {
            BeginInvoke(new Action(() => { if (!IsDisposed) LamMoiMon(false); }));
        }

        private void TheDoiMon(int donId, int dongId, string tenMon, bool batDau)
        {
            if (!CoQuyen) { MessageBox.Show("Bạn không có quyền thực hiện thao tác này."); return; }
            try
            {
                bool ok = batDau ? BepRepository.BatDauCheBien(dongId) : BepRepository.HoanThanh(dongId);
                if (ok)
                    lblThongBao.Text = (batDau ? "Đã bắt đầu chế biến: " : "Đã hoàn thành: ") + tenMon;
                else
                    MessageBox.Show(batDau ? "Món này không còn ở trạng thái 'Chờ chế biến' (có thể đã được xử lý hoặc bị hủy)."
                                           : "Món này không còn ở trạng thái 'Đang chế biến'.",
                        "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LamLai();
        }

        private void TheDoiTatCa(int donId, List<int> dongIds, bool batDau)
        {
            if (!CoQuyen) { MessageBox.Show("Bạn không có quyền thực hiện thao tác này."); return; }
            try
            {
                bool ok = batDau ? BepRepository.BatDauNhieuMon(dongIds) : BepRepository.HoanThanhNhieuMon(dongIds);
                if (ok)
                    lblThongBao.Text = batDau ? "Đã bắt đầu chế biến các món chờ của thẻ." : "Đã hoàn thành các món đang làm của thẻ.";
                else
                    MessageBox.Show("Không có món nào cần cập nhật (có thể đã được xử lý).",
                        "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LamLai();
        }
        private void TheSuaGhiChu(int donId, int dongId, string tenMon, string ghiChu)
        {
            if (!CoQuyen) { MessageBox.Show("Bạn không có quyền thực hiện thao tác này."); return; }
            string moi = HoiGhiChu(tenMon, ghiChu);
            if (moi == null) return;   // bấm Hủy
            try
            {
                bool ok = BepRepository.CapNhatGhiChu(dongId, moi);
                lblThongBao.Text = ok ? "Đã lưu ghi chú: " + tenMon : "Không thể lưu ghi chú (món đã hoàn thành/hủy).";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LamLai();
        }

        // Hộp thoại nhỏ nhập ghi chú (dựng bằng code). Trả về null nếu bấm Hủy.
        private string HoiGhiChu(string tenMon, string hienTai)
        {
            using (var f = new Form())
            {
                f.Text = "Sửa ghi chú";
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.MaximizeBox = false;
                f.MinimizeBox = false;
                f.ShowInTaskbar = false;
                f.Font = Font;
                f.ClientSize = new Size(420, 130);

                var lbl = new Label { Text = "Món: " + tenMon, AutoSize = true, Location = new Point(12, 12) };
                var txt = new TextBox { Text = hienTai, MaxLength = 200, Location = new Point(12, 40), Width = 396 };
                var ok = new Button { Text = "Lưu", DialogResult = DialogResult.OK, Location = new Point(232, 84), Size = new Size(80, 32) };
                var huy = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new Point(328, 84), Size = new Size(80, 32) };
                f.Controls.AddRange(new Control[] { lbl, txt, ok, huy });
                f.AcceptButton = ok;
                f.CancelButton = huy;

                return f.ShowDialog(this) == DialogResult.OK ? txt.Text.Trim() : null;
            }
        }
    }
}