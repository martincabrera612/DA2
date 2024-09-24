using Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Users.Models;
using WebApi.Services.Users;

namespace WebApi.Controllers.Users
{
    [ApiController]
    [Route("api/users")]
    public class UserController(IUserService _userService) : ControllerBase
    {
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

            var userToSave = new User(request.UserName, request.Password);
            userToSave = _userService.Add(userToSave);

            return new CreateUserResponse(userToSave);
        }

        [HttpGet]
        public List<UserOutDto> GetAll([FromQuery] UserFiltersRequest filters)
        {
            return _userService.GetAll(filters.UserName)
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

            var user = _userService.GetByUserName(userName);

            if (user == null)
            {
                throw new Exception($"User with userName: {userName} does not exist");
            }

            return new GetUsersResponse(user);
        }

        [HttpDelete("{userName}")]
        public void DeleteByUserName(string userName)
        {
            var user = _userService.GetByUserName(userName);

            if (user == null)
            {
                throw new Exception($"User with userName: {userName} does not exist");
            }

            _userService.DeleteByUserName(userName);
        }

        [HttpPut("{userName}")]
        public void UpdateByUserName(string userName, UpdateUserRequest? request)
        {
            if (request == null)
            {
                throw new Exception("The request can not be null");
            }

            var user = _userService.GetByUserName(userName);

            if (user == null)
            {
                throw new Exception($"User with userName: {userName} does not exist");
            }

            if (!string.IsNullOrEmpty(request.Password))
            {
                _userService.Update(userName, request.Password);
            }
        }

        [HttpGet("paged")]
        public List<UserOutDto> GetUsersPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var users = _userService.GetUsers(pageNumber, pageSize);

            return users.Select(u => new UserOutDto(u)).ToList();
        }

    }
}
