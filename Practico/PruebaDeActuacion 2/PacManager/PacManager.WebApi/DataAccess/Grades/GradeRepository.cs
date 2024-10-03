using Microsoft.EntityFrameworkCore;
using PacManager.WebApi.Services.Grades.Entities;

namespace PacManager.WebApi.DataAccess.Grades
{
    public class GradeRepository : IGradeRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Grade> _grades;

        public GradeRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _grades = dbContext.Set<Grade>();
        }

        public void AddGrade(Grade grade)
        {
            _grades.Add(grade);
            _dbContext.SaveChanges();
        }
    }
}
