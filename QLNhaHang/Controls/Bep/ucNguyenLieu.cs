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
        private bool _dangThem;                 // đang ở chế độ thêm nguyên liệu
        private bool _tenChiDoc;                // trạng thái ReadOnly gốc của ô tên
        private string _chuLuu, _chuThem;       // chữ gốc của 2 nút
        private ComboBox cboDvt;                // đơn vị tính (chỉ hiện khi thêm)
        public ucNguyenLieu()
        {
            InitializeComponent();
            dgvNL.AutoGenerateColumns = false;
            foreach (DataGridViewColumn c in dgvNL.Columns) c.SortMode = DataGridViewColumnSortMode.NotSortable;
            cboDvt = new ComboBox
            {
                Location = lblDvtTon.Location,
                Width = 70,
                MaxLength = 30,
                Visible = false
            };
            cboDvt.Items.AddRange(new object[] { "kg", "g", "lít", "ml", "quả", "gói", "hộp", "chai", "lon", "bó", "thùng" });
            cboDvt.TextChanged += (s, e) => { if (_dangThem) lblDvtCanhBao.Text = cboDvt.Text; };
            lblDvtTon.Parent.Controls.Add(cboDvt);
            cboDvt.BringToFront();

            _tenChiDoc = txtTenNL.ReadOnly;
            _chuLuu = btnLuuNL.Text;
            _chuThem = btnThemNL.Text;
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
            if (_daLoad && Visible && !_dangThem)
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
        private static void DatSo(NumericUpDown n, decimal v)
        {
            n.Value = v == n.Maximum ? n.Minimum : n.Maximum;
            n.Value = v;
        }

        private static bool ChuaNhap(NumericUpDown n)
        {
            return n.Text.Trim().Length == 0;
        }
        // Trả về true nếu hợp lệ (tồn > mức cảnh báo); ngược lại báo lỗi và đưa con trỏ về ô Tồn
        private bool TonHopLe()
        {
            if (nudTon.Value > nudCanhBao.Value) return true;

            MessageBox.Show(
                "Số lượng tồn (" + nudTon.Value.ToString("0.##") + ") phải lớn hơn mức cảnh báo (" +
                nudCanhBao.Value.ToString("0.##") + ").\nHãy nhập lại tồn hoặc giảm mức cảnh báo.",
                "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nudTon.Focus();
            nudTon.Select(0, nudTon.Text.Length);
            return false;
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
            if (_dangThem) return;
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
            if (_dangThem)                  // nút Lưu đang đóng vai trò "Hủy"
            {
                KetThucThem();
                DongNLDaChon();
                return;
            }
            if (_nlId < 0) return;
            if (!TonHopLe()) return;
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

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (!_dangThem) BatDauThem();
            else XacNhanThem();
        }
        private void BatDauThem()
        {
            _dangThem = true;
            _nlId = -1;

            dgvNL.Enabled = false;
            txtTenNL.ReadOnly = false;
            txtTenNL.Text = "";
            cboDvt.Text = "";
            cboDvt.Visible = true;
            lblDvtTon.Visible = false;
            lblDvtCanhBao.Text = "";
            nudTon.Value = 0;
            nudCanhBao.Value = 0;
            dtpHan.Checked = false;

            btnThemNL.Text = "Xác nhận";
            btnLuuNL.Text = "Hủy";
            btnLuuNL.Enabled = true;
            txtTenNL.Focus();
        }

        private void KetThucThem()
        {
            _dangThem = false;
            DatSo(nudTon, 0);
            DatSo(nudCanhBao, 0);
            dgvNL.Enabled = true;
            txtTenNL.ReadOnly = _tenChiDoc;
            cboDvt.Visible = false;
            lblDvtTon.Visible = true;
            btnThemNL.Text = _chuThem;
            btnLuuNL.Text = _chuLuu;
        }

        private void XacNhanThem()
        {
            string ten = txtTenNL.Text.Trim(), dvt = cboDvt.Text.Trim();

            var thieu = new List<string>();
            Control oDau = null;
            if (ten.Length == 0) { thieu.Add("Tên nguyên liệu"); if (oDau == null) oDau = txtTenNL; }
            if (dvt.Length == 0) { thieu.Add("Đơn vị tính"); if (oDau == null) oDau = cboDvt; }
            if (ChuaNhap(nudTon)) { thieu.Add("Tồn"); if (oDau == null) oDau = nudTon; }
            if (ChuaNhap(nudCanhBao)) { thieu.Add("Mức cảnh báo"); if (oDau == null) oDau = nudCanhBao; }
            if (!dtpHan.Checked) { thieu.Add("Hạn dùng"); if (oDau == null) oDau = dtpHan; }

            if (thieu.Count > 0)
            {
                MessageBox.Show("Bạn chưa nhập:\n- " + string.Join("\n- ", thieu.ToArray()),
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oDau.Focus();
                return;
            }
            if (!TonHopLe()) return;

        }

        private void ChonTheoTen(string ten)
        {
            foreach (DataGridViewRow row in dgvNL.Rows)
            {
                var rv = row.DataBoundItem as DataRowView;
                if (rv != null && string.Equals(Convert.ToString(rv["TenNguyenLieu"]), ten, StringComparison.OrdinalIgnoreCase))
                {
                    DataGridViewColumn cot = dgvNL.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
                    dgvNL.CurrentCell = row.Cells[cot.Index];
                    return;
                }
            }
        }
    }
}
