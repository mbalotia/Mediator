using Microsoft.EntityFrameworkCore;
namespace ClientMinimalAPI
{
    public class BookingDbContext : DbContext
    {
        protected override void OnConfiguring
      (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BookingDb");
        }
        public DbSet<Booking> Bookings { get; set; }
    }
}
