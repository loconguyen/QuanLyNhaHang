using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLNhaHang.Classes;

namespace QLNhaHang.Controls.Admin
{
    public partial class ucDuyetNhanVien : UserControl
    {
        private int taiKhoanID;

        private readonly QuanLyTaiKhoan qltk =
          new QuanLyTaiKhoan();
        public ucDuyetNhanVien()
        {
            InitializeComponent();
            gbNhanVienDaCo.Enabled = false;
            gbNhanVienMoi.Enabled = false;
        }
        // Constructor nhận mã tài khoản từ ucTaiKhoan
        public ucDuyetNhanVien(int taiKhoanID) : this()
        {
            this.taiKhoanID = taiKhoanID;
            LoadThongTinDangKy();
        }
        private void LoadThongTinDangKy()
        {
            try
            {
                DataRow? row =
                    qltk.LayThongTinDangKy(taiKhoanID);

                if (row == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy tài khoản đang chờ duyệt!");
                    return;
                }

                // Hiển thị thông tin đăng ký
                txtTenDangNhap.Text =
                    row["TenDangNhap"].ToString();

                txtHoTenDK.Text =
                    row["HoTenDangKy"].ToString();

                txtSDTDK.Text =
                    row["SDTDangKy"].ToString();

                txtThoiGianDK.Text =
                    row["NgayDangKy"] == DBNull.Value
                    ? ""
                    : Convert.ToDateTime(
                        row["NgayDangKy"]).ToString("dd/MM/yyyy HH:mm");

                txtTrangThai.Text =
                    row["TrangThai"].ToString();

                // Không cho sửa thông tin đăng ký
                txtTenDangNhap.ReadOnly = true;
                txtHoTenDK.ReadOnly = true;
                txtSDTDK.ReadOnly = true;
                txtThoiGianDK.ReadOnly = true;
                txtTrangThai.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải thông tin đăng ký: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gbNhanVienDaCo.Enabled = radioButton1.Checked;
            gbNhanVienMoi.Enabled = radioButton2.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gbNhanVienDaCo.Enabled = radioButton1.Checked;
            gbNhanVienMoi.Enabled = radioButton2.Checked;
        }

        private void gbNhanVienDaCo_Enter(object sender, EventArgs e)
        {

        }

        private void lblDuyetTaiKhoan_Click(object sender, EventArgs e)
        {

        }
    }
}
