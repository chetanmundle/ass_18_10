using App.Core.Common;
using App.Core.Common.Exceptions;
using App.Core.Interfaces;
using App.Core.Models.Customer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.Customer.Command
{
    public class UpdateCustomerCommand : IRequest<ResponseDto>
    {
        public CustomerDto CustomerDto { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ResponseDto>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdateCustomerCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var CustomerDto = request.CustomerDto;

            if (CustomerDto is null)
                throw new BadRequest("Customer is Null");

            var customer = await _appDbContext.Set<Domain.Entities.Customer>()
                                 .FirstOrDefaultAsync(c => c.CustomerId == CustomerDto.CustomerId, cancellationToken: cancellationToken);

            if (customer is null)
                throw new NotFoundException("Customer With this id Not Found");

             customer.FirstName = CustomerDto.FirstName;
             customer.MiddleName = CustomerDto.MiddleName;
             customer.LastName = CustomerDto.LastName;
             customer.Email = CustomerDto.Email;
             customer.Phone = CustomerDto.Phone;
             customer.Gender = CustomerDto.Gender;
             customer.AddressLine1 = CustomerDto.AddressLine1;
             customer.AddressLine2 = CustomerDto.AddressLine2;
             customer.City = CustomerDto.City;
             customer.State = CustomerDto.State;
             customer.Country  = CustomerDto.Country;
             customer.ZipCode = CustomerDto.ZipCode;

             customer.DateOfBirth = CustomerDto.DateOfBirth;
             customer.Occupation = CustomerDto.Occupation;
             customer.Company = CustomerDto.Company;
             customer.Department = CustomerDto.Department;
            customer.CreatedDate = CustomerDto.CreatedDate;
            customer.UpdatedDate = DateTime.Now.Date;
            customer.IsDeleted = false;

        await _appDbContext.SaveChangesAsync();

            return new ResponseDto
            {
                Status = 200,
                Message = "Customer Updated Successfully"
            };

    }
    }
}
