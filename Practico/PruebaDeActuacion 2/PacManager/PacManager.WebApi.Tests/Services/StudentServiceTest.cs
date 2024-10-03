using Moq;
using PacManager.WebApi.DataAccess.Students;
using PacManager.WebApi.Services.Students;
using PacManager.WebApi.Services.Students.Entities;

namespace PacManager.WebApi.Tests.Services
{
    [TestClass]
    public class StudentServiceTest
    {
        private Mock<IStudentRepository> _studentRepositoryMock;
        private StudentService _service;
        
        [TestInitialize]
        public void Initialize()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>(MockBehavior.Strict);
            _service = new StudentService(_studentRepositoryMock.Object);
        }

        [TestMethod]
        public void AddStudent_WhenInfoIsCorrect_ShouldReturnStudent()
        {
            var arg = new Student("Test name", "Test surname", "211900");
            _studentRepositoryMock.Setup(repo => repo.AddStudent(It.IsAny<Student>()));
            
            var student = _service.AddStudent(arg);
            
            _studentRepositoryMock.VerifyAll();
            Assert.AreEqual(arg.Name, student.Name);
        }
    }
}

