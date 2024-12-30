namespace YourNamespace.Models
{
    public class User
    {
        public required string Id { get; set; } // MongoDB Id
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; } // Store hashed passwords
        public required int Role { get; set; } // 1: Admin, 2: Tacir, 3: User
    }
}