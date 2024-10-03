using PacManager.WebApi.DataAccess.Quizzes;
using PacManager.WebApi.Services.Quizzes.Entities;

namespace PacManager.WebApi.Services.Quizzes
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public Quiz AddQuiz(Quiz quiz)
        {
            _quizRepository.AddQuiz(quiz);

            return quiz;
        }

        public bool ExistsQuiz(int quizId)
        {
            return _quizRepository.ExistsQuiz(quizId);
        }
    }
}
