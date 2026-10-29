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
        private static bool CoQuyenThem
        {
            get { return Session.Role == "BEP" || Session.Role == "ADMIN"; }
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
                    row.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226);
                else if (sapHetHan)
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 237, 213);
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
            if (!CoQuyenThem)
            {
                MessageBox.Show("Bạn không có quyền thêm nguyên liệu.");
                return;
            }
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
            if (ten.Length == 0)
            {
                MessageBox.Show("Hãy nhập tên nguyên liệu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNL.Focus();
                return;
            }
            if (dvt.Length == 0)
            {
                MessageBox.Show("Hãy nhập hoặc chọn đơn vị tính.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDvt.Focus();
                return;
            }

            DateTime? han = dtpHan.Checked ? (DateTime?)dtpHan.Value.Date : null;
            if (han.HasValue && han.Value < DateTime.Today &&
                MessageBox.Show("Hạn sử dụng đã qua. Vẫn thêm nguyên liệu này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                if (!BepRepository.ThemNguyenLieu(ten, dvt, nudTon.Value, nudCanhBao.Value, han))
                {
                    MessageBox.Show("Nguyên liệu \"" + ten + "\" đã có trong danh sách. Hãy chọn dòng đó và sửa số lượng.",
                        "Trùng tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KetThucThem();
            TaiNguyenLieu();
            ChonTheoTen(ten);
            MessageBox.Show("Đã thêm nguyên liệu: " + ten, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
