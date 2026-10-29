using QLNhaHang.Classes;
namespace QLNhaHang.Controls.Bep
{
    partial class ucTongQuan
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tblMain = new TableLayoutPanel();
            lblTieuDe = new Label();
            lblCapNhat = new Label();
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
            pnlNguyenLieu = new Panel();
            lblNguyenLieuCaption = new Label();
            lblNguyenLieu = new Label();
            lblBangCho = new Label();
            lblBangNL = new Label();
            dgvCho = new DataGridView();
            colMaDon = new DataGridViewTextBoxColumn();
            colSoBan = new DataGridViewTextBoxColumn();
            colTenMon = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colPhutCho = new DataGridViewTextBoxColumn();
            dgvNL = new DataGridView();
            colTenNguyenLieu = new DataGridViewTextBoxColumn();
            colDonViTinh = new DataGridViewTextBoxColumn();
            colSoLuongTon = new DataGridViewTextBoxColumn();
            colMucCanhBao = new DataGridViewTextBoxColumn();
            colHanSuDung = new DataGridViewTextBoxColumn();
            colLyDo = new DataGridViewTextBoxColumn();
            timer1 = new System.Windows.Forms.Timer(components);
            tblMain.SuspendLayout();
            tblDem.SuspendLayout();
            pnlCho.SuspendLayout();
            pnlDang.SuspendLayout();
            pnlXong.SuspendLayout();
            pnlNguyenLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCho).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNL).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lblTieuDe, 0, 0);
            tblMain.Controls.Add(lblCapNhat, 1, 0);
            tblMain.Controls.Add(tblDem, 0, 1);
            tblMain.Controls.Add(lblBangCho, 0, 2);
            tblMain.Controls.Add(lblBangNL, 1, 2);
            tblMain.Controls.Add(dgvCho, 0, 3);
            tblMain.Controls.Add(dgvNL, 1, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.Padding = new Padding(8);
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(1378, 642);
            tblMain.TabIndex = 1;
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDe.Location = new Point(11, 8);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(675, 40);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Tổng Quan";
            lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapNhat
            // 
            lblCapNhat.Dock = DockStyle.Fill;
            lblCapNhat.ForeColor = Theme.TextMuted;
            lblCapNhat.Location = new Point(692, 8);
            lblCapNhat.Name = "lblCapNhat";
            lblCapNhat.Size = new Size(675, 40);
            lblCapNhat.TabIndex = 1;
            lblCapNhat.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tblDem
            // 
            tblDem.ColumnCount = 4;
            tblMain.SetColumnSpan(tblDem, 2);
            tblDem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblDem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblDem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblDem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblDem.Controls.Add(pnlCho, 0, 0);
            tblDem.Controls.Add(pnlDang, 1, 0);
            tblDem.Controls.Add(pnlXong, 2, 0);
            tblDem.Controls.Add(pnlNguyenLieu, 3, 0);
            tblDem.Dock = DockStyle.Fill;
            tblDem.Location = new Point(11, 51);
            tblDem.Name = "tblDem";
            tblDem.RowCount = 1;
            tblDem.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblDem.Size = new Size(1356, 78);
            tblDem.TabIndex = 2;
            // 
            // pnlCho
            // 
            pnlCho.BackColor = Theme.Surface;
            pnlCho.Controls.Add(lblChoCaption);
            pnlCho.Controls.Add(lblCho);
            pnlCho.Dock = DockStyle.Fill;
            pnlCho.Location = new Point(4, 4);
            pnlCho.Margin = new Padding(4);
            pnlCho.Name = "pnlCho";
            pnlCho.Size = new Size(331, 70);
            pnlCho.TabIndex = 0;
            // 
            // lblChoCaption
            // 
            lblChoCaption.Dock = DockStyle.Fill;
            lblChoCaption.ForeColor = Theme.TextMuted;
            lblChoCaption.Location = new Point(0, 46);
            lblChoCaption.Name = "lblChoCaption";
            lblChoCaption.Size = new Size(331, 24);
            lblChoCaption.TabIndex = 1;
            lblChoCaption.Text = "Chờ chế biến";
            lblChoCaption.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCho
            // 
            lblCho.Dock = DockStyle.Top;
            lblCho.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblCho.ForeColor = Theme.Orange;
            lblCho.Location = new Point(0, 0);
            lblCho.Name = "lblCho";
            lblCho.Size = new Size(331, 46);
            lblCho.TabIndex = 0;
            lblCho.Text = "00";
            lblCho.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDang
            // 
            pnlDang.BackColor = Theme.Surface;
            pnlDang.Controls.Add(lblDangCaption);
            pnlDang.Controls.Add(lblDang);
            pnlDang.Dock = DockStyle.Fill;
            pnlDang.Location = new Point(343, 4);
            pnlDang.Margin = new Padding(4);
            pnlDang.Name = "pnlDang";
            pnlDang.Size = new Size(331, 70);
            pnlDang.TabIndex = 1;
            // 
            // lblDangCaption
            // 
            lblDangCaption.Dock = DockStyle.Fill;
            lblDangCaption.ForeColor = Theme.TextMuted;
            lblDangCaption.Location = new Point(0, 46);
            lblDangCaption.Name = "lblDangCaption";
            lblDangCaption.Size = new Size(331, 24);
            lblDangCaption.TabIndex = 1;
            lblDangCaption.Text = "Đang làm";
            lblDangCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDang
            // 
            lblDang.Dock = DockStyle.Top;
            lblDang.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblDang.ForeColor = Theme.Blue;
            lblDang.Location = new Point(0, 0);
            lblDang.Name = "lblDang";
            lblDang.Size = new Size(331, 46);
            lblDang.TabIndex = 0;
            lblDang.Text = "00";
            lblDang.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlXong
            // 
            pnlXong.BackColor = Theme.Surface;
            pnlXong.Controls.Add(lblXongCaption);
            pnlXong.Controls.Add(lblXong);
            pnlXong.Dock = DockStyle.Fill;
            pnlXong.Location = new Point(682, 4);
            pnlXong.Margin = new Padding(4);
            pnlXong.Name = "pnlXong";
            pnlXong.Size = new Size(331, 70);
            pnlXong.TabIndex = 2;
            // 
            // lblXongCaption
            // 
            lblXongCaption.Dock = DockStyle.Fill;
            lblXongCaption.ForeColor = Theme.TextMuted;
            lblXongCaption.Location = new Point(0, 46);
            lblXongCaption.Name = "lblXongCaption";
            lblXongCaption.Size = new Size(331, 24);
            lblXongCaption.TabIndex = 1;
            lblXongCaption.Text = "Hoàn thành (chờ phục vụ)";
            lblXongCaption.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblXong
            // 
            lblXong.Dock = DockStyle.Top;
            lblXong.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblXong.ForeColor = Theme.Green;
            lblXong.Location = new Point(0, 0);
            lblXong.Name = "lblXong";
            lblXong.Size = new Size(331, 46);
            lblXong.TabIndex = 0;
            lblXong.Text = "00";
            lblXong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlNguyenLieu
            // 
            pnlNguyenLieu.BackColor = Theme.Surface;
            pnlNguyenLieu.Controls.Add(lblNguyenLieuCaption);
            pnlNguyenLieu.Controls.Add(lblNguyenLieu);
            pnlNguyenLieu.Dock = DockStyle.Fill;
            pnlNguyenLieu.Location = new Point(1021, 4);
            pnlNguyenLieu.Margin = new Padding(4);
            pnlNguyenLieu.Name = "pnlNguyenLieu";
            pnlNguyenLieu.Size = new Size(331, 70);
            pnlNguyenLieu.TabIndex = 3;
            // 
            // lblNguyenLieuCaption
            // 
            lblNguyenLieuCaption.Dock = DockStyle.Fill;
            lblNguyenLieuCaption.ForeColor = Theme.TextMuted;
            lblNguyenLieuCaption.Location = new Point(0, 46);
            lblNguyenLieuCaption.Name = "lblNguyenLieuCaption";
            lblNguyenLieuCaption.Size = new Size(331, 24);
            lblNguyenLieuCaption.TabIndex = 1;
            lblNguyenLieuCaption.Text = "Nguyên liệu cần chú ý";
            lblNguyenLieuCaption.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNguyenLieu
            // 
            lblNguyenLieu.Dock = DockStyle.Top;
            lblNguyenLieu.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblNguyenLieu.ForeColor = Theme.Danger;
            lblNguyenLieu.Location = new Point(0, 0);
            lblNguyenLieu.Name = "lblNguyenLieu";
            lblNguyenLieu.Size = new Size(331, 46);
            lblNguyenLieu.TabIndex = 0;
            lblNguyenLieu.Text = "00";
            lblNguyenLieu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBangCho
            // 
            lblBangCho.Dock = DockStyle.Fill;
            lblBangCho.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblBangCho.Location = new Point(11, 132);
            lblBangCho.Name = "lblBangCho";
            lblBangCho.Size = new Size(675, 30);
            lblBangCho.TabIndex = 3;
            lblBangCho.Text = "Món chờ chề biến lâu nhất";
            lblBangCho.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblBangNL
            // 
            lblBangNL.Dock = DockStyle.Fill;
            lblBangNL.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblBangNL.Location = new Point(692, 132);
            lblBangNL.Name = "lblBangNL";
            lblBangNL.Size = new Size(675, 30);
            lblBangNL.TabIndex = 4;
            lblBangNL.Text = "Nguyên liệu sắp hết / sắp hết hạn";
            lblBangNL.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dgvCho
            // 
            dgvCho.AllowUserToAddRows = false;
            dgvCho.AllowUserToDeleteRows = false;
            dgvCho.AllowUserToResizeRows = false;
            dgvCho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCho.BackgroundColor = Theme.Surface;
            dgvCho.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.BackColor = Theme.Background;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvCho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCho.Columns.AddRange(new DataGridViewColumn[] { colMaDon, colSoBan, colTenMon, colSoLuong, colPhutCho });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Theme.BlueBold;
            dataGridViewCellStyle2.SelectionForeColor = Theme.Surface;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCho.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCho.Dock = DockStyle.Fill;
            dgvCho.EnableHeadersVisualStyles = false;
            dgvCho.Location = new Point(8, 166);
            dgvCho.Margin = new Padding(0, 4, 6, 0);
            dgvCho.MultiSelect = false;
            dgvCho.Name = "dgvCho";
            dgvCho.ReadOnly = true;
            dgvCho.RowHeadersVisible = false;
            dgvCho.RowHeadersWidth = 51;
            dgvCho.RowTemplate.Height = 30;
            dgvCho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCho.Size = new Size(675, 468);
            dgvCho.TabIndex = 5;
            dgvCho.DataBindingComplete += dgvCho_DataBindingComplete;
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
            colSoBan.FillWeight = 45F;
            colSoBan.HeaderText = "Bàn";
            colSoBan.MinimumWidth = 6;
            colSoBan.Name = "colSoBan";
            colSoBan.ReadOnly = true;
            // 
            // colTenMon
            // 
            colTenMon.DataPropertyName = "TenMon";
            colTenMon.FillWeight = 150F;
            colTenMon.HeaderText = "Tên món";
            colTenMon.MinimumWidth = 6;
            colTenMon.Name = "colTenMon";
            colTenMon.ReadOnly = true;
            // 
            // colSoLuong
            // 
            colSoLuong.DataPropertyName = "SoLuong";
            colSoLuong.FillWeight = 35F;
            colSoLuong.HeaderText = "SL";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            colSoLuong.ReadOnly = true;
            // 
            // colPhutCho
            // 
            colPhutCho.DataPropertyName = "PhutCho";
            colPhutCho.FillWeight = 70F;
            colPhutCho.HeaderText = "Chờ (phút)";
            colPhutCho.MinimumWidth = 6;
            colPhutCho.Name = "colPhutCho";
            colPhutCho.ReadOnly = true;
            // 
            // dgvNL
            // 
            dgvNL.AllowUserToAddRows = false;
            dgvNL.AllowUserToDeleteRows = false;
            dgvNL.AllowUserToResizeRows = false;
            dgvNL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNL.BackgroundColor = Theme.Surface;
            dgvNL.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Theme.Background;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvNL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvNL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNL.Columns.AddRange(new DataGridViewColumn[] { colTenNguyenLieu, colDonViTinh, colSoLuongTon, colMucCanhBao, colHanSuDung, colLyDo });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Theme.BlueBold;
            dataGridViewCellStyle5.SelectionForeColor = Theme.Surface;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvNL.DefaultCellStyle = dataGridViewCellStyle5;
            dgvNL.Dock = DockStyle.Fill;
            dgvNL.EnableHeadersVisualStyles = false;
            dgvNL.Location = new Point(695, 166);
            dgvNL.Margin = new Padding(6, 4, 0, 0);
            dgvNL.MultiSelect = false;
            dgvNL.Name = "dgvNL";
            dgvNL.ReadOnly = true;
            dgvNL.RowHeadersVisible = false;
            dgvNL.RowHeadersWidth = 51;
            dgvNL.RowTemplate.Height = 30;
            dgvNL.Size = new Size(675, 468);
            dgvNL.TabIndex = 6;
            dgvNL.DataBindingComplete += dgvNL_DataBindingComplete;
            // 
            // colTenNguyenLieu
            // 
            colTenNguyenLieu.DataPropertyName = "TenNguyenLieu";
            colTenNguyenLieu.FillWeight = 150F;
            colTenNguyenLieu.HeaderText = "Nguyên liệu";
            colTenNguyenLieu.MinimumWidth = 6;
            colTenNguyenLieu.Name = "colTenNguyenLieu";
            colTenNguyenLieu.ReadOnly = true;
            // 
            // colDonViTinh
            // 
            colDonViTinh.DataPropertyName = "DonViTinh";
            colDonViTinh.FillWeight = 45F;
            colDonViTinh.HeaderText = "ĐVT";
            colDonViTinh.MinimumWidth = 6;
            colDonViTinh.Name = "colDonViTinh";
            colDonViTinh.ReadOnly = true;
            // 
            // colSoLuongTon
            // 
            colSoLuongTon.DataPropertyName = "SoLuongTon";
            colSoLuongTon.FillWeight = 55F;
            colSoLuongTon.HeaderText = "Tồn";
            colSoLuongTon.MinimumWidth = 6;
            colSoLuongTon.Name = "colSoLuongTon";
            colSoLuongTon.ReadOnly = true;
            // 
            // colMucCanhBao
            // 
            colMucCanhBao.DataPropertyName = "MucCanhBao";
            colMucCanhBao.FillWeight = 65F;
            colMucCanhBao.HeaderText = "Cảnh báo";
            colMucCanhBao.MinimumWidth = 6;
            colMucCanhBao.Name = "colMucCanhBao";
            colMucCanhBao.ReadOnly = true;
            // 
            // colHanSuDung
            // 
            colHanSuDung.DataPropertyName = "HanSuDung";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            dataGridViewCellStyle4.NullValue = null;
            colHanSuDung.DefaultCellStyle = dataGridViewCellStyle4;
            colHanSuDung.FillWeight = 85F;
            colHanSuDung.HeaderText = "Hạn dùng";
            colHanSuDung.MinimumWidth = 6;
            colHanSuDung.Name = "colHanSuDung";
            colHanSuDung.ReadOnly = true;
            // 
            // colLyDo
            // 
            colLyDo.DataPropertyName = "LyDo";
            colLyDo.FillWeight = 85F;
            colLyDo.HeaderText = "Lý do";
            colLyDo.MinimumWidth = 6;
            colLyDo.Name = "colLyDo";
            colLyDo.ReadOnly = true;
            // 
            // timer1
            // 
            timer1.Interval = 10000;
            timer1.Tick += timer1_Tick;
            // 
            // ucTongQuan
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 10F);
            BackColor = QLNhaHang.Classes.Theme.Background;
            ForeColor = QLNhaHang.Classes.Theme.Black;
            Name = "ucTongQuan";
            Size = new Size(1378, 642);
            Load += ucTongQuan_Load;
            VisibleChanged += ucTongQuan_VisibleChanged;
            tblMain.ResumeLayout(false);
            tblDem.ResumeLayout(false);
            pnlCho.ResumeLayout(false);
            pnlDang.ResumeLayout(false);
            pnlXong.ResumeLayout(false);
            pnlNguyenLieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCho).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNL).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblTieuDe;
        private Label lblCapNhat;
        private TableLayoutPanel tblDem;
        private Label lblBangCho;
        private Label lblBangNL;
        private DataGridView dgvCho;
        private DataGridView dgvNL;
        private Panel pnlCho;
        private Panel pnlDang;
        private Panel pnlXong;
        private Panel pnlNguyenLieu;
        private Label lblChoCaption;
        private Label lblCho;
        private Label lblDang;
        private Label lblDangCaption;
        private Label lblXong;
        private Label lblXongCaption;
        private Label lblNguyenLieu;
        private Label lblNguyenLieuCaption;
        private DataGridViewTextBoxColumn colMaDon;
        private DataGridViewTextBoxColumn colSoBan;
        private DataGridViewTextBoxColumn colTenMon;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colPhutCho;
        private DataGridViewTextBoxColumn colTenNguyenLieu;
        private DataGridViewTextBoxColumn colDonViTinh;
        private DataGridViewTextBoxColumn colSoLuongTon;
        private DataGridViewTextBoxColumn colMucCanhBao;
        private DataGridViewTextBoxColumn colHanSuDung;
        private DataGridViewTextBoxColumn colLyDo;
        private System.Windows.Forms.Timer timer1;
    }
}
