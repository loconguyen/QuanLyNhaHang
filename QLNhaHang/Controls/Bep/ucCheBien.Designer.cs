using System.Drawing;
using System.Windows.Forms;

namespace QLNhaHang.Controls.Bep
{
    partial class ucCheBien
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
            components = new System.ComponentModel.Container();
            tblMain = new TableLayoutPanel();
            lblTitle = new Label();
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
            lblThongBao = new Label();
            flpDon = new FlowCuon();
            timer1 = new System.Windows.Forms.Timer(components);
            tblMain.SuspendLayout();
            tblDem.SuspendLayout();
            pnlCho.SuspendLayout();
            pnlDang.SuspendLayout();
            pnlXong.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblTitle, 0, 0);
            tblMain.Controls.Add(tblDem, 0, 1);
            tblMain.Controls.Add(lblThongBao, 0, 2);
            tblMain.Controls.Add(flpDon, 0, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.Padding = new Padding(8);
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(1378, 644);
            tblMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(11, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1356, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý chế biến";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
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
            tblDem.Location = new Point(11, 51);
            tblDem.Name = "tblDem";
            tblDem.RowCount = 1;
            tblDem.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblDem.Size = new Size(1356, 78);
            tblDem.TabIndex = 1;
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
            pnlCho.Size = new Size(444, 70);
            pnlCho.TabIndex = 0;
            // 
            // lblChoCaption
            // 
            lblChoCaption.Dock = DockStyle.Fill;
            lblChoCaption.ForeColor = Color.DimGray;
            lblChoCaption.Location = new Point(0, 46);
            lblChoCaption.Name = "lblChoCaption";
            lblChoCaption.Size = new Size(444, 24);
            lblChoCaption.TabIndex = 0;
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
            lblCho.Size = new Size(444, 46);
            lblCho.TabIndex = 1;
            lblCho.Text = "00";
            lblCho.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDang
            // 
            pnlDang.BackColor = Color.White;
            pnlDang.Controls.Add(lblDangCaption);
            pnlDang.Controls.Add(lblDang);
            pnlDang.Dock = DockStyle.Fill;
            pnlDang.Location = new Point(456, 4);
            pnlDang.Margin = new Padding(4);
            pnlDang.Name = "pnlDang";
            pnlDang.Size = new Size(444, 70);
            pnlDang.TabIndex = 1;
            // 
            // lblDangCaption
            // 
            lblDangCaption.Dock = DockStyle.Fill;
            lblDangCaption.ForeColor = Color.DimGray;
            lblDangCaption.Location = new Point(0, 46);
            lblDangCaption.Name = "lblDangCaption";
            lblDangCaption.Size = new Size(444, 24);
            lblDangCaption.TabIndex = 0;
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
            lblDang.Size = new Size(444, 46);
            lblDang.TabIndex = 1;
            lblDang.Text = "00";
            lblDang.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlXong
            // 
            pnlXong.BackColor = Color.White;
            pnlXong.Controls.Add(lblXongCaption);
            pnlXong.Controls.Add(lblXong);
            pnlXong.Dock = DockStyle.Fill;
            pnlXong.Location = new Point(908, 4);
            pnlXong.Margin = new Padding(4);
            pnlXong.Name = "pnlXong";
            pnlXong.Size = new Size(444, 70);
            pnlXong.TabIndex = 2;
            // 
            // lblXongCaption
            // 
            lblXongCaption.Dock = DockStyle.Fill;
            lblXongCaption.ForeColor = Color.DimGray;
            lblXongCaption.Location = new Point(0, 46);
            lblXongCaption.Name = "lblXongCaption";
            lblXongCaption.Size = new Size(444, 24);
            lblXongCaption.TabIndex = 0;
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
            lblXong.Size = new Size(444, 46);
            lblXong.TabIndex = 1;
            lblXong.Text = "00";
            lblXong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblThongBao
            // 
            lblThongBao.Dock = DockStyle.Fill;
            lblThongBao.ForeColor = Color.DimGray;
            lblThongBao.Location = new Point(11, 132);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(1356, 28);
            lblThongBao.TabIndex = 2;
            lblThongBao.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flpDon
            // 
            flpDon.AutoScroll = true;
            flpDon.BackColor = Color.FromArgb(244, 246, 250);
            flpDon.Dock = DockStyle.Fill;
            flpDon.Location = new Point(11, 163);
            flpDon.Name = "flpDon";
            flpDon.Size = new Size(1356, 470);
            flpDon.TabIndex = 3;
            flpDon.TabStop = true;
            // 
            // timer1
            // 
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick;
            // 
            // ucCheBien
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 10F);
            Name = "ucCheBien";
            Size = new Size(1378, 644);
            Load += ucCheBien_Load;
            tblMain.ResumeLayout(false);
            tblDem.ResumeLayout(false);
            pnlCho.ResumeLayout(false);
            pnlDang.ResumeLayout(false);
            pnlXong.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblTitle;
        private TableLayoutPanel tblDem;
        private Panel pnlCho;
        private Label lblChoCaption;
        private Label lblCho;
        private Panel pnlDang;
        private Label lblDangCaption;
        private Label lblDang;
        private Panel pnlXong;
        private Label lblXongCaption;
        private Label lblXong;
        private Label lblThongBao;
        private FlowCuon flpDon;
        private System.Windows.Forms.Timer timer1;
    }
}