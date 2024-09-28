namespace FoddieDB.Models
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public int IsActive { get; set; }
    }
}
