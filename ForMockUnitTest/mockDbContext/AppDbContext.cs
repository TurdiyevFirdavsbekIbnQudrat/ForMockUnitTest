using ForMockUnitTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForMockUnitTest.mockDbContext
{
    public class AppDbContext:DbContext
    {
        protected readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<User> Users { get; set; }
    }
}
