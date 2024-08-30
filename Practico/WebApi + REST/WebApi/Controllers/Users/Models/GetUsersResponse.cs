using WebApi.Controllers.Users.Entities;

namespace WebApi.Controllers.Users.Models
{
    public class GetUsersResponse(User user)
    {
        public string UserName { get; set; } = user.UserName;
        public string Password { get; set; } = user.Password;
        public string Email { get; set; } = user.Email;
    }
}
