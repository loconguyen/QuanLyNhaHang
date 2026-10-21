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
    public partial class ucTongQuan : UserControl
    {
        private const int NguongChoPhut = 15;
        private bool _daLoad;
        public ucTongQuan()
        {
            InitializeComponent();
            dgvCho.AutoGenerateColumns = false;
            dgvNL.AutoGenerateColumns = false;
        }

        private bool DangThietKe
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        private void ucTongQuan_Load(object sender, EventArgs e)
        {
            if (DangThietKe)
                return;
            _daLoad = true;
            Nap();
            timer1.Start();
        }

        private void ucTongQuan_VisibleChanged(object sender, EventArgs e)
        {
            if (DangThietKe || !_daLoad)
                return;
            if (Visible)
            {
                Nap();
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Nap();
        }

        private void dgvCho_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCho.Rows)
            {
                var rv = row.DataBoundItem as DataRowView;
                if (rv != null || Convert.ToInt32(rv["PhutCho"]) >= NguongChoPhut)
                    row.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void dgvNL_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvNL.Rows)
            {
                var rv = row.DataBoundItem as DataRowView;
                if (rv == null)
                    continue;
                row.DefaultCellStyle.BackColor = Convert.ToString(rv["LyDo"]) == "Sắp hết hàng" ? Color.FromArgb(254, 226, 226)
                    : Color.FromArgb(255, 237, 213);
            }
        }

        private static int SoMon(DataTable dt, string trangThai)
        {
            foreach(DataRow r in dt.Rows)
                if (Convert.ToString(r["TrangThaiMon"]) == trangThai)
                    return Convert.ToInt32(r["SoMon"]);
            return 0;
        }

        private void Nap()
        {
            try
            {
                var dem = BepRepository.DemMonTheoTrangThai();
                lblCho.Text = SoMon(dem, TrangThaiMon.ChoCheBien).ToString("00");
                lblDang.Text = SoMon(dem, TrangThaiMon.DangCheBien).ToString("00");
                lblXong.Text = SoMon(dem, TrangThaiMon.DaHoanThanh).ToString("00");

                dgvCho.DataSource = BepRepository.LayMonChoLauNhat(10);
                var nl = BepRepository.LayNguyenLieuCanChuY();
                lblNguyenLieu.Text = nl.Rows.Count.ToString("00");
                dgvNL.DataSource = nl;

                lblCapNhat.Text = "Cập nhật lúc: " + DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                lblCapNhat.Text = "Lỗi kết nối CSDL: " + ex.Message;
            }
        }
    }
}
