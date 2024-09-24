using Domain;
using Moq;
using WebApi.Controllers.Users;
using WebApi.Controllers.Users.Models;
using WebApi.Services.Users;

namespace WebApiTest
{
    [TestClass]
    public class UserServiceTest
    {
        private Mock<IUserService> _userServiceMock;
        private UserController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _userServiceMock = new Mock<IUserService>(MockBehavior.Strict);
            _controller = new UserController(_userServiceMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Create_WhenRequestIsNull_ShouldThrowException()
        {
            _controller.Create(null);
        }

        [TestMethod]
        public void Create_WhenRequestHasCorrectInfo_ShouldCreateUser()
        {
            var request = new CreateUserRequest
            {
                UserName = "Test",
                Password = "password"
            };
            var expectedUser = new User(request.UserName, request.Password);
            _userServiceMock.Setup(u => u.Add(It.IsAny<User>())).Returns(expectedUser);

            var response = _controller.Create(request);

            _userServiceMock.VerifyAll();
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Id, expectedUser.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Delete_WhenUserDoesNotExist_ShouldThrowException()
        {
            string userName = "Test";
            _userServiceMock.Setup(u => u.GetByUserName(userName)).Returns((User)null);
            _userServiceMock.Setup(u => u.DeleteByUserName(userName));

            _controller.DeleteByUserName(userName);

            _userServiceMock.VerifyAll();
        }

        [TestMethod]
        public void Delete_WhenUserExists_ShouldDeleteUser()
        {
            string userName = "Test";
            var user = new User("Test", "Password");

            _userServiceMock.Setup(u => u.GetByUserName(userName)).Returns(user);
            _userServiceMock.Setup(u => u.DeleteByUserName(userName));

            _controller.DeleteByUserName(userName);

            _userServiceMock.VerifyAll();
        }
    }
}
