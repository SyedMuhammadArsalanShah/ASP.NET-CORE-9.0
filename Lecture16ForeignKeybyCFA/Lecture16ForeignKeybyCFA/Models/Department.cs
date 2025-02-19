using System.ComponentModel.DataAnnotations;

namespace Lecture16ForeignKeybyCFA.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string DeptName { get; set; }
    }
}
