using System.ComponentModel.DataAnnotations;

namespace Lecture15CRUDbyEF.Models
{
    public class Student
    {
        [Key] 
        public int Id { get; set; }  // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }

}
