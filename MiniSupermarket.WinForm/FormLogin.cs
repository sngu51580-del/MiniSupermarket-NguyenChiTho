namespace MiniSupermarket.WinForms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Cảnh báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;

            try
            {
                bool thanhCong = await ApiClientService.LoginAsync(username, password);

                if (thanhCong)
                {
                    MessageBox.Show($"Đăng nhập thành công!\nQuyền: {SessionManager.CurrentRole}",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormCategoryManagement mainForm = new FormCategoryManagement();
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập thất bại",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi hệ thống",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnLogin.Enabled = true;
        }
    }
}