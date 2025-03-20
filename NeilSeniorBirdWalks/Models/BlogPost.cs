using Microsoft.CodeAnalysis.Operations;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace NeilSeniorBirdWalks.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Title { get; set; }

        [Required]
        [StringLength(100)]
        public required string Slug { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Today;

        [Url]
        public required string FeaturedImageUrl { get; set; }

        public List<ContentSection>? ContentSections { get; set; } = new List<ContentSection>();

        public List<string>? AdditionalImageUrls { get; set; } = new List<string>();
    }

    public class ContentSection
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }

        public required string Text { get; set; }

        [Url]
        public required string ImageUrl { get; set; }

        // Navigation properties
        public BlogPost? BlogPost { get; set; }
    }
}
