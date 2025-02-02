using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _3_formsapp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;

namespace _3_formsapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string searchString, string category)
    {
        var products = Repository.Products;

        if (!String.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            products = products.Where(m => m.Name!.ToLower().Contains(searchString.ToLower())).ToList(); // m.Name!
        }

        if (!String.IsNullOrEmpty(category) && category != "0")
        {
            products = products.Where(m => m.CategoryId.ToString() == category).ToList();
        }

        var model = new ProductViewModel
        {
            Products = products,
            Categories = Repository.Categories,
            SelectedCategory = category
        };
        return View(model);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product model, IFormFile? ImageFile)
    {
        model.ProductId = Repository.Products.Count() + 1;

        if (ImageFile == null)
        {
            ModelState.AddModelError("ImageFile", "Image file is required.");
            Console.WriteLine("Image file is required.");
        }
        else
        {
            var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
            var extension = Path.GetExtension(ImageFile.FileName);

            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("ImageFile", "Invalid file type.");
                Console.WriteLine("Invalid file type.");
            }

            if (ModelState.IsValid)
            {
                var randomFileName = $"{Guid.NewGuid()}{extension}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                model.Image = randomFileName;
                Repository.AddProduct(model);
                return RedirectToAction("Index");
            }
        }

        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        {
            Console.WriteLine(error.ErrorMessage);
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }
}
