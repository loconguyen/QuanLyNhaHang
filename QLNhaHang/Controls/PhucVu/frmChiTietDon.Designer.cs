namespace QLNhaHang.Controls.PhucVu
{
    partial class frmChiTietDon
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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblInfo = new Label();
            dgvMon = new DataGridView();
            lblTong = new Label();
            btnThemMon = new Button();
            btnChuyenBan = new Button();
            btnDaPhucVu = new Button();
            btnDonBan = new Button();
            btnDong = new Button();
            tmrLamMoi = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgvMon).BeginInit();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 10F);
            lblInfo.Location = new Point(17, 16);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(0, 23);
            lblInfo.TabIndex = 0;
            // 
            // dgvMon
            // 
            dgvMon.AllowUserToAddRows = false;
            dgvMon.AllowUserToDeleteRows = false;
            dgvMon.AllowUserToResizeRows = false;
            dgvMon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMon.BackgroundColor = Color.White;
            dgvMon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 38, 66);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(24, 38, 66);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            // Tăng chiều cao hàng tiêu đề để hiển thị đầy đủ chữ "Số lượng"
            dgvMon.ColumnHeadersHeight = 55;

            dgvMon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMon.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMon.EnableHeadersVisualStyles = false;
            dgvMon.GridColor = Color.FromArgb(207, 216, 220);
            dgvMon.Location = new Point(17, 80);
            dgvMon.Margin = new Padding(3, 4, 3, 4);
            dgvMon.Name = "dgvMon";
            dgvMon.ReadOnly = true;
            dgvMon.RowHeadersVisible = false;
            dgvMon.RowHeadersWidth = 51;
            dgvMon.RowTemplate.Height = 28;
            dgvMon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMon.Size = new Size(880, 400);
            dgvMon.TabIndex = 0;
            dgvMon.CellFormatting += dgvMon_CellFormatting;
            // 
            // lblTong
            // 
            lblTong.AutoSize = true;
            lblTong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTong.ForeColor = Color.FromArgb(24, 38, 66);
            lblTong.Location = new Point(17, 496);
            lblTong.Name = "lblTong";
            lblTong.Size = new Size(215, 25);
            lblTong.TabIndex = 1;
            lblTong.Text = "Tổng tiền tạm tính: 0 đ";
            // 
            // btnThemMon
            // 
            btnThemMon.BackColor = Color.FromArgb(21, 101, 192);
            btnThemMon.Cursor = Cursors.Hand;
            btnThemMon.FlatAppearance.BorderSize = 0;
            btnThemMon.FlatStyle = FlatStyle.Flat;
            btnThemMon.ForeColor = Color.White;
            btnThemMon.Location = new Point(27, 560);
            btnThemMon.Margin = new Padding(3, 4, 3, 4);
            btnThemMon.Name = "btnThemMon";
            btnThemMon.Size = new Size(109, 48);
            btnThemMon.TabIndex = 2;
            btnThemMon.Text = "Thêm món";
            btnThemMon.UseVisualStyleBackColor = false;
            btnThemMon.Click += btnThemMon_Click;
            // 
            // btnChuyenBan
            // 
            btnChuyenBan.BackColor = Color.FromArgb(106, 27, 154);
            btnChuyenBan.Cursor = Cursors.Hand;
            btnChuyenBan.FlatAppearance.BorderSize = 0;
            btnChuyenBan.FlatStyle = FlatStyle.Flat;
            btnChuyenBan.ForeColor = Color.White;
            btnChuyenBan.Location = new Point(190, 560);
            btnChuyenBan.Margin = new Padding(3, 4, 3, 4);
            btnChuyenBan.Name = "btnChuyenBan";
            btnChuyenBan.Size = new Size(109, 48);
            btnChuyenBan.TabIndex = 3;
            btnChuyenBan.Text = "Chuyển bàn";
            btnChuyenBan.UseVisualStyleBackColor = false;
            btnChuyenBan.Click += btnChuyenBan_Click;
            // 
            // btnDaPhucVu
            // 
            btnDaPhucVu.BackColor = Color.FromArgb(46, 125, 50);
            btnDaPhucVu.Cursor = Cursors.Hand;
            btnDaPhucVu.FlatAppearance.BorderSize = 0;
            btnDaPhucVu.FlatStyle = FlatStyle.Flat;
            btnDaPhucVu.ForeColor = Color.White;
            btnDaPhucVu.Location = new Point(355, 560);
            btnDaPhucVu.Margin = new Padding(3, 4, 3, 4);
            btnDaPhucVu.Name = "btnDaPhucVu";
            btnDaPhucVu.Size = new Size(126, 48);
            btnDaPhucVu.TabIndex = 4;
            btnDaPhucVu.Text = "Đã phục vụ";
            btnDaPhucVu.UseVisualStyleBackColor = false;
            btnDaPhucVu.Click += btnDaPhucVu_Click;
            // 
            // btnDonBan
            // 
            btnDonBan.BackColor = Color.FromArgb(0, 121, 107);
            btnDonBan.Cursor = Cursors.Hand;
            btnDonBan.FlatAppearance.BorderSize = 0;
            btnDonBan.FlatStyle = FlatStyle.Flat;
            btnDonBan.ForeColor = Color.White;
            btnDonBan.Location = new Point(530, 560);
            btnDonBan.Margin = new Padding(3, 4, 3, 4);
            btnDonBan.Name = "btnDonBan";
            btnDonBan.Size = new Size(171, 48);
            btnDonBan.TabIndex = 5;
            btnDonBan.Text = "Xác nhận dọn bàn";
            btnDonBan.UseVisualStyleBackColor = false;
            btnDonBan.Click += btnDonBan_Click;
            // 
            // btnDong
            // 
            btnDong.BackColor = Color.FromArgb(96, 125, 139);
            btnDong.Cursor = Cursors.Hand;
            btnDong.DialogResult = DialogResult.Cancel;
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(783, 560);
            btnDong.Margin = new Padding(3, 4, 3, 4);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(114, 48);
            btnDong.TabIndex = 6;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;
            // 
            // tmrLamMoi
            // 
            tmrLamMoi.Interval = 8000;
            tmrLamMoi.Tick += tmrLamMoi_Tick;
            // 
            // frmChiTietDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDong;
            ClientSize = new Size(914, 627);
            Controls.Add(lblInfo);
            Controls.Add(dgvMon);
            Controls.Add(lblTong);
            Controls.Add(btnThemMon);
            Controls.Add(btnChuyenBan);
            Controls.Add(btnDaPhucVu);
            Controls.Add(btnDonBan);
            Controls.Add(btnDong);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChiTietDon";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết đơn";
            ((System.ComponentModel.ISupportInitialize)dgvMon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridView dgvMon;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Button btnDaPhucVu;
        private System.Windows.Forms.Button btnDonBan;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Timer tmrLamMoi;
    }
}