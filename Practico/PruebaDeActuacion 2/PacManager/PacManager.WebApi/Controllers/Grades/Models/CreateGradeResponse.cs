using PacManager.WebApi.Services.Grades.Entities;

namespace PacManager.WebApi.Controllers.Grades.Models
{
    public class CreateGradeResponse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QuizId { get; set; }
        public float Value { get; set; }

        public CreateGradeResponse(Grade grade)
        {
            Id = grade.Id;
            StudentId = grade.StudentId;
            QuizId = grade.QuizId;
            Value = grade.Value;
        }
    }
}

