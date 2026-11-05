using MiniSupermarket.WinForms.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormMainShell : Form
    {
        private Form? _activeForm = null;

        public FormMainShell()
        {
            InitializeComponent();

            // Đăng ký các sự kiện Click
            btnPOS.Click += btnPOS_Click;
            btnCategory.Click += btnCategory_Click;
            btnProduct.Click += btnProduct_Click;
            btnCustomer.Click += btnCustomer_Click;
            btnReports.Click += btnReports_Click;
            btnUserManage.Click += btnUserManage_Click;
            btnLogout.Click += btnLogout_Click;

            timerClock.Tick += (s, e) =>
            {
                lblClock.Text = DateTime.Now.ToString("⏰ dd/MM/yyyy HH:mm:ss");
            };
            lblClock.Text = DateTime.Now.ToString("⏰ dd/MM/yyyy HH:mm:ss");

            this.Load += FormMainShell_Load;
            this.Resize += FormMainShell_Resize;
        }

        private void FormMainShell_Load(object? sender, EventArgs e)
        {
            string role = SessionManager.CurrentRole;
            string username = string.IsNullOrEmpty(SessionManager.CurrentUsername) ? "coba_chutiem" : SessionManager.CurrentUsername;

            lblUserInfo.Text = $"👤 {username}  [{role.ToUpper()}]";
            lblUserFullName.Text = username;
            lblUserRoleBadge.Text = role.ToUpper();

            // Tùy biến màu thẻ vai trò
            switch (role.Trim().ToUpper())
            {
                case "ADMIN":
                    lblUserRoleBadge.BackColor = Color.FromArgb(124, 58, 237); // Purple
                    break;
                case "CASHIER":
                    lblUserRoleBadge.BackColor = Color.FromArgb(5, 150, 105);  // Emerald
                    break;
                case "WAREHOUSE":
                    lblUserRoleBadge.BackColor = Color.FromArgb(217, 119, 6);  // Amber
                    break;
                default:
                    lblUserRoleBadge.BackColor = Color.FromArgb(71, 85, 105);
                    break;
            }

            if (!string.IsNullOrEmpty(username))
            {
                lblAvatar.Text = username.Substring(0, 1).ToUpper();
            }

            // Tự động căn chỉnh nhãn ORGANIC cạnh logo để không bao giờ bị đè chữ
            if (lblLogo != null && lblLogoTag != null)
            {
                lblLogoTag.Location = new Point(lblLogo.Right + 4, lblLogo.Top + 4);
            }

            // Header positioning is automatically managed by flowHeaderRight (DockStyle.Right)
            ApplyRolePermissions(role);
            OpenDefaultScreenByRole(role);
        }

        private void FormMainShell_Resize(object? sender, EventArgs e)
        {
        }

        private void UpdateUserInfoPosition()
        {
        }

        // =====================================================
        // PHÂN QUYỀN MENU
        // =====================================================

        private void ApplyRolePermissions(string role)
        {
            btnPOS.Visible = false;
            btnCategory.Visible = false;
            btnProduct.Visible = false;
            btnCustomer.Visible = false;
            btnReports.Visible = false;
            btnUserManage.Visible = false;

            lblNavSales.Visible = false;
            lblNavStore.Visible = false;
            lblNavAdmin.Visible = false;

            switch (role.Trim().ToUpper())
            {
                case "ADMIN":
                    lblNavSales.Visible = true;
                    btnPOS.Visible = true;
                    lblNavStore.Visible = true;
                    btnCategory.Visible = true;
                    btnProduct.Visible = true;
                    btnCustomer.Visible = true;
                    lblNavAdmin.Visible = true;
                    btnReports.Visible = true;
                    btnUserManage.Visible = true;
                    break;

                case "CASHIER":
                    lblNavSales.Visible = true;
                    btnPOS.Visible = true;
                    lblNavStore.Visible = true;
                    btnCustomer.Visible = true;
                    break;

                case "WAREHOUSE":
                    lblNavStore.Visible = true;
                    btnCategory.Visible = true;
                    btnProduct.Visible = true;
                    break;

                default:
                    MessageBox.Show(
                        "Tài khoản chưa được cấp quyền hạn hợp lệ!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    this.Close();
                    break;
            }
        }

        // =====================================================
        // MỞ FORM MẶC ĐỊNH
        // =====================================================

        private void OpenDefaultScreenByRole(string role)
        {
            switch (role.Trim().ToUpper())
            {
                case "ADMIN":
                    OpenChildForm(
                        new FormCategoryManagement(),
                        "QUẢN LÝ DANH MỤC NHÓM HÀNG",
                        btnCategory
                    );
                    break;

                case "CASHIER":
                    OpenChildForm(
                        new FormPOS(),
                        "HỆ THỐNG QUẦY BÁN HÀNG & THU NGÂN (POS)",
                        btnPOS
                    );
                    break;

                case "WAREHOUSE":
                    OpenChildForm(
                        new FormProductManagement(),
                        "QUẢN LÝ THÔNG TIN SẢN PHẨM & KHO HÀNG",
                        btnProduct
                    );
                    break;
            }
        }

        // =====================================================
        // NHÚNG FORM CON
        // =====================================================

        private void OpenChildForm(
            Form childForm,
            string screenTitle,
            Button senderButton)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            HighlightActiveButton(senderButton);

            _activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMainContent.Controls.Clear();
            panelMainContent.Controls.Add(childForm);
            panelMainContent.Tag = childForm;

            lblTitle.Text = screenTitle;

            childForm.BringToFront();
            childForm.Show();
        }

        // =====================================================
        // HIGHLIGHT MENU
        // =====================================================

        private void HighlightActiveButton(Button activeButton)
        {
            foreach (Control ctrl in panelSidebar.Controls)
            {
                if (ctrl is Button btn && btn != btnLogout)
                {
                    btn.BackColor = Color.FromArgb(30, 27, 75);
                    btn.ForeColor = Color.FromArgb(203, 213, 225);
                }
            }

            activeButton.BackColor = Color.FromArgb(124, 58, 237);
            activeButton.ForeColor = Color.White;
        }

        // =====================================================
        // CHỨC NĂNG CÁC NÚT BẤM
        // =====================================================

        private void btnCategory_Click(object? sender, EventArgs e)
        {
            if (!IsAllowed("ADMIN", "WAREHOUSE"))
                return;

            OpenChildForm(
                new FormCategoryManagement(),
                "QUẢN LÝ DANH MỤC NHÓM HÀNG",
                btnCategory
            );
        }

        private void btnCustomer_Click(object? sender, EventArgs e)
        {
            if (!IsAllowed("ADMIN", "CASHIER"))
                return;

            OpenChildForm(
                new FormCustomerManagement(),
                "QUẢN LÝ KHÁCH HÀNG & TÍCH ĐIỂM",
                btnCustomer
            );
        }

        private void btnPOS_Click(object? sender, EventArgs e)
        {
            if (!IsAllowed("ADMIN", "CASHIER"))
                return;

            OpenChildForm(
                new FormPOS(),
                "HỆ THỐNG QUẦY BÁN HÀNG & THU NGÂN (POS)",
                btnPOS
            );
        }

        private void btnProduct_Click(object? sender, EventArgs e)
        {
            if (!IsAllowed("ADMIN", "WAREHOUSE"))
                return;

            OpenChildForm(
                new FormProductManagement(),
                "QUẢN LÝ THÔNG TIN SẢN PHẨM & KHO HÀNG",
                btnProduct
            );
        }

        private void btnReports_Click(object? sender, EventArgs e)
        {
            if (SessionManager.CurrentRole.Trim().ToUpper() != "ADMIN")
            {
                MessageBox.Show(
                    "Bạn không có quyền xem dữ liệu tài chính của siêu thị!",
                    "Từ chối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
                return;
            }

            OpenChildForm(
                new FormQuickReport(),
                "BÁO CÁO DOANH THU & HIỆU SUẤT CA BÁN",
                btnReports
            );
        }

        private void btnUserManage_Click(object? sender, EventArgs e)
        {
            if (SessionManager.CurrentRole.Trim().ToUpper() != "ADMIN")
            {
                MessageBox.Show(
                    "Bạn không có quyền quản trị tài khoản!",
                    "Từ chối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
                return;
            }

            OpenChildForm(
                new FormUserManagement(),
                "QUẢN TRỊ TÀI KHOẢN VÀ PHÂN QUYỀN HỆ THỐNG",
                btnUserManage
            );
        }

        // =====================================================
        // KIỂM TRA QUYỀN
        // =====================================================

        private bool IsAllowed(params string[] allowedRoles)
        {
            string currentRole =
                SessionManager.CurrentRole.Trim().ToUpper();

            foreach (string role in allowedRoles)
            {
                if (currentRole == role.ToUpper())
                    return true;
            }

            MessageBox.Show(
                "Bạn không có quyền truy cập chức năng này!",
                "Từ chối truy cập",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return false;
        }

        // =====================================================
        // LOGOUT
        // =====================================================

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            SessionManager.JwtToken = string.Empty;
            SessionManager.CurrentUsername = string.Empty;
            SessionManager.CurrentRole = string.Empty;

            this.Hide();

            FormLogin login = new FormLogin();

            login.ShowDialog();

            this.Close();
        }

        private void panelMainContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}