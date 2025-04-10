namespace NeilSeniorBirdWalks.Models
{
    public class ImageFileInfo
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; }
        public string? Description { get; set; } = string.Empty;
        
    }
}
