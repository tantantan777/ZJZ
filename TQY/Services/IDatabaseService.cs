namespace TQY.Services
{
    public interface IDatabaseService
    {
        Task<(bool IsSuccess, string Message)> RegisterAsync(string email, string password);
    }
}