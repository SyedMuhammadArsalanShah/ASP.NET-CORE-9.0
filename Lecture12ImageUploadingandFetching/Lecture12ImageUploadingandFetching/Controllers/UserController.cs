using Lecture12ImageUploadingandFetching.Models;
using Microsoft.AspNetCore.Mvc;


namespace Lecture12ImageUploadingandFetching.Controllers
{
    public class UserController : Controller
    {
        StudentDbContext dbContext;
        IWebHostEnvironment webHostEnvironment;

        public UserController(StudentDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(dbContext.emps.ToList());
        }



        public IActionResult ImgUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImgUp(EmpModel empModel)
        {
            string uniqueFileName = null;

            if (empModel.propic != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + empModel.propic.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                empModel.propic.CopyTo(new FileStream(filePath, FileMode.Create));


                Emp emp = new Emp()
                {
                    name = empModel.name,
                    email = empModel.email,
                    profile = uniqueFileName

                };
                dbContext.emps.Add(emp);
                dbContext.SaveChanges();
                ViewBag.emps = "Record Has been Added";
                return RedirectToAction("index");
            }
            return View();
        }








    }
}
