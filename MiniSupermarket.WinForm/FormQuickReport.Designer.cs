using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MiniSupermarket.WinForms
{
    partial class FormQuickReport
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
            ChartArea chartArea1 = new ChartArea();
            Series series1 = new Series();
            Title title1 = new Title();

            panelHeader = new Panel();
            btnRunReport = new Button();
            btnAllOrders = new Button();
            dtpToDate = new DateTimePicker();
            lblToDate = new Label();
            dtpReportDate = new DateTimePicker();
            lblSelectDate = new Label();
            lblReportHeader = new Label();

            panelSummary = new TableLayoutPanel();
            cardRevenue = new Panel();
            lblRevenueIcon = new Label();
            lblRevenueTitle = new Label();
            lblTotalRevenue = new Label();

            cardOrders = new Panel();
            lblOrdersIcon = new Label();
            lblOrdersTitle = new Label();
            lblTotalOrders = new Label();

            cardCustomers = new Panel();
            lblCustomersIcon = new Label();
            lblCustomersTitle = new Label();
            lblTotalCustomers = new Label();

            cardLowStock = new Panel();
            lblLowStockIcon = new Label();
            lblLowStockTitle = new Label();
            lblLowStock = new Label();

            panelContent = new Panel();
            tabReports = new TabControl();
            tabOrders = new TabPage();
            dgvOrders = new DataGridView();
            tabChart = new TabPage();
            chartRevenue = new Chart();

            panelGridActions = new Panel();
            btnExportReport = new Button();
            btnCancelOrder = new Button();
            btnViewOrderDetail = new Button();
            btnRefresh = new Button();
            lblGridTitle = new Label();

            panelHeader.SuspendLayout();
            panelSummary.SuspendLayout();
            cardRevenue.SuspendLayout();
            cardOrders.SuspendLayout();
            cardCustomers.SuspendLayout();
            cardLowStock.SuspendLayout();
            panelContent.SuspendLayout();
            tabReports.SuspendLayout();
            tabOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            tabChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).BeginInit();
            panelGridActions.SuspendLayout();
            SuspendLayout();

            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(btnRunReport);
            panelHeader.Controls.Add(btnAllOrders);
            panelHeader.Controls.Add(dtpToDate);
            panelHeader.Controls.Add(lblToDate);
            panelHeader.Controls.Add(dtpReportDate);
            panelHeader.Controls.Add(lblSelectDate);
            panelHeader.Controls.Add(lblReportHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(12, 12);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(15, 12, 15, 12);
            panelHeader.Size = new Size(1256, 64);
            panelHeader.TabIndex = 0;

            // 
            // btnRunReport
            // 
            btnRunReport.BackColor = Color.FromArgb(124, 58, 237);
            btnRunReport.Cursor = Cursors.Hand;
            btnRunReport.FlatAppearance.BorderSize = 0;
            btnRunReport.FlatStyle = FlatStyle.Flat;
            btnRunReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRunReport.ForeColor = Color.White;
            btnRunReport.Location = new Point(780, 14);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new Size(160, 36);
            btnRunReport.TabIndex = 5;
            btnRunReport.Text = "📊 Xem Báo Cáo";
            btnRunReport.UseVisualStyleBackColor = false;

            // 
            // 
            // btnAllOrders
            // 
            btnAllOrders.BackColor = Color.FromArgb(71, 85, 105);
            btnAllOrders.Cursor = Cursors.Hand;
            btnAllOrders.FlatAppearance.BorderSize = 0;
            btnAllOrders.FlatStyle = FlatStyle.Flat;
            btnAllOrders.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAllOrders.ForeColor = Color.White;
            btnAllOrders.Location = new Point(950, 14);
            btnAllOrders.Name = "btnAllOrders";
            btnAllOrders.Size = new Size(110, 36);
            btnAllOrders.TabIndex = 6;
            btnAllOrders.Text = "🌐 Tất Cả";
            btnAllOrders.UseVisualStyleBackColor = false;

            // dtpToDate
            // 
            dtpToDate.CustomFormat = "dd/MM/yyyy";
            dtpToDate.Font = new Font("Segoe UI", 10F);
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.Location = new Point(625, 18);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(140, 29);
            dtpToDate.TabIndex = 4;

            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblToDate.ForeColor = Color.FromArgb(71, 85, 105);
            lblToDate.Location = new Point(545, 22);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(74, 17);
            lblToDate.TabIndex = 3;
            lblToDate.Text = "Đến ngày:";

            // 
            // dtpReportDate
            // 
            dtpReportDate.CustomFormat = "dd/MM/yyyy";
            dtpReportDate.Font = new Font("Segoe UI", 10F);
            dtpReportDate.Format = DateTimePickerFormat.Custom;
            dtpReportDate.Location = new Point(395, 18);
            dtpReportDate.Name = "dtpReportDate";
            dtpReportDate.Size = new Size(140, 29);
            dtpReportDate.TabIndex = 2;

            // 
            // lblSelectDate
            // 
            lblSelectDate.AutoSize = true;
            lblSelectDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSelectDate.ForeColor = Color.FromArgb(71, 85, 105);
            lblSelectDate.Location = new Point(325, 22);
            lblSelectDate.Name = "lblSelectDate";
            lblSelectDate.Size = new Size(66, 17);
            lblSelectDate.TabIndex = 1;
            lblSelectDate.Text = "Từ ngày:";

            // 
            // lblReportHeader
            // 
            lblReportHeader.AutoSize = true;
            lblReportHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblReportHeader.ForeColor = Color.FromArgb(15, 23, 42);
            lblReportHeader.Location = new Point(15, 20);
            lblReportHeader.Name = "lblReportHeader";
            lblReportHeader.Size = new Size(290, 21);
            lblReportHeader.TabIndex = 0;
            lblReportHeader.Text = "📈 BÁO CÁO DOANH THU & DASHBOARD";

            // 
            // panelSummary (4 THẺ KPI DASHBOARD - TIÊU CHÍ 44)
            // 
            panelSummary.ColumnCount = 4;
            panelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelSummary.Controls.Add(cardRevenue, 0, 0);
            panelSummary.Controls.Add(cardOrders, 1, 0);
            panelSummary.Controls.Add(cardCustomers, 2, 0);
            panelSummary.Controls.Add(cardLowStock, 3, 0);
            panelSummary.Dock = DockStyle.Top;
            panelSummary.Location = new Point(12, 86);
            panelSummary.Name = "panelSummary";
            panelSummary.RowCount = 1;
            panelSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelSummary.Size = new Size(1256, 125);
            panelSummary.TabIndex = 1;

            // 
            // cardRevenue (Thẻ 1: Doanh thu hôm nay)
            // 
            cardRevenue.BackColor = Color.FromArgb(124, 58, 237);
            cardRevenue.Controls.Add(lblRevenueIcon);
            cardRevenue.Controls.Add(lblRevenueTitle);
            cardRevenue.Controls.Add(lblTotalRevenue);
            cardRevenue.Dock = DockStyle.Fill;
            cardRevenue.Location = new Point(0, 0);
            cardRevenue.Margin = new Padding(0, 0, 8, 0);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Padding = new Padding(16);
            cardRevenue.Size = new Size(306, 125);
            cardRevenue.TabIndex = 0;

            // 
            // lblRevenueIcon
            // 
            lblRevenueIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRevenueIcon.AutoSize = true;
            lblRevenueIcon.Font = new Font("Segoe UI", 26F);
            lblRevenueIcon.ForeColor = Color.FromArgb(221, 214, 254);
            lblRevenueIcon.Location = new Point(245, 12);
            lblRevenueIcon.Name = "lblRevenueIcon";
            lblRevenueIcon.Size = new Size(61, 47);
            lblRevenueIcon.TabIndex = 2;
            lblRevenueIcon.Text = "💰";

            // 
            // lblRevenueTitle
            // 
            lblRevenueTitle.AutoSize = true;
            lblRevenueTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRevenueTitle.ForeColor = Color.FromArgb(237, 233, 254);
            lblRevenueTitle.Location = new Point(14, 16);
            lblRevenueTitle.Name = "lblRevenueTitle";
            lblRevenueTitle.Size = new Size(137, 15);
            lblRevenueTitle.TabIndex = 0;
            lblRevenueTitle.Text = "DOANH THU HÔM NAY";

            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalRevenue.ForeColor = Color.White;
            lblTotalRevenue.Location = new Point(12, 52);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(62, 37);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "0 đ";

            // 
            // cardOrders (Thẻ 2: Tổng số hóa đơn)
            // 
            cardOrders.BackColor = Color.FromArgb(37, 99, 235);
            cardOrders.Controls.Add(lblOrdersIcon);
            cardOrders.Controls.Add(lblOrdersTitle);
            cardOrders.Controls.Add(lblTotalOrders);
            cardOrders.Dock = DockStyle.Fill;
            cardOrders.Location = new Point(314, 0);
            cardOrders.Margin = new Padding(0, 0, 8, 0);
            cardOrders.Name = "cardOrders";
            cardOrders.Padding = new Padding(16);
            cardOrders.Size = new Size(306, 125);
            cardOrders.TabIndex = 1;

            // 
            // lblOrdersIcon
            // 
            lblOrdersIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOrdersIcon.AutoSize = true;
            lblOrdersIcon.Font = new Font("Segoe UI", 26F);
            lblOrdersIcon.ForeColor = Color.FromArgb(191, 219, 254);
            lblOrdersIcon.Location = new Point(245, 12);
            lblOrdersIcon.Name = "lblOrdersIcon";
            lblOrdersIcon.Size = new Size(61, 47);
            lblOrdersIcon.TabIndex = 2;
            lblOrdersIcon.Text = "🧾";

            // 
            // lblOrdersTitle
            // 
            lblOrdersTitle.AutoSize = true;
            lblOrdersTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOrdersTitle.ForeColor = Color.FromArgb(219, 234, 254);
            lblOrdersTitle.Location = new Point(14, 16);
            lblOrdersTitle.Name = "lblOrdersTitle";
            lblOrdersTitle.Size = new Size(125, 15);
            lblOrdersTitle.TabIndex = 0;
            lblOrdersTitle.Text = "TỔNG SỐ HÓA ĐƠN";

            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalOrders.ForeColor = Color.White;
            lblTotalOrders.Location = new Point(12, 52);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(95, 37);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "0 đơn";

            // 
            // cardCustomers (Thẻ 3: Khách hàng thành viên)
            // 
            cardCustomers.BackColor = Color.FromArgb(99, 102, 241);
            cardCustomers.Controls.Add(lblCustomersIcon);
            cardCustomers.Controls.Add(lblCustomersTitle);
            cardCustomers.Controls.Add(lblTotalCustomers);
            cardCustomers.Dock = DockStyle.Fill;
            cardCustomers.Location = new Point(628, 0);
            cardCustomers.Margin = new Padding(0, 0, 8, 0);
            cardCustomers.Name = "cardCustomers";
            cardCustomers.Padding = new Padding(16);
            cardCustomers.Size = new Size(306, 125);
            cardCustomers.TabIndex = 2;

            // 
            // lblCustomersIcon
            // 
            lblCustomersIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCustomersIcon.AutoSize = true;
            lblCustomersIcon.Font = new Font("Segoe UI", 26F);
            lblCustomersIcon.ForeColor = Color.FromArgb(224, 231, 255);
            lblCustomersIcon.Location = new Point(245, 12);
            lblCustomersIcon.Name = "lblCustomersIcon";
            lblCustomersIcon.Size = new Size(61, 47);
            lblCustomersIcon.TabIndex = 2;
            lblCustomersIcon.Text = "👥";

            // 
            // lblCustomersTitle
            // 
            lblCustomersTitle.AutoSize = true;
            lblCustomersTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomersTitle.ForeColor = Color.FromArgb(224, 231, 255);
            lblCustomersTitle.Location = new Point(14, 16);
            lblCustomersTitle.Name = "lblCustomersTitle";
            lblCustomersTitle.Size = new Size(160, 15);
            lblCustomersTitle.TabIndex = 0;
            lblCustomersTitle.Text = "KHÁCH HÀNG THÀNH VIÊN";

            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalCustomers.ForeColor = Color.White;
            lblTotalCustomers.Location = new Point(12, 52);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(111, 37);
            lblTotalCustomers.TabIndex = 1;
            lblTotalCustomers.Text = "0 khách";

            // 
            // cardLowStock (Thẻ 4: Cảnh báo tồn kho <= 10)
            // 
            cardLowStock.BackColor = Color.FromArgb(220, 38, 38);
            cardLowStock.Controls.Add(lblLowStockIcon);
            cardLowStock.Controls.Add(lblLowStockTitle);
            cardLowStock.Controls.Add(lblLowStock);
            cardLowStock.Dock = DockStyle.Fill;
            cardLowStock.Location = new Point(942, 0);
            cardLowStock.Margin = new Padding(0);
            cardLowStock.Name = "cardLowStock";
            cardLowStock.Padding = new Padding(16);
            cardLowStock.Size = new Size(314, 125);
            cardLowStock.TabIndex = 3;

            // 
            // lblLowStockIcon
            // 
            lblLowStockIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLowStockIcon.AutoSize = true;
            lblLowStockIcon.Font = new Font("Segoe UI", 26F);
            lblLowStockIcon.ForeColor = Color.FromArgb(254, 202, 202);
            lblLowStockIcon.Location = new Point(255, 12);
            lblLowStockIcon.Name = "lblLowStockIcon";
            lblLowStockIcon.Size = new Size(61, 47);
            lblLowStockIcon.TabIndex = 2;
            lblLowStockIcon.Text = "⚠️";

            // 
            // lblLowStockTitle
            // 
            lblLowStockTitle.AutoSize = true;
            lblLowStockTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLowStockTitle.ForeColor = Color.FromArgb(254, 226, 226);
            lblLowStockTitle.Location = new Point(14, 16);
            lblLowStockTitle.Name = "lblLowStockTitle";
            lblLowStockTitle.Size = new Size(170, 15);
            lblLowStockTitle.TabIndex = 0;
            lblLowStockTitle.Text = "CẢNH BÁO TỒN KHO (<=10)";

            // 
            // lblLowStock
            // 
            lblLowStock.AutoSize = true;
            lblLowStock.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblLowStock.ForeColor = Color.White;
            lblLowStock.Location = new Point(12, 52);
            lblLowStock.Name = "lblLowStock";
            lblLowStock.Size = new Size(125, 37);
            lblLowStock.TabIndex = 1;
            lblLowStock.Text = "0 sp yếu";

            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(tabReports);
            panelContent.Controls.Add(panelGridActions);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(12, 221);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(18, 12, 18, 16);
            panelContent.Size = new Size(1256, 455);
            panelContent.TabIndex = 2;

            // 
            // panelGridActions
            // 
            panelGridActions.Controls.Add(btnExportReport);
            panelGridActions.Controls.Add(btnCancelOrder);
            panelGridActions.Controls.Add(btnViewOrderDetail);
            panelGridActions.Controls.Add(btnRefresh);
            panelGridActions.Controls.Add(lblGridTitle);
            panelGridActions.Dock = DockStyle.Top;
            panelGridActions.Location = new Point(18, 12);
            panelGridActions.Name = "panelGridActions";
            panelGridActions.Size = new Size(1220, 42);
            panelGridActions.TabIndex = 0;

            // 
            // lblGridTitle
            // 
            lblGridTitle.Dock = DockStyle.Left;
            lblGridTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGridTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblGridTitle.Location = new Point(0, 0);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Size = new Size(420, 42);
            lblGridTitle.TabIndex = 0;
            lblGridTitle.Text = "📋 CHI TIẾT HÓA ĐƠN & BIỂU ĐỒ BÁN HÀNG";
            lblGridTitle.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // btnExportReport (TIÊU CHÍ 48: XUẤT CSV/EXCEL UTF-8 WITH BOM)
            // 
            btnExportReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportReport.BackColor = Color.FromArgb(16, 185, 129);
            btnExportReport.Cursor = Cursors.Hand;
            btnExportReport.FlatAppearance.BorderSize = 0;
            btnExportReport.FlatStyle = FlatStyle.Flat;
            btnExportReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExportReport.ForeColor = Color.White;
            btnExportReport.Location = new Point(570, 4);
            btnExportReport.Name = "btnExportReport";
            btnExportReport.Size = new Size(155, 34);
            btnExportReport.TabIndex = 4;
            btnExportReport.Text = "📊 Xuất Excel/CSV";
            btnExportReport.UseVisualStyleBackColor = false;

            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(241, 245, 249);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(71, 85, 105);
            btnRefresh.Location = new Point(735, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(105, 34);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "🔄 Tải lại";
            btnRefresh.UseVisualStyleBackColor = false;

            // 
            // btnViewOrderDetail
            // 
            btnViewOrderDetail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewOrderDetail.BackColor = Color.FromArgb(37, 99, 235);
            btnViewOrderDetail.Cursor = Cursors.Hand;
            btnViewOrderDetail.FlatAppearance.BorderSize = 0;
            btnViewOrderDetail.FlatStyle = FlatStyle.Flat;
            btnViewOrderDetail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnViewOrderDetail.ForeColor = Color.White;
            btnViewOrderDetail.Location = new Point(850, 4);
            btnViewOrderDetail.Name = "btnViewOrderDetail";
            btnViewOrderDetail.Size = new Size(160, 34);
            btnViewOrderDetail.TabIndex = 2;
            btnViewOrderDetail.Text = "🔍 Xem Chi Tiết";
            btnViewOrderDetail.UseVisualStyleBackColor = false;

            // 
            // btnCancelOrder
            // 
            btnCancelOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelOrder.BackColor = Color.FromArgb(220, 38, 38);
            btnCancelOrder.Cursor = Cursors.Hand;
            btnCancelOrder.FlatAppearance.BorderSize = 0;
            btnCancelOrder.FlatStyle = FlatStyle.Flat;
            btnCancelOrder.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancelOrder.ForeColor = Color.White;
            btnCancelOrder.Location = new Point(1020, 4);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(160, 34);
            btnCancelOrder.TabIndex = 3;
            btnCancelOrder.Text = "❌ Hủy Đơn Hàng";
            btnCancelOrder.UseVisualStyleBackColor = false;

            // 
            // tabReports
            // 
            tabReports.Controls.Add(tabOrders);
            tabReports.Controls.Add(tabChart);
            tabReports.Dock = DockStyle.Fill;
            tabReports.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabReports.Location = new Point(18, 54);
            tabReports.Name = "tabReports";
            tabReports.SelectedIndex = 0;
            tabReports.Size = new Size(1220, 385);
            tabReports.TabIndex = 1;

            // 
            // tabOrders
            // 
            tabOrders.Controls.Add(dgvOrders);
            tabOrders.Location = new Point(4, 30);
            tabOrders.Name = "tabOrders";
            tabOrders.Padding = new Padding(3);
            tabOrders.Size = new Size(1212, 351);
            tabOrders.TabIndex = 0;
            tabOrders.Text = "📋 Danh Sách Đơn Hàng";
            tabOrders.UseVisualStyleBackColor = true;

            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.BorderStyle = BorderStyle.None;
            dgvOrders.ColumnHeadersHeight = 38;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.Location = new Point(3, 3);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowTemplate.Height = 34;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(1206, 345);
            dgvOrders.TabIndex = 0;

            // 
            // tabChart (TIÊU CHÍ 45: BIỂU ĐỒ DOANH THU THEO NGÀY - COLUMN CHART)
            // 
            tabChart.Controls.Add(chartRevenue);
            tabChart.Location = new Point(4, 30);
            tabChart.Name = "tabChart";
            tabChart.Padding = new Padding(8);
            tabChart.Size = new Size(1212, 351);
            tabChart.TabIndex = 1;
            tabChart.Text = "📊 Biểu Đồ Cột Doanh Thu";
            tabChart.UseVisualStyleBackColor = true;

            // 
            // chartRevenue
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);
            chartArea1.AxisX.MajorGrid.LineColor = Color.FromArgb(241, 245, 249);
            chartArea1.AxisX.Title = "Ngày";
            chartArea1.AxisX.TitleFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            chartArea1.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
            chartArea1.AxisY.MajorGrid.LineColor = Color.FromArgb(241, 245, 249);
            chartArea1.AxisY.Title = "Doanh thu (VNĐ)";
            chartArea1.AxisY.TitleFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            chartArea1.BackColor = Color.White;
            chartArea1.Name = "ChartArea1";
            chartRevenue.ChartAreas.Add(chartArea1);
            chartRevenue.Dock = DockStyle.Fill;
            chartRevenue.Location = new Point(8, 8);
            chartRevenue.Name = "chartRevenue";

            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Column;
            series1.Color = Color.FromArgb(124, 58, 237);
            series1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "{0:N0} đ";
            series1.Name = "DoanhThu";
            chartRevenue.Series.Add(series1);

            title1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            title1.ForeColor = Color.FromArgb(15, 23, 42);
            title1.Name = "Title1";
            title1.Text = "BIỂU ĐỒ DOANH THU THEO THỜI GIAN (GROUP BY NGÀY)";
            chartRevenue.Titles.Add(title1);

            chartRevenue.Size = new Size(1196, 335);
            chartRevenue.TabIndex = 0;

            // 
            // FormQuickReport
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1280, 688);
            Controls.Add(panelContent);
            Controls.Add(panelSummary);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9.75F);
            Name = "FormQuickReport";
            Padding = new Padding(12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard Báo Cáo Doanh Thu & Hiệu Suất";

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSummary.ResumeLayout(false);
            cardRevenue.ResumeLayout(false);
            cardRevenue.PerformLayout();
            cardOrders.ResumeLayout(false);
            cardOrders.PerformLayout();
            cardCustomers.ResumeLayout(false);
            cardCustomers.PerformLayout();
            cardLowStock.ResumeLayout(false);
            cardLowStock.PerformLayout();
            panelContent.ResumeLayout(false);
            panelGridActions.ResumeLayout(false);
            tabReports.ResumeLayout(false);
            tabOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            tabChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartRevenue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblReportHeader;
        private Label lblSelectDate;
        private DateTimePicker dtpReportDate;
        private Label lblToDate;
        private DateTimePicker dtpToDate;
        private Button btnRunReport;
        private Button btnAllOrders;

        private TableLayoutPanel panelSummary;
        private Panel cardRevenue;
        private Label lblRevenueTitle;
        private Label lblTotalRevenue;
        private Label lblRevenueIcon;

        private Panel cardOrders;
        private Label lblOrdersTitle;
        private Label lblTotalOrders;
        private Label lblOrdersIcon;

        private Panel cardCustomers;
        private Label lblCustomersTitle;
        private Label lblTotalCustomers;
        private Label lblCustomersIcon;

        private Panel cardLowStock;
        private Label lblLowStockTitle;
        private Label lblLowStock;
        private Label lblLowStockIcon;

        private Panel panelContent;
        private Panel panelGridActions;
        private Label lblGridTitle;
        private Button btnExportReport;
        private Button btnCancelOrder;
        private Button btnViewOrderDetail;
        private Button btnRefresh;

        private TabControl tabReports;
        private TabPage tabOrders;
        private DataGridView dgvOrders;
        private TabPage tabChart;
        private Chart chartRevenue;
    }
}
