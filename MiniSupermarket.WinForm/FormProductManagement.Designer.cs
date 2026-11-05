namespace MiniSupermarket.WinForms
{
    partial class FormProductManagement
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
            panelTop = new Panel();
            cboFilterCategory = new ComboBox();
            lblFilterCategory = new Label();
            btnLoad = new Button();
            btnSearch = new Button();
            txtKeyword = new TextBox();
            lblSearch = new Label();
            panelInputs = new Panel();
            lblPanelTitle = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            cbCategory = new ComboBox();
            lblCategory = new Label();
            txtUnit = new TextBox();
            lblUnit = new Label();
            txtStockQuantity = new TextBox();
            lblStock = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
            txtProductName = new TextBox();
            lblProductName = new Label();
            txtBarcode = new TextBox();
            lblBarcode = new Label();
            txtProductId = new TextBox();
            lblProductId = new Label();
            panelBody = new Panel();
            dgvProducts = new DataGridView();
            panelPaging = new Panel();
            lblPaging = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            statusStrip = new StatusStrip();
            lblReady = new ToolStripStatusLabel();
            panelTop.SuspendLayout();
            panelInputs.SuspendLayout();
            panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panelPaging.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(cboFilterCategory);
            panelTop.Controls.Add(lblFilterCategory);
            panelTop.Controls.Add(btnLoad);
            panelTop.Controls.Add(btnSearch);
            panelTop.Controls.Add(txtKeyword);
            panelTop.Controls.Add(lblSearch);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(12, 12);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(15, 12, 15, 12);
            panelTop.Size = new Size(1176, 60);
            panelTop.TabIndex = 0;
            // 
            // cboFilterCategory
            // 
            cboFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterCategory.Font = new Font("Segoe UI", 10F);
            cboFilterCategory.FormattingEnabled = true;
            cboFilterCategory.Location = new Point(480, 16);
            cboFilterCategory.Name = "cboFilterCategory";
            cboFilterCategory.Size = new Size(200, 25);
            cboFilterCategory.TabIndex = 3;
            // 
            // lblFilterCategory
            // 
            lblFilterCategory.AutoSize = true;
            lblFilterCategory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFilterCategory.ForeColor = Color.FromArgb(71, 85, 105);
            lblFilterCategory.Location = new Point(390, 20);
            lblFilterCategory.Name = "lblFilterCategory";
            lblFilterCategory.Size = new Size(84, 17);
            lblFilterCategory.TabIndex = 2;
            lblFilterCategory.Text = "Nhóm hàng:";
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(241, 245, 249);
            btnLoad.Cursor = Cursors.Hand;
            btnLoad.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLoad.ForeColor = Color.FromArgb(71, 85, 105);
            btnLoad.Location = new Point(785, 14);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(88, 30);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "🔄 Tải lại";
            btnLoad.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(37, 99, 235);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(692, 14);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(85, 30);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "🔍 Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtKeyword
            // 
            txtKeyword.BorderStyle = BorderStyle.FixedSingle;
            txtKeyword.Font = new Font("Segoe UI", 10F);
            txtKeyword.Location = new Point(95, 16);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Tên sản phẩm hoặc mã vạch...";
            txtKeyword.Size = new Size(275, 25);
            txtKeyword.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(71, 85, 105);
            lblSearch.Location = new Point(18, 20);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(69, 17);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // panelInputs
            // 
            panelInputs.BackColor = Color.White;
            panelInputs.Controls.Add(lblPanelTitle);
            panelInputs.Controls.Add(btnClear);
            panelInputs.Controls.Add(btnDelete);
            panelInputs.Controls.Add(btnUpdate);
            panelInputs.Controls.Add(btnAdd);
            panelInputs.Controls.Add(cbCategory);
            panelInputs.Controls.Add(lblCategory);
            panelInputs.Controls.Add(txtUnit);
            panelInputs.Controls.Add(lblUnit);
            panelInputs.Controls.Add(txtStockQuantity);
            panelInputs.Controls.Add(lblStock);
            panelInputs.Controls.Add(txtPrice);
            panelInputs.Controls.Add(lblPrice);
            panelInputs.Controls.Add(txtProductName);
            panelInputs.Controls.Add(lblProductName);
            panelInputs.Controls.Add(txtBarcode);
            panelInputs.Controls.Add(lblBarcode);
            panelInputs.Controls.Add(txtProductId);
            panelInputs.Controls.Add(lblProductId);
            panelInputs.Dock = DockStyle.Right;
            panelInputs.Location = new Point(816, 0);
            panelInputs.Name = "panelInputs";
            panelInputs.Padding = new Padding(20);
            panelInputs.Size = new Size(360, 582);
            panelInputs.TabIndex = 1;
            panelInputs.Paint += panelInputs_Paint;
            // 
            // lblPanelTitle
            // 
            lblPanelTitle.AutoSize = true;
            lblPanelTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblPanelTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblPanelTitle.Location = new Point(18, 16);
            lblPanelTitle.Name = "lblPanelTitle";
            lblPanelTitle.Size = new Size(244, 21);
            lblPanelTitle.TabIndex = 18;
            lblPanelTitle.Text = "📝 CHI TIẾT SẢN PHẨM & KHO";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(241, 245, 249);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.5F);
            btnClear.ForeColor = Color.FromArgb(71, 85, 105);
            btnClear.Location = new Point(185, 415);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 40);
            btnClear.TabIndex = 10;
            btnClear.Text = "🧹 Nhập lại";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 38, 38);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(22, 415);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 40);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "🗑 Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(37, 99, 235);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(185, 360);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 40);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "✏️ Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(124, 58, 237);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(22, 360);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 40);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "➕ Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.Font = new Font("Segoe UI", 10F);
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(115, 298);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(220, 25);
            cbCategory.TabIndex = 6;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(71, 85, 105);
            lblCategory.Location = new Point(20, 303);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(66, 15);
            lblCategory.TabIndex = 11;
            lblCategory.Text = "Danh mục:";
            // 
            // txtUnit
            // 
            txtUnit.BorderStyle = BorderStyle.FixedSingle;
            txtUnit.Font = new Font("Segoe UI", 10F);
            txtUnit.Location = new Point(115, 258);
            txtUnit.Name = "txtUnit";
            txtUnit.PlaceholderText = "Chai, Lon, Gói, Thùng, Bao...";
            txtUnit.Size = new Size(220, 25);
            txtUnit.TabIndex = 5;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUnit.ForeColor = Color.FromArgb(71, 85, 105);
            lblUnit.Location = new Point(20, 263);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(46, 15);
            lblUnit.TabIndex = 12;
            lblUnit.Text = "Đơn vị:";
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.BorderStyle = BorderStyle.FixedSingle;
            txtStockQuantity.Font = new Font("Segoe UI", 10F);
            txtStockQuantity.Location = new Point(115, 218);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.PlaceholderText = "0";
            txtStockQuantity.Size = new Size(220, 25);
            txtStockQuantity.TabIndex = 4;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStock.ForeColor = Color.FromArgb(71, 85, 105);
            lblStock.Location = new Point(20, 223);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(55, 15);
            lblStock.TabIndex = 13;
            lblStock.Text = "Tồn kho:";
            // 
            // txtPrice
            // 
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtPrice.Location = new Point(115, 178);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "0";
            txtPrice.Size = new Size(220, 25);
            txtPrice.TabIndex = 3;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(71, 85, 105);
            lblPrice.Location = new Point(20, 183);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(54, 15);
            lblPrice.TabIndex = 14;
            lblPrice.Text = "Giá bán:";
            // 
            // txtProductName
            // 
            txtProductName.BorderStyle = BorderStyle.FixedSingle;
            txtProductName.Font = new Font("Segoe UI", 10F);
            txtProductName.Location = new Point(115, 138);
            txtProductName.Name = "txtProductName";
            txtProductName.PlaceholderText = "Nhập tên mặt hàng tạp hóa...";
            txtProductName.Size = new Size(220, 25);
            txtProductName.TabIndex = 2;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductName.ForeColor = Color.FromArgb(71, 85, 105);
            lblProductName.Location = new Point(20, 143);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(50, 15);
            lblProductName.TabIndex = 15;
            lblProductName.Text = "Tên SP:";
            // 
            // txtBarcode
            // 
            txtBarcode.BorderStyle = BorderStyle.FixedSingle;
            txtBarcode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtBarcode.Location = new Point(115, 98);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.PlaceholderText = "8935001100...";
            txtBarcode.Size = new Size(220, 25);
            txtBarcode.TabIndex = 1;
            // 
            // lblBarcode
            // 
            lblBarcode.AutoSize = true;
            lblBarcode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBarcode.ForeColor = Color.FromArgb(71, 85, 105);
            lblBarcode.Location = new Point(20, 103);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(56, 15);
            lblBarcode.TabIndex = 16;
            lblBarcode.Text = "Mã vạch:";
            // 
            // txtProductId
            // 
            txtProductId.BackColor = Color.FromArgb(241, 245, 249);
            txtProductId.BorderStyle = BorderStyle.FixedSingle;
            txtProductId.Font = new Font("Segoe UI", 10F);
            txtProductId.Location = new Point(115, 58);
            txtProductId.Name = "txtProductId";
            txtProductId.ReadOnly = true;
            txtProductId.Size = new Size(220, 25);
            txtProductId.TabIndex = 0;
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductId.ForeColor = Color.FromArgb(71, 85, 105);
            lblProductId.Location = new Point(20, 63);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(46, 15);
            lblProductId.TabIndex = 17;
            lblProductId.Text = "Mã ID:";
            // 
            // panelBody
            // 
            panelBody.Controls.Add(dgvProducts);
            panelBody.Controls.Add(panelPaging);
            panelBody.Controls.Add(panelInputs);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(12, 72);
            panelBody.Name = "panelBody";
            panelBody.Padding = new Padding(0, 10, 0, 0);
            panelBody.Size = new Size(1176, 582);
            panelBody.TabIndex = 1;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(0, 10);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(816, 527);
            dgvProducts.TabIndex = 2;
            // 
            // panelPaging
            // 
            panelPaging.BackColor = Color.White;
            panelPaging.Controls.Add(lblPaging);
            panelPaging.Controls.Add(btnNext);
            panelPaging.Controls.Add(btnPrev);
            panelPaging.Dock = DockStyle.Bottom;
            panelPaging.Location = new Point(0, 537);
            panelPaging.Name = "panelPaging";
            panelPaging.Padding = new Padding(12, 8, 12, 8);
            panelPaging.Size = new Size(816, 45);
            panelPaging.TabIndex = 3;
            // 
            // lblPaging
            // 
            lblPaging.Anchor = AnchorStyles.Top;
            lblPaging.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPaging.ForeColor = Color.FromArgb(71, 85, 105);
            lblPaging.Location = new Point(238, 12);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(340, 23);
            lblPaging.TabIndex = 1;
            lblPaging.Text = "Trang 1 / 1 (Tổng số: 0 sản phẩm)";
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
            btnNext.Location = new Point(676, 8);
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
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(241, 245, 249);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblReady });
            statusStrip.Location = new Point(12, 654);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1176, 22);
            statusStrip.TabIndex = 2;
            // 
            // lblReady
            // 
            lblReady.Font = new Font("Segoe UI", 8.5F);
            lblReady.ForeColor = Color.FromArgb(100, 116, 139);
            lblReady.Name = "lblReady";
            lblReady.Size = new Size(54, 17);
            lblReady.Text = "Sẵn sàng";
            // 
            // FormProductManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1200, 688);
            Controls.Add(panelBody);
            Controls.Add(statusStrip);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 9.75F);
            Name = "FormProductManagement";
            Padding = new Padding(12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sản phẩm & Tồn kho";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelInputs.ResumeLayout(false);
            panelInputs.PerformLayout();
            panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panelPaging.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTop;
        private Label lblSearch;
        private TextBox txtKeyword;
        private Label lblFilterCategory;
        private ComboBox cboFilterCategory;
        private Button btnSearch;
        private Button btnLoad;
        private Panel panelBody;
        private Panel panelInputs;
        private Label lblPanelTitle;
        private Label lblProductId;
        private TextBox txtProductId;
        private Label lblBarcode;
        private TextBox txtBarcode;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblStock;
        private TextBox txtStockQuantity;
        private Label lblUnit;
        private TextBox txtUnit;
        private Label lblCategory;
        private ComboBox cbCategory;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvProducts;
        private Panel panelPaging;
        private Button btnPrev;
        private Label lblPaging;
        private Button btnNext;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblReady;
    }
}