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
            grpSearch = new GroupBox();
            btnLoad = new Button();
            btnSearch = new Button();
            txtKeyword = new TextBox();
            grpList = new GroupBox();
            dgvCategories = new DataGridView();
            CategoryId = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            grpInfo = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtCategoryName = new TextBox();
            lblCategoryName = new Label();
            txtId = new TextBox();
            lblId = new Label();
            statusStrip1 = new StatusStrip();
            lblReady = new ToolStripStatusLabel();
            lblApiUrl = new ToolStripStatusLabel();
            grpSearch.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            grpInfo.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grpSearch
            // 
            grpSearch.Controls.Add(btnLoad);
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Controls.Add(txtKeyword);
            grpSearch.Font = new Font("Segoe UI", 9F);
            grpSearch.Location = new Point(12, 12);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(475, 65);
            grpSearch.TabIndex = 0;
            grpSearch.TabStop = false;
            grpSearch.Text = "Tìm kiếm";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(377, 22);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(85, 28);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(286, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(85, 28);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtKeyword
            // 
            txtKeyword.Font = new Font("Segoe UI", 9.75F);
            txtKeyword.Location = new Point(12, 24);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Nhập từ khóa...";
            txtKeyword.Size = new Size(268, 25);
            txtKeyword.TabIndex = 0;
            // 
            // grpList
            // 
            grpList.Controls.Add(dgvCategories);
            grpList.Font = new Font("Segoe UI", 9F);
            grpList.Location = new Point(12, 83);
            grpList.Name = "grpList";
            grpList.Size = new Size(475, 345);
            grpList.TabIndex = 1;
            grpList.TabStop = false;
            grpList.Text = "Danh sách Nhóm hàng";
            // 
            // dgvCategories
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.BackgroundColor = SystemColors.Window;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Columns.AddRange(new DataGridViewColumn[] { CategoryId, CategoryName, Description });
            dgvCategories.Dock = DockStyle.Fill;
            dgvCategories.Location = new Point(3, 19);
            dgvCategories.MultiSelect = false;
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(469, 323);
            dgvCategories.TabIndex = 0;
            dgvCategories.CellClick += dgvCategories_CellClick;
            // 
            // CategoryId
            // 
            CategoryId.DataPropertyName = "CategoryId";
            CategoryId.FillWeight = 25F;
            CategoryId.HeaderText = "Mã ID";
            CategoryId.Name = "CategoryId";
            CategoryId.ReadOnly = true;
            // 
            // CategoryName
            // 
            CategoryName.DataPropertyName = "CategoryName";
            CategoryName.FillWeight = 45F;
            CategoryName.HeaderText = "Tên Nhóm hàng";
            CategoryName.Name = "CategoryName";
            CategoryName.ReadOnly = true;
            // 
            // Description
            // 
            Description.DataPropertyName = "Description";
            Description.FillWeight = 50F;
            Description.HeaderText = "Mô Tả";
            Description.Name = "Description";
            Description.ReadOnly = true;
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnUpdate);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(txtDescription);
            grpInfo.Controls.Add(lblDescription);
            grpInfo.Controls.Add(txtCategoryName);
            grpInfo.Controls.Add(lblCategoryName);
            grpInfo.Controls.Add(txtId);
            grpInfo.Controls.Add(lblId);
            grpInfo.Font = new Font("Segoe UI", 9F);
            grpInfo.Location = new Point(493, 12);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(295, 416);
            grpInfo.TabIndex = 2;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin Nhóm hàng";
            grpInfo.Enter += grpInfo_Enter;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(198, 365);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 32);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(106, 365);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(86, 32);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(14, 365);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(86, 32);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 9.75F);
            txtDescription.Location = new Point(14, 190);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Mô tả chi tiết...";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(266, 155);
            txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(14, 168);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(40, 15);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Mô Tả";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Font = new Font("Segoe UI", 9.75F);
            txtCategoryName.Location = new Point(14, 122);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.PlaceholderText = "Ví dụ: Bánh kẹo";
            txtCategoryName.Size = new Size(266, 25);
            txtCategoryName.TabIndex = 3;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(14, 100);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(92, 15);
            lblCategoryName.TabIndex = 2;
            lblCategoryName.Text = "Tên Nhóm hàng";
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 9.75F);
            txtId.Location = new Point(14, 55);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(266, 25);
            txtId.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(14, 33);
            lblId.Name = "lblId";
            lblId.Size = new Size(38, 15);
            lblId.TabIndex = 0;
            lblId.Text = "Mã ID";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblReady, lblApiUrl });
            statusStrip1.Location = new Point(0, 439);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblReady
            // 
            lblReady.Name = "lblReady";
            lblReady.Size = new Size(39, 17);
            lblReady.Text = "Ready";
            // 
            // lblApiUrl
            // 
            lblApiUrl.Name = "lblApiUrl";
            lblApiUrl.Size = new Size(202, 17);
            lblApiUrl.Text = "https://localhost:7292/api/categories";
            // 
            // FormCategoryManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 461);
            Controls.Add(statusStrip1);
            Controls.Add(grpInfo);
            Controls.Add(grpList);
            Controls.Add(grpSearch);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormCategoryManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Danh mục Nhóm hàng - FormCategoryManagement";
            Load += FormCategoryManagement_Load;
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpSearch;
        private TextBox txtKeyword;
        private Button btnSearch;
        private Button btnLoad;
        private GroupBox grpList;
        private DataGridView dgvCategories;
        private GroupBox grpInfo;
        private Label lblId;
        private TextBox txtId;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblReady;
        private ToolStripStatusLabel lblApiUrl;
        private DataGridViewTextBoxColumn CategoryId;
        private DataGridViewTextBoxColumn CategoryName;
        private DataGridViewTextBoxColumn Description;
    }
}