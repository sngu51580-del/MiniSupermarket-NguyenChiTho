namespace MiniSupermarket.WinForms.Forms
{
    partial class FormPOS
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelTopBar = new Panel();
            lblBarcodeBadge = new Label();
            lblTitle = new Label();
            lblBarcode = new Label();
            txtBarcode = new TextBox();
            btnAdd = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            lblQuantity = new Label();
            nudQuantity = new NumericUpDown();
            panelBody = new Panel();
            panelRight = new Panel();
            panelCartWrap = new Panel();
            dgvCart = new DataGridView();
            colProductId = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colSubTotal = new DataGridViewTextBoxColumn();
            panelCartHeader = new Panel();
            btnCancelOrder = new Button();
            btnClear = new Button();
            btnRemove = new Button();
            lblCart = new Label();
            panelPaymentWrap = new Panel();
            btnPay = new Button();
            lblCustomerSummary = new Label();
            lblRedeemPointsTitle = new Label();
            nudRedeemPoints = new NumericUpDown();
            lblRedeemDiscount = new Label();
            lblPointsSummary = new Label();
            lblPointsSummaryTitle = new Label();
            lblChange = new Label();
            lblChangeTitle = new Label();
            txtAmountReceived = new TextBox();
            lblReceived = new Label();
            cboPaymentMethod = new ComboBox();
            lblMethod = new Label();
            panelTotalBanner = new Panel();
            lblTotal = new Label();
            lblTotalTitle = new Label();
            lblPayment = new Label();
            panelLeft = new Panel();
            panelProductsWrap = new Panel();
            dgvProducts = new DataGridView();
            panelProductsHeader = new Panel();
            lblProductsHeader = new Label();
            grpCustomer = new GroupBox();
            btnSelectGuest = new Button();
            lblCustStatus = new Label();
            lblCustEarn = new Label();
            lblCustEarnTitle = new Label();
            lblCustPoints = new Label();
            lblCustPointsTitle = new Label();
            lblCustRank = new Label();
            lblCustRankTitle = new Label();
            lblCustName = new Label();
            lblCustNameTitle = new Label();
            btnCustClear = new Button();
            btnCustAdd = new Button();
            btnCustSearch = new Button();
            txtCustPhone = new TextBox();
            lblCustPhone = new Label();
            panelTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRedeemPoints).BeginInit();
            panelBody.SuspendLayout();
            panelRight.SuspendLayout();
            panelCartWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            panelCartHeader.SuspendLayout();
            panelPaymentWrap.SuspendLayout();
            panelTotalBanner.SuspendLayout();
            panelLeft.SuspendLayout();
            panelProductsWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panelProductsHeader.SuspendLayout();
            grpCustomer.SuspendLayout();
            SuspendLayout();
            // 
            // panelTopBar
            // 
            panelTopBar.BackColor = Color.White;
            panelTopBar.Controls.Add(lblBarcodeBadge);
            panelTopBar.Controls.Add(lblTitle);
            panelTopBar.Controls.Add(lblBarcode);
            panelTopBar.Controls.Add(txtBarcode);
            panelTopBar.Controls.Add(btnAdd);
            panelTopBar.Controls.Add(lblSearch);
            panelTopBar.Controls.Add(txtSearch);
            panelTopBar.Controls.Add(btnSearch);
            panelTopBar.Controls.Add(lblQuantity);
            panelTopBar.Controls.Add(nudQuantity);
            panelTopBar.Dock = DockStyle.Top;
            panelTopBar.Location = new Point(12, 12);
            panelTopBar.Name = "panelTopBar";
            panelTopBar.Padding = new Padding(12, 10, 12, 10);
            panelTopBar.Size = new Size(1216, 62);
            panelTopBar.TabIndex = 0;
            // 
            // lblBarcodeBadge
            // 
            lblBarcodeBadge.AutoSize = true;
            lblBarcodeBadge.BackColor = Color.FromArgb(245, 243, 255);
            lblBarcodeBadge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBarcodeBadge.ForeColor = Color.FromArgb(124, 58, 237);
            lblBarcodeBadge.Location = new Point(14, 18);
            lblBarcodeBadge.Name = "lblBarcodeBadge";
            lblBarcodeBadge.Padding = new Padding(6, 4, 6, 4);
            lblBarcodeBadge.Size = new Size(130, 28);
            lblBarcodeBadge.TabIndex = 0;
            lblBarcodeBadge.Text = "⚡ QUÉT MÃ VẠCH";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9F);
            lblTitle.ForeColor = Color.Transparent;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 20);
            lblTitle.TabIndex = 0;
            // 
            // lblBarcode
            // 
            lblBarcode.AutoSize = true;
            lblBarcode.Location = new Point(0, 0);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(0, 20);
            lblBarcode.TabIndex = 1;
            lblBarcode.Visible = false;
            // 
            // txtBarcode
            // 
            txtBarcode.BorderStyle = BorderStyle.FixedSingle;
            txtBarcode.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            txtBarcode.Location = new Point(160, 16);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.PlaceholderText = "Quét mã hoặc nhập barcode rồi bấm Enter...";
            txtBarcode.Size = new Size(255, 31);
            txtBarcode.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(124, 58, 237);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(425, 16);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(95, 31);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "+ Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(71, 85, 105);
            lblSearch.Location = new Point(540, 21);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(82, 21);
            lblSearch.TabIndex = 4;
            lblSearch.Text = "🔍 Tìm SP:";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(628, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm theo tên sản phẩm...";
            txtSearch.Size = new Size(200, 30);
            txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(37, 99, 235);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(838, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(65, 30);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblQuantity.ForeColor = Color.FromArgb(71, 85, 105);
            lblQuantity.Location = new Point(920, 21);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(31, 21);
            lblQuantity.TabIndex = 7;
            lblQuantity.Text = "SL:";
            // 
            // nudQuantity
            // 
            nudQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            nudQuantity.Location = new Point(955, 16);
            nudQuantity.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(60, 30);
            nudQuantity.TabIndex = 8;
            nudQuantity.TextAlign = HorizontalAlignment.Center;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // panelBody
            // 
            panelBody.Controls.Add(panelRight);
            panelBody.Controls.Add(panelLeft);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(12, 74);
            panelBody.Name = "panelBody";
            panelBody.Padding = new Padding(0, 10, 0, 0);
            panelBody.Size = new Size(1216, 634);
            panelBody.TabIndex = 1;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(panelCartWrap);
            panelRight.Controls.Add(panelPaymentWrap);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(590, 10);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(10, 0, 0, 0);
            panelRight.Size = new Size(626, 624);
            panelRight.TabIndex = 1;
            // 
            // panelCartWrap
            // 
            panelCartWrap.BackColor = Color.White;
            panelCartWrap.Controls.Add(dgvCart);
            panelCartWrap.Controls.Add(panelCartHeader);
            panelCartWrap.Dock = DockStyle.Fill;
            panelCartWrap.Location = new Point(10, 0);
            panelCartWrap.Name = "panelCartWrap";
            panelCartWrap.Size = new Size(616, 324);
            panelCartWrap.TabIndex = 0;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Columns.AddRange(new DataGridViewColumn[] { colProductId, colProductName, colQuantity, colUnitPrice, colSubTotal });
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Location = new Point(0, 42);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(616, 282);
            dgvCart.TabIndex = 1;
            // 
            // colProductId
            // 
            colProductId.DataPropertyName = "ProductId";
            colProductId.FillWeight = 15F;
            colProductId.HeaderText = "Mã";
            colProductId.MinimumWidth = 6;
            colProductId.Name = "colProductId";
            colProductId.ReadOnly = true;
            // 
            // colProductName
            // 
            colProductName.DataPropertyName = "ProductName";
            colProductName.FillWeight = 45F;
            colProductName.HeaderText = "Sản phẩm";
            colProductName.MinimumWidth = 6;
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.FillWeight = 12F;
            colQuantity.HeaderText = "SL";
            colQuantity.MinimumWidth = 6;
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            // 
            // colUnitPrice
            // 
            colUnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle1.Format = "N0";
            colUnitPrice.DefaultCellStyle = dataGridViewCellStyle1;
            colUnitPrice.FillWeight = 20F;
            colUnitPrice.HeaderText = "Đơn giá";
            colUnitPrice.MinimumWidth = 6;
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.ReadOnly = true;
            // 
            // colSubTotal
            // 
            colSubTotal.DataPropertyName = "SubTotal";
            dataGridViewCellStyle2.Format = "N0";
            colSubTotal.DefaultCellStyle = dataGridViewCellStyle2;
            colSubTotal.FillWeight = 23F;
            colSubTotal.HeaderText = "Thành tiền";
            colSubTotal.MinimumWidth = 6;
            colSubTotal.Name = "colSubTotal";
            colSubTotal.ReadOnly = true;
            // 
            // panelCartHeader
            // 
            panelCartHeader.BackColor = Color.FromArgb(248, 250, 252);
            panelCartHeader.Controls.Add(btnCancelOrder);
            panelCartHeader.Controls.Add(btnClear);
            panelCartHeader.Controls.Add(btnRemove);
            panelCartHeader.Controls.Add(lblCart);
            panelCartHeader.Dock = DockStyle.Top;
            panelCartHeader.Location = new Point(0, 0);
            panelCartHeader.Name = "panelCartHeader";
            panelCartHeader.Size = new Size(616, 42);
            panelCartHeader.TabIndex = 0;
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelOrder.BackColor = Color.FromArgb(254, 242, 242);
            btnCancelOrder.Cursor = Cursors.Hand;
            btnCancelOrder.FlatAppearance.BorderColor = Color.FromArgb(252, 165, 165);
            btnCancelOrder.FlatStyle = FlatStyle.Flat;
            btnCancelOrder.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnCancelOrder.ForeColor = Color.FromArgb(185, 28, 28);
            btnCancelOrder.Location = new Point(308, 7);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(100, 28);
            btnCancelOrder.TabIndex = 3;
            btnCancelOrder.Text = "\U000021a9\U0000fe0f H\u1ee7y \u0111\u01a1n";
            btnCancelOrder.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.FromArgb(241, 245, 249);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 8.5F);
            btnClear.ForeColor = Color.FromArgb(71, 85, 105);
            btnClear.Location = new Point(510, 7);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(95, 28);
            btnClear.TabIndex = 2;
            btnClear.Text = "\U0001f9f9 Làm rỗng";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemove.BackColor = Color.FromArgb(254, 226, 226);
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnRemove.ForeColor = Color.FromArgb(220, 38, 38);
            btnRemove.Location = new Point(415, 7);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(88, 28);
            btnRemove.TabIndex = 1;
            btnRemove.Text = "🗑 Xóa món";
            btnRemove.UseVisualStyleBackColor = false;
            // 
            // lblCart
            // 
            lblCart.AutoSize = true;
            lblCart.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCart.ForeColor = Color.FromArgb(15, 23, 42);
            lblCart.Location = new Point(12, 10);
            lblCart.Name = "lblCart";
            lblCart.Size = new Size(242, 25);
            lblCart.TabIndex = 0;
            lblCart.Text = "\U0001f6d2 GIỎ HÀNG BÁN HÀNG";
            // 
            // panelPaymentWrap
            // 
            panelPaymentWrap.BackColor = Color.White;
            panelPaymentWrap.Controls.Add(btnPay);
            panelPaymentWrap.Controls.Add(lblCustomerSummary);
            panelPaymentWrap.Controls.Add(lblPointsSummary);
            panelPaymentWrap.Controls.Add(lblPointsSummaryTitle);
            panelPaymentWrap.Controls.Add(lblRedeemDiscount);
            panelPaymentWrap.Controls.Add(nudRedeemPoints);
            panelPaymentWrap.Controls.Add(lblRedeemPointsTitle);
            panelPaymentWrap.Controls.Add(lblChange);
            panelPaymentWrap.Controls.Add(lblChangeTitle);
            panelPaymentWrap.Controls.Add(txtAmountReceived);
            panelPaymentWrap.Controls.Add(lblReceived);
            panelPaymentWrap.Controls.Add(cboPaymentMethod);
            panelPaymentWrap.Controls.Add(lblMethod);
            panelPaymentWrap.Controls.Add(panelTotalBanner);
            panelPaymentWrap.Controls.Add(lblPayment);
            panelPaymentWrap.Dock = DockStyle.Bottom;
            panelPaymentWrap.Location = new Point(10, 290);
            panelPaymentWrap.Name = "panelPaymentWrap";
            panelPaymentWrap.Padding = new Padding(15, 12, 15, 12);
            panelPaymentWrap.Size = new Size(616, 334);
            panelPaymentWrap.TabIndex = 1;
            // 
            // btnPay
            // 
            btnPay.BackColor = Color.FromArgb(124, 58, 237);
            btnPay.Cursor = Cursors.Hand;
            btnPay.Dock = DockStyle.Bottom;
            btnPay.FlatAppearance.BorderSize = 0;
            btnPay.FlatStyle = FlatStyle.Flat;
            btnPay.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            btnPay.ForeColor = Color.White;
            btnPay.Location = new Point(15, 270);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(586, 52);
            btnPay.TabIndex = 11;
            btnPay.Text = "⚡ TIẾN HÀNH THANH TOÁN (F9)";
            btnPay.UseVisualStyleBackColor = false;
            // 
            // lblCustomerSummary
            // 
            lblCustomerSummary.AutoSize = true;
            lblCustomerSummary.Font = new Font("Segoe UI", 9F);
            lblCustomerSummary.ForeColor = Color.FromArgb(71, 85, 105);
            lblCustomerSummary.Location = new Point(18, 238);
            lblCustomerSummary.Name = "lblCustomerSummary";
            lblCustomerSummary.Size = new Size(189, 20);
            lblCustomerSummary.TabIndex = 10;
            lblCustomerSummary.Text = "Khách hàng: Khách vãng lai";
            // 
            // lblRedeemPointsTitle
            // 
            lblRedeemPointsTitle.AutoSize = true;
            lblRedeemPointsTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRedeemPointsTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblRedeemPointsTitle.Location = new Point(18, 206);
            lblRedeemPointsTitle.Name = "lblRedeemPointsTitle";
            lblRedeemPointsTitle.Size = new Size(130, 21);
            lblRedeemPointsTitle.TabIndex = 12;
            lblRedeemPointsTitle.Text = "Đổi điểm trừ tiền:";
            // 
            // nudRedeemPoints
            // 
            nudRedeemPoints.BorderStyle = BorderStyle.FixedSingle;
            nudRedeemPoints.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            nudRedeemPoints.Location = new Point(148, 203);
            nudRedeemPoints.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudRedeemPoints.Name = "nudRedeemPoints";
            nudRedeemPoints.Size = new Size(95, 30);
            nudRedeemPoints.TabIndex = 13;
            // 
            // lblRedeemDiscount
            // 
            lblRedeemDiscount.AutoSize = true;
            lblRedeemDiscount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRedeemDiscount.ForeColor = Color.FromArgb(220, 38, 38);
            lblRedeemDiscount.Location = new Point(250, 206);
            lblRedeemDiscount.Name = "lblRedeemDiscount";
            lblRedeemDiscount.Size = new Size(160, 21);
            lblRedeemDiscount.TabIndex = 14;
            lblRedeemDiscount.Text = "(-0 đ | 1đ = 1.000đ)";
            // 
            // lblPointsSummary
            // 
            lblPointsSummary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPointsSummary.AutoSize = true;
            lblPointsSummary.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPointsSummary.ForeColor = Color.FromArgb(220, 38, 38);
            lblPointsSummary.Location = new Point(475, 172);
            lblPointsSummary.Name = "lblPointsSummary";
            lblPointsSummary.Size = new Size(82, 25);
            lblPointsSummary.TabIndex = 9;
            lblPointsSummary.Text = "+0 điểm";
            // 
            // lblPointsSummaryTitle
            // 
            lblPointsSummaryTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPointsSummaryTitle.AutoSize = true;
            lblPointsSummaryTitle.Font = new Font("Segoe UI", 9.5F);
            lblPointsSummaryTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblPointsSummaryTitle.Location = new Point(375, 174);
            lblPointsSummaryTitle.Name = "lblPointsSummaryTitle";
            lblPointsSummaryTitle.Size = new Size(104, 21);
            lblPointsSummaryTitle.TabIndex = 8;
            lblPointsSummaryTitle.Text = "Điểm tích lũy:";
            // 
            // lblChange
            // 
            lblChange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblChange.AutoSize = true;
            lblChange.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblChange.ForeColor = Color.FromArgb(124, 58, 237);
            lblChange.Location = new Point(475, 136);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(46, 30);
            lblChange.TabIndex = 7;
            lblChange.Text = "0 đ";
            // 
            // lblChangeTitle
            // 
            lblChangeTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblChangeTitle.AutoSize = true;
            lblChangeTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblChangeTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblChangeTitle.Location = new Point(395, 140);
            lblChangeTitle.Name = "lblChangeTitle";
            lblChangeTitle.Size = new Size(87, 21);
            lblChangeTitle.TabIndex = 6;
            lblChangeTitle.Text = "Tiền thừa:";
            // 
            // txtAmountReceived
            // 
            txtAmountReceived.BorderStyle = BorderStyle.FixedSingle;
            txtAmountReceived.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtAmountReceived.Location = new Point(125, 169);
            txtAmountReceived.Name = "txtAmountReceived";
            txtAmountReceived.PlaceholderText = "Nhập tiền khách đưa...";
            txtAmountReceived.Size = new Size(190, 32);
            txtAmountReceived.TabIndex = 5;
            // 
            // lblReceived
            // 
            lblReceived.AutoSize = true;
            lblReceived.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblReceived.ForeColor = Color.FromArgb(15, 23, 42);
            lblReceived.Location = new Point(18, 172);
            lblReceived.Name = "lblReceived";
            lblReceived.Size = new Size(95, 21);
            lblReceived.TabIndex = 4;
            lblReceived.Text = "Khách đưa:";
            // 
            // cboPaymentMethod
            // 
            cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentMethod.Font = new Font("Segoe UI", 10F);
            cboPaymentMethod.FormattingEnabled = true;
            cboPaymentMethod.Items.AddRange(new object[] { "Cash", "Transfer" });
            cboPaymentMethod.Location = new Point(125, 132);
            cboPaymentMethod.Name = "cboPaymentMethod";
            cboPaymentMethod.Size = new Size(190, 31);
            cboPaymentMethod.TabIndex = 3;
            cboPaymentMethod.SelectedIndexChanged += cboPaymentMethod_SelectedIndexChanged_1;
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMethod.ForeColor = Color.FromArgb(15, 23, 42);
            lblMethod.Location = new Point(18, 135);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(114, 21);
            lblMethod.TabIndex = 2;
            lblMethod.Text = "Phương thức:";
            // 
            // panelTotalBanner
            // 
            panelTotalBanner.BackColor = Color.FromArgb(30, 27, 75);
            panelTotalBanner.Controls.Add(lblTotal);
            panelTotalBanner.Controls.Add(lblTotalTitle);
            panelTotalBanner.Dock = DockStyle.Top;
            panelTotalBanner.Location = new Point(15, 42);
            panelTotalBanner.Name = "panelTotalBanner";
            panelTotalBanner.Padding = new Padding(18, 10, 18, 10);
            panelTotalBanner.Size = new Size(586, 75);
            panelTotalBanner.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Right;
            lblTotal.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(196, 181, 253);
            lblTotal.Location = new Point(236, 10);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(332, 55);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "0 đ";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Dock = DockStyle.Left;
            lblTotalTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblTotalTitle.ForeColor = Color.White;
            lblTotalTitle.Location = new Point(18, 10);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(200, 55);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "TỔNG TIỀN PHẢI THU:";
            lblTotalTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPayment
            // 
            lblPayment.Dock = DockStyle.Top;
            lblPayment.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPayment.ForeColor = Color.FromArgb(15, 23, 42);
            lblPayment.Location = new Point(15, 12);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(586, 30);
            lblPayment.TabIndex = 0;
            lblPayment.Text = "💳 QUẦY THU NGÂN - THANH TOÁN";
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(panelProductsWrap);
            panelLeft.Controls.Add(grpCustomer);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 10);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(0, 0, 10, 0);
            panelLeft.Size = new Size(590, 624);
            panelLeft.TabIndex = 0;
            // 
            // panelProductsWrap
            // 
            panelProductsWrap.BackColor = Color.White;
            panelProductsWrap.Controls.Add(dgvProducts);
            panelProductsWrap.Controls.Add(panelProductsHeader);
            panelProductsWrap.Dock = DockStyle.Fill;
            panelProductsWrap.Location = new Point(0, 0);
            panelProductsWrap.Name = "panelProductsWrap";
            panelProductsWrap.Size = new Size(580, 360);
            panelProductsWrap.TabIndex = 0;
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
            dgvProducts.Location = new Point(0, 42);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(580, 318);
            dgvProducts.TabIndex = 1;
            // 
            // panelProductsHeader
            // 
            panelProductsHeader.BackColor = Color.FromArgb(248, 250, 252);
            panelProductsHeader.Controls.Add(lblProductsHeader);
            panelProductsHeader.Dock = DockStyle.Top;
            panelProductsHeader.Location = new Point(0, 0);
            panelProductsHeader.Name = "panelProductsHeader";
            panelProductsHeader.Size = new Size(580, 42);
            panelProductsHeader.TabIndex = 0;
            // 
            // lblProductsHeader
            // 
            lblProductsHeader.AutoSize = true;
            lblProductsHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblProductsHeader.ForeColor = Color.FromArgb(15, 23, 42);
            lblProductsHeader.Location = new Point(12, 10);
            lblProductsHeader.Name = "lblProductsHeader";
            lblProductsHeader.Size = new Size(436, 25);
            lblProductsHeader.TabIndex = 0;
            lblProductsHeader.Text = "📦 DANH MỤC SẢN PHẨM (Nhấn đúp để chọn)";
            // 
            // grpCustomer
            // 
            grpCustomer.BackColor = Color.White;
            grpCustomer.Controls.Add(btnSelectGuest);
            grpCustomer.Controls.Add(lblCustStatus);
            grpCustomer.Controls.Add(lblCustEarn);
            grpCustomer.Controls.Add(lblCustEarnTitle);
            grpCustomer.Controls.Add(lblCustPoints);
            grpCustomer.Controls.Add(lblCustPointsTitle);
            grpCustomer.Controls.Add(lblCustRank);
            grpCustomer.Controls.Add(lblCustRankTitle);
            grpCustomer.Controls.Add(lblCustName);
            grpCustomer.Controls.Add(lblCustNameTitle);
            grpCustomer.Controls.Add(btnCustClear);
            grpCustomer.Controls.Add(btnCustAdd);
            grpCustomer.Controls.Add(btnCustSearch);
            grpCustomer.Controls.Add(txtCustPhone);
            grpCustomer.Controls.Add(lblCustPhone);
            grpCustomer.Dock = DockStyle.Bottom;
            grpCustomer.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            grpCustomer.ForeColor = Color.FromArgb(15, 23, 42);
            grpCustomer.Location = new Point(0, 360);
            grpCustomer.Name = "grpCustomer";
            grpCustomer.Padding = new Padding(15, 10, 15, 10);
            grpCustomer.Size = new Size(580, 264);
            grpCustomer.TabIndex = 1;
            grpCustomer.TabStop = false;
            grpCustomer.Text = "💎 KHÁCH HÀNG & TÍCH ĐIỂM HỘI VIÊN";
            // 
            // btnSelectGuest
            // 
            btnSelectGuest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSelectGuest.BackColor = Color.FromArgb(241, 245, 249);
            btnSelectGuest.Cursor = Cursors.Hand;
            btnSelectGuest.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnSelectGuest.FlatStyle = FlatStyle.Flat;
            btnSelectGuest.Font = new Font("Segoe UI", 8.5F);
            btnSelectGuest.ForeColor = Color.FromArgb(71, 85, 105);
            btnSelectGuest.Location = new Point(15, 222);
            btnSelectGuest.Name = "btnSelectGuest";
            btnSelectGuest.Size = new Size(130, 28);
            btnSelectGuest.TabIndex = 14;
            btnSelectGuest.Text = "👤 Khách vãng lai";
            btnSelectGuest.UseVisualStyleBackColor = false;
            // 
            // lblCustStatus
            // 
            lblCustStatus.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblCustStatus.ForeColor = Color.FromArgb(100, 116, 139);
            lblCustStatus.Location = new Point(15, 185);
            lblCustStatus.Name = "lblCustStatus";
            lblCustStatus.Size = new Size(550, 30);
            lblCustStatus.TabIndex = 13;
            lblCustStatus.Text = "Nhập SĐT khách hàng rồi bấm [Tra cứu] hoặc Enter để tự động tích điểm hóa đơn.";
            // 
            // lblCustEarn
            // 
            lblCustEarn.AutoSize = true;
            lblCustEarn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustEarn.ForeColor = Color.FromArgb(220, 38, 38);
            lblCustEarn.Location = new Point(165, 148);
            lblCustEarn.Name = "lblCustEarn";
            lblCustEarn.Size = new Size(287, 23);
            lblCustEarn.TabIndex = 12;
            lblCustEarn.Text = "+0 điểm (Tỷ lệ: 10.000đ = 1 điểm)";
            // 
            // lblCustEarnTitle
            // 
            lblCustEarnTitle.AutoSize = true;
            lblCustEarnTitle.Font = new Font("Segoe UI", 9.5F);
            lblCustEarnTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblCustEarnTitle.Location = new Point(15, 150);
            lblCustEarnTitle.Name = "lblCustEarnTitle";
            lblCustEarnTitle.Size = new Size(157, 21);
            lblCustEarnTitle.TabIndex = 11;
            lblCustEarnTitle.Text = "Tích lũy hóa đơn này:";
            // 
            // lblCustPoints
            // 
            lblCustPoints.AutoSize = true;
            lblCustPoints.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustPoints.ForeColor = Color.FromArgb(124, 58, 237);
            lblCustPoints.Location = new Point(380, 110);
            lblCustPoints.Name = "lblCustPoints";
            lblCustPoints.Size = new Size(66, 23);
            lblCustPoints.TabIndex = 10;
            lblCustPoints.Text = "0 điểm";
            // 
            // lblCustPointsTitle
            // 
            lblCustPointsTitle.AutoSize = true;
            lblCustPointsTitle.Font = new Font("Segoe UI", 9.5F);
            lblCustPointsTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblCustPointsTitle.Location = new Point(280, 112);
            lblCustPointsTitle.Name = "lblCustPointsTitle";
            lblCustPointsTitle.Size = new Size(104, 21);
            lblCustPointsTitle.TabIndex = 9;
            lblCustPointsTitle.Text = "Điểm hiện có:";
            // 
            // lblCustRank
            // 
            lblCustRank.AutoSize = true;
            lblCustRank.BackColor = Color.FromArgb(241, 245, 249);
            lblCustRank.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustRank.ForeColor = Color.FromArgb(124, 58, 237);
            lblCustRank.Location = new Point(115, 110);
            lblCustRank.Name = "lblCustRank";
            lblCustRank.Padding = new Padding(6, 2, 6, 2);
            lblCustRank.Size = new Size(27, 24);
            lblCustRank.TabIndex = 8;
            lblCustRank.Text = "-";
            // 
            // lblCustRankTitle
            // 
            lblCustRankTitle.AutoSize = true;
            lblCustRankTitle.Font = new Font("Segoe UI", 9.5F);
            lblCustRankTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblCustRankTitle.Location = new Point(15, 112);
            lblCustRankTitle.Name = "lblCustRankTitle";
            lblCustRankTitle.Size = new Size(76, 21);
            lblCustRankTitle.TabIndex = 7;
            lblCustRankTitle.Text = "Hạng thẻ:";
            // 
            // lblCustName
            // 
            lblCustName.AutoSize = true;
            lblCustName.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblCustName.ForeColor = Color.FromArgb(37, 99, 235);
            lblCustName.Location = new Point(115, 73);
            lblCustName.Name = "lblCustName";
            lblCustName.Size = new Size(137, 25);
            lblCustName.TabIndex = 6;
            lblCustName.Text = "Khách vãng lai";
            // 
            // lblCustNameTitle
            // 
            lblCustNameTitle.AutoSize = true;
            lblCustNameTitle.Font = new Font("Segoe UI", 9.5F);
            lblCustNameTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblCustNameTitle.Location = new Point(15, 75);
            lblCustNameTitle.Name = "lblCustNameTitle";
            lblCustNameTitle.Size = new Size(94, 21);
            lblCustNameTitle.TabIndex = 5;
            lblCustNameTitle.Text = "Khách hàng:";
            // 
            // btnCustClear
            // 
            btnCustClear.BackColor = Color.FromArgb(254, 242, 242);
            btnCustClear.Cursor = Cursors.Hand;
            btnCustClear.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnCustClear.FlatStyle = FlatStyle.Flat;
            btnCustClear.Font = new Font("Segoe UI", 8.5F);
            btnCustClear.ForeColor = Color.FromArgb(185, 28, 28);
            btnCustClear.Location = new Point(475, 27);
            btnCustClear.Name = "btnCustClear";
            btnCustClear.Size = new Size(58, 28);
            btnCustClear.TabIndex = 4;
            btnCustClear.Text = "Hủy";
            btnCustClear.UseVisualStyleBackColor = false;
            // 
            // btnCustAdd
            // 
            btnCustAdd.BackColor = Color.FromArgb(245, 243, 255);
            btnCustAdd.Cursor = Cursors.Hand;
            btnCustAdd.FlatAppearance.BorderColor = Color.FromArgb(196, 181, 253);
            btnCustAdd.FlatStyle = FlatStyle.Flat;
            btnCustAdd.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnCustAdd.ForeColor = Color.FromArgb(124, 58, 237);
            btnCustAdd.Location = new Point(395, 27);
            btnCustAdd.Name = "btnCustAdd";
            btnCustAdd.Size = new Size(72, 28);
            btnCustAdd.TabIndex = 3;
            btnCustAdd.Text = "+ Mới";
            btnCustAdd.UseVisualStyleBackColor = false;
            // 
            // btnCustSearch
            // 
            btnCustSearch.BackColor = Color.FromArgb(37, 99, 235);
            btnCustSearch.Cursor = Cursors.Hand;
            btnCustSearch.FlatAppearance.BorderSize = 0;
            btnCustSearch.FlatStyle = FlatStyle.Flat;
            btnCustSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCustSearch.ForeColor = Color.White;
            btnCustSearch.Location = new Point(305, 27);
            btnCustSearch.Name = "btnCustSearch";
            btnCustSearch.Size = new Size(82, 28);
            btnCustSearch.TabIndex = 2;
            btnCustSearch.Text = "Tra cứu";
            btnCustSearch.UseVisualStyleBackColor = false;
            // 
            // txtCustPhone
            // 
            txtCustPhone.BorderStyle = BorderStyle.FixedSingle;
            txtCustPhone.Font = new Font("Segoe UI", 10.5F);
            txtCustPhone.Location = new Point(115, 28);
            txtCustPhone.Name = "txtCustPhone";
            txtCustPhone.PlaceholderText = "Nhập SĐT hội viên...";
            txtCustPhone.Size = new Size(180, 31);
            txtCustPhone.TabIndex = 1;
            // 
            // lblCustPhone
            // 
            lblCustPhone.AutoSize = true;
            lblCustPhone.Font = new Font("Segoe UI", 9.5F);
            lblCustPhone.ForeColor = Color.FromArgb(71, 85, 105);
            lblCustPhone.Location = new Point(15, 33);
            lblCustPhone.Name = "lblCustPhone";
            lblCustPhone.Size = new Size(104, 21);
            lblCustPhone.TabIndex = 0;
            lblCustPhone.Text = "Số điện thoại:";
            // 
            // FormPOS
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1240, 720);
            Controls.Add(panelBody);
            Controls.Add(panelTopBar);
            Font = new Font("Segoe UI", 10F);
            Name = "FormPOS";
            Padding = new Padding(12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "POS - Bán hàng & Tích điểm hội viên";
            panelTopBar.ResumeLayout(false);
            panelTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            panelBody.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            panelCartWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            panelCartHeader.ResumeLayout(false);
            panelCartHeader.PerformLayout();
            panelPaymentWrap.ResumeLayout(false);
            panelPaymentWrap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRedeemPoints).EndInit();
            panelTotalBanner.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelProductsWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panelProductsHeader.ResumeLayout(false);
            panelProductsHeader.PerformLayout();
            grpCustomer.ResumeLayout(false);
            grpCustomer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Label lblBarcodeBadge;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelProductsWrap;
        private System.Windows.Forms.Panel panelProductsHeader;
        private System.Windows.Forms.Label lblProductsHeader;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.Label lblCustPhone;
        private System.Windows.Forms.TextBox txtCustPhone;
        private System.Windows.Forms.Button btnCustSearch;
        private System.Windows.Forms.Button btnCustAdd;
        private System.Windows.Forms.Button btnCustClear;
        private System.Windows.Forms.Label lblCustNameTitle;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.Label lblCustRankTitle;
        private System.Windows.Forms.Label lblCustRank;
        private System.Windows.Forms.Label lblCustPointsTitle;
        private System.Windows.Forms.Label lblCustPoints;
        private System.Windows.Forms.Label lblCustEarnTitle;
        private System.Windows.Forms.Label lblCustEarn;
        private System.Windows.Forms.Label lblCustStatus;
        private System.Windows.Forms.Button btnSelectGuest;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelCartWrap;
        private System.Windows.Forms.Panel panelCartHeader;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;
        private System.Windows.Forms.Panel panelPaymentWrap;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Panel panelTotalBanner;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label lblReceived;
        private System.Windows.Forms.TextBox txtAmountReceived;
        private System.Windows.Forms.Label lblChangeTitle;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label lblPointsSummaryTitle;
        private System.Windows.Forms.Label lblPointsSummary;
        private System.Windows.Forms.Label lblRedeemPointsTitle;
        private System.Windows.Forms.NumericUpDown nudRedeemPoints;
        private System.Windows.Forms.Label lblRedeemDiscount;
        private System.Windows.Forms.Label lblCustomerSummary;
        private System.Windows.Forms.Button btnPay;
    }
}