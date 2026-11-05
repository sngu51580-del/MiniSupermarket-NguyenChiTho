namespace MiniSupermarket.WinForms
{
    partial class FormLogin
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
            panelBrand = new Panel();
            lblBrandVersion = new Label();
            panelBrandCard = new Panel();
            lblBrandBullet4 = new Label();
            lblBrandBullet3 = new Label();
            lblBrandBullet2 = new Label();
            lblBrandBullet1 = new Label();
            lblBrandFeatureTitle = new Label();
            lblBrandSub = new Label();
            lblBrandTitle = new Label();
            lblBrandIcon = new Label();
            panelLogin = new Panel();
            lblHint = new Label();
            lblMessage = new Label();
            btnLogin = new Button();
            txtPass = new TextBox();
            lblPass = new Label();
            txtUser = new TextBox();
            lblUser = new Label();
            lblWelcomeSub = new Label();
            lblWelcome = new Label();
            lblTitle = new Label();
            panelBrand.SuspendLayout();
            panelBrandCard.SuspendLayout();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelBrand
            // 
            panelBrand.BackColor = Color.FromArgb(30, 27, 75);
            panelBrand.Controls.Add(lblBrandVersion);
            panelBrand.Controls.Add(panelBrandCard);
            panelBrand.Controls.Add(lblBrandSub);
            panelBrand.Controls.Add(lblBrandTitle);
            panelBrand.Controls.Add(lblBrandIcon);
            panelBrand.Dock = DockStyle.Left;
            panelBrand.Location = new Point(0, 0);
            panelBrand.Name = "panelBrand";
            panelBrand.Padding = new Padding(35, 40, 35, 30);
            panelBrand.Size = new Size(360, 520);
            panelBrand.TabIndex = 7;
            // 
            // lblBrandVersion
            // 
            lblBrandVersion.Dock = DockStyle.Bottom;
            lblBrandVersion.Font = new Font("Segoe UI", 9F);
            lblBrandVersion.ForeColor = Color.FromArgb(100, 116, 139);
            lblBrandVersion.Location = new Point(35, 465);
            lblBrandVersion.Name = "lblBrandVersion";
            lblBrandVersion.Size = new Size(290, 25);
            lblBrandVersion.TabIndex = 4;
            lblBrandVersion.Text = "Tạp Hóa Cô Ba POS v2.4 • Sài Gòn Xưa & Nay";
            lblBrandVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelBrandCard
            // 
            panelBrandCard.BackColor = Color.FromArgb(49, 46, 129);
            panelBrandCard.Controls.Add(lblBrandBullet4);
            panelBrandCard.Controls.Add(lblBrandBullet3);
            panelBrandCard.Controls.Add(lblBrandBullet2);
            panelBrandCard.Controls.Add(lblBrandBullet1);
            panelBrandCard.Controls.Add(lblBrandFeatureTitle);
            panelBrandCard.Location = new Point(35, 210);
            panelBrandCard.Name = "panelBrandCard";
            panelBrandCard.Padding = new Padding(18, 16, 18, 16);
            panelBrandCard.Size = new Size(290, 220);
            panelBrandCard.TabIndex = 3;
            // 
            // lblBrandBullet4
            // 
            lblBrandBullet4.Font = new Font("Segoe UI", 9.25F);
            lblBrandBullet4.ForeColor = Color.FromArgb(203, 213, 225);
            lblBrandBullet4.Location = new Point(15, 165);
            lblBrandBullet4.Name = "lblBrandBullet4";
            lblBrandBullet4.Size = new Size(260, 42);
            lblBrandBullet4.TabIndex = 4;
            lblBrandBullet4.Text = "📊 Báo cáo doanh thu ca thời gian thực với Stored Procedure.";
            // 
            // lblBrandBullet3
            // 
            lblBrandBullet3.Font = new Font("Segoe UI", 9.25F);
            lblBrandBullet3.ForeColor = Color.FromArgb(203, 213, 225);
            lblBrandBullet3.Location = new Point(15, 122);
            lblBrandBullet3.Name = "lblBrandBullet3";
            lblBrandBullet3.Size = new Size(260, 38);
            lblBrandBullet3.TabIndex = 3;
            lblBrandBullet3.Text = "🎁 Tích điểm hội viên tự động & phân hạng thành viên.";
            // 
            // lblBrandBullet2
            // 
            lblBrandBullet2.Font = new Font("Segoe UI", 9.25F);
            lblBrandBullet2.ForeColor = Color.FromArgb(203, 213, 225);
            lblBrandBullet2.Location = new Point(15, 76);
            lblBrandBullet2.Name = "lblBrandBullet2";
            lblBrandBullet2.Size = new Size(260, 42);
            lblBrandBullet2.TabIndex = 2;
            lblBrandBullet2.Text = "🛡️ Giao dịch ACID nguyên tử bọc SqlTransaction an toàn 100%.";
            // 
            // lblBrandBullet1
            // 
            lblBrandBullet1.Font = new Font("Segoe UI", 9.25F);
            lblBrandBullet1.ForeColor = Color.FromArgb(203, 213, 225);
            lblBrandBullet1.Location = new Point(15, 34);
            lblBrandBullet1.Name = "lblBrandBullet1";
            lblBrandBullet1.Size = new Size(260, 38);
            lblBrandBullet1.TabIndex = 1;
            lblBrandBullet1.Text = "⚡ Tra cứu mã vạch siêu tốc bằng ADO.NET thuần < 100ms.";
            // 
            // lblBrandFeatureTitle
            // 
            lblBrandFeatureTitle.AutoSize = true;
            lblBrandFeatureTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBrandFeatureTitle.ForeColor = Color.FromArgb(196, 181, 253);
            lblBrandFeatureTitle.Location = new Point(14, 10);
            lblBrandFeatureTitle.Name = "lblBrandFeatureTitle";
            lblBrandFeatureTitle.Size = new Size(160, 17);
            lblBrandFeatureTitle.TabIndex = 0;
            lblBrandFeatureTitle.Text = "✨ TÍNH NĂNG NỔI BẬT";
            // 
            // lblBrandSub
            // 
            lblBrandSub.Font = new Font("Segoe UI", 9.5F);
            lblBrandSub.ForeColor = Color.FromArgb(148, 163, 184);
            lblBrandSub.Location = new Point(35, 145);
            lblBrandSub.Name = "lblBrandSub";
            lblBrandSub.Size = new Size(290, 45);
            lblBrandSub.TabIndex = 2;
            lblBrandSub.Text = "Hệ thống Quản lý Bán lẻ, Tích điểm & Sổ sách Tiệm Tạp Hóa Cô Ba Sài Gòn";
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.AutoSize = true;
            lblBrandTitle.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblBrandTitle.ForeColor = Color.White;
            lblBrandTitle.Location = new Point(35, 102);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(215, 38);
            lblBrandTitle.TabIndex = 1;
            lblBrandTitle.Text = "TẠP HÓA CÔ BA";
            // 
            // lblBrandIcon
            // 
            lblBrandIcon.AutoSize = true;
            lblBrandIcon.Font = new Font("Segoe UI", 36F);
            lblBrandIcon.ForeColor = Color.FromArgb(167, 139, 250);
            lblBrandIcon.Location = new Point(28, 32);
            lblBrandIcon.Name = "lblBrandIcon";
            lblBrandIcon.Size = new Size(130, 65);
            lblBrandIcon.TabIndex = 0;
            lblBrandIcon.Text = "👑🛍️";
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.White;
            panelLogin.Controls.Add(lblHint);
            panelLogin.Controls.Add(lblMessage);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(txtPass);
            panelLogin.Controls.Add(lblPass);
            panelLogin.Controls.Add(txtUser);
            panelLogin.Controls.Add(lblUser);
            panelLogin.Controls.Add(lblWelcomeSub);
            panelLogin.Controls.Add(lblWelcome);
            panelLogin.Controls.Add(lblTitle);
            panelLogin.Dock = DockStyle.Fill;
            panelLogin.Location = new Point(360, 0);
            panelLogin.Name = "panelLogin";
            panelLogin.Padding = new Padding(50, 45, 50, 35);
            panelLogin.Size = new Size(464, 520);
            panelLogin.TabIndex = 8;
            // 
            // lblHint
            // 
            lblHint.BackColor = Color.FromArgb(248, 250, 252);
            lblHint.Font = new Font("Segoe UI", 9F);
            lblHint.ForeColor = Color.FromArgb(71, 85, 105);
            lblHint.Location = new Point(50, 435);
            lblHint.Name = "lblHint";
            lblHint.Padding = new Padding(10, 8, 10, 8);
            lblHint.Size = new Size(364, 50);
            lblHint.TabIndex = 9;
            lblHint.Text = "💡 Tài khoản mẫu (MK: 123): coba_chutiem (Chủ tiệm) | thungan_mai (Thu ngân) | kho_anhba (Thủ kho)";
            lblHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 9.5F);
            lblMessage.ForeColor = Color.FromArgb(220, 38, 38);
            lblMessage.Location = new Point(50, 388);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(364, 30);
            lblMessage.TabIndex = 8;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Click += lblMessage_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(124, 58, 237);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 325);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(364, 50);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "ĐĂNG NHẬP HỆ THỐNG →";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPass
            // 
            txtPass.BorderStyle = BorderStyle.FixedSingle;
            txtPass.Font = new Font("Segoe UI", 11.5F);
            txtPass.Location = new Point(50, 260);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '●';
            txtPass.PlaceholderText = "Nhập mật khẩu của bạn...";
            txtPass.Size = new Size(364, 28);
            txtPass.TabIndex = 6;
            txtPass.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPass.ForeColor = Color.FromArgb(15, 23, 42);
            lblPass.Location = new Point(48, 235);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(95, 19);
            lblPass.TabIndex = 5;
            lblPass.Text = "🔒 Mật khẩu:";
            // 
            // txtUser
            // 
            txtUser.BorderStyle = BorderStyle.FixedSingle;
            txtUser.Font = new Font("Segoe UI", 11.5F);
            txtUser.Location = new Point(50, 185);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Nhập tên đăng nhập...";
            txtUser.Size = new Size(364, 28);
            txtUser.TabIndex = 4;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUser.ForeColor = Color.FromArgb(15, 23, 42);
            lblUser.Location = new Point(48, 160);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(160, 19);
            lblUser.TabIndex = 3;
            lblUser.Text = "👤 Tài khoản nhân viên:";
            // 
            // lblWelcomeSub
            // 
            lblWelcomeSub.Font = new Font("Segoe UI", 10F);
            lblWelcomeSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblWelcomeSub.Location = new Point(48, 88);
            lblWelcomeSub.Name = "lblWelcomeSub";
            lblWelcomeSub.Size = new Size(366, 45);
            lblWelcomeSub.TabIndex = 2;
            lblWelcomeSub.Text = "Vui lòng nhập thông tin xác thực để bắt đầu ca làm việc và kết nối với trạm POS.";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(15, 23, 42);
            lblWelcome.Location = new Point(46, 48);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(286, 32);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Chào mừng trở lại! 👋";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9F);
            lblTitle.ForeColor = Color.Transparent;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 15);
            lblTitle.TabIndex = 0;
            // 
            // FormLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(824, 520);
            Controls.Add(panelLogin);
            Controls.Add(panelBrand);
            Font = new Font("Segoe UI", 9.75F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tiệm Tạp Hóa Cô Ba Sài Gòn - Đăng nhập hệ thống POS";
            Load += FormLogin_Load;
            panelBrand.ResumeLayout(false);
            panelBrand.PerformLayout();
            panelBrandCard.ResumeLayout(false);
            panelBrandCard.PerformLayout();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBrand;
        private Label lblBrandIcon;
        private Label lblBrandTitle;
        private Label lblBrandSub;
        private Panel panelBrandCard;
        private Label lblBrandFeatureTitle;
        private Label lblBrandBullet1;
        private Label lblBrandBullet2;
        private Label lblBrandBullet3;
        private Label lblBrandBullet4;
        private Label lblBrandVersion;
        private Panel panelLogin;
        private Label lblWelcome;
        private Label lblWelcomeSub;
        internal Label lblTitle;
        internal Label lblUser;
        internal TextBox txtUser;
        internal Label lblPass;
        internal TextBox txtPass;
        internal Button btnLogin;
        internal Label lblMessage;
        private Label lblHint;
    }
}