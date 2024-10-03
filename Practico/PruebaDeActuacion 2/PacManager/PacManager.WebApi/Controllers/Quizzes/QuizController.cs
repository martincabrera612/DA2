using Microsoft.AspNetCore.Mvc;
using PacManager.WebApi.Controllers.Quizzes.Models;
using PacManager.WebApi.Services.Quizzes;
using PacManager.WebApi.Services.Quizzes.Entities;

namespace PacManager.WebApi.Controllers.Quizzes
{
    [ApiController]
    [Route("quizzes")]
    public class QuizController
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpPost]
        public CreateQuizResponse CreateQuiz(CreateQuizRequest quizReq)
        {
            var quizToSave = new Quiz(quizReq.Name, quizReq.Value);
            quizToSave = _quizService.AddQuiz(quizToSave);

            return new CreateQuizResponse(quizToSave);
        }
    }
}
