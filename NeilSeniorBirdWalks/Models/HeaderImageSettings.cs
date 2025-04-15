using System.ComponentModel.DataAnnotations;

namespace NeilSeniorBirdWalks.Models
{
    public class HeaderImageSettings
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(150, ErrorMessage = "Title cannot be longer than 150 characters")]
        public string Title { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Subtitle cannot be longer than 200 characters")]
        public string Subtitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Background image URL is required")]
        [Url(ErrorMessage = "Invalid URL format")]
        public string BackgroundImageUrl { get; set; } = string.Empty;
        public string PageIdentifier { get; set; } = string.Empty;
    }
}
