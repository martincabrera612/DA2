using Domain;

namespace DataAccess.Repositories.UserDataAccess
{
    public interface IUserRepository
    {
        void Add(User user);
        bool Exists(string username);
        void UpdateUser(string username, string newPassword);
        List<User> GetAllUsers();
        void DeleteUser(User user);
        List<User> GetUsers(int pageNumber, int pageSize);
    }
}
