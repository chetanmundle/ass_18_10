using App.Core.Common;
using App.Core.Common.Exceptions;
using App.Core.Interfaces;
using App.Core.Models.Patient;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.Patient.Command
{
    public class UpdatePatientCommand : IRequest<ResponseDto>
    {
        public PatientDto PatientDto { get;     set; }
    }

    internal class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, ResponseDto>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdatePatientCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDto> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patientDto = request.PatientDto;

            if (patientDto is null)
                throw new BadRequest("Employee is Null");

            var patient = await _appDbContext.Set<Domain.Entities.Patient>()
                                 .FirstOrDefaultAsync(e => e.PatientId == patientDto.PatientId,
                                                      cancellationToken: cancellationToken);

            if (patient is null) throw new NotFoundException("Employee Not Found With Given ID");

            patient.FirstName = patientDto.FirstName;
            patient.LastName = patientDto.LastName;
            patient.MiddleName = patientDto.MiddleName;
            patient.DateOfBirth = patientDto.DateOfBirth;
            patient.Gender = patientDto.Gender;
            patient.PhoneNumber = patientDto.PhoneNumber;
            patient.Email = patientDto.Email;
            patient.Address = patientDto.Address;
            patient.City = patientDto.City;
            patient.State = patientDto.State;
            patient.ZipCode = patientDto.ZipCode;
            patient.Country = patientDto.Country;
            patient.DateOfAdmission = patientDto.DateOfAdmission;
            patient.DateOfDischarge = patientDto.DateOfDischarge;
            patient.MedicalHistory = patientDto.MedicalHistory;
            patient.BloodGroup = patientDto.BloodGroup;
            patient.EmergencyContactName = patientDto.EmergencyContactName;
            patient.EmergencyContactPhone = patientDto.EmergencyContactPhone;
            patient.EmergencyContactRelation = patientDto.EmergencyContactRelation;
            patient.IsInsured = patientDto.IsInsured;
            patient.InsuranceProvider = patientDto.InsuranceProvider;
            patient.IsDeleted = false;


           await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto
            {
                Status = 200,
                Data = "Employee Updated Successfully",
            }; 

    }
    }

}
