using YourNamespace.Models;
using System.Threading.Tasks;

namespace YourNamespace.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}