/*
 * Họ và tên sinh viên: Nguyễn Chí Thọ
 * DTO: Top sản phẩm bán chạy nhất
 */
namespace MiniSupermarket.API.Dto
{
    public class TopSellingProductDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int TotalQuantitySold { get; set; }
        public decimal TotalSalesAmount { get; set; }
    }
}
