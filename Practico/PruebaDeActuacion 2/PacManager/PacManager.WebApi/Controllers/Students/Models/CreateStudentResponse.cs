using PacManager.WebApi.Services.Students.Entities;

namespace PacManager.WebApi.Controllers.Students.Models
{
    public class CreateStudentResponse
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string StudentNumber { set; get; }

        public CreateStudentResponse(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            Surname = student.Surname;
            StudentNumber = student.StudentNumber;
        }
    }
}
