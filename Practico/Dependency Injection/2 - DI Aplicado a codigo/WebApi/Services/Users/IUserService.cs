using WebApi.Services.Users.Entities;

namespace WebApi.Services.Users
{
    public interface IUserService
    {
        User Add(User user);

        User GetByUserName(string userName);

        List<User> GetAll(string userName);

        void DeleteByUserName(string userName);

        void UpdateByUserName(string userName, string password);
    }
}
