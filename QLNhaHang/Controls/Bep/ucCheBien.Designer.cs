namespace QLNhaHang.Controls.Bep
{
    partial class ucCheBien
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tblMain = new TableLayoutPanel();
            tblDem = new TableLayoutPanel();
            pnlCho = new Panel();
            lblChoCaption = new Label();
            lblCho = new Label();
            pnlDang = new Panel();
            lblDangCaption = new Label();
            lblDang = new Label();
            pnlXong = new Panel();
            lblXongCaption = new Label();
            lblXong = new Label();
            pnlLoc = new Panel();
            lblThongBao = new Label();
            btnLamMoi = new Button();
            cboLoc = new ComboBox();
            lblLoc = new Label();
            dgvMon = new DataGridView();
            colDonHangID = new DataGridViewTextBoxColumn();
            colMonID = new DataGridViewTextBoxColumn();
            colMaDon = new DataGridViewTextBoxColumn();
            colSoBan = new DataGridViewTextBoxColumn();
            colThoiGianTao = new DataGridViewTextBoxColumn();
            colTenMon = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colGhiChu = new DataGridViewTextBoxColumn();
            colTrangThaiMon = new DataGridViewTextBoxColumn();
            colTrangThaiText = new DataGridViewTextBoxColumn();
            tblAct = new TableLayoutPanel();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            btnLuuGhiChu = new Button();
            pnlNut = new Panel();
            btnHoanThanh = new Button();
            btnBatDau = new Button();
            lblTitle = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            tblMain.SuspendLayout();
            tblDem.SuspendLayout();
            pnlCho.SuspendLayout();
            pnlDang.SuspendLayout();
            pnlXong.SuspendLayout();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMon).BeginInit();
            tblAct.SuspendLayout();
            pnlNut.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(tblDem, 0, 0);
            tblMain.Controls.Add(pnlLoc, 0, 1);
            tblMain.Controls.Add(dgvMon, 0, 2);
            tblMain.Controls.Add(tblAct, 0, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 40);
            tblMain.Margin = new Padding(8);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tblMain.Size = new Size(1080, 590);
            tblMain.TabIndex = 0;
            // 
            // tblDem
            // 
            tblDem.ColumnCount = 3;
            tblDem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblDem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblDem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblDem.Controls.Add(pnlCho, 0, 0);
            tblDem.Controls.Add(pnlDang, 1, 0);
            tblDem.Controls.Add(pnlXong, 2, 0);
            tblDem.Dock = DockStyle.Fill;
            tblDem.Location = new Point(3, 3);
            tblDem.Name = "tblDem";
            tblDem.RowCount = 1;
            tblDem.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblDem.Size = new Size(1074, 78);
            tblDem.TabIndex = 0;
            // 
            // pnlCho
            // 
            pnlCho.BackColor = Color.White;
            pnlCho.Controls.Add(lblChoCaption);
            pnlCho.Controls.Add(lblCho);
            pnlCho.Dock = DockStyle.Fill;
            pnlCho.Location = new Point(4, 4);
            pnlCho.Margin = new Padding(4);
            pnlCho.Name = "pnlCho";
            pnlCho.Size = new Size(350, 70);
            pnlCho.TabIndex = 0;
            // 
            // lblChoCaption
            // 
            lblChoCaption.Dock = DockStyle.Fill;
            lblChoCaption.ForeColor = Color.DimGray;
            lblChoCaption.Location = new Point(0, 46);
            lblChoCaption.Name = "lblChoCaption";
            lblChoCaption.Size = new Size(350, 24);
            lblChoCaption.TabIndex = 1;
            lblChoCaption.Text = "Chờ chế biến";
            lblChoCaption.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCho
            // 
            lblCho.Dock = DockStyle.Top;
            lblCho.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblCho.ForeColor = Color.OrangeRed;
            lblCho.Location = new Point(0, 0);
            lblCho.Name = "lblCho";
            lblCho.Size = new Size(350, 46);
            lblCho.TabIndex = 0;
            lblCho.Text = "00";
            lblCho.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDang
            // 
            pnlDang.BackColor = Color.White;
            pnlDang.Controls.Add(lblDangCaption);
            pnlDang.Controls.Add(lblDang);
            pnlDang.Dock = DockStyle.Fill;
            pnlDang.Location = new Point(362, 4);
            pnlDang.Margin = new Padding(4);
            pnlDang.Name = "pnlDang";
            pnlDang.Size = new Size(350, 70);
            pnlDang.TabIndex = 1;
            // 
            // lblDangCaption
            // 
            lblDangCaption.Dock = DockStyle.Fill;
            lblDangCaption.ForeColor = Color.DimGray;
            lblDangCaption.Location = new Point(0, 46);
            lblDangCaption.Name = "lblDangCaption";
            lblDangCaption.Size = new Size(350, 24);
            lblDangCaption.TabIndex = 1;
            lblDangCaption.Text = "Đang làm";
            lblDangCaption.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblDang
            // 
            lblDang.Dock = DockStyle.Top;
            lblDang.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblDang.ForeColor = Color.RoyalBlue;
            lblDang.Location = new Point(0, 0);
            lblDang.Name = "lblDang";
            lblDang.Size = new Size(350, 46);
            lblDang.TabIndex = 0;
            lblDang.Text = "00";
            lblDang.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlXong
            // 
            pnlXong.BackColor = Color.White;
            pnlXong.Controls.Add(lblXongCaption);
            pnlXong.Controls.Add(lblXong);
            pnlXong.Dock = DockStyle.Fill;
            pnlXong.Location = new Point(720, 4);
            pnlXong.Margin = new Padding(4);
            pnlXong.Name = "pnlXong";
            pnlXong.Size = new Size(350, 70);
            pnlXong.TabIndex = 2;
            // 
            // lblXongCaption
            // 
            lblXongCaption.Dock = DockStyle.Fill;
            lblXongCaption.ForeColor = Color.DimGray;
            lblXongCaption.Location = new Point(0, 46);
            lblXongCaption.Name = "lblXongCaption";
            lblXongCaption.Size = new Size(350, 24);
            lblXongCaption.TabIndex = 1;
            lblXongCaption.Text = "Hoàn thành (chờ phục vụ)";
            lblXongCaption.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblXong
            // 
            lblXong.Dock = DockStyle.Top;
            lblXong.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblXong.ForeColor = Color.SeaGreen;
            lblXong.Location = new Point(0, 0);
            lblXong.Name = "lblXong";
            lblXong.Size = new Size(350, 46);
            lblXong.TabIndex = 0;
            lblXong.Text = "00";
            lblXong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLoc
            // 
            pnlLoc.Controls.Add(lblThongBao);
            pnlLoc.Controls.Add(btnLamMoi);
            pnlLoc.Controls.Add(cboLoc);
            pnlLoc.Controls.Add(lblLoc);
            pnlLoc.Dock = DockStyle.Fill;
            pnlLoc.Location = new Point(3, 87);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(1074, 34);
            pnlLoc.TabIndex = 1;
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.ForeColor = Color.DimGray;
            lblThongBao.Location = new Point(422, 9);
            lblThongBao.Margin = new Padding(12, 6, 0, 0);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(0, 20);
            lblThongBao.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnLamMoi.Location = new Point(260, 2);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // cboLoc
            // 
            cboLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoc.FormattingEnabled = true;
            cboLoc.Location = new Point(70, 3);
            cboLoc.Name = "cboLoc";
            cboLoc.Size = new Size(180, 28);
            cboLoc.TabIndex = 1;
            cboLoc.SelectedIndexChanged += cboLoc_SelectedIndexChanged;
            // 
            // lblLoc
            // 
            lblLoc.AutoSize = true;
            lblLoc.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblLoc.Location = new Point(17, 8);
            lblLoc.Margin = new Padding(0, 6, 6, 0);
            lblLoc.Name = "lblLoc";
            lblLoc.Size = new Size(44, 19);
            lblLoc.TabIndex = 0;
            lblLoc.Text = "Lọc:";
            // 
            // dgvMon
            // 
            dgvMon.AllowUserToAddRows = false;
            dgvMon.AllowUserToDeleteRows = false;
            dgvMon.AllowUserToResizeRows = false;
            dgvMon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMon.BackgroundColor = Color.White;
            dgvMon.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(241, 245, 249);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMon.Columns.AddRange(new DataGridViewColumn[] { colDonHangID, colMonID, colMaDon, colSoBan, colThoiGianTao, colTenMon, colSoLuong, colGhiChu, colTrangThaiMon, colTrangThaiText });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvMon.DefaultCellStyle = dataGridViewCellStyle3;
            dgvMon.Dock = DockStyle.Fill;
            dgvMon.EnableHeadersVisualStyles = false;
            dgvMon.Location = new Point(3, 127);
            dgvMon.MultiSelect = false;
            dgvMon.Name = "dgvMon";
            dgvMon.ReadOnly = true;
            dgvMon.RowHeadersVisible = false;
            dgvMon.RowHeadersWidth = 51;
            dgvMon.RowTemplate.Height = 30;
            dgvMon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMon.Size = new Size(1074, 360);
            dgvMon.TabIndex = 2;
            dgvMon.DataBindingComplete += dgvMon_DataBindingComplete;
            dgvMon.SelectionChanged += dgvMon_SelectionChanged;
            // 
            // colDonHangID
            // 
            colDonHangID.DataPropertyName = "DonHangID";
            colDonHangID.HeaderText = "";
            colDonHangID.MinimumWidth = 6;
            colDonHangID.Name = "colDonHangID";
            colDonHangID.ReadOnly = true;
            colDonHangID.Visible = false;
            // 
            // colMonID
            // 
            colMonID.DataPropertyName = "MonID";
            colMonID.HeaderText = "";
            colMonID.MinimumWidth = 6;
            colMonID.Name = "colMonID";
            colMonID.ReadOnly = true;
            colMonID.Visible = false;
            // 
            // colMaDon
            // 
            colMaDon.DataPropertyName = "MaDon";
            colMaDon.FillWeight = 70F;
            colMaDon.HeaderText = "Mã đơn";
            colMaDon.MinimumWidth = 6;
            colMaDon.Name = "colMaDon";
            colMaDon.ReadOnly = true;
            // 
            // colSoBan
            // 
            colSoBan.DataPropertyName = "SoBan";
            colSoBan.FillWeight = 50F;
            colSoBan.HeaderText = "Bàn";
            colSoBan.MinimumWidth = 6;
            colSoBan.Name = "colSoBan";
            colSoBan.ReadOnly = true;
            // 
            // colThoiGianTao
            // 
            colThoiGianTao.DataPropertyName = "ThoiGianTao";
            dataGridViewCellStyle2.Format = "HH:mm  dd/MM";
            dataGridViewCellStyle2.NullValue = null;
            colThoiGianTao.DefaultCellStyle = dataGridViewCellStyle2;
            colThoiGianTao.HeaderText = "Thời gian gửi";
            colThoiGianTao.MinimumWidth = 6;
            colThoiGianTao.Name = "colThoiGianTao";
            colThoiGianTao.ReadOnly = true;
            // 
            // colTenMon
            // 
            colTenMon.DataPropertyName = "TenMon";
            colTenMon.FillWeight = 180F;
            colTenMon.HeaderText = "Tên món";
            colTenMon.MinimumWidth = 6;
            colTenMon.Name = "colTenMon";
            colTenMon.ReadOnly = true;
            // 
            // colSoLuong
            // 
            colSoLuong.DataPropertyName = "SoLuong";
            colSoLuong.FillWeight = 40F;
            colSoLuong.HeaderText = "SL";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            colSoLuong.ReadOnly = true;
            // 
            // colGhiChu
            // 
            colGhiChu.DataPropertyName = "GhiChu";
            colGhiChu.FillWeight = 170F;
            colGhiChu.HeaderText = "Ghi chú";
            colGhiChu.MinimumWidth = 6;
            colGhiChu.Name = "colGhiChu";
            colGhiChu.ReadOnly = true;
            // 
            // colTrangThaiMon
            // 
            colTrangThaiMon.DataPropertyName = "TrangThaiMon";
            colTrangThaiMon.HeaderText = "";
            colTrangThaiMon.MinimumWidth = 6;
            colTrangThaiMon.Name = "colTrangThaiMon";
            colTrangThaiMon.ReadOnly = true;
            colTrangThaiMon.Visible = false;
            // 
            // colTrangThaiText
            // 
            colTrangThaiText.DataPropertyName = "TrangThaiText";
            colTrangThaiText.HeaderText = "Trạng thái";
            colTrangThaiText.MinimumWidth = 6;
            colTrangThaiText.Name = "colTrangThaiText";
            colTrangThaiText.ReadOnly = true;
            // 
            // tblAct
            // 
            tblAct.ColumnCount = 3;
            tblAct.ColumnStyles.Add(new ColumnStyle());
            tblAct.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblAct.ColumnStyles.Add(new ColumnStyle());
            tblAct.Controls.Add(lblGhiChu, 0, 0);
            tblAct.Controls.Add(txtGhiChu, 1, 0);
            tblAct.Controls.Add(btnLuuGhiChu, 2, 0);
            tblAct.Controls.Add(pnlNut, 0, 1);
            tblAct.Dock = DockStyle.Fill;
            tblAct.Location = new Point(3, 493);
            tblAct.Name = "tblAct";
            tblAct.RowCount = 2;
            tblAct.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblAct.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblAct.Size = new Size(1074, 94);
            tblAct.TabIndex = 3;
            // 
            // lblGhiChu
            // 
            lblGhiChu.Anchor = AnchorStyles.Left;
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new Point(3, 10);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(99, 20);
            lblGhiChu.TabIndex = 0;
            lblGhiChu.Text = "Ghi chú món: ";
            // 
            // txtGhiChu
            // 
            txtGhiChu.BorderStyle = BorderStyle.None;
            txtGhiChu.Dock = DockStyle.Fill;
            txtGhiChu.Location = new Point(108, 3);
            txtGhiChu.MaxLength = 200;
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(862, 34);
            txtGhiChu.TabIndex = 1;
            // 
            // btnLuuGhiChu
            // 
            btnLuuGhiChu.AutoSize = true;
            btnLuuGhiChu.Enabled = false;
            btnLuuGhiChu.Location = new Point(976, 3);
            btnLuuGhiChu.Name = "btnLuuGhiChu";
            btnLuuGhiChu.Size = new Size(95, 30);
            btnLuuGhiChu.TabIndex = 2;
            btnLuuGhiChu.Text = "Lưu ghi chú";
            btnLuuGhiChu.UseVisualStyleBackColor = true;
            btnLuuGhiChu.Click += btnLuuGhiChu_Click;
            // 
            // pnlNut
            // 
            tblAct.SetColumnSpan(pnlNut, 3);
            pnlNut.Controls.Add(btnHoanThanh);
            pnlNut.Controls.Add(btnBatDau);
            pnlNut.Dock = DockStyle.Fill;
            pnlNut.Location = new Point(3, 43);
            pnlNut.Name = "pnlNut";
            pnlNut.Size = new Size(1068, 48);
            pnlNut.TabIndex = 3;
            // 
            // btnHoanThanh
            // 
            btnHoanThanh.BackColor = Color.FromArgb(22, 163, 74);
            btnHoanThanh.Enabled = false;
            btnHoanThanh.FlatStyle = FlatStyle.Flat;
            btnHoanThanh.ForeColor = Color.White;
            btnHoanThanh.Location = new Point(241, 6);
            btnHoanThanh.Name = "btnHoanThanh";
            btnHoanThanh.Size = new Size(210, 42);
            btnHoanThanh.TabIndex = 1;
            btnHoanThanh.Text = "Hoàn thành";
            btnHoanThanh.UseVisualStyleBackColor = false;
            btnHoanThanh.Click += btnHoanThanh_Click;
            // 
            // btnBatDau
            // 
            btnBatDau.BackColor = Color.FromArgb(37, 99, 235);
            btnBatDau.Enabled = false;
            btnBatDau.FlatStyle = FlatStyle.Flat;
            btnBatDau.ForeColor = Color.White;
            btnBatDau.Location = new Point(14, 3);
            btnBatDau.Name = "btnBatDau";
            btnBatDau.Size = new Size(210, 42);
            btnBatDau.TabIndex = 0;
            btnBatDau.Text = "Bắt đầu chế biến";
            btnBatDau.UseVisualStyleBackColor = false;
            btnBatDau.Click += btnBatDau_Click;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(8, 0, 0, 0);
            lblTitle.Size = new Size(1080, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý chế biến";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick;
            // 
            // ucCheBien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tblMain);
            Controls.Add(lblTitle);
            Name = "ucCheBien";
            Size = new Size(1080, 630);
            Load += ucCheBien_Load;
            tblMain.ResumeLayout(false);
            tblDem.ResumeLayout(false);
            pnlCho.ResumeLayout(false);
            pnlDang.ResumeLayout(false);
            pnlXong.ResumeLayout(false);
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMon).EndInit();
            tblAct.ResumeLayout(false);
            tblAct.PerformLayout();
            pnlNut.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblTitle;
        private TableLayoutPanel tblDem;
        private Panel pnlCho;
        private Label lblCho;
        private Label lblChoCaption;
        private Panel pnlDang;
        private Label lblDang;
        private Label lblDangCaption;
        private Panel pnlXong;
        private Label lblXong;
        private Label lblXongCaption;
        private Panel pnlLoc;
        private ComboBox cboLoc;
        private Label lblLoc;
        private Button btnLamMoi;
        private Label lblThongBao;
        private DataGridView dgvMon;
        private DataGridViewTextBoxColumn colDonHangID;
        private DataGridViewTextBoxColumn colMonID;
        private DataGridViewTextBoxColumn colMaDon;
        private DataGridViewTextBoxColumn colSoBan;
        private DataGridViewTextBoxColumn colThoiGianTao;
        private DataGridViewTextBoxColumn colTenMon;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colGhiChu;
        private DataGridViewTextBoxColumn colTrangThaiMon;
        private DataGridViewTextBoxColumn colTrangThaiText;
        private TableLayoutPanel tblAct;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Button btnLuuGhiChu;
        private Panel pnlNut;
        private Button btnBatDau;
        private Button btnHoanThanh;
        private System.Windows.Forms.Timer timer1;
    }
}
