using MediatR;
using School.Mediator.Queries;
using School.Modules.Student.BO.Dtos.Student.Response;
using School.Modules.Student.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Mediator.Handlers
{
    public class GetByIdStudentHandler: IRequestHandler<StudentGetByIdQuery, StudentResponse>
    {
        protected readonly IStudentService _studentService;

        public GetByIdStudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<StudentResponse> Handle(StudentGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetById(request.id);
        }
    }
}
