
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Runtime.InteropServices;
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
        public static readonly Color Green = Color.FromArgb(17, 169, 77);


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
            form.BackColor = Color.FromArgb(248, 249, 251);

            form.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void StyleLabel(Label lbl)
        {
            lbl.Font = H3;
            lbl.ForeColor = Color.Black;
        }

        public static void StyleTextBox(TextBox txt)
        {
            txt.Font = H3;
            txt.BackColor = Color.White;
            txt.ForeColor = Color.Black;
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
            cbo.ForeColor = Color.Black;
            

            cbo.FlatStyle = FlatStyle.Flat;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.Cursor = Cursors.Hand;
        }
        public static void StyleLink(LinkLabel link)
        {
            link.Font = H4;
            link.LinkColor = BlueBold;
            link.ActiveLinkColor = Color.RoyalBlue;
            link.VisitedLinkColor = BlueBold;

            link.LinkBehavior = LinkBehavior.HoverUnderline;
            link.Cursor = Cursors.Hand;
            link.BackColor = Color.Transparent;
        }

    }
    }
