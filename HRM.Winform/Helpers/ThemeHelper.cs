namespace HRM.Winform.Helpers
{
    public static class ThemeHelper
    {
        public static Color AppBackColor => Color.FromArgb(236, 243, 250);
        public static Color CardBackColor => Color.White;
        public static Color CardMutedBackColor => Color.FromArgb(247, 250, 252);
        public static Color SidebarBackColor => Color.FromArgb(18, 32, 56);
        public static Color SidebarHeaderColor => Color.FromArgb(27, 46, 78);
        public static Color PrimaryColor => Color.FromArgb(27, 110, 223);
        public static Color SecondaryAccent => Color.FromArgb(18, 184, 134);
        public static Color WarmAccent => Color.FromArgb(249, 115, 22);
        public static Color DangerColor => Color.FromArgb(239, 68, 68);
        public static Color BorderColor => Color.FromArgb(223, 232, 242);
        public static Color ListBandColor => Color.FromArgb(248, 251, 255);
        public static Color GridHeaderBackColor => Color.FromArgb(250, 252, 255);
        public static Color GridHeaderBorderColor => Color.FromArgb(209, 221, 236);
        public static Color GridSelectionColor => Color.FromArgb(225, 236, 252);
        public static Color TextPrimary => Color.FromArgb(15, 23, 42);
        public static Color TextSecondary => Color.FromArgb(92, 108, 131);

        public static void ApplyPrimaryButton(Button button)
        {
            button.BackColor = PrimaryColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        public static void ApplySecondaryButton(Button button)
        {
            button.BackColor = CardBackColor;
            button.ForeColor = PrimaryColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(186, 216, 255);
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        public static void ApplySuccessButton(Button button)
        {
            button.BackColor = CardBackColor;
            button.ForeColor = SecondaryAccent;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(167, 243, 208);
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        public static void ApplyDangerButton(Button button)
        {
            button.BackColor = DangerColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        public static void ApplyInput(Control control)
        {
            control.BackColor = CardMutedBackColor;
            control.ForeColor = TextPrimary;

            if (control is TextBox textBox)
            {
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        public static void ApplyCard(Panel panel)
        {
            panel.BackColor = CardBackColor;
            panel.Paint -= DrawCardBorder;
            panel.Paint += DrawCardBorder;
        }

        public static void ApplyMutedCard(Panel panel)
        {
            panel.BackColor = CardMutedBackColor;
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
            grid.ColumnHeadersHeight = 34;
            grid.RowTemplate.Height = 32;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBackColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = GridHeaderBackColor;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = TextPrimary;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.25F);
            grid.DefaultCellStyle.BackColor = CardBackColor;
            grid.DefaultCellStyle.ForeColor = TextPrimary;
            grid.DefaultCellStyle.SelectionBackColor = GridSelectionColor;
            grid.DefaultCellStyle.SelectionForeColor = TextPrimary;
            grid.DefaultCellStyle.Padding = new Padding(3, 0, 3, 0);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(251, 253, 255);
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = GridSelectionColor;
        }

        private static void DrawCardBorder(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel panel)
            {
                return;
            }

            using var pen = new Pen(BorderColor);
            e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
        }
    }
}
