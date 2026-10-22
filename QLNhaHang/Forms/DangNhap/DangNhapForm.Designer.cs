
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLNhaHang.Forms.DangNhap
{
    partial class DangNhapForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlDangNhap = new Panel();
            pnlThanhTrangTri = new Panel();

            heading = new Label();
            lblMoTa = new Label();

            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();

            txtDangNhap = new TextBox();
            txtMaNhanVien = new TextBox();
            txtMatKhau = new TextBox();

            cbRole = new ComboBox();
            btnDangNhap = new Button();

            linkDK = new LinkLabel();
            linkMatKhau = new LinkLabel();

            pnlDangNhap.SuspendLayout();
            SuspendLayout();

            // =====================================
            // FORM ĐĂNG NHẬP
            // =====================================
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1100, 790);
            BackColor = Color.FromArgb(241, 245, 249);
            Font = new Font("Segoe UI", 11F);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            Name = "DangNhapForm";
            Text = "Đăng nhập - Quản lý nhà hàng";

            // =====================================
            // PANEL CHÍNH
            // =====================================
            pnlDangNhap.Location = new Point(130, 40);
            pnlDangNhap.Size = new Size(840, 700);
            pnlDangNhap.BackColor = Color.White;
            pnlDangNhap.BorderStyle = BorderStyle.FixedSingle;
            pnlDangNhap.Name = "pnlDangNhap";

            // Thanh trang trí phía trên
            pnlThanhTrangTri.Location = new Point(0, 0);
            pnlThanhTrangTri.Size = new Size(840, 7);
            pnlThanhTrangTri.BackColor =
                Color.FromArgb(23, 38, 62);
            pnlThanhTrangTri.Name = "pnlThanhTrangTri";

            // =====================================
            // TIÊU ĐỀ
            // =====================================
            heading.AutoSize = false;
            heading.Location = new Point(40, 35);
            heading.Size = new Size(760, 50);
            heading.Text = "ĐĂNG NHẬP HỆ THỐNG";
            heading.Font = new Font(
                "Segoe UI", 23F, FontStyle.Bold);
            heading.ForeColor =
                Color.FromArgb(23, 38, 62);
            heading.TextAlign =
                ContentAlignment.MiddleCenter;
            heading.Name = "heading";

            // Mô tả
            lblMoTa.AutoSize = false;
            lblMoTa.Location = new Point(40, 88);
            lblMoTa.Size = new Size(760, 30);
            lblMoTa.Text =
                "Đăng nhập để truy cập hệ thống quản lý nhà hàng";
            lblMoTa.Font = new Font("Segoe UI", 10.5F);
            lblMoTa.ForeColor = Color.Gray;
            lblMoTa.TextAlign =
                ContentAlignment.MiddleCenter;
            lblMoTa.Name = "lblMoTa";

            // =====================================
            // TÊN ĐĂNG NHẬP
            // =====================================
            label1.AutoSize = true;
            label1.Location = new Point(50, 145);
            label1.Text = "Tên đăng nhập";
            label1.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor =
                Color.FromArgb(23, 38, 62);
            label1.Name = "label1";

            txtDangNhap.Location = new Point(50, 178);
            txtDangNhap.Size = new Size(345, 37);
            txtDangNhap.Font =
                new Font("Segoe UI", 12F);
            txtDangNhap.BackColor =
                Color.FromArgb(248, 250, 252);
            txtDangNhap.ForeColor =
                Color.FromArgb(16, 18, 15);
            txtDangNhap.BorderStyle =
                BorderStyle.FixedSingle;
            txtDangNhap.Name = "txtDangNhap";
            txtDangNhap.TabIndex = 0;

            // =====================================
            // MÃ NHÂN VIÊN
            // =====================================
            label2.AutoSize = true;
            label2.Location = new Point(445, 145);
            label2.Text = "Mã nhân viên";
            label2.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor =
                Color.FromArgb(23, 38, 62);
            label2.Name = "label2";

            txtMaNhanVien.Location =
                new Point(445, 178);
            txtMaNhanVien.Size = new Size(345, 37);
            txtMaNhanVien.Font =
                new Font("Segoe UI", 12F);
            txtMaNhanVien.BackColor =
                Color.FromArgb(248, 250, 252);
            txtMaNhanVien.BorderStyle =
                BorderStyle.FixedSingle;
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.TabIndex = 1;

            // =====================================
            // MẬT KHẨU
            // =====================================
            label3.AutoSize = true;
            label3.Location = new Point(50, 242);
            label3.Text = "Mật khẩu";
            label3.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor =
                Color.FromArgb(23, 38, 62);
            label3.Name = "label3";

            txtMatKhau.Location = new Point(50, 275);
            txtMatKhau.Size = new Size(740, 37);
            txtMatKhau.Font =
                new Font("Segoe UI", 12F);
            txtMatKhau.BackColor =
                Color.FromArgb(248, 250, 252);
            txtMatKhau.BorderStyle =
                BorderStyle.FixedSingle;
            txtMatKhau.UseSystemPasswordChar = true;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.TabIndex = 2;

            // =====================================
            // BỘ PHẬN LÀM VIỆC
            // =====================================
            label4.AutoSize = true;
            label4.Location = new Point(50, 337);
            label4.Text = "Bộ phận làm việc";
            label4.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            label4.ForeColor =
                Color.FromArgb(23, 38, 62);
            label4.Name = "label4";

            cbRole.Location = new Point(50, 370);
            cbRole.Size = new Size(740, 40);
            cbRole.Font = new Font("Segoe UI", 12F);
            cbRole.BackColor = Color.White;
            cbRole.ForeColor =
                Color.FromArgb(16, 18, 15);
            cbRole.FlatStyle = FlatStyle.Standard;
            cbRole.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cbRole.FormattingEnabled = true;
            cbRole.Name = "cbRole";
            cbRole.TabIndex = 3;

            // Danh sách bộ phận được nạp trong
            // phương thức LoadBoPhan() của DangNhapForm.cs

            // =====================================
            // NÚT ĐĂNG NHẬP
            // =====================================
            btnDangNhap.Location =
                new Point(235, 480);
            btnDangNhap.Size = new Size(370, 56);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Text = "ĐĂNG NHẬP";
            btnDangNhap.Font = new Font(
                "Segoe UI", 12F, FontStyle.Bold);

            btnDangNhap.BackColor =
                Color.FromArgb(23, 38, 62);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.Cursor = Cursors.Hand;
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.TabIndex = 4;

            // Giữ nguyên sự kiện đăng nhập
            btnDangNhap.Click += btnDangNhap_Click;

            // =====================================
            // LINK ĐĂNG KÝ
            // =====================================
            linkDK.AutoSize = true;
            linkDK.Location = new Point(125, 585);
            linkDK.Text = "Đăng ký tài khoản";
            linkDK.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            linkDK.LinkColor =
                Color.FromArgb(60, 115, 201);
            linkDK.ActiveLinkColor =
                Color.FromArgb(23, 38, 62);
            linkDK.LinkBehavior =
                LinkBehavior.HoverUnderline;
            linkDK.Cursor = Cursors.Hand;
            linkDK.Name = "linkDK";
            linkDK.TabIndex = 5;

            // Sự kiện linkDK.LinkClicked đã được
            // đăng ký trong DangNhapForm.cs

            // =====================================
            // LINK QUÊN MẬT KHẨU
            // =====================================
            linkMatKhau.AutoSize = true;
            linkMatKhau.Location =
                new Point(520, 585);
            linkMatKhau.Text = "Bạn quên mật khẩu?";
            linkMatKhau.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            linkMatKhau.LinkColor =
                Color.FromArgb(60, 115, 201);
            linkMatKhau.ActiveLinkColor =
                Color.FromArgb(23, 38, 62);
            linkMatKhau.LinkBehavior =
                LinkBehavior.HoverUnderline;
            linkMatKhau.Cursor = Cursors.Hand;
            linkMatKhau.Name = "linkMatKhau";
            linkMatKhau.TabIndex = 6;

            // =====================================
            // THÊM CONTROL VÀO PANEL
            // =====================================
            pnlDangNhap.Controls.Add(
                pnlThanhTrangTri);

            pnlDangNhap.Controls.Add(heading);
            pnlDangNhap.Controls.Add(lblMoTa);

            pnlDangNhap.Controls.Add(label1);
            pnlDangNhap.Controls.Add(txtDangNhap);

            pnlDangNhap.Controls.Add(label2);
            pnlDangNhap.Controls.Add(txtMaNhanVien);

            pnlDangNhap.Controls.Add(label3);
            pnlDangNhap.Controls.Add(txtMatKhau);

            pnlDangNhap.Controls.Add(label4);
            pnlDangNhap.Controls.Add(cbRole);

            pnlDangNhap.Controls.Add(btnDangNhap);
            pnlDangNhap.Controls.Add(linkDK);
            pnlDangNhap.Controls.Add(linkMatKhau);

            Controls.Add(pnlDangNhap);

            AcceptButton = btnDangNhap;

            pnlDangNhap.ResumeLayout(false);
            pnlDangNhap.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlDangNhap;
        private Panel pnlThanhTrangTri;

        private Label heading;
        private Label lblMoTa;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;

        private TextBox txtDangNhap;
        private TextBox txtMaNhanVien;
        private TextBox txtMatKhau;

        private ComboBox cbRole;
        private Button btnDangNhap;

        private LinkLabel linkDK;
        private LinkLabel linkMatKhau;
    }
}
