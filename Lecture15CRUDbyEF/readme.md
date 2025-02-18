To create a CRUD (Create, Read, Update, Delete) application using the Code First approach in ASP.NET Core MVC with Visual Studio 2022, follow these steps:

**1. Set Up the ASP.NET Core MVC Project**

- **Launch Visual Studio 2022**: Open Visual Studio 2022.

- **Create a New Project**:
  - Select "Create a new project."
  - Choose "ASP.NET Core Web App (Model-View-Controller)" and click "Next."
  - Name the project (e.g., "ContosoUniversity") and click "Create."

- **Configure the Project**:
  - In the "Additional Information" dialog, ensure ".NET 9.0" is selected.
  - Ensure "Configure for HTTPS" is checked.
  - Click "Create" to set up the project.

**2. Install Entity Framework Core**

- **Manage NuGet Packages**:
  - Right-click the project in the Solution Explorer.
  - Select "Manage NuGet Packages."
  - Search for and install the following packages:
    - `Microsoft.EntityFrameworkCore.SqlServer`
    - `Microsoft.EntityFrameworkCore.Tools`

**3. Define the Data Model**

- **Create the Model Class**:
  - Right-click the "Models" folder.
  - Select "Add" > "Class."
  - Name it "Student.cs" and define properties such as `ID`, `FirstName`, `LastName`, `EnrollmentDate`, etc.

**4. Configure the Database Context**

- **Add the DbContext Class**:
  - Right-click the "Data" folder (create it if it doesn't exist).
  - Add a new class named "SchoolContext.cs."
  - Inherit from `DbContext` and include `DbSet<Student>` and other entities.

- **Register the Context**:
  - Open `Program.cs`.
  - In the `ConfigureServices` method, add:
    ```csharp
    services.AddDbContext<SchoolContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    ```

- **Set Up the Connection String**:
  - Open `appsettings.json`.
  - Add:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;"
    }
    ```

**5. Create the Database**

- **Enable Migrations**:
  - Open the Package Manager Console (`Tools` > `NuGet Package Manager` > `Package Manager Console`).
  - Run:
    ```
    Add-Migration InitialCreate
    ```

- **Update the Database**:
  - In the same console, run:
    ```
    Update-Database
    ```

**6. Scaffold the CRUD Operations**

- **Add a Controller**:
  - Right-click the "Controllers" folder.
  - Select "Add" > "New Scaffolded Item."
  - Choose "MVC Controller with views, using Entity Framework."
  - Select the "Student" model and "SchoolContext" for the data context.
  - Click "Add" to generate the controller and views.

**7. Update the Navigation Menu**

- **Modify Layout**:
  - Open `Views/Shared/_Layout.cshtml`.
  - Add a new menu item for "Students" in the navigation bar.

**8. Run the Application**

- **Start Debugging**:
  - Press F5 or click the "IIS Express" button to run the application.
  - Navigate to `/Students` to access the CRUD interface for students.

 