using System.ComponentModel.DataAnnotations;

namespace NeilSeniorBirdWalks.Models
{
    public class Tour
    {
        public int TourId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string Description { get; set; }

        [StringLength(200, ErrorMessage = "Info Headline cannot be longer than 200 characters")]
        public string InfoHeadline { get; set; }

        [StringLength(2000, ErrorMessage = "Info Text cannot be longer than 2000 characters")]
        public string InfoText { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        public string InfoImageUrl { get; set; } = "images/tours/default.jpg";

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Duration must be a positive value")]
        public int? Duration { get; set; }

        // Navigation properties
        public ICollection<TourSeason> TourSeasons { get; set; }
        public ICollection<TourBird> TourBirds { get; set; }
        public ICollection<TourSchedule> TourSchedules { get; set; }
    }
}
