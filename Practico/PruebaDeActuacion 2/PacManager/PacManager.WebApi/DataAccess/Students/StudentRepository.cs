using Microsoft.EntityFrameworkCore;
using PacManager.WebApi.Services.Students.Entities;

namespace PacManager.WebApi.DataAccess.Students;

public class StudentRepository : IStudentRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Student> _students;

    public StudentRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _students = dbContext.Set<Student>();
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
        _dbContext.SaveChanges();
    }

    public bool ExistsStudent(int studentId)
    {
        return _students.Any(s => s.Id == studentId);
    }
}