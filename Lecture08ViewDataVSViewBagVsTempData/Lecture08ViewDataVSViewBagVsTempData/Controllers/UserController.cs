using Microsoft.AspNetCore.Mvc;

namespace Lecture08ViewDataVSViewBagVsTempData.Controllers
{
    public class UserController : Controller
    {
      
           public IActionResult IndexViewData()
        {
            List<string> students = new List<string> { "Fatimah", "Hiba", "Mahnoor" };
            ViewData["Students"] = students;
            return View();
        }


        public IActionResult IndexViewBag()
        {
            List<string> courses = new List<string> { "ASP.NET Core", "Flutter", "Data Science" };
            ViewBag.Courses = courses;
            return View();
        }
        public IActionResult IndexTempData()
        {
            List<string> cities = new List<string> { "Karachi", "Lahore", "Islamabad" };
            TempData["Cities"] = cities;
            return RedirectToAction("AnotherAction");
            //return View();
        }

        public IActionResult AnotherAction()
        {
            return View();
        }

    }
}
