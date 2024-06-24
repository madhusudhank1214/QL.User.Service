using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using QL.Infra.Repository.Repositories;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            List<RequestsDto> _lstRequestsDto = [];
            return await _empWFHRequest.GetAllRequestDetails();
        }

        [HttpGet("getAllRequestsByProjectId")]
        public async Task<IEnumerable<RequestsDto>> GetAllRequestsByProjectId(string projectId)
        {
            List<RequestsDto> _lstRequestsDto = [];
            return await _empWFHRequest.GetAllRequestsByProjectId(projectId);
        }

        [HttpGet("getAllRequestsByEmployeeId")]
        public async Task<IEnumerable<RequestsDto>> GetAllRequestsByEmployeeId(string employeeId)
        {
            List<RequestsDto> _lstRequestsDto = [];
            return await _empWFHRequest.GetAllRequestsByEmployeeId(employeeId);
        }

        [HttpPost("saveRequests")]
        public async Task<IEnumerable<RequestsDto>> SaveRequests(WFHRequests request)
        {
            List<RequestsDto> _lstRequestsDto = [];
            return await _empWFHRequest.SaveRequests(request);
        }
    }
}
