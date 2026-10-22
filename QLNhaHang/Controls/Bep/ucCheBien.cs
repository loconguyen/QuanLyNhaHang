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
    public partial class ucCheBien : UserControl
    {
        private static readonly Color MauCho = Color.FromArgb(255, 233, 220);
        private static readonly Color MauDang = Color.FromArgb(220, 235, 255);
        private static readonly Color MauXong = Color.FromArgb(221, 245, 227);
        private bool _daLoad;
        private int _soChoTruoc = -1;
        private string _selKey;     // "DonHangID|MonID" của dòng đang chọn
        private bool _dangNap;
        private static bool CoQuyen
        {
            get { return Session.Role == "BEP" || Session.Role == "ADMIN"; }
        }
        public ucCheBien()
        {
            InitializeComponent();
            dgvMon.AutoGenerateColumns = false;
            cboLoc.SelectedIndexChanged -= cboLoc_SelectedIndexChanged;
            cboLoc.Items.AddRange(new object[] { "Tất cả", "Chờ chế biến", "Đang chế biến", "Đã hoàn thành" });
            cboLoc.SelectedIndex = 0;
            cboLoc.SelectedIndexChanged += cboLoc_SelectedIndexChanged;
        }

        private bool DangThietKe
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        private void ucCheBien_Load(object sender, EventArgs e)
        {
            if (DangThietKe)
                return;
            _daLoad = true;
            LamMoiMon(false);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LamMoiMon(true);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiMon(false);
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LamMoiMon(false);
        }

        private void dgvMon_SelectionChanged(object sender, EventArgs e)
        {
            if (!_dangNap)
                DongDaChon();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(true);
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(false);
        }

        private void dgvMon_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMon.Rows)
            {
                var r = row.DataBoundItem as DataRowView;
                if (r == null)
                    continue;
                switch (Convert.ToString(r["TrangThaiMon"]))
                {
                    case TrangThaiMon.ChoCheBien:
                        row.DefaultCellStyle.BackColor = MauCho;
                        break;
                    case TrangThaiMon.DangCheBien:
                        row.DefaultCellStyle.BackColor = MauDang;
                        break;
                    case TrangThaiMon.DaHoanThanh:
                        row.DefaultCellStyle.BackColor = MauXong;
                        break;
                }
            }
        }

        private void btnLuuGhiChu_Click(object sender, EventArgs e)
        {
            if (!CoQuyen) { MessageBox.Show("Bạn không có quyền thực hiện thao tác này."); return; }   
            var r = Chon();
            if (r == null) return;
            try
            {
                bool ok = BepRepository.CapNhatGhiChu(Convert.ToInt32(r["DonHangID"]), Convert.ToInt32(r["MonID"]), txtGhiChu.Text.Trim());
                lblThongBao.Text = ok ? "Đã lưu ghi chú." : "Không thể lưu ghi chú (món đã hoàn thành/hủy).";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LamMoiMon(false);
        }

        private static string KeyCua(DataRowView r)
        {
            return r == null ? null : r["DonHangID"] + "|" + r["MonID"];
        }

        private DataRowView Chon()
        {
            return dgvMon.CurrentRow == null ? null : dgvMon.CurrentRow.DataBoundItem as DataRowView;
        }

        private string BoLoc()
        {
            switch (cboLoc.SelectedIndex)
            {
                case 1: return "TrangThaiMon = '" + TrangThaiMon.ChoCheBien + "'";
                case 2: return "TrangThaiMon = '" + TrangThaiMon.DangCheBien + "'";
                case 3: return "TrangThaiMon = '" + TrangThaiMon.DaHoanThanh + "'";
                default: return "";
            }
        }
        private static int Dem(DataTable dt, string trangThai)
        {
            return Convert.ToInt32(dt.Compute("COUNT(DonHangID)", "TrangThaiMon = '" + trangThai + "'"));
        }

        private void LamMoiMon(bool baoMonMoi)
        {
            lblThongBao.ForeColor = Color.DimGray;
            DataTable dt;
            try
            {
                dt = BepRepository.LayMonCanCheBien();
            }
            catch (Exception ex)
            {
                lblThongBao.Text = "Lỗi kết nối CSDL: " + ex.Message;
                return;
            }
            int cho = Dem(dt, TrangThaiMon.ChoCheBien);
            lblCho.Text = cho.ToString("00");
            lblDang.Text = Dem(dt, TrangThaiMon.DangCheBien).ToString("00");
            lblXong.Text = Dem(dt, TrangThaiMon.DaHoanThanh).ToString("00");
            if (baoMonMoi && _soChoTruoc >= 0 && cho > _soChoTruoc)
            {
                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Text = "Có món mới gửi xuống bếp lúc " + DateTime.Now.ToString("HH:mm:ss");
            }
            _soChoTruoc = cho;
            string keyCu = _selKey;
            _dangNap = true;
            try
            {
                dt.DefaultView.RowFilter = BoLoc();
                dgvMon.DataSource = dt.DefaultView;
                if (keyCu != null)
                {
                    foreach (DataGridViewRow row in dgvMon.Rows)
                    {
                        if (KeyCua(row.DataBoundItem as DataRowView) == keyCu)
                        {
                            dgvMon.CurrentCell = row.Cells[colMaDon.Index];
                            break;
                        }
                    }
                }
            }
            finally
            {
                _dangNap = false;
            }
            DongDaChon();

        }

        private void DongDaChon()
        {
            var r = Chon();
            string key = KeyCua(r);
            if (key != _selKey)     // chọn dòng khác -> nạp ghi chú; cùng dòng (do timer) -> giữ chữ đang gõ
            {
                _selKey = key;
                txtGhiChu.Text = r == null ? "" : Convert.ToString(r["GhiChu"]);
            }
            string tt = r == null ? "" : Convert.ToString(r["TrangThaiMon"]);
            btnBatDau.Enabled = CoQuyen && tt == TrangThaiMon.ChoCheBien;
            btnHoanThanh.Enabled = CoQuyen && tt == TrangThaiMon.DangCheBien;
            btnLuuGhiChu.Enabled = CoQuyen && (tt == TrangThaiMon.ChoCheBien || tt == TrangThaiMon.DangCheBien);
        }

        private void ChuyenTrangThai(bool batDau)
        {
            if (!CoQuyen) { MessageBox.Show("Bạn không có quyền thực hiện thao tác này."); return; }   
            var r = Chon();
            if (r == null) return;
            int dh = Convert.ToInt32(r["DonHangID"]);
            int mon = Convert.ToInt32(r["MonID"]);
            try
            {
                bool ok = batDau ? BepRepository.BatDauCheBien(dh, mon) : BepRepository.HoanThanh(dh, mon);
                if (!ok)
                    MessageBox.Show(batDau ? "Món này không còn ở trạng thái 'Chờ chế biến' (có thể đã được xử lý hoặc bị hủy)."
                        : "Món này không còn ở trạng thái 'Đang chế biến'.",
                        "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    lblThongBao.Text = (batDau ? "Đã bắt đầu chế biến: " : "Đã hoàn thành: ") + r["TenMon"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LamMoiMon(false);
        }
    }
}