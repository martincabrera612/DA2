namespace WebApi.Services.Users.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
