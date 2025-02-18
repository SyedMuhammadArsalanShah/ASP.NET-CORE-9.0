using Lecture11LoginRegistrationSystem.Models;

using Microsoft.AspNetCore.Mvc;

namespace Lecture11LoginRegistrationSystem.Controllers
{
    public class UserController : Controller
    {
        StudentContext studentContext;

        public UserController(StudentContext studentContext)
        {
            this.studentContext = studentContext;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Students students)
        {
            studentContext.myStudents.Add(students);
            studentContext.SaveChanges();
            ModelState.Clear();
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Students students)
        {
           var check= studentContext.myStudents.Where(x=>x.Email == students.Email && x.password== students.password).FirstOrDefault();
            if (check != null)
            {
                HttpContext.Session.SetString("myname", check.Name);

                string name = HttpContext.Session.GetString("myname");

                ViewBag.name = name;

                return View("Index");
            }
            else
            {
                ViewBag.error = "O bhai email ya pass sahi karo ";
                return View();
            }

        }


        public IActionResult Logout()
        {

            if (HttpContext.Session.GetString("myname")!="")
            {
                HttpContext.Session.SetString("myname", "");
                return RedirectToAction("Login");
            }
            return View();
        }


    }
}
