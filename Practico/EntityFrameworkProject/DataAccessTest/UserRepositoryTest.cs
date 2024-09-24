using DataAccess.Repositories.UserDataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DataAccessTest
{
    [TestClass]
    public class UserRepositoryTest
    {
        private Guid _id;
        private IQueryable<User> _data;
        private Mock<DbSet<User>> _mockSet;
        private Mock<DbContext> _userManagerContextMock;
        private UserRepository _userDataAccess;
        private User _user;

        [TestInitialize]
        public void Initialize()
        {
            _id = new Guid();
            _user = new User
            {
                Id = _id,
                UserName = "TestUserName",
                Password = "TestPassword"
            };
            _data = new List<User>
            {
                _user
            }.AsQueryable();
            _mockSet = new Mock<DbSet<User>>();
            _mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(_data.Provider);
            _mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(_data.Expression);
            _mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(_data.ElementType);
            _mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => _data.GetEnumerator());
            _userManagerContextMock = new Mock<DbContext>();
            _userDataAccess = new UserRepository(_userManagerContextMock.Object);
            _userManagerContextMock.Setup(x => x.Set<User>()).Returns(_mockSet.Object);
        }

        [TestMethod]
        public void AddUserTest()
        {
            _userManagerContextMock.Setup(x => x.SaveChanges()).Returns(1);

            _userDataAccess.Add(_user);

            _userManagerContextMock.Verify(blogSystemContext => blogSystemContext.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void ExistsUserTest()
        {
            bool result = _userDataAccess.Exists(_user.UserName);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            List<User> result = _userDataAccess.GetAllUsers();

            Assert.AreEqual(1, result.Count());
            Assert.IsTrue(result.Contains(_user));
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            _userManagerContextMock.Setup(x => x.SaveChanges()).Returns(1);

            _userDataAccess.DeleteUser(_user);

            _userManagerContextMock.Verify(blogSystemContext => blogSystemContext.SaveChanges(), Times.Once());
        }
    }
}