namespace QLNhaHang.Controls.Bep
{
    partial class ucThucDon
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tblMain = new TableLayoutPanel();
            lblTitle = new Label();
            pnlLoc = new Panel();
            txtTim = new TextBox();
            lblTim = new Label();
            cboDanhMuc = new ComboBox();
            lblDanhMuc = new Label();
            dgvThucDon = new DataGridView();
            colMonID = new DataGridViewTextBoxColumn();
            colDanhMucID = new DataGridViewTextBoxColumn();
            colTenMon = new DataGridViewTextBoxColumn();
            colTenDanhMuc = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colDonViTinh = new DataGridViewTextBoxColumn();
            colMoTa = new DataGridViewTextBoxColumn();
            colTrangThaiMon = new DataGridViewTextBoxColumn();
            tblMain.SuspendLayout();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThucDon).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblTitle, 0, 0);
            tblMain.Controls.Add(pnlLoc, 0, 1);
            tblMain.Controls.Add(dgvThucDon, 0, 2);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(8);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 3;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 13.0508471F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 86.94915F));
            tblMain.Size = new Size(1080, 630);
            tblMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(8, 0);
            lblTitle.Margin = new Padding(8, 0, 0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1072, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thực đơn";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLoc
            // 
            pnlLoc.Controls.Add(txtTim);
            pnlLoc.Controls.Add(lblTim);
            pnlLoc.Controls.Add(cboDanhMuc);
            pnlLoc.Controls.Add(lblDanhMuc);
            pnlLoc.Dock = DockStyle.Fill;
            pnlLoc.Location = new Point(3, 43);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(1074, 71);
            pnlLoc.TabIndex = 1;
            // 
            // txtTim
            // 
            txtTim.BorderStyle = BorderStyle.None;
            txtTim.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtTim.Location = new Point(483, 25);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(240, 31);
            txtTim.TabIndex = 3;
            txtTim.TextChanged += txtTim_TextChanged;
            // 
            // lblTim
            // 
            lblTim.AutoSize = true;
            lblTim.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTim.Location = new Point(378, 27);
            lblTim.Margin = new Padding(16, 6, 6, 0);
            lblTim.Name = "lblTim";
            lblTim.Size = new Size(101, 28);
            lblTim.TabIndex = 2;
            lblTim.Text = "Tìm món:";
            // 
            // cboDanhMuc
            // 
            cboDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDanhMuc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboDanhMuc.FormattingEnabled = true;
            cboDanhMuc.Location = new Point(136, 20);
            cboDanhMuc.Name = "cboDanhMuc";
            cboDanhMuc.Size = new Size(200, 36);
            cboDanhMuc.TabIndex = 1;
            cboDanhMuc.SelectionChangeCommitted += cboDanhMuc_SelectionChangeCommitted;
            // 
            // lblDanhMuc
            // 
            lblDanhMuc.AutoSize = true;
            lblDanhMuc.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblDanhMuc.Location = new Point(19, 25);
            lblDanhMuc.Margin = new Padding(0, 6, 6, 0);
            lblDanhMuc.Name = "lblDanhMuc";
            lblDanhMuc.Size = new Size(113, 28);
            lblDanhMuc.TabIndex = 0;
            lblDanhMuc.Text = "Danh mục:";
            // 
            // dgvThucDon
            // 
            dgvThucDon.AllowUserToAddRows = false;
            dgvThucDon.AllowUserToDeleteRows = false;
            dgvThucDon.AllowUserToResizeRows = false;
            dgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThucDon.BackgroundColor = Color.White;
            dgvThucDon.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(241, 245, 249);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvThucDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvThucDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThucDon.Columns.AddRange(new DataGridViewColumn[] { colMonID, colDanhMucID, colTenMon, colTenDanhMuc, colDonGia, colDonViTinh, colMoTa, colTrangThaiMon });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvThucDon.DefaultCellStyle = dataGridViewCellStyle3;
            dgvThucDon.Dock = DockStyle.Fill;
            dgvThucDon.EnableHeadersVisualStyles = false;
            dgvThucDon.Location = new Point(3, 120);
            dgvThucDon.MultiSelect = false;
            dgvThucDon.Name = "dgvThucDon";
            dgvThucDon.ReadOnly = true;
            dgvThucDon.RowHeadersVisible = false;
            dgvThucDon.RowHeadersWidth = 51;
            dgvThucDon.RowTemplate.Height = 30;
            dgvThucDon.Size = new Size(1074, 507);
            dgvThucDon.TabIndex = 2;
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
            // colDanhMucID
            // 
            colDanhMucID.DataPropertyName = "DanhMucID";
            colDanhMucID.HeaderText = "";
            colDanhMucID.MinimumWidth = 6;
            colDanhMucID.Name = "colDanhMucID";
            colDanhMucID.ReadOnly = true;
            colDanhMucID.Visible = false;
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
            // colTenDanhMuc
            // 
            colTenDanhMuc.DataPropertyName = "TenDanhMuc";
            colTenDanhMuc.FillWeight = 120F;
            colTenDanhMuc.HeaderText = "Danh mục";
            colTenDanhMuc.MinimumWidth = 6;
            colTenDanhMuc.Name = "colTenDanhMuc";
            colTenDanhMuc.ReadOnly = true;
            // 
            // colDonGia
            // 
            colDonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            colDonGia.DefaultCellStyle = dataGridViewCellStyle2;
            colDonGia.FillWeight = 80F;
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.MinimumWidth = 6;
            colDonGia.Name = "colDonGia";
            colDonGia.ReadOnly = true;
            // 
            // colDonViTinh
            // 
            colDonViTinh.DataPropertyName = "DonViTinh";
            colDonViTinh.FillWeight = 60F;
            colDonViTinh.HeaderText = "ĐVT";
            colDonViTinh.MinimumWidth = 6;
            colDonViTinh.Name = "colDonViTinh";
            colDonViTinh.ReadOnly = true;
            // 
            // colMoTa
            // 
            colMoTa.DataPropertyName = "MoTa";
            colMoTa.FillWeight = 220F;
            colMoTa.HeaderText = "Mô tả";
            colMoTa.MinimumWidth = 6;
            colMoTa.Name = "colMoTa";
            colMoTa.ReadOnly = true;
            // 
            // colTrangThaiMon
            // 
            colTrangThaiMon.DataPropertyName = "TrangThaiMon";
            colTrangThaiMon.FillWeight = 110F;
            colTrangThaiMon.HeaderText = "Trạng thái";
            colTrangThaiMon.MinimumWidth = 6;
            colTrangThaiMon.Name = "colTrangThaiMon";
            colTrangThaiMon.ReadOnly = true;
            // 
            // ucThucDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tblMain);
            Name = "ucThucDon";
            Size = new Size(1080, 630);
            Load += ucThucDon_Load;
            VisibleChanged += ucThucDon_VisibleChanged;
            tblMain.ResumeLayout(false);
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThucDon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblTitle;
        private Panel pnlLoc;
        private ComboBox cboDanhMuc;
        private Label lblDanhMuc;
        private TextBox txtTim;
        private Label lblTim;
        private DataGridView dgvThucDon;
        private DataGridViewTextBoxColumn colMonID;
        private DataGridViewTextBoxColumn colDanhMucID;
        private DataGridViewTextBoxColumn colTenMon;
        private DataGridViewTextBoxColumn colTenDanhMuc;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colDonViTinh;
        private DataGridViewTextBoxColumn colMoTa;
        private DataGridViewTextBoxColumn colTrangThaiMon;
    }
}
