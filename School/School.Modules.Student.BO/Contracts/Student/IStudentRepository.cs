using School.Modules.Student.BO.Models;

namespace School.Modules.Student.BO.Contracts.Student
{
    public interface IStudentRepository
    {
        Task<StudentModel> AddStudent(StudentModel student);
        Task<IEnumerable<StudentModel>> GetAllStudents();
        Task<StudentModel> GetById(int id);
        Task<StudentModel> UpdateStudent(StudentModel student);

        Task DeleteStudent(StudentModel student);
    }
}
