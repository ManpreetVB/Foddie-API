namespace FoddieDB.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Users> listUsers { get; set; }
        public Users user { get; set; }
        public Products products { get; set; }
        public List<Products> listProducts { get; set; }
        public List<Cart> listCart { get; set; }
        public List<Orders> listOrders { get; set; }
        public Orders order { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string Type { get; set; }

    }
}
