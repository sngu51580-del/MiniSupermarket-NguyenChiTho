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
    public partial class FormCustomerManagement : Form
    {
        private int _currentPage = 1;
        private readonly int _pageSize = 5;
        private int _totalPages = 1;

        public FormCustomerManagement()
        {
            InitializeComponent();
            Theme.UITheme.ApplyModernDataGridView(dgvCustomers);
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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
            return client;
        }

        private async void FormCustomerManagement_Load(object sender, EventArgs e)
        {
            if (cbMembershipRank.Items.Count > 0 && cbMembershipRank.SelectedIndex == -1)
            {
                cbMembershipRank.SelectedIndex = 0;
            }

            if (!string.IsNullOrEmpty(SessionManager.CurrentRole))
            {
                lblReady.Text = $"Sẵn sàng | Quyền: {SessionManager.CurrentRole} | Phân hệ Khách hàng";
            }

            await LoadCustomersPagedAsync();
        }

        private async Task LoadCustomersPagedAsync()
        {
            try
            {
                string keyword = txtKeyword.Text.Trim();
                using var client = GetAuthenticatedClient();
                string url = $"customers/paged?keyword={Uri.EscapeDataString(keyword)}&pageNumber={_currentPage}&pageSize={_pageSize}";

                var result = await client.GetFromJsonAsync<PagedViewResult<CustomerDto>>(url);
                if (result != null)
                {
                    _currentPage = result.CurrentPage;
                    _totalPages = result.TotalPages == 0 ? 1 : result.TotalPages;

                    dgvCustomers.DataSource = null;
                    dgvCustomers.DataSource = result.Items;

                    lblPaging.Text = $"Trang {_currentPage} / {_totalPages} (Tổng: {result.TotalItems} khách hàng)";
                    btnPrev.Enabled = _currentPage > 1;
                    btnNext.Enabled = _currentPage < _totalPages;

                    lblReady.Text = $"Đã tải trang {_currentPage}/{_totalPages} (Tổng: {result.TotalItems} khách hàng) | Hiển thị: {_pageSize} mục/trang";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu khách hàng: " + ex.Message, "Lỗi kết nối",
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
                await LoadCustomersPagedAsync();
            }
        }

        private async void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadCustomersPagedAsync();
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomers.Rows[e.RowIndex].DataBoundItem is CustomerDto customer)
            {
                txtCustomerId.Text = customer.CustomerId.ToString();
                txtCustomerName.Text = customer.CustomerName;
                txtPhoneNumber.Text = customer.PhoneNumber;
                txtAddress.Text = customer.Address ?? string.Empty;
                txtRewardPoints.Text = customer.RewardPoints.ToString();

                int rankIndex = cbMembershipRank.FindStringExact(customer.MembershipRank ?? "Mới");
                cbMembershipRank.SelectedIndex = rankIndex >= 0 ? rankIndex : 0;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtCustomerName.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumber.Focus();
                return;
            }

            int points = 0;
            int.TryParse(txtRewardPoints.Text.Trim(), out points);

            var newCustomer = new
            {
                CustomerName = name,
                PhoneNumber = phone,
                Address = txtAddress.Text.Trim(),
                RewardPoints = points,
                MembershipRank = cbMembershipRank.SelectedItem?.ToString() ?? "Mới"
            };

            try
            {
                using var client = GetAuthenticatedClient();
                var response = await client.PostAsJsonAsync("customers", newCustomer);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCustomersPagedAsync();
                    ClearInputs();
                }
                else
                {
                    string err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Thêm thất bại: {err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerId.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtCustomerId.Text);
            string name = txtCustomerName.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Tên và số điện thoại không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int points = 0;
            int.TryParse(txtRewardPoints.Text.Trim(), out points);

            var updateCustomer = new
            {
                CustomerId = id,
                CustomerName = name,
                PhoneNumber = phone,
                Address = txtAddress.Text.Trim(),
                RewardPoints = points,
                MembershipRank = cbMembershipRank.SelectedItem?.ToString() ?? "Mới"
            };

            try
            {
                using var client = GetAuthenticatedClient();
                var response = await client.PutAsJsonAsync($"customers/{id}", updateCustomer);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCustomersPagedAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerId.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtCustomerId.Text);
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng ID = {id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using var client = GetAuthenticatedClient();
                    var response = await client.DeleteAsync($"customers/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadCustomersPagedAsync();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadCustomersPagedAsync();
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            _currentPage = 1;
            await LoadCustomersPagedAsync();
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtRewardPoints.Text = "0";
            if (cbMembershipRank.Items.Count > 0)
            {
                cbMembershipRank.SelectedIndex = 0;
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }

    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
        public int RewardPoints { get; set; }
        public string MembershipRank { get; set; } = "Mới";
    }
}
