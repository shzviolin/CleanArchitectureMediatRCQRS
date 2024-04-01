using Application.Commands.EmployeeCommand;
using Application.Queries.EmployeeQuery;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _mediator.Send(new GetEmployeeListQuery()));


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _mediator.Send(new GetEmployeeByIdQuery { Id = id }));


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee employee) => Ok(await _mediator.Send(new CreateEmployeeCommand { Employee = employee }));


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employee) => Ok(await _mediator.Send(new UpdateEmployeeCommand { Employee = employee }));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _mediator.Send(new DeleteEmployeeByIdCommand { Id = id }));
    }
}
