using MediatR;
using School.Mediator.Queries;
using School.Modules.Student.BO.Contracts.Student;
using School.Modules.Student.BO.Dtos.Student.Response;
using School.Modules.Student.Logic.Interfaces;
using School.Modules.Student.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Mediator.Handlers
{
    public class GetAllStudentHandler : IRequestHandler<StudentGetAllQuery, IEnumerable<StudentResponse>>
    {
        protected readonly IStudentService _studentService;

        public GetAllStudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IEnumerable<StudentResponse>> Handle(StudentGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetAll();
        }
    }
}
