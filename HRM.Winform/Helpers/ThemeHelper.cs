namespace HRM.Winform.Helpers
{
    public static class ThemeHelper
    {
        public static Color AppBackColor => Color.FromArgb(242, 250, 255);
        public static Color CardBackColor => Color.FromArgb(255, 255, 255);
        public static Color CardMutedBackColor => Color.FromArgb(247, 252, 255);
        public static Color SidebarBackColor => Color.FromArgb(17, 58, 128);
        public static Color SidebarHeaderColor => Color.FromArgb(0, 196, 255);
        public static Color PrimaryColor => Color.FromArgb(58, 134, 255);
        public static Color SecondaryAccent => Color.FromArgb(0, 191, 166);
        public static Color WarmAccent => Color.FromArgb(255, 183, 3);
        public static Color DangerColor => Color.FromArgb(255, 107, 53);
        public static Color BorderColor => Color.FromArgb(205, 226, 245);
        public static Color ListBandColor => Color.FromArgb(246, 251, 255);
        public static Color GridHeaderBackColor => Color.FromArgb(232, 245, 255);
        public static Color GridHeaderBorderColor => Color.FromArgb(191, 223, 247);
        public static Color GridSelectionColor => Color.FromArgb(214, 236, 255);
        public static Color TextPrimary => Color.FromArgb(24, 38, 71);
        public static Color TextSecondary => Color.FromArgb(96, 122, 161);
        public static Color AccentPurple => Color.FromArgb(108, 99, 255);
        public static Color AccentSky => Color.FromArgb(0, 196, 255);
        public static Color CardShadowColor => Color.FromArgb(209, 235, 255);

        public static void ApplyPrimaryButton(Button button)
        {
            StyleButton(button, PrimaryColor, Color.White, 0, PrimaryColor, Color.FromArgb(39, 119, 246), Color.FromArgb(28, 98, 220));
        }

        public static void ApplySecondaryButton(Button button)
        {
            StyleButton(button, Color.FromArgb(243, 249, 255), PrimaryColor, 1, Color.FromArgb(176, 220, 255), Color.FromArgb(232, 244, 255), Color.FromArgb(219, 237, 255));
        }

        public static void ApplySuccessButton(Button button)
        {
            StyleButton(button, Color.FromArgb(236, 255, 252), SecondaryAccent, 1, Color.FromArgb(150, 236, 223), Color.FromArgb(223, 252, 247), Color.FromArgb(206, 248, 240));
        }

        public static void ApplyDangerButton(Button button)
        {
            StyleButton(button, DangerColor, Color.White, 0, DangerColor, Color.FromArgb(246, 92, 36), Color.FromArgb(228, 77, 22));
        }

        public static void ApplyInput(Control control)
        {
            control.BackColor = Color.FromArgb(251, 254, 255);
            control.ForeColor = TextPrimary;
            control.Font = new Font("Segoe UI", 10F);

            if (control is TextBox textBox)
            {
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }

            if (control is ComboBox comboBox)
            {
                comboBox.FlatStyle = FlatStyle.Flat;
            }

            if (control is DateTimePicker dateTimePicker)
            {
                dateTimePicker.CalendarForeColor = TextPrimary;
                dateTimePicker.CalendarMonthBackground = CardBackColor;
            }

            if (control is NumericUpDown numericUpDown)
            {
                numericUpDown.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        public static void ApplyCard(Panel panel)
        {
            panel.BackColor = CardBackColor;
            ApplyRoundedRegion(panel, 22);
            panel.Paint -= DrawCardBorder;
            panel.Paint += DrawCardBorder;
        }

        public static void ApplyMutedCard(Panel panel)
        {
            panel.BackColor = CardMutedBackColor;
            ApplyRoundedRegion(panel, 22);
            panel.Paint -= DrawCardBorder;
            panel.Paint += DrawCardBorder;
        }

        public static void ApplyDataGrid(DataGridView grid)
        {
            grid.BackgroundColor = CardBackColor;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.GridColor = GridHeaderBorderColor;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeight = 38;
            grid.RowTemplate.Height = 36;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBackColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = PrimaryColor;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = GridHeaderBackColor;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = PrimaryColor;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.25F);
            grid.DefaultCellStyle.BackColor = CardBackColor;
            grid.DefaultCellStyle.ForeColor = TextPrimary;
            grid.DefaultCellStyle.SelectionBackColor = GridSelectionColor;
            grid.DefaultCellStyle.SelectionForeColor = TextPrimary;
            grid.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.AlternatingRowsDefaultCellStyle.BackColor = ListBandColor;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = GridSelectionColor;
        }

        private static void StyleButton(Button button, Color backColor, Color foreColor, int borderSize, Color borderColor, Color hoverColor, Color pressedColor)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = borderSize;
            button.FlatAppearance.BorderColor = borderColor;
            button.FlatAppearance.MouseOverBackColor = hoverColor;
            button.FlatAppearance.MouseDownBackColor = pressedColor;
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            ApplyRoundedRegion(button, 16);
        }

        private static void ApplyRoundedRegion(Control control, int radius)
        {
            void ApplyRegion()
            {
                if (control.Width <= 0 || control.Height <= 0)
                {
                    return;
                }

                control.Region?.Dispose();
                control.Region = new Region(CreateRoundedPath(new Rectangle(0, 0, control.Width, control.Height), radius));
            }

            ApplyRegion();
            control.Resize -= Control_Resize;
            control.Resize += Control_Resize;

            void Control_Resize(object? sender, EventArgs e)
            {
                ApplyRegion();
            }
        }

        private static void DrawCardBorder(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel panel)
            {
                return;
            }

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using var path = CreateRoundedPath(new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 22);
            using var pen = new Pen(BorderColor);
            e.Graphics.DrawPath(pen, path);
        }

        public static System.Drawing.Drawing2D.GraphicsPath CreateRoundedPath(Rectangle bounds, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
