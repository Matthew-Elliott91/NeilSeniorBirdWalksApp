namespace NeilSeniorBirdWalks.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TourScheduleId { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public int NumberOfParticipants { get; set; } = 1;

        // Navigation Properties

        public TourSchedule TourSchedule { get; set; }

    }
}
