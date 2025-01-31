using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _1_blogapp.Models;

namespace _1_blogapp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(Repository.Products);
    }
}
