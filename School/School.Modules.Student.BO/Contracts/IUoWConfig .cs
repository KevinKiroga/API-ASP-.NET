using School.Modules.Student.BO.Contracts;
using School.Modules.Student.BO.Contracts.Student;

namespace School.Modules.Student.Infraestructure.Repository
{
    public interface IUoWConfig: IUnitOfWork
    {
        public IStudentRepository StudentRepository { get; }
    }
}
