# 👑🛍️ Hệ thống POS Thu ngân tích hợp Quản lý Kho hàng – Tiệm Tạp hóa Cô Ba Sài Gòn

## 📌 Thông tin Đồ án Môn học
- **Trường:** Trường Cao đẳng Công Thương TP. Hồ Chí Minh (HITC) – Khoa Công nghệ Thông tin
- **Học phần:** Lập trình Ứng dụng C# .NET Core
- **Đề tài:** Thiết kế và Thi công Hệ thống POS Thu ngân tích hợp Quản lý Kho hàng – Tiệm Tạp hóa Cô Ba Sài Gòn
- **Giảng viên hướng dẫn (GVHD):** ThS. NGUYỄN CAO THÁI
- **Sinh viên thực hiện (SVTH):** NGUYỄN CHÍ THỌ
- **MSSV:** `2124110260`
- **Lớp:** `CCQ2411H`

---

## 🏗️ Kiến trúc Hệ thống & Công nghệ Sử dụng
Dự án được xây dựng theo kiến trúc **Client – Server (3-Tier Architecture)** tách biệt hoàn toàn giữa tầng xử lý nghiệp vụ Backend và giao diện người dùng Desktop Frontend:

1. **Backend (`MiniSupermarket.API`) – ASP.NET Core 8.0 Web API:**
   - **RESTful Web API & DTO Pattern:** Chuẩn hóa các phương thức HTTP (`GET`, `POST`, `PUT`, `DELETE`) và mã trạng thái (`200 OK`, `201 Created`, `400 Bad Request`, `401 Unauthorized`, `403 Forbidden`, `404 Not Found`), kết hợp các lớp DTO (`LoginRequestDto`, `LoginResponseDto`, `ProductDto`, `CreateProductDto`, `OrderRequestDto`, `OrderResponseDto`).
   - **Entity Framework Core 8.0 (ORM) & Code-First Migrations:** Quản lý 6 thực thể (`User`, `Category`, `Product`, `Customer`, `Order`, `OrderDetail`), cấu hình khóa ngoại (`Fluent API` + `Data Annotations`), tự động khởi tạo CSDL và nạp dữ liệu mẫu (`DbSeeder`: 5 ngành hàng, 18 mặt hàng tạp hóa, 4 khách hàng thân thiết, 3 tài khoản phân quyền, 5 hóa đơn mẫu).
   - **Tối ưu hóa truy vấn LINQ:** Tìm kiếm gần đúng (`.Contains()`), lọc theo danh mục, phân trang máy chủ (`.Skip()` & `.Take()`), nạp bảng liên quan Eager Loading (`.Include(p => p.Category)`), và giải phóng bộ nhớ với `.AsNoTracking()`.
   - **Bảo mật Xác thực JWT & Phân quyền RBAC:** Cấp phát chuỗi mã thông báo JWT (`HS256`, `JwtRegisteredClaimNames`, `ClaimTypes.Role`), bảo vệ Endpoint bằng `[Authorize]` và `[Authorize(Roles = "Admin")]`, tích hợp nút ổ khóa **Bearer Authorize** trên giao diện Swagger UI.
   - **ADO.NET Thuần Hiệu năng cao & Giao dịch ACID (`SqlTransaction`):**
     - Tra cứu siêu tốc sản phẩm theo mã vạch (`Barcode`) qua `SqlConnection`, `SqlCommand`, `SqlDataReader` (`CommandBehavior.SingleRow`) chống tấn công SQL Injection bằng `Parameters.AddWithValue`.
     - Báo cáo doanh thu theo ngày/ca làm việc bằng `CommandType.StoredProcedure` (`sp_GetDailyRevenue`).
     - Thanh toán hóa đơn POS an toàn tuyệt đối trong khối `SqlTransaction` (`OrdersController.Checkout`): kiểm tra tồn kho (`SELECT ... WITH (UPDLOCK)`), lưu `Orders`, lưu `OrderDetails`, trừ tồn kho `Products.StockQuantity`, cộng điểm tích lũy `Customers.Points` (1 điểm / 10.000đ). Tự động `Rollback()` toàn bộ nếu bất kỳ mặt hàng nào không đủ tồn kho.

2. **Frontend (`MiniSupermarket.WinForm`) – Windows Forms (.NET 8.0):**
   - **Giao diện Shell MDI hiện đại (Tông màu Tím Violet/Indigo đặc trưng):** Bố cục 3 phân vùng cố định (`Sidebar Menu` bên trái, `Header Bar` bên trên, ` Workspace Panel` ở giữa), nhúng mượt mà các Form con (`TopLevel = false`, `Dock = Fill`) chống giật lag.
   - **Phân quyền Giao diện Động (Role-Based UI):** Tự động ẩn/hiện các nút điều hướng và chức năng theo `SessionManager.CurrentUser.Role` (`Admin` toàn quyền, `Cashier` chỉ mở quầy POS bán hàng, `Warehouse` chuyên trách danh mục & kho hàng).
   - **Trải nghiệm Người dùng (UX) & Bất đồng bộ (`async/await`):** Tích hợp `HttpClient` dùng chung đính kèm `AuthenticationHeaderValue("Bearer", JwtToken)`, hiệu ứng `Cursor = Cursors.WaitCursor`, khóa nút bấm chống Double-Click khi thanh toán, bắt lỗi thân thiện tiếng Việt và vẽ biểu đồ cột GDI+ (`Graphics.FillRectangle`) trực quan.

---

## 📂 Cấu trúc Thư mục Dự án
```text
MiniSuperMartket_NguyenChiTho/
├── MiniSupermarket.sln                     # Tệp Solution quản lý 2 Project độc lập
├── README.md                               # Tài liệu hướng dẫn cài đặt & vận hành hệ thống
├── BaoCaoDoAn_NguyenChiTho_2124110260.docx # Báo cáo đồ án môn học hoàn chỉnh (Word chuẩn HITC)
├── CamNangBaoVe_TieuChi_11_50_NguyenChiTho.docx # Cẩm nang đối chiếu 40 tiêu chí chấm điểm thực hành
│
├── MiniSupermarket.API/                    # Project 1: Tầng Backend (ASP.NET Core Web API)
│   ├── Controllers/
│   │   ├── AuthController.cs               # Đăng nhập xác thực & cấp phát JWT Token
│   │   ├── CategoriesController.cs         # CRUD danh mục ngành hàng tạp hóa
│   │   ├── ProductsController.cs           # CRUD sản phẩm, tìm kiếm LINQ, phân trang, Include
│   │   ├── AdoProductsController.cs        # Tra cứu Barcode bằng ADO.NET thuần & SqlDataReader
│   │   ├── OrdersController.cs             # Thanh toán POS bọc trong SqlTransaction & xem lịch sử
│   │   ├── CustomersController.cs          # Quản lý khách hàng thân thiết & tích điểm
│   │   ├── ReportsController.cs            # Thống kê doanh thu qua Stored Procedure & LINQ
│   │   └── UsersController.cs              # Quản trị tài khoản nhân sự (Admin)
│   ├── Data/
│   │   ├── ApplicationDbContext.cs         # Cấu hình EF Core DbContext & Fluent API
│   │   └── DbSeeder.cs                     # Tự động nạp dữ liệu mẫu Tiệm Tạp Hóa Cô Ba Sài Gòn
│   ├── DTOs/
│   │   └── Dtos.cs                         # Các lớp Data Transfer Object truyền tải JSON
│   ├── Models/                             # 6 thực thể CSDL (User, Category, Product, Customer, Order, OrderDetail)
│   ├── Migrations/                         # Lịch sử khởi tạo CSDL EF Core Code-First
│   ├── appsettings.json                    # Chuỗi kết nối SQL Server & cấu hình khóa bí mật JWT
│   └── Program.cs                          # Cấu hình DI Container, CORS, JWT Bearer, Swagger UI
│
└── MiniSupermarket.WinForm/                # Project 2: Tầng Frontend (Windows Forms Desktop Client)
    ├── Forms/
    │   ├── FormLogin.cs                    # Màn hình đăng nhập & chọn nhanh tài khoản Demo
    │   ├── FormMain.cs                     # Giao diện khung Shell MDI & điều hướng phân quyền
    │   ├── FormDashboard.cs                # Tổng quan vận hành, thẻ KPI & cảnh báo sắp hết hàng
    │   ├── FormPOS.cs                      # Quầy thu ngân POS, quét Barcode ADO.NET, giỏ hàng & thanh toán
    │   ├── FormProducts.cs                 # Quản lý kho hàng, lọc danh mục, phân trang & CRUD
    │   ├── FormCategories.cs               # Quản lý ngành hàng tạp hóa
    │   ├── FormCustomers.cs                # Quản lý sổ khách hàng thân thiết & hạng thành viên
    │   ├── FormOrders.cs                   # Tra cứu lịch sử hóa đơn & chi tiết mặt hàng
    │   ├── FormReports.cs                  # Biểu đồ cột GDI+ doanh thu 7 ngày & Stored Procedure
    │   └── FormUsers.cs                    # Quản lý nhân sự & phân quyền vai trò (Admin)
    ├── Services/
    │   ├── ApiClient.cs                    # Lớp bọc HttpClient bất đồng bộ & tự động gắn Bearer Token
    │   └── SessionManager.cs               # Lưu trữ phiên đăng nhập (JwtToken, CurrentUser)
    └── Program.cs                          # Điểm khởi chạy ứng dụng WinForms
```

---

## 🚀 Hướng dẫn Cài đặt và Chạy Dự án (Quick Start)

### 1. Yêu cầu Hệ thống (Prerequisites)
- **.NET SDK:** `.NET 8.0 SDK` trở lên.
- **Cơ sở dữ liệu:** `SQL Server` (Express / Developer) hoặc `SQL Server LocalDB` (`(localdb)\MSSQLLocalDB`).
- **Công cụ phát triển:** Visual Studio 2022 hoặc Visual Studio Code / PowerShell.

### 2. Cấu hình Chuỗi kết nối (`appsettings.json`)
Mở tệp `MiniSupermarket.API/appsettings.json` và kiểm tra chuỗi kết nối `DefaultConnection` (mặc định sử dụng LocalDB, tự động tạo CSDL `MiniSupermarketDb_NguyenChiTho` khi chạy):
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MiniSupermarketDb_NguyenChiTho;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

### 3. Bước 1 – Khởi chạy Backend (`MiniSupermarket.API`)
Mở Terminal / PowerShell tại thư mục gốc của dự án và chạy lệnh:
```powershell
cd MiniSupermarket.API
dotnet run --urls "http://localhost:5237"
```
- Ngay khi khởi động, `DbSeeder.Seed(app)` sẽ tự động thực thi `context.Database.Migrate()`, khởi tạo bảng, tạo thủ tục lưu trữ `sp_GetDailyRevenue` và nạp đầy đủ dữ liệu mẫu.
- Truy cập giao diện kiểm thử **Swagger UI** tại: `http://localhost:5237/swagger`

### 4. Bước 2 – Khởi chạy Frontend (`MiniSupermarket.WinForm`)
Mở một cửa sổ Terminal / PowerShell thứ hai (giữ nguyên cửa sổ Backend đang chạy) và thực thi:
```powershell
cd MiniSupermarket.WinForm
dotnet run
```
*(Hoặc trong Visual Studio 2022: Chuột phải vào Solution -> **Configure Startup Projects...** -> chọn **Multiple startup projects** -> đặt cả `MiniSupermarket.API` và `MiniSupermarket.WinForm` thành **Start** rồi nhấn **F5**).*

---

## 🔐 Danh sách Tài khoản Đăng nhập Mẫu (Seed Accounts)

| STT | Tên đăng nhập (`Username`) | Mật khẩu (`Password`) | Họ và tên nhân sự | Vai trò (`Role`) | Quyền hạn trên Hệ thống |
| :-: | :--- | :--- | :--- | :---: | :--- |
| 1 | `coba_chutiem` | `123456` | Nguyễn Thị Ba (Cô Ba) | `Admin` | Toàn quyền quản trị hệ thống, xem báo cáo doanh thu, quản lý kho, POS, khách hàng và nhân sự. |
| 2 | `thungan_mai` | `123456` | Trần Ngọc Mai (Ca Sáng) | `Cashier` | Chuyên trách quầy Thu ngân POS bán hàng, quét Barcode và tra cứu khách hàng tích điểm. |
| 3 | `kho_anhba` | `123456` | Lê Văn Tư (Thủ Kho) | `Warehouse` | Chuyên trách quản lý danh mục ngành hàng, kiểm kê tồn kho và cập nhật giá sản phẩm. |

---

## 🔗 Danh mục các Endpoint RESTful API Tiêu biểu

| Phân hệ | Phương thức | Đường dẫn (Endpoint URL) | Phân quyền | Mô tả Nghiệp vụ |
| :--- | :---: | :--- | :---: | :--- |
| **Xác thực** | `POST` | `/api/auth/login` | Public | Xác thực tài khoản & cấp phát chuỗi mã JWT Token |
| **Danh mục** | `GET` | `/api/categories` | Authenticated | Lấy danh sách ngành hàng tạp hóa (`AsNoTracking`) |
| **Danh mục** | `POST/PUT/DELETE` | `/api/categories/{id}` | `Admin`, `Warehouse` | Thêm mới, cập nhật hoặc xóa ngành hàng |
| **Sản phẩm** | `GET` | `/api/products?search=&categoryId=&page=&pageSize=` | Authenticated | Tìm kiếm LINQ, lọc theo nhóm, phân trang `Skip/Take`, `Include` |
| **Sản phẩm** | `POST/PUT/DELETE` | `/api/products/{id}` | `Admin`, `Warehouse` | Thêm mới, sửa, xóa sản phẩm qua EF Core |
| **ADO.NET** | `GET` | `/api/ado-products/barcode/{barcode}` | Authenticated | Tra cứu nhanh mã vạch bằng `SqlConnection` & `SqlDataReader` |
| **Hóa đơn POS** | `POST` | `/api/orders/checkout` | Authenticated | Thanh toán giỏ hàng POS bọc trong `SqlTransaction` (ACID) |
| **Hóa đơn POS** | `GET` | `/api/orders` | Authenticated | Xem lịch sử hóa đơn & chi tiết mặt hàng |
| **Báo cáo** | `GET` | `/api/reports/daily-revenue?days=7` | `Admin` | Thống kê doanh thu theo ngày qua `Stored Procedure` |
| **Báo cáo** | `GET` | `/api/reports/top-products?top=5` | `Admin` | Thống kê Top sản phẩm bán chạy nhất bằng LINQ `GroupBy` |
