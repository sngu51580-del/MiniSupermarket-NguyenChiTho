/*
 * Họ tên sinh viên: Nguyen Chi Tho
 * Mã môn học: 229162 – Lập trình Ứng dụng
 * Mô tả: Code-behind xử lý hiển thị danh sách phân trang LINQ, Eager Loading, tìm kiếm, lọc theo nhóm hàng và CRUD sản phẩm
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms.Services;

namespace MiniSupermarket.WinForms
{
    // Lớp nhận dữ liệu DTO từ API về Client (chi tiết sản phẩm kèm tên nhóm hàng)
    public class ProductItemViewDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Unit { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    // DTO nhóm hàng nạp vào ComboBox
    public class CategoryComboDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    // Lớp Generic bọc kết quả phân trang trả về từ API
    public class PagedViewResult<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new();
    }

    public partial class FormProductManagement : Form
    {
        private int _currentPage = 1;
        private readonly int _pageSize = 5;
        private int _totalPages = 1;
        private bool _isFilterLoading = false;

        public FormProductManagement()
        {
            InitializeComponent();
            ApplyCustomTheme();
            RegisterEvents();
        }

        private void ApplyCustomTheme()
        {
            dgvProducts.AutoGenerateColumns = true;
            Theme.UITheme.ApplyModernDataGridView(dgvProducts);
            Theme.UITheme.StyleButton(btnAdd, Theme.UITheme.ButtonVariant.Primary);
            Theme.UITheme.StyleButton(btnUpdate, Theme.UITheme.ButtonVariant.Secondary);
            Theme.UITheme.StyleButton(btnDelete, Theme.UITheme.ButtonVariant.Danger);
            Theme.UITheme.StyleButton(btnClear, Theme.UITheme.ButtonVariant.Neutral);
            Theme.UITheme.StyleButton(btnSearch, Theme.UITheme.ButtonVariant.Secondary);
            Theme.UITheme.StyleButton(btnLoad, Theme.UITheme.ButtonVariant.Neutral);
            Theme.UITheme.StyleButton(btnPrev, Theme.UITheme.ButtonVariant.Neutral);
            Theme.UITheme.StyleButton(btnNext, Theme.UITheme.ButtonVariant.Neutral);

            // Nút Xuất Excel/CSV (Tiêu chí 48)
            SetupExportButton();
        }

        private Button btnExportExcel = new();

        private void SetupExportButton()
        {
            btnExportExcel.Text = "📊 Xuất Excel/CSV";
            btnExportExcel.Size = new Size(130, 30);
            btnExportExcel.Location = new Point(btnLoad.Right + 8, btnLoad.Top);
            btnExportExcel.Cursor = Cursors.Hand;
            Theme.UITheme.StyleButton(btnExportExcel, Theme.UITheme.ButtonVariant.Primary);
            btnExportExcel.Click += btnExportExcel_Click;
            panelTop.Controls.Add(btnExportExcel);
        }

        private void RegisterEvents()
        {
            this.Load += FormProductManagement_Load;

            // Sự kiện tìm kiếm & lọc
            btnSearch.Click += btnSearch_Click;
            btnLoad.Click += btnLoad_Click;
            txtKeyword.KeyDown += txtKeyword_KeyDown;
            cboFilterCategory.SelectedIndexChanged += cboFilterCategory_SelectedIndexChanged;

            // Sự kiện phân trang
            btnPrev.Click += btnPrev_Click;
            btnNext.Click += btnNext_Click;

            // Sự kiện CRUD
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;

            // Sự kiện DataGridView
            dgvProducts.CellClick += dgvProducts_CellClick;

            // Tiêu chí 43: Bắt sự kiện CellFormatting để cảnh báo hàng sắp hết kho (<= 10)
            dgvProducts.CellFormatting += dgvProducts_CellFormatting;
        }

        // =====================================================
        // LOAD FORM
        // =====================================================
        private async void FormProductManagement_Load(object? sender, EventArgs e)
        {
            string role = SessionManager.CurrentRole.Trim().ToUpper();

            // Phân quyền: Warehouse chỉ được xem, không được thêm/sửa/xóa
            if (role == "WAREHOUSE")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }

            lblReady.Text = $"Sẵn sàng | Quyền: {(string.IsNullOrEmpty(SessionManager.CurrentRole) ? "Khách / Chưa đăng nhập" : SessionManager.CurrentRole)} | Quản lý sản phẩm";

            await LoadCategoriesComboAsync(); // Nạp nhóm hàng vào cả 2 ComboBox
            await LoadProductsPagedAsync();    // Nạp bảng sản phẩm phân trang
        }

        // =====================================================
        // 1. TẢI DANH SÁCH NHÓM HÀNG VÀO COMBOBOX
        // =====================================================
        private async Task LoadCategoriesComboAsync()
        {
            try
            {
                _isFilterLoading = true;

                var categories = await ApiClientService.Client
                    .GetFromJsonAsync<List<CategoryComboDto>>("categories");

                if (categories != null && categories.Count > 0)
                {
                    // 1. Nạp danh mục cho ô nhập liệu (panelInputs)
                    cbCategory.DataSource = new List<CategoryComboDto>(categories);
                    cbCategory.DisplayMember = "CategoryName";
                    cbCategory.ValueMember = "CategoryId";

                    // 2. Nạp danh mục cho bộ lọc (panelTop - Bài tập mở rộng 6.2)
                    var filterList = new List<CategoryComboDto>
                    {
                        new CategoryComboDto { CategoryId = 0, CategoryName = "-- Tất cả nhóm hàng --" }
                    };
                    filterList.AddRange(categories);

                    cboFilterCategory.DataSource = filterList;
                    cboFilterCategory.DisplayMember = "CategoryName";
                    cboFilterCategory.ValueMember = "CategoryId";
                    cboFilterCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isFilterLoading = false;
            }
        }

        // =====================================================
        // 2. GỌI API PHÂN TRANG VÀ HIỂN THỊ DỮ LIỆU
        // =====================================================
        private async Task LoadProductsPagedAsync()
        {
            try
            {
                string keyword = txtKeyword.Text.Trim();

                // Kiểm tra bộ lọc nhóm hàng (Bài tập mở rộng 6.2)
                int? categoryId = null;
                if (cboFilterCategory.SelectedValue != null &&
                    int.TryParse(cboFilterCategory.SelectedValue.ToString(), out int catId) && catId > 0)
                {
                    categoryId = catId;
                }

                // Xây dựng URL API phân trang
                string url = $"products/paged?keyword={Uri.EscapeDataString(keyword)}&pageNumber={_currentPage}&pageSize={_pageSize}";
                if (categoryId.HasValue)
                {
                    url += $"&categoryId={categoryId.Value}";
                }

                var result = await ApiClientService.Client.GetFromJsonAsync<PagedViewResult<ProductItemViewDto>>(url);
                if (result != null)
                {
                    _currentPage = result.CurrentPage;
                    _totalPages = result.TotalPages == 0 ? 1 : result.TotalPages;

                    // Hiển thị dữ liệu lên DataGridView
                    dgvProducts.DataSource = null;
                    dgvProducts.DataSource = result.Items;
                    FormatDataGridView();

                    // Cập nhật nhãn phân trang
                    lblPaging.Text = $"Trang {_currentPage} / {_totalPages} (Tổng: {result.TotalItems} SP)";

                    // Bật/tắt nút điều hướng
                    btnPrev.Enabled = _currentPage > 1;
                    btnNext.Enabled = _currentPage < _totalPages;

                    lblReady.Text = $"Đã tải trang {_currentPage}/{_totalPages} (Tổng: {result.TotalItems} SP) | Hiển thị: {_pageSize} SP/trang";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu sản phẩm: " + ex.Message, "Lỗi kết nối",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // ĐỊNH DẠNG CỘT CHO DATAGRIDVIEW
        // =====================================================
        private void FormatDataGridView()
        {
            if (dgvProducts.Columns.Count == 0) return;

            if (dgvProducts.Columns["ProductId"] != null)
            {
                dgvProducts.Columns["ProductId"].HeaderText = "Mã SP";
                dgvProducts.Columns["ProductId"].Width = 65;
            }

            if (dgvProducts.Columns["Barcode"] != null)
            {
                dgvProducts.Columns["Barcode"].HeaderText = "Mã vạch";
                dgvProducts.Columns["Barcode"].Width = 120;
            }

            if (dgvProducts.Columns["ProductName"] != null)
            {
                dgvProducts.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                dgvProducts.Columns["ProductName"].Width = 200;
            }

            if (dgvProducts.Columns["Price"] != null)
            {
                dgvProducts.Columns["Price"].HeaderText = "Đơn giá (VNĐ)";
                dgvProducts.Columns["Price"].DefaultCellStyle.Format = "N0";
                dgvProducts.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvProducts.Columns["Price"].Width = 110;
            }

            if (dgvProducts.Columns["StockQuantity"] != null)
            {
                dgvProducts.Columns["StockQuantity"].HeaderText = "Tồn kho";
                dgvProducts.Columns["StockQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProducts.Columns["StockQuantity"].Width = 75;
            }

            if (dgvProducts.Columns["Unit"] != null)
            {
                dgvProducts.Columns["Unit"].HeaderText = "Đơn vị";
                dgvProducts.Columns["Unit"].Width = 80;
            }

            if (dgvProducts.Columns["CategoryName"] != null)
            {
                dgvProducts.Columns["CategoryName"].HeaderText = "Nhóm hàng (Eager Loading)";
                dgvProducts.Columns["CategoryName"].Width = 180;
            }

            if (dgvProducts.Columns["CategoryId"] != null)
            {
                dgvProducts.Columns["CategoryId"].Visible = false; // Ẩn ID danh mục
            }
        }

        // =====================================================
        // 3. SỰ KIỆN CHUYỂN TRANG
        // =====================================================
        private async void btnPrev_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadProductsPagedAsync();
            }
        }

        private async void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadProductsPagedAsync();
            }
        }

        // =====================================================
        // 4. SỰ KIỆN TÌM KIẾM & BỘ LỌC NHÓM HÀNG
        // =====================================================
        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            _currentPage = 1; // Khi tìm kiếm từ khóa mới, luôn quay về trang 1
            await LoadProductsPagedAsync();
        }

        private async void txtKeyword_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _currentPage = 1;
                await LoadProductsPagedAsync();
            }
        }

        private async void cboFilterCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isFilterLoading) return;
            _currentPage = 1; // Khi đổi danh mục lọc, quay về trang 1
            await LoadProductsPagedAsync();
        }

        private async void btnLoad_Click(object? sender, EventArgs e)
        {
            txtKeyword.Clear();
            if (cboFilterCategory.Items.Count > 0)
            {
                cboFilterCategory.SelectedIndex = 0;
            }
            _currentPage = 1;
            await LoadCategoriesComboAsync();
            await LoadProductsPagedAsync();
            ClearInputs();
        }

        // =====================================================
        // 5. CLICK DÒNG TRÊN DATAGRIDVIEW -> ĐỔ VÀO FORM
        // =====================================================
        private void dgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvProducts.Rows[e.RowIndex].DataBoundItem is ProductItemViewDto item)
            {
                txtProductId.Text = item.ProductId.ToString();
                txtBarcode.Text = item.Barcode;
                txtProductName.Text = item.ProductName;
                txtPrice.Text = item.Price.ToString("0.##");
                txtStockQuantity.Text = item.StockQuantity.ToString();
                txtUnit.Text = item.Unit ?? string.Empty;

                if (cbCategory.Items.Count > 0)
                {
                    cbCategory.SelectedValue = item.CategoryId;
                }
            }
        }

        // =====================================================
        // 6. THAO TÁC THÊM MỚI SẢN PHẨM (CREATE)
        // =====================================================
        private async void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var newProd = new
            {
                Barcode = txtBarcode.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text.Trim(), CultureInfo.CurrentCulture),
                StockQuantity = int.Parse(txtStockQuantity.Text.Trim()),
                Unit = string.IsNullOrWhiteSpace(txtUnit.Text) ? "Cái" : txtUnit.Text.Trim(),
                CategoryId = (int)cbCategory.SelectedValue!
            };

            try
            {
                var res = await ApiClientService.Client.PostAsJsonAsync("products", newProd);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    await LoadProductsPagedAsync();
                }
                else
                {
                    string err = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"Thêm thất bại. Mã: {res.StatusCode}\n{err}", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // 7. THAO TÁC CẬP NHẬT SẢN PHẨM (UPDATE)
        // =====================================================
        private async void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtProductId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa trên danh sách!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            var updateProd = new
            {
                ProductId = id,
                Barcode = txtBarcode.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text.Trim(), CultureInfo.CurrentCulture),
                StockQuantity = int.Parse(txtStockQuantity.Text.Trim()),
                Unit = string.IsNullOrWhiteSpace(txtUnit.Text) ? "Cái" : txtUnit.Text.Trim(),
                CategoryId = (int)cbCategory.SelectedValue!
            };

            try
            {
                var res = await ApiClientService.Client.PutAsJsonAsync($"products/{id}", updateProd);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    await LoadProductsPagedAsync();
                }
                else
                {
                    string err = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"Cập nhật thất bại. Mã: {res.StatusCode}\n{err}", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // 8. THAO TÁC XÓA SẢN PHẨM (DELETE)
        // =====================================================
        private async void btnDelete_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtProductId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa trên danh sách!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtProductName.Text.Trim();
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm #{id} - '{name}' khỏi hệ thống?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var res = await ApiClientService.Client.DeleteAsync($"products/{id}");
                    if (res.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã xóa sản phẩm thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        await LoadProductsPagedAsync();
                    }
                    else
                    {
                        string err = await res.Content.ReadAsStringAsync();
                        MessageBox.Show($"Xóa thất bại. Mã: {res.StatusCode}\n{err}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =====================================================
        // TIỆN ÍCH LÀM SẠCH VÀ VALIDATION
        // =====================================================
        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtProductId.Clear();
            txtBarcode.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtStockQuantity.Clear();
            txtUnit.Clear();

            if (cbCategory.Items.Count > 0)
                cbCategory.SelectedIndex = 0;

            dgvProducts.ClearSelection();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã vạch sản phẩm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarcode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal price) || price < 0)
            {
                MessageBox.Show("Đơn giá sản phẩm không hợp lệ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            if (!int.TryParse(txtStockQuantity.Text.Trim(), out int stock) || stock < 0)
            {
                MessageBox.Show("Số lượng tồn kho phải là số nguyên không âm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockQuantity.Focus();
                return false;
            }

            if (cbCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCategory.Focus();
                return false;
            }

            return true;
        }

        // =====================================================
        // TIÊU CHÍ 43: CẢNH BÁO HÀNG SẮP HẾT KHO (LOW-STOCK ALERT)
        // Nghiệp vụ: Các sản phẩm có tồn kho <= 10 tự động tô màu đỏ/cam
        // Kỹ thuật: Bắt sự kiện CellFormatting đổi e.CellStyle.BackColor
        // =====================================================
        private void dgvProducts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvProducts.Rows.Count) return;

            // Kiểm tra cột StockQuantity
            if (dgvProducts.Columns[e.ColumnIndex].Name == "StockQuantity" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int qty))
                {
                if (e.CellStyle != null)
                {
                    if (qty <= 10)
                    {
                        // Tiêu chí 43: Nếu tồn kho <= 10 thì đổi màu nền Color.LightCoral
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.Font = new Font(dgvProducts.Font, FontStyle.Bold);
                        e.CellStyle.SelectionBackColor = Color.Crimson;
                        e.CellStyle.SelectionForeColor = Color.White;
                    }
                    else if (qty <= 25)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(254, 243, 199); // Vàng cam cảnh báo
                        e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
                        e.CellStyle.Font = new Font(dgvProducts.Font, FontStyle.Bold);
                    }
                }
                }
            }
        }

        // =====================================================
        // TIÊU CHÍ 48: XUẤT DANH MỤC SẢN PHẨM RA EXCEL / CSV
        // =====================================================
        private async void btnExportExcel_Click(object? sender, EventArgs e)
        {
            try
            {
                // Lấy toàn bộ danh sách sản phẩm từ API
                var products = await ApiClientService.Client.GetFromJsonAsync<List<ProductItemViewDto>>("products");
                if (products == null || products.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var sfd = new SaveFileDialog
                {
                    Filter = "CSV (Excel Compatible) (*.csv)|*.csv|All Files (*.*)|*.*",
                    FileName = $"DanhSachSanPham_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    Title = "Xuất danh mục sản phẩm ra Excel / CSV"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var sb = new System.Text.StringBuilder();
                    // Tiêu đề cột
                    sb.AppendLine("Mã SP,Mã vạch,Tên sản phẩm,Đơn giá (VNĐ),Tồn kho,Đơn vị,Nhóm hàng,Cảnh báo tồn kho");

                    foreach (var p in products)
                    {
                        string alert = p.StockQuantity <= 10 ? "SẮP HẾT HÀNG (<= 10)" : (p.StockQuantity <= 25 ? "Cảnh báo" : "Bình thường");
                        string nameEscaped = $"\"{p.ProductName.Replace("\"", "\"\"")}\"";
                        string catEscaped = $"\"{p.CategoryName.Replace("\"", "\"\"")}\"";
                        sb.AppendLine($"{p.ProductId},\"{p.Barcode}\",{nameEscaped},{p.Price},{p.StockQuantity},\"{p.Unit}\",{catEscaped},\"{alert}\"");
                    }

                    // Lưu file với encoding UTF-8 có BOM để Microsoft Excel đọc font tiếng Việt chính xác
                    await System.IO.File.WriteAllTextAsync(sfd.FileName, sb.ToString(), new System.Text.UTF8Encoding(true));

                    MessageBox.Show($"Đã xuất thành công {products.Count} sản phẩm ra file:\n{sfd.FileName}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelInputs_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}