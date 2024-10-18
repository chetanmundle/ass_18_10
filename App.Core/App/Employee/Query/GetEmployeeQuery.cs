using App.Core.Common;
using App.Core.Interfaces;
using App.Core.Models.Customer;
using App.Core.Models.Employee;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.Employee.Query
{
    public class GetEmployeeQuery : IRequest<ResponseDto>
    {
    }

    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery,ResponseDto>
    {
        private readonly IAppDbContext _appDbContext;
        public GetEmployeeQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var listOfEmployee = await _appDbContext.Set<Domain.Entities.Employee>()
                                       .Where(x => x.IsDeleted != true)
                                       .AsNoTracking()
                                       .ToListAsync(cancellationToken);

            var result = listOfEmployee.Adapt<List<EmployeeDto>>();

            return new ResponseDto
            {
                Status = 200,
                Message = "Successfully Fetched",
                Data = result
            };
        }
    }
}
