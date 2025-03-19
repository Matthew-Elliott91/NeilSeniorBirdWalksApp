namespace NeilSeniorBirdWalks.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TourScheduleID { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfParticipants { get; set; }

        // Navigation Properties

        public TourSchedule TourSchedule { get; set; }

    }
}
