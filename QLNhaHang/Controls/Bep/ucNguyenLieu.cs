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

    //Nguyên liệu: xem, chỉ sửa tồn kho / mức cảnh báo / hạn sử dụng.
    public partial class ucNguyenLieu : UserControl
    {
        private int _nlId = -1;
        private bool _dangNapNL;
        private bool _daLoad;
        public ucNguyenLieu()
        {
            InitializeComponent();
            dgvNL.AutoGenerateColumns = false;
            foreach (DataGridViewColumn c in dgvNL.Columns) c.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private bool DangThietKe
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        private void ucNguyenLieu_Load(object sender, EventArgs e)
        {
            if (DangThietKe)
                return;
            _daLoad = true;
            TaiAnToan();
        }

        private void ucNguyenLieu_VisibleChanged(object sender, EventArgs e)
        {
            if (DangThietKe)
                return;
            if (_daLoad && Visible)
            {
                TaiAnToan();
            }
        }

        private void dgvNL_SelectionChanged(object sender, EventArgs e)
        {
            if (!_dangNapNL)
                DongNLDaChon();
        }
        private static decimal Dec(object o)
        {
            return o == null || o == DBNull.Value ? 0m : Convert.ToDecimal(o);
        }

        private void dgvNL_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvNL.Rows)
            {
                var rv = row.DataBoundItem as DataRowView;
                if (rv == null)
                    continue;
                bool sapHet = Dec(rv["SoLuongTon"]) <= Dec(rv["MucCanhBao"]);
                bool sapHetHan = rv["HanSuDung"] != DBNull.Value && Convert.ToDateTime(rv["HanSuDung"]).Date <= DateTime.Today.AddDays(7);
                if (sapHet)
                    row.DefaultCellStyle.BackColor = Theme.DangerSoft;
                else if (sapHetHan)
                    row.DefaultCellStyle.BackColor = Theme.OrangeSoft;
            }
        }

        private void TaiAnToan()
        {
            try
            {
                TaiNguyenLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TaiNguyenLieu()
        {
            int giu = _nlId;
            _dangNapNL = true;
            try
            {
                dgvNL.DataSource = BepRepository.LayNguyenLieu();
                if (giu >= 0)
                {
                    foreach (DataGridViewRow row in dgvNL.Rows)
                    {
                        var rv = row.DataBoundItem as DataRowView;
                        if (rv != null && Convert.ToInt32(rv["NguyenLieuID"]) == giu)
                        {
                            dgvNL.CurrentCell = row.Cells[colTenNguyeLieu.Index];
                            break;
                        }
                    }
                }
            }
            finally
            {
                _dangNapNL = false;
            }
            DongNLDaChon();
        }

        private void DongNLDaChon()
        {
            var rv = dgvNL.CurrentRow == null ? null : dgvNL.CurrentRow.DataBoundItem as DataRowView;
            if (rv == null)
            {
                _nlId = -1;
                txtTenNL.Text = "";
                lblDvtTon.Text = "";                 
                lblDvtCanhBao.Text = "";              
                btnLuuNL.Enabled = false;
                return;
            }
            _nlId = Convert.ToInt32(rv["NguyenLieuID"]);
            txtTenNL.Text = Convert.ToString(rv["TenNguyenLieu"]);

            string dvt = Convert.ToString(rv["DonViTinh"]);   
            lblDvtTon.Text = dvt;                              
            lblDvtCanhBao.Text = dvt;                          

            nudTon.Value = Math.Min(nudTon.Maximum, Dec(rv["SoLuongTon"]));
            nudCanhBao.Value = Math.Min(nudCanhBao.Maximum, Dec(rv["MucCanhBao"]));
            if (rv["HanSuDung"] == DBNull.Value)
            {
                dtpHan.Checked = false;
            }
            else
            {
                dtpHan.Value = Convert.ToDateTime(rv["HanSuDung"]);
                dtpHan.Checked = true;
            }
            btnLuuNL.Enabled = true;
        }

        private void btnLuuNL_Click(object sender, EventArgs e)
        {
            if (_nlId < 0) return;
            try
            {
                bool ok = BepRepository.CapNhatNguyenLieu(_nlId, nudTon.Value, nudCanhBao.Value,
                    dtpHan.Checked ? (DateTime?)dtpHan.Value.Date : null);
                MessageBox.Show(ok ? "Đã cập nhật nguyên liệu." : "Không tìm thấy nguyên liệu.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TaiNguyenLieu();
        }
    }
}
