using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using QL.Infra.Repository.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IEmployeeWFHRequest _empWFHRequest;

        public UsersController(IEmployeeWFHRequest empWFHRequest, ILogger<UsersController> logger)
        {
            _logger = logger;
            _empWFHRequest = empWFHRequest;
        }
        [HttpGet]
        public string Get()
        {
            return "Welcome to User World";
        }
        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<IEnumerable<QLEmployee>>> GetAllEmployees()
        {
            var lstqLEmployees  = await _empWFHRequest.GetAllEmployees();
            if (lstqLEmployees == null)
            {
                return NotFound();
            }

            return Ok(lstqLEmployees);
        }

        [HttpGet("getAllRequests")]
        public async Task<IEnumerable<RequestsDto>> GetAllRequests()
        {
            return await _empWFHRequest.GetAllRequestDetails();
        }

        [HttpGet("getAllRequestsByProjectId")]
        public async Task<ActionResult<IEnumerable<RequestsDto>>> GetAllRequestsByProjectId(string projectId)
        {

            var lstRequestsByProject =  await _empWFHRequest.GetAllRequestsByProjectId(projectId);
            if(lstRequestsByProject == null)
            { return Ok("No Records Found"); }
            return Ok(lstRequestsByProject);
        }

        [HttpGet("getAllRequestsByEmployeeId")]
        public async Task<IEnumerable<RequestsDto>> GetAllRequestsByEmployeeId(string employeeId)
        {
            return await _empWFHRequest.GetAllRequestsByEmployeeId(employeeId);
        }

        [HttpPost("saveRequests")]
        public async Task<IEnumerable<RequestsDto>> SaveRequests(WFHRequests request)
        {
            return await _empWFHRequest.SaveRequests(request);
        }

        [HttpGet("GetAppName")]
        public async Task<IActionResult> GetAppName()
        {
            var data = await _empWFHRequest.GetAppName();
            if (data == null) 
            { 
                return Ok("No Records Found");
            }
            return Ok(data);
        }

        [HttpGet("GetRequestType")]
        public async Task<IActionResult> GetRequestType()
        {
            var data = await _empWFHRequest.GetRequestType();
            if (data == null)
            {
                return Ok("No Records Found");
            }
            return Ok(data);
        }

        [HttpGet("GetStatus")]
        public async Task<IActionResult> GetStatus()
        {
            var data = await _empWFHRequest.GetStatus();
            if (data == null)
            {
                return Ok("No Records Found");
            }
            return Ok(data);
        }

        [HttpGet("getAllRequestCountByEmployeeId")]
        public async Task<IEnumerable<RequestCountDto>> GetAllRequestCountByEmployeeId(string employeeId)
        {
            return await _empWFHRequest.GetAllRequestCountByEmployeeId(employeeId);
        }

        [HttpGet("getProjectsByEmployeeId")]
        public async Task<IEnumerable<EmployeeProjectDetails>> GetProjectsByEmployeeId(string employeeId)
        {
            return await _empWFHRequest.GetProjectsByEmployeeId(employeeId);
        }

        [HttpGet("getEmployeeDetailsForProject")]
        public async Task<IEnumerable<ProjectsEmployeeDetailsDto>> GetEmployeeDetailsForProject(string project)
        {
            return await _empWFHRequest.GetEmployeeDetailsForProject(project);
        }

        [HttpPut("updateRequestStatus")]
        public async Task<bool> UpdateRequestStatus(Guid requestid, string status)
        {
            return await _empWFHRequest.UpdateRequestStatus(requestid, status);
        }

        [HttpPost("saveNotifications")]
        public async Task<bool> SaveNotifications(Notifications notification)
        {
            return await _empWFHRequest.SaveNotifications(notification);
        }

        [HttpPut("updateNotification")]
        public async Task<bool> UpdateRequestStatus(Notifications notification)
        {
            return await _empWFHRequest.UpdateNotifications(notification);
        }

        [HttpGet("GetQLIdeaTracker")]
        public async Task<IEnumerable<QLIdeaTrackerDto>> GetQLIdeaTracker(string employeeId)
        {
            return await _empWFHRequest.GetQLIdeaTracker(employeeId);
        }


        [HttpGet("GetQLIdeaDetails")]
        public async Task<IActionResult> GetQLIdeaDetails()
        {
            var data = await _empWFHRequest.GetQLIdeaDetails();
            if (data == null)
            {
                return Ok("No Records Found");
            }
            return Ok(data);
        }

        [HttpGet("getNotificationsByEmployeeId")]
        public async Task<IEnumerable<NotificationsDto>> GetNotificationsByEmployeeId(string employeeId)
        {
            return await _empWFHRequest.GetNotificationsByEmployeeId(employeeId);
        }

        [HttpGet("getCardsByEmployeeId")]
        public async Task<IEnumerable<CardsDto>> GetCardsByEmployeeId(string employeeId)
        {
            return await _empWFHRequest.GetCardsByEmployeeId(employeeId);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            string pattern = @"qentelli.com";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            if (!regex.IsMatch(login.UserName))
            {
                throw new ValidationException("Username is invalid");
            }
            return Ok("Logged in successfully");
        }

        [HttpPost("saveIdeaTracker")]
        public async Task<bool> SaveIdeaTracker(IdeaTracker ideaTracker)
        {
            return await _empWFHRequest.SaveIdeaTracker(ideaTracker);
        }
    }
}
