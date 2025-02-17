using Lecture10CodeFirstApproach_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lecture10CodeFirstApproach_CRUD.Controllers
{
    public class StudentController : Controller
    {
        StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

            // Action to display all students
            public IActionResult Index()
            {
                var students = _context.Students.ToList();
                return View(students);
            }

            // Action to display the student creation form
            public IActionResult Create()
            {
                return View();
            }

            // POST: Save a new student
            [HttpPost]
            public IActionResult Create(Student student)
            {
                if (ModelState.IsValid)
                {
                    _context.Students.Add(student);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(student);
            }



        public IActionResult getuser(int id)
        {
            var check = _context.Students.Where(h => h.Id == id).FirstOrDefault();

            if (check == null)
            {

            }

            return Json(check);

        }


        public IActionResult Update(int uid, string FirstName, string LastName, DateTime DateOfBirth, string Email)
        {
            Student edit = _context.Students.Where(x => x.Id == uid).FirstOrDefault();

            if (edit != null)
            {
                edit.FirstName =FirstName;
                edit.LastName = LastName;
                edit.DateOfBirth = DateOfBirth;
                edit.Email = Email;
                
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }


    }


    }

