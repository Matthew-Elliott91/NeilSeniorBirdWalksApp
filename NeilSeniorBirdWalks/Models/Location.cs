namespace NeilSeniorBirdWalks.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string SpringImagePath { get; set; }
        public string SummerImagePath { get; set; }
        public string AutumnImagePath { get; set; }
        public string WinterImagePath { get; set; }

        public ICollection<Tour> Tours { get; set; }    
    }
}
