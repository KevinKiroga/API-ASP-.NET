using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Mediator.Commands;
using School.Mediator.Queries;
using School.Modules.Student.BO.Dtos.Student.Request;
using School.Modules.Student.BO.Dtos.Student.Response;

namespace School.Controllers
{
    [Route("student")]
    [ApiController]
    [Produces("application/json")]
    //[EnableCors("AllowAllOrigins")]
    public class StudentController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(StudentRequest request)
        {
            await _mediator.Send(new StudentCommand(request));
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetAll()
        {
            var students = await _mediator.Send(new StudentGetAllQuery());
            return Ok(students);
        }

        [HttpGet("id")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StudentResponse>> GetById(int id)
        {
            var student = await _mediator.Send(new StudentGetByIdQuery(id));
            return Ok(student);
        }

        [HttpPut("id")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StudentResponse>> Update(int id, StudentRequest request)
        {
            var student = await _mediator.Send(new StudentUpdateCommand(id, request));
            return Ok(student);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new StudentDeleteCommand(id));
            return NoContent();
        }
    }
}
