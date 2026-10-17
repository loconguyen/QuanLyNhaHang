using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLNhaHang.Classes;

namespace QLNhaHang.Forms.DangNhap
{
    public partial class DangNhapForm : Form
    {
        Classes.DataProcesser db = new DataProcesser();
        public DangNhapForm()
        {
            InitializeComponent();
            LoadBoPhan();
            heading.Font = Classes.Theme.H1;
            Classes.Theme.StyleForm(this);
            Classes.Theme.StyleButton(btnDangNhap);
            Classes.Theme.StyleComboBox(cbRole);
            Classes.Theme.StyleTextBox(txtDangNhap);
            Classes.Theme.StyleTextBox(txtMaNhanVien);
            Classes.Theme.StyleTextBox(txtMatKhau);
            Classes.Theme.StyleLink(linkDK);
            Classes.Theme.StyleLink(linkMatKhau);
            pnlDangNhap.Left = (ClientSize.Width - pnlDangNhap.Width) / 2;
            pnlDangNhap.Top = (ClientSize.Height - pnlDangNhap.Height) / 2;
            pnlDangNhap.BackColor = Color.White;

        }

        private void LoadBoPhan()
        {
            cbRole.DataSource = new[]
            {
        new { Text = "Quản lý", Value = "ADMIN" },
        new { Text = "Bếp", Value = "BEP" },
        new { Text = "Thu ngân", Value = "THUNGAN" },
        new { Text ="Phục vụ" , Value ="PHUCVU"}
    };

            cbRole.DisplayMember = "Text";
            cbRole.ValueMember = "Value";
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRole.SelectedIndex = -1;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập
            if (txtDangNhap.Text.Trim() == "" ||
                txtMaNhanVien.Text.Trim() == "" ||
                txtMatKhau.Text == "" ||
                cbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!int.TryParse(txtMaNhanVien.Text, out int maNV))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ!");
                return;
            }

            string username = txtDangNhap.Text.Trim();
            string password = txtMatKhau.Text;
            string role = cbRole.SelectedValue!.ToString()!;

        
                // Lấy tài khoản từ CSDL
                string sql = @"
            SELECT tk.TaiKhoanID, tk.NhanVienID,
                   tk.TenDangNhap, tk.MatKhauHash,
                   tk.TrangThai, nv.HoTen, vt.TenVaiTro
            FROM TAI_KHOAN tk
            JOIN NHAN_VIEN nv ON tk.NhanVienID = nv.NhanVienID
            JOIN VAI_TRO vt ON tk.RoleID = vt.RoleID";

                DataTable dt = db.DocBang(sql);

                // Lọc theo thông tin đăng nhập
                DataRow[] rows = dt.AsEnumerable()
                    .Where(row =>
                        row["TenDangNhap"].ToString() == username &&
                        Convert.ToInt32(row["NhanVienID"]) == maNV &&
                        row["MatKhauHash"].ToString() == password &&
                        row["TenVaiTro"].ToString() == role
                    ).ToArray();

                if (rows.Length > 0)
                {
                    DataRow account = rows[0];

                    // Lưu thông tin vào Session
                    Session.TaiKhoanID =
                        Convert.ToInt32(account["TaiKhoanID"]);

                    Session.NhanVienID =
                        Convert.ToInt32(account["NhanVienID"]);

                    Session.HoTen = account["HoTen"].ToString()!;

                    Session.Role = role switch
                    {
                        "ADMIN" => "ADMIN",
                        "BEP" => "BEP",
                        "PHUCVU" => "PHUC_VU",
                        "THUNGAN" => "THU_NGAN",
                        _ => role
                    };

                    MessageBox.Show("Đăng nhập thành công!");

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác!");
                }
            }
           

        }
    
}
