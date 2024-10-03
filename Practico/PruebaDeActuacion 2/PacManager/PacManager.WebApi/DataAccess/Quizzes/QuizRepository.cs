using Microsoft.EntityFrameworkCore;
using PacManager.WebApi.Services.Quizzes.Entities;

namespace PacManager.WebApi.DataAccess.Quizzes;

public class QuizRepository : IQuizRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Quiz> _quizzes;

    public QuizRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _quizzes = dbContext.Set<Quiz>();
    }

    public void AddQuiz(Quiz quiz)
    {
        _quizzes.Add(quiz);
        _dbContext.SaveChanges();
    }

    public bool ExistsQuiz(int quizId)
    {
        return _quizzes.Any(q => q.Id == quizId);
    }
}