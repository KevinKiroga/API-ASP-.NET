using MediatR;
using School.Mediator.Commands;
using School.Modules.Student.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Mediator.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<StudentDeleteCommand, Unit>
    {
        protected readonly IStudentService _studentService;

        public DeleteStudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Unit> Handle(StudentDeleteCommand request, CancellationToken cancellationToken)
        {
            await _studentService.Delete(request.Id);
            return Unit.Value;
        }
    }
}
