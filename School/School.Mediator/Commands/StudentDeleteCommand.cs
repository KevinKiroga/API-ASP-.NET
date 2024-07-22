using MediatR;
using School.Modules.Student.BO.Dtos.Student.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Mediator.Commands
{
    public record StudentDeleteCommand(int Id) : IRequest<Unit>;
}
