using QLNhaHang.Classes;
namespace QLNhaHang.Controls.Admin
{
    partial class ucTaiKhoan
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlBoCuc = new TableLayoutPanel();
            pnlTieuDe = new TableLayoutPanel();
            lblTieuDe = new Label();
            btnThem = new Button();
            pnlThongKe = new TableLayoutPanel();
            pnlTongSo = new Panel();
            lblTongSo = new Label();
            lblNhanTongSo = new Label();
            pnlChoDuyet = new Panel();
            lblChoDuyet = new Label();
            lblNhanChoDuyet = new Label();
            pnlHoatDong = new Panel();
            lblHoatDong = new Label();
            lblNhanHoatDong = new Label();
            pnlBiKhoa = new Panel();
            lblBiKhoa = new Label();
            lblNhanBiKhoa = new Label();
            pnlBoLoc = new TableLayoutPanel();
            txtTimKiem = new TextBox();
            cbLocTrangThai = new ComboBox();
            cbLocVaiTro = new ComboBox();
            btnTaiLai = new Button();
            pnlNoiDung = new TableLayoutPanel();
            dgvTaiKhoan = new DataGridView();
            tabChiTiet = new TabControl();
            tabThongTin = new TabPage();
            pnlChiTiet = new FlowLayoutPanel();
            lblNhanChiTiet = new Label();
            lblNguoiDung = new Label();
            lblMaNhanVien = new Label();
            lblTrangThai = new Label();
            lblNhanTen = new Label();
            txtTenDangNhap = new TextBox();
            lblNhanVaiTro = new Label();
            cbVaiTro = new ComboBox();
            pnlDuyet = new FlowLayoutPanel();
            btnDuyet = new Button();
            btnTuChoi = new Button();
            pnlQuanTri = new FlowLayoutPanel();
            btnLuu = new Button();
            btnKhoa = new Button();
            tabMatKhau = new TabPage();
            pnlMatKhau = new FlowLayoutPanel();
            lblNhanMatKhau = new Label();
            txtMatKhauMoi = new TextBox();
            txtXacNhanMatKhau = new TextBox();
            chkHienMatKhau = new CheckBox();
            btnDatLaiMatKhau = new Button();
            lblThongBao = new Label();
            pnlBoCuc.SuspendLayout();
            pnlTieuDe.SuspendLayout();
            pnlThongKe.SuspendLayout();
            pnlTongSo.SuspendLayout();
            pnlChoDuyet.SuspendLayout();
            pnlHoatDong.SuspendLayout();
            pnlBiKhoa.SuspendLayout();
            pnlBoLoc.SuspendLayout();
            pnlNoiDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            tabChiTiet.SuspendLayout();
            tabThongTin.SuspendLayout();
            pnlChiTiet.SuspendLayout();
            pnlDuyet.SuspendLayout();
            pnlQuanTri.SuspendLayout();
            tabMatKhau.SuspendLayout();
            pnlMatKhau.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBoCuc
            // 
            pnlBoCuc.ColumnCount = 1;
            pnlBoCuc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlBoCuc.Controls.Add(pnlTieuDe, 0, 0);
            pnlBoCuc.Controls.Add(pnlThongKe, 0, 1);
            pnlBoCuc.Controls.Add(pnlBoLoc, 0, 2);
            pnlBoCuc.Controls.Add(pnlNoiDung, 0, 3);
            pnlBoCuc.Controls.Add(lblThongBao, 0, 4);
            pnlBoCuc.Dock = DockStyle.Fill;
            pnlBoCuc.Location = new Point(0, 0);
            pnlBoCuc.Name = "pnlBoCuc";
            pnlBoCuc.Padding = new Padding(24, 16, 24, 12);
            pnlBoCuc.RowCount = 5;
            pnlBoCuc.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            pnlBoCuc.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            pnlBoCuc.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            pnlBoCuc.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlBoCuc.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            pnlBoCuc.Size = new Size(1280, 850);
            pnlBoCuc.TabIndex = 0;
            // 
            // pnlTieuDe
            // 
            pnlTieuDe.ColumnCount = 2;
            pnlTieuDe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlTieuDe.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 194F));
            pnlTieuDe.Controls.Add(lblTieuDe, 0, 0);
            pnlTieuDe.Controls.Add(btnThem, 1, 0);
            pnlTieuDe.Dock = DockStyle.Fill;
            pnlTieuDe.Location = new Point(24, 16);
            pnlTieuDe.Margin = new Padding(0);
            pnlTieuDe.Name = "pnlTieuDe";
            pnlTieuDe.RowCount = 2;
            pnlTieuDe.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            pnlTieuDe.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlTieuDe.Size = new Size(1232, 90);
            pnlTieuDe.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTieuDe.Location = new Point(0, 0);
            lblTieuDe.Margin = new Padding(0);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(1038, 50);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Quản lý tài khoản";
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(23, 38, 62);
            btnThem.Cursor = Cursors.Hand;
            btnThem.Dock = DockStyle.Fill;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThem.ForeColor = Color.FromArgb(255, 255, 255);
            btnThem.Location = new Point(1038, 8);
            btnThem.Margin = new Padding(0, 8, 0, 16);
            btnThem.Name = "btnThem";
            pnlTieuDe.SetRowSpan(btnThem, 2);
            btnThem.Size = new Size(194, 66);
            btnThem.TabIndex = 0;
            btnThem.Text = "+  Cấp tài khoản";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // pnlThongKe
            // 
            pnlThongKe.ColumnCount = 4;
            pnlThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlThongKe.Controls.Add(pnlTongSo, 0, 0);
            pnlThongKe.Controls.Add(pnlChoDuyet, 1, 0);
            pnlThongKe.Controls.Add(pnlHoatDong, 2, 0);
            pnlThongKe.Controls.Add(pnlBiKhoa, 3, 0);
            pnlThongKe.Dock = DockStyle.Fill;
            pnlThongKe.Location = new Point(24, 106);
            pnlThongKe.Margin = new Padding(0, 0, 0, 12);
            pnlThongKe.Name = "pnlThongKe";
            pnlThongKe.RowCount = 1;
            pnlThongKe.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlThongKe.Size = new Size(1232, 88);
            pnlThongKe.TabIndex = 1;
            // 
            // pnlTongSo
            // 
            pnlTongSo.AutoSize = true;
            pnlTongSo.BackColor = Color.FromArgb(255, 255, 255);
            pnlTongSo.Controls.Add(lblTongSo);
            pnlTongSo.Controls.Add(lblNhanTongSo);
            pnlTongSo.Dock = DockStyle.Fill;
            pnlTongSo.Location = new Point(0, 0);
            pnlTongSo.Margin = new Padding(0, 0, 12, 0);
            pnlTongSo.Name = "pnlTongSo";
            pnlTongSo.Size = new Size(296, 88);
            pnlTongSo.TabIndex = 0;
            // 
            // lblTongSo
            // 
            lblTongSo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTongSo.ForeColor = Color.FromArgb(23, 38, 62);
            lblTongSo.Location = new Point(16, 0);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Size = new Size(210, 38);
            lblTongSo.TabIndex = 0;
            lblTongSo.Text = "—";
            // 
            // lblNhanTongSo
            // 
            lblNhanTongSo.ForeColor = Color.FromArgb(100, 116, 139);
            lblNhanTongSo.Location = new Point(18, 39);
            lblNhanTongSo.Name = "lblNhanTongSo";
            lblNhanTongSo.Size = new Size(210, 24);
            lblNhanTongSo.TabIndex = 1;
            lblNhanTongSo.Text = "Tổng tài khoản";
            // 
            // pnlChoDuyet
            // 
            pnlChoDuyet.BackColor = Color.FromArgb(255, 255, 255);
            pnlChoDuyet.Controls.Add(lblChoDuyet);
            pnlChoDuyet.Controls.Add(lblNhanChoDuyet);
            pnlChoDuyet.Dock = DockStyle.Fill;
            pnlChoDuyet.Location = new Point(308, 0);
            pnlChoDuyet.Margin = new Padding(0, 0, 12, 0);
            pnlChoDuyet.Name = "pnlChoDuyet";
            pnlChoDuyet.Size = new Size(296, 88);
            pnlChoDuyet.TabIndex = 1;
            // 
            // lblChoDuyet
            // 
            lblChoDuyet.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblChoDuyet.ForeColor = Color.FromArgb(154, 65, 12);
            lblChoDuyet.Location = new Point(16, 0);
            lblChoDuyet.Name = "lblChoDuyet";
            lblChoDuyet.Size = new Size(210, 38);
            lblChoDuyet.TabIndex = 0;
            lblChoDuyet.Text = "—";
            // 
            // lblNhanChoDuyet
            // 
            lblNhanChoDuyet.ForeColor = Color.FromArgb(100, 116, 139);
            lblNhanChoDuyet.Location = new Point(18, 39);
            lblNhanChoDuyet.Name = "lblNhanChoDuyet";
            lblNhanChoDuyet.Size = new Size(210, 24);
            lblNhanChoDuyet.TabIndex = 1;
            lblNhanChoDuyet.Text = "Chờ phê duyệt";
            // 
            // pnlHoatDong
            // 
            pnlHoatDong.BackColor = Color.FromArgb(255, 255, 255);
            pnlHoatDong.Controls.Add(lblHoatDong);
            pnlHoatDong.Controls.Add(lblNhanHoatDong);
            pnlHoatDong.Dock = DockStyle.Fill;
            pnlHoatDong.Location = new Point(616, 0);
            pnlHoatDong.Margin = new Padding(0, 0, 12, 0);
            pnlHoatDong.Name = "pnlHoatDong";
            pnlHoatDong.Size = new Size(296, 88);
            pnlHoatDong.TabIndex = 2;
            // 
            // lblHoatDong
            // 
            lblHoatDong.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHoatDong.ForeColor = Color.FromArgb(21, 128, 61);
            lblHoatDong.Location = new Point(16, 0);
            lblHoatDong.Name = "lblHoatDong";
            lblHoatDong.Size = new Size(210, 38);
            lblHoatDong.TabIndex = 0;
            lblHoatDong.Text = "—";
            // 
            // lblNhanHoatDong
            // 
            lblNhanHoatDong.ForeColor = Color.FromArgb(100, 116, 139);
            lblNhanHoatDong.Location = new Point(18, 39);
            lblNhanHoatDong.Name = "lblNhanHoatDong";
            lblNhanHoatDong.Size = new Size(210, 24);
            lblNhanHoatDong.TabIndex = 1;
            lblNhanHoatDong.Text = "Đang hoạt động";
            // 
            // pnlBiKhoa
            // 
            pnlBiKhoa.BackColor = Color.FromArgb(255, 255, 255);
            pnlBiKhoa.Controls.Add(lblBiKhoa);
            pnlBiKhoa.Controls.Add(lblNhanBiKhoa);
            pnlBiKhoa.Dock = DockStyle.Fill;
            pnlBiKhoa.Location = new Point(924, 0);
            pnlBiKhoa.Margin = new Padding(0, 0, 12, 0);
            pnlBiKhoa.Name = "pnlBiKhoa";
            pnlBiKhoa.Size = new Size(296, 88);
            pnlBiKhoa.TabIndex = 3;
            // 
            // lblBiKhoa
            // 
            lblBiKhoa.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblBiKhoa.ForeColor = Color.FromArgb(185, 48, 48);
            lblBiKhoa.Location = new Point(16, 0);
            lblBiKhoa.Name = "lblBiKhoa";
            lblBiKhoa.Size = new Size(210, 38);
            lblBiKhoa.TabIndex = 0;
            lblBiKhoa.Text = "—";
            // 
            // lblNhanBiKhoa
            // 
            lblNhanBiKhoa.ForeColor = Color.FromArgb(100, 116, 139);
            lblNhanBiKhoa.Location = new Point(18, 39);
            lblNhanBiKhoa.Name = "lblNhanBiKhoa";
            lblNhanBiKhoa.Size = new Size(210, 24);
            lblNhanBiKhoa.TabIndex = 1;
            lblNhanBiKhoa.Text = "Đang bị khóa";
            // 
            // pnlBoLoc
            // 
            pnlBoLoc.ColumnCount = 4;
            pnlBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            pnlBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            pnlBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            pnlBoLoc.Controls.Add(txtTimKiem, 0, 0);
            pnlBoLoc.Controls.Add(cbLocTrangThai, 1, 0);
            pnlBoLoc.Controls.Add(cbLocVaiTro, 2, 0);
            pnlBoLoc.Controls.Add(btnTaiLai, 3, 0);
            pnlBoLoc.Dock = DockStyle.Fill;
            pnlBoLoc.Location = new Point(24, 206);
            pnlBoLoc.Margin = new Padding(0);
            pnlBoLoc.Name = "pnlBoLoc";
            pnlBoLoc.Padding = new Padding(0, 8, 0, 8);
            pnlBoLoc.RowCount = 1;
            pnlBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlBoLoc.Size = new Size(1232, 60);
            pnlBoLoc.TabIndex = 2;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Dock = DockStyle.Fill;
            txtTimKiem.Location = new Point(0, 12);
            txtTimKiem.Margin = new Padding(0, 4, 12, 4);
            txtTimKiem.MaxLength = 100;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm tên đăng nhập, họ tên, SĐT, mã NV…";
            txtTimKiem.Size = new Size(860, 34);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.TextChanged += BoLoc_Changed;
            // 
            // cbLocTrangThai
            // 
            cbLocTrangThai.Dock = DockStyle.Fill;
            cbLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLocTrangThai.Items.AddRange(new object[] { "Tất cả trạng thái", "Chờ duyệt", "Hoạt động", "Bị khóa", "Từ chối" });
            cbLocTrangThai.Location = new Point(872, 12);
            cbLocTrangThai.Margin = new Padding(0, 4, 12, 4);
            cbLocTrangThai.Name = "cbLocTrangThai";
            cbLocTrangThai.Size = new Size(138, 36);
            cbLocTrangThai.TabIndex = 1;
            cbLocTrangThai.SelectedIndexChanged += BoLoc_Changed;
            // 
            // cbLocVaiTro
            // 
            cbLocVaiTro.Dock = DockStyle.Fill;
            cbLocVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLocVaiTro.Items.AddRange(new object[] { "Tất cả vai trò", "Quản lý", "Bếp", "Phục vụ", "Thu ngân" });
            cbLocVaiTro.Location = new Point(1022, 12);
            cbLocVaiTro.Margin = new Padding(0, 4, 12, 4);
            cbLocVaiTro.Name = "cbLocVaiTro";
            cbLocVaiTro.Size = new Size(118, 36);
            cbLocVaiTro.TabIndex = 2;
            cbLocVaiTro.SelectedIndexChanged += BoLoc_Changed;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Dock = DockStyle.Fill;
            btnTaiLai.Location = new Point(1152, 8);
            btnTaiLai.Margin = new Padding(0, 0, 0, 4);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(80, 40);
            btnTaiLai.TabIndex = 3;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.ColumnCount = 2;
            pnlNoiDung.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlNoiDung.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280F));
            pnlNoiDung.Controls.Add(dgvTaiKhoan, 0, 0);
            pnlNoiDung.Controls.Add(tabChiTiet, 1, 0);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Location = new Point(24, 266);
            pnlNoiDung.Margin = new Padding(0);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.RowCount = 1;
            pnlNoiDung.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlNoiDung.Size = new Size(1232, 522);
            pnlNoiDung.TabIndex = 3;
            // 
            // dgvTaiKhoan
            // 
            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dgvTaiKhoan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTaiKhoan.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvTaiKhoan.BorderStyle = BorderStyle.None;
            dgvTaiKhoan.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(232, 240, 254);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(23, 38, 62);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTaiKhoan.ColumnHeadersHeight = 42;
            dgvTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(16, 18, 15);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(23, 38, 62);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTaiKhoan.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTaiKhoan.Dock = DockStyle.Fill;
            dgvTaiKhoan.EnableHeadersVisualStyles = false;
            dgvTaiKhoan.GridColor = Color.FromArgb(226, 232, 240);
            dgvTaiKhoan.Location = new Point(0, 0);
            dgvTaiKhoan.Margin = new Padding(0, 0, 16, 0);
            dgvTaiKhoan.MultiSelect = false;
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.RowHeadersVisible = false;
            dgvTaiKhoan.RowHeadersWidth = 62;
            dgvTaiKhoan.RowTemplate.Height = 40;
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.Size = new Size(936, 522);
            dgvTaiKhoan.TabIndex = 0;
            dgvTaiKhoan.CellFormatting += dgvTaiKhoan_CellFormatting;
            dgvTaiKhoan.SelectionChanged += dgvTaiKhoan_SelectionChanged;
            // 
            // tabChiTiet
            // 
            tabChiTiet.Controls.Add(tabThongTin);
            tabChiTiet.Controls.Add(tabMatKhau);
            tabChiTiet.Dock = DockStyle.Fill;
            tabChiTiet.Location = new Point(952, 0);
            tabChiTiet.Margin = new Padding(0);
            tabChiTiet.Name = "tabChiTiet";
            tabChiTiet.SelectedIndex = 0;
            tabChiTiet.Size = new Size(280, 522);
            tabChiTiet.TabIndex = 1;
            // 
            // tabThongTin
            // 
            tabThongTin.BackColor = Color.FromArgb(255, 255, 255);
            tabThongTin.Controls.Add(pnlChiTiet);
            tabThongTin.Location = new Point(4, 37);
            tabThongTin.Name = "tabThongTin";
            tabThongTin.Size = new Size(272, 481);
            tabThongTin.TabIndex = 0;
            tabThongTin.Text = "Thông tin";
            // 
            // pnlChiTiet
            // 
            pnlChiTiet.AutoScroll = true;
            pnlChiTiet.BackColor = Color.FromArgb(255, 255, 255);
            pnlChiTiet.Controls.Add(lblNhanChiTiet);
            pnlChiTiet.Controls.Add(lblNguoiDung);
            pnlChiTiet.Controls.Add(lblMaNhanVien);
            pnlChiTiet.Controls.Add(lblTrangThai);
            pnlChiTiet.Controls.Add(lblNhanTen);
            pnlChiTiet.Controls.Add(txtTenDangNhap);
            pnlChiTiet.Controls.Add(lblNhanVaiTro);
            pnlChiTiet.Controls.Add(cbVaiTro);
            pnlChiTiet.Controls.Add(pnlDuyet);
            pnlChiTiet.Controls.Add(pnlQuanTri);
            pnlChiTiet.Dock = DockStyle.Fill;
            pnlChiTiet.FlowDirection = FlowDirection.TopDown;
            pnlChiTiet.Location = new Point(0, 0);
            pnlChiTiet.Margin = new Padding(0);
            pnlChiTiet.Name = "pnlChiTiet";
            pnlChiTiet.Padding = new Padding(12);
            pnlChiTiet.Size = new Size(272, 481);
            pnlChiTiet.TabIndex = 1;
            pnlChiTiet.WrapContents = false;
            // 
            // lblNhanChiTiet
            // 
            lblNhanChiTiet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNhanChiTiet.Location = new Point(12, 12);
            lblNhanChiTiet.Margin = new Padding(0, 0, 0, 8);
            lblNhanChiTiet.Name = "lblNhanChiTiet";
            lblNhanChiTiet.Size = new Size(236, 28);
            lblNhanChiTiet.TabIndex = 0;
            lblNhanChiTiet.Text = "CHI TIẾT TÀI KHOẢN";
            lblNhanChiTiet.Visible = false;
            // 
            // lblNguoiDung
            // 
            lblNguoiDung.AutoEllipsis = true;
            lblNguoiDung.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNguoiDung.Location = new Point(12, 48);
            lblNguoiDung.Margin = new Padding(0);
            lblNguoiDung.Name = "lblNguoiDung";
            lblNguoiDung.Size = new Size(236, 24);
            lblNguoiDung.TabIndex = 1;
            lblNguoiDung.Text = "Chưa chọn tài khoản";
            // 
            // lblMaNhanVien
            // 
            lblMaNhanVien.ForeColor = Color.FromArgb(100, 116, 139);
            lblMaNhanVien.Location = new Point(12, 72);
            lblMaNhanVien.Margin = new Padding(0);
            lblMaNhanVien.Name = "lblMaNhanVien";
            lblMaNhanVien.Size = new Size(236, 22);
            lblMaNhanVien.TabIndex = 2;
            // 
            // lblTrangThai
            // 
            lblTrangThai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTrangThai.Location = new Point(12, 94);
            lblTrangThai.Margin = new Padding(0, 0, 0, 4);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(236, 18);
            lblTrangThai.TabIndex = 3;
            lblTrangThai.Text = "—";
            // 
            // lblNhanTen
            // 
            lblNhanTen.Location = new Point(12, 116);
            lblNhanTen.Margin = new Padding(0);
            lblNhanTen.Name = "lblNhanTen";
            lblNhanTen.Size = new Size(236, 18);
            lblNhanTen.TabIndex = 4;
            lblNhanTen.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(12, 134);
            txtTenDangNhap.Margin = new Padding(0, 0, 0, 6);
            txtTenDangNhap.MaxLength = 50;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(236, 34);
            txtTenDangNhap.TabIndex = 0;
            // 
            // lblNhanVaiTro
            // 
            lblNhanVaiTro.Location = new Point(12, 174);
            lblNhanVaiTro.Margin = new Padding(0);
            lblNhanVaiTro.Name = "lblNhanVaiTro";
            lblNhanVaiTro.Size = new Size(236, 18);
            lblNhanVaiTro.TabIndex = 5;
            lblNhanVaiTro.Text = "Vai trò được cấp";
            // 
            // cbVaiTro
            // 
            cbVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVaiTro.Location = new Point(12, 192);
            cbVaiTro.Margin = new Padding(0, 0, 0, 8);
            cbVaiTro.Name = "cbVaiTro";
            cbVaiTro.Size = new Size(236, 36);
            cbVaiTro.TabIndex = 1;
            // 
            // pnlDuyet
            // 
            pnlDuyet.Controls.Add(btnDuyet);
            pnlDuyet.Controls.Add(btnTuChoi);
            pnlDuyet.Location = new Point(12, 236);
            pnlDuyet.Margin = new Padding(0);
            pnlDuyet.Name = "pnlDuyet";
            pnlDuyet.Size = new Size(236, 38);
            pnlDuyet.TabIndex = 6;
            // 
            // btnDuyet
            // 
            btnDuyet.BackColor = Color.FromArgb(23, 38, 62);
            btnDuyet.FlatAppearance.BorderSize = 0;
            btnDuyet.FlatStyle = FlatStyle.Flat;
            btnDuyet.ForeColor = Color.FromArgb(255, 255, 255);
            btnDuyet.Location = new Point(0, 0);
            btnDuyet.Margin = new Padding(0, 0, 8, 0);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(138, 36);
            btnDuyet.TabIndex = 0;
            btnDuyet.Text = "Duyệt đăng ký";
            btnDuyet.UseVisualStyleBackColor = false;
            btnDuyet.Click += btnDuyet_Click;
            // 
            // btnTuChoi
            // 
            btnTuChoi.Location = new Point(146, 0);
            btnTuChoi.Margin = new Padding(0);
            btnTuChoi.Name = "btnTuChoi";
            btnTuChoi.Size = new Size(90, 36);
            btnTuChoi.TabIndex = 1;
            btnTuChoi.Text = "Từ chối";
            btnTuChoi.Click += btnTuChoi_Click;
            // 
            // pnlQuanTri
            // 
            pnlQuanTri.Controls.Add(btnLuu);
            pnlQuanTri.Controls.Add(btnKhoa);
            pnlQuanTri.Location = new Point(12, 274);
            pnlQuanTri.Margin = new Padding(0);
            pnlQuanTri.Name = "pnlQuanTri";
            pnlQuanTri.Size = new Size(236, 38);
            pnlQuanTri.TabIndex = 7;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(0, 0);
            btnLuu.Margin = new Padding(0, 0, 8, 0);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(132, 36);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "Lưu thay đổi";
            btnLuu.Click += btnLuu_Click;
            // 
            // btnKhoa
            // 
            btnKhoa.ForeColor = Color.FromArgb(185, 48, 48);
            btnKhoa.Location = new Point(140, 0);
            btnKhoa.Margin = new Padding(0);
            btnKhoa.Name = "btnKhoa";
            btnKhoa.Size = new Size(96, 36);
            btnKhoa.TabIndex = 4;
            btnKhoa.Text = "Khóa";
            btnKhoa.Click += btnKhoa_Click;
            // 
            // tabMatKhau
            // 
            tabMatKhau.BackColor = Color.FromArgb(255, 255, 255);
            tabMatKhau.Controls.Add(pnlMatKhau);
            tabMatKhau.Location = new Point(4, 34);
            tabMatKhau.Name = "tabMatKhau";
            tabMatKhau.Size = new Size(272, 484);
            tabMatKhau.TabIndex = 1;
            tabMatKhau.Text = "Mật khẩu";
            // 
            // pnlMatKhau
            // 
            pnlMatKhau.AutoScroll = true;
            pnlMatKhau.BackColor = Color.FromArgb(255, 255, 255);
            pnlMatKhau.Controls.Add(lblNhanMatKhau);
            pnlMatKhau.Controls.Add(txtMatKhauMoi);
            pnlMatKhau.Controls.Add(txtXacNhanMatKhau);
            pnlMatKhau.Controls.Add(chkHienMatKhau);
            pnlMatKhau.Controls.Add(btnDatLaiMatKhau);
            pnlMatKhau.Dock = DockStyle.Fill;
            pnlMatKhau.FlowDirection = FlowDirection.TopDown;
            pnlMatKhau.Location = new Point(0, 0);
            pnlMatKhau.Name = "pnlMatKhau";
            pnlMatKhau.Padding = new Padding(12);
            pnlMatKhau.Size = new Size(272, 484);
            pnlMatKhau.TabIndex = 0;
            pnlMatKhau.WrapContents = false;
            // 
            // lblNhanMatKhau
            // 
            lblNhanMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNhanMatKhau.Location = new Point(12, 12);
            lblNhanMatKhau.Margin = new Padding(0);
            lblNhanMatKhau.Name = "lblNhanMatKhau";
            lblNhanMatKhau.Size = new Size(236, 30);
            lblNhanMatKhau.TabIndex = 0;
            lblNhanMatKhau.Text = "ĐẶT LẠI MẬT KHẨU";
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(12, 42);
            txtMatKhauMoi.Margin = new Padding(0, 0, 0, 10);
            txtMatKhauMoi.MaxLength = 128;
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PlaceholderText = "Mật khẩu mới (8–128 ký tự)";
            txtMatKhauMoi.Size = new Size(236, 34);
            txtMatKhauMoi.TabIndex = 5;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Location = new Point(12, 86);
            txtXacNhanMatKhau.Margin = new Padding(0, 0, 0, 8);
            txtXacNhanMatKhau.MaxLength = 128;
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.PlaceholderText = "Nhập lại mật khẩu mới";
            txtXacNhanMatKhau.Size = new Size(236, 34);
            txtXacNhanMatKhau.TabIndex = 6;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.Location = new Point(12, 128);
            chkHienMatKhau.Margin = new Padding(0, 0, 0, 8);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(236, 28);
            chkHienMatKhau.TabIndex = 7;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // btnDatLaiMatKhau
            // 
            btnDatLaiMatKhau.Location = new Point(12, 164);
            btnDatLaiMatKhau.Margin = new Padding(0, 0, 0, 8);
            btnDatLaiMatKhau.Name = "btnDatLaiMatKhau";
            btnDatLaiMatKhau.Size = new Size(236, 38);
            btnDatLaiMatKhau.TabIndex = 8;
            btnDatLaiMatKhau.Text = "Đặt lại mật khẩu";
            btnDatLaiMatKhau.Click += btnDatLaiMatKhau_Click;
            // 
            // lblThongBao
            // 
            lblThongBao.Dock = DockStyle.Fill;
            lblThongBao.ForeColor = Color.FromArgb(100, 116, 139);
            lblThongBao.Location = new Point(24, 788);
            lblThongBao.Margin = new Padding(0);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Padding = new Padding(0, 10, 0, 0);
            lblThongBao.Size = new Size(1232, 50);
            lblThongBao.TabIndex = 4;
            lblThongBao.Text = "Chọn tài khoản để xem chi tiết. Tài khoản chờ duyệt chưa có mã nhân viên.";
            // 
            // ucTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 251);
            Controls.Add(pnlBoCuc);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(16, 18, 15);
            Name = "ucTaiKhoan";
            Size = new Size(1280, 850);
            Load += ucTaiKhoan_Load;
            pnlBoCuc.ResumeLayout(false);
            pnlTieuDe.ResumeLayout(false);
            pnlThongKe.ResumeLayout(false);
            pnlThongKe.PerformLayout();
            pnlTongSo.ResumeLayout(false);
            pnlChoDuyet.ResumeLayout(false);
            pnlHoatDong.ResumeLayout(false);
            pnlBiKhoa.ResumeLayout(false);
            pnlBoLoc.ResumeLayout(false);
            pnlBoLoc.PerformLayout();
            pnlNoiDung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            tabChiTiet.ResumeLayout(false);
            tabThongTin.ResumeLayout(false);
            pnlChiTiet.ResumeLayout(false);
            pnlChiTiet.PerformLayout();
            pnlDuyet.ResumeLayout(false);
            pnlQuanTri.ResumeLayout(false);
            tabMatKhau.ResumeLayout(false);
            pnlMatKhau.ResumeLayout(false);
            pnlMatKhau.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private TableLayoutPanel pnlBoCuc;
        private TableLayoutPanel pnlTieuDe;
        private Label lblTieuDe;
        private Button btnThem;
        private TableLayoutPanel pnlThongKe;
        private Panel pnlTongSo;
        private Label lblTongSo;
        private Label lblNhanTongSo;
        private Panel pnlChoDuyet;
        private Label lblChoDuyet;
        private Label lblNhanChoDuyet;
        private Panel pnlHoatDong;
        private Label lblHoatDong;
        private Label lblNhanHoatDong;
        private Panel pnlBiKhoa;
        private Label lblBiKhoa;
        private Label lblNhanBiKhoa;
        private TableLayoutPanel pnlBoLoc;
        private TextBox txtTimKiem;
        private ComboBox cbLocTrangThai;
        private ComboBox cbLocVaiTro;
        private Button btnTaiLai;
        private TableLayoutPanel pnlNoiDung;
        private DataGridView dgvTaiKhoan;
        private DataGridViewTextBoxColumn colMaTaiKhoan;
        private DataGridViewTextBoxColumn colTenDangNhap;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colMaNhanVien;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colVaiTro;
        private DataGridViewTextBoxColumn colTrangThai;
        private FlowLayoutPanel pnlChiTiet;
        private TabControl tabChiTiet;
        private TabPage tabThongTin;
        private TabPage tabMatKhau;
        private FlowLayoutPanel pnlMatKhau;
        private Label lblNhanChiTiet;
        private Label lblNguoiDung;
        private Label lblMaNhanVien;
        private Label lblTrangThai;
        private Label lblNhanTen;
        private TextBox txtTenDangNhap;
        private Label lblNhanVaiTro;
        private ComboBox cbVaiTro;
        private FlowLayoutPanel pnlDuyet;
        private FlowLayoutPanel pnlQuanTri;
        private Button btnDuyet;
        private Button btnTuChoi;
        private Button btnLuu;
        private Button btnKhoa;
        private Label lblNhanMatKhau;
        private TextBox txtMatKhauMoi;
        private TextBox txtXacNhanMatKhau;
        private CheckBox chkHienMatKhau;
        private Button btnDatLaiMatKhau;
        private Label lblThongBao;
    }
}


