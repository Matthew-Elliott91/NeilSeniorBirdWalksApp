namespace NeilSeniorBirdWalks.Models
{
    public class TourBird
    {
        public int TourId { get; set; }
        public int BirdId { get; set; }
        public string Likelihood { get; set; }

        public Tour Tour { get; set; }
        public Bird Bird { get; set; }
    }
}
