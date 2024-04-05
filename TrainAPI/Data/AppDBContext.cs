using Microsoft.EntityFrameworkCore;
using TrainAPI.Model;
namespace TrainAPI.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Train> trains { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookedUsers> BookedUsers { get; set; }
        public DbSet<Admin> admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Train>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Data Source=LAPTOP-NK5A4VL1;" +
                "Initial Catalog=trainDB;" +
                "User ID=sa;Password=1234;" +
                "Trust Server Certificate=True;" +
                "ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False"; 

            optionsBuilder.UseSqlServer(conn);
        }
    }
}
