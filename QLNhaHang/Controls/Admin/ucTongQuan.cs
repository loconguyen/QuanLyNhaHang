using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Globalization;
using QLNhaHang.Classes;

namespace QLNhaHang.Controls.Admin
{
    public partial class ucTongQuan : UserControl
    {
        private readonly DateTimePicker tuNgay = new(), denNgay = new();
        private readonly Button xem = new();
        private readonly ComboBox khoangNgay = new();
        private readonly Label thongBao = new();
        private readonly Label[] giaTri = new Label[4];
        private readonly BieuDo doanhThu = new(0), topMon = new(1), thanhToan = new(2);
        private readonly DataGridView donMoi = new();
        private readonly Label[] soBan = new Label[4];
        private bool dangTai, dangChon;
        private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");

        public ucTongQuan()
        {
            InitializeComponent();
            Font = new Font("Segoe UI", 9.5F);
            BackColor = Theme.Background;
            Padding = new Padding(18);
            AutoScroll = true;
            TaoGiaoDien();
            Load += async (_, _) =>
            {
                if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && Session.Role == "ADMIN") await TaiDuLieu();
            };
        }

        private static Label Nhan(string text, float size = 10, bool bold = false) => new()
        {
            Text = text, AutoSize = true, ForeColor = Theme.BlueBold,
            Font = new Font("Segoe UI", size, bold ? FontStyle.Bold : FontStyle.Regular),
            Margin = new Padding(0, 0, 0, 5)
        };

        private static TableLayoutPanel Luoi(int columns, params float[] widths)
        {
            var p = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = columns, RowCount = 1, Margin = Padding.Empty };
            foreach (float width in widths) p.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));
            p.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            return p;
        }

        private static Panel The(string title, Control body)
        {
            var panel = new Panel { Dock = DockStyle.Fill, BackColor = Theme.Surface, Padding = new Padding(16), Margin = new Padding(0, 0, 12, 12) };
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Margin = Padding.Empty };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var heading = Nhan(title, 10, true); heading.AutoSize = false; heading.Dock = DockStyle.Fill; heading.AutoEllipsis = true; layout.Controls.Add(heading, 0, 0);
            body.Dock = DockStyle.Fill;
            layout.Controls.Add(body, 0, 1);
            panel.Controls.Add(layout);
            return panel;
        }

        private void TaoGiaoDien()
        {
            var page = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 1, RowCount = 6, MinimumSize = new Size(1120, 0), Margin = Padding.Empty };
            page.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            foreach (int height in new[] { 68, 50, 140, 286, 316, 40 }) page.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
            page.Height = 900;
            var heading = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, Margin = Padding.Empty };
            heading.Controls.Add(Nhan("Tổng quan", 21, true));
            page.Controls.Add(heading, 0, 0);

            var filter = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, Margin = Padding.Empty };
            filter.Controls.Add(Nhan("Khoảng thời gian", 10));
            foreach (var date in new[] { tuNgay, denNgay })
            {
                date.Format = DateTimePickerFormat.Custom; date.CustomFormat = "dd/MM/yyyy";
                date.Width = 132; date.Margin = new Padding(8, 0, 0, 0);
                date.Value = DateTime.Today;
            }
            filter.Controls.Add(tuNgay); filter.Controls.Add(Nhan("  —")); filter.Controls.Add(denNgay);
            xem.Text = "Xem thống kê"; xem.AutoSize = true; xem.Height = 32;
            xem.BackColor = Theme.Blue; xem.ForeColor = Color.White; xem.FlatStyle = FlatStyle.Flat;
            xem.FlatAppearance.BorderSize = 0; xem.Margin = new Padding(12, 0, 12, 0);
            xem.Click += async (_, _) => await TaiDuLieu(); filter.Controls.Add(xem);
            khoangNgay.DropDownStyle = ComboBoxStyle.DropDownList; khoangNgay.Width = 145;
            khoangNgay.Items.AddRange(new object[] { "Hôm nay", "7 ngày qua", "Tháng này", "Tùy chọn" });
            khoangNgay.SelectedIndex = 0; filter.Controls.Add(khoangNgay);
            khoangNgay.SelectedIndexChanged += async (_, _) =>
            {
                if (dangChon || khoangNgay.SelectedIndex == 3) return;
                dangChon = true;
                denNgay.Value = DateTime.Today;
                tuNgay.Value = khoangNgay.SelectedIndex switch { 1 => DateTime.Today.AddDays(-6), 2 => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), _ => DateTime.Today };
                dangChon = false;
                if (IsHandleCreated && Session.Role == "ADMIN") await TaiDuLieu();
            };
            foreach (var date in new[] { tuNgay, denNgay }) date.ValueChanged += (_, _) => { if (!dangChon) khoangNgay.SelectedIndex = 3; };
            page.Controls.Add(filter, 0, 1);

            var metrics = Luoi(4, 25, 25, 25, 25);
            string[] titles = { "Doanh thu", "Tổng số đơn", "Số món đã bán", "Đơn bị hủy" };
            string[] notes = { "Hóa đơn đã thanh toán", "Đơn tạo trong khoảng chọn", "Món thuộc hóa đơn đã thu", "Đơn hủy trong khoảng chọn" };
            Color[] colors = { Theme.Green, Theme.Blue, Theme.Orange, Theme.Danger };
            string[] icons = { "₫", "≡", "♨", "×" };
            for (int i = 0; i < 4; i++)
            {
                var card = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(0, 0, 12, 12), Padding = new Padding(12) };
                var stripe = new Panel { Dock = DockStyle.Left, Width = 4, BackColor = colors[i] }; card.Controls.Add(stripe);
                var icon = new Label { Text = icons[i], ForeColor = colors[i], Font = new Font("Segoe UI", 24, FontStyle.Bold), Dock = DockStyle.Left, Width = 45, TextAlign = ContentAlignment.MiddleCenter };
                var details = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3, ColumnCount = 1, Padding = new Padding(8, 0, 0, 0) };
                details.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); details.RowStyles.Add(new RowStyle(SizeType.Absolute, 28)); details.RowStyles.Add(new RowStyle(SizeType.Absolute, 44)); details.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                details.Controls.Add(Nhan(titles[i], 9), 0, 0);
                giaTri[i] = new MetricLabel { Text = "—", ForeColor = Theme.BlueBold, AutoSize = false, Dock = DockStyle.Fill, Margin = Padding.Empty }; details.Controls.Add(giaTri[i], 0, 1);
                var note = Nhan(notes[i], 8); note.ForeColor = Theme.TextMuted; note.AutoSize = false; note.AutoEllipsis = true; note.Dock = DockStyle.Fill; details.Controls.Add(note, 0, 2);
                card.Controls.Add(details); card.Controls.Add(icon); metrics.Controls.Add(card, i, 0);
            }
            page.Controls.Add(metrics, 0, 2);
            var charts = Luoi(2, 61, 39);
            charts.Controls.Add(The("Doanh thu theo ngày", doanhThu), 0, 0);
            charts.Controls.Add(The("Top 5 món bán chạy · Theo số lượng", topMon), 1, 0);
            page.Controls.Add(charts, 0, 3);

            donMoi.BackgroundColor = Color.White; donMoi.BorderStyle = BorderStyle.None; donMoi.ReadOnly = true;
            donMoi.AutoGenerateColumns = false; donMoi.AllowUserToAddRows = false; donMoi.AllowUserToDeleteRows = false;
            donMoi.RowHeadersVisible = false; donMoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            donMoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect; donMoi.MultiSelect = false;
            donMoi.EnableHeadersVisualStyles = false; donMoi.ColumnHeadersDefaultCellStyle.BackColor = Theme.SurfaceMuted;
            donMoi.ColumnHeadersDefaultCellStyle.ForeColor = Theme.TextMuted; donMoi.ColumnHeadersDefaultCellStyle.Font = new Font(Font, FontStyle.Bold);
            donMoi.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme.Blue;
            donMoi.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            donMoi.ColumnHeadersHeight = 34; donMoi.RowTemplate.Height = 33;
            donMoi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; donMoi.GridColor = Theme.Divider;
            donMoi.DefaultCellStyle.SelectionBackColor = Theme.BlueSoft; donMoi.DefaultCellStyle.SelectionForeColor = Theme.BlueBold;
            donMoi.AlternatingRowsDefaultCellStyle.BackColor = Theme.SurfaceMuted;
            string[] fields = { "MaDon", "SoBan", "ThoiGianTao", "TongTien", "TrangThai" };
            string[] headers = { "Mã đơn", "Bàn", "Thời gian", "Tổng tiền", "Trạng thái" };
            for (int i = 0; i < fields.Length; i++) donMoi.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = fields[i], HeaderText = headers[i], FillWeight = i == 1 ? 50 : i == 2 || i == 4 ? 130 : 100 });
            donMoi.Columns[2].DefaultCellStyle.Format = "dd/MM HH:mm"; donMoi.Columns[3].DefaultCellStyle.Format = "N0";
            donMoi.Columns[3].DefaultCellStyle.FormatProvider = Vi;
            donMoi.CellFormatting += (_, e) =>
            {
                if (e.ColumnIndex != 4 || e.Value is not string state) return;
                e.CellStyle!.ForeColor = state == "Đã thanh toán" ? Theme.Green : state == "Đã hủy" ? Theme.Danger : Theme.Blue;
            };
            var bottom = Luoi(2, 61, 39);
            bottom.Controls.Add(The("10 đơn gần đây · Trong khoảng ngày đã chọn", donMoi), 0, 0);
            var right = Luoi(2, 55, 45);
            right.Controls.Add(The("Cơ cấu thanh toán", thanhToan), 0, 0);
            var tables = new TableLayoutPanel { ColumnCount = 1, RowCount = 4, Dock = DockStyle.Fill }; tables.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            string[] states = { "Trống", "Đang phục vụ", "Chờ dọn", "Bảo trì" };
            Color[] stateColors = { Theme.Green, Theme.Blue, Theme.Orange, Theme.Danger };
            for (int i = 0; i < 4; i++)
            {
                tables.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
                var row = new Panel { Dock = DockStyle.Fill, BackColor = Theme.SurfaceMuted, Margin = new Padding(0, 0, 0, 7), Padding = new Padding(8, 4, 8, 4) };
                var label = Nhan(states[i], 8); label.AutoSize = false; label.Dock = DockStyle.Fill; label.TextAlign = ContentAlignment.MiddleLeft; label.Margin = Padding.Empty; row.Controls.Add(label);
                soBan[i] = Nhan("—", 11, true); soBan[i].AutoSize = false; soBan[i].Dock = DockStyle.Right; soBan[i].Width = 32; soBan[i].TextAlign = ContentAlignment.MiddleCenter; soBan[i].Margin = Padding.Empty; soBan[i].ForeColor = stateColors[i]; row.Controls.Add(soBan[i]); tables.Controls.Add(row, 0, i);
            }
            right.Controls.Add(The("Bàn hiện tại", tables), 1, 0); bottom.Controls.Add(right, 1, 0);
            page.Controls.Add(bottom, 0, 4);
            thongBao.AutoSize = true; thongBao.ForeColor = Theme.TextMuted; thongBao.Text = "Chọn khoảng ngày để xem kết quả kinh doanh.";
            page.Controls.Add(thongBao, 0, 5);
            Controls.Add(page);
        }

        private sealed class MetricLabel : Label
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                float size = 16;
                while (true)
                {
                    using var font = new Font("Segoe UI", size, FontStyle.Bold);
                    if (TextRenderer.MeasureText(Text, font).Width <= Width || size <= 8)
                    {
                        TextRenderer.DrawText(e.Graphics, Text, font, ClientRectangle, ForeColor,
                            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
                        return;
                    }
                    size -= .5F;
                }
            }
        }
        private async Task TaiDuLieu()
        {
            if (dangTai) return;
            if (tuNgay.Value.Date > denNgay.Value.Date) { thongBao.ForeColor = Theme.Danger; thongBao.Text = "Ngày bắt đầu phải trước hoặc bằng ngày kết thúc."; return; }
            dangTai = true; xem.Enabled = khoangNgay.Enabled = tuNgay.Enabled = denNgay.Enabled = false;
            thongBao.ForeColor = Theme.TextMuted; thongBao.Text = "Đang tải dữ liệu thống kê…";
            try
            {
                DateTime from = tuNgay.Value.Date, to = denNgay.Value.Date;
                using var data = await ThongKeAdmin.TaiAsync(from, to);
                if (IsDisposed) return;
                DataRow sum = data.Tables["Tong"]!.Rows[0];
                giaTri[0].Text = Convert.ToDecimal(sum["DoanhThu"]).ToString("N0", Vi) + " ₫";
                giaTri[1].Text = Convert.ToInt64(sum["SoDon"]).ToString("N0", Vi);
                giaTri[2].Text = Convert.ToInt64(sum["SoMon"]).ToString("N0", Vi);
                giaTri[3].Text = Convert.ToInt64(sum["DonHuy"]).ToString("N0", Vi);
                // Fill missing dates with zero; group long ranges to keep the chart legible.
                int days = (to - from).Days + 1;
                int step = Math.Max(1, (int)Math.Ceiling(days / 14d));
                var buckets = new List<(string, decimal, decimal)>();
                var daily = data.Tables["TheoNgay"]!.AsEnumerable().ToDictionary(r => r.Field<DateTime>("Ngay").Date);
                for (DateTime day = from; day <= to; day = day.AddDays(step))
                {
                    decimal money = 0, orders = 0;
                    for (int j = 0; j < step && day.AddDays(j) <= to; j++) if (daily.TryGetValue(day.AddDays(j), out var r)) { money += Convert.ToDecimal(r["Tien"]); orders += Convert.ToDecimal(r["SoDon"]); }
                    buckets.Add((day.ToString("dd/MM"), money, orders));
                }
                doanhThu.SetData(buckets);
                topMon.SetData(data.Tables["TopMon"]!.AsEnumerable().Select(r => (r.Field<string>("TenMon")!, Convert.ToDecimal(r["SoLuong"]), 0m)).ToList());
                thanhToan.SetData(data.Tables["ThanhToan"]!.AsEnumerable().Select(r => (r.Field<string>("PhuongThuc")!, Convert.ToDecimal(r["Tien"]), 0m)).ToList());
                var old = donMoi.DataSource as DataTable; donMoi.DataSource = data.Tables["DonMoi"]!.Copy(); old?.Dispose();
                string[] states = { "Trống", "Đang phục vụ", "Chờ dọn", "Bảo trì" };
                for (int i = 0; i < states.Length; i++) soBan[i].Text = data.Tables["Ban"]!.AsEnumerable().Where(r => r.Field<string>("TrangThai") == states[i]).Sum(r => Convert.ToInt32(r["SoBan"])).ToString();
                thongBao.ForeColor = Theme.TextMuted;
                thongBao.Text = $"Cập nhật {DateTime.Now:HH:mm:ss}  ·  {from:dd/MM/yyyy} – {to:dd/MM/yyyy}  ·  Doanh thu theo ngày thu tiền; trạng thái bàn là hiện tại.";
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                foreach (var label in giaTri.Concat(soBan)) label.Text = "—";
                doanhThu.SetData(new()); topMon.SetData(new()); thanhToan.SetData(new());
                var old = donMoi.DataSource as DataTable; donMoi.DataSource = null; old?.Dispose();
                thongBao.ForeColor = Theme.Danger; thongBao.Text = "Không tải được thống kê: " + ex.Message;
            }
            finally
            {
                dangTai = false;
                if (!IsDisposed) xem.Enabled = khoangNgay.Enabled = tuNgay.Enabled = denNgay.Enabled = true;
            }
        }

        private sealed class BieuDo : Control
        {
            private readonly int loai;
            private List<(string Name, decimal Value, decimal Orders)> rows = new();
            private readonly Color[] palette = { Color.FromArgb(53, 145, 250), Color.FromArgb(255, 153, 68), Color.FromArgb(37, 184, 127), Theme.Purple };
            public BieuDo(int type) { loai = type; DoubleBuffered = true; ResizeRedraw = true; BackColor = Color.White; }
            public void SetData(List<(string, decimal, decimal)> data) { rows = data; Invalidate(); }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                using var font = new Font("Segoe UI", 8);
                using var bold = new Font("Segoe UI", 9, FontStyle.Bold);
                using var muted = new SolidBrush(Theme.TextMuted);
                using var blue = new SolidBrush(palette[0]);
                if (rows.Count == 0 || rows.All(r => r.Value == 0 && r.Orders == 0))
                {
                    TextRenderer.DrawText(g, "Chưa có dữ liệu trong khoảng ngày này", font, ClientRectangle, Theme.TextMuted, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak); return;
                }
                if (loai == 1)
                {
                    decimal max = Math.Max(1, rows.Max(r => r.Value));
                    float line = Math.Min(40, Height / 5f);
                    for (int i = 0; i < rows.Count; i++)
                    {
                        float y = i * line + 6;
                        TextRenderer.DrawText(g, $"{i + 1:00}  {rows[i].Name}", font, new Rectangle(0, (int)y, Width / 2 - 8, 22), Theme.BlueBold, TextFormatFlags.EndEllipsis);
                        int x = Width / 2, width = Math.Max(1, Width - x - 42);
                        using var track = new SolidBrush(Theme.BlueSoft); g.FillRectangle(track, x, y + 5, width, 10);
                        g.FillRectangle(blue, x, y + 5, width * (float)(rows[i].Value / max), 10);
                        TextRenderer.DrawText(g, rows[i].Value.ToString("N0", Vi), font, new Rectangle(Width - 40, (int)y, 40, 22), Theme.TextMuted, TextFormatFlags.Right);
                    }
                    return;
                }
                if (loai == 2)
                {
                    decimal total = rows.Sum(r => r.Value); if (total <= 0) return;
                    int d = Math.Max(30, Math.Min(Width - 12, Height / 2));
                    var circle = new Rectangle((Width - d) / 2, 2, d, d);
                    float start = -90;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        float sweep = (float)(rows[i].Value / total * 360);
                        using var brush = new SolidBrush(palette[i % palette.Length]);
                        g.FillPie(brush, circle, start, sweep); start += sweep;
                    }
                    var hole = Rectangle.Inflate(circle, -d / 5, -d / 5); g.FillEllipse(Brushes.White, hole);
                    TextRenderer.DrawText(g, "Đã thu", bold, hole, Theme.BlueBold, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    for (int i = 0; i < rows.Count; i++)
                    {
                        using var brush = new SolidBrush(palette[i % palette.Length]); int y = d + 12 + i * 24;
                        g.FillEllipse(brush, 0, y + 5, 7, 7);
                        TextRenderer.DrawText(g, $"{rows[i].Name}  {rows[i].Value / total:P0}", font, new Rectangle(12, y, Width - 12, 24), Theme.TextMuted, TextFormatFlags.EndEllipsis);
                    }
                    return;
                }
                const int left = 47, top = 26, bottom = 32, right = 26;
                int w = Width - left - right, h = Height - top - bottom; if (w <= 0 || h <= 0) return;
                decimal maxMoney = Math.Max(1, rows.Max(r => r.Value)), maxOrders = Math.Max(1, rows.Max(r => r.Orders));
                using var grid = new Pen(Theme.Divider); using var orange = new Pen(palette[1], 2);
                g.DrawString("Doanh thu (triệu ₫)", font, blue, left, 0);
                using var orangeBrush = new SolidBrush(palette[1]); g.DrawString("Số đơn (trục phải)", font, orangeBrush, Math.Max(left, Width - 160), 0);
                for (int i = 0; i <= 4; i++)
                {
                    float y = top + h - h * i / 4f; g.DrawLine(grid, left, y, left + w, y);
                    TextRenderer.DrawText(g, (maxMoney * i / 4 / 1000000).ToString("0.##", Vi), font, new Rectangle(0, (int)y - 8, left - 4, 20), Theme.TextMuted, TextFormatFlags.Right);
                    g.DrawString((maxOrders * i / 4).ToString("0.#"), font, muted, left + w + 3, y - 7);
                }
                float cell = w / (float)rows.Count;
                var points = new List<PointF>();
                for (int i = 0; i < rows.Count; i++)
                {
                    float x = left + cell * (i + .5f), barH = h * (float)(rows[i].Value / maxMoney);
                    g.FillRectangle(blue, x - cell * .26f, top + h - barH, cell * .52f, barH);
                    points.Add(new PointF(x, top + h - h * (float)(rows[i].Orders / maxOrders)));
                    if (i % Math.Max(1, (int)Math.Ceiling(rows.Count / 7d)) == 0)
                        TextRenderer.DrawText(g, rows[i].Name, font, new Rectangle((int)x - 22, top + h + 8, 44, 22), Theme.TextMuted, TextFormatFlags.HorizontalCenter);
                }
                if (points.Count > 1) g.DrawLines(orange, points.ToArray());
                foreach (var p in points) g.FillEllipse(orangeBrush, p.X - 3, p.Y - 3, 6, 6);
            }
        }
    }
}
