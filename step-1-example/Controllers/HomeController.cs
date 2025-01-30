using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using step_1_example.Models;

namespace step_1_example.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(Repository.Products);
    }
}
