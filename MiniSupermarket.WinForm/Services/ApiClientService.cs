/*
 * Họ tên sinh viên: Nguyen Chi Tho
 * Mô tả: Lớp tĩnh quản lý HttpClient kết nối Web API, tự động gắn JWT Bearer Token
 */
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniSupermarket.WinForms.Services
{
    public static class ApiClientService
    {
        public const string ApiBaseUrl = "http://localhost:5000/api/";

        public static HttpMessageHandler? CustomHandler { get; set; }

        // Khởi tạo một phiên bản HttpClient dùng chung cho toàn ứng dụng
        public static HttpClient Client { get; set; } = new HttpClient
        {
            // Đảm bảo số cổng Port trùng khớp với số Port đang chạy của Web API Backend
            BaseAddress = new Uri(ApiBaseUrl)
        };

        public static HttpClient CreateClient()
        {
            var client = CustomHandler != null
                ? new HttpClient(CustomHandler, disposeHandler: false) { BaseAddress = new Uri(ApiBaseUrl) }
                : new HttpClient { BaseAddress = new Uri(ApiBaseUrl) };
            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
            return client;
        }

        public static void UseCustomHandler(HttpMessageHandler handler)
        {
            CustomHandler = handler;
            Client = CreateClient();
        }

        // Phương thức cập nhật Bearer Token sau khi đăng nhập thành công
        public static void AttachToken(string token)
        {
            Client.DefaultRequestHeaders.Authorization = null; // Xóa token cũ
            if (!string.IsNullOrEmpty(token))
            {
                Client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        // Hàm gọi API đăng nhập lấy Token
        public static async Task<bool> LoginAsync(string username, string password)
        {
            var loginObj = new { Username = username, Password = password };
            var response = await Client.PostAsJsonAsync("auth/login", loginObj);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(jsonString);

                string token = doc.RootElement.GetProperty("token").GetString() ?? string.Empty;
                string role = doc.RootElement.GetProperty("role").GetString() ?? string.Empty;

                SessionManager.JwtToken = token;
                SessionManager.CurrentRole = role;
                SessionManager.CurrentUsername = username;

                // Gắn Bearer Token ngay sau khi đăng nhập thành công
                AttachToken(token);

                return true;
            }
            return false;
        }

        // Hàm gọi API lấy dữ liệu có gắn kèm Bearer Token bảo mật
        public static async Task<string> GetDataWithTokenAsync(string endpoint)
        {
            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                AttachToken(SessionManager.JwtToken);
            }

            var response = await Client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("Phiên làm việc hết hạn hoặc chưa đăng nhập!");
            }
            throw new Exception("Lỗi khi gọi dữ liệu từ Server.");
        }
    }
}
