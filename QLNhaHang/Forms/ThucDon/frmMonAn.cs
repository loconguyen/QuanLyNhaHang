using System.Data;
using QLNhaHang.Classes;

namespace QLNhaHang.Forms.ThucDon
{
    public sealed class frmMonAn : Form
    {
        private readonly TextBox ten = new() { MaxLength = 100 }, donVi = new() { MaxLength = 30 }, moTa = new() { Multiline = true, MaxLength = 255, ScrollBars = ScrollBars.Vertical };
        private readonly ComboBox danhMuc = new() { DropDownStyle = ComboBoxStyle.DropDownList }, trangThai = new() { DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly NumericUpDown gia = new() { Minimum = 0, Maximum = 9999999999999999.99m, DecimalPlaces = 2, ThousandsSeparator = true };
        private readonly Label loi = new() { AutoSize = true, ForeColor = Theme.Danger, MaximumSize = new Size(400, 0) };
        private readonly int? id;
        public int MonDaLuu { get; private set; }
        public frmMonAn(DataRow? mon = null)
        {
            SuspendLayout();
            id = mon == null ? null : Convert.ToInt32(mon["MonID"]);
            Text = id.HasValue ? "Sửa món ăn" : "Thêm món mới";
            Font = new Font("Segoe UI", 10); BackColor = Theme.Background; ForeColor = Theme.BlueBold;
            AutoScaleMode = AutoScaleMode.Dpi; AutoScaleDimensions = new SizeF(96, 96);
            ClientSize = new Size(460, 650); MinimumSize = new Size(450, 600);
            StartPosition = FormStartPosition.CenterParent; MaximizeBox = false; MinimizeBox = false;
            var scroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.White };
            var content = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, ColumnCount = 1, RowCount = 0, Padding = new Padding(22), BackColor = Color.White };
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            content.RowStyles.Clear(); content.RowCount = 0;
            void Add(Control c, int height)
            {
                int row = content.RowCount++; content.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                c.Dock = DockStyle.Top;
                c.Margin = new Padding(0, 0, 0, c is Label ? 6 : 14);
                if (c is Label label) label.AutoSize = true;
                if (c == moTa) c.Height = height;
                content.Controls.Add(c, 0, row);
            }
            void Field(string label, Control control, int height = 40)
            {
                Add(new Label { Text = label, TextAlign = ContentAlignment.MiddleLeft }, 28); Add(control, height);
            }
            Add(new Label { Text = Text, Font = new Font(Font.FontFamily, 17, FontStyle.Bold) }, 44);
            Field("Tên món *", ten);
            var categoryHeading = new TableLayoutPanel { ColumnCount = 2, RowCount = 1, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Margin = Padding.Empty };
            categoryHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50)); categoryHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            categoryHeading.Controls.Add(new Label { Text = "Danh mục *", AutoSize = true, Dock = DockStyle.Fill, Margin = Padding.Empty }, 0, 0);
            var addCategory = new LinkLabel { Text = "+ Thêm danh mục", AutoSize = true, Dock = DockStyle.Fill, Margin = Padding.Empty, TextAlign = ContentAlignment.MiddleRight, LinkColor = Theme.Blue };
            categoryHeading.Controls.Add(addCategory, 1, 0); Add(categoryHeading, 28); Add(danhMuc, 40);
            Field("Đơn giá (₫) *", gia); Field("Đơn vị tính *", donVi);
            Field("Mô tả món", moTa, 76); Field("Trạng thái *", trangThai);
            trangThai.Items.AddRange(TrangThaiMonAn.TatCa); trangThai.SelectedIndex = 0;
            Add(loi, 58);
            var buttons = new TableLayoutPanel { Dock = DockStyle.Bottom, AutoSize = true, ColumnCount = 2, RowCount = 1, Padding = new Padding(22, 12, 22, 16), BackColor = Theme.Background };
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50)); buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            var save = new Button { Text = "Lưu", AutoSize = true, Padding = new Padding(8), BackColor = Theme.Blue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Dock = DockStyle.Fill };
            var cancel = new Button { Text = "Hủy", AutoSize = true, Padding = new Padding(8), DialogResult = DialogResult.Cancel, Dock = DockStyle.Fill, FlatStyle = FlatStyle.Flat, BackColor = Theme.SurfaceMuted };
            save.FlatAppearance.BorderSize = 0; cancel.FlatAppearance.BorderColor = Theme.Divider;
            buttons.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            buttons.Controls.Add(save, 0, 0); buttons.Controls.Add(cancel, 1, 0);
            scroll.Controls.Add(content); Controls.Add(scroll); Controls.Add(buttons); CancelButton = cancel;
            content.SizeChanged += (_, _) => loi.MaximumSize = new Size(Math.Max(100, content.ClientSize.Width - content.Padding.Horizontal), 0);
            ResumeLayout(true);
            Load += (_, _) =>
            {
                if (Session.Role != "ADMIN") { DialogResult = DialogResult.Cancel; Close(); return; }
                try
                {
                    NapDanhMuc(mon == null || mon.IsNull("DanhMucID") ? null : Convert.ToInt32(mon["DanhMucID"]));
                    if (mon != null)
                    {
                        ten.Text = Convert.ToString(mon["TenMon"]); gia.Value = Convert.ToDecimal(mon["DonGia"]);
                        donVi.Text = Convert.ToString(mon["DonViTinh"]); moTa.Text = Convert.ToString(mon["MoTa"]);
                        trangThai.SelectedItem = Convert.ToString(mon["TrangThaiMon"]);
                    }
                    else donVi.Text = "Phần";
                }
                catch (Exception ex) { loi.Text = "Không tải được danh mục: " + ex.Message; save.Enabled = false; }
            };
            save.Click += (_, _) =>
            {
                try
                {
                    ValidateChildren(); 
                    if (danhMuc.SelectedValue is not int dm || trangThai.SelectedItem == null) throw new ArgumentException("Chọn danh mục và trạng thái món.");
                    MonDaLuu = QuanLyThucDon.Luu(id, ten.Text, dm, gia.Value, donVi.Text, moTa.Text, trangThai.Text);
                    DialogResult = DialogResult.OK; Close();
                }
                catch (Exception ex) { loi.Text = ex.Message; }
            };
            addCategory.LinkClicked += (_, _) =>
            {
                using var dialog = new Form { Text = "Thêm danh mục", ClientSize = new Size(380, 150), Font = Font, StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false, MinimizeBox = false };
                var input = new TextBox { Left = 18, Top = 38, Width = 340, MaxLength = 100 };
                var label = new Label { Text = "Tên danh mục", Left = 18, Top = 12, AutoSize = true };
                var ok = new Button { Text = "Thêm", Left = 258, Top = 88, Width = 100, Height = 34, BackColor = Theme.Blue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                dialog.Controls.AddRange(new Control[] { label, input, ok }); dialog.AcceptButton = ok;
                ok.Click += (_, _) =>
                {
                    try { int dm = QuanLyThucDon.ThemDanhMuc(input.Text); NapDanhMuc(dm); dialog.DialogResult = DialogResult.OK; dialog.Close(); }
                    catch (Exception ex) { MessageBox.Show(dialog, ex.Message, "Chưa thêm được danh mục", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                };
                dialog.ShowDialog(this);
            };
            FormClosed += (_, _) => (danhMuc.DataSource as DataTable)?.Dispose();
        }
        private void NapDanhMuc(int? selected)
        {
            var data = BepRepository.LayDanhMuc(); var old = danhMuc.DataSource as DataTable;
            danhMuc.DisplayMember = "TenDanhMuc"; danhMuc.ValueMember = "DanhMucID"; danhMuc.DataSource = data; old?.Dispose();
            if (selected.HasValue) danhMuc.SelectedValue = selected.Value;
        }
    }
}