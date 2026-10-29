using QLNhaHang.Classes;
using QLNhaHang.Forms.ThucDon;
using System.Data;

namespace QLNhaHang.Controls.Bep
{
    public partial class ucThucDon
    {
        private FlowLayoutPanel thanhQuanTri;
        private Button btnThemMon, btnSuaMon, btnXoaMon;
        private void TaoNutQuanTri()
        {
            thanhQuanTri = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(10), BackColor = Theme.Background, WrapContents = true };
            Button Nut(string text, Color color)
            {
                var b = new Button { Text = text, AutoSize = true, MinimumSize = new Size(105, 36), Padding = new Padding(8, 3, 8, 3), BackColor = color, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Margin = new Padding(0, 0, 10, 0) };
                b.FlatAppearance.BorderSize = 0; thanhQuanTri.Controls.Add(b); return b;
            }
            btnThemMon = Nut("+  Thêm món", Theme.Blue);
            btnSuaMon = Nut("Sửa món", Theme.Teal);
            btnXoaMon = Nut("Xóa món", Theme.Danger);
            btnThemMon.Click += (_, _) => MoSuaMon(true);
            btnSuaMon.Click += (_, _) => MoSuaMon(false);
            btnXoaMon.Click += (_, _) => XoaMon();
            Controls.Add(thanhQuanTri);
            dgvThucDon.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme.Blue;
            dgvThucDon.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            CapNhatNutQuanTri();
        }
        private void CapNhatNutQuanTri()
        {
            if (thanhQuanTri == null) return;
            bool admin = Session.Role == "ADMIN";
            thanhQuanTri.Visible = admin;
            btnThemMon.Enabled = admin;
            btnSuaMon.Enabled = btnXoaMon.Enabled = admin && _monId > 0;
        }
        private void MoSuaMon(bool them)
        {
            if (Session.Role != "ADMIN") return;
            DataRow? selected = (dgvThucDon.CurrentRow?.DataBoundItem as DataRowView)?.Row;
            if (!them && selected == null) return;
            using var form = new frmMonAn(them ? null : selected);
            if (form.ShowDialog(FindForm()) != DialogResult.OK) return;
            txtTim.Clear(); cboDanhMuc.SelectedValue = 0;
            _monId = form.MonDaLuu;
            TaiAnToan();
        }
        private void XoaMon()
        {
            if (Session.Role != "ADMIN" || _monId < 1) return;
            if (MessageBox.Show(FindForm(), $"Xóa món “{txtTenMon.Text}” khỏi thực đơn?\nMón đã có dữ liệu liên quan sẽ không được xóa.", "Xác nhận xóa món", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
            try { QuanLyThucDon.Xoa(_monId); _monId = -1; TaiAnToan(); }
            catch (Exception ex) { MessageBox.Show(FindForm(), ex.Message, "Không thể xóa món", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }
}
