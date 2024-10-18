using App.Core.Common;
using App.Core.Common.Exceptions;
using App.Core.Interfaces;
using App.Core.Models.Customer;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.Customer.Command
{
    public class CreateCustomerCommand : IRequest<ResponseDto>
    {
        public CreateCustomerRequestDto CustomerDto { get; set; }
    }
    internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResponseDto>
    {
        private readonly IAppDbContext _appDbContext;
        public CreateCustomerCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }          
        public async Task<ResponseDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerDto = request.CustomerDto;

            if (customerDto is null)
                throw new BadRequest("Customer is Null");

            var validator = new CreateCustomerRequestDtoValidator();
            var val = validator.Validate(customerDto);

            if (!val.IsValid)
            {
                var errorMessage = val.Errors[0].ErrorMessage;
                throw new BadRequest(errorMessage);
            }

            var customer = customerDto.Adapt<Domain.Entities.Customer>();

            customer.DateOfBirth = customer.DateOfBirth.Date;
            customer.IsDeleted = false;
            customer.UpdatedDate = DateTime.Now;
            customer.CreatedDate = DateTime.Now;

            var saveData =  await _appDbContext.Set<Domain.Entities.Customer>().AddAsync(customer);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto
            {
                Status = 200,
                Message = "Customer Created Successfully",
                Data = customer.Adapt<CustomerDto>()
            };
        }
    }
}
