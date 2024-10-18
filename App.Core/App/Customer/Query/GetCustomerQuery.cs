using App.Core.Common;
using App.Core.Interfaces;
using App.Core.Models.Customer;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.Customer.Query
{
    public class GetCustomerQuery : IRequest<ResponseDto>
    {
    }

    internal class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, ResponseDto>
    {
        private readonly IAppDbContext _appDbContext;

        public GetCustomerQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var listOfCustomer = await _appDbContext.Set<Domain.Entities.Customer>()
                               .Where(c => c.IsDeleted == false)
                               .AsNoTracking()
                               .ToListAsync(cancellationToken);

            var result = listOfCustomer.Adapt<List<CustomerDto>>();

            return new ResponseDto
            {
                Status = 200,
                Message = "Successfully Fetched",
                Data = result
            };
        }
    }
}
