
using Microsoft.Data.SqlClient;
using QLNhaHang.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLNhaHang.Controls.PhucVu
{
    public partial class ucQuanLyBan : UserControl
    {
        // Chuỗi kết nối lấy chung từ DataProcesser
        static readonly string ConnStr = DataProcesser.strConnect;

        // Báo cho MainForm biết cần mở đơn nào (banId, donHangId)
        public event Action<int, int>? MoDon;

        class BanInfo
        {
            public int BanID;
            public string SoBan = "";
            public string TrangThai = "";
            public string ViTri = "";
            public int SucChua;
            public string GhiChu = "";
        }

        public ucQuanLyBan()
        {
            InitializeComponent();

            // Chỉ Admin được thêm bàn mới
            btnThemBan.Visible = Session.Role == "ADMIN";

            // Không chạy truy vấn khi đang mở trong Designer
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            // Khi form đổi kích thước thì giãn lại các dòng tiêu đề khu vực
            flpBan.SizeChanged += (s, e) =>
            {
                foreach (Label lbl in flpBan.Controls.OfType<Label>())
                    lbl.Width = RongDong();
            };

            cboLoc.SelectedIndex = 0;   // tự gọi LoadBan()
        }

        int RongDong()
        {
            return Math.Max(200, flpBan.ClientSize.Width - flpBan.Padding.Horizontal
                                 - SystemInformation.VerticalScrollBarWidth - 10);
        }

        // ===== TẢI DANH SÁCH BÀN, CHIA THEO TẦNG / KHU VỰC =====
        void LoadBan()
        {
            string loc = cboLoc.SelectedItem?.ToString() ?? "Tất cả";
            var ds = new List<BanInfo>();

            try
            {
                using var conn = new SqlConnection(ConnStr);
                using var cmd = new SqlCommand(@"
                    SELECT BanID, SoBan, SucChua, TrangThai, ISNULL(ViTri, N'Chưa phân khu') AS ViTri,
                        CASE
                            WHEN EXISTS (SELECT 1 FROM DON_HANG d
                                         WHERE d.BanID = BAN_AN.BanID
                                           AND d.TrangThaiDon = N'Đang xử lý'
                                           AND EXISTS (SELECT 1 FROM CHI_TIET_DON_HANG c
                                                       WHERE c.DonHangID = d.DonHangID AND c.TrangThaiMon <> N'Đã hủy')
                                           AND NOT EXISTS (SELECT 1 FROM CHI_TIET_DON_HANG c
                                                           WHERE c.DonHangID = d.DonHangID
                                                             AND c.TrangThaiMon NOT IN (N'Đã phục vụ', N'Đã hủy')))
                                 THEN N'Chờ thanh toán'
                            WHEN TrangThai = N'Đang phục vụ'
                                 AND NOT EXISTS (SELECT 1 FROM DON_HANG d
                                                 WHERE d.BanID = BAN_AN.BanID
                                                   AND d.TrangThaiDon = N'Đang xử lý') THEN N'Đã thanh toán'
                            ELSE N''
                        END AS GhiChuBan
                    FROM BAN_AN
                    WHERE (@tt = N'Tất cả' OR TrangThai = @tt)
                    ORDER BY CASE WHEN ViTri LIKE N'Tầng%' THEN 0 ELSE 1 END, ViTri, SoBan", conn);
                cmd.Parameters.AddWithValue("@tt", loc);
                conn.Open();
                using var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ds.Add(new BanInfo
                    {
                        BanID = Convert.ToInt32(rd["BanID"]),
                        SoBan = rd["SoBan"].ToString() ?? "",
                        TrangThai = rd["TrangThai"].ToString() ?? "",
                        ViTri = rd["ViTri"].ToString() ?? "",
                        SucChua = Convert.ToInt32(rd["SucChua"]),
                        GhiChu = rd["GhiChuBan"].ToString() ?? ""
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách bàn:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            flpBan.SuspendLayout();
            flpBan.Controls.Clear();

            Button? banCuoi = null;

            // Mỗi khu vực: một dòng tiêu đề rồi tới các bàn của khu đó
            foreach (var khu in ds.GroupBy(b => b.ViTri))
            {
                if (banCuoi != null)
                    flpBan.SetFlowBreak(banCuoi, true);   // khu mới bắt đầu ở dòng mới

                int soTrong = khu.Count(b => b.TrangThai == "Trống");

                var tieuDe = new Label
                {
                    Text = $"{khu.Key}   ·   {khu.Count()} bàn   ·   {soTrong} trống",
                    AutoSize = false,
                    Size = new Size(RongDong(), 30),
                    Margin = new Padding(0, 12, 0, 2),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    ForeColor = Theme.BlueBold
                };
                flpBan.Controls.Add(tieuDe);

                foreach (var ban in khu)
                {
                    var btn = new Button
                    {
                        Text = $"Bàn {ban.SoBan}\n{ban.SucChua} chỗ\n{ban.TrangThai}" + (ban.GhiChu != "" ? "\n" + ban.GhiChu : ""),
                        Size = new Size(150, 100),
                        Margin = new Padding(0, 6, 14, 6),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = MauTheoTrangThai(ban.TrangThai),
                        Cursor = Cursors.Hand,
                        Font = new Font("Segoe UI", 10),
                        Tag = ban
                    };
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += BtnBan_Click;
                    flpBan.Controls.Add(btn);
                    banCuoi = btn;
                }
            }

            flpBan.ResumeLayout();
        }

        static Color MauTheoTrangThai(string tt)
        {
            switch (tt)
            {
                case "Trống": return Theme.GreenSoft;
                case "Đang phục vụ": return Theme.OrangeSoft;
                case "Chờ dọn": return Theme.YellowSoft;
                default: return Theme.Border;
            }
        }

        // ===== BẤM VÀO MỘT BÀN =====
        void BtnBan_Click(object? sender, EventArgs e)
        {
            var ban = (BanInfo)((Button)sender!).Tag!;

            try
            {
                switch (ban.TrangThai)
                {
                    case "Trống":
                        if (Session.Role != "PHUCVU" && Session.Role != "ADMIN")
                        {
                            MessageBox.Show("Chỉ nhân viên phục vụ mới tạo đơn.");
                            return;
                        }

                        var hoi = MessageBox.Show(
                            $"Tạo đơn mới cho bàn {ban.SoBan}?",
                            "Tạo đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (hoi != DialogResult.Yes) return;

                        int? donMoi = TaoDon(ban.BanID);
                        if (donMoi == null)
                        {
                            MessageBox.Show("Bàn này đang có đơn chưa hoàn tất.");
                        }
                        else
                        {
                            LoadBan();
                            MoDonHang(ban, donMoi.Value);
                        }
                        break;

                    case "Đang phục vụ":
                        ChiTietDonDialog(ban);
                        break;

                    case "Chờ dọn":
                        // Chỉ Phục vụ (và Admin) xác nhận đã dọn bàn
                        if (Session.Role != "PHUCVU" && Session.Role != "ADMIN")
                        {
                            MessageBox.Show("Chỉ nhân viên phục vụ mới xác nhận dọn bàn.");
                            return;
                        }

                        var xong = MessageBox.Show(
                            $"Xác nhận bàn {ban.SoBan} đã dọn xong?",
                            "Dọn bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (xong != DialogResult.Yes) return;

                        if (!DonXong(ban.BanID))
                            MessageBox.Show("Trạng thái bàn đã thay đổi, danh sách sẽ được làm mới.");
                        LoadBan();
                        break;

                    default:
                        MessageBox.Show($"Bàn {ban.SoBan} có trạng thái không hợp lệ.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void MoDonHang(BanInfo ban, int donHangId)
        {
            if (MoDon != null)
                MoDon.Invoke(ban.BanID, donHangId);
            else
                MessageBox.Show($"Đơn #{donHangId} - bàn {ban.SoBan}\n(Màn hình Tạo đơn chưa được nối)");
        }

        // ===== TẠO ĐƠN MỚI CHO BÀN TRỐNG =====
        // Trả về DonHangID, hoặc null nếu bàn đã có đơn chưa hoàn tất
        int? TaoDon(int banId)
        {
            using var conn = new SqlConnection(ConnStr);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                // 1. Bàn đã có đơn đang xử lý chưa?
                using (var chk = new SqlCommand(
                    "SELECT COUNT(*) FROM DON_HANG WHERE BanID = @b AND TrangThaiDon = N'Đang xử lý'",
                    conn, tran))
                {
                    chk.Parameters.AddWithValue("@b", banId);
                    if (Convert.ToInt32(chk.ExecuteScalar()) > 0)
                    {
                        tran.Rollback();
                        return null;
                    }
                }

                // 2. Tạo đơn, gán nhân viên phục vụ từ tài khoản đăng nhập
                int donId;
                using (var ins = new SqlCommand(@"
                    INSERT INTO DON_HANG (BanID, NhanVienPhucVuID)
                    OUTPUT INSERTED.DonHangID
                    VALUES (@b, @nv)", conn, tran))
                {
                    ins.Parameters.AddWithValue("@b", banId);
                    ins.Parameters.AddWithValue("@nv", Session.NhanVienID);
                    donId = Convert.ToInt32(ins.ExecuteScalar());
                }

                // 3. Bàn chuyển sang Đang phục vụ
                using (var upd = new SqlCommand(
                    "UPDATE BAN_AN SET TrangThai = N'Đang phục vụ' WHERE BanID = @b",
                    conn, tran))
                {
                    upd.Parameters.AddWithValue("@b", banId);
                    upd.ExecuteNonQuery();
                }

                tran.Commit();
                return donId;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        // Đơn gần nhất của bàn: ưu tiên đơn đang xử lý, nếu không có thì đơn vừa hoàn thành
        (int Id, string TrangThai)? DonGanNhat(int banId)
        {
            using var conn = new SqlConnection(ConnStr);
            using var cmd = new SqlCommand(@"
                SELECT TOP 1 DonHangID, TrangThaiDon
                FROM DON_HANG
                WHERE BanID = @b AND TrangThaiDon <> N'Đã hủy'
                ORDER BY CASE WHEN TrangThaiDon = N'Đang xử lý' THEN 0 ELSE 1 END, ThoiGianTao DESC", conn);
            cmd.Parameters.AddWithValue("@b", banId);
            conn.Open();
            using var rd = cmd.ExecuteReader();
            if (!rd.Read()) return null;
            return (Convert.ToInt32(rd["DonHangID"]), rd["TrangThaiDon"].ToString() ?? "");
        }

        // ===== XÁC NHẬN DỌN BÀN: Đang phục vụ -> Chờ dọn =====
        // Chỉ được khi bàn không còn đơn nào đang xử lý (đơn đã thanh toán)
        void XacNhanDonBan(BanInfo ban)
        {
            try
            {
                using var conn = new SqlConnection(ConnStr);
                using var cmd = new SqlCommand(@"
                    UPDATE BAN_AN SET TrangThai = N'Chờ dọn'
                    WHERE BanID = @b
                      AND TrangThai = N'Đang phục vụ'
                      AND NOT EXISTS (SELECT 1 FROM DON_HANG
                                      WHERE BanID = @b AND TrangThaiDon = N'Đang xử lý')", conn);
                cmd.Parameters.AddWithValue("@b", ban.BanID);
                conn.Open();

                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show($"Bàn {ban.SoBan} chuyển sang Chờ dọn.");
                else
                    MessageBox.Show("Không thể xác nhận: bàn còn đơn chưa thanh toán hoặc trạng thái đã thay đổi.");

                LoadBan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== CHI TIẾT ĐƠN: mở Form riêng khi bấm vào bàn Đang phục vụ =====
        void ChiTietDonDialog(BanInfo ban)
        {
            try
            {
                var don = DonGanNhat(ban.BanID);
                if (don == null)
                {
                    MessageBox.Show("Không tìm thấy đơn của bàn này.");
                    return;
                }

                int donId = don.Value.Id;

                using var f = new frmChiTietDon(donId, ban.SoBan, ban.ViTri, ban.SucChua);
                f.ShowDialog(this);

                switch (f.HanhDong)
                {
                    case "modon": MoDonHang(ban, donId); break;
                    case "chuyen": ChuyenBanDialog(ban); break;
                    case "donban": XacNhanDonBan(ban); break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== DỌN XONG: Chờ dọn -> Trống =====
        // Trả về false nếu bàn không còn ở trạng thái Chờ dọn (đã có người đổi trước)
        bool DonXong(int banId)
        {
            using var conn = new SqlConnection(ConnStr);
            using var cmd = new SqlCommand(
                "UPDATE BAN_AN SET TrangThai = N'Trống' WHERE BanID = @b AND TrangThai = N'Chờ dọn'",
                conn);
            cmd.Parameters.AddWithValue("@b", banId);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // ===== CHUYỂN BÀN (chỉ sang bàn trống CÙNG SỨC CHỨA) =====
        void ChuyenBanDialog(BanInfo banCu)
        {
            var trong = new List<BanInfo>();
            try
            {
                using var conn = new SqlConnection(ConnStr);
                using var cmd = new SqlCommand(@"
                    SELECT BanID, SoBan, SucChua, ISNULL(ViTri, N'') AS ViTri
                    FROM BAN_AN
                    WHERE TrangThai = N'Trống' AND SucChua = @sc
                    ORDER BY SoBan", conn);
                cmd.Parameters.AddWithValue("@sc", banCu.SucChua);
                conn.Open();
                using var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    trong.Add(new BanInfo
                    {
                        BanID = Convert.ToInt32(rd["BanID"]),
                        SoBan = rd["SoBan"].ToString() ?? "",
                        ViTri = rd["ViTri"].ToString() ?? "",
                        SucChua = Convert.ToInt32(rd["SucChua"])
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return;
            }

            if (trong.Count == 0)
            {
                MessageBox.Show($"Hiện không có bàn trống nào {banCu.SucChua} chỗ để chuyển.");
                return;
            }

            using var f = new Form
            {
                Text = $"Chuyển từ bàn {banCu.SoBan} ({banCu.SucChua} chỗ)",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(320, 120)
            };

            var cbo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(15, 15),
                Width = 290
            };
            foreach (var b in trong) cbo.Items.Add($"{b.SoBan} - {b.ViTri}");
            cbo.SelectedIndex = 0;

            var ok = new Button { Text = "Chuyển", DialogResult = DialogResult.OK, Location = new Point(135, 70), Size = new Size(80, 30) };
            var huy = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new Point(225, 70), Size = new Size(80, 30) };

            f.Controls.AddRange(new Control[] { cbo, ok, huy });
            f.AcceptButton = ok;
            f.CancelButton = huy;

            if (f.ShowDialog() != DialogResult.OK) return;

            try
            {
                if (ChuyenBan(banCu.BanID, trong[cbo.SelectedIndex].BanID))
                    LoadBan();
                else
                    MessageBox.Show("Không chuyển được: bàn mới đã có người dùng, khác sức chứa, hoặc đơn đã đóng.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool ChuyenBan(int banCuId, int banMoiId)
        {
            using var conn = new SqlConnection(ConnStr);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                // 1. Giữ chỗ bàn mới: phải còn Trống và cùng sức chứa với bàn cũ
                using (var c1 = new SqlCommand(@"
                    UPDATE BAN_AN SET TrangThai = N'Đang phục vụ'
                    WHERE BanID = @moi
                      AND TrangThai = N'Trống'
                      AND SucChua = (SELECT SucChua FROM BAN_AN WHERE BanID = @cu)", conn, tran))
                {
                    c1.Parameters.AddWithValue("@moi", banMoiId);
                    c1.Parameters.AddWithValue("@cu", banCuId);
                    if (c1.ExecuteNonQuery() == 0) { tran.Rollback(); return false; }
                }

                // 2. Đổi bàn cho đơn đang xử lý (món, hóa đơn giữ nguyên)
                using (var c2 = new SqlCommand(
                    "UPDATE DON_HANG SET BanID = @moi WHERE BanID = @cu AND TrangThaiDon = N'Đang xử lý'",
                    conn, tran))
                {
                    c2.Parameters.AddWithValue("@moi", banMoiId);
                    c2.Parameters.AddWithValue("@cu", banCuId);
                    if (c2.ExecuteNonQuery() == 0) { tran.Rollback(); return false; }
                }

                // 3. Bàn cũ chuyển sang Chờ dọn
                using (var c3 = new SqlCommand(
                    "UPDATE BAN_AN SET TrangThai = N'Chờ dọn' WHERE BanID = @cu", conn, tran))
                {
                    c3.Parameters.AddWithValue("@cu", banCuId);
                    c3.ExecuteNonQuery();
                }

                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        // ===== ADMIN THÊM BÀN MỚI =====
        void btnThemBan_Click(object? sender, EventArgs e)
        {
            if (Session.Role != "ADMIN")
            {
                MessageBox.Show("Chỉ Admin mới được thêm bàn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var f = new Form
            {
                Text = "Thêm bàn mới",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(430, 255),
                Font = new Font("Segoe UI", 10)
            };

            var lblSoBan = new Label
            {
                Text = "Số bàn:",
                Location = new Point(20, 18),
                Size = new Size(135, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };
            var txtSoBan = new TextBox { Location = new Point(165, 18), Width = 245, MaxLength = 10 };

            var lblSucChua = new Label
            {
                Text = "Sức chứa (chỗ):",
                Location = new Point(20, 63),
                Size = new Size(135, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };
            var numSucChua = new NumericUpDown
            {
                Location = new Point(165, 63),
                Width = 245,
                Minimum = 1,
                Maximum = 100,
                Value = 4
            };

            var lblViTri = new Label
            {
                Text = "Vị trí / Khu vực:",
                Location = new Point(20, 108),
                Size = new Size(135, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };
            var txtViTri = new TextBox { Location = new Point(165, 108), Width = 245, MaxLength = 100 };

            var btnLuu = new Button
            {
                Text = "Thêm bàn",
                Location = new Point(220, 190),
                Size = new Size(100, 35),
                BackColor = Theme.Green,
                ForeColor = Theme.Surface,
                FlatStyle = FlatStyle.Flat
            };
            btnLuu.FlatAppearance.BorderSize = 0;

            var btnHuy = new Button
            {
                Text = "Hủy",
                Location = new Point(330, 190),
                Size = new Size(75, 35),
                DialogResult = DialogResult.Cancel
            };

            btnLuu.Click += (s, args) =>
            {
                string soBan = txtSoBan.Text.Trim();
                string viTri = txtViTri.Text.Trim();

                if (soBan.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập số bàn.", "Thiếu thông tin",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoBan.Focus();
                    return;
                }

                try
                {
                    using var conn = new SqlConnection(ConnStr);
                    using var cmd = new SqlCommand(@"
                        INSERT INTO BAN_AN (SoBan, SucChua, TrangThai, ViTri)
                        VALUES (@soBan, @sucChua, N'Trống', @viTri);", conn);

                    cmd.Parameters.AddWithValue("@soBan", soBan);
                    cmd.Parameters.AddWithValue("@sucChua", Convert.ToInt32(numSucChua.Value));
                    cmd.Parameters.AddWithValue("@viTri",
                        string.IsNullOrWhiteSpace(viTri) ? (object)DBNull.Value : viTri);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Đã thêm bàn {soBan}.", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.DialogResult = DialogResult.OK;
                    f.Close();
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Số bàn này đã tồn tại. Vui lòng nhập số bàn khác.",
                        "Trùng số bàn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm bàn:\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            f.Controls.AddRange(new Control[]
            {
                lblSoBan, txtSoBan, lblSucChua, numSucChua,
                lblViTri, txtViTri, btnLuu, btnHuy
            });
            f.AcceptButton = btnLuu;
            f.CancelButton = btnHuy;

            if (f.ShowDialog(this) == DialogResult.OK)
                LoadBan();
        }

        // ===== LỌC / LÀM MỚI =====
        private void cboLoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadBan();
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            LoadBan();
        }
    }
}
