using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Training;
using QL.Infra.Repository.Repositories;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLTrainingsController : ControllerBase
    {
        private readonly ILogger<QLTrainingsController> _logger;
        private IQLTrainingsRepository _qlTrainingsRepository;

        public QLTrainingsController(IQLTrainingsRepository qlTrainingsRepository, ILogger<QLTrainingsController> logger)
        {
            _logger = logger;
            _qlTrainingsRepository = qlTrainingsRepository;
        }

        [HttpPost("RegisterTraining")]
        public async Task<IActionResult> RegisterTraining([FromBody] QLRegisterTrainingDTO model)
        {
            if (model == null)
            {
                return BadRequest("Invalid details.");
            }

            var exists = await _qlTrainingsRepository.TrainingAlreadyRegistered(model);

            if (exists)
            {
                return Conflict($" Training {model.TrainingScheduleId} already registered with Employee {model.EmpId}");
            }

            var result = await _qlTrainingsRepository.RegisterTrainingAsync(model);
            
            return Ok(new { Id = result, Message = $"Training {model.TrainingScheduleId} registered successfully by Employee {model.EmpId}" });
        }

        [HttpPut("CancelRegisterTraining")]
        public async Task<IActionResult> CancelRegisterTraining(Guid trainingId, string empId)
        {
            var result = await _qlTrainingsRepository.CancelRegisterTrainingAsync(trainingId, empId);
            if (result)
            {
                return Ok($" Training Id {trainingId} cancelled successfully.");
            }

            return NotFound($"Training Id {trainingId} not found registered for the employee {empId}.");
        }
        
        [HttpGet("GetTrainingsforRegistration")]
        public async Task<IEnumerable<QLTrainingsDto>> GetTrainingsforRegistration()
        {
            return await _qlTrainingsRepository.GetTrainingsforRegistration();
        }

        [HttpGet("GetMandatoryTrainings")]
        public async Task<IEnumerable<QLTrainingsDto>> GetMandatoryTrainings()
        {
            return await _qlTrainingsRepository.GetMandatoryTrainings();
        }
        [HttpGet("GetRegisteredTrainingsByEmployee")]
        public async Task<IEnumerable<QLTrainingRegistrationDto>> GetRegisteredTrainingsByEmployee(string employeeId)
        {
            return await _qlTrainingsRepository.GetRegisteredTrainingsByEmployee(employeeId);
        }

        [HttpPut("MarkAttendance")]
        public async Task<IEnumerable<AttendanceResultDto>> MarkAttendance(List<MarkAttendance> empIds)
        {
            return await _qlTrainingsRepository.MarkAttendanceAsync(empIds);
        }

        [HttpGet("CompletedTrainings")]
        public async Task<IEnumerable<CompletedTrainingsDTO>> CompletedTrainings()
        {
            return await _qlTrainingsRepository.CompletedTrainings();
        }

        [HttpGet("UpcomingTrainings")]
        public async Task<IEnumerable<UpcomingTrainingsDTO>> UpcomingTrainings()
        {
            return await _qlTrainingsRepository.UpcomingTrainings();
        }

        [HttpPost("FilterTraining")]
        public async Task<IEnumerable<QLTrainingsDto>> FilterTraining(FilterRequest filterRequest)
        {
            return await _qlTrainingsRepository.FilterTraining(filterRequest);
        }

        [HttpGet("GetEmployeesRegisteredToTraining")]
        public async Task<IEnumerable<EmployeesRegisteredToTraining>> GetEmployeesRegisteredToTraining(Guid trainingId)
        {
            return await _qlTrainingsRepository.GetEmployeesRegisteredToTraining(trainingId);
        }
    }
}
