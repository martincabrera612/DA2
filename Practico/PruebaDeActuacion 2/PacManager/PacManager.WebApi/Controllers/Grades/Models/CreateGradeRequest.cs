namespace PacManager.WebApi.Controllers.Grades.Models
{
    public class CreateGradeRequest
    {
        public int StudentId { get; set; }
        public int QuizId { get; set; }
        public float Value { get; set; }
    }
}
