namespace FoddieDB.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string CardName { get; set; }
        public int  CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string PaymentMode { get; set; }
        public int CvvNumber{ get; set; }
    }
}
