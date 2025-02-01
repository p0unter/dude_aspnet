using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _3_formsapp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _3_formsapp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(string searchString, string category)
    {
        var products = Repository.Products;

        if (!String.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            products = products.Where(m => m.Name.ToLower().Contains(searchString.ToLower())).ToList();
        }

        if (!String.IsNullOrEmpty(category) && category != "0")
        {
            products = products.Where(m => m.CategoryId.ToString() == category).ToList();
        }

        // ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name", category);

        var model = new ProductViewModel
        {
            Products = products,
            Categories = Repository.Categories,
            SelectedCategory = category
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
