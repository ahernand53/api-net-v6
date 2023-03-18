using api_net_v6.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace api_net_v6.DataAccess
{
    public class UniversityContext : DbContext
    {

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }

        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }

    }
}
