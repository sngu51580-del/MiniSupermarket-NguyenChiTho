using System;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext() { }

        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-N4LP8GQI;Database=MiniSupermarketDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Quan hệ User - Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Quan hệ Order - OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ Product - OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================================================================
            // === 15 DANH MỤC (TIỆM TẠP HÓA CÔ BA SÀI GÒN) ==============================
            // =========================================================================
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Gia vị bếp nhà", Description = "Nước mắm, đường cát, bột ngọt, hạt nêm gia vị truyền thống" },
                new Category { CategoryId = 2, CategoryName = "Gạo tấm & Ngũ cốc bao", Description = "Gạo tấm thơm Sài Gòn, nếp cái hoa vàng, các loại đậu hạt" },
                new Category { CategoryId = 3, CategoryName = "Mì gói & Miến bún khô", Description = "Mì tôm Miliket, Hảo Hảo, phở khô, miến dong ăn liền" },
                new Category { CategoryId = 4, CategoryName = "Bánh kẹo tuổi thơ", Description = "Bánh quy bơ, kẹo dừa, bánh men, kẹo mè xửng, kẹo lạc" },
                new Category { CategoryId = 5, CategoryName = "Nước ngọt & Bia chai giải khát", Description = "Xá xị Chương Dương, nước ngọt có ga, bia lon Sài Gòn ướp lạnh" },
                new Category { CategoryId = 6, CategoryName = "Sữa đặc & Cà phê phin", Description = "Sữa đặc Ông Thọ, cà phê nguyên chất pha phin vợt Sài Gòn" },
                new Category { CategoryId = 7, CategoryName = "Đồ hộp & Thực phẩm chế biến", Description = "Cá hộp Ba Cô Gái, pate thịt nguội, xúc xích tiệt trùng" },
                new Category { CategoryId = 8, CategoryName = "Chăm sóc giặt xả vải vóc", Description = "Bột giặt Viso, nước giặt xả Comfort thơm hương ban mai" },
                new Category { CategoryId = 9, CategoryName = "Tẩy rửa & Vệ sinh nhà cửa", Description = "Nước rửa chén Mỹ Hảo, nước lau sàn, chổi cước, cọ chùi xoong" },
                new Category { CategoryId = 10, CategoryName = "Vệ sinh cá nhân gia đình", Description = "Xà bông Cô Ba, kem đánh răng Dạ Lan, dầu gội gói tiện dụng" },
                new Category { CategoryId = 11, CategoryName = "Băng giấy & Màng bọc tiện lợi", Description = "Giấy vệ sinh cuộn, tăm bông, túi bóng gói hàng, màng bọc thực phẩm" },
                new Category { CategoryId = 12, CategoryName = "Dầu ăn & Mỡ tinh luyện", Description = "Dầu đậu nành Tường An, dầu mè thơm chiên xào nấu nướng" },
                new Category { CategoryId = 13, CategoryName = "Đồ khô & Thảo quả rim", Description = "Tôm khô Cà Mau, cá sặc bổi, mực khô, nấm mèo, mộc nhĩ khô" },
                new Category { CategoryId = 14, CategoryName = "Thuốc lá & Trầu cau lễ", Description = "Bao diêm Thống Nhất, bật lửa ga, trà bắc Thái Nguyên" },
                new Category { CategoryId = 15, CategoryName = "Vật dụng tạp hóa gia dụng", Description = "Kẹp quần áo, bật lửa, pin con thỏ, keo 502, băng keo bấm ghim" }
            );

            // =========================================================================
            // === 15 SẢN PHẨM ĐẶC TRƯNG TẠP HÓA =======================================
            // =========================================================================
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Barcode = "8935001100011", ProductName = "Nước mắm Nam Ngư Đệ Nhị 900ml", CategoryId = 1, Price = 28000, StockQuantity = 120, Unit = "Chai" },
                new Product { ProductId = 2, Barcode = "8935001100028", ProductName = "Gạo Tấm Thơm Chợ Đào (Bao 5kg)", CategoryId = 2, Price = 115000, StockQuantity = 80, Unit = "Bao 5kg" },
                new Product { ProductId = 3, Barcode = "8935001100035", ProductName = "Thùng mì Hảo Hảo tôm chua cay 30 gói", CategoryId = 3, Price = 128000, StockQuantity = 60, Unit = "Thùng" },
                new Product { ProductId = 4, Barcode = "8935001100042", ProductName = "Kẹo dừa Bến Tre gói truyền thống", CategoryId = 4, Price = 35000, StockQuantity = 150, Unit = "Gói 300g" },
                new Product { ProductId = 5, Barcode = "8935001100059", ProductName = "Nước ngọt Xá Xị Chương Dương lon 330ml", CategoryId = 5, Price = 10000, StockQuantity = 240, Unit = "Lon" },
                new Product { ProductId = 6, Barcode = "8935001100066", ProductName = "Sữa đặc Ông Thọ nắp bật lon 380g", CategoryId = 6, Price = 26000, StockQuantity = 180, Unit = "Lon" },
                new Product { ProductId = 7, Barcode = "8935001100073", ProductName = "Cá hộp xốt cà Ba Cô Gái lon 155g", CategoryId = 7, Price = 18000, StockQuantity = 140, Unit = "Hộp" },
                new Product { ProductId = 8, Barcode = "8935001100080", ProductName = "Bột giặt Viso Trắng Sáng gói 1kg", CategoryId = 8, Price = 38000, StockQuantity = 90, Unit = "Gói 1kg" },
                new Product { ProductId = 9, Barcode = "8935001100097", ProductName = "Nước rửa chén Mỹ Hảo hương chanh 750ml", CategoryId = 9, Price = 24000, StockQuantity = 110, Unit = "Chai" },
                new Product { ProductId = 10, Barcode = "8935001100103", ProductName = "Xà bông thơm Cô Ba Sài Gòn 90g", CategoryId = 10, Price = 15000, StockQuantity = 200, Unit = "Cục" },
                new Product { ProductId = 11, Barcode = "8935001100110", ProductName = "Lốc giấy vệ sinh Sài Gòn Extra 10 cuộn", CategoryId = 11, Price = 42000, StockQuantity = 75, Unit = "Lốc" },
                new Product { ProductId = 12, Barcode = "8935001100127", ProductName = "Dầu ăn thực vật Tường An Cooking Oil 1L", CategoryId = 12, Price = 48000, StockQuantity = 130, Unit = "Chai 1L" },
                new Product { ProductId = 13, Barcode = "8935001100134", ProductName = "Tôm khô đất Cà Mau loại 1 (Hũ 200g)", CategoryId = 13, Price = 190000, StockQuantity = 40, Unit = "Hũ 200g" },
                new Product { ProductId = 14, Barcode = "8935001100141", ProductName = "Trà lài Sài Gòn gói thiếc thơm lâu 100g", CategoryId = 14, Price = 22000, StockQuantity = 160, Unit = "Gói 100g" },
                new Product { ProductId = 15, Barcode = "8935001100158", ProductName = "Vỉ pin đại Con Thỏ (Lốc 2 viên AA)", CategoryId = 15, Price = 12000, StockQuantity = 150, Unit = "Vỉ" }
            );

            // =========================================================================
            // === 15 KHÁCH HÀNG THÂN THIẾT XÓM PHỐ ===================================
            // =========================================================================
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Má Bảy Hẻm Cây Điệp", PhoneNumber = "0903112233", Address = "14/2 Cô Giang, Phường Cầu Ông Lãnh, TP.HCM", MembershipRank = "Kim Cương", RewardPoints = 1450 },
                new Customer { CustomerId = 2, CustomerName = "Chị Lan Bún Bò", PhoneNumber = "0918776655", Address = "82 Bùi Viện, Phường Phạm Ngũ Lão,  TP.HCM", MembershipRank = "Vàng", RewardPoints = 820 },
                new Customer { CustomerId = 3, CustomerName = "Chú Tư Xe Ôm", PhoneNumber = "0983445566", Address = "105 Đề Thám, Phường Cô Giang, TP.HCM", MembershipRank = "Thân Thiết", RewardPoints = 210 },
                new Customer { CustomerId = 4, CustomerName = "Cô Năm Bánh Tiêu", PhoneNumber = "0935667788", Address = "204 Trần Hưng Đạo , Phường 7, TP.HCM", MembershipRank = "Bạc", RewardPoints = 430 },
                new Customer { CustomerId = 5, CustomerName = "Bác Sáu Thợ Hồ", PhoneNumber = "0977881122", Address = "45 Nguyễn Biểu, Phường 1 , TP.HCM", MembershipRank = "Mới", RewardPoints = 35 },
                new Customer { CustomerId = 6, CustomerName = "Chị Hương Tiệm Tóc", PhoneNumber = "0909123456", Address = "68 Lê Thị Riêng , Phường Bến Thành , TP.HCM", MembershipRank = "Vàng", RewardPoints = 760 },
                new Customer { CustomerId = 7, CustomerName = "Anh Ba Sửa Xe", PhoneNumber = "0913987654", Address = "12 Vĩnh Viễn, Phường 2 , TP.HCM", MembershipRank = "Bạc", RewardPoints = 390 },
                new Customer { CustomerId = 8, CustomerName = "Bà Hai Trầu Cau", PhoneNumber = "0987112233", Address = "39 Chợ Lớn, Phường 11 , TP.HCM", MembershipRank = "Kim Cương", RewardPoints = 1600 },
                new Customer { CustomerId = 9, CustomerName = "Chị Út Tạp Hóa Xóm Dưới", PhoneNumber = "0932334455", Address = "55 Tôn Đản, Phường 13, TP.HCM", MembershipRank = "Vàng", RewardPoints = 910 },
                new Customer { CustomerId = 10, CustomerName = "Thím Chín Bán Chè", PhoneNumber = "0974556677", Address = "73 Hoàng Diệu, Phường 12,  TP.HCM", MembershipRank = "Bạc", RewardPoints = 340 },
                new Customer { CustomerId = 11, CustomerName = "Chú Chín Thợ Mộc", PhoneNumber = "0908889900", Address = "118 Hậu Giang, Phường 6,  TP.HCM", MembershipRank = "Thân Thiết", RewardPoints = 180 },
                new Customer { CustomerId = 12, CustomerName = "Cô Mười Bánh Mì", PhoneNumber = "0915667799", Address = "29 Võ Văn Tần, Phường 6,  TP.HCM", MembershipRank = "Vàng", RewardPoints = 870 },
                new Customer { CustomerId = 13, CustomerName = "Dì Tư Dệt Chiếu", PhoneNumber = "0989223344", Address = "88 Calmette, Phường Nguyễn Thái Bình, Q TP.HCM", MembershipRank = "Thân Thiết", RewardPoints = 150 },
                new Customer { CustomerId = 14, CustomerName = "Anh Năm Giao Nước Đá", PhoneNumber = "0938665544", Address = "10 Bến Vân Đồn, Phường 9,  TP.HCM", MembershipRank = "Bạc", RewardPoints = 420 },
                new Customer { CustomerId = 15, CustomerName = "Chị Mai Công Nhân May", PhoneNumber = "0976113355", Address = "215 Lý Thường Kiệt, Phường 7,  TP.HCM", MembershipRank = "Mới", RewardPoints = 50 }
            );

            // =========================================================================
            // === 3 PHÂN QUYỀN HỆ THỐNG ===============================================
            // =========================================================================
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin", Description = "Chủ tiệm Cô Ba - Quản lý toàn bộ sổ sách, giá cả và tồn kho" },
                new Role { Id = 2, RoleName = "Cashier", Description = "Thu ngân quầy tạp hóa - Bán lẻ, tính tiền và in bill cho khách" },
                new Role { Id = 3, RoleName = "Warehouse", Description = "Thủ kho tiệm tạp hóa - Nhập bao hàng, kiểm date và bốc dỡ kho" }
            );

            // =========================================================================
            // === 15 TÀI KHOẢN NHÂN VIÊN TIỆM TẠP HÓA CÔ BA ===========================
            // =========================================================================
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "coba_chutiem", Password = "123", FullName = "Cô Ba Sài Gòn (Chủ Tiệm)", RoleId = 1 },
                new User { Id = 2, Username = "anhha_quanly", Password = "123", FullName = "Anh Hai Trưởng Cửa Hàng", RoleId = 1 },

                new User { Id = 3, Username = "thungan_mai", Password = "123", FullName = "Bé Mai Thu Ngân Ca Sáng", RoleId = 2 },
                new User { Id = 4, Username = "thungan_cuc", Password = "123", FullName = "Bé Cúc Thu Ngân Ca Chiều", RoleId = 2 },
                new User { Id = 5, Username = "thungan_lan", Password = "123", FullName = "Cô Lan Bán Quầy Trước", RoleId = 2 },
                new User { Id = 6, Username = "thungan_dao", Password = "123", FullName = "Em Đào Quẹt Mã POS", RoleId = 2 },
                new User { Id = 7, Username = "thungan_truc", Password = "123", FullName = "Chị Trúc Kiểm Tiền Ca Tối", RoleId = 2 },

                new User { Id = 8, Username = "kho_anhba", Password = "123", FullName = "Anh Ba Bốc Vác Kho Gạo", RoleId = 3 },
                new User { Id = 9, Username = "kho_chutu", Password = "123", FullName = "Chú Tư Kiểm Thùng Nước Ngọt", RoleId = 3 },
                new User { Id = 10, Username = "kho_anhsau", Password = "123", FullName = "Anh Sáu Phụ Kho Đồ Hộp", RoleId = 3 },
                new User { Id = 11, Username = "kho_beut", Password = "123", FullName = "Út Đực Nhận Hàng Chợ Đầu Mối", RoleId = 3 },

                new User { Id = 12, Username = "admin_phu", Password = "123", FullName = "Kế Toán Sổ Sách Tiệm", RoleId = 1 },
                new User { Id = 13, Username = "thungan_tuyet", Password = "123", FullName = "Chị Tuyết Ca Trưa Quầy Trái", RoleId = 2 },
                new User { Id = 14, Username = "kho_anhnam", Password = "123", FullName = "Anh Năm Chạy Xe Giao Hàng Kho", RoleId = 3 },
                new User { Id = 15, Username = "giamsat_tiem", Password = "123", FullName = "Bác Tám Giám Sát Cửa Hàng", RoleId = 1 }
            );

            // =========================================================================
            // === 15 ĐƠN HÀNG MUA TẠP HÓA ==============================================
            // =========================================================================
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, UserId = 3, OrderDate = new DateTime(2026, 10, 1, 7, 45, 0), TotalAmount = 54000, Status = "Completed", PaymentMethod = "Cash", AmountReceived = 60000, ChangeAmount = 6000 },
                new Order { OrderId = 2, UserId = 4, OrderDate = new DateTime(2026, 10, 1, 8, 30, 0), TotalAmount = 143000, Status = "Completed", PaymentMethod = "Cash", AmountReceived = 150000, ChangeAmount = 7000 },
                new Order { OrderId = 3, UserId = 5, OrderDate = new DateTime(2026, 10, 2, 9, 15, 0), TotalAmount = 148000, Status = "Completed", PaymentMethod = "Transfer", AmountReceived = 148000, ChangeAmount = 0 },
                new Order { OrderId = 4, UserId = 6, OrderDate = new DateTime(2026, 10, 2, 10, 20, 0), TotalAmount = 70000, Status = "Completed", PaymentMethod = "Cash", AmountReceived = 100000, ChangeAmount = 30000 },
                new Order { OrderId = 5, UserId = 7, OrderDate = new DateTime(2026, 10, 3, 11, 40, 0), TotalAmount = 45000, Status = "Completed", PaymentMethod = "Cash", AmountReceived = 50000, ChangeAmount = 5000 },
                new Order { OrderId = 6, UserId = 3, OrderDate = new DateTime(2026, 10, 3, 14, 10, 0), TotalAmount = 62000, Status = "Completed", PaymentMethod = "Cash", AmountReceived = 100000, ChangeAmount = 38000 },
                new Order { OrderId = 7, UserId = 4, OrderDate = new DateTime(2026, 10, 4, 15, 05, 0), TotalAmount = 238000, Status = "Completed", PaymentMethod = "Transfer", AmountReceived = 238000, ChangeAmount = 0 },
                new Order { OrderId = 8, UserId = 5, OrderDate = new DateTime(2026, 10, 4, 16, 30, 0), TotalAmount = 76000, Status = "Completed", PaymentMethod = "Cash", AmountReceived = 100000, ChangeAmount = 24000 },
                new Order { OrderId = 9, UserId = 6, OrderDate = new DateTime(2026, 10, 5, 8, 15, 0), TotalAmount = 142000, Status = "Completed", PaymentMethod = "Transfer", AmountReceived = 142000, ChangeAmount = 0 },
                new Order { OrderId = 10, UserId = 7, OrderDate = new DateTime(2026, 10, 5, 9, 50, 0), TotalAmount = 64000, Status = "Completed", PaymentMethod = "Cash", AmountReceived = 70000, ChangeAmount = 6000 },
                new Order { OrderId = 11, UserId = 3, OrderDate = new DateTime(2026, 10, 6, 10, 30, 0), TotalAmount = 214000, Status = "Completed", PaymentMethod = "Transfer", AmountReceived = 214000, ChangeAmount = 0 },
                new Order { OrderId = 12, UserId = 4, OrderDate = new DateTime(2026, 10, 7, 16, 20, 0), TotalAmount = 57000, Status = "Completed", PaymentMethod = "Cash", AmountReceived = 60000, ChangeAmount = 3000 },
                new Order { OrderId = 13, UserId = 5, OrderDate = new DateTime(2026, 10, 8, 17, 10, 0), TotalAmount = 72000, Status = "Completed", PaymentMethod = "Transfer", AmountReceived = 72000, ChangeAmount = 0 },
                new Order { OrderId = 14, UserId = 6, OrderDate = new DateTime(2026, 10, 9, 11, 20, 0), TotalAmount = 40000, Status = "Completed", PaymentMethod = "Cash", AmountReceived = 50000, ChangeAmount = 10000 },
                new Order { OrderId = 15, UserId = 7, OrderDate = new DateTime(2026, 10, 10, 18, 40, 0), TotalAmount = 143000, Status = "Cancelled", PaymentMethod = "Cash", AmountReceived = 0, ChangeAmount = 0 }
            );

            // =========================================================================
            // === 30 CHI TIẾT ĐƠN HÀNG (SỐ LƯỢNG x ĐƠN GIÁ KHỚP TOTAL) ==================
            // =========================================================================
            modelBuilder.Entity<OrderDetail>().HasData(
                // Đơn 1: Nam Ngư (28k x 1) + Sữa Ông Thọ (26k x 1) = 54k
                new OrderDetail { OrderDetailId = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 28000, SubTotal = 28000 },
                new OrderDetail { OrderDetailId = 2, OrderId = 1, ProductId = 6, Quantity = 1, UnitPrice = 26000, SubTotal = 26000 },

                // Đơn 2: Gạo tấm thơm (115k x 1) + Nam Ngư (28k x 1) = 143k
                new OrderDetail { OrderDetailId = 3, OrderId = 2, ProductId = 2, Quantity = 1, UnitPrice = 115000, SubTotal = 115000 },
                new OrderDetail { OrderDetailId = 4, OrderId = 2, ProductId = 1, Quantity = 1, UnitPrice = 28000, SubTotal = 28000 },

                // Đơn 3: Thùng mì Hảo Hảo (128k x 1) + Xá Xị (10k x 2) = 148k
                new OrderDetail { OrderDetailId = 5, OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 128000, SubTotal = 128000 },
                new OrderDetail { OrderDetailId = 6, OrderId = 3, ProductId = 5, Quantity = 2, UnitPrice = 10000, SubTotal = 20000 },

                // Đơn 4: Kẹo dừa (35k x 2) = 70k
                new OrderDetail { OrderDetailId = 7, OrderId = 4, ProductId = 4, Quantity = 2, UnitPrice = 35000, SubTotal = 70000 },
                new OrderDetail { OrderDetailId = 8, OrderId = 4, ProductId = 15, Quantity = 0, UnitPrice = 12000, SubTotal = 0 },

                // Đơn 5: Xà bông Cô Ba (15k x 1) + Xà bông Cô Ba (15k x 2) = 45k
                new OrderDetail { OrderDetailId = 9, OrderId = 5, ProductId = 10, Quantity = 3, UnitPrice = 15000, SubTotal = 45000 },
                new OrderDetail { OrderDetailId = 10, OrderId = 5, ProductId = 5, Quantity = 0, UnitPrice = 10000, SubTotal = 0 },

                // Đơn 6: Cá hộp Ba Cô Gái (18k x 2) + Sữa đặc Ông Thọ (26k x 1) = 62k
                new OrderDetail { OrderDetailId = 11, OrderId = 6, ProductId = 7, Quantity = 2, UnitPrice = 18000, SubTotal = 36000 },
                new OrderDetail { OrderDetailId = 12, OrderId = 6, ProductId = 6, Quantity = 1, UnitPrice = 26000, SubTotal = 26000 },

                // Đơn 7: Tôm khô Cà Mau (190k x 1) + Dầu ăn Tường An (48k x 1) = 238k
                new OrderDetail { OrderDetailId = 13, OrderId = 7, ProductId = 13, Quantity = 1, UnitPrice = 190000, SubTotal = 190000 },
                new OrderDetail { OrderDetailId = 14, OrderId = 7, ProductId = 12, Quantity = 1, UnitPrice = 48000, SubTotal = 48000 },

                // Đơn 8: Bột giặt Viso (38k x 2) = 76k
                new OrderDetail { OrderDetailId = 15, OrderId = 8, ProductId = 8, Quantity = 2, UnitPrice = 38000, SubTotal = 76000 },
                new OrderDetail { OrderDetailId = 16, OrderId = 8, ProductId = 9, Quantity = 0, UnitPrice = 24000, SubTotal = 0 },

                // Đơn 9: Lốc giấy Sài Gòn (42k x 1) + Xá xị (10k x 10) = 142k
                new OrderDetail { OrderDetailId = 17, OrderId = 9, ProductId = 11, Quantity = 1, UnitPrice = 42000, SubTotal = 42000 },
                new OrderDetail { OrderDetailId = 18, OrderId = 9, ProductId = 5, Quantity = 10, UnitPrice = 10000, SubTotal = 100000 },

                // Đơn 10: Trà lài Sài Gòn (22k x 1) + Lốc giấy Sài Gòn (42k x 1) = 64k
                new OrderDetail { OrderDetailId = 19, OrderId = 10, ProductId = 14, Quantity = 1, UnitPrice = 22000, SubTotal = 22000 },
                new OrderDetail { OrderDetailId = 20, OrderId = 10, ProductId = 11, Quantity = 1, UnitPrice = 42000, SubTotal = 42000 },

                // Đơn 11: Tôm khô Cà Mau (190k x 1) + Nước rửa chén Mỹ Hảo (24k x 1) = 214k
                new OrderDetail { OrderDetailId = 21, OrderId = 11, ProductId = 13, Quantity = 1, UnitPrice = 190000, SubTotal = 190000 },
                new OrderDetail { OrderDetailId = 22, OrderId = 11, ProductId = 9, Quantity = 1, UnitPrice = 24000, SubTotal = 24000 },

                // Đơn 12: Kẹo dừa (35k x 1) + Trà lài (22k x 1) = 57k
                new OrderDetail { OrderDetailId = 23, OrderId = 12, ProductId = 4, Quantity = 1, UnitPrice = 35000, SubTotal = 35000 },
                new OrderDetail { OrderDetailId = 24, OrderId = 12, ProductId = 14, Quantity = 1, UnitPrice = 22000, SubTotal = 22000 },

                // Đơn 13: Dầu ăn Tường An (48k x 1) + Nước rửa chén Mỹ Hảo (24k x 1) = 72k
                new OrderDetail { OrderDetailId = 25, OrderId = 13, ProductId = 12, Quantity = 1, UnitPrice = 48000, SubTotal = 48000 },
                new OrderDetail { OrderDetailId = 26, OrderId = 13, ProductId = 9, Quantity = 1, UnitPrice = 24000, SubTotal = 24000 },

                // Đơn 14: Pin con thỏ (12k x 2) + Xà bông Cô Ba (15k x 1) + 1 viên giảm lẻ = 40k (12k + 28k Nam Ngư)
                new OrderDetail { OrderDetailId = 27, OrderId = 14, ProductId = 15, Quantity = 1, UnitPrice = 12000, SubTotal = 12000 },
                new OrderDetail { OrderDetailId = 28, OrderId = 14, ProductId = 1, Quantity = 1, UnitPrice = 28000, SubTotal = 28000 },

                // Đơn 15 (Đơn hủy): Gạo Tấm Thơm (115k x 1) + Nam Ngư (28k x 1) = 143k
                new OrderDetail { OrderDetailId = 29, OrderId = 15, ProductId = 2, Quantity = 1, UnitPrice = 115000, SubTotal = 115000 },
                new OrderDetail { OrderDetailId = 30, OrderId = 15, ProductId = 1, Quantity = 1, UnitPrice = 28000, SubTotal = 28000 }
            );
        }
    }
}