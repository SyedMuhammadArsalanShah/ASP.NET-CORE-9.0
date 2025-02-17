using Microsoft.AspNetCore.Mvc;

namespace Lecture06RazorEngineView.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
