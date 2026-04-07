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
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = BorderColor;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeight = 40;
            grid.RowTemplate.Height = 36;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(244, 247, 251);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grid.DefaultCellStyle.BackColor = CardBackColor;
            grid.DefaultCellStyle.ForeColor = TextPrimary;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 236, 255);
            grid.DefaultCellStyle.SelectionForeColor = TextPrimary;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 255);
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
