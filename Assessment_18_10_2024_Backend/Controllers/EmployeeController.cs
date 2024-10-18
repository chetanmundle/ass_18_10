using App.Core.App.Employee.Command;
using App.Core.App.Employee.Query;
using App.Core.Models.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Assessment_18_10_2024_Backend.Controllers
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

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto employee)
        {
            return Ok(await _mediator.Send(new CreateEmployeeCommand { CreateEmployeeDto = employee }));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployee()
        {
            return Ok(await _mediator.Send(new GetEmployeeQuery()));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employeeDto)
        {
            return Ok(await _mediator.Send(new UpdateEmployeeCommand { EmployeeDto = employeeDto }));
        }

        [HttpDelete("[action]/{EmpId:int}")]
        public async Task<IActionResult> DeleteEmployee(int EmpId)
        {
            return Ok(await _mediator.Send(new DeleteEmployeeCommand { EmployeeId = EmpId }));
        }
    }
}
