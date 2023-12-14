using ForMockUnitTest.Entities;
using ForMockUnitTest.mockDbContext;

namespace ForMockUnitTest.Services
{
    public class UserService : IUserServvice
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User AddUser(User user)
        {
            var result = _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteUser(int Id)
        {
            var filteredData = _dbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> GetUserList()
        {
            return _dbContext.Users.ToList();
        }

        public User UpdateUser(User user)
        {
            var result = _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
