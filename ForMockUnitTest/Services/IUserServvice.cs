using ForMockUnitTest.Entities;

namespace ForMockUnitTest.Services
{
    public interface IUserServvice
    {
        public IEnumerable<User> GetUserList();
        public User GetUserById(int id);
        public User AddUser(User user);
        public User UpdateUser(User user);
        public bool DeleteUser(int Id);
    }
}
