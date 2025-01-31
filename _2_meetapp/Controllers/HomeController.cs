using _2_meetapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1_meetapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}