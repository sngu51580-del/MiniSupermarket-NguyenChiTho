using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Yêu cầu đăng nhập chung cho toàn bộ controller
    public class CategoriesController : ControllerBase
    {
        private static readonly List<Category> _categories = new() {
            new Category { CategoryId = 1, CategoryName = "Bánh kẹo & Đồ ăn vặt", Description = "Snack, bánh quy, kẹo dẻo" },
            new Category { CategoryId = 2, CategoryName = "Nước giải khát & Trà", Description = "Nước ngọt, nước khoáng, trà" },
            new Category { CategoryId = 3, CategoryName = "Sữa & Sản phẩm từ sữa", Description = "Sữa tươi, sữa chua, phô mai" },
            new Category { CategoryId = 4, CategoryName = "Mì gói & Thực phẩm ăn liền", Description = "Mì ăn liền, phở khô, cháo gói" },
            new Category { CategoryId = 5, CategoryName = "Gia vị & Dầu ăn", Description = "Nước mắm, hạt nêm, dầu thực vật" }
        };

        // Xem tất cả: Cả Admin và Cashier đều truy cập được
        [HttpGet]
        [Authorize(Roles = "Admin,Cashier")]
        public IActionResult GetAll() => Ok(_categories);

        // Xem theo ID: Cả Admin và Cashier đều truy cập được
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Cashier")]
        public IActionResult GetById(int id)
        {
            var cat = _categories.FirstOrDefault(c => c.CategoryId == id);
            return cat == null ? NotFound(new { message = "Không tìm thấy nhóm hàng!" }) : Ok(cat);
        }

        // Tìm kiếm: Cả Admin và Cashier đều truy cập được
        [HttpGet("search")]
        [Authorize(Roles = "Admin,Cashier")]
        public IActionResult Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return BadRequest(new { message = "Vui lòng nhập từ khóa!" });
            var res = _categories.Where(c => c.CategoryName.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(res);
        }

        // Thêm mới: Chỉ Admin có quyền
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] Category newCat)
        {
            if (string.IsNullOrWhiteSpace(newCat.CategoryName)) return BadRequest(new { message = "Tên không được trống!" });
            newCat.CategoryId = _categories.Count > 0 ? _categories.Max(c => c.CategoryId) + 1 : 1;
            _categories.Add(newCat);
            return CreatedAtAction(nameof(GetById), new { id = newCat.CategoryId }, newCat);
        }

        // Cập nhật: Chỉ Admin có quyền
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, [FromBody] Category updateCat)
        {
            if (string.IsNullOrWhiteSpace(updateCat.CategoryName)) return BadRequest(new { message = "Tên không được trống!" });

            var cat = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (cat == null) return NotFound(new { message = "Không tìm thấy nhóm hàng cần sửa!" });

            cat.CategoryName = updateCat.CategoryName;
            cat.Description = updateCat.Description;
            return NoContent();
        }

        // Xóa: Chỉ Admin có quyền
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var cat = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (cat == null) return NotFound(new { message = "Không tìm thấy nhóm hàng cần xóa!" });

            _categories.Remove(cat);
            return NoContent();
        }

        // Dashboard dành riêng cho Admin
        [HttpGet("admin-dashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminDashboard() => Ok(new { message = "Chào mừng Admin!" });

        // Màn hình POS cho nhân viên
        [HttpGet("staff-pos")]
        [Authorize(Roles = "Admin,Cashier")]
        public IActionResult GetStaffPos() => Ok(new { message = "Màn hình POS sẵn sàng!" });
    }
}