using Microsoft.AspNetCore.Mvc;
using PacManager.WebApi.Controllers.Grades.Models;
using PacManager.WebApi.Services.Grades;
using PacManager.WebApi.Services.Grades.Entities;

namespace PacManager.WebApi.Controllers.Grades
{
    [ApiController]
    [Route("grades")]
    public class GradeController
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        
        [HttpPost]
        public CreateGradeResponse CreateGrade(CreateGradeRequest gradeReq)
        {
            var gradeToSave = new Grade(gradeReq.StudentId, gradeReq.QuizId, gradeReq.Value);
            gradeToSave = _gradeService.AddGrade(gradeToSave);

            return new CreateGradeResponse(gradeToSave);
        }
    }
}
