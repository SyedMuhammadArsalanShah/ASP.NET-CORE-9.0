using Microsoft.EntityFrameworkCore;

namespace Lecture16ForeignKeybyCFA.Models
{
    public class DSContext : DbContext
    {
        public DSContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Department> departments { get; set; }
        public DbSet<Students> students { get; set; }
    }
}
