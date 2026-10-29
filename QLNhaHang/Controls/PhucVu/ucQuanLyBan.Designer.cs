using QLNhaHang.Classes;
namespace QLNhaHang.Controls.PhucVu
{
    partial class ucQuanLyBan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.cboLoc = new System.Windows.Forms.ComboBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTrong = new System.Windows.Forms.Label();
            this.lblDangPhucVu = new System.Windows.Forms.Label();
            this.lblChoDon = new System.Windows.Forms.Label();
            this.lblBaoTri = new System.Windows.Forms.Label();
            this.flpBan = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.BackColor = QLNhaHang.Classes.Theme.Surface;
            this.pnlTop.Controls.Add(this.lblTieuDe);
            this.pnlTop.Controls.Add(this.cboLoc);
            this.pnlTop.Controls.Add(this.btnLamMoi);
            this.pnlTop.Controls.Add(this.lblTrong);
            this.pnlTop.Controls.Add(this.lblDangPhucVu);
            this.pnlTop.Controls.Add(this.lblChoDon);
            this.pnlTop.Controls.Add(this.lblBaoTri);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1080, 80);
            this.pnlTop.TabIndex = 0;
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = QLNhaHang.Classes.Theme.BlueBold;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 10);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "Sơ đồ bàn";
            //
            // cboLoc
            //
            this.cboLoc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.cboLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoc.Items.AddRange(new object[] { "Tất cả", "Trống", "Đang phục vụ", "Chờ dọn", "Bảo trì" });
            this.cboLoc.Location = new System.Drawing.Point(800, 14);
            this.cboLoc.Name = "cboLoc";
            this.cboLoc.Size = new System.Drawing.Size(150, 25);
            this.cboLoc.TabIndex = 0;
            this.cboLoc.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);
            //
            // btnLamMoi
            //
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnLamMoi.BackColor = QLNhaHang.Classes.Theme.BlueBold;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = QLNhaHang.Classes.Theme.Surface;
            this.btnLamMoi.Location = new System.Drawing.Point(960, 12);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 30);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            //
            // Chú thích màu
            //
            this.lblTrong.BackColor = QLNhaHang.Classes.Theme.GreenSoft;
            this.lblTrong.Location = new System.Drawing.Point(20, 46);
            this.lblTrong.Name = "lblTrong";
            this.lblTrong.Size = new System.Drawing.Size(110, 24);
            this.lblTrong.Text = "Trống";
            this.lblTrong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblDangPhucVu.BackColor = QLNhaHang.Classes.Theme.OrangeSoft;
            this.lblDangPhucVu.Location = new System.Drawing.Point(140, 46);
            this.lblDangPhucVu.Name = "lblDangPhucVu";
            this.lblDangPhucVu.Size = new System.Drawing.Size(110, 24);
            this.lblDangPhucVu.Text = "Đang phục vụ";
            this.lblDangPhucVu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblChoDon.BackColor = QLNhaHang.Classes.Theme.OrangeSoft;
            this.lblChoDon.Location = new System.Drawing.Point(260, 46);
            this.lblChoDon.Name = "lblChoDon";
            this.lblChoDon.Size = new System.Drawing.Size(110, 24);
            this.lblChoDon.Text = "Chờ dọn";
            this.lblChoDon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblBaoTri.BackColor = QLNhaHang.Classes.Theme.Border;
            this.lblBaoTri.Location = new System.Drawing.Point(380, 46);
            this.lblBaoTri.Name = "lblBaoTri";
            this.lblBaoTri.Size = new System.Drawing.Size(110, 24);
            this.lblBaoTri.Text = "Bảo trì";
            this.lblBaoTri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // flpBan (lưới bàn)
            //
            this.flpBan.AutoScroll = true;
            this.flpBan.BackColor = QLNhaHang.Classes.Theme.Background;
            this.flpBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBan.Location = new System.Drawing.Point(0, 80);
            this.flpBan.Name = "flpBan";
            this.flpBan.Padding = new System.Windows.Forms.Padding(15);
            this.flpBan.Size = new System.Drawing.Size(1080, 550);
            this.flpBan.TabIndex = 1;
            //
            // ucQuanLyBan (thứ tự add: Fill -> Top)
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpBan);
            this.Controls.Add(this.pnlTop);
            this.Name = "ucQuanLyBan";
            this.Size = new System.Drawing.Size(1080, 630);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.ComboBox cboLoc;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTrong;
        private System.Windows.Forms.Label lblDangPhucVu;
        private System.Windows.Forms.Label lblChoDon;
        private System.Windows.Forms.Label lblBaoTri;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
    }
}