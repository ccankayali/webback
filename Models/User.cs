namespace YourNamespace.Models
{
    public class User
    {
        public required string Id { get; set; } // MongoDB Id
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; } // Store hashed passwords
        public List<string> Roles { get; set; } = new List<string>(); // User roles
    }
}
