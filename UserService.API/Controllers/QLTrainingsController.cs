using LMSService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Training;
using QL.Infra.Repository.Repositories;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class QLTrainingsController : ControllerBase
    {
        private readonly ILogger<QLTrainingsController> _logger;
        private IQLTrainingsRepository _qlTrainingsRepository;
        private IEmailSender _emailSender;
        public QLTrainingsController(IQLTrainingsRepository qlTrainingsRepository, ILogger<QLTrainingsController> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _qlTrainingsRepository = qlTrainingsRepository;
            _emailSender = emailSender;
        }

        [HttpPost("RegisterTraining")]
        public async Task<IActionResult> RegisterTraining([FromBody] QLRegisterTrainingDTO model)
        {            
            var exists = await _qlTrainingsRepository.TrainingAlreadyRegistered(model);

            if (exists)
            {
                return BadRequest(new { Message = "Training already registered." });
            }

            var result = await _qlTrainingsRepository.RegisterTrainingAsync(model);
            string ManagerEmailSubject = "Approval Request for Employee Training Program";
            string ApprovalRequestTemplate = "ApprovalRequestTemplate";
            await _emailSender.SendEmailAsync("mohd.majeed@qentelli.com", ManagerEmailSubject, "", ApprovalRequestTemplate);
            return Ok(new { Id = result, Message = $"Training {model.TrainingScheduleId} registered successfully by Employee {model.EmpMail}" });
        }

        [HttpPut("CancelRegisterTraining")]
        public async Task<IActionResult> CancelRegisterTraining(Guid trainingId, string empMail)
        {
            var result = await _qlTrainingsRepository.CancelRegisterTrainingAsync(trainingId, empMail);

            return result switch
            {
                "Training is already cancelled." => BadRequest(new { Message = result }),
                "Training has already started." => BadRequest(new { Message = $"Sorry, {result}" }),
                "Training was not started and has now been cancelled." => Ok(new { Message = $"Training Id {trainingId} cancelled successfully for the employee {empMail}." }),
                _ => NotFound(new { Message = $"Training Id {trainingId} not found registered for the employee {empMail}." })
            };
        }
        
        [HttpGet("GetTrainingsforRegistration")]
        public async Task<IEnumerable<QLTrainingsDto>> GetTrainingsforRegistration()
        {
            return await _qlTrainingsRepository.GetTrainingsforRegistration();
        }

        [HttpGet("GetMandatoryTrainings")]
        public async Task<IEnumerable<QLRegisterTrainingDto>> GetMandatoryTrainings(string? empMail)
        {
            return await _qlTrainingsRepository.GetMandatoryTrainings(empMail);
        }
        [HttpGet("GetRegisteredTrainingsByEmployee")]
        public async Task<IEnumerable<QLTrainingRegistrationDto>> GetRegisteredTrainingsByEmployee(string employeeMail)
        {
            return await _qlTrainingsRepository.GetRegisteredTrainingsByEmployee(employeeMail);
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
        public async Task<IEnumerable<UpcomingTrainingsDTO>> UpcomingTrainings(string? empMail)
        {
            return await _qlTrainingsRepository.UpcomingTrainings(empMail);
        }

        [HttpPost("FilterTraining")]
        public async Task<IEnumerable<FilterResponse>> FilterTraining(FilterRequest filterRequest)
        {
            return await _qlTrainingsRepository.FilterTraining(filterRequest);
        }

        [HttpGet("GetEmployeesRegisteredToTraining")]
        public async Task<IActionResult> GetEmployeesRegisteredToTraining(Guid trainingId)
        {
            var result = await _qlTrainingsRepository.GetEmployeesRegisteredToTraining(trainingId);

            if (!result.Any())
            {
                return NotFound(new { message = $"No employees registered to this training {trainingId}" });
            }

            return Ok(result);
        }

        [HttpGet("OptedTrainings")]
        public async Task<IEnumerable<OptedTrainingsDTO>> OptedTrainings(string employeeMail)
        {
            return await _qlTrainingsRepository.OptedTrainings(employeeMail);
        }

        [HttpPut("ManagerApproval")]
        public async Task<IActionResult> ManagerApproval(Guid trainingScheduleId,string empMail, string? buHeadMail)
        {
            var result = await _qlTrainingsRepository.ManagerApproval(trainingScheduleId,empMail, buHeadMail);
            if (result)
            {
                return Ok(new {message= $" Training Id {trainingScheduleId} is approved by manager." });
            }

            return BadRequest(new {message= $"Training Id {trainingScheduleId} not found." });
        }


        [HttpPut("ManagerReject")]
        public async Task<IActionResult> ManagerReject(Guid trainingScheduleId, string empMail, string? reason)
        {
            var result = await _qlTrainingsRepository.ManagerReject(trainingScheduleId, empMail, reason);
            if (result)
            {
                return Ok($" Training Id {trainingScheduleId} is rejected by manager.");
            }
            return NotFound($"Training Id {trainingScheduleId} not found.");
        }

        [HttpPut("BuHeadApproval")]
        public async Task<IActionResult> BuHeadApproval(Guid trainingScheduleId, string empMail, string? buHeadMail)
        {
            var result = await _qlTrainingsRepository.BuHeadApproval(trainingScheduleId, empMail, buHeadMail);
            if (result)
            {
                return Ok(new { message = $" Training Id {trainingScheduleId} is approved by BuHead." });
            }
            return BadRequest(new { message = $"Training Id {trainingScheduleId} not found." });
        }


        [HttpPut("BuHeadReject")]
        public async Task<IActionResult> BuHeadReject(Guid trainingScheduleId, string empMail, string? buHeadMail, string? reason)
        {
            var result = await _qlTrainingsRepository.BuHeadReject(trainingScheduleId, empMail, buHeadMail, reason);
            if (result)
            {
                return Ok($" Training Id {trainingScheduleId} is rejected by BuHead.");
            }

            return NotFound($"Training Id {trainingScheduleId} not found.");
        }


        [HttpGet("PendingApprovalsForManager")]
        public async Task<IEnumerable<PendingApprovalsDTO>> PendingApprovalsForManager(string managerMail)
        {
            return await _qlTrainingsRepository.PendingApprovalsForManager(managerMail);
        }

        [HttpGet("PendingApprovalsForBUHead")]
        public async Task<IEnumerable<PendingApprovalsDTO>> PendingApprovalsForBUHead()
        {
            return await _qlTrainingsRepository.PendingApprovalsForBUHead();
        }

        [HttpGet("CompletedTrainingsByEmployee")]
        public async Task<IEnumerable<CompletedTrainingsDTO>> CompletedTrainingsByEmployee(string empMail)
        {
            return await _qlTrainingsRepository.CompletedTrainingsByEmployee(empMail);
        }

        //Insert the data into the TrainingAttendanceRecords table 
        [HttpPost("InsertTrainingAttendanceRecords")]
        public async Task<IEnumerable<TrainingAttendanceRecords>> InsertTrainingAttendanceRecords(TrainingAttendanceRecords request)
        {
            return await _qlTrainingsRepository.InsertTrainingAttendanceRecords(request);
        }

        //Updates the Comments and IsAttended records into the TrainingAttendanceRecords table based on EmailAddress and TrainingID 
        [HttpPut("UpdateTrainingAttendanceRecords")]
        public async Task<IEnumerable<TrainingAttendanceRecordsDto>> UpdateTrainingAttendanceRecords(TrainingAttendanceRecordsDto request)
        {
            return await _qlTrainingsRepository.UpdateTrainingAttendanceRecords(request);
        }

        [HttpGet("GetBuHeadDetails")]
        public async Task<IEnumerable<BuHeadDetailDto>> GetBuHeadDetails()
        {
            return await _qlTrainingsRepository.GetBuHeadDetails();
        }

        [HttpGet("GetInbox")]
        public async Task<IActionResult> GetInbox([FromQuery]InboxRequest request)
        {
            if (!request.IsAdmin && !request.IsEmployee && !request.IsManager && !request.IsBUHead)
            {
                return BadRequest(new { message = "At least one role (Admin, Employee, Manager, or BUHead) must be specified." });
            }

            if ((request.IsEmployee && string.IsNullOrEmpty(request.EmpMail)) ||
                (request.IsManager && string.IsNullOrEmpty(request.ManagerEmail)))
            {
                var missingField = request.IsEmployee ? "EmpMail" : "ManagerEmail";
                return BadRequest(new { message = $"Please enter {missingField}" });
            }
            
            var result = await _qlTrainingsRepository.GetInboxAsync(request);

            if (request.IsManager || request.IsBUHead)
            {
                return Ok(new { PendingApprovals = result.UpcomingTrainings });
            }

            return Ok(new { result.UpcomingTrainings, result.FeedbackTrainings });
        }
    }
}
