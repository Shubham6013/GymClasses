
namespace GymClasses
{
    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options) : base(options) { }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Occurrence> Occurrences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Occurrence>()
                .HasOne(o => o.Class)
                .WithMany(c => c.Occurrences)
                .HasForeignKey(o => o.ClassId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Class)
                .WithMany()
                .HasForeignKey(b => b.ClassId);
        }
    }
}

