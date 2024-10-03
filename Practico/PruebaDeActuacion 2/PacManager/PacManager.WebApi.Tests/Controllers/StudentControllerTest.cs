using Moq;
using PacManager.WebApi.Controllers.Students;
using PacManager.WebApi.Controllers.Students.Models;
using PacManager.WebApi.Services.Students;
using PacManager.WebApi.Services.Students.Entities;

namespace PacManager.WebApi.Tests
{
    [TestClass]
    public class StudentControllerTest
    {
        private StudentController _controller;
        private Mock<IStudentService> _studentServiceMock;

        [TestInitialize]
        public void Initialize()
        {
            _studentServiceMock = new Mock<IStudentService>(MockBehavior.Strict);
            _controller = new StudentController(_studentServiceMock.Object);
        }
    
        [TestMethod]
        public void CreateStudent_WhenRequestIsOk_ShouldCreateStudent()
        {
            var request = new CreateStudentRequest
            {
                Name = "Test name",
                Surname = "Test surname",
                StudentNumber = "211900"
            };

            var expectedStudent = new Student(request.Name, request.Surname, request.StudentNumber);
            _studentServiceMock.Setup(s => s.AddStudent(It.IsAny<Student>())).Returns(expectedStudent);

            var response = _controller.CreateStudent(request);
        
            _studentServiceMock.VerifyAll();
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Id, expectedStudent.Id);
        }
    }
}

