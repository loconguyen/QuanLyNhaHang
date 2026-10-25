using System.Drawing;
using System.Windows.Forms;

namespace QLNhaHang.Controls.Bep
{
    partial class ucThucDon
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>Required method for Designer support - do not modify the contents with the code editor.</summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tblMain = new TableLayoutPanel();
            pnlLoc = new FlowLayoutPanel();
            lblDanhMuc = new Label();
            cboDanhMuc = new ComboBox();
            lblTim = new Label();
            txtTim = new TextBox();
            dgvThucDon = new DataGridView();
            colTenMon = new DataGridViewTextBoxColumn();
            colTenDanhMuc = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colDonViTinh = new DataGridViewTextBoxColumn();
            colMoTa = new DataGridViewTextBoxColumn();
            colTrangThaiMon = new DataGridViewTextBoxColumn();
            pnlEdit = new FlowLayoutPanel();
            lblMon = new Label();
            txtTenMon = new TextBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnLuuTrangThai = new Button();
            tblMain.SuspendLayout();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThucDon).BeginInit();
            pnlEdit.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(pnlLoc, 0, 0);
            tblMain.Controls.Add(dgvThucDon, 0, 1);
            tblMain.Controls.Add(pnlEdit, 0, 2);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.Padding = new Padding(8);
            tblMain.RowCount = 3;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tblMain.Size = new Size(1378, 802);
            tblMain.TabIndex = 0;
            // 
            // pnlLoc
            // 
            pnlLoc.Controls.Add(lblDanhMuc);
            pnlLoc.Controls.Add(cboDanhMuc);
            pnlLoc.Controls.Add(lblTim);
            pnlLoc.Controls.Add(txtTim);
            pnlLoc.Dock = DockStyle.Fill;
            pnlLoc.Location = new Point(11, 11);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(1356, 34);
            pnlLoc.TabIndex = 0;
            pnlLoc.WrapContents = false;
            // 
            // lblDanhMuc
            // 
            lblDanhMuc.AutoSize = true;
            lblDanhMuc.Location = new Point(3, 0);
            lblDanhMuc.Name = "lblDanhMuc";
            lblDanhMuc.Padding = new Padding(0, 6, 6, 0);
            lblDanhMuc.Size = new Size(99, 29);
            lblDanhMuc.TabIndex = 0;
            lblDanhMuc.Text = "Danh mục:";
            // 
            // cboDanhMuc
            // 
            cboDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDanhMuc.Location = new Point(108, 3);
            cboDanhMuc.Name = "cboDanhMuc";
            cboDanhMuc.Size = new Size(200, 31);
            cboDanhMuc.TabIndex = 1;
            cboDanhMuc.SelectionChangeCommitted += cboDanhMuc_SelectionChangeCommitted;
            // 
            // lblTim
            // 
            lblTim.AutoSize = true;
            lblTim.Location = new Point(314, 0);
            lblTim.Name = "lblTim";
            lblTim.Padding = new Padding(16, 6, 6, 0);
            lblTim.Size = new Size(104, 29);
            lblTim.TabIndex = 2;
            lblTim.Text = "Tìm món:";
            // 
            // txtTim
            // 
            txtTim.Location = new Point(424, 3);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(240, 30);
            txtTim.TabIndex = 3;
            txtTim.TextChanged += txtTim_TextChanged;
            // 
            // dgvThucDon
            // 
            dgvThucDon.AllowUserToAddRows = false;
            dgvThucDon.AllowUserToDeleteRows = false;
            dgvThucDon.AllowUserToResizeRows = false;
            dgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThucDon.BackgroundColor = Color.White;
            dgvThucDon.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(241, 245, 249);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(241, 245, 249);
            dgvThucDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvThucDon.ColumnHeadersHeight = 29;
            dgvThucDon.Columns.AddRange(new DataGridViewColumn[] { colTenMon, colTenDanhMuc, colDonGia, colDonViTinh, colMoTa, colTrangThaiMon });
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
            dgvThucDon.Location = new Point(11, 51);
            dgvThucDon.MultiSelect = false;
            dgvThucDon.Name = "dgvThucDon";
            dgvThucDon.ReadOnly = true;
            dgvThucDon.RowHeadersVisible = false;
            dgvThucDon.RowHeadersWidth = 51;
            dgvThucDon.RowTemplate.Height = 30;
            dgvThucDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThucDon.Size = new Size(1356, 684);
            dgvThucDon.TabIndex = 1;
            dgvThucDon.DataBindingComplete += dgvThucDon_DataBindingComplete;
            dgvThucDon.SelectionChanged += dgvThucDon_SelectionChanged;
            // 
            // colTenMon
            // 
            colTenMon.DataPropertyName = "TenMon";
            colTenMon.FillWeight = 180F;
            colTenMon.HeaderText = "Tên món";
            colTenMon.MinimumWidth = 6;
            colTenMon.Name = "colTenMon";
            colTenMon.ReadOnly = true;
            colTenMon.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colTenDanhMuc
            // 
            colTenDanhMuc.DataPropertyName = "TenDanhMuc";
            colTenDanhMuc.FillWeight = 120F;
            colTenDanhMuc.HeaderText = "Danh mục";
            colTenDanhMuc.MinimumWidth = 6;
            colTenDanhMuc.Name = "colTenDanhMuc";
            colTenDanhMuc.ReadOnly = true;
            colTenDanhMuc.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colDonGia
            // 
            colDonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            colDonGia.DefaultCellStyle = dataGridViewCellStyle2;
            colDonGia.FillWeight = 80F;
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.MinimumWidth = 6;
            colDonGia.Name = "colDonGia";
            colDonGia.ReadOnly = true;
            colDonGia.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colDonViTinh
            // 
            colDonViTinh.DataPropertyName = "DonViTinh";
            colDonViTinh.FillWeight = 60F;
            colDonViTinh.HeaderText = "ĐVT";
            colDonViTinh.MinimumWidth = 6;
            colDonViTinh.Name = "colDonViTinh";
            colDonViTinh.ReadOnly = true;
            colDonViTinh.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colMoTa
            // 
            colMoTa.DataPropertyName = "MoTa";
            colMoTa.FillWeight = 220F;
            colMoTa.HeaderText = "Mô tả";
            colMoTa.MinimumWidth = 6;
            colMoTa.Name = "colMoTa";
            colMoTa.ReadOnly = true;
            colMoTa.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colTrangThaiMon
            // 
            colTrangThaiMon.DataPropertyName = "TrangThaiMon";
            colTrangThaiMon.FillWeight = 90F;
            colTrangThaiMon.HeaderText = "Trạng thái";
            colTrangThaiMon.MinimumWidth = 6;
            colTrangThaiMon.Name = "colTrangThaiMon";
            colTrangThaiMon.ReadOnly = true;
            colTrangThaiMon.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlEdit
            // 
            pnlEdit.Controls.Add(lblMon);
            pnlEdit.Controls.Add(txtTenMon);
            pnlEdit.Controls.Add(lblTrangThai);
            pnlEdit.Controls.Add(cboTrangThai);
            pnlEdit.Controls.Add(btnLuuTrangThai);
            pnlEdit.Dock = DockStyle.Fill;
            pnlEdit.Location = new Point(11, 741);
            pnlEdit.Name = "pnlEdit";
            pnlEdit.Size = new Size(1356, 50);
            pnlEdit.TabIndex = 2;
            pnlEdit.WrapContents = false;
            // 
            // lblMon
            // 
            lblMon.AutoSize = true;
            lblMon.Location = new Point(3, 0);
            lblMon.Name = "lblMon";
            lblMon.Padding = new Padding(0, 6, 4, 0);
            lblMon.Size = new Size(53, 29);
            lblMon.TabIndex = 0;
            lblMon.Text = "Món:";
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(62, 3);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.ReadOnly = true;
            txtTenMon.Size = new Size(240, 30);
            txtTenMon.TabIndex = 1;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(308, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Padding = new Padding(10, 6, 4, 0);
            lblTrangThai.Size = new Size(105, 29);
            lblTrangThai.TabIndex = 2;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Location = new Point(419, 3);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(170, 31);
            cboTrangThai.TabIndex = 3;
            // 
            // btnLuuTrangThai
            // 
            btnLuuTrangThai.Enabled = false;
            btnLuuTrangThai.Location = new Point(595, 3);
            btnLuuTrangThai.Name = "btnLuuTrangThai";
            btnLuuTrangThai.Size = new Size(80, 32);
            btnLuuTrangThai.TabIndex = 4;
            btnLuuTrangThai.Text = "Lưu";
            btnLuuTrangThai.UseVisualStyleBackColor = true;
            btnLuuTrangThai.Click += btnLuuTrangThai_Click;
            // 
            // ucThucDon
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 10F);
            Name = "ucThucDon";
            Size = new Size(1378, 802);
            Load += ucThucDon_Load;
            VisibleChanged += ucThucDon_VisibleChanged;
            tblMain.ResumeLayout(false);
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThucDon).EndInit();
            pnlEdit.ResumeLayout(false);
            pnlEdit.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private FlowLayoutPanel pnlLoc;
        private Label lblDanhMuc;
        private ComboBox cboDanhMuc;
        private Label lblTim;
        private TextBox txtTim;
        private DataGridView dgvThucDon;
        private FlowLayoutPanel pnlEdit;
        private Label lblMon;
        private TextBox txtTenMon;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnLuuTrangThai;
        private DataGridViewTextBoxColumn colTenMon;
        private DataGridViewTextBoxColumn colTenDanhMuc;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colDonViTinh;
        private DataGridViewTextBoxColumn colMoTa;
        private DataGridViewTextBoxColumn colTrangThaiMon;
    }
}