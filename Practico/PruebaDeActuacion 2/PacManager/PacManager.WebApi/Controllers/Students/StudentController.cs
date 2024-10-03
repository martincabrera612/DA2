using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PacManager.WebApi.Controllers.Students.Models;
using PacManager.WebApi.Services.Students;
using PacManager.WebApi.Services.Students.Entities;

namespace PacManager.WebApi.Controllers.Students
{
    [ApiController]
    [Route("students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public CreateStudentResponse CreateStudent(CreateStudentRequest studentReq)
        {
            var studentToSave = new Student(studentReq.Name, studentReq.Surname, studentReq.StudentNumber);
            studentToSave = _studentService.AddStudent(studentToSave);

            return new CreateStudentResponse(studentToSave);
        }
    }
}
