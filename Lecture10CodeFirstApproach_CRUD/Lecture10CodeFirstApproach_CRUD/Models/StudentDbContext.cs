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
