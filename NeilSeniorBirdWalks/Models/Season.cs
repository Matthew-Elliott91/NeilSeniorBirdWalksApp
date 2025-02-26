namespace NeilSeniorBirdWalks.Models
{
    public class Season
    {
        public int SeasonId { get; set; }
        public string SeasonCode { get; set; }
        public string SeasonName { get; set; }
        public string Description { get; set; }

        public ICollection<Tour> Tours { get; set; }
    }
}
