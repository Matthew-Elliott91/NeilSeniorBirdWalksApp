namespace NeilSeniorBirdWalks.Models
{
    public class GiftVoucher
    {
        public int Id { get; set; }
        public string VoucherCode { get; set; }
        public int TourScheduleId { get; set; }
        public string BuyerEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public string BuyerName { get; set; }  
        public string ReceiverName { get; set; }
        public string PersonalMessage { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        public bool IsRedeemed { get; set; }

        //Navigation properties
        public TourSchedule TourSchedule { get; set; }
    }
}
