# 👑🛍️ Hệ thống POS Thu ngân tích hợp Quản lý Kho hàng – Tiệm Tạp hóa Cô Ba Sài Gòn

<<<<<<< HEAD
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
=======
**Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
**Buổi thực hành:** Buổi 4 – Thiết kế kiến trúc giao diện WinForms Shell và điều hướng phân quyền người dùng.

---

## 🏗️ 1. Mô hình kiến trúc hệ thống (Client – Server)

Dự án được xây dựng theo mô hình Client – Server, gồm hai thành phần chính:

- **MiniSupermarket.API (Backend):** Ứng dụng ASP.NET Core Web API chịu trách nhiệm xử lý nghiệp vụ, quản lý dữ liệu và cung cấp API cho ứng dụng Client.
- **MiniSupermarket.WinForm (Frontend Client):** Ứng dụng Windows Forms cung cấp giao diện quản lý siêu thị, hỗ trợ điều hướng giữa các màn hình nghiệp vụ và tổ chức giao diện theo vai trò người dùng.

Trong buổi thực hành 4, trọng tâm là xây dựng kiến trúc giao diện trung tâm `FormMainShell`, tổ chức thanh điều hướng Sidebar, vùng hiển thị nội dung và cơ chế phân quyền giao diện theo ba vai trò: Admin, Cashier và Warehouse.

## 🛠️ 2. Công nghệ sử dụng

- **Ngôn ngữ lập trình:** C#
- **Nền tảng:** .NET 8.0
- **Backend:** ASP.NET Core Web API
- **Frontend:** Windows Forms
- **Giao tiếp Client – Server:** HTTP API
- **Thành phần giao diện:** Form, Panel, Button, Label, DataGridView
- **Kỹ thuật điều hướng:** Nhúng Form con vào Panel trung tâm
- **Kỹ thuật phân quyền:** Role-Based Access Control (RBAC)

## 📂 3. Cấu trúc Solution

Cấu trúc dưới đây được tổng hợp từ các thư mục và tệp hiển thị trong Solution Explorer.

```text
MiniSupermarket.API/
│
├── Controllers/
│   ├── CustomerController.cs
│   ├── OrdersController.cs
│   ├── ProductsController.cs
│   ├── RolesController.cs
│   ├── UsersController.cs
│   └── WeatherForecastController.cs
│
├── Data/
│
├── Migrations/
│
├── Models/
│
├── appsettings.json
├── MiniSupermarket.API.http
├── Program.cs
└── WeatherForecast.cs
│
└── MiniSupermarket.WinForm/
    │
    ├── Dependencies/
    ├── Form1.cs
    ├── FormCategoryManagement.cs
    ├── FormCustomerManagement.cs
    ├── FormLogin.cs
    ├── FormMainShell.cs
    ├── FormPOS.cs
    ├── FormProductManagement.cs
    ├── FormQuickReport.cs
    ├── FormRoleManagement.cs
    ├── FormUserManagement.cs
    ├── Program.cs
    └── SessionManager.cs
```

**Chức năng các thành phần chính:**

### Backend – MiniSupermarket.API

| Thành phần | Chức năng |
|---|---|
| `Controllers/` | Chứa các Controller xử lý những nhóm chức năng của API. |
| `CustomerController.cs` | Xử lý các yêu cầu liên quan đến khách hàng. |
| `OrdersController.cs` | Xử lý các yêu cầu liên quan đến đơn hàng. |
| `ProductsController.cs` | Xử lý các yêu cầu liên quan đến sản phẩm. |
| `RolesController.cs` | Xử lý các yêu cầu liên quan đến vai trò. |
| `UsersController.cs` | Xử lý các yêu cầu liên quan đến tài khoản người dùng. |
| `Data/` | Chứa các thành phần làm việc với dữ liệu. |
| `Migrations/` | Chứa các tệp Migration của Entity Framework Core. |
| `Models/` | Chứa các lớp mô hình dữ liệu. |
| `Program.cs` | Điểm khởi chạy và cấu hình ứng dụng API. |
| `appsettings.json` | Chứa các cấu hình của ứng dụng. |

### Frontend – MiniSupermarket.WinForm

| Tệp | Chức năng |
|---|---|
| `FormMainShell.cs` | Giao diện khung chính, tổ chức Sidebar, Header và vùng hiển thị nội dung. |
| `FormLogin.cs` | Giao diện đăng nhập người dùng. |
| `SessionManager.cs` | Quản lý thông tin phiên đăng nhập và vai trò người dùng. |
| `FormCategoryManagement.cs` | Giao diện quản lý danh mục nhóm hàng. |
| `FormProductManagement.cs` | Giao diện quản lý sản phẩm. |
| `FormCustomerManagement.cs` | Giao diện quản lý khách hàng. |
| `FormPOS.cs` | Giao diện quầy bán hàng POS. |
| `FormQuickReport.cs` | Giao diện báo cáo nhanh. |
| `FormUserManagement.cs` | Giao diện quản lý tài khoản người dùng. |
| `FormRoleManagement.cs` | Giao diện quản lý vai trò. |
| `Form1.cs` | Form Windows Forms bổ sung trong dự án. |
| `Program.cs` | Điểm khởi chạy ứng dụng Windows Forms. |

*Lưu ý: Cây thư mục thể hiện các thành phần nhìn thấy trong Solution Explorer; không đại diện cho toàn bộ tệp bên trong từng thư mục.*

## 🖥️ 4. Nội dung thực hành

### 4.1. Thiết kế giao diện khung chính FormMainShell

Xây dựng giao diện điều khiển trung tâm theo kiến trúc Single-Form, gồm ba khu vực:

- **Sidebar:** Thanh điều hướng bên trái, chứa logo MiniMart POS và các nút chức năng.
- **Top Header:** Thanh tiêu đề, hiển thị tên màn hình và thông tin người dùng.
- **Main Content:** Vùng nội dung trung tâm dùng để hiển thị các màn hình nghiệp vụ.

Các chức năng điều hướng chính gồm:

- Bán hàng (POS).
- Quản lý danh mục.
- Quản lý sản phẩm.
- Quản lý khách hàng.
- Báo cáo doanh thu.
- Quản trị tài khoản.
- Đăng xuất.

### 4.2. Nhúng Form con vào vùng nội dung trung tâm

Tổ chức các màn hình nghiệp vụ trong `panelMainContent`, hạn chế việc mở nhiều cửa sổ độc lập.

Các thuộc tính quan trọng khi nhúng Form con:

- `TopLevel = false`: Chuyển Form con thành thành phần có thể nhúng vào Form cha.
- `FormBorderStyle = None`: Loại bỏ đường viền cửa sổ.
- `Dock = Fill`: Cho Form con lấp đầy vùng nội dung.
- `Controls.Clear()`: Xóa các điều khiển cũ trong vùng hiển thị trước khi nạp màn hình mới.
- `BringToFront()` và `Show()`: Đưa Form con lên trước và hiển thị giao diện.

### 4.3. Điều hướng và làm nổi bật chức năng đang chọn

Khi người dùng chọn một chức năng trên Sidebar:

- Mở Form nghiệp vụ tương ứng trong vùng nội dung trung tâm.
- Cập nhật tiêu đề màn hình trên Header.
- Đổi màu nút chức năng đang được chọn để người dùng dễ nhận biết.
- Đóng Form con đang hoạt động trước khi chuyển sang Form khác.

### 4.4. Phân quyền giao diện theo vai trò người dùng

Sử dụng cơ chế Role-Based Access Control (RBAC) để điều chỉnh các chức năng hiển thị theo vai trò đăng nhập.

| Vai trò | Chức năng được phép truy cập |
|---|---|
| **Admin** | Bán hàng POS, quản lý danh mục, sản phẩm, khách hàng, báo cáo doanh thu và tài khoản người dùng. |
| **Cashier** | Bán hàng POS và quản lý khách hàng. |
| **Warehouse** | Quản lý danh mục và sản phẩm, phục vụ công việc kho hàng. |

Cơ chế phân quyền giao diện sử dụng thuộc tính `Visible` của các nút chức năng để ẩn hoặc hiện menu theo vai trò.

Đối với vai trò không hợp lệ, ứng dụng hiển thị cảnh báo và đóng giao diện khung chính.

### 4.5. Hiển thị thông tin phiên đăng nhập

Sử dụng `SessionManager` để truy xuất thông tin phiên đăng nhập, bao gồm:

- Tên tài khoản đang đăng nhập.
- Vai trò hiện tại của người dùng.
- Thông tin phiên phục vụ điều hướng và phân quyền giao diện.

Thông tin người dùng được hiển thị trên Header của `FormMainShell`.

### 4.6. Xử lý chức năng đăng xuất

Tổ chức chức năng đăng xuất trên Sidebar:

- Hiển thị hộp thoại xác nhận đăng xuất.
- Xóa thông tin phiên đăng nhập hiện tại.
- Ẩn giao diện khung chính.
- Mở lại màn hình đăng nhập.
- Đóng giao diện khung chính sau khi hoàn tất quá trình chuyển màn hình.

## 🚀 5. Hướng dẫn chạy và kiểm thử

### Bước 1: Khởi chạy Backend

1. Mở Solution bằng Visual Studio.
2. Chọn `MiniSupermarket.API` làm Startup Project.
3. Nhấn `F5` để chạy ứng dụng API.
4. Kiểm tra địa chỉ và cổng API đang hoạt động.

### Bước 2: Khởi chạy WinForms Client

1. Đảm bảo địa chỉ API được cấu hình chính xác trong ứng dụng WinForms.
2. Chọn `MiniSupermarket.WinForm` làm Startup Project.
3. Nhấn `F5` để chạy ứng dụng.
4. Đăng nhập bằng tài khoản phù hợp với vai trò cần kiểm thử.

### Bước 3: Kiểm thử phân quyền giao diện

Có thể sử dụng bộ tài khoản mẫu trong tài liệu thực hành để kiểm tra:

| Tài khoản mẫu | Vai trò | Kết quả mong đợi |
|---|---|---|
| `admin01` | Admin | Hiển thị đầy đủ các chức năng. |
| `cashier01` | Cashier | Chỉ hiển thị Bán hàng POS và Khách hàng. |
| `ware01` | Warehouse | Chỉ hiển thị Quản lý danh mục và Quản lý sản phẩm. |

Mật khẩu mẫu theo tài liệu thực hành: `123456`.

*Các tài khoản trên là dữ liệu kiểm thử được cung cấp trong tài liệu; cần bảo đảm chúng đã được tạo trong hệ thống trước khi đăng nhập.*

### Bước 4: Kiểm thử điều hướng

- Chọn từng nút trên Sidebar.
- Kiểm tra Form nghiệp vụ được hiển thị trong vùng nội dung trung tâm.
- Kiểm tra tiêu đề Header thay đổi tương ứng.
- Kiểm tra màu nút chức năng đang được chọn.
- Kiểm tra chức năng đăng xuất và quay lại màn hình đăng nhập.

## 👨‍💻 6. Thông tin sinh viên

- **Họ và tên:** Nguyễn Quốc Vương
- **Mã sinh viên:** 2124110272
- **Lớp học phần:** CCQ2411D
>>>>>>> buoi5
