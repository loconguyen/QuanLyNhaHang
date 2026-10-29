
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Design;
namespace QLNhaHang.Classes
{
    internal static class Theme
    {
        // bang mau

        public static readonly Color BlueBold = Color.FromArgb(23, 38, 62);
        public static readonly Color White = Color.White;
        public static readonly Color Black = Color.FromArgb(16, 18, 15);
        public static readonly Color Orange = Color.FromArgb(229, 100, 29);
        public static readonly Color Blue = Color.FromArgb(60, 115, 201);
        public static readonly Color Green = Color.FromArgb(21, 128, 61);
        


        // Màu ngữ nghĩa dùng chung trên tất cả màn hình.
        public static readonly Color Background = Color.FromArgb(244, 247, 251);
        public static readonly Color Surface = Color.FromArgb(255, 255, 255);
        public static readonly Color SurfaceMuted = Color.FromArgb(248, 250, 252);
        public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);
        public static readonly Color Border = Color.FromArgb(203, 213, 225);
        public static readonly Color Divider = Color.FromArgb(226, 232, 240);
        public static readonly Color BlueSoft = Color.FromArgb(232, 240, 254);
        public static readonly Color GreenSoft = Color.FromArgb(221, 245, 227);
        public static readonly Color OrangeSoft = Color.FromArgb(255, 237, 213);
        public static readonly Color OrangeText = Color.FromArgb(154, 65, 12);
        public static readonly Color WarningBackground = Color.FromArgb(255, 247, 237);
        public static readonly Color WarningBorder = Color.FromArgb(253, 186, 116);
        public static readonly Color Danger = Color.FromArgb(185, 48, 48);
        public static readonly Color DangerSoft = Color.FromArgb(254, 226, 226);
        public static readonly Color Purple = Color.FromArgb(112, 64, 176);
        public static readonly Color PurpleSoft = Color.FromArgb(240, 231, 250);
        public static readonly Color Teal = Color.FromArgb(0, 121, 107);
        public static readonly Color TealSoft = Color.FromArgb(218, 242, 239);
        // font

        public static readonly Font H1 = new("Segoe UI", 25, FontStyle.Bold);
        public static readonly Font H2 = new("Segoe UI", 21, FontStyle.Bold);
        public static readonly Font H3 = new("Segoe UI", 18, FontStyle.Bold);
        public static readonly Font H4 = new("Segoe UI", 14, FontStyle.Bold);
        public static readonly Font Body = new("Segoe UI", 12);
        public static readonly Font LabelFont = new("Segoe UI", 10.5f);
        public static readonly Font ButtonFont = new("Segoe UI", 11, FontStyle.Bold);



        public static void StyleForm(Form form)
        {
            form.Font = Body;
            form.ForeColor = Black;
            form.BackColor = Background;

            form.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void StyleLabel(Label lbl)
        {
            lbl.Font = H3;
            lbl.ForeColor = Black;
        }

        public static void StyleTextBox(TextBox txt)
        {
            txt.Font = H3;
            txt.BackColor = Color.White;
            txt.ForeColor = Black;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        public static void StyleButton(Button btn)
        {
            btn.Font = H4;
            btn.BackColor = BlueBold;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        public static void StyleTitle(Label lbl)
        {
            lbl.Font = H2;
            lbl.ForeColor = BlueBold;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.AutoSize = false;
        }
        public static void StyleComboBox(ComboBox cbo)
        {
            cbo.Font = H4;
            cbo.BackColor = Color.White;
            cbo.ForeColor = Black;
            

            cbo.FlatStyle = FlatStyle.Flat;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.Cursor = Cursors.Hand;
        }
        public static void StyleLink(LinkLabel link)
        {
            link.Font = H4;
            link.LinkColor = BlueBold;
            link.ActiveLinkColor = Blue;
            link.VisitedLinkColor = BlueBold;

            link.LinkBehavior = LinkBehavior.HoverUnderline;
            link.Cursor = Cursors.Hand;
            link.BackColor = Color.Transparent;
        }

    }
    }
