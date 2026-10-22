namespace QLNhaHang.Controls.ThuNgan
{
    partial class ucHoaDon
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
            lblTimKiem = new Label();
            lblChiTiet = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnTaiLai = new Button();
            dgvHoaDon = new DataGridView();
            dgvChiTietHD = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXuatExcel = new Button();
            lblDonHang = new Label();
            cbDonHang = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHD).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(356, 10);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(203, 32);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Quản lý hóa đơn";
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(3, 66);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(71, 15);
            lblTimKiem.TabIndex = 1;
            lblTimKiem.Text = "Mã hóa đơn";
            // 
            // lblChiTiet
            // 
            lblChiTiet.AutoSize = true;
            lblChiTiet.Location = new Point(3, 301);
            lblChiTiet.Name = "lblChiTiet";
            lblChiTiet.Size = new Size(89, 15);
            lblChiTiet.TabIndex = 2;
            lblChiTiet.Text = "Chi tiết món ăn";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(80, 63);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(100, 23);
            txtTimKiem.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(207, 63);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(75, 23);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Location = new Point(288, 63);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(75, 23);
            btnTaiLai.TabIndex = 5;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = true;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.BackgroundColor = Color.DarkRed;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(3, 92);
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new Size(939, 150);
            dgvHoaDon.TabIndex = 6;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            // 
            // dgvChiTietHD
            // 
            dgvChiTietHD.AllowUserToAddRows = false;
            dgvChiTietHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietHD.BackgroundColor = Color.Tomato;
            dgvChiTietHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietHD.Location = new Point(3, 319);
            dgvChiTietHD.MultiSelect = false;
            dgvChiTietHD.Name = "dgvChiTietHD";
            dgvChiTietHD.ReadOnly = true;
            dgvChiTietHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietHD.Size = new Size(939, 150);
            dgvChiTietHD.TabIndex = 7;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(266, 248);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 23);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(418, 248);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 23);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Location = new Point(576, 248);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(75, 23);
            btnXuatExcel.TabIndex = 11;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // lblDonHang
            // 
            lblDonHang.AutoSize = true;
            lblDonHang.Location = new Point(407, 66);
            lblDonHang.Name = "lblDonHang";
            lblDonHang.Size = new Size(59, 15);
            lblDonHang.TabIndex = 12;
            lblDonHang.Text = "Đơn hàng";
            // 
            // cbDonHang
            // 
            cbDonHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDonHang.FormattingEnabled = true;
            cbDonHang.Location = new Point(472, 63);
            cbDonHang.Name = "cbDonHang";
            cbDonHang.Size = new Size(121, 23);
            cbDonHang.TabIndex = 13;
            // 
            // ucHoaDon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cbDonHang);
            Controls.Add(lblDonHang);
            Controls.Add(btnXuatExcel);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgvChiTietHD);
            Controls.Add(dgvHoaDon);
            Controls.Add(btnTaiLai);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(lblChiTiet);
            Controls.Add(lblTimKiem);
            Controls.Add(lblTieuDe);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucHoaDon";
            Size = new Size(945, 472);
            Load += ucHoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblTimKiem;
        private Label lblChiTiet;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Button btnTaiLai;
        private DataGridView dgvHoaDon;
        private DataGridView dgvChiTietHD;
        private Button btnThem;
        private Button btnSua;
        private Button btnXuatExcel;
        private Label lblDonHang;
        private ComboBox cbDonHang;
    }
}
