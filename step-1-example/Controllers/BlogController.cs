using Microsoft.AspNetCore.Mvc;
using step_1_example.Models;

namespace step_1_example.Controllers
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
