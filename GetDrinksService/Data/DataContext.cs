using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BreadService
{
    public class DataContext:DbContext
    {
        public DbSet<Bread> Bread { get; set; }
        public DbSet<BreadReview> Reviews { get; set; }
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
            modelBuilder.Entity<Bread>()
                .HasMany(x => x.breadReviews)
                .WithOne(x => x.Bread);
        }
    }
}
