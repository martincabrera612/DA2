using WebApi.Controllers.Users.Entities;

namespace WebApi.Controllers.Users.Models
{
    public class CreateUserResponse(User user)
    {
        public Guid Id { get; set; } = user.Id;
    }
}
