namespace QLNhaHang.Forms.DangNhap
{
    partial class DangNhapForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cbRole = new ComboBox();
            btnDangNhap = new Button();
            linkMatKhau = new LinkLabel();
            linkDK = new LinkLabel();
            txtDangNhap = new TextBox();
            txtMaNhanVien = new TextBox();
            txtMatKhau = new TextBox();
            heading = new Label();
            pnlDangNhap = new Panel();
            pnlDangNhap.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(73, 203);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(206, 38);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 286);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(191, 38);
            label2.TabIndex = 1;
            label2.Text = "Mã nhân viên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 369);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(139, 38);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 452);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(234, 38);
            label4.TabIndex = 3;
            label4.Text = "Bộ phận làm việc:";
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Items.AddRange(new object[] { "Quản lý", "Bếp", "Kho ", "Thu ngân" });
            cbRole.Location = new Point(340, 452);
            cbRole.Margin = new Padding(4, 5, 4, 5);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(448, 46);
            cbRole.TabIndex = 7;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new Point(188, 575);
            btnDangNhap.Margin = new Padding(4, 5, 4, 5);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(450, 85);
            btnDangNhap.TabIndex = 8;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // linkMatKhau
            // 
            linkMatKhau.AutoSize = true;
            linkMatKhau.Location = new Point(482, 715);
            linkMatKhau.Margin = new Padding(4, 0, 4, 0);
            linkMatKhau.Name = "linkMatKhau";
            linkMatKhau.Size = new Size(278, 38);
            linkMatKhau.TabIndex = 10;
            linkMatKhau.TabStop = true;
            linkMatKhau.Text = "Bạn quên mật khẩu ?";
            // 
            // linkDK
            // 
            linkDK.AutoSize = true;
            linkDK.Location = new Point(73, 715);
            linkDK.Margin = new Padding(4, 0, 4, 0);
            linkDK.Name = "linkDK";
            linkDK.Size = new Size(241, 38);
            linkDK.TabIndex = 11;
            linkDK.TabStop = true;
            linkDK.Text = "Đăng ký tài khoản";
            // 
            // txtDangNhap
            // 
            txtDangNhap.Location = new Point(340, 203);
            txtDangNhap.Margin = new Padding(4, 5, 4, 5);
            txtDangNhap.Name = "txtDangNhap";
            txtDangNhap.Size = new Size(448, 45);
            txtDangNhap.TabIndex = 13;
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Location = new Point(340, 286);
            txtMaNhanVien.Margin = new Padding(4, 5, 4, 5);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(448, 45);
            txtMaNhanVien.TabIndex = 14;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(340, 369);
            txtMatKhau.Margin = new Padding(4, 5, 4, 5);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(448, 45);
            txtMatKhau.TabIndex = 15;
            // 
            // heading
            // 
            heading.AutoSize = true;
            heading.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            heading.Location = new Point(130, 41);
            heading.Margin = new Padding(4, 0, 4, 0);
            heading.Name = "heading";
            heading.Size = new Size(630, 70);
            heading.TabIndex = 16;
            heading.Text = "ĐĂNG NHẬP HỆ THỐNG";
            heading.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnlDangNhap
            // 
            pnlDangNhap.Controls.Add(linkMatKhau);
            pnlDangNhap.Controls.Add(linkDK);
            pnlDangNhap.Controls.Add(heading);
            pnlDangNhap.Controls.Add(txtMatKhau);
            pnlDangNhap.Controls.Add(btnDangNhap);
            pnlDangNhap.Controls.Add(txtMaNhanVien);
            pnlDangNhap.Controls.Add(txtDangNhap);
            pnlDangNhap.Controls.Add(cbRole);
            pnlDangNhap.Controls.Add(label4);
            pnlDangNhap.Controls.Add(label3);
            pnlDangNhap.Controls.Add(label2);
            pnlDangNhap.Controls.Add(label1);
            pnlDangNhap.Location = new Point(229, 90);
            pnlDangNhap.Name = "pnlDangNhap";
            pnlDangNhap.Size = new Size(852, 848);
            pnlDangNhap.TabIndex = 17;
            // 
            // DangNhapForm
            // 
            AutoScaleDimensions = new SizeF(15F, 38F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1303, 968);
            Controls.Add(pnlDangNhap);
            Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 8, 6, 8);
            MaximizeBox = false;
            Name = "DangNhapForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập ";
            pnlDangNhap.ResumeLayout(false);
            pnlDangNhap.PerformLayout();
            ResumeLayout(false);
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbRole;
        private Button btnDangNhap;
        private LinkLabel linkMatKhau;
        private LinkLabel linkDK;
        private TextBox txtDangNhap;
        private TextBox txtMaNhanVien;
        private TextBox txtMatKhau;
        private Label heading;
        private Panel pnlDangNhap;
    }
}