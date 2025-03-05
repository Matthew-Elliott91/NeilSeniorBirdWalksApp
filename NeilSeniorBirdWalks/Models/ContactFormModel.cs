using System.ComponentModel.DataAnnotations;

namespace NeilSeniorBirdWalks.Models
{
    public class ContactFormModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression(@"^(\+\d{1,3}[- ]?)?\d{10,15}$", ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter a subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        [MinLength(10, ErrorMessage = "Your message should be at least 10 characters long")]
        public string Message { get; set; }

        public DateTime DateSubmitted { get; set; } = DateTime.Now;
    }
}
