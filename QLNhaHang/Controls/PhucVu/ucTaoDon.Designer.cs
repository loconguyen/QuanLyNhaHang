using QLNhaHang.Classes;
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
            // Kiểu tiêu đề bảng: nền xanh đậm, chữ trắng đậm
            System.Windows.Forms.DataGridViewCellStyle stHdDon = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stHdMon = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stHdCT = new System.Windows.Forms.DataGridViewCellStyle();
            // Kiểu định dạng số, giờ
            System.Windows.Forms.DataGridViewCellStyle stFmtDonGio = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stFmtDonTien = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stFmtMonGia = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stFmtCtGia = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stFmtCtTien = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stFmtCtGio = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlDanhSach = new System.Windows.Forms.Panel();
            this.pnlTopDS = new System.Windows.Forms.Panel();
            this.lblTieuDeDS = new System.Windows.Forms.Label();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.btnLamMoiDS = new System.Windows.Forms.Button();
            this.dgvDon = new System.Windows.Forms.DataGridView();
            this.cDonHangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDonSoBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDonViTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDonHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDonThoiGianTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDonSoMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDonTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cMonMonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMonTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMonDVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMonDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMonDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMonTinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlThem = new System.Windows.Forms.Panel();
            this.lblSL = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblGC = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblGoiY = new System.Windows.Forms.Label();
            this.pnlKe = new System.Windows.Forms.Panel();
            this.pnlGio = new System.Windows.Forms.Panel();
            this.pnlGioTop = new System.Windows.Forms.Panel();
            this.lblGio = new System.Windows.Forms.Label();
            this.dgvCT = new System.Windows.Forms.DataGridView();
            this.cCtDongID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCtTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCtSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCtDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCtThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCtTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCtGuiBep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCtGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
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

            // =====================================================================
            //  MÀN 1: DANH SÁCH ĐƠN ĐANG XỬ LÝ
            // =====================================================================
            this.pnlDanhSach.BackColor = QLNhaHang.Classes.Theme.Background;
            this.pnlDanhSach.Controls.Add(this.dgvDon);
            this.pnlDanhSach.Controls.Add(this.pnlTopDS);
            this.pnlDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDanhSach.Name = "pnlDanhSach";
            this.pnlDanhSach.TabIndex = 1;

            this.pnlTopDS.BackColor = QLNhaHang.Classes.Theme.Surface;
            this.pnlTopDS.Controls.Add(this.lblTieuDeDS);
            this.pnlTopDS.Controls.Add(this.lblHuongDan);
            this.pnlTopDS.Controls.Add(this.btnLamMoiDS);
            this.pnlTopDS.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopDS.Name = "pnlTopDS";
            this.pnlTopDS.Size = new System.Drawing.Size(1080, 80);

            this.lblTieuDeDS.AutoSize = true;
            this.lblTieuDeDS.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeDS.ForeColor = QLNhaHang.Classes.Theme.BlueBold;
            this.lblTieuDeDS.Location = new System.Drawing.Point(20, 10);
            this.lblTieuDeDS.Name = "lblTieuDeDS";
            this.lblTieuDeDS.Text = "Đơn đang xử lý";

            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.ForeColor = QLNhaHang.Classes.Theme.TextMuted;
            this.lblHuongDan.Location = new System.Drawing.Point(22, 48);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Text = "";

            this.btnLamMoiDS.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnLamMoiDS.BackColor = QLNhaHang.Classes.Theme.BlueBold;
            this.btnLamMoiDS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiDS.FlatAppearance.BorderSize = 0;
            this.btnLamMoiDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiDS.ForeColor = QLNhaHang.Classes.Theme.Surface;
            this.btnLamMoiDS.Location = new System.Drawing.Point(960, 22);
            this.btnLamMoiDS.Name = "btnLamMoiDS";
            this.btnLamMoiDS.Size = new System.Drawing.Size(95, 36);
            this.btnLamMoiDS.Text = "Làm mới";
            this.btnLamMoiDS.UseVisualStyleBackColor = false;
            this.btnLamMoiDS.Click += new System.EventHandler(this.btnLamMoiDS_Click);

            // --- bảng danh sách đơn ---
            stHdDon.BackColor = QLNhaHang.Classes.Theme.BlueBold;
            stHdDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            stHdDon.ForeColor = QLNhaHang.Classes.Theme.Surface;
            stHdDon.SelectionBackColor = QLNhaHang.Classes.Theme.BlueBold;
            stHdDon.SelectionForeColor = QLNhaHang.Classes.Theme.Surface;
            this.dgvDon.AllowUserToAddRows = false;
            this.dgvDon.AllowUserToDeleteRows = false;
            this.dgvDon.AutoGenerateColumns = false;
            this.dgvDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDon.BackgroundColor = QLNhaHang.Classes.Theme.Surface;
            this.dgvDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDon.ColumnHeadersDefaultCellStyle = stHdDon;
            this.dgvDon.ColumnHeadersHeight = 34;
            this.dgvDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.cDonHangID, this.cDonSoBan, this.cDonViTri, this.cDonHoTen,
                this.cDonThoiGianTao, this.cDonSoMon, this.cDonTongTien });
            this.dgvDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDon.EnableHeadersVisualStyles = false;
            this.dgvDon.GridColor = QLNhaHang.Classes.Theme.Border;
            this.dgvDon.MultiSelect = false;
            this.dgvDon.Name = "dgvDon";
            this.dgvDon.ReadOnly = true;
            this.dgvDon.RowHeadersVisible = false;
            this.dgvDon.RowTemplate.Height = 28;
            this.dgvDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDon.TabIndex = 1;
            this.dgvDon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDon_CellDoubleClick);
            this.dgvDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDon_CellFormatting);

            this.cDonHangID.DataPropertyName = "DonHangID";
            this.cDonHangID.FillWeight = 50F;
            this.cDonHangID.HeaderText = "Mã đơn";
            this.cDonHangID.Name = "DonHangID";
            this.cDonHangID.ReadOnly = true;

            this.cDonSoBan.DataPropertyName = "SoBan";
            this.cDonSoBan.FillWeight = 50F;
            this.cDonSoBan.HeaderText = "Bàn";
            this.cDonSoBan.Name = "SoBan";
            this.cDonSoBan.ReadOnly = true;

            this.cDonViTri.DataPropertyName = "ViTri";
            this.cDonViTri.FillWeight = 80F;
            this.cDonViTri.HeaderText = "Khu vực";
            this.cDonViTri.Name = "ViTri";
            this.cDonViTri.ReadOnly = true;

            this.cDonHoTen.DataPropertyName = "HoTen";
            this.cDonHoTen.FillWeight = 120F;
            this.cDonHoTen.HeaderText = "Nhân viên phục vụ";
            this.cDonHoTen.Name = "HoTen";
            this.cDonHoTen.ReadOnly = true;

            stFmtDonGio.Format = "dd/MM/yyyy HH:mm";
            this.cDonThoiGianTao.DataPropertyName = "ThoiGianTao";
            this.cDonThoiGianTao.DefaultCellStyle = stFmtDonGio;
            this.cDonThoiGianTao.FillWeight = 100F;
            this.cDonThoiGianTao.HeaderText = "Tạo lúc";
            this.cDonThoiGianTao.Name = "ThoiGianTao";
            this.cDonThoiGianTao.ReadOnly = true;

            this.cDonSoMon.DataPropertyName = "SoMon";
            this.cDonSoMon.FillWeight = 50F;
            this.cDonSoMon.HeaderText = "Số món";
            this.cDonSoMon.Name = "SoMon";
            this.cDonSoMon.ReadOnly = true;

            stFmtDonTien.Format = "N0";
            this.cDonTongTien.DataPropertyName = "TongTien";
            this.cDonTongTien.DefaultCellStyle = stFmtDonTien;
            this.cDonTongTien.FillWeight = 90F;
            this.cDonTongTien.HeaderText = "Tổng tiền (đ)";
            this.cDonTongTien.Name = "TongTien";
            this.cDonTongTien.ReadOnly = true;

            // =====================================================================
            //  MÀN 2: CHI TIẾT ĐƠN
            //  Thứ tự add: Fill -> Left (đường kẻ) -> Left (cột trái) -> Top
            // =====================================================================
            this.pnlChiTiet.BackColor = QLNhaHang.Classes.Theme.Surface;
            this.pnlChiTiet.Controls.Add(this.pnlGio);
            this.pnlChiTiet.Controls.Add(this.pnlKe);
            this.pnlChiTiet.Controls.Add(this.pnlMenu);
            this.pnlChiTiet.Controls.Add(this.pnlHeaderCT);
            this.pnlChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChiTiet.Name = "pnlChiTiet";
            this.pnlChiTiet.TabIndex = 0;
            this.pnlChiTiet.Visible = false;

            // --- header ---
            this.pnlHeaderCT.BackColor = QLNhaHang.Classes.Theme.BlueSoft;
            this.pnlHeaderCT.Controls.Add(this.btnQuayLai);
            this.pnlHeaderCT.Controls.Add(this.lblThongTinDon);
            this.pnlHeaderCT.Controls.Add(this.lblTrangThaiDon);
            this.pnlHeaderCT.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderCT.Name = "pnlHeaderCT";
            this.pnlHeaderCT.Size = new System.Drawing.Size(1080, 70);

            this.btnQuayLai.BackColor = QLNhaHang.Classes.Theme.TextMuted;
            this.btnQuayLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuayLai.FlatAppearance.BorderSize = 0;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.ForeColor = QLNhaHang.Classes.Theme.Surface;
            this.btnQuayLai.Location = new System.Drawing.Point(20, 17);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(110, 36);
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);

            this.lblThongTinDon.AutoSize = true;
            this.lblThongTinDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblThongTinDon.ForeColor = QLNhaHang.Classes.Theme.BlueBold;
            this.lblThongTinDon.Location = new System.Drawing.Point(150, 12);
            this.lblThongTinDon.Name = "lblThongTinDon";
            this.lblThongTinDon.Text = "Bàn  ·  Đơn #";

            this.lblTrangThaiDon.AutoSize = true;
            this.lblTrangThaiDon.ForeColor = QLNhaHang.Classes.Theme.Danger;
            this.lblTrangThaiDon.Location = new System.Drawing.Point(152, 42);
            this.lblTrangThaiDon.Name = "lblTrangThaiDon";
            this.lblTrangThaiDon.Text = "";

            // --- cột trái: thực đơn (rộng 520) ---
            this.pnlMenu.BackColor = QLNhaHang.Classes.Theme.Surface;
            this.pnlMenu.Controls.Add(this.dgvMon);
            this.pnlMenu.Controls.Add(this.pnlThem);
            this.pnlMenu.Controls.Add(this.pnlLocMon);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(520, 560);

            // Thanh trên cột trái: cao 52, trùng với thanh trên cột phải
            this.pnlLocMon.BackColor = QLNhaHang.Classes.Theme.Surface;
            this.pnlLocMon.Controls.Add(this.cboDanhMuc);
            this.pnlLocMon.Controls.Add(this.txtTim);
            this.pnlLocMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLocMon.Name = "pnlLocMon";
            this.pnlLocMon.Size = new System.Drawing.Size(520, 52);

            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Location = new System.Drawing.Point(12, 13);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(160, 23);
            this.cboDanhMuc.TabIndex = 0;
            this.cboDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged);

            this.txtTim.Location = new System.Drawing.Point(182, 13);
            this.txtTim.Name = "txtTim";
            this.txtTim.PlaceholderText = "Tìm món...";
            this.txtTim.Size = new System.Drawing.Size(326, 23);
            this.txtTim.TabIndex = 1;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);

            // --- bảng thực đơn ---
            stHdMon.BackColor = QLNhaHang.Classes.Theme.BlueBold;
            stHdMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            stHdMon.ForeColor = QLNhaHang.Classes.Theme.Surface;
            stHdMon.SelectionBackColor = QLNhaHang.Classes.Theme.BlueBold;
            stHdMon.SelectionForeColor = QLNhaHang.Classes.Theme.Surface;
            this.dgvMon.AllowUserToAddRows = false;
            this.dgvMon.AllowUserToDeleteRows = false;
            this.dgvMon.AutoGenerateColumns = false;
            this.dgvMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMon.BackgroundColor = QLNhaHang.Classes.Theme.Surface;
            this.dgvMon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMon.ColumnHeadersDefaultCellStyle = stHdMon;
            this.dgvMon.ColumnHeadersHeight = 34;
            this.dgvMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.cMonMonID, this.cMonTenMon, this.cMonDVT, this.cMonDonGia,
                this.cMonDanhMuc, this.cMonTinhTrang });
            this.dgvMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMon.EnableHeadersVisualStyles = false;
            this.dgvMon.GridColor = QLNhaHang.Classes.Theme.Border;
            this.dgvMon.MultiSelect = false;
            this.dgvMon.Name = "dgvMon";
            this.dgvMon.ReadOnly = true;
            this.dgvMon.RowHeadersVisible = false;
            this.dgvMon.RowTemplate.Height = 28;
            this.dgvMon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMon.TabIndex = 2;
            this.dgvMon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMon_CellDoubleClick);
            this.dgvMon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMon_CellFormatting);

            this.cMonMonID.DataPropertyName = "MonID";
            this.cMonMonID.Name = "MonID";
            this.cMonMonID.ReadOnly = true;
            this.cMonMonID.Visible = false;

            this.cMonTenMon.DataPropertyName = "TenMon";
            this.cMonTenMon.FillWeight = 120F;
            this.cMonTenMon.HeaderText = "Món";
            this.cMonTenMon.Name = "TenMon";
            this.cMonTenMon.ReadOnly = true;

            this.cMonDVT.DataPropertyName = "DonViTinh";
            this.cMonDVT.FillWeight = 40F;
            this.cMonDVT.HeaderText = "ĐVT";
            this.cMonDVT.Name = "DonViTinh";
            this.cMonDVT.ReadOnly = true;

            stFmtMonGia.Format = "N0";
            this.cMonDonGia.DataPropertyName = "DonGia";
            this.cMonDonGia.DefaultCellStyle = stFmtMonGia;
            this.cMonDonGia.FillWeight = 70F;
            this.cMonDonGia.HeaderText = "Đơn giá";
            this.cMonDonGia.Name = "DonGia";
            this.cMonDonGia.ReadOnly = true;

            this.cMonDanhMuc.DataPropertyName = "TenDanhMuc";
            this.cMonDanhMuc.FillWeight = 80F;
            this.cMonDanhMuc.HeaderText = "Danh mục";
            this.cMonDanhMuc.Name = "TenDanhMuc";
            this.cMonDanhMuc.ReadOnly = true;

            this.cMonTinhTrang.DataPropertyName = "TrangThaiMon";
            this.cMonTinhTrang.FillWeight = 60F;
            this.cMonTinhTrang.HeaderText = "Tình trạng";
            this.cMonTinhTrang.Name = "TrangThaiMon";
            this.cMonTinhTrang.ReadOnly = true;

            // Thanh dưới cột trái: cao 120, trùng với thanh dưới cột phải
            this.pnlThem.BackColor = QLNhaHang.Classes.Theme.Surface;
            this.pnlThem.Controls.Add(this.lblSL);
            this.pnlThem.Controls.Add(this.nudSoLuong);
            this.pnlThem.Controls.Add(this.lblGC);
            this.pnlThem.Controls.Add(this.txtGhiChu);
            this.pnlThem.Controls.Add(this.btnThem);
            this.pnlThem.Controls.Add(this.lblGoiY);
            this.pnlThem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThem.Name = "pnlThem";
            this.pnlThem.Size = new System.Drawing.Size(520, 120);

            this.lblSL.AutoSize = true;
            this.lblSL.Location = new System.Drawing.Point(12, 10);
            this.lblSL.Name = "lblSL";
            this.lblSL.Text = "Số lượng";

            this.nudSoLuong.Location = new System.Drawing.Point(12, 32);
            this.nudSoLuong.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(70, 23);
            this.nudSoLuong.TabIndex = 0;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });

            this.lblGC.AutoSize = true;
            this.lblGC.Location = new System.Drawing.Point(95, 10);
            this.lblGC.Name = "lblGC";
            this.lblGC.Text = "Ghi chú món";

            this.txtGhiChu.Location = new System.Drawing.Point(95, 32);
            this.txtGhiChu.MaxLength = 255;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(413, 23);
            this.txtGhiChu.TabIndex = 1;

            // Nút nằm ở hàng y=72, cùng hàng với nhóm nút bên phải
            this.btnThem.BackColor = QLNhaHang.Classes.Theme.Blue;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = QLNhaHang.Classes.Theme.Surface;
            this.btnThem.Location = new System.Drawing.Point(378, 72);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 38);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm vào đơn";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.lblGoiY.AutoSize = true;
            this.lblGoiY.ForeColor = QLNhaHang.Classes.Theme.TextMuted;
            this.lblGoiY.Location = new System.Drawing.Point(12, 82);
            this.lblGoiY.Name = "lblGoiY";
            this.lblGoiY.Text = "Nhấp đúp vào một món để thêm nhanh.";

            // --- đường kẻ giữa hai cột ---
            this.pnlKe.BackColor = QLNhaHang.Classes.Theme.Border;
            this.pnlKe.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKe.Name = "pnlKe";
            this.pnlKe.Size = new System.Drawing.Size(2, 560);

            // --- cột phải: món trong đơn ---
            this.pnlGio.BackColor = QLNhaHang.Classes.Theme.Surface;
            this.pnlGio.Controls.Add(this.dgvCT);
            this.pnlGio.Controls.Add(this.pnlGioBottom);
            this.pnlGio.Controls.Add(this.pnlGioTop);
            this.pnlGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGio.Name = "pnlGio";

            // Thanh trên cột phải: cao 52, trùng với thanh trên cột trái
            this.pnlGioTop.BackColor = QLNhaHang.Classes.Theme.Surface;
            this.pnlGioTop.Controls.Add(this.lblGio);
            this.pnlGioTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGioTop.Name = "pnlGioTop";
            this.pnlGioTop.Size = new System.Drawing.Size(558, 52);

            this.lblGio.AutoSize = true;
            this.lblGio.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGio.ForeColor = QLNhaHang.Classes.Theme.BlueBold;
            this.lblGio.Location = new System.Drawing.Point(12, 14);
            this.lblGio.Name = "lblGio";
            this.lblGio.Text = "Món trong đơn";

            // --- bảng món trong đơn ---
            stHdCT.BackColor = QLNhaHang.Classes.Theme.BlueBold;
            stHdCT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            stHdCT.ForeColor = QLNhaHang.Classes.Theme.Surface;
            stHdCT.SelectionBackColor = QLNhaHang.Classes.Theme.BlueBold;
            stHdCT.SelectionForeColor = QLNhaHang.Classes.Theme.Surface;
            this.dgvCT.AllowUserToAddRows = false;
            this.dgvCT.AllowUserToDeleteRows = false;
            this.dgvCT.AutoGenerateColumns = false;
            this.dgvCT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCT.BackgroundColor = QLNhaHang.Classes.Theme.Surface;
            this.dgvCT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCT.ColumnHeadersDefaultCellStyle = stHdCT;
            this.dgvCT.ColumnHeadersHeight = 34;
            this.dgvCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.cCtDongID, this.cCtTenMon, this.cCtSoLuong, this.cCtDonGia,
                this.cCtThanhTien, this.cCtTrangThai, this.cCtGuiBep, this.cCtGhiChu });
            this.dgvCT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCT.EnableHeadersVisualStyles = false;
            this.dgvCT.GridColor = QLNhaHang.Classes.Theme.Border;
            this.dgvCT.MultiSelect = false;
            this.dgvCT.Name = "dgvCT";
            this.dgvCT.ReadOnly = true;
            this.dgvCT.RowHeadersVisible = false;
            this.dgvCT.RowTemplate.Height = 28;
            this.dgvCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCT.TabIndex = 0;

            this.cCtDongID.DataPropertyName = "DongID";
            this.cCtDongID.Name = "DongID";
            this.cCtDongID.ReadOnly = true;
            this.cCtDongID.Visible = false;

            this.cCtTenMon.DataPropertyName = "TenMon";
            this.cCtTenMon.FillWeight = 110F;
            this.cCtTenMon.HeaderText = "Món";
            this.cCtTenMon.Name = "TenMon";
            this.cCtTenMon.ReadOnly = true;

            this.cCtSoLuong.DataPropertyName = "SoLuong";
            this.cCtSoLuong.FillWeight = 30F;
            this.cCtSoLuong.HeaderText = "SL";
            this.cCtSoLuong.Name = "SoLuong";
            this.cCtSoLuong.ReadOnly = true;

            stFmtCtGia.Format = "N0";
            this.cCtDonGia.DataPropertyName = "DonGia";
            this.cCtDonGia.DefaultCellStyle = stFmtCtGia;
            this.cCtDonGia.FillWeight = 70F;
            this.cCtDonGia.HeaderText = "Đơn giá";
            this.cCtDonGia.Name = "DonGia";
            this.cCtDonGia.ReadOnly = true;

            stFmtCtTien.Format = "N0";
            this.cCtThanhTien.DataPropertyName = "ThanhTien";
            this.cCtThanhTien.DefaultCellStyle = stFmtCtTien;
            this.cCtThanhTien.FillWeight = 80F;
            this.cCtThanhTien.HeaderText = "Thành tiền";
            this.cCtThanhTien.Name = "ThanhTien";
            this.cCtThanhTien.ReadOnly = true;

            this.cCtTrangThai.DataPropertyName = "TrangThaiMon";
            this.cCtTrangThai.FillWeight = 85F;
            this.cCtTrangThai.HeaderText = "Trạng thái";
            this.cCtTrangThai.Name = "TrangThaiMon";
            this.cCtTrangThai.ReadOnly = true;

            stFmtCtGio.Format = "HH:mm dd/MM";
            this.cCtGuiBep.DataPropertyName = "ThoiGianGuiBep";
            this.cCtGuiBep.DefaultCellStyle = stFmtCtGio;
            this.cCtGuiBep.FillWeight = 80F;
            this.cCtGuiBep.HeaderText = "Gửi bếp lúc";
            this.cCtGuiBep.Name = "ThoiGianGuiBep";
            this.cCtGuiBep.ReadOnly = true;

            this.cCtGhiChu.DataPropertyName = "GhiChu";
            this.cCtGhiChu.FillWeight = 90F;
            this.cCtGhiChu.HeaderText = "Ghi chú";
            this.cCtGhiChu.Name = "GhiChu";
            this.cCtGhiChu.ReadOnly = true;

            // Thanh dưới cột phải: cao 120, trùng với thanh dưới cột trái
            this.pnlGioBottom.BackColor = QLNhaHang.Classes.Theme.Surface;
            this.pnlGioBottom.Controls.Add(this.lblTong);
            this.pnlGioBottom.Controls.Add(this.lblQuyTac);
            this.pnlGioBottom.Controls.Add(this.btnSua);
            this.pnlGioBottom.Controls.Add(this.btnXoa);
            this.pnlGioBottom.Controls.Add(this.btnHuyDon);
            this.pnlGioBottom.Controls.Add(this.btnGuiBep);
            this.pnlGioBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGioBottom.Name = "pnlGioBottom";
            this.pnlGioBottom.Size = new System.Drawing.Size(558, 120);

            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTong.ForeColor = QLNhaHang.Classes.Theme.BlueBold;
            this.lblTong.Location = new System.Drawing.Point(12, 10);
            this.lblTong.Name = "lblTong";
            this.lblTong.Text = "Tổng tiền tạm tính: 0 đ";

            this.lblQuyTac.AutoSize = true;
            this.lblQuyTac.ForeColor = QLNhaHang.Classes.Theme.TextMuted;
            this.lblQuyTac.Location = new System.Drawing.Point(12, 42);
            this.lblQuyTac.Name = "lblQuyTac";
            this.lblQuyTac.Text = "Dòng màu vàng là món chưa gửi bếp, được sửa và xóa.";

            // Các nút nằm ở hàng y=72, cùng hàng với nút Thêm vào đơn bên trái
            this.btnSua.BackColor = QLNhaHang.Classes.Theme.Orange;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = QLNhaHang.Classes.Theme.Surface;
            this.btnSua.Location = new System.Drawing.Point(12, 72);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(105, 38);
            this.btnSua.Text = "Sửa món";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.BackColor = QLNhaHang.Classes.Theme.Danger;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = QLNhaHang.Classes.Theme.Surface;
            this.btnXoa.Location = new System.Drawing.Point(125, 72);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 38);
            this.btnXoa.Text = "Xóa món";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnHuyDon.BackColor = QLNhaHang.Classes.Theme.Danger;
            this.btnHuyDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyDon.FlatAppearance.BorderSize = 0;
            this.btnHuyDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyDon.ForeColor = QLNhaHang.Classes.Theme.Surface;
            this.btnHuyDon.Location = new System.Drawing.Point(228, 72);
            this.btnHuyDon.Name = "btnHuyDon";
            this.btnHuyDon.Size = new System.Drawing.Size(105, 38);
            this.btnHuyDon.Text = "Hủy đơn";
            this.btnHuyDon.UseVisualStyleBackColor = false;
            this.btnHuyDon.Visible = false;
            this.btnHuyDon.Click += new System.EventHandler(this.btnHuyDon_Click);

            this.btnGuiBep.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnGuiBep.BackColor = QLNhaHang.Classes.Theme.Green;
            this.btnGuiBep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuiBep.FlatAppearance.BorderSize = 0;
            this.btnGuiBep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiBep.ForeColor = QLNhaHang.Classes.Theme.Surface;
            this.btnGuiBep.Location = new System.Drawing.Point(421, 72);
            this.btnGuiBep.Name = "btnGuiBep";
            this.btnGuiBep.Size = new System.Drawing.Size(125, 38);
            this.btnGuiBep.Text = "Gửi bếp";
            this.btnGuiBep.UseVisualStyleBackColor = false;
            this.btnGuiBep.Click += new System.EventHandler(this.btnGuiBep_Click);

            // =====================================================================
            //  ucTaoDon
            // =====================================================================
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
        private System.Windows.Forms.DataGridViewTextBoxColumn cDonHangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDonSoBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDonViTri;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDonHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDonThoiGianTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDonSoMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDonTongTien;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn cMonMonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMonTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMonDVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMonDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMonDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMonTinhTrang;
        private System.Windows.Forms.Panel pnlThem;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label lblGC;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblGoiY;
        private System.Windows.Forms.Panel pnlKe;
        private System.Windows.Forms.Panel pnlGio;
        private System.Windows.Forms.Panel pnlGioTop;
        private System.Windows.Forms.Label lblGio;
        private System.Windows.Forms.DataGridView dgvCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCtDongID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCtTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCtSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCtDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCtThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCtTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCtGuiBep;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCtGhiChu;
        private System.Windows.Forms.Panel pnlGioBottom;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label lblQuyTac;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuyDon;
        private System.Windows.Forms.Button btnGuiBep;
    }
}