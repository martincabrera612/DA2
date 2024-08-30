using WebApi.Controllers.Users.Entities;

namespace WebApi.Controllers.Users.Models
{
    public class UserOutDto(User user)
    {
        public string UserName { get; set; } = user.UserName;
    }
}
