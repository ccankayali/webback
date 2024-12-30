using YourNamespace.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace YourNamespace.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("Users");
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
        }


        public async Task AddUserAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }
    }
}
