namespace MiniSupermarket.WinForms
{
    partial class FormCustomerManagement
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
            btnLoad = new Button();
            btnSearch = new Button();
            txtKeyword = new TextBox();
            lblSearch = new Label();
            panelBody = new Panel();
            dgvCustomers = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colPoints = new DataGridViewTextBoxColumn();
            colRank = new DataGridViewTextBoxColumn();
            panelPaging = new Panel();
            lblPaging = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            panelInfo = new Panel();
            lblInfoTitle = new Label();
            cbMembershipRank = new ComboBox();
            lblMembershipRank = new Label();
            txtRewardPoints = new TextBox();
            lblRewardPoints = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtPhoneNumber = new TextBox();
            lblPhoneNumber = new Label();
            txtCustomerName = new TextBox();
            lblCustomerName = new Label();
            txtCustomerId = new TextBox();
            lblCustomerId = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            statusStrip1 = new StatusStrip();
            lblReady = new ToolStripStatusLabel();
            panelTop.SuspendLayout();
            panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            panelPaging.SuspendLayout();
            panelInfo.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
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
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(241, 245, 249);
            btnLoad.Cursor = Cursors.Hand;
            btnLoad.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLoad.ForeColor = Color.FromArgb(71, 85, 105);
            btnLoad.Location = new Point(480, 15);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(90, 30);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "🔄 Tải lại";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(37, 99, 235);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(385, 15);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(88, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtKeyword
            // 
            txtKeyword.BorderStyle = BorderStyle.FixedSingle;
            txtKeyword.Font = new Font("Segoe UI", 10F);
            txtKeyword.Location = new Point(95, 17);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Nhập tên hoặc số điện thoại...";
            txtKeyword.Size = new Size(275, 25);
            txtKeyword.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(71, 85, 105);
            lblSearch.Location = new Point(18, 21);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(69, 17);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // panelBody
            // 
            panelBody.Controls.Add(dgvCustomers);
            panelBody.Controls.Add(panelPaging);
            panelBody.Controls.Add(panelInfo);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(12, 72);
            panelBody.Name = "panelBody";
            panelBody.Padding = new Padding(0, 10, 0, 0);
            panelBody.Size = new Size(1176, 582);
            panelBody.TabIndex = 1;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colPhone, colAddress, colPoints, colRank });
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.Location = new Point(0, 10);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(806, 527);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "CustomerId";
            colId.FillWeight = 15F;
            colId.HeaderText = "Mã KH";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colName
            // 
            colName.DataPropertyName = "CustomerName";
            colName.FillWeight = 30F;
            colName.HeaderText = "Họ và Tên";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.DataPropertyName = "PhoneNumber";
            colPhone.FillWeight = 20F;
            colPhone.HeaderText = "Số Điện Thoại";
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.DataPropertyName = "Address";
            colAddress.FillWeight = 30F;
            colAddress.HeaderText = "Địa Chỉ";
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            // 
            // colPoints
            // 
            colPoints.DataPropertyName = "RewardPoints";
            colPoints.FillWeight = 15F;
            colPoints.HeaderText = "Điểm Tích Lũy";
            colPoints.Name = "colPoints";
            colPoints.ReadOnly = true;
            // 
            // colRank
            // 
            colRank.DataPropertyName = "MembershipRank";
            colRank.FillWeight = 20F;
            colRank.HeaderText = "Hạng Thẻ";
            colRank.Name = "colRank";
            colRank.ReadOnly = true;
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
            panelPaging.Size = new Size(806, 45);
            panelPaging.TabIndex = 2;
            // 
            // lblPaging
            // 
            lblPaging.Anchor = AnchorStyles.Top;
            lblPaging.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPaging.ForeColor = Color.FromArgb(71, 85, 105);
            lblPaging.Location = new Point(233, 12);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(340, 23);
            lblPaging.TabIndex = 1;
            lblPaging.Text = "Trang 1 / 1 (Tổng số: 0 khách hàng)";
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
            btnNext.Location = new Point(666, 8);
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
            // panelInfo
            // 
            panelInfo.BackColor = Color.White;
            panelInfo.Controls.Add(lblInfoTitle);
            panelInfo.Controls.Add(cbMembershipRank);
            panelInfo.Controls.Add(lblMembershipRank);
            panelInfo.Controls.Add(txtRewardPoints);
            panelInfo.Controls.Add(lblRewardPoints);
            panelInfo.Controls.Add(txtAddress);
            panelInfo.Controls.Add(lblAddress);
            panelInfo.Controls.Add(txtPhoneNumber);
            panelInfo.Controls.Add(lblPhoneNumber);
            panelInfo.Controls.Add(txtCustomerName);
            panelInfo.Controls.Add(lblCustomerName);
            panelInfo.Controls.Add(txtCustomerId);
            panelInfo.Controls.Add(lblCustomerId);
            panelInfo.Controls.Add(btnDelete);
            panelInfo.Controls.Add(btnUpdate);
            panelInfo.Controls.Add(btnAdd);
            panelInfo.Dock = DockStyle.Right;
            panelInfo.Location = new Point(806, 10);
            panelInfo.Name = "panelInfo";
            panelInfo.Padding = new Padding(22);
            panelInfo.Size = new Size(370, 572);
            panelInfo.TabIndex = 1;
            // 
            // lblInfoTitle
            // 
            lblInfoTitle.AutoSize = true;
            lblInfoTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblInfoTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblInfoTitle.Location = new Point(18, 16);
            lblInfoTitle.Name = "lblInfoTitle";
            lblInfoTitle.Size = new Size(236, 21);
            lblInfoTitle.TabIndex = 0;
            lblInfoTitle.Text = "👤 THÔNG TIN KHÁCH HÀNG";
            // 
            // cbMembershipRank
            // 
            cbMembershipRank.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMembershipRank.Font = new Font("Segoe UI", 10F);
            cbMembershipRank.FormattingEnabled = true;
            cbMembershipRank.Items.AddRange(new object[] { "Mới", "Thân Thiết", "Bạc", "Vàng", "Kim Cương" });
            cbMembershipRank.Location = new Point(25, 340);
            cbMembershipRank.Name = "cbMembershipRank";
            cbMembershipRank.Size = new Size(320, 25);
            cbMembershipRank.TabIndex = 12;
            // 
            // lblMembershipRank
            // 
            lblMembershipRank.AutoSize = true;
            lblMembershipRank.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMembershipRank.ForeColor = Color.FromArgb(71, 85, 105);
            lblMembershipRank.Location = new Point(25, 320);
            lblMembershipRank.Name = "lblMembershipRank";
            lblMembershipRank.Size = new Size(62, 15);
            lblMembershipRank.TabIndex = 11;
            lblMembershipRank.Text = "Hạng thẻ:";
            // 
            // txtRewardPoints
            // 
            txtRewardPoints.BorderStyle = BorderStyle.FixedSingle;
            txtRewardPoints.Font = new Font("Segoe UI", 10F);
            txtRewardPoints.Location = new Point(25, 280);
            txtRewardPoints.Name = "txtRewardPoints";
            txtRewardPoints.Size = new Size(320, 25);
            txtRewardPoints.TabIndex = 10;
            txtRewardPoints.Text = "0";
            // 
            // lblRewardPoints
            // 
            lblRewardPoints.AutoSize = true;
            lblRewardPoints.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRewardPoints.ForeColor = Color.FromArgb(71, 85, 105);
            lblRewardPoints.Location = new Point(25, 260);
            lblRewardPoints.Name = "lblRewardPoints";
            lblRewardPoints.Size = new Size(84, 15);
            lblRewardPoints.TabIndex = 9;
            lblRewardPoints.Text = "Điểm tích lũy:";
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(25, 220);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(320, 25);
            txtAddress.TabIndex = 8;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(71, 85, 105);
            lblAddress.Location = new Point(25, 200);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(47, 15);
            lblAddress.TabIndex = 7;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            txtPhoneNumber.Font = new Font("Segoe UI", 10F);
            txtPhoneNumber.Location = new Point(25, 160);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(320, 25);
            txtPhoneNumber.TabIndex = 6;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPhoneNumber.ForeColor = Color.FromArgb(71, 85, 105);
            lblPhoneNumber.Location = new Point(25, 140);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(83, 15);
            lblPhoneNumber.TabIndex = 5;
            lblPhoneNumber.Text = "Số điện thoại:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerName.Font = new Font("Segoe UI", 10F);
            txtCustomerName.Location = new Point(25, 105);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(320, 25);
            txtCustomerName.TabIndex = 4;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomerName.ForeColor = Color.FromArgb(71, 85, 105);
            lblCustomerName.Location = new Point(25, 85);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(64, 15);
            lblCustomerName.TabIndex = 3;
            lblCustomerName.Text = "Họ và tên:";
            // 
            // txtCustomerId
            // 
            txtCustomerId.BackColor = Color.FromArgb(248, 250, 252);
            txtCustomerId.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerId.Font = new Font("Segoe UI", 10F);
            txtCustomerId.Location = new Point(25, 55);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.ReadOnly = true;
            txtCustomerId.Size = new Size(320, 25);
            txtCustomerId.TabIndex = 2;
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomerId.ForeColor = Color.FromArgb(71, 85, 105);
            lblCustomerId.Location = new Point(25, 35);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(49, 15);
            lblCustomerId.TabIndex = 1;
            lblCustomerId.Text = "Mã KH:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(250, 390);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(95, 34);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(37, 99, 235);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(138, 390);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 34);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "✏️ Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(124, 58, 237);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(25, 390);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 34);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "➕ Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.White;
            statusStrip1.Font = new Font("Segoe UI", 9F);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblReady });
            statusStrip1.Location = new Point(12, 654);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            statusStrip1.Size = new Size(1176, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblReady
            // 
            lblReady.Font = new Font("Segoe UI", 8.5F);
            lblReady.ForeColor = Color.FromArgb(100, 116, 139);
            lblReady.Name = "lblReady";
            lblReady.Size = new Size(54, 17);
            lblReady.Text = "Sẵn sàng";
            // 
            // FormCustomerManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1200, 688);
            Controls.Add(panelBody);
            Controls.Add(statusStrip1);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 9.75F);
            Name = "FormCustomerManagement";
            Padding = new Padding(12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Khách hàng & Tích điểm hội viên";
            Load += FormCustomerManagement_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            panelPaging.ResumeLayout(false);
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTop;
        private Label lblSearch;
        private TextBox txtKeyword;
        private Button btnSearch;
        private Button btnLoad;
        private Panel panelBody;
        private DataGridView dgvCustomers;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colAddress;
        private DataGridViewTextBoxColumn colPoints;
        private DataGridViewTextBoxColumn colRank;
        private Panel panelPaging;
        private Button btnPrev;
        private Label lblPaging;
        private Button btnNext;
        private Panel panelInfo;
        private Label lblInfoTitle;
        private Label lblCustomerId;
        private TextBox txtCustomerId;
        private Label lblCustomerName;
        private TextBox txtCustomerName;
        private Label lblPhoneNumber;
        private TextBox txtPhoneNumber;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblRewardPoints;
        private TextBox txtRewardPoints;
        private Label lblMembershipRank;
        private ComboBox cbMembershipRank;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblReady;
    }
}
