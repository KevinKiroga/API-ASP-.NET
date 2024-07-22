using MediatR;
using School.Mediator.Commands;
using School.Modules.Student.BO.Dtos.Student.Response;
using School.Modules.Student.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Mediator.Handlers
{
    public class UpdateStudentHanlder: IRequestHandler<StudentUpdateCommand, StudentResponse>
    {
        protected readonly IStudentService _studentService;

        public UpdateStudentHanlder(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<StudentResponse> Handle(StudentUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _studentService.Update(request.Id, request.Request);
        }
    }
}
