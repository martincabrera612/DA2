using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Users.Entities;
using WebApi.Controllers.Users.Models;

namespace WebApi.Controllers.Users
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private static readonly List<User> _users = [];

        [HttpPost]
        public CreateUserResponse Create(CreateUserRequest request)
        {
            if (request == null) 
            {
                throw new Exception("Request can not be null");
            }

            if (string.IsNullOrEmpty(request.UserName))
            {
                throw new Exception("UserName can not be null or empty");
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                throw new Exception("Password can not be null or empty");
            }

            var existUser = _users.Any(m => m.UserName == request.UserName);
            if (existUser)
            {
                throw new Exception($"User with prop: UserName and value: {request.UserName} already exists");
            }

            var userToSave = new User(request.UserName, request.Password);
            _users.Add(userToSave);

            return new CreateUserResponse(userToSave);
        }

        [HttpGet]
        public List<UserOutDto> GetAll([FromQuery] UserFiltersRequest filters)
        {
            return _users
                .Where(m =>
                (string.IsNullOrEmpty(filters.UserName) || m.UserName.Contains(filters.UserName)))
                .Select(m => new UserOutDto(m))
                .ToList();
        }

        [HttpGet("{userName}")]
        public GetUsersResponse GetByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new Exception("UserName can not be null or empty");
            }

            var user = _users.Find(u => u.UserName == userName);

            if (user == null)
            {
                throw new Exception($"User with userName: {userName} does not exist");
            }

            return new GetUsersResponse(user);
        }

        [HttpDelete("{userName}")]
        public string DeleteByUserName(string userName)
        {
            var user = _users.Find(u => u.UserName == userName);

            if (user == null)
            {
                throw new Exception($"User with userName: {userName} does not exist");
            }

            _users.Remove(user);
            return "Se elimino el usuario " + userName ;
        }

        [HttpPut("{userName}")]
        public void UpdateByUserName(string userName, UpdateUserRequest? request)
        {
            if (request == null)
            {
                throw new Exception("The request can not be null");
            }

            var user = _users.Find(u => u.UserName == userName);

            if (user == null)
            {
                throw new Exception($"User with userName: {userName} does not exist");
            }

            if (!string.IsNullOrEmpty(request.Password))
            {
                user.Password = request.Password;
            }
        }
    }
}
