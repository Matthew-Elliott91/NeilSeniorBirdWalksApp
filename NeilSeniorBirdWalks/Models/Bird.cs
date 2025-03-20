using System.ComponentModel.DataAnnotations;

namespace NeilSeniorBirdWalks.Models
{
    public class Bird
    {
        public int BirdId { get; set; }

        [Required(ErrorMessage = "Common name is required")]
        [StringLength(50, ErrorMessage = "Common name must be less than 50 characters")]
        [Display(Name = "Common Name")]
        public required string CommonName { get; set; }

        [Required(ErrorMessage ="Description is required")]
        [StringLength(500, ErrorMessage = "Description must be less than 500 characters")]
        [DataType(DataType.MultilineText)]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        [Url(ErrorMessage ="Please enter a valid URL")]
        [Display(Name = "Image URL")]
        public required string ImageUrl { get; set; }

        // Navigation properties
        public ICollection<TourBird>? TourBirds { get; set; }
    }
}
