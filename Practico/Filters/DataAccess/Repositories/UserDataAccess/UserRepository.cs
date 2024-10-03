using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.UserDataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Set<User>().Add(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            var userToDelete = _dbContext.Set<User>().FirstOrDefault(u => u.UserName == user.UserName);
            if (userToDelete != null)
            {
                _dbContext.Set<User>().Remove(userToDelete);
                _dbContext.SaveChanges();
            }
        }

        public bool Exists(string username)
        {
            return _dbContext.Set<User>().Any(u => u.UserName == username);
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Set<User>().ToList();
        }

        public void UpdateUser(string username, string newPassword)
        {
            var userToUpdate = _dbContext.Set<User>().FirstOrDefault(u => u.UserName == username);

            if (userToUpdate != null)
            {
                userToUpdate.Password = newPassword;
                _dbContext.SaveChanges();
            }
        }

        public List<User> GetUsers(int pageNumber, int pageSize)
        {
            return _dbContext.Set<User>()
                .OrderBy(u => u.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
