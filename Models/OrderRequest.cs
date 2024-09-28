namespace FoddieDB.Models
{
    public class OrderRequest
    {
        public string Email { get; set; } 
        public int UserId { get; set; } 

        
        
        

        public int PaymentId { get; set; }
        public string PaymentMode { get; set; }
        public decimal OrderTotal { get; set; }
        public List<OrderItem> OrderItems { get; set; } 

        
        public string Address { get; set; }
        public int PostCode { get; set; }
        public int PhoneNumber { get; set; }
    }
}
