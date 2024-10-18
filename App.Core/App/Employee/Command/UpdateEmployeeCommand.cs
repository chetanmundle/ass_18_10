using App.Core.Common;
using App.Core.Common.Exceptions;
using App.Core.Interfaces;
using App.Core.Models.Employee;
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
    public class UpdateEmployeeCommand : IRequest<ResponseDto>
    {
        public EmployeeDto EmployeeDto {  get; set; }
    }

    internal class UpdateEmployeeCommandHandaler  : IRequestHandler<UpdateEmployeeCommand, ResponseDto>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdateEmployeeCommandHandaler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponseDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeDto = request.EmployeeDto;

            if (employeeDto is null)
                throw new BadRequest("Employee is Null");

            var employee = await _appDbContext.Set<Domain.Entities.Employee>()
                                 .FirstOrDefaultAsync(e => e.EmployeeId == employeeDto.EmployeeId,
                                                      cancellationToken: cancellationToken);

            if (employee is null) throw new NotFoundException("Employee Not Found With Given ID");

            employee.FirstName = employeeDto.FirstName;
            employee.MiddleName = employeeDto.MiddleName;
            employee.LastName = employeeDto.LastName;
            employee.Email = employeeDto.Email;
            employee.PhoneNumber = employeeDto.PhoneNumber;
            employee.Gender = employeeDto.Gender;
            employee.DateOfBirth = employeeDto.DateOfBirth;
            employee.AddressLine1 = employeeDto.AddressLine1;
            employee.AddressLine2 = employeeDto.AddressLine2;
            employee.City = employeeDto.City;
            employee.State = employeeDto.State;
            employee.ZipCode = employeeDto.ZipCode;
            employee.Country = employeeDto.Country;
            employee.Department = employeeDto.Department;
            employee.Position = employeeDto.Position;
            employee.Salary = employeeDto.Salary;
            employee.IsFullTime = employeeDto.IsFullTime;
            employee.JoiningDate = employeeDto.JoiningDate;
            employee.LastPromotionDate = employeeDto.LastPromotionDate;
            employee.NumberOfProjects = employeeDto.NumberOfProjects;
            employee.EmergencyContactNumber = employeeDto.EmergencyContactNumber;
            employee.IsDeleted = false;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto
            {
                Status = 200,
                Data = "Employee Updated Successfully",
            };

    }
    }
}
