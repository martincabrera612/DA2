using WebApi.Controllers.Users.Models;
using WebApi.Services.Users.Entities;

namespace WebApi.Services.Users
{
    public class UserService : IUserService
    {
        private static readonly List<User> _users = [];

        public User Add(User user)
        {
            var existUser = _users.Any(m => m.UserName == user.UserName);
            if (existUser)
            {
                throw new Exception($"User with prop: UserName and value: {user.UserName} already exists");
            }

            var userToSave = new User(user.UserName, user.Password);
            _users.Add(userToSave);

            return userToSave;
        }

        public void DeleteByUserName(string userName)
        {
           var user = GetByUserName(userName);
           
           _users.Remove(user);
        }

        public List<User> GetAll(string userName)
        {
            return _users
                .Where(m =>
                (string.IsNullOrEmpty(userName) || m.UserName.Contains(userName)))
                .ToList();
        }

        public User GetByUserName(string userName)
        {
            var user = _users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }

            return user;
        }

        public void UpdateByUserName(string userName, string password)
        {
            var user = GetByUserName(userName);

            if (!string.IsNullOrEmpty(password))
            {
                user.Password = password;
            }
        }
    }
}
