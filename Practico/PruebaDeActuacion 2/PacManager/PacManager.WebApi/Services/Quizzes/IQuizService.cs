using PacManager.WebApi.Services.Quizzes.Entities;

namespace PacManager.WebApi.Services.Quizzes
{
    public interface IQuizService
    {
        Quiz AddQuiz(Quiz quiz);
        bool ExistsQuiz(int quizId);
    }
}
