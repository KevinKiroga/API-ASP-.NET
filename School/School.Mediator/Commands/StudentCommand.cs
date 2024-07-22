using MediatR;
using School.Modules.Student.BO.Dtos.Student.Request;
using School.Modules.Student.BO.Dtos.Student.Response;

namespace School.Mediator.Commands
{
    public record StudentCommand(StudentRequest Request) : IRequest<StudentResponse>;
}
