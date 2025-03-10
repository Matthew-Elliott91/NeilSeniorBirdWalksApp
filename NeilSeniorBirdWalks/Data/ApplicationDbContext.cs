using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeilSeniorBirdWalks.Models;

namespace NeilSeniorBirdWalks.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourBird> TourBirds { get; set; }
        public DbSet<PageContent> PageContents { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<ContactFormModel> ContactForms { get; set; }
        public DbSet<TourSchedule> TourSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure primary keys for junction table
            modelBuilder.Entity<TourBird>()
                .HasKey(tb => new { tb.TourId, tb.BirdId });

            // Configure relationships
            modelBuilder.Entity<TourBird>()
                .HasOne(tb => tb.Tour)
                .WithMany(t => t.TourBirds)
                .HasForeignKey(tb => tb.TourId);

            modelBuilder.Entity<TourBird>()
                .HasOne(tb => tb.Bird)
                .WithMany(b => b.TourBirds)
                .HasForeignKey(tb => tb.BirdId);

            // Enforce unique constraint on Tour's Location and Season
            modelBuilder.Entity<Tour>()
                .HasIndex(t => new { t.LocationId, t.SeasonId })
                .IsUnique();
        }
    }
}