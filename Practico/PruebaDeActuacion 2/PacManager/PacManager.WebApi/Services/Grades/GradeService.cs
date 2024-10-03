using PacManager.WebApi.DataAccess.Grades;
using PacManager.WebApi.Services.Grades.Entities;
using PacManager.WebApi.Services.Quizzes;
using PacManager.WebApi.Services.Students;

namespace PacManager.WebApi.Services.Grades
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IQuizService _quizService;
        private readonly IStudentService _studentService;

        public GradeService(IGradeRepository gradeRepository, IQuizService quizService, IStudentService studentService)
        {
            _gradeRepository = gradeRepository;
            _quizService = quizService;
            _studentService = studentService;
        }

        public Grade AddGrade(Grade grade)
        {
            _gradeRepository.AddGrade(grade);
            return grade;
        }
    }
}
