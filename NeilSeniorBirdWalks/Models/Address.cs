using System.ComponentModel.DataAnnotations;

namespace NeilSeniorBirdWalks.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "First Line of Address must be less than 100 characters")]
        [Display(Name = "First Line of Address")]
        public string AddressLine1 { get; set; } = string.Empty;
        [Required]
        [StringLength(100, ErrorMessage = "Second Line of Address must be less than 100 characters")]
        [Display(Name = "Second Line of Address")]
        public string AddressLine2 { get; set; } = string.Empty;
        [Required]
        [StringLength(50, ErrorMessage = "City must be less than 50 characters")]
        public string City { get; set; } = string.Empty;
        [Required]
        [StringLength(50, ErrorMessage = "County must be less than 50 characters")]
        public string County { get; set; } = string.Empty;
        private string _postcode = string.Empty;

        [Required]
        [StringLength(10, ErrorMessage = "Postcode must be less than 10 characters")]
        [RegularExpression(@"^(([A-Z][0-9]{1,2})|(([A-Z][A-HJ-Y][0-9]{1,2})|(([A-Z][0-9][A-Z])|([A-Z][A-HJ-Y][0-9]?[A-Z])))) ?[0-9][A-Z]{2}$",
                  ErrorMessage = "Please enter a valid UK postcode format")]
        public string Postcode
        {
            get => _postcode;
            set => _postcode = value?.Replace(" ", "").ToUpper() ?? string.Empty;
        }
        
        
    }
}
