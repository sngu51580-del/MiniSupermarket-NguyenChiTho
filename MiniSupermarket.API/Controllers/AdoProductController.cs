/*
 * Họ và tên sinh viên: Nguyễn Chí Thọ
 * Bài tập: Buổi 5 - Tiết 2: API Tra cứu Barcode & Mô hình ngắt kết nối DataTable
 * Mô tả: Controller ADO.NET thuần - Tra cứu mã vạch siêu tốc và demo DataTable ngắt kết nối (bất đồng bộ async/await)
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MiniSupermarket.API.Dto;
using System.Data;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/ado-products")]
    [ApiController]
    public class AdoProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Constructor tiêm IConfiguration để đọc chuỗi kết nối từ appsettings.json
        public AdoProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // =========================================================================
        // THAO TÁC 1: TRA CỨU THEO MÃ VẠCH (CONNECTED MODE - SQLDATAREADER)
        // =========================================================================
        // GET: api/ado-products/barcode/8930000001041
        [HttpGet("barcode/{barcode}")]
        public async Task<IActionResult> GetProductByBarcode(string barcode)
        {
            // 1. Kiểm tra tính hợp lệ của tham số đầu vào
            if (string.IsNullOrWhiteSpace(barcode))
            {
                return BadRequest(new { message = "Mã vạch không được để trống!" });
            }

            // 2. Lấy chuỗi kết nối tới SQL Server
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            // 3. Sử dụng khối await using để đảm bảo SqlConnection luôn được đóng và giải phóng bất đồng bộ
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 4. Câu lệnh SELECT có tham số hóa @Barcode chống SQL Injection
                string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity 
                                 FROM Products 
                                 WHERE Barcode = @Barcode";

                await using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // 5. Gán giá trị an toàn qua SqlParameter
                    command.Parameters.AddWithValue("@Barcode", barcode.Trim());

                    try
                    {
                        // 6. Mở kết nối vật lý tới SQL Server bất đồng bộ
                        await connection.OpenAsync();

                        // 7. Khởi tạo luồng đọc nhanh Forward-Only SqlDataReader bất đồng bộ
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            // 8. Đọc bản ghi: await reader.ReadAsync() trả về true nếu tìm thấy dòng dữ liệu
                            if (await reader.ReadAsync())
                            {
                                var productDto = new ProductLookupDto
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    Barcode = reader["Barcode"].ToString() ?? string.Empty,
                                    ProductName = reader["ProductName"].ToString() ?? string.Empty,
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                                };

                                // Trả về mã 200 OK kèm dữ liệu sản phẩm
                                return Ok(productDto);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Bắt lỗi nếu kết nối CSDL gặp sự cố
                        return StatusCode(500, new { message = "Lỗi truy vấn SQL: " + ex.Message });
                    }
                }
            }

            // 9. Nếu không tìm thấy sản phẩm nào khớp mã vạch -> Trả về 404 Not Found
            return NotFound(new { message = $"Không tìm thấy sản phẩm có mã vạch: {barcode}" });
        }

        // =========================================================================
        // THAO TÁC 2: TẢI DANH SÁCH LƯU ĐỆM (DISCONNECTED MODE - DATATABLE & ADAPTER)
        // =========================================================================
        // GET: api/ado-products/disconnected-cache
        [HttpGet("disconnected-cache")]
        public async Task<IActionResult> GetProductsDisconnected()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            // 1. Khởi tạo bảng ảo DataTable trên RAM
            DataTable productTable = new DataTable("CachedProducts");

            // 2. Mở kết nối và sử dụng SqlDataAdapter để nạp dữ liệu bất đồng bộ
            await Task.Run(() =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity 
                                     FROM Products 
                                     ORDER BY ProductId ASC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(productTable);
                        }
                    }
                }
            });

            // 3. Thao tác độc lập trên bộ nhớ RAM (Không cần kết nối tới SQL Server nữa)
            var resultList = new List<ProductLookupDto>();

            foreach (DataRow row in productTable.Rows)
            {
                resultList.Add(new ProductLookupDto
                {
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    Barcode = row["Barcode"].ToString() ?? string.Empty,
                    ProductName = row["ProductName"].ToString() ?? string.Empty,
                    Price = Convert.ToDecimal(row["Price"]),
                    StockQuantity = Convert.ToInt32(row["StockQuantity"])
                });
            }

            // Trả về danh sách sản phẩm đã được lưu đệm trên RAM
            return Ok(new
            {
                totalLoaded = productTable.Rows.Count,
                cachedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                data = resultList
            });
        }

        // =========================================================================
        // BÀI TẬP 2.1: TRA CỨU THEO KHOẢNG TỒN KHO (SQLDATAREADER CẢNH BÁO NHẬP HÀNG)
        // =========================================================================
        // GET: api/ado-products/filter-stock?minStock=50
        [HttpGet("filter-stock")]
        public async Task<IActionResult> GetProductsLowStock([FromQuery] int minStock = 50)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            var lowStockList = new List<ProductLookupDto>();

            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity 
                                 FROM Products 
                                 WHERE StockQuantity <= @MinStock 
                                 ORDER BY StockQuantity ASC";

                await using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MinStock", minStock);

                    try
                    {
                        await connection.OpenAsync();
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lowStockList.Add(new ProductLookupDto
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    Barcode = reader["Barcode"].ToString() ?? string.Empty,
                                    ProductName = reader["ProductName"].ToString() ?? string.Empty,
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new { message = "Lỗi truy vấn SQL: " + ex.Message });
                    }
                }
            }

            return Ok(new
            {
                filter = $"Tồn kho <= {minStock}",
                totalFound = lowStockList.Count,
                data = lowStockList
            });
        }

        // =========================================================================
        // BÀI TẬP 2.2: ĐẾM SỐ LƯỢNG SẢN PHẨM THEO TỪNG NHÓM DANH MỤC BẰNG DATATABLE
        // =========================================================================
        // GET: api/ado-products/category-summary
        [HttpGet("category-summary")]
        public async Task<IActionResult> GetCategorySummary()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            DataTable categorySummaryTable = new DataTable("CategorySummary");

            await Task.Run(() =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT CategoryId, COUNT(*) AS Total 
                                     FROM Products 
                                     GROUP BY CategoryId 
                                     ORDER BY CategoryId ASC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(categorySummaryTable);
                        }
                    }
                }
            });

            var summaryList = new List<CategoryProductSummaryDto>();
            foreach (DataRow row in categorySummaryTable.Rows)
            {
                summaryList.Add(new CategoryProductSummaryDto
                {
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    TotalProducts = Convert.ToInt32(row["Total"])
                });
            }

            return Ok(new
            {
                totalCategories = categorySummaryTable.Rows.Count,
                data = summaryList
            });
        }
    }
}
