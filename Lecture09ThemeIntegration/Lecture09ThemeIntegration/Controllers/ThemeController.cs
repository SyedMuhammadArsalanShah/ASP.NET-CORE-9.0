using Microsoft.AspNetCore.Mvc;

namespace Lecture09ThemeIntegration.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
