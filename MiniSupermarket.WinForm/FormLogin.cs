namespace MiniSupermarket.WinForms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            Theme.UITheme.StyleButton(btnLogin, Theme.UITheme.ButtonVariant.Primary);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "⚠️ Vui lòng nhập đầy đủ tài khoản và mật khẩu!";
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Cảnh báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            string originalBtnText = btnLogin.Text;
            btnLogin.Text = "⏳ Đang xác thực thông tin...";
            lblMessage.Text = "Đang kết nối tới trạm máy chủ API...";

            try
            {
                bool thanhCong = await ApiClientService.LoginAsync(username, password);

                if (thanhCong)
                {
                    lblMessage.ForeColor = System.Drawing.Color.FromArgb(124, 58, 237);
                    lblMessage.Text = "✓ Đăng nhập thành công! Đang chuyển hướng...";

                    MessageBox.Show($"Đăng nhập thành công!\nNhân viên: {username}\nVai trò: [{SessionManager.CurrentRole}]",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormMainShell mainForm = new FormMainShell();

                    this.Hide();

                    mainForm.ShowDialog();

                    this.Close();
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
                    lblMessage.Text = "❌ Sai tên đăng nhập hoặc mật khẩu!";
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập thất bại",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
                lblMessage.Text = "❌ Lỗi kết nối máy chủ API!";
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi hệ thống",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = originalBtnText;
            }
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
        }
    }
}