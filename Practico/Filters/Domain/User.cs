namespace Domain
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User() { }

        public User(string username, string password, string role)
        {
            UserName = username;
            Password = password;
            Role = role;
        }
    }
}
