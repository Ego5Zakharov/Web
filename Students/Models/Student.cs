using System.ComponentModel.DataAnnotations;

namespace Students.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string StudentName{ get; set; }
        [Required]
        public string StudentAddress { get; set; }
    }
}
