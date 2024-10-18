using App.Core.App.Customer.Command;
using App.Core.App.Customer.Query;
using App.Core.Models.Customer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Assessment_18_10_2024_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequestDto customer)
        {
            return Ok(await _mediator.Send(new CreateCustomerCommand { CustomerDto = customer}));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await _mediator.Send(new GetCustomerQuery()));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCustomer(CustomerDto customerDto)
        {
            return Ok(await _mediator.Send(new UpdateCustomerCommand { CustomerDto = customerDto }));
        }

        [HttpDelete("[action]/{customerId:int}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            return Ok( await _mediator.Send(new DeleteCustomerCommand { CustomerId = customerId }));
        }
    }
}
