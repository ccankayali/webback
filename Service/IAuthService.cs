using YourNamespace.Models;
using System.Threading.Tasks;

namespace YourNamespace.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(string username, string email, string password);
        Task<string> LoginAsync(string email, string password);
    }
}