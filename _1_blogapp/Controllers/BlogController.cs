using Microsoft.AspNetCore.Mvc;
using _1_blogapp.Models;

namespace _1_blogapp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.Products);
        }

        public IActionResult Detail(int id)
        {
            var blogM = Repository.GetById(id);
            return View(blogM);
        }
    }
}
