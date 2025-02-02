using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _3_formsapp.Models
{
    public class Product
    {
        [Display(Name = "Id")]
        public int ProductId { get; set; }

        //[Required(ErrorMessage = "Required place.")]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        [Display(Name = "Price")]
        public decimal? Price { get; set; }

        [Display(Name = "Image")]
        public string? Image { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public int? CategoryId { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
