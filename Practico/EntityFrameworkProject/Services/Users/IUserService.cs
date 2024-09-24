using Domain;

namespace WebApi.Services.Users
{
    public interface IUserService
    {
        User Add(User user);

        User GetByUserName(string userName);

        List<User> GetAll(string userName);

        void DeleteByUserName(string userName);

        void Update(string userName, string password);
        List<User> GetUsers(int pageNumber, int pageSize);
    }
}
