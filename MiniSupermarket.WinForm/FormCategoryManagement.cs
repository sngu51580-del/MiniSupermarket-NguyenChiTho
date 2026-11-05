using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms.Services;

namespace MiniSupermarket.WinForms
{
    public partial class FormCategoryManagement : Form
    {
        private int _currentPage = 1;
        private readonly int _pageSize = 5;
        private int _totalPages = 1;

        public FormCategoryManagement()
        {
            InitializeComponent();
            Theme.UITheme.ApplyModernDataGridView(dgvCategories);
            Theme.UITheme.StyleButton(btnAdd, Theme.UITheme.ButtonVariant.Primary);
            Theme.UITheme.StyleButton(btnUpdate, Theme.UITheme.ButtonVariant.Secondary);
            Theme.UITheme.StyleButton(btnDelete, Theme.UITheme.ButtonVariant.Danger);
            Theme.UITheme.StyleButton(btnSearch, Theme.UITheme.ButtonVariant.Secondary);
            Theme.UITheme.StyleButton(btnLoad, Theme.UITheme.ButtonVariant.Neutral);
            Theme.UITheme.StyleButton(btnPrev, Theme.UITheme.ButtonVariant.Neutral);
            Theme.UITheme.StyleButton(btnNext, Theme.UITheme.ButtonVariant.Neutral);

            btnPrev.Click += btnPrev_Click;
            btnNext.Click += btnNext_Click;
            txtKeyword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnSearch.PerformClick();
                }
            };
        }

        private HttpClient GetAuthenticatedClient()
        {
            var client = ApiClientService.CreateClient();
            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
            return client;
        }

        private async void FormCategoryManagement_Load(object sender, EventArgs e)
        {
            string role = SessionManager.CurrentRole.Trim().ToUpper();
            if (role == "WAREHOUSE")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }

            lblReady.Text = $"Sẵn sàng | Quyền: {(string.IsNullOrEmpty(SessionManager.CurrentRole) ? "Khách" : SessionManager.CurrentRole)} | Quản lý danh mục";
            await LoadCategoriesPagedAsync();
        }

        private async Task LoadCategoriesPagedAsync()
        {
            try
            {
                string keyword = txtKeyword.Text.Trim();
                using var client = GetAuthenticatedClient();
                string url = $"categories/paged?keyword={Uri.EscapeDataString(keyword)}&pageNumber={_currentPage}&pageSize={_pageSize}";

                var result = await client.GetFromJsonAsync<PagedViewResult<CategoryDto>>(url);
                if (result != null)
                {
                    _currentPage = result.CurrentPage;
                    _totalPages = result.TotalPages == 0 ? 1 : result.TotalPages;

                    dgvCategories.DataSource = null;
                    dgvCategories.DataSource = result.Items;

                    lblPaging.Text = $"Trang {_currentPage} / {_totalPages} (Tổng: {result.TotalItems} danh mục)";
                    btnPrev.Enabled = _currentPage > 1;
                    btnNext.Enabled = _currentPage < _totalPages;

                    lblReady.Text = $"Đã tải trang {_currentPage}/{_totalPages} (Tổng: {result.TotalItems} danh mục) | Hiển thị: {_pageSize} mục/trang";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu danh mục: " + ex.Message, "Lỗi kết nối",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.Message.Contains("401") || ex.Message.Contains("chưa đăng nhập"))
                {
                    new FormLogin().Show();
                    this.Close();
                }
            }
        }

        private async void btnPrev_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadCategoriesPagedAsync();
            }
        }

        private async void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadCategoriesPagedAsync();
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            _currentPage = 1;
            await LoadCategoriesPagedAsync();
            ClearInputs();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadCategoriesPagedAsync();
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCategories.Rows[e.RowIndex].DataBoundItem is CategoryDto cat)
            {
                txtId.Text = cat.CategoryId.ToString();
                txtCategoryName.Text = cat.CategoryName;
                txtDescription.Text = cat.Description ?? "";
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var client = GetAuthenticatedClient();
                var newCat = new { CategoryName = name, Description = txtDescription.Text.Trim() };
                var res = await client.PostAsJsonAsync("categories", newCat);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCategoriesPagedAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var client = GetAuthenticatedClient();
                int id = int.Parse(txtId.Text);
                var updateCat = new { CategoryId = id, CategoryName = txtCategoryName.Text.Trim(), Description = txtDescription.Text.Trim() };
                var res = await client.PutAsJsonAsync($"categories/{id}", updateCat);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCategoriesPagedAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nhóm hàng ID = {id}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using var client = GetAuthenticatedClient();
                    var res = await client.DeleteAsync($"categories/{id}");
                    if (res.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadCategoriesPagedAsync();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại! Nhóm hàng này có thể đang chứa sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputs()
        {
            txtId.Text = "";
            txtCategoryName.Text = "";
            txtDescription.Text = "";
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }

    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
