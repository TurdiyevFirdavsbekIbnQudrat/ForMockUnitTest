using ForMockUnitTest.Controllers;
using ForMockUnitTest.Entities;
using ForMockUnitTest.Services;
using Moq;
namespace mockTestt
{
    public class UnitTestController
    {
        private readonly Mock<IUserServvice> userService;
        public UnitTestController()
        {
            userService = new Mock<IUserServvice>();
        }
        [Fact]
        public void GetUserList_UserList()
        {
            //arrange
            var userList = GetUserData();
            userService.Setup(x => x.GetUserList())
                .Returns(userList);
            var userController = new UsersController(userService.Object);
            //act
            var userResult = userController.UserList();
            //assert
            Assert.NotNull(userResult);
            Assert.Equal(GetUserData().Count(), userResult.Count());
            Assert.Equal(GetUserData().ToString(), userResult.ToString());
            Assert.True(userList.Equals(userResult));
        }
        [Fact]
        public void GetUserByID_User()
        {
            //arrange
            var userList = GetUserData();
            userService.Setup(x => x.GetUserById(2))
                .Returns(userList[1]);
            var userController = new UsersController(userService.Object);
            //act
            var userResult = userController.GetUserById(2);
            //assert
            Assert.NotNull(userResult);
            Assert.Equal(userList[1].Id, userResult.Id);
            Assert.True(userList[1].Id == userResult.Id);
        }
        [Theory]
        [InlineData("Firdavs")]
        public void CheckUserExistOrNotByUserName_User(string Name)
        {
            //arrange
            var userList = GetUserData();
            userService.Setup(x => x.GetUserList())
                .Returns(userList);
            var userController = new UsersController(userService.Object);
            //act
            var userResult = userController.UserList();
            var expectedUserName = userResult.ToList()[0].Name;
            //assert
            Assert.Equal(Name, expectedUserName);
        }

        [Fact]
        public void AddUser_User()
        {
            //arrange
            var userList = GetUserData();
            userService.Setup(x => x.AddUser(userList[2]))
                .Returns(userList[2]);
            var userController = new UsersController(userService.Object);
            //act
            var userResult = userController.AddUser(userList[2]);
            //assert
            Assert.NotNull(userResult);
            Assert.Equal(userList[2].Id, userResult.Id);
            Assert.True(userList[2].Id == userResult.Id);
        }

        private List<User> GetUserData()
        {
            List<User> productsData = new List<User>
        {
            new User
            {
                Id=1,
                Email="firdavs@gmail.com",
                Name="Firdavs",
            },
             new User
            {
                Id=2,
                Email="quvvat@gmail.com",
                Name="Quvvat",
            },
          
        };
            return productsData;
        }
    }
}