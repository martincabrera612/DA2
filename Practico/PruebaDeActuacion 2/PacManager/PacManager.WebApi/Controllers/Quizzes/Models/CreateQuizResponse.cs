using PacManager.WebApi.Services.Quizzes.Entities;

namespace PacManager.WebApi.Controllers.Quizzes.Models
{
    public class CreateQuizResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }

        public CreateQuizResponse(Quiz quiz)
        {
            Id = quiz.Id;
            Name = quiz.Name;
            Value = quiz.Value;
        }
    }
}
