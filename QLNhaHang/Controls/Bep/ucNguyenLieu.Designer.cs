using QLNhaHang.Classes;
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
            colTenNguyeLieu = new DataGridViewTextBoxColumn();
            colDonViTinh = new DataGridViewTextBoxColumn();
            colSoLuongTon = new DataGridViewTextBoxColumn();
            colMucCanhBao = new DataGridViewTextBoxColumn();
            colHanSuDung = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            lblChuThich = new Label();
            pnlEdit = new Panel();
            btnThemNL = new Button();
            lblDvtCanhBao = new Label();
            lblDvtTon = new Label();
            lblDonVi = new Label();
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
            tblMain.Margin = new Padding(10, 10, 10, 10);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tblMain.Size = new Size(1350, 788);
            tblMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 0);
            lblTitle.Margin = new Padding(10, 0, 0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1340, 50);
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
            dgvNL.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvNL.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(244, 247, 251);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNL.Columns.AddRange(new DataGridViewColumn[] { colTenNguyeLieu, colDonViTinh, colSoLuongTon, colMucCanhBao, colHanSuDung, colTrangThai });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(23, 38, 62);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(23, 38, 62);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvNL.DefaultCellStyle = dataGridViewCellStyle3;
            dgvNL.Dock = DockStyle.Fill;
            dgvNL.EnableHeadersVisualStyles = false;
            dgvNL.Location = new Point(4, 57);
            dgvNL.Margin = new Padding(4, 4, 4, 4);
            dgvNL.MultiSelect = false;
            dgvNL.Name = "dgvNL";
            dgvNL.ReadOnly = true;
            dgvNL.RowHeadersVisible = false;
            dgvNL.RowHeadersWidth = 51;
            dgvNL.RowTemplate.Height = 31;
            dgvNL.Size = new Size(1342, 529);
            dgvNL.TabIndex = 1;
            dgvNL.DataBindingComplete += dgvNL_DataBindingComplete;
            dgvNL.SelectionChanged += dgvNL_SelectionChanged;
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
            lblChuThich.BackColor = Color.FromArgb(255, 255, 255);
            lblChuThich.Dock = DockStyle.Fill;
            lblChuThich.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblChuThich.ForeColor = Color.FromArgb(100, 116, 139);
            lblChuThich.Location = new Point(4, 590);
            lblChuThich.Margin = new Padding(4, 0, 4, 0);
            lblChuThich.Name = "lblChuThich";
            lblChuThich.Size = new Size(1342, 35);
            lblChuThich.TabIndex = 2;
            lblChuThich.Text = "Đỏ: tồn kho ≤ mức cảnh báo      Cam: hết hạn hoặc hạn dùng trong 7 ngày tới";
            // 
            // pnlEdit
            // 
            pnlEdit.AutoScroll = true;
            pnlEdit.AutoScrollMinSize = new Size(1050, 0);
            pnlEdit.BackColor = SystemColors.Control;
            pnlEdit.Controls.Add(btnThemNL);
            pnlEdit.Controls.Add(lblDvtCanhBao);
            pnlEdit.Controls.Add(lblDvtTon);
            pnlEdit.Controls.Add(lblDonVi);
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
            pnlEdit.Location = new Point(4, 629);
            pnlEdit.Margin = new Padding(4, 4, 4, 4);
            pnlEdit.Name = "pnlEdit";
            pnlEdit.Size = new Size(1342, 155);
            pnlEdit.TabIndex = 3;
            // 
            // btnThemNL
            // 
            btnThemNL.BackColor = Color.FromArgb(37, 99, 235);
            btnThemNL.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnThemNL.ForeColor = Color.White;
            btnThemNL.Location = new Point(1169, 48);
            btnThemNL.Margin = new Padding(4, 4, 4, 4);
            btnThemNL.Name = "btnThemNL";
            btnThemNL.Size = new Size(230, 55);
            btnThemNL.TabIndex = 12;
            btnThemNL.Text = "Thêm nguyên liệu";
            btnThemNL.UseVisualStyleBackColor = false;
            btnThemNL.Click += btnThemNL_Click;
            // 
            // lblDvtCanhBao
            // 
            lblDvtCanhBao.AutoSize = true;
            lblDvtCanhBao.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblDvtCanhBao.Location = new Point(925, 26);
            lblDvtCanhBao.Margin = new Padding(0, 8, 0, 0);
            lblDvtCanhBao.Name = "lblDvtCanhBao";
            lblDvtCanhBao.Size = new Size(54, 30);
            lblDvtCanhBao.TabIndex = 11;
            lblDvtCanhBao.Text = "ĐVT";
            // 
            // lblDvtTon
            // 
            lblDvtTon.AutoSize = true;
            lblDvtTon.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblDvtTon.Location = new Point(449, 96);
            lblDvtTon.Margin = new Padding(0, 8, 0, 0);
            lblDvtTon.Name = "lblDvtTon";
            lblDvtTon.Size = new Size(54, 30);
            lblDvtTon.TabIndex = 10;
            lblDvtTon.Text = "ĐVT";
            // 
            // lblDonVi
            // 
            lblDonVi.AutoSize = true;
            lblDonVi.Location = new Point(454, 98);
            lblDonVi.Margin = new Padding(4, 0, 4, 0);
            lblDonVi.Name = "lblDonVi";
            lblDonVi.Size = new Size(0, 25);
            lblDonVi.TabIndex = 9;
            // 
            // btnLuuNL
            // 
            btnLuuNL.BackColor = Color.FromArgb(21, 128, 61);
            btnLuuNL.Enabled = false;
            btnLuuNL.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnLuuNL.ForeColor = Color.FromArgb(255, 255, 255);
            btnLuuNL.Location = new Point(1018, 48);
            btnLuuNL.Margin = new Padding(4, 4, 4, 4);
            btnLuuNL.Name = "btnLuuNL";
            btnLuuNL.Size = new Size(131, 55);
            btnLuuNL.TabIndex = 8;
            btnLuuNL.Text = "Lưu";
            btnLuuNL.UseVisualStyleBackColor = false;
            btnLuuNL.Click += btnLuuNL_Click;
            // 
            // dtpHan
            // 
            dtpHan.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dtpHan.Format = DateTimePickerFormat.Short;
            dtpHan.Location = new Point(698, 85);
            dtpHan.Margin = new Padding(4, 4, 4, 4);
            dtpHan.Name = "dtpHan";
            dtpHan.ShowCheckBox = true;
            dtpHan.Size = new Size(282, 35);
            dtpHan.TabIndex = 7;
            // 
            // lblHan
            // 
            lblHan.AutoSize = true;
            lblHan.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblHan.Location = new Point(530, 94);
            lblHan.Margin = new Padding(12, 8, 5, 0);
            lblHan.Name = "lblHan";
            lblHan.Size = new Size(117, 30);
            lblHan.TabIndex = 6;
            lblHan.Text = "Hạn dùng:";
            // 
            // nudCanhBao
            // 
            nudCanhBao.DecimalPlaces = 2;
            nudCanhBao.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            nudCanhBao.Location = new Point(698, 24);
            nudCanhBao.Margin = new Padding(4, 4, 4, 4);
            nudCanhBao.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudCanhBao.Name = "nudCanhBao";
            nudCanhBao.Size = new Size(210, 35);
            nudCanhBao.TabIndex = 5;
            // 
            // lblCanhBao
            // 
            lblCanhBao.AutoSize = true;
            lblCanhBao.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblCanhBao.Location = new Point(530, 26);
            lblCanhBao.Margin = new Padding(12, 8, 5, 0);
            lblCanhBao.Name = "lblCanhBao";
            lblCanhBao.Size = new Size(159, 30);
            lblCanhBao.TabIndex = 4;
            lblCanhBao.Text = "Mức cảnh báo:";
            // 
            // nudTon
            // 
            nudTon.DecimalPlaces = 2;
            nudTon.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            nudTon.Location = new Point(211, 92);
            nudTon.Margin = new Padding(4, 4, 4, 4);
            nudTon.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudTon.Name = "nudTon";
            nudTon.Size = new Size(220, 35);
            nudTon.TabIndex = 3;
            // 
            // lblTon
            // 
            lblTon.AutoSize = true;
            lblTon.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTon.Location = new Point(44, 96);
            lblTon.Margin = new Padding(12, 8, 5, 0);
            lblTon.Name = "lblTon";
            lblTon.Size = new Size(57, 30);
            lblTon.TabIndex = 2;
            lblTon.Text = "Tồn:";
            // 
            // txtTenNL
            // 
            txtTenNL.BackColor = Color.FromArgb(255, 255, 255);
            txtTenNL.BorderStyle = BorderStyle.None;
            txtTenNL.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtTenNL.Location = new Point(205, 22);
            txtTenNL.Margin = new Padding(4, 4, 4, 4);
            txtTenNL.Multiline = true;
            txtTenNL.Name = "txtTenNL";
            txtTenNL.ReadOnly = true;
            txtTenNL.Size = new Size(292, 38);
            txtTenNL.TabIndex = 1;
            // 
            // lblTenNL
            // 
            lblTenNL.AutoSize = true;
            lblTenNL.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTenNL.Location = new Point(44, 26);
            lblTenNL.Margin = new Padding(0, 8, 5, 0);
            lblTenNL.Name = "lblTenNL";
            lblTenNL.Size = new Size(139, 30);
            lblTenNL.TabIndex = 0;
            lblTenNL.Text = "Nguyên liệu:";
            // 
            // ucNguyenLieu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 251);
            Controls.Add(tblMain);
            ForeColor = Color.FromArgb(23, 38, 62);
            Margin = new Padding(4, 4, 4, 4);
            Name = "ucNguyenLieu";
            Size = new Size(1350, 788);
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
        private DataGridViewTextBoxColumn colTenNguyeLieu;
        private DataGridViewTextBoxColumn colDonViTinh;
        private DataGridViewTextBoxColumn colSoLuongTon;
        private DataGridViewTextBoxColumn colMucCanhBao;
        private DataGridViewTextBoxColumn colHanSuDung;
        private DataGridViewTextBoxColumn colTrangThai;
        private Label lblDonVi;
        private Label lblDvtCanhBao;
        private Label lblDvtTon;
        private Button btnThemNL;
    }
}
