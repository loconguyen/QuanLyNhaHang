#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLNhaHang.Classes;

namespace QLNhaHang.Controls.Bep
{
    public partial class ucThucDon : UserControl
    {
        private DataTable _dtThucDon;
        private bool _daLoad;
        private bool _dangNap;
        private int _monId = -1;
        private static bool CoQuyen
        {
            get { return Session.Role == "BEP" || Session.Role == "ADMIN"; }
        }
        public ucThucDon()
        {
            InitializeComponent();
            dgvThucDon.AutoGenerateColumns = false;
            foreach (DataGridViewColumn c in dgvThucDon.Columns) c.SortMode = DataGridViewColumnSortMode.NotSortable;
            cboTrangThai.Items.AddRange(TrangThaiMonAn.TatCa);
        }

        private bool DangThietKe
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        private void ucThucDon_Load(object sender, EventArgs e)
        {
            if (DangThietKe)
                return;
            _daLoad = true;
            TaiAnToan();
        }

        private void ucThucDon_VisibleChanged(object sender, EventArgs e)
        {
            if (DangThietKe)
                return;
            if (_daLoad && Visible)
            {
                TaiAnToan();
            }
        }

        private void cboDanhMuc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LocThucDon();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            LocThucDon();
        }
        private void dgvThucDon_SelectionChanged(object sender, EventArgs e)
        {
            if (!_dangNap) DongDaChon();
        }
        // Tô màu theo trạng thái kinh doanh
        private void dgvThucDon_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvThucDon.Rows)
            {
                var rv = row.DataBoundItem as DataRowView;
                if (rv == null) continue;
                switch (Convert.ToString(rv["TrangThaiMon"]))
                {
                    case TrangThaiMonAn.TamHet: row.DefaultCellStyle.BackColor = Theme.Danger; break;
                    case TrangThaiMonAn.NgungBan: row.DefaultCellStyle.BackColor = Theme.Divider; break;
                }
            }
        }
        private void btnLuuTrangThai_Click(object sender, EventArgs e)
        {
            if (!CoQuyen) { MessageBox.Show("Bạn không có quyền thực hiện thao tác này."); return; }
            if (_monId < 0 || cboTrangThai.SelectedItem == null) return;
            try
            {
                bool ok = BepRepository.CapNhatTrangThaiMonAn(_monId, cboTrangThai.SelectedItem.ToString());
                MessageBox.Show(ok ? "Đã cập nhật trạng thái món." : "Không cập nhật được (không tìm thấy món).",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TaiAnToan();   // nạp lại, vẫn giữ món đang chọn và danh mục đang lọc
        }
        private void TaiAnToan()
        {
            try
            {
                Nap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Nap()
        {
            int giuMon = _monId;
            int giuDanhMuc = cboDanhMuc.SelectedValue == null || cboDanhMuc.SelectedValue is DataRowView
                ? 0 : Convert.ToInt32(cboDanhMuc.SelectedValue);

            _dangNap = true;
            try
            {
                var dm = BepRepository.LayDanhMuc();   // đã sắp A-Z theo tên danh mục
                var all = dm.NewRow();
                all["DanhMucID"] = 0;
                all["TenDanhMuc"] = "Tất cả";
                dm.Rows.InsertAt(all, 0);
                cboDanhMuc.DisplayMember = "TenDanhMuc";
                cboDanhMuc.ValueMember = "DanhMucID";
                cboDanhMuc.DataSource = dm;
                cboDanhMuc.SelectedValue = giuDanhMuc;

                _dtThucDon = BepRepository.LayThucDon();   // đã sắp: danh mục A-Z, rồi tên món A-Z
                dgvThucDon.DataSource = _dtThucDon.DefaultView;
                LocThucDon();
                ChonLaiMon(giuMon);
            }
            finally { _dangNap = false; }
            DongDaChon();
        }
        private void LocThucDon()
        {
            if (_dtThucDon == null) return;
            var dk = new List<string>();
            if (cboDanhMuc.SelectedValue != null && !(cboDanhMuc.SelectedValue is DataRowView))
            {
                int id = Convert.ToInt32(cboDanhMuc.SelectedValue);
                if (id != 0) dk.Add("DanhMucID = " + id);
            }
            string t = txtTim.Text.Trim()
                .Replace("'", "''").Replace("[", "").Replace("]", "").Replace("%", "").Replace("*", "");
            if (t.Length > 0) dk.Add("TenMon LIKE '%" + t + "%'");
            _dtThucDon.DefaultView.RowFilter = string.Join(" AND ", dk.ToArray());
        }
        private void ChonLaiMon(int monId)
        {
            if (monId < 0) return;
            foreach (DataGridViewRow row in dgvThucDon.Rows)
            {
                var rv = row.DataBoundItem as DataRowView;
                if (rv != null && Convert.ToInt32(rv["MonID"]) == monId)
                {
                    dgvThucDon.CurrentCell = row.Cells[colTenMon.Index];
                    return;
                }
            }
        }
        private void DongDaChon()
        {
            var rv = dgvThucDon.CurrentRow == null ? null : dgvThucDon.CurrentRow.DataBoundItem as DataRowView;
            if (rv == null)
            {
                _monId = -1;
                txtTenMon.Text = "";
                cboTrangThai.SelectedIndex = -1;
                btnLuuTrangThai.Enabled = false;
                return;
            }
            _monId = Convert.ToInt32(rv["MonID"]);
            txtTenMon.Text = Convert.ToString(rv["TenMon"]);
            cboTrangThai.SelectedItem = Convert.ToString(rv["TrangThaiMon"]);
            btnLuuTrangThai.Enabled = CoQuyen;
        }
    }
}
