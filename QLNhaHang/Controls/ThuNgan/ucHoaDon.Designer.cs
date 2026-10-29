using QLNhaHang.Classes;
namespace QLNhaHang.Controls.ThuNgan
{
    partial class ucHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            pnlHeader = new Panel();
            lblIconCho = new Label();
            lblCapCho = new Label();
            lblSoCho = new Label();
            cardCho = new Panel();
            lblIconDa = new Label();
            lblCapDa = new Label();
            lblSoDa = new Label();
            cardDa = new Panel();
            lblIconThu = new Label();
            lblCapThu = new Label();
            lblThuNay = new Label();
            cardThu = new Panel();
            tlpStats = new TableLayoutPanel();
            lblIconTim = new Label();
            txtTim = new TextBox();
            pnlTim = new Panel();
            dtpNgay = new DateTimePicker();
            pnlNgay = new Panel();
            cboTrangThai = new ComboBox();
            pnlTT = new Panel();
            btnLamMoi = new Button();
            tlpToolbar = new TableLayoutPanel();
            btnTabCho = new Button();
            btnTabDa = new Button();
            pnlTabs = new Panel();
            lblFooter = new Label();
            pnlFoot = new Panel();
            colMa = new DataGridViewTextBoxColumn();
            colBan = new DataGridViewTextBoxColumn();
            colGio = new DataGridViewTextBoxColumn();
            colTong = new DataGridViewTextBoxColumn();
            colTT = new DataGridViewTextBoxColumn();
            dgvHD = new DataGridView();
            pnlLeft = new Panel();
            lblCT = new Label();
            mTen = new DataGridViewTextBoxColumn();
            mSL = new DataGridViewTextBoxColumn();
            mGia = new DataGridViewTextBoxColumn();
            mTien = new DataGridViewTextBoxColumn();
            dgvMon = new DataGridView();
            lblCap_lblTienMon = new Label();
            lblTienMon = new Label();
            lblCap_lblGiamGia = new Label();
            lblGiamGia = new Label();
            lblCap_lblPhuThu = new Label();
            lblPhuThu = new Label();
            lblCanCap = new Label();
            lblCan = new Label();
            pnlCan = new Panel();
            tlpTong = new TableLayoutPanel();
            lblPT = new Label();
            btnTienMat = new Button();
            btnChuyenKhoan = new Button();
            btnThe = new Button();
            tlpPT = new TableLayoutPanel();
            pnlPT = new Panel();
            lblDuaCap = new Label();
            lblDongDua = new Label();
            txtDua = new TextBox();
            pnlDuaBox = new Panel();
            pnlDua = new Panel();
            lblThuaCap = new Label();
            lblDongThua = new Label();
            txtThua = new TextBox();
            pnlThuaBox = new Panel();
            pnlThua = new Panel();
            tlpTien = new TableLayoutPanel();
            btnIn = new Button();
            btnXacNhan = new Button();
            tlpNut = new TableLayoutPanel();
            tlpPhai = new TableLayoutPanel();
            pnlRight = new Panel();
            pnlGap = new Panel();
            pnlMain = new Panel();
            pnlHeader.SuspendLayout();
            cardCho.SuspendLayout();
            cardDa.SuspendLayout();
            cardThu.SuspendLayout();
            tlpStats.SuspendLayout();
            pnlTim.SuspendLayout();
            pnlNgay.SuspendLayout();
            pnlTT.SuspendLayout();
            tlpToolbar.SuspendLayout();
            pnlTabs.SuspendLayout();
            pnlFoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHD).BeginInit();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMon).BeginInit();
            pnlCan.SuspendLayout();
            tlpTong.SuspendLayout();
            tlpPT.SuspendLayout();
            pnlPT.SuspendLayout();
            pnlDuaBox.SuspendLayout();
            pnlDua.SuspendLayout();
            pnlThuaBox.SuspendLayout();
            pnlThua.SuspendLayout();
            tlpTien.SuspendLayout();
            tlpNut.SuspendLayout();
            tlpPhai.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.BackColor = Color.Transparent;
            lblTieuDe.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(35, 52, 73);
            lblTieuDe.Location = new Point(0, 2);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(333, 54);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Quản lý hóa đơn";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(243, 245, 248);
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(20, 14);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1460, 48);
            pnlHeader.TabIndex = 3;
            // 
            // lblIconCho
            // 
            lblIconCho.BackColor = Color.FromArgb(234, 241, 249);
            lblIconCho.Font = new Font("Segoe UI Symbol", 16F, FontStyle.Bold);
            lblIconCho.ForeColor = Color.FromArgb(49, 99, 156);
            lblIconCho.Location = new Point(18, 14);
            lblIconCho.Name = "lblIconCho";
            lblIconCho.Size = new Size(52, 52);
            lblIconCho.TabIndex = 0;
            lblIconCho.Text = "≡";
            lblIconCho.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCapCho
            // 
            lblCapCho.AutoSize = true;
            lblCapCho.BackColor = Color.Transparent;
            lblCapCho.Font = new Font("Segoe UI", 10.5F);
            lblCapCho.ForeColor = Color.FromArgb(100, 116, 139);
            lblCapCho.Location = new Point(82, 8);
            lblCapCho.Name = "lblCapCho";
            lblCapCho.Size = new Size(159, 30);
            lblCapCho.TabIndex = 1;
            lblCapCho.Text = "Chờ thanh toán";
            // 
            // lblSoCho
            // 
            lblSoCho.AutoSize = true;
            lblSoCho.BackColor = Color.Transparent;
            lblSoCho.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblSoCho.ForeColor = Color.FromArgb(49, 99, 156);
            lblSoCho.Location = new Point(80, 28);
            lblSoCho.Name = "lblSoCho";
            lblSoCho.Size = new Size(84, 65);
            lblSoCho.TabIndex = 2;
            lblSoCho.Text = "00";
            // 
            // cardCho
            // 
            cardCho.BackColor = Color.FromArgb(255, 255, 255);
            cardCho.BorderStyle = BorderStyle.FixedSingle;
            cardCho.Controls.Add(lblIconCho);
            cardCho.Controls.Add(lblCapCho);
            cardCho.Controls.Add(lblSoCho);
            cardCho.Dock = DockStyle.Fill;
            cardCho.Location = new Point(0, 0);
            cardCho.Margin = new Padding(0, 0, 12, 0);
            cardCho.Name = "cardCho";
            cardCho.Size = new Size(475, 84);
            cardCho.TabIndex = 0;
            // 
            // lblIconDa
            // 
            lblIconDa.BackColor = Color.FromArgb(35, 123, 94);
            lblIconDa.Font = new Font("Segoe UI Symbol", 16F, FontStyle.Bold);
            lblIconDa.ForeColor = Color.FromArgb(255, 255, 255);
            lblIconDa.Location = new Point(18, 14);
            lblIconDa.Name = "lblIconDa";
            lblIconDa.Size = new Size(52, 52);
            lblIconDa.TabIndex = 0;
            lblIconDa.Text = "✓";
            lblIconDa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCapDa
            // 
            lblCapDa.AutoSize = true;
            lblCapDa.BackColor = Color.Transparent;
            lblCapDa.Font = new Font("Segoe UI", 10.5F);
            lblCapDa.ForeColor = Color.FromArgb(100, 116, 139);
            lblCapDa.Location = new Point(82, 8);
            lblCapDa.Name = "lblCapDa";
            lblCapDa.Size = new Size(147, 30);
            lblCapDa.TabIndex = 1;
            lblCapDa.Text = "Đã thanh toán";
            // 
            // lblSoDa
            // 
            lblSoDa.AutoSize = true;
            lblSoDa.BackColor = Color.Transparent;
            lblSoDa.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblSoDa.ForeColor = Color.FromArgb(35, 123, 94);
            lblSoDa.Location = new Point(80, 28);
            lblSoDa.Name = "lblSoDa";
            lblSoDa.Size = new Size(84, 65);
            lblSoDa.TabIndex = 2;
            lblSoDa.Text = "00";
            // 
            // cardDa
            // 
            cardDa.BackColor = Color.FromArgb(255, 255, 255);
            cardDa.BorderStyle = BorderStyle.FixedSingle;
            cardDa.Controls.Add(lblIconDa);
            cardDa.Controls.Add(lblCapDa);
            cardDa.Controls.Add(lblSoDa);
            cardDa.Dock = DockStyle.Fill;
            cardDa.Location = new Point(487, 0);
            cardDa.Margin = new Padding(0, 0, 12, 0);
            cardDa.Name = "cardDa";
            cardDa.Size = new Size(475, 84);
            cardDa.TabIndex = 1;
            // 
            // lblIconThu
            // 
            lblIconThu.BackColor = Color.FromArgb(251, 241, 226);
            lblIconThu.Font = new Font("Segoe UI Symbol", 16F, FontStyle.Bold);
            lblIconThu.ForeColor = Color.FromArgb(171, 102, 34);
            lblIconThu.Location = new Point(18, 14);
            lblIconThu.Name = "lblIconThu";
            lblIconThu.Size = new Size(52, 52);
            lblIconThu.TabIndex = 0;
            lblIconThu.Text = "₫";
            lblIconThu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCapThu
            // 
            lblCapThu.AutoSize = true;
            lblCapThu.BackColor = Color.Transparent;
            lblCapThu.Font = new Font("Segoe UI", 10.5F);
            lblCapThu.ForeColor = Color.FromArgb(100, 116, 139);
            lblCapThu.Location = new Point(82, 8);
            lblCapThu.Name = "lblCapThu";
            lblCapThu.Size = new Size(163, 30);
            lblCapThu.TabIndex = 1;
            lblCapThu.Text = "Đã thu hôm nay";
            // 
            // lblThuNay
            // 
            lblThuNay.AutoSize = true;
            lblThuNay.BackColor = Color.Transparent;
            lblThuNay.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblThuNay.ForeColor = Color.FromArgb(35, 52, 73);
            lblThuNay.Location = new Point(80, 32);
            lblThuNay.Name = "lblThuNay";
            lblThuNay.Size = new Size(78, 51);
            lblThuNay.TabIndex = 2;
            lblThuNay.Text = "0 đ";
            // 
            // cardThu
            // 
            cardThu.BackColor = Color.FromArgb(255, 255, 255);
            cardThu.BorderStyle = BorderStyle.FixedSingle;
            cardThu.Controls.Add(lblIconThu);
            cardThu.Controls.Add(lblCapThu);
            cardThu.Controls.Add(lblThuNay);
            cardThu.Dock = DockStyle.Fill;
            cardThu.Location = new Point(974, 0);
            cardThu.Margin = new Padding(0);
            cardThu.Name = "cardThu";
            cardThu.Size = new Size(486, 84);
            cardThu.TabIndex = 2;
            // 
            // tlpStats
            // 
            tlpStats.BackColor = Color.FromArgb(244, 247, 251);
            tlpStats.ColumnCount = 3;
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tlpStats.Controls.Add(cardCho, 0, 0);
            tlpStats.Controls.Add(cardDa, 1, 0);
            tlpStats.Controls.Add(cardThu, 2, 0);
            tlpStats.Dock = DockStyle.Top;
            tlpStats.Location = new Point(20, 62);
            tlpStats.Name = "tlpStats";
            tlpStats.RowCount = 1;
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpStats.Size = new Size(1460, 84);
            tlpStats.TabIndex = 2;
            // 
            // lblIconTim
            // 
            lblIconTim.AutoSize = true;
            lblIconTim.BackColor = Color.Transparent;
            lblIconTim.Font = new Font("Segoe UI Symbol", 14F);
            lblIconTim.ForeColor = Color.FromArgb(100, 116, 139);
            lblIconTim.Location = new Point(12, 7);
            lblIconTim.Name = "lblIconTim";
            lblIconTim.Size = new Size(38, 38);
            lblIconTim.TabIndex = 1;
            lblIconTim.Text = "⌕";
            // 
            // txtTim
            // 
            txtTim.BorderStyle = BorderStyle.None;
            txtTim.Dock = DockStyle.Fill;
            txtTim.Font = new Font("Segoe UI", 9F);
            txtTim.ForeColor = Color.FromArgb(35, 52, 73);
            txtTim.Location = new Point(40, 11);
            txtTim.Name = "txtTim";
            txtTim.PlaceholderText = "Tìm mã hóa đơn, bàn, khách hàng...";
            txtTim.Size = new Size(786, 24);
            txtTim.TabIndex = 0;
            txtTim.TextChanged += txtTim_TextChanged;
            // 
            // pnlTim
            // 
            pnlTim.BackColor = Color.FromArgb(255, 255, 255);
            pnlTim.BorderStyle = BorderStyle.FixedSingle;
            pnlTim.Controls.Add(txtTim);
            pnlTim.Controls.Add(lblIconTim);
            pnlTim.Dock = DockStyle.Fill;
            pnlTim.Location = new Point(0, 8);
            pnlTim.Margin = new Padding(0, 0, 12, 0);
            pnlTim.Name = "pnlTim";
            pnlTim.Padding = new Padding(40, 11, 10, 0);
            pnlTim.Size = new Size(838, 44);
            pnlTim.TabIndex = 0;
            // 
            // dtpNgay
            // 
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            dtpNgay.Dock = DockStyle.Fill;
            dtpNgay.Font = new Font("Segoe UI", 9F);
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(12, 9);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.ShowCheckBox = true;
            dtpNgay.Size = new Size(196, 31);
            dtpNgay.TabIndex = 0;
            dtpNgay.ValueChanged += dtpNgay_ValueChanged;
            // 
            // pnlNgay
            // 
            pnlNgay.BackColor = Color.FromArgb(255, 255, 255);
            pnlNgay.BorderStyle = BorderStyle.FixedSingle;
            pnlNgay.Controls.Add(dtpNgay);
            pnlNgay.Dock = DockStyle.Fill;
            pnlNgay.Location = new Point(850, 8);
            pnlNgay.Margin = new Padding(0, 0, 12, 0);
            pnlNgay.Name = "pnlNgay";
            pnlNgay.Padding = new Padding(12, 9, 8, 0);
            pnlNgay.Size = new Size(218, 44);
            pnlNgay.TabIndex = 1;
            // 
            // cboTrangThai
            // 
            cboTrangThai.BackColor = Color.FromArgb(255, 255, 255);
            cboTrangThai.Dock = DockStyle.Fill;
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FlatStyle = FlatStyle.Flat;
            cboTrangThai.Font = new Font("Segoe UI", 9F);
            cboTrangThai.Items.AddRange(new object[] { "Tất cả trạng thái", "Chờ thanh toán", "Đã thanh toán" });
            cboTrangThai.Location = new Point(12, 8);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(216, 33);
            cboTrangThai.TabIndex = 0;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;
            // 
            // pnlTT
            // 
            pnlTT.BackColor = Color.FromArgb(255, 255, 255);
            pnlTT.BorderStyle = BorderStyle.FixedSingle;
            pnlTT.Controls.Add(cboTrangThai);
            pnlTT.Dock = DockStyle.Fill;
            pnlTT.Location = new Point(1080, 8);
            pnlTT.Margin = new Padding(0, 0, 12, 0);
            pnlTT.Name = "pnlTT";
            pnlTT.Padding = new Padding(12, 8, 8, 0);
            pnlTT.Size = new Size(238, 44);
            pnlTT.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(49, 99, 156);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.Dock = DockStyle.Fill;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.FromArgb(255, 255, 255);
            btnLamMoi.Location = new Point(1330, 8);
            btnLamMoi.Margin = new Padding(0);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(130, 44);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "⟳  Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // tlpToolbar
            // 
            tlpToolbar.BackColor = Color.FromArgb(243, 245, 248);
            tlpToolbar.ColumnCount = 4;
            tlpToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 230F));
            tlpToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tlpToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tlpToolbar.Controls.Add(pnlTim, 0, 0);
            tlpToolbar.Controls.Add(pnlNgay, 1, 0);
            tlpToolbar.Controls.Add(pnlTT, 2, 0);
            tlpToolbar.Controls.Add(btnLamMoi, 3, 0);
            tlpToolbar.Dock = DockStyle.Top;
            tlpToolbar.Location = new Point(20, 146);
            tlpToolbar.Name = "tlpToolbar";
            tlpToolbar.Padding = new Padding(0, 8, 0, 6);
            tlpToolbar.RowCount = 1;
            tlpToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpToolbar.Size = new Size(1460, 58);
            tlpToolbar.TabIndex = 1;
            // 
            // btnTabCho
            // 
            btnTabCho.BackColor = Color.FromArgb(255, 255, 255);
            btnTabCho.Cursor = Cursors.Hand;
            btnTabCho.FlatAppearance.BorderSize = 0;
            btnTabCho.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 250, 252);
            btnTabCho.FlatStyle = FlatStyle.Flat;
            btnTabCho.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnTabCho.ForeColor = Color.FromArgb(100, 116, 139);
            btnTabCho.Location = new Point(18, 0);
            btnTabCho.Name = "btnTabCho";
            btnTabCho.Size = new Size(210, 56);
            btnTabCho.TabIndex = 0;
            btnTabCho.TabStop = false;
            btnTabCho.Text = "▤  Chờ thanh toán";
            btnTabCho.UseVisualStyleBackColor = false;
            btnTabCho.Click += btnTab_Click;
            btnTabCho.Paint += btnTab_Paint;
            // 
            // btnTabDa
            // 
            btnTabDa.BackColor = Color.FromArgb(255, 255, 255);
            btnTabDa.Cursor = Cursors.Hand;
            btnTabDa.FlatAppearance.BorderSize = 0;
            btnTabDa.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 250, 252);
            btnTabDa.FlatStyle = FlatStyle.Flat;
            btnTabDa.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnTabDa.ForeColor = Color.FromArgb(100, 116, 139);
            btnTabDa.Location = new Point(234, 0);
            btnTabDa.Name = "btnTabDa";
            btnTabDa.Size = new Size(210, 56);
            btnTabDa.TabIndex = 1;
            btnTabDa.TabStop = false;
            btnTabDa.Text = "✓  Đã thanh toán";
            btnTabDa.UseVisualStyleBackColor = false;
            btnTabDa.Click += btnTab_Click;
            btnTabDa.Paint += btnTab_Paint;
            // 
            // pnlTabs
            // 
            pnlTabs.BackColor = Color.FromArgb(255, 255, 255);
            pnlTabs.Controls.Add(btnTabCho);
            pnlTabs.Controls.Add(btnTabDa);
            pnlTabs.Dock = DockStyle.Top;
            pnlTabs.Location = new Point(1, 1);
            pnlTabs.Name = "pnlTabs";
            pnlTabs.Size = new Size(864, 56);
            pnlTabs.TabIndex = 2;
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.BackColor = Color.Transparent;
            lblFooter.Font = new Font("Segoe UI", 9.5F);
            lblFooter.ForeColor = Color.FromArgb(100, 116, 139);
            lblFooter.Location = new Point(18, 10);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(411, 25);
            lblFooter.TabIndex = 0;
            lblFooter.Text = "0 hóa đơn  •  Chọn một hóa đơn để xem chi tiết";
            // 
            // pnlFoot
            // 
            pnlFoot.BackColor = Color.FromArgb(255, 255, 255);
            pnlFoot.Controls.Add(lblFooter);
            pnlFoot.Dock = DockStyle.Bottom;
            pnlFoot.Location = new Point(1, 591);
            pnlFoot.Name = "pnlFoot";
            pnlFoot.Size = new Size(864, 40);
            pnlFoot.TabIndex = 1;
            // 
            // colMa
            // 
            colMa.FillWeight = 15F;
            colMa.HeaderText = "Mã HD";
            colMa.MinimumWidth = 6;
            colMa.Name = "colMa";
            colMa.ReadOnly = true;
            colMa.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colBan
            // 
            colBan.FillWeight = 10F;
            colBan.HeaderText = "Bàn";
            colBan.MinimumWidth = 6;
            colBan.Name = "colBan";
            colBan.ReadOnly = true;
            colBan.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colGio
            // 
            colGio.FillWeight = 22F;
            colGio.HeaderText = "Giờ vào";
            colGio.MinimumWidth = 6;
            colGio.Name = "colGio";
            colGio.ReadOnly = true;
            colGio.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colTong
            // 
            colTong.FillWeight = 21F;
            colTong.HeaderText = "Tổng tiền";
            colTong.MinimumWidth = 6;
            colTong.Name = "colTong";
            colTong.ReadOnly = true;
            colTong.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colTT
            // 
            colTT.FillWeight = 32F;
            colTT.HeaderText = "Trạng thái";
            colTT.MinimumWidth = 6;
            colTT.Name = "colTT";
            colTT.ReadOnly = true;
            colTT.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvHD
            // 
            dgvHD.AllowUserToAddRows = false;
            dgvHD.AllowUserToDeleteRows = false;
            dgvHD.AllowUserToResizeColumns = false;
            dgvHD.AllowUserToResizeRows = false;
            dgvHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHD.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvHD.BorderStyle = BorderStyle.None;
            dgvHD.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHD.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHD.ColumnHeadersHeight = 52;
            dgvHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHD.Columns.AddRange(new DataGridViewColumn[] { colMa, colBan, colGio, colTong, colTT });
            dgvHD.Dock = DockStyle.Fill;
            dgvHD.EnableHeadersVisualStyles = false;
            dgvHD.GridColor = Color.FromArgb(226, 232, 240);
            dgvHD.Location = new Point(1, 57);
            dgvHD.MultiSelect = false;
            dgvHD.Name = "dgvHD";
            dgvHD.ReadOnly = true;
            dgvHD.RowHeadersVisible = false;
            dgvHD.RowHeadersWidth = 51;
            dgvHD.RowTemplate.Height = 56;
            dgvHD.ScrollBars = ScrollBars.Vertical;
            dgvHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHD.Size = new Size(864, 534);
            dgvHD.TabIndex = 0;
            dgvHD.CellPainting += dgvHD_CellPainting;
            dgvHD.SelectionChanged += dgvHD_SelectionChanged;
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(255, 255, 255);
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(dgvHD);
            pnlLeft.Controls.Add(pnlFoot);
            pnlLeft.Controls.Add(pnlTabs);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(0, 6);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(1);
            pnlLeft.Size = new Size(866, 634);
            pnlLeft.TabIndex = 0;
            // 
            // lblCT
            // 
            lblCT.Dock = DockStyle.Fill;
            lblCT.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCT.ForeColor = Color.FromArgb(35, 52, 73);
            lblCT.Location = new Point(3, 0);
            lblCT.Name = "lblCT";
            lblCT.Size = new Size(536, 36);
            lblCT.TabIndex = 0;
            lblCT.Text = "Chi tiết hóa đơn";
            lblCT.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mTen
            // 
            mTen.FillWeight = 40F;
            mTen.HeaderText = "Tên món";
            mTen.MinimumWidth = 6;
            mTen.Name = "mTen";
            mTen.ReadOnly = true;
            mTen.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // mSL
            // 
            mSL.FillWeight = 10F;
            mSL.HeaderText = "SL";
            mSL.MinimumWidth = 6;
            mSL.Name = "mSL";
            mSL.ReadOnly = true;
            mSL.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // mGia
            // 
            mGia.FillWeight = 24F;
            mGia.HeaderText = "Đơn giá";
            mGia.MinimumWidth = 6;
            mGia.Name = "mGia";
            mGia.ReadOnly = true;
            mGia.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // mTien
            // 
            mTien.FillWeight = 26F;
            mTien.HeaderText = "Thành tiền";
            mTien.MinimumWidth = 6;
            mTien.Name = "mTien";
            mTien.ReadOnly = true;
            mTien.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvMon
            // 
            dgvMon.AllowUserToAddRows = false;
            dgvMon.AllowUserToDeleteRows = false;
            dgvMon.AllowUserToResizeColumns = false;
            dgvMon.AllowUserToResizeRows = false;
            dgvMon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMon.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvMon.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMon.ColumnHeadersHeight = 40;
            dgvMon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMon.Columns.AddRange(new DataGridViewColumn[] { mTen, mSL, mGia, mTien });
            dgvMon.Dock = DockStyle.Fill;
            dgvMon.EnableHeadersVisualStyles = false;
            dgvMon.GridColor = Color.FromArgb(226, 232, 240);
            dgvMon.Location = new Point(0, 38);
            dgvMon.Margin = new Padding(0, 2, 0, 8);
            dgvMon.MultiSelect = false;
            dgvMon.Name = "dgvMon";
            dgvMon.ReadOnly = true;
            dgvMon.RowHeadersVisible = false;
            dgvMon.RowHeadersWidth = 51;
            dgvMon.RowTemplate.Height = 40;
            dgvMon.ScrollBars = ScrollBars.Vertical;
            dgvMon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMon.Size = new Size(542, 258);
            dgvMon.TabIndex = 1;
            dgvMon.SelectionChanged += dgvMon_SelectionChanged;
            // 
            // lblCap_lblTienMon
            // 
            lblCap_lblTienMon.Dock = DockStyle.Fill;
            lblCap_lblTienMon.Font = new Font("Segoe UI", 10.5F);
            lblCap_lblTienMon.ForeColor = Color.FromArgb(35, 52, 73);
            lblCap_lblTienMon.Location = new Point(3, 0);
            lblCap_lblTienMon.Name = "lblCap_lblTienMon";
            lblCap_lblTienMon.Size = new Size(262, 26);
            lblCap_lblTienMon.TabIndex = 0;
            lblCap_lblTienMon.Text = "Tiền món";
            lblCap_lblTienMon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTienMon
            // 
            lblTienMon.Dock = DockStyle.Fill;
            lblTienMon.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTienMon.ForeColor = Color.FromArgb(15, 23, 42);
            lblTienMon.Location = new Point(271, 0);
            lblTienMon.Name = "lblTienMon";
            lblTienMon.Padding = new Padding(0, 0, 6, 0);
            lblTienMon.Size = new Size(262, 26);
            lblTienMon.TabIndex = 1;
            lblTienMon.Text = "0 đ";
            lblTienMon.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCap_lblGiamGia
            // 
            lblCap_lblGiamGia.Dock = DockStyle.Fill;
            lblCap_lblGiamGia.Font = new Font("Segoe UI", 10.5F);
            lblCap_lblGiamGia.ForeColor = Color.FromArgb(35, 52, 73);
            lblCap_lblGiamGia.Location = new Point(3, 26);
            lblCap_lblGiamGia.Name = "lblCap_lblGiamGia";
            lblCap_lblGiamGia.Size = new Size(262, 26);
            lblCap_lblGiamGia.TabIndex = 2;
            lblCap_lblGiamGia.Text = "Giảm giá";
            lblCap_lblGiamGia.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGiamGia
            // 
            lblGiamGia.Dock = DockStyle.Fill;
            lblGiamGia.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblGiamGia.ForeColor = Color.FromArgb(15, 23, 42);
            lblGiamGia.Location = new Point(271, 26);
            lblGiamGia.Name = "lblGiamGia";
            lblGiamGia.Padding = new Padding(0, 0, 6, 0);
            lblGiamGia.Size = new Size(262, 26);
            lblGiamGia.TabIndex = 3;
            lblGiamGia.Text = "0 đ";
            lblGiamGia.TextAlign = ContentAlignment.MiddleRight;
            lblGiamGia.Click += lblGiamGia_Click;
            // 
            // lblCap_lblPhuThu
            // 
            lblCap_lblPhuThu.Dock = DockStyle.Fill;
            lblCap_lblPhuThu.Font = new Font("Segoe UI", 10.5F);
            lblCap_lblPhuThu.ForeColor = Color.FromArgb(35, 52, 73);
            lblCap_lblPhuThu.Location = new Point(3, 52);
            lblCap_lblPhuThu.Name = "lblCap_lblPhuThu";
            lblCap_lblPhuThu.Size = new Size(262, 26);
            lblCap_lblPhuThu.TabIndex = 4;
            lblCap_lblPhuThu.Text = "Phụ thu";
            lblCap_lblPhuThu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPhuThu
            // 
            lblPhuThu.Dock = DockStyle.Fill;
            lblPhuThu.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPhuThu.ForeColor = Color.FromArgb(15, 23, 42);
            lblPhuThu.Location = new Point(271, 52);
            lblPhuThu.Name = "lblPhuThu";
            lblPhuThu.Padding = new Padding(0, 0, 6, 0);
            lblPhuThu.Size = new Size(262, 26);
            lblPhuThu.TabIndex = 5;
            lblPhuThu.Text = "0 đ";
            lblPhuThu.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCanCap
            // 
            lblCanCap.AutoSize = true;
            lblCanCap.BackColor = Color.Transparent;
            lblCanCap.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblCanCap.ForeColor = Color.FromArgb(35, 52, 73);
            lblCanCap.Location = new Point(3, 6);
            lblCanCap.Name = "lblCanCap";
            lblCanCap.Size = new Size(203, 36);
            lblCanCap.TabIndex = 1;
            lblCanCap.Text = "Cần thanh toán";
            // 
            // lblCan
            // 
            lblCan.Dock = DockStyle.Right;
            lblCan.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblCan.ForeColor = Color.FromArgb(15, 23, 42);
            lblCan.Location = new Point(276, 0);
            lblCan.Name = "lblCan";
            lblCan.Padding = new Padding(0, 0, 6, 0);
            lblCan.Size = new Size(260, 36);
            lblCan.TabIndex = 0;
            lblCan.Text = "0 đ";
            lblCan.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlCan
            // 
            pnlCan.BackColor = Color.FromArgb(234, 241, 249);
            tlpTong.SetColumnSpan(pnlCan, 2);
            pnlCan.Controls.Add(lblCan);
            pnlCan.Controls.Add(lblCanCap);
            pnlCan.Dock = DockStyle.Fill;
            pnlCan.Location = new Point(0, 84);
            pnlCan.Margin = new Padding(0, 6, 0, 0);
            pnlCan.Name = "pnlCan";
            pnlCan.Size = new Size(536, 36);
            pnlCan.TabIndex = 6;
            // 
            // tlpTong
            // 
            tlpTong.BackColor = Color.FromArgb(255, 255, 255);
            tlpTong.ColumnCount = 2;
            tlpTong.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpTong.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpTong.Controls.Add(lblCap_lblTienMon, 0, 0);
            tlpTong.Controls.Add(lblTienMon, 1, 0);
            tlpTong.Controls.Add(lblCap_lblGiamGia, 0, 1);
            tlpTong.Controls.Add(lblGiamGia, 1, 1);
            tlpTong.Controls.Add(lblCap_lblPhuThu, 0, 2);
            tlpTong.Controls.Add(lblPhuThu, 1, 2);
            tlpTong.Controls.Add(pnlCan, 0, 3);
            tlpTong.Dock = DockStyle.Fill;
            tlpTong.Location = new Point(3, 307);
            tlpTong.Name = "tlpTong";
            tlpTong.RowCount = 4;
            tlpTong.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tlpTong.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tlpTong.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tlpTong.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTong.Size = new Size(536, 120);
            tlpTong.TabIndex = 2;
            // 
            // lblPT
            // 
            lblPT.Dock = DockStyle.Top;
            lblPT.Font = new Font("Segoe UI", 10.5F);
            lblPT.ForeColor = Color.FromArgb(35, 52, 73);
            lblPT.Location = new Point(0, 0);
            lblPT.Name = "lblPT";
            lblPT.Size = new Size(536, 24);
            lblPT.TabIndex = 1;
            lblPT.Text = "Phương thức thanh toán";
            lblPT.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnTienMat
            // 
            btnTienMat.BackColor = Color.FromArgb(255, 255, 255);
            btnTienMat.Cursor = Cursors.Hand;
            btnTienMat.Dock = DockStyle.Fill;
            btnTienMat.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btnTienMat.FlatStyle = FlatStyle.Flat;
            btnTienMat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTienMat.Location = new Point(0, 4);
            btnTienMat.Margin = new Padding(0, 4, 8, 4);
            btnTienMat.Name = "btnTienMat";
            btnTienMat.Size = new Size(170, 30);
            btnTienMat.TabIndex = 0;
            btnTienMat.Text = "▣  Tiền mặt";
            btnTienMat.UseVisualStyleBackColor = false;
            btnTienMat.Click += btnPhuongThuc_Click;
            // 
            // btnChuyenKhoan
            // 
            btnChuyenKhoan.BackColor = Color.FromArgb(255, 255, 255);
            btnChuyenKhoan.Cursor = Cursors.Hand;
            btnChuyenKhoan.Dock = DockStyle.Fill;
            btnChuyenKhoan.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btnChuyenKhoan.FlatStyle = FlatStyle.Flat;
            btnChuyenKhoan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnChuyenKhoan.Location = new Point(178, 4);
            btnChuyenKhoan.Margin = new Padding(0, 4, 8, 4);
            btnChuyenKhoan.Name = "btnChuyenKhoan";
            btnChuyenKhoan.Size = new Size(170, 30);
            btnChuyenKhoan.TabIndex = 1;
            btnChuyenKhoan.Text = "⌂  Chuyển khoản";
            btnChuyenKhoan.UseVisualStyleBackColor = false;
            btnChuyenKhoan.Click += btnPhuongThuc_Click;
            // 
            // btnThe
            // 
            btnThe.BackColor = Color.FromArgb(255, 255, 255);
            btnThe.Cursor = Cursors.Hand;
            btnThe.Dock = DockStyle.Fill;
            btnThe.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btnThe.FlatStyle = FlatStyle.Flat;
            btnThe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThe.Location = new Point(356, 4);
            btnThe.Margin = new Padding(0, 4, 0, 4);
            btnThe.Name = "btnThe";
            btnThe.Size = new Size(180, 30);
            btnThe.TabIndex = 2;
            btnThe.Text = "▭  Thẻ";
            btnThe.UseVisualStyleBackColor = false;
            btnThe.Click += btnPhuongThuc_Click;
            // 
            // tlpPT
            // 
            tlpPT.BackColor = Color.FromArgb(255, 255, 255);
            tlpPT.ColumnCount = 3;
            tlpPT.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpPT.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpPT.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpPT.Controls.Add(btnTienMat, 0, 0);
            tlpPT.Controls.Add(btnChuyenKhoan, 1, 0);
            tlpPT.Controls.Add(btnThe, 2, 0);
            tlpPT.Dock = DockStyle.Fill;
            tlpPT.Location = new Point(0, 24);
            tlpPT.Name = "tlpPT";
            tlpPT.RowCount = 1;
            tlpPT.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPT.Size = new Size(536, 38);
            tlpPT.TabIndex = 0;
            // 
            // pnlPT
            // 
            pnlPT.BackColor = Color.FromArgb(255, 255, 255);
            pnlPT.Controls.Add(tlpPT);
            pnlPT.Controls.Add(lblPT);
            pnlPT.Dock = DockStyle.Fill;
            pnlPT.Location = new Point(3, 433);
            pnlPT.Name = "pnlPT";
            pnlPT.Size = new Size(536, 62);
            pnlPT.TabIndex = 3;
            // 
            // lblDuaCap
            // 
            lblDuaCap.Dock = DockStyle.Top;
            lblDuaCap.Font = new Font("Segoe UI", 10F);
            lblDuaCap.ForeColor = Color.FromArgb(35, 52, 73);
            lblDuaCap.Location = new Point(0, 0);
            lblDuaCap.Name = "lblDuaCap";
            lblDuaCap.Size = new Size(283, 22);
            lblDuaCap.TabIndex = 1;
            lblDuaCap.Text = "Khách đưa";
            lblDuaCap.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDongDua
            // 
            lblDongDua.BackColor = Color.FromArgb(255, 255, 255);
            lblDongDua.Dock = DockStyle.Right;
            lblDongDua.Font = new Font("Segoe UI", 10.5F);
            lblDongDua.ForeColor = Color.FromArgb(100, 116, 139);
            lblDongDua.Location = new Point(247, 9);
            lblDongDua.Name = "lblDongDua";
            lblDongDua.Size = new Size(34, 26);
            lblDongDua.TabIndex = 1;
            lblDongDua.Text = "đ";
            lblDongDua.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDua
            // 
            txtDua.BackColor = Color.FromArgb(255, 255, 255);
            txtDua.BorderStyle = BorderStyle.None;
            txtDua.Dock = DockStyle.Fill;
            txtDua.Font = new Font("Segoe UI", 11F);
            txtDua.ForeColor = Color.FromArgb(35, 52, 73);
            txtDua.Location = new Point(10, 9);
            txtDua.Name = "txtDua";
            txtDua.Size = new Size(237, 25);
            txtDua.TabIndex = 0;
            txtDua.TextChanged += txtDua_TextChanged;
            // 
            // pnlDuaBox
            // 
            pnlDuaBox.BackColor = Color.FromArgb(255, 255, 255);
            pnlDuaBox.BorderStyle = BorderStyle.FixedSingle;
            pnlDuaBox.Controls.Add(txtDua);
            pnlDuaBox.Controls.Add(lblDongDua);
            pnlDuaBox.Dock = DockStyle.Top;
            pnlDuaBox.Location = new Point(0, 22);
            pnlDuaBox.Name = "pnlDuaBox";
            pnlDuaBox.Padding = new Padding(10, 9, 0, 0);
            pnlDuaBox.Size = new Size(283, 37);
            pnlDuaBox.TabIndex = 0;
            // 
            // pnlDua
            // 
            pnlDua.BackColor = Color.FromArgb(255, 255, 255);
            pnlDua.Controls.Add(pnlDuaBox);
            pnlDua.Controls.Add(lblDuaCap);
            pnlDua.Dock = DockStyle.Fill;
            pnlDua.Location = new Point(0, 0);
            pnlDua.Margin = new Padding(0, 0, 10, 0);
            pnlDua.Name = "pnlDua";
            pnlDua.Size = new Size(283, 62);
            pnlDua.TabIndex = 0;
            // 
            // lblThuaCap
            // 
            lblThuaCap.Dock = DockStyle.Top;
            lblThuaCap.Font = new Font("Segoe UI", 10F);
            lblThuaCap.ForeColor = Color.FromArgb(35, 52, 73);
            lblThuaCap.Location = new Point(0, 0);
            lblThuaCap.Name = "lblThuaCap";
            lblThuaCap.Size = new Size(233, 22);
            lblThuaCap.TabIndex = 1;
            lblThuaCap.Text = "Tiền thừa";
            lblThuaCap.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDongThua
            // 
            lblDongThua.BackColor = Color.FromArgb(243, 245, 248);
            lblDongThua.Dock = DockStyle.Right;
            lblDongThua.Font = new Font("Segoe UI", 10.5F);
            lblDongThua.ForeColor = Color.FromArgb(100, 116, 139);
            lblDongThua.Location = new Point(197, 9);
            lblDongThua.Name = "lblDongThua";
            lblDongThua.Size = new Size(34, 26);
            lblDongThua.TabIndex = 1;
            lblDongThua.Text = "đ";
            lblDongThua.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtThua
            // 
            txtThua.BackColor = Color.FromArgb(243, 245, 248);
            txtThua.BorderStyle = BorderStyle.None;
            txtThua.Dock = DockStyle.Fill;
            txtThua.Font = new Font("Segoe UI", 11F);
            txtThua.ForeColor = Color.FromArgb(100, 116, 139);
            txtThua.Location = new Point(10, 9);
            txtThua.Name = "txtThua";
            txtThua.ReadOnly = true;
            txtThua.Size = new Size(187, 25);
            txtThua.TabIndex = 0;
            txtThua.TabStop = false;
            // 
            // pnlThuaBox
            // 
            pnlThuaBox.BackColor = Color.FromArgb(243, 245, 248);
            pnlThuaBox.BorderStyle = BorderStyle.FixedSingle;
            pnlThuaBox.Controls.Add(txtThua);
            pnlThuaBox.Controls.Add(lblDongThua);
            pnlThuaBox.Dock = DockStyle.Top;
            pnlThuaBox.Location = new Point(0, 22);
            pnlThuaBox.Name = "pnlThuaBox";
            pnlThuaBox.Padding = new Padding(10, 9, 0, 0);
            pnlThuaBox.Size = new Size(233, 37);
            pnlThuaBox.TabIndex = 0;
            // 
            // pnlThua
            // 
            pnlThua.BackColor = Color.FromArgb(255, 255, 255);
            pnlThua.Controls.Add(pnlThuaBox);
            pnlThua.Controls.Add(lblThuaCap);
            pnlThua.Dock = DockStyle.Fill;
            pnlThua.Location = new Point(293, 0);
            pnlThua.Margin = new Padding(0, 0, 10, 0);
            pnlThua.Name = "pnlThua";
            pnlThua.Size = new Size(233, 62);
            pnlThua.TabIndex = 1;
            // 
            // tlpTien
            // 
            tlpTien.BackColor = Color.FromArgb(255, 255, 255);
            tlpTien.ColumnCount = 2;
            tlpTien.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tlpTien.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tlpTien.Controls.Add(pnlDua, 0, 0);
            tlpTien.Controls.Add(pnlThua, 1, 0);
            tlpTien.Dock = DockStyle.Fill;
            tlpTien.Location = new Point(3, 501);
            tlpTien.Name = "tlpTien";
            tlpTien.RowCount = 1;
            tlpTien.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTien.Size = new Size(536, 62);
            tlpTien.TabIndex = 4;
            // 
            // btnIn
            // 
            btnIn.BackColor = Color.FromArgb(255, 255, 255);
            btnIn.Cursor = Cursors.Hand;
            btnIn.Dock = DockStyle.Fill;
            btnIn.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btnIn.FlatStyle = FlatStyle.Flat;
            btnIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIn.ForeColor = Color.FromArgb(15, 23, 42);
            btnIn.Location = new Point(0, 4);
            btnIn.Margin = new Padding(0, 4, 10, 0);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(204, 38);
            btnIn.TabIndex = 0;
            btnIn.Text = "⎙  In tạm tính";
            btnIn.UseVisualStyleBackColor = false;
            btnIn.Click += btnIn_Click;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.FromArgb(49, 99, 156);
            btnXacNhan.Cursor = Cursors.Hand;
            btnXacNhan.Dock = DockStyle.Fill;
            btnXacNhan.FlatAppearance.BorderSize = 0;
            btnXacNhan.FlatStyle = FlatStyle.Flat;
            btnXacNhan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.Location = new Point(214, 4);
            btnXacNhan.Margin = new Padding(0, 4, 0, 0);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(322, 38);
            btnXacNhan.TabIndex = 1;
            btnXacNhan.Text = "✓  Xác nhận thanh toán";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // tlpNut
            // 
            tlpNut.BackColor = Color.FromArgb(255, 255, 255);
            tlpNut.ColumnCount = 2;
            tlpNut.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpNut.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpNut.Controls.Add(btnIn, 0, 0);
            tlpNut.Controls.Add(btnXacNhan, 1, 0);
            tlpNut.Dock = DockStyle.Fill;
            tlpNut.Location = new Point(3, 569);
            tlpNut.Name = "tlpNut";
            tlpNut.RowCount = 1;
            tlpNut.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpNut.Size = new Size(536, 42);
            tlpNut.TabIndex = 5;
            // 
            // tlpPhai
            // 
            tlpPhai.BackColor = Color.FromArgb(255, 255, 255);
            tlpPhai.ColumnCount = 1;
            tlpPhai.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPhai.Controls.Add(lblCT, 0, 0);
            tlpPhai.Controls.Add(dgvMon, 0, 1);
            tlpPhai.Controls.Add(tlpTong, 0, 2);
            tlpPhai.Controls.Add(pnlPT, 0, 3);
            tlpPhai.Controls.Add(tlpTien, 0, 4);
            tlpPhai.Controls.Add(tlpNut, 0, 5);
            tlpPhai.Dock = DockStyle.Fill;
            tlpPhai.Location = new Point(18, 8);
            tlpPhai.Name = "tlpPhai";
            tlpPhai.RowCount = 6;
            tlpPhai.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpPhai.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPhai.RowStyles.Add(new RowStyle(SizeType.Absolute, 126F));
            tlpPhai.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            tlpPhai.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            tlpPhai.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpPhai.Size = new Size(542, 614);
            tlpPhai.TabIndex = 0;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(255, 255, 255);
            pnlRight.BorderStyle = BorderStyle.FixedSingle;
            pnlRight.Controls.Add(tlpPhai);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(880, 6);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(18, 8, 18, 10);
            pnlRight.Size = new Size(580, 634);
            pnlRight.TabIndex = 2;
            // 
            // pnlGap
            // 
            pnlGap.BackColor = Color.FromArgb(243, 245, 248);
            pnlGap.Dock = DockStyle.Right;
            pnlGap.Location = new Point(866, 6);
            pnlGap.Name = "pnlGap";
            pnlGap.Size = new Size(14, 634);
            pnlGap.TabIndex = 1;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(243, 245, 248);
            pnlMain.Controls.Add(pnlLeft);
            pnlMain.Controls.Add(pnlGap);
            pnlMain.Controls.Add(pnlRight);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(20, 204);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(0, 6, 0, 0);
            pnlMain.Size = new Size(1460, 640);
            pnlMain.TabIndex = 0;
            // 
            // ucHoaDon
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            AutoScrollMinSize = new Size(1240, 780);
            BackColor = Color.FromArgb(244, 247, 251);
            Controls.Add(pnlMain);
            Controls.Add(tlpToolbar);
            Controls.Add(tlpStats);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(39, 51, 67);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucHoaDon";
            Padding = new Padding(20, 14, 20, 16);
            Size = new Size(1500, 860);
            Load += ucHoaDon_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            cardCho.ResumeLayout(false);
            cardCho.PerformLayout();
            cardDa.ResumeLayout(false);
            cardDa.PerformLayout();
            cardThu.ResumeLayout(false);
            cardThu.PerformLayout();
            tlpStats.ResumeLayout(false);
            pnlTim.ResumeLayout(false);
            pnlTim.PerformLayout();
            pnlNgay.ResumeLayout(false);
            pnlTT.ResumeLayout(false);
            tlpToolbar.ResumeLayout(false);
            pnlTabs.ResumeLayout(false);
            pnlFoot.ResumeLayout(false);
            pnlFoot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHD).EndInit();
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMon).EndInit();
            pnlCan.ResumeLayout(false);
            pnlCan.PerformLayout();
            tlpTong.ResumeLayout(false);
            tlpPT.ResumeLayout(false);
            pnlPT.ResumeLayout(false);
            pnlDuaBox.ResumeLayout(false);
            pnlDuaBox.PerformLayout();
            pnlDua.ResumeLayout(false);
            pnlThuaBox.ResumeLayout(false);
            pnlThuaBox.PerformLayout();
            pnlThua.ResumeLayout(false);
            tlpTien.ResumeLayout(false);
            tlpNut.ResumeLayout(false);
            tlpPhai.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private Panel pnlHeader;
        private Label lblIconCho;
        private Label lblCapCho;
        private Label lblSoCho;
        private Panel cardCho;
        private Label lblIconDa;
        private Label lblCapDa;
        private Label lblSoDa;
        private Panel cardDa;
        private Label lblIconThu;
        private Label lblCapThu;
        private Label lblThuNay;
        private Panel cardThu;
        private TableLayoutPanel tlpStats;
        private Label lblIconTim;
        private TextBox txtTim;
        private Panel pnlTim;
        private DateTimePicker dtpNgay;
        private Panel pnlNgay;
        private ComboBox cboTrangThai;
        private Panel pnlTT;
        private Button btnLamMoi;
        private TableLayoutPanel tlpToolbar;
        private Button btnTabCho;
        private Button btnTabDa;
        private Panel pnlTabs;
        private Label lblFooter;
        private Panel pnlFoot;
        private DataGridViewTextBoxColumn colMa;
        private DataGridViewTextBoxColumn colBan;
        private DataGridViewTextBoxColumn colGio;
        private DataGridViewTextBoxColumn colTong;
        private DataGridViewTextBoxColumn colTT;
        private DataGridView dgvHD;
        private Panel pnlLeft;
        private Label lblCT;
        private DataGridViewTextBoxColumn mTen;
        private DataGridViewTextBoxColumn mSL;
        private DataGridViewTextBoxColumn mGia;
        private DataGridViewTextBoxColumn mTien;
        private DataGridView dgvMon;
        private Label lblCap_lblTienMon;
        private Label lblTienMon;
        private Label lblCap_lblGiamGia;
        private Label lblGiamGia;
        private Label lblCap_lblPhuThu;
        private Label lblPhuThu;
        private Label lblCanCap;
        private Label lblCan;
        private Panel pnlCan;
        private TableLayoutPanel tlpTong;
        private Label lblPT;
        private Button btnTienMat;
        private Button btnChuyenKhoan;
        private Button btnThe;
        private TableLayoutPanel tlpPT;
        private Panel pnlPT;
        private Label lblDuaCap;
        private Label lblDongDua;
        private TextBox txtDua;
        private Panel pnlDuaBox;
        private Panel pnlDua;
        private Label lblThuaCap;
        private Label lblDongThua;
        private TextBox txtThua;
        private Panel pnlThuaBox;
        private Panel pnlThua;
        private TableLayoutPanel tlpTien;
        private Button btnIn;
        private Button btnXacNhan;
        private TableLayoutPanel tlpNut;
        private TableLayoutPanel tlpPhai;
        private Panel pnlRight;
        private Panel pnlGap;
        private Panel pnlMain;
    }
}