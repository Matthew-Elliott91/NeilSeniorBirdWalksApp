namespace NeilSeniorBirdWalks.Models
{
    public class Bird
    {
        public int BirdId { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<TourBird> TourBirds { get; set; }
    }
}
