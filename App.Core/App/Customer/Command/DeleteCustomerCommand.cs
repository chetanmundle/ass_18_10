using App.Core.Common;
using App.Core.Common.Exceptions;
using App.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.Customer.Command
{
    public class DeleteCustomerCommand : IRequest<ResponseDto>
    {
        public int CustomerId {  get; set; } 
    }

    internal class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand,ResponseDto>
    {
        private readonly IAppDbContext _appDbContext;

        public DeleteCustomerCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerId = request.CustomerId;

            if (customerId <= 0)
                throw new BadRequest("Id is Invalid");
            
            // This is Soft Delete
            var customer = await _appDbContext.Set<Domain.Entities.Customer>()
                           .FirstOrDefaultAsync(c => c.CustomerId == customerId, cancellationToken: cancellationToken);

            if (customer is null)
                throw new NotFoundException("Customer with this id Not Found / Exists");

            customer.IsDeleted = true;

            return new ResponseDto
            {
                Status = 200,
                Message = $"Student with CustomerId : {customerId} has been deleted.",
            };
        }
    }
}
