using Domain;

namespace DataAccess.Repositories.SessionDataAccess
{
    public interface ISessionRepository
    {
        void AddSession(Session session);
        Session GetSession(string token);
    }
}
