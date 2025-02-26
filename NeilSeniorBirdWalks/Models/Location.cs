namespace NeilSeniorBirdWalks.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }

        public ICollection<Tour> Tours { get; set; }    
    }
}
