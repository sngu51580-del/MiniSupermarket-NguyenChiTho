🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

Môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)
Buổi thực hành: BUỔI 2: BẢO MẬT & PHÂN QUYỀN JWT CHO WEB API

Hệ thống Quản lý Siêu thị Mini — Tích hợp Đăng nhập & Bảo mật Token
## 📝 Tóm tắt công việc đã thực hiện (Buổi 2)

### 1. 🔑 Backend (`MiniSupermarket.API`)
* **Tích hợp thư viện bảo mật:** Cài đặt các gói NuGet `System.IdentityModel.Tokens.Jwt` và `Microsoft.AspNetCore.Authentication.JwtBearer`.
* **Xây dựng `AuthController`:**
  * Tạo endpoint `POST /api/auth/login` tiếp nhận tài khoản/mật khẩu.
  * Lập trình hàm `GenerateJwtToken` mã hóa thông tin người dùng (`Username`, `Role`) thành chuỗi mã JWT Token có thời hạn 2 giờ.
* **Cấu hình Middleware trong `Program.cs`:** 
  * Đăng ký dịch vụ xác thực `JwtBearer` với tham số kiểm tra chữ ký bí mật (`IssuerSigningKey`).
  * Kích hoạt `app.UseAuthentication()` và `app.UseAuthorization()`.
* **Phân quyền Endpoint:**
  * Áp dụng thuộc tính `[Authorize]` để bảo vệ toàn bộ `CategoriesController`.
  * Phân định ranh giới chức năng: `[Authorize(Roles = "Admin")]` cho trang quản trị và `[Authorize(Roles = "Admin,Cashier")]` cho chức năng bán hàng POS.

---

### 2. 🖥️ Frontend Client (`MiniSupermarket.WinForms`)
* **Quản lý phiên làm việc (`SessionManager`):** Tạo lớp tĩnh lưu trữ chuỗi `JwtToken` và `CurrentRole` trong bộ nhớ tạm sau khi đăng nhập.
* **Xây dựng Form đăng nhập (`FormLogin`):**
  * Thiết kế giao diện nhập tài khoản, mật khẩu (ẩn ký tự).
  * Xử lý gọi API đăng nhập, đọc JSON trả về để lấy Token và điều hướng sang Form chính.
* **Cấu hình đính kèm Token khi gọi API:** Cập nhật hàm khởi tạo `HttpClient` tự động đính kèm Header `Authorization: Bearer <token>` đối với mọi yêu cầu gửi lên Web API backend.
* **Cập nhật khởi chạy ứng dụng:** Đổi Form khởi chạy mặc định trong `Program.cs` thành `FormLogin`.

---

### 3. 🧪 Kiểm thử & Xác minh bảo mật
* Kiểm thử bằng Swagger UI:
  * ✅ Trả về **`401 Unauthorized`** khi truy cập API chưa có Token.
  * ✅ Trả về **`200 OK`** khi đăng nhập lấy Token và truy cập đúng chức năng theo quyền.
  * ✅ Trả về **`403 Forbidden`** khi dùng tài khoản Thu ngân (`Cashier`) cố truy cập khu vực Quản lý (`Admin`).
👨‍💻 5. Tác giả
Họ tên sinh viên: Nguyễn Quốc Vương


Mã sinh viên: 2124110272


Lớp học phần: CCQ2411D
