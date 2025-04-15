using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeilSeniorBirdWalks.Models;

namespace NeilSeniorBirdWalks.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Season> Seasons { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourSeason> TourSeasons { get; set; }
        public DbSet<TourBird> TourBirds { get; set; }
        public DbSet<PageContent> PageContents { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<ContactFormModel> ContactForms { get; set; }
        public DbSet<TourSchedule> TourSchedules { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ImageFileInfo> ImageFiles { get; set; }
        public DbSet<HeaderImageSettings> HeaderImageSettings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
             .OwnsOne(c => c.Address, a =>
             {
                 a.Property(p => p.AddressLine1).HasColumnName("AddressLine1");
                 a.Property(p => p.AddressLine2).HasColumnName("AddressLine2");
                 a.Property(p => p.City).HasColumnName("City");
                 a.Property(p => p.County).HasColumnName("County");
                 a.Property(p => p.Postcode).HasColumnName("Postcode");
         
             });

            modelBuilder.Entity<Booking>()
                    .HasOne(b => b.User)
                    .WithMany()
                    .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<TourSeason>()
                .HasKey(ts => new { ts.TourId, ts.SeasonId });

            modelBuilder.Entity<TourSeason>()
                .HasOne(ts => ts.Tour)
                .WithMany(t => t.TourSeasons)
                .HasForeignKey(ts => ts.TourId);

            modelBuilder.Entity<TourSeason>()
                .HasOne(ts => ts.Season)
                .WithMany(s => s.TourSeasons)
                .HasForeignKey(ts => ts.SeasonId);

            modelBuilder.Entity<TourBird>()
                .HasKey(tb => new { tb.TourId, tb.BirdId });

            modelBuilder.Entity<TourBird>()
                .HasOne(tb => tb.Tour)
                .WithMany(t => t.TourBirds)
                .HasForeignKey(tb => tb.TourId);

            modelBuilder.Entity<TourBird>()
                .HasOne(tb => tb.Bird)
                .WithMany(b => b.TourBirds)
                .HasForeignKey(tb => tb.BirdId);

            // Seed BlogPost data
            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    Id = 1,
                    Title = "First Blog Post",
                    Slug = "first-blog-post",
                    CreatedDate = DateTime.UtcNow,
                    FeaturedImageUrl = "/Images/ToursHeaderImg.jpg",
                    AdditionalImageUrls = new List<string> { "/Images/ToursHeaderImg.jpg" }
                },
                new BlogPost
                {
                    Id = 2,
                    Title = "Second Blog Post",
                    Slug = "second-blog-post",
                    CreatedDate = DateTime.UtcNow,
                    FeaturedImageUrl = "/Images/ToursHeaderImg.jpg",
                    AdditionalImageUrls = new List<string> { "/Images/ToursHeaderImg.jpg" }
                },
                new BlogPost
                {
                    Id = 3,
                    Title = "Third Blog Post",
                    Slug = "third-blog-post",
                    CreatedDate = DateTime.UtcNow,
                    FeaturedImageUrl = "/Images/ToursHeaderImg.jpg",
                    AdditionalImageUrls = new List<string> { "/Images/ToursHeaderImg.jpg" }
                }
            );

            // Seed ContentSection data with foreign key
            modelBuilder.Entity<ContentSection>().HasData(
                new ContentSection
                {
                    Id = 1,
                    BlogPostId = 1,
                    Text = "This is the first paragraph of the first blog post.",
                    ImageUrl = "/Images/ToursHeaderImg.jpg"
                },
                new ContentSection
                {
                    Id = 2,
                    BlogPostId = 1,
                    Text = "This is the second paragraph of the first blog post.",
                    ImageUrl = "/Images/ToursHeaderImg.jpg"
                },
                new ContentSection
                {
                    Id = 3,
                    BlogPostId = 2,
                    Text = "This is the first paragraph of the second blog post.",
                    ImageUrl = "/Images/ToursHeaderImg.jpg"
                },
                new ContentSection
                {
                    Id = 4,
                    BlogPostId = 2,
                    Text = "This is the second paragraph of the second blog post.",
                    ImageUrl = "/Images/ToursHeaderImg.jpg"
                },
                new ContentSection
                {
                    Id = 5,
                    BlogPostId = 3,
                    Text = "This is the first paragraph of the third blog post.",
                    ImageUrl = "/Images/ToursHeaderImg.jpg"
                },
                new ContentSection
                {
                    Id = 6,
                    BlogPostId = 3,
                    Text = "This is the second paragraph of the third blog post.",
                    ImageUrl = "/Images/ToursHeaderImg.jpg"
                }
            );
        }
    }
}
