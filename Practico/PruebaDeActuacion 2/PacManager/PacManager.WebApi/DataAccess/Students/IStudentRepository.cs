using PacManager.WebApi.Services.Students.Entities;

namespace PacManager.WebApi.DataAccess.Students;

public interface IStudentRepository
{
    void AddStudent(Student student);
    bool ExistsStudent(int studentId);
}