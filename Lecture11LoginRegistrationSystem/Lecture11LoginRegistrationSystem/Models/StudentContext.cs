using Microsoft.EntityFrameworkCore;

namespace Lecture11LoginRegistrationSystem.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Students> myStudents { get; set; }
    }
}
