using QLNhaHang.Classes;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLNhaHang.Forms.DangKy
{
    partial class frmDangKy
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
            pnlDangKy = new Panel();
            pnlThanhTrangTri = new Panel();
            label1 = new Label();
            lblMoTa = new Label();
            label2 = new Label();
            txtHoTen = new TextBox();
            label3 = new Label();
            txtSDT = new TextBox();
            label4 = new Label();
            txtTenDangNhap = new TextBox();
            label5 = new Label();
            txtMatKhau = new TextBox();
            label6 = new Label();
            txtXacNhanMatKhau = new TextBox();
            lblThongBao = new Label();
            btnDangKy = new Button();
            label7 = new Label();
            linkDangNhap = new LinkLabel();
            pnlDangKy.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDangKy
            // 
            pnlDangKy.BackColor = Theme.Surface;
            pnlDangKy.BorderStyle = BorderStyle.FixedSingle;
            pnlDangKy.Controls.Add(pnlThanhTrangTri);
            pnlDangKy.Controls.Add(label1);
            pnlDangKy.Controls.Add(lblMoTa);
            pnlDangKy.Controls.Add(label2);
            pnlDangKy.Controls.Add(txtHoTen);
            pnlDangKy.Controls.Add(label3);
            pnlDangKy.Controls.Add(txtSDT);
            pnlDangKy.Controls.Add(label4);
            pnlDangKy.Controls.Add(txtTenDangNhap);
            pnlDangKy.Controls.Add(label5);
            pnlDangKy.Controls.Add(txtMatKhau);
            pnlDangKy.Controls.Add(label6);
            pnlDangKy.Controls.Add(txtXacNhanMatKhau);
            pnlDangKy.Controls.Add(lblThongBao);
            pnlDangKy.Controls.Add(btnDangKy);
            pnlDangKy.Controls.Add(label7);
            pnlDangKy.Controls.Add(linkDangNhap);
            pnlDangKy.Location = new Point(130, 12);
            pnlDangKy.Name = "pnlDangKy";
            pnlDangKy.Size = new Size(840, 710);
            pnlDangKy.TabIndex = 0;
            // 
            // pnlThanhTrangTri
            // 
            pnlThanhTrangTri.BackColor = Theme.BlueBold;
            pnlThanhTrangTri.Location = new Point(0, 0);
            pnlThanhTrangTri.Name = "pnlThanhTrangTri";
            pnlThanhTrangTri.Size = new Size(840, 7);
            pnlThanhTrangTri.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            label1.ForeColor = Theme.BlueBold;
            label1.Location = new Point(40, 35);
            label1.Name = "label1";
            label1.Size = new Size(760, 50);
            label1.TabIndex = 1;
            label1.Text = "ĐĂNG KÝ TÀI KHOẢN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMoTa
            // 
            lblMoTa.Font = new Font("Segoe UI", 10.5F);
            lblMoTa.ForeColor = Theme.TextMuted;
            lblMoTa.Location = new Point(40, 88);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(760, 30);
            lblMoTa.TabIndex = 2;
            lblMoTa.Text = "Đăng ký dành cho nhân viên mới";
            lblMoTa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = Theme.BlueBold;
            label2.Location = new Point(50, 145);
            label2.Name = "label2";
            label2.Size = new Size(113, 30);
            label2.TabIndex = 3;
            label2.Text = "Họ và tên";
            // 
            // txtHoTen
            // 
            txtHoTen.BackColor = Theme.SurfaceMuted;
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.Font = new Font("Segoe UI", 12F);
            txtHoTen.ForeColor = Theme.Black;
            txtHoTen.Location = new Point(50, 178);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(345, 39);
            txtHoTen.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = Theme.BlueBold;
            label3.Location = new Point(445, 145);
            label3.Name = "label3";
            label3.Size = new Size(148, 30);
            label3.TabIndex = 4;
            label3.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            txtSDT.BackColor = Theme.SurfaceMuted;
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Font = new Font("Segoe UI", 12F);
            txtSDT.Location = new Point(445, 178);
            txtSDT.MaxLength = 10;
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(345, 39);
            txtSDT.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.ForeColor = Theme.BlueBold;
            label4.Location = new Point(50, 242);
            label4.Name = "label4";
            label4.Size = new Size(166, 30);
            label4.TabIndex = 5;
            label4.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BackColor = Theme.SurfaceMuted;
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
            txtTenDangNhap.Font = new Font("Segoe UI", 12F);
            txtTenDangNhap.Location = new Point(50, 275);
            txtTenDangNhap.MaxLength = 50;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(740, 39);
            txtTenDangNhap.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = Theme.BlueBold;
            label5.Location = new Point(50, 342);
            label5.Name = "label5";
            label5.Size = new Size(111, 30);
            label5.TabIndex = 6;
            label5.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            txtMatKhau.BackColor = Theme.SurfaceMuted;
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Font = new Font("Segoe UI", 12F);
            txtMatKhau.Location = new Point(50, 375);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(740, 39);
            txtMatKhau.TabIndex = 3;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.ForeColor = Theme.BlueBold;
            label6.Location = new Point(50, 435);
            label6.Name = "label6";
            label6.Size = new Size(210, 30);
            label6.TabIndex = 7;
            label6.Text = "Xác nhận mật khẩu";
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.BackColor = Theme.SurfaceMuted;
            txtXacNhanMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtXacNhanMatKhau.Font = new Font("Segoe UI", 12F);
            txtXacNhanMatKhau.Location = new Point(50, 468);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.Size = new Size(740, 39);
            txtXacNhanMatKhau.TabIndex = 4;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;
            // 
            // lblThongBao
            // 
            lblThongBao.Font = new Font("Segoe UI", 10F);
            lblThongBao.ForeColor = Theme.TextMuted;
            lblThongBao.Location = new Point(50, 530);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(740, 32);
            lblThongBao.TabIndex = 8;
            lblThongBao.Text = "Đã có hồ sơ nhân viên? Liên hệ quản lý để được cấp tài khoản.";
            lblThongBao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDangKy
            // 
            btnDangKy.BackColor = Theme.BlueBold;
            btnDangKy.Cursor = Cursors.Hand;
            btnDangKy.FlatAppearance.BorderSize = 0;
            btnDangKy.FlatStyle = FlatStyle.Flat;
            btnDangKy.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDangKy.ForeColor = Theme.Surface;
            btnDangKy.Location = new Point(235, 575);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(370, 52);
            btnDangKy.TabIndex = 5;
            btnDangKy.Text = "ĐĂNG KÝ";
            btnDangKy.UseVisualStyleBackColor = false;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.5F);
            label7.ForeColor = Theme.TextMuted;
            label7.Location = new Point(247, 653);
            label7.Name = "label7";
            label7.Size = new Size(168, 30);
            label7.TabIndex = 9;
            label7.Text = "Đã có tài khoản?";
            // 
            // linkDangNhap
            // 
            linkDangNhap.ActiveLinkColor = Theme.BlueBold;
            linkDangNhap.AutoSize = true;
            linkDangNhap.Cursor = Cursors.Hand;
            linkDangNhap.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            linkDangNhap.LinkBehavior = LinkBehavior.HoverUnderline;
            linkDangNhap.LinkColor = Theme.Blue;
            linkDangNhap.Location = new Point(410, 653);
            linkDangNhap.Name = "linkDangNhap";
            linkDangNhap.Size = new Size(205, 30);
            linkDangNhap.TabIndex = 6;
            linkDangNhap.TabStop = true;
            linkDangNhap.Text = "Quay lại đăng nhập";
            linkDangNhap.LinkClicked += linkDangNhap_LinkClicked;
            // 
            // frmDangKy
            // 
            AcceptButton = btnDangKy;
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            ClientSize = new Size(1100, 734);
            Controls.Add(pnlDangKy);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = QLNhaHang.Classes.Theme.Background;
            ForeColor = QLNhaHang.Classes.Theme.Black;
            Name = "frmDangKy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký tài khoản - Quản lý nhà hàng";
            pnlDangKy.ResumeLayout(false);
            pnlDangKy.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlDangKy;
        private Panel pnlThanhTrangTri;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;

        private Label lblMoTa;
        private Label lblThongBao;

        private TextBox txtHoTen;
        private TextBox txtSDT;
        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private TextBox txtXacNhanMatKhau;

        private Button btnDangKy;
        private LinkLabel linkDangNhap;
    }
}
