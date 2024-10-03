using DataAccess.Repositories.SessionDataAccess;
using Domain;
using Services.Users;

namespace Services.Sessions
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserService _userService;

        public SessionService(ISessionRepository sessionRepository, IUserService userService)
        {
            _sessionRepository = sessionRepository;
            _userService = userService;
        }

        public Session AddSession(string username, string password)
        {
            User user = _userService.GetByUserName(username);
            if (user.Password.Equals(password))
            {
                Session newSession = new Session
                {
                    Token = Guid.NewGuid().ToString(),
                    UserId = user.Id
                };
                _sessionRepository.AddSession(newSession);
                return newSession;
            } 
            else
            {
                throw new Exception("Invalid credentials");
            }
        }

        public User GetUserFromSession(string token)
        {
            Guid userId = _sessionRepository.GetSession(token).UserId;
            User user = _userService.GetUserById(userId);
            return user;
        }

        public bool ValidSession(string token, string role)
        {
            Session session = _sessionRepository.GetSession(token);
            if (session != null)
            {
                try
                {
                    User user = _userService.GetUserById(session.UserId);
                        return (user.Role.Contains(role) || role.Equals("any"));
                }
                catch (Exception)
                {
                    throw new Exception("Invalid Token");
                }
            }
            throw new Exception("Invalid Token");
        }
    }
}
