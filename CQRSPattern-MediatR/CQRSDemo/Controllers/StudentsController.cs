using CQRSDemo.Commands;
using CQRSDemo.Models;
using CQRSDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StudentsController(IMediator mediator)
        {
           this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentCommand studentCommand)
        {
            var record = await this.mediator.Send(studentCommand);

            var student = new Student()
            {
                Id = record.Id,
                StudentAddress = record.StudentAddress,
                StudentAge = record.StudentAge,
                StudentName = record.StudentName
            };

            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody]UpdateStudentCommand studentCommand)
        {
            var status = await this.mediator.Send(studentCommand);
            return Ok(0);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent([FromBody] DeleteStudentCommand studentCommand)
        {
            var status = await this.mediator.Send(studentCommand);
            return Ok(status);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var records = await this.mediator.Send(new GetStudentListQuery());

            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetStudentQuery() { Id = id };

            var response = await this.mediator.Send(request);

            return Ok(response);
        }

    }
}
