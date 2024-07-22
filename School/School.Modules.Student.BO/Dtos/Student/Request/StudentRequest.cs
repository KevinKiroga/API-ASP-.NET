using System.ComponentModel.DataAnnotations;

namespace School.Modules.Student.BO.Dtos.Student.Request
{
    public class StudentRequest
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
