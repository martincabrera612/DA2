using PacManager.WebApi.Services.Grades.Entities;

namespace PacManager.WebApi.DataAccess.Grades
{
    public interface IGradeRepository
    {
        void AddGrade(Grade grade);
    }
}
