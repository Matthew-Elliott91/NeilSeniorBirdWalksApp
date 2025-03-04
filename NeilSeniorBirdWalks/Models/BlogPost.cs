namespace NeilSeniorBirdWalks.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Today;
        public string FeaturedImageUrl { get; set; } = string.Empty;
        public string FirstParagraph { get; set; } = string.Empty;
        public string FirstImageUrl { get; set; } = string.Empty;
        public string SecondParagraph { get; set; } = string.Empty;
        public string SecondImageUrl { get; set; } = string.Empty;
        public string ThirdParagraph { get; set; } = string.Empty;
        public string ThirdImageUrl { get; set; } = string.Empty;
        public List<string> AdditionalImageUrls { get; set; } = new List<string>();
        
    }
}
