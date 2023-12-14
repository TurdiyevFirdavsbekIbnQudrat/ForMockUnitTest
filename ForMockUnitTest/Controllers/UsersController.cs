using ForMockUnitTest.Entities;
using ForMockUnitTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForMockUnitTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServvice _userService;
        public UsersController(IUserServvice userServvice)
        {
            _userService = userServvice;
        }
        [HttpGet("userlist")]
        public IEnumerable<User> UserList()
        {
            var productList = _userService.GetUserList();
            return productList;
        }
        [HttpGet("getuserbyid")]
        public User GetUserById(int Id)
        {
            return _userService.GetUserById(Id);
        }
        [HttpPost("adduser")]
        public User AddUser(User user)
        {
            return _userService.AddUser(user);
        }
        [HttpPut("updateuser")]
        public User UpdateUser(User user)
        {
           return _userService.UpdateUser(user);
        }
        [HttpDelete("deleteuser")]
        public bool DeleteUser(int Id)
        {
            return _userService.DeleteUser(Id);
        }
    }
}
