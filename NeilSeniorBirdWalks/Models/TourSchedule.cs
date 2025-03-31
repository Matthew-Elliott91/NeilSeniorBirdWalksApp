namespace NeilSeniorBirdWalks.Models
{
    public class TourSchedule
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int? AvailableSpots { get; set; } = 8;
        public bool IsCanceled { get; set; }
        public string TourScheduleImgUrl { get; set; } = "images/logo.svg";
        public string? TourSchduleInfo { get; set; }


        //Calculate Title Property
        public string Title => Tour?.Title + " - " + StartDateTime.ToString("d MMM yyyy");

        // Navigation properties
        public Tour Tour { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
