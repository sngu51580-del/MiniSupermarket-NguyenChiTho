/*
 * Họ và tên sinh viên: Nguyễn Chí Thọ
 * Bài tập: Buổi 5 - Tiết 5: Hiện thực hóa API thanh toán POS bọc trong SqlTransaction & Kịch bản kiểm thử
 * Mô tả: API Thanh toán POS đa bảng và Hủy đơn hàng được bảo vệ trọn vẹn bởi SqlTransaction (ACID),
 *       sử dụng cấu trúc dữ liệu chuẩn của dự án trong /Data (SupermarketDbContext) kết hợp async/await.
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MiniSupermarket.API.Dto;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CheckoutController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // =========================================================================
        // POST: api/checkout
        // Chức năng: Thanh toán hóa đơn, trừ tồn kho và tích điểm trong 1 Transaction
        // =========================================================================
        [HttpPost]
        public async Task<IActionResult> ProcessCheckout([FromBody] CheckoutRequestDto request)
        {
            // 1. Kiểm tra tính hợp lệ của giỏ hàng
            if (request.Items == null || request.Items.Count == 0)
            {
                return BadRequest(new { message = "Giỏ hàng rỗng, không thể tiến hành thanh toán!" });
            }

            if (string.IsNullOrWhiteSpace(request.CashierUsername))
            {
                return BadRequest(new { message = "Thiếu thông tin tài khoản thu ngân lập hóa đơn!" });
            }

            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // 2. KHỞI TẠO TRANSACTION (Bắt đầu phiên giao dịch khép kín bảo vệ ACID)
                SqlTransaction transaction = (SqlTransaction)await connection.BeginTransactionAsync();

                try
                {
                    // 2.1. Tra cứu UserId tương ứng với CashierUsername từ bảng Users trong /Data
                    string findUserSql = "SELECT TOP 1 Id FROM Users WHERE Username = @Username";
                    int userId = 3; // Mặc định là thungan_mai (Id = 3) nếu không tìm thấy

                    await using (SqlCommand cmdUser = new SqlCommand(findUserSql, connection, transaction))
                    {
                        cmdUser.Parameters.AddWithValue("@Username", request.CashierUsername.Trim());
                        object? objUserId = await cmdUser.ExecuteScalarAsync();
                        if (objUserId != null && objUserId != DBNull.Value)
                        {
                            userId = Convert.ToInt32(objUserId);
                        }
                    }

                    // 2.1b. Nếu chưa có CustomerId nhưng có CustomerPhone, tra cứu CustomerId
                    if (request.CustomerId <= 0 && !string.IsNullOrWhiteSpace(request.CustomerPhone))
                    {
                        string findCustSql = "SELECT TOP 1 CustomerId FROM Customers WHERE PhoneNumber = @Phone";
                        await using (SqlCommand cmdCust = new SqlCommand(findCustSql, connection, transaction))
                        {
                            cmdCust.Parameters.AddWithValue("@Phone", request.CustomerPhone.Trim());
                            object? objCustId = await cmdCust.ExecuteScalarAsync();
                            if (objCustId != null && objCustId != DBNull.Value)
                            {
                                request.CustomerId = Convert.ToInt32(objCustId);
                            }
                        }
                    }

                    // 2.2. Tính toán tổng tiền, tổng số lượng và điểm thưởng tích lũy
                    decimal originalAmount = request.Items.Sum(i => i.Quantity * i.UnitPrice);
                    int totalItems = request.Items.Sum(i => i.Quantity);
                    int pointsToRedeem = Math.Max(0, request.PointsToRedeem);
                    decimal discountFromPoints = 0;

                    // Tiêu chí 47: Kiểm tra & Trừ tiền hóa đơn từ điểm tích lũy (1 điểm = 1.000 VNĐ)
                    if (pointsToRedeem > 0 && request.CustomerId > 0)
                    {
                        string checkPointsSql = "SELECT RewardPoints FROM Customers WHERE CustomerId = @CustomerId";
                        int availablePoints = 0;
                        await using (SqlCommand cmdGetPts = new SqlCommand(checkPointsSql, connection, transaction))
                        {
                            cmdGetPts.Parameters.AddWithValue("@CustomerId", request.CustomerId);
                            object? objPts = await cmdGetPts.ExecuteScalarAsync();
                            if (objPts != null && objPts != DBNull.Value)
                            {
                                availablePoints = Convert.ToInt32(objPts);
                            }
                        }

                        if (availablePoints < pointsToRedeem)
                        {
                            throw new InvalidOperationException(
                                $"Khách hàng không đủ điểm thưởng để quy đổi! (Điểm hiện có: {availablePoints}, Yêu cầu dùng: {pointsToRedeem})");
                        }

                        discountFromPoints = pointsToRedeem * 1000m;
                    }

                    decimal finalAmount = Math.Max(0, originalAmount - discountFromPoints);
                    int rewardPoints = (int)(originalAmount / 10000); // 10.000đ = 1 điểm tích lũy mới theo tổng tiền hàng
                    string orderCode = $"HD-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";

                    // =====================================================================
                    // BƯỚC 1: TẠO HÓA ĐƠN TỔNG THỂ TRONG BẢNG Orders
                    // =====================================================================
                    string insertOrderSql = @"
                        INSERT INTO Orders (UserId, OrderDate, TotalAmount, Status, PaymentMethod, AmountReceived, ChangeAmount)
                        OUTPUT INSERTED.OrderId
                        VALUES (@UserId, GETDATE(), @TotalAmount, 'Completed', @PaymentMethod, @AmountReceived, 0)";

                    int orderId = 0;
                    await using (SqlCommand cmdOrder = new SqlCommand(insertOrderSql, connection, transaction))
                    {
                        cmdOrder.Parameters.AddWithValue("@UserId", userId);
                        cmdOrder.Parameters.AddWithValue("@TotalAmount", finalAmount);
                        cmdOrder.Parameters.AddWithValue("@PaymentMethod", string.IsNullOrWhiteSpace(request.PaymentMethod) ? "Cash" : request.PaymentMethod);
                        cmdOrder.Parameters.AddWithValue("@AmountReceived", finalAmount);

                        object? objOrderId = await cmdOrder.ExecuteScalarAsync();
                        orderId = Convert.ToInt32(objOrderId);
                    }

                    // =====================================================================
                    // BƯỚC 2 & 3: XỬ LÝ TỪNG MÓN HÀNG (KIỂM TRA TỒN KHO, LƯU CHI TIẾT VÀ TRỪ KHO)
                    // =====================================================================
                    foreach (var item in request.Items)
                    {
                        // 3.1. Kiểm tra số lượng tồn kho thực tế trước khi trừ
                        string checkStockSql = "SELECT StockQuantity, ProductName FROM Products WHERE ProductId = @ProductId";
                        int currentStock = 0;
                        string productName = string.Empty;

                        await using (SqlCommand cmdCheck = new SqlCommand(checkStockSql, connection, transaction))
                        {
                            cmdCheck.Parameters.AddWithValue("@ProductId", item.ProductId);

                            await using (SqlDataReader reader = await cmdCheck.ExecuteReaderAsync())
                            {
                                if (!await reader.ReadAsync())
                                {
                                    throw new InvalidOperationException($"Không tìm thấy sản phẩm có ID: {item.ProductId}");
                                }
                                currentStock = Convert.ToInt32(reader["StockQuantity"]);
                                productName = reader["ProductName"].ToString() ?? string.Empty;
                            }
                        }

                        // 3.2. ĐIỂM KIỂM SOÁT LOGIC: Nếu số lượng mua vượt quá tồn kho -> Kích hoạt Exception để Rollback
                        if (currentStock < item.Quantity)
                        {
                            throw new InvalidOperationException(
                                $"Sản phẩm '{productName}' (ID: {item.ProductId}) không đủ tồn kho! " +
                                $"(Tồn kho thực tế: {currentStock}, Số lượng yêu cầu mua: {item.Quantity})");
                        }

                        // 3.3. Thêm dòng chi tiết vào bảng OrderDetails (cột SubTotal theo /Data)
                        string insertDetailSql = @"
                            INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice, SubTotal)
                            VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice, @SubTotal)";

                        await using (SqlCommand cmdDetail = new SqlCommand(insertDetailSql, connection, transaction))
                        {
                            cmdDetail.Parameters.AddWithValue("@OrderId", orderId);
                            cmdDetail.Parameters.AddWithValue("@ProductId", item.ProductId);
                            cmdDetail.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmdDetail.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                            cmdDetail.Parameters.AddWithValue("@SubTotal", item.Quantity * item.UnitPrice);
                            await cmdDetail.ExecuteNonQueryAsync();
                        }

                        // 3.4. Khấu trừ số lượng tồn kho trong bảng Products
                        string updateStockSql = @"
                            UPDATE Products 
                            SET StockQuantity = StockQuantity - @Qty 
                            WHERE ProductId = @ProductId";

                        await using (SqlCommand cmdStock = new SqlCommand(updateStockSql, connection, transaction))
                        {
                            cmdStock.Parameters.AddWithValue("@Qty", item.Quantity);
                            cmdStock.Parameters.AddWithValue("@ProductId", item.ProductId);
                            await cmdStock.ExecuteNonQueryAsync();
                        }
                    }

                    // =====================================================================
                    // BƯỚC 4: CẬP NHẬT ĐIỂM TÍCH LŨY CHO KHÁCH HÀNG (CỘNG ĐIỂM MỚI & TRỪ ĐIỂM ĐỔI)
                    // =====================================================================
                    if (request.CustomerId > 0 && (rewardPoints > 0 || pointsToRedeem > 0))
                    {
                        int netPointsDiff = rewardPoints - pointsToRedeem;
                        string updatePointsSql = @"
                            UPDATE Customers 
                            SET RewardPoints = CASE WHEN RewardPoints + @NetPoints < 0 THEN 0 ELSE RewardPoints + @NetPoints END,
                                MembershipRank = CASE 
                                    WHEN RewardPoints + @NetPoints >= 1000 THEN N'Kim Cương'
                                    WHEN RewardPoints + @NetPoints >= 500 THEN N'Vàng'
                                    WHEN RewardPoints + @NetPoints >= 200 THEN N'Bạc'
                                    WHEN RewardPoints + @NetPoints >= 50 THEN N'Thân Thiết'
                                    ELSE N'Mới'
                                END
                            WHERE CustomerId = @CustomerId";

                        await using (SqlCommand cmdCustomer = new SqlCommand(updatePointsSql, connection, transaction))
                        {
                            cmdCustomer.Parameters.AddWithValue("@NetPoints", netPointsDiff);
                            cmdCustomer.Parameters.AddWithValue("@CustomerId", request.CustomerId);
                            await cmdCustomer.ExecuteNonQueryAsync();
                        }
                    }

                    // =====================================================================
                    // BƯỚC 5: XÁC NHẬN LƯU VĨNH VIỄN TOÀN BỘ THAO TÁC (COMMIT)
                    // =====================================================================
                    await transaction.CommitAsync();

                    return Ok(new
                    {
                        success = true,
                        message = pointsToRedeem > 0 
                            ? $"Thanh toán thành công! Đã quy đổi {pointsToRedeem} điểm giảm {discountFromPoints:N0} đ!"
                            : "Thanh toán hóa đơn POS thành công!",
                        orderId = orderId,
                        orderCode = orderCode,
                        totalItems = totalItems,
                        originalAmount = originalAmount,
                        pointsRedeemed = pointsToRedeem,
                        discountFromPoints = discountFromPoints,
                        finalAmount = finalAmount,
                        rewardPointsAdded = rewardPoints
                    });
                }
                catch (Exception ex)
                {
                    // =====================================================================
                    // BƯỚC 6: HOÀN TÁC TOÀN BỘ DỮ LIỆU SẠCH SẼ KHI CÓ BẤT KỲ LỖI NÀO (ROLLBACK)
                    // =====================================================================
                    try
                    {
                        await transaction.RollbackAsync();
                    }
                    catch (Exception rollbackEx)
                    {
                        return StatusCode(500, new 
                        { 
                            success = false,
                            message = "Lỗi nghiêm trọng khi thực thi Rollback: " + rollbackEx.Message 
                        });
                    }

                    return BadRequest(new
                    {
                        success = false,
                        message = "Giao dịch thanh toán bị hủy và đã được Rollback an toàn!",
                        errorDetail = ex.Message
                    });
                }
            }
        }

        // =========================================================================
        // BÀI TẬP MỞ RỘNG (TIẾT 5): HỦY ĐƠN HÀNG VÀ HOÀN TRẢ TỒN KHO & ĐIỂM THƯỞNG
        // DELETE: api/checkout/cancel/{orderId}
        // =========================================================================
        [HttpDelete("cancel/{orderId}")]
        [HttpPost("cancel/{orderId}")]
        [HttpPut("cancel/{orderId}")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlTransaction transaction = (SqlTransaction)await connection.BeginTransactionAsync();

                try
                {
                    // 1. Kiểm tra hóa đơn
                    string getOrderSql = "SELECT TotalAmount FROM Orders WHERE OrderId = @OrderId";
                    decimal totalAmount = 0;

                    await using (SqlCommand cmdGet = new SqlCommand(getOrderSql, connection, transaction))
                    {
                        cmdGet.Parameters.AddWithValue("@OrderId", orderId);
                        object? objAmount = await cmdGet.ExecuteScalarAsync();
                        if (objAmount == null || objAmount == DBNull.Value)
                        {
                            throw new InvalidOperationException($"Không tìm thấy hóa đơn ID = {orderId} để hủy!");
                        }
                        totalAmount = Convert.ToDecimal(objAmount);
                    }

                    // 2. Lấy danh sách sản phẩm đã mua để hoàn trả kho
                    var itemsToRestore = new List<(int ProductId, int Quantity)>();
                    string getDetailsSql = "SELECT ProductId, Quantity FROM OrderDetails WHERE OrderId = @OrderId";

                    await using (SqlCommand cmdDetails = new SqlCommand(getDetailsSql, connection, transaction))
                    {
                        cmdDetails.Parameters.AddWithValue("@OrderId", orderId);
                        await using (SqlDataReader reader = await cmdDetails.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                itemsToRestore.Add((
                                    Convert.ToInt32(reader["ProductId"]), 
                                    Convert.ToInt32(reader["Quantity"])
                                ));
                            }
                        }
                    }

                    // 3. Hoàn trả tồn kho trong bảng Products
                    foreach (var item in itemsToRestore)
                    {
                        string restoreStockSql = @"
                            UPDATE Products 
                            SET StockQuantity = StockQuantity + @Qty 
                            WHERE ProductId = @ProductId";

                        await using (SqlCommand cmdRestore = new SqlCommand(restoreStockSql, connection, transaction))
                        {
                            cmdRestore.Parameters.AddWithValue("@Qty", item.Quantity);
                            cmdRestore.Parameters.AddWithValue("@ProductId", item.ProductId);
                            await cmdRestore.ExecuteNonQueryAsync();
                        }
                    }

                    // 4. Khấu trừ điểm thưởng tương ứng
                    int pointsToDeduct = (int)(totalAmount / 10000);
                    if (pointsToDeduct > 0)
                    {
                        string deductPointsSql = @"
                            UPDATE Customers 
                            SET RewardPoints = CASE 
                                WHEN RewardPoints >= @Pts THEN RewardPoints - @Pts 
                                ELSE 0 
                            END 
                            WHERE CustomerId = 1"; // Hoặc CustomerId tương ứng nếu lưu quan hệ

                        await using (SqlCommand cmdDeduct = new SqlCommand(deductPointsSql, connection, transaction))
                        {
                            cmdDeduct.Parameters.AddWithValue("@Pts", pointsToDeduct);
                            await cmdDeduct.ExecuteNonQueryAsync();
                        }
                    }

                    // 5. Xóa chi tiết hóa đơn trước (tránh vi phạm ràng buộc khóa ngoại)
                    string deleteDetailsSql = "DELETE FROM OrderDetails WHERE OrderId = @OrderId";
                    await using (SqlCommand cmdDelDetails = new SqlCommand(deleteDetailsSql, connection, transaction))
                    {
                        cmdDelDetails.Parameters.AddWithValue("@OrderId", orderId);
                        await cmdDelDetails.ExecuteNonQueryAsync();
                    }

                    // 6. Xóa hóa đơn trong bảng Orders
                    string deleteOrderSql = "DELETE FROM Orders WHERE OrderId = @OrderId";
                    await using (SqlCommand cmdDelOrder = new SqlCommand(deleteOrderSql, connection, transaction))
                    {
                        cmdDelOrder.Parameters.AddWithValue("@OrderId", orderId);
                        await cmdDelOrder.ExecuteNonQueryAsync();
                    }

                    // 7. Xác nhận lưu vĩnh viễn (Commit)
                    await transaction.CommitAsync();

                    return Ok(new
                    {
                        success = true,
                        message = $"Đã hủy thành công hóa đơn #{orderId} và hoàn trả toàn bộ tồn kho vào CSDL!"
                    });
                }
                catch (Exception ex)
                {
                    try
                    {
                        await transaction.RollbackAsync();
                    }
                    catch { }

                    return BadRequest(new
                    {
                        success = false,
                        message = "Hủy hóa đơn thất bại, giao dịch đã được Rollback!",
                        errorDetail = ex.Message
                    });
                }
            }
        }
    }
}
