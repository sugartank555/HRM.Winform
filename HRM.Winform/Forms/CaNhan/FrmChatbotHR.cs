using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.CaNhan
{
    public class FrmChatbotHR : Form
    {
        private readonly Label lblTitle = new();
        private readonly Label lblSubtitle = new();
        private readonly ComboBox cboNhanVien = new();
        private readonly Label lblNhanVien = new();
        private readonly RichTextBox rtbChat = new();
        private readonly TextBox txtQuestion = new();
        private readonly Button btnSend = new();
        private readonly FlowLayoutPanel flpQuickAsk = new();

        public FrmChatbotHR()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Text = "Chatbot HR noi bo";
            BackColor = ThemeHelper.AppBackColor;
            ClientSize = new Size(1180, 760);
            MinimumSize = new Size(1000, 680);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = ThemeHelper.TextPrimary;
            lblTitle.Location = new Point(24, 22);
            lblTitle.Text = "Chatbot HR noi bo";

            lblSubtitle.AutoSize = false;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = ThemeHelper.TextSecondary;
            lblSubtitle.Location = new Point(26, 62);
            lblSubtitle.Size = new Size(760, 24);
            lblSubtitle.Text = "Hoi nhanh ve ca hom nay, cong, phep, don tu, di muon va tang ca tren du lieu thuc te.";

            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(28, 104);
            lblNhanVien.Text = "Nguoi duoc hoi";

            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(130, 100);
            cboNhanVien.Size = new Size(300, 28);

            flpQuickAsk.Location = new Point(24, 144);
            flpQuickAsk.Size = new Size(1132, 44);
            flpQuickAsk.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpQuickAsk.WrapContents = false;

            rtbChat.Location = new Point(24, 202);
            rtbChat.Size = new Size(1132, 448);
            rtbChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbChat.ReadOnly = true;
            rtbChat.BorderStyle = BorderStyle.None;
            rtbChat.BackColor = Color.White;
            rtbChat.Font = new Font("Segoe UI", 10F);

            txtQuestion.Location = new Point(24, 670);
            txtQuestion.Size = new Size(970, 27);
            txtQuestion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtQuestion.PlaceholderText = "Nhap cau hoi, vi du: Toi con bao nhieu ngay phep?";
            txtQuestion.KeyDown += txtQuestion_KeyDown;

            btnSend.Location = new Point(1012, 664);
            btnSend.Size = new Size(144, 38);
            btnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSend.Text = "Gui cau hoi";
            btnSend.Click += btnSend_Click;

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(lblNhanVien);
            Controls.Add(cboNhanVien);
            Controls.Add(flpQuickAsk);
            Controls.Add(rtbChat);
            Controls.Add(txtQuestion);
            Controls.Add(btnSend);

            Load += FrmChatbotHR_Load;
            ResumeLayout(false);
        }

        private void FrmChatbotHR_Load(object? sender, EventArgs e)
        {
            ThemeHelper.ApplyInput(cboNhanVien);
            ThemeHelper.ApplyInput(txtQuestion);
            ThemeHelper.ApplyPrimaryButton(btnSend);
            TaiNhanVien();
            BuildQuickQuestions();
            AppendBot(InternalHrChatbotService.BuildGreeting(CurrentUser.HoTen));
        }

        private void TaiNhanVien()
        {
            using var db = new AppDbContext();
            var ds = db.NhanViens
                .AsNoTracking()
                .Where(x => x.DangLamViec)
                .OrderBy(x => x.HoTen)
                .Select(x => new
                {
                    x.Id,
                    HienThi = x.MaNhanVien + " - " + x.HoTen
                })
                .ToList();

            cboNhanVien.DataSource = ds;
            cboNhanVien.DisplayMember = "HienThi";
            cboNhanVien.ValueMember = "Id";

            int selectedIndex = ds.FindIndex(x => x.Id == CurrentUser.NhanVienId);
            cboNhanVien.SelectedIndex = selectedIndex >= 0 ? selectedIndex : 0;

            bool laNhanVien = string.Equals(CurrentUser.VaiTro, "NhanVien", StringComparison.OrdinalIgnoreCase);
            cboNhanVien.Enabled = !laNhanVien;
            lblNhanVien.Visible = !laNhanVien;
            cboNhanVien.Visible = !laNhanVien;
        }

        private void BuildQuickQuestions()
        {
            flpQuickAsk.Controls.Clear();
            AddQuickButton("Ca hom nay", "Ca hom nay cua toi la gi?");
            AddQuickButton("Cong hom nay", "Cong hom nay cua toi the nao?");
            AddQuickButton("Phep con lai", "Toi con bao nhieu ngay phep?");
            AddQuickButton("Don cua toi", "Don cua toi da duyet chua?");
            AddQuickButton("Di muon", "Thang nay toi di muon may lan?");
            AddQuickButton("Tang ca", "OT thang nay cua toi bao nhieu gio?");
            AddQuickButton("Check-in gan nhat", "Lan check-in gan nhat cua toi bang gi?");
            AddQuickButton("Xac thuc hom nay", "Hom nay xac thuc cua toi co thanh cong khong?");
        }

        private void AddQuickButton(string text, string question)
        {
            var button = new Button
            {
                Text = text,
                Width = 150,
                Height = 34,
                Margin = new Padding(0, 0, 12, 0),
                Tag = question
            };
            ThemeHelper.ApplySecondaryButton(button);
            button.Click += (_, _) =>
            {
                txtQuestion.Text = question;
                GuiCauHoi();
            };
            flpQuickAsk.Controls.Add(button);
        }

        private void btnSend_Click(object? sender, EventArgs e)
        {
            GuiCauHoi();
        }

        private void txtQuestion_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                GuiCauHoi();
            }
        }

        private void GuiCauHoi()
        {
            string question = txtQuestion.Text.Trim();
            if (string.IsNullOrWhiteSpace(question))
            {
                return;
            }

            int nhanVienId = GetNhanVienId();
            AppendUser(question);
            string answer = InternalHrChatbotService.Ask(question, nhanVienId);
            AppendBot(answer);
            txtQuestion.Clear();
            txtQuestion.Focus();
        }

        private int GetNhanVienId()
        {
            if (!cboNhanVien.Visible)
            {
                return CurrentUser.NhanVienId;
            }

            return int.TryParse(cboNhanVien.SelectedValue?.ToString(), out int id)
                ? id
                : CurrentUser.NhanVienId;
        }

        private void AppendUser(string text)
        {
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionColor = ThemeHelper.PrimaryColor;
            rtbChat.SelectionFont = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            rtbChat.AppendText($"Ban: {text}{Environment.NewLine}");
            rtbChat.SelectionColor = ThemeHelper.TextPrimary;
            rtbChat.SelectionFont = new Font("Segoe UI", 10F);
        }

        private void AppendBot(string text)
        {
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionColor = ThemeHelper.SecondaryAccent;
            rtbChat.SelectionFont = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            rtbChat.AppendText($"Tro ly HR: {text}{Environment.NewLine}{Environment.NewLine}");
            rtbChat.SelectionColor = ThemeHelper.TextPrimary;
            rtbChat.SelectionFont = new Font("Segoe UI", 10F);
            rtbChat.ScrollToCaret();
        }
    }
}
