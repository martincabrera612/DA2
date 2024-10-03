using PacManager.WebApi.DataAccess.Students;
using PacManager.WebApi.Services.Students.Entities;

namespace PacManager.WebApi.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public Student AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);

            return student;
        }

        public bool ExistsStudent(int studentId)
        {
            return _studentRepository.ExistsStudent(studentId);
        }
    }
}
