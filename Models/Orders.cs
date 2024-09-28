namespace FoddieDB.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public decimal OrderTotal { get; set; }
        public string Status { get; set; }
       
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
