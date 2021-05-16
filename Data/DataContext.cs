using APIREST_PlanningPocker.Models;
using Microsoft.EntityFrameworkCore;

namespace APIREST_PlanningPocker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet <Users> users { get; set; }

        public DbSet <UserHistory> userHistories { get; set; }

        public DbSet <Letters> letters  { get; set; }

        public DbSet <Votes> votes  { get; set; }

    }
}
