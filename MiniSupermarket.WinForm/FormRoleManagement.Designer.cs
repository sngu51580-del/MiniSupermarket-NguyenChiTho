namespace MiniSupermarket.WinForms
{
    partial class FormRoleManagement
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
            grpList = new GroupBox();
            dgvRoles = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colRoleName = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            grpInfo = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtRoleName = new TextBox();
            lblRoleName = new Label();
            txtId = new TextBox();
            lblId = new Label();
            statusStrip1 = new StatusStrip();
            lblReady = new ToolStripStatusLabel();
            lblApiUrl = new ToolStripStatusLabel();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
            grpInfo.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grpList
            // 
            grpList.Controls.Add(dgvRoles);
            grpList.Location = new Point(12, 12);
            grpList.Name = "grpList";
            grpList.Size = new Size(475, 416);
            grpList.TabIndex = 0;
            grpList.TabStop = false;
            grpList.Text = "Danh sách Vai trò";
            // 
            // dgvRoles
            // 
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoles.BackgroundColor = SystemColors.Window;
            dgvRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoles.Columns.AddRange(new DataGridViewColumn[] { colId, colRoleName, colDesc });
            dgvRoles.Dock = DockStyle.Fill;
            dgvRoles.Location = new Point(3, 19);
            dgvRoles.MultiSelect = false;
            dgvRoles.Name = "dgvRoles";
            dgvRoles.ReadOnly = true;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.Size = new Size(469, 394);
            dgvRoles.TabIndex = 0;
            dgvRoles.CellClick += dgvRoles_CellClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.FillWeight = 25F;
            colId.HeaderText = "Mã ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colRoleName
            // 
            colRoleName.DataPropertyName = "RoleName";
            colRoleName.FillWeight = 45F;
            colRoleName.HeaderText = "Tên Vai trò";
            colRoleName.Name = "colRoleName";
            colRoleName.ReadOnly = true;
            // 
            // colDesc
            // 
            colDesc.DataPropertyName = "Description";
            colDesc.FillWeight = 50F;
            colDesc.HeaderText = "Mô Tả";
            colDesc.Name = "colDesc";
            colDesc.ReadOnly = true;
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnUpdate);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(txtDescription);
            grpInfo.Controls.Add(lblDescription);
            grpInfo.Controls.Add(txtRoleName);
            grpInfo.Controls.Add(lblRoleName);
            grpInfo.Controls.Add(txtId);
            grpInfo.Controls.Add(lblId);
            grpInfo.Location = new Point(493, 12);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(295, 416);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin Vai trò";
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
            txtDescription.PlaceholderText = "Mô tả vai trò...";
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
            // txtRoleName
            // 
            txtRoleName.Font = new Font("Segoe UI", 9.75F);
            txtRoleName.Location = new Point(14, 122);
            txtRoleName.Name = "txtRoleName";
            txtRoleName.PlaceholderText = "Ví dụ: Admin, Quản lý...";
            txtRoleName.Size = new Size(266, 25);
            txtRoleName.TabIndex = 3;
            // 
            // lblRoleName
            // 
            lblRoleName.AutoSize = true;
            lblRoleName.Location = new Point(14, 100);
            lblRoleName.Name = "lblRoleName";
            lblRoleName.Size = new Size(61, 15);
            lblRoleName.TabIndex = 2;
            lblRoleName.Text = "Tên Vai trò";
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
            statusStrip1.TabIndex = 2;
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
            lblApiUrl.Size = new Size(173, 17);
            lblApiUrl.Text = "https://localhost:7123/api/roles";
            // 
            // FormRoleManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 461);
            Controls.Add(statusStrip1);
            Controls.Add(grpInfo);
            Controls.Add(grpList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormRoleManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Vai trò - FormRoleManagement";
            Load += FormRoleManagement_Load;
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpList;
        private DataGridView dgvRoles;
        private GroupBox grpInfo;
        private Label lblId;
        private TextBox txtId;
        private Label lblRoleName;
        private TextBox txtRoleName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblReady;
        private ToolStripStatusLabel lblApiUrl;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colRoleName;
        private DataGridViewTextBoxColumn colDesc;
    }
}