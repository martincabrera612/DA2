using Microsoft.EntityFrameworkCore;
using PacManager.WebApi.Services.Grades.Entities;
using PacManager.WebApi.Services.Quizzes.Entities;
using PacManager.WebApi.Services.Students.Entities;

namespace PacManager.WebApi.DataAccess
{
    public class PacManagerDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public PacManagerDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
