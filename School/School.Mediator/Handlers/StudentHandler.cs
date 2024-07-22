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
    public class StudentHandler: IRequestHandler<StudentCommand, StudentResponse>
    {
        protected readonly IStudentService _studentService;

        public StudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<StudentResponse> Handle(StudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentService.Create(request.Request);
        }
    }
}
