using api_net_v6.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace api_net_v6.DataAccess
{
    public class UniversityContext : DbContext
    {

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }

        public DbSet<User>? Users { get; set; }

    }
}
