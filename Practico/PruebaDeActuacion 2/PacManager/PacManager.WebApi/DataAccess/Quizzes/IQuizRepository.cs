using PacManager.WebApi.Services.Quizzes.Entities;

namespace PacManager.WebApi.DataAccess.Quizzes
{
    public interface IQuizRepository
    {
        void AddQuiz(Quiz quiz);
        bool ExistsQuiz(int quizId);
    }
}
