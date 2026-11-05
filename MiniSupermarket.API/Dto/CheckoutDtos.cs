/*
 * Họ và tên sinh viên: Nguyễn Chí Thọ
 * DTO: Nghiệp vụ thanh toán giỏ hàng POS
 */
namespace MiniSupermarket.API.Dto
{
    // DTO biểu diễn từng dòng sản phẩm trong giỏ hàng
    public class CartItemCheckoutDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    // DTO nhận yêu cầu thanh toán tổng thể từ máy POS
    public class CheckoutRequestDto
    {
        // Tài khoản thu ngân đang đứng ca trực (ví dụ: cashier01, cashier02...)
        public string CashierUsername { get; set; } = string.Empty;

        // Mã định danh khách hàng (nếu là khách vãng lai, truyền CustomerId = 15)
        public int CustomerId { get; set; }

        // Số điện thoại khách hàng tra cứu tích điểm
        public string? CustomerPhone { get; set; }

        // Phương thức thanh toán (Cash / Transfer)
        public string PaymentMethod { get; set; } = "Cash";

        // Số điểm tích lũy muốn đổi trừ tiền hóa đơn (Tiêu chí 47: 1 điểm = 1.000 VNĐ)
        public int PointsToRedeem { get; set; } = 0;

        // Danh sách các món hàng cần thanh toán
        public List<CartItemCheckoutDto> Items { get; set; } = new();
    }
}
