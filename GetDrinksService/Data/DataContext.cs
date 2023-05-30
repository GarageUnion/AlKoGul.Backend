using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace DrinksService
{
    public class DataContext:DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<DrinkReview> Reviews { get; set; }
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
            modelBuilder.Entity<Drink>()
                .HasMany(x => x.drinkReviews)
                .WithOne(x => x.Drink);
        }
    }
}
