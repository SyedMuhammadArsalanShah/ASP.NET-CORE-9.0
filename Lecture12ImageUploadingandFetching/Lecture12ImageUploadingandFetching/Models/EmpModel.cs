using System.ComponentModel.DataAnnotations;

namespace Lecture12ImageUploadingandFetching.Models
{
    public class EmpModel
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public IFormFile propic { get; set; }
    }
}
