/*
 * Họ và tên sinh viên: Nguyễn Chí Thọ
 * Bài tập: Buổi 5 - Tiết 3: Tối ưu truy vấn với Stored Procedure & Báo cáo doanh thu ca bán lẻ
 * Mô tả: Controller ADO.NET thực thi Stored Procedure xuất báo cáo ca bán dựa trên dữ liệu bảng Orders và Users (bất đồng bộ async/await)
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Dto;
using System.Data;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SupermarketDbContext _context;

        public ReportsController(IConfiguration configuration, SupermarketDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        // =========================================================================
        // GET: api/reports/revenue-by-cashier
        // Chức năng: Thống kê doanh thu theo từng thu ngân
        // =========================================================================
        [HttpGet("revenue-by-cashier")]
        public async Task<IActionResult> GetRevenueByCashier()
        {
            var reportList = new List<CashierRevenueDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                bool useProcedure = true;
                await using (SqlCommand command = new SqlCommand("sp_GetRevenueByCashier", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            await ReadCashierRevenueDataAsync(reader, reportList);
                        }
                    }
                    catch (SqlException ex) when (ex.Number == 2812) // 2812: Không tìm thấy Stored Procedure
                    {
                        useProcedure = false;
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new 
                        { 
                            success = false,
                            message = "Lỗi thực thi Stored Procedure trên SQL Server: " + ex.Message 
                        });
                    }
                }

                // Dự phòng trực tiếp nếu Stored Procedure chưa được tạo trên SQL Server
                if (!useProcedure)
                {
                    string fallbackSql = @"
                        SELECT 
                            u.Username AS CashierUsername,
                            COUNT(o.OrderId) AS TotalOrders,
                            SUM(o.TotalAmount) AS TotalRevenue,
                            CAST(SUM(o.TotalAmount) / 10000 AS INT) AS TotalPointsAwarded
                        FROM Orders o
                        INNER JOIN Users u ON o.UserId = u.Id
                        GROUP BY u.Username
                        ORDER BY TotalRevenue DESC";

                    await using (SqlCommand fallbackCmd = new SqlCommand(fallbackSql, connection))
                    {
                        await using (SqlDataReader reader = await fallbackCmd.ExecuteReaderAsync())
                        {
                            await ReadCashierRevenueDataAsync(reader, reportList);
                        }
                    }
                }
            }

            return Ok(new
            {
                success = true,
                generatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                totalCashiers = reportList.Count,
                grandTotalRevenue = reportList.Sum(x => x.TotalRevenue),
                data = reportList
            });
        }

        // =========================================================================
        // BÀI TẬP 3.1: BÁO CÁO DOANH THU THEO KHOẢNG NGÀY (CÓ THAM SỐ)
        // GET: api/reports/revenue-by-date-range?fromDate=2026-10-01&toDate=2026-10-31
        // =========================================================================
        [HttpGet("revenue-by-date-range")]
        public async Task<IActionResult> GetRevenueByDateRange([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            var reportList = new List<CashierRevenueDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                bool useProcedure = true;

                await using (SqlCommand command = new SqlCommand("sp_GetRevenueByDateRange", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);

                    try
                    {
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            await ReadCashierRevenueDataAsync(reader, reportList);
                        }
                    }
                    catch (SqlException ex) when (ex.Number == 2812)
                    {
                        useProcedure = false;
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new 
                        { 
                            success = false,
                            message = "Lỗi thực thi Stored Procedure theo khoảng ngày: " + ex.Message 
                        });
                    }
                }

                if (!useProcedure)
                {
                    string fallbackSql = @"
                        SELECT 
                            u.Username AS CashierUsername,
                            COUNT(o.OrderId) AS TotalOrders,
                            SUM(o.TotalAmount) AS TotalRevenue,
                            CAST(SUM(o.TotalAmount) / 10000 AS INT) AS TotalPointsAwarded
                        FROM Orders o
                        INNER JOIN Users u ON o.UserId = u.Id
                        WHERE o.OrderDate >= @FromDate AND o.OrderDate <= @ToDate
                        GROUP BY u.Username
                        ORDER BY TotalRevenue DESC";

                    await using (SqlCommand fallbackCmd = new SqlCommand(fallbackSql, connection))
                    {
                        fallbackCmd.Parameters.AddWithValue("@FromDate", fromDate);
                        fallbackCmd.Parameters.AddWithValue("@ToDate", toDate);
                        await using (SqlDataReader reader = await fallbackCmd.ExecuteReaderAsync())
                        {
                            await ReadCashierRevenueDataAsync(reader, reportList);
                        }
                    }
                }
            }

            return Ok(new
            {
                success = true,
                fromDate = fromDate.ToString("yyyy-MM-dd HH:mm:ss"),
                toDate = toDate.ToString("yyyy-MM-dd HH:mm:ss"),
                totalCashiers = reportList.Count,
                grandTotalRevenue = reportList.Sum(x => x.TotalRevenue),
                data = reportList
            });
        }

        // =========================================================================
        // BÀI TẬP 3.2: TOP 5 SẢN PHẨM BÁN CHẠY NHẤT
        // GET: api/reports/top-selling
        // =========================================================================
        [HttpGet("top-selling")]
        public async Task<IActionResult> GetTop5SellingProducts()
        {
            var topList = new List<TopSellingProductDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                bool useProcedure = true;

                await using (SqlCommand command = new SqlCommand("sp_GetTop5SellingProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            await ReadTopSellingDataAsync(reader, topList);
                        }
                    }
                    catch (SqlException ex) when (ex.Number == 2812)
                    {
                        useProcedure = false;
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new 
                        { 
                            success = false,
                            message = "Lỗi thực thi Stored Procedure top sản phẩm: " + ex.Message 
                        });
                    }
                }

                if (!useProcedure)
                {
                    string fallbackSql = @"
                        SELECT TOP 5
                            p.ProductId,
                            p.Barcode,
                            p.ProductName,
                            SUM(od.Quantity) AS TotalQuantitySold,
                            SUM(od.SubTotal) AS TotalSalesAmount
                        FROM OrderDetails od
                        INNER JOIN Products p ON od.ProductId = p.ProductId
                        GROUP BY p.ProductId, p.Barcode, p.ProductName
                        ORDER BY TotalQuantitySold DESC";

                    await using (SqlCommand fallbackCmd = new SqlCommand(fallbackSql, connection))
                    {
                        await using (SqlDataReader reader = await fallbackCmd.ExecuteReaderAsync())
                        {
                            await ReadTopSellingDataAsync(reader, topList);
                        }
                    }
                }
            }

            return Ok(new
            {
                success = true,
                totalProducts = topList.Count,
                data = topList
            });
        }

        // =========================================================================
        // TIÊU CHÍ 44: DASHBOARD 4 THẺ CHỈ SỐ TỔNG QUAN (KPI SUMMARY CARDS)
        // GET: api/reports/dashboard-summary
        // =========================================================================
        [HttpGet("dashboard-summary")]
        public async Task<IActionResult> GetDashboardSummary([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var today = DateTime.Today;

            // 1. Doanh thu hôm nay
            decimal todayRevenue = await _context.Orders
                .Where(o => o.OrderDate.Date == today && o.Status == "Completed")
                .SumAsync(o => (decimal?)o.TotalAmount) ?? 0;

            int todayOrdersCount = await _context.Orders
                .CountAsync(o => o.OrderDate.Date == today);

            // 2. Tổng số hóa đơn toàn hệ thống
            int totalOrders = await _context.Orders.CountAsync();

            decimal periodRevenue = todayRevenue;
            int periodOrdersCount = totalOrders;

            if (fromDate.HasValue && toDate.HasValue)
            {
                DateTime start = fromDate.Value.Date;
                DateTime end = toDate.Value.Date.AddDays(1).AddTicks(-1);

                periodRevenue = await _context.Orders
                    .Where(o => o.OrderDate >= start && o.OrderDate <= end && o.Status == "Completed")
                    .SumAsync(o => (decimal?)o.TotalAmount) ?? 0;

                periodOrdersCount = await _context.Orders
                    .CountAsync(o => o.OrderDate >= start && o.OrderDate <= end);
            }

            // 3. Số lượng khách hàng thành viên
            int totalCustomers = await _context.Customers.CountAsync();

            // 4. Số mặt hàng sắp hết hàng (tồn kho <= 10 theo đúng tiêu chuẩn Tiêu chí 43 & 44)
            int lowStockCount = await _context.Products
                .CountAsync(p => p.StockQuantity <= 10);

            // Tổng doanh thu toàn hệ thống
            decimal grandTotalRevenue = await _context.Orders
                .Where(o => o.Status == "Completed")
                .SumAsync(o => (decimal?)o.TotalAmount) ?? 0;

            var summary = new DashboardSummaryDto
            {
                TodayRevenue = todayRevenue,
                TodayOrdersCount = todayOrdersCount,
                TotalOrders = totalOrders,
                PeriodOrdersCount = periodOrdersCount,
                PeriodRevenue = periodRevenue,
                TotalCustomers = totalCustomers,
                LowStockProductsCount = lowStockCount,
                GrandTotalRevenue = grandTotalRevenue,
                GeneratedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return Ok(new
            {
                success = true,
                data = summary
            });
        }

        // TIÊU CHÍ 45: BIỂU ĐỒ CỘT DOANH THU THEO NGÀY (BAR CHART)
        // GET: api/reports/daily-revenue?fromDate=2026-10-01&toDate=2026-10-31
        // =========================================================================
        [HttpGet("daily-revenue")]
        public async Task<IActionResult> GetDailyRevenue([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            DateTime start = fromDate ?? DateTime.Today.AddDays(-30);
            DateTime end = toDate ?? DateTime.Today.AddDays(1);

            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            var result = new List<DailyRevenueDto>();

            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                bool useProcedure = true;

                // Gọi Stored Procedure sp_GetDailyRevenue (GROUP BY CAST(OrderDate AS DATE))
                await using (SqlCommand command = new SqlCommand("sp_GetDailyRevenue", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FromDate", start);
                    command.Parameters.AddWithValue("@ToDate", end);

                    try
                    {
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                result.Add(new DailyRevenueDto
                                {
                                    Date = Convert.ToDateTime(reader["RevenueDate"]).ToString("yyyy-MM-dd"),
                                    Revenue = Convert.ToDecimal(reader["Revenue"]),
                                    OrderCount = Convert.ToInt32(reader["OrderCount"])
                                });
                            }
                        }
                    }
                    catch (SqlException ex) when (ex.Number == 2812)
                    {
                        useProcedure = false;
                    }
                }

                if (!useProcedure)
                {
                    string fallbackSql = @"
                        SELECT 
                            CAST(OrderDate AS DATE) AS RevenueDate,
                            SUM(TotalAmount) AS Revenue,
                            COUNT(OrderId) AS OrderCount
                        FROM Orders
                        WHERE OrderDate >= @FromDate AND OrderDate <= @ToDate AND Status = 'Completed'
                        GROUP BY CAST(OrderDate AS DATE)
                        ORDER BY RevenueDate ASC";

                    await using (SqlCommand fallbackCmd = new SqlCommand(fallbackSql, connection))
                    {
                        fallbackCmd.Parameters.AddWithValue("@FromDate", start);
                        fallbackCmd.Parameters.AddWithValue("@ToDate", end);
                        await using (SqlDataReader reader = await fallbackCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                result.Add(new DailyRevenueDto
                                {
                                    Date = Convert.ToDateTime(reader["RevenueDate"]).ToString("yyyy-MM-dd"),
                                    Revenue = Convert.ToDecimal(reader["Revenue"]),
                                    OrderCount = Convert.ToInt32(reader["OrderCount"])
                                });
                            }
                        }
                    }
                }
            }
            var dailyData = await _context.Orders
                .Where(o => o.OrderDate >= start && o.OrderDate <= end && o.Status == "Completed")
                .GroupBy(o => o.OrderDate.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Revenue = g.Sum(o => o.TotalAmount),
                    OrderCount = g.Count()
                })
                .OrderBy(x => x.Date)
                .ToListAsync();

            if (result.Count == 0) result = dailyData.Select(x => new DailyRevenueDto
            {
                Date = x.Date.ToString("yyyy-MM-dd"),
                Revenue = x.Revenue,
                OrderCount = x.OrderCount
            }).ToList();

            return Ok(new
            {
                success = true,
                fromDate = start.ToString("yyyy-MM-dd"),
                toDate = end.ToString("yyyy-MM-dd"),
                totalDays = result.Count,
                grandTotalRevenue = result.Sum(x => x.Revenue),
                data = result
            });
        }

        // =========================================================================
        // TIÊU CHÍ 46: THỐNG KÊ TOP 5 SẢN PHẨM BÁN CHẠY NHẤT BẰNG LINQ
        // GET: api/reports/top-selling-linq
        // =========================================================================
        [HttpGet("top-selling-linq")]
        public async Task<IActionResult> GetTop5SellingProductsLinq()
        {
            var topProducts = await _context.OrderDetails
                .Include(od => od.Product)
                .Where(od => od.Product != null)
                .GroupBy(od => new
                {
                    od.ProductId,
                    Barcode = od.Product!.Barcode,
                    ProductName = od.Product.ProductName
                })
                .Select(g => new TopSellingProductDto
                {
                    ProductId = g.Key.ProductId,
                    Barcode = g.Key.Barcode,
                    ProductName = g.Key.ProductName,
                    TotalQuantitySold = g.Sum(x => x.Quantity),
                    TotalSalesAmount = g.Sum(x => x.SubTotal)
                })
                .OrderByDescending(x => x.TotalQuantitySold)
                .Take(5)
                .ToListAsync();

            return Ok(new
            {
                success = true,
                method = "LINQ EF Core (GroupBy -> OrderByDescending -> Take(5))",
                totalProducts = topProducts.Count,
                data = topProducts
            });
        }

        private static async Task ReadCashierRevenueDataAsync(SqlDataReader reader, List<CashierRevenueDto> list)
        {
            while (await reader.ReadAsync())
            {
                list.Add(new CashierRevenueDto
                {
                    CashierUsername = reader["CashierUsername"].ToString() ?? string.Empty,
                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"]),
                    TotalPointsAwarded = reader["TotalPointsAwarded"] != DBNull.Value 
                        ? Convert.ToInt32(reader["TotalPointsAwarded"]) 
                        : 0
                });
            }
        }

        private static async Task ReadTopSellingDataAsync(SqlDataReader reader, List<TopSellingProductDto> list)
        {
            while (await reader.ReadAsync())
            {
                list.Add(new TopSellingProductDto
                {
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    Barcode = reader["Barcode"].ToString() ?? string.Empty,
                    ProductName = reader["ProductName"].ToString() ?? string.Empty,
                    TotalQuantitySold = Convert.ToInt32(reader["TotalQuantitySold"]),
                    TotalSalesAmount = Convert.ToDecimal(reader["TotalSalesAmount"])
                });
            }
        }
    }
}
