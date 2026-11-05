using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToCoBaStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RewardPoints = table.Column<int>(type: "int", nullable: false),
                    MembershipRank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountReceived = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChangeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Gia vị bếp nhà", "Nước mắm, đường cát, bột ngọt, hạt nêm gia vị truyền thống" },
                    { 2, "Gạo tấm & Ngũ cốc bao", "Gạo tấm thơm Sài Gòn, nếp cái hoa vàng, các loại đậu hạt" },
                    { 3, "Mì gói & Miến bún khô", "Mì tôm Miliket, Hảo Hảo, phở khô, miến dong ăn liền" },
                    { 4, "Bánh kẹo tuổi thơ", "Bánh quy bơ, kẹo dừa, bánh men, kẹo mè xửng, kẹo lạc" },
                    { 5, "Nước ngọt & Bia chai giải khát", "Xá xị Chương Dương, nước ngọt có ga, bia lon Sài Gòn ướp lạnh" },
                    { 6, "Sữa đặc & Cà phê phin", "Sữa đặc Ông Thọ, cà phê nguyên chất pha phin vợt Sài Gòn" },
                    { 7, "Đồ hộp & Thực phẩm chế biến", "Cá hộp Ba Cô Gái, pate thịt nguội, xúc xích tiệt trùng" },
                    { 8, "Chăm sóc giặt xả vải vóc", "Bột giặt Viso, nước giặt xả Comfort thơm hương ban mai" },
                    { 9, "Tẩy rửa & Vệ sinh nhà cửa", "Nước rửa chén Mỹ Hảo, nước lau sàn, chổi cước, cọ chùi xoong" },
                    { 10, "Vệ sinh cá nhân gia đình", "Xà bông Cô Ba, kem đánh răng Dạ Lan, dầu gội gói tiện dụng" },
                    { 11, "Băng giấy & Màng bọc tiện lợi", "Giấy vệ sinh cuộn, tăm bông, túi bóng gói hàng, màng bọc thực phẩm" },
                    { 12, "Dầu ăn & Mỡ tinh luyện", "Dầu đậu nành Tường An, dầu mè thơm chiên xào nấu nướng" },
                    { 13, "Đồ khô & Thảo quả rim", "Tôm khô Cà Mau, cá sặc bổi, mực khô, nấm mèo, mộc nhĩ khô" },
                    { 14, "Thuốc lá & Trầu cau lễ", "Bao diêm Thống Nhất, bật lửa ga, trà bắc Thái Nguyên" },
                    { 15, "Vật dụng tạp hóa gia dụng", "Kẹp quần áo, bật lửa, pin con thỏ, keo 502, băng keo bấm ghim" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 1, "14/2 Cô Giang, Phường Cầu Ông Lãnh, TP.HCM", "Má Bảy Hẻm Cây Điệp", "Kim Cương", "0903112233", 1450 },
                    { 2, "82 Bùi Viện, Phường Phạm Ngũ Lão,  TP.HCM", "Chị Lan Bún Bò", "Vàng", "0918776655", 820 },
                    { 3, "105 Đề Thám, Phường Cô Giang, TP.HCM", "Chú Tư Xe Ôm", "Thân Thiết", "0983445566", 210 },
                    { 4, "204 Trần Hưng Đạo , Phường 7, TP.HCM", "Cô Năm Bánh Tiêu", "Bạc", "0935667788", 430 },
                    { 5, "45 Nguyễn Biểu, Phường 1 , TP.HCM", "Bác Sáu Thợ Hồ", "Mới", "0977881122", 35 },
                    { 6, "68 Lê Thị Riêng , Phường Bến Thành , TP.HCM", "Chị Hương Tiệm Tóc", "Vàng", "0909123456", 760 },
                    { 7, "12 Vĩnh Viễn, Phường 2 , TP.HCM", "Anh Ba Sửa Xe", "Bạc", "0913987654", 390 },
                    { 8, "39 Chợ Lớn, Phường 11 , TP.HCM", "Bà Hai Trầu Cau", "Kim Cương", "0987112233", 1600 },
                    { 9, "55 Tôn Đản, Phường 13, TP.HCM", "Chị Út Tạp Hóa Xóm Dưới", "Vàng", "0932334455", 910 },
                    { 10, "73 Hoàng Diệu, Phường 12,  TP.HCM", "Thím Chín Bán Chè", "Bạc", "0974556677", 340 },
                    { 11, "118 Hậu Giang, Phường 6,  TP.HCM", "Chú Chín Thợ Mộc", "Thân Thiết", "0908889900", 180 },
                    { 12, "29 Võ Văn Tần, Phường 6,  TP.HCM", "Cô Mười Bánh Mì", "Vàng", "0915667799", 870 },
                    { 13, "88 Calmette, Phường Nguyễn Thái Bình, Q TP.HCM", "Dì Tư Dệt Chiếu", "Thân Thiết", "0989223344", 150 },
                    { 14, "10 Bến Vân Đồn, Phường 9,  TP.HCM", "Anh Năm Giao Nước Đá", "Bạc", "0938665544", 420 },
                    { 15, "215 Lý Thường Kiệt, Phường 7,  TP.HCM", "Chị Mai Công Nhân May", "Mới", "0976113355", 50 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "RoleName" },
                values: new object[,]
                {
                    { 1, "Chủ tiệm Cô Ba - Quản lý toàn bộ sổ sách, giá cả và tồn kho", "Admin" },
                    { 2, "Thu ngân quầy tạp hóa - Bán lẻ, tính tiền và in bill cho khách", "Cashier" },
                    { 3, "Thủ kho tiệm tạp hóa - Nhập bao hàng, kiểm date và bốc dỡ kho", "Warehouse" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity", "Unit" },
                values: new object[,]
                {
                    { 1, "8935001100011", 1, 28000m, "Nước mắm Nam Ngư Đệ Nhị 900ml", 120, "Chai" },
                    { 2, "8935001100028", 2, 115000m, "Gạo Tấm Thơm Chợ Đào (Bao 5kg)", 80, "Bao 5kg" },
                    { 3, "8935001100035", 3, 128000m, "Thùng mì Hảo Hảo tôm chua cay 30 gói", 60, "Thùng" },
                    { 4, "8935001100042", 4, 35000m, "Kẹo dừa Bến Tre gói truyền thống", 150, "Gói 300g" },
                    { 5, "8935001100059", 5, 10000m, "Nước ngọt Xá Xị Chương Dương lon 330ml", 240, "Lon" },
                    { 6, "8935001100066", 6, 26000m, "Sữa đặc Ông Thọ nắp bật lon 380g", 180, "Lon" },
                    { 7, "8935001100073", 7, 18000m, "Cá hộp xốt cà Ba Cô Gái lon 155g", 140, "Hộp" },
                    { 8, "8935001100080", 8, 38000m, "Bột giặt Viso Trắng Sáng gói 1kg", 90, "Gói 1kg" },
                    { 9, "8935001100097", 9, 24000m, "Nước rửa chén Mỹ Hảo hương chanh 750ml", 110, "Chai" },
                    { 10, "8935001100103", 10, 15000m, "Xà bông thơm Cô Ba Sài Gòn 90g", 200, "Cục" },
                    { 11, "8935001100110", 11, 42000m, "Lốc giấy vệ sinh Sài Gòn Extra 10 cuộn", 75, "Lốc" },
                    { 12, "8935001100127", 12, 48000m, "Dầu ăn thực vật Tường An Cooking Oil 1L", 130, "Chai 1L" },
                    { 13, "8935001100134", 13, 190000m, "Tôm khô đất Cà Mau loại 1 (Hũ 200g)", 40, "Hũ 200g" },
                    { 14, "8935001100141", 14, 22000m, "Trà lài Sài Gòn gói thiếc thơm lâu 100g", 160, "Gói 100g" },
                    { 15, "8935001100158", 15, 12000m, "Vỉ pin đại Con Thỏ (Lốc 2 viên AA)", 150, "Vỉ" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, "Cô Ba Sài Gòn (Chủ Tiệm)", "123", 1, "coba_chutiem" },
                    { 2, "Anh Hai Trưởng Cửa Hàng", "123", 1, "anhha_quanly" },
                    { 3, "Bé Mai Thu Ngân Ca Sáng", "123", 2, "thungan_mai" },
                    { 4, "Bé Cúc Thu Ngân Ca Chiều", "123", 2, "thungan_cuc" },
                    { 5, "Cô Lan Bán Quầy Trước", "123", 2, "thungan_lan" },
                    { 6, "Em Đào Quẹt Mã POS", "123", 2, "thungan_dao" },
                    { 7, "Chị Trúc Kiểm Tiền Ca Tối", "123", 2, "thungan_truc" },
                    { 8, "Anh Ba Bốc Vác Kho Gạo", "123", 3, "kho_anhba" },
                    { 9, "Chú Tư Kiểm Thùng Nước Ngọt", "123", 3, "kho_chutu" },
                    { 10, "Anh Sáu Phụ Kho Đồ Hộp", "123", 3, "kho_anhsau" },
                    { 11, "Út Đực Nhận Hàng Chợ Đầu Mối", "123", 3, "kho_beut" },
                    { 12, "Kế Toán Sổ Sách Tiệm", "123", 1, "admin_phu" },
                    { 13, "Chị Tuyết Ca Trưa Quầy Trái", "123", 2, "thungan_tuyet" },
                    { 14, "Anh Năm Chạy Xe Giao Hàng Kho", "123", 3, "kho_anhnam" },
                    { 15, "Bác Tám Giám Sát Cửa Hàng", "123", 1, "giamsat_tiem" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "AmountReceived", "ChangeAmount", "OrderDate", "PaymentMethod", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, 60000m, 6000m, new DateTime(2026, 10, 1, 7, 45, 0, 0, DateTimeKind.Unspecified), "Cash", "Completed", 54000m, 3 },
                    { 2, 150000m, 7000m, new DateTime(2026, 10, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), "Cash", "Completed", 143000m, 4 },
                    { 3, 148000m, 0m, new DateTime(2026, 10, 2, 9, 15, 0, 0, DateTimeKind.Unspecified), "Transfer", "Completed", 148000m, 5 },
                    { 4, 100000m, 30000m, new DateTime(2026, 10, 2, 10, 20, 0, 0, DateTimeKind.Unspecified), "Cash", "Completed", 70000m, 6 },
                    { 5, 50000m, 5000m, new DateTime(2026, 10, 3, 11, 40, 0, 0, DateTimeKind.Unspecified), "Cash", "Completed", 45000m, 7 },
                    { 6, 100000m, 38000m, new DateTime(2026, 10, 3, 14, 10, 0, 0, DateTimeKind.Unspecified), "Cash", "Completed", 62000m, 3 },
                    { 7, 238000m, 0m, new DateTime(2026, 10, 4, 15, 5, 0, 0, DateTimeKind.Unspecified), "Transfer", "Completed", 238000m, 4 },
                    { 8, 100000m, 24000m, new DateTime(2026, 10, 4, 16, 30, 0, 0, DateTimeKind.Unspecified), "Cash", "Completed", 76000m, 5 },
                    { 9, 142000m, 0m, new DateTime(2026, 10, 5, 8, 15, 0, 0, DateTimeKind.Unspecified), "Transfer", "Completed", 142000m, 6 },
                    { 10, 70000m, 6000m, new DateTime(2026, 10, 5, 9, 50, 0, 0, DateTimeKind.Unspecified), "Cash", "Completed", 64000m, 7 },
                    { 11, 214000m, 0m, new DateTime(2026, 10, 6, 10, 30, 0, 0, DateTimeKind.Unspecified), "Transfer", "Completed", 214000m, 3 },
                    { 12, 60000m, 3000m, new DateTime(2026, 10, 7, 16, 20, 0, 0, DateTimeKind.Unspecified), "Cash", "Completed", 57000m, 4 },
                    { 13, 72000m, 0m, new DateTime(2026, 10, 8, 17, 10, 0, 0, DateTimeKind.Unspecified), "Transfer", "Completed", 72000m, 5 },
                    { 14, 50000m, 10000m, new DateTime(2026, 10, 9, 11, 20, 0, 0, DateTimeKind.Unspecified), "Cash", "Completed", 40000m, 6 },
                    { 15, 0m, 0m, new DateTime(2026, 10, 10, 18, 40, 0, 0, DateTimeKind.Unspecified), "Cash", "Cancelled", 143000m, 7 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductId", "Quantity", "SubTotal", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 28000m, 28000m },
                    { 2, 1, 6, 1, 26000m, 26000m },
                    { 3, 2, 2, 1, 115000m, 115000m },
                    { 4, 2, 1, 1, 28000m, 28000m },
                    { 5, 3, 3, 1, 128000m, 128000m },
                    { 6, 3, 5, 2, 20000m, 10000m },
                    { 7, 4, 4, 2, 70000m, 35000m },
                    { 8, 4, 15, 0, 0m, 12000m },
                    { 9, 5, 10, 3, 45000m, 15000m },
                    { 10, 5, 5, 0, 0m, 10000m },
                    { 11, 6, 7, 2, 36000m, 18000m },
                    { 12, 6, 6, 1, 26000m, 26000m },
                    { 13, 7, 13, 1, 190000m, 190000m },
                    { 14, 7, 12, 1, 48000m, 48000m },
                    { 15, 8, 8, 2, 76000m, 38000m },
                    { 16, 8, 9, 0, 0m, 24000m },
                    { 17, 9, 11, 1, 42000m, 42000m },
                    { 18, 9, 5, 10, 100000m, 10000m },
                    { 19, 10, 14, 1, 22000m, 22000m },
                    { 20, 10, 11, 1, 42000m, 42000m },
                    { 21, 11, 13, 1, 190000m, 190000m },
                    { 22, 11, 9, 1, 24000m, 24000m },
                    { 23, 12, 4, 1, 35000m, 35000m },
                    { 24, 12, 14, 1, 22000m, 22000m },
                    { 25, 13, 12, 1, 48000m, 48000m },
                    { 26, 13, 9, 1, 24000m, 24000m },
                    { 27, 14, 15, 1, 12000m, 12000m },
                    { 28, 14, 1, 1, 28000m, 28000m },
                    { 29, 15, 2, 1, 115000m, 115000m },
                    { 30, 15, 1, 1, 28000m, 28000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
