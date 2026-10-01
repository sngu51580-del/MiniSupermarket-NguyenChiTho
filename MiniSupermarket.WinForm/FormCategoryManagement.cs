using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormCategoryManagement : Form
    {
        public FormCategoryManagement()
        {
            InitializeComponent();
        }

        private HttpClient GetAuthenticatedClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7292/api/")
            };
            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
            return client;
        }

        private async void FormCategoryManagement_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                using var client = GetAuthenticatedClient();
                var categories = await client.GetFromJsonAsync<List<CategoryDto>>("categories");
                if (categories != null) dgvCategories.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối Server: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.Message.Contains("401") || ex.Message.Contains("chưa đăng nhập"))
                {
                    new FormLogin().Show();
                    this.Close();
                }
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                txtId.Text = row.Cells["CategoryId"].Value.ToString();
                txtCategoryName.Text = row.Cells["CategoryName"].Value?.ToString() ?? "";
                txtDescription.Text = row.Cells["Description"]?.Value?.ToString() ?? "";
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using var client = GetAuthenticatedClient();
                var newCat = new { CategoryName = txtCategoryName.Text, Description = txtDescription.Text };
                var res = await client.PostAsJsonAsync("categories", newCat);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                    await LoadDataAsync(); ClearInputs();
                }
                else MessageBox.Show("Thêm thất bại!", "Lỗi");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) { MessageBox.Show("Chọn dòng cần sửa!"); return; }
            try
            {
                using var client = GetAuthenticatedClient();
                int id = int.Parse(txtId.Text);
                var updateCat = new { CategoryId = id, CategoryName = txtCategoryName.Text, Description = txtDescription.Text };
                var res = await client.PutAsJsonAsync($"categories/{id}", updateCat);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    await LoadDataAsync(); ClearInputs();
                }
                else MessageBox.Show("Cập nhật thất bại!", "Lỗi");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) { MessageBox.Show("Chọn dòng cần xóa!"); return; }
            int id = int.Parse(txtId.Text);
            if (MessageBox.Show($"Xóa ID={id}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using var client = GetAuthenticatedClient();
                    var res = await client.DeleteAsync($"categories/{id}");
                    if (res.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        await LoadDataAsync(); ClearInputs();
                    }
                    else MessageBox.Show("Xóa thất bại!", "Lỗi");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtKeyword.Text.Trim();
            if (string.IsNullOrEmpty(kw)) { await LoadDataAsync(); return; }
            try
            {
                using var client = GetAuthenticatedClient();
                var res = await client.GetFromJsonAsync<List<CategoryDto>>($"categories/search?keyword={kw}");
                dgvCategories.DataSource = res;
            }
            catch { MessageBox.Show("Không tìm thấy!"); }
        }

        private void ClearInputs() { txtId.Text = ""; txtCategoryName.Text = ""; txtDescription.Text = ""; }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void grpInfo_Enter(object sender, EventArgs e) { }
    }

    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}