namespace NeilSeniorBirdWalks.Models
{
    public class TourSeason
    {
        public int TourId { get; set; }
        public int SeasonId { get; set; }

        // Navigation properties
        public Tour Tour { get; set; }
        public Season Season { get; set; }
    }
}
