using Microsoft.EntityFrameworkCore;

namespace Lecture12ImageUploadingandFetching.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Emp> emps { get; set; }
    }
}
