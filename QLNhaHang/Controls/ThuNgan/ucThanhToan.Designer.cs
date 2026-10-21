namespace QLNhaHang.Controls.ThuNgan
{
    partial class ucThanhToan
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            cbMaHD = new ComboBox();
            lblMaHD = new Label();
            lblTrangThai = new Label();
            txtTrangThai = new TextBox();
            dgvChiTiet = new DataGridView();
            lblChiTiet = new Label();
            lblTongTien = new Label();
            txtTongTien = new TextBox();
            lblGiamGIa = new Label();
            txtGiamGia = new TextBox();
            lblThanhTien = new Label();
            txtThanhTien = new TextBox();
            lblPhuongThuc = new Label();
            cbPhuongThuc = new ComboBox();
            btnThanhToan = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.BackColor = SystemColors.Control;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(363, 9);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(244, 32);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Thanh toán hóa đơn";
            // 
            // cbMaHD
            // 
            cbMaHD.DisplayMember = "(none)";
            cbMaHD.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaHD.FormattingEnabled = true;
            cbMaHD.Location = new Point(194, 67);
            cbMaHD.Name = "cbMaHD";
            cbMaHD.Size = new Size(121, 23);
            cbMaHD.TabIndex = 1;
            cbMaHD.SelectedIndexChanged += cbMaHD_SelectedIndexChanged;
            // 
            // lblMaHD
            // 
            lblMaHD.AutoSize = true;
            lblMaHD.Location = new Point(114, 70);
            lblMaHD.Name = "lblMaHD";
            lblMaHD.Size = new Size(74, 15);
            lblMaHD.TabIndex = 2;
            lblMaHD.Text = "Mã hóa đơn:";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(612, 70);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(62, 15);
            lblTrangThai.TabIndex = 3;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // txtTrangThai
            // 
            txtTrangThai.Location = new Point(680, 67);
            txtTrangThai.Name = "txtTrangThai";
            txtTrangThai.ReadOnly = true;
            txtTrangThai.Size = new Size(138, 23);
            txtTrangThai.TabIndex = 4;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(3, 138);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.Size = new Size(939, 150);
            dgvChiTiet.TabIndex = 5;
            // 
            // lblChiTiet
            // 
            lblChiTiet.AutoSize = true;
            lblChiTiet.Location = new Point(3, 120);
            lblChiTiet.Name = "lblChiTiet";
            lblChiTiet.Size = new Size(92, 15);
            lblChiTiet.TabIndex = 6;
            lblChiTiet.Text = "Chi tiết món ăn:";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(3, 307);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(60, 15);
            lblTongTien.TabIndex = 7;
            lblTongTien.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            txtTongTien.Location = new Point(69, 304);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.ReadOnly = true;
            txtTongTien.Size = new Size(100, 23);
            txtTongTien.TabIndex = 8;
            // 
            // lblGiamGIa
            // 
            lblGiamGIa.AutoSize = true;
            lblGiamGIa.Location = new Point(230, 307);
            lblGiamGIa.Name = "lblGiamGIa";
            lblGiamGIa.Size = new Size(57, 15);
            lblGiamGIa.TabIndex = 9;
            lblGiamGIa.Text = "Giảm giá:";
            // 
            // txtGiamGia
            // 
            txtGiamGia.Location = new Point(293, 304);
            txtGiamGia.Name = "txtGiamGia";
            txtGiamGia.Size = new Size(100, 23);
            txtGiamGia.TabIndex = 10;
            txtGiamGia.TextChanged += txtGiamGia_TextChanged;
            // 
            // lblThanhTien
            // 
            lblThanhTien.AutoSize = true;
            lblThanhTien.Location = new Point(480, 307);
            lblThanhTien.Name = "lblThanhTien";
            lblThanhTien.Size = new Size(66, 15);
            lblThanhTien.TabIndex = 11;
            lblThanhTien.Text = "Thành tiền:";
            // 
            // txtThanhTien
            // 
            txtThanhTien.Location = new Point(552, 304);
            txtThanhTien.Name = "txtThanhTien";
            txtThanhTien.ReadOnly = true;
            txtThanhTien.Size = new Size(100, 23);
            txtThanhTien.TabIndex = 12;
            // 
            // lblPhuongThuc
            // 
            lblPhuongThuc.AutoSize = true;
            lblPhuongThuc.Location = new Point(732, 307);
            lblPhuongThuc.Name = "lblPhuongThuc";
            lblPhuongThuc.Size = new Size(79, 15);
            lblPhuongThuc.TabIndex = 13;
            lblPhuongThuc.Text = "Phương thức:";
            // 
            // cbPhuongThuc
            // 
            cbPhuongThuc.FormattingEnabled = true;
            cbPhuongThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ" });
            cbPhuongThuc.Location = new Point(817, 304);
            cbPhuongThuc.Name = "cbPhuongThuc";
            cbPhuongThuc.Size = new Size(121, 23);
            cbPhuongThuc.TabIndex = 14;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(386, 374);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(128, 44);
            btnThanhToan.TabIndex = 15;
            btnThanhToan.Text = "Thanh toán hóa đơn";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // ucThanhToan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnThanhToan);
            Controls.Add(cbPhuongThuc);
            Controls.Add(lblPhuongThuc);
            Controls.Add(txtThanhTien);
            Controls.Add(lblThanhTien);
            Controls.Add(txtGiamGia);
            Controls.Add(lblGiamGIa);
            Controls.Add(txtTongTien);
            Controls.Add(lblTongTien);
            Controls.Add(lblChiTiet);
            Controls.Add(dgvChiTiet);
            Controls.Add(txtTrangThai);
            Controls.Add(lblTrangThai);
            Controls.Add(lblMaHD);
            Controls.Add(cbMaHD);
            Controls.Add(lblTieuDe);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucThanhToan";
            Size = new Size(945, 472);
            Load += ucHoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private ComboBox cbMaHD;
        private Label lblMaHD;
        private Label lblTrangThai;
        private TextBox txtTrangThai;
        private DataGridView dgvChiTiet;
        private Label lblChiTiet;
        private Label lblTongTien;
        private TextBox txtTongTien;
        private Label lblGiamGIa;
        private TextBox txtGiamGia;
        private Label lblThanhTien;
        private TextBox txtThanhTien;
        private Label lblPhuongThuc;
        private ComboBox cbPhuongThuc;
        private Button btnThanhToan;
    }
}
