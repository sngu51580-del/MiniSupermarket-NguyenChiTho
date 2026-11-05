namespace MiniSupermarket.WinForms
{
    partial class FormMainShell
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelSidebar = new Panel();
            btnUserManage = new Button();
            btnReports = new Button();
            lblNavAdmin = new Label();
            btnCustomer = new Button();
            btnProduct = new Button();
            btnCategory = new Button();
            lblNavStore = new Label();
            btnPOS = new Button();
            lblNavSales = new Label();
            panelLogo = new Panel();
            lblLogoTag = new Label();
            lblLogoSub = new Label();
            lblLogo = new Label();
            panelUserFooter = new Panel();
            btnLogout = new Button();
            lblUserRoleBadge = new Label();
            lblUserFullName = new Label();
            lblAvatar = new Label();
            panelTopHeader = new Panel();
            flowHeaderRight = new FlowLayoutPanel();
            lblUserInfo = new Label();
            lblClock = new Label();
            lblServerStatus = new Label();
            lblBreadcrumb = new Label();
            lblTitle = new Label();
            panelMainContent = new Panel();
            timerClock = new System.Windows.Forms.Timer(components);
            panelSidebar.SuspendLayout();
            panelLogo.SuspendLayout();
            panelUserFooter.SuspendLayout();
            panelTopHeader.SuspendLayout();
            flowHeaderRight.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(30, 27, 75);
            panelSidebar.Controls.Add(btnUserManage);
            panelSidebar.Controls.Add(btnReports);
            panelSidebar.Controls.Add(lblNavAdmin);
            panelSidebar.Controls.Add(btnCustomer);
            panelSidebar.Controls.Add(btnProduct);
            panelSidebar.Controls.Add(btnCategory);
            panelSidebar.Controls.Add(lblNavStore);
            panelSidebar.Controls.Add(btnPOS);
            panelSidebar.Controls.Add(lblNavSales);
            panelSidebar.Controls.Add(panelLogo);
            panelSidebar.Controls.Add(panelUserFooter);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(260, 760);
            panelSidebar.TabIndex = 0;
            // 
            // btnUserManage
            // 
            btnUserManage.BackColor = Color.FromArgb(30, 27, 75);
            btnUserManage.Cursor = Cursors.Hand;
            btnUserManage.Dock = DockStyle.Top;
            btnUserManage.FlatAppearance.BorderSize = 0;
            btnUserManage.FlatAppearance.MouseDownBackColor = Color.FromArgb(49, 46, 129);
            btnUserManage.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 56, 202);
            btnUserManage.FlatStyle = FlatStyle.Flat;
            btnUserManage.Font = new Font("Segoe UI", 10F);
            btnUserManage.ForeColor = Color.FromArgb(226, 232, 240);
            btnUserManage.Location = new Point(0, 403);
            btnUserManage.Name = "btnUserManage";
            btnUserManage.Padding = new Padding(15, 0, 0, 0);
            btnUserManage.Size = new Size(260, 46);
            btnUserManage.TabIndex = 6;
            btnUserManage.Text = "   🛡️  Quản Trị Tài Khoản";
            btnUserManage.TextAlign = ContentAlignment.MiddleLeft;
            btnUserManage.UseMnemonic = false;
            btnUserManage.UseVisualStyleBackColor = false;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(30, 27, 75);
            btnReports.Cursor = Cursors.Hand;
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatAppearance.MouseDownBackColor = Color.FromArgb(49, 46, 129);
            btnReports.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 56, 202);
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 10F);
            btnReports.ForeColor = Color.FromArgb(226, 232, 240);
            btnReports.Location = new Point(0, 357);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(15, 0, 0, 0);
            btnReports.Size = new Size(260, 46);
            btnReports.TabIndex = 5;
            btnReports.Text = "   📊  Báo Cáo Doanh Thu";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseMnemonic = false;
            btnReports.UseVisualStyleBackColor = false;
            // 
            // lblNavAdmin
            // 
            lblNavAdmin.Dock = DockStyle.Top;
            lblNavAdmin.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNavAdmin.ForeColor = Color.FromArgb(100, 116, 139);
            lblNavAdmin.Location = new Point(0, 329);
            lblNavAdmin.Name = "lblNavAdmin";
            lblNavAdmin.Padding = new Padding(18, 10, 0, 0);
            lblNavAdmin.Size = new Size(260, 28);
            lblNavAdmin.TabIndex = 11;
            lblNavAdmin.Text = "QUẢN TRỊ & THỐNG KÊ";
            lblNavAdmin.UseMnemonic = false;
            // 
            // btnCustomer
            // 
            btnCustomer.BackColor = Color.FromArgb(30, 27, 75);
            btnCustomer.Cursor = Cursors.Hand;
            btnCustomer.Dock = DockStyle.Top;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatAppearance.MouseDownBackColor = Color.FromArgb(49, 46, 129);
            btnCustomer.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 56, 202);
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.Font = new Font("Segoe UI", 10F);
            btnCustomer.ForeColor = Color.FromArgb(226, 232, 240);
            btnCustomer.Location = new Point(0, 283);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Padding = new Padding(15, 0, 0, 0);
            btnCustomer.Size = new Size(260, 46);
            btnCustomer.TabIndex = 4;
            btnCustomer.Text = "   👥  Khách Hàng & Hội Viên";
            btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomer.UseMnemonic = false;
            btnCustomer.UseVisualStyleBackColor = false;
            // 
            // btnProduct
            // 
            btnProduct.BackColor = Color.FromArgb(30, 27, 75);
            btnProduct.Cursor = Cursors.Hand;
            btnProduct.Dock = DockStyle.Top;
            btnProduct.FlatAppearance.BorderSize = 0;
            btnProduct.FlatAppearance.MouseDownBackColor = Color.FromArgb(49, 46, 129);
            btnProduct.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 56, 202);
            btnProduct.FlatStyle = FlatStyle.Flat;
            btnProduct.Font = new Font("Segoe UI", 10F);
            btnProduct.ForeColor = Color.FromArgb(226, 232, 240);
            btnProduct.Location = new Point(0, 237);
            btnProduct.Name = "btnProduct";
            btnProduct.Padding = new Padding(15, 0, 0, 0);
            btnProduct.Size = new Size(260, 46);
            btnProduct.TabIndex = 3;
            btnProduct.Text = "   📦  Quản Lý Sản Phẩm";
            btnProduct.TextAlign = ContentAlignment.MiddleLeft;
            btnProduct.UseMnemonic = false;
            btnProduct.UseVisualStyleBackColor = false;
            // 
            // btnCategory
            // 
            btnCategory.BackColor = Color.FromArgb(30, 27, 75);
            btnCategory.Cursor = Cursors.Hand;
            btnCategory.Dock = DockStyle.Top;
            btnCategory.FlatAppearance.BorderSize = 0;
            btnCategory.FlatAppearance.MouseDownBackColor = Color.FromArgb(49, 46, 129);
            btnCategory.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 56, 202);
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.Font = new Font("Segoe UI", 10F);
            btnCategory.ForeColor = Color.FromArgb(226, 232, 240);
            btnCategory.Location = new Point(0, 191);
            btnCategory.Name = "btnCategory";
            btnCategory.Padding = new Padding(15, 0, 0, 0);
            btnCategory.Size = new Size(260, 46);
            btnCategory.TabIndex = 2;
            btnCategory.Text = "   📁  Danh Mục Nhóm Hàng";
            btnCategory.TextAlign = ContentAlignment.MiddleLeft;
            btnCategory.UseMnemonic = false;
            btnCategory.UseVisualStyleBackColor = false;
            // 
            // lblNavStore
            // 
            lblNavStore.Dock = DockStyle.Top;
            lblNavStore.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNavStore.ForeColor = Color.FromArgb(100, 116, 139);
            lblNavStore.Location = new Point(0, 163);
            lblNavStore.Name = "lblNavStore";
            lblNavStore.Padding = new Padding(18, 10, 0, 0);
            lblNavStore.Size = new Size(260, 28);
            lblNavStore.TabIndex = 10;
            lblNavStore.Text = "KHO & DỮ LIỆU CỬA HÀNG";
            lblNavStore.UseMnemonic = false;
            // 
            // btnPOS
            // 
            btnPOS.BackColor = Color.FromArgb(30, 27, 75);
            btnPOS.Cursor = Cursors.Hand;
            btnPOS.Dock = DockStyle.Top;
            btnPOS.FlatAppearance.BorderSize = 0;
            btnPOS.FlatAppearance.MouseDownBackColor = Color.FromArgb(49, 46, 129);
            btnPOS.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 56, 202);
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnPOS.ForeColor = Color.White;
            btnPOS.Location = new Point(0, 115);
            btnPOS.Name = "btnPOS";
            btnPOS.Padding = new Padding(15, 0, 0, 0);
            btnPOS.Size = new Size(260, 48);
            btnPOS.TabIndex = 1;
            btnPOS.Text = "   🛒  Quầy Bán Hàng (POS)";
            btnPOS.TextAlign = ContentAlignment.MiddleLeft;
            btnPOS.UseMnemonic = false;
            btnPOS.UseVisualStyleBackColor = false;
            // 
            // lblNavSales
            // 
            lblNavSales.Dock = DockStyle.Top;
            lblNavSales.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNavSales.ForeColor = Color.FromArgb(100, 116, 139);
            lblNavSales.Location = new Point(0, 87);
            lblNavSales.Name = "lblNavSales";
            lblNavSales.Padding = new Padding(18, 10, 0, 0);
            lblNavSales.Size = new Size(260, 28);
            lblNavSales.TabIndex = 9;
            lblNavSales.Text = "BÁN HÀNG & THU NGÂN";
            lblNavSales.UseMnemonic = false;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(30, 27, 75);
            panelLogo.Controls.Add(lblLogoTag);
            panelLogo.Controls.Add(lblLogoSub);
            panelLogo.Controls.Add(lblLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Padding = new Padding(18, 16, 18, 12);
            panelLogo.Size = new Size(260, 87);
            panelLogo.TabIndex = 8;
            // 
            // lblLogoTag
            // 
            lblLogoTag.AutoSize = true;
            lblLogoTag.BackColor = Color.FromArgb(124, 58, 237);
            lblLogoTag.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            lblLogoTag.ForeColor = Color.White;
            lblLogoTag.Location = new Point(164, 24);
            lblLogoTag.Name = "lblLogoTag";
            lblLogoTag.Padding = new Padding(4, 2, 4, 2);
            lblLogoTag.Size = new Size(57, 16);
            lblLogoTag.TabIndex = 2;
            lblLogoTag.Text = "SÀI GÒN";
            lblLogoTag.UseMnemonic = false;
            // 
            // lblLogoSub
            // 
            lblLogoSub.AutoSize = true;
            lblLogoSub.Font = new Font("Segoe UI", 8.25F);
            lblLogoSub.ForeColor = Color.FromArgb(148, 163, 184);
            lblLogoSub.Location = new Point(18, 52);
            lblLogoSub.Name = "lblLogoSub";
            lblLogoSub.Size = new Size(188, 13);
            lblLogoSub.TabIndex = 1;
            lblLogoSub.Text = "Tiệm Tạp Hóa & Bách Hóa Tổng Hợp";
            lblLogoSub.UseMnemonic = false;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(16, 18);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(142, 25);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "👑 CÔ BA";
            lblLogo.UseMnemonic = false;
            // 
            // panelUserFooter
            // 
            panelUserFooter.BackColor = Color.FromArgb(19, 17, 54);
            panelUserFooter.Controls.Add(btnLogout);
            panelUserFooter.Controls.Add(lblUserRoleBadge);
            panelUserFooter.Controls.Add(lblUserFullName);
            panelUserFooter.Controls.Add(lblAvatar);
            panelUserFooter.Dock = DockStyle.Bottom;
            panelUserFooter.Location = new Point(0, 660);
            panelUserFooter.Name = "panelUserFooter";
            panelUserFooter.Padding = new Padding(12, 10, 12, 10);
            panelUserFooter.Size = new Size(260, 100);
            panelUserFooter.TabIndex = 7;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(49, 46, 129);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseDownBackColor = Color.FromArgb(15, 23, 42);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 38, 38);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(12, 56);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(236, 34);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "🚪 Đăng xuất";
            btnLogout.UseMnemonic = false;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // lblUserRoleBadge
            // 
            lblUserRoleBadge.AutoSize = true;
            lblUserRoleBadge.BackColor = Color.FromArgb(124, 58, 237);
            lblUserRoleBadge.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblUserRoleBadge.ForeColor = Color.White;
            lblUserRoleBadge.Location = new Point(56, 30);
            lblUserRoleBadge.Name = "lblUserRoleBadge";
            lblUserRoleBadge.Padding = new Padding(5, 1, 5, 1);
            lblUserRoleBadge.Size = new Size(54, 15);
            lblUserRoleBadge.TabIndex = 2;
            lblUserRoleBadge.Text = "ADMIN";
            lblUserRoleBadge.UseMnemonic = false;
            // 
            // lblUserFullName
            // 
            lblUserFullName.AutoSize = true;
            lblUserFullName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblUserFullName.ForeColor = Color.White;
            lblUserFullName.Location = new Point(56, 10);
            lblUserFullName.Name = "lblUserFullName";
            lblUserFullName.Size = new Size(59, 17);
            lblUserFullName.TabIndex = 1;
            lblUserFullName.Text = "coba_chutiem";
            lblUserFullName.UseMnemonic = false;
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = Color.FromArgb(49, 46, 129);
            lblAvatar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.FromArgb(196, 181, 253);
            lblAvatar.Location = new Point(12, 10);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(36, 36);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "👤";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelTopHeader
            // 
            panelTopHeader.BackColor = Color.White;
            panelTopHeader.Controls.Add(flowHeaderRight);
            panelTopHeader.Controls.Add(lblBreadcrumb);
            panelTopHeader.Controls.Add(lblTitle);
            panelTopHeader.Dock = DockStyle.Top;
            panelTopHeader.Location = new Point(260, 0);
            panelTopHeader.Name = "panelTopHeader";
            panelTopHeader.Padding = new Padding(25, 0, 25, 0);
            panelTopHeader.Size = new Size(1060, 65);
            panelTopHeader.TabIndex = 1;
            // 
            // flowHeaderRight
            // 
            flowHeaderRight.AutoSize = true;
            flowHeaderRight.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowHeaderRight.BackColor = Color.Transparent;
            flowHeaderRight.Controls.Add(lblUserInfo);
            flowHeaderRight.Controls.Add(lblClock);
            flowHeaderRight.Controls.Add(lblServerStatus);
            flowHeaderRight.Dock = DockStyle.Right;
            flowHeaderRight.FlowDirection = FlowDirection.RightToLeft;
            flowHeaderRight.Location = new Point(585, 0);
            flowHeaderRight.Name = "flowHeaderRight";
            flowHeaderRight.Padding = new Padding(0, 16, 15, 0);
            flowHeaderRight.Size = new Size(450, 65);
            flowHeaderRight.TabIndex = 5;
            flowHeaderRight.WrapContents = false;
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.BackColor = Color.FromArgb(241, 245, 249);
            lblUserInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUserInfo.ForeColor = Color.FromArgb(15, 23, 42);
            lblUserInfo.Location = new Point(310, 16);
            lblUserInfo.Margin = new Padding(8, 0, 0, 0);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Padding = new Padding(10, 6, 10, 6);
            lblUserInfo.Size = new Size(140, 27);
            lblUserInfo.TabIndex = 1;
            lblUserInfo.Text = "👤 coba_chutiem [ADMIN]";
            lblUserInfo.UseMnemonic = false;
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.Font = new Font("Segoe UI", 9.25F);
            lblClock.ForeColor = Color.FromArgb(71, 85, 105);
            lblClock.Location = new Point(148, 21);
            lblClock.Margin = new Padding(8, 5, 0, 0);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(154, 17);
            lblClock.TabIndex = 3;
            lblClock.Text = "⏰ 22/10/2026 18:45:00";
            lblClock.UseMnemonic = false;
            // 
            // lblServerStatus
            // 
            lblServerStatus.AutoSize = true;
            lblServerStatus.BackColor = Color.FromArgb(245, 243, 255);
            lblServerStatus.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblServerStatus.ForeColor = Color.FromArgb(124, 58, 237);
            lblServerStatus.Location = new Point(16, 19);
            lblServerStatus.Margin = new Padding(8, 3, 0, 0);
            lblServerStatus.Name = "lblServerStatus";
            lblServerStatus.Padding = new Padding(8, 4, 8, 4);
            lblServerStatus.Size = new Size(124, 23);
            lblServerStatus.TabIndex = 4;
            lblServerStatus.Text = "🟣 Máy chủ: Trực tuyến";
            lblServerStatus.UseMnemonic = false;
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Font = new Font("Segoe UI", 8F);
            lblBreadcrumb.ForeColor = Color.FromArgb(148, 163, 184);
            lblBreadcrumb.Location = new Point(25, 12);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Size = new Size(183, 13);
            lblBreadcrumb.TabIndex = 2;
            lblBreadcrumb.Text = "TIỆM TẠP HÓA CÔ BA SÀI GÒN  ›  ";
            lblBreadcrumb.UseMnemonic = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(24, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(257, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BÀN LÀM VIỆC HỆ THỐNG";
            lblTitle.UseMnemonic = false;
            // 
            // panelMainContent
            // 
            panelMainContent.BackColor = Color.FromArgb(241, 245, 249);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(260, 65);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1060, 695);
            panelMainContent.TabIndex = 2;
            panelMainContent.Paint += panelMainContent_Paint;
            // 
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Interval = 1000;
            // 
            // FormMainShell
            // 
            ClientSize = new Size(1320, 760);
            Controls.Add(panelMainContent);
            Controls.Add(panelTopHeader);
            Controls.Add(panelSidebar);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1200, 720);
            Name = "FormMainShell";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tiệm Tạp Hóa Cô Ba Sài Gòn - Hệ thống Quản lý Bán lẻ & Tồn kho POS";
            panelSidebar.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelUserFooter.ResumeLayout(false);
            panelUserFooter.PerformLayout();
            panelTopHeader.ResumeLayout(false);
            panelTopHeader.PerformLayout();
            flowHeaderRight.ResumeLayout(false);
            flowHeaderRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelTopHeader;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Panel panelUserFooter;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblLogoSub;
        private System.Windows.Forms.Label lblLogoTag;
        private System.Windows.Forms.Label lblNavSales;
        private System.Windows.Forms.Label lblNavStore;
        private System.Windows.Forms.Label lblNavAdmin;
        private System.Windows.Forms.Label lblBreadcrumb;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flowHeaderRight;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblUserFullName;
        private System.Windows.Forms.Label lblUserRoleBadge;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUserManage;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Timer timerClock;
    }
}