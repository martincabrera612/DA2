using Domain;

namespace WebApi.Controllers.Users.Models
{
    public class GetUsersResponse(User user)
    {
        public string UserName { get; set; } = user.UserName;
        public string Password { get; set; } = user.Password;
    }
}
