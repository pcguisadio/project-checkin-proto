using System.Data.Entity;

namespace ProjectCheckIn_Beta.Models
{
    public class MainDbContext: DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}