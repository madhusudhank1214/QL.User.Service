using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using QL.Infra.Repository.Repositories;

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
        public async Task<IEnumerable<QLEmployee>> GetAllEmployees()
        {
            List<QLEmployee> _lstqLEmployees = [];
            return await _empWFHRequest.GetAllEmployees();
        }

        [HttpGet("getAllRequests")]
        public async Task<IEnumerable<RequestsDto>> GetAllRequests()
        {
            return await _empWFHRequest.GetAllRequestDetails();
        }

        [HttpGet("getAllRequestsByProjectId")]
        public async Task<IEnumerable<RequestsDto>> GetAllRequestsByProjectId(string projectId)
        {
            return await _empWFHRequest.GetAllRequestsByProjectId(projectId);
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
    }
}
