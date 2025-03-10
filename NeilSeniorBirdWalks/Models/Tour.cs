namespace NeilSeniorBirdWalks.Models
{
    public class Tour
    {
        public int TourId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InfoHeadline { get; set; }
        public string InfoText { get; set; }
        public string InfoImageUrl { get; set; }
        public decimal? Price { get; set; }
        public int? Duration { get; set; }

        // Navigation properties
        public ICollection<TourSeason> TourSeasons { get; set; }
        public ICollection<TourBird> TourBirds { get; set; }
        public ICollection<TourSchedule> TourSchedules { get; set; }
    }
}
