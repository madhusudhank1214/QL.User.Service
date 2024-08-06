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
        private IMasterInfomation _masterInfo;

        public UsersController(IEmployeeWFHRequest empWFHRequest, IMasterInfomation masterInfo, ILogger<UsersController> logger)
        {
            _logger = logger;
            _empWFHRequest = empWFHRequest;
            _masterInfo = masterInfo;
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
        

        [HttpGet("getCardsByEmployeeId")]
        public async Task<IEnumerable<CardsDto>> GetCardsByEmployeeId(string employeeId)
        {
            return await _masterInfo.GetCardsByEmployeeId(employeeId);
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

       
        [HttpGet("getEmployeesDetailsForEmployeeId")]
        public async Task<IEnumerable<QLEmployee>> GetEmployeesDetailsForEmployeeId(string employeeId)
        {
            return await _empWFHRequest.GetEmployeesDetailsForEmployeeId(employeeId);
        }
    }

}
