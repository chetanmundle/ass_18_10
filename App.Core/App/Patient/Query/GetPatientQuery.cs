using App.Core.Common;
using App.Core.Interfaces;
using App.Core.Models.Employee;
using App.Core.Models.Patient;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.Patient.Query
{
    public class GetPatientQuery : IRequest<ResponseDto>
    {
    }

    internal class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, ResponseDto>
    {
        private readonly IAppDbContext _appDbContext;
        public GetPatientQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDto> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var listOfEmployee = await _appDbContext.Set<Domain.Entities.Patient>()
                                        .Where(x => x.IsDeleted != true)
                                        .AsNoTracking()
                                        .ToListAsync(cancellationToken);

            var result = listOfEmployee.Adapt<List<PatientDto>>();

            return new ResponseDto
            {
                Status = 200,
                Message = "Successfully Fetched",
                Data = result
            };
        }
    }
}
