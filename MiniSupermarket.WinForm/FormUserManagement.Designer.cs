namespace MiniSupermarket.WinForms
{
    partial class FormUserManagement
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
            panelRight = new Panel();
            btnRefresh = new Button();
            btnDeleteUser = new Button();
            btnResetPassword = new Button();
            btnAddUser = new Button();
            cboRole = new ComboBox();
            lblRole = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblPanelTitle = new Label();
            panelMain = new Panel();
            dgvUsers = new DataGridView();
            panelPaging = new Panel();
            lblPaging = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            panelMainHeader = new Panel();
            btnSearch = new Button();
            txtKeyword = new TextBox();
            lblUserCount = new Label();
            lblListTitle = new Label();
            panelRight.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panelPaging.SuspendLayout();
            panelMainHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.White;
            panelRight.Controls.Add(btnRefresh);
            panelRight.Controls.Add(btnDeleteUser);
            panelRight.Controls.Add(btnResetPassword);
            panelRight.Controls.Add(btnAddUser);
            panelRight.Controls.Add(cboRole);
            panelRight.Controls.Add(lblRole);
            panelRight.Controls.Add(txtFullName);
            panelRight.Controls.Add(lblFullName);
            panelRight.Controls.Add(txtPassword);
            panelRight.Controls.Add(lblPassword);
            panelRight.Controls.Add(txtUsername);
            panelRight.Controls.Add(lblUsername);
            panelRight.Controls.Add(lblPanelTitle);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(804, 12);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(22);
            panelRight.Size = new Size(384, 642);
            panelRight.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(241, 245, 249);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(71, 85, 105);
            btnRefresh.Location = new Point(22, 520);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(340, 40);
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "🔄 Tải Lại Danh Sách";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.FromArgb(220, 38, 38);
            btnDeleteUser.Cursor = Cursors.Hand;
            btnDeleteUser.FlatAppearance.BorderSize = 0;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(22, 465);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(340, 40);
            btnDeleteUser.TabIndex = 11;
            btnDeleteUser.Text = "🗑 Xóa Tài Khoản";
            btnDeleteUser.UseVisualStyleBackColor = false;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.FromArgb(217, 119, 6);
            btnResetPassword.Cursor = Cursors.Hand;
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.Location = new Point(22, 415);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(340, 40);
            btnResetPassword.TabIndex = 10;
            btnResetPassword.Text = "🔑 Đặt Lại Mật Khẩu (123456)";
            btnResetPassword.UseVisualStyleBackColor = false;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.FromArgb(124, 58, 237);
            btnAddUser.Cursor = Cursors.Hand;
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(22, 360);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(340, 45);
            btnAddUser.TabIndex = 9;
            btnAddUser.Text = "➕ Tạo Tài Khoản Mới";
            btnAddUser.UseVisualStyleBackColor = false;
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 10F);
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(22, 290);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(340, 25);
            cboRole.TabIndex = 8;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(71, 85, 105);
            lblRole.Location = new Point(22, 270);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(47, 15);
            lblRole.TabIndex = 7;
            lblRole.Text = "Vai Trò:";
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(22, 220);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Nhập họ và tên đầy đủ...";
            txtFullName.Size = new Size(340, 25);
            txtFullName.TabIndex = 6;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(71, 85, 105);
            lblFullName.Location = new Point(22, 200);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(64, 15);
            lblFullName.TabIndex = 5;
            lblFullName.Text = "Họ Và Tên:";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(22, 150);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Mật khẩu khởi tạo...";
            txtPassword.Size = new Size(340, 25);
            txtPassword.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblPassword.Location = new Point(22, 130);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(63, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Mật Khẩu:";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(22, 80);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Nhập tên đăng nhập...";
            txtUsername.Size = new Size(340, 25);
            txtUsername.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(71, 85, 105);
            lblUsername.Location = new Point(22, 60);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(94, 15);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Tên Đăng Nhập:";
            // 
            // lblPanelTitle
            // 
            lblPanelTitle.AutoSize = true;
            lblPanelTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblPanelTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblPanelTitle.Location = new Point(18, 18);
            lblPanelTitle.Name = "lblPanelTitle";
            lblPanelTitle.Size = new Size(216, 21);
            lblPanelTitle.TabIndex = 0;
            lblPanelTitle.Text = "🛡️ THÔNG TIN TÀI KHOẢN";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(dgvUsers);
            panelMain.Controls.Add(panelPaging);
            panelMain.Controls.Add(panelMainHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(12, 12);
            panelMain.Margin = new Padding(0, 0, 15, 0);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(15);
            panelMain.Size = new Size(792, 642);
            panelMain.TabIndex = 2;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.ColumnHeadersHeight = 38;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(15, 60);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowTemplate.Height = 34;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(762, 522);
            dgvUsers.TabIndex = 1;
            // 
            // panelPaging
            // 
            panelPaging.BackColor = Color.White;
            panelPaging.Controls.Add(lblPaging);
            panelPaging.Controls.Add(btnNext);
            panelPaging.Controls.Add(btnPrev);
            panelPaging.Dock = DockStyle.Bottom;
            panelPaging.Location = new Point(15, 582);
            panelPaging.Name = "panelPaging";
            panelPaging.Padding = new Padding(12, 8, 12, 8);
            panelPaging.Size = new Size(762, 45);
            panelPaging.TabIndex = 2;
            // 
            // lblPaging
            // 
            lblPaging.Anchor = AnchorStyles.Top;
            lblPaging.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPaging.ForeColor = Color.FromArgb(71, 85, 105);
            lblPaging.Location = new Point(211, 12);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(340, 23);
            lblPaging.TabIndex = 1;
            lblPaging.Text = "Trang 1 / 1 (Tổng số: 0 người dùng)";
            lblPaging.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.BackColor = Color.FromArgb(241, 245, 249);
            btnNext.Cursor = Cursors.Hand;
            btnNext.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNext.ForeColor = Color.FromArgb(71, 85, 105);
            btnNext.Location = new Point(625, 8);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(125, 29);
            btnNext.TabIndex = 2;
            btnNext.Text = "Trang sau >>";
            btnNext.UseVisualStyleBackColor = false;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.FromArgb(241, 245, 249);
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPrev.ForeColor = Color.FromArgb(71, 85, 105);
            btnPrev.Location = new Point(12, 8);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(125, 29);
            btnPrev.TabIndex = 0;
            btnPrev.Text = "<< Trang trước";
            btnPrev.UseVisualStyleBackColor = false;
            // 
            // panelMainHeader
            // 
            panelMainHeader.Controls.Add(btnSearch);
            panelMainHeader.Controls.Add(txtKeyword);
            panelMainHeader.Controls.Add(lblUserCount);
            panelMainHeader.Controls.Add(lblListTitle);
            panelMainHeader.Dock = DockStyle.Top;
            panelMainHeader.Location = new Point(15, 15);
            panelMainHeader.Name = "panelMainHeader";
            panelMainHeader.Size = new Size(762, 45);
            panelMainHeader.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(37, 99, 235);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(515, 8);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 28);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "🔍 Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtKeyword
            // 
            txtKeyword.BorderStyle = BorderStyle.FixedSingle;
            txtKeyword.Font = new Font("Segoe UI", 9.5F);
            txtKeyword.Location = new Point(320, 10);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Tìm theo tên, vai trò...";
            txtKeyword.Size = new Size(185, 24);
            txtKeyword.TabIndex = 2;
            // 
            // lblUserCount
            // 
            lblUserCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserCount.AutoSize = true;
            lblUserCount.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblUserCount.ForeColor = Color.FromArgb(100, 116, 139);
            lblUserCount.Location = new Point(625, 15);
            lblUserCount.Name = "lblUserCount";
            lblUserCount.Size = new Size(110, 15);
            lblUserCount.TabIndex = 1;
            lblUserCount.Text = "Tổng: 0 người dùng";
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblListTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblListTitle.Location = new Point(0, 12);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(180, 20);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "DANH SÁCH TÀI KHOẢN";
            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1200, 666);
            Controls.Add(panelMain);
            Controls.Add(panelRight);
            Font = new Font("Segoe UI", 9.75F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormUserManagement";
            Padding = new Padding(12);
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panelPaging.ResumeLayout(false);
            panelMainHeader.ResumeLayout(false);
            panelMainHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelRight;
        private Label lblPanelTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblRole;
        private ComboBox cboRole;
        private Button btnAddUser;
        private Button btnResetPassword;
        private Button btnDeleteUser;
        private Button btnRefresh;
        private Panel panelMain;
        private Panel panelMainHeader;
        private Label lblListTitle;
        private TextBox txtKeyword;
        private Button btnSearch;
        private Label lblUserCount;
        private DataGridView dgvUsers;
        private Panel panelPaging;
        private Button btnPrev;
        private Label lblPaging;
        private Button btnNext;
    }
}
