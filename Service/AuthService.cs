using YourNamespace.Models;
using YourNamespace.Repositories;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace YourNamespace.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> RegisterAsync(string username, string email, string password, int role)
        {
            if (await _userRepository.GetByEmailAsync(email) != null)
                throw new Exception("Email already exists.");

            var passwordHash = HashPassword(password);

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                Role = role
            };

            await _userRepository.AddUserAsync(user);
            return "User registered successfully.";
        }
        public async Task<LoginResult> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null || !VerifyPassword(password, user.PasswordHash))
                throw new Exception("Invalid email or password.");

            var randomHash = GenerateRandomHash(); // Generate a unique hash for this login session.

            return new LoginResult
            {
                Message = "Login successful.",
                Role = user.Role,
                SessionHash = randomHash, // Include the random hash in the result.
                Username = user.Username
            };
        }


        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }

        private string GenerateRandomHash()
        {
            using var rng = RandomNumberGenerator.Create();
            var randomBytes = new byte[32];
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

    }
}