namespace HRM.Winform.Forms.HeThong
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Panel pnlSidebar;
        private Panel pnlSidebarHeader;
        private Label lblAppName;
        private Label lblAppSubtitle;
        private FlowLayoutPanel flpNavigation;
        private Panel pnlSidebarFooter;
        private Label lblCurrentUser;
        private Label lblCurrentRole;
        private Panel pnlShell;
        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private FlowLayoutPanel flpHeaderActions;
        private Button btnDashboard;
        private Button btnDoiMatKhau;
        private Button btnDangXuat;
        private Panel pnlMainContent;
        private Panel pnlDashboard;
        private Label lblDashboardTitle;
        private Label lblDashboardSubtitle;
        private TableLayoutPanel tlpStats;
        private Label lblAiHighlights;
        private FlowLayoutPanel flpAiHighlights;
        private Label lblQuickActions;
        private FlowLayoutPanel flpQuickActions;
        private Panel pnlFormHost;

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            flpNavigation = new FlowLayoutPanel();
            pnlSidebarFooter = new Panel();
            lblCurrentRole = new Label();
            lblCurrentUser = new Label();
            pnlSidebarHeader = new Panel();
            lblAppSubtitle = new Label();
            lblAppName = new Label();
            pnlShell = new Panel();
            pnlMainContent = new Panel();
            pnlFormHost = new Panel();
            pnlDashboard = new Panel();
            flpQuickActions = new FlowLayoutPanel();
            flpAiHighlights = new FlowLayoutPanel();
            lblAiHighlights = new Label();
            lblQuickActions = new Label();
            tlpStats = new TableLayoutPanel();
            lblDashboardSubtitle = new Label();
            lblDashboardTitle = new Label();
            pnlHeader = new Panel();
            flpHeaderActions = new FlowLayoutPanel();
            btnDangXuat = new Button();
            btnDoiMatKhau = new Button();
            btnDashboard = new Button();
            lblHeaderSubtitle = new Label();
            lblHeaderTitle = new Label();
            pnlSidebar.SuspendLayout();
            pnlSidebarFooter.SuspendLayout();
            pnlSidebarHeader.SuspendLayout();
            pnlShell.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlDashboard.SuspendLayout();
            pnlHeader.SuspendLayout();
            flpHeaderActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(flpNavigation);
            pnlSidebar.Controls.Add(pnlSidebarFooter);
            pnlSidebar.Controls.Add(pnlSidebarHeader);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(280, 761);
            pnlSidebar.TabIndex = 0;
            // 
            // flpNavigation
            // 
            flpNavigation.AutoScroll = true;
            flpNavigation.Dock = DockStyle.Fill;
            flpNavigation.FlowDirection = FlowDirection.TopDown;
            flpNavigation.Location = new Point(0, 112);
            flpNavigation.Name = "flpNavigation";
            flpNavigation.Size = new Size(280, 563);
            flpNavigation.TabIndex = 1;
            flpNavigation.WrapContents = false;
            // 
            // pnlSidebarFooter
            // 
            pnlSidebarFooter.Controls.Add(lblCurrentRole);
            pnlSidebarFooter.Controls.Add(lblCurrentUser);
            pnlSidebarFooter.Dock = DockStyle.Bottom;
            pnlSidebarFooter.Location = new Point(0, 675);
            pnlSidebarFooter.Name = "pnlSidebarFooter";
            pnlSidebarFooter.Size = new Size(280, 86);
            pnlSidebarFooter.TabIndex = 2;
            // 
            // lblCurrentRole
            // 
            lblCurrentRole.AutoSize = true;
            lblCurrentRole.Location = new Point(24, 44);
            lblCurrentRole.Name = "lblCurrentRole";
            lblCurrentRole.Size = new Size(100, 20);
            lblCurrentRole.TabIndex = 1;
            lblCurrentRole.Text = "Role  |  @user";
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.AutoSize = true;
            lblCurrentUser.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCurrentUser.Location = new Point(24, 16);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(145, 25);
            lblCurrentUser.TabIndex = 0;
            lblCurrentUser.Text = "Current User";
            // 
            // pnlSidebarHeader
            // 
            pnlSidebarHeader.Controls.Add(lblAppSubtitle);
            pnlSidebarHeader.Controls.Add(lblAppName);
            pnlSidebarHeader.Dock = DockStyle.Top;
            pnlSidebarHeader.Location = new Point(0, 0);
            pnlSidebarHeader.Name = "pnlSidebarHeader";
            pnlSidebarHeader.Size = new Size(280, 112);
            pnlSidebarHeader.TabIndex = 0;
            // 
            // lblAppSubtitle
            // 
            lblAppSubtitle.AutoSize = true;
            lblAppSubtitle.Location = new Point(24, 70);
            lblAppSubtitle.Name = "lblAppSubtitle";
            lblAppSubtitle.Size = new Size(170, 20);
            lblAppSubtitle.TabIndex = 1;
            lblAppSubtitle.Text = "Human Resource Manager";
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAppName.Location = new Point(24, 24);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(80, 37);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "HRM";
            // 
            // pnlShell
            // 
            pnlShell.Controls.Add(pnlMainContent);
            pnlShell.Controls.Add(pnlHeader);
            pnlShell.Dock = DockStyle.Fill;
            pnlShell.Location = new Point(280, 0);
            pnlShell.Name = "pnlShell";
            pnlShell.Size = new Size(1084, 761);
            pnlShell.TabIndex = 1;
            // 
            // pnlMainContent
            // 
            pnlMainContent.Controls.Add(pnlFormHost);
            pnlMainContent.Controls.Add(pnlDashboard);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(0, 94);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1084, 667);
            pnlMainContent.TabIndex = 1;
            // 
            // pnlFormHost
            // 
            pnlFormHost.Dock = DockStyle.Fill;
            pnlFormHost.Location = new Point(0, 0);
            pnlFormHost.Name = "pnlFormHost";
            pnlFormHost.Size = new Size(1084, 667);
            pnlFormHost.TabIndex = 1;
            pnlFormHost.Visible = false;
            // 
            // pnlDashboard
            // 
            pnlDashboard.AutoScroll = true;
            pnlDashboard.Controls.Add(flpQuickActions);
            pnlDashboard.Controls.Add(lblQuickActions);
            pnlDashboard.Controls.Add(flpAiHighlights);
            pnlDashboard.Controls.Add(lblAiHighlights);
            pnlDashboard.Controls.Add(tlpStats);
            pnlDashboard.Controls.Add(lblDashboardSubtitle);
            pnlDashboard.Controls.Add(lblDashboardTitle);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 0);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(1084, 667);
            pnlDashboard.TabIndex = 0;
            // 
            // flpQuickActions
            // 
            flpQuickActions.AutoSize = true;
            flpQuickActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpQuickActions.Location = new Point(28, 434);
            flpQuickActions.Name = "flpQuickActions";
            flpQuickActions.Size = new Size(1018, 140);
            flpQuickActions.TabIndex = 4;
            // 
            // flpAiHighlights
            // 
            flpAiHighlights.AutoSize = true;
            flpAiHighlights.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpAiHighlights.Location = new Point(28, 230);
            flpAiHighlights.Name = "flpAiHighlights";
            flpAiHighlights.Size = new Size(1018, 160);
            flpAiHighlights.TabIndex = 5;
            // 
            // lblAiHighlights
            // 
            lblAiHighlights.AutoSize = true;
            lblAiHighlights.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAiHighlights.Location = new Point(28, 192);
            lblAiHighlights.Name = "lblAiHighlights";
            lblAiHighlights.Size = new Size(165, 28);
            lblAiHighlights.TabIndex = 6;
            lblAiHighlights.Text = "Dashboard AI mini";
            // 
            // lblQuickActions
            // 
            lblQuickActions.AutoSize = true;
            lblQuickActions.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQuickActions.Location = new Point(28, 396);
            lblQuickActions.Name = "lblQuickActions";
            lblQuickActions.Size = new Size(152, 28);
            lblQuickActions.TabIndex = 3;
            lblQuickActions.Text = "Truy cap nhanh";
            // 
            // tlpStats
            // 
            tlpStats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpStats.ColumnCount = 4;
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpStats.Location = new Point(28, 90);
            tlpStats.Name = "tlpStats";
            tlpStats.RowCount = 1;
            tlpStats.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpStats.Size = new Size(1018, 96);
            tlpStats.TabIndex = 2;
            // 
            // lblDashboardSubtitle
            // 
            lblDashboardSubtitle.AutoSize = true;
            lblDashboardSubtitle.Location = new Point(28, 52);
            lblDashboardSubtitle.Name = "lblDashboardSubtitle";
            lblDashboardSubtitle.Size = new Size(293, 20);
            lblDashboardSubtitle.TabIndex = 1;
            lblDashboardSubtitle.Text = "Tong quan cong viec, quyen han va cac muc uu tien.";
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblDashboardTitle.Location = new Point(28, 12);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(170, 41);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Dashboard";
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(flpHeaderActions);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1084, 94);
            pnlHeader.TabIndex = 0;
            // 
            // flpHeaderActions
            // 
            flpHeaderActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpHeaderActions.AutoSize = true;
            flpHeaderActions.Controls.Add(btnDangXuat);
            flpHeaderActions.Controls.Add(btnDoiMatKhau);
            flpHeaderActions.Controls.Add(btnDashboard);
            flpHeaderActions.FlowDirection = FlowDirection.RightToLeft;
            flpHeaderActions.Location = new Point(665, 20);
            flpHeaderActions.Name = "flpHeaderActions";
            flpHeaderActions.Size = new Size(391, 42);
            flpHeaderActions.TabIndex = 2;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Location = new Point(261, 0);
            btnDangXuat.Margin = new Padding(0);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(130, 42);
            btnDangXuat.TabIndex = 0;
            btnDangXuat.Text = "Dang xuat";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.Location = new Point(122, 0);
            btnDoiMatKhau.Margin = new Padding(9, 0, 0, 0);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(130, 42);
            btnDoiMatKhau.TabIndex = 1;
            btnDoiMatKhau.Text = "Doi mat khau";
            btnDoiMatKhau.UseVisualStyleBackColor = true;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Location = new Point(0, 0);
            btnDashboard.Margin = new Padding(9, 0, 0, 0);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(113, 42);
            btnDashboard.TabIndex = 2;
            btnDashboard.Text = "Trang chu";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Location = new Point(28, 55);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(191, 20);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Thong tin tong quan he thong";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeaderTitle.Location = new Point(28, 14);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(152, 41);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Trang chu";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1364, 761);
            Controls.Add(pnlShell);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1180, 720);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HRM - Quan ly nhan su";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            pnlSidebar.ResumeLayout(false);
            pnlSidebarFooter.ResumeLayout(false);
            pnlSidebarFooter.PerformLayout();
            pnlSidebarHeader.ResumeLayout(false);
            pnlSidebarHeader.PerformLayout();
            pnlShell.ResumeLayout(false);
            pnlMainContent.ResumeLayout(false);
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            flpHeaderActions.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
