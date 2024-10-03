using Microsoft.EntityFrameworkCore;
using PacManager.WebApi.Services.Students.Entities;
using Moq;
using PacManager.WebApi.DataAccess.Students;

namespace PacManager.WebApi.Tests.Repositories
{
    [TestClass]
    public class StudentRepositoryTest
    {
        private Student _student;
        private IQueryable<Student> _data;
        private Mock<DbSet<Student>> _mockSet;
        private Mock<DbContext> _pacManagerDbContext;
        private StudentRepository _studentRepo;
        
        [TestInitialize]
        public void Initialize()
        {
            _student = new Student("Test name", "Test surname", "211900");
            _student.Id = 1;
            
            _data = new List<Student>
            {
                _student
            }.AsQueryable();

            _mockSet = new Mock<DbSet<Student>>();
            _mockSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(_data.Provider);
            _mockSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(_data.Expression);
            _mockSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(_data.ElementType);
            _mockSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(() => _data.GetEnumerator());
            
            _pacManagerDbContext = new Mock<DbContext>();
            _pacManagerDbContext.Setup(x => x.Set<Student>()).Returns(_mockSet.Object);
            _studentRepo = new StudentRepository(_pacManagerDbContext.Object);
        }

        [TestMethod]
        public void AddUserTest()
        {
            _pacManagerDbContext.Setup(x => x.SaveChanges()).Returns(1);

            _studentRepo.AddStudent(_student);

            _pacManagerDbContext.Verify(blogSystemContext => blogSystemContext.SaveChanges(), Times.Once());
        }
    }
}

