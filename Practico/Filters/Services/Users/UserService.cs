using DataAccess.Repositories.UserDataAccess;
using Domain;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Add(User user)
        {
            bool existUser = _userRepository.Exists(user.UserName);
            if (!existUser)
            {
                _userRepository.Add(user);
            }
            else
            {
                throw new Exception($"User with prop: UserName and value: {user.UserName} already exists");
            }

            return user;
        }

        public void DeleteByUserName(string userName)
        {
           var user = GetByUserName(userName);
            if (_userRepository.Exists(user.UserName))
            {
                _userRepository.DeleteUser(user);
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public List<User> GetAll(string userName)
        {
            return _userRepository.GetAllUsers()
                .Where(m =>
                (string.IsNullOrEmpty(userName) || m.UserName.Contains(userName)))
                .ToList();
        }

        public User GetByUserName(string userName)
        {
            List<User> users = _userRepository.GetAllUsers();
            var user = users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public void Update(string userName, string password)
        {
            var user = GetByUserName(userName);

            if (!string.IsNullOrEmpty(password))
            {
                _userRepository.UpdateUser(userName, password);
            }
        }

        public List<User> GetUsers(int pageNumber, int pageSize)
        {
            return _userRepository.GetUsers(pageNumber, pageSize);
        }

        public User GetUserById(Guid userId)
        {
            List<User> Users = _userRepository.GetAllUsers()
                .Where(m =>(m.Id.Equals(userId)))
                .ToList();
            return Users[0];
        }
    }
}
