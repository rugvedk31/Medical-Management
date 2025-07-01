namespace MedicalStoreManagement.entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Optional: Constructor
        public User() { }

        public User(int userId, string username, string password)
        {
            UserId = userId;
            Username = username;
            Password = password;
        }
    }
}
