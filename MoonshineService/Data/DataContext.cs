using Microsoft.EntityFrameworkCore;

namespace CraftBreadService
{
    public class DataContext : DbContext
    {
        public DbSet<CraftBread> Bread { get; set; }
        public DbSet<CraftBreadReview> Reviews { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CraftBread>()
                .HasMany(x => x.breadReviews)
                .WithOne(x => x.Bread);
        }
    }
}
