using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.SessionDataAccess
{
    public class SessionRepository : ISessionRepository
    {
        private readonly DbContext _dbContext;

        public SessionRepository(DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void AddSession(Session session)
        {
            _dbContext.Set<Session>().Add(session);
            _dbContext.SaveChanges();
        }

        public Session GetSession(string token)
        {
            return _dbContext.Set<Session>().FirstOrDefault(s => s.Token == token);
        }
    }
}
