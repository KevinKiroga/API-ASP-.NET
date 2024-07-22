using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Modules.Student.Infraestructure.Entity
{
    [Table("students")]
    public class StudentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

    }
}
