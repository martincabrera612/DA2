using PacManager.WebApi.Services.Grades.Entities;

namespace PacManager.WebApi.Services.Grades
{
    public interface IGradeService
    {
        Grade AddGrade(Grade grade);
    }
}
