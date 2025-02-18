using System.ComponentModel.DataAnnotations;

namespace Lecture12ImageUploadingandFetching.Models
{
    public class Emp
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string profile { get; set; }
    }
}
