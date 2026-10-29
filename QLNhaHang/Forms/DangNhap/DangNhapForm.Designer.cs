using QLNhaHang.Classes;

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
            label3 = new Label();
            label4 = new Label();

            txtDangNhap = new TextBox();
            txtMatKhau = new TextBox();

            cbRole = new ComboBox();
            btnDangNhap = new Button();

            linkDK = new LinkLabel();

            pnlDangNhap.SuspendLayout();
            SuspendLayout();

            // =====================================
            // FORM ĐĂNG NHẬP
            // =====================================
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1100, 790);
            BackColor = Theme.Background;
            Font = new Font("Segoe UI", 11F);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            BackColor = QLNhaHang.Classes.Theme.Background;
            ForeColor = QLNhaHang.Classes.Theme.Black;
            Name = "DangNhapForm";
            Text = "Đăng nhập - Quản lý nhà hàng";

            // =====================================
            // PANEL CHÍNH
            // =====================================
            pnlDangNhap.Location = new Point(130, 40);
            pnlDangNhap.Size = new Size(840, 700);
            pnlDangNhap.BackColor = Theme.Surface;
            pnlDangNhap.BorderStyle = BorderStyle.FixedSingle;
            pnlDangNhap.Name = "pnlDangNhap";

            // Thanh trang trí phía trên
            pnlThanhTrangTri.Location = new Point(0, 0);
            pnlThanhTrangTri.Size = new Size(840, 7);
            pnlThanhTrangTri.BackColor =
                Theme.BlueBold;
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
                Theme.BlueBold;
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
            lblMoTa.ForeColor = Theme.TextMuted;
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
                Theme.BlueBold;
            label1.Name = "label1";

            txtDangNhap.Location = new Point(50, 178);
            txtDangNhap.Size = new Size(740, 37);
            txtDangNhap.Font =
                new Font("Segoe UI", 12F);
            txtDangNhap.BackColor =
                Theme.SurfaceMuted;
            txtDangNhap.ForeColor =
                Theme.Black;
            txtDangNhap.BorderStyle =
                BorderStyle.FixedSingle;
            txtDangNhap.Name = "txtDangNhap";
            txtDangNhap.TabIndex = 0;
            txtDangNhap.MaxLength = 50;

            // =====================================
            // MẬT KHẨU
            // =====================================
            label3.AutoSize = true;
            label3.Location = new Point(50, 242);
            label3.Text = "Mật khẩu";
            label3.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor =
                Theme.BlueBold;
            label3.Name = "label3";

            txtMatKhau.Location = new Point(50, 275);
            txtMatKhau.Size = new Size(740, 37);
            txtMatKhau.Font =
                new Font("Segoe UI", 12F);
            txtMatKhau.BackColor =
                Theme.SurfaceMuted;
            txtMatKhau.BorderStyle =
                BorderStyle.FixedSingle;
            txtMatKhau.UseSystemPasswordChar = true;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.TabIndex = 1;

            // =====================================
            // BỘ PHẬN LÀM VIỆC
            // =====================================
            label4.AutoSize = true;
            label4.Location = new Point(50, 337);
            label4.Text = "Bộ phận làm việc";
            label4.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            label4.ForeColor =
                Theme.BlueBold;
            label4.Name = "label4";

            cbRole.Location = new Point(50, 370);
            cbRole.Size = new Size(740, 40);
            cbRole.Font = new Font("Segoe UI", 12F);
            cbRole.BackColor = Theme.Surface;
            cbRole.ForeColor =
                Theme.Black;
            cbRole.FlatStyle = FlatStyle.Standard;
            cbRole.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cbRole.FormattingEnabled = true;
            cbRole.Name = "cbRole";
            cbRole.TabIndex = 2;

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
                Theme.BlueBold;
            btnDangNhap.ForeColor = Theme.Surface;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.Cursor = Cursors.Hand;
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.TabIndex = 3;

            // Giữ nguyên sự kiện đăng nhập
            btnDangNhap.Click += btnDangNhap_Click;

            // =====================================
            // LINK ĐĂNG KÝ
            // =====================================
            linkDK.AutoSize = false;
            linkDK.Location = new Point(50, 585);
            linkDK.Size = new Size(740, 40);
            linkDK.TextAlign = ContentAlignment.MiddleCenter;
            linkDK.Text = "Đăng ký tài khoản";
            linkDK.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            linkDK.LinkColor =
                Theme.Blue;
            linkDK.ActiveLinkColor =
                Theme.BlueBold;
            linkDK.LinkBehavior =
                LinkBehavior.HoverUnderline;
            linkDK.Cursor = Cursors.Hand;
            linkDK.Name = "linkDK";
            linkDK.TabIndex = 4;

            // Sự kiện linkDK.LinkClicked đã được
            // đăng ký trong DangNhapForm.cs

            // =====================================
            // THÊM CONTROL VÀO PANEL
            // =====================================
            pnlDangNhap.Controls.Add(
                pnlThanhTrangTri);

            pnlDangNhap.Controls.Add(heading);
            pnlDangNhap.Controls.Add(lblMoTa);

            pnlDangNhap.Controls.Add(label1);
            pnlDangNhap.Controls.Add(txtDangNhap);


            pnlDangNhap.Controls.Add(label3);
            pnlDangNhap.Controls.Add(txtMatKhau);

            pnlDangNhap.Controls.Add(label4);
            pnlDangNhap.Controls.Add(cbRole);

            pnlDangNhap.Controls.Add(btnDangNhap);
            pnlDangNhap.Controls.Add(linkDK);

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
        private Label label3;
        private Label label4;

        private TextBox txtDangNhap;
        private TextBox txtMatKhau;

        private ComboBox cbRole;
        private Button btnDangNhap;

        private LinkLabel linkDK;
    }
}
