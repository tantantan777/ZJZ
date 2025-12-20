using Microsoft.EntityFrameworkCore;
using TQY.Data;
using TQY.Helpers; // 引用 PasswordHelper
using TQY.Models;

namespace TQY.Services
{
    public class DatabaseService : IDatabaseService
    {
        // 注册新用户
        public async Task<(bool IsSuccess, string Message)> RegisterAsync(string email, string password)
        {
            try
            {
                // 使用 using 确保数据库连接用完即释放
                using var context = new AppDbContext();

                // 1. 检查邮箱是否已被注册
                var exists = await context.Users.AnyAsync(u => u.Email == email);
                if (exists)
                {
                    return (false, "该邮箱已被注册！");
                }

                // 2. 创建新用户
                var user = new User
                {
                    Email = email,
                    Username = email.Split('@')[0], // 默认用户名为邮箱前缀
                    PasswordHash = PasswordHelper.HashPassword(password), // ★ 关键：密码加密存储
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    Role = "User"
                };

                // 3. 写入数据库
                context.Users.Add(user);
                await context.SaveChangesAsync();

                return (true, "注册成功");
            }
            catch (Exception ex)
            {
                return (false, $"注册发生错误: {ex.Message}");
            }
        }
    }
}