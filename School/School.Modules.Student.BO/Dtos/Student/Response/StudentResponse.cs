using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Modules.Student.BO.Dtos.Student.Response
{
    public class StudentResponse
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public StudentResponse(int id, string fullName, int age, DateTime dateOfBirth)
        {
            Id = id;
            FullName = fullName;
            Age = age;
            DateOfBirth = dateOfBirth;
        }
    }
}
