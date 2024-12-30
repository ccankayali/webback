namespace YourNamespace.Models
{
    public class LoginResult
    {
        public string Message { get; set; }
        public int Role { get; set; }
        public string SessionHash { get; set; }
        
        // name
        public string Username { get; set; }

    }

}