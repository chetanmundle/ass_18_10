using App.Core.App.Employee.Command;
using App.Core.App.Patient.Command;
using App.Core.App.Patient.Query;
using App.Core.Models.Employee;
using App.Core.Models.Patient;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Assessment_18_10_2024_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePatient(CreatePatientDto patientDto)
        {
            return Ok(await _mediator.Send(new CreatePatientCommand { CreatePatientDto = patientDto }));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPatient()
        {
            return Ok(await _mediator.Send(new GetPatientQuery()));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePatient(PatientDto patient)
        {
            return Ok(await _mediator.Send(new UpdatePatientCommand { PatientDto = patient }));
        }

        [HttpDelete("[action]/{patientId:int}")]
        public async Task<IActionResult> DeletePatinet(int patientId)
        {
            return Ok(await _mediator.Send(new DeletePatientCommand { PatientId = patientId }));
        }
    }
}
