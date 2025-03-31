using Microsoft.AspNetCore.Identity;
using NeilSeniorBirdWalks.Data;
using System.ComponentModel.DataAnnotations;

namespace NeilSeniorBirdWalks.Models
{
    public class Booking
    {
        public Booking()
        {
            UserId = string.Empty;
            BookingDate = DateTime.UtcNow;
            NumberOfParticipants = 1;
            TourScheduleId = 0;
        }

        public int Id { get; set; }
        
        [Required] 
        public required string UserId { get; set; }

        [Required]
        public required int TourScheduleId { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Range(1, 8, ErrorMessage ="Number of participants must be between 1 and 8")]
        public required int NumberOfParticipants { get; set; } = 1;

        // Navigation Properties

        public TourSchedule? TourSchedule { get; set; }
        public ApplicationUser? User { get; set; }

    }
}
