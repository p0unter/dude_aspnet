using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _3_formsapp.Models
{
    public class Product
    {
        [Display(Name = "Id")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Required place.")]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue)]
        [Display(Name = "Price")]
        public decimal? Price { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string? Image { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int? CategoryId { get; set; }
    }
}
