

using App.Core.Common;
using App.Core.Common.Exceptions;
using App.Core.Interfaces;
using App.Core.Models.Employee;
using App.Core.Models.Patient;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.Patient.Command
{
    public class CreatePatientCommand : IRequest<ResponseDto>
    {
        public CreatePatientDto CreatePatientDto { get; set; }
    }

    internal class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, ResponseDto>
    {
        private readonly IAppDbContext _appDbContext;
        public CreatePatientCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var createPatientDto = request.CreatePatientDto;

            if (createPatientDto is null)
                throw new BadRequest("Patient is Null");

            var validator = new CreatePatientDtoValidator();
            var val = validator.Validate(createPatientDto);

            if (!val.IsValid )
            {
                var errorMessage = val.Errors[0].ErrorMessage;
                throw new BadRequest(errorMessage);
            }

            if (createPatientDto.DateOfDischarge <= createPatientDto.DateOfAdmission)
                throw new BadRequest("Date Of Discharge Must be Greater than Date of Admission");

            var patient = createPatientDto.Adapt<Domain.Entities.Patient>();

            patient.IsDeleted = false;

            var res = await _appDbContext.Set<Domain.Entities.Patient>()
                     .AddAsync(patient, cancellationToken);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto
            {
                Status = 200,
                Message = "Employee Save SuccessFully",
                Data = patient.Adapt<PatientDto>()
            };
        }
    }

}
