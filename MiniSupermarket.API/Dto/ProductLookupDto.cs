/*
 * Họ và tên sinh viên: Nguyễn Chí Thọ
 * DTO: Tra cứu sản phẩm theo mã vạch và thống kê nhóm danh mục
 */
namespace MiniSupermarket.API.Dto
{
    // DTO tra cứu sản phẩm cho quầy POS
    public class ProductLookupDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }

    // DTO thống kê sản phẩm theo danh mục (Bài tập 2.2)
    public class CategoryProductSummaryDto
    {
        public int CategoryId { get; set; }
        public int TotalProducts { get; set; }
    }
}
