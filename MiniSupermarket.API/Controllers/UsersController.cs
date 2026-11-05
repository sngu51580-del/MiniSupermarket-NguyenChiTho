using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public UsersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: /api/users/paged?keyword=...&pageNumber=1&pageSize=5
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedUsers(
            [FromQuery] string? keyword,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1 || pageSize > 50) pageSize = 5;

            var query = _context.Users
                .Include(u => u.Role)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                query = query.Where(u => u.Username.ToLower().Contains(kw) ||
                                        (u.FullName != null && u.FullName.ToLower().Contains(kw)) ||
                                        (u.Role != null && u.Role.RoleName.ToLower().Contains(kw)));
            }

            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var items = await query
                .OrderBy(u => u.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    FullName = u.FullName,
                    Role = u.Role != null ? u.Role.RoleName : "Cashier",
                    IsActive = true
                })
                .ToListAsync();

            var response = new PagedResult<UserDto>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages == 0 ? 1 : totalPages,
                Items = items
            };

            return Ok(response);
        }

        // GET: /api/users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users
                .Include(u => u.Role)
                .OrderBy(u => u.Id)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    FullName = u.FullName,
                    Role = u.Role != null ? u.Role.RoleName : "Cashier",
                    IsActive = true
                })
                .ToListAsync();

            return Ok(users);
        }

        // POST: /api/users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Tên đăng nhập và mật khẩu không được để trống!" });
            }

            var exists = await _context.Users.AnyAsync(u => u.Username.ToLower() == request.Username.Trim().ToLower());
            if (exists)
            {
                return BadRequest(new { message = "Tên đăng nhập đã tồn tại!" });
            }

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName.ToLower() == request.Role.Trim().ToLower());
            int roleId = role?.Id ?? 2; // Default to Cashier (Id=2)

            var newUser = new User
            {
                Username = request.Username.Trim(),
                Password = request.Password.Trim(),
                FullName = string.IsNullOrWhiteSpace(request.FullName) ? request.Username.Trim() : request.FullName.Trim(),
                RoleId = roleId
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Tạo tài khoản thành công!",
                user = new UserDto
                {
                    Id = newUser.Id,
                    Username = newUser.Username,
                    FullName = newUser.FullName,
                    Role = role?.RoleName ?? "Cashier",
                    IsActive = true
                }
            });
        }

        // PUT: /api/users/{id}/reset-password
        [HttpPut("{id}/reset-password")]
        public async Task<IActionResult> ResetPassword(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy người dùng!" });
            }

            user.Password = "123456";
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đặt lại mật khẩu thành công về 123456!" });
        }

        // DELETE: /api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy người dùng!" });
            }

            if (user.Username.ToLower() == "coba_chutiem" || user.Username.ToLower() == "admin01")
            {
                return BadRequest(new { message = "Không thể xóa tài khoản Chủ tiệm gốc (coba_chutiem)!" });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Xóa tài khoản thành công!" });
        }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }

    public class CreateUserRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Cashier";
    }
}
