using PacManager.WebApi.Services.Students.Entities;

namespace PacManager.WebApi.Services.Students
{
    public interface IStudentService
    {
        Student AddStudent(Student student);
        bool ExistsStudent(int studentId);
    }
}
