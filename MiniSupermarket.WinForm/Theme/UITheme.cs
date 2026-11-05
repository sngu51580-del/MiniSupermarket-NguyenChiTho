using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms.Theme
{
    public static class UITheme
    {
        // =========================================================
        // BẢNG MÀU CHUẨN DESIGN SYSTEM (ORGANIC & MODERN POS)
        // =========================================================

        // Primary Emerald Palette (Thương hiệu Siêu thị Nông sản / Thực phẩm xanh)
        public static readonly Color Primary = Color.FromArgb(139, 92, 246);        // Violet 500
        public static readonly Color PrimaryDark = Color.FromArgb(124, 58, 237);      // Violet 600
        public static readonly Color PrimaryDarker = Color.FromArgb(109, 40, 217);     // Violet 700
        public static readonly Color PrimaryLight = Color.FromArgb(221, 214, 254);   // Violet 200
        public static readonly Color PrimaryUltraLight = Color.FromArgb(245, 243, 255); // Violet 50

        // Slate / Navy Sidebar Palette
        public static readonly Color SidebarDark = Color.FromArgb(30, 27, 75);       // Indigo 950
        public static readonly Color SidebarDarkSecondary = Color.FromArgb(49, 46, 129); // Indigo 900
        public static readonly Color SidebarHover = Color.FromArgb(67, 56, 202);      // Indigo 700
        public static readonly Color SidebarActive = Color.FromArgb(124, 58, 237);    // Violet 600

        // Neutral & Background Surfaces
        public static readonly Color Background = Color.FromArgb(241, 245, 249);     // Slate 100
        public static readonly Color CardBg = Color.White;
        public static readonly Color BorderLight = Color.FromArgb(226, 232, 240);    // Slate 200
        public static readonly Color BorderSubtle = Color.FromArgb(203, 213, 225);   // Slate 300

        // Typography Colors
        public static readonly Color TextMain = Color.FromArgb(15, 23, 42);         // Slate 900
        public static readonly Color TextSecondary = Color.FromArgb(71, 85, 105);   // Slate 600
        public static readonly Color TextMuted = Color.FromArgb(148, 163, 184);     // Slate 400
        public static readonly Color TextLight = Color.White;

        // Semantic Accents
        public static readonly Color AccentBlue = Color.FromArgb(37, 99, 235);       // Blue 600
        public static readonly Color AccentBlueDark = Color.FromArgb(29, 78, 216);   // Blue 700
        public static readonly Color AccentBlueLight = Color.FromArgb(219, 234, 254);// Blue 100

        public static readonly Color AccentAmber = Color.FromArgb(217, 119, 6);      // Amber 600
        public static readonly Color AccentAmberLight = Color.FromArgb(254, 243, 199); // Amber 100

        public static readonly Color AccentRed = Color.FromArgb(220, 38, 38);        // Red 600
        public static readonly Color AccentRedDark = Color.FromArgb(185, 28, 28);    // Red 700
        public static readonly Color AccentRedLight = Color.FromArgb(254, 226, 226); // Red 100

        public static readonly Color AccentPurple = Color.FromArgb(124, 58, 237);    // Purple 600
        public static readonly Color AccentPurpleLight = Color.FromArgb(243, 232, 255); // Purple 100

        public static readonly Color AccentTeal = Color.FromArgb(13, 148, 136);      // Teal 600

        // =========================================================
        // FONTS
        // =========================================================
        public static readonly Font FontDisplayLarge = new Font("Segoe UI", 18F, FontStyle.Bold);
        public static readonly Font FontHeader = new Font("Segoe UI", 13.5F, FontStyle.Bold);
        public static readonly Font FontSubHeader = new Font("Segoe UI", 11F, FontStyle.Bold);
        public static readonly Font FontBody = new Font("Segoe UI", 9.75F, FontStyle.Regular);
        public static readonly Font FontBodyBold = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        public static readonly Font FontSmall = new Font("Segoe UI", 8.5F, FontStyle.Regular);
        public static readonly Font FontSmallBold = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        public static readonly Font FontPriceDisplay = new Font("Segoe UI", 20F, FontStyle.Bold);

        // =========================================================
        // BUTTON VARIANTS
        // =========================================================
        public enum ButtonVariant
        {
            Primary,       // Emerald
            Secondary,     // Modern Blue
            Success,       // Forest Green
            Danger,        // Crimson Red
            Warning,       // Amber
            Neutral,       // Crisp Light Gray
            Dark,          // Deep Slate
            OutlinePrimary // White bg with Emerald border
        }

        public static void StyleButton(Button btn, ButtonVariant variant)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = FontBodyBold;

            switch (variant)
            {
                case ButtonVariant.Primary:
                    btn.BackColor = PrimaryDark;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = Primary;
                    btn.FlatAppearance.MouseDownBackColor = PrimaryDarker;
                    break;

                case ButtonVariant.Secondary:
                    btn.BackColor = AccentBlue;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
                    btn.FlatAppearance.MouseDownBackColor = AccentBlueDark;
                    break;

                case ButtonVariant.Success:
                    btn.BackColor = Color.FromArgb(22, 163, 74);
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(34, 197, 94);
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(21, 128, 61);
                    break;

                case ButtonVariant.Danger:
                    btn.BackColor = AccentRed;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 68, 68);
                    btn.FlatAppearance.MouseDownBackColor = AccentRedDark;
                    break;

                case ButtonVariant.Warning:
                    btn.BackColor = AccentAmber;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 158, 11);
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 83, 9);
                    break;

                case ButtonVariant.Neutral:
                    btn.BackColor = Color.FromArgb(241, 245, 249);
                    btn.ForeColor = TextMain;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = BorderLight;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 232, 240);
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(203, 213, 225);
                    break;

                case ButtonVariant.Dark:
                    btn.BackColor = SidebarDarkSecondary;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = SidebarHover;
                    btn.FlatAppearance.MouseDownBackColor = SidebarDark;
                    break;

                case ButtonVariant.OutlinePrimary:
                    btn.BackColor = Color.White;
                    btn.ForeColor = PrimaryDark;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Primary;
                    btn.FlatAppearance.MouseOverBackColor = PrimaryUltraLight;
                    btn.FlatAppearance.MouseDownBackColor = PrimaryLight;
                    break;
            }
        }

        // =========================================================
        // STYLING DATAGRIDVIEW
        // =========================================================
        public static void ApplyModernDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(241, 245, 249);
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // Column Header
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 46, 129);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);

            // Row Template
            dgv.RowTemplate.Height = 36;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(237, 233, 254); // Soft purple tint
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);    // Readable dark text!
            dgv.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);

            // Alternating Row
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(237, 233, 254);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgv.AlternatingRowsDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
        }

        // =========================================================
        // CARD BORDER & PANEL STYLING
        // =========================================================
        public static void ApplyCardStyle(Panel panel, Color? borderColor = null)
        {
            panel.BackColor = Color.White;
            Color border = borderColor ?? BorderLight;
            panel.Paint += (s, e) =>
            {
                using var pen = new Pen(border, 1f);
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            };
        }

        public static void ApplyCardStyle(GroupBox grp, Color? borderColor = null)
        {
            grp.BackColor = Color.White;
            grp.Font = FontSubHeader;
            grp.ForeColor = TextMain;
        }

        // =========================================================
        // INPUT STYLING
        // =========================================================
        public static void ApplyModernInput(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
            txt.ForeColor = TextMain;
        }

        public static void ApplyModernComboBox(ComboBox cbo)
        {
            cbo.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.BackColor = Color.White;
            cbo.ForeColor = TextMain;
        }
    }
}
