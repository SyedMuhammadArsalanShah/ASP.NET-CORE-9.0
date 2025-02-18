using System.ComponentModel.DataAnnotations;

namespace Lecture11LoginRegistrationSystem.Models
{
    public class Students
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
    }
}
