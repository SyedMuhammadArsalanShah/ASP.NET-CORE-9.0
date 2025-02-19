using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lecture16ForeignKeybyCFA.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string address { get; set; }

        public int deptId { get; set; }

        [ForeignKey("deptId")]
        public virtual Department Department { get; set; }



    }
}
