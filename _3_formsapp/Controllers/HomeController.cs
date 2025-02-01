using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _3_formsapp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;

namespace _3_formsapp.Controllers;

public class HomeController : Controller
{
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
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)
    {

        if (imageFile == null)
        {
            ModelState.AddModelError("", "Image file is required.");
        }
        else
        {
            var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
            var extension = Path.GetExtension(imageFile.FileName);
            var randomFileName = $"{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("", "Invalid file type.");
            }

            if (ModelState.IsValid)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                model.Image = randomFileName;
                Repository.AddProduct(model);
                return RedirectToAction("Index");
            }
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }
}
