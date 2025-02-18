using Lecture14SearchbyName.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lecture14SearchbyName.Controllers
{
    public class StudentController : Controller
    {

        StudentDbContext studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        public IActionResult Index(string search)
        {
            return View(studentDbContext.Students.Where(x=>x.FirstName.Contains(search)|| search==null).ToList());
        }
    }
}
