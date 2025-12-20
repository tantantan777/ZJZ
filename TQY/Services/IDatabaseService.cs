using TQY.Models;

namespace TQY.Services
{
    public interface IDatabaseService
    {
        Task<(bool IsSuccess, string Message, User? User)> LoginOrRegisterAsync(string email);
    }
}