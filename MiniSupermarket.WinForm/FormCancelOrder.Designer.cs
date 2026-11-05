namespace MiniSupermarket.WinForms.Forms
{
    partial class FormCancelOrder
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
            panelHeader = new System.Windows.Forms.Panel();
            lblSubTitle = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            lblOrderId = new System.Windows.Forms.Label();
            txtOrderId = new System.Windows.Forms.TextBox();
            btnLookup = new System.Windows.Forms.Button();
            grpOrderInfo = new System.Windows.Forms.GroupBox();
            lstItems = new System.Windows.Forms.ListBox();
            lblItemsTitle = new System.Windows.Forms.Label();
            lblStatusValue = new System.Windows.Forms.Label();
            lblStatusTitle = new System.Windows.Forms.Label();
            lblTotalValue = new System.Windows.Forms.Label();
            lblTotalTitle = new System.Windows.Forms.Label();
            lblCashierValue = new System.Windows.Forms.Label();
            lblCashierTitle = new System.Windows.Forms.Label();
            lblDateValue = new System.Windows.Forms.Label();
            lblDateTitle = new System.Windows.Forms.Label();
            lblReason = new System.Windows.Forms.Label();
            cboReason = new System.Windows.Forms.ComboBox();
            btnConfirm = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            panelHeader.SuspendLayout();
            grpOrderInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(30, 27, 75);
            panelHeader.Controls.Add(lblSubTitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            panelHeader.Size = new System.Drawing.Size(540, 75);
            panelHeader.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            lblSubTitle.Location = new System.Drawing.Point(20, 42);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new System.Drawing.Size(370, 15);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Hủy giao dịch hóa đơn bán lẻ và tự động hoàn trả số lượng vào kho CSDL";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            lblTitle.Location = new System.Drawing.Point(18, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(306, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🗑️ HỦY ĐƠN HÀNG & HOÀN TỒN KHO";
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblOrderId.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblOrderId.Location = new System.Drawing.Point(24, 95);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new System.Drawing.Size(120, 17);
            lblOrderId.TabIndex = 1;
            lblOrderId.Text = "Mã hóa đơn (ID):";
            // 
            // txtOrderId
            // 
            txtOrderId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtOrderId.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            txtOrderId.Location = new System.Drawing.Point(150, 91);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.PlaceholderText = "Nhập mã đơn ví dụ: 16";
            txtOrderId.Size = new System.Drawing.Size(220, 27);
            txtOrderId.TabIndex = 2;
            // 
            // btnLookup
            // 
            btnLookup.BackColor = System.Drawing.Color.FromArgb(124, 58, 237);
            btnLookup.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLookup.FlatAppearance.BorderSize = 0;
            btnLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLookup.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnLookup.ForeColor = System.Drawing.Color.White;
            btnLookup.Location = new System.Drawing.Point(380, 90);
            btnLookup.Name = "btnLookup";
            btnLookup.Size = new System.Drawing.Size(130, 29);
            btnLookup.TabIndex = 3;
            btnLookup.Text = "🔍 Tra Cứu";
            btnLookup.UseVisualStyleBackColor = false;
            // 
            // grpOrderInfo
            // 
            grpOrderInfo.Controls.Add(lstItems);
            grpOrderInfo.Controls.Add(lblItemsTitle);
            grpOrderInfo.Controls.Add(lblStatusValue);
            grpOrderInfo.Controls.Add(lblStatusTitle);
            grpOrderInfo.Controls.Add(lblTotalValue);
            grpOrderInfo.Controls.Add(lblTotalTitle);
            grpOrderInfo.Controls.Add(lblCashierValue);
            grpOrderInfo.Controls.Add(lblCashierTitle);
            grpOrderInfo.Controls.Add(lblDateValue);
            grpOrderInfo.Controls.Add(lblDateTitle);
            grpOrderInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            grpOrderInfo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            grpOrderInfo.Location = new System.Drawing.Point(24, 135);
            grpOrderInfo.Name = "grpOrderInfo";
            grpOrderInfo.Padding = new System.Windows.Forms.Padding(12);
            grpOrderInfo.Size = new System.Drawing.Size(490, 255);
            grpOrderInfo.TabIndex = 4;
            grpOrderInfo.TabStop = false;
            grpOrderInfo.Text = "Thông Tin Hóa Đơn Chi Tiết";
            // 
            // lstItems
            // 
            lstItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lstItems.Font = new System.Drawing.Font("Segoe UI", 9F);
            lstItems.FormattingEnabled = true;
            lstItems.ItemHeight = 15;
            lstItems.Location = new System.Drawing.Point(15, 150);
            lstItems.Name = "lstItems";
            lstItems.Size = new System.Drawing.Size(460, 92);
            lstItems.TabIndex = 9;
            // 
            // lblItemsTitle
            // 
            lblItemsTitle.AutoSize = true;
            lblItemsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblItemsTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblItemsTitle.Location = new System.Drawing.Point(15, 128);
            lblItemsTitle.Name = "lblItemsTitle";
            lblItemsTitle.Size = new System.Drawing.Size(207, 15);
            lblItemsTitle.TabIndex = 8;
            lblItemsTitle.Text = "Danh sách sản phẩm sẽ hoàn trả kho:";
            // 
            // lblStatusValue
            // 
            lblStatusValue.AutoSize = true;
            lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblStatusValue.ForeColor = System.Drawing.Color.FromArgb(124, 58, 237);
            lblStatusValue.Location = new System.Drawing.Point(340, 65);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new System.Drawing.Size(95, 17);
            lblStatusValue.TabIndex = 7;
            lblStatusValue.Text = "Chưa tra cứu...";
            // 
            // lblStatusTitle
            // 
            lblStatusTitle.AutoSize = true;
            lblStatusTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblStatusTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblStatusTitle.Location = new System.Drawing.Point(265, 65);
            lblStatusTitle.Name = "lblStatusTitle";
            lblStatusTitle.Size = new System.Drawing.Size(64, 15);
            lblStatusTitle.TabIndex = 6;
            lblStatusTitle.Text = "Trạng thái:";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblTotalValue.Location = new System.Drawing.Point(340, 28);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new System.Drawing.Size(39, 21);
            lblTotalValue.TabIndex = 5;
            lblTotalValue.Text = "0 đ";
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblTotalTitle.Location = new System.Drawing.Point(265, 32);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new System.Drawing.Size(60, 15);
            lblTotalTitle.TabIndex = 4;
            lblTotalTitle.Text = "Tổng tiền:";
            // 
            // lblCashierValue
            // 
            lblCashierValue.AutoSize = true;
            lblCashierValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblCashierValue.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblCashierValue.Location = new System.Drawing.Point(90, 65);
            lblCashierValue.Name = "lblCashierValue";
            lblCashierValue.Size = new System.Drawing.Size(23, 17);
            lblCashierValue.TabIndex = 3;
            lblCashierValue.Text = "---";
            // 
            // lblCashierTitle
            // 
            lblCashierTitle.AutoSize = true;
            lblCashierTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblCashierTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblCashierTitle.Location = new System.Drawing.Point(15, 65);
            lblCashierTitle.Name = "lblCashierTitle";
            lblCashierTitle.Size = new System.Drawing.Size(61, 15);
            lblCashierTitle.TabIndex = 2;
            lblCashierTitle.Text = "Thu ngân:";
            // 
            // lblDateValue
            // 
            lblDateValue.AutoSize = true;
            lblDateValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblDateValue.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblDateValue.Location = new System.Drawing.Point(90, 32);
            lblDateValue.Name = "lblDateValue";
            lblDateValue.Size = new System.Drawing.Size(23, 17);
            lblDateValue.TabIndex = 1;
            lblDateValue.Text = "---";
            // 
            // lblDateTitle
            // 
            lblDateTitle.AutoSize = true;
            lblDateTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblDateTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblDateTitle.Location = new System.Drawing.Point(15, 32);
            lblDateTitle.Name = "lblDateTitle";
            lblDateTitle.Size = new System.Drawing.Size(59, 15);
            lblDateTitle.TabIndex = 0;
            lblDateTitle.Text = "Thời gian:";
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblReason.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblReason.Location = new System.Drawing.Point(24, 405);
            lblReason.Name = "lblReason";
            lblReason.Size = new System.Drawing.Size(84, 17);
            lblReason.TabIndex = 5;
            lblReason.Text = "Lý do hủy:";
            // 
            // cboReason
            // 
            cboReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboReason.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cboReason.FormattingEnabled = true;
            cboReason.Items.AddRange(new object[] {
            "Khách hàng đổi ý, không mua nữa",
            "Thu ngân nhập sai món / tính nhầm",
            "Hàng hóa bị lỗi / khách đổi trả hàng",
            "Lỗi thanh toán / sai phương thức",
            "Lý do khác"});
            cboReason.Location = new System.Drawing.Point(125, 402);
            cboReason.Name = "cboReason";
            cboReason.Size = new System.Drawing.Size(389, 25);
            cboReason.TabIndex = 6;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            btnConfirm.ForeColor = System.Drawing.Color.White;
            btnConfirm.Location = new System.Drawing.Point(175, 448);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new System.Drawing.Size(210, 42);
            btnConfirm.TabIndex = 7;
            btnConfirm.Text = "❌ Xác Nhận Hủy & Hoàn Kho";
            btnConfirm.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnClose.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnClose.Location = new System.Drawing.Point(395, 448);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(119, 42);
            btnClose.TabIndex = 8;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // FormCancelOrder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(540, 508);
            Controls.Add(btnClose);
            Controls.Add(btnConfirm);
            Controls.Add(cboReason);
            Controls.Add(lblReason);
            Controls.Add(grpOrderInfo);
            Controls.Add(btnLookup);
            Controls.Add(txtOrderId);
            Controls.Add(lblOrderId);
            Controls.Add(panelHeader);
            Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCancelOrder";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Hủy Đơn Hàng & Hoàn Trả Kho POS";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpOrderInfo.ResumeLayout(false);
            grpOrderInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.GroupBox grpOrderInfo;
        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblCashierTitle;
        private System.Windows.Forms.Label lblCashierValue;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblItemsTitle;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cboReason;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClose;
    }
}
