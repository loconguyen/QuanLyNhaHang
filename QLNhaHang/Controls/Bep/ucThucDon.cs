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
        public ucThucDon()
        {
            InitializeComponent();
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
            var dm = BepRepository.LayDanhMuc();
            var all = dm.NewRow();
            all["DanhMucID"] = 0;
            all["TenDanhMuc"] = "Tất cả";
            dm.Rows.InsertAt(all, 0);
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "DanhMucID";
            cboDanhMuc.DataSource = dm;

            _dtThucDon = BepRepository.LayThucDon();
            dgvThucDon.DataSource = _dtThucDon.DefaultView;
            LocThucDon();
        }
        private void LocThucDon()
        {
            if (_dtThucDon == null)
                return;
            var dk = new List<string>();
            if (cboDanhMuc.SelectedValue != null)
            {
                int id = Convert.ToInt32(cboDanhMuc.SelectedValue);
                if (id != 0)
                    dk.Add("DanhMucID = " + id);
            }
            string t = txtTim.Text.Trim().Replace("'", "''").Replace("[", "").Replace("]", "").Replace("%", "").Replace("*", "");
            if (t.Length > 0)
                dk.Add("TenMon Like '%" + t + "%'");
            _dtThucDon.DefaultView.RowFilter = string.Join(" And ", dk.ToArray());
        }
    }
}
