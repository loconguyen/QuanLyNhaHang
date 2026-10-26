#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLNhaHang.Classes;

namespace QLNhaHang.Controls.Bep
{
    //FlowLayoutPanel có thể nhận focus để cuộn bằng chuột giữa khi rê chuột vào
    public class FlowCuon : FlowLayoutPanel
    {
        public FlowCuon()
        {
            SetStyle(ControlStyles.Selectable, true);
            TabStop = true;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!DesignMode) Focus();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!DesignMode) Focus();
            base.OnMouseDown(e);
        }
    }

    // Thẻ hiển thị 1 đơn (1 bàn) gửi xuống bếp: tiêu đề (bàn, mã đơn, giờ gửi, trạng thái),
    // danh sách món (số lượng, ghi chú, trạng thái, nút thao tác) và nút thao tác cả đơn.
    internal class TheDonBep : Panel
    {
        public const int Rong = 380;

        private static readonly Color NenCho = Color.FromArgb(255, 233, 220);
        private static readonly Color NenDang = Color.FromArgb(220, 235, 255);
        private static readonly Color NenXong = Color.FromArgb(221, 245, 227);
        private static readonly Color ChuCho = Color.FromArgb(194, 65, 12);
        private static readonly Color ChuDang = Color.FromArgb(29, 78, 216);
        private static readonly Color ChuXong = Color.FromArgb(21, 128, 61);
        private static readonly Color XanhDuong = Color.FromArgb(37, 99, 235);
        private static readonly Color XanhLa = Color.FromArgb(22, 163, 74);
        private static readonly Color MauGhiChu = Color.FromArgb(180, 83, 9);
        private static readonly Color MauGoiThem = Color.FromArgb(124, 58, 237);   // tím: thẻ "gọi thêm"
        private static readonly Color MauVien = Color.FromArgb(203, 213, 225);

        private static readonly Font FBan = new Font("Segoe UI", 12.5F, FontStyle.Bold);
        private static readonly Font FNho = new Font("Segoe UI", 9F);
        private static readonly Font FNhoDam = new Font("Segoe UI", 9F, FontStyle.Bold);
        private static readonly Font FMon = new Font("Segoe UI", 11F, FontStyle.Bold);
        private static readonly Font FGhiChu = new Font("Segoe UI", 9.5F, FontStyle.Italic);
        private static readonly Font FNut = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        private static readonly Font FNutNho = new Font("Segoe UI", 8.5F);

        // donId, monId, tenMon, true = bắt đầu / false = hoàn thành
        public event Action<int, int, string, bool> DoiMon;
        // donId, danh sách mã món của thẻ này, true = bắt đầu / false = hoàn thành
        public event Action<int, List<int>, bool> DoiTatCa;
        //donId, monId, tenMon, ghiChu hiện tại
        public event Action<int, int, string, string> SuaGhiChu;

        private readonly int _donId;
        private readonly Color _vien;

        /// <param name="gui">Giờ các món trong thẻ này được gửi xuống bếp</param>
        /// <param name="lan">1 = đơn gốc, từ 2 trở lên = các lần gọi thêm của cùng đơn</param>
        public TheDonBep(int donId, string maDon, string soBan, DateTime gui, int lan, IList<DataRow> mon, bool coQuyen)
        {
            _donId = donId;
            _vien = lan > 1 ? MauGoiThem : MauVien;
            DoubleBuffered = true;
            BackColor = Color.White;
            Margin = new Padding(8);
            Padding = new Padding(1);

            var idCho = new List<int>();
            var idDang = new List<int>();
            foreach (DataRow r in mon)
            {
                string tt = Convert.ToString(r["TrangThaiMon"]);
                int id = Convert.ToInt32(r["DongID"]);
                if (tt == TrangThaiMon.ChoCheBien) idCho.Add(id);
                else if (tt == TrangThaiMon.DangCheBien) idDang.Add(id);
            }

            var dong = new List<Control>();
            dong.Add(TaoDau(maDon, soBan, gui, lan, idCho.Count, idDang.Count));
            foreach (DataRow r in mon) dong.Add(TaoDong(r, coQuyen));
            if (coQuyen && (idCho.Count > 0 || idDang.Count > 0)) dong.Add(TaoChan(idCho, idDang));

            int h = 2;
            foreach (Control c in dong) h += c.Height;
            Size = new Size(Rong, h);

            // Dock Top: control thêm sau cùng sẽ nằm trên cùng -> thêm theo thứ tự ngược
            for (int i = dong.Count - 1; i >= 0; i--) Controls.Add(dong[i]);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(_vien))
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }

        private static Button TaoNut(string text, Color nen, int rong, int cao)
        {
            var b = new Button
            {
                Text = text,
                Size = new Size(rong, cao),
                FlatStyle = FlatStyle.Flat,
                BackColor = nen,
                ForeColor = Color.White,
                Font = FNut,
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }

        // Tiêu đề thẻ
        private Control TaoDau(string maDon, string soBan, DateTime gui, int lan, int cho, int dang)
        {
            bool goiThem = lan > 1;
            Color nen = dang > 0 ? NenDang : cho > 0 ? NenCho : NenXong;
            Color chu = dang > 0 ? ChuDang : cho > 0 ? ChuCho : ChuXong;
            string tt = dang > 0 ? "Đang chế biến" : cho > 0 ? "Chờ chế biến" : "Chờ phục vụ";

            var p = new Panel { Size = new Size(Rong - 2, 58), Dock = DockStyle.Top, BackColor = nen };
            if (goiThem) p.Controls.Add(new Panel { Dock = DockStyle.Top, Height = 4, BackColor = MauGoiThem });
            p.Controls.Add(new Label
            {
                Text = "Bàn " + soBan + "  ·  " + maDon,
                Font = FBan,
                AutoSize = true,
                Location = new Point(12, 8)
            });
            p.Controls.Add(new Label
            {
                Text = goiThem
                    ? "GỌI THÊM LẦN " + (lan - 1) + "  ·  lúc " + gui.ToString("HH:mm  dd/MM")
                    : "Gửi lúc " + gui.ToString("HH:mm  dd/MM"),
                Font = goiThem ? FNhoDam : FNho,
                ForeColor = goiThem ? MauGoiThem : Color.DimGray,
                AutoSize = true,
                Location = new Point(13, 34)
            });
            var pill = new Label
            {
                Text = tt,
                Font = FNhoDam,
                ForeColor = chu,
                BackColor = Color.White,
                AutoSize = true,
                Padding = new Padding(10, 3, 10, 3)
            };
            pill.Location = new Point(Rong - 2 - pill.PreferredSize.Width - 12, 10);
            p.Controls.Add(pill);
            return p;
        }

        // Một dòng món
        private Control TaoDong(DataRow r, bool coQuyen)
        {
            int dongId = Convert.ToInt32(r["DongID"]);
            string ten = Convert.ToString(r["TenMon"]);
            string gc = Convert.ToString(r["GhiChu"]);
            string tt = Convert.ToString(r["TrangThaiMon"]);
            bool coGc = !string.IsNullOrWhiteSpace(gc);
            bool cho = tt == TrangThaiMon.ChoCheBien;
            bool dang = tt == TrangThaiMon.DangCheBien;
            Color mau = dang ? XanhDuong : cho ? ChuCho : XanhLa;
            Color chu = dang ? ChuDang : cho ? ChuCho : ChuXong;

            int xPhai = Rong - 2 - 92 - 12;
            var p = new Panel { Size = new Size(Rong - 2, 62 + (coGc ? 20 : 0)), Dock = DockStyle.Top, BackColor = Color.White };
            p.Controls.Add(new Panel { Dock = DockStyle.Left, Width = 5, BackColor = mau });
            p.Controls.Add(new Label
            {
                Text = Convert.ToString(r["SoLuong"]) + " ×  " + ten,
                Font = FMon,
                AutoEllipsis = true,
                Location = new Point(14, 8),
                Size = new Size(xPhai - 14 - 6, 24)
            });
            p.Controls.Add(new Label { Text = tt, Font = FNho, ForeColor = chu, AutoSize = true, Location = new Point(15, 34) });
            if (coGc)
                p.Controls.Add(new Label
                {
                    Text = "Ghi chú: " + gc,
                    Font = FGhiChu,
                    ForeColor = MauGhiChu,
                    AutoEllipsis = true,
                    Location = new Point(15, 56),
                    Size = new Size(Rong - 2 - 15 - 12, 18)
                });

            if (coQuyen && (cho || dang))
            {
                var btn = TaoNut(cho ? "Bắt đầu" : "Xong", cho ? XanhDuong : XanhLa, 92, 28);
                btn.Location = new Point(xPhai, 6);
                bool batDau = cho;
                btn.Click += (s, e) => { if (DoiMon != null) DoiMon(_donId, dongId, ten, batDau); };
                p.Controls.Add(btn);

                var ghi = new Button
                {
                    Text = "Ghi chú",
                    Size = new Size(92, 30),
                    Location = new Point(xPhai, 36),
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.DimGray,
                    Font = FNutNho,
                    Cursor = Cursors.Hand,
                    UseVisualStyleBackColor = true
                };
                ghi.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
                ghi.Click += (s, e) => { if (SuaGhiChu != null) SuaGhiChu(_donId, dongId, ten, gc); };
                p.Controls.Add(ghi);
            }
            else if (!cho && !dang)
            {
                p.Controls.Add(new Label
                {
                    Text = "✔ Đã xong",
                    Font = FNhoDam,
                    ForeColor = ChuXong,
                    AutoSize = true,
                    Location = new Point(xPhai + 8, 14)
                });
            }

            p.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(226, 232, 240)))
                    e.Graphics.DrawLine(pen, 14, p.Height - 1, p.Width - 12, p.Height - 1);
            };
            return p;
        }

        //Chân thẻ: thao tác cả thẻ (chỉ các món thuộc thẻ này)
        private Control TaoChan(List<int> idCho, List<int> idDang)
        {
            var p = new Panel { Size = new Size(Rong - 2, 48), Dock = DockStyle.Top, BackColor = Color.FromArgb(248, 250, 252) };
            int x = 12;
            if (idCho.Count > 0)
            {
                var b = TaoNut("▶  Bắt đầu tất cả (" + idCho.Count + ")", XanhDuong, 172, 32);
                b.Location = new Point(x, 8);
                b.Click += (s, e) => { if (DoiTatCa != null) DoiTatCa(_donId, idCho, true); };
                p.Controls.Add(b);
                x += 180;
            }
            if (idDang.Count > 0)
            {
                var b = TaoNut("✔  Hoàn thành tất cả (" + idDang.Count + ")", XanhLa, 178, 32);
                b.Location = new Point(x, 8);
                b.Click += (s, e) => { if (DoiTatCa != null) DoiTatCa(_donId, idDang, false); };
                p.Controls.Add(b);
            }
            return p;
        }
    }

    // Dải thông báo đặt trên cùng một màn hình của Bếp (món chờ lâu, nguyên liệu sắp hết / sắp hết hạn).
    // Mỗi màn truyền vào các loại cần hiện; không có thông báo thì tự ẩn. Tự làm mới 15 giây một lần.
    // Cách dùng (trong constructor của màn hình, sau InitializeComponent):
    //     Controls.Add(new BangThongBaoBep(CanhBaoBep.ChoLau));

    public class BangThongBaoBep : Panel
    {
        private const int CaoDong = 30;
        private const int ToiDaCao = 180;

        private static readonly Font FNhan =
            new Font("Segoe UI", 8.5F, FontStyle.Bold);

        private static readonly Font FChu =
            new Font("Segoe UI", 9.5F);

        private readonly string[] _loai;
        private readonly System.Windows.Forms.Timer _timer;
        private readonly ToolTip _tip = new ToolTip();

        private readonly Panel _vungCuon;
        private readonly FlowLayoutPanel _danhSach;

        private List<CanhBaoBep> _ds = new List<CanhBaoBep>();
        private string _chuKy = "";
        public BangThongBaoBep(params string[] loaiHienThi)
        {
            _loai = loaiHienThi;

            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true);

            Dock = DockStyle.Top;
            BackColor = Color.FromArgb(255, 247, 237);
            Height = 0;
            Visible = false;
            Padding = new Padding(0);

            // Vùng chứa có thanh cuộn dọc
            _vungCuon = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = BackColor,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            // Danh sách các dòng thông báo
            _danhSach = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Margin = new Padding(0),
                Padding = new Padding(0),
                BackColor = BackColor
            };

            _vungCuon.Controls.Add(_danhSach);
            Controls.Add(_vungCuon);

            _timer = new System.Windows.Forms.Timer
            {
                Interval = 300
            };

            _timer.Tick += (s, e) =>
            {
                _timer.Interval = 15000;
                LamMoi();
            };

            _timer.Start();
            // Tải thông báo ngay khi khởi tạo
            LamMoi();

        }
        public void LamMoi()
        {
            List<CanhBaoBep> ds;

            try
            {
                ds = BepRepository.LayCanhBao()
                    .Where(c => Array.IndexOf(_loai, c.Loai) >= 0)
                    .ToList();
            }
            catch
            {
                // Nếu lỗi kết nối, giữ nguyên thông báo cũ
                return;
            }

            string chuKy = string.Join("\n",
                ds.Select(c => c.Loai + "|" + c.NoiDung).ToArray());

            if (chuKy == _chuKy)
                return;

            _chuKy = chuKy;
            _ds = ds;

            _danhSach.SuspendLayout();
            try
            {
                _danhSach.Controls.Clear();

                foreach (CanhBaoBep c in _ds)
                {
                    _danhSach.Controls.Add(TaoDongThongBao(c));
                }
                // Đặt lại vị trí cuộn khi danh sách thay đổi
                _vungCuon.AutoScrollPosition = new Point(0, 0);

                int tongCao = _ds.Count * CaoDong + 14;

                Height = _ds.Count == 0
                    ? 0
                    : Math.Min(tongCao, ToiDaCao);

                Visible = _ds.Count > 0;
            }
            finally
            {
                _danhSach.ResumeLayout(true);
            }

            PerformLayout();
            Invalidate();
        }

        private Control TaoDongThongBao(CanhBaoBep c)
        {
            Color mau;
            string nhan;

            switch (c.Loai)
            {
                case CanhBaoBep.ChoLau:
                    mau = Color.FromArgb(255, 0, 0);
                    nhan = "CHỜ LÂU";
                    break;

                case CanhBaoBep.NguyenLieuSapHet:
                    mau = Color.FromArgb(180, 83, 9);
                    nhan = "SẮP HẾT";
                    break;

                case CanhBaoBep.NguyenLieuHetHan:
                    mau = Color.FromArgb(126, 34, 206);
                    nhan = "HẾT HẠN";
                    break;

                default:
                    mau = Color.Gray;
                    nhan = "LƯU Ý";
                    break;
            }

            var dong = new Panel
            {
                Width = Math.Max(100, _vungCuon.ClientSize.Width - 20),
                Height = CaoDong,
                Margin = new Padding(0),
                BackColor = BackColor
            };

            var lblNhan = new Label
            {
                Text = nhan,
                Location = new Point(12, 3),
                Size = new Size(104, 22),
                BackColor = mau,
                ForeColor = Color.White,
                Font = FNhan,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblNoiDung = new Label
            {
                Text = c.NoiDung,
                Location = new Point(124, 2),
                Size = new Size(
                    Math.Max(50, dong.Width - 136), 24),
                Font = FChu,
                ForeColor = Color.FromArgb(51, 65, 85),
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleLeft
            };

            dong.Controls.Add(lblNhan);
            dong.Controls.Add(lblNoiDung);

            // Hiện đầy đủ nội dung khi rê chuột
            _tip.SetToolTip(lblNoiDung, c.NoiDung);
            _tip.SetToolTip(lblNhan, c.NoiDung);

            dong.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(253, 186, 116)))
                {
                    e.Graphics.DrawLine(
                        pen, 12, dong.Height - 1,
                        dong.Width - 12, dong.Height - 1);
                }
            };

            return dong;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_danhSach == null || _vungCuon == null)
                return;

            foreach (Control c in _danhSach.Controls)
            {
                c.Width = Math.Max(
                    100, _vungCuon.ClientSize.Width - 20);

                if (c.Controls.Count > 1)
                {
                    c.Controls[1].Width =
                        Math.Max(50, c.Width - 136);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _timer.Dispose();
                _tip.Dispose();
            }

            base.Dispose(disposing);
        }
    }

}
