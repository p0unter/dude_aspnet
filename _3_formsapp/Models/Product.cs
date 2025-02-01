using System.ComponentModel.DataAnnotations;

namespace _3_formsapp.Models
{
    public class Product
    {
        [Display(Name = "Id")]
        public int ProductId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
