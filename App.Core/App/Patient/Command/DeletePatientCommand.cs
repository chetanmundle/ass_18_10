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

namespace App.Core.App.Patient.Command
{
    public class DeletePatientCommand : IRequest<ResponseDto>
    {
        public int PatientId { get; set; }
    }
    internal class DeletePatientCommandHandaler : IRequestHandler<DeletePatientCommand, ResponseDto>
    {
        private readonly IAppDbContext _appDbContext;

        public DeletePatientCommandHandaler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDto> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patientId = request.PatientId;

            if (patientId <= 0) throw new BadRequest("Id Not Valid");

            var patient = await _appDbContext.Set<Domain.Entities.Patient>()
                                 .FirstOrDefaultAsync(e => e.PatientId == patientId);

            if (patient is null) throw new NotFoundException("Patient Data with this id Not Found");

            patient.IsDeleted = true;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto
            {
                Status = 200,
                Message = $"Employee With {patientId} is Deleted Successfully"
            };
        }
    }
   
}
