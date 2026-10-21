namespace QLNhaHang.Controls.PhucVu
{
    partial class ucTaoDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlDanhSach = new System.Windows.Forms.Panel();
            this.pnlTopDS = new System.Windows.Forms.Panel();
            this.lblTieuDeDS = new System.Windows.Forms.Label();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.btnLamMoiDS = new System.Windows.Forms.Button();
            this.dgvDon = new System.Windows.Forms.DataGridView();
            this.pnlChiTiet = new System.Windows.Forms.Panel();
            this.pnlHeaderCT = new System.Windows.Forms.Panel();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.lblThongTinDon = new System.Windows.Forms.Label();
            this.lblTrangThaiDon = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlLocMon = new System.Windows.Forms.Panel();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.dgvMon = new System.Windows.Forms.DataGridView();
            this.pnlThem = new System.Windows.Forms.Panel();
            this.lblSL = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblGC = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblGoiY = new System.Windows.Forms.Label();
            this.pnlGio = new System.Windows.Forms.Panel();
            this.pnlGioTop = new System.Windows.Forms.Panel();
            this.lblGio = new System.Windows.Forms.Label();
            this.dgvCT = new System.Windows.Forms.DataGridView();
            this.pnlGioBottom = new System.Windows.Forms.Panel();
            this.lblTong = new System.Windows.Forms.Label();
            this.lblQuyTac = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHuyDon = new System.Windows.Forms.Button();
            this.btnGuiBep = new System.Windows.Forms.Button();

            this.pnlDanhSach.SuspendLayout();
            this.pnlTopDS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDon)).BeginInit();
            this.pnlChiTiet.SuspendLayout();
            this.pnlHeaderCT.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlLocMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMon)).BeginInit();
            this.pnlThem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.pnlGio.SuspendLayout();
            this.pnlGioTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).BeginInit();
            this.pnlGioBottom.SuspendLayout();
            this.SuspendLayout();

            // ================= MÀN DANH SÁCH ĐƠN =================
            this.pnlDanhSach.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDanhSach.Controls.Add(this.dgvDon);
            this.pnlDanhSach.Controls.Add(this.pnlTopDS);
            this.pnlDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDanhSach.Name = "pnlDanhSach";
            this.pnlDanhSach.TabIndex = 1;

            this.pnlTopDS.BackColor = System.Drawing.Color.White;
            this.pnlTopDS.Controls.Add(this.lblTieuDeDS);
            this.pnlTopDS.Controls.Add(this.lblHuongDan);
            this.pnlTopDS.Controls.Add(this.btnLamMoiDS);
            this.pnlTopDS.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopDS.Name = "pnlTopDS";
            this.pnlTopDS.Size = new System.Drawing.Size(1080, 80);

            this.lblTieuDeDS.AutoSize = true;
            this.lblTieuDeDS.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeDS.ForeColor = System.Drawing.Color.FromArgb(24, 38, 66);
            this.lblTieuDeDS.Location = new System.Drawing.Point(20, 10);
            this.lblTieuDeDS.Name = "lblTieuDeDS";
            this.lblTieuDeDS.Text = "Đơn đang xử lý";

            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.ForeColor = System.Drawing.Color.DimGray;
            this.lblHuongDan.Location = new System.Drawing.Point(22, 48);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Text = "";

            this.btnLamMoiDS.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnLamMoiDS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiDS.Location = new System.Drawing.Point(960, 22);
            this.btnLamMoiDS.Name = "btnLamMoiDS";
            this.btnLamMoiDS.Size = new System.Drawing.Size(95, 36);
            this.btnLamMoiDS.Text = "Làm mới";
            this.btnLamMoiDS.UseVisualStyleBackColor = true;
            this.btnLamMoiDS.Click += new System.EventHandler(this.btnLamMoiDS_Click);

            this.dgvDon.AllowUserToAddRows = false;
            this.dgvDon.AllowUserToDeleteRows = false;
            this.dgvDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDon.MultiSelect = false;
            this.dgvDon.Name = "dgvDon";
            this.dgvDon.ReadOnly = true;
            this.dgvDon.RowHeadersVisible = false;
            this.dgvDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDon.TabIndex = 1;
            this.dgvDon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDon_CellDoubleClick);

            // ================= MÀN CHI TIẾT ĐƠN =================
            this.pnlChiTiet.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlChiTiet.Controls.Add(this.pnlGio);
            this.pnlChiTiet.Controls.Add(this.pnlMenu);
            this.pnlChiTiet.Controls.Add(this.pnlHeaderCT);
            this.pnlChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChiTiet.Name = "pnlChiTiet";
            this.pnlChiTiet.TabIndex = 0;
            this.pnlChiTiet.Visible = false;

            // --- header ---
            this.pnlHeaderCT.BackColor = System.Drawing.Color.White;
            this.pnlHeaderCT.Controls.Add(this.btnQuayLai);
            this.pnlHeaderCT.Controls.Add(this.lblThongTinDon);
            this.pnlHeaderCT.Controls.Add(this.lblTrangThaiDon);
            this.pnlHeaderCT.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderCT.Name = "pnlHeaderCT";
            this.pnlHeaderCT.Size = new System.Drawing.Size(1080, 70);

            this.btnQuayLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuayLai.Location = new System.Drawing.Point(20, 17);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(110, 36);
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);

            this.lblThongTinDon.AutoSize = true;
            this.lblThongTinDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblThongTinDon.ForeColor = System.Drawing.Color.FromArgb(24, 38, 66);
            this.lblThongTinDon.Location = new System.Drawing.Point(150, 12);
            this.lblThongTinDon.Name = "lblThongTinDon";
            this.lblThongTinDon.Text = "Bàn  ·  Đơn #";

            this.lblTrangThaiDon.AutoSize = true;
            this.lblTrangThaiDon.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTrangThaiDon.Location = new System.Drawing.Point(152, 42);
            this.lblTrangThaiDon.Name = "lblTrangThaiDon";
            this.lblTrangThaiDon.Text = "";

            // --- cột trái: thực đơn ---
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.dgvMon);
            this.pnlMenu.Controls.Add(this.pnlThem);
            this.pnlMenu.Controls.Add(this.pnlLocMon);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(500, 560);

            this.pnlLocMon.Controls.Add(this.cboDanhMuc);
            this.pnlLocMon.Controls.Add(this.txtTim);
            this.pnlLocMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLocMon.Name = "pnlLocMon";
            this.pnlLocMon.Size = new System.Drawing.Size(500, 52);

            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Location = new System.Drawing.Point(12, 13);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(160, 23);
            this.cboDanhMuc.TabIndex = 0;
            this.cboDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged);

            this.txtTim.Location = new System.Drawing.Point(182, 13);
            this.txtTim.Name = "txtTim";
            this.txtTim.PlaceholderText = "Tìm món...";
            this.txtTim.Size = new System.Drawing.Size(300, 23);
            this.txtTim.TabIndex = 1;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);

            this.dgvMon.AllowUserToAddRows = false;
            this.dgvMon.AllowUserToDeleteRows = false;
            this.dgvMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMon.BackgroundColor = System.Drawing.Color.White;
            this.dgvMon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMon.MultiSelect = false;
            this.dgvMon.Name = "dgvMon";
            this.dgvMon.ReadOnly = true;
            this.dgvMon.RowHeadersVisible = false;
            this.dgvMon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMon.TabIndex = 2;
            this.dgvMon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMon_CellDoubleClick);

            this.pnlThem.Controls.Add(this.lblSL);
            this.pnlThem.Controls.Add(this.nudSoLuong);
            this.pnlThem.Controls.Add(this.lblGC);
            this.pnlThem.Controls.Add(this.txtGhiChu);
            this.pnlThem.Controls.Add(this.btnThem);
            this.pnlThem.Controls.Add(this.lblGoiY);
            this.pnlThem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThem.Name = "pnlThem";
            this.pnlThem.Size = new System.Drawing.Size(500, 110);

            this.lblSL.AutoSize = true;
            this.lblSL.Location = new System.Drawing.Point(12, 12);
            this.lblSL.Name = "lblSL";
            this.lblSL.Text = "Số lượng";

            this.nudSoLuong.Location = new System.Drawing.Point(12, 34);
            this.nudSoLuong.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(70, 23);
            this.nudSoLuong.TabIndex = 0;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });

            this.lblGC.AutoSize = true;
            this.lblGC.Location = new System.Drawing.Point(95, 12);
            this.lblGC.Name = "lblGC";
            this.lblGC.Text = "Ghi chú món";

            this.txtGhiChu.Location = new System.Drawing.Point(95, 34);
            this.txtGhiChu.MaxLength = 255;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(270, 23);
            this.txtGhiChu.TabIndex = 1;

            this.btnThem.BackColor = System.Drawing.Color.FromArgb(24, 38, 66);
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(375, 28);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(112, 34);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm vào đơn";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.lblGoiY.AutoSize = true;
            this.lblGoiY.ForeColor = System.Drawing.Color.DimGray;
            this.lblGoiY.Location = new System.Drawing.Point(12, 78);
            this.lblGoiY.Name = "lblGoiY";
            this.lblGoiY.Text = "Nhấp đúp vào một món để thêm nhanh.";

            // --- cột phải: món trong đơn ---
            this.pnlGio.BackColor = System.Drawing.Color.White;
            this.pnlGio.Controls.Add(this.dgvCT);
            this.pnlGio.Controls.Add(this.pnlGioBottom);
            this.pnlGio.Controls.Add(this.pnlGioTop);
            this.pnlGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGio.Name = "pnlGio";

            this.pnlGioTop.Controls.Add(this.lblGio);
            this.pnlGioTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGioTop.Name = "pnlGioTop";
            this.pnlGioTop.Size = new System.Drawing.Size(580, 40);

            this.lblGio.AutoSize = true;
            this.lblGio.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGio.ForeColor = System.Drawing.Color.FromArgb(24, 38, 66);
            this.lblGio.Location = new System.Drawing.Point(12, 10);
            this.lblGio.Name = "lblGio";
            this.lblGio.Text = "Món trong đơn";

            this.dgvCT.AllowUserToAddRows = false;
            this.dgvCT.AllowUserToDeleteRows = false;
            this.dgvCT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCT.BackgroundColor = System.Drawing.Color.White;
            this.dgvCT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCT.MultiSelect = false;
            this.dgvCT.Name = "dgvCT";
            this.dgvCT.ReadOnly = true;
            this.dgvCT.RowHeadersVisible = false;
            this.dgvCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCT.TabIndex = 0;

            this.pnlGioBottom.Controls.Add(this.lblTong);
            this.pnlGioBottom.Controls.Add(this.lblQuyTac);
            this.pnlGioBottom.Controls.Add(this.btnSua);
            this.pnlGioBottom.Controls.Add(this.btnXoa);
            this.pnlGioBottom.Controls.Add(this.btnHuyDon);
            this.pnlGioBottom.Controls.Add(this.btnGuiBep);
            this.pnlGioBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGioBottom.Name = "pnlGioBottom";
            this.pnlGioBottom.Size = new System.Drawing.Size(580, 120);

            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTong.ForeColor = System.Drawing.Color.FromArgb(24, 38, 66);
            this.lblTong.Location = new System.Drawing.Point(12, 10);
            this.lblTong.Name = "lblTong";
            this.lblTong.Text = "Tổng tiền tạm tính: 0 đ";

            this.lblQuyTac.AutoSize = true;
            this.lblQuyTac.ForeColor = System.Drawing.Color.DimGray;
            this.lblQuyTac.Location = new System.Drawing.Point(12, 42);
            this.lblQuyTac.Name = "lblQuyTac";
            this.lblQuyTac.Text = "Dòng màu vàng là món chưa gửi bếp, được sửa và xóa.";

            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Location = new System.Drawing.Point(12, 72);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(105, 36);
            this.btnSua.Text = "Sửa món";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Location = new System.Drawing.Point(125, 72);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 36);
            this.btnXoa.Text = "Xóa món";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnHuyDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyDon.Location = new System.Drawing.Point(230, 72);
            this.btnHuyDon.Name = "btnHuyDon";
            this.btnHuyDon.Size = new System.Drawing.Size(105, 36);
            this.btnHuyDon.Text = "Hủy đơn";
            this.btnHuyDon.UseVisualStyleBackColor = true;
            this.btnHuyDon.Visible = false;
            this.btnHuyDon.Click += new System.EventHandler(this.btnHuyDon_Click);

            this.btnGuiBep.BackColor = System.Drawing.Color.FromArgb(24, 38, 66);
            this.btnGuiBep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuiBep.FlatAppearance.BorderSize = 0;
            this.btnGuiBep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiBep.ForeColor = System.Drawing.Color.White;
            this.btnGuiBep.Location = new System.Drawing.Point(440, 72);
            this.btnGuiBep.Name = "btnGuiBep";
            this.btnGuiBep.Size = new System.Drawing.Size(125, 36);
            this.btnGuiBep.Text = "Gửi bếp";
            this.btnGuiBep.UseVisualStyleBackColor = false;
            this.btnGuiBep.Click += new System.EventHandler(this.btnGuiBep_Click);

            // ================= ucTaoDon =================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlChiTiet);
            this.Controls.Add(this.pnlDanhSach);
            this.Name = "ucTaoDon";
            this.Size = new System.Drawing.Size(1080, 630);

            this.pnlDanhSach.ResumeLayout(false);
            this.pnlTopDS.ResumeLayout(false);
            this.pnlTopDS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDon)).EndInit();
            this.pnlChiTiet.ResumeLayout(false);
            this.pnlHeaderCT.ResumeLayout(false);
            this.pnlHeaderCT.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlLocMon.ResumeLayout(false);
            this.pnlLocMon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMon)).EndInit();
            this.pnlThem.ResumeLayout(false);
            this.pnlThem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.pnlGio.ResumeLayout(false);
            this.pnlGioTop.ResumeLayout(false);
            this.pnlGioTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).EndInit();
            this.pnlGioBottom.ResumeLayout(false);
            this.pnlGioBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlDanhSach;
        private System.Windows.Forms.Panel pnlTopDS;
        private System.Windows.Forms.Label lblTieuDeDS;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Button btnLamMoiDS;
        private System.Windows.Forms.DataGridView dgvDon;
        private System.Windows.Forms.Panel pnlChiTiet;
        private System.Windows.Forms.Panel pnlHeaderCT;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Label lblThongTinDon;
        private System.Windows.Forms.Label lblTrangThaiDon;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlLocMon;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.DataGridView dgvMon;
        private System.Windows.Forms.Panel pnlThem;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label lblGC;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblGoiY;
        private System.Windows.Forms.Panel pnlGio;
        private System.Windows.Forms.Panel pnlGioTop;
        private System.Windows.Forms.Label lblGio;
        private System.Windows.Forms.DataGridView dgvCT;
        private System.Windows.Forms.Panel pnlGioBottom;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label lblQuyTac;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuyDon;
        private System.Windows.Forms.Button btnGuiBep;
    }
}