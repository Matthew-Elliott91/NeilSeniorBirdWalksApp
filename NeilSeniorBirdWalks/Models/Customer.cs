using NeilSeniorBirdWalks.Data;
using System.ComponentModel.DataAnnotations;

namespace NeilSeniorBirdWalks.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First Name must be less than 20 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last Name must be less than 20 characters")]
        public string LastName { get; set; }
        [Required]
        public Address Address { get; set; }
        public string UserId { get; set; }

        // Navigation property
        public virtual ApplicationUser? User { get; set; }
    }
}
