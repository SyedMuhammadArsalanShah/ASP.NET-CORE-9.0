using Microsoft.AspNetCore.Mvc;

namespace Lecture02ConventionBasedRouting.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }
    }
}
