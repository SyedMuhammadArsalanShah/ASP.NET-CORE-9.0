using Lecture16ForeignKeybyCFA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lecture16ForeignKeybyCFA.Controllers
{
    public class UserController : Controller
    {



        DSContext dsContext;
public UserController(DSContext dsContext)
        {
            this.dsContext = dsContext;
        }

        public IActionResult Index()
        {
            return View(dsContext.students.Include(x=>x.Department).ToList());
        }

        public IActionResult AddDept()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDept(Department department)
        {


            dsContext.departments.Add(department);
            dsContext.SaveChanges();
            ModelState.Clear();
            return View();
        }


        public IActionResult AddStudents()
        {

            ViewBag.getDepts = dsContext.departments.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddStudents(Students student)
        {
            dsContext.students.Add(student);
            dsContext.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index");
        }






    }
}
