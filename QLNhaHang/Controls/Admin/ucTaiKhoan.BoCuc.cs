namespace QLNhaHang.Controls.Admin
{
    public partial class ucTaiKhoan
    {
        // Chỉ bố trí các component đã có; không thay đổi font/DPI của Windows.
        private void ThietLapBoCuc()
        {
            SuspendLayout();
            pnlBoCuc.SuspendLayout();
            for (int i = 0; i < pnlBoCuc.RowStyles.Count; i++)
                pnlBoCuc.RowStyles[i].SizeType = i == 3 ? SizeType.Percent : SizeType.AutoSize;
            pnlBoCuc.RowStyles[3].Height = 100;

            pnlTieuDe.AutoSize = true;
            pnlTieuDe.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            foreach (RowStyle hang in pnlTieuDe.RowStyles) hang.SizeType = SizeType.AutoSize;
            lblTieuDe.AutoSize = true;
            lblTieuDe.Margin = new Padding(0, 4, 12, 12);
            btnThem.AutoSize = true;
            btnThem.Padding = new Padding(10, 6, 10, 6);
            btnThem.Margin = new Padding(0, 4, 0, 12);
            pnlTieuDe.ColumnStyles[1].Width = TextRenderer.MeasureText(btnThem.Text, btnThem.Font).Width
                + btnThem.Padding.Horizontal + 24;

            pnlThongKe.AutoSize = true;
            pnlThongKe.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlThongKe.RowStyles[0].SizeType = SizeType.AutoSize;
            BoTriThongKe(pnlTongSo, lblTongSo, lblNhanTongSo);
            BoTriThongKe(pnlChoDuyet, lblChoDuyet, lblNhanChoDuyet);
            BoTriThongKe(pnlHoatDong, lblHoatDong, lblNhanHoatDong);
            BoTriThongKe(pnlBiKhoa, lblBiKhoa, lblNhanBiKhoa);

            pnlBoLoc.AutoSize = true;
            pnlBoLoc.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlBoLoc.RowStyles[0].SizeType = SizeType.AutoSize;
            txtTimKiem.Dock = cbLocTrangThai.Dock = cbLocVaiTro.Dock = DockStyle.Top;
            btnTaiLai.AutoSize = true;
            btnTaiLai.Padding = new Padding(6, 3, 6, 3);
            pnlBoLoc.ColumnStyles[1].Width = RongBoLoc(cbLocTrangThai);
            pnlBoLoc.ColumnStyles[2].Width = RongBoLoc(cbLocVaiTro);
            pnlBoLoc.ColumnStyles[3].Width = TextRenderer.MeasureText(btnTaiLai.Text, btnTaiLai.Font).Width + 28;
            pnlNoiDung.ColumnStyles[1].Width = Math.Max(320,
                TextRenderer.MeasureText(new string('0', 24), Font).Width + 64);

            foreach (FlowLayoutPanel khung in new[] { pnlChiTiet, pnlMatKhau })
            {
                khung.AutoScroll = true;
                khung.WrapContents = false;
                foreach (Control thanhPhan in khung.Controls)
                {
                    if (thanhPhan is Label nhan)
                    {
                        nhan.AutoSize = true;
                        nhan.AutoEllipsis = false;
                        nhan.Margin = new Padding(0, 0, 0, 8);
                    }
                    else if (thanhPhan is CheckBox hopChon)
                        hopChon.AutoSize = true;
                }
                khung.SizeChanged += (_, _) => CanChinhChiTiet(khung);
                CanChinhChiTiet(khung);
            }
            foreach (FlowLayoutPanel hangNut in new[] { pnlDuyet, pnlQuanTri })
            {
                hangNut.AutoSize = true;
                hangNut.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                hangNut.WrapContents = true;
                foreach (Button nut in hangNut.Controls.OfType<Button>())
                {
                    nut.AutoSize = true;
                    nut.Padding = new Padding(8, 5, 8, 5);
                    nut.Margin = new Padding(0, 0, 6, 6);
                }
            }
            btnDatLaiMatKhau.AutoSize = true;
            btnDatLaiMatKhau.Padding = new Padding(8, 5, 8, 5);
            lblThongBao.AutoSize = true;

            KhoiPhucCotNeuThieu();
            pnlBoCuc.ResumeLayout(true);
            ResumeLayout(true);
        }

        private static void BoTriThongKe(Panel khung, Label soLuong, Label moTa)
        {
            // Dock theo thứ tự: số ở trên, chú thích ở dưới, không dựa vào tọa độ cố định.
            khung.SuspendLayout();
            khung.AutoSize = true;
            khung.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            khung.Padding = new Padding(14, 8, 14, 10);
            soLuong.AutoSize = moTa.AutoSize = true;
            soLuong.Dock = moTa.Dock = DockStyle.Top;
            khung.Controls.SetChildIndex(soLuong, 1);
            khung.Controls.SetChildIndex(moTa, 0);
            khung.ResumeLayout(true);
        }

        private static int RongBoLoc(ComboBox boLoc) => boLoc.Items.Cast<object>()
            .Select(muc => TextRenderer.MeasureText(muc.ToString(), boLoc.Font).Width)
            .DefaultIfEmpty(100).Max() + SystemInformation.VerticalScrollBarWidth + boLoc.Margin.Horizontal + 18;

        private static void CanChinhChiTiet(FlowLayoutPanel khung)
        {
            int rong = Math.Max(80, khung.ClientSize.Width - khung.Padding.Horizontal
                - SystemInformation.VerticalScrollBarWidth - 2);
            khung.SuspendLayout();
            foreach (Control thanhPhan in khung.Controls)
            {
                if (thanhPhan is Label nhan)
                {
                    nhan.MinimumSize = new Size(rong, 0);
                    nhan.MaximumSize = new Size(rong, 0);
                }
                else
                {
                    thanhPhan.Width = rong;
                    if (thanhPhan is FlowLayoutPanel hangNut)
                        hangNut.MaximumSize = new Size(rong, 0);
                }
            }
            khung.ResumeLayout(true);
        }

        private void KhoiPhucCotNeuThieu()
        {
            if (dgvTaiKhoan.Columns.Count != 0) return;
            // Giữ lưới hoạt động nếu Designer làm mất collection Columns khi lưu.
            colMaTaiKhoan = new DataGridViewTextBoxColumn { Name = "colMaTaiKhoan", DataPropertyName = "TaiKhoanID", HeaderText = "Mã TK", Visible = false };
            colTenDangNhap = new DataGridViewTextBoxColumn { Name = "colTenDangNhap", DataPropertyName = "TenDangNhap", HeaderText = "Tên đăng nhập", MinimumWidth = 130 };
            colHoTen = new DataGridViewTextBoxColumn { Name = "colHoTen", DataPropertyName = "HoTen", HeaderText = "Họ tên", MinimumWidth = 155 };
            colMaNhanVien = new DataGridViewTextBoxColumn { Name = "colMaNhanVien", DataPropertyName = "NhanVienID", HeaderText = "Mã NV", Visible = false };
            colSDT = new DataGridViewTextBoxColumn { Name = "colSDT", DataPropertyName = "SDT", HeaderText = "Điện thoại", MinimumWidth = 100 };
            colVaiTro = new DataGridViewTextBoxColumn { Name = "colVaiTro", DataPropertyName = "TenVaiTro", HeaderText = "Vai trò", MinimumWidth = 85 };
            colTrangThai = new DataGridViewTextBoxColumn { Name = "colTrangThai", DataPropertyName = "TrangThai", HeaderText = "Trạng thái", MinimumWidth = 100 };
            dgvTaiKhoan.Columns.AddRange(colMaTaiKhoan, colTenDangNhap, colHoTen, colMaNhanVien, colSDT, colVaiTro, colTrangThai);
        }
    }
}
