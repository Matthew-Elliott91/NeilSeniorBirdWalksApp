namespace NeilSeniorBirdWalks.Models
{
    public class PageContent
    {
        public int Id { get; set; }
        public string PageType { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string MainContent { get; set; }
        public string MainContentImage { get; set; }
        public string SecondaryContent { get; set; }
        public string SecondaryContentImage { get; set; }
        public string TertiaryContent { get; set; }
        public string TertiaryContentImage { get; set; }
        public bool IsPublished { get; set; } = true;
    }
}
