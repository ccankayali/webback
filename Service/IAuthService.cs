using YourNamespace.Models;

namespace YourNamespace.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(string username, string email, string password, int role);
        Task<LoginResult> LoginAsync(string email, string password);
    }
}