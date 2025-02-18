

### 1. **Create a New Project:**
   - Open **Visual Studio 2022**.
   - Click on **Create a new project**.
   - Select **ASP.NET Core Web App** and click **Next**.
   - Name the project (e.g., `Lecture10CodeFirstApproach_CRUD`) and choose the location for the project.
   - Choose **.NET 6.0** (or 9.0, if available) and select **Web Application (Model-View-Controller)** template. Click **Create**.

### 2. **Set Up the Data Model:**
   In your `Models` folder, create a class named `Student.cs` with the following properties:
   ```csharp
   namespace Lecture10CodeFirstApproach_CRUD.Models
   {
       public class Student
       {
           public int Id { get; set; }
           public string FirstName { get; set; }
           public string LastName { get; set; }
           public DateTime DateOfBirth { get; set; }
           public string Email { get; set; }
       }
   }
   ```

### 3. **Set Up the Database Context:**
   In the `Models` folder, create the `StudentDbContext.cs`:
   ```csharp
   using Microsoft.EntityFrameworkCore;

   namespace Lecture10CodeFirstApproach_CRUD.Models
   {
       public class StudentDbContext : DbContext
       {
           public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
           {
           }

           public DbSet<Student> Students { get; set; }
       }
   }
   ```

### 4. **Configure the Connection String:**
   Open `appsettings.json` and add a connection string for your database:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "YourConnectionStringHere"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft": "Warning",
         "Microsoft.Hosting.Lifetime": "Information"
       }
     },
     "AllowedHosts": "*"
   }
   ```

### 5. **Configure Services in `Startup.cs` or `Program.cs`:**
   In `Program.cs`, add the following code to configure the `DbContext`:
   ```csharp
   using Lecture10CodeFirstApproach_CRUD.Models;
   using Microsoft.EntityFrameworkCore;

   var builder = WebApplication.CreateBuilder(args);

   // Add services to the container.
   builder.Services.AddDbContext<StudentDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
   builder.Services.AddControllersWithViews();

   var app = builder.Build();

   // Configure the HTTP request pipeline.
   if (app.Environment.IsDevelopment())
   {
       app.UseDeveloperExceptionPage();
   }
   else
   {
       app.UseExceptionHandler("/Home/Error");
       app.UseHsts();
   }

   app.UseHttpsRedirection();
   app.UseStaticFiles();
   app.UseRouting();

   app.MapControllerRoute(
       name: "default",
       pattern: "{controller=Home}/{action=Index}/{id?}");

   app.Run();
   ```

### 6. **Add Database Migration and Update the Database:**
   - Open **Package Manager Console** (`Tools` -> `NuGet Package Manager` -> `Package Manager Console`).
   - Run the following commands to create the migration and update the database:
     ```bash
     Add-Migration InitialCreate
     Update-Database
     ```

### 7. **Create the Student Controller:**
   In the `Controllers` folder, create a controller named `StudentController.cs`:
   ```csharp
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
                   // handle null case if necessary
               }

               return Json(check);
           }

           public IActionResult Update(int uid, string FirstName, string LastName, DateTime DateOfBirth, string Email)
           {
               Student edit = _context.Students.Where(x => x.Id == uid).FirstOrDefault();

               if (edit != null)
               {
                   edit.FirstName = FirstName;
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
   ```

### 8. **Create the Views:**
   - In the `Views` folder, create a folder named `Student`.
   - Add the **Index.cshtml** view:
     ```html
     @model IEnumerable<Lecture10CodeFirstApproach_CRUD.Models.Student>

     @{
         ViewData["Title"] = "Index";
     }

     <h1>Index</h1>

     <p>
         <a asp-action="Create">Create New</a>
     </p>
     <table class="table">
         <thead>
             <tr>
                 <th>
                     @Html.DisplayNameFor(model => model.FirstName)
                 </th>
                 <th>
                     @Html.DisplayNameFor(model => model.LastName)
                 </th>
                 <th>
                     @Html.DisplayNameFor(model => model.DateOfBirth)
                 </th>
                 <th>
                     @Html.DisplayNameFor(model => model.Email)
                 </th>
                 <th></th>
             </tr>
         </thead>
         <tbody>
         @foreach (var item in Model) {
             <tr>
                 <td>
                     @Html.DisplayFor(modelItem => item.FirstName)
                 </td>
                 <td>
                     @Html.DisplayFor(modelItem => item.LastName)
                 </td>
                 <td>
                     @Html.DisplayFor(modelItem => item.DateOfBirth)
                 </td>
                 <td>
                     @Html.DisplayFor(modelItem => item.Email)
                 </td>
                 <td>
                     <button class="btn btn-outline-info" data-id="@item.Id" id="editBtn">Edit</button> |
                     <a asp-action="Details" asp-route-id="@item.Id">Details</a> |
                     <a asp-action="Delete" asp-route-id="@item.Id">Delete</a>
                 </td>
             </tr>
         }
         </tbody>
     </table>
     ```

### 9. **Implement the Modal for Editing:**
   - In the **Index.cshtml** file, add the modal for updating the student (as shown in the original code).
   
### 10. **Add JavaScript for AJAX:**
   Ensure you add the necessary JavaScript code to handle the AJAX request for fetching student details when the edit button is clicked:
   ```javascript
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>

   <script>
       $(document).ready(function(){
           $(document).on("click", "#editBtn", function(){
               var id = $(this).attr("data-id");
               $.ajax({
                   url: "getuser/" + id,
                   type: "POST",
                   success: function(response) {
                       $("#exampleModal").modal("show");
                       $("#uid").val(response.id);
                       $("#FirstName").val(response.firstName);
                       $("#LastName").val(response.lastName);
                       $("#DOB").val(response.dateOfBirth);
                       $("#Email").val(response.email);
                   }
               });
           });
       });
   </script>
   ```

### 11. **Run the Application:**
   - Build the project (`Ctrl+Shift+B`) and run it (`F5`).
   - You should be able to access the student CRUD operations (Create, Edit, Update, and Delete) using the views and controller.

