using App.Core.Common;
using App.Core.Common.Exceptions;
using App.Core.Interfaces;
using App.Core.Models.Customer;
using App.Core.Models.Employee;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.Employee.Command
{
    public class CreateEmployeeCommand : IRequest<ResponseDto>
    {
        public CreateEmployeeDto CreateEmployeeDto { get; set; }
    }

    internal class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ResponseDto>
    {
        private readonly IAppDbContext _appDbContext;
        public CreateEmployeeCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponseDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var createEmployeeDto = request.CreateEmployeeDto;

            if (createEmployeeDto is null)
                throw new BadRequest("Employee is Null");

            var validator = new CreateEmployeeValidator();
            var val = validator.Validate(createEmployeeDto);

            if (!val.IsValid)
            {
                var errorMessage = val.Errors[0].ErrorMessage;
                throw new BadRequest(errorMessage);
            }

            var employee = createEmployeeDto.Adapt<Domain.Entities.Employee>();

            employee.IsDeleted = false;

            var res = await _appDbContext.Set<Domain.Entities.Employee>()
                     .AddAsync(employee, cancellationToken);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto
            {
                Status = 200,
                Message = "Employee Save SuccessFully",
                Data = employee.Adapt<EmployeeDto>()
            };
        }
    }
}
