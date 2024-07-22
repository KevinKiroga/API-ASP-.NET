using School.Modules.Student.BO.Dtos.Student.Request;
using School.Modules.Student.BO.Dtos.Student.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Modules.Student.Logic.Interfaces
{
    public interface IStudentService
    {
        Task<StudentResponse> Create(StudentRequest request);
        Task<IEnumerable<StudentResponse>> GetAll();
        Task<StudentResponse> GetById(int id);
        Task<StudentResponse> Update(int id, StudentRequest request);
        Task Delete(int id);
    }
}
