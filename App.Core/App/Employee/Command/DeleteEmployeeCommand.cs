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

namespace App.Core.App.Employee.Command
{
    public class DeleteEmployeeCommand : IRequest<ResponseDto>
    {
        public int EmployeeId { get; set; }
    }

    internal class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ResponseDto>
    {
        private readonly IAppDbContext _appDbContext;

        public DeleteEmployeeCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDto> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var empId = request.EmployeeId;

            if(empId <= 0) throw new BadRequest("Id Not Valid");

            var employee = await _appDbContext.Set<Domain.Entities.Employee>()
                                 .FirstOrDefaultAsync(e => e.EmployeeId == empId);

            if (employee is null) throw new NotFoundException("Employee Data with this id Not Found");

            employee.IsDeleted = true;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto
            {
                Status = 200,
                Message = $"Employee With {empId} is Deleted Successfully"
            };

        }
    }
}
