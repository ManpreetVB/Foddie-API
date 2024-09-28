namespace FoddieDB.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int PostCode { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public int IsActive { get; set; }
        public string Type { get; set; }
    }
}
