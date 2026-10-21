namespace QLNhaHang.Controls.Bep
{
    partial class ucNguyenLieu
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
            dgvNL = new DataGridView();
            colNguyenLieuID = new DataGridViewTextBoxColumn();
            colTenNguyeLieu = new DataGridViewTextBoxColumn();
            colDonViTinh = new DataGridViewTextBoxColumn();
            colSoLuongTon = new DataGridViewTextBoxColumn();
            colMucCanhBao = new DataGridViewTextBoxColumn();
            colHanSuDung = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            lblChuThich = new Label();
            pnlEdit = new Panel();
            btnLuuNL = new Button();
            dtpHan = new DateTimePicker();
            lblHan = new Label();
            nudCanhBao = new NumericUpDown();
            lblCanhBao = new Label();
            nudTon = new NumericUpDown();
            lblTon = new Label();
            txtTenNL = new TextBox();
            lblTenNL = new Label();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNL).BeginInit();
            pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCanhBao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTon).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblTitle, 0, 0);
            tblMain.Controls.Add(dgvNL, 0, 1);
            tblMain.Controls.Add(lblChuThich, 0, 2);
            tblMain.Controls.Add(pnlEdit, 0, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(8);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
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
            lblTitle.Text = "Nguyên liệu";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvNL
            // 
            dgvNL.AllowUserToAddRows = false;
            dgvNL.AllowUserToDeleteRows = false;
            dgvNL.AllowUserToResizeRows = false;
            dgvNL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNL.BackgroundColor = Color.White;
            dgvNL.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(241, 245, 249);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNL.Columns.AddRange(new DataGridViewColumn[] { colNguyenLieuID, colTenNguyeLieu, colDonViTinh, colSoLuongTon, colMucCanhBao, colHanSuDung, colTrangThai });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvNL.DefaultCellStyle = dataGridViewCellStyle3;
            dgvNL.Dock = DockStyle.Fill;
            dgvNL.EnableHeadersVisualStyles = false;
            dgvNL.Location = new Point(3, 46);
            dgvNL.MultiSelect = false;
            dgvNL.Name = "dgvNL";
            dgvNL.ReadOnly = true;
            dgvNL.RowHeadersVisible = false;
            dgvNL.RowHeadersWidth = 51;
            dgvNL.RowTemplate.Height = 31;
            dgvNL.Size = new Size(1074, 424);
            dgvNL.TabIndex = 1;
            dgvNL.DataBindingComplete += dgvNL_DataBindingComplete;
            dgvNL.SelectionChanged += dgvNL_SelectionChanged;
            // 
            // colNguyenLieuID
            // 
            colNguyenLieuID.DataPropertyName = "NguyenLieuID";
            colNguyenLieuID.HeaderText = "";
            colNguyenLieuID.MinimumWidth = 6;
            colNguyenLieuID.Name = "colNguyenLieuID";
            colNguyenLieuID.ReadOnly = true;
            colNguyenLieuID.Visible = false;
            // 
            // colTenNguyeLieu
            // 
            colTenNguyeLieu.DataPropertyName = "TenNguyenLieu";
            colTenNguyeLieu.FillWeight = 180F;
            colTenNguyeLieu.HeaderText = "Nguyên liệu";
            colTenNguyeLieu.MinimumWidth = 6;
            colTenNguyeLieu.Name = "colTenNguyeLieu";
            colTenNguyeLieu.ReadOnly = true;
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
            // colSoLuongTon
            // 
            colSoLuongTon.DataPropertyName = "SoLuongTon";
            colSoLuongTon.FillWeight = 80F;
            colSoLuongTon.HeaderText = "Tồn kho";
            colSoLuongTon.MinimumWidth = 6;
            colSoLuongTon.Name = "colSoLuongTon";
            colSoLuongTon.ReadOnly = true;
            // 
            // colMucCanhBao
            // 
            colMucCanhBao.DataPropertyName = "MucCanhBao";
            colMucCanhBao.FillWeight = 80F;
            colMucCanhBao.HeaderText = "Mức cảnh báo";
            colMucCanhBao.MinimumWidth = 6;
            colMucCanhBao.Name = "colMucCanhBao";
            colMucCanhBao.ReadOnly = true;
            // 
            // colHanSuDung
            // 
            colHanSuDung.DataPropertyName = "HanSuDung";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            dataGridViewCellStyle2.NullValue = null;
            colHanSuDung.DefaultCellStyle = dataGridViewCellStyle2;
            colHanSuDung.FillWeight = 90F;
            colHanSuDung.HeaderText = "Hạn sử dụng";
            colHanSuDung.MinimumWidth = 6;
            colHanSuDung.Name = "colHanSuDung";
            colHanSuDung.ReadOnly = true;
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.FillWeight = 80F;
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            // 
            // lblChuThich
            // 
            lblChuThich.BackColor = Color.White;
            lblChuThich.Dock = DockStyle.Fill;
            lblChuThich.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblChuThich.ForeColor = Color.DimGray;
            lblChuThich.Location = new Point(3, 473);
            lblChuThich.Name = "lblChuThich";
            lblChuThich.Size = new Size(1074, 28);
            lblChuThich.TabIndex = 2;
            lblChuThich.Text = "Đỏ: tồn kho ≤ mức cảnh báo      Cam: hết hạn hoặc hạn dùng trong 7 ngày tới";
            // 
            // pnlEdit
            // 
            pnlEdit.BackColor = SystemColors.Control;
            pnlEdit.Controls.Add(btnLuuNL);
            pnlEdit.Controls.Add(dtpHan);
            pnlEdit.Controls.Add(lblHan);
            pnlEdit.Controls.Add(nudCanhBao);
            pnlEdit.Controls.Add(lblCanhBao);
            pnlEdit.Controls.Add(nudTon);
            pnlEdit.Controls.Add(lblTon);
            pnlEdit.Controls.Add(txtTenNL);
            pnlEdit.Controls.Add(lblTenNL);
            pnlEdit.Dock = DockStyle.Fill;
            pnlEdit.Location = new Point(3, 504);
            pnlEdit.Name = "pnlEdit";
            pnlEdit.Size = new Size(1074, 123);
            pnlEdit.TabIndex = 3;
            // 
            // btnLuuNL
            // 
            btnLuuNL.BackColor = Color.SeaGreen;
            btnLuuNL.Enabled = false;
            btnLuuNL.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnLuuNL.ForeColor = Color.White;
            btnLuuNL.Location = new Point(891, 38);
            btnLuuNL.Name = "btnLuuNL";
            btnLuuNL.Size = new Size(105, 44);
            btnLuuNL.TabIndex = 8;
            btnLuuNL.Text = "Lưu";
            btnLuuNL.UseVisualStyleBackColor = false;
            btnLuuNL.Click += btnLuuNL_Click;
            // 
            // dtpHan
            // 
            dtpHan.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dtpHan.Format = DateTimePickerFormat.Short;
            dtpHan.Location = new Point(591, 70);
            dtpHan.Name = "dtpHan";
            dtpHan.ShowCheckBox = true;
            dtpHan.Size = new Size(226, 30);
            dtpHan.TabIndex = 7;
            // 
            // lblHan
            // 
            lblHan.AutoSize = true;
            lblHan.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblHan.Location = new Point(439, 74);
            lblHan.Margin = new Padding(10, 6, 4, 0);
            lblHan.Name = "lblHan";
            lblHan.Size = new Size(94, 23);
            lblHan.TabIndex = 6;
            lblHan.Text = "Hạn dùng:";
            // 
            // nudCanhBao
            // 
            nudCanhBao.DecimalPlaces = 2;
            nudCanhBao.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            nudCanhBao.Location = new Point(591, 19);
            nudCanhBao.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudCanhBao.Name = "nudCanhBao";
            nudCanhBao.Size = new Size(226, 30);
            nudCanhBao.TabIndex = 5;
            // 
            // lblCanhBao
            // 
            lblCanhBao.AutoSize = true;
            lblCanhBao.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblCanhBao.Location = new Point(439, 21);
            lblCanhBao.Margin = new Padding(10, 6, 4, 0);
            lblCanhBao.Name = "lblCanhBao";
            lblCanhBao.Size = new Size(127, 23);
            lblCanhBao.TabIndex = 4;
            lblCanhBao.Text = "Mức cảnh báo:";
            // 
            // nudTon
            // 
            nudTon.DecimalPlaces = 2;
            nudTon.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            nudTon.Location = new Point(169, 74);
            nudTon.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudTon.Name = "nudTon";
            nudTon.Size = new Size(234, 30);
            nudTon.TabIndex = 3;
            // 
            // lblTon
            // 
            lblTon.AutoSize = true;
            lblTon.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTon.Location = new Point(46, 74);
            lblTon.Margin = new Padding(10, 6, 4, 0);
            lblTon.Name = "lblTon";
            lblTon.Size = new Size(45, 23);
            lblTon.TabIndex = 2;
            lblTon.Text = "Tồn:";
            // 
            // txtTenNL
            // 
            txtTenNL.BackColor = Color.White;
            txtTenNL.BorderStyle = BorderStyle.None;
            txtTenNL.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtTenNL.Location = new Point(169, 18);
            txtTenNL.Name = "txtTenNL";
            txtTenNL.ReadOnly = true;
            txtTenNL.Size = new Size(234, 31);
            txtTenNL.TabIndex = 1;
            // 
            // lblTenNL
            // 
            lblTenNL.AutoSize = true;
            lblTenNL.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTenNL.Location = new Point(46, 20);
            lblTenNL.Margin = new Padding(0, 6, 4, 0);
            lblTenNL.Name = "lblTenNL";
            lblTenNL.Size = new Size(111, 23);
            lblTenNL.TabIndex = 0;
            lblTenNL.Text = "Nguyên liệu:";
            // 
            // ucNguyenLieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tblMain);
            Name = "ucNguyenLieu";
            Size = new Size(1080, 630);
            Load += ucNguyenLieu_Load;
            VisibleChanged += ucNguyenLieu_VisibleChanged;
            tblMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNL).EndInit();
            pnlEdit.ResumeLayout(false);
            pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCanhBao).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblTitle;
        private DataGridView dgvNL;
        private DataGridViewTextBoxColumn colNguyenLieuID;
        private DataGridViewTextBoxColumn colTenNguyeLieu;
        private DataGridViewTextBoxColumn colDonViTinh;
        private DataGridViewTextBoxColumn colSoLuongTon;
        private DataGridViewTextBoxColumn colMucCanhBao;
        private DataGridViewTextBoxColumn colHanSuDung;
        private DataGridViewTextBoxColumn colTrangThai;
        private Label lblChuThich;
        private Panel pnlEdit;
        private Label lblTenNL;
        private NumericUpDown nudTon;
        private Label lblTon;
        private TextBox txtTenNL;
        private Label lblCanhBao;
        private Button btnLuuNL;
        private DateTimePicker dtpHan;
        private Label lblHan;
        private NumericUpDown nudCanhBao;
    }
}
