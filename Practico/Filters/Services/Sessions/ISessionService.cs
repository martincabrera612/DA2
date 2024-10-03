using Domain;

namespace Services.Sessions
{
    public interface ISessionService
    {
        Session AddSession(string email, string password);
        User GetUserFromSession(string token);
        bool ValidSession(string token, string role);
    }
}
