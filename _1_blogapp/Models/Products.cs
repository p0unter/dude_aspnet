namespace _1_blogapp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Subheading { get; set; }
        public required string Content { get; set; }
        public string ImgUrl { get; set; }
        public required string Author { get; set; }
    }
}