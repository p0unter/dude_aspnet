using Microsoft.AspNetCore.Mvc;

namespace _4_entityapp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
