namespace MiniSupermarket.WinForms
{
    partial class FormCategoryManagement
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
            // ------------------------------------------------------------------
            // 1. KHỞI TẠO CÁC CONTROL
            // ------------------------------------------------------------------
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();

            this.dgvCategories = new System.Windows.Forms.DataGridView();

            this.grpEditor = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.grpEditor.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // ------------------------------------------------------------------
            // 2. KHU VỰC TÌM KIẾM (grpSearch)
            // ------------------------------------------------------------------
            this.grpSearch.Controls.Add(this.lblKeyword);
            this.grpSearch.Controls.Add(this.txtKeyword);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.btnLoad);
            this.grpSearch.Location = new System.Drawing.Point(12, 12);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(860, 65);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Tìm kiếm & Thao tác nhanh";

            // Label Tìm kiếm
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Location = new System.Drawing.Point(15, 28);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(53, 15);
            this.lblKeyword.TabIndex = 0;
            this.lblKeyword.Text = "Từ khóa:";

            // Ô nhập từ khóa
            this.txtKeyword.Location = new System.Drawing.Point(74, 25);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(300, 23);
            this.txtKeyword.TabIndex = 1;

            // Nút Tìm kiếm
            this.btnSearch.Location = new System.Drawing.Point(385, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍 Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // Nút Tải lại
            this.btnLoad.Location = new System.Drawing.Point(485, 24);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(90, 25);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "🔄 Tải lại";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            // ------------------------------------------------------------------
            // 3. BẢNG DỮ LIỆU (dgvCategories)
            // ------------------------------------------------------------------
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(12, 85);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(515, 385);
            this.dgvCategories.TabIndex = 1;
            this.dgvCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellClick);

            // ------------------------------------------------------------------
            // 4. KHU VỰC CHI TIẾT DANH MỤC (grpEditor)
            // ------------------------------------------------------------------
            this.grpEditor.Controls.Add(this.lblId);
            this.grpEditor.Controls.Add(this.txtId);
            this.grpEditor.Controls.Add(this.lblCategoryName);
            this.grpEditor.Controls.Add(this.txtCategoryName);
            this.grpEditor.Controls.Add(this.lblDescription);
            this.grpEditor.Controls.Add(this.txtDescription);
            this.grpEditor.Controls.Add(this.pnlButtons);
            this.grpEditor.Location = new System.Drawing.Point(535, 85);
            this.grpEditor.Name = "grpEditor";
            this.grpEditor.Size = new System.Drawing.Size(337, 385);
            this.grpEditor.TabIndex = 2;
            this.grpEditor.TabStop = false;
            this.grpEditor.Text = "Thông tin danh mục";

            // Label & TextBox Mã ID
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(15, 35);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(83, 15);
            this.lblId.Text = "Mã danh mục:";

            this.txtId.Location = new System.Drawing.Point(110, 32);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(210, 23);
            this.txtId.TabIndex = 0;

            // Label & TextBox Tên danh mục
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(15, 80);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(84, 15);
            this.lblCategoryName.Text = "Tên danh mục:";

            this.txtCategoryName.Location = new System.Drawing.Point(110, 77);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(210, 23);
            this.txtCategoryName.TabIndex = 1;

            // Label & TextBox Mô tả
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 125);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(41, 15);
            this.lblDescription.Text = "Mô tả:";

            this.txtDescription.Location = new System.Drawing.Point(110, 122);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(210, 110);
            this.txtDescription.TabIndex = 2;

            // Panel chứa bộ nút thao tác
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Location = new System.Drawing.Point(18, 255);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(302, 45);
            this.pnlButtons.TabIndex = 3;

            // Nút Thêm
            this.btnAdd.Location = new System.Drawing.Point(0, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "➕ Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // Nút Sửa
            this.btnUpdate.Location = new System.Drawing.Point(106, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 35);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "✏️ Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // Nút Xóa
            this.btnDelete.Location = new System.Drawing.Point(212, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // ------------------------------------------------------------------
            // 5. CẤU HÌNH TỔNG THỂ FORM
            // ------------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 481);
            this.Controls.Add(this.grpEditor);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.grpSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormCategoryManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; this.Text = "Quản lý danh mục sản phẩm";

            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.grpEditor.ResumeLayout(false);
            this.grpEditor.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // Khai báo danh sách các Control
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblKeyword;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;

        private System.Windows.Forms.DataGridView dgvCategories;

        private System.Windows.Forms.GroupBox grpEditor;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}